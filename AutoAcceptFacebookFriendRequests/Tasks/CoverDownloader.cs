using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class CoverDownloader : BaseTask
    {
        public CoverDownloader(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {
        }

        public override async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < Input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Downloader);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Downloader()
        {
            while (true)
            {
                FacebookAccountAPI api;

                lock (LockObject)
                {
                    if (Accounts.Count < 1)
                        return;

                    api = Accounts.Dequeue();
                }

                Service.UpdateCookieStatus(GridView, api, $"Đang tải ảnh bìa...");
                Semaphore.Wait();
                try
                {
                    bool success = await api.DownloadCover();
                    if (success)
                        Service.UpdateRequest(GridView, api, "1");

                    Service.UpdateCookieStatus(GridView, api, $"Hoàn thành");
                }
                catch (TaskCanceledException)
                {
                    Service.UpdateCookieStatus(GridView, api, $"Timeout");
                }
                catch (Exception ex)
                {
                    if (ex is InvalidCookie || ex is AccountCheckpointed)
                    {
                        if (ex is InvalidCookie)
                            api.State.IsInvalidCookie = true;

                        if (ex is AccountCheckpointed)
                            api.State.IsCheckpointed = true;
                    }
                    else if (ex is OperationCanceledException)
                        break;
                    else
                        Service.UpdateCookieStatus(GridView, api, ex.Message);
                }
                finally
                {
                    if (api.State.IsCheckpointed)
                        Service.UpdateCookieStatus(GridView, api, "Checkpoint");

                    if (api.State.IsInvalidCookie)
                        Service.UpdateCookieStatus(GridView, api, "Invalid cookie.");

                    if (Token.IsCancellationRequested)
                        Service.UpdateCookieStatus(GridView, api, "Đã dừng.");

                    Semaphore.Release();
                }
            }
        }
    }
}
