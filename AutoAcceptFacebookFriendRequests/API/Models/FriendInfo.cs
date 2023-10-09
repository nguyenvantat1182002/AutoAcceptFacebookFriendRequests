namespace AutoAcceptFacebookFriendRequests.API.Model
{
    public class FriendInfo
    {
        public string Id { get; }
        public string Name { get; }

        public FriendInfo(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}