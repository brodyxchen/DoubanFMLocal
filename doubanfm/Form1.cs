using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;
using System.Timers;

namespace DoubanFM
{
    public delegate void CallbackMethodDelegate(string path);      //委托   用于回调函数

    public partial class Form1 : Form
    {
        #region 参数定义
        private Cookie cookie;
        private ArrayList channels;
        private Player player;
        private System.Windows.Forms.Timer trackTimer;             //更新歌曲进度条和时间
        private Downloader downloader;
        private Httper httper;

        private Image starGray;
        private Image starRed;

        private ChannelsJson channelsJson;

        #endregion

        #region 初始化
        public Form1()
        {
            InitializeComponent();

            InitData();
            InitUI();
            LoadLibrarys();

        }

        public void GetChannels()
        {
            channelsJson = httper.Channels();
            channels = new ArrayList();
            channels.Add(new Channel("红心兆赫", -3));
            foreach (ChannelJson item in channelsJson.channels)
            {
                channels.Add(new Channel(item.name, item.seq_id));
            }
        }

        public void InitData()
        {
            trackTimer = new System.Windows.Forms.Timer();
            trackTimer.Interval = 1000;
            trackTimer.Tick += new EventHandler(timer_Tick);

            string UIImageFolder = Helper.GetUIImageFolder();
            starGray = Image.FromFile(Path.Combine(UIImageFolder, "likeGrayOn.jpg"));
            starRed = Image.FromFile(Path.Combine(UIImageFolder, "likeRedOn.jpg"));

            player = new Player(PlayCompleted);
            downloader = new Downloader();
            httper = new Httper();

            LoadChannels();

            cookie = new Cookie();

            //实时信息
            cookie.channel = channels[1] as Channel;
            cookie.playList = new LinkedList<SongJson>();
            cookie.playListIndex = cookie.playList.First;       //null

        }

        public void InitUI()
        {
            for (int i = 0; i < channels.Count; i++)
                UI_ChannelList.Items.Add(((Channel)channels[i]).name);

            UI_ChannelList.SelectedIndex = 1;

            UI_Voice.Maximum = 100;
            UI_Voice.Minimum = 0;
            UI_Voice.TickFrequency = 5;
            UI_Voice.TickStyle = TickStyle.None;
            UI_Voice.SmallChange = 5;
            UI_Voice.LargeChange = 20;
            UI_Voice.Value = 30;

            UI_PlayTrack.Maximum = 100;
            UI_PlayTrack.Minimum = 0;
            UI_PlayTrack.TickFrequency = 1;
            UI_PlayTrack.TickStyle = TickStyle.None;
            UI_PlayTrack.Value = 0;

            UI_TimeNowShow.Text = "";
            UI_TimeTotalShow.Text = "";
            UI_SongName.Text = "";
            UI_SongArtist.Text = "";
            UI_MsgShow.Text = "停止";

            toolTip1.SetToolTip(UI_Star, "收藏");
            toolTip1.SetToolTip(UI_Hate, "不喜欢");
            toolTip1.SetToolTip(UI_Next, "下一首");

        }


        private void timer_Tick(object sender, EventArgs e)
        {
            int max = (int)(player.duration() + 0.5);
            int now = (int)player.currentPosition();
            if (max == 0)
                return;

            string a = player.currentPositionString();
            string b = player.durationString();

            if (a == null || a == "")
                return;

            if (now > max)
            {
                trackTimer.Stop();
                return;
            }

            UI_TimeNowShow.Text = a;
            UI_TimeTotalShow.Text = b;

            UI_PlayTrack.Maximum = max;
            UI_PlayTrack.Value = now;

            if (UI_MsgShow.Text.Trim().Equals("Loading..."))
            {
                UI_MsgShow.Text = "";
            }

        }


        #endregion

        #region 加载和保存数据

        public void LoadChannels()
        {
            string path = Path.Combine(Helper.rootPath, Helper.channels);
            if (File.Exists(path))
            {
                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    List<Channel> list = (List<Channel>)serializer.Deserialize(file, typeof(List<Channel>));
                    channels = new ArrayList(list);
                }
            }

        }

        public void LoadLibrarys()
        {
            //if (File.Exists(Path.Combine(Helper.rootPath, Helper.libraryJsonName)))
            //{
            //    using (StreamReader file = File.OpenText(Path.Combine(Helper.rootPath, Helper.libraryJsonName)))
            //    {
            //        JsonSerializer serializer = new JsonSerializer();
            //        librarys = (Dictionary<int, HashSet<string>>)serializer.Deserialize(file, typeof(Dictionary<int, HashSet<string>>));
            //    }
            //}
            //else
            //{
            //    librarys = new Dictionary<int, HashSet<string>>();
            //}

        }
        public void SaveLibrarys()
        {
            //string json = JsonConvert.SerializeObject(librarys, Formatting.Indented);
            //File.WriteAllText(Path.Combine(Helper.rootPath, Helper.libraryJsonName), json);
        }

        public void DeleteLibrarys()
        {
            //string path = Path.Combine(Helper.rootPath, Helper.libraryJsonName);
            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}
        }

        public void TimeSaveLibrarys()
        {
            //定时保存数据
        }
        #endregion

        #region 后台处理

        public void UpdateTracks()
        {
            //切换歌曲
            if (cookie.playList.Count == 0)
            {//初始  或者  切换频道
                SongListJson songListJson = null;
                int count = 0;
                do
                {
                    songListJson = httper.NewSongList(cookie.channel.channel_id);
                    UI_MsgShow.Text = "获取歌曲列表失败";
                    count++;
                } while (songListJson.r == 1 && count < 5);

                foreach (SongJson item in songListJson.song)
                {
                    item.exist = true;
                    item.downloading = false;
                    item.skipped = false;
                    cookie.playList.AddLast(item);

                    string path = Helper.GetMP3Path(item, cookie.channel.name);
                    item.exist = File.Exists(path);
                }

                cookie.playListIndex = cookie.playList.First;

            }
            else if (cookie.playListIndex.Next == null)
            {//播放到列表末尾

                SongListJson songListJson = null;
                int count = 0;
                do
                {
                    songListJson = httper.NewSongList(cookie.channel.channel_id);
                    UI_MsgShow.Text = "获取歌曲列表失败";
                    count++;
                } while (songListJson.r == 1 && count < 5);


                foreach (SongJson item in songListJson.song)
                {
                    item.exist = true;
                    item.downloading = false;
                    item.skipped = false;
                    cookie.playList.AddLast(item);

                    string path = Helper.GetMP3Path(item, cookie.channel.name);
                    item.exist = File.Exists(path);

                }

                cookie.playListIndex = cookie.playListIndex.Next;

            }
            else
            {
                cookie.playListIndex = cookie.playListIndex.Next;

            }
        }

        public void UpdateUI()
        {
            //UI处理
            UI_PlayTrack.Value = 0;
            UI_SongName.Text = cookie.playListIndex.Value.title;
            UI_SongArtist.Text = cookie.playListIndex.Value.artist;
            toolTip1.SetToolTip(UI_SongName, UI_SongName.Text);
            toolTip1.SetToolTip(UI_SongArtist, UI_SongArtist.Text);

            if (cookie.channel.channel_id == -3 || cookie.playListIndex.Value.like == 1)
            {
                UI_Star.BackgroundImage = starRed;
            }
            else
            {
                UI_Star.BackgroundImage = starGray;
            }
            UI_TimeNowShow.Text = "";
            UI_TimeTotalShow.Text = "";
            UI_MsgShow.Text = "Loading...";
        }

        public void DownloadSong()
        {
            //下载歌曲
            for (LinkedListNode<SongJson> index = cookie.playListIndex; index != null; index = index.Next)
            {
                string remotePath = index.Value.url;
                string localPath = Helper.GetMP3Path(index.Value, cookie.channel.name);

                if (!index.Value.downloading && !File.Exists(localPath))
                {
                    index.Value.exist = false;
                    index.Value.downloading = true;

                    downloader.PushBack(remotePath, localPath, DownloadFinish);
                }

                //string pictureRemotePath = index.Value.picture;
                //string pictureLocalPath = Helper.GetPicturePath(index.Value, cookie.channel.name);

                //if (!File.Exists(pictureLocalPath))
                //{
                //    downloader.PushBack(pictureRemotePath, pictureLocalPath, DownloadPictureFinish);
                //}
            }

            downloader.Start();
        }


        public void PlaySong()
        {
            if (cookie.playListIndex.Value.exist)
            {
                string path = Helper.GetMP3Path(cookie.playListIndex.Value, cookie.channel.name);
                player.Play(path);
                trackTimer.Start();

                //UpdatePicture();
            }

        }

        //public void UpdatePicture()
        //{
        //    string pictureLocalPath = Helper.GetPicturePath(cookie.playListIndex.Value, cookie.channel.name);
        //    if (File.Exists(pictureLocalPath))
        //    {
        //        UI_SongPicture.BackgroundImage = Image.FromFile(pictureLocalPath);
        //    }
        //}

        private void PlayCompleted(string msg)
        {
            NextSong();
        }

        public void NextSong()
        {
            player.Stop();
            trackTimer.Stop();
            UpdateTracks();
            UpdateUI();

            DownloadSong();
            PlaySong();

        }

        public void DownloadFinish(string path)
        {
            for (LinkedListNode<SongJson> item = cookie.playListIndex; item != null; item = item.Next)
            {
                string tempPath = Helper.GetMP3Path(item.Value, cookie.channel.name);
                if (tempPath.Equals(path))
                {
                    item.Value.exist = true;
                    break;
                }
            }

            string currentPath = Helper.GetMP3Path(cookie.playListIndex.Value, cookie.channel.name);
            if (path.Equals(currentPath))
            {
                PlaySong();
            }
        }

        //public void DownloadPictureFinish(string path)
        //{
        //    string pictureLocalPath = Helper.GetPicturePath(cookie.playListIndex.Value, cookie.channel.name);

        //    if (pictureLocalPath.Equals(path) && UI_SongPicture.BackgroundImage == null)
        //    {
        //        UpdatePicture();
        //    }
        //}

        #endregion

        #region 界面操作

        private void UI_LoginIn_Click(object sender, EventArgs e)
        {
            LoginJson loginJson = null;

            loginJson = httper.Login(UI_LoginUsername.Text.Trim(), UI_LoginPassword.Text.Trim());

            if (loginJson.r == 1)
            {
                UI_MsgShow.Text = loginJson.err;
                return;
            }


            cookie.user_id = loginJson.user_id;
            cookie.expire = loginJson.expire;
            cookie.token = loginJson.token;


            cookie.channel = channels[1] as Channel;

            UI_LoginTip.Text = loginJson.user_name;

            UI_LoginPanel.Visible = false;
        }



        private void UI_Voice_Scroll(object sender, EventArgs e)
        {
            player.Volume(UI_Voice.Value);
        }

        private void UI_ChannelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cookie.channel = channels[UI_ChannelList.SelectedIndex] as Channel;
            if (cookie.playList.Count == 0)
            {
                return;
            }
            else
            {
                cookie.playList.Clear();
                cookie.playListIndex = null;
            }
            NextSong();
        }



        private void UI_PlayTrack_Scroll(object sender, EventArgs e)
        {
            int value = UI_PlayTrack.Value;
            player.Jump(value);
        }

        #endregion

        bool IsMouseDown = false;
        Point downPoint = new Point();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                downPoint = new Point(-e.X, -e.Y);
                IsMouseDown = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                Point movePoint = Control.MousePosition;
                movePoint.Offset(downPoint.X, downPoint.Y);
                ((System.Windows.Forms.Form)sender).Location = movePoint;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = false;
            }
        }

        private void UI_ClosePicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Close();
            }
        }


        private void UI_SettingClose_MouseClick(object sender, MouseEventArgs e)
        {

            Point p = new Point(e.X, e.Y);
            bool line1 = (e.X - e.Y > 0);
            bool line2 = (e.X - e.Y - 50 < 0);
            if (e.Button == MouseButtons.Left && (line1 && line2))
            {
                //点击了设置
                UI_LoginPanel.Visible = !UI_LoginPanel.Visible;

            }
            else if (e.Button == MouseButtons.Left && (line1 && !line2))
            {//左键点击了X  关闭
                SaveLibrarys();
                this.Close();
            }
            else if (e.Button == MouseButtons.Right && (line1 && !line2))
            {//右键点击了X  最小化
                this.WindowState = FormWindowState.Minimized;
            }

        }

        private void UI_Star_MouseClick(object sender, MouseEventArgs e)
        {
            if (cookie.channel.channel_id == -3 || UI_Star.BackgroundImage == starRed)
            {
                UI_Star.BackgroundImage = starGray;
                httper.UnStartSong(cookie.playListIndex.Value.sid);
                cookie.playListIndex.Value.like = 0;

            }
            else
            {
                UI_Star.BackgroundImage = starRed;
                httper.StarSong(cookie.playListIndex.Value.sid);
                cookie.playListIndex.Value.like = 1;
            }
        }

        private void UI_Hate_MouseClick(object sender, MouseEventArgs e)
        {
            httper.HateSong(cookie.playListIndex.Value.sid);
            NextSong();
        }

        private void UI_Next_MouseClick(object sender, MouseEventArgs e)
        {
            if (cookie.playList != null && cookie.playList.Count > 0)
                cookie.playListIndex.Value.skipped = true;
            NextSong();
        }

        string lastMsgText = "";
        private void UI_SongName_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool IsPause = player.Pause();
                if (IsPause)
                {
                    lastMsgText = UI_MsgShow.Text;
                    UI_MsgShow.Text = "暂停中";
                }
                else
                {
                    UI_MsgShow.Text = lastMsgText;
                }
            }
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Hotkey.Regist(this.Handle, HotkeyModifiers.MOD_CONTROL, Keys.Right, RegisterHotkey);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            downloader.Stop();
            player.Pause();
            SaveLibrarys();
            Hotkey.UnRegist(this.Handle, RegisterHotkey);
        }

        private void RegisterHotkey()
        {
            if (cookie.playList != null && cookie.playList.Count > 0)
                cookie.playListIndex.Value.skipped = true;
            NextSong();
        }

    }

}
