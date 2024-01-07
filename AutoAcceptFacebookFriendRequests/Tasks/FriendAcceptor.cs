using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Models;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendAcceptor : BaseTask
    {
        public FriendAcceptor(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token) { }

        public override async Task Start()
        {
            int currentLoop = 0;

            while (true)
            {
                List<Task> tasks = new List<Task>();

                Accounts = new Queue<FacebookAccountAPI>(Service.MainForm.AccountList);

                for (int _ = 0; _ < Input.MaxThreadCount; _++)
                {
                    Task task = Task.Run(Acceptor);
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

        async Task Acceptor()
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
                int acceptedRequestCount = 0;

                Service.UpdateCookieStatus(GridView, accountAPI, $"Đang chờ...");
                Semaphore.Wait();
                try
                {
                    string friendRequestData = await accountAPI.GetFriendRequestData();
                    int friendRequestCount = accountAPI.GetFriendRequestCount(friendRequestData);

                    while (acceptedRequestCount < Input.MaxAcceptanceLimit)
                    {
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Lấy danh sách lời mời kết bạn");
                        Queue<FriendInfo> friendRequests = new Queue<FriendInfo>(accountAPI.GetFriendRequests(friendRequestData));

                        if (friendRequests.Count < 1)
                        {
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Không có lời mời kết bạn nào.");
                            break;
                        }

                        long endTime = 0;

                        while (friendRequests.Count > 0)
                        {
                            FriendInfo friendRequest = friendRequests.Dequeue();

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

                            Service.UpdateCookieStatus(GridView, accountAPI, $"Chấp nhận kết bạn với {friendRequest.Name}");
                            await accountAPI.AcceptFriendRequest(friendRequest);

                            requestedCount++;
                            acceptedRequestCount++;

                            Service.UpdateRequest(GridView, accountAPI, $"{acceptedRequestCount}/{friendRequestCount}");

                            endTime = TimeUtils.GetTimestamp() + Input.Duration;
                        }
                    }

                    if (acceptedRequestCount > 0)
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");

                    nextAccount = true;
                }
                catch (TaskCanceledException)
                {
                    Service.UpdateCookieStatus(GridView, accountAPI, $"Timeout");
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
