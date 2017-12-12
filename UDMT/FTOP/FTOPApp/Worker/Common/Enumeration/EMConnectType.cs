using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public enum EMConnectType
    {
        OPC,
        DB,
    }

    public enum EMServerMenu
    {
        Run,
        Stop,
        Option,
        ReConnect
    }

    public enum EMDataPushType
    {
        SOAP,
        TCPIP,
        ENET,
    }

    public enum EMTarget
    {
        ALL = 0,
        MES = 1,
        CPS = 2
    }

    public enum EMUsed
    {
        Y,
        N,
        ALL,
    }

    public enum ViewMode
    {
        Expand,
        Collapse,

    }


}
