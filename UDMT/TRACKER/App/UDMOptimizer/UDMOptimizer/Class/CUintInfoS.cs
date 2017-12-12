using DevExpress.Utils.Serializing.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMOptimizer
{
    [Serializable]
    public class CUnitInfoS: Dictionary<string, CUnitInfo>
    {

        public CUnitInfoS()
        {

        }

        protected CUnitInfoS(System.Runtime.Serialization.SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

    }
}
