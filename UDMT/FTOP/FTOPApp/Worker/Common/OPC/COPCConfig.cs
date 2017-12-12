using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTOPApp
{
    [Serializable]
    public class COPCConfig : IDisposable
    {
        #region Member Variables

        protected bool m_bUse = false;
        protected bool m_bLsOpc = false;
        protected string m_sServerName = "";
        protected string m_sChannelDevice = "";
        protected int m_iUpdateRate = 10;

        protected bool m_bABOpc = false;

        protected bool m_bDCOM = false;
        protected string m_sRemoteAddress = "";

        #endregion


        #region Initialize/Dispose

        public COPCConfig()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool ABOpc
        {
            get { return m_bABOpc;}
            set { m_bABOpc = value; }
        }

        public bool Use
        {
            get { return m_bUse; }
            set { m_bUse = value; }
        }

        public bool LsOpc
        {
            get { return m_bLsOpc; }
            set { m_bLsOpc = value; }
        }

        public string ServerName
        {
            get { return m_sServerName; }
            set { m_sServerName = value; }
        }

        public string ChannelDevice
        {
            get { return m_sChannelDevice; }
            set { m_sChannelDevice = value; }
        }

        public int UpdateRate
        {
            get { return m_iUpdateRate; }
            set { m_iUpdateRate = value; }
        }

        public bool DCOM
        {
            get { return m_bDCOM; }
            set { m_bDCOM = value; }
        }

        public string RemoteAddress
        {
            get { return m_sRemoteAddress; }
            set { m_sRemoteAddress = value; }
        }

        #endregion


        #region Public Methods


        #endregion
    }
}
