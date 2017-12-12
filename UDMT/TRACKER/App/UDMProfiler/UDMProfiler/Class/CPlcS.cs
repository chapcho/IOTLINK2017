using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMProfiler
{
    [Serializable]
    /// <summary>
    /// Key = PLCName
    /// </summary>
    public class CPlcS : Dictionary<string, CPlc>, IDisposable
    {

        #region Initialize/Dispose

        public CPlcS()
        {
            
        }
        public void Dispose()
        {
            this.Clear();
        }

        protected CPlcS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
