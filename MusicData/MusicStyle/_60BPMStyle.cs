﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData.MusicStyle
{
    public class _60BPMStyle : MusicStyle
    {

        /// <summary>
        /// A real-time music style (1 beat = 1 second)
        /// </summary>
        public _60BPMStyle() : base("60BPM", 60, 60)
        {
        }

        public _60BPMStyle(int customBPM) : this()
        {
        }
    }
}
