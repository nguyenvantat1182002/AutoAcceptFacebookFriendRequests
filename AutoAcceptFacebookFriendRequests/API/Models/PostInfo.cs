namespace AutoAcceptFacebookFriendRequests.API.Models
{
    public class PostInfo
    {
        public string Id { get; }
        public string Hash { get; }

        public PostInfo(string id, string hash)
        {
            Id = id;
            Hash = hash;
        }
    }
}
