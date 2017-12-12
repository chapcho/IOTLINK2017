using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CStdTagS : Dictionary<string, CStdTag>
    {
        public CStdTagS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CStdTagS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

    }
}
