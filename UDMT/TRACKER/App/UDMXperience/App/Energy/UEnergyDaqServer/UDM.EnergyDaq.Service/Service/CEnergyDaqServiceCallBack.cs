using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using UDM.General.RemoteService;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Service
{
    public class CEnergyDaqServiceCallBack : CServiceCallBack, IEnergyDaqServiceCallBack
    {
        #region Member Variables

        public event UEventHandlerDataRecieved UEventDataRecieved;

        #endregion


        #region Initilaize/Dispose

        #endregion


        #region Public Properties


        #endregion

        
        #region Public Methods

        public void RecieveData(CEnergyLogS cLogS)
        {
            if (cLogS == null || cLogS.Count == 0)
                return;

            GenerateDataRecievedEvent(cLogS);
        }

        #endregion


        #region Private Methods

        private void GenerateDataRecievedEvent(CEnergyLogS cLogS)
        {
            if (UEventDataRecieved != null)
                UEventDataRecieved(this, cLogS);
        }


        #endregion
    }
}
