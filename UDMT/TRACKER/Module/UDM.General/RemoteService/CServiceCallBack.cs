using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UDM.General.Remote
{
    public class CServiceCallBack : IServiceCallBack, IDisposable
    {

        #region Member Variables

        public event EventHandler UEventTerminated;

        #endregion


        #region Initialize/Dispose

        public CServiceCallBack()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void Terminate()
        {
            if (UEventTerminated != null)
                UEventTerminated(null, EventArgs.Empty);
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
