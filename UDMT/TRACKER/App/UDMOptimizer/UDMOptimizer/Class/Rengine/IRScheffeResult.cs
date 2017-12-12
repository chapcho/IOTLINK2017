using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public interface IRScheffeResult : ICloneable
    {
        string[] GroupName { get; set; }
        float[] GroupDiff { get; set; }
        float[] GroupPValue { get; set; }
        int[] GroupSig { get; set; }
        float[] GroupLCL { get; set; }
        float[] GroupUCL { get; set; }
    }
}
