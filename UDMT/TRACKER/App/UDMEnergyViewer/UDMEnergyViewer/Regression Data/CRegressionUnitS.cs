using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CRegressionUnitS : Dictionary<string, CRegressionUnit>, IDisposable
    {
        #region Initialize/Dispose

        public CRegressionUnitS()
        {

        }

        public void Dispose()
        {

        }

        protected CRegressionUnitS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
