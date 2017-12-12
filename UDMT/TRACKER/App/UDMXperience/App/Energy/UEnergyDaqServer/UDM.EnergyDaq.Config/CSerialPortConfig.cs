using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;

namespace UDM.EnergyDaq.Config
{
    [Serializable]
    public class CSerialPortConfig:CConfig
    {
        protected string m_sComPortName = string.Empty;
        protected int m_iBaudRate = 0;
        protected int m_iReadBufferSize = 256;
        protected int m_iWriterBufferSize = 64;
        protected int m_iReadTimeout = 500;
        protected int m_iWriteTimeout = 100;
        protected int m_iDataBits = 8;
        protected Parity m_pParity = Parity.Even;
        protected StopBits m_sStopBits = StopBits.One;
        protected List<CSerialDeviceConfig> m_lstSeralDeviceS = null;

        #region Initialze/Dispose

        public CSerialPortConfig()
        {
            m_lstSeralDeviceS = new List<CSerialDeviceConfig>();
        }

        public CSerialPortConfig(string sPortName, int iBaudRate)
        {
            m_sComPortName = sPortName;
            m_iBaudRate = iBaudRate;
            m_lstSeralDeviceS = new List<CSerialDeviceConfig>();
        }

        public CSerialPortConfig(string sPortName, int iBaudRate, int iReadBuffer, int iWriterBuffer, int iReadTimeout, int iWriterTimeOut)
        {
            m_sComPortName = sPortName;
            m_iBaudRate = iBaudRate;
            m_iReadBufferSize = iReadBuffer;
            m_iWriterBufferSize = iWriterBuffer;
            m_iReadTimeout = iReadTimeout;
            m_iWriteTimeout = iWriterTimeOut;
            m_lstSeralDeviceS = new List<CSerialDeviceConfig>();
        }

        #endregion

        #region Public Properties

        public string ComPortName
        {
            get { return m_sComPortName; }
            set { m_sComPortName = value; }
        }
        public int BaudRate
        {
            get { return m_iBaudRate; }
            set { m_iBaudRate = value; }
        }
        public int ReadBufferSize
        {
            get { return m_iReadBufferSize; }
            set { m_iReadBufferSize = value; }
        }
        public int WriteBufferSize
        {
            get { return m_iWriterBufferSize; }
            set { m_iWriterBufferSize = value; }
        }
        public int ReadTimeOut
        {
            get { return m_iReadTimeout; }
            set { m_iReadTimeout = value; }
        }
        public int WriteTimeOut
        {
            get { return m_iWriteTimeout; }
            set { m_iWriteTimeout = value; }
        }
        public Parity ParityS
        {
            get { return m_pParity; }
            set { m_pParity = value; }
        }
        public StopBits StopBit
        {
            get { return m_sStopBits; }
            set { m_sStopBits = value; }
        }
        public int DataBits
        {
            get { return m_iDataBits; }
            set { m_iDataBits = value; }
        }
        public List<CSerialDeviceConfig> DeviceConfigList
        {
            get { return m_lstSeralDeviceS; }
            set { m_lstSeralDeviceS = value; }
        }
        #endregion
    }
}
