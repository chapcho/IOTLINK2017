using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Config
{
    public class CPersetConfig
    {
        protected EMMeterModel m_emModel = EMMeterModel.OtherModel;
        protected string m_sConnectType = "Demo";
        protected int m_iStartAddress = 0;
        protected int m_iWordCount = 0;
        protected int m_iChannelCount = 0;
        protected int m_iWordCountPreChannel = 0;
        protected string m_sIPAddress = "";
        protected int m_iPort = 0;

        #region Public Properties

        public EMMeterModel Model
        {
            get { return m_emModel; }
            set { m_emModel = value; }
        }

        public string ConnectType
        {
            get { return m_sConnectType; }
            set { m_sConnectType = value; }
        }

        public int StartAddress
        {
            get { return m_iStartAddress; }
            set { m_iStartAddress = value; }
        }

        public int WordCount
        {
            get { return m_iWordCount; }
            set { m_iWordCount = value; }
        }

        public int ChannelCount
        {
            get { return m_iChannelCount; }
            set { m_iChannelCount = value; }
        }

        public int WordCountPreChannel
        {
            get { return m_iWordCountPreChannel; }
            set { m_iWordCountPreChannel = value; }
        }

        public string IPAddress
        {
            get { return m_sIPAddress; }
            set { m_sIPAddress = value; }
        }

        public int Port
        {
            get { return m_iPort; }
            set { m_iPort = value; }
        }
        #endregion

    }
}
