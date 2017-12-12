using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

using UDM.General.RemoteService;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CEnergyDaqService : CService, IEnergyDaqService
    {
        #region Member Variables

        public event UEventHandlerLogListRequire UEventLogListRequire;

        #endregion


        #region Initilaize/Dispose


        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void SendToClient(CEnergyLogS cLogS)
        {
            try
            {
                lock (m_Locker)
                {
                    List<string> lstInactiveClient = new List<string>();
                    foreach (var cClientInfo in m_lstClient)
                    {
                        try
                        {
                            IEnergyDaqServiceCallBack cClient = cClientInfo.Value as IEnergyDaqServiceCallBack;
                            cClient.RecieveData(cLogS);
                        }
                        catch (System.Exception ex)
                        {
                            ex.Data.Clear();
                            lstInactiveClient.Add(cClientInfo.Key);
                        }
                    }

                    if (lstInactiveClient.Count > 0)
                    {
                        foreach (string sClient in lstInactiveClient)
                            m_lstClient.Remove(sClient);

                        lstInactiveClient.Clear();
                    }
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public List<string> RequireLogKeyList(string sClient)
        {
            List<string> lstMeterKey = new List<string>();

            if (UEventLogListRequire != null)
                lstMeterKey = UEventLogListRequire(this, sClient);

            return lstMeterKey;
        }

        public void SendLogKeyStoClient(List<string> lstKeyS)
        {
            try
            {
                lock(m_Locker)
                {
                    foreach (var cClientInfo in m_lstClient)
                    {
                        try
                        {
                            IEnergyDaqServiceCallBack cClient = cClientInfo.Value as IEnergyDaqServiceCallBack;
                            //cClient.RecieveLogKeyList(lstKeyS);
                        }
                        catch (System.Exception ex)
                        {
                            ex.Data.Clear();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }


        #endregion


        #region Private Methods

        #endregion

        #region Event Methods



        #endregion
    }
}
