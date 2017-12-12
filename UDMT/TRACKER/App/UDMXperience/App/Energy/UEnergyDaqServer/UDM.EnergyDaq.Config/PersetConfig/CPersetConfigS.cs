using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Config
{
    public static class CPersetConfigS
    {
        #region Memver Variables

        private static Dictionary<string, CPersetConfig> m_dicPersetMeter = null;
        private static List<string> m_lstEthernetMeter = null;
        private static List<string> m_lstSerialMeter = null;

        #endregion

        #region Initilaize/Dispose

        static CPersetConfigS()
        {
            m_dicPersetMeter = new Dictionary<string, CPersetConfig>();
            m_lstEthernetMeter = new List<string>();
            m_lstSerialMeter = new List<string>();

            PersetAdd();
        }

        #endregion

        #region Public Properties

        public static Dictionary<string,CPersetConfig> PersetMeter
        {
            get { return m_dicPersetMeter; }
            set { m_dicPersetMeter = value; }
        }

        public static List<string> EthernetMeter
        {
            get { return m_lstEthernetMeter; }
            set { m_lstEthernetMeter = value; }
        }

        public static List<string> SerialMeter
        {
            get { return m_lstSerialMeter; }
            set { m_lstSerialMeter = value; }
        }
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private static void PersetAdd()
        {
            CPersetConfig cTempConfig = new CPersetConfig();

            // AcuRev2000
            cTempConfig.Model = EMMeterModel.AcuRev2000;
            cTempConfig.ConnectType = "Ethernet&Serial";
            cTempConfig.IPAddress = "192.168.1.254";
            cTempConfig.Port = 502;
            cTempConfig.StartAddress = 8448;
            cTempConfig.ChannelCount = 18;
            cTempConfig.WordCountPreChannel = 12;
            cTempConfig.WordCount = 216;

            m_dicPersetMeter.Add("AcuRev2000", cTempConfig);
            m_lstEthernetMeter.Add("AcuRev2000");
            m_lstSerialMeter.Add("AcuRev2000");

            // Accura3300S

            cTempConfig = new CPersetConfig();
            cTempConfig.Model = EMMeterModel.Accura3300S;
            cTempConfig.ConnectType = "Serial";
            cTempConfig.StartAddress = 9000;
            cTempConfig.WordCount = 53;
            cTempConfig.ChannelCount = 1;
            cTempConfig.WordCountPreChannel = 53;

            m_dicPersetMeter.Add("Accura3300S", cTempConfig);
            m_lstSerialMeter.Add("Accura3300S");

        }
        #endregion
    }
}
