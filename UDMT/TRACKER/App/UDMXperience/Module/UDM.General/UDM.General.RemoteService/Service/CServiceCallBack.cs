using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.General.RemoteService
{
    /// <summary>
    /// Attribute : None
    /// </summary>
    public class CServiceCallBack : IServiceCallBack, IDisposable
    {

        #region Member Variables

        public event UEventHandlerServerTerminated UEventTerminated;

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
                UEventTerminated(null);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
