using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    public delegate void UEventHandlerTrackerSymbolReceive(object sender);
    public delegate void UEventHandlerTrackerResearchSymbolReceive(object sender, CDDEASymbolS cSymbolS, out string[] saLogData);
}
