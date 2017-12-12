using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Plc.Source.LS
{
    [Serializable]
    public class CLsConfig : IDisposable
    {
        #region Member Variables

        protected bool m_bUse = false;
		protected string m_sIP = "192.168.0.150";
		protected string m_sPort = "2004";
		protected int m_iInterval = 10;
		protected EMLsInterfaceType m_emInterfaceType = EMLsInterfaceType.Ethernet;

        #endregion


        #region Initialize/Dispose

		public CLsConfig()
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

		public int Interval
		{
			get { return m_iInterval; }
			set { m_iInterval = value; }
		}

		public EMLsInterfaceType InterfaceType
		{
			get { return m_emInterfaceType; }
			set { m_emInterfaceType = value; }
		}

        #endregion


        #region Public Methods


        #endregion
    }
}
