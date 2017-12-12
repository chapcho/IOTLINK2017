using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UserDesigner;
using TrackerCommon;
using TrackerSPD.LS;
using TrackerSPD.OPC;
using UDM.Common;
using UDM.UDLImport;

namespace UDMOptimizer
{
    public partial class FrmTagAddProperty : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private CTag m_cTag = new CTag();
        private string m_sPlcID = string.Empty;
        private bool m_bValidate = false;

        #endregion

        #region Initialize/Dispose

        public FrmTagAddProperty()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public string PlcID
        {
            get { return m_sPlcID; }
            set { m_sPlcID = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool CheckTag()
        {
            bool bOK = true;

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

            if (!CMultiProject.PlcLogicDataS[m_sPlcID].Maker.Equals(EMPLCMaker.Mitsubishi_Developer) && !CMultiProject.PlcLogicDataS[m_sPlcID].Maker.Equals(EMPLCMaker.LS) && m_cTag.Name == string.Empty)
            {
                XtraMessageBox.Show("PLC 심볼의 Name이 입력되지 않았습니다.\r\nName을 입력해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return bOK;
        }

        private void SetMakerPLCAddress()
        {
            EMPLCMaker emPLCMaker = CMultiProject.PlcLogicDataS[m_sPlcID].Maker;

            m_cTag.Address = m_cTag.Address.ToUpper();
            m_cTag.PLCMaker = emPLCMaker;

            if (emPLCMaker.Equals(EMPLCMaker.Rockwell))
            {

            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                SetSiemensPLCAddress();
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
                SetMelsecPLCAddress();
            //else if (emPLCMaker.Equals(EMPLCMaker.LS))
                //SetLSPLCAddress();
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
                CMultiProject.SystemLog.WriteLog("Siemens PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
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
                CMultiProject.SystemLog.WriteLog("Melsec PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
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
                CMultiProject.SystemLog.WriteLog("LS PLC Address Setting Fail", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
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

        private void ValidateTag()
        {
            //m_cTag.Address = m_cTag.Address.ToUpper();

            bool bOK = CheckTag();

            if (!bOK)
                return;

            CPlcConfig cConfig = null;

            if (!CMultiProject.PlcConfigS.ContainsKey(m_sPlcID))
                return;

            cConfig = CMultiProject.PlcConfigS[m_sPlcID];

            //if (cConfig.CollectType != EMCollectType.OPC)
            //{
            //    XtraMessageBox.Show("현재 Validate Checking은 OPC Server를 대상으로만 가능합니다.", "Validate Check",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if(cConfig.CollectType.Equals(EMCollectType.OPC))
                ValidateOPC(cConfig);
            else if (cConfig.CollectType.Equals(EMCollectType.LSDDE))
                ValidateLSDDEA(cConfig);
            else
            {
                XtraMessageBox.Show("해당 Collect Type은 Validate Checking을 진행할 수 없습니다.", "Validate Check",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void ValidateOPC(CPlcConfig cConfig)
        {
            try
            {
                COPCServer cOPCServer = new COPCServer();
                cOPCServer.Config = new COPCConfig();
                cOPCServer.Config.Use = true;
                cOPCServer.Config.ABOpc = cConfig.OPCConfig.ABOpc;
                cOPCServer.Config.LsOpc = cConfig.OPCConfig.LsOpc;
                cOPCServer.Config.ServerName = cConfig.OPCConfig.ServerName;
                cOPCServer.Config.ChannelDevice = cConfig.OPCConfig.ChannelDevice;
                cOPCServer.Config.UpdateRate = cConfig.OPCConfig.UpdateRate;

                bool bOK = cOPCServer.Connect();

                List<CTag> lstTag = new List<CTag>();
                lstTag.Add(m_cTag);

                if (bOK)
                {
                    List<string> lstResult = cOPCServer.ValidateItemS(lstTag);
                    if (lstResult != null && lstResult.Count != 0)
                    {
                        string sMessage =
                            string.Format(
                                "Validate Check Fail!!!\r\nServer Name : {0}, ChannelDevice : {1}, Address : {2}",
                                cConfig.OPCConfig.ServerName, cConfig.OPCConfig.ChannelDevice, m_cTag.Address);

                        XtraMessageBox.Show(sMessage, "Validate Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string sMessage =
                            string.Format(
                                "Validate Check Success!!!\r\nServer Name : {0}, ChannelDevice : {1}, Address : {2}",
                                cConfig.OPCConfig.ServerName, cConfig.OPCConfig.ChannelDevice, m_cTag.Address);

                        XtraMessageBox.Show(sMessage, "Validate Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_bValidate = true;
                    }
                }
                else
                    XtraMessageBox.Show("OPC Server가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);


                cOPCServer.Disconnect();
                cOPCServer.Dispose();
                cOPCServer = null;
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty ValidateOPC Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ValidateLSDDEA(CPlcConfig cConfig)
        {
            try
            {
                CLsReader cReader = new CLsReader();
                cReader.Config = cConfig.LsConfig;

                bool bOK = cReader.Connect();

                List<CTag> lstTag = new List<CTag>();
                lstTag.Add(m_cTag);

                if (bOK)
                {
                    if (!cReader.AddItemS(lstTag))
                        XtraMessageBox.Show("LS DDEA Validate Fail!!!.", "Validate Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        XtraMessageBox.Show("LS DDEA Validate Success!!!.", "Validate Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_bValidate = true;
                    }
                }
                else
                    XtraMessageBox.Show("LS DDEA가 연결되지 않습니다.", "Connect Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cReader.Disconnect();
                cReader.Dispose();
                cReader = null;
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty ValidateLSDDEA Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void cboPLCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCList.EditValue;
                string sPLCID = string.Empty;

                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    if (who.Value.PlcName == sPLCName)
                    {
                        sPLCID = who.Key;
                        m_sPlcID = sPLCID;
                        break;
                    }
                }

                m_cTag.Channel = CMultiProject.PlcLogicDataS[sPLCID].PlcChannel;
                exSymbolProperty.Refresh();

                txtMaker.EditValue = CMultiProject.PlcLogicDataS[sPLCID].Maker;
                txtCollectType.EditValue = CMultiProject.PlcLogicDataS[sPLCID].CollectType;

            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty cboPLCList_SelectedIndexChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmTagAddProperty_Load(object sender, EventArgs e)
        {
            try
            {
                cboPLCList.Properties.Items.Clear();

                foreach (var who in CMultiProject.PlcLogicDataS)
                    cboPLCList.Properties.Items.Add(who.Value.PlcName);

                if (CMultiProject.PlcLogicDataS.Count != 0)
                {
                    string sPlcID = CMultiProject.PlcLogicDataS.First().Key;
                    m_cTag.PLCMaker = CMultiProject.PlcLogicDataS[sPlcID].Maker;

                    if (m_cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_cTag.PLCMaker.Equals(EMPLCMaker.LS))
                        rowTagName.Properties.Caption = "Name";

                    cboPLCList.EditValue = CMultiProject.PlcLogicDataS.First().Value.PlcName;
                }

                exSymbolProperty.SelectedObject = m_cTag;
                exSymbolProperty.Refresh();

            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bValidate)
                {
                    DialogResult dlgResult = XtraMessageBox.Show("생성하신 태그에 대한 Validate Checking이 완료되지 않았습니다.\r\n그래도 태그를 추가하시겠습니까?", "Tag Add",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlgResult == DialogResult.No)
                        return;
                }

                m_cTag.Address = m_cTag.Address.ToUpper();

                bool bOK = CheckTag();

                if (!bOK)
                    return;

                SetMakerPLCAddress();
                m_cTag.Key = string.Format("[{0}]{1}[{2}]", m_cTag.Channel, m_cTag.Address, m_cTag.Size);

                if (CMultiProject.TotalTagS.ContainsKey(m_cTag.Key))
                {
                    XtraMessageBox.Show("해당 Address를 가진 PLC 심볼은 이미 존재합니다.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                m_cTag.Creator = m_sPlcID;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty btnOK_Click Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnValidTag_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateTag();
            }
            catch (System.Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmTagAddProperty btnValidTag_Click Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }
}