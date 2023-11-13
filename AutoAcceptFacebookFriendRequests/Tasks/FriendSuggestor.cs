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
            int currentLoop = 0;

            while (true)
            {
                List<Task> tasks = new List<Task>();

                Accounts = new Queue<FacebookAccountAPI>(Service.MainForm.AccountList);

                for (int _ = 0; _ < Input.MaxThreadCount; _++)
                {
                    Task task = Task.Run(Suggestor);
                    tasks.Add(task);

                    await Task.Delay(5000);
                }

                await Task.WhenAll(tasks);

                if (!Service.IsRepeat)
                    break;

                if (currentLoop >= Service.RepeatCount)
                    break;

                currentLoop++;
            }
        }

        private async Task Suggestor()
        {
            FacebookAccountAPI accountAPI = null!;

            bool nextAccount = true;

            while (true)
            {
                if (nextAccount)
                {
                    lock (LockObject)
                    {
                        if (Accounts.Count < 1)
                            break;

                        accountAPI = Accounts.Dequeue();
                    }

                    nextAccount = false;
                }

                int requestedCount = 0;
                int suggestionCount = 0;

                Service.UpdateCookieStatus(GridView, accountAPI, $"Đang chờ...");
                Semaphore.Wait();
                try
                {
                    while (suggestionCount < Input.MaxSuggestionLimit)
                    {
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Lấy danh sách gợi ý kết bạn");
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
                    nextAccount = true;
                }
                catch (Exception ex)
                {
                    if (ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            accountAPI.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                            accountAPI.State.IsCheckpointed = true;

                        nextAccount = true;
                    }
                    else if (ex is TaskCanceledException)
                        break;
                    else
                        Service.UpdateCookieStatus(GridView, accountAPI, ex.Message);
                }
                finally
                {
                    if (accountAPI.State.IsCheckpointed)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Checkpoint");

                    if (accountAPI.State.IsInvalidCookie)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Invalid cookie.");

                    if (Token.IsCancellationRequested)
                        Service.UpdateCookieStatus(GridView, accountAPI, "Đã dừng.");

                    Semaphore.Release();
                }
            }
        }
    }
}
