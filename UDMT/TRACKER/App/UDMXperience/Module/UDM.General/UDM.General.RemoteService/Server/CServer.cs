using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace UDM.General.RemoteService
{
    /// <summary>
    /// Remote Server
    /// </summary>
    /// <typeparam name="IT"> IT is the inteface of service</typeparam>
    /// <typeparam name="T">T is the implementation of IT</typeparam>
    public class CServer<IT, T> : IDisposable
        where IT : IService
        where T : CService
    {

        #region Member Variables

        protected bool m_bRun = false;
        protected string m_sServiceName = "UDMService";
        protected int m_iPort = 8731;

        protected T m_cService = default(T);
        protected ServiceHost m_cHost = null;

        public event UEventHandlerClientConnected UEventClientConnected;
        public event UEventHandlerClientDisconnected UEventClientDisconnected;

        #endregion


        #region Initialize/Dispose

        public CServer()
        {

        }

        public void Dispose()
        {            
            Stop();
        }

        #endregion


        #region Pubilc Properties

        public bool IsRunning
        {
            get { return m_bRun; }
        }

        public string ServiceName
        {
            get { return m_sServiceName; }
            set { m_sServiceName = value; }
        }

        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }

        #endregion


        #region Pubilc Methods

        public bool Start()
        {
            if (m_bRun)
                return true;

            bool bOK = true;

            try
            {
                string sUrl = "net.tcp://localhost:" + m_iPort.ToString() + "/" + m_sServiceName + "/";

                m_cService = (T)(Activator.CreateInstance(typeof(T)));
                m_cHost = new ServiceHost(m_cService, new Uri(sUrl));

                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.MaxBufferPoolSize = 2000000;
                tcpBinding.MaxBufferSize = 2000000;
                tcpBinding.MaxReceivedMessageSize = 2000000;
                tcpBinding.ReaderQuotas.MaxDepth = 32;
                tcpBinding.ReaderQuotas.MaxStringContentLength = 2000000;
                tcpBinding.ReaderQuotas.MaxArrayLength = 2000000;
                tcpBinding.TransactionFlow = false;
                tcpBinding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                tcpBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
                tcpBinding.Security.Mode = SecurityMode.None;
                m_cHost.AddServiceEndpoint(typeof(IT), tcpBinding, sUrl);

                ServiceMetadataBehavior metaBehavior = null;
                metaBehavior = m_cHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
                if (metaBehavior == null)
                {
                    metaBehavior = new ServiceMetadataBehavior();
                    metaBehavior.HttpGetEnabled = false;
                    metaBehavior.HttpsGetEnabled = false;
                    m_cHost.Description.Behaviors.Add(metaBehavior);
                    m_cHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                }

                m_cHost.Open();

                m_bRun = true;

                OnServerStarted();
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public void Stop()
        {
            if (m_bRun == false)
                return;

            try
            {
                if (m_cService != null)
                {
                    m_cService.Terminate();
                    m_cService.Dispose();
                    m_cService = null;
                }

                m_cHost.Close(new TimeSpan(0, 0, 10));

                m_bRun = false;

                OnServerStoped();
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


        #region Virtual Methods

        protected virtual void OnServerStarted()
        {
            m_cService.UEventClientConnected += m_cService_UEventClientConnected;
            m_cService.UEventClientDisconnected += m_cService_UEventClientDisconnected;
        }

        protected virtual void OnServerStoped()
        {
            m_cService.UEventClientConnected -= m_cService_UEventClientConnected;
            m_cService.UEventClientDisconnected -= m_cService_UEventClientDisconnected;
        }

        #endregion


        #region Event Methods

        protected void m_cService_UEventClientConnected(object sender, string sClient)
        {
            GenerateClientConnectedEvent(sClient);
        }

        protected void m_cService_UEventClientDisconnected(object sender, string sClient)
        {
            GenerateClientDisconnectedEvent(sClient);
        }

        #endregion
    }
}
