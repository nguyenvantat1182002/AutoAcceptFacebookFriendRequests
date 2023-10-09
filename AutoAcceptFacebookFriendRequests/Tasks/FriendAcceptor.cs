using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class FriendAcceptor
    {
        private Queue<FacebookAccountAPI> _accountList;
        private Input _input;
        private CancellationToken _token;

        private object _lockObject = new object();

        public FriendAcceptor(CancellationToken token)
        {
            _accountList = new Queue<FacebookAccountAPI>(MainForm.Instance!.AccountList);
            _input = MainForm.Instance!.Input;
            _token = token;
        }

        public async Task Start()
        {
            List<Task> tasks = new List<Task>();

            for (int _ = 0; _ < _input.MaxThreadCount; _++)
            {
                Task task = Task.Run(Acceptor);
                tasks.Add(task);

                await Task.Delay(100);
            }

            await Task.WhenAll(tasks);
        }

        async Task Acceptor()
        {
            int requests = 0;

            while (_accountList.Count > 0)
            {
                FacebookAccountAPI accountAPI;
                lock (_lockObject)
                    accountAPI = _accountList.Dequeue();


            }
        }
    }
}
