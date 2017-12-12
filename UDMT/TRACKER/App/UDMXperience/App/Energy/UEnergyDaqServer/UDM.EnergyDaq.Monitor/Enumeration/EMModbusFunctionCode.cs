using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Monitor
{
    public enum EMModbusFunctionCode
    {
        ReadRelayOutputStatus = 1,
        ReadDigitalInputStatus = 2,
        ReadMultipleRegister = 3,
        ControlSingleRelayOutput = 5,
        WriteSingleRegister = 6,
        WriteMultipleRegister = 16
    }
}
