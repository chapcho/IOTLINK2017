using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDMOptimizer
{
    public interface IRTtestResult : ICloneable
    {
        float[] GroupM { get; set; }
        float[] GroupSD { get; set; }
        float[] GroupSE { get; set; }
        float DF { get; set; }
        float TValue { get; set; }
        float PValue { get; set; }
    }
}
