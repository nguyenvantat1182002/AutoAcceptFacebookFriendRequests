using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Services
{
    public class MainFormService
    {
        public MainForm MainForm { get; }

        public MainFormService(MainForm mainForm)
        {
            MainForm = mainForm;
        }

        public void AddCookie(string cookie, string proxy)
        {
            string agent = FileUtils.RandomChoice($"{Directory.GetCurrentDirectory()}\\user_agents.txt");
            if (string.IsNullOrWhiteSpace(agent))
                throw new Exception("Vui lòng thêm User-Agent(s).");

            MainForm.AccountList.Add(new FacebookAccountAPI(cookie, agent, proxy));

            int index = MainForm.CookieGridView.Rows.Add(new object[] {0, cookie});
            MainForm.CookieGridView.Rows[index].Cells[0].Value = MainForm.CookieGridView.RowCount;
            MainForm.CookieGridView.Rows[index].Cells[3].Value = proxy ?? "";
        }

        public void UpdateCookieStatus(FacebookAccountAPI account, string status)
        {
            int index = MainForm.AccountList.IndexOf(account);
            MainForm.CookieGridView.Rows[index].Cells[4].Value = status;
        }

        public void UpdateFriendRequests(FacebookAccountAPI account, int requests)
        {
            int index = MainForm.AccountList.IndexOf(account);
            MainForm.CookieGridView.Rows[index].Cells[2].Value = requests;
        }
    }
}
