using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public enum EMCoilType
    {
        None,
        Bit,
        Timer,
        Counter,
        Maths,
        Move,
        ProgramControl,
        Convertor,
        ASCII,
        Other
    }
}
