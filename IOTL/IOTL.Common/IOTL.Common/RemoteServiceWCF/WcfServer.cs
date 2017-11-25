using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace IOTL.Common.Remote
{
    /// <summary>
    /// Remote Server
    /// </summary>
    /// <typeparam name="IT"> IT is the inteface of service</typeparam>
    /// <typeparam name="T">T is the implementation of IT</typeparam>
    public class WcfServer<IT, T> : IDisposable
        where IT : IWcfService
        where T : WcfService
    {

        #region Member Variables

        protected bool m_bRun = false;
        protected string m_sServiceName = "UDMService";
        protected int m_iPort = 8731;

        protected T m_cService = default(T);
        protected ServiceHost m_cHost = null;

        #endregion


        #region Initialize/Dispose

        public WcfServer()
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

        public T Service
        {
            get { return m_cService; }
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
                tcpBinding.CloseTimeout = new TimeSpan(0, 10, 0);
                tcpBinding.OpenTimeout = new TimeSpan(0, 10, 0);
                tcpBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);
                tcpBinding.SendTimeout = new TimeSpan(0, 10, 0);

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

                m_cHost.Close();

                m_bRun = false;
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
