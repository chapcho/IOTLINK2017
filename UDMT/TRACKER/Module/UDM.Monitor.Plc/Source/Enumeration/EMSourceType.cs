using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source
{
    [Serializable]
    public enum EMSourceType
    {
        DDEA,
        OPC,
        Simulator,
		LS
    }
}
