using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;

namespace AutoAcceptFacebookFriendRequests
{
    public partial class MainForm : MaterialForm
    {
        public List<FacebookAccountAPI> AccountList { get; }

        public MainFormService Service { get; }

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue800, Accent.Blue100, TextShade.WHITE);

            AccountList = new List<FacebookAccountAPI>();
            Service = new MainFormService(this);
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            string selectedFilePath;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text documents (*.txt)|*.txt";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                selectedFilePath = openFileDialog.FileName;
            }

            if (AccountList.Count > 0)
                AccountList.Clear();

            if (CookieGridView.RowCount > 0)
                CookieGridView.Rows.Clear();

            try
            {
                foreach (string line in FileUtil.ReadLines(selectedFilePath))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] parts = line.Split('|');
                    string proxy = parts[0];
                    string cookie = parts[1];

                    Service.AddCookie(cookie, proxy);
                }

                CookieGridView.Columns[1].HeaderText = $"Cookie [{CookieGridView.RowCount}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        text: ex.Message,
                        caption: "Thông báo",
                        buttons: MessageBoxButtons.OK,
                        icon: MessageBoxIcon.Error
                    );
            }
        }

        private void addUserAgentButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"{Directory.GetCurrentDirectory()}\\user_agents.txt");
        }

        private void addProxyButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"{Directory.GetCurrentDirectory()}\\proxies.txt");
        }
    }
}