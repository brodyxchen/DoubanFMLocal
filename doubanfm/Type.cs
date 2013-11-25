using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanFM
{
    //static class Type
    //{
    //    public static string HateSong = "b";   //讨厌这首歌
    //    public static string EndSong = "e";    //这首歌播放完毕,还有歌曲
    //    public static string NewSongList = "n";    //没有歌曲，需要新播放列表
    //    public static string NextSongList = "p";//还有歌曲，需要新播放列表
    //    public static string SkipSong = "s";   //跳过这首歌
    //    public static string StarSong = "r";   //喜欢这首歌
    //    public static string UnStarSong = "u"; //取消喜欢这首歌

    //    public static string Nothing = ""; //不需要类型
    //}

    public enum Type
    {
        LoginIn, GetChannel, HateSong, EndSong, NewSongList, NextSongList, SkipSong, StarSong, UnStartSong, Report
    };
}
