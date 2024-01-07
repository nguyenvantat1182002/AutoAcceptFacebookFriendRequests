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
            //Test().Wait();

            string[] folders = new string[] { "covers" };
            foreach (string folder in folders)
            {
                string folderPath = $"{Directory.GetCurrentDirectory()}\\{folder}";
                if (Directory.Exists(folderPath))
                    continue;
                Directory.CreateDirectory(folderPath);
            }

            string[] files = new string[] { "user_agents.txt" };
            foreach (string file in files)
            {
                string filePath = $"{Directory.GetCurrentDirectory()}\\{file}";
                if (File.Exists(filePath))
                    continue;
                using (File.Create(filePath)) { }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        public static async Task Test()
        {
            string cookie = "sb=tECWZYV1954uLMHQMYKJxl15; datr=tECWZbm3vfrqEFe9m4g10Hxb; c_user=61555291797517; xs=35%3AszXiKi5MEVDn_Q%3A2%3A1704345788%3A-1%3A-1%3A%3AAcXptqlp5XzHgiF3tf2VerF_740CaJdAeACkMPYJYg; wd=951x955; fr=1Pk5wv5epv95jzVJB.AWWnhLtrpWpqI7Etv9exdx89KT0.BlmrCu.HL.AAA.0.0.BlmrPP.AWUJtsi_L0w; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1704637393888%2C%22v%22%3A1%7D";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36";
            string proxy = "";

            FacebookAccountAPI api = new FacebookAccountAPI(cookie, userAgent, proxy);
            await api.CreatePost("Wowow :O", "https://www.facebook.com/61554732011208/posts/pfbid07qHFPLR7qEp4xCwsiFDXntunQvj6HKEwgGj7oThu3Aqoyhrbo6M7htm6W79Rsq85l/?mibextid=hubsqH");
        }
    }
}