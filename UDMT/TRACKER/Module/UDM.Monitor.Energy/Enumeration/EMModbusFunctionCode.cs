using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
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
