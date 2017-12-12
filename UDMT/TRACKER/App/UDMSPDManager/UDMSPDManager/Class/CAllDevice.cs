using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMSPDManager
{
    public class CAllBitDevice
    {
        #region Member Veriables

        private List<CDWordDevice> m_lstInputWordDevice = new List<CDWordDevice>();
        private List<CDWordDevice> m_lstOutputWordDevice = new List<CDWordDevice>();
        private List<CDWordDevice> m_lstM_WordDevice = new List<CDWordDevice>();
        private List<string> m_lstSendText = new List<string>();

        #endregion


        #region Properties

        public List<CDWordDevice> InputWordDeviceList
        {
            get { return m_lstInputWordDevice; }
            set { m_lstInputWordDevice = value; }
        }

        public List<CDWordDevice> OutputWordDeviceList
        {
            get { return m_lstOutputWordDevice; }
            set { m_lstOutputWordDevice = value; }
        }

        public List<CDWordDevice> M_WordDeviceList
        {
            get { return m_lstM_WordDevice; }
            set { m_lstM_WordDevice = value; }
        }

        public List<string> SendTextData
        {
            get { return m_lstSendText; }
            set { m_lstSendText = value; }
        }

        #endregion
    }

    public class CBitTagComparer : IComparer<CBitDevice>
    {
        public int Compare(CBitDevice x, CBitDevice y)
        {
            int iValue = x.MajorNumber.CompareTo(y.MajorNumber);

            return iValue;
        }
    }
}
