using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.General.RemoteService;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Service
{
    public class CEnergyDaqClient : CClient<IEnergyDaqService, CEnergyDaqServiceCallBack>
    {
        #region Member Variables

        public event UEventHandlerDataRecieved UEventDataRecieved;

        #endregion


        #region Initilaize/Dispose

        public CEnergyDaqClient(string sName) : base(sName)
        {
            base.ServiceName = "UDMEnergyDaqSerivce";
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

       

        #endregion


        #region Private Methods

        private void GenerateDataRecievedEvent(CEnergyLogS cLogS)
        {
            if (UEventDataRecieved != null)
                UEventDataRecieved(this, cLogS);
        }


        #endregion


        #region Override Methods

        protected override void OnClientConnected()
        {
            base.OnClientConnected();

            m_cServiceCallBack.UEventDataRecieved += m_cServiceCallBack_UEventDataRecieved;
        }

        protected override void OnClientDisconnected()
        {
            base.OnClientDisconnected();

            m_cServiceCallBack.UEventDataRecieved -= m_cServiceCallBack_UEventDataRecieved;
        }

        #endregion


        #region Event Methods

        private void m_cServiceCallBack_UEventDataRecieved(object sender, CEnergyLogS cLogS)
        {
            GenerateDataRecievedEvent(cLogS);
        }


        #endregion


    }
}
