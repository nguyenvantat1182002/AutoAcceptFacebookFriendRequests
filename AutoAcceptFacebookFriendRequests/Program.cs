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
            //string cookie = "sb=9PIrZa4G_Q8ZS00wBNAhQ7ej; datr=9PIrZQEZb1xaXfe_M0nyhKza; c_user=715240575; m_page_voice=715240575; m_ls=%7B%22c%22%3A%7B%221%22%3A%22HCwAABb8v1IWqNGC-gQTBRb-0Y2qBQA%22%2C%222%22%3A%22GSwVQBxMAAAWbBaKobPUDBYAABV-HEwAABYAFoqhs9QMFgAAFigA%22%2C%2295%22%3A%22HCwAABaQHhaQhviiCBMFFv7RjaoFAA%22%7D%2C%22d%22%3A%2255933d66-ca82-4723-8ed1-adb4202f02a2%22%2C%22s%22%3A%221%22%2C%22u%22%3A%22iv290p%22%7D; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1699511184152%2C%22v%22%3A1%7D; xs=10%3Apt2OVoJPJApOiA%3A2%3A1699274880%3A-1%3A6147%3A%3AAcUsEnjtT8vARlzbaFLHnzayBArPsLm3L3mof1ZzHoM; fr=122eh0ZNPDejTuTuS.AWXxu2xgXgNdZIMDs5ZtKUfSt8I.BlTIlW.w0.AAA.0.0.BlTIlW.AWWrfyOGywc; wd=846x937";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36";
            //string proxy = "";

            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent, proxy);

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