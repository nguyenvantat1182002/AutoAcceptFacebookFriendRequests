﻿using AutoAcceptFacebookFriendRequests.API;
using AutoAcceptFacebookFriendRequests.API.Model;
using AutoAcceptFacebookFriendRequests.Utils;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;

namespace AutoAcceptFacebookFriendRequests.Services
{
    public class MainFormService
    {
        public MainForm MainForm { get; }

        public List<DataGridView> GridViews { get; }

        public bool IsRepeat
        {
            get
            {
                bool result = false;

                MainForm.materialSwitch1.Invoke(new Action(() =>
                {
                    result = MainForm.materialSwitch1.Checked;
                }));

                return result;
            }
        }

        public int RepeatCount
        {
            get
            {
                int result = 0;

                MainForm.repeatCount.Invoke(new Action(() =>
                {
                    result = Convert.ToInt32(MainForm.repeatCount.Text);
                }));

                return result;
            }
        }

        private readonly List<TabPage> _tabs;

        public MainFormService(MainForm mainForm)
        {
            MainForm = mainForm;
            GridViews = new List<DataGridView>();

            GridViews.Add(MainForm.CookieGridView1);
            GridViews.Add(MainForm.CookieGridView2);
            GridViews.Add(MainForm.CookieGridView3);
            GridViews.Add(MainForm.CookieGridView4);
            GridViews.Add(MainForm.CookieGridView5);
            GridViews.Add(MainForm.CookieGridView6);
            GridViews.Add(MainForm.CookieGridView7);
            GridViews.Add(MainForm.CookieGridView8);
            GridViews.Add(MainForm.CookieGridView9);

            _tabs = new List<TabPage>();
            _tabs.Add(MainForm.tabPage1);
            _tabs.Add(MainForm.tabPage3);
            _tabs.Add(MainForm.tabPage4);
            _tabs.Add(MainForm.tabPage5);
            _tabs.Add(MainForm.tabPage6);
            _tabs.Add(MainForm.tabPage6);
            _tabs.Add(MainForm.tabPage7);
            _tabs.Add(MainForm.tabPage8);
            _tabs.Add(MainForm.tabPage9);
            _tabs.Add(MainForm.tabPage10);
        }

        public void AddMemberId(FriendInfo member)
        {
            MainForm.materialMultiLineTextBox25.Invoke(new Action(() =>
            {
                MainForm.materialMultiLineTextBox25.Text = $"{MainForm.materialMultiLineTextBox25.Text}\r\n{member.Id}";
                MainForm.materialMultiLineTextBox25.Text = MainForm.materialMultiLineTextBox25.Text.Trim();
            }));

            MainForm.materialLabel18.Invoke(new Action(() =>
            {
                string[] ids = ReadTextBoxLines(MainForm.materialMultiLineTextBox25);
                MainForm.materialLabel18.Text = $"Id(s): {ids.Length}";
            }));
        }

        public string GetUidFromDataRow(DataGridViewRow dataGridViewRow)
        {
            Match match = Regex.Match(dataGridViewRow.Cells[1].Value.ToString()!, "c_user=(\\d+);");
            return match.Groups[1].Value;
        }

        public string[] GetUserIds(MaterialMultiLineTextBox2 multiLineTextBox)
        {
            return ReadTextBoxLines(multiLineTextBox);
        }

        public string GetLink()
        {
            string link = "";

            MainForm.materialTextBox22.Invoke(new Action(() =>
            {
                link = MainForm.materialTextBox22.Text.Trim();
            }));

            return link;
        }

        public string GetPostContent()
        {
            string content = "";

            MainForm.materialMultiLineTextBox22.Invoke(new Action(() =>
            {
                content = MainForm.materialMultiLineTextBox22.Text.Replace("\r", "");
            }));

            return content;
        }

        public int GetMaxInviteCount()
        {
            int value = 30;

            MainForm.maxInviteCount.Invoke(new Action(() =>
            {
                value = Convert.ToInt32(MainForm.maxInviteCount.Text);
            }));

            return value;
        }

        public string[] GetGroupIDs(MaterialMultiLineTextBox2 multiLineTextBox)
        {
            return ReadTextBoxLines(multiLineTextBox);
        }

        public string[] ReadTextBoxLines(MaterialMultiLineTextBox2 textBox)
        {
            string[] values = new string[] { };

            textBox.Invoke(new Action(() =>
            {
                values = textBox.Text.Split("\r\n").Where(item => item.Length > 0).ToArray();
            }));

            return values;
        }

        public void HighlightMainTab(TabPage tab, bool enable)
        {
            foreach (TabPage item in _tabs)
            {
                if (item == tab)
                    continue;

                item.Enabled = enable;
            }
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

            foreach (DataGridView item in GridViews)
                item.Columns[1].HeaderText = $"Cookie [{item.RowCount}]";
        }

        public DataGridViewCell GetRequestCell(DataGridView dataGridView, int index)
        {
            return dataGridView.Rows[index].Cells[3];
        }

        public DataGridViewCell GetStatusCell(DataGridView dataGridView, int index)
        {
            return dataGridView.Rows[index].Cells[dataGridView.ColumnCount < 5 ? 3 : 4];
        }

        public void UpdateCookieStatus(DataGridView gridView, FacebookAccountAPI account, string status)
        {
            int index = MainForm.AccountList.IndexOf(account);

            gridView.Invoke(new Action(() =>
            {
                GetStatusCell(gridView, index).Value = status;
            }));
        }

        public void UpdateRequest(DataGridView gridView, FacebookAccountAPI account, string value)
        {
            int index = MainForm.AccountList.IndexOf(account);

            gridView.Invoke(new Action(() =>
            {
                gridView.Rows[index].Cells[3].Value = value;
            }));
        }
    }
}
