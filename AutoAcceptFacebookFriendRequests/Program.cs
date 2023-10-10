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
            //string cookie = "sb=5JYeZa0wswmnb5tdem1zOHt1; datr=5JYeZc_SsK68sn679x-0P2Gl; locale=en_GB; c_user=100076442166779; m_page_voice=100076442166779; xs=39%3ANk_VVYb-JuShkQ%3A2%3A1696503549%3A-1%3A4101%3A%3AAcW9TmTjXTbVw6GPFb1a-FQYTF-TJp7M_yK2sj3vrqw; fr=0BukD02cfjAeR2hXT.AWXlJdB8VQgX6_hGtz70zzEqVgY.BlJKjz.uO.AAA.0.0.BlJNtx.AWUeeSbpctQ; m_ls=%7B%22c%22%3A%7B%221%22%3A%22HCwAABaSJxb0mJa7BxMFFvaXycybwS0A%22%2C%222%22%3A%22GSwVQBxMAAAWCBaO3PTRDBYAABV-HEwAABYAFo7c9NEMFgAAFigA%22%2C%2295%22%3A%22HCwAABYYFuTs9uIHEwUW9pfJzJvBLQA%22%7D%2C%22d%22%3A%220cf9a671-227c-42bc-a24c-4e11033f491a%22%2C%22s%22%3A%221%22%2C%22u%22%3A%22chaago%22%7D; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1696914353450%2C%22v%22%3A1%7D; wd=1365x963";
            //string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/117.0.0.0 Safari/537.36";
            //string proxy = "fb3111.proxyfb.com:11729:user11729:C758";

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