using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData.MusicStyle
{
    /// <summary>
    /// A music style has a name, a bpm (contained in a ranged defined by children), and define a way to convert beat to seconds.
    /// </summary>
    abstract public class MusicStyle : ISecondsConverter
    {
        public string Name { get; protected set; }
        public int BPMMin { get; private set; }
        public int BPMMax { get; private set; }
        public int BPM { get; protected set; }
        protected int BPMMean { get { return (BPMMin + BPMMax) / 2; } }


        public MusicStyle(string name, int bpmmin, int bpmmax)
        {
            Name = name;
            BPMMin = bpmmin;
            BPMMax = bpmmax;
            BPM = BPMMean;
        }

        public MusicStyle(string name, int bpmmin, int bpmmax, int customBPM)
        {
            Name = name;
            BPMMin = bpmmin;
            BPMMax = bpmmax;

            if (customBPM < BPMMin)
                BPM = BPMMin;
            else if (customBPM > BPMMax)
                BPM = BPMMax;
            else
                BPM = customBPM;
        }

        public float ConvertInSeconds(float duration, int bpm)
        {
            return duration / ((float)bpm / 60f);
        }
    }
}
