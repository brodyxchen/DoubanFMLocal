using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Threading;

namespace DoubanFM
{
    public class Httper
    {
        public string username;
        public string password;

        public string user_id;
        public string expire;
        public string token;


        string DataUrl;
        string DataParam;

        string loginUrl;
        string loginParam;

        string ChannelUrl;
        string ChannelParam;



        public Httper()
        {
            DataUrl = "http://www.douban.com/j/app/radio/people";
            DataParam = "app_name=radio_desktop_win&version=100&user_id=";// + user_id + "&expire=" + expire + "&token=" + token;

            loginUrl = "http://www.douban.com/j/app/login";
            loginParam = "app_name=radio_desktop_win&version=100&email=";// + username + "&password=" + password;

            ChannelUrl = "http://www.douban.com/j/app/radio/channels";
            ChannelParam = "";
        }



        public LoginJson Login(string username, string password)
        {
            this.username = username;
            this.password = password;

            string param =loginParam + username + "&password=" + password;
            

            string json = Post(loginUrl, param);

            LoginJson loginJson = JsonConvert.DeserializeObject<LoginJson>(json);

            user_id = loginJson.user_id;
            expire = loginJson.expire;
            token = loginJson.token;

            return loginJson;
        }

        public ChannelsJson Channels()
        {
            string json = Post(ChannelUrl, ChannelParam);
            ChannelsJson channelList = JsonConvert.DeserializeObject<ChannelsJson>(json);

            return channelList;
        }

        public SongListJson NewSongList(int channel_id)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&channel=" + channel_id + "&type=" + "n";

            string json = Post(DataUrl, param);
            SongListJson songListJson = JsonConvert.DeserializeObject<SongListJson>(json);


            return songListJson;
        }

        public SongListJson NextSongList(int channel_id, string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&channel=" + channel_id + "&type=" + "p";

            string json = Post(DataUrl, param);
            SongListJson songListJson = JsonConvert.DeserializeObject<SongListJson>(json);


            return songListJson;
        }

        public void Report(int channel_id)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&h=" + "" + "&channel=" + channel_id;

            string json = Post(DataUrl, param);
        }

        public void EndSong(string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&type=" + "e";

            string json = Post(DataUrl, param);
        }

        public void HateSong(string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&type=" + "b";

            string json = Post(DataUrl, param);
        }

        public void SkipSong(string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&type=" + "s";

            string json = Post(DataUrl, param);
        }

        public void StarSong(string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&type=" + "r";

            string json = Post(DataUrl, param);
        }

        public void UnStartSong(string sid)
        {
            string param = DataParam + user_id + "&expire=" + expire + "&token=" + token;
            param += "&sid=" + sid + "&type=" + "u";

            string json = Post(DataUrl, param);
        }



        public string Post(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.KeepAlive = true;
            Encoding encoding = Encoding.GetEncoding("utf-8");
            if ((param != null & param.Length > 0))
            {
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] b = Encoding.UTF8.GetBytes(param);
                request.ContentLength = b.Length;
                System.IO.Stream sw = null;
                try
                {
                    sw = request.GetRequestStream();
                    sw.Write(b, 0, b.Length);
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("Post Error");
                }
                finally
                {
                    if (sw != null) { sw.Close(); }
                }


            }
            using (HttpWebResponse wr = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(wr.GetResponseStream(), encoding))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }


}
