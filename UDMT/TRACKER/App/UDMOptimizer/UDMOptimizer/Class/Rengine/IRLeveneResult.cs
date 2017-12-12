using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public interface IRLeveneResult : ICloneable
    {
        float Statistic { get; set; }
        float PValue { get; set; }
    }
}
