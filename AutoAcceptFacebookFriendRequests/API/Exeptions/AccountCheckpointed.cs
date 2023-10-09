namespace AutoAcceptFacebookFriendRequests.API.Exeptions
{
    public class AccountCheckpointed : Exception
    {
        public AccountCheckpointed(string message) : base(message) { }
    }
}
