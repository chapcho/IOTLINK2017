using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log.DB;
using UDM.Log;
using DevExpress.XtraEditors;
using System.Diagnostics;
using UDM.General.Csv;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System.IO;
using DevExpress.XtraLayout.Customization;
using TrackerCommon;
using DevExpress.XtraTab;
using UDM.General.Statistics;
using UDM.Ladder;
using UDM.Flow;

namespace UDMLadderTracker
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private List<string> m_lstAddressFilter = new List<string>();
        private List<string> m_lstDescriptionFilter = new List<string>();

        private Dictionary<string, int> m_dicCycleCount = new Dictionary<string, int>();
        private string m_sFixUpmPath = Application.StartupPath + "\\LastProjectPath.txt";
        private string m_sAutoOpenUpmPath = "";
        private string m_sSysLogPath = Application.StartupPath + "\\TrackerSystemLog";
        private bool m_bUpmOpenFirst = true;
        private CTrackerServer m_cTrackerServer = new CTrackerServer();
        private CSystemLog m_cSysLog = null;
        private CTrackerAnalyzer m_cAnalyzer = new CTrackerAnalyzer();
        private CTrackerLogWriter m_cLogWriter = new CTrackerLogWriter();
        private CTrackerErrorAnalyzer m_cErrorAnalyzer = new CTrackerErrorAnalyzer();
        private CMySqlLogReader m_cReader = new CMySqlLogReader();

        private Dictionary<string, CErrorInfo> m_dicSendedSubDepth = new Dictionary<string, CErrorInfo>();
        private Dictionary<string, DateTime> m_dicProcessCycleStart = new Dictionary<string, DateTime>();
        private Dictionary<string, string> m_dicProcessRecipe = new Dictionary<string, string>();
        private Dictionary<string, bool> m_dicSPDStatusCheck = new Dictionary<string, bool>();


        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected delegate void UpdateErrorTabBack();
        protected delegate void UpdatwFlowChartCallback(CTimeLogS cLogS);
        private delegate void UpdateDoubleClickCallback(object sender, CErrorInfo cInfo);
        
        #endregion


        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(exRibbonGallery, true);

            dtpkExportFrom.EditValue = System.DateTime.Now.AddMinutes(-30);
            dtpkExportTo.EditValue = System.DateTime.Now;

            exRibbonControl.Minimized = true;
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        private bool CheckProjectAvailable()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "" || CMultiProject.ProjectInfo.ProjectID == "00000000")
            {
                MessageBox.Show("Please Create New Project First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private bool CheckProjectEditable()
        {
            if (m_cTrackerServer.IsRunning)
            {
                MessageBox.Show("Please Stop Monitoring First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return false;
            }

            return true;
        }

        private void CheckProjectNullProperties()
        {
            if (CMultiProject.PlcProcS == null)
                CMultiProject.PlcProcS = new CPlcProcS();
            if (CMultiProject.RecipeWordList == null)
                CMultiProject.RecipeWordList = new Dictionary<int, CRecipeWord>();
            if (CMultiProject.ProjectInfo == null)
                CMultiProject.ProjectInfo = new CProjectBaseInfo();
            if (CMultiProject.MasterPatternS == null)
                CMultiProject.MasterPatternS = new UDM.Flow.CMasterPatternS();
            if (CMultiProject.UserDeviceS == null)
                CMultiProject.UserDeviceS = new CUserDeviceS();
            if (CMultiProject.PlcConfigS == null)
                CMultiProject.PlcConfigS = new CPlcConfigS();
            if (CMultiProject.PlcLogicDataS == null)
                CMultiProject.PlcLogicDataS = new CPlcLogicDataS();
            if (CMultiProject.TotalTagS == null)
                CMultiProject.TotalTagS = new CTagS();
            if (CMultiProject.ErrorInfoS == null)
                CMultiProject.ErrorInfoS = new CErrorInfoS();
            if (CMultiProject.PlcIDList == null)
                CMultiProject.PlcIDList = new List<string>();
            if (CMultiProject.AbnormalFilter == null)
                CMultiProject.AbnormalFilter = new List<string>();
            if (CMultiProject.DicProcessTimeAvr == null)
                CMultiProject.DicProcessTimeAvr = new Dictionary<string, double>();

        }

        protected void UpdateSystemMessage(string sSender, string sMessage)
        {
            if (this.InvokeRequired)
            {
                UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateSystemMessage);
                this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
            }
            else
            {
                ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                m_cSysLog.WriteLog(sSender, sMessage);
            }
        }

        private void UpdateErrorTab()
        {
            if (this.InvokeRequired)
            {
                UpdateErrorTabBack cbUpdateText = new UpdateErrorTabBack(UpdateErrorTab);
                this.Invoke(cbUpdateText, new object[] { });
            }
            else
                btnMain_Click(null, null);
                
        }

        private void UpdateFlowChart(CTimeLogS cLogS)
        {
            if (this.InvokeRequired)
            {
                UpdatwFlowChartCallback cUpdate = new UpdatwFlowChartCallback(UpdateFlowChart);
                this.Invoke(cUpdate, new object[] { cLogS });
            }
            else
            {
                for (int i = 0; i < tabFlow.TabPages.Count; i++)
                {
                    UCFlowPanelS ucFlowPS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                    ucFlowPS.UpdateFlowChart(cLogS);
                }

                cLogS.Clear();
                cLogS = null;
            }
        }

        private void CreateFlowChart()
        {
            if (CMultiProject.PlcProcS.Where(b => b.Value.RecipeFlowChartItemS.Count > 0).Count() > 0)
            {
                DialogResult dlgResult = MessageBox.Show("기존 FlowChart가 존재 합니다. 다시 생성하시겠습니까?", "UDM Tracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    return;
            }

            //FlowChart 삽입
            int iCount = 0;
            tabFlow.TabPages.Clear();
            foreach (var who in CMultiProject.PlcProcS)
                CreateFlowChartTabPage(iCount++, who.Value);
        }

        private bool CreateFlowChartTabPage(int iNumber, CPlcProc cProcess)
        {
            if (cProcess.KeySymbolS == null || cProcess.KeySymbolS.Count == 0)
            {
                UpdateSystemMessage("FlowChart", cProcess.Name + "에 KeySymbol이 없어 Flow Chart를 생성할 수 없습니다.");
                return false;
            }

            cProcess.RecipeFlowChartItemS.Clear();
            //FlowItem 생성

            int iCount = 0;
            CFlowChartItemS cItemS = null;
            CFlowChartItem cItem = null;
            CMasterPattern cPattern = CMultiProject.MasterPatternS[cProcess.Name];
            string sRecipe = string.Empty;

            foreach(var who in cPattern)
            {
                sRecipe = who.Key;
                iCount = 0;
                cItemS = new CFlowChartItemS();

                if (who.Value.Count == 0)
                    continue;

                foreach(var who2 in who.Value.First().FlowItemS)
                {
                    cItem = new CFlowChartItem();
                    cItem.Key = who2.Key;
                    cItem.KeySymbol = cProcess.KeySymbolS[who2.Key];
                    cItem.TargetValue = 1;
                    cItemS.Add(iCount++, cItem);
                }

                cProcess.RecipeFlowChartItemS.Add(sRecipe, cItemS);
            }

            ShowFlowChart(iNumber, cProcess);

            return true;
        }

        private void SetTagList(List<CTag> lstTotalTag, List<CTag> lstValue)
        {
            foreach (CTag cTag in lstValue)
            {
                if (!lstTotalTag.Contains(cTag))
                    lstTotalTag.Add(cTag);
            }
        }

        private void WriteLastUpmPath()
        {
            StreamWriter writer = new StreamWriter(m_sFixUpmPath);
            writer.WriteLine(CMultiProject.ProjectPath);
            m_sAutoOpenUpmPath = CMultiProject.ProjectPath;
            writer.Dispose();
            writer = null;
        }

        private string ReadLastUpmPath()
        {
            StreamReader reader = new StreamReader(m_sFixUpmPath);
            string sLine = "";
            while ((sLine = reader.ReadLine()) != null)
            {
                if (sLine != "")
                {
                    reader.Dispose();
                    reader = null;
                    return sLine;
                }
            }
            reader.Dispose();
            reader = null;
            return null;
        }

        private void SetSplitterPosition()
        {
            sptUserMain.SplitterPosition = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.4);
        }

        private void InitSetting()
        {
            CMultiProject.Editable = true;
            CMultiProject.ErrorView = ucErrorView;
            CMultiProject.ErrorLogTable = ucErrorLogTable;
            CMultiProject.RobotCycle = ucRobotCycle;
            CMultiProject.StatusView = ucStatusView;
            CMultiProject.ErrorPanelS = ucErrorListPanelS;

            ucErrorListPanelS.UEventErrorPanelDoubleClicked += ucErrorListPanelS_GridDoubleClick;

            m_cAnalyzer.RobotCycle = ucRobotCycle;
            m_cAnalyzer.CollectGrid = grdRuntimeValue;
            m_cAnalyzer.UserAllGrid = grdUserAll;
            m_cAnalyzer.UserWordGrid = grdUserDevice;

            bool bOK = m_cReader.Connect();
            if (bOK == false)
            {
                MessageBox.Show("Can't connect Database!! Please check Database installation", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSystemMessage("DBReader", "연결에 실패했습니다.");
                return;
            }

            CMultiProject.LogReader = m_cReader;

            chkMainTabHeader.Checked = false;

            if (File.Exists(m_sFixUpmPath) == false)
            {
                FileStream stream = File.Create(m_sFixUpmPath);
                stream.Dispose();
                stream = null;
                UpdateSystemMessage("Project", "자동으로 불러올 UMPP 경로를 찾을 수 없습니다. 새로 만드세요!!!");
            }
            else
            {
                m_sAutoOpenUpmPath = ReadLastUpmPath();
                m_cSysLog.WriteLog("자동열기", "기존 UMPP 경로 : " + m_sAutoOpenUpmPath);
                btnOpen_ItemClick(null, null);
            }
        }

        private void ShowTrackerMode()
        {
            if (CMultiProject.PatternItemStep == EMMonitorModeType.UpdateEnd)
            {
                chkMonitorErrorDetection.Enabled = true;
                chkMonitorErrorDetection.Checked = true;

                ucTrackerMode.MonitorType = EMMonitorType.Detection;
            }
            else
            {
                chkMonitorErrorDetection.Enabled = false;
                chkMonitorFlowItem.Checked = true;
                btnFlowChart.Enabled = true;

                ucTrackerMode.MonitorType = EMMonitorType.FlowItem;
            }

            ucTrackerMode.Stop();
        }

        private void ShowFlowChart(int iNumber, CPlcProc cProcess)
        {
            if (cProcess.RecipeFlowChartItemS.Count == 0)
                return;

            XtraTabPage tabPage = new XtraTabPage();
            UCFlowPanelS ucFlowPanelS = new UCFlowPanelS();
            ucFlowPanelS.Dock = DockStyle.Fill;
            ucFlowPanelS.PlcProcess = cProcess;
            ucFlowPanelS.ShowFlowChartInit();

            tabPage.Name = "tpFlow" + iNumber.ToString();
            tabPage.Text = cProcess.Name;
            tabFlow.TabPages.Add(tabPage);

            tabPage.Controls.Add(ucFlowPanelS);
            tabPage.Refresh();
        }
        
        private void ShowFlowChart()
        {
            int iCount = 0;
            tabFlow.TabPages.Clear();
            foreach (var who in CMultiProject.PlcProcS)
            {
                ShowFlowChart(iCount++, who.Value);
            }
        }

        private void HandlingRunningEvent(bool bCreate)
        {
            if (bCreate)
            {
                m_cTrackerServer.UEventTimeLogS += m_cTrackerServer_UEventTimeLogS;
                m_cTrackerServer.UEventEmergTimeLogS += m_cTrackerServer_UEventEmergTimeLogS;
                m_cAnalyzer.UEventMessage += m_cAnalyzer_UEventMessage;
                m_cAnalyzer.UEventCycleStart += m_cAnalyzer_UEventCycleStart;
                m_cAnalyzer.UEventInterlockError += m_cAnalyzer_UEventInterlockError;
                m_cAnalyzer.UEventRobotCycleOn += m_cAnalyzer_UEventRobotCycleOn;
                m_cLogWriter.UEventMessage += m_cLogWriter_UEventMessage;
                m_cErrorAnalyzer.UEventMessage += m_cLogWriter_UEventMessage;
            }
            else
            {
                m_cTrackerServer.UEventTimeLogS -= m_cTrackerServer_UEventTimeLogS;
                m_cTrackerServer.UEventEmergTimeLogS -= m_cTrackerServer_UEventEmergTimeLogS;
                m_cAnalyzer.UEventMessage -= m_cAnalyzer_UEventMessage;
                m_cAnalyzer.UEventCycleStart -= m_cAnalyzer_UEventCycleStart;
                m_cAnalyzer.UEventInterlockError -= m_cAnalyzer_UEventInterlockError;
                m_cAnalyzer.UEventRobotCycleOn -= m_cAnalyzer_UEventRobotCycleOn;
                m_cLogWriter.UEventMessage -= m_cLogWriter_UEventMessage;
                m_cErrorAnalyzer.UEventMessage -= m_cLogWriter_UEventMessage;
            }
        }

        private void SaveProject(string sPath)
        {
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                string sMessage = "";
                bool bOK = CMultiProject.Save(sPath, out sMessage);
                if (bOK)
                {
                    UpdateSystemMessage("저장", "저장에 성공했습니다.");
                    WriteLastUpmPath();
                }
                else
                    UpdateSystemMessage("저장실패", sMessage);
            }
            SplashScreenManager.CloseForm(false);
        }

        private CStep GetMasterStep(CTag cTag, CPlcLogicData cLogic)
        {
            if (cTag == null) return null;
            if (cLogic == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = cLogic.StepS.Where(b => b.Value.Address == cTag.Address).Select(b => b.Value).ToList();

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.ShowDialog();

                    cStep = frmSelector.GetSelectedStep();

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            return cStep;
        }

        private void SetLadderStep(CStep cStep, CErrorInfo cErrorInfo, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
                    return;

                CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                UCLadderStep ucStep = new UCLadderStep(cStep, cErrorInfo.ErrorLogS, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.AutoScroll = false;
                ucStep.ScaleDefault = 1f; // 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel;
                ucStep.IsViewStep = bView;
                ucStep.StepName =
                    string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlView.Controls.Add(ucStep);
                this.Size = ucStep.Size;
            }
        }

        private void UpdateFlowChart(string sProcessKey, string sRecipe)
        {
            for (int i = 0; i < tabFlow.TabPages.Count; i++)
            {
                if (tabFlow.TabPages[i].Text == sProcessKey)
                {
                    if (tabFlow.TabPages[i].Controls.Count == 0) continue;
                    UCFlowPanelS ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                    ucFlowS.ClearActive();
                    ucFlowS.UpdateRecipe(sRecipe);
                    break;
                }
            }
        }

        #endregion


        #region Event Methods


        #region Form Event

        #region Main Form Event
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            bool bOK = m_cTrackerServer.StartServer();
            if (bOK == false)
            {
                MessageBox.Show("Collect Manager가 실행되지 않았습니다.");
                this.Close();
                return;
            }
            m_cSysLog = new CSystemLog(m_sSysLogPath, "Tracker");
            tmrSystemLog.Start();
            m_cTrackerServer.UEventMessage += m_cTrackerServer_UEventMessage;
            m_cTrackerServer.UEventSPDStatus += m_cTrackerServer_UEventSPDStatus;
            m_cTrackerServer.UEventClientConnect += m_cTrackerServer_UEventClientConnect;

            Process[] aProcess = Process.GetProcessesByName("UDMSPDManager");
            if (aProcess.Length > 0) m_cSysLog.WriteLog("SPDManager", "처음실행을 위해 기존 SPD Manager를 강제 종료합니다.  " + aProcess.Length.ToString());
            foreach (Process pro in aProcess)
                pro.Kill();

            Process proSPDManager = new Process();
            proSPDManager.StartInfo.FileName = Application.StartupPath + "\\UDMSPDManager.exe";
            proSPDManager.Start();
            m_cSysLog.WriteLog("SPDManager", "실행합니다.");
            InitSetting();

            SetSplitterPosition();

            toggMainEditorMode.Checked = false;
        }

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (m_cTrackerServer.IsRunning)
            {
                MessageBox.Show("Please stop monitoring first!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateSystemMessage("FormClosing", "현재 수집 중입니다. 정지 후 다시 시도");
                e.Cancel = true;
                return;
            }
            Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
            foreach (Process pro in aProcess)
                pro.Kill();

            aProcess = Process.GetProcessesByName("UDMSPDManager");
            foreach (Process pro in aProcess)
                pro.Kill();

            m_cTrackerServer.StopServer();
            tmrSystemLog.Stop();
            m_cSysLog.WriteLog("FormClose", "모든 프로세스를 종료 했습니다.");
            m_cSysLog.WriteEndLog();
		}

        private void tmrSystemLog_Tick(object sender, EventArgs e)
        {
            tmrSystemLog.Enabled = false;

            try
            {
                if (m_cSysLog != null)
                {
                    m_cSysLog.WriteLog("SystemLog", "새로운 파일을 생성합니다.(주기 1시간)");
                    string sFileName = m_cSysLog.FileName;
                    m_cSysLog.WriteEndLog();

                    m_cSysLog = new CSystemLog(m_sSysLogPath, "Tracker");

                    m_cSysLog.WriteLog("SystemLog", "이전 파일 : " + sFileName);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("SystemLog", "Error : " + ex.Message);
                ex.Data.Clear();
            }

            tmrSystemLog.Enabled = true;
        }

        #endregion


        #region File Button

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sPath = "";
            if (m_bUpmOpenFirst)
            {
                sPath = m_sAutoOpenUpmPath;
                m_bUpmOpenFirst = false;
            }

            if (sPath == "" || sPath == null)
            {
                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.Filter = "*.umpp|*.umpp";
                dlgOpenFile.ShowDialog();

                sPath = dlgOpenFile.FileName;
            }
            UpdateSystemMessage("열기", "프로젝트 열기를 시작 : " + sPath);
            if (sPath != "")
            {
                bool bOK = false;
                string sMessage = "";
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bOK = CMultiProject.Open(sPath, out sMessage);
                }
                SplashScreenManager.CloseForm(false);
                if (bOK)
                {
                    UpdateSystemMessage("열기", "성공");
                    CheckProjectNullProperties();

                    CMultiProject.ComposeProcessLogicData();
                    if (CMultiProject.PatternItemStep == EMMonitorModeType.None)
                        btnUpdatePatternItem.Enabled = false;

                    ShowTrackerMode();

                    grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                    grdUserAll.RefreshDataSource();

                    grdUserDevice.DataSource = CMultiProject.UserDeviceS.Values.Where(b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
                    grdUserDevice.RefreshDataSource();

                    ShowFlowChart();
                    ;

                    CMultiProject.ProjectPath = sPath;
                    WriteLastUpmPath();

                    CMultiProject.PlcIDList.Clear();
                    foreach (var who in CMultiProject.PlcLogicDataS)
                        CMultiProject.PlcIDList.Add(who.Key);

                    tmrLoadFirst.Start();
                }
                else
                    UpdateSystemMessage("열기실패", sMessage + "  문제가 있습니다.");
            }
            else
                UpdateSystemMessage("열기실패", "경로가 없습니다");
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            string sPath = CMultiProject.ProjectPath;
            if (File.Exists(sPath) == false)
            {
                SaveFileDialog dlgSaveFile = new SaveFileDialog();
                dlgSaveFile.Filter = "*.umpp|*.umpp";
                dlgSaveFile.ShowDialog();

                sPath = dlgSaveFile.FileName;
                CMultiProject.ProjectPath = sPath;
            }

            UpdateSystemMessage("저장", "프로젝트 저장를 시작 : " + sPath);
            if (sPath != "")
                SaveProject(sPath);
            else
                UpdateSystemMessage("저장실패", "경로가 없습니다");
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Upm files (*.umpp)|*.umpp";
            DialogResult dlgResult = dlgSave.ShowDialog();

            if (dlgResult == DialogResult.Cancel) return;

            string sPath = dlgSave.FileName;
            UpdateSystemMessage("저장", "프로젝트 저장를 시작 : " + sPath);
            if (sPath != "")
            {
                CMultiProject.ProjectPath = sPath;
                SaveProject(sPath);
            }
            else
                UpdateSystemMessage("저장실패", "경로가 없습니다");
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit program?", "UDMTracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion


        #region Model Button

        private void btnProjectSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int iPlcCount = CMultiProject.PlcLogicDataS.Count;
            FrmModel frmModel = new FrmModel();
            frmModel.ShowDialog();

            CMultiProject.Refresh();

            if (CMultiProject.PlcProcS.Where(b => b.Value.RecipeFlowChartItemS.Count > 0).Count() == 0)
                tabFlow.TabPages.Clear();

            if (CMultiProject.PatternItemStep == EMMonitorModeType.None)
                btnFlowChart.Enabled = false;

            ShowTrackerMode();

            grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
            grdUserAll.RefreshDataSource();

            grdUserDevice.DataSource = CMultiProject.UserDeviceS.Values.Where(b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
            grdUserDevice.RefreshDataSource();

            CMultiProject.PlcIDList.Clear();
            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                CMultiProject.PlcIDList.Add(who.Key);
            }
            if (frmModel.IsSaveExcute)
                btnSave_ItemClick(null, null);
         
            //SPD Single실행
            if (frmModel.IsChangePlcList)
                m_cTrackerServer.SendCollectList();
        }

        private void btnUpdateMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Please Wait", "Flow Chart 자동 생성 중입니다.");
            {
                UpdateSystemMessage("Flow Chart", "생성요청");

                FrmMasterPatternUpdate frmMasterpattern = new FrmMasterPatternUpdate();
                frmMasterpattern.ShowDialog();

                if (frmMasterpattern.MasterPastternOK)
                {
                    CMultiProject.PatternItemStep = EMMonitorModeType.UpdateEnd;
                    ShowTrackerMode();

                    CreateFlowChart();
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        #endregion
        

        #region Button Click

        private void btnErrorDetail_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTabPage = tpErrorNew;
        }

        private void btnUserDevice_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTabPage = tpUserDevice;
        }

        private void btnCurrentValue_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTabPage = tpCurrentSymbol;
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTabPage = tpMain;
        }

        private void btnExportPDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportExporter frmReport = new FrmReportExporter();
            frmReport.ShowDialog();
        }

        private void btnFlowChartHide_Click_1(object sender, EventArgs e)
        {
            //grpProcessFlowChart.Hide();
        }

        private void btnExitHMI_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit program?", "UDMTracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnErrorReport_Click(object sender, EventArgs e)
        {
            tabMain.SelectedTabPage = tpErrorLog;
        }

        #endregion


        #region Check Box

        private void chkShowSysLog_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chkShowSysLog.Checked == false)
            {
                if (dpnlSystemLog.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlSystemLog.Hide();
            }
            else
            {
                if (dpnlSystemLog.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlSystemLog.Show();
            }
        }

        private void chkShowMonitorStatus_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            grpMonitorStatus.Visible = chkShowMonitorStatus.Checked;
            //int iSptWidth = 0;
            //if (chkShowMonitorStatus.Checked)
            //    iSptWidth = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.5);
            //else
            //    iSptWidth = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.6);
            //sptCycleMain.SplitterPosition = iSptWidth;
            sptUserMain.SplitterPosition = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.4);
            //sptError.SplitterPosition = (int)(Screen.PrimaryScreen.Bounds.Size.Width * 0.3);
        }

        private void chkMainTabHeader_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chkMainTabHeader.Checked)
                tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            else
                tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        private void chkMonitorFlowItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ucTrackerMode.MonitorType = EMMonitorType.FlowItem;
            CMultiProject.MonitorType = EMMonitorType.FlowItem;
            ucTrackerMode.Stop();
        }

        private void chkMonitorErrorDetection_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ucTrackerMode.MonitorType = EMMonitorType.Detection;
            CMultiProject.MonitorType = EMMonitorType.Detection;
            ucTrackerMode.Stop();
        }

        #endregion

        private void btnMonitorStart_Click(object sender, EventArgs e)
        {
            UpdateSystemMessage("수집시작", "수집을 시작합니다.");
            HandlingRunningEvent(true);
            CMultiProject.UserDeviceS.ClearCurrentValue();
            CMultiProject.ClearCurrentID();

            if (m_cErrorAnalyzer.LogWriter == null)
                m_cErrorAnalyzer.LogWriter = m_cLogWriter;
            m_dicCycleCount.Clear();
            foreach (var who in CMultiProject.PlcProcS)
            {
                if(!m_dicProcessCycleStart.ContainsKey(who.Key))
                    m_dicProcessCycleStart.Add(who.Key, DateTime.MinValue);

                if (!m_dicProcessRecipe.ContainsKey(who.Key))
                    m_dicProcessRecipe.Add(who.Key, string.Empty);

                if (!m_dicCycleCount.ContainsKey(who.Key))
                    m_dicCycleCount.Add(who.Key, 0);
            }
            bool bOK = m_cLogWriter.Run();
            if (bOK == false)
            {
                UpdateSystemMessage("시작실패", "LogWriter 시작 실패");
                return;
            }

            bOK = m_cErrorAnalyzer.Run();
            if (!bOK)
            {
                UpdateSystemMessage("시작실패", "Error Anlayzer 시작 실패");
                return;
            }

            bOK = m_cAnalyzer.Run();
            if (bOK == false)
            {
                UpdateSystemMessage("시작실패", "분석기 시작 실패");
                return;
            }

            bOK = m_cTrackerServer.Run();
            if (bOK == false)
            {
                UpdateSystemMessage("시작실패", "SPD 시작 실패");
                return;
            }

            m_dicSendedSubDepth.Clear();

            foreach (var who in CMultiProject.TotalTagS)
                who.Value.LogCount = 0;

            for (int i = 0; i < tabFlow.TabPages.Count; i++)
            {
                if (tabFlow.TabPages[i].Controls.Count == 0) continue;
                UCFlowPanelS ucFlowS = (UCFlowPanelS)tabFlow.TabPages[i].Controls[0];
                ucFlowS.ClearActive();
            }

            mnuDatabase.Enabled = false;
            ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Monitoring Start!!");
            ucMonitorStatus.Run("Monitoring Start");
            btnMonitorStart.Enabled = false;
            btnMonitorStop.Enabled = true;

            if (CMultiProject.PatternItemStep == EMMonitorModeType.None)
                btnCurrentValue_Click(null, null);
            else
                btnMain_Click(null, null);

            toggMainEditorMode.Enabled = false;
            toggMainEditorMode.Checked = false;
            btnShowLogView.Enabled = false;
            mnuHomeFile.Enabled = false;
        }

        private void btnMonitorStop_Click(object sender, EventArgs e)
        {
            if (m_cTrackerServer.IsRunning == true)
            {
                UpdateSystemMessage("수집정지", "모든SPD를 정지 합니다.");
                m_cTrackerServer.SPDStop();
                
                mnuDatabase.Enabled = true;
                ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Monitor Stop");

                ShowTrackerMode();
                HandlingRunningEvent(false);
                m_cLogWriter.Stop();
                m_cErrorAnalyzer.Stop();
                m_cAnalyzer.Stop();
                ucStatusView.ClearData();
                ucMonitorStatus.Stop("Monitoring Stop");
                btnSave_ItemClick(null, null);

                btnMonitorStart.Enabled = true;
                btnMonitorStop.Enabled = false;
                btnShowLogView.Enabled = true;
                toggMainEditorMode.Enabled = true;
                mnuHomeFile.Enabled = true;

                if (CMultiProject.PatternItemStep != EMMonitorModeType.UpdateEnd)
                    toggMainEditorMode.Checked = true;
            }
        }

        private void grvUserAll_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "DetailViewShow") return;
            CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
            if (cUser == null) return;
            if (cUser.DataType == EMDataType.Bool)
            {
                cUser.DetailViewShow = false;
                return;
            }
        }

        private void grvUserAll_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName != "DetailViewShow") return;
            CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
            if (cUser == null) return;
            if (cUser.DataType != EMDataType.Bool)
            {
                if (cUser.DetailViewShow != (bool)e.Value)
                {
                    cUser.DetailViewShow = (bool)e.Value;

                    grdUserDevice.DataSource = CMultiProject.UserDeviceS.Values.Where(b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
                    grdUserDevice.RefreshDataSource();
                }
            }
        }

        private void grvUserAll_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName != "Value") return;
            CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
            if (cUser == null) return;
            if (cUser.DataType == EMDataType.Bool)
            {
                if (cUser.Value > 0)
                    e.Appearance.BackColor = Color.GreenYellow;
                else
                    e.Appearance.BackColor = Color.White;
                e.DisplayText = cUser.Value.ToString();
            }
        }

        private void grvUserAll_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void toggMainEditorMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (toggMainEditorMode.Checked == false)
                this.exRibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            else
                this.exRibbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
        }

        private void tmrSPDStatusCheck_Tick(object sender, EventArgs e)
        {
            tmrSPDStatusCheck.Enabled = false;

            foreach (var who in m_dicSPDStatusCheck)
            {
                if (who.Value == false)
                {
                    UpdateSystemMessage("SPD Single", "연결 상태 반응이 없습니다. ID : " + who.Key);
                    ucStatusView.UpdateSpdStatus(who.Key, "Error");
                }
            }

            m_dicSPDStatusCheck.Clear();

            foreach (var who in CMultiProject.PlcLogicDataS)
                m_dicSPDStatusCheck.Add(who.Key, false);

            tmrSPDStatusCheck.Enabled = true;
        }

        private void tmrLoadFirst_Tick(object sender, EventArgs e)
        {
            tmrLoadFirst.Enabled = false;

            //SPD Single실행
            m_cTrackerServer.SendCollectList();
            tmrSPDStatusCheck.Start();
        }

        #endregion


		#region User Event

        #region Analyzer Event

        private void m_cAnalyzer_UEventCycleStart(string sProcessKey, DateTime dtActTime)
        {
            if (CMultiProject.TotalCycleInfoS.ContainsKey(sProcessKey))
            {
                ucStatusView.UpdateProcessStatus(sProcessKey, EMCycleRunType.Start);
                ucErrorListPanelS.ClearErrorListPanelS(sProcessKey);

                CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];

                UpdateFlowChart(sProcessKey, cProcess.CurrentRecipe);

                CCycleInfoS cCycleInfoS = CMultiProject.TotalCycleInfoS[sProcessKey];
                CCycleInfo cCycleInfo = cCycleInfoS.CurrentCycleInfo;
                //이미 생성되어 있으므로 값만 채워 넣음.
                cCycleInfo.ProjectID = CMultiProject.ProjectID;
                cCycleInfo.CycleID = cCycleInfoS.LastCycleID;
                cCycleInfo.GroupKey = sProcessKey;

                if (cProcess.CycleEndFlag == false || cCycleInfo.CycleStart == DateTime.MinValue)
                {
                    m_dicProcessCycleStart[sProcessKey] = dtActTime;
                    cCycleInfo.CycleStart = dtActTime;
                    return;
                }

                cCycleInfo.CycleEnd = dtActTime;
                cCycleInfo.NextCycleStart = dtActTime;
                cCycleInfo.CycleCount = m_dicCycleCount[sProcessKey]++;
                cProcess.CycleID = cCycleInfo.CycleID;

                if (cProcess.CycleErrorFlag)
                {
                    cCycleInfo.CycleType = EMCycleRunType.Error;
                    cProcess.CycleErrorFlag = false;
                }
                else
                    cCycleInfo.CycleType = EMCycleRunType.Complete;

                if (m_cLogWriter.IsConnected == false)
                {
                    UpdateSystemMessage("CycleInfo", "LogWriter Fail");
                    return;
                }
                m_dicProcessRecipe[sProcessKey] = cProcess.CurrentRecipe;
                cCycleInfo.CurrentRecipe = cProcess.CurrentRecipe;


                m_cLogWriter.EnQue((CCycleInfo)cCycleInfo.Clone());
                
                int iCycleLastID = cCycleInfoS.LastCycleID;

                //Memory 최적화
                cCycleInfoS.Clear();
                UpdateSystemMessage("CycleStartEvent", string.Format("CycleInfoS를 Clear합니다. 마지막 ID = {0}", iCycleLastID));

                //다음 Cycle Info 추가
                CCycleInfo cNextCycleInfo = new CCycleInfo();
                cNextCycleInfo.CycleStart = dtActTime;
                cNextCycleInfo.CycleID = iCycleLastID + 1;
                cCycleInfoS.Add(cNextCycleInfo.CycleID, cNextCycleInfo);
                UpdateSystemMessage("CycleStartEvent", string.Format("새로운 ID를 발급합니다. {0}", cNextCycleInfo.CycleID));
                m_dicProcessCycleStart[sProcessKey] = dtActTime;
            }
        }

        private void m_cAnalyzer_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void m_cAnalyzer_UEventInterlockError(CAbnormalSymbol cSymbol, CErrorInfo cErrorInfo)
        {
            if (m_dicSendedSubDepth.ContainsKey(cSymbol.Tag.Key) == false)
            {
                ucStatusView.UpdateProcessStatus(cErrorInfo.GroupKey, EMCycleRunType.Error);

                //Flow Chart를 빨간색으로 표시

                //ucProcessCycleBoardS.UpdateCycleOver(cErrorInfo.GroupKey);

                if (cSymbol.AllSubDepthTagList.Count > 0)
                {
                    m_cTrackerServer.GetSubDepthStateValue(cSymbol);
                    m_dicSendedSubDepth.Add(cSymbol.Tag.Key, cErrorInfo);
                    UpdateSystemMessage("CycleInterlockEvent", string.Format("{0}", cSymbol.Tag.Key));
                }
            }
        }

        private void m_cAnalyzer_UEventRobotCycleOn(string sTagKey, string sState)
        {
            ucStatusView.UpdateRobotCycle(sTagKey, sState);
            UpdateSystemMessage("CycleRobotEvent", string.Format("{0}", sTagKey));
        }

        #endregion

        #region Server Event

        private void m_cTrackerServer_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void m_cTrackerServer_UEventTimeLogS(EMTrackerLogType emLogType, CTimeLogS cLogS)
        {
            if (cLogS == null || cLogS.Count == 0)
            {
                UpdateSystemMessage("TimeLogEvent", "cLogS가 Null이거나 Count가 0입니다.");
                return;
            }
            Dictionary<EMTrackerLogType, CTimeLogS> dicData = new Dictionary<EMTrackerLogType, CTimeLogS>();
            dicData.Add(emLogType, (CTimeLogS)cLogS.Clone());
            m_cLogWriter.EnQue((CTimeLogS)cLogS.Clone());
            m_cAnalyzer.EnQue(dicData);
            lblMonitorCount.Caption = cLogS.Count.ToString();

            if (CMultiProject.MonitorType == EMMonitorType.Detection)
                UpdateFlowChart((CTimeLogS)cLogS.Clone());

            cLogS.Clear();
        }

        private void m_cTrackerServer_UEventEmergTimeLogS(EMTrackerLogType emLogType, string sKey, CTimeLogS cLogS)
        {
            if (m_dicSendedSubDepth.ContainsKey(sKey))
            {
                CErrorInfo cErrorInfo = m_dicSendedSubDepth[sKey];
                UpdateSystemMessage("EmergTimeLogS", string.Format("{0} Event 진입 / Error Type : {1}", sKey, cErrorInfo.ErrorType));

                int iCycleLog = cErrorInfo.ErrorLogS.Count;

                cErrorInfo.ErrorLogS = (CTimeLogS)cLogS.Clone();
                cErrorInfo.CycleStart = m_dicProcessCycleStart[cErrorInfo.GroupKey];
                cErrorInfo.CurrentRecipe = m_dicProcessRecipe[cErrorInfo.GroupKey];

                UpdateSystemMessage("EmergTimeLogS", string.Format("{0} 하위Depth수집결과 : Cycle Log = {1} / Error Log = {2}", sKey, iCycleLog, cLogS.Count));
                m_cErrorAnalyzer.EnQue((CErrorInfo)cErrorInfo.Clone());

                //Memory 최적화
                cErrorInfo.ErrorLogS.Clear();
                cErrorInfo = null;

                UpdateErrorTab();
                m_dicSendedSubDepth.Remove(sKey);
            }
            else
                UpdateSystemMessage("EmergTimeLogS", "해당키가 없습니다.  " + sKey);

            //Memory 최적화
            cLogS.Clear();
        }

        private void m_cTrackerServer_UEventClientConnect(bool bConnect)
        {
            if (bConnect)
            {
                ucMonitorStatus.Run("SPD Manager ON");
                UpdateSystemMessage("SPD Manager", "연결 성공");
                if (m_cAnalyzer.IsRunning == false)
                    btnMonitorStart.Enabled = true;
            }
            else
            {
                ucMonitorStatus.Error("SPD Manager OFF");
                UpdateSystemMessage("SPD Manager", "연결 실패");
                if (m_cAnalyzer.IsRunning == false)
                    btnMonitorStart.Enabled = false;
            }
        }

        private void m_cTrackerServer_UEventSPDStatus(string[] saData)
        {
            ucStatusView.UpdateSpdStatus(saData[0], saData[1]);
            //UpdateSystemMessage("SPD 상태", string.Format("{0}상태변화 : {1}", saData[0], saData[1]));
            if (m_dicSPDStatusCheck.ContainsKey(saData[0]) == false)
                m_dicSPDStatusCheck.Add(saData[0], true);
            else
                m_dicSPDStatusCheck[saData[0]] = true;
        }

        #endregion

        private void ucErrorListPanelS_GridDoubleClick(object sender, CErrorInfo cErrorInfo)
        {
            if (this.InvokeRequired)
            {
                UpdateDoubleClickCallback cUpdate = new UpdateDoubleClickCallback(ucErrorListPanelS_GridDoubleClick);
                this.Invoke(cUpdate, new object[] { sender, cErrorInfo });
            }
            else
            {
                if (CMultiProject.TotalTagS.ContainsKey(cErrorInfo.SymbolKey))
                {
                    if (cErrorInfo.ErrorLogS == null || cErrorInfo.ErrorLogS.Count == 0)
                        cErrorInfo.ErrorLogS = CMultiProject.LogReader.GetErrorLogS(cErrorInfo.ErrorID);

                    if (cErrorInfo.ErrorLogS == null)
                        cErrorInfo.ErrorLogS = new CTimeLogS();

                    pnlView.Controls.Clear();
                    CTag cTag = CMultiProject.TotalTagS[cErrorInfo.SymbolKey];
                    CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];

                    CStep cStep = null;

                    if (cErrorInfo.AbnormalSymbolKey != string.Empty)
                    {
                        CAbnormalSymbol cSymbol = CMultiProject.PlcProcS[cErrorInfo.GroupKey].AbnormalSymbolS.GetAbnormalSymbol(cErrorInfo.AbnormalSymbolKey);
                        Dictionary<int, string> dicTraceSymbolKey = null;

                        if (cErrorInfo.CoilKey != string.Empty)
                            dicTraceSymbolKey = cSymbol.SubCoil.GetTraceSymbolKey(cErrorInfo.CoilKey);
                        else
                            dicTraceSymbolKey = cSymbol.SubCoil.GetTraceSymbolKey(cErrorInfo.SymbolKey);

                        for (int i = 0; i < dicTraceSymbolKey.Count; i++)
                        {
                            cStep = cLogic.StepS[dicTraceSymbolKey[i]];
                            if (i != dicTraceSymbolKey.Count - 1)
                                SetLadderStep(cStep, cErrorInfo, i, false);
                            else
                                SetLadderStep(cStep, cErrorInfo, i, true);
                        }
                    }
                    else if (cErrorInfo.CoilKey != string.Empty)
                    {
                        cStep = GetMasterStep(CMultiProject.TotalTagS[cErrorInfo.CoilKey], cLogic);
                        SetLadderStep(cStep, cErrorInfo, 0, true);
                    }
                    else
                    {
                        cStep = GetMasterStep(cTag, cLogic);
                        SetLadderStep(cStep, cErrorInfo, 0, true);

                    }
                    tabMainError.SelectedTabPageIndex = 1;
                }
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            if (cTag == null) return;
            CPlcLogicData cLogic = CMultiProject.PlcLogicDataS[cTag.Creator];
            CStep cStep = GetMasterStep(cTag, cLogic);

            if (cStep != null)
            {
                List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                for (int i = 0; i < pnlView.Controls.Count; i++)
                {
                    UCLadderStep ucView = (UCLadderStep)pnlView.Controls[i];
                    if (ucView.StepLevel > iStepLevel)
                        lstRemove.Add(ucView);
                    else
                    {
                        if (ucView.Step.Key == cStep.Key)
                        {
                            MessageBox.Show("같은 Step이 열려 있습니다.");
                            return;
                        }
                    }
                }
                for (int i = 0; i < lstRemove.Count; i++)
                    pnlView.Controls.Remove(lstRemove[i]);

                UCLadderStep ucStep = new UCLadderStep(cStep, cLogS, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.ScaleDefault = 1f;// 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel + 1;
                ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )", cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, cTag.Description);
                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlView.Controls.Add(ucStep);
            }
        }

        private void m_cLogWriter_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        #endregion



        #endregion



    }
} 