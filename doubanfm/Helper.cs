using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DoubanFM
{

    #region helper

    public static class Helper
    {
        //程序信息
        public static string rootPath = System.Environment.CurrentDirectory;        //程序根目录路径
        public static string libraryJsonName = "librarys.json";    //json格式库文件名称（包含.json后缀：librarys.json）  以后转为本地数据库
        public static string libraryFolderName = "librarys";  //存储歌曲的库文件夹名称（librarys）
        public static string appName = "DoubanFMDown.exe";            //本程序名称(DoubanFMDown.exe)
        public static string channels = "channels.json";
        public static char[] invalidChars = Path.GetInvalidFileNameChars();     //非法文件名字符

        public static string GetUIImageFolder()
        {
            return Path.Combine(rootPath, "images");
        }

        public static string GetMP3Name(SongJson songJson)
        {
            string title = songJson.title;
            string artist = songJson.artist;
            foreach (char c in invalidChars)
            {
                title = title.Replace(c, ' ');
                artist = artist.Replace(c, ' ');
            }

            return title + " - " + artist + ".mp3";
        }

        public static string GetMP3Path(SongJson songJson, string channel_name)
        {
            string songName = Helper.GetMP3Name(songJson);
            string folderPath = Path.Combine(Path.Combine(rootPath, libraryFolderName), channel_name.ToString());
            return Path.Combine(folderPath, songName);

        }

        public static string GetPicturePath(SongJson songJson, string channel_name)
        {
            string path = GetMP3Path(songJson, channel_name);
            return Path.ChangeExtension(path, "jpg");
        }

    }
    #endregion
}
