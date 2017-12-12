using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Export;
using UDM.UDLImport;
using UDM.UI;

namespace UDMIOMaker
{
    public partial class FrmMain
    {
        private EMPLCMaker m_emCurPLCMaker = EMPLCMaker.ALL;
        private List<string> m_lstHMIGroup = new List<string>();
        private bool m_bRedundancy = false;

        private string m_sHMIGroup = string.Empty;
        private double m_dMappingCount = -1;
        private double m_dTotalCount = -1;

        private bool m_bAutoMappingFirst = true;

        private int m_iModuleNumber = -1;

        #region Public Methods

        #endregion

        #region Private Methods

        private string GetUserInputText(string sTitle, string sMessage, bool bModuleVisible)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);

            m_iModuleNumber = CProjectManager.LogicDataS.Count;
            dlgInput.ModuleNumber = m_iModuleNumber;
            dlgInput.IsModuleVisible = bModuleVisible;

            if (dlgInput.ShowDialog() == DialogResult.OK)
                m_iModuleNumber = dlgInput.ModuleNumber;

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        private void CreateVerificationTagS(CTagS cTagS)
        {
            try
            {
                CVerifTag cVerifTag = null;

                foreach (var who in cTagS)
                {
                    if (CProjectManager.VerifTagS.ContainsKey(who.Key))
                        continue;

                    cVerifTag = new CVerifTag();
                    cVerifTag.PLCMaker = who.Value.PLCMaker;
                    cVerifTag.Channel = who.Value.Channel;
                    cVerifTag.Address = who.Value.Address;
                    cVerifTag.Name = who.Value.Name;
                    cVerifTag.Description = who.Value.Description;
                    cVerifTag.Key = who.Value.Key;
                    cVerifTag.DataType = who.Value.DataType;

                    if(who.Value.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || who.Value.PLCMaker.Equals(EMPLCMaker.LS))
                        cVerifTag.GroupKey = GetVerifTagGroupKey(who.Value.Description);
                    else
                        cVerifTag.GroupKey = GetVerifTagGroupKey(who.Value.Name);

                    SetUsedLogic(who.Value, cVerifTag);
                    SetSymbolRole(who.Value, cVerifTag);
                    SetDoubleCoil(who.Value, cVerifTag);

                    CProjectManager.VerifTagS.Add(cVerifTag.Key, cVerifTag);
                }

                ucVerifyIOTree.ShowTree(false);
                ucVerifyAllTree.ShowTree(true);
                //ucVerifyElemTree.ShowDefaultReportTree();

                WriteToExcelReport();
                LoadVerificationExceltoSheet(CProjectManager.VerifPathUser);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Verification Tag Create", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private string GetVerifTagGroupKey(string sDescription)
        {
            string sGroupKey = string.Empty;

            if (sDescription.StartsWith("_"))
                return sGroupKey;

            sGroupKey = sDescription.Split('_')[0];

            return sGroupKey;
        }

        private bool ImportPLC(string sChannel)
        {
            bool bOK = true;

            try
            {
                CPlcLogicData cData = null;

                CUDLImport cLogic = new CUDLImport(EMPLCMaker.ALL, false);
                cLogic.Channel = sChannel;

                if (!cLogic.FileOpenCheck)
                {
                    XtraMessageBox.Show("File Open Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                bOK = cLogic.UDLGenerate();

                if (!bOK)
                {
                    XtraMessageBox.Show("Not Support File Format!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                cData = new CPlcLogicData();
                cData.TagS = cLogic.GlobalTags;
                cData.StepS = cLogic.StepS; //StepExtract

                if (pgPLCVerification.Visible)
                {
                    CStepExtract.SplitStepS(cData.StepS, cData.TagS);
                    cData.Compose();
                }

                cData.PLCMaker = cLogic.CUDL.Tags[0].PLCMaker;
                m_emCurPLCMaker = cLogic.CUDL.Tags[0].PLCMaker;

                if (m_emCurPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer))
                {
                    colName.Visible = false;
                    colVerifName.Visible = false;
                }
                else
                {
                    colName.Visible = true;
                    colVerifName.Visible = true;
                }

                foreach (var who in cData.TagS)
                {
                    if(m_emCurPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_emCurPLCMaker.Equals(EMPLCMaker.LS))
                        who.Value.Creator = GetPLCGroupKey(who.Value.Description);
                    else
                        who.Value.Creator = GetPLCGroupKey(who.Value.Name);
                }

                cData.Name = sChannel;

                if (pgHMIMapping.Visible)
                {
                    if (m_iModuleNumber != 0)
                        SetModuleNumber(cData.TagS);
                }

                CProjectManager.LogicDataS.Add(cData.Name, cData);
                CProjectManager.PLCTagS.AddRange(cData.TagS);


                if(pgPLCVerification.Visible || pgHMIMapping.Visible)
                    CreateVerificationTagS(cData.TagS);

                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Import", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }

            return bOK;
        }

        private string GetPLCGroupKey(string sDescription)
        {
            string sGroupKey = string.Empty;

            if (sDescription.StartsWith("\""))
                return sGroupKey;

            sGroupKey = sDescription.Split('_')[0];

            if (sGroupKey.Contains("-"))
                sGroupKey = sGroupKey.Split('-')[0];

            if(sGroupKey.Contains(" "))
                sGroupKey = sGroupKey.Split(' ')[0];

            return sGroupKey;
        }

        private void SetModuleNumber(CTagS cTagS)
        {
            try
            {
                foreach (var who in cTagS)
                    who.Value.Address = string.Format("{0}:{1}", m_iModuleNumber, who.Value.Address);

            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Import", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void ImportIO()
        {
            
        }

        private bool ImportHMI()
        {
            bool bOK = false;

            try
            {
                DataTable dtHMI = null;
                DataRow drRow = null;
                CHMITag cHMITag = null;

                ModuleHMI cHMI = new ModuleHMI(EMCommonHMIPrograms.XP_Builder.ToString());

                if (!cHMI.IsFileOpen)
                    return false;

                dtHMI = cHMI.dbHMI;

                if (dtHMI == null)
                {
                    XtraMessageBox.Show("Not Support File Format!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                ClearHMI();

                foreach (var who in dtHMI.Rows)
                {
                    drRow = (DataRow)who;
                    cHMITag = new CHMITag();

                    cHMITag.Number = int.Parse((string)drRow[0]);
                    cHMITag.Group = (string)drRow[1];
                    cHMITag.Name = (string)drRow[2];
                    cHMITag.DataType = (string)drRow[3];
                    cHMITag.Address = (string) drRow[4];

                    if (cHMITag.Address == string.Empty || cHMITag.Address.StartsWith("HX") || cHMITag.Address.StartsWith("HW"))
                        cHMITag.IsEmpty = true;

                    cHMITag.Description = (string)drRow[5];

                    if(cHMITag.Name.Contains("]"))
                    {
                        cHMITag.ConvertName = cHMITag.Name.Split(']')[1];
                        cHMITag.GroupKey = GetGroupKey(cHMITag.ConvertName);
                    }

                    CProjectManager.HMITagS.Add(cHMITag.Name, cHMITag);
                }

                bOK = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMI Import", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private void SetHMIGroupConvertUnitS()
        {
            foreach (var who in CProjectManager.HMITagS)
            {
                if (!m_lstHMIGroup.Contains(who.Value.Group))
                    m_lstHMIGroup.Add(who.Value.Group);
            }

            CConvertUnitS cUnitS;
            foreach (string sGroup in m_lstHMIGroup)
            {
                cUnitS = new CConvertUnitS();
                CreateDefaultGroupConvertUnitS(cUnitS);

                if(!CProjectManager.GroupConvertUnitS.ContainsKey(sGroup))
                    CProjectManager.GroupConvertUnitS.Add(sGroup, cUnitS);
            }
        }

        private void CreateDefaultGroupConvertUnitS(CConvertUnitS cUnitS)
        {
            CConvertUnit cUnit1 = new CConvertUnit("CLP_ADV", "CLP");
            cUnitS.Add(cUnit1);

            CConvertUnit cUnit2 = new CConvertUnit("CLP_RET", "UNCLP");
            cUnitS.Add(cUnit2);

            cUnit1 = new CConvertUnit("CLAMP_ADV", "CLP");
            cUnitS.Add(cUnit1);

            cUnit2 = new CConvertUnit("CLAMP_RET", "UNCLP");
            cUnitS.Add(cUnit2);

            CConvertUnit cUnit3 = new CConvertUnit("PIN_ADV", "PIN_UP");
            cUnitS.Add(cUnit3);

            CConvertUnit cUnit4 = new CConvertUnit("PIN_RET", "PIN_DN");
            cUnitS.Add(cUnit4);

            CConvertUnit cUnit5 = new CConvertUnit("EJECTOR_ADV", "EJECTOR_UP");
            cUnitS.Add(cUnit5);

            CConvertUnit cUnit6 = new CConvertUnit("EJECTOR_RET", "EJECTOR_DN");
            cUnitS.Add(cUnit6);

            CConvertUnit cUnit7 = new CConvertUnit("HK", "HOOK");
            cUnitS.Add(cUnit7);

            CConvertUnit cUnit8 = new CConvertUnit("BR_LINE", "BR");
            cUnitS.Add(cUnit8);

            CConvertUnit cUnit12 = new CConvertUnit("-M-IN", "");
            cUnitS.Add(cUnit12);

            CConvertUnit cUnit13 = new CConvertUnit("-DB-IN", "_MNT");
            cUnitS.Add(cUnit13);


            CConvertUnit cUnit10 = new CConvertUnit("R##", "RBT#");
            cUnitS.Add(cUnit10);

            CConvertUnit cUnit11 = new CConvertUnit("#BT", "BT#");
            cUnitS.Add(cUnit11);
        }

        private void ShowPLCGrid()
        {
            grdPLC.DataSource = null;
            grdPLC.DataSource = CProjectManager.PLCTagS.Values.ToList();
            grdPLC.RefreshDataSource();
        }

        private void ShowHMIGrid()
        {
            grdHMI.DataSource = null;
            grdHMI.DataSource = CProjectManager.HMITagS.Values.ToList();
            grdHMI.RefreshDataSource();
        }

        private void ShowPartialHMIExport()
        {
            foreach (string sGroup in m_lstHMIGroup)
            {
                if(!exEditorSectionExport.Items.Contains(sGroup))
                    exEditorSectionExport.Items.Add(sGroup);
            }
        }

        private void ClearPLC()
        {
            CProjectManager.LogicDataS.Clear();
            CProjectManager.PLCTagS.Clear();
            CProjectManager.VerifTagS.Clear();

            grdPLC.DataSource = null;
            grdPLC.RefreshDataSource();

            grdVerifPLC.DataSource = null;
            grdVerifPLC.RefreshDataSource();

            ucVerifyIOTree.ClearTree();
            ucVerifyAllTree.ClearTree();
            ucVerifyElemTree.ClearTree();

            //Design Page Clear
            ClearSymbolPLC();
            ClearAddressAreaInfo();
            ClearDesignPLC();
            ClearIOModuleInfo();
        }

        private void ClearHMI()
        {
            CProjectManager.HMITagS.Clear();
            CProjectManager.GroupConvertUnitS.Clear();

            m_lstHMIGroup.Clear();

            grdHMI.DataSource = null;
            grdHMI.RefreshDataSource();

            grdVerifHMI.DataSource = null;
            grdVerifHMI.RefreshDataSource();

            foreach (var who in CProjectManager.PLCTagS)
                who.Value.IsHMIMapping = false;

            grdPLC.RefreshDataSource();
        }

        private bool CheckPLC()
        {
            bool bOK = true;

            if (CProjectManager.LogicDataS.Count == 0)
                bOK = false;

            return bOK;
        }

        private bool CheckHMI()
        {
            bool bOK = true;

            if (CProjectManager.HMITagS.Count == 0)
                bOK = false;

            return bOK;
        }

        protected void ExportIOList()
        {
            var dlgSaveFile = new SaveFileDialog { Filter = @"*.xlsx|*.xlsx" };
            dlgSaveFile.ShowDialog();
            var sPath = dlgSaveFile.FileName;
            if (sPath == "")
                return;

            var type = PLCMakerConvertor(CProjectManager.LogicDataS.ElementAt(0).Value.PLCMaker.ToString());
            if (type == ePLC_MAKER.AB_ALIAS)
            {
                XtraMessageBox.Show("AB IO List에 부분은 Version Up 개발 진행중에 있습니다.", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;

                //m_backgroundWorker = new BackgroundWorker();
                //m_backgroundWorker.DoWork += new DoWorkEventHandler(ExportExcelAB);
                //var BGT = new BackgroundThread(m_backgroundWorker, "Processing..", sPath);
                //m_backgroundWorker.RunWorkerCompleted += (o, s) => { LoadExeltoSheet(sPath); };
            }
            else
            {
                m_backgroundWorker = new BackgroundWorker();
                m_backgroundWorker.DoWork += new DoWorkEventHandler(ExportExcel);
                var BGT = new BackgroundThread(m_backgroundWorker, "Processing..", sPath);
                m_backgroundWorker.RunWorkerCompleted += (o, s) => { LoadExeltoSheet(sPath); };
            }
        }

        private string PLCMakerConvertor(string value)
        {

            if (value.Contains("Developer"))
                return ePLC_MAKER.MITSUBISHI_DEVELOPER;
            else if (value.Contains("Works2"))
                return ePLC_MAKER.MITSUBISHI_WORKS2;
            else if (value.Contains("Works3"))
                return ePLC_MAKER.MITSUBISHI_WORKS3;
            else if (value.Contains("Siemens"))
                return ePLC_MAKER.SIEMENS;
            else if (value.Contains("Rockwell"))
                return ePLC_MAKER.AB_ALIAS;
            else
                return value;

        }

        private void ExportExcelAB(object sender, DoWorkEventArgs e)
        {
            var abExport = new IOListExport(CProjectManager.PLCTagS);
            var inputPath = string.Empty;

            switch (m_emExcelListType)
            {
                case eExcelListType.IO:
                    inputPath = Application.StartupPath + "\\ExcelTemplate\\AB\\IO_LIST_Template.xls";
                    break;
                case eExcelListType.DUMMY:
                    inputPath = Application.StartupPath + "\\ExcelTemplate\\AB\\DUMMY_LIST_Template.xls";
                    break;
            }

            var finfo = new FileInfo(inputPath);
            if (!finfo.Exists)
            {
                XtraMessageBox.Show("ExcelTemplate 파일이 존재 하지 않습니다.", "Important Note",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                m_bExport = false;
                return;
            }

            var path = (string)e.Argument;

            abExport.UEventExcelExportProcess += ExcelExportProgressInformation;
            switch (m_emExcelListType)
            {
                case eExcelListType.IO:
                    m_bExport = abExport.ExportToExcel(abExport.LstIoTag, inputPath, (string)e.Argument, "Project");
                    break;
                case eExcelListType.DUMMY:
                    m_bExport = abExport.ExportToExcelDummy(abExport.DicDummyTagS, inputPath, (string)e.Argument, "Project");
                    break;
            }
            abExport.UEventExcelExportProcess -= ExcelExportProgressInformation;
        }

        private void ExportExcel(object sender, DoWorkEventArgs e)
        {
            var path = (string)e.Argument;
            m_cExport.UEventExcelExportProcess += ExcelExportProgressInformation;

            if (!m_cExport.ExportExcel(CProjectManager.PLCTagS, (string)e.Argument, m_emExcelListType, PLCMakerConvertor(CProjectManager.LogicDataS.ElementAt(0).Value.PLCMaker.ToString())))
            {
                XtraMessageBox.Show("ExcelTemplate 파일이 존재 하지 않습니다.", "Important Note",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                m_bExport = false;
                return;
            }

            m_bExport = true;
            m_cExport.UEventExcelExportProcess -= ExcelExportProgressInformation;
        }

        private void ExcelExportProgressInformation(object sender, int nProcess)
        {
            m_backgroundWorker.ReportProgress(nProcess);
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is: 
                //still being written to 
                //or being processed by another thread 
                //or does not exist (has already been processed) 
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked 
            return false;
        }

        private void LoadExeltoSheet(string sPath)
        {
            try
            {

                var finfo = new FileInfo(sPath);
                if (finfo.Exists && !IsFileLocked(finfo))
                {
                    if(IOSpreadSheet.LoadDocument(sPath))
                        chkViewIOList.Checked = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string TagNameExtractor(string key)
        {
            string Temp = key.Replace("HMI_Sensor_Disp_Area.", "");

            return Temp;
        }

        private CHMITag GetHMITag(int iHandle)
        {
            CHMITag cHMITag = null;

            if (iHandle < 0)
                return null;

            object oData = grvHMI.GetRow(iHandle);
            if (oData.GetType() != typeof (CHMITag))
                return null;

            cHMITag = (CHMITag) oData;

            return cHMITag;
        }

        private CTag GetPLCTag(int iHandle)
        {
            CTag cTag = null;

            if (iHandle < 0)
                return null;

            object oData = grvPLC.GetRow(iHandle);
            if (oData.GetType() != typeof(CTag))
                return null;

            cTag = (CTag)oData;

            return cTag;
        }

        private void SetHMITagAddressAccordingToPLCMaker(CHMITag cHMITag, CTag cPLCTag)
        {
            if (cPLCTag.Description == string.Empty)
                cHMITag.Description = string.Empty;
            if (cPLCTag.Address == string.Empty)
                cHMITag.Address = string.Empty;

            if (m_emCurPLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                cHMITag.Address = cPLCTag.Name;
                cHMITag.Description = cPLCTag.Description;
            }
            //else if (m_emCurPLCMaker.Equals(EMPLCMaker.Siemens))
            //{
            //    cHMITag.Address = cPLCTag.Address;
            //    cHMITag.Description = cPLCTag.Name;
            //}
            else if(m_emCurPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || m_emCurPLCMaker.Equals(EMPLCMaker.LS))
            {
                cHMITag.Address = cPLCTag.Address;
                cHMITag.Description = cPLCTag.Description;
            }
            else
            {
                cHMITag.Address = cPLCTag.Address;
                cHMITag.Description = cPLCTag.Name;
            }
        }

        private bool CheckPLCTagRedundancy(CTag cPLCTag)
        {
            bool bOK = true;
            m_bRedundancy = false;

            if (CProjectManager.HMITagS.CheckPLCTagMapping(cPLCTag.Key))
            {
                List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cPLCTag.Key);
                string sTemp = string.Empty;

                for (int j = 0; j < lstHMIKey.Count; j++)
                {
                    if (j == lstHMIKey.Count - 1)
                        sTemp += lstHMIKey[j];
                    else
                        sTemp += string.Format("{0}/", lstHMIKey[j]);
                }

                if (
                    XtraMessageBox.Show(
                        "PLC Address : " + cPLCTag.Address +
                        " 는 이미 Mapping되어 있습니다.\r\n 중복해서 Mapping 하시겠습니까?\r\n\r\n 기존 Mapping된 HMI 이름 : " + sTemp,
                        "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    bOK = false;
                else
                {
                    CHMITag cHMITag = null;
                    foreach (var who in lstHMIKey)
                    {
                        cHMITag = CProjectManager.HMITagS[who];
                        cHMITag.IsRedundancy = true;

                        cHMITag = null;
                    }
                    m_bRedundancy = true;
                }
            }

            return bOK;
        }

        private void MappingPLCtoHMI(EMMappingType emMappingType)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int[] arrPLC = grvPLC.GetSelectedRows();

                if (emMappingType != EMMappingType.Insert)
                {
                    if (arrPLC.Length <= 0)
                    {
                        XtraMessageBox.Show("Select PLC Tag First!!", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                int[] arrHMI = grvHMI.GetSelectedRows();

                if (arrHMI.Length <= 0)
                {
                    XtraMessageBox.Show("Select HMI Tag First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (emMappingType)
                {
                    case EMMappingType.Match:
                        SetMatch(arrPLC, arrHMI);
                        break;
                    case EMMappingType.Convert:
                        SetConvert();
                        break;
                    case EMMappingType.Insert:
                        SetInsert();
                        break;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Error Match", "Match Error");
                ex.Data.Clear();
            }
        }

        private void SetMatch(int[] arrPLC, int[] arrHMI)
        {
            CancelMappingHMI(false, true);

            CHMITag cHMITag = null;
            CTag cPLCTag = null;
            int iMappingCount = arrPLC.Length >= arrHMI.Length ? arrHMI.Length : arrPLC.Length;

            if (iMappingCount > 1 && (arrPLC.Length != arrHMI.Length))
            {
                if (XtraMessageBox.Show(
                         "연결 하려는 대상의 수가 다릅니다. 계속 하시겠습니까? ", "[선택된 PLC : " + arrPLC.Length + "]" + " [선택된 HMI : " + arrHMI.Length + "]"
                         , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    return;
            }

            SetConvertName();

            for (int i = 0; i < iMappingCount; i++)
            {
                cPLCTag = GetPLCTag(arrPLC[i]);
                cHMITag = GetHMITag(arrHMI[i]);

                if (cPLCTag == null || cHMITag == null)
                    continue;

                cPLCTag.IsHMIMapping = true;

                if (!CheckPLCTagRedundancy(cPLCTag))
                    continue;

                cHMITag.PLCTagKey = cPLCTag.Key;
                cHMITag.IsMatch = true;

                if (m_bRedundancy)
                    cHMITag.IsRedundancy = true;

                SetHMITagAddressAccordingToPLCMaker(cHMITag, cPLCTag);

                CProjectManager.UpdateMappingMessage(EMMappingMessage.Manual_Mapping, cPLCTag, cHMITag);

                if (CProjectManager.HMITagS.IsContainConvertName(cHMITag.ConvertName, cHMITag.Name))
                    SetSameConvertNameHMITag(cHMITag);
            }

            grdPLC.RefreshDataSource();
            grdHMI.RefreshDataSource();
        }

        private void SetConvert()
        {
            
        }

        private void SetInsert()
        {
            CHMITag cFirstHMITag = null;
            int[] arrHMI = grvHMI.GetSelectedRows();

            if (arrHMI.Length <= 1)
            {
                XtraMessageBox.Show("2개 이상의 HMI Tag를 선택한 후 진행하세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cFirstHMITag = GetHMITag(arrHMI[0]);

            if (!cFirstHMITag.IsMatch && !cFirstHMITag.IsInsert && !cFirstHMITag.IsExistedMatch)
            {
                XtraMessageBox.Show(
                    "첫 번째 HMI Tag : " + cFirstHMITag.Name + " 가 Mapping되지 않았습니다.\r\n 먼저 첫 번째 HMI Tag를 Mapping 하세요.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InsertBit cInsertBit = new InsertBit(m_emCurPLCMaker, cFirstHMITag.Address, arrHMI.Length);

            if (!cInsertBit.IsInsertOK)
                return;

            CancelMappingHMI(true, false);

            CHMITag cHMITag = null;
            string sPLCTagKey = string.Empty;
            for (int i = 1; i < arrHMI.Length; i++)
            {
                cHMITag = GetHMITag(arrHMI[i]);
                if (cHMITag == null)
                    continue;

                if (!cHMITag.EMDataType.Equals(EMDataType.Bool))
                    continue;

                cHMITag.Address = cInsertBit.Bit[i - 1];
                sPLCTagKey = string.Format("[{0}]{1}[{2}]", CProjectManager.PLCTagS[cFirstHMITag.PLCTagKey].Channel,
                    cHMITag.Address, 1);

                if (CProjectManager.PLCTagS.ContainsKey(sPLCTagKey))
                {
                    CProjectManager.PLCTagS[sPLCTagKey].IsHMIMapping = true;

                    if(CProjectManager.PLCTagS[sPLCTagKey].PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) ||
                        CProjectManager.PLCTagS[sPLCTagKey].PLCMaker.Equals(EMPLCMaker.LS))
                        cHMITag.Description = CProjectManager.PLCTagS[sPLCTagKey].Description;
                    else
                        cHMITag.Description = CProjectManager.PLCTagS[sPLCTagKey].Name;

                    cHMITag.PLCTagKey = sPLCTagKey;
                }
                cHMITag.IsInsert = true;

                CProjectManager.UpdateMappingMessage(EMMappingMessage.Manual_Mapping, CProjectManager.PLCTagS[sPLCTagKey], cHMITag);
            }

            grdPLC.RefreshDataSource();
            grdHMI.RefreshDataSource();
        }

        private void CancelMappingHMI(bool bFirst, bool bMatch)
        {
            CHMITag cTag = null;
            int[] arrHMI = grvHMI.GetSelectedRows();

            for (int i = 0; i < arrHMI.Length; i++)
            {
                if (bFirst && i == 0)
                    continue;

                cTag = GetHMITag(arrHMI[i]);

                if (cTag == null)
                    continue;

                List<string> lstHMIKey = null;


                if (cTag.PLCTagKey != string.Empty)
                    lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.PLCTagKey);
                else
                    lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Address, cTag.Description);

                if (lstHMIKey.Count == 1 && CProjectManager.PLCTagS.ContainsKey(cTag.PLCTagKey))
                    CProjectManager.PLCTagS[cTag.PLCTagKey].IsHMIMapping = false;
                else if (lstHMIKey.Count == 2)
                {
                    foreach (string sKey in lstHMIKey)
                        CProjectManager.HMITagS[sKey].IsRedundancy = false;
                }

                if (!bMatch)
                {
                    cTag.Address = string.Empty;
                    cTag.Description = string.Empty;
                }
                cTag.PLCTagKey = string.Empty;
                cTag.IsExistedMatch = false;
                cTag.ClearPLCData();

                CProjectManager.UpdateMappingMessage(EMMappingMessage.Mapping_Cancel, null, cTag);
            }

            grdPLC.RefreshDataSource();
            grdHMI.RefreshDataSource();
            grdVerifHMI.RefreshDataSource();
        }

        private void CancelAllMappingHMI()
        {
            CHMITag cTag = null;
            int[] arrHMI = grvHMI.GetSelectedRows();

            for (int i = 0; i < arrHMI.Length; i++)
            {
                cTag = GetHMITag(arrHMI[i]);

                if (cTag == null)
                    continue;

                if (cTag.PLCTagKey == string.Empty)
                    continue;

                CProjectManager.PLCTagS[cTag.PLCTagKey].IsHMIMapping = false;
                List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.PLCTagKey);

                foreach (string sKey in lstHMIKey)
                {
                    cTag = CProjectManager.HMITagS[sKey];

                    cTag.Address = string.Empty;
                    cTag.Description = string.Empty;
                    cTag.PLCTagKey = string.Empty;
                    cTag.IsExistedMatch = false;
                    cTag.ClearPLCData();

                    CProjectManager.UpdateMappingMessage(EMMappingMessage.Mapping_Cancel, null, cTag);
                }
            }

            grdPLC.RefreshDataSource();
            grdHMI.RefreshDataSource();
        }

        private void ExportHMIFormat(bool bAll, string sPath, string sGroup)
        {
            DataTable DT = null;
            List<CHMITag> lstHMITag = null;

            if (bAll)
                lstHMITag = CProjectManager.HMITagS.Values.ToList();
            else
                lstHMITag = CProjectManager.HMITagS.Values.Where(x => x.Group == sGroup).ToList();

            DT = GetHMIFormatDataTable(lstHMITag);
            WriteCSV(sPath, DT);
        }

        private void WriteCSV(string sPath, DataTable DT)
        {
            try
            {
                FileStream fsOutput = new FileStream(sPath, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(1200));
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)

                        str.Append(string.Format("{0}\t", field));

                    str.Remove(str.Length - 1, 1);

                    str.Append("\r\n");

                }

                str.Remove(str.Length - 2, 2);
                srOutput.WriteLine(str.ToString());
                srOutput.Close();
                fsOutput.Close();

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private DataTable GetHMIFormatDataTable(List<CHMITag> lstTag)
        {
            DataTable DT = new DataTable();
            DataRow drRow = null;

            string sinfoRow1 = "# Tag Table Export";
            string sinfoRow2 = "# Do not edit the below 1 line. These lines contain important information.";
            string sinfoRow3 = "태그 *";

            string sColumn1 = "#번호";
            string sColumn2 = "그룹";
            string sColumn3 = "이름";
            string sColumn4 = "타입";
            string sColumn5 = "디바이스";
            string sColumn6 = "설명";
            string sColumn7 = "";

            DT.Columns.Add(sColumn1);
            DT.Columns.Add(sColumn2);
            DT.Columns.Add(sColumn3);
            DT.Columns.Add(sColumn4);
            DT.Columns.Add(sColumn5);
            DT.Columns.Add(sColumn6);
            DT.Columns.Add(sColumn7);

            drRow = DT.NewRow();
            drRow[0] = sinfoRow1;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sinfoRow2;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sinfoRow3;
            DT.Rows.Add(drRow);

            drRow = DT.NewRow();
            drRow[0] = sColumn1;
            drRow[1] = sColumn2;
            drRow[2] = sColumn3;
            drRow[3] = sColumn4;
            drRow[4] = sColumn5;
            drRow[5] = sColumn6;
            DT.Rows.Add(drRow);

            foreach (CHMITag cTag in lstTag)
            {
                drRow = DT.NewRow();
                drRow[0] = cTag.Number;
                drRow[1] = cTag.Group;
                drRow[2] = cTag.Name;
                drRow[3] = cTag.DataType;
                drRow[4] = cTag.Address;
                drRow[5] = cTag.Description;

                DT.Rows.Add(drRow);
            }

            return DT;
        }

        private void ExportHMITag(bool bAll, string sGroup)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = @"*.csv|*.csv";
            if (dlgSaveFile.ShowDialog() == DialogResult.Cancel)
                return;

            string sPath = dlgSaveFile.FileName;
            if (sPath == string.Empty)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ExportHMIFormat(bAll, sPath, sGroup);
            }
            SplashScreenManager.CloseForm(false);

            XtraMessageBox.Show("Export Success!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewMatchedPLC()
        {
            int[] arrHMI = grvHMI.GetSelectedRows();

            if (arrHMI == null || arrHMI.Length == 0)
                return;

            CHMITag cHMITag = GetHMITag(arrHMI[0]);

            if (cHMITag == null || cHMITag.PLCTagKey == string.Empty)
                return;

            if (grdPLC.DataSource == null)
                return;

            int iRowHandle = -1;
            string sTemp = string.Empty;

            for (int i = 0; i < CProjectManager.PLCTagS.Count; i++)
            {
                sTemp = grvPLC.GetRowCellDisplayText(i, "Key");

                if (sTemp == cHMITag.PLCTagKey)
                {
                    iRowHandle = i;
                    break;
                }
            }

            grvPLC.SelectRow(iRowHandle);
            grvPLC.FocusedRowHandle = iRowHandle;
        }

        private void ViewMappedHMIList()
        {
            if (CProjectManager.PLCTagS.Count == 0)
                return;

            int[] arrPLC = grvPLC.GetSelectedRows();

            if (arrPLC == null || arrPLC.Length == 0)
                return;

            CTag cTag = GetPLCTag(arrPLC[0]);

            if (cTag == null)
                return;

            List<string> lstMappedHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Key);

            if (lstMappedHMIKey.Count < 1)
                return;

            if (lstMappedHMIKey.Count == 1)
            {
                ViewMappedHMI(lstMappedHMIKey.First());
                return;
            }

            FrmRedundancyHMI frmView = new FrmRedundancyHMI();
            frmView.MappedHMIKeyList = lstMappedHMIKey;
            frmView.UHMIGridDoubleClickEvent += FrmRedundancy_HMIGridDoubleClick;
            frmView.Show();
        }

        private void ViewMappedHMI(string sHMIKey)
        {
            int iRowHandle = -1;
            string sTemp = string.Empty;

            for (int i = 0; i < CProjectManager.HMITagS.Count; i++)
            {
                sTemp = grvHMI.GetRowCellDisplayText(i, "Name");

                if (sTemp == sHMIKey)
                {
                    iRowHandle = i;
                    break;
                }
            }
            //grvHMI.GetRowCellDisplayText()

            //List<CHMITag> lstTag = (List<CHMITag>) grdHMI.DataSource;

            //for (int i = 0; i < lstTag.Count; i++)
            //{
            //    if (lstTag[i].Name == sHMIKey)
            //    {
            //        iRowHandle = i;
            //        break;
            //    }
            //}

            grvHMI.SelectRow(iRowHandle);
            grvHMI.FocusedRowHandle = iRowHandle;
        }

        private void CreateAutoMappingPLCTagS()
        {
            CVerifTagS cTagS = null;

            foreach (var who in CProjectManager.VerifTagS)
            {
                if (CProjectManager.AutoMappingPLCTagS.ContainsKey(who.Value.GroupKey))
                {
                    cTagS = CProjectManager.AutoMappingPLCTagS[who.Value.GroupKey];
                    cTagS.Add(who.Key, who.Value);
                }
                else
                {
                    cTagS = new CVerifTagS();
                    cTagS.Add(who.Key, who.Value);

                    CProjectManager.AutoMappingPLCTagS.Add(who.Value.GroupKey, cTagS);
                }
            }
        }

        private string GetPLCKeyToDescription(string sDescription)
        {
            string sPLCKey = string.Empty;

            foreach (var who in CProjectManager.PLCTagS)
            {
                if (who.Value.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || who.Value.PLCMaker.Equals(EMPLCMaker.LS))
                {
                    if (who.Value.Description == sDescription)
                    {
                        sPLCKey = who.Key;
                        break;
                    }
                }
                else
                {
                    if (who.Value.Name == sDescription)
                    {
                        sPLCKey = who.Key;
                        break;
                    }
                }
            }

            return sPLCKey;
        }

        private void AutoHMIMapping()
        {
            bool bOK = false;

            m_dMappingCount = 0;
            m_dTotalCount = 0;

            CProjectManager.AutoMappingPLCTagS.Clear();
            CreateAutoMappingPLCTagS();

            List<CHMITag> lstHMITag = CProjectManager.HMITagS.Values.Where(x => x.Group == m_sHMIGroup).ToList();
            m_dTotalCount = lstHMITag.Count;

            lstHMITag = lstHMITag.OrderBy(x => x.ConvertName).ToList();

            for (int i = 0; i < lstHMITag.Count; i++)
            {
                if (lstHMITag[i].IsExistedMatch)
                    continue;

                if (lstHMITag[i].Description != string.Empty)
                {
                    if (SetHMIDeviceContainDescription(lstHMITag[i]))
                    {
                        m_dMappingCount++;
                        continue;
                    }
                }

                if (lstHMITag[i].GroupKey == string.Empty)
                {
                    lstHMITag[i].ClearPLCData();
                    continue;
                }

                //if (lstHMITag[i].IsInsert && lstHMITag[i].Group.Contains("INTERLOCK"))
                //    i = SetInsertBitAutomatic(lstHMITag, i) - 1;
                //if (lstHMITag[i].ConvertNameParseS.Count < 3)
                //    continue;
                if (SetHMIDevice(lstHMITag[i]))
                    m_dMappingCount++;
                //else if (CProjectManager.HMITagS.IsContainConvertName(lstHMITag[i].ConvertName, lstHMITag[i].Name))
                //{
                //    if (SetSameConvertNameHMITag(lstHMITag[i]))
                //        m_dMappingCount++;
                //}
            }
        }

        private bool SetHMIDeviceContainDescription(CHMITag cHMITag)
        {
            bool bOK = false;

            string sKey = GetPLCKeyToDescription(cHMITag.Description);

            if (sKey != string.Empty && CProjectManager.PLCTagS[sKey].DataType == cHMITag.EMDataType)
            {
                bOK = true;

                List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(sKey);

                if (lstHMIKey.Count > 0)
                {
                    foreach (string sHMIKey in lstHMIKey)
                        CProjectManager.HMITagS[sHMIKey].IsRedundancy = true;

                    cHMITag.IsRedundancy = true;
                }

                cHMITag.IsMatch = true;
                cHMITag.PLCTagKey = sKey;
                cHMITag.Address = CProjectManager.PLCTagS[sKey].Address;

                CProjectManager.PLCTagS[sKey].IsHMIMapping = true;
            }

            return bOK;
        }

        private bool SetSameConvertNameHMITag(CHMITag cHMITag)
        {
            bool bOK = true;

            string sHMIKey = CProjectManager.HMITagS.GetSameConvertNameHMIKey(cHMITag.ConvertName, cHMITag.Name);
            string sPLCKey = CProjectManager.HMITagS[cHMITag.Name].PLCTagKey;

            if (sPLCKey == string.Empty)
            {
                cHMITag.ClearPLCData();
                return false;
            }

            cHMITag.IsRedundancy = true;

            CHMITag cSameHMITag = CProjectManager.HMITagS[sHMIKey];
            cSameHMITag.IsRedundancy = true;
            cSameHMITag.PLCTagKey = sPLCKey;
            cSameHMITag.Address = cHMITag.Address;
            cSameHMITag.IsMatch = true;
            cSameHMITag.Description = cHMITag.Description;

            CProjectManager.UpdateMappingMessage(EMMappingMessage.Manual_Mapping, CProjectManager.PLCTagS[sPLCKey], CProjectManager.HMITagS[sHMIKey]);

            return bOK;
        }

        private int SetInsertBitAutomatic(List<CHMITag> lstHMITag, int iStartIndex)
        {
            int iEndIndex = iStartIndex;
            bool bInput = lstHMITag[iStartIndex].IsHMIInput;
            int iUnderbarLastIndex = lstHMITag[iStartIndex].ConvertName.LastIndexOf("_");
            string sName = lstHMITag[iStartIndex].ConvertName.Substring(0, iUnderbarLastIndex);

            CHMITagS cInsertTagS = new CHMITagS();

            for (int i = iStartIndex; i < lstHMITag.Count; i++)
            {
                if (!lstHMITag[i].IsInsert || lstHMITag[i].IsHMIInput != bInput || !lstHMITag[i].ConvertName.Contains(sName))
                    break;

                cInsertTagS.Add(lstHMITag[i].Name, lstHMITag[i]);
                iEndIndex++;
            }

            MappingInsertBitAutomatic(cInsertTagS, bInput, sName);

            cInsertTagS.Dispose();
            cInsertTagS = null;

            return iEndIndex;
        }

        private void MappingInsertBitAutomatic(CHMITagS cInsertTagS, bool bInput, string sName)
        {
            int iInsertCount = cInsertTagS.Count;

            CVerifTag cFirstPLCTag = GetFirstInsertTag(bInput, sName);

            if (cFirstPLCTag == null)
            {
                foreach (var who in cInsertTagS)
                    who.Value.ClearPLCData();

                return;
            }

            SetHMIInsertIndex(bInput, sName, cInsertTagS.ElementAt(0).Value.GroupKey);

            string sHexaValue = string.Empty;
            int iHexaValue = -1;
            int iCurrentValue = -1;
            string sKey = string.Empty;

            if (bInput)
                sHexaValue = cFirstPLCTag.Address.Replace("X", "");
            else
                sHexaValue = cFirstPLCTag.Address.Replace("Y", "");

            iHexaValue = Convert.ToInt32(sHexaValue, 16);

            CHMITag cHMITag = null;

            for (int i = 0; i < iInsertCount; i++)
            {
                cHMITag = cInsertTagS.ElementAt(i).Value;

                iCurrentValue = iHexaValue + cHMITag.HMIIndex;

                if (bInput)
                    sKey = string.Format("[{0}]X{1}[1]", cFirstPLCTag.Channel, iCurrentValue.ToString("X"));
                else
                    sKey = string.Format("[{0}]Y{1}[1]", cFirstPLCTag.Channel, iCurrentValue.ToString("X"));

                if (CProjectManager.PLCTagS.ContainsKey(sKey))
                {
                    if(cHMITag.EMDataType != CProjectManager.PLCTagS[sKey].DataType)
                        cHMITag.ClearPLCData();

                    if (CProjectManager.HMITagS.CheckPLCTagMapping(sKey))
                    {
                        List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(sKey);

                        foreach (string sHMIKey in lstHMIKey)
                            CProjectManager.HMITagS[sHMIKey].IsRedundancy = true;

                        cHMITag.IsRedundancy = true;
                    }

                    cHMITag.PLCTagKey = sKey;
                    cHMITag.Description = CProjectManager.PLCTagS[sKey].Description;
                    cHMITag.Address = CProjectManager.PLCTagS[sKey].Address;

                    if (cHMITag.IsEmpty)
                        cHMITag.IsEmpty = false;

                    CProjectManager.PLCTagS[sKey].IsHMIMapping = true;

                    m_dMappingCount++;
                }
                else
                    cHMITag.ClearPLCData();
            }
        }

        private void SetHMIInsertIndex(bool bInput, string sName, string sGroupKey)
        {
            List<CHMITag> lstTag =
                CProjectManager.HMITagS.Values.Where(x => x.ConvertName.Contains(sName)).Where(x => x.Group.Contains("INTERLOCK")).ToList();

            lstTag = lstTag.OrderBy(x => x.ConvertName).ToList();

            List<string> lstConvertName = new List<string>();
            int iIndex = 0;

            foreach (var who in lstTag)
            {
                if (who.GroupKey != sGroupKey)
                    continue;

                if (lstConvertName.Contains(who.ConvertName))
                    continue;

                lstConvertName.Add(who.ConvertName);

                if (bInput)
                {
                    if (Regex.IsMatch(who.ConvertName, "I[0-9][0-9][0-9]"))
                        who.HMIIndex = iIndex++;
                }
                else
                {
                    if (Regex.IsMatch(who.ConvertName, "O[0-9][0-9][0-9]"))
                        who.HMIIndex = iIndex++;
                }
            }
        }

        private CVerifTag GetFirstInsertTag(bool bInput, string sName)
        {
            CVerifTag cFirstTag = null;

            List<string> lstDesc = sName.Split('_').ToList();

            SetInputOutputDescription(lstDesc, bInput);

            foreach (var who in CProjectManager.VerifTagS.Values.OrderBy(x => x.Address))
            {
                if (!CProjectManager.PLCTagS.ContainsKey(who.Key))
                    continue;

                if (CProjectManager.PLCTagS[who.Key].DataType != EMDataType.Bool)
                    continue;

                if (bInput && !who.Address.StartsWith("X"))
                    continue;
                else if (!bInput && !who.Address.StartsWith("Y"))
                    continue;

                if (who.IsDescContain(lstDesc, true))
                {
                    cFirstTag = who;
                    break;
                }
            }

            return cFirstTag;
        }

        private void SetInputOutputDescription(List<string> lstDesc, bool bInput)
        {
            if (CProjectManager.PLCTagS[0].PLCMaker == EMPLCMaker.Siemens)
            {
                if (bInput)
                    lstDesc.Add("O");
                else
                    lstDesc.Add("I");
            }
            else if (CProjectManager.PLCTagS[0].PLCMaker.ToString().Contains("Mitsubishi"))
            {
                if (bInput)
                    lstDesc.Add("X");
                else
                    lstDesc.Add("Y");
            }
        }

        private bool SetHMIDevice(CHMITag cHMITag)
        {
            bool bOK = false;
            int iMappingCount = 0;

            string sGroupKey = cHMITag.GroupKey;

            if (!CProjectManager.AutoMappingPLCTagS.ContainsKey(sGroupKey))
                return false;

            CVerifTagS cTagS = CProjectManager.AutoMappingPLCTagS[sGroupKey];
            CVerifTag cTag = null;

            foreach (var who in cTagS)
            {
                if (!CheckHMITag(who.Value, cHMITag))
                    continue;

                if (who.Value.IsDescContain(cHMITag.ConvertNameParseS, false))
                {
                    iMappingCount++;
                    cTag = who.Value;
                }

                if (iMappingCount >= 2)
                {
                    bOK = false;
                    break;
                }
            }

            if (iMappingCount == 1 && cTag != null)
            {
                bOK = true;

                if (CProjectManager.HMITagS.CheckPLCTagMapping(cTag.Key))
                {
                    List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(cTag.Key);

                    if (lstHMIKey.Count < 2)
                    {
                        foreach (string sKey in lstHMIKey)
                            CProjectManager.HMITagS[sKey].IsRedundancy = true;

                        cHMITag.IsRedundancy = true;
                    }
                    else
                    {
                        foreach (string sKey in lstHMIKey)
                            CProjectManager.HMITagS[sKey].ClearPLCData();

                        cHMITag.ClearPLCData();
                        CProjectManager.PLCTagS[cTag.Key].IsHMIMapping = false;
                    }
                }

                cHMITag.PLCTagKey = cTag.Key;
                cHMITag.Address = cTag.Address;

                if(cTag.PLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer) || cTag.PLCMaker.Equals(EMPLCMaker.LS))
                    cHMITag.Description = cTag.Description;
                else
                    cHMITag.Description = cTag.Name;

                CProjectManager.PLCTagS[cTag.Key].IsHMIMapping = true;
                cHMITag.IsMatch = true;
            }
            return bOK;
        }

        private void ConvertSelectedHMITagDescription(CHMITag cHMITag)
        {
            if (cHMITag.Name.Contains("]"))
                cHMITag.ConvertName = cHMITag.Name.Split(']')[1];

            foreach (CConvertUnit cUnit in CProjectManager.GroupConvertUnitS[cHMITag.Group])
            {
                bool bRegex = false;

                if (cUnit.Current.Contains("#"))
                {
                    cUnit.ConvertCurrent = cUnit.Current.Replace("#", "[0-9]");
                    bRegex = true;
                }

                if (!cHMITag.Name.Contains("]"))
                    continue;

                if (!bRegex)
                {
                    if (cHMITag.ConvertName.Contains(cUnit.Current))
                        cHMITag.ConvertName = cHMITag.ConvertName.Replace(cUnit.Current, cUnit.Target);
                }
                else
                {
                    Match regex = Regex.Match(cHMITag.ConvertName, cUnit.ConvertCurrent);
                    if (regex.Success)
                    {
                        string sValue = regex.Value;

                        int iCurrentNumericDigit = cUnit.Current.Where(x => x.Equals('#')).Count();

                        int iStartIndex = cUnit.Current.IndexOf("#");

                        string sNumeric = sValue.Substring(iStartIndex, iCurrentNumericDigit);

                        int iTargetNumericDigit = cUnit.Target.Where(x => x.Equals('#')).Count();

                        cUnit.ConvertTarget = cUnit.Target;
                        int iTargetIndex = cUnit.ConvertTarget.LastIndexOf("#");

                        for (int i = 0; i < iTargetNumericDigit; i++)
                        {
                            cUnit.ConvertTarget = cUnit.ConvertTarget.Remove(iTargetIndex, 1);
                            cUnit.ConvertTarget = cUnit.ConvertTarget.Insert(iTargetIndex, sNumeric[sNumeric.Length - (1 + i)].ToString());

                            iTargetIndex = cUnit.ConvertTarget.LastIndexOf("#");
                        }

                        cHMITag.ConvertName = Regex.Replace(cHMITag.ConvertName, cUnit.ConvertCurrent, cUnit.ConvertTarget);
                    }
                }

                if (cHMITag.ConvertName != string.Empty)
                {
                    if (cHMITag.Name.Contains("]"))
                        cHMITag.GroupKey = GetGroupKey(cHMITag.ConvertName);
                }

            }

            if (cHMITag.PLCTagKey != string.Empty && !cHMITag.IsExistedMatch)
            {
                if (CProjectManager.PLCTagS.ContainsKey(cHMITag.PLCTagKey))
                {
                    List<string> lstKey = CProjectManager.HMITagS.GetHMITagKey(cHMITag.PLCTagKey);

                    if (lstKey.Count <= 1)
                        CProjectManager.PLCTagS[cHMITag.PLCTagKey].IsHMIMapping = false;
                    else if (lstKey.Count == 2)
                    {
                        foreach (string sKey in lstKey)
                            CProjectManager.HMITagS[sKey].IsRedundancy = false;
                    }

                    cHMITag.PLCTagKey = string.Empty;
                }
            }

            cHMITag.ClearPLCData();

            if (cHMITag.Name.Contains("-R-IN"))
                cHMITag.IsHMIInput = true;
            else if (cHMITag.Name.Contains("-R-OUT"))
                cHMITag.IsHMIOutput = true;

            cHMITag.ConvertNameParseS.Clear();
            cHMITag.ConvertNameParseS.AddRange(cHMITag.ConvertName.Split('_').ToList());

            if (Regex.IsMatch(cHMITag.ConvertNameParseS.Last(), "I[0-9][0-9][0-9]") && cHMITag.Group.Contains("INTERLOCK"))
                cHMITag.IsHMIInput = true;
            else if (Regex.IsMatch(cHMITag.ConvertNameParseS.Last(), "O[0-9][0-9][0-9]") && cHMITag.Group.Contains("INTERLOCK"))
                cHMITag.IsHMIOutput = true;
        }

        private CTagS GetRecommendPLCTagS(CHMITag cHMITag)
        {
            CTagS cTagS = new CTagS();
            ConvertSelectedHMITagDescription(cHMITag);

            string sGroupKey = cHMITag.GroupKey;

            CProjectManager.AutoMappingPLCTagS.Clear();
            CreateAutoMappingPLCTagS();

            if (!CProjectManager.AutoMappingPLCTagS.ContainsKey(sGroupKey))
                return cTagS;

            CVerifTagS cVerifTagS = CProjectManager.AutoMappingPLCTagS[sGroupKey];
            CVerifTag cTag = null;

            foreach (var who in cVerifTagS)
            {
                if (!CheckHMITag(who.Value, cHMITag))
                    continue;

                if (who.Value.IsDescContain(cHMITag.ConvertNameParseS, false))
                {
                    if(!cTagS.ContainsKey(who.Key))
                        cTagS.Add(who.Key, CProjectManager.PLCTagS[who.Key]);
                }
            }

            return cTagS;
        }

        private bool CheckHMITag(CVerifTag cTag, CHMITag cHMITag)
        {
            bool bOK = true;

            if (cHMITag.IsHMIOutput)
            {
                if (!cTag.Address.StartsWith("Y"))
                    return false;
            }
            else if (cHMITag.IsHMIInput)
            {
                if (!cTag.Address.StartsWith("X"))
                    return false;
            }

            if (CProjectManager.PLCTagS[cTag.Key].DataType != cHMITag.EMDataType)
                return false;

            return bOK;
        }

        private void ConvertHMIDesc()
        {
            foreach (var who in CProjectManager.HMITagS)
            {
                if(who.Value.Name.Contains("]"))
                    who.Value.ConvertName = who.Value.Name.Split(']')[1];
            }

            foreach (CConvertUnit cUnit in CProjectManager.GroupConvertUnitS[m_sHMIGroup])
            {
                bool bRegex = false;

                if (cUnit.Current.Contains("#"))
                {
                    cUnit.ConvertCurrent = cUnit.Current.Replace("#", "[0-9]");
                    bRegex = true;
                }
                SetHMIDesc(cUnit, bRegex);
            }
        }

        private void SetHMIDesc()
        {
            foreach (var who in CProjectManager.HMITagS)
            {
                if (who.Value.Group != m_sHMIGroup)
                    continue;

                if (who.Value.PLCTagKey != string.Empty && !who.Value.IsExistedMatch)
                {
                    if (CProjectManager.PLCTagS.ContainsKey(who.Value.PLCTagKey))
                    {
                        List<string> lstKey = CProjectManager.HMITagS.GetHMITagKey(who.Value.PLCTagKey);

                        if (lstKey.Count <= 1)
                            CProjectManager.PLCTagS[who.Value.PLCTagKey].IsHMIMapping = false;
                        else if (lstKey.Count == 2)
                        {
                            foreach (string sKey in lstKey)
                                CProjectManager.HMITagS[sKey].IsRedundancy = false;
                        }

                        who.Value.PLCTagKey = string.Empty;
                    }
                }

                who.Value.ClearPLCData();

                if (who.Value.Name.Contains("-R-IN"))
                    who.Value.IsHMIInput = true;
                else if (who.Value.Name.Contains("-R-OUT"))
                    who.Value.IsHMIOutput = true;

                who.Value.ConvertNameParseS.Clear();
                who.Value.ConvertNameParseS.AddRange(who.Value.ConvertName.Split('_').ToList());

                if (Regex.IsMatch(who.Value.ConvertNameParseS.Last(), "I[0-9][0-9][0-9]") && who.Value.Group.Contains("INTERLOCK"))
                {
                    //who.Value.IsInsert = true;
                    who.Value.IsHMIInput = true;
                }
                else if (Regex.IsMatch(who.Value.ConvertNameParseS.Last(), "O[0-9][0-9][0-9]") && who.Value.Group.Contains("INTERLOCK"))
                {
                    //who.Value.IsInsert = true;
                    who.Value.IsHMIOutput = true;
                }
            }
        }

        private void SetHMIDesc(CConvertUnit cUnit, bool bRegex)
        {
            try
            {
                foreach (var who in CProjectManager.HMITagS)
                {
                    if (!who.Value.Name.Contains("]"))
                        continue;

                    if (!bRegex)
                    {
                        if (who.Value.ConvertName.Contains(cUnit.Current))
                            who.Value.ConvertName = who.Value.ConvertName.Replace(cUnit.Current, cUnit.Target);
                    }
                    else
                    {
                        Match regex = Regex.Match(who.Value.ConvertName, cUnit.ConvertCurrent);
                        if (regex.Success)
                        {
                            string sValue = regex.Value;

                            int iCurrentNumericDigit = cUnit.Current.Where(x => x.Equals('#')).Count();

                            int iStartIndex = cUnit.Current.IndexOf("#");

                            string sNumeric = sValue.Substring(iStartIndex, iCurrentNumericDigit);

                            int iTargetNumericDigit = cUnit.Target.Where(x => x.Equals('#')).Count();

                            cUnit.ConvertTarget = cUnit.Target;
                            int iTargetIndex = cUnit.ConvertTarget.LastIndexOf("#");

                            for (int i = 0; i < iTargetNumericDigit; i++)
                            {
                                cUnit.ConvertTarget = cUnit.ConvertTarget.Remove(iTargetIndex, 1);
                                cUnit.ConvertTarget = cUnit.ConvertTarget.Insert(iTargetIndex, sNumeric[sNumeric.Length - (1 + i) ].ToString());

                                iTargetIndex = cUnit.ConvertTarget.LastIndexOf("#");
                            }

                            who.Value.ConvertName = Regex.Replace(who.Value.ConvertName, cUnit.ConvertCurrent, cUnit.ConvertTarget);
                        }
                    }

                    if (who.Value.ConvertName != string.Empty)
                    {
                        if(who.Value.Name.Contains("]"))
                            who.Value.GroupKey = GetGroupKey(who.Value.ConvertName);
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMI Auto Mapping", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private string GetGroupKey(string sDescription)
        {
            string sGroupKey = string.Empty;

            if (sDescription.StartsWith("_"))
                return sGroupKey;

            sGroupKey = sDescription.Split('_')[0];

            if (sGroupKey.Contains("-"))
                sGroupKey = sGroupKey.Split('-')[0];

            return sGroupKey;
        }

        private void SetConvertName()
        {
            foreach (var who in CProjectManager.HMITagS)
            {
                if (who.Value.Name.Contains("]"))
                    who.Value.ConvertName = who.Value.Name.Split(']')[1];
            }
        }


        #endregion

        private void FrmRedundancy_HMIGridDoubleClick(string sHMIKey)
        {
            try
            {
                ViewMappedHMI(sHMIKey);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Redundancy HMi Grid DoubleClick Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOpenPLC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;
                string sChannel = string.Empty;
                sChannel = GetUserInputText("Input PLC Name", "Please enter text below...", true);

                if (sChannel == string.Empty)
                {
                    XtraMessageBox.Show("PLC Name is Empty!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CProjectManager.LogicDataS.ContainsKey(sChannel))
                {
                    XtraMessageBox.Show("Already Exist PLC Name!!", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = ImportPLC(sChannel);

                    if (!bOK)
                    {
                        SplashScreenManager.CloseForm(false);
                        return;
                    }

                    ShowPLCGrid();
                    ShowVerificationGrid();

                    CProjectManager.UpdateSystemMessage("Mapping", "PLC Open OK");
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Open PLC Logic Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOpenHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    bOK = ImportHMI();
                    CProjectManager.UpdateSystemMessage("Mapping", "HMI Open OK");
                }
                SplashScreenManager.CloseForm(false);

                if (bOK && CProjectManager.HMITagS.Count != 0)
                {
                    if (pgHMIMapping.Visible)
                    {
                        if (XtraMessageBox.Show(
                            "새로운 HMI 태그 파일을 Import 하셨습니다.\r\n 해당 HMI 태그에 매핑되어 있는 PLC에 대한 매핑을 확인하시겠습니까?",
                            "PLC 매핑 체크", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            FrmMappingChecker frmChecker = new FrmMappingChecker();
                            frmChecker.ShowDialog();

                            frmChecker.Dispose();
                            frmChecker = null;
                        }
                    }

                    ShowHMIGrid();
                    ShowPartialHMIExport();
                    SetHMIGroupConvertUnitS();
                    ShowHMIVerifGrid();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Open HMI Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClearPLC_Click(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show("Are you sure to clear All PLC Information?", "Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ClearPLC();
                CProjectManager.UpdateSystemMessage("Mapping", "Clear PLC OK");
            }
            else
                return;
        }

        private void chkPLCEditable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridColumn Column;
                foreach (var who in grvPLC.Columns)
                {
                    Column = (GridColumn)who;

                    if (Column.FieldName == "IsHMIMapping")
                        continue;

                    Column.OptionsColumn.AllowEdit = chkPLCEditable.Checked;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("PLC Editable Check Box", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void chkHMIEditable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridColumn Column;
                foreach (var who in grvHMI.Columns)
                {
                    Column = (GridColumn)who;

                    if (Column.FieldName == "DataType")
                        continue;

                    Column.OptionsColumn.AllowEdit = chkHMIEditable.Checked;
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("HMI Editable Check Box", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void btnAllHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CheckHMI())
                    ExportHMITag(true, string.Empty);
                else
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export All HMI Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void cboSectionExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string sGroup = string.Empty;

                sGroup = (string) cboSectionExport.EditValue;

                if (sGroup == null || sGroup == "Choice a Group..")
                    return;

                if (!m_lstHMIGroup.Contains(sGroup))
                {
                    XtraMessageBox.Show("Export하고자 하는 Group을 선택하세요.", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                ExportHMITag(false, sGroup);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export Group Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                grdHMI.RefreshDataSource();

                foreach (var who in CProjectManager.HMITagS)
                {
                    if (!m_lstHMIGroup.Contains(who.Value.Group))
                        m_lstHMIGroup.Add(who.Value.Group);
                }

                ShowPartialHMIExport();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export HMI DropDown Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClearHMI_Click(object sender, EventArgs e)
        {
            if (
                XtraMessageBox.Show("Are you sure to clear All HMI Tag Information?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                ClearHMI();
            else
                return;
        }

        private void grdPLC_DoubleClick(object sender, EventArgs e)
        {

        }

        private void grvPLC_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                bool bOK = false;
                var View = sender as GridView;
                if (e.Column.FieldName == "IsHMIMapping")
                {
                    var category = View.GetRowCellValue(e.RowHandle, View.Columns["IsHMIMapping"]);

                    if (category != null)
                        bOK = (bool) category;

                    if (bOK)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.Salmon;
                        e.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvPLC RowCellStyle Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvPLC_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvHMI_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void grvHMI_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                var View = sender as GridView;
                bool bOK = false;


                if (e.Column.FieldName == "Address")
                {
                    //string sDevice = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Address"]);
                    //if (sDevice.StartsWith("HX") || sDevice.StartsWith("HW"))
                    //{
                    //    e.Appearance.BackColor = System.Drawing.Color.FromArgb(229, 224, 236);
                    //    e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(204, 193, 217);
                    //}

                    //e.Appearance.ForeColor = Color.Black;

                    object obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsRedundancy"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK && e.Appearance.BackColor != Color.Silver)
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.BackColor2 = Color.OrangeRed;
                        e.Appearance.ForeColor = Color.White;
                        return;
                    }

                    bOK = false;
                    obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsExistedMatch"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK && e.Appearance.BackColor != Color.Silver)
                    {
                        e.Appearance.BackColor = Color.Thistle;
                        e.Appearance.BackColor2 = Color.Thistle;
                        return;
                    }

                    if (!CProjectManager.IsOptionApply)
                        return;

                    bOK = false;
                    obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsMatch"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK && e.Appearance.BackColor != Color.Silver)
                    {
                        e.Appearance.BackColor = (Color) cboMappingColor.EditValue;
                        e.Appearance.BackColor2 = (Color) cboMappingColor.EditValue;
                        return;
                    }

                    bOK = false;
                    obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsInsert"]);

                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK && e.Appearance.BackColor != Color.Silver)
                    {
                        e.Appearance.BackColor = (Color) cboInsert.EditValue;
                        e.Appearance.BackColor2 = (Color) cboInsert.EditValue;
                        return;
                    }

                    bOK = false;
                    obj = View.GetRowCellValue(e.RowHandle, View.Columns["IsEdit"]);
                    if (obj != null)
                        bOK = (bool) obj;

                    if (bOK && e.Appearance.BackColor != Color.Silver)
                    {
                        e.Appearance.BackColor = (Color) cboConvert.EditValue;
                        e.Appearance.BackColor2 = (Color) cboConvert.EditValue;
                        return;
                    }
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvHMI RowCellStyle Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvHMI_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                ////grvHMI.FocusedColumn.BestFit();
                //ViewMatchedPLC();
                //SplashScreenManager.CloseForm(false);

            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grdHMI Best Fit Exception", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void grvHMI_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuMappingHMI.ShowPopup(CurrentPoint);
                }
                else if (e.Button == MouseButtons.Left)
                {
                    int iSelectedHMI = grvHMI.GetSelectedRows().Length;
                    txtHMIRowCount.Text = iSelectedHMI.ToString();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvHMI Mouse Up Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnConnectHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MappingPLCtoHMI(EMMappingType.Match);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Connect HMI Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnConnectDataType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MappingPLCtoHMI(EMMappingType.Convert);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("ConnectDataType Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnInputHMIBit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MappingPLCtoHMI(EMMappingType.Insert);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("InputHmiBit Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMappingCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (
                    XtraMessageBox.Show("해당 HMI Tag의 연결을 해제하시겠습니까?", "연결 해제", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    CancelMappingHMI(false, false);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Cancel Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAllMappingCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (
                    XtraMessageBox.Show("중복된 모든 연결을 해제하시겠습니까?", "연결 해제", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    CancelAllMappingHMI();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("All Mapping Cancel Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvPLC_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    int iSelectedPLC = grvPLC.GetSelectedRows().Length;
                    txtPLCRowCount.Text = iSelectedPLC.ToString();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                    mnuMappingPLC.ShowPopup(CurrentPoint);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvPLC_MouseUp Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvHMI_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F5)
                    btnConnectHMI_ItemClick(null, null);
                else if (e.KeyData == Keys.F6)
                    btnMappingCancel_ItemClick(null, null);
                else if (e.KeyData == Keys.F7)
                    btnAllMappingCancel_ItemClick(null, null);
                else if (e.KeyData == Keys.F8)
                    btnInputHMIBit_ItemClick(null, null);
                else if (e.KeyData == Keys.F9)
                    btnGroupAutoMapping_ItemClick(null, null);
                else if (e.KeyData == Keys.Tab)
                    grdPLC.Focus();
                else if (e.KeyData == Keys.F10)
                {
                    grdPLC.Focus();
                    btnCheckConnectPLC_ItemClick(null, null);
                }
                else if (e.KeyData == Keys.F12)
                    btnRecommend_ItemClick(null, null);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvHMI keyDown Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvPLC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Tab)
                    grdHMI.Focus();
                else if (e.KeyData == Keys.F5)
                    btnConnectHMI_ItemClick(null, null);
                else if (e.KeyData == Keys.F11)
                    btnConnectHMITag_ItemClick(null, null);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvPLC KeyDown Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkOptionApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CProjectManager.IsOptionApply = chkOptionApply.Down;
            grdHMI.RefreshDataSource();
        }

        private void btnAutoMapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_lstHMIGroup.Count == 0)
                {
                    foreach (var who in CProjectManager.HMITagS)
                    {
                        if (!m_lstHMIGroup.Contains(who.Value.Group))
                            m_lstHMIGroup.Add(who.Value.Group);
                    }
                }

                FrmMappingOption frmMappingOption = new FrmMappingOption();
                frmMappingOption.HMIGroupS = m_lstHMIGroup;
                frmMappingOption.IsOptionSetting = true;
                frmMappingOption.TopMost = true;
                frmMappingOption.Show();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("AutoMapping Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnGroupAutoMapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvHMI.FocusedRowHandle;
                object obj = grvHMI.GetRow(iRowHandle);

                if (obj == null)
                    return;

                if (obj.GetType() != typeof (CHMITag))
                    return;

                CHMITag cHMITag = (CHMITag) obj;
                m_sHMIGroup = cHMITag.Group;

                FrmMappingOption frmOption = new FrmMappingOption();
                frmOption.UEventAutoMappingOK += frmAutoMappingOption_OKButtonClick;
                frmOption.HMIGroupS = m_lstHMIGroup;
                frmOption.SelectedGroup = m_sHMIGroup;
                frmOption.IsOptionSetting = false;
                frmOption.TopMost = true;
                frmOption.Show();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Group Auto Mapping Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void frmAutoMappingOption_OKButtonClick()
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    ConvertHMIDesc();
                    SetHMIDesc();
                    AutoHMIMapping();
                }
                SplashScreenManager.CloseForm(false);
                string sMessage = string.Format("PLC-HMI 자동 매핑 진행 완료!!\r\nMapping Percentage : {0} %",
                    Math.Round((m_dMappingCount*100)/m_dTotalCount), 2);

                XtraMessageBox.Show(sMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                grdHMI.RefreshDataSource();
                grdPLC.RefreshDataSource();
                grdVerifHMI.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Option OK Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCheckConnectPLC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ViewMatchedPLC();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grdHMI Check Connect PLC Exception", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void btnConnectHMITag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ViewMappedHMIList();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grdPLC Check Connect HMI Exception", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        private void grvHMI_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (!chkHMIEditable.Checked)
                    return;

                int iRowHandle = grvHMI.FocusedRowHandle;
                object obj = grvHMI.GetRow(iRowHandle);

                if (obj.GetType() != typeof (CHMITag))
                    return;

                CHMITag cHMITag = (CHMITag) obj;

                string sPLCKey = cHMITag.PLCTagKey;

                if (sPLCKey != string.Empty)
                {
                    List<string> lstHMIKey = CProjectManager.HMITagS.GetHMITagKey(sPLCKey);

                    if (lstHMIKey.Count == 2)
                    {
                        foreach (string sKey in lstHMIKey)
                            CProjectManager.HMITagS[sKey].IsRedundancy = false;
                    }
                }

                cHMITag.PLCTagKey = string.Empty;
                cHMITag.ClearPLCData();
                cHMITag.IsEdit = true;

                grdHMI.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvHMI CellValueChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvPLC_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int iSelectedPLC = grvPLC.GetSelectedRows().Length;
                txtPLCRowCount.Text = iSelectedPLC.ToString();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvPLC_KeyUp Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grvHMI_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int iSelectedHMI = grvHMI.GetSelectedRows().Length;
                txtHMIRowCount.Text = iSelectedHMI.ToString();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("grvHMI KeyUp Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnMappingCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmMappingChecker frmChecker = new FrmMappingChecker();
                frmChecker.ShowDialog();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Mapping Check Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRecommend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckHMI())
                {
                    XtraMessageBox.Show("Import HMI Tag First!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvHMI.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                CHMITag cHMITag = (CHMITag) grvHMI.GetRow(iRowHandle);

                if (cHMITag.PLCTagKey != string.Empty)
                {
                    XtraMessageBox.Show("이미 PLC 태그가 매핑되어 있습니다.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                CTagS cTagS = null;

                SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                {
                    cTagS = GetRecommendPLCTagS(cHMITag);
                }
                SplashScreenManager.CloseForm();

                FrmMappingRecommend frmView = new FrmMappingRecommend();
                frmView.HMITag = cHMITag;
                frmView.TagS = cTagS;

                if (frmView.ShowDialog() == DialogResult.OK)
                {
                    grdPLC.RefreshDataSource();
                    grdHMI.RefreshDataSource();
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Recommend Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportErrorList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!CheckPLC())
                {
                    XtraMessageBox.Show("Import PLC First!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmErrorListProperty frmErrorProperty = new FrmErrorListProperty();
                frmErrorProperty.TopMost = true;
                frmErrorProperty.Show();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Export Error List Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void grdHMI_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    if (!chkHMIEditable.Checked)
                        return;

                    IDataObject obj = Clipboard.GetDataObject();
                    if (obj == null)
                        return;

                    if (!obj.GetDataPresent(DataFormats.Text))
                        return;

                    string sData = (string) obj.GetData(DataFormats.Text);
                    string[] arrData = sData.Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

                    if (arrData.Length < 1)
                        return;

                    int iStartRowHandle = grvHMI.FocusedRowHandle;
                    int iColumnIndex = grvHMI.FocusedColumn.VisibleIndex;
                    if (iStartRowHandle < 0)
                        return;

                    foreach (string sRow in arrData)
                    {
                        CHMITag cTag = (CHMITag) grvHMI.GetRow(iStartRowHandle);
                        if (cTag == null)
                            continue;

                        cTag.IsEdit = true;

                        grvHMI.SetRowCellValue(iStartRowHandle++, grvHMI.VisibleColumns[iColumnIndex], sRow);
                        if (!grvHMI.IsValidRowHandle(iStartRowHandle))
                            break;
                    }

                    grdHMI.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("붙여넣기 에러", ex.Message);
                ex.Data.Clear();
            }
        }


    }
}
