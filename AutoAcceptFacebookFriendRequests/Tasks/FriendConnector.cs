using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendConnector : BaseTask
    {
        public FriendConnector(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
        }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Connector);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Connector()
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

                try
                {
                    string[] groupIds = Service.GetGroupIDs(Service.MainForm.materialMultiLineTextBox23);
                    DateTime coolDownTime = DateTime.Now;
                    int requested = 0;
                    int sentCount = 0;

                    foreach (string groupId in groupIds)
                    {
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Lấy danh sách thành viên trong nhóm {groupId}");
                        List<FriendInfo> friendList = await accountAPI.GetGroupNewMenbers(groupId, Input.MaxRequestLimit);
                        foreach (FriendInfo friend in friendList)
                        {
                            while (true)
                            {
                                if (DateTime.Now > coolDownTime)
                                    break;

                                TimeSpan remainningTime = coolDownTime - DateTime.Now;
                                Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ tiếp tục sau {remainningTime.Hours}:{remainningTime.Minutes}:{remainningTime.Seconds}");

                                await Task.Delay(1000, Token);
                            }

                            if (requested >= Input.RateLimit)
                            {
                                DateTime endTime = DateTime.Now.AddSeconds(Input.RateLimitDuration);

                                while (true)
                                {
                                    if (DateTime.Now > endTime)
                                        break;

                                    TimeSpan remainningTime = endTime - DateTime.Now;
                                    Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ tiếp tục sau {remainningTime.Hours}:{remainningTime.Minutes}:{remainningTime.Seconds}");

                                    await Task.Delay(1000, Token);
                                }

                                requested = 0;
                            }

                            Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ kết bạn với {friend.Name}");
                            await accountAPI.AddFriend(friend);

                            Service.UpdateRequest(GridView, accountAPI, ++sentCount);

                            coolDownTime = DateTime.Now.AddSeconds(Input.Duration);

                            requested++;
                        }
                    }

                    Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");
                }
                catch (Exception ex)
                {
                    if (ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            accountAPI.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                            accountAPI.State.IsCheckpointed = true;
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
                }
            }
        }
    }
}
