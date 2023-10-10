namespace AutoAcceptFacebookFriendRequests
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string cookie = "";
            //string userAgent = "";
            //string proxy = "";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

            //List<FriendInfo> friends = accountAPI.GetFriendRequests().Result;
            //foreach (FriendInfo friend in friends)
            //    Console.WriteLine($"{friend.Id} {friend.Name}");

            //accountAPI.Dispose();

            string[] files = new string[] { "user_agents.txt" };
            foreach (string file in files)
            {
                if (!File.Exists(file))
                    using (File.Create(file)) { }
            }

            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}