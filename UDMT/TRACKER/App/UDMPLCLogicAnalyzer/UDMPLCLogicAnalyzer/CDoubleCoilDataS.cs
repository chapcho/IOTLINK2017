using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMPLCLogicAnalyzer
{
    [Serializable]
    public class CDoubleCoilDataS : Dictionary<string , List<CDoubleCoilData>>
    {

        public CDoubleCoilDataS()
        {

        }

        protected CDoubleCoilDataS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

    }
}
