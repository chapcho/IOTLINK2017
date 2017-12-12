using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Import.Xls;
using UDM.Common;
using UDM.Export;
using UDM.UDLImport;
using UDM.UI;
using UDM.General.Csv;

namespace UDMIOMaker
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private eExcelListType m_emExcelListType = eExcelListType.ALL;
        private BackgroundWorker m_backgroundWorker = null;
        private CExport m_cExport = new CExport();
        private bool m_bExport = false;

        private bool m_bFirst = false;

        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods



        #endregion 

        #region Private Methods

        private void InitScreen()
        {
            SetSpliterLocation();

            tabMain.ShowTabHeader = DefaultBoolean.False;
            //tabHelp.ShowTabHeader = DefaultBoolean.False;

            cboMappingColor.EditValue = Color.FromArgb(192, 192, 255);
            cboInsert.EditValue = Color.FromArgb(253, 234, 218);
            cboConvert.EditValue = Color.FromArgb(235, 241, 221);

            if (CProjectManager.Project.FactoryName != string.Empty)
                txtFactory.EditValue = CProjectManager.Project.FactoryName;
            else
                txtFactory.EditValue = null;

            if (CProjectManager.Project.LineName != string.Empty)
                txtLine.EditValue = CProjectManager.Project.LineName;
            else
                txtLine.EditValue = null;

            if (CProjectManager.Project.FactoryName != string.Empty && CProjectManager.Project.LineName != string.Empty)
            {
                mnuPLC.Enabled = true;
                mnuHMI.Enabled = true;
                mnuMappingOption.Enabled = true;
                mnuStandardPLC.Enabled = true;
                mnuDesignPLC.Enabled = true;
                mnuStandardization.Enabled = true;
                mnuPLCVerification.Enabled = true;
                mnuExport.Enabled = true;
                mnuHMIVerification.Enabled = true;
                mnuDefHMIVerif.Enabled = true;
                mnuHMIExit.Enabled = true;
            }
            else
            {
                mnuPLC.Enabled = false;
                mnuHMI.Enabled = false;
                mnuMappingOption.Enabled = false;
                mnuStandardPLC.Enabled = false;
                mnuDesignPLC.Enabled = false;
                mnuStandardization.Enabled = false;
                mnuPLCVerification.Enabled = false;
                mnuExport.Enabled = false;
                mnuHMIVerification.Enabled = false;
                mnuDefHMIVerif.Enabled = false;
                mnuHMIExit.Enabled = false;
            }
        }

        private void SetSpliterLocation()
        {
            sptMain.SplitterPosition = sptMain.Width / 2;
            sptVerification.SplitterPosition = sptVerification.Width / 2;
            sptHMIVerification.SplitterPosition = sptHMIVerification.Width / 2;
        }

        private void InitErrorListFilter()
        {
            if (CProjectManager.ErrorFilterS.Count != 0)
                return;

            CErrorFilter cFilter = new CErrorFilter();
            cFilter.SheetName = "일반 이상 신호";
            cFilter.ErrorFilter.Add("이상");
            cFilter.ErrorFilter.Add("NG");
            cFilter.ErrorFilter.Add("에러");
            cFilter.ErrorFilter.Add("FAULT");
            cFilter.ErrorFilter.Add("Fault");
            cFilter.ErrorFilter.Add("ABNORMAL");
            cFilter.ErrorFilter.Add("Abnormal");
            cFilter.ErrorFilter.Add("Error");
            cFilter.ErrorFilter.Add("ERROR");
            cFilter.ErrorFilter.Add("Err");
            cFilter.ErrorFilter.Add("ERR");
            cFilter.ErrorFilter.Add("Warning");
            cFilter.ErrorFilter.Add("WARNING");
            cFilter.ErrorFilter.Add("Alarm");
            cFilter.ErrorFilter.Add("ALARM");

            cFilter.ErrorNotContainFilter.Add("RUNNING");

            CProjectManager.ErrorFilterS.Add(cFilter.SheetName, cFilter);

            cFilter = new CErrorFilter();
            cFilter.SheetName = "비상 정지";
            cFilter.ErrorFilter.Add("비상정지");
            cFilter.ErrorFilter.Add("비상_정지");
            cFilter.ErrorFilter.Add("안전");
            cFilter.ErrorFilter.Add("OFF");
            cFilter.ErrorFilter.Add("Off");
            CProjectManager.ErrorFilterS.Add(cFilter.SheetName, cFilter);

            cFilter = new CErrorFilter();
            cFilter.SheetName = "Over Run";
            cFilter.ErrorFilter.Add("OVERRUN");
            cFilter.ErrorFilter.Add("OVER_RUN");
            CProjectManager.ErrorFilterS.Add(cFilter.SheetName, cFilter);
        }

        private void SetIOMakerMode(bool bDesign, bool bMapping, bool bVerification)
        {
            if (bDesign)
            {
                pgPLCSymbolStandardization.Visible = true;
                pgHMIMapping.Visible = false;
                pgHMIVerification.Visible = false;
                pgPLCVerification.Visible = false;

                tabMain.SelectedTabPage = tpDesign;
            }
            else if (bMapping)
            {
                pgHMIMapping.Visible = true;
                pgPLCSymbolStandardization.Visible = false;
                pgPLCVerification.Visible = false;
                pgHMIVerification.Visible = false;

                tabMain.SelectedTabPage = tpMapping;
            }
            else if (bVerification)
            {
                pgPLCVerification.Visible = true;
                pgHMIVerification.Visible = true;
                pgHMIMapping.Visible = false;
                pgPLCSymbolStandardization.Visible = false;

                tabMain.SelectedTabPage = tpPLCVerification;
            }

            pgHelper.Visible = true;
        }

        private void FrmPLCWizard_NewClicked()
        {
            btnNewPLC_ItemClick(null, null);
        }

        private void FrmPLCWizard_OpenClicked()
        {
            btnOpenPLCTag_ItemClick(null, null);
        }

        private void FrmProjectLoadWizard_NewClicked()
        {
            btnNew_ItemClick(null, null);
        }

        private void FrmProjectLoadWizard_OpenClicked()
        {
            btnOpen_ItemClick(null, null);
        }

        #endregion


        private void FrmMain_Load(object sender, EventArgs e)
        {
            int iStep = 0;
            try
            {
                this.Hide();

                iStep = 1;

                FrmMode frmMode = new FrmMode();

                iStep = 2;

                if (frmMode.ShowDialog() == DialogResult.Cancel)
                {
                    frmMode.Dispose();
                    frmMode = null;

                    Application.ExitThread();
                    Environment.Exit(0);
                }

                SetIOMakerMode(frmMode.IsDesignMode, frmMode.IsMappingMode, frmMode.IsVerificationMode);
                this.Show();

                //CProjectManager.Project = new CProject();
                //InitScreen();

                //if (frmMode.IsDesignMode)
                //    CProjectManager.IOMakerMode = EMIOMakerMode.Design;
                //else if (frmMode.IsMappingMode)
                //    CProjectManager.IOMakerMode = EMIOMakerMode.Mapping;
                //else if (frmMode.IsVerificationMode)
                //    CProjectManager.IOMakerMode = EMIOMakerMode.Verification;
                
                LoadFrmNameEdit();

                frmMode.Dispose();
                frmMode = null;

                CProjectManager.Project = new CProject();
                InitScreen();

                FrmLoadWizard frmWizard = new FrmLoadWizard();
                frmWizard.UEventNewProjectClicked += FrmProjectLoadWizard_NewClicked;
                frmWizard.UEventOpenProjectClicked += FrmProjectLoadWizard_OpenClicked;
                frmWizard.TopMost = true;
                frmWizard.Show();
                //btnNew_ItemClick(null, null);
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmMain", "Load Error, Step : " + iStep + ", Message : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            SetSpliterLocation();
        }

        private void FrmRibbon_SelectedPageChanged(object sender, EventArgs e)
        {
            if (FrmRibbon.SelectedPage == pgHMIMapping)
                tabMain.SelectedTabPage = tpMapping;
            else if (FrmRibbon.SelectedPage == pgPLCVerification)
            {
                tabMain.SelectedTabPage = tpPLCVerification;

                if (!m_bFirst)
                {
                    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                    {
                        LoadVerificationExceltoSheet(CProjectManager.VerifPath);
                        LoadHMIVerificationExceltoSheet(m_sHMIVerifPath);
                        m_bFirst = true;
                    }
                    SplashScreenManager.CloseForm(false);
                }
            }
            else if (FrmRibbon.SelectedPage == pgHMIVerification)
            {
                tabMain.SelectedTabPage = tpHMIVerification;

                if (!m_bFirst)
                {
                    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                    {
                        LoadVerificationExceltoSheet(CProjectManager.VerifPath);
                        LoadHMIVerificationExceltoSheet(m_sHMIVerifPath);
                        m_bFirst = true;
                    }
                    SplashScreenManager.CloseForm(false);
                }
            }
            else if (FrmRibbon.SelectedPage == pgHelper)
                tabMain.SelectedTabPage = tpHelp;
            else if (FrmRibbon.SelectedPage == pgPLCSymbolStandardization)
                tabMain.SelectedTabPage = tpDesign;

            SetSpliterLocation();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeFrmNameEdit();
        }

        private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;

                if (CProjectManager.LogicDataS.Count > 0)
                {
                    if (
                        XtraMessageBox.Show("기존 프로젝트에 대한 정보가 남아있습니다.\r\n저장되지 않은 심볼 정보가 존재할 수 있습니다.\r\n새로운 프로젝트를 Open 하시겠습니까?",
                            "UDM IO Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }

                chkViewIOList.Checked = false;
                m_bExport = false;
                IOSpreadSheet.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.Default);
                IOSpreadSheet.CreateNewDocument();

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bOK = CProjectManager.Open();

                    if (bOK)
                    {
                        if (CProjectManager.IOMakerMode != EMIOMakerMode.Design)
                        {
                            if (pgPLCSymbolStandardization.Visible)
                                bOK = false;
                            else
                            {
                                ShowPLCGrid();
                                ShowVerificationGrid();
                                bOK = true;
                            }
                        }
                        else
                        {
                            if (!pgPLCSymbolStandardization.Visible)
                                bOK = false;
                            else
                            {
                                ShowDesignPLCGrid();

                                grdStd.DataSource = null;
                                grdStd.DataSource = CProjectManager.StdTagS.Values.ToList();
                                grdStd.RefreshDataSource();

                                CreateAddressBlockS(CProjectManager.LogicDataS.First().Value);

                                SetPLCList();
                                SetListType();
                                ShowIOModuleTree(chkIOExtend.Checked, chkIOUsed.Checked);
                                CheckMakerRedundancy(CProjectManager.LogicDataS[m_sPLCName]);

                                bOK = true;
                            }
                        }

                        if (bOK)
                        {
                            m_emCurPLCMaker = CProjectManager.LogicDataS[m_sPLCName].PLCMaker;

                            if (m_emCurPLCMaker.Equals(EMPLCMaker.Mitsubishi_Developer))
                            {
                                colName.Visible = false;
                                colVerifName.Visible = false;
                                colDesignName.Visible = false;
                            }
                            else
                            {
                                colName.Visible = true;
                                colVerifName.Visible = true;
                                colDesignName.Visible = true;
                            }

                            if (m_emCurPLCMaker.Equals(EMPLCMaker.Rockwell))
                                colDesignNote.Visible = true;
                            else
                                colDesignNote.Visible = false;
                        }

                        InitScreen();
                    }
                    else if (!CProjectManager.DialogCancel)
                        XtraMessageBox.Show("Open Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SplashScreenManager.CloseForm(false);

                if(bOK)
                    XtraMessageBox.Show("Open Success!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(!CProjectManager.DialogCancel)
                {
                    string sMessage = string.Format("해당 IO Maker Mode에서 저장한 프로젝트 파일이 아닙니다.\r\n이 프로젝트 파일은 {0} Mode에서 저장된 파일입니다.", CProjectManager.IOMakerMode.ToString());

                    ClearPLC();
                    ClearHMI();

                    XtraMessageBox.Show(sMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Open Project Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bOK = CProjectManager.Save();
                }
                SplashScreenManager.CloseForm(false);

                if (!bOK && !CProjectManager.DialogCancel)
                    XtraMessageBox.Show("Save Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (bOK)
                    XtraMessageBox.Show("Save Success!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Save Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool bOK = false;

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bOK = CProjectManager.SaveAs();
                }
                SplashScreenManager.CloseForm(false);

                if (!bOK && !CProjectManager.DialogCancel)
                    XtraMessageBox.Show("Save Fail!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (bOK)
                    XtraMessageBox.Show("Save Success!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Save As Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnModeChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (
                XtraMessageBox.Show("IO Maker 모드를 변경하시면 기존 프로젝트의 내용은 모두 지워집니다.\r\nIO Maker 모드를 변경하시겠습니까?",
                    "IO Maker 모드 변경", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ClearPLC();
            ClearHMI();

            pdfViewer.CloseDocument();

            LoadVerificationExceltoSheet(CProjectManager.VerifPath);

            CProjectManager.ProjectPath = string.Empty;

            FrmMain_Load(null, null);
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.LogicDataS.Count > 0)
            {
                if (
                    XtraMessageBox.Show("기존 프로젝트에 대한 정보가 남아있습니다.\r\n저장되지 않은 심볼 정보가 존재할 수 있습니다.\r\n그래도 프로그램을 종료하시겠습니까?",
                        "UDM IO Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            pdfViewer.CloseDocument();
            Application.Exit();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (CProjectManager.Project != null && CProjectManager.LogicDataS.Count > 0)
                {
                    if (XtraMessageBox.Show("기존 프로젝트에 대한 정보가 남아있습니다.\r\n프로젝트를 새로 생성하시겠습니까?",
                        "New Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClearPLC();
                        ClearHMI();
                    }
                    else
                        return;
                }

                CProjectManager.Project = new CProject();

                if (CProjectManager.ErrorFilterS == null)
                    CProjectManager.ErrorFilterS = new CErrorFilterS();

                InitErrorListFilter();

                if (LoadStdLibrary())
                {
                    grdStdL.DataSource = CProjectManager.StdS.Values.ToList();
                    grdStdL.RefreshDataSource();
                }

                if(pgPLCSymbolStandardization.Visible)
                    CProjectManager.IOMakerMode = EMIOMakerMode.Design;
                else if(pgHMIMapping.Visible)
                    CProjectManager.IOMakerMode = EMIOMakerMode.Mapping;
                else if(pgHMIVerification.Visible || pgPLCVerification.Visible)
                    CProjectManager.IOMakerMode = EMIOMakerMode.Verification;

                FrmProjectWizard frmWizard = new FrmProjectWizard();
                DialogResult dlgResult = frmWizard.ShowDialog();

                frmWizard.Dispose();
                frmWizard = null;

                InitScreen();

                if (dlgResult == DialogResult.OK)
                {
                    FrmPLCOpenWizard frmPLCWizard = new FrmPLCOpenWizard();
                    frmPLCWizard.UEventOpenClicked += FrmPLCWizard_OpenClicked;
                    frmPLCWizard.UEventNewClicked += FrmPLCWizard_NewClicked;
                    frmPLCWizard.TopMost = true;
                    frmPLCWizard.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        
    }
}
