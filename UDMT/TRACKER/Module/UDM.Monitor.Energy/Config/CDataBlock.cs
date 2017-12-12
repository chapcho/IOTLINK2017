using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    public class CDataBlock
    {
        protected int m_iStartAddress = 8448;
        protected int m_iWordCount = 108;


        #region public Properties

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

        #endregion
    }
}
