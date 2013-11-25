using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanFM
{
    public class JsonHelpler
    {
    }

    public class LoginJson
    {
        public string user_id { get; set; }
        public string err { get; set; }
        public string token { get; set; }
        public string expire { get; set; }
        public int r { get; set; }
        public string user_name { get; set; }
        public string email { get; set; }
        
    }

    public class ChannelJson
    {
        public string name { get; set; }
        public int seq_id { get; set; }
        public string abbr_en { get; set; }
        public int channel_id { get; set; }
        public string name_en { get; set; }
    }

    public class SongJson
    {
        public string album { get; set; }
        public string picture { get; set; }
        public string ssid { get; set; }
        public string artist { get; set; }
        public string url { get; set; }
        public string company { get; set; }
        public string title { get; set; }
        public double rating_avg { get; set; }
        public int length { get; set; }
        public string subtype { get; set; }
        public string public_time { get; set; }
        public string sid { get; set; }
        public string aid { get; set; }
        public string sha256 { get; set; }
        public string kbps { get; set; }
        public string albumtitle { get; set; }
        public int like { get; set; }
    }

    public class SongListJson
    {
        public int r { get; set; }
        public int version_max { get; set; }
        public IList<SongJson> song { get; set; }
    }



}
