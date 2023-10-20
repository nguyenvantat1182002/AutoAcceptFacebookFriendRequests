using AutoAcceptFacebookFriendRequests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAcceptFacebookFriendRequests.Tasks
{
    public class GroupInviter : BaseTask
    {
        public GroupInviter(MainFormService service, DataGridView gridView, CancellationToken token) : base(service, gridView, token)
        {

        }

        public override Task Start()
        {
            throw new NotImplementedException();
        }
    }
}
