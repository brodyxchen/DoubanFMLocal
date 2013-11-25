using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubanFM
{
    class State
    {
    }
    public enum PlayState
    {
        Undefined, Stopped, Paused, Playing, Buffering, Waiting, Ended
    };
}
