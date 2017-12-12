using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public interface ILadderItemContact
    {
        Pen Pen { get; set; }
        string DateFormat { get; set; }
        CContact Contact { get; set; }
        bool Value { get; set; }
        //CFB_Info FB_Info { get; set; }
    }
}
