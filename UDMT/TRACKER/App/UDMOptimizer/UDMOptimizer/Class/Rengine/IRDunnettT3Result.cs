using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public interface IRDunnettT3Result : ICloneable
    {
        string[] GroupName { get; set; }
        float[] GroupDiff { get; set; }
        float[] GroupLowerCI { get; set; }
        float[] GroupUpperCI { get; set; }

    }
}
