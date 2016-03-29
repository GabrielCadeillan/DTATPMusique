using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData.MusicStyle
{
    /// <summary>
    /// The HipHop music style (BPM 80-100)
    /// </summary>
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
