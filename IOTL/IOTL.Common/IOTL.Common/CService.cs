using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UDM.General.Remote
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CService : IService, IDisposable
    {

        #region Member Variables

        protected static Dictionary<string, IServiceCallBack> m_lstClient = new Dictionary<string, IServiceCallBack>();
        protected static object m_Locker = new object();

        public event UEventHandlerClientConnected UEventClientConnected;
        public event UEventHandlerClientDisconnected UEventClientDisconnected;
        public event EventHandler UEventTerminated;

        #endregion


        #region Initialize/Dispose

        public CService()
        {

        }

        public void Dispose()
        {
            m_lstClient.Clear();
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

                if (UEventClientConnected != null)
                    UEventClientConnected(this, sClient);

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

                if (UEventClientDisconnected != null)
                    UEventClientDisconnected(this, sClient);
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
                    foreach (var client in m_lstClient)
                    {
                        try
                        {
                            client.Value.Terminate();
                        }
                        catch (System.Exception ex)
                        {
                            ex.Data.Clear();
                            lstInactiveClient.Add(client.Key);
                        }
                    }

                    if (lstInactiveClient.Count > 0)
                    {
                        foreach (string sClient in lstInactiveClient)
                            m_lstClient.Remove(sClient);

                        lstInactiveClient.Clear();
                    }
                }

                if (UEventTerminated != null)
                    UEventTerminated(this, EventArgs.Empty);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
