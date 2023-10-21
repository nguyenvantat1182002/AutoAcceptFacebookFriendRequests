using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAcceptFacebookFriendRequests.API.Exeptions
{
    public class GroupIdNotFound : Exception
    {
        public GroupIdNotFound(string groupId) : base($"{groupId} not found") { }
    }
}
