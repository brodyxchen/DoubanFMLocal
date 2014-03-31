namespace DoubanFM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UI_ControlPanel = new System.Windows.Forms.Panel();
            this.UI_Next = new System.Windows.Forms.PictureBox();
            this.UI_Star = new System.Windows.Forms.PictureBox();
            this.UI_Hate = new System.Windows.Forms.PictureBox();
            this.UI_MsgShow = new System.Windows.Forms.Label();
            this.UI_SongArtist = new System.Windows.Forms.Label();
            this.UI_TimeNowShow = new System.Windows.Forms.Label();
            this.UI_PlayTrack = new System.Windows.Forms.TrackBar();
            this.UI_TimeTotalShow = new System.Windows.Forms.Label();
            this.UI_SongName = new System.Windows.Forms.Label();
            this.UI_LoginPanel = new System.Windows.Forms.Panel();
            this.UI_LoginIn = new System.Windows.Forms.Button();
            this.UI_LoginUsername = new System.Windows.Forms.TextBox();
            this.UI_LoginPassword = new System.Windows.Forms.TextBox();
            this.UI_ChannelList = new System.Windows.Forms.ComboBox();
            this.UI_Voice = new System.Windows.Forms.TrackBar();
            this.UI_LoginTip = new System.Windows.Forms.Label();
            this.UI_SettingClose = new System.Windows.Forms.PictureBox();
            this.UI_SaveLoginIn = new System.Windows.Forms.CheckBox();
            this.UI_ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Star)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Hate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PlayTrack)).BeginInit();
            this.UI_LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Voice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_SettingClose)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_ControlPanel
            // 
            this.UI_ControlPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UI_ControlPanel.BackgroundImage")));
            this.UI_ControlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UI_ControlPanel.Controls.Add(this.UI_Next);
            this.UI_ControlPanel.Controls.Add(this.UI_Star);
            this.UI_ControlPanel.Controls.Add(this.UI_Hate);
            this.UI_ControlPanel.Controls.Add(this.UI_MsgShow);
            this.UI_ControlPanel.Controls.Add(this.UI_SongArtist);
            this.UI_ControlPanel.Controls.Add(this.UI_TimeNowShow);
            this.UI_ControlPanel.Controls.Add(this.UI_PlayTrack);
            this.UI_ControlPanel.Controls.Add(this.UI_TimeTotalShow);
            this.UI_ControlPanel.Controls.Add(this.UI_SongName);
            this.UI_ControlPanel.Location = new System.Drawing.Point(55, 53);
            this.UI_ControlPanel.Name = "UI_ControlPanel";
            this.UI_ControlPanel.Size = new System.Drawing.Size(238, 136);
            this.UI_ControlPanel.TabIndex = 23;
            // 
            // UI_Next
            // 
            this.UI_Next.BackgroundImage = global::DoubanFM.Properties.Resources.NextOn;
            this.UI_Next.Location = new System.Drawing.Point(187, 101);
            this.UI_Next.Name = "UI_Next";
            this.UI_Next.Size = new System.Drawing.Size(25, 25);
            this.UI_Next.TabIndex = 29;
            this.UI_Next.TabStop = false;
            this.UI_Next.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_Next_MouseClick);
            // 
            // UI_Star
            // 
            this.UI_Star.BackColor = System.Drawing.Color.Transparent;
            this.UI_Star.BackgroundImage = global::DoubanFM.Properties.Resources.likeGrayOn;
            this.UI_Star.Location = new System.Drawing.Point(29, 101);
            this.UI_Star.Name = "UI_Star";
            this.UI_Star.Size = new System.Drawing.Size(25, 25);
            this.UI_Star.TabIndex = 29;
            this.UI_Star.TabStop = false;
            this.UI_Star.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_Star_MouseClick);
            // 
            // UI_Hate
            // 
            this.UI_Hate.BackgroundImage = global::DoubanFM.Properties.Resources.HateOn;
            this.UI_Hate.Location = new System.Drawing.Point(105, 101);
            this.UI_Hate.Name = "UI_Hate";
            this.UI_Hate.Size = new System.Drawing.Size(25, 25);
            this.UI_Hate.TabIndex = 29;
            this.UI_Hate.TabStop = false;
            this.UI_Hate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_Hate_MouseClick);
            // 
            // UI_MsgShow
            // 
            this.UI_MsgShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_MsgShow.BackColor = System.Drawing.Color.Transparent;
            this.UI_MsgShow.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UI_MsgShow.Location = new System.Drawing.Point(51, 71);
            this.UI_MsgShow.Name = "UI_MsgShow";
            this.UI_MsgShow.Size = new System.Drawing.Size(141, 16);
            this.UI_MsgShow.TabIndex = 26;
            this.UI_MsgShow.Text = "tips";
            this.UI_MsgShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_SongArtist
            // 
            this.UI_SongArtist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_SongArtist.BackColor = System.Drawing.Color.Transparent;
            this.UI_SongArtist.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UI_SongArtist.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UI_SongArtist.Location = new System.Drawing.Point(29, 36);
            this.UI_SongArtist.Name = "UI_SongArtist";
            this.UI_SongArtist.Size = new System.Drawing.Size(183, 12);
            this.UI_SongArtist.TabIndex = 25;
            this.UI_SongArtist.Text = "歌曲作者";
            this.UI_SongArtist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI_TimeNowShow
            // 
            this.UI_TimeNowShow.AutoSize = true;
            this.UI_TimeNowShow.BackColor = System.Drawing.Color.Transparent;
            this.UI_TimeNowShow.Location = new System.Drawing.Point(18, 52);
            this.UI_TimeNowShow.Name = "UI_TimeNowShow";
            this.UI_TimeNowShow.Size = new System.Drawing.Size(53, 12);
            this.UI_TimeNowShow.TabIndex = 24;
            this.UI_TimeNowShow.Text = "time now";
            this.UI_TimeNowShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UI_PlayTrack
            // 
            this.UI_PlayTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.UI_PlayTrack.Location = new System.Drawing.Point(51, 48);
            this.UI_PlayTrack.Name = "UI_PlayTrack";
            this.UI_PlayTrack.Size = new System.Drawing.Size(132, 45);
            this.UI_PlayTrack.TabIndex = 12;
            this.UI_PlayTrack.TickFrequency = 0;
            this.UI_PlayTrack.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UI_PlayTrack.Scroll += new System.EventHandler(this.UI_PlayTrack_Scroll);
            // 
            // UI_TimeTotalShow
            // 
            this.UI_TimeTotalShow.AutoSize = true;
            this.UI_TimeTotalShow.BackColor = System.Drawing.Color.Transparent;
            this.UI_TimeTotalShow.Location = new System.Drawing.Point(189, 52);
            this.UI_TimeTotalShow.Name = "UI_TimeTotalShow";
            this.UI_TimeTotalShow.Size = new System.Drawing.Size(65, 12);
            this.UI_TimeTotalShow.TabIndex = 20;
            this.UI_TimeTotalShow.Text = "time total";
            this.UI_TimeTotalShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UI_SongName
            // 
            this.UI_SongName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_SongName.BackColor = System.Drawing.Color.Transparent;
            this.UI_SongName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UI_SongName.Location = new System.Drawing.Point(29, 9);
            this.UI_SongName.Name = "UI_SongName";
            this.UI_SongName.Size = new System.Drawing.Size(183, 21);
            this.UI_SongName.TabIndex = 19;
            this.UI_SongName.Text = "歌曲信息";
            this.UI_SongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UI_SongName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_SongName_MouseClick);
            // 
            // UI_LoginPanel
            // 
            this.UI_LoginPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UI_LoginPanel.BackgroundImage")));
            this.UI_LoginPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UI_LoginPanel.Controls.Add(this.UI_SaveLoginIn);
            this.UI_LoginPanel.Controls.Add(this.UI_LoginIn);
            this.UI_LoginPanel.Controls.Add(this.UI_LoginUsername);
            this.UI_LoginPanel.Controls.Add(this.UI_LoginPassword);
            this.UI_LoginPanel.Controls.Add(this.UI_ChannelList);
            this.UI_LoginPanel.Controls.Add(this.UI_Voice);
            this.UI_LoginPanel.Controls.Add(this.UI_LoginTip);
            this.UI_LoginPanel.Location = new System.Drawing.Point(55, 53);
            this.UI_LoginPanel.Name = "UI_LoginPanel";
            this.UI_LoginPanel.Size = new System.Drawing.Size(238, 136);
            this.UI_LoginPanel.TabIndex = 26;
            // 
            // UI_LoginIn
            // 
            this.UI_LoginIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UI_LoginIn.Location = new System.Drawing.Point(77, 64);
            this.UI_LoginIn.Name = "UI_LoginIn";
            this.UI_LoginIn.Size = new System.Drawing.Size(47, 23);
            this.UI_LoginIn.TabIndex = 10;
            this.UI_LoginIn.Text = "登陆";
            this.UI_LoginIn.UseVisualStyleBackColor = true;
            this.UI_LoginIn.Click += new System.EventHandler(this.UI_LoginIn_Click);
            // 
            // UI_LoginUsername
            // 
            this.UI_LoginUsername.Location = new System.Drawing.Point(24, 15);
            this.UI_LoginUsername.Name = "UI_LoginUsername";
            this.UI_LoginUsername.Size = new System.Drawing.Size(100, 21);
            this.UI_LoginUsername.TabIndex = 8;
            // 
            // UI_LoginPassword
            // 
            this.UI_LoginPassword.Location = new System.Drawing.Point(24, 42);
            this.UI_LoginPassword.Name = "UI_LoginPassword";
            this.UI_LoginPassword.Size = new System.Drawing.Size(100, 21);
            this.UI_LoginPassword.TabIndex = 9;
            this.UI_LoginPassword.UseSystemPasswordChar = true;
            // 
            // UI_ChannelList
            // 
            this.UI_ChannelList.FormattingEnabled = true;
            this.UI_ChannelList.Location = new System.Drawing.Point(24, 99);
            this.UI_ChannelList.Name = "UI_ChannelList";
            this.UI_ChannelList.Size = new System.Drawing.Size(121, 20);
            this.UI_ChannelList.TabIndex = 18;
            this.UI_ChannelList.SelectedIndexChanged += new System.EventHandler(this.UI_ChannelList_SelectedIndexChanged);
            // 
            // UI_Voice
            // 
            this.UI_Voice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.UI_Voice.Location = new System.Drawing.Point(173, 49);
            this.UI_Voice.Name = "UI_Voice";
            this.UI_Voice.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.UI_Voice.Size = new System.Drawing.Size(45, 66);
            this.UI_Voice.TabIndex = 13;
            this.UI_Voice.TickFrequency = 0;
            this.UI_Voice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UI_Voice.Scroll += new System.EventHandler(this.UI_Voice_Scroll);
            // 
            // UI_LoginTip
            // 
            this.UI_LoginTip.AutoSize = true;
            this.UI_LoginTip.BackColor = System.Drawing.Color.Transparent;
            this.UI_LoginTip.Location = new System.Drawing.Point(171, 15);
            this.UI_LoginTip.Name = "UI_LoginTip";
            this.UI_LoginTip.Size = new System.Drawing.Size(41, 12);
            this.UI_LoginTip.TabIndex = 7;
            this.UI_LoginTip.Text = "未登录";
            // 
            // UI_SettingClose
            // 
            this.UI_SettingClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UI_SettingClose.BackgroundImage")));
            this.UI_SettingClose.Location = new System.Drawing.Point(252, 0);
            this.UI_SettingClose.Name = "UI_SettingClose";
            this.UI_SettingClose.Size = new System.Drawing.Size(100, 100);
            this.UI_SettingClose.TabIndex = 27;
            this.UI_SettingClose.TabStop = false;
            this.UI_SettingClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UI_SettingClose_MouseClick);
            // 
            // UI_SaveLoginIn
            // 
            this.UI_SaveLoginIn.AutoSize = true;
            this.UI_SaveLoginIn.Location = new System.Drawing.Point(24, 67);
            this.UI_SaveLoginIn.Name = "UI_SaveLoginIn";
            this.UI_SaveLoginIn.Size = new System.Drawing.Size(48, 16);
            this.UI_SaveLoginIn.TabIndex = 19;
            this.UI_SaveLoginIn.Text = "记住";
            this.UI_SaveLoginIn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(352, 249);
            this.Controls.Add(this.UI_LoginPanel);
            this.Controls.Add(this.UI_ControlPanel);
            this.Controls.Add(this.UI_SettingClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.UI_ControlPanel.ResumeLayout(false);
            this.UI_ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Star)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Hate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_PlayTrack)).EndInit();
            this.UI_LoginPanel.ResumeLayout(false);
            this.UI_LoginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UI_Voice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_SettingClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UI_LoginTip;
        private System.Windows.Forms.TextBox UI_LoginUsername;
        private System.Windows.Forms.TextBox UI_LoginPassword;
        private System.Windows.Forms.Button UI_LoginIn;
        private System.Windows.Forms.TrackBar UI_PlayTrack;
        private System.Windows.Forms.TrackBar UI_Voice;
        private System.Windows.Forms.ComboBox UI_ChannelList;
        private System.Windows.Forms.Label UI_SongName;
        private System.Windows.Forms.Label UI_TimeTotalShow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel UI_ControlPanel;
        private System.Windows.Forms.Label UI_TimeNowShow;
        private System.Windows.Forms.Label UI_SongArtist;
        private System.Windows.Forms.Panel UI_LoginPanel;
        private System.Windows.Forms.Label UI_MsgShow;
        private System.Windows.Forms.PictureBox UI_SettingClose;
        private System.Windows.Forms.PictureBox UI_Star;
        private System.Windows.Forms.PictureBox UI_Hate;
        private System.Windows.Forms.PictureBox UI_Next;
        private System.Windows.Forms.CheckBox UI_SaveLoginIn;

    }
}

