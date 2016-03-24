using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMusique
{
    class NoteTest
    {
        public Track testTrack { get; set; }

        public NoteTest()
        {
            testTrack = new Track();
            testTrack.Notes.Add(new Note(0.1f, Frequence.Do));
            testTrack.Notes.Add(new Note(0.1f, Frequence.Fa));
            testTrack.Notes.Add(new Note(0.3f, Frequence.Fad));
            testTrack.Notes.Add(new Note(0.4f, Frequence.Dod));
            testTrack.Notes.Add(new Note(0.1f, Frequence.Si));
            testTrack.Notes.Add(new Note(0.2f, Frequence.La));
            testTrack.Notes.Add(new Note(0.125f, Frequence.La));
            testTrack.Notes.Add(new Note(0.2f, Frequence.Mi));
        }
    }
}
