using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public interface ILadderItemFB
    {
        Pen Pen { get; set; }
        string DateFormat { get; set; }
        CFB_Info FB_Info { get; set; }
        bool Value { get; set; }
    }
}
