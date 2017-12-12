using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace UDM.General.RemoteService
{
    /// <summary>
    /// Remote Client
    /// </summary>
    /// <typeparam name="IT">IT is the interface of service</typeparam>
    /// <typeparam name="U">U is the implementation of sevice callback interface</typeparam>
    public class CClient<IT, U> : IDisposable
        where IT : IService
        where U : CServiceCallBack
    {

        #region Member Variables

        protected bool m_bConnected = false;

        protected string m_sName = "Test";
        protected string m_sServiceName = "UDMService";
        protected string m_sIP = "localhost";
        protected int m_iPort = 8731;

        protected IT m_cService = default(IT);
        protected U m_cServiceCallBack = default(U);
        protected DuplexChannelFactory<IT> m_cFactory = null;

        public event UEventHandlerServerTerminated UEventTerminated;

        #endregion


        #region Initialize/Dispose

        public CClient(string sName)
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
            get { return m_bConnected; }
        }

        public string ServiceName
        {
            get { return m_sServiceName; }
            set { m_sServiceName = value; }
        }

        public string IP
        {
            get { return m_sIP; }
            set { m_sIP = value; }
        }

        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }


        #endregion


        #region Pubilc Methods

        public bool Connect()
        {
            if (m_bConnected)
                return true;

            bool bOK = true;

            string sUrl = "net.tcp://" + m_sIP + ":" + m_iPort.ToString() + "/" + m_sServiceName + "/";
            EndpointAddress tcpAddress = new EndpointAddress(sUrl);
            NetTcpBinding tcpBinding = new NetTcpBinding();
            tcpBinding.Security.Mode = SecurityMode.None;

            try
            {
                m_cServiceCallBack = (U)Activator.CreateInstance(typeof(U));
                System.ServiceModel.InstanceContext cContext = new InstanceContext(m_cServiceCallBack);

                m_cFactory = new DuplexChannelFactory<IT>(cContext, tcpBinding, tcpAddress);
                m_cService = m_cFactory.CreateChannel();
                m_cService.Connect(m_sName);

                OnClientConnected();
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

                m_cFactory.Abort();
                m_cFactory.Close();
                m_cFactory = null;

                OnClientDisconnected();

            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            m_bConnected = false;
        }

        #endregion


        #region Private Methods

        protected void GenerateTerminatedEvent()
        {
            if (UEventTerminated != null)
                UEventTerminated(null);
        }

        #endregion


        #region Virtual Methods

        protected virtual void OnClientConnected()
        {
            m_cServiceCallBack.UEventTerminated += m_cServiceCallBack_UEventTerminated;
        }

        protected virtual void OnClientDisconnected()
        {
            m_cServiceCallBack.UEventTerminated -= m_cServiceCallBack_UEventTerminated;
        }

        #endregion


        #region Event Methods

        private void m_cServiceCallBack_UEventTerminated(object sender)
        {
            Disconnect();
            GenerateTerminatedEvent();
        }

        #endregion
    }
}
