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

        public void AddCookie(string cookie, string? proxy = null)
        {
            string agent = FileUtil.RandomChoice($"{Directory.GetCurrentDirectory()}\\user_agents.txt");
            if (string.IsNullOrWhiteSpace(agent))
                throw new Exception("Vui lòng thêm User-Agent(s).");

            MainForm.AccountList.Add(new FacebookAccountAPI(cookie, agent, proxy));

            int index = MainForm.CookieGridView.Rows.Add(new object[] {0, cookie});
            MainForm.CookieGridView.Rows[index].Cells[0].Value = MainForm.CookieGridView.RowCount;
            MainForm.CookieGridView.Rows[index].Cells[3].Value = proxy ?? "";
        }
    }
}
