﻿namespace AutoAcceptFacebookFriendRequests
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            maxAcceptanceLimit = new MaterialSkin.Controls.MaterialTextBox2();
            CookieGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            stopButton = new MaterialSkin.Controls.MaterialButton();
            startButton = new MaterialSkin.Controls.MaterialButton();
            tabPage3 = new TabPage();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            maxSuggestionLimit = new MaterialSkin.Controls.MaterialTextBox2();
            CookieGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            stopButton2 = new MaterialSkin.Controls.MaterialButton();
            startButton2 = new MaterialSkin.Controls.MaterialButton();
            tabPage4 = new TabPage();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            maxDeleteLimit = new MaterialSkin.Controls.MaterialTextBox2();
            CookieGridView3 = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            stopButton3 = new MaterialSkin.Controls.MaterialButton();
            startButton3 = new MaterialSkin.Controls.MaterialButton();
            tabPage2 = new TabPage();
            addAccountButton = new MaterialSkin.Controls.MaterialButton();
            addUserAgentButton = new MaterialSkin.Controls.MaterialButton();
            maxThreadCount = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            duration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            rateLimit = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            rateLimitDuration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            imageList = new ImageList(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView2).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView3).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Depth = 0;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.ImageList = imageList;
            tabControl1.Location = new Point(3, 64);
            tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(677, 607);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialLabel8);
            tabPage1.Controls.Add(maxAcceptanceLimit);
            tabPage1.Controls.Add(CookieGridView1);
            tabPage1.Controls.Add(stopButton);
            tabPage1.Controls.Add(startButton);
            tabPage1.ImageKey = "account-arrow-right.png";
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(669, 564);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Chấp nhận yêu cầu";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(6, 3);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(148, 19);
            materialLabel8.TabIndex = 36;
            materialLabel8.Text = "Chỉ chấp nhận tối đa";
            // 
            // maxAcceptanceLimit
            // 
            maxAcceptanceLimit.AnimateReadOnly = false;
            maxAcceptanceLimit.BackgroundImageLayout = ImageLayout.None;
            maxAcceptanceLimit.CharacterCasing = CharacterCasing.Normal;
            maxAcceptanceLimit.Depth = 0;
            maxAcceptanceLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxAcceptanceLimit.HideSelection = true;
            maxAcceptanceLimit.LeadingIcon = null;
            maxAcceptanceLimit.Location = new Point(6, 25);
            maxAcceptanceLimit.MaxLength = 32767;
            maxAcceptanceLimit.MouseState = MaterialSkin.MouseState.OUT;
            maxAcceptanceLimit.Name = "maxAcceptanceLimit";
            maxAcceptanceLimit.PasswordChar = '\0';
            maxAcceptanceLimit.PrefixSuffixText = null;
            maxAcceptanceLimit.ReadOnly = false;
            maxAcceptanceLimit.RightToLeft = RightToLeft.No;
            maxAcceptanceLimit.SelectedText = "";
            maxAcceptanceLimit.SelectionLength = 0;
            maxAcceptanceLimit.SelectionStart = 0;
            maxAcceptanceLimit.ShortcutsEnabled = true;
            maxAcceptanceLimit.Size = new Size(174, 48);
            maxAcceptanceLimit.TabIndex = 37;
            maxAcceptanceLimit.TabStop = false;
            maxAcceptanceLimit.Text = "30";
            maxAcceptanceLimit.TextAlign = HorizontalAlignment.Left;
            maxAcceptanceLimit.TrailingIcon = null;
            maxAcceptanceLimit.UseSystemPasswordChar = false;
            maxAcceptanceLimit.TextChanged += maxAcceptanceLimit_TextChanged;
            // 
            // CookieGridView1
            // 
            CookieGridView1.AllowUserToAddRows = false;
            CookieGridView1.AllowUserToDeleteRows = false;
            CookieGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CookieGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CookieGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column5, Column6, Column4 });
            CookieGridView1.Location = new Point(6, 79);
            CookieGridView1.Name = "CookieGridView1";
            CookieGridView1.ReadOnly = true;
            CookieGridView1.RowHeadersVisible = false;
            CookieGridView1.RowTemplate.Height = 25;
            CookieGridView1.Size = new Size(657, 479);
            CookieGridView1.TabIndex = 33;
            // 
            // Column1
            // 
            Column1.HeaderText = "N.";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column1.Width = 60;
            // 
            // Column2
            // 
            Column2.HeaderText = "Cookie [0]";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column2.Width = 150;
            // 
            // Column5
            // 
            Column5.HeaderText = "Proxy";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            Column6.HeaderText = "Đã chấp nhận";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Status";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // stopButton
            // 
            stopButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stopButton.Cursor = Cursors.Hand;
            stopButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            stopButton.Depth = 0;
            stopButton.Enabled = false;
            stopButton.HighEmphasis = true;
            stopButton.Icon = null;
            stopButton.Location = new Point(262, 37);
            stopButton.Margin = new Padding(4, 6, 4, 6);
            stopButton.MouseState = MaterialSkin.MouseState.HOVER;
            stopButton.Name = "stopButton";
            stopButton.NoAccentTextColor = Color.Empty;
            stopButton.Size = new Size(64, 36);
            stopButton.TabIndex = 31;
            stopButton.Text = "STOP";
            stopButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            stopButton.UseAccentColor = false;
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // startButton
            // 
            startButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startButton.Cursor = Cursors.Hand;
            startButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            startButton.Depth = 0;
            startButton.HighEmphasis = true;
            startButton.Icon = null;
            startButton.Location = new Point(187, 37);
            startButton.Margin = new Padding(4, 6, 4, 6);
            startButton.MouseState = MaterialSkin.MouseState.HOVER;
            startButton.Name = "startButton";
            startButton.NoAccentTextColor = Color.Empty;
            startButton.Size = new Size(67, 36);
            startButton.TabIndex = 30;
            startButton.Text = "START";
            startButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            startButton.UseAccentColor = false;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(materialLabel9);
            tabPage3.Controls.Add(maxSuggestionLimit);
            tabPage3.Controls.Add(CookieGridView2);
            tabPage3.Controls.Add(stopButton2);
            tabPage3.Controls.Add(startButton2);
            tabPage3.ImageKey = "account-plus.png";
            tabPage3.Location = new Point(4, 39);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(669, 564);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Kết bạn theo đề xuất";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(6, 5);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(125, 19);
            materialLabel9.TabIndex = 41;
            materialLabel9.Text = "Chỉ kết bạn tối đa";
            // 
            // maxSuggestionLimit
            // 
            maxSuggestionLimit.AnimateReadOnly = false;
            maxSuggestionLimit.BackgroundImageLayout = ImageLayout.None;
            maxSuggestionLimit.CharacterCasing = CharacterCasing.Normal;
            maxSuggestionLimit.Depth = 0;
            maxSuggestionLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxSuggestionLimit.HideSelection = true;
            maxSuggestionLimit.LeadingIcon = null;
            maxSuggestionLimit.Location = new Point(6, 27);
            maxSuggestionLimit.MaxLength = 32767;
            maxSuggestionLimit.MouseState = MaterialSkin.MouseState.OUT;
            maxSuggestionLimit.Name = "maxSuggestionLimit";
            maxSuggestionLimit.PasswordChar = '\0';
            maxSuggestionLimit.PrefixSuffixText = null;
            maxSuggestionLimit.ReadOnly = false;
            maxSuggestionLimit.RightToLeft = RightToLeft.No;
            maxSuggestionLimit.SelectedText = "";
            maxSuggestionLimit.SelectionLength = 0;
            maxSuggestionLimit.SelectionStart = 0;
            maxSuggestionLimit.ShortcutsEnabled = true;
            maxSuggestionLimit.Size = new Size(174, 48);
            maxSuggestionLimit.TabIndex = 42;
            maxSuggestionLimit.TabStop = false;
            maxSuggestionLimit.Text = "30";
            maxSuggestionLimit.TextAlign = HorizontalAlignment.Left;
            maxSuggestionLimit.TrailingIcon = null;
            maxSuggestionLimit.UseSystemPasswordChar = false;
            maxSuggestionLimit.TextChanged += MaxSuggestionLimit_TextChanged;
            // 
            // CookieGridView2
            // 
            CookieGridView2.AllowUserToAddRows = false;
            CookieGridView2.AllowUserToDeleteRows = false;
            CookieGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CookieGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CookieGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            CookieGridView2.Location = new Point(6, 81);
            CookieGridView2.Name = "CookieGridView2";
            CookieGridView2.ReadOnly = true;
            CookieGridView2.RowHeadersVisible = false;
            CookieGridView2.RowTemplate.Height = 25;
            CookieGridView2.Size = new Size(657, 479);
            CookieGridView2.TabIndex = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "N.";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Cookie [0]";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Proxy";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Đã gửi";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.HeaderText = "Status";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // stopButton2
            // 
            stopButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stopButton2.Cursor = Cursors.Hand;
            stopButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            stopButton2.Depth = 0;
            stopButton2.Enabled = false;
            stopButton2.HighEmphasis = true;
            stopButton2.Icon = null;
            stopButton2.Location = new Point(262, 39);
            stopButton2.Margin = new Padding(4, 6, 4, 6);
            stopButton2.MouseState = MaterialSkin.MouseState.HOVER;
            stopButton2.Name = "stopButton2";
            stopButton2.NoAccentTextColor = Color.Empty;
            stopButton2.Size = new Size(64, 36);
            stopButton2.TabIndex = 39;
            stopButton2.Text = "STOP";
            stopButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            stopButton2.UseAccentColor = false;
            stopButton2.UseVisualStyleBackColor = true;
            stopButton2.Click += stopButton2_Click;
            // 
            // startButton2
            // 
            startButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startButton2.Cursor = Cursors.Hand;
            startButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            startButton2.Depth = 0;
            startButton2.HighEmphasis = true;
            startButton2.Icon = null;
            startButton2.Location = new Point(187, 39);
            startButton2.Margin = new Padding(4, 6, 4, 6);
            startButton2.MouseState = MaterialSkin.MouseState.HOVER;
            startButton2.Name = "startButton2";
            startButton2.NoAccentTextColor = Color.Empty;
            startButton2.Size = new Size(67, 36);
            startButton2.TabIndex = 38;
            startButton2.Text = "START";
            startButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            startButton2.UseAccentColor = false;
            startButton2.UseVisualStyleBackColor = true;
            startButton2.Click += startButton2_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(materialLabel10);
            tabPage4.Controls.Add(maxDeleteLimit);
            tabPage4.Controls.Add(CookieGridView3);
            tabPage4.Controls.Add(stopButton3);
            tabPage4.Controls.Add(startButton3);
            tabPage4.ImageKey = "account-multiple-minus.png";
            tabPage4.Location = new Point(4, 39);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(669, 564);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Xóa bạn ngẫu nhiên";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(6, 5);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(99, 19);
            materialLabel10.TabIndex = 46;
            materialLabel10.Text = "Chỉ xóa tối đa";
            // 
            // maxDeleteLimit
            // 
            maxDeleteLimit.AnimateReadOnly = false;
            maxDeleteLimit.BackgroundImageLayout = ImageLayout.None;
            maxDeleteLimit.CharacterCasing = CharacterCasing.Normal;
            maxDeleteLimit.Depth = 0;
            maxDeleteLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxDeleteLimit.HideSelection = true;
            maxDeleteLimit.LeadingIcon = null;
            maxDeleteLimit.Location = new Point(6, 27);
            maxDeleteLimit.MaxLength = 32767;
            maxDeleteLimit.MouseState = MaterialSkin.MouseState.OUT;
            maxDeleteLimit.Name = "maxDeleteLimit";
            maxDeleteLimit.PasswordChar = '\0';
            maxDeleteLimit.PrefixSuffixText = null;
            maxDeleteLimit.ReadOnly = false;
            maxDeleteLimit.RightToLeft = RightToLeft.No;
            maxDeleteLimit.SelectedText = "";
            maxDeleteLimit.SelectionLength = 0;
            maxDeleteLimit.SelectionStart = 0;
            maxDeleteLimit.ShortcutsEnabled = true;
            maxDeleteLimit.Size = new Size(174, 48);
            maxDeleteLimit.TabIndex = 47;
            maxDeleteLimit.TabStop = false;
            maxDeleteLimit.Text = "30";
            maxDeleteLimit.TextAlign = HorizontalAlignment.Left;
            maxDeleteLimit.TrailingIcon = null;
            maxDeleteLimit.UseSystemPasswordChar = false;
            maxDeleteLimit.TextChanged += maxDeleteLimit_TextChanged;
            // 
            // CookieGridView3
            // 
            CookieGridView3.AllowUserToAddRows = false;
            CookieGridView3.AllowUserToDeleteRows = false;
            CookieGridView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CookieGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CookieGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
            CookieGridView3.Location = new Point(6, 81);
            CookieGridView3.Name = "CookieGridView3";
            CookieGridView3.ReadOnly = true;
            CookieGridView3.RowHeadersVisible = false;
            CookieGridView3.RowTemplate.Height = 25;
            CookieGridView3.Size = new Size(657, 479);
            CookieGridView3.TabIndex = 45;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "N.";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Cookie [0]";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Proxy";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Đã xóa";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn10.HeaderText = "Status";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            dataGridViewTextBoxColumn10.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // stopButton3
            // 
            stopButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            stopButton3.Cursor = Cursors.Hand;
            stopButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            stopButton3.Depth = 0;
            stopButton3.Enabled = false;
            stopButton3.HighEmphasis = true;
            stopButton3.Icon = null;
            stopButton3.Location = new Point(262, 39);
            stopButton3.Margin = new Padding(4, 6, 4, 6);
            stopButton3.MouseState = MaterialSkin.MouseState.HOVER;
            stopButton3.Name = "stopButton3";
            stopButton3.NoAccentTextColor = Color.Empty;
            stopButton3.Size = new Size(64, 36);
            stopButton3.TabIndex = 44;
            stopButton3.Text = "STOP";
            stopButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            stopButton3.UseAccentColor = false;
            stopButton3.UseVisualStyleBackColor = true;
            stopButton3.Click += stopButton3_Click;
            // 
            // startButton3
            // 
            startButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startButton3.Cursor = Cursors.Hand;
            startButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            startButton3.Depth = 0;
            startButton3.HighEmphasis = true;
            startButton3.Icon = null;
            startButton3.Location = new Point(187, 39);
            startButton3.Margin = new Padding(4, 6, 4, 6);
            startButton3.MouseState = MaterialSkin.MouseState.HOVER;
            startButton3.Name = "startButton3";
            startButton3.NoAccentTextColor = Color.Empty;
            startButton3.Size = new Size(67, 36);
            startButton3.TabIndex = 43;
            startButton3.Text = "START";
            startButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            startButton3.UseAccentColor = false;
            startButton3.UseVisualStyleBackColor = true;
            startButton3.Click += startButton3_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(addAccountButton);
            tabPage2.Controls.Add(addUserAgentButton);
            tabPage2.Controls.Add(maxThreadCount);
            tabPage2.Controls.Add(materialLabel7);
            tabPage2.Controls.Add(materialLabel6);
            tabPage2.Controls.Add(duration);
            tabPage2.Controls.Add(materialLabel5);
            tabPage2.Controls.Add(materialLabel4);
            tabPage2.Controls.Add(materialLabel3);
            tabPage2.Controls.Add(rateLimit);
            tabPage2.Controls.Add(materialLabel2);
            tabPage2.Controls.Add(rateLimitDuration);
            tabPage2.Controls.Add(materialLabel1);
            tabPage2.ImageKey = "cog.png";
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(669, 564);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cài đặt";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // addAccountButton
            // 
            addAccountButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addAccountButton.Cursor = Cursors.Hand;
            addAccountButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addAccountButton.Depth = 0;
            addAccountButton.HighEmphasis = true;
            addAccountButton.Icon = null;
            addAccountButton.Location = new Point(387, 195);
            addAccountButton.Margin = new Padding(4, 6, 4, 6);
            addAccountButton.MouseState = MaterialSkin.MouseState.HOVER;
            addAccountButton.Name = "addAccountButton";
            addAccountButton.NoAccentTextColor = Color.Empty;
            addAccountButton.Size = new Size(142, 36);
            addAccountButton.TabIndex = 39;
            addAccountButton.Text = "Add Account(s)";
            addAccountButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addAccountButton.UseAccentColor = false;
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += addAccountButton_Click;
            // 
            // addUserAgentButton
            // 
            addUserAgentButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserAgentButton.Cursor = Cursors.Hand;
            addUserAgentButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addUserAgentButton.Depth = 0;
            addUserAgentButton.HighEmphasis = true;
            addUserAgentButton.Icon = null;
            addUserAgentButton.Location = new Point(218, 195);
            addUserAgentButton.Margin = new Padding(4, 6, 4, 6);
            addUserAgentButton.MouseState = MaterialSkin.MouseState.HOVER;
            addUserAgentButton.Name = "addUserAgentButton";
            addUserAgentButton.NoAccentTextColor = Color.Empty;
            addUserAgentButton.Size = new Size(161, 36);
            addUserAgentButton.TabIndex = 38;
            addUserAgentButton.Text = "Add User-Agent(s)";
            addUserAgentButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addUserAgentButton.UseAccentColor = false;
            addUserAgentButton.UseVisualStyleBackColor = true;
            addUserAgentButton.Click += addUserAgentButton_Click;
            // 
            // maxThreadCount
            // 
            maxThreadCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            maxThreadCount.AnimateReadOnly = false;
            maxThreadCount.BackgroundImageLayout = ImageLayout.None;
            maxThreadCount.CharacterCasing = CharacterCasing.Normal;
            maxThreadCount.Depth = 0;
            maxThreadCount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxThreadCount.HideSelection = true;
            maxThreadCount.LeadingIcon = null;
            maxThreadCount.Location = new Point(6, 183);
            maxThreadCount.MaxLength = 32767;
            maxThreadCount.MouseState = MaterialSkin.MouseState.OUT;
            maxThreadCount.Name = "maxThreadCount";
            maxThreadCount.PasswordChar = '\0';
            maxThreadCount.PrefixSuffixText = null;
            maxThreadCount.ReadOnly = false;
            maxThreadCount.RightToLeft = RightToLeft.No;
            maxThreadCount.SelectedText = "";
            maxThreadCount.SelectionLength = 0;
            maxThreadCount.SelectionStart = 0;
            maxThreadCount.ShortcutsEnabled = true;
            maxThreadCount.Size = new Size(169, 48);
            maxThreadCount.TabIndex = 37;
            maxThreadCount.TabStop = false;
            maxThreadCount.Text = "5";
            maxThreadCount.TextAlign = HorizontalAlignment.Left;
            maxThreadCount.TrailingIcon = null;
            maxThreadCount.UseSystemPasswordChar = false;
            maxThreadCount.TextChanged += maxThreadCount_TextChanged;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(6, 161);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(64, 19);
            materialLabel7.TabIndex = 36;
            materialLabel7.Text = "Số luồng";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(181, 82);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(31, 19);
            materialLabel6.TabIndex = 34;
            materialLabel6.Text = "giây";
            // 
            // duration
            // 
            duration.AnimateReadOnly = false;
            duration.BackgroundImageLayout = ImageLayout.None;
            duration.CharacterCasing = CharacterCasing.Normal;
            duration.Depth = 0;
            duration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            duration.HideSelection = true;
            duration.LeadingIcon = null;
            duration.Location = new Point(6, 104);
            duration.MaxLength = 32767;
            duration.MouseState = MaterialSkin.MouseState.OUT;
            duration.Name = "duration";
            duration.PasswordChar = '\0';
            duration.PrefixSuffixText = null;
            duration.ReadOnly = false;
            duration.RightToLeft = RightToLeft.No;
            duration.SelectedText = "";
            duration.SelectionLength = 0;
            duration.SelectionStart = 0;
            duration.ShortcutsEnabled = true;
            duration.Size = new Size(169, 48);
            duration.TabIndex = 33;
            duration.TabStop = false;
            duration.Text = "15";
            duration.TextAlign = HorizontalAlignment.Left;
            duration.TrailingIcon = null;
            duration.UseSystemPasswordChar = false;
            duration.TextChanged += duration_TextChanged;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(6, 82);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(160, 19);
            materialLabel5.TabIndex = 32;
            materialLabel5.Text = "Mỗi yêu cầu tạm dừng";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(393, 3);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(56, 19);
            materialLabel4.TabIndex = 31;
            materialLabel4.Text = "yêu cầu";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(218, 3);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(137, 19);
            materialLabel3.TabIndex = 30;
            materialLabel3.Text = "sau khi hoàn thành";
            // 
            // rateLimit
            // 
            rateLimit.AnimateReadOnly = false;
            rateLimit.BackgroundImageLayout = ImageLayout.None;
            rateLimit.CharacterCasing = CharacterCasing.Normal;
            rateLimit.Depth = 0;
            rateLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            rateLimit.HideSelection = true;
            rateLimit.LeadingIcon = null;
            rateLimit.Location = new Point(218, 25);
            rateLimit.MaxLength = 32767;
            rateLimit.MouseState = MaterialSkin.MouseState.OUT;
            rateLimit.Name = "rateLimit";
            rateLimit.PasswordChar = '\0';
            rateLimit.PrefixSuffixText = null;
            rateLimit.ReadOnly = false;
            rateLimit.RightToLeft = RightToLeft.No;
            rateLimit.SelectedText = "";
            rateLimit.SelectionLength = 0;
            rateLimit.SelectionStart = 0;
            rateLimit.ShortcutsEnabled = true;
            rateLimit.Size = new Size(169, 48);
            rateLimit.TabIndex = 29;
            rateLimit.TabStop = false;
            rateLimit.Text = "10";
            rateLimit.TextAlign = HorizontalAlignment.Left;
            rateLimit.TrailingIcon = null;
            rateLimit.UseSystemPasswordChar = false;
            rateLimit.TextChanged += rateLimit_TextChanged;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(181, 3);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(31, 19);
            materialLabel2.TabIndex = 28;
            materialLabel2.Text = "giây";
            // 
            // rateLimitDuration
            // 
            rateLimitDuration.AnimateReadOnly = false;
            rateLimitDuration.BackgroundImageLayout = ImageLayout.None;
            rateLimitDuration.CharacterCasing = CharacterCasing.Normal;
            rateLimitDuration.Depth = 0;
            rateLimitDuration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            rateLimitDuration.HideSelection = true;
            rateLimitDuration.LeadingIcon = null;
            rateLimitDuration.Location = new Point(6, 25);
            rateLimitDuration.MaxLength = 32767;
            rateLimitDuration.MouseState = MaterialSkin.MouseState.OUT;
            rateLimitDuration.Name = "rateLimitDuration";
            rateLimitDuration.PasswordChar = '\0';
            rateLimitDuration.PrefixSuffixText = null;
            rateLimitDuration.ReadOnly = false;
            rateLimitDuration.RightToLeft = RightToLeft.No;
            rateLimitDuration.SelectedText = "";
            rateLimitDuration.SelectionLength = 0;
            rateLimitDuration.SelectionStart = 0;
            rateLimitDuration.ShortcutsEnabled = true;
            rateLimitDuration.Size = new Size(169, 48);
            rateLimitDuration.TabIndex = 27;
            rateLimitDuration.TabStop = false;
            rateLimitDuration.Text = "120";
            rateLimitDuration.TextAlign = HorizontalAlignment.Left;
            rateLimitDuration.TrailingIcon = null;
            rateLimitDuration.UseSystemPasswordChar = false;
            rateLimitDuration.TextChanged += rateLimitDuration_TextChanged;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(6, 3);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(75, 19);
            materialLabel1.TabIndex = 26;
            materialLabel1.Text = "Tạm dừng";
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageStream = (ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = Color.Transparent;
            imageList.Images.SetKeyName(0, "cog.png");
            imageList.Images.SetKeyName(1, "account-plus.png");
            imageList.Images.SetKeyName(2, "account-arrow-right.png");
            imageList.Images.SetKeyName(3, "account-multiple-minus.png");
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 674);
            Controls.Add(tabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tabControl1;
            DrawerWidth = 300;
            MinimumSize = new Size(669, 606);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FACEBOOK TOOLKIT";
            Load += MainForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView2).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CookieGridView3).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialTextBox2 maxAcceptanceLimit;
        public DataGridView CookieGridView1;
        private MaterialSkin.Controls.MaterialButton stopButton;
        private MaterialSkin.Controls.MaterialButton startButton;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox2 duration;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox2 rateLimit;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 rateLimitDuration;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 maxThreadCount;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialButton addAccountButton;
        private MaterialSkin.Controls.MaterialButton addUserAgentButton;
        private ImageList imageList;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column4;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialTextBox2 maxSuggestionLimit;
        public DataGridView CookieGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private MaterialSkin.Controls.MaterialButton stopButton2;
        private MaterialSkin.Controls.MaterialButton startButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialTextBox2 maxDeleteLimit;
        public DataGridView CookieGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private MaterialSkin.Controls.MaterialButton stopButton3;
        private MaterialSkin.Controls.MaterialButton startButton3;
    }
}