using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMTracker
{
    public class CCollectTag
    {
        public string Address { get; set; }
        public string Description { get; set; }

        public EMDataType DataType { get; set; }

        public string Key { get; set; }

        public int CurrentValue { get; set; }

        public int ChangeCount { get; set; }
    }
}
