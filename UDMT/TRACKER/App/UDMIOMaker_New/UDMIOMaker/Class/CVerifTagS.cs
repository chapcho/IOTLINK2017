using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CVerifTagS : Dictionary<string, CVerifTag>, IDisposable
    {
        public CVerifTagS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CVerifTagS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


    }
}
