using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    /// <summary>
    /// AddressRange가 Key
    /// </summary>
    [Serializable]
    public class CBlockUnitS : Dictionary<int, CBlockUnit>, IDisposable
    {


        #region Initialize/Dispose
        public CBlockUnitS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CBlockUnitS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        #endregion

        #region Properties

        #endregion

        #region Public Methods


        #endregion


        #region Private Methods

        #endregion
    }
}
