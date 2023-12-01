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
    }
}