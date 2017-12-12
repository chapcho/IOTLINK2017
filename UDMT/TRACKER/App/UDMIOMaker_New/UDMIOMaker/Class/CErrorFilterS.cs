using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CErrorFilterS : Dictionary<string, CErrorFilter>, IDisposable
    {
        public CErrorFilterS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CErrorFilterS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

    }
}
