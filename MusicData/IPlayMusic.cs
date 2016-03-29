using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData
{
    /// <summary>
    /// The implementer must define a way to play music with a style
    /// </summary>
    public interface IPlayMusic
    {
        void PlayMusic(MusicStyle.MusicStyle style, bool muted);
    }
}
