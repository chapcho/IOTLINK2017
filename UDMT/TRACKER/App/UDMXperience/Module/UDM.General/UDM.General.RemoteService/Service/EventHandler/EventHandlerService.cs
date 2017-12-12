using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.General.RemoteService
{
    public delegate void UEventHandlerClientConnected(object sender, string sClient);
    public delegate void UEventHandlerClientDisconnected(object sender, string sClient);
    public delegate void UEventHandlerServerTerminated(object sender);
}
