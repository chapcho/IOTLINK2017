using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Log.Energy;

namespace UDM.EnergyDaq.Service
{
    public delegate void UEventHandlerDataRecieved(object sender, CEnergyLogS cLogS);
    public delegate List<string> UEventHandlerLogListRequire(object sender,string cClient);
}
