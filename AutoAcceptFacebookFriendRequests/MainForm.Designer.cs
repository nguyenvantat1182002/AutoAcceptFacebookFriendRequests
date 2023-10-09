namespace AutoAcceptFacebookFriendRequests
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
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            rateLimitDuration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            rateLimit = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            duration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            addUserAgentButton = new MaterialSkin.Controls.MaterialButton();
            startButton = new MaterialSkin.Controls.MaterialButton();
            stopButton = new MaterialSkin.Controls.MaterialButton();
            addAccountButton = new MaterialSkin.Controls.MaterialButton();
            CookieGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            maxThreadCount = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)CookieGridView).BeginInit();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(6, 90);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(75, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Tạm dừng";
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
            rateLimitDuration.Location = new Point(6, 112);
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
            rateLimitDuration.TabIndex = 2;
            rateLimitDuration.TabStop = false;
            rateLimitDuration.Text = "120";
            rateLimitDuration.TextAlign = HorizontalAlignment.Left;
            rateLimitDuration.TrailingIcon = null;
            rateLimitDuration.UseSystemPasswordChar = false;
            rateLimitDuration.TextChanged += rateLimitDuration_TextChanged;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(181, 90);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(31, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "giây";
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
            rateLimit.Location = new Point(218, 112);
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
            rateLimit.TabIndex = 4;
            rateLimit.TabStop = false;
            rateLimit.Text = "10";
            rateLimit.TextAlign = HorizontalAlignment.Left;
            rateLimit.TrailingIcon = null;
            rateLimit.UseSystemPasswordChar = false;
            rateLimit.TextChanged += rateLimit_TextChanged;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(218, 90);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(131, 19);
            materialLabel3.TabIndex = 5;
            materialLabel3.Text = "sau khi chấp nhận";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(387, 90);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(56, 19);
            materialLabel4.TabIndex = 6;
            materialLabel4.Text = "yêu cầu";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(6, 182);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(160, 19);
            materialLabel5.TabIndex = 7;
            materialLabel5.Text = "Mỗi yêu cầu tạm dừng";
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
            duration.Location = new Point(6, 204);
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
            duration.TabIndex = 8;
            duration.TabStop = false;
            duration.Text = "15";
            duration.TextAlign = HorizontalAlignment.Left;
            duration.TrailingIcon = null;
            duration.UseSystemPasswordChar = false;
            duration.TextChanged += duration_TextChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(181, 182);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(31, 19);
            materialLabel6.TabIndex = 9;
            materialLabel6.Text = "giây";
            // 
            // addUserAgentButton
            // 
            addUserAgentButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addUserAgentButton.Cursor = Cursors.Hand;
            addUserAgentButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addUserAgentButton.Depth = 0;
            addUserAgentButton.HighEmphasis = true;
            addUserAgentButton.Icon = null;
            addUserAgentButton.Location = new Point(7, 261);
            addUserAgentButton.Margin = new Padding(4, 6, 4, 6);
            addUserAgentButton.MouseState = MaterialSkin.MouseState.HOVER;
            addUserAgentButton.Name = "addUserAgentButton";
            addUserAgentButton.NoAccentTextColor = Color.Empty;
            addUserAgentButton.Size = new Size(161, 36);
            addUserAgentButton.TabIndex = 10;
            addUserAgentButton.Text = "Add User-Agent(s)";
            addUserAgentButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addUserAgentButton.UseAccentColor = false;
            addUserAgentButton.UseVisualStyleBackColor = true;
            addUserAgentButton.Click += addUserAgentButton_Click;
            // 
            // startButton
            // 
            startButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startButton.Cursor = Cursors.Hand;
            startButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            startButton.Depth = 0;
            startButton.HighEmphasis = true;
            startButton.Icon = null;
            startButton.Location = new Point(537, 261);
            startButton.Margin = new Padding(4, 6, 4, 6);
            startButton.MouseState = MaterialSkin.MouseState.HOVER;
            startButton.Name = "startButton";
            startButton.NoAccentTextColor = Color.Empty;
            startButton.Size = new Size(67, 36);
            startButton.TabIndex = 11;
            startButton.Text = "START";
            startButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            startButton.UseAccentColor = false;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
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
            stopButton.Location = new Point(612, 261);
            stopButton.Margin = new Padding(4, 6, 4, 6);
            stopButton.MouseState = MaterialSkin.MouseState.HOVER;
            stopButton.Name = "stopButton";
            stopButton.NoAccentTextColor = Color.Empty;
            stopButton.Size = new Size(64, 36);
            stopButton.TabIndex = 12;
            stopButton.Text = "STOP";
            stopButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            stopButton.UseAccentColor = false;
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // addAccountButton
            // 
            addAccountButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addAccountButton.Cursor = Cursors.Hand;
            addAccountButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addAccountButton.Depth = 0;
            addAccountButton.HighEmphasis = true;
            addAccountButton.Icon = null;
            addAccountButton.Location = new Point(176, 261);
            addAccountButton.Margin = new Padding(4, 6, 4, 6);
            addAccountButton.MouseState = MaterialSkin.MouseState.HOVER;
            addAccountButton.Name = "addAccountButton";
            addAccountButton.NoAccentTextColor = Color.Empty;
            addAccountButton.Size = new Size(142, 36);
            addAccountButton.TabIndex = 14;
            addAccountButton.Text = "Add Account(s)";
            addAccountButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addAccountButton.UseAccentColor = false;
            addAccountButton.UseVisualStyleBackColor = true;
            addAccountButton.Click += addAccountButton_Click;
            // 
            // CookieGridView
            // 
            CookieGridView.AllowUserToAddRows = false;
            CookieGridView.AllowUserToDeleteRows = false;
            CookieGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CookieGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column4 });
            CookieGridView.Location = new Point(7, 306);
            CookieGridView.Name = "CookieGridView";
            CookieGridView.ReadOnly = true;
            CookieGridView.RowHeadersVisible = false;
            CookieGridView.RowTemplate.Height = 25;
            CookieGridView.Size = new Size(669, 362);
            CookieGridView.TabIndex = 15;
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
            // Column3
            // 
            Column3.HeaderText = "Request";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            Column5.HeaderText = "Proxy";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.SortMode = DataGridViewColumnSortMode.NotSortable;
            Column5.Width = 150;
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Status";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(537, 182);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(64, 19);
            materialLabel7.TabIndex = 16;
            materialLabel7.Text = "Số luồng";
            // 
            // maxThreadCount
            // 
            maxThreadCount.AnimateReadOnly = false;
            maxThreadCount.BackgroundImageLayout = ImageLayout.None;
            maxThreadCount.CharacterCasing = CharacterCasing.Normal;
            maxThreadCount.Depth = 0;
            maxThreadCount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            maxThreadCount.HideSelection = true;
            maxThreadCount.LeadingIcon = null;
            maxThreadCount.Location = new Point(537, 204);
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
            maxThreadCount.Size = new Size(139, 48);
            maxThreadCount.TabIndex = 17;
            maxThreadCount.TabStop = false;
            maxThreadCount.Text = "5";
            maxThreadCount.TextAlign = HorizontalAlignment.Left;
            maxThreadCount.TrailingIcon = null;
            maxThreadCount.UseSystemPasswordChar = false;
            maxThreadCount.TextChanged += maxThreadCount_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 674);
            Controls.Add(maxThreadCount);
            Controls.Add(materialLabel7);
            Controls.Add(CookieGridView);
            Controls.Add(addAccountButton);
            Controls.Add(stopButton);
            Controls.Add(startButton);
            Controls.Add(addUserAgentButton);
            Controls.Add(materialLabel6);
            Controls.Add(duration);
            Controls.Add(materialLabel5);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(rateLimit);
            Controls.Add(materialLabel2);
            Controls.Add(rateLimitDuration);
            Controls.Add(materialLabel1);
            MinimumSize = new Size(669, 606);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AUTO ACCEPT FACEBOOK FRIEND REQUESTS";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)CookieGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 rateLimitDuration;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 rateLimit;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox2 duration;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialButton addUserAgentButton;
        private MaterialSkin.Controls.MaterialButton stopButton;
        private MaterialSkin.Controls.MaterialButton addAccountButton;
        public DataGridView CookieGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private MaterialSkin.Controls.MaterialButton startButton;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox2 maxThreadCount;
    }
}