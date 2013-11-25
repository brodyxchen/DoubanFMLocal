using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoubanFM
{
    class Cookie
    {
        //登录信息
        public string user_id { get; set; }
        public string expire { get; set; }
        public string token { get; set; }



        //实时信息
        public Channel channel { get; set; }
        public LinkedList<SongJson> playList { get; set; }
        public LinkedListNode<SongJson> playListIndex { get; set; }
        public bool starred { get; set; }
        public PlayState currentPlayState { get; set; }
    }
}
