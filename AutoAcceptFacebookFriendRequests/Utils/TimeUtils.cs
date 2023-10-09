namespace AutoAcceptFacebookFriendRequests.Utils
{
    public class TimeUtils
    {
        public static string SecondsToFormattedTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        public static long GetTimestamp() => DateTimeOffset.Now.ToUnixTimeSeconds();
    }
}
