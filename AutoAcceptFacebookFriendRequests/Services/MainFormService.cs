using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Utils;

namespace AutoAcceptFacebookFriendRequests.Services
{
    public class MainFormService
    {
        public MainForm MainForm { get; }

        public List<DataGridView> GridViews { get; }

        public MainFormService(MainForm mainForm)
        {
            MainForm = mainForm;
            GridViews = new List<DataGridView>();

            GridViews.Add(MainForm.CookieGridView1);
            GridViews.Add(MainForm.CookieGridView2);
            GridViews.Add(MainForm.CookieGridView3);
        }

        public void AddCookie(string cookie, string proxy)
        {
            string agent = FileUtils.RandomChoice($"{Directory.GetCurrentDirectory()}\\user_agents.txt");
            if (string.IsNullOrWhiteSpace(agent))
                throw new Exception("Vui lòng thêm User-Agent(s).");

            MainForm.AccountList.Add(new FacebookAccountAPI(cookie, agent, proxy));

            foreach (DataGridView item in GridViews)
            {
                int index = item.Rows.Add(new object[] {0, cookie});
                item.Rows[index].Cells[0].Value = item.RowCount;
                item.Rows[index].Cells[2].Value = proxy ?? "";
            }
        }

        public void UpdateCookieStatus(DataGridView gridView, FacebookAccountAPI account, string status)
        {
            int index = MainForm.AccountList.IndexOf(account);

            gridView.Invoke(new Action(() =>
            {
                gridView.Rows[index].Cells[4].Value = status;
            }));
        }

        public void UpdateRequest(DataGridView gridView, FacebookAccountAPI account, int value)
        {
            int index = MainForm.AccountList.IndexOf(account);

            gridView.Invoke(new Action(() =>
            {
                gridView.Rows[index].Cells[3].Value = value;
            }));
        }
    }
}
