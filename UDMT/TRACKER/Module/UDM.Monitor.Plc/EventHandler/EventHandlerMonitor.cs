using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Plc
{  
   public delegate void UEventHandlerMonitorValueChanged(object sender, CTimeLogS cLogS);
   public delegate void UEventHandlerMonitorGroupStateChanged(object sender, CGroupLog cLog);
}
