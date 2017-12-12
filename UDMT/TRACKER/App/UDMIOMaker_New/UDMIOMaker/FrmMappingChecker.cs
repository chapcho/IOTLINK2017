using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmMappingChecker : DevExpress.XtraEditors.XtraForm
    {
        private double m_dTotalCount = -1;
        private double m_dMappingCount = -1;

        private bool m_bOK = false;

        public FrmMappingChecker()
        {
            InitializeComponent();
        }

        public bool IsOK
        {
            get { return m_bOK; }
            set { m_bOK = value; }
        }

        private List<string> GetTypeValue(string sType)
        {
            List<string> lstValue = new List<string>();
            List<string> sTemp = null;

            if (sType.Contains(";"))
                sTemp = sType.Split(';').ToList();

            if (sTemp != null && sTemp.Count > 0)
            {
                foreach (var who in sTemp)
                    lstValue.Add(who);
            }

            return lstValue;
        }

        private string GetDigitAddress(string sAddress, EMPLCMaker emPLCMaker)
        {
            string sNewAddress = string.Empty;

            try
            {
                if (sAddress.StartsWith("HX") || sAddress.StartsWith("HW"))
                    sNewAddress = GetNullAddress(sAddress);
                else
                {
                    if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                        sNewAddress = GetSiemensDigitAddress(sAddress);
                    else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                        sNewAddress = GetMelsecDigitAddress(sAddress);
                    else if (emPLCMaker.Equals(EMPLCMaker.LS))
                        sNewAddress = GetLSDigitAddress(sAddress);
                    else
                        sNewAddress = sAddress;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Tag Import",
                    ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return sNewAddress;
        }

        private string GetNullAddress(string sAddress)
        {
            string sNewAddress = string.Empty;
            string sHeader = sAddress.Substring(0, 2);
            string sIndex = sAddress.Remove(0, 2);
            int iIndex = -1;
            bool bHexa = false;

            if (Regex.IsMatch(sIndex.ToUpper(), "[A-F]"))
                bHexa = true;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = iIndex.ToString("X");
            }
            else
            {
                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();
            }

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sNewAddress = string.Format("{0}{1}", sHeader, sIndex);

            return sNewAddress;
        }

        private string GetMelsecDigitAddress(string sAddress)
        {
            string sNewAddress = string.Empty;
            bool bHexa = false;
            List<string> lstParse = GetTypeValue(EMBLOCK_MITUBISHI.TYPE_LIST);

            if (!CheckAddressHeader(lstParse, sAddress))
                return sAddress;

            bHexa = CheckMelsecHexa(sAddress);

            if (sAddress.Contains("."))
                sNewAddress = GetMelsecAddressContainDot(sAddress, bHexa);
            else
                sNewAddress = GetMelsecAddressNotContainDot(sAddress, bHexa);

            return sNewAddress.ToUpper();
        }

        private string GetLSDigitAddress(string sAddress)
        {
            string sNewAddress = string.Empty;
            List<string> lstParse = GetTypeValue(EMBLOCK_LS.TYPE_LIST);

            if (!CheckAddressHeader(lstParse, sAddress))
                return sAddress;

            if (sAddress.Contains("."))
                sNewAddress = GetLSAddressContainDot(sAddress);
            else
                sNewAddress = GetLSAddressNotContainDot(sAddress);

            return sNewAddress.ToUpper();
        }
        private string GetLSAddressContainDot(string sAddress)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iValue = -1;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1);
            sDotValue = sIndex.Split('.')[1];
            sIndex = sIndex.Split('.')[0];

            iValue = Convert.ToInt32(sIndex);
            sIndex = iValue.ToString();

            if (sIndex.Length < 5)
            {
                int iCount = 5 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sNewAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);

            return sNewAddress;
        }

        private string GetLSAddressNotContainDot(string sAddress)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sBitValue = string.Empty;
            int iValue = -1;
            bool bWord = false;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1);
            sBitValue = sIndex.Substring(sIndex.Length - 1, 1);
            sIndex = sIndex.Remove(sIndex.Length - 1, 1);

            if (sAddress.StartsWith("T") || sAddress.StartsWith("C") || sAddress.StartsWith("N"))
            {
                bWord = true;
                sIndex = sAddress.Remove(0, 1);
            }

            iValue = Convert.ToInt32(sIndex);
            sIndex = iValue.ToString();

            if (sIndex.Length < 5)
            {
                int iCount = 5 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            if (bWord)
                sNewAddress = string.Format("{0}{1}", sHeader, sIndex);
            else
                sNewAddress = string.Format("{0}{1}{2}", sHeader, sIndex, sBitValue);

            return sNewAddress;
        }


        private string GetMelsecAddressContainDot(string sAddress, bool bHexa)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iValue = -1;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1);
            sDotValue = sIndex.Split('.')[1];
            sIndex = sIndex.Split('.')[0];

            if (bHexa)
            {
                iValue = Convert.ToInt32(sIndex, 16);
                sIndex = iValue.ToString("X");
            }
            else
            {
                iValue = Convert.ToInt32(sIndex);
                sIndex = iValue.ToString();
            }

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sNewAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);

            return sNewAddress;
        }

        private string GetMelsecAddressNotContainDot(string sAddress, bool bHexa)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iValue = -1;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1);

            if (bHexa)
            {
                iValue = Convert.ToInt32(sIndex, 16);
                sIndex = iValue.ToString("X");
            }
            else
            {
                iValue = Convert.ToInt32(sIndex);
                sIndex = iValue.ToString();
            }

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sNewAddress = string.Format("{0}{1}", sHeader, sIndex);

            return sNewAddress;
        }

        private bool CheckMelsecHexa(string sAddress)
        {
            bool bOK = false;

            List<string> lstParse = GetTypeValue(EMBLOCK_MITUBISHI.HEXA_LIST);

            foreach (string sParse in lstParse)
            {
                if (sAddress.StartsWith(sParse))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckAddressHeader(List<string> lstParse, string sAddress)
        {
            bool bOK = false;

            foreach (string sParse in lstParse)
            {
                if (sAddress.StartsWith(sParse))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private string GetSiemensDigitAddress(string sAddress)
        {
            string sNewAddress = string.Empty;
            List<string> lstParse = GetTypeValue(EMBLOCK_SIEMENS.TYPE_LIST);

            if (!CheckAddressHeader(lstParse, sAddress))
                return sAddress;

            bool bTwoHead = CheckSiemensTwoHead(sAddress);

            if (sAddress.Contains("."))
                sNewAddress = GetSiemensAddressContainDot(sAddress, bTwoHead);
            else
                sNewAddress = GetSiemensAddressNotContainDot(sAddress, bTwoHead);

            return sNewAddress.ToUpper();
        }

        private bool CheckSiemensTwoHead(string sAddress)
        {
            bool bOK = false;

            if (sAddress.StartsWith("DB") || sAddress.StartsWith("MB") || sAddress.StartsWith("MD") ||
                sAddress.StartsWith("MW"))
                bOK = true;

            return bOK;
        }


        private string GetSiemensAddressContainDot(string sAddress, bool bHeadTwo)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;

            if (bHeadTwo)
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }
            else
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }

            sDotValue = sIndex.Split('.')[1];
            sIndex = sIndex.Split('.')[0];

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }
            sNewAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue).ToUpper();

            return sNewAddress;
        }

        private string GetSiemensAddressNotContainDot(string sAddress, bool bHeadTwo)
        {
            string sNewAddress = string.Empty;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;

            if (bHeadTwo)
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }
            else
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }
            sNewAddress = sHeader + sIndex;

            return sNewAddress.ToUpper();
        }

        private void HMITagMappingCheck()
        {
            bool bOK = false;
            string sKey = string.Empty;

            m_dMappingCount = 0;
            m_dTotalCount = CProjectManager.HMITagS.Count;

            foreach (var who in CProjectManager.HMITagS)
            {
                who.Value.ClearPLCData();
                who.Value.PLCTagKey = string.Empty;
            }


            foreach (var who in CProjectManager.HMITagS)
            {
                bOK = false;

                if (chkDescription.Checked && who.Value.Description != string.Empty)
                {
                    sKey = GetPLCKeyToDescription(who.Value.Description, who.Value.Address);

                    if (sKey != string.Empty && CProjectManager.PLCTagS[sKey].DataType == who.Value.EMDataType)
                    {
                        bOK = true;
                        CProjectManager.PLCTagS[sKey].IsHMIMapping = true;

                        if (CProjectManager.HMITagS.CheckPLCTagMapping(sKey))
                        {
                            List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(sKey);

                            foreach (string sHMIKey in lstHMIKey)
                                CProjectManager.HMITagS[sHMIKey].IsRedundancy = true;

                            who.Value.IsRedundancy = true;
                        }

                        who.Value.IsExistedMatch = true;
                        who.Value.PLCTagKey = sKey;

                        CProjectManager.UpdateMappingMessage(EMMappingMessage.Mapping_Check_Description, CProjectManager.PLCTagS[sKey], who.Value);
                    }
                }

                if (!bOK && chkAddress.Checked)
                {
                    sKey = GetPLCKeyToAddress(who.Value.Address);

                    if (sKey != string.Empty && CProjectManager.PLCTagS[sKey].DataType == who.Value.EMDataType)
                    {
                        bOK = true;
                        CProjectManager.PLCTagS[sKey].IsHMIMapping = true;

                        if (CProjectManager.HMITagS.CheckPLCTagMapping(sKey))
                        {
                            List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(sKey);

                            foreach (string sHMIKey in lstHMIKey)
                                CProjectManager.HMITagS[sHMIKey].IsRedundancy = true;

                            who.Value.IsRedundancy = true;
                        }
                        who.Value.IsExistedMatch = true;
                        who.Value.PLCTagKey = sKey;

                        CProjectManager.UpdateMappingMessage(EMMappingMessage.Mapping_Check_Address, CProjectManager.PLCTagS[sKey], who.Value);
                    }
                }

                if (bOK)
                    m_dMappingCount++;
            }
        }

        private string GetPLCKeyToDescription(string sDescription, string sAddress)
        {
            string sPLCKey = string.Empty;
            string sNewAddress = string.Empty;

            foreach (var who in CProjectManager.PLCTagS)
            {
                if (who.Value.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || who.Value.PLCMaker.Equals(EMPLCMaker.LS))
                {
                    if (who.Value.Description == sDescription)
                    {
                        sNewAddress = GetDigitAddress(sAddress, who.Value.PLCMaker);

                        if (who.Value.Address == sNewAddress)
                        {
                            sPLCKey = who.Key;
                            break;
                        }
                    }
                }
                else
                {
                    if (who.Value.Name == sDescription)
                    {
                        sNewAddress = GetDigitAddress(sAddress, who.Value.PLCMaker);

                        if (who.Value.Address == sNewAddress)
                        {
                            sPLCKey = who.Key;
                            break;
                        }
                    }
                }
            }

            return sPLCKey;
        }

        private string GetPLCKeyToAddress(string sAddress)
        {
            string sPLCKey = string.Empty;

            foreach (var who in CProjectManager.PLCTagS)
            {
                if (who.Value.Address == sAddress)
                {
                    sPLCKey = who.Key;
                    break;
                }
            }

            return sPLCKey;
        }

        private string GetPLCKeyToName(string sName)
        {
            string sPLCKey = string.Empty;

            foreach (var who in CProjectManager.PLCTagS)
            {
                if (who.Value.Name == sName)
                {
                    sPLCKey = who.Key;
                    break;
                }
            }

            return sPLCKey;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    HMITagMappingCheck();
                }
                SplashScreenManager.CloseForm();

                string sMessage = string.Format("PLC-HMI 매핑 확인 진행 완료!!\r\nMapping Percentage : {0} %",
                    Math.Round((m_dMappingCount*100)/m_dTotalCount), 2);

                XtraMessageBox.Show(sMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                m_bOK = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Checker OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            m_bOK = false;
            this.Close();
        }
    }
}