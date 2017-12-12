using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public interface IPLC 
    {
        /// <summary> Maker of the PLC </summary>
        EMFTOPPLCMaker PLCMaker { get; set; }

        /// <summary> datatype of the PLC </summary>
        EMPLCDataType PLCDataType { get; set; }

        /// <summary> PLCHardWareInfo of the PLC  </summary>
        string PLCHardWareInfo { get; set; }

        /// <summary> ip of the PLC  </summary>
        string PLCIPAddress { get; set; }

        /// <summary> real Address of the PLC  </summary>
        string PLCAddress { get; set; }

        /// <summary> variable name of the PLC  </summary>
        string PLCName { get; set; }

        /// <summary> detail contents of the PLC  </summary>
        string PLCDESC { get; set; }
    }
}
