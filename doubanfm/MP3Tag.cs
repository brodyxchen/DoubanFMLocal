using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoubanFM
{
    public class MediaTags
    {
        #region Mp3文件属性
        //// 

        /// 标题
        /// 

        [MediaProperty("Title")]
        public string Title { get; set; }

        /// 

        /// 子标题
        /// 

        [MediaProperty("Media.SubTitle")]
        public string SubTitle { get; set; }

        /// 

        /// 星级
        /// 

        [MediaProperty("Rating")]
        public uint? Rating { get; set; }

        /// 

        /// 备注
        /// 

        [MediaProperty("Comment")]
        public string Comment { get; set; }

        /// 

        /// 艺术家
        /// 

        [MediaProperty("Author")]
        public string Author { get; set; }

        /// 

        /// 唱片集
        /// 

        [MediaProperty("Music.AlbumTitle")]
        public string AlbumTitle { get; set; }

        /// 

        /// 唱片集艺术家
        /// 

        [MediaProperty("Music.AlbumArtist")]
        public string AlbumArtist { get; set; }

        /// 

        /// 年
        /// 

        [MediaProperty("Media.Year")]
        public uint? Year { get; set; }

        /// 

        /// 流派
        /// 

        [MediaProperty("Music.Genre")]
        public string Genre { get; set; }

        /// 

        /// #
        /// 

        [MediaProperty("Music.TrackNumber")]
        public uint? TrackNumber { get; set; }

        /// 

        /// 播放时间
        /// 

        [MediaProperty("Media.Duration")]
        public string Duration { get; private set; }

        /// 

        /// 比特率
        /// 

        [MediaProperty("Audio.EncodingBitrate")]
        public string BitRate { get; private set; }
        #endregion

        public MediaTags(string mediaPath)
        {
            //var obj = ShellObject.FromParsingName(mp3Path);   //缩略图，只读
            //obj.Thumbnail.Bitmap.Save(@"R:/2.jpg");

            Init(mediaPath);
        }

        void Init(string mediaPath)
        {
            using (var obj = ShellObject.FromParsingName(mediaPath))
            {
                var mediaInfo = obj.Properties;
                foreach (var properItem in this.GetType().GetProperties())
                {
                    var mp3Att = properItem.GetCustomAttributes(typeof(MediaPropertyAttribute), false).FirstOrDefault();
                    var shellProper = mediaInfo.GetProperty("System." + mp3Att);
                    var value = shellProper == null ? null : shellProper.ValueAsObject;

                    if (value == null)
                    {
                        continue;
                    }

                    if (shellProper.ValueType == typeof(string[]))    //艺术家，流派等多值属性
                    {
                        properItem.SetValue(this, string.Join(";", value as string[]), null);
                    }
                    else if (properItem.PropertyType != shellProper.ValueType)    //一些只读属性，类型不是string，但作为string输出，避免转换 如播放时间，比特率等
                    {
                        properItem.SetValue(this, value == null ? "" : shellProper.FormatForDisplay(PropertyDescriptionFormat.Default), null);
                    }
                    else
                    {
                        properItem.SetValue(this, value, null);
                    }
                }
            }
        }

        public void Commit(string mp3Path)
        {
            var old = new MediaTags(mp3Path);

            using (var obj = ShellObject.FromParsingName(mp3Path))
            {
                var mediaInfo = obj.Properties;
                foreach (var proper in this.GetType().GetProperties())
                {
                    var oldValue = proper.GetValue(old, null);
                    var newValue = proper.GetValue(this, null);

                    if (oldValue == null && newValue == null)
                    {
                        continue;
                    }

                    // 这里做了修改  郭红俊 20091202
                       // 原先在旧值存在，新值没有给出时，会有空对象引用的bug
                    //if (oldValue == null || !oldValue.Equals(newValue))

                    // 新的逻辑 新值存在时， 则替换旧值
                    if ((newValue != null) && (newValue.ToString().Trim().Length > 0) && (newValue != oldValue))
                    {
                        var mp3Att = proper.GetCustomAttributes(typeof(MediaPropertyAttribute), false).FirstOrDefault();
                        var shellProper = mediaInfo.GetProperty("System." + mp3Att);
                        Console.WriteLine(mp3Att);

                        if (newValue == null) newValue = string.Empty;

                        SetPropertyValue(shellProper, newValue);
                    }
                }
            }
        }

        #region SetPropertyValue
        static void SetPropertyValue(IShellProperty prop, object value)
        {
            if (prop.ValueType == typeof(string[]))        //只读属性不会改变，故与实际类型不符的只有string[]这一种
            {
                string[] values = (value as string).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                (prop as ShellProperty<string[]>).Value = values;
            }
            if (prop.ValueType == typeof(string))
            {
                (prop as ShellProperty<string>).Value = value as string;
            }
            else if (prop.ValueType == typeof(ushort?))
            {
                (prop as ShellProperty<ushort?>).Value = value as ushort?;
            }
            else if (prop.ValueType == typeof(short?))
            {
                (prop as ShellProperty<short?>).Value = value as short?;
            }
            else if (prop.ValueType == typeof(uint?))
            {
                (prop as ShellProperty<uint?>).Value = value as uint?;
            }
            else if (prop.ValueType == typeof(int?))
            {
                (prop as ShellProperty<int?>).Value = value as int?;
            }
            else if (prop.ValueType == typeof(ulong?))
            {
                (prop as ShellProperty<ulong?>).Value = value as ulong?;
            }
            else if (prop.ValueType == typeof(long?))
            {
                (prop as ShellProperty<long?>).Value = value as long?;
            }
            else if (prop.ValueType == typeof(DateTime?))
            {
                (prop as ShellProperty).Value = value as DateTime?;
            }
            else if (prop.ValueType == typeof(double?))
            {
                (prop as ShellProperty<double?>).Value = value as double?;
            }
        }
        #endregion

        #region MediaPropertyAttribute
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
        sealed class MediaPropertyAttribute : Attribute
        {
            public string PropertyKey { get; private set; }
            public MediaPropertyAttribute(string propertyKey)
            {
                this.PropertyKey = propertyKey;
            }

            public override string ToString()
            {
                return PropertyKey;
            }
        }
        #endregion
    }

}
}
