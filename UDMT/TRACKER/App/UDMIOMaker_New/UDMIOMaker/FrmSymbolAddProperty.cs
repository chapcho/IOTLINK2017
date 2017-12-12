using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.MVVM;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Import.OpenXml;
using UDM.Common;
using UDM.UDLImport;

namespace UDMIOMaker
{
    public partial class FrmSymbolAddProperty : DevExpress.XtraEditors.XtraForm
    {
        private CTag m_cTag = new CTag();
        private string m_sPLCName = string.Empty;

        public FrmSymbolAddProperty()
        {
            InitializeComponent();
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public string PLCName
        {
            get { return m_sPLCName; }
            set { m_sPLCName = value; }
        }

        private void SetMakerPLCAddress()
        {
            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[m_cTag.Channel].PLCMaker;

            m_cTag.Address = m_cTag.Address.ToUpper();
            m_cTag.PLCMaker = emPLCMaker;

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensPLCAddress();
            else if(emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecPLCAddress();
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                SetLSPLCAddress();
        }

        private void SetSiemensPLCAddress()
        {
            try
            {
                if (!m_cTag.Address.Contains("."))
                    SetSiemensAddressNotContainDot(m_cTag);
                else
                    SetSiemensAddressContainDot(m_cTag);

                if (m_cTag.DataType.Equals(EMDataType.Block))
                    m_cTag.UDTType = m_cTag.Address;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Siemens PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetMelsecPLCAddress()
        {
            try
            {
                if (!m_cTag.Address.Contains("."))
                    SetMelsecAddressNotContainDot(m_cTag);
                else
                    SetMelsecAddressContainDot(m_cTag);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Melsec PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
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

        private void SetLSPLCAddress()
        {
            try
            {
                if (!m_cTag.Address.Contains("."))
                    SetLSAddressNotContainDot(m_cTag);
                else
                    SetLSAddressContainDot(m_cTag);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("LS PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetLSAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            sHeader = sAddress.Substring(0, 1);
            sIndex = sAddress.Remove(0, 1).Split('.')[0];
            sDotValue = sAddress.Remove(0, 1).Split('.')[1];

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 5)
            {
                int iCount = 5 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress.ToUpper();
        }

        private void SetLSAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;
            bool bHexa = false;


                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);


            if (sAddress.StartsWith("T") || sAddress.StartsWith("C") || sAddress.StartsWith("N"))
                bHexa = false;
            else
                bHexa = true;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);

                if (sIndex.Length < 6)
                {
                    int iCount = 6 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
            }
            else
            {
                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();

                if (sIndex.Length < 5)
                {
                    int iCount = 5 - sIndex.Length;

                    for (int i = 0; i < iCount; i++)
                        sIndex = sIndex.Insert(0, "0");
                }
            }

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress.ToUpper();
        }

        private void SetSiemensAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;

            if (!sAddress.StartsWith("DB"))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1).Split('.')[0];
                sDotValue = sAddress.Remove(0, 1).Split('.')[1];
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2).Split('.')[0];
                sDotValue = sAddress.Remove(0, 2).Split('.')[1];
            }

            iIndex = Convert.ToInt32(sIndex);
            sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress;
        }

        private void SetSiemensAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;

            if (!sAddress.StartsWith("DB"))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

                iIndex = Convert.ToInt32(sIndex);
                sIndex = iIndex.ToString();

            if (sIndex.Length < 4)
            {
                int iCount = 4 - sIndex.Length;

                for (int i = 0; i < iCount; i++)
                    sIndex = sIndex.Insert(0, "0");
            }

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress;
        }


        private void SetMelsecAddressContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            string sDotValue = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1).Split('.')[0];
                sDotValue = sAddress.Remove(0, 1).Split('.')[1];
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2).Split('.')[0];
                sDotValue = sAddress.Remove(0, 2).Split('.')[1];
            }

            if (CMelsecPlc.IsMelsecHexa(sAddress))
                bHexa = true;
            else
                bHexa = false;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);
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

            sAddress = string.Format("{0}{1}.{2}", sHeader, sIndex, sDotValue);
            cTag.Address = sAddress;
        }

        private void SetMelsecAddressNotContainDot(CTag cTag)
        {
            string sAddress = cTag.Address;
            string sHeader = string.Empty;
            string sIndex = string.Empty;
            int iIndex = -1;
            bool bHexa = false;

            if (CMelsecPlc.IsMelsecHeadOne(sAddress))
            {
                sHeader = sAddress.Substring(0, 1);
                sIndex = sAddress.Remove(0, 1);
            }
            else
            {
                sHeader = sAddress.Substring(0, 2);
                sIndex = sAddress.Remove(0, 2);
            }

            if (CMelsecPlc.IsMelsecHexa(sAddress))
                bHexa = true;
            else
                bHexa = false;

            if (bHexa)
            {
                iIndex = Convert.ToInt32(sIndex, 16);
                sIndex = string.Format("{0:X}", iIndex);
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

            sAddress = string.Format("{0}{1}", sHeader, sIndex);
            cTag.Address = sAddress;
        }

        private bool CheckTag()
        {
            bool bOK = true;

            if (m_cTag.Channel == string.Empty)
            {
                XtraMessageBox.Show("PLC 심볼의 PLC Name이 입력되지 않았습니다.\r\nPLC Name을 입력해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cTag.Address == string.Empty)
            {
                XtraMessageBox.Show("PLC 심볼의 Address가 입력되지 않았습니다.\r\nAddress를 입력해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (m_cTag.Address.Contains(","))
            {
                XtraMessageBox.Show("PLC 심볼의 Address 형식이 잘못되었습니다.\r\nAddress를 확인해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (m_cTag.DataType == EMDataType.None)
            {
                XtraMessageBox.Show("PLC 심볼의 Data Type이 None 입니다.\r\nData Type을 설정해 주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!CProjectManager.LogicDataS[m_cTag.Channel].PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) && !CProjectManager.LogicDataS[m_cTag.Channel].PLCMaker.Equals(EMPLCMaker.LS) && m_cTag.Name == string.Empty)
            {
                XtraMessageBox.Show("PLC 심볼의 Name이 입력되지 않았습니다.\r\nName을 입력해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return bOK;
        }

        private bool CheckAddressHeader()
        {
            bool bOK = false;
            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[m_cTag.Channel].PLCMaker;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
                bOK = CheckMelsecHeader();
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                bOK = CheckSiemensHeader();
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                bOK = CheckLSHeader();

            return bOK;
        }

        private bool CheckMelsecHeader()
        {
            bool bOK = false;

            string sAddress = m_cTag.Address;

            if (sAddress.StartsWith("X") || sAddress.StartsWith("Y") || sAddress.StartsWith("M") ||
                sAddress.StartsWith("L")
                || sAddress.StartsWith("B") || sAddress.StartsWith("T") || sAddress.StartsWith("C"))
            {
                if (sAddress.Contains("."))
                    return false;
            }

            string sValue = sAddress.Remove(0, 1);

            if (sValue.Contains("."))
            {
                if (sValue.Length > 6)
                    return false;
            }
            else
            {
                if (sValue.Length > 5)
                    return false;
            }

            List<string> lstHeader = GetTypeValue(EMBLOCK_MITUBISHI.TYPE_LIST);

            foreach (var sHeader in lstHeader)
            {
                if (sAddress.StartsWith(sHeader))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckSiemensHeader()
        {
            bool bOK = false;

            string sAddress = m_cTag.Address;

            if (sAddress.StartsWith("DB") || sAddress.StartsWith("T") || sAddress.StartsWith("C"))
            {
                if (sAddress.Contains("."))
                    return false;
            }

            string sValue = string.Empty;

            if(sAddress.StartsWith("DB"))
                sValue = sAddress.Remove(0, 2);
            else
                sValue = sAddress.Remove(0, 1);

            if (sValue.Contains("."))
            {
                if (sValue.Length > 7)
                    return false;
            }
            else
            {
                if (sValue.Length > 6)
                    return false;
            }

            List<string> lstHeader = GetTypeValue(EMBLOCK_SIEMENS.TYPE_LIST);

            foreach (var sHeader in lstHeader)
            {
                if (sAddress.StartsWith(sHeader))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckLSHeader()
        {
            bool bOK = false;

            string sAddress = m_cTag.Address;

            if (!sAddress.StartsWith("D"))
            {
                if (sAddress.Contains("."))
                    return false;
            }

            string sValue = sAddress.Remove(0, 1);

            if (sValue.Contains("."))
            {
                if (sValue.Length > 7)
                    return false;
            }
            else
            {
                if (sValue.Length > 6)
                    return false;
            }

            List<string> lstHeader = GetTypeValue(EMBLOCK_LS.TYPE_LIST);

            foreach (var sHeader in lstHeader)
            {
                if (sAddress.StartsWith(sHeader))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_cTag.Address = m_cTag.Address.ToUpper();

                bool bOK = CheckTag();

                if (!bOK)
                    return;

                if (!CheckAddressHeader())
                {
                    XtraMessageBox.Show("해당 Address는 생성 불가능한 Address 입니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                SetMakerPLCAddress();
                m_cTag.Key = string.Format("[{0}]{1}[{2}]", m_cTag.Channel, m_cTag.Address, m_cTag.Size);

                if (CProjectManager.PLCTagS.ContainsKey(m_cTag.Key))
                {
                    XtraMessageBox.Show("해당 Address를 가진 PLC 심볼은 이미 존재합니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("SymbolAddProperty OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmSymbolAddProperty_Load(object sender, EventArgs e)
        {
            try
            {
                cboPLCList.Properties.Items.Clear();

                foreach (var who in CProjectManager.LogicDataS)
                    cboPLCList.Properties.Items.Add(who.Key);

                cboPLCList.EditValue = m_sPLCName;
                m_cTag.PLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

                if (m_cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_cTag.PLCMaker.Equals(EMPLCMaker.LS))
                    rowTagName.Properties.Caption = "Name";

                exSymbolProperty.SelectedObject = m_cTag;
                exSymbolProperty.Refresh();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmSymbolAddProperty Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboPLCList_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCList.EditValue;

                m_cTag.Channel = sPLCName;
                exSymbolProperty.Refresh();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("SymbolAddProperty SelectedValueChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }
}