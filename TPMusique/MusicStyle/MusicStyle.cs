using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMusique.MusicStyle
{
    abstract class MusicStyle : IStyle
    {
        public string Name { get; protected set; }
        public int BPMMin { get; protected set; }
        public int BPMMax { get; protected set; }
        public int BPM { get; protected set; }
        protected int BPMMean { get { return (BPMMin + BPMMax) / 2; } }

        public float ConvertInSeconds(float duration, int bpm)
        {
            return duration / ((float)bpm / 60f);
        }
    }
}
