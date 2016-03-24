using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMusique
{
    interface IStyle
    {
        float ConvertInSeconds(float duration, int BPM);
    }
}
