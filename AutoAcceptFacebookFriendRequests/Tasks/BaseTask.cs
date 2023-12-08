using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Models;
using AutoAcceptFacebookFriendRequests.Services;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public abstract class BaseTask
    {
        protected MainFormService Service { get; }
        protected DataGridView GridView { get; }
        protected CancellationToken Token { get; }
        protected Queue<FacebookAccountAPI> Accounts { get; set; }
        protected object LockObject { get; }
        protected Input Input { get; }
        protected SemaphoreSlim Semaphore { get; }

        protected BaseTask(MainFormService service, DataGridView gridView, CancellationToken token)
        {
            Service = service;
            GridView = gridView;
            Token = token;
            Accounts = new Queue<FacebookAccountAPI>(Service.MainForm.AccountList);
            LockObject = new object();
            Input = Service.MainForm.Input;
            Semaphore = new SemaphoreSlim(1000, 1000);
        }

        public abstract Task Start();
    }
}
