using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanFM
{
    public class Channel
    {
        public string name { get; set; }
        public int channel_id { get; set; }

        public Channel(string name, int channel_id)
        {
            this.name = name;
            this.channel_id = channel_id;
        }
    }

}
