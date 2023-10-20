using AutoAcceptFacebookFriendRequests.Services;
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

        public override Task Start()
        {
            throw new NotImplementedException();
        }
    }
}
