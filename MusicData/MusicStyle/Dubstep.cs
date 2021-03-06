﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData.MusicStyle
{
    /// <summary>
    /// The dubstep music style (BPM : 138-142)
    /// </summary>
    public class Dubstep : MusicStyle
    {
        public Dubstep(): base("Dubstep", 138, 142)
        {
        }

        public Dubstep(int customBPM) : base("Dubstep", 138, 142, customBPM)
        {
        }
    }
}
