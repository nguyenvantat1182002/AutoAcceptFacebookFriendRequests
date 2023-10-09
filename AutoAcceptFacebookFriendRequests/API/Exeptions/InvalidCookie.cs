using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAcceptFacebookFriendRequests.API.Exeptions
{
    public class InvalidCookie : Exception
    {
        public InvalidCookie() : base("Invalid cookie.") { }
    }
}
