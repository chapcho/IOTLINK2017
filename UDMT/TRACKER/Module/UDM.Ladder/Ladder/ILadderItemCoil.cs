using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public interface ILadderItemCoil
    {
        Pen Pen { get; set; }
        string DateFormat { get; set; }
        CCoil Coil { get; set; }
        bool Value { get; set; }

    }
}
