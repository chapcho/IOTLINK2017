using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace IOTL.Common.Remote
{
    public delegate void UEventHandlerClientFaulted(string sKey);
    /// <summary>
    /// Remote Client
    /// </summary>
    /// <typeparam name="IT">IT is the interface of service</typeparam>
    /// <typeparam name="U">U is the implementation of sevice callback</typeparam>
    public class WcfClient<IT, U> : IDisposable  where IT : IWcfService where U : IWcfServiceCallBack
    {

        #region Member Variables

        protected bool m_bConnected = false;

        protected string m_sName = "Test";
        protected string m_sServiceName = "APPService";
        protected int m_iPort = 8731;

        protected IT m_cService = default(IT);
        protected U m_cServiceCallBack = default(U);
        protected DuplexChannelFactory<IT> m_cFactory = null;

        public event UEventHandlerClientFaulted UEventFaulted = null;
        #endregion


        #region Initialize/Dispose

        public WcfClient(string sName)
        {
            m_sName = sName;            
        }

        public void Dispose()
        {
            Disconnect();
        }

        #endregion


        #region Public Properties

        public bool IsConnected
        {
            get {return m_bConnected;}
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

        public IT Service
        {
            get { return m_cService; }
        }

        public U ServiceCallBack
        {
            get { return m_cServiceCallBack; }
        }

        
        #endregion


        #region Pubilc Methods

        public bool Connect()
        {   
            if(m_bConnected )
                return true;

            bool bOK = true;

            string sUrl = "net.tcp://localhost:" + m_iPort.ToString() + "/" + m_sServiceName + "/";
            EndpointAddress tcpAddress = new EndpointAddress(sUrl);
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.Security.Mode = SecurityMode.None;
            tcpBinding.MaxBufferSize = 2000000;
            tcpBinding.MaxBufferPoolSize = 2000000;
            tcpBinding.ReaderQuotas.MaxDepth = 32;
            tcpBinding.ReaderQuotas.MaxStringContentLength = 2000000;
            tcpBinding.ReaderQuotas.MaxArrayLength = 2000000;
            tcpBinding.TransactionFlow = false;
            tcpBinding.CloseTimeout = new TimeSpan(0, 10, 0);
            tcpBinding.OpenTimeout = new TimeSpan(0, 10, 0);
            tcpBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            tcpBinding.SendTimeout = new TimeSpan(0, 10, 0);

            try
            {
                m_cServiceCallBack = (U)Activator.CreateInstance(typeof(U));
                System.ServiceModel.InstanceContext cContext = new InstanceContext(m_cServiceCallBack);

                m_cFactory = new DuplexChannelFactory<IT>(cContext, tcpBinding, tcpAddress);
                m_cService = m_cFactory.CreateChannel();
                m_cService.Connect(m_sName);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
                bOK = false;
            }

            m_bConnected = bOK;

            return bOK;
        }

        public void Disconnect()
        {
            if (m_bConnected == false)
                return;

            try
            {
                m_cService.Disconnect(m_sName);
                m_cService = default(IT);
                m_cServiceCallBack = default(U);
                m_cFactory.Close();
                m_cFactory = null;
                
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            m_bConnected = false;
        }

        #endregion


        #region Private Methods

        #endregion
    }
}
