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
            //string cookie = "sb=51wzZYXttzcqQRR6RVljHU4X; datr=51wzZcGm7hDTqaGJDQP6x-Yo; locale=vi_VN; c_user=100095045050896; xs=41%3ANYB3gKIxVzLUaQ%3A2%3A1697864968%3A-1%3A5599; fr=020U8bUoIOOCVDDYr.AWW98Pjzk-taO3sRgoGCWES-oeA.BlM1zn.9q.AAA.0.0.BlM11F.AWXchF_Rpis; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1697865035080%2C%22v%22%3A1%7D; wd=788x931";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
            //string proxy = "";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

            //List<FriendInfo> menbers = accountAPI.GetSuggestedMembers("374465029337889", 10).Result;
            //accountAPI.InviteFriendToGroup("374465029337889", menbers).Wait();

            ////accountAPI.CreatePost("<3\nhttps://thanhnien.vn/me-don-than-chay-grab-nuoi-me-gia-cung-2-con-toi-thich-di-trong-mua-vi-185231020125329655.htm").Wait();

            ////List<FriendInfo> friends = accountAPI.GetFriends(1).Result;
            ////accountAPI.InviteFriendToGroup("416906762405096", friends).Wait();

            ////accountAPI.Unfriend(new FriendInfo("100026251358162", "")).Wait();

            ////List<FriendInfo> friends = accountAPI.GetFriends(100).Result;
            ////foreach (FriendInfo friend in friends)
            ////{
            ////    Console.WriteLine($"{friend.Id} {friend.Name}");
            ////}

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