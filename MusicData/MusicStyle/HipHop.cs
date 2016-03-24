using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData.MusicStyle
{
    public class HipHop : MusicStyle
    {
        public HipHop() : base ("HipHop", 80, 100)
        {
        }


        public HipHop(int customBPM) : base("HipHop", 80, 100, customBPM)
        {   
        }
    }
}
