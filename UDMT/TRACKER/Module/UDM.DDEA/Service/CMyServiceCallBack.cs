using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.DDEA
{
    
    public class CMyServiceCallBack : UDM.General.Remote.CServiceCallBack, IMyServiceCallBack
    {

        #region Member Variables

        public event UEventHandlerLogDataRecieved UEventLogDataRecieved;

        #endregion


        #region Intialize/Dispose

        public CMyServiceCallBack()
        {

        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void RecieveLogData(string[] saData)
        {
            if (UEventLogDataRecieved != null)
                UEventLogDataRecieved(this, saData);
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
