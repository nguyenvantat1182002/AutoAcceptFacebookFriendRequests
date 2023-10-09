namespace AutoAcceptFacebookFriendRequests.Models
{
    public class Input
    {
        public int RateLimitDuration { get; set; } = 120;
        public int RateLimit { get; set; } = 10;
        public int Duration { get; set; } = 15;
        public int MaxThreadCount { get; set; } = 5;
    }
}
