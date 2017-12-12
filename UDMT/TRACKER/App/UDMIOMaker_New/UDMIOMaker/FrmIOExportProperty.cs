using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.UI;

namespace UDMIOMaker
{
    public partial class FrmIOExportProperty : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bExtend = false;
        private string m_sSavePath = string.Empty;
        private BackgroundWorker m_BGWorker = null;
        private bool m_bExportOK = false;

        private Dictionary<string, CBlockView> m_dicBlockView = new Dictionary<string, CBlockView>();

        #region Default Maker Range

        private const int SIEMENS_GENERAL_NORMAL_RANGE = 8191;
        private const int SIEMENS_GENERAL_EXTEND_RANGE = 16383;
        private const int SIEMENS_WORD_NORMAL_RANGE = 819;
        private const int SIEMENS_WORD_EXTEND_RANGE = 1638;
        private const int LS_GENERAL_NORMAL_RANGE = 1023;
        private const int LS_GENERAL_EXTEND_RANGE = 2047;
        private const int LS_TC_NORMAL_RANGE = 102;
        private const int LS_TC_EXTEND_RANGE = 204;
        private const int LS_L_NORMAL_RANGE = 5630;
        private const int LS_L_EXTEND_RANGE = 11263;
        private const int LS_N_NORMAL_RANGE = 11263;
        private const int LS_N_EXTEND_RANGE = 21503;
        private const int LS_MD_NORMAL_RANGE = 12000;
        private const int LS_MD_EXTEND_RANGE = 25000;
        private const int MELSEC_GENERAL_NORMAL_RANGE = 511;
        private const int MELSEC_GENERAL_EXTEND_RANGE = 1023;
        private const int MELSEC_D_NORMAL_RANGE = 8191;
        private const int MELSEC_D_EXTEND_RANGE = 12287;
        private const int MELSEC_T_NORMAL_RANGE = 204;
        private const int MELSEC_T_EXTEND_RANGE = 204;
        private const int MELSEC_C_NORMAL_RANGE = 102;
        private const int MELSEC_C_EXTEND_RANGE = 102;

        #endregion

        public FrmIOExportProperty()
        {
            InitializeComponent();
        }

        public string SavePath
        {
            get { return m_sSavePath; }
            set { m_sSavePath = value; }
        }

        private void SetPLCList()
        {
            cboPLCList.Properties.Items.Clear();

            foreach (var who in CProjectManager.LogicDataS)
                cboPLCList.Properties.Items.Add(who.Key);

            if (CProjectManager.LogicDataS.Count != 0)
                cboPLCList.EditValue = CProjectManager.LogicDataS.First().Key;
        }

        private void SetTypeList()
        {
            cboTypeList.Properties.Items.Clear();

            if (CProjectManager.LogicDataS.Count == 0 || cboPLCList.EditValue == null)
                return;

            string sPLCName = (string) cboPLCList.EditValue;

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                cboTypeList.Properties.Items.Add("IO_LIST");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_M");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_L");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_D");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_N");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_T");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_C");
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                cboTypeList.Properties.Items.Add("IO_LIST");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_M");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_T");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_C");
            }
            else if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                cboTypeList.Properties.Items.Add("IO_LIST");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_M");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_L");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_D");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_B");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_W");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_T");
                cboTypeList.Properties.Items.Add("DUMMY_LIST_C");
            }

            cboTypeList.EditValue = "IO_LIST";
        }

        private void SetAddressTypeArea(string sPLCName)
        {
            try
            {
                m_dicBlockView.Clear();

                CBlock cBlock;
                CBlockView cBlockView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    cBlockView = new CBlockView();
                    cBlockView.BlockName = who.Key;
                    cBlockView.StartAddress = cBlock.GetFirstBlockUnit();
                    cBlockView.EndAddress = cBlock.GetLastBlockUnit();

                    m_dicBlockView.Add(who.Key, cBlockView);

                    cBlock = null;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Block View Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private bool ExportMaker(string sPLCName, string sTypeList, string sSavePath)
        {
            bool bOK = false;

            string sDummyType = string.Empty;
            bool bDummy = false;
            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            CUtil.UEventExcelProcess += BGWorker_ProgressChanged;

            if (sTypeList.Contains("DUMMY"))
            {
                bDummy = true;
                sDummyType = sTypeList.Split('_').Last();
            }

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                CMelsecExport cExport = new CMelsecExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                cExport.IsExtendArea = m_bExtend;
                cExport.SavePath = sSavePath;

                if (!bDummy)
                    bOK = cExport.ExportMelsecIOList();
                else
                    bOK = cExport.ExportMelsecDummyList(sDummyType);

                if (bOK)
                    m_sSavePath = cExport.SavePath;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                CSiemensExport cExport = new CSiemensExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                cExport.IsExtendArea = m_bExtend;
                cExport.SavePath = sSavePath;

                if (!bDummy)
                    bOK = cExport.ExportSiemensIOList();
                else
                    bOK = cExport.ExportSiemensDummyList(sDummyType);

                if (bOK)
                    m_sSavePath = cExport.SavePath;
            }
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                CLSExport cExport = new CLSExport(emPLCMaker, CProjectManager.LogicDataS[sPLCName]);
                cExport.IsExtendArea = m_bExtend;
                cExport.SavePath = sSavePath;

                if (!bDummy)
                    bOK = cExport.ExportLSIOList();
                else
                    bOK = cExport.ExportLSDummyList(sDummyType);

                if (bOK)
                    m_sSavePath = cExport.SavePath;
            }

            CUtil.UEventExcelProcess -= BGWorker_ProgressChanged;

            m_bExportOK = bOK;

            return bOK;
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string sPath = (string) e.Argument;
            string sPLCName = (string) cboPLCList.EditValue;
            string sTypeList = (string)cboTypeList.EditValue;

            ExportMaker(sPLCName, sTypeList, sPath);
        }

        private void BGWorker_ProgressChanged(object sender, int iProcess)
        {
            m_BGWorker.ReportProgress(iProcess);
        }

        private void BGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                XtraMessageBox.Show("Export IO/Dummy List Fail!!!", "Export IO/Dummy List", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                CProjectManager.UpdateSystemMessage("IO Export Error", e.Error.Message);
                Console.WriteLine("IO Export Error " + e.Error.Message);
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                if (m_bExportOK)
                {
                    XtraMessageBox.Show("Export IO/Dummy List Success!!!", "Export IO/Dummy List", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    XtraMessageBox.Show("Export IO/Dummy List Fail!!!", "Export IO/Dummy List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }

            this.Close();
        }

        private void SetExportMaxArea()
        {
            string sMaxArea = string.Empty;
            string sPLCName = string.Empty;
            string sTypeList = string.Empty;

            if (cboPLCList.EditValue == null || cboTypeList.EditValue == null)
                return;

            sPLCName = (string) cboPLCList.EditValue;
            sTypeList = (string) cboTypeList.EditValue;

            if (sTypeList.Contains("IO_LIST"))
                sTypeList = "IO";
            else
                sTypeList = sTypeList.Split('_').Last();

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (m_bExtend)
                {
                    if (sTypeList.Equals("IO") || sTypeList.Equals("L") || sTypeList.Equals("B") ||
                        sTypeList.Equals("W") || sTypeList.Equals("M"))
                        sMaxArea = "16383 (3FFF)";
                    else if(sTypeList.Equals("D"))
                        sMaxArea = "12287 (12287.F)";
                    else if (sTypeList.Equals("T"))
                        sMaxArea = "2047";
                    else if (sTypeList.Equals("C"))
                        sMaxArea = "1023";
                }
                else
                {
                    if (sTypeList.Equals("IO") || sTypeList.Equals("L") || sTypeList.Equals("B") || 
                        sTypeList.Equals("W") || sTypeList.Equals("M"))
                        sMaxArea = "8191 (1FFF)";
                    else if (sTypeList.Equals("D"))
                        sMaxArea = "8191 (8191.F)";
                    else if (sTypeList.Equals("T"))
                        sMaxArea = "2047";
                    else if (sTypeList.Equals("C"))
                        sMaxArea = "1023";
                }
            }
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
            {
                if (m_bExtend)
                {
                    if (sTypeList.Equals("IO") || sTypeList.Equals("M"))
                        sMaxArea = "16383 (16383.7)";
                    else if (sTypeList.Equals("T") || sTypeList.Equals("C"))
                        sMaxArea = "16383";
                }
                else
                {
                    if (sTypeList.Equals("IO") || sTypeList.Equals("M"))
                        sMaxArea = "8191 (8191.7)";
                    else if (sTypeList.Equals("T") || sTypeList.Equals("C"))
                        sMaxArea = "8191";
                }
            }
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
            {
                if (m_bExtend)
                {
                    if (sTypeList.Equals("IO"))
                        sMaxArea = "2047F";
                    else if (sTypeList.Equals("T") || sTypeList.Equals("C"))
                        sMaxArea = "2047";
                    else if (sTypeList.Equals("L"))
                        sMaxArea = "11263";
                    else if (sTypeList.Equals("N"))
                        sMaxArea = "21503";
                    else if (sTypeList.Equals("M") || sTypeList.Equals("D"))
                        sMaxArea = "25000";
                }
                else
                {
                    if (sTypeList.Equals("IO"))
                        sMaxArea = "1023F";
                    else if (sTypeList.Equals("T") || sTypeList.Equals("C"))
                        sMaxArea = "1023";
                    else if (sTypeList.Equals("L"))
                        sMaxArea = "5630";
                    else if (sTypeList.Equals("N"))
                        sMaxArea = "11263";
                    else if (sTypeList.Equals("M") || sTypeList.Equals("D"))
                        sMaxArea = "12000";
                }
            }

            txtExportMaxArea.EditValue = sMaxArea;
        }

        private int GetCurrentExportMaxRange(EMPLCMaker emPLCMaker, string sType)
        {
            int iRange = -1;

            if (emPLCMaker.ToString().Contains("Mitsubishi"))
                iRange = GetMelsecUnitCount(sType);
            else if (emPLCMaker.Equals(EMPLCMaker.LS))
                iRange = GetLSUnitCount(sType);
            else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                iRange = GetSiemensUnitCount(sType);

            return iRange;
        }

        private int GetMelsecUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("D"))
            {
                if (m_bExtend)
                    iCount = MELSEC_D_EXTEND_RANGE;
                else
                    iCount = MELSEC_D_NORMAL_RANGE;
            }
            else if (sType.Equals("T"))
            {
                if (m_bExtend)
                    iCount = MELSEC_T_EXTEND_RANGE;
                else
                    iCount = MELSEC_T_NORMAL_RANGE;
            }
            else if (sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = MELSEC_C_EXTEND_RANGE;
                else
                    iCount = MELSEC_C_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = MELSEC_GENERAL_EXTEND_RANGE;
                else
                    iCount = MELSEC_GENERAL_NORMAL_RANGE;
            }

            return iCount;
        }

        private int GetSiemensUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("T") || sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = SIEMENS_WORD_EXTEND_RANGE;
                else
                    iCount = SIEMENS_WORD_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = SIEMENS_GENERAL_EXTEND_RANGE;
                else
                    iCount = SIEMENS_GENERAL_NORMAL_RANGE;
            }

            return iCount;
        }

        private int GetLSUnitCount(string sType)
        {
            int iCount = -1;

            if (sType.Equals("L"))
            {
                if (m_bExtend)
                    iCount = LS_L_EXTEND_RANGE;
                else
                    iCount = LS_L_NORMAL_RANGE;
            }
            else if (sType.Equals("N"))
            {
                if (m_bExtend)
                    iCount = LS_N_EXTEND_RANGE;
                else
                    iCount = LS_N_NORMAL_RANGE;
            }
            else if (sType.Equals("M") || sType.Equals("D"))
            {
                if (m_bExtend)
                    iCount = LS_MD_EXTEND_RANGE;
                else
                    iCount = LS_MD_NORMAL_RANGE;
            }
            else if (sType.Equals("T") || sType.Equals("C"))
            {
                if (m_bExtend)
                    iCount = LS_TC_EXTEND_RANGE;
                else
                    iCount = LS_TC_NORMAL_RANGE;
            }
            else
            {
                if (m_bExtend)
                    iCount = LS_GENERAL_EXTEND_RANGE;
                else
                    iCount = LS_GENERAL_NORMAL_RANGE;
            }

            return iCount;
        }

        private string GetMakerType(EMPLCMaker emPLCMaker, string sPLCName, string sTypeList)
        {
            string sType = string.Empty;

            if (sTypeList.Contains("IO_LIST"))
            {
                int iInputIndex = -1;
                int iOutputIndex = -1;

                if (emPLCMaker.ToString().Contains("Mitsubishi"))
                {
                    iInputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["X"].GetLastBlockRangeIndex();
                    iOutputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["Y"].GetLastBlockRangeIndex();

                    sType = iInputIndex >= iOutputIndex ? "X" : "Y";
                }
                else if (emPLCMaker.Equals(EMPLCMaker.Siemens))
                {
                    iInputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["I"].GetLastBlockRangeIndex();
                    iOutputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["Q"].GetLastBlockRangeIndex();

                    sType = iInputIndex >= iOutputIndex ? "I" : "Q";
                }
                else if (emPLCMaker.Equals(EMPLCMaker.LS))
                {
                    iInputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["P"].GetLastBlockRangeIndex();
                    iOutputIndex = CProjectManager.LogicDataS[sPLCName].AddressBlockS["K"].GetLastBlockRangeIndex();

                    sType = iInputIndex >= iOutputIndex ? "P" : "K";
                }
            }
            else
                sType = sTypeList.Split('_').Last();

            return sType;
        }

        private bool CheckAddressRange(string sPLCName, string sTypeList)
        {
            bool bOK = true;

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;

            string sType = GetMakerType(emPLCMaker, sPLCName, sTypeList);

            CBlock cBlock = CProjectManager.LogicDataS[sPLCName].AddressBlockS[sType];

            if (cBlock.GetFirstBlockUnit() == string.Empty && cBlock.GetLastBlockUnit() == string.Empty)
            {
                XtraMessageBox.Show("해당 \'" + sTypeList + "\'의 사용되는 Address 영역이 존재하지 않습니다.", "Export Fail!!!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            int iCurrentMaxRange = GetCurrentExportMaxRange(emPLCMaker, sType);
            int iBlockMaxRange = cBlock.GetLastBlockRangeIndex();

            if (iCurrentMaxRange < iBlockMaxRange)
            {
                string sMessage =
                    string.Format(
                        "현재 내보내기 하시고자 하는 최대 영역 \'{0}\' 보다 사용 중인 영역 \'{1}\' 이 더 큽니다.\r\n그래도 IO/Dummy List 내보내기를 진행하시겠습니까?",
                        txtExportMaxArea.EditValue.ToString(), cBlock.GetLastBlockUnit());

                if (
                    XtraMessageBox.Show(sMessage, "Max Address Range Check", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.No)
                    bOK = false;
            }

            return bOK;
        }

        private void FrmIOExportProperty_Load(object sender, EventArgs e)
        {
            try
            {
                SetPLCList();
                SetTypeList();
                SetExportMaxArea();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("IOExportProperty Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboPLCList_SelectedValueChanged(object sender, EventArgs e)
        {
            SetTypeList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null || cboTypeList.EditValue == null)
                    return;

                string sPLCName = (string)cboPLCList.EditValue;
                string sTypeList = (string) cboTypeList.EditValue;

                string sMessage = string.Format("내보내기 하고자 하시는 PLC의 이름은 {0} 이며, Type은 {1} 입니다.\r\nPLC의 크기가 클수록 시간이 오래걸릴 수 있습니다.\r\n그래도 내보내기 하시겠습니까?", sPLCName, sTypeList);

                if (XtraMessageBox.Show(sMessage, "Export PLC Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    DialogResult.No)
                    return;

                if (!CheckAddressRange(sPLCName, sTypeList))
                    return;

                bool bOK = false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.FileName = "IOMAKER_" + sTypeList + "_" + sPLCName + "_"  + CProjectManager.LogicDataS[sPLCName].PLCMaker.ToString();
                dlgSave.Filter = "*.xls|*.xls";

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                    return;

                //this.Hide();


                m_BGWorker = new BackgroundWorker();
                m_BGWorker.WorkerReportsProgress = true;
                m_BGWorker.DoWork += new DoWorkEventHandler(BGWorker_DoWork);
                var BGT = new BackgroundThread(m_BGWorker, "IO/DUMMY LIST 작성 중...", dlgSave.FileName);
                m_BGWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGWorker_RunWorkerCompleted);

                dlgSave.Dispose();
                dlgSave = null;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("IOExportProperty Export Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void btnAreaInfo_Click(object sender, EventArgs e)
        {
            FrmAreaInformation frmView = new FrmAreaInformation();
            frmView.TopMost = true;
            frmView.ShowDialog();


            frmView.Dispose();
            frmView = null;
        }

        private void chkExtendExport_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExtendExport.Checked)
                m_bExtend = true;
            else
                m_bExtend = false;

            SetExportMaxArea();
        }

        private void cboPLCList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboPLCList.EditValue == null)
                    return;

                string sPLCName = (string) cboPLCList.EditValue;

                grdAddressType.DataSource = null;
                SetAddressTypeArea(sPLCName);

                grdAddressType.DataSource = m_dicBlockView.Values.ToList();
                grdAddressType.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("IOExportProperty Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetExportMaxArea();

            //if (cboTypeList.EditValue != null)
            //{
            //    string sTypeList = (string) cboTypeList.EditValue;

            //    if (sTypeList.Contains("IO_LIST"))
            //        tgsEditable.ReadOnly = true;
            //    else
            //        tgsEditable.ReadOnly = false;
            //}
        }

        //private void tgsEditable_Toggled(object sender, EventArgs e)
        //{
        //    if (tgsEditable.IsOn)
        //        txtExportMaxArea.ReadOnly = false;
        //    else
        //        txtExportMaxArea.ReadOnly = true;
        //}
    }
}