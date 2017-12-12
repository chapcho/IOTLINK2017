using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    public delegate void UEventHandlerMainMessage(object sender, string sSender, string sMessage);
    public delegate void UEventHandlerServerStateChange(object sender, bool bRun);
}
