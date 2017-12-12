using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMEnergyViewer
{
    [Serializable]
    public class CMeterConfig : IDisposable
    {

        #region Member Variables

        private string m_sIP = "";
        private string m_sPort = "";
        private int m_iChannelNum = 0;

        #endregion


        #region Initialize/Dispose

        public CMeterConfig()
        {
            
        }

        public CMeterConfig(string sIP, string sPort)
        {
            m_sIP = sIP;
            m_sPort = sPort;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string IP
        {
            get { return m_sIP; }
            set { m_sIP = value; }
        }

        public string Port
        {
            get { return m_sPort; }
            set { m_sPort = value; }
        }

        public int ChannelNum
        {
            get { return m_iChannelNum; }
            set { m_iChannelNum = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
