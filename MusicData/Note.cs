using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MusicData
{
    /// <summary>
    /// A music note has a duration (in beat) and a frequence (defined by enum). Define a way to be played and is serializable.
    /// </summary>
    [Serializable]
    public class Note : IPlayMusic, ISerializable
    {
        public float Duration { get; set; }
        public Frequence MaFrequence { get; set; }

        public Note(float duration, Frequence frequence)
        {
            Duration = duration;
            MaFrequence = frequence;
        }

        public Note(SerializationInfo info, StreamingContext ctxt)
        {
            Duration = (float)info.GetValue("Duration", typeof(float));
            MaFrequence = (Frequence)info.GetValue("MaFrequence", typeof(Frequence));
        }

        /// <summary>
        /// Play music with 1 beat per second style. Only writing in console if muted is true
        /// </summary>
        /// <param name="muted">No beep if true</param>
        public void PlayMusic(bool muted)
        {
            PlayMusic(new MusicStyle._60BPMStyle(), muted);
        }

        /// <summary>
        /// Play the music with the style. Only writing in console if muted is true
        /// </summary>
        /// <param name="style">The style used to play the note</param>
        /// <param name="muted">No beep if true</param>
        public void PlayMusic(MusicStyle.MusicStyle style, bool muted)
        {
            Console.Write((MaFrequence).ToString() + " - ");
            Console.WriteLine(((int)style.ConvertInSeconds(Duration * 1000, style.BPM)).ToString() + " ms");
            if (muted)
            {
                System.Threading.Thread.Sleep((int)MaFrequence + (int)style.ConvertInSeconds(Duration, style.BPM));
            }
            else
            {
                Console.Beep((int)MaFrequence, ((int)style.ConvertInSeconds(Duration*1000, style.BPM)));
            }
        }

        public override string ToString()
        {
            return MaFrequence.ToString() + " " + Duration;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Duration", Duration);
            info.AddValue("MaFrequence", MaFrequence);
        }
    }

    /// <summary>
    /// Possible frequences for a note
    /// </summary>
    public enum Frequence
    {
        Silence = 0,
        Do = 262,
        Dod = 277,
        Re = 294,
        Red = 311,
        Mi = 330,
        Fa = 349,
        Fad = 370,
        Sol = 392,
        Sold = 415,
        La = 440,
        Lad = 466,
        Si = 494
    }

    

}
