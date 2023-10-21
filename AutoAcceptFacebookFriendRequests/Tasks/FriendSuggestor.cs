using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendSuggestor : BaseTask
    {
        public FriendSuggestor(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token) { }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Suggestor);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Suggestor()
        {
            while (true)
            {
                FacebookAccountAPI accountAPI;

                lock (LockObject)
                {
                    if (Accounts.Count < 1)
                        break;

                    accountAPI = Accounts.Dequeue();
                }

                int requestedCount = 0;
                int suggestionCount = 0;

                try
                {
                    while (suggestionCount < Input.MaxSuggestionLimit)
                    {
                        Queue<FriendInfo> suggestionFriends = new Queue<FriendInfo>(await accountAPI.GetSuggestionFriends(Input.MaxSuggestionLimit));

                        if (suggestionFriends.Count < 1)
                        {
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Không có gợi ý nào");
                            break;
                        }

                        long endTime = 0;

                        while (suggestionFriends.Count > 0)
                        {
                            FriendInfo suggestionFriend = suggestionFriends.Dequeue();

                            while (true)
                            {
                                if (TimeUtils.GetTimestamp() > endTime)
                                    break;

                                int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                                string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                                Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ tiếp tục sau {formattedTime}");

                                await Task.Delay(1000, Token);
                            }

                            if (requestedCount >= Input.RateLimit)
                            {
                                endTime = TimeUtils.GetTimestamp() + Input.RateLimitDuration;

                                while (true)
                                {
                                    if (TimeUtils.GetTimestamp() > endTime)
                                        break;

                                    int remainningTime = (int)(endTime - TimeUtils.GetTimestamp());
                                    string formattedTime = TimeUtils.SecondsToFormattedTime(remainningTime);

                                    Service.UpdateCookieStatus(GridView, accountAPI, $"Tạm dừng, sẽ tiếp tục sau {formattedTime}");

                                    await Task.Delay(1000, Token);
                                }

                                requestedCount = 0;
                            }

                            Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ kết bạn với {suggestionFriend.Name}");
                            await accountAPI.AddFriend(suggestionFriend);

                            requestedCount++;
                            suggestionCount++;

                            Service.UpdateRequest(GridView, accountAPI, suggestionCount);

                            endTime = TimeUtils.GetTimestamp() + Input.Duration;
                        }
                    }

                    if (suggestionCount > 0)
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");
                }
                catch (Exception ex)
                {
                    if (ex is TaskCanceledException || ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            accountAPI.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                        {
                            accountAPI.State.IsCheckpointed = true;
                            Service.UpdateCookieStatus(GridView, accountAPI, ex.Message);
                        }

                        break;
                    }
                    else
                        Service.UpdateCookieStatus(GridView, accountAPI, ex.Message);
                }
                finally
                {
                    if (accountAPI.State.IsInvalidCookie)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Invalid cookie.");

                    if (Token.IsCancellationRequested)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Đã dừng.");
                }
            }
        }
    }
}
