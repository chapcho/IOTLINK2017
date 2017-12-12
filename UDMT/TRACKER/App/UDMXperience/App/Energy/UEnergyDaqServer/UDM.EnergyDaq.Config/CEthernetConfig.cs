using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Config
{
    [Serializable]
    public class CEthernetConfig:CConfig
    {
        #region Member Variables

        private string m_sIP = "";
        private string m_sPort = "";
        private List<CDataBlock> m_lstDataBlock = null;

        #endregion


        #region Initialize/Dispose

        public CEthernetConfig()
        {
            m_lstDataBlock = new List<CDataBlock>();
        }

        public CEthernetConfig(string sIP, string sPort)
        {
            m_sIP = sIP;
            m_sPort = sPort;
            m_lstDataBlock = new List<CDataBlock>();
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

        public List<CDataBlock> DataBlockS
        {
            get { return m_lstDataBlock; }
            set { m_lstDataBlock = value; }
        }
        #endregion
    }
}
