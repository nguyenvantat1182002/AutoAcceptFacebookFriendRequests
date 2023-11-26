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

                Accounts = new Queue<FacebookAccountAPI>(Service.MainForm.AccountList);

                for (int _ = 0; _ < Input.MaxThreadCount; _++)
                {
                    Task task = Task.Run(Deleter);
                    tasks.Add(task);

                    await Task.Delay(800);
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
            FacebookAccountAPI accountAPI = null!;

            bool nextAccount = true;

            while (Accounts.Count > 0)
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
                int deletedCount = 0;

                Service.UpdateCookieStatus(GridView, accountAPI, $"Đang chờ...");
                Semaphore.Wait();
                try
                {
                    while (deletedCount < Input.MaxDeleteLimit)
                    {
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Đang lấy danh sách bạn bè");
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

                                Token.ThrowIfCancellationRequested();

                                await Task.Delay(1000);
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

                                    Token.ThrowIfCancellationRequested();

                                    await Task.Delay(1000);
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

                    nextAccount = true;

                    if (deletedCount > 0)
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");

                }
                catch (TaskCanceledException)
                {
                    nextAccount = true;
                    Service.UpdateCookieStatus(GridView, accountAPI, $"Timeout");
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
                    else if (ex is OperationCanceledException)
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
