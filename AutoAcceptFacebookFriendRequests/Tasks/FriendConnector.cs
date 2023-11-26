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
            int currentLoop = 0;

            while (true)
            {
                List<Task> tasks = new List<Task>();

                Accounts = new Queue<FacebookAccountAPI>(Service.MainForm.AccountList);

                for (int _ = 0; _ < Input.MaxThreadCount; _++)
                {
                    Task task = Task.Run(Connector);
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
                    string[] userIdArr = Service.GetUserIds(Service.MainForm.materialMultiLineTextBox23);

                    // Shuffle Array
                    Random random = new Random();
                    for (int i = userIdArr.Length - 1; i > 0; i--)
                    {
                        int j = random.Next(0, i + 1);
                        string temp = userIdArr[i];
                        userIdArr[i] = userIdArr[j];
                        userIdArr[j] = temp;
                    }

                    Queue<string> userIds = new Queue<string>(userIdArr);

                    DateTime coolDownTime = DateTime.Now;
                    int requested = 0;
                    int sentCount = 0;

                    foreach (string userId in userIds)
                    {
                        if (sentCount >= Input.MaxRequestLimit)
                            break;

                        while (true)
                        {
                            if (DateTime.Now > coolDownTime)
                                break;

                            TimeSpan remainningTime = coolDownTime - DateTime.Now;
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ tiếp tục sau {remainningTime.Hours}:{remainningTime.Minutes}:{remainningTime.Seconds}");

                            Token.ThrowIfCancellationRequested();

                            await Task.Delay(1000);
                        }

                        if (requested >= Input.RateLimit)
                        {
                            DateTime endTime = DateTime.Now.AddSeconds(Input.RateLimitDuration);

                            while (true)
                            {
                                if (DateTime.Now > endTime)
                                    break;

                                TimeSpan remainningTime = endTime - DateTime.Now;
                                Service.UpdateCookieStatus(GridView, accountAPI, $"Tạm dừng, sẽ tiếp tục sau {remainningTime.Hours}:{remainningTime.Minutes}:{remainningTime.Seconds}");

                                Token.ThrowIfCancellationRequested();

                                await Task.Delay(1000);
                            }

                            requested = 0;
                        }

                        Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ kết bạn với {userId}");
                        FriendInfo friend = new FriendInfo(userId, "");
                        await accountAPI.AddFriend(friend);

                        sentCount++;
                        requested++;

                        Service.UpdateRequest(GridView, accountAPI, sentCount);

                        coolDownTime = DateTime.Now.AddSeconds(Input.Duration);
                    }

                    Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");
                }
                catch (TaskCanceledException)
                {
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
                }
            }
        }
    }
}
