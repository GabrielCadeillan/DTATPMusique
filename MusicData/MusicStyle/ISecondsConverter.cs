using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicData
{
    /// <summary>
    /// The implementer must define a way to convert in seconds a beat duration from a BPM
    /// </summary>
    public interface ISecondsConverter
    {
        float ConvertInSeconds(float duration, int BPM);
    }
}
