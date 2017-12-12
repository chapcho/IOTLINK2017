using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public enum EMOPCType
    {
        OPCWorkX,
        KEPServerEX,
        RSLinX
    }

    public enum EMLogSenderType
    {
        OPC,
        Thread,
        DB,
        ScanTimer,
        Procedure,
        Information,
        ETC
    }
}
