using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    /// <summary>
    /// Block Name이 Key
    /// </summary>
    [Serializable]
    public class CBlockS : Dictionary<string, CBlock>, IDisposable
    {


        #region Initialize/Dispose

        public CBlockS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CBlockS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        #endregion


        #region Properties

        #endregion

        #region Public Methods


        #endregion


        #region Private Methods

        #endregion

    }
}
