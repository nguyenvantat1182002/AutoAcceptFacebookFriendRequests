using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendDeleter : BaseTask
    {
        public FriendDeleter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token) { }

        public override async Task Start()
        {
            int currentLoop = 0;

            while (true)
            {
                List<Task> tasks = new List<Task>();

                for (int _ = 0; _ < Input.MaxThreadCount; _++)
                {
                    Task task = Task.Run(Deleter);
                    tasks.Add(task);

                    await Task.Delay(100);
                }

                await Task.WhenAll(tasks);

                if (!Service.IsRepeat)
                    break;

                if (currentLoop >= Service.RepeatCount)
                    break;

                currentLoop++;
            }
        }

        public async Task Deleter()
        {
            while (Accounts.Count > 0)
            {
                FacebookAccountAPI accountAPI;

                lock (LockObject)
                {
                    if (Accounts.Count < 1)
                        break;

                    accountAPI = Accounts.Dequeue();
                }

                int requestedCount = 0;
                int deletedCount = 0;

                try
                {
                    while (deletedCount < Input.MaxDeleteLimit)
                    {
                        Queue<FriendInfo> friends = new Queue<FriendInfo>(await accountAPI.GetFriends(Input.MaxDeleteLimit));

                        if (friends.Count < 1)
                        {
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Không còn bạn bè nào.");
                            break;
                        }

                        long endTime = 0;

                        while (friends.Count > 0)
                        {
                            FriendInfo friend = friends.Dequeue();

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

                            Service.UpdateCookieStatus(GridView, accountAPI, $"Xóa kết bạn với {friend.Name}");
                            await accountAPI.Unfriend(friend);

                            requestedCount++;
                            deletedCount++;

                            Service.UpdateRequest(GridView, accountAPI, deletedCount);

                            endTime = TimeUtils.GetTimestamp() + Input.Duration;
                        }
                    }

                    if (deletedCount > 0)
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
