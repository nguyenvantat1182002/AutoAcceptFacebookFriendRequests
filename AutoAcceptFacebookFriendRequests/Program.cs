using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;
using static System.Net.WebRequestMethods;
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
            //string[] files = new string[] { "proxies.txt", "user_agents.txt" };
            //foreach (string file in files)
            //{
            //    if (!File.Exists(file))
            //        using (File.Create(file)) { }
            //}

            //string cookie = "sb=mH4jZYuLORG9A7xNcMRQKxbG; datr=mH4jZZ6ihsOKi8wzCa_H_2v2; c_user=715240575; xs=21%3AJCpWGdWxHrd12g%3A2%3A1696824988%3A-1%3A6147; fr=0x2800WS5oixPEngy.AWXcHG5t2BWoZfcb50GDQHyoFBo.BlI36Y.si.AAA.0.0.BlI36e.AWWfRywtZVo; m_ls=%7B%22c%22%3A%7B%221%22%3A%22HCwAABbOjFAWwuz6twITBRb-0Y2qBQA%22%2C%222%22%3A%22GSwVQBxMAAAWAhbM-pvSDBYAABV-HEwAABYAFsz6m9IMFgAAFigA%22%2C%2295%22%3A%22HCwAABaEGRb69Ib0DxMFFv7RjaoFAA%22%7D%2C%22d%22%3A%221b14dc5d-ba47-46ed-a0e1-542d40adbda2%22%2C%22s%22%3A%221%22%2C%22u%22%3A%22vp0cd2%22%7D; wd=578x931; presence=C%7B%22t3%22%3A%5B%7B%22o%22%3A0%2C%22i%22%3A%22u.100001862302868%22%7D%5D%2C%22utc3%22%3A1696829300661%2C%22v%22%3A1%7D";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36";
            //FacebookAccountAPI accountAPI = new FacebookAccountAPI(cookie, userAgent);

            //List<FriendInfo> friendRequests = accountAPI.GetFriendRequests().Result;
            //foreach (FriendInfo friendInfo in friendRequests)
            //    Console.WriteLine($"{friendInfo.Id} {friendInfo.Name}");
            //Console.WriteLine(friendRequests.Count);

            //accountAPI.AcceptFriendRequest(new FriendInfo("61550104633344", "")).Wait();

            //accountAPI.Dispose();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}