using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.API.Models;
using System.Net;

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
            //string cookie = "sb=ggQ4ZXM6Favk_a5ztSFynOxR; datr=ggQ4ZYzg5okChUOyUHXT4czP; locale=vi_VN; c_user=61550104633344; xs=12%3AWa9JlFirLvxUZQ%3A2%3A1698170069%3A-1%3A7656; fr=0bUbuOgYHqsg25eDS.AWXamHHElqjlHLsraVMgL8YB5-A.BlOASC.ws.AAA.0.0.BlOATY.AWUSsXTCXz4; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1698170076712%2C%22v%22%3A1%7D; wd=812x931";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
            //string proxy = "";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

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