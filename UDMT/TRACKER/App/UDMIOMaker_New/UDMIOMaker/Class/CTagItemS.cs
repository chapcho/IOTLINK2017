using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CTagItemS : List<CTagItem>, IDisposable
    {


        
        #region Initialize/Dispose
        public CTagItemS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }


        #endregion

        #region Properties

        #endregion

        #region Public Methods


        #endregion


        #region Private Methods

        #endregion
    }
}
