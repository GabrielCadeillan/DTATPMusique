using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMusique.MusicStyle
{
    class HipHop : MusicStyle
    {
        public HipHop()
        {
            Name = "HipHop";
            BPMMin = 80;
            BPMMax = 100;
            BPM = BPMMean;
        }

        public HipHop(int customBPM) : this()
        {
            if (customBPM < BPMMin)
                BPM = BPMMin;
            else if (customBPM > BPMMax)
                BPM = BPMMax;
            else
                BPM = customBPM;
        }
    }
}
