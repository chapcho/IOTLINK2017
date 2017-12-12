using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.OPC
{
    [Serializable]
    public class COPCConfig : IDisposable
    {
        #region Member Variables

        protected bool m_bUse = false;
        protected bool m_bLsOpc = false;
        protected string m_sServerName = "";
        protected string m_sChannelDevice = "";
        protected int m_iUpdateRate = 50;

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

        #endregion


        #region Public Methods


        #endregion
    }
}
