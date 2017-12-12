using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CSubData
    {
        private string m_sAddress = string.Empty;
        private int m_iSize = 0;
        private List<string> m_lstSubDataDst = new List<string>();
        EMSubDataType m_emSubDataType = EMSubDataType.Unknown;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.Mitsubishi;

        private int m_MoveLimitCount = 128;

        #region Initialize/Dispose

        public CSubData(string sAddress, int iSize, EMSubDataType emSubDataType, bool bCheckDoubleWord, EMPLCMaker emPLCMaker)
        {
            if (iSize > m_MoveLimitCount)
                return;

            m_sAddress = sAddress;
            m_iSize = iSize;
            m_emSubDataType = emSubDataType;
            m_emPLCMaker = emPLCMaker;

            m_lstSubDataDst = GetSubDataList();
        }

        #endregion

        #region Properties

        public string Address
        {
            get { return m_sAddress; }
        }

        public EMSubDataType SubDataType
        {
            get { return m_emSubDataType; }
        }

        public List<string> SubDataList
        {
            get { return m_lstSubDataDst; }
        }

        #endregion
        
        #region Private Methods

        private List<string> GetSubDataList()
        {
            List<string> ListAddress = new List<string>();

            //Melsec 간접 지정(@, DWord), LS 간접 지정(#, Word)

            if (m_emPLCMaker != EMPLCMaker.LS && m_sAddress.StartsWith("K"))
            {
                if (m_emSubDataType == EMSubDataType.Word)
                    ListAddress = GetSubArrayData(false);
                else if(m_emSubDataType == EMSubDataType.DWord)
                    ListAddress = GetSubArrayData(true);
            }
            else if (m_emSubDataType == EMSubDataType.Word || m_emSubDataType == EMSubDataType.DWord)
                ListAddress = GetSubData();

            return ListAddress;
        }

        private List<string> GetSubData()
        {
            List<string> ListAddress = new List<string>();
            int iTemp = (m_emSubDataType == EMSubDataType.DWord ? 2 : 1);

            for (int i = 1; i < m_iSize; i++ )
                ListAddress.Add(GetNextAddress(m_sAddress, i * iTemp));

                return ListAddress;
        }

        private List<string> GetSubArrayData(bool bCheckDoubleWord)
        {
            List<string> ListAddress = new List<string>();

            for (int i = 1; i < m_iSize; i++)
                ListAddress.Add(GetNextArrayAddress(m_sAddress, i, bCheckDoubleWord));

            return ListAddress;
        }

        private string GetNextArrayAddress(string sAddress, int nNext, bool bCheckDoubleWord)
        {
            string sNextAddress = string.Empty;
            string sAddressArrayHeader = sAddress.Substring(0, 2);
            
            sAddress = sAddress.Remove(0, 2);

            string sAddressType = GetAddressType(sAddress);
            string sAddressIndex = sAddress.Substring(sAddressType.Length, sAddress.Length - sAddressType.Length);

            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            sNextAddress = sAddressArrayHeader + GetMelsecNextArrayAddress(sAddress, sAddressIndex, sAddressType, nNext, bCheckDoubleWord);

            return sNextAddress;
        }

        private string GetMelsecNextArrayAddress(string sAddress, string sAddressIndex, string sAddressType, int nNext, bool bCheckDoubleWord)
        {
            string sNextAddress = string.Empty;
            int iBitSize = 16;

            if (bCheckDoubleWord)
                iBitSize = 32;

            if (CMelsecPlc.IsMelsecHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nNext * iBitSize);
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nNext * iBitSize);
            }

            return sNextAddress;
        }

        private string GetNextAddress(string sAddress, int nNext)
        {
            string sNextAddress = string.Empty;
            string sAddressType = GetAddressType(sAddress);
            string sAddressIndex = sAddress.Substring(sAddressType.Length, sAddress.Length - sAddressType.Length);

            if (sAddressIndex.Contains("Z"))
                sAddressIndex = sAddressIndex.Split('Z')[0];

            if (m_emPLCMaker == EMPLCMaker.Mitsubishi || m_emPLCMaker == EMPLCMaker.Mitsubishi_Developer
                || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works2 || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works3)
                sNextAddress = GetMelsecNextAddress(sAddress, sAddressIndex, sAddressType, nNext);
            else if (m_emPLCMaker == EMPLCMaker.LS)
                sNextAddress = GetLSNextAddress(sAddressType, sAddressIndex, sAddressType, nNext);

            return sNextAddress;
        }

        private string GetAddressType(string sAddress)
        {
            string sAddressType = string.Empty;

            if (m_emPLCMaker == EMPLCMaker.Mitsubishi || m_emPLCMaker == EMPLCMaker.Mitsubishi_Developer
                || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works2 || m_emPLCMaker == EMPLCMaker.Mitsubishi_Works3)
            {
                if (CMelsecPlc.IsMelsecHeadOne(sAddress))
                    sAddressType = sAddress.Substring(0, 1);
                else if (CMelsecPlc.IsMelsecHeadTwo(sAddress))
                    sAddressType = sAddress.Substring(0, 2);
            }
            else if (m_emPLCMaker == EMPLCMaker.LS)
            {
                if (CLSPlc.IsLSHeadOne(sAddress))
                    sAddressType = sAddress.Substring(0, 1);
                else if (CLSPlc.IsLSHeadTwo(sAddress))
                    sAddressType = sAddress.Substring(0, 2);
            }

            return sAddressType;
        }

        private string GetMelsecNextAddress(string sAddress, string sAddressIndex, string sAddressType, int nNext)
        {
            string sNextAddress = string.Empty;

            if (CMelsecPlc.IsMelsecHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nNext);
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nNext);
            }

            return sNextAddress;
        }

        private string GetLSNextAddress(string sAddress, string sAddressIndex, string sAddressType, int nNext)
        {
            string sNextAddress = string.Empty;

            if (CLSPlc.IsLSHexa(sAddress))
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 16);
                sNextAddress = string.Format("{0}{1:X}", sAddressType, nAddress + nNext);
            }
            else
            {
                int nAddress = Convert.ToInt32(sAddressIndex, 10);
                sNextAddress = string.Format("{0}{1}", sAddressType, nAddress + nNext);
            }

            string sTemp = sNextAddress.Remove(0, sAddressType.Length);
            string sDigit = string.Empty;

            for (int i = sTemp.Length; i < 5; i++)
                sDigit += "0";

            sNextAddress = sAddressType + sDigit + sTemp;
            return sNextAddress;
        }


        #endregion

    }
}
