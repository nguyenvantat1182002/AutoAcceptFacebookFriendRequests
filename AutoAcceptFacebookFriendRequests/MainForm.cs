using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.Models;
using AutoAcceptFacebookFriendRequests.Services;
using AutoAcceptFacebookFriendRequests.Tasks;
using AutoAcceptFacebookFriendRequests.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data;
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

            foreach (DataGridView item in Service.GridViews)
            {
                if (item.RowCount > 0)
                    item.Rows.Clear();
            }

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

                foreach (DataGridView item in Service.GridViews)
                    item.Columns[1].HeaderText = $"Cookie [{item.RowCount}]";
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

            Console.WriteLine(duration.Text);

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
            Service.HighlightMainTab(tabPage1, false);

            tabPage3.Enabled = false;
            tabPage4.Enabled = false;

            startButton.Enabled = false;
            stopButton.Enabled = true;

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            FriendAcceptor acceptor = new FriendAcceptor(Service, CookieGridView1, _tokenSource.Token);
            await Task.Run(acceptor.Start);

            startButton.Enabled = true;
            stopButton.Enabled = false;

            stopButton.Text = "Stop";

            Service.HighlightMainTab(tabPage1, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            rateLimitDuration.Text = Input.RateLimitDuration.ToString();
            rateLimit.Text = Input.RateLimit.ToString();
            duration.Text = Input.Duration.ToString();
            maxThreadCount.Text = Input.MaxThreadCount.ToString();
            maxAcceptanceLimit.Text = Input.MaxAcceptanceLimit.ToString();
            maxSuggestionLimit.Text = Input.MaxSuggestionLimit.ToString();
            maxInviteCount.Text = Input.MaxInviteCounnt.ToString();
            repeatCount.Text = Input.RepeatCount.ToString();
        }

        private void maxAcceptanceLimit_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxAcceptanceLimit.Text, out int result);

            Input.MaxAcceptanceLimit = result < 1 ? 5 : result;

            maxAcceptanceLimit.Text = Input.MaxAcceptanceLimit.ToString();
        }

        private async void startButton2_Click(object sender, EventArgs e)
        {
            Service.HighlightMainTab(tabPage3, false);

            startButton2.Enabled = false;
            stopButton2.Enabled = true;

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            FriendSuggestor suggestor = new FriendSuggestor(Service, CookieGridView2, _tokenSource.Token);
            await Task.Run(suggestor.Start);

            startButton2.Enabled = true;
            stopButton2.Enabled = false;

            stopButton2.Text = "Stop";

            Service.HighlightMainTab(tabPage3, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton2_Click(object sender, EventArgs e)
        {
            stopButton2.Text = "Stop...";
            _tokenSource!.Cancel();
        }

        private void MaxSuggestionLimit_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxSuggestionLimit.Text, out int result);

            Input.MaxSuggestionLimit = result < 1 ? 30 : result;

            maxSuggestionLimit.Text = Input.MaxSuggestionLimit.ToString();
        }

        private void maxDeleteLimit_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxDeleteLimit.Text, out int result);

            Input.MaxDeleteLimit = result < 1 ? 30 : result;

            maxDeleteLimit.Text = Input.MaxDeleteLimit.ToString();
        }

        private async void startButton3_Click(object sender, EventArgs e)
        {
            startButton3.Enabled = false;
            stopButton3.Enabled = true;

            Service.HighlightMainTab(tabPage4, false);

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            FriendDeleter deleter = new FriendDeleter(Service, CookieGridView3, _tokenSource.Token);
            await Task.Run(deleter.Start);

            startButton3.Enabled = true;
            stopButton3.Enabled = false;

            stopButton3.Text = "Stop";

            Service.HighlightMainTab(tabPage4, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton3_Click(object sender, EventArgs e)
        {
            stopButton3.Text = "Stop...";
            _tokenSource!.Cancel();
        }

        private async void startButton4_Click(object sender, EventArgs e)
        {
            startButton4.Enabled = false;
            stopButton4.Enabled = true;

            Service.HighlightMainTab(tabPage5, false);

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            GroupInviter inviter = new GroupInviter(Service, CookieGridView4, _tokenSource.Token);
            await Task.Run(inviter.Start);

            startButton4.Enabled = true;
            stopButton4.Enabled = false;

            stopButton4.Text = "Stop";

            Service.HighlightMainTab(tabPage5, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton4_Click(object sender, EventArgs e)
        {
            stopButton4.Text = "Stop...";
            _tokenSource!.Cancel();
        }

        private async void startButton5_Click(object sender, EventArgs e)
        {
            startButton5.Enabled = false;
            stopButton5.Enabled = true;

            Service.HighlightMainTab(tabPage6, false);

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            PostCreator creator = new PostCreator(Service, CookieGridView5, _tokenSource.Token);
            await Task.Run(creator.Start);

            startButton5.Enabled = true;
            stopButton5.Enabled = false;

            stopButton5.Text = "Stop";

            Service.HighlightMainTab(tabPage6, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton5_Click(object sender, EventArgs e)
        {
            stopButton5.Text = "Stop...";
            _tokenSource!.Cancel();
        }

        private void maxInviteCount_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxInviteCount.Text, out int result);

            Input.MaxInviteCounnt = result < 1 ? 30 : result;

            maxInviteCount.Text = Input.MaxInviteCounnt.ToString();
        }

        private void repeatCount_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(repeatCount.Text, out int result);

            Input.RepeatCount = result < 1 ? 3 : result;

            repeatCount.Text = Input.RepeatCount.ToString();
        }

        private void maxPostsDelete_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(maxPostsDelete.Text, out int result);

            Input.MaxPostsDelete = result < 1 ? 30 : result;

            maxPostsDelete.Text = Input.MaxPostsDelete.ToString();
        }

        private async void startButton6_Click(object sender, EventArgs e)
        {
            startButton6.Enabled = false;
            stopButton6.Enabled = true;

            Service.HighlightMainTab(tabPage7, false);

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            PostDeleter deleter = new PostDeleter(Service, CookieGridView6, _tokenSource.Token);
            await Task.Run(deleter.Start);

            startButton6.Enabled = true;
            stopButton6.Enabled = false;

            stopButton6.Text = "Stop";

            Service.HighlightMainTab(tabPage7, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton6_Click(object sender, EventArgs e)
        {
            stopButton6.Text = "Stop...";
            _tokenSource!.Cancel();
        }

        private void materialTextBox21_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(materialTextBox21.Text, out int result);

            Input.MaxRequestLimit = result < 1 ? 30 : result;

            materialTextBox21.Text = Input.MaxRequestLimit.ToString();
        }

        private async void startButton7_Click(object sender, EventArgs e)
        {
            startButton7.Enabled = false;
            stopButton7.Enabled = true;

            Service.HighlightMainTab(tabPage8, false);

            _tokenSource = null;
            _tokenSource = new CancellationTokenSource();

            FriendConnector connector = new FriendConnector(Service, CookieGridView7, _tokenSource.Token);
            await Task.Run(connector.Start);

            startButton7.Enabled = true;
            stopButton7.Enabled = false;

            stopButton7.Text = "Stop";

            Service.HighlightMainTab(tabPage8, true);

            MessageBox.Show(
                    text: _tokenSource.IsCancellationRequested ? "Đã dừng" : "Hoàn thành",
                    caption: "Thông báo",
                    buttons: MessageBoxButtons.OK,
                    icon: MessageBoxIcon.Information
                );
        }

        private void stopButton7_Click(object sender, EventArgs e)
        {
            stopButton7.Text = "Stop...";
            _tokenSource!.Cancel();
        }
    }
}