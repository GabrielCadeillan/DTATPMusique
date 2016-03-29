using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TPMusic;
using MusicData;

namespace TPMusic
{
    static class Menu
    {
        public static bool Muted = false;

        /// <summary>
        /// Affiche le menu principal dans la console
        /// </summary>
        public static void AfficherMenu()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Bonjour ! Que voulez-vous faire ?");
                Console.WriteLine("1. Composer une piste");
                Console.WriteLine("2. Jouer la piste enregistrée");
                //Console.WriteLine("3. Jouer une chanson");
                //Console.WriteLine("4. Regarder les styles de musiques");
                switch (Console.ReadLine())
                {
                    case "":
                        quit = true;
                        break;
                    case "1":
                        ComposeTrack();
                        break;
                    case "2":
                        PlayTrack(GetRecordedTrack());
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Create a track then add notes to it with user input
        /// </summary>
        private static void ComposeTrack()
        {
            Console.WriteLine("Entrez votre composition");
            Track track = new Track();

            bool composing = true;
            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        track.Notes.Add(new Note(1f, Frequence.Do));
                        break;
                    case ConsoleKey.D:
                        track.Notes.Add(new Note(1f, Frequence.Fad));
                        break;
                    case ConsoleKey.E:
                        track.Notes.Add(new Note(1f, Frequence.Mi));
                        break;
                    case ConsoleKey.F:
                        track.Notes.Add(new Note(1f, Frequence.Sold));
                        break;
                    case ConsoleKey.G:
                        track.Notes.Add(new Note(1f, Frequence.Lad));
                        break;
                    case ConsoleKey.Q:
                        track.Notes.Add(new Note(1f, Frequence.Dod));
                        break;
                    case ConsoleKey.R:
                        track.Notes.Add(new Note(1f, Frequence.Fa));
                        break;
                    case ConsoleKey.S:
                        track.Notes.Add(new Note(1f, Frequence.Red));
                        break;
                    case ConsoleKey.T:
                        track.Notes.Add(new Note(1f, Frequence.Sol));
                        break;
                    case ConsoleKey.U:
                        track.Notes.Add(new Note(1f, Frequence.Si));
                        break;
                    case ConsoleKey.Y:
                        track.Notes.Add(new Note(1f, Frequence.La));
                        break;
                    case ConsoleKey.Z:
                        track.Notes.Add(new Note(1f, Frequence.Re));
                        break;
                    case ConsoleKey.Spacebar:
                        track.Notes.Add(new Note(1f, Frequence.Silence));
                        break;
                    case ConsoleKey.Enter:
                        composing = false;
                        break;
                    default:
                        break;
                }
                if (track.Notes.Count >= 1)
                    track.Notes[track.Notes.Count - 1].PlayMusic(true);
            } while (composing);

            foreach (Note n in track.Notes)
            {
                Console.Out.WriteLine(n.MaFrequence);
            }

            Console.Out.WriteLine("Voulez vous enregistrer la piste ?");
            if (Console.In.ReadLine() == "o")
            {
                RecordTrack(track);
            }
            else
            {
                Console.Out.WriteLine("Comme vous voulez");
            }


            Console.ReadKey();

        }

        /// <summary>
        /// Play the track in parameter, with user input to decide in wich style and BPM
        /// </summary>
        /// <param name="track">The track that gonna be played</param>
        public static void PlayTrack(IPlayMusic track)
        {
            Console.WriteLine("Quel style tu veut écouter ?");
            Console.WriteLine("1. Hip Hop");
            Console.WriteLine("2. Dubstep");
            MusicData.MusicStyle.MusicStyle styleChosen = null;
            switch (Console.ReadLine())
            {
                case "1":
                    styleChosen = new MusicData.MusicStyle.HipHop();
                    break;
                case "2":
                    styleChosen = new MusicData.MusicStyle.Dubstep();
                    break;
                default:
                    break;
            }
            if (styleChosen == null)
                return;
            Console.WriteLine("Quel BPM veut-tu ?? (Minimum : " + styleChosen.BPMMin.ToString() + " Maximum : " + styleChosen.BPMMax.ToString() + ").");
            int res;
            if (int.TryParse(Console.ReadLine(), out res))
            {
                if (styleChosen.GetType() == new MusicData.MusicStyle.HipHop().GetType())
                {
                    styleChosen = new MusicData.MusicStyle.HipHop(res);
                }
                if (styleChosen.GetType() == new MusicData.MusicStyle.Dubstep().GetType())
                {
                    styleChosen = new MusicData.MusicStyle.Dubstep(res);
                }
            }
            track.PlayMusic(styleChosen, Muted);
        }

        /// <summary>
        /// Record the track in parameter into the MyTrack/track file (binary serialization)
        /// </summary>
        /// <param name="track">The track recorded</param>
        public static void RecordTrack(Track track)
        {

            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/MyTrack"))
            {
                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/MyTrack");
            }

            IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream buffer = System.IO.File.Open(AppDomain.CurrentDomain.BaseDirectory + "/MyTrack/track", System.IO.FileMode.OpenOrCreate);
            formatter.Serialize(buffer, track);
            buffer.Close();
        }

        /// <summary>
        /// Deserialize the track in the MyTrack/track file and return it
        /// </summary>
        /// <returns>The track deserialized</returns>
        public static Track GetRecordedTrack()
        {
            IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream buffer = System.IO.File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "/MyTrack/track");
            Track track = formatter.Deserialize(buffer) as Track;
            buffer.Close();
            return track;
        }
    }
}
