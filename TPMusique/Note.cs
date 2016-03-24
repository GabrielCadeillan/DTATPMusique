using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TPMusique
{
    [Serializable]
    class Note : IPlayMusic, ISerializable
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

        public void PlayMusic()
        {
            PlayMusic(new MusicStyle._60BPMStyle());
        }

        public void PlayMusic(MusicStyle.MusicStyle style)
        {
            if (Menu.Muted)
            {
                Console.WriteLine("Note joué : " + MaFrequence.ToString() + " pendant " + style.ConvertInSeconds(Duration, style.BPM).ToString() + " secondes.  ("+Duration.ToString()+" temps)");
                System.Threading.Thread.Sleep((int)MaFrequence + (int)style.ConvertInSeconds(Duration, style.BPM));
            }
            else
            {
                Console.WriteLine(((int)MaFrequence).ToString());
                Console.WriteLine(((int)style.ConvertInSeconds(Duration*1000, style.BPM)).ToString());
                Console.Beep((int)MaFrequence, ((int)style.ConvertInSeconds(Duration*10000, style.BPM)));
              
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

    enum Frequence
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
