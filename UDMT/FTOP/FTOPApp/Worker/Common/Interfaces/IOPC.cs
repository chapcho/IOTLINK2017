using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public interface IOPC
    {
        EMOPCType OPCType { get; set; }
        int OPCID { get; set; }
    }
}
