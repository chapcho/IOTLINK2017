using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.DDEA
{
    /// <summary>
    /// Melsec Ethernet Module Type
    /// </summary>
    public enum EMENetModuleTypeMS
    {
        QJ71E71 = 0,
        CPU = 1,
        AJ71E71 = 2,
        AJ71QE71 = 3,
        GOT = 4
    }

    /// <summary>
    /// Melsec Ethernet Packet Type
    /// </summary>
    public enum EMENetPacketTypeMS 
    {
        ASCII   = 0,
        Binary  = 1
    }

    /// <summary>
    /// Melsec Ethernet Protocol Type
    /// </summary>
    public enum EMENetProtocolTypeMS
    {
        TCP = 0,
        UDP = 1
    }

}
