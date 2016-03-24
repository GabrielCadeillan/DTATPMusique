using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP

namespace TPMusique
{
    class Song : IPlayMusic
    {
        public List<Track> Tracks { get; set; }

        public Song()
        {
            Tracks = new List<Track>();
        }

        public void PlayMusic(MusicStyle.MusicStyle style)
        {
            foreach (var track in Tracks)
            {
                track.PlayMusic(style);
            }
        }

        public override string ToString()
        {
            string notesString = "";
            foreach (var track in Tracks)
            {
                notesString += track.ToString() + "\n";
            }

            return notesString;
        }

    }
}
