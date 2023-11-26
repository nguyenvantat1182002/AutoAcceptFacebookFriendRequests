using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAcceptFacebookFriendRequests.API.Models;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class PostDeleter : BaseTask
    {
        public PostDeleter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
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

        private async Task Deleter()
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

                int deletedCount = 0;
                int requested = 0;
                DateTime coolDownTime = DateTime.Now;

                Service.UpdateCookieStatus(GridView, accountAPI, $"Đang chờ...");
                Semaphore.Wait();
                try
                {
                    while (deletedCount < Input.MaxPostsDelete)
                    {
                        while (true)
                        {
                            if (DateTime.Now > coolDownTime)
                                break;

                            TimeSpan remainningTime = coolDownTime - DateTime.Now;
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Sẽ thực hiện sau 0:{remainningTime.Minutes}:{remainningTime.Seconds}");

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

                        Service.UpdateCookieStatus(GridView, accountAPI, $"Lấy bài viết...");
                        PostInfo? info = await accountAPI.GetPost();

                        if (info == null)
                        {
                            Service.UpdateCookieStatus(GridView, accountAPI, $"Không có bài viết nào");
                            break;
                        }

                        Service.UpdateCookieStatus(GridView, accountAPI, $"Xóa bài viết {info.Id}");
                        await accountAPI.DeletePost(info);

                        deletedCount++;
                        requested++;

                        Service.UpdateRequest(GridView, accountAPI, deletedCount);

                        coolDownTime = DateTime.Now.AddSeconds(Input.Duration);

                        await Task.Delay(500, Token);
                    }

                    if (deletedCount > 0)
                        Service.UpdateCookieStatus(GridView, accountAPI, $"Hoàn thành");

                    nextAccount = true;
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
