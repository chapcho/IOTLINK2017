using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public enum EMMESResponseMessage
    {
        OK = 00,
        AppError = 01,
        DBError = 02,
        DataEmpty = 03,
        ConnectError = 04,
        EtcError = 99,
    }
}
