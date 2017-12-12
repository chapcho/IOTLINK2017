using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILSubData
    {
        private string m_sAddress = string.Empty;
        private int m_nSize = 0;
        private EMSubDataType m_eSubDataType = EMSubDataType.Word;
        private List<string> m_ListSubDataDst = new List<string>();
        private List<string> m_ListSubDataSrc = new List<string>();

        public CILSubData(string sAddress, int nSize, EMSubDataType eSubDataType, bool bSource)
        {
            if (nSize > CPlcMelsecConfig.MoveLimitCount)
                return;

            m_sAddress = sAddress;

            if (m_sAddress == "Z")
                m_sAddress = "Z0";
            if (m_sAddress == "V")
                m_sAddress = "V0";

            m_nSize = nSize;
            m_eSubDataType = eSubDataType;

            if (bSource)
                m_ListSubDataSrc = GetSubDataList();
            else
                m_ListSubDataDst = GetSubDataList();

        }


        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public List<string> SubDataListDst
        {
            get { return m_ListSubDataDst; }
            set { m_ListSubDataDst = value; }
        }

        public List<string> SubDataListSrc
        {
            get { return m_ListSubDataSrc; }
            set { m_ListSubDataSrc = value; }
        }

        private List<string> GetSubDataList()
        {
            List<string> ListAddress = new List<string>();

            if (!CPlcMelsec.IsAddress(m_sAddress))
                return ListAddress;

            if (m_eSubDataType == EMSubDataType.Bit && m_sAddress.StartsWith("K"))
                ListAddress = GetSubArrayData();
            else if (m_eSubDataType == EMSubDataType.WordDotBit)
                ListAddress = GetSubWordDotBitData();
            else
                ListAddress = GetSubData();

            return ListAddress;
        }


        private List<string> GetSubWordDotBitData()
        {
            List<string> ListAddress = new List<string>();
            int nWordSize = m_nSize / 16;

            for (int i = 0; i <= nWordSize; i++)
                ListAddress.Add(CILSubDataType.GetNextAddress(m_sAddress.Split('.')[0], i));

            for (int iBitSize = 0; iBitSize < m_nSize; iBitSize++)
                ListAddress.Add(CILSubDataType.GetNextWordDotBitAddress(m_sAddress, iBitSize));

            return ListAddress;
        }

        private List<string> GetSubArrayData()
        {
            List<string> ListAddress = new List<string>();
            int nBitSize = Convert.ToInt32(m_sAddress.Substring(1, 1));

            for (int i = 0; i < m_nSize; i++)
            {
                for (int iBitSize = 0; iBitSize < nBitSize * 4; iBitSize++)      // EHeadSize K = 4;
                    ListAddress.Add(CILSubDataType.GetNextArrayAddress(m_sAddress, iBitSize, i));
            }

            return ListAddress;
        }

        private List<string> GetSubData()
        {
            List<string> ListAddress = new List<string>();

            for (int i = 0; i < m_nSize; i++)
                ListAddress.Add(CILSubDataType.GetNextAddress(m_sAddress, i));

            return ListAddress;
        }
    }
}
