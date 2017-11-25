using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOTL.Common.Remote
{
    public delegate void UEventHandlerClientConnected(object sender, string sClient);
    public delegate void UEventHandlerClientDisconnected(object sender, string sClient);
    public delegate void UEventHandlerDataRecieved(object sender, string sKey, string[] saData);
    public delegate void UEventHandlerDataResearch(object sender, string sKey, string[] saData);
}
