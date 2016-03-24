using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMusique.MusicStyle
{
    class Dubstep : MusicStyle
    {
        public Dubstep()
        {
            Name = "Dubstep";
            BPMMin = 138;
            BPMMax = 142;
            BPM = BPMMean;
        }

        public Dubstep(int customBPM) : this()
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
