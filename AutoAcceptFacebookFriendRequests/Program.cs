using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;

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
            //string cookie = "sb=PB8yZWkL2anb0ZrS2Q1FRIge; datr=PB8yZWtGu9U3pleBKYiJPCxD; locale=vi_VN; c_user=61550104633344; xs=6%3AObYLYen9n1Fzeg%3A2%3A1697783659%3A-1%3A7656; m_page_voice=61550104633344; wd=788x931; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1697784116111%2C%22v%22%3A1%7D; fr=0AnwTSDScgNKEaxlG.AWW0ikqEpyISUbk8wN3RfaYNv3A.BlMh88.iU.AAA.0.0.BlMiFN.AWWzKRbnNqw";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
            //string proxy = "";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

            //accountAPI.CreatePost("<3\nhttps://thanhnien.vn/me-don-than-chay-grab-nuoi-me-gia-cung-2-con-toi-thich-di-trong-mua-vi-185231020125329655.htm").Wait();

            //List<FriendInfo> friends = accountAPI.GetFriends(1).Result;
            //accountAPI.InviteFriendToGroup("416906762405096", friends).Wait();

            //accountAPI.Unfriend(new FriendInfo("100026251358162", "")).Wait();

            //List<FriendInfo> friends = accountAPI.GetFriends(100).Result;
            //foreach (FriendInfo friend in friends)
            //{
            //    Console.WriteLine($"{friend.Id} {friend.Name}");
            //}

            //accountAPI.Dispose();

            string[] files = new string[] { "user_agents.txt" };
            foreach (string file in files)
            {
                if (!File.Exists(file))
                    using (File.Create(file)) { }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}