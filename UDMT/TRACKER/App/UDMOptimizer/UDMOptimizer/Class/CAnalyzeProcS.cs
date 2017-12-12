using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMOptimizer
{
    public class CAnalyzeProcS : Dictionary<string, CAnalyzeProc>
    {
        public CAnalyzeProcS()
        {

        }

        protected CAnalyzeProcS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
    }
}
