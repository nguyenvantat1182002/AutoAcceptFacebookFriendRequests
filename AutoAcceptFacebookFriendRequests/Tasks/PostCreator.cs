using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class PostCreator : BaseTask
    {
        public PostCreator(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
        }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Creator);
                tasks.Add(task);

                await Task.Delay(5000);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Creator()
        {
            DateTime coolDownTime = DateTime.Now;

            while (true)
            {
                FacebookAccountAPI accountAPI;

                lock (LockObject)
                {
                    if (Accounts.Count < 1)
                        break;

                    accountAPI = Accounts.Dequeue();
                }

                while (true)
                {
                    if (DateTime.Now > coolDownTime)
                        break;

                    TimeSpan remainningTime = coolDownTime - DateTime.Now;
                    Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ thực hiện sau 0:{remainningTime.Minutes}:{remainningTime.Seconds}");

                    if (Token.IsCancellationRequested)
                        return;
                }

                Service.UpdateCookieStatus(GridView, accountAPI, $"Đang tạo bài viết...");
                Semaphore.Wait();
                try
                {
                    string content = Service.GetPostContent();
                    string link = Service.GetLink();

                    await accountAPI.CreatePost(content, link);

                    Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");

                    Token.ThrowIfCancellationRequested();
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

                    coolDownTime = DateTime.Now.AddSeconds(Input.Duration);

                    Semaphore.Release();
                }
            }
        }
    }
}
