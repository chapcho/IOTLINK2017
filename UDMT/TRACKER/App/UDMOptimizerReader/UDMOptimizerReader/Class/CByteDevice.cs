using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizerReader
{
    public class CByteDevice
    {
        #region Member Veriables

        private byte m_nMaskValue = 0;
        private string m_sMajorString = "";
        private int m_iMajorNumber = 0;
        private List<CBitDevice> m_lstBitDevice = new List<CBitDevice>();
        private byte m_nCurrentValue = 0;
        private bool m_bUsed = false;

        #endregion


        #region Properties
       
        public byte MaskValue
        {
            get { return m_nMaskValue; }
            set { m_nMaskValue = value; }
        }

        public string MajorString
        {
            get { return m_sMajorString; }
            set { m_sMajorString = value; }
        }

        public int MajorNumber
        {
            get { return m_iMajorNumber; }
            set { m_iMajorNumber = value; }
        }

        public List<CBitDevice> BitDeviceList
        {
            get { return m_lstBitDevice; }
            set { m_lstBitDevice = value; }
        }

        public byte CurrentValue
        {
            get { return m_nCurrentValue; }
            set { m_nCurrentValue = value; }
        }

        public bool Used
        {
            get { return m_bUsed; }
            set { m_bUsed = value; }
        }

        #endregion
    }
}
