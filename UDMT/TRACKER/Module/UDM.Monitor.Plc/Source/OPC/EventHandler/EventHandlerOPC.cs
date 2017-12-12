using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.OPC
{  

    public delegate void UEventHandlerOPCItemValueChanged(object sender, string sGroupName, int iCount, Array arHandles, Array arValues, Array arTimeStamp);

    public delegate void UEventHandlerOPCServerInitialized(object sender, COPCServer cOPCServer);
}
