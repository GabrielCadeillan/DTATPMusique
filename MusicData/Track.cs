using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicData
{
    [Serializable]
    public class Track : IPlayMusic, ISerializable
    {
        public List<Note> Notes;

        public Track()
        {
            Notes = new List<Note>();
        }

        public Track(SerializationInfo info, StreamingContext ctxt)
        {
            Notes = new List<Note>();
            for (int i=0; i<info.MemberCount; i++)
            {
               Notes.Add((Note)info.GetValue("Note" + i.ToString(), typeof(Note)));
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            int i = 0;
            foreach(Note note in Notes)
            {
                info.AddValue("Note"+i.ToString(), note);
                i++;
            }
        }

        public void PlayMusic(MusicStyle.MusicStyle style, bool muted)
        {
            foreach(Note note in Notes)
            {
                note.PlayMusic(style, muted);
                //Console.WriteLine("Spleep 0.5");
            }
        }

        public override string ToString()
        {
            string notesString="";
            foreach (var note in Notes)
            {
                notesString += note.ToString() +"\n" ;
            }

            return notesString;

        }
    }
}
