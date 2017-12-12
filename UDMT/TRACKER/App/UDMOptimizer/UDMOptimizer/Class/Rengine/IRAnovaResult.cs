using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public interface IRAnovaResult : ICloneable
    {
        float GroupDF { get; set; }
        float GroupSS { get; set; }
        float GroupMS { get; set; }
        float ErrorDF { get; set; }
        float ErrorSS { get; set; }
        float ErrorMS { get; set; }
        float FValue { get; set; }
        float PValue { get; set; }
    }
}
