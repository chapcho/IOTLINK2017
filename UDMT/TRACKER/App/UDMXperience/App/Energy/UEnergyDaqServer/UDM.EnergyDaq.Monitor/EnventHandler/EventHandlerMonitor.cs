using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Log;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
{
    public delegate void UEventHandlerMeterMonitorDataRead(object sender,CEnergyLogS cLogS);
    public delegate void UEventHandlerMeterLogCreate(object sender, CEnergyLogS cLogS);
    public delegate void UEventHandlerMonitorLogDeQue(object sender, CEnergyLogS cLogS);
}
