using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMOptimizerReader
{
    public class CViewTag
    {
        public CTag Tag { get; set; }

        public bool CollectUse { get; set; }

        public int CurrentValue { get; set; }

        public bool UserSymbol { get; set; }
    }
}
