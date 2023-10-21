using AutoAcceptFacebookFriendRequests.API.Exeptions;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        private async Task Creator()
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
                    Service.UpdateCookieStatus(GridView, accountAPI, $"Đang tạo bài viết...");

                    string content = Service.GetPostContent();

                    await accountAPI.CreatePost(content);

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
