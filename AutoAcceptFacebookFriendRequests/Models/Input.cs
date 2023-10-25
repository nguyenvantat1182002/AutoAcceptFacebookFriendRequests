namespace AutoAcceptFacebookFriendRequests.Models
{
    public class Input
    {
        public int RateLimitDuration { get; set; } = 120;
        public int RateLimit { get; set; } = 10;
        public int Duration { get; set; } = 15;
        public int MaxThreadCount { get; set; } = 5;
        public int MaxAcceptanceLimit { get; set; } = 30;
        public int MaxSuggestionLimit { get; set; } = 30;
        public int MaxDeleteLimit { get; set; } = 30;
        public int MaxInviteCounnt { get; set; } = 30;
        public int RepeatCount { get; set; } = 3;
        public int MaxPostsDelete { get; set; } = 30;
    }
}
