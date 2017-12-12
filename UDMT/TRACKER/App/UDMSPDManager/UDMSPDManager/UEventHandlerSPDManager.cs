using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDMSPDManager
{
    public delegate void UEventHandlerSendLogStringArray(string[] saSendData);
    public delegate void UEventHandlerMessage(string sSender, string sMessage);
}
