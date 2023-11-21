using AutoAcceptFacebookFriendRequests.API;

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
            //string cookie = "locale=en_US; c_user=100077352290246; datr=Tx9JZT34ltluxXjHvXAoxqga; sb=Tx9JZeJ91FA2TvoHhbZgA1-N; m_page_voice=100077352290246; xs=24%3AB4UiIDqcstXfYg%3A2%3A1700536658%3A-1%3A4276%3A%3AAcXOh9CYeXCxgtFMRuMT1XOYREmrVQ1CTQbm_Q8yeA; fr=1UK979MPWFCxSd8uW.AWUWLL-2fIFUaOckjtfXj2tUFPg.BlVjBv.ro.AAA.0.0.BlXEZF.AWWLmz17uZ8; wd=1078x953; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1700546080432%2C%22v%22%3A1%7D; m_pixel_ratio=1; datr=Tx9JZT34ltluxXjHvXAoxqga; c_user=100077352290246; xs=24%3AB4UiIDqcstXfYg%3A2%3A1700536658%3A-1%3A4276%3A%3AAcXRooywm2RTI0VnUINU_xZztBkXIDduEfiJchdIqw; fr=1Lr8LkqptlOoQApPM.AWVxAyICpBZ3bWzD8824VyKMWkQ.BlXEoB.ro.AAA.0.0.BlXEoB.AWXLH5RsUPY; wd=1061x953; x-referer=eyJyIjoiLz9zb2Z0PWNvbXBvc2VyIiwiaCI6Ii8%2Fc29mdD1jb21wb3NlciIsInMiOiJtIn0%3D";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36";
            //string proxy = "139.84.169.136:10949:lev10949:JHitE";

            //FacebookAccountAPI api = new FacebookAccountAPI(cookie, userAgent, proxy);

            //api.CreatePost("", "https://www.facebook.com/hoifancuongonepiece/posts/767920548477980").Wait();

            //api.Dispose();

            //List<FriendInfo> friends = accountAPI.GetGroupNewMenbers("1053510842501893").Result;
            //foreach (FriendInfo friend in friends)
            //    Console.WriteLine($"{friend.Id} {friend.Name}");

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