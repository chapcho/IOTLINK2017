using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDM.Flow
{
    /// <summary>
    /// Key == 공정
    /// </summary>
    [Serializable]
    public class CMasterSequenceS : Dictionary<string, CMasterSequence>, IDisposable
    {
        public CMasterSequenceS()
        {

        }

        
        public void Dispose()
        {
            Clear();
        }

        protected CMasterSequenceS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


    }
}
