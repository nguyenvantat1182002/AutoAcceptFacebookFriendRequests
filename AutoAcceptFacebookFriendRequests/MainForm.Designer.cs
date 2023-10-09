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
            RateLimitDuration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            RataLimit = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            Duration = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            addUserAgentButton = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            addAccountButton = new MaterialSkin.Controls.MaterialButton();
            CookieGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
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
            // RateLimitDuration
            // 
            RateLimitDuration.AnimateReadOnly = false;
            RateLimitDuration.BackgroundImageLayout = ImageLayout.None;
            RateLimitDuration.CharacterCasing = CharacterCasing.Normal;
            RateLimitDuration.Depth = 0;
            RateLimitDuration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            RateLimitDuration.HideSelection = true;
            RateLimitDuration.LeadingIcon = null;
            RateLimitDuration.Location = new Point(6, 112);
            RateLimitDuration.MaxLength = 32767;
            RateLimitDuration.MouseState = MaterialSkin.MouseState.OUT;
            RateLimitDuration.Name = "RateLimitDuration";
            RateLimitDuration.PasswordChar = '\0';
            RateLimitDuration.PrefixSuffixText = null;
            RateLimitDuration.ReadOnly = false;
            RateLimitDuration.RightToLeft = RightToLeft.No;
            RateLimitDuration.SelectedText = "";
            RateLimitDuration.SelectionLength = 0;
            RateLimitDuration.SelectionStart = 0;
            RateLimitDuration.ShortcutsEnabled = true;
            RateLimitDuration.Size = new Size(169, 48);
            RateLimitDuration.TabIndex = 2;
            RateLimitDuration.TabStop = false;
            RateLimitDuration.Text = "120";
            RateLimitDuration.TextAlign = HorizontalAlignment.Left;
            RateLimitDuration.TrailingIcon = null;
            RateLimitDuration.UseSystemPasswordChar = false;
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
            // RataLimit
            // 
            RataLimit.AnimateReadOnly = false;
            RataLimit.BackgroundImageLayout = ImageLayout.None;
            RataLimit.CharacterCasing = CharacterCasing.Normal;
            RataLimit.Depth = 0;
            RataLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            RataLimit.HideSelection = true;
            RataLimit.LeadingIcon = null;
            RataLimit.Location = new Point(218, 112);
            RataLimit.MaxLength = 32767;
            RataLimit.MouseState = MaterialSkin.MouseState.OUT;
            RataLimit.Name = "RataLimit";
            RataLimit.PasswordChar = '\0';
            RataLimit.PrefixSuffixText = null;
            RataLimit.ReadOnly = false;
            RataLimit.RightToLeft = RightToLeft.No;
            RataLimit.SelectedText = "";
            RataLimit.SelectionLength = 0;
            RataLimit.SelectionStart = 0;
            RataLimit.ShortcutsEnabled = true;
            RataLimit.Size = new Size(169, 48);
            RataLimit.TabIndex = 4;
            RataLimit.TabStop = false;
            RataLimit.Text = "10";
            RataLimit.TextAlign = HorizontalAlignment.Left;
            RataLimit.TrailingIcon = null;
            RataLimit.UseSystemPasswordChar = false;
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
            // Duration
            // 
            Duration.AnimateReadOnly = false;
            Duration.BackgroundImageLayout = ImageLayout.None;
            Duration.CharacterCasing = CharacterCasing.Normal;
            Duration.Depth = 0;
            Duration.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            Duration.HideSelection = true;
            Duration.LeadingIcon = null;
            Duration.Location = new Point(6, 204);
            Duration.MaxLength = 32767;
            Duration.MouseState = MaterialSkin.MouseState.OUT;
            Duration.Name = "Duration";
            Duration.PasswordChar = '\0';
            Duration.PrefixSuffixText = null;
            Duration.ReadOnly = false;
            Duration.RightToLeft = RightToLeft.No;
            Duration.SelectedText = "";
            Duration.SelectionLength = 0;
            Duration.SelectionStart = 0;
            Duration.ShortcutsEnabled = true;
            Duration.Size = new Size(169, 48);
            Duration.TabIndex = 8;
            Duration.TabStop = false;
            Duration.Text = "15";
            Duration.TextAlign = HorizontalAlignment.Left;
            Duration.TrailingIcon = null;
            Duration.UseSystemPasswordChar = false;
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
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Cursor = Cursors.Hand;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(537, 261);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(67, 36);
            materialButton2.TabIndex = 11;
            materialButton2.Text = "START";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialButton3
            // 
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Cursor = Cursors.Hand;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.Enabled = false;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(612, 261);
            materialButton3.Margin = new Padding(4, 6, 4, 6);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(64, 36);
            materialButton3.TabIndex = 12;
            materialButton3.Text = "STOP";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
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
            // materialTextBox21
            // 
            materialTextBox21.AnimateReadOnly = false;
            materialTextBox21.BackgroundImageLayout = ImageLayout.None;
            materialTextBox21.CharacterCasing = CharacterCasing.Normal;
            materialTextBox21.Depth = 0;
            materialTextBox21.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox21.HideSelection = true;
            materialTextBox21.LeadingIcon = null;
            materialTextBox21.Location = new Point(537, 204);
            materialTextBox21.MaxLength = 32767;
            materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox21.Name = "materialTextBox21";
            materialTextBox21.PasswordChar = '\0';
            materialTextBox21.PrefixSuffixText = null;
            materialTextBox21.ReadOnly = false;
            materialTextBox21.RightToLeft = RightToLeft.No;
            materialTextBox21.SelectedText = "";
            materialTextBox21.SelectionLength = 0;
            materialTextBox21.SelectionStart = 0;
            materialTextBox21.ShortcutsEnabled = true;
            materialTextBox21.Size = new Size(139, 48);
            materialTextBox21.TabIndex = 17;
            materialTextBox21.TabStop = false;
            materialTextBox21.Text = "15";
            materialTextBox21.TextAlign = HorizontalAlignment.Left;
            materialTextBox21.TrailingIcon = null;
            materialTextBox21.UseSystemPasswordChar = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(683, 674);
            Controls.Add(materialTextBox21);
            Controls.Add(materialLabel7);
            Controls.Add(CookieGridView);
            Controls.Add(addAccountButton);
            Controls.Add(materialButton3);
            Controls.Add(materialButton2);
            Controls.Add(addUserAgentButton);
            Controls.Add(materialLabel6);
            Controls.Add(Duration);
            Controls.Add(materialLabel5);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(RataLimit);
            Controls.Add(materialLabel2);
            Controls.Add(RateLimitDuration);
            Controls.Add(materialLabel1);
            MinimumSize = new Size(669, 606);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AUTO ACCEPT FACEBOOK FRIEND REQUESTS";
            ((System.ComponentModel.ISupportInitialize)CookieGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 RateLimitDuration;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 RataLimit;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox2 Duration;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialButton addUserAgentButton;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton addAccountButton;
        public DataGridView CookieGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
    }
}