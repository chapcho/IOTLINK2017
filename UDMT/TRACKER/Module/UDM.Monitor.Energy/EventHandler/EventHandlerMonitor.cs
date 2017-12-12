using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Monitor.Energy
{  
   public delegate void UEventHandlerMonitorValueChanged(object sender, CEnergyLogS cLogS);
   public delegate void UEventHandlerMeterMonitorDataRead(object sender, CEnergyLog cLog);
   public delegate void UEventHandlerMeterLogCreate(object sender,CEnergyLog cLog);
}
