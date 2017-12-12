using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    [Serializable]
    public class CSerialDeviceConfig
    {

        protected int m_iStartAdd = 9000;
        protected int m_iWordCount = 54;
        protected int m_iSlaveIndex = 1;

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
        #endregion
    }
}
