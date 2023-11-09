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
            //string cookie = "presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1699421921907%2C%22v%22%3A1%7D;fr=19KnfwZOnJLSpXdLY.AWUlci4uCY8xqNTdRBecg1zhAys.BlRmUy.z1.AAA.0.0.BlSx7a.AWWrFwaBJAg;wd=383x317;xs=48%3AUJIoTV1Pbg0plA%3A2%3A1699153770%3A-1%3A4784;m_page_voice=100046488757424;c_user=100046488757424;datr=_W1GZVoRoQmJ1rmjtPktUGw_;sb=La1AZTZa7XyRdbRT7284cycR;";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36";
            //string proxy = "fb2425.proxyfb.com:25745:user25745:0872";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

            //accountAPI.CreatePost("https://www.facebook.com/groups/2568945776603748/posts/2594291997402459").Wait();

            //List<FriendInfo> friends = accountAPI.GetGroupNewMenbers("howkteam").Result;
            //foreach (FriendInfo friend in friends)
            //    Console.WriteLine($"{friend.Name} {friend.Id}");

            //PostInfo? post = accountAPI.GetPost().Result;

            //Console.WriteLine(post == null);

            //accountAPI.DeletePost(post).Wait();

            //List<FriendInfo> menbers = accountAPI.GetSuggestedMembers("374465029337889", 10).Result;
            //accountAPI.InviteFriendToGroup("374465029337889", menbers).Wait();

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