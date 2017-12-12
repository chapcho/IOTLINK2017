using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyProcAgent.Config
{
    [Serializable]
    public class CServerInfo : IDisposable, ICloneable
    {

        #region Member Variables

        protected string m_sServiceName = "UDMEnergyDaqSerivce";
        protected string m_sIP = "localhost";
        protected int m_iPort = 8731;

        protected CServerChannelInfoS m_cChannelInfoS = new CServerChannelInfoS();

        #endregion


        #region Initialize/Dispose

        public CServerInfo()
        {

        }

        public CServerInfo(string sServiceName)
        {
            m_sServiceName = sServiceName;
        }

        public CServerInfo(string sServiceName, string sIP, int iPort)
        {
            m_sServiceName = sServiceName;
            m_sIP = sIP;
            m_iPort = iPort;
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

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

        public CServerChannelInfoS ChannelInfoS
        {
            get { return m_cChannelInfoS; }
            set { m_cChannelInfoS = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            if (m_cChannelInfoS != null)
                m_cChannelInfoS.Clear();
        }

        public object Clone()
        {
            CServerInfo cInfo = new CServerInfo(m_sServiceName, m_sIP, m_iPort);

            cInfo.ChannelInfoS = (CServerChannelInfoS) m_cChannelInfoS.Clone();

            return cInfo;
        }

        #endregion


        #region Private Methods


        #endregion


        #region Event Methods


        #endregion
    }
}
