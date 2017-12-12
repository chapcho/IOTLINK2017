using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.EnergyDaq.Config
{
    [Serializable]
    public class CSerialDeviceConfig
    {
        protected int m_iStartAdd = 9000;
        protected int m_iWordCount = 54;
        protected int m_iSlaveIndex = 1;
        protected string m_sMeterDeviceKey = string.Empty;
        protected EMMeterModel m_emModel = EMMeterModel.Accura3300S;

        #region Initialze/Dispose

        public CSerialDeviceConfig()
        {

        }

        public CSerialDeviceConfig(int iSlaveIndex, int iStartAdd, int iWordCount)
        {
            m_iSlaveIndex = iSlaveIndex;
            m_iStartAdd = iStartAdd;
            m_iWordCount = iWordCount;
        }

        #endregion

        #region Public Properties

        public int SlaveIndex
        {
            get { return m_iSlaveIndex; }
            set { m_iSlaveIndex = value; }
        }

        public int StartAddress
        {
            get { return m_iStartAdd; }
            set { m_iStartAdd = value; }
        }

        public int WordCount
        {
            get { return m_iWordCount; }
            set { m_iWordCount = value; }
        }

        public string MeterDeviceKey
        {
            get { return m_sMeterDeviceKey; }
            set { m_sMeterDeviceKey = value; }
        }

        public EMMeterModel MeterModel
        {
            get { return m_emModel; }
            set { m_emModel = value; }
        }
        #endregion
    }
}
