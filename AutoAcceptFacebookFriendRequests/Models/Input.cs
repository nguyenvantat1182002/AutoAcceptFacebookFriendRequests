namespace AutoAcceptFacebookFriendRequests.Models
{
    public class Input
    {
        public int RateLimitDuration { get; set; }
        public int RateLimit { get; set; }
        public int Duration { get; set; }
        public int MaxThreadCount { get; set; } 
    }
}
