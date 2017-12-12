using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace UDM.General.RemoteService
{
    /// <summary>
    /// Attribute :  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CService : IService, IDisposable
    {

        #region Member Variables

        protected static Dictionary<string, IServiceCallBack> m_lstClient = new Dictionary<string, IServiceCallBack>();
        protected static object m_Locker = new object();

        public event UEventHandlerClientConnected UEventClientConnected;
        public event UEventHandlerClientDisconnected UEventClientDisconnected;

        #endregion


        #region Initialize/Dispose

        public CService()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void Connect(string sClient)
        {
            if (sClient == null || sClient == "")
                return;

            try
            {
                IServiceCallBack cCallBack = OperationContext.Current.GetCallbackChannel<IServiceCallBack>();
                lock (m_Locker)
                {
                    if (m_lstClient.ContainsKey(sClient))
                        m_lstClient.Remove(sClient);

                    m_lstClient.Add(sClient, cCallBack);
                }

                GenerateClientConnectedEvent(sClient);

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public void Disconnect(string sClient)
        {
            if (sClient == null || sClient == "")
                return;

            try
            {
                lock (m_Locker)
                {
                    if (m_lstClient.ContainsKey(sClient))
                        m_lstClient.Remove(sClient);
                }

                GenerateClientDisconnectedEvent(sClient);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        public void Terminate()
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
                            cClientInfo.Value.Terminate();
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

        #endregion


        #region Private Methods

        protected void GenerateClientConnectedEvent(string sName)
        {
            if (UEventClientConnected != null)
                UEventClientConnected(null, sName);
        }

        protected void GenerateClientDisconnectedEvent(string sName)
        {
            if (UEventClientDisconnected != null)
                UEventClientDisconnected(null, sName);
        }

        #endregion
    }
}
