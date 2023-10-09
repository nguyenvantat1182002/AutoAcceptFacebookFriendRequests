using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Models;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Tasks;
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
        public Input Input { get; }

        public static MainForm? Instance { get; set; }

        private CancellationTokenSource? _tokenSource = null;

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue800, Accent.Blue100, TextShade.WHITE);

            AccountList = new List<FacebookAccountAPI>();
            Service = new MainFormService(this);
            Input = new Input();
            Instance = this;
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
                foreach (string line in FileUtils.ReadLines(selectedFilePath))
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

        private void rateLimitDuration_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(rateLimitDuration.Text, out int result);

            Input.RateLimitDuration = result < 1 ? 120 : result;

            rateLimitDuration.Text = Input.RateLimitDuration.ToString();
        }

        private void rateLimit_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(rateLimit.Text, out int result);

            Input.RateLimit = result < 1 ? 10 : result;

            rateLimit.Text = Input.RateLimit.ToString();
        }

        private void duration_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(duration.Text, out int result);

            Input.Duration = result < 1 ? 15 : result;

            duration.Text = Input.Duration.ToString();
        }

        private void maxThreadCount_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxThreadCount.Text, out int result);

            Input.MaxThreadCount = result < 1 ? 5 : result;

            maxThreadCount.Text = Input.MaxThreadCount.ToString();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            FriendAcceptor acceptor = new FriendAcceptor(_tokenSource.Token);
            await Task.Run(acceptor.Start);

            startButton.Enabled = true;
            stopButton.Enabled = false;

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoành thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Text = "Stop...";
            _tokenSource!.Cancel();
        }
    }
}