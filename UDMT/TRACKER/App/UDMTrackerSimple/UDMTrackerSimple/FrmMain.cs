using System;
using System.Collections.Generic;
using System.Drawing;
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
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Threading;
using TrackerCommon;
using UDM.Flow;
using TrackerSPD.OPC;
using System.Reflection;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;

namespace UDMTrackerSimple
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private Dictionary<string, int> m_dicCycleCount = new Dictionary<string, int>();
        private string m_sFixUpmPath = Application.StartupPath + "\\LastProjectPath.txt";
        private string m_sFixMainImage = Application.StartupPath + "\\LastMainImage.txt";
        private string m_sAutoOpenUpmPath = "";
        private string m_sSysLogPath = Application.StartupPath + "\\TrackerSystemLog";
        private string m_sDBBackupPath = Application.StartupPath + "\\TrackerDBBackup";
        private bool m_bUpmOpenFirst = true;
        private bool m_bMntAutoStart = false;
        private CTrackerServer m_cTrackerServer = new CTrackerServer();
        private CTrackerClient m_cTrackerClient = new CTrackerClient();
        private CTrackerAnalyzer m_cAnalyzer = new CTrackerAnalyzer();
        private CTrackerLogWriter m_cLogWriter = new CTrackerLogWriter();
        private CTrackerErrorAnalyzer m_cErrorAnalyzer = new CTrackerErrorAnalyzer();
        private CTrackerRecipeChecker m_cRecipeChecker = new CTrackerRecipeChecker();
        private CTrackerCollectOptimizer m_cOptimizer = new CTrackerCollectOptimizer();
        private CMySqlLogReader m_cReader = new CMySqlLogReader();

        private Dictionary<string, CErrorInfo> m_dicSendedSubDepth = new Dictionary<string, CErrorInfo>();
        private Dictionary<string, DateTime> m_dicProcessCycleStart = new Dictionary<string, DateTime>();
        private Dictionary<string, string> m_dicProcessRecipe = new Dictionary<string, string>();
        private Dictionary<string, bool> m_dicSPDStatusCheck = new Dictionary<string, bool>();
        private Dictionary<string, int> m_dicSPDStatusDisconnectCount = new Dictionary<string, int>(); 
        private CTagS m_cRecipeCheckTagS = new CTagS();

        private string m_sSelectedProcess = string.Empty;
        private bool m_bOptimizerMode = false;
        private bool m_bCycleOverAutoDetect = false;
        private bool m_bLoadSPDSingle = false;
        private bool m_bTrackerAlive = false;

        private UCAllErrorAlarmView2 ucSummary = new UCAllErrorAlarmView2();
        private UCFlowChart ucFlowChart = new UCFlowChart();
        private UCPlcCycle ucPlcCycle = new UCPlcCycle();
        private UCErrorView ucErrorView = new UCErrorView();
        private UCErrorLogTable ucErrorLogTable = new UCErrorLogTable();
        private UCSymbolValue ucSymbolValue = new UCSymbolValue();
        private UCStepLadderView ucStepLadderView = new UCStepLadderView();

        private RepositoryItemPictureEdit repositoryPic = new RepositoryItemPictureEdit();

        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected delegate void UpdateErrorTabBack();
        protected delegate void UpdatwFlowChartCallback(CTimeLogS cLogS);
        protected delegate void UpdatwFlowChartCallback2(string sProcessKey, CTimeLog cLog);
        protected delegate void UpdateTagFinderCallback();
        protected delegate void UpdateNewRecipeCallback(Dictionary<string, CCycleInfoS> dicCycleInfoS);
        protected delegate void UpdateNewRecipeCallback2(List<CNewRecipeView> lstRecipeView);
        protected delegate void UpdateOptimizerMonitorStartCallback(bool bFirst, bool bAll, string sProcess);
        protected delegate void UpdateOptimizerMonitorStopCallback(bool bMonitorEnd);

        private FrmNewRecipeViewer m_frmViewer = null;
        private FrmCollectOptimizer m_frmCollectOptimizer = null;

        #endregion


        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(exRibbonGallery, true);

            dtpkExportFrom.EditValue = System.DateTime.Now.AddMinutes(-30);
            dtpkExportTo.EditValue = System.DateTime.Now;

            exRibbon.Minimized = true;

            //ReadLastMainImage();
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
        }

        private bool CheckProjectAvailable()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "" || CMultiProject.ProjectInfo.ProjectID == "00000000")
            {
                XtraMessageBox.Show("Please Create New Project First!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        
        private bool CheckProjectEditable()
        {
            if (m_cTrackerServer.IsRunning)
            {
                XtraMessageBox.Show("Please Stop Monitoring First!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CheckProjectNullProperties()
        {
            if (CMultiProject.PlcProcS == null)
                CMultiProject.PlcProcS = new CPlcProcS();
            //if (CMultiProject.RecipeWordList == null)
            //CMultiProject.RecipeWordList = new Dictionary<int, CRecipeWord>();
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
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateSystemMessage);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    
                    CMultiProject.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void UpdateErrorTab()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateErrorTabBack cbUpdateText = new UpdateErrorTabBack(UpdateErrorTab);
                    this.Invoke(cbUpdateText, new object[] { });
                }
                else
                    btnSummary_Click(null, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UpdateFlowChart(string sProcessKey, CTimeLog cLog)
        {
            if (this.InvokeRequired)
            {
                UpdatwFlowChartCallback2 cUpdate = new UpdatwFlowChartCallback2(UpdateFlowChart);
                this.Invoke(cUpdate, new object[] { sProcessKey, cLog });
            }
            else
                ucFlowChart.UpdateFlowChart(sProcessKey, cLog);
                cLog = null;
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

        //private void WriteLastMainImage()
        //{
        //    if (!File.Exists(m_sFixMainImage))
        //        File.Create(m_sFixMainImage);

        //    byte[] byteImage = null;
        //    StreamWriter writer = null;

        //    try
        //    {
        //        Image img = picMain.EditValue as Image;

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //            byteImage = ms.ToArray();
        //        }

        //        writer = new StreamWriter(m_sFixMainImage);
        //        foreach (byte bt in byteImage)
        //        {
        //            writer.Write(bt.ToString() + ",");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }
        //    finally
        //    {
        //        if (writer != null)
        //        {
        //            writer.Close();
        //            writer.Dispose();
        //            writer = null;
        //        }
        //    }
        //}

        //private void ReadLastMainImage()
        //{
        //    if (!File.Exists(m_sFixMainImage)) return;

        //    string sLine = "";
        //    string sImage = "";
        //    StreamReader reader = null;
        //    MemoryStream ms = null;

        //    try
        //    {
        //        reader = new StreamReader(m_sFixMainImage);
        //        sLine = reader.ReadLine();

        //        if (sLine != null)
        //        {
        //            sImage = sLine;

        //            string[] saIamge = sImage.Split(',');
        //            byte[] byteImage = new byte[saIamge.Length];

        //            for (int i = 0; i < saIamge.Length; i++)
        //            {
        //                if (saIamge[i] != null && saIamge[i] != "")
        //                    byteImage[i] = byte.Parse(saIamge[i]);
        //            }

        //            if (reader != null)
        //            {
        //                reader.Dispose();
        //                reader = null;
        //            }

        //            ms = new MemoryStream(byteImage, 0, byteImage.Length);
        //            ms.Write(byteImage, 0, byteImage.Length);
        //            Image imgMain = Image.FromStream(ms, true);

        //            picMain.EditValue = imgMain;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.Write(ex.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //            reader.Dispose();
        //            reader = null;
        //        }
        //        if(ms != null)
        //        {
        //            ms.Close();
        //            ms.Dispose();
        //            ms = null;
        //        }
        //    }
        //}

        private void InitSetting()
        {
            CMultiProject.Editable = true;

            CMultiProject.ErrorView = ucErrorView;
            CMultiProject.ErrorLogTable = ucErrorLogTable;
            CMultiProject.RobotCycle = ucSymbolValue.RobotCycle;
            CMultiProject.PlcSummary = ucSummary;
            ucSummary.UEventPanelDoubleClick += ucSumErrorAlarmView_UEventErrorAlarmGroupClicked;
            CMultiProject.PlcFlowChart = ucFlowChart;
            ucFlowChart.UEventPanelDoubleClick += ucSumErrorAlarmView_UEventErrorAlarmGroupClicked;
            ucFlowChart.UEventManualCycleOverTagKey += ucFlowPanelS_ManualCycleOverTagKeyClick;
            CMultiProject.PlcCycle = ucPlcCycle;

            CMultiProject.StepLadderView = ucStepLadderView;
            ucStepLadderView.UEventSendTagS += ucStepLadderView_UEventSendTags;
            ucStepLadderView.UEventSendAddTagS += ucStepLadderView_UEventSendAddTags;
            ucStepLadderView.UEventSendRemoveTagS += ucStepLadderView_UEventSendRemoveTagS;
            ucStepLadderView.UEventCloseSPD += ucStepLadderView_UEventCloseSPD;

            m_cAnalyzer.RobotCycle = ucSymbolValue.RobotCycle;
            m_cAnalyzer.CollectGrid = ucSymbolValue.CollectGrid;
            m_cAnalyzer.UserAllGrid = ucSymbolValue.UserAllGrid;
            m_cAnalyzer.UserWordGrid = ucSymbolValue.UserWordGrid;

            bool bOK = m_cReader.Connect();
            if (bOK == false)
            {
                XtraMessageBox.Show("Can't connect Database!! Please check Database installation", "UDM Tracker",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSystemMessage("DBReader", "연결에 실패했습니다.");
                return;
            }

            CMultiProject.LogReader = m_cReader;

            chkMainTabHeader.Checked = false;
        }

        private CErrorInfo CreateCycleOverErrorInfo(string sProcessKey, CKeySymbol cFirstSymbol, CTimeLogS cCycleLogS)
        {
            CErrorInfo cErrInfo = new CErrorInfo();

            cErrInfo.ProjectID = CMultiProject.ProjectID;
            if (CMultiProject.PlcProcS.ContainsKey(sProcessKey))
                cErrInfo.CycleID = CMultiProject.PlcProcS[sProcessKey].CycleID + 1;
            else
                return null;

            cErrInfo.GroupKey = sProcessKey;
            cErrInfo.ErrorType = "CycleOver";

            if (cCycleLogS != null)
                cErrInfo.ErrorLogS = (CTimeLogS)cCycleLogS.Clone();
            else
                cErrInfo.ErrorLogS = new CTimeLogS();

            cErrInfo.ErrorMessage = string.Format("{0} Cycle Over", sProcessKey);
            cErrInfo.DetailErrorMessage = cFirstSymbol.Description;
            cErrInfo.ErrorTime = DateTime.Now;
            cErrInfo.SymbolKey = cFirstSymbol.Tag.Key;
            cErrInfo.ErrorID = CMultiProject.ErrorIDCur++;
            cErrInfo.Value = -99;

            //준표 추가
            cErrInfo.CycleStart = m_dicProcessCycleStart[sProcessKey];
            cErrInfo.CurrentRecipe = m_dicProcessRecipe[sProcessKey];

            //Memory 최적화
            //cCycleLogS.Dispose();
            //cCycleLogS = null;

            return cErrInfo;
        }

        private void ShowTrackerMode()
        {
            if (CMultiProject.LearningStep == EMMonitorModeType.UpdateEnd &&
                     CMultiProject.MasterStep == EMMonitorModeType.UpdateEnd)
            {
                chkErrorDetectMode.Checked = true;
            }
            else
            {
                chkLearningMode.Checked = true;
            }
        }

        private void ucFlowPanelS_ManualCycleOverClick(string sProcessName)
        {
            ucPlcCycle.UpdateCycleOver(sProcessName);
            m_cAnalyzer.GenerateCycleOver(sProcessName);
        }

        private void ucFlowPanelS_ManualCycleOverTagKeyClick(string sProcessName, string sTagKey)
        {
            try
            {
                CPlcProc cProcess = CMultiProject.PlcProcS[sProcessName];

                if (!cProcess.CycleStartFlag) return;
                cProcess.CycleErrorFlag = true;

                ucPlcCycle.UpdateCycleOver(sProcessName);
                UEventManualCycleOverError(sProcessName, sTagKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
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
                m_cAnalyzer.UEventCycleEnd += m_cAnalyzer_UEventCycleEnd;
                m_cAnalyzer.UEventCycleCheck += m_cAnalyzer_UEventCycleCheck;
                m_cAnalyzer.UEventMaxCycleOver += m_cAnalyzer_UEventMaxCycleOver;
                m_cAnalyzer.UEventInterlockError += m_cAnalyzer_UEventInterlockError;
                m_cAnalyzer.UEventRobotCycleOn += m_cAnalyzer_UEventRobotCycleOn;
                m_cAnalyzer.UEventUpdateFlowChart += m_cAnalyzer_UEVentUpdateFlowChart;
                m_cAnalyzer.UEventRuntimeGridUpdate += m_cAnalyzer_UpdateSymbolValueGrid;
                m_cAnalyzer.UEventUserDeviceGridUpdate += m_cAnalyzer_UpdateUserDeviceValueGrid;
                m_cRecipeChecker.UEventNewRecipeChecked += m_cRecipeChecker_NewRecipeChecked;
                m_cRecipeChecker.UEventNewRecipeChanged += m_cRecipeChecker_RecipeChangeChecked;
                m_cLogWriter.UEventMessage += m_cLogWriter_UEventMessage;
                m_cErrorAnalyzer.UEventMessage += m_cLogWriter_UEventMessage;
            }
            else
            {
                m_cTrackerServer.UEventTimeLogS -= m_cTrackerServer_UEventTimeLogS;
                m_cTrackerServer.UEventEmergTimeLogS -= m_cTrackerServer_UEventEmergTimeLogS;
                m_cAnalyzer.UEventMessage -= m_cAnalyzer_UEventMessage;
                m_cAnalyzer.UEventCycleStart -= m_cAnalyzer_UEventCycleStart;
                m_cAnalyzer.UEventCycleEnd -= m_cAnalyzer_UEventCycleEnd;
                m_cAnalyzer.UEventCycleCheck -= m_cAnalyzer_UEventCycleCheck;
                m_cAnalyzer.UEventInterlockError -= m_cAnalyzer_UEventInterlockError;
                m_cAnalyzer.UEventMaxCycleOver -= m_cAnalyzer_UEventMaxCycleOver;
                m_cAnalyzer.UEventRobotCycleOn -= m_cAnalyzer_UEventRobotCycleOn;
                m_cAnalyzer.UEventUpdateFlowChart -= m_cAnalyzer_UEVentUpdateFlowChart;
                m_cAnalyzer.UEventRuntimeGridUpdate -= m_cAnalyzer_UpdateSymbolValueGrid;
                m_cAnalyzer.UEventUserDeviceGridUpdate -= m_cAnalyzer_UpdateUserDeviceValueGrid;
                m_cRecipeChecker.UEventNewRecipeChecked -= m_cRecipeChecker_NewRecipeChecked;
                m_cRecipeChecker.UEventNewRecipeChanged -= m_cRecipeChecker_RecipeChangeChecked;
                m_cLogWriter.UEventMessage -= m_cLogWriter_UEventMessage;
                m_cErrorAnalyzer.UEventMessage -= m_cLogWriter_UEventMessage;
            }
        }

        private void SaveProject(string sPath)
        {
            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            CShowWaitForm.ShowForm("Save Project", string.Format("Save Path :\r\n{0}", sPath), "Start...", true);
            {
                string sMessage = "";
                bool bOK = CMultiProject.Save(sPath, out sMessage);
                if (bOK)
                {
                    UpdateSystemMessage("저장", "저장에 성공했습니다.");
                    WriteLastUpmPath();
                    m_cTrackerClient.SendProjectInfoToServer();
                }
                else
                    UpdateSystemMessage("저장실패", sMessage);

                GC.Collect();
            }
            //SplashScreenManager.CloseForm(false);
            CShowWaitForm.CloseForm();
        }

        private void AddRecipeCheckTagS()
        {
            m_cRecipeCheckTagS.Clear();

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.SelectRecipeWord != null)
                    m_cRecipeCheckTagS.Add(who.Value.SelectRecipeWord);
            }
        }

        private void AnalyzeRecipe(CTimeLogS cLogS)
        {
            foreach (CTimeLog cLog in cLogS)
            {
                if (m_cRecipeCheckTagS.ContainsKey(cLog.Key))
                    AnalyzeRecipe(cLog);
            }
        }

        private void AnalyzeRecipe(CTimeLog cLog)
        {
            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.SelectRecipeWord == null) continue;
                if (cLog.Key == who.Value.SelectRecipeWord.Key)
                {
                    who.Value.CurrentRecipe = cLog.Value.ToString();// GetRecipeName(cLog.Value);
                }
            }
        }

        private string GetRecipeName(int iValue)
        {
            CRecipeSection cRecipeSection = CMultiProject.ProjectInfo.ViewRecipe;
            string sResult = "";

            int iSumValue = 0;
            cRecipeSection.BitPosList.Sort();

            for (int i = 0; i < cRecipeSection.BitPosList.Count; i++)
            {
                int iBitValue = iValue & (0x1 << cRecipeSection.BitPosList[i]);
                if (iBitValue > 0)
                    iSumValue += 0x1 << cRecipeSection.BitPosList[i];
            }

            for (int i = 0; i < cRecipeSection.SectionItemList.Count; i++)
            {
                CRecipeSectionItem cItem = cRecipeSection.SectionItemList[i];
                if (cItem.ItemValue == iSumValue)
                {
                    sResult = cItem.ItemName;
                    break;
                }
            }
            return sResult;
        }

        private bool CheckLSOPCServerOpen()
        {
            bool bOK = false;

            if (CMultiProject.PlcLogicDataS.Where(x => x.Value.Maker == EMPLCMaker.LS).Count() == 0)
                return true;

            Process[] arrOPCProcess = System.Diagnostics.Process.GetProcessesByName("LGOPCConfig");

            if (arrOPCProcess.Length > 0)
                bOK = true;
            else
            {
                XtraMessageBox.Show("LS OPC Server가 꺼져 있습니다.\r\nLS OPC Server를 먼저 실행시켜주세요.", "OPC Connect Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                bOK = false;
            }

            return bOK;
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "")
            {
                XtraMessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                XtraMessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void FrmMasterPatternUpdate_MasterPatternGenerateEvent(bool bOK)
        {
            try
            {
                if (bOK)
                {
                    CMultiProject.MasterStep = EMMonitorModeType.UpdateEnd;
                    ShowTrackerMode();

                    ucFlowChart.CreateFlowChart();
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        //PLC 별 OPC Connection 확인
        private void CheckOPCConnection(bool bCallFormLoaded)
        {
            bool bOK = false;
            string sOPCCon = "";
            try
            {
                foreach (CPlcConfig cConfig in CMultiProject.PlcConfigS.Values)
                {
                    if (cConfig.OPCConfig != null)
                    {
                        //PLC ID
                        COPCServer cOPCServer = new COPCServer();
                        cOPCServer.Config = cConfig.OPCConfig;
                        cOPCServer.Config.Use = true;

                        bOK = cOPCServer.Connect();

                        if (bOK)
                            sOPCCon += cConfig.PlcID + " : Connect,";
                        else
                            sOPCCon += cConfig.PlcID + " : Nonconnect,";

                        cOPCServer.Disconnect();
                        cOPCServer.Dispose();
                        cOPCServer = null;
                    }

                    Thread.Sleep(100);
                }
                sOPCCon = sOPCCon.Substring(0, sOPCCon.LastIndexOf(','));
                string[] saData = { "Tracker", "OPC", sOPCCon, bCallFormLoaded.ToString() };
                m_cTrackerClient.SendStatusToServer(saData);
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private CFlowItemS GetMasterFlowItemS(string sProcessName, string sRecipe)
        {
            CFlowItemS cItemS = null;

            if (!CMultiProject.MasterPatternS.ContainsKey(sProcessName) ||
                CMultiProject.MasterPatternS[sProcessName].Count == 0)
                return null;

            if (sRecipe != null && CMultiProject.MasterPatternS[sProcessName].ContainsKey(sRecipe))
            {
                if (CMultiProject.MasterPatternS[sProcessName][sRecipe].Count != 0)
                    cItemS = CMultiProject.MasterPatternS[sProcessName][sRecipe].First().FlowItemS;
            }
            else
            {
                if (CMultiProject.MasterPatternS[sProcessName].First().Value.Count != 0)
                    cItemS = CMultiProject.MasterPatternS[sProcessName].First().Value.First().FlowItemS;
            }

            return cItemS;
        }

        private bool CheckLastOFFKeySymbol(int iCurrentIndex, CTimeLogS cLogS, CFlowItemS cItemS)
        {
            bool bOK = true;

            if ((cItemS.Count - 1) == iCurrentIndex)
                return true;

            string sFlowKey = string.Empty;

            for (int i = iCurrentIndex + 1; i < cItemS.Count; i++)
            {
                sFlowKey = cItemS[i].Key;

                if (cLogS.Where(x => x.Key == sFlowKey && x.Value > 0).Count() > 0)
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckTrackerProcess(string sName)
        {
            bool bOK = false;

            try
            {
                Process[] arrProcessTracker = Process.GetProcessesByName(sName);
                if (arrProcessTracker != null && arrProcessTracker.Length > 1)
                    bOK = true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }

            return bOK;
        }

        private void FrmModel_CreateFlowChart()
        {
            try
            {
                ucFlowChart.CreateFlowChart();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmModel_ClearFlowChart()
        {
            try
            {
                ucFlowChart.ClearFlowChartDocuments();
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cLogWriter_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void ucSumErrorAlarmView_UEventErrorAlarmGroupClicked()
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCErrorView");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
                ucErrorView.InitialErrorView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucStepLadderView_UEventSendTags(CPlcConfig cPlcConfig, CTagS cTags)
        {
            string sPlc = "Tracker," + cPlcConfig.PlcID;
            string[] saData = { sPlc, CMultiProject.ConfigFilePath };

            bool bOK = m_cTrackerServer.SendCollectorList(saData);

            if (bOK)
                m_cTrackerServer.SendLadderViewTagList(cPlcConfig, cTags, false);

            m_cTrackerServer.UEventLadderViewTimeLogS += m_cTrackerServer_UEventLadderViewTimeLogS;
        }

        private void ucStepLadderView_UEventSendAddTags(CPlcConfig cConfig, CTagS cTags)
        {
            m_cTrackerServer.SendLadderViewTagList(cConfig, cTags, true);
        }

        private void ucStepLadderView_UEventSendRemoveTagS(CPlcConfig cConfig, CTagS cTags)
        {
            m_cTrackerServer.SendLadderViewRemoveTagList(cConfig, cTags);
        }

        private void ucStepLadderView_UEventCloseSPD(string sPlc)
        {
            m_cTrackerServer.UEventLadderViewTimeLogS -= m_cTrackerServer_UEventLadderViewTimeLogS;

            string[] saData = { sPlc, "Close" };
            m_cTrackerServer.SendStopCommand(saData);
        }

        private void m_cAnalyzer_UpdateSymbolValueGrid()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTagFinderCallback cUpdate = new UpdateTagFinderCallback(m_cAnalyzer_UpdateSymbolValueGrid);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    ucSymbolValue.CollectGrid.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UpdateUserDeviceValueGrid()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTagFinderCallback cUpdate = new UpdateTagFinderCallback(m_cAnalyzer_UpdateUserDeviceValueGrid);
                    this.Invoke(cUpdate, new object[] { });
                }
                else
                {
                    ucSymbolValue.UserAllGrid.RefreshDataSource();
                    ucSymbolValue.UserWordGrid.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void SetRecipeViewer(List<CNewRecipeView> lstRecipeView)
        {
            try
            {
                if (m_frmViewer == null || m_frmViewer.IsDisposed)
                {
                    m_frmViewer = new FrmNewRecipeViewer();
                    m_frmViewer.RecipeViewS = lstRecipeView;
                    m_frmViewer.TopMost = true;
                    m_frmViewer.Show();
                }
                else
                    m_frmViewer.RecipeViewS = lstRecipeView;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void DisposeRecipeViewer()
        {
            if (m_frmViewer != null)
                m_frmViewer.Dispose();

            m_frmViewer = null;
        }

        private void m_cRecipeChecker_RecipeChangeChecked(List<CNewRecipeView> lstRecipeView)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNewRecipeCallback2 cUpdate = new UpdateNewRecipeCallback2(m_cRecipeChecker_RecipeChangeChecked);
                    this.Invoke(cUpdate, new object[] { lstRecipeView });
                }
                else
                {
                    SetRecipeViewer(lstRecipeView);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cRecipeChecker_NewRecipeChecked(Dictionary<string, CCycleInfoS> dicProcessCycleInfoS)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNewRecipeCallback cUpdate = new UpdateNewRecipeCallback(m_cRecipeChecker_NewRecipeChecked);
                    this.Invoke(cUpdate, new object[] { dicProcessCycleInfoS });
                }
                else
                {
                    bool bOK = false;

                    btnMonitorStop_Click(null, null);

                    if (m_frmViewer != null && !m_frmViewer.IsDisposed)
                        m_frmViewer.SetMasterPatternGenPanel();

                    FrmMasterPatternUpdate frmMaster = new FrmMasterPatternUpdate();
                    frmMaster.SetDescription("새로운 Recipe에 해당하는 마스터 패턴을 자동 생성 중입니다.");
                    frmMaster.TopMost = true;
                    frmMaster.Show();
                    if (frmMaster.CreateNewRecipeMasterPattern(dicProcessCycleInfoS))
                        bOK = true;

                    frmMaster.Dispose();
                    frmMaster = null;

                    if (bOK)
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            ucFlowChart.CreateFlowChart();
                            CMultiProject.Refresh();
                        }
                        SplashScreenManager.CloseForm(false);
                    }

                    tmrNewRecipe.Start();
                    //저장 및 Timer 걸어서 진행
                    //m_bMntAutoStart = true;
                    //btnMonitorStart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cOptimizer_Optimization(bool bAllProcess, string sProcess, bool bLastFrequency,
            bool bFrequencyCompl)
        {
            try
            {
                if (!m_frmCollectOptimizer.IsLoad)
                    return;

                m_frmCollectOptimizer.StartOptimization(bAllProcess, sProcess, bLastFrequency, bFrequencyCompl);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cOptimizer_SystemMessage(string sSender, string sMessage)
        {
            try
            {
                if (!m_frmCollectOptimizer.IsLoad)
                    return;

                m_frmCollectOptimizer.UpdateOptimizerMessage(sSender, sMessage);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cOptimizer_OptimizationMessage(string sProcess, string sSender, string sMessage)
        {
            try
            {
                if (!m_frmCollectOptimizer.IsLoad)
                    return;

                m_frmCollectOptimizer.UpdateOptimizationMessage(sProcess, sSender, sMessage);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cOptimizer_UpdateGrid()
        {
            try
            {
                if (!m_frmCollectOptimizer.IsLoad)
                    return;

                m_frmCollectOptimizer.UpdateGrid();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_frmCollectOptimizer_MonitorStartEvent(bool bMonitorStartFirst, bool bAllProcess, string sProcess)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateOptimizerMonitorStartCallback cUpdate = new UpdateOptimizerMonitorStartCallback(m_frmCollectOptimizer_MonitorStartEvent);
                    this.Invoke(cUpdate, new object[] { bMonitorStartFirst, bAllProcess, sProcess });
                }
                else
                {
                    m_bMntAutoStart = true;
                    m_bOptimizerMode = true;

                    if (bMonitorStartFirst)
                    {
                        m_cOptimizer.OptimizerSelectionList = m_frmCollectOptimizer.OptimizerSelectionList;
                        m_cOptimizer.OptimizerViewList = m_frmCollectOptimizer.OptimizerViewList;
                        m_cOptimizer.UEventOptimization += m_cOptimizer_Optimization;
                        m_cOptimizer.UEventSystemMessage += m_cOptimizer_SystemMessage;
                        m_cOptimizer.UEventOptimizationMessage += m_cOptimizer_OptimizationMessage;
                        m_cOptimizer.UEventUpdateGrid += m_cOptimizer_UpdateGrid;
                        m_cOptimizer.Run();
                    }

                    //bAllProcess일 땐 sProcess = string.Empty;
                    m_sSelectedProcess = sProcess;
                    btnMonitorStart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_frmCollectOptimizer_MonitorStopEvent(bool bMonitoringEnd)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateOptimizerMonitorStopCallback cUpdate = new UpdateOptimizerMonitorStopCallback(m_frmCollectOptimizer_MonitorStopEvent);
                    this.Invoke(cUpdate, new object[] {bMonitoringEnd});
                }
                else
                {
                    if (bMonitoringEnd)
                    {
                        m_bOptimizerMode = false;
                        m_cOptimizer.Stop();
                        m_cOptimizer.UEventOptimization -= m_cOptimizer_Optimization;
                        m_cOptimizer.UEventSystemMessage -= m_cOptimizer_SystemMessage;
                        m_cOptimizer.UEventUpdateGrid -= m_cOptimizer_UpdateGrid;
                        m_cOptimizer.UEventOptimizationMessage -= m_cOptimizer_OptimizationMessage;
                    }

                    m_sSelectedProcess = string.Empty;
                    btnMonitorStop_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        private bool CheckAllProcessMasterPatternExist()
        {
            bool bOK = false;

            if (CMultiProject.MasterPatternS == null || CMultiProject.MasterPatternS.Count == 0)
            {
                XtraMessageBox.Show(
                    "감지 모드는 학습 모드를 통해 공정 세팅 및 마스터 패턴 생성을 완료하게 되면 자동으로 설정됩니다.\r\n현재 모든 공정의 마스터 패턴이 생성되지 않았기 때문에 감지 모드를 진행할 수 없습니다.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string sNotExist = string.Empty;
            bool bNotExist = false;

            foreach (var who in CMultiProject.PlcProcS)
            {
                if (who.Value.IsErrorMonitoring)
                    continue;

                if (!CMultiProject.MasterPatternS.ContainsKey(who.Value.Name))
                {
                    bNotExist = true;
                    sNotExist += who.Value.Name + ", ";
                }
            }

            if (bNotExist)
            {
                sNotExist = sNotExist.Substring(0, sNotExist.Length - 2);
                if (
                    XtraMessageBox.Show(
                        "\'" + sNotExist +
                        "\' 공정의 마스터 패턴이 생성되지 않은 상황입니다.\r\n마스터 패턴이 생성되지 않으면 무언 정지 상황에 대한 이상 감지를 진행할 수 없습니다.\r\n그래도 감지 모드로 변경하시겠습니까?",
                        "경고!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    bOK = false;
                else
                    bOK = true;
            }
            else
                bOK = true;

            return bOK;
        }

        private void SendAllTagSToTrackerReader()
        {
            Dictionary<string, List<string>> dicPlcSendItem = new Dictionary<string, List<string>>();
            UpdateSystemMessage("Server", string.Format("Tracker Reader All TagS Clear"));
            string[] saData = { "ClearTagS" };
            m_cTrackerServer.SendTagList(saData);

            string sFilePath = string.Format("{0}\\TrackerReaderAllTagS.tags", Application.StartupPath);

            CMultiProject.SaveTotalTag(sFilePath);

            string[] saData2 = { "SaveAllTagS", sFilePath };
            m_cTrackerServer.SendTagList(saData2);
        }

        private void LoadMainLayout()
        {
            try
            {
                string sPath = Application.StartupPath + "\\MainLayout.xml";

                if (!File.Exists(sPath))
                    return;

                tabView.RestoreLayoutFromXml(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SaveMainLayout()
        {
            try
            {
                string sPath = Application.StartupPath + "\\MainLayout.xml";
                tabView.SaveLayoutToXml(sPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ComposeKeySymbolS()
        {
            try
            {
                CPlcLogicData cData = null;

                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    if(cProcess.PlcLogicDataS == null)
                        cProcess.PlcLogicDataS = new CPlcLogicDataS();

                    foreach (CKeySymbol cKeySymbol in cProcess.KeySymbolS.Values)
                    {
                        if (cKeySymbol.TagKey != null && cKeySymbol.TagKey != string.Empty)
                            cKeySymbol.Tag = CMultiProject.TotalTagS[cKeySymbol.TagKey];

                        if (cProcess.ChartViewTagS == null)
                            cProcess.ChartViewTagS = new CTagS();

                        if (!cProcess.ChartViewTagS.ContainsKey(cKeySymbol.TagKey))
                            cProcess.ChartViewTagS.Add(cKeySymbol.Tag);

                        if (cKeySymbol.AllSubDepthTagKeyList == null)
                            cKeySymbol.AllSubDepthTagKeyList = new List<string>();

                        if (!cProcess.IsErrorMonitoring)
                        {
                            if (cKeySymbol.Tag != null)
                            {
                                cData = CMultiProject.GetPlcLogicData(cKeySymbol.Tag);

                                if(cData != null && !cProcess.PlcLogicDataS.ContainsKey(cData.PLCID))
                                    cProcess.PlcLogicDataS.Add(cData.PLCID, cData);
                            }
                        }
                        else if (cProcess.TotalAbnormalSymbolKey != string.Empty)
                        {
                            if (CMultiProject.TotalTagS.ContainsKey(cProcess.TotalAbnormalSymbolKey))
                            {
                                cData = CMultiProject.GetPlcLogicData(CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey]);

                                if (cData != null && !cProcess.PlcLogicDataS.ContainsKey(cData.PLCID))
                                    cProcess.PlcLogicDataS.Add(cData.PLCID, cData);
                            }
                        }
                    }
                    cProcess.CollectSubDepth = CMultiProject.ProjectInfo.CollectSymbolSubDepth;
                    //cProcess.ComposeKeySymbolS();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ComposeAbnormalSymbolS()
        {
            if (CMultiProject.AbnormalFilter == null || CMultiProject.AbnormalFilter.Count == 0)
                CMultiProject.AbnormalFilter = CMultiProject.GetAbnormalFilter();

            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                if (cProcess.AbnormalSymbolS == null)
                    cProcess.AbnormalSymbolS = new CAbnormalSymbolS();

                if (cProcess.AbnormalSymbolList == null)
                    cProcess.AbnormalSymbolList = new List<string>();

                cProcess.AbnormalFilter = CMultiProject.GetAbnormalFilter();

                if (cProcess.TotalAbnormalSymbolKey == string.Empty)
                    continue;

                cProcess.ComposeAbnormalSymbolS(CMultiProject.TotalTagS[cProcess.TotalAbnormalSymbolKey]);
                cProcess.UpdateAbnormalSymbolS();
                CMultiProject.UpdatePlcProcHierarchyAbnormalSymbolS();
            }
        }

        private bool CheckSPDSingleStateNormal()
        {
            bool bOK = false;
            string sSPDSingle = string.Empty;

            if (m_dicSPDStatusDisconnectCount == null)
                return true;

            if (m_dicSPDStatusDisconnectCount.Any(x => x.Value > 0))
            {
                foreach (var who in m_dicSPDStatusDisconnectCount)
                {
                    if (who.Value > 0)
                        sSPDSingle += string.Format("{0},", who.Key);
                }

                sSPDSingle = sSPDSingle.Substring(0, sSPDSingle.Length - 1);
                AutoClosingMessageBox.Show(
                    string.Format("{0} SPD Single이 반응이 없습니다.\r\nOPC 연결을 확인 후 Tracker를 다시 시작해주세요.", sSPDSingle),
                    "SPD Single Error", 30000);
            }
            else bOK = true;

            return bOK;
        }

        #endregion


        #region Event Methods

        #region Form Event

        #region Main Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (CheckTrackerProcess("UDMTrackerSimple"))
                {
                    XtraMessageBox.Show("Tracker가 이미 실행중입니다.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_bTrackerAlive = true;
                    this.Close();
                    return;
                }
                else
                    m_bTrackerAlive = false;

                bool bOK = m_cTrackerServer.StartServer();
                if (bOK == false)
                {
                    XtraMessageBox.Show("Collect Manager가 실행되지 않았습니다.", "Tracker Reader", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                //Tracker Client 추가
                bOK = m_cTrackerClient.ClientConnect();
                if (bOK == false)
                {
                    XtraMessageBox.Show("Tracker Manager와 연결에 실패했습니다.", "Tracker Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (CheckTrackerProcess("UDMTrackerManager") == false)
                        Process.Start(Application.StartupPath + "\\UDMTrackerManager.exe");
                    this.Close();
                    return;
                }

                //Default
                chkMariaDB.Checked = true;

                CMultiProject.SystemLog = new CSystemLog(m_sSysLogPath, "Tracker");
                tmrSystemLog.Start();
                m_cTrackerServer.UEventMessage += m_cTrackerServer_UEventMessage;
                m_cTrackerServer.UEventSPDStatus += m_cTrackerServer_UEventSPDStatus;
                m_cTrackerServer.UEventLadderViewSPDStatus += m_cTrackerServer_UEventLadderViewSPDStatus;
                m_cTrackerServer.UEventClientConnect += m_cTrackerServer_UEventClientConnect;
                m_cTrackerServer.UnknownErrorClient = m_dicSPDStatusDisconnectCount;

                m_cTrackerClient.UEventMessage += m_cTrackerClient_UEventMessage;
                m_cTrackerClient.UEventMonitoringStart += m_cTrackerClient_UEventMonitoringStart;
                m_cTrackerClient.UEventMonitoringStop += m_cTrackerClient_UEventMonitoringStop;

                Process[] aProcess = Process.GetProcessesByName("UDMSPDManager");
                if (aProcess.Length > 0)
                    CMultiProject.SystemLog.WriteLog("SPDManager", "처음실행을 위해 기존 SPD Manager를 강제 종료합니다.  " + aProcess.Length.ToString());
                foreach (Process pro in aProcess)
                    pro.Kill();

                Process proSPDManager = new Process();
                proSPDManager.StartInfo.FileName = Application.StartupPath + "\\UDMSPDManager.exe";
                proSPDManager.Start();
                CMultiProject.SystemLog.WriteLog("SPDManager", "실행합니다.");
                InitSetting();
                LoadMainLayout();
                toggMainEditorMode.Checked = false;

                if (m_cTrackerClient != null && m_cTrackerClient.IsConnected)
                {
                    string[] saMess = { "Tracker", "Tracker 실행 성공!!" };
                    m_cTrackerClient.SendMessageToServer(saMess);
                }

                m_frmCollectOptimizer = new FrmCollectOptimizer();
                m_frmCollectOptimizer.UEventOptimizerMonitorStart += m_frmCollectOptimizer_MonitorStartEvent;
                m_frmCollectOptimizer.UEventOptimizerMonitorStop += m_frmCollectOptimizer_MonitorStopEvent;
                m_frmCollectOptimizer.TopMost = true;

                tmrLoadFirst.Start();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!m_bTrackerAlive)
                {
                    if (m_cTrackerServer.IsRunning)
                    {
                        XtraMessageBox.Show("Please stop monitoring first!!", "UDM Tracker", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        UpdateSystemMessage("FormClosing", "현재 수집 중입니다. 정지 후 다시 시도");
                        e.Cancel = true;
                        return;
                    }
                    else if (toggAdministratorMode.Checked == false)
                    {
                        XtraMessageBox.Show("Administrator mode.\r\nYou can only exit before switching.", "UDM Tracker", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        UpdateSystemMessage("FormClosing", "관리자 모드입니다. 전환후 종료 할 수 있습니다.");
                        e.Cancel = true;
                        return;
                    }

                    if (m_frmCollectOptimizer != null)
                    {
                        m_frmCollectOptimizer.UEventOptimizerMonitorStart -= m_frmCollectOptimizer_MonitorStartEvent;
                        m_frmCollectOptimizer.UEventOptimizerMonitorStop -= m_frmCollectOptimizer_MonitorStopEvent;
                        m_frmCollectOptimizer.Dispose();
                    }
                    m_frmCollectOptimizer = null;

                    if (m_cTrackerClient != null && m_cTrackerClient.IsConnected)
                    {
                        string[] saMess = { "Tracker", "Tracker 종료 성공!!" };
                        m_cTrackerClient.SendMessageToServer(saMess);
                        m_cTrackerClient.ClientDisconnect();
                    }

                    if (ucStepLadderView != null && ucStepLadderView.IsRunning)
                        ucStepLadderView.Stop();

                    CShowWaitForm.ShowForm("Close Tracker", "Close Safety to SPD (Data Collector)\r\nPlease Wait...", "Close...", true);
                    {
                        m_cTrackerServer.SPDClose();

                        Thread.Sleep(5000);

                        m_cTrackerServer.StopServer();
                        tmrSystemLog.Stop();
                    }
                    CShowWaitForm.CloseForm();

                    //Process[] aProcess = Process.GetProcessesByName("UDMSPDSingle");
                    //foreach (Process pro in aProcess)
                    //    pro.Kill();

                    //aProcess = Process.GetProcessesByName("UDMSPDManager");
                    //foreach (Process pro in aProcess)
                    //    pro.Kill();

                    CMultiProject.SystemLog.WriteLog("FormClose", "모든 프로세스를 종료 했습니다.");
                    CMultiProject.SystemLog.WriteEndLog();

                    Process[] aProcess = Process.GetProcessesByName("UDMTrackerSimple");

                    foreach (Process pro in aProcess)
                        pro.Kill();
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrSystemLog_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrSystemLog.Enabled = false;

                try
                {
                    if (CMultiProject.SystemLog != null)
                    {
                        CMultiProject.SystemLog.WriteLog("SystemLog", "새로운 파일을 생성합니다.(주기 1시간)");
                        string sFileName = CMultiProject.SystemLog.FileName;
                        CMultiProject.SystemLog.WriteEndLog();

                        CMultiProject.SystemLog = new CSystemLog(m_sSysLogPath, "Tracker");

                        CMultiProject.SystemLog.WriteLog("SystemLog", "이전 파일 : " + sFileName);
                    }
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("SystemLog", "Error : " + ex.Message);
                    ex.Data.Clear();
                }

                tmrSystemLog.Enabled = true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion


        #region File Button

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
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

                //ucStepLadderView.Clear(); // 새로운 프로젝트를 열때만 실행하도록

                UpdateSystemMessage("열기", "프로젝트 열기를 시작 : " + sPath);
                if (sPath != "")
                {
                    bool bOK = false;
                    string sMessage = "";

                    CShowWaitForm.ShowForm("Open Project", string.Format("Open Path :\r\n{0}", sPath), "Start...", true);
                    {
                        bOK = CMultiProject.Open(sPath, out sMessage);

                        if (bOK)
                        {
                            CShowWaitForm.UpdateText("Set Project", "화면 초기화, 공정 설정 표시, 수집기 자동 연결, ", "Setting...");
                            UpdateSystemMessage("열기", "성공");
                            tmrSPDStatusCheck.Stop();
                            CheckProjectNullProperties();

                            ComposeKeySymbolS();
                            ComposeAbnormalSymbolS();

                            if (CMultiProject.LearningStep == EMMonitorModeType.None)
                                btnMakeMasterPattern.Enabled = false;

                            CMultiProject.Refresh();
                            ShowTrackerMode();
                            CheckDBRealtedPath();

                            if (CMultiProject.IsProjectBaseView)
                                chkProjectBaseView.Checked = true;
                            else
                                chkPlcBaseView.Checked = true;

                            ucSymbolValue.UserAllGrid.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                            ucSymbolValue.UserAllGrid.RefreshDataSource();

                            ucSymbolValue.UserWordGrid.DataSource =
                                CMultiProject.UserDeviceS.Values.Where(
                                    b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
                            ucSymbolValue.UserWordGrid.RefreshDataSource();

                            ucFlowChart.ShowFlowChart();

                            CMultiProject.ProjectPath = sPath;
                            WriteLastUpmPath();

                            CMultiProject.PlcIDList.Clear();
                            foreach (var who in CMultiProject.PlcLogicDataS)
                                CMultiProject.PlcIDList.Add(who.Key);
                            if (CMultiProject.ProjectInfo.ViewRecipe == null)
                                CMultiProject.ProjectInfo.ViewRecipe = new CRecipeSection();
                            m_cTrackerClient.SendProjectInfoToServer();
                            btnSummary_Click(null, null);
                            tmrLoadSecond.Start();

                            CheckOPCConnection(true);

                            if (CMultiProject.Account == false)
                            {
                                if (toggMainEditorMode.Checked == true)
                                {
                                    exRibbon.Minimized = true;
                                    toggMainEditorMode.Checked = false;
                                }

                                if (toggAdministratorMode.Checked == true) toggAdministratorMode.Checked = false;

                                //btnCycle.Visible = false;
                                //btnMonitorStart.Enabled = false;
                                //btnMonitorStop.Enabled = false;
                                btnExitHMI.Visible = false;
                                toggMainEditorMode.Enabled = false;
                                btnExportPDF.Enabled = false;
                                this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})   <<Account : User>>", CMultiProject.ProjectName, CMultiProject.ProjectPath);
                                CMultiProject.Account = false;
                            }
                            else this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})   <<Account : Administrator>>", CMultiProject.ProjectName, CMultiProject.ProjectPath);
                        }
                        else
                            UpdateSystemMessage("열기실패", sMessage + "  문제가 있습니다.");

                        //GC.Collect();
                    }
                    CShowWaitForm.CloseForm();

                }
                else
                    UpdateSystemMessage("열기실패", "경로가 없습니다");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})", CMultiProject.ProjectName, CMultiProject.ProjectPath);
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})", CMultiProject.ProjectName, CMultiProject.ProjectPath);
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to exit program?", "UDM Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion


        #region Setting Button

        private void btnProjectSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmModel frmModel = new FrmModel();
                frmModel.UEventMessage += UpdateSystemMessage;
                frmModel.UEventFlowChart += FrmModel_CreateFlowChart;
                frmModel.UEventClearFlowChart += FrmModel_ClearFlowChart;
                frmModel.ShowDialog();

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

                GC.Collect();

                if (CMultiProject.LearningStep == EMMonitorModeType.None)
                    btnMakeMasterPattern.Enabled = false;

                ShowTrackerMode();

                ucSymbolValue.UserAllGrid.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                ucSymbolValue.UserAllGrid.RefreshDataSource();

                ucSymbolValue.UserWordGrid.DataSource =
                    CMultiProject.UserDeviceS.Values.Where(
                        b => b.DetailViewShow == true && b.DataType != EMDataType.Bool).ToList();
                ucSymbolValue.UserWordGrid.RefreshDataSource();

                CMultiProject.PlcIDList.Clear();
                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    CMultiProject.PlcIDList.Add(who.Key);
                }

                if (frmModel.IsSaveExcute || frmModel.IsChangePlcList || frmModel.IsMasterPatternEdit)
                {
                    btnSave_ItemClick(null, null);
                    CMultiProject.Refresh();
                }

                //SPD Single실행
                if (frmModel.IsChangePlcList)
                {
                    m_bLoadSPDSingle = false;
                    m_bLoadSPDSingle = m_cTrackerServer.SendCollectList();

                    SendAllTagSToTrackerReader();
                }

                btnSummary_Click(null, null);

                frmModel.Dispose();
                frmModel = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnUpdateMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                exEditorProcess.Items.Clear();

                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                    return;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.IsErrorMonitoring)
                        continue;

                    exEditorProcess.Items.Add(who.Key);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnEditMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                if (CMultiProject.MasterPatternS == null || CMultiProject.MasterPatternS.Count == 0)
                {
                    XtraMessageBox.Show("Master Pattern이 생성되지 않았습니다.\r\nMaster Pattern을 먼저 생성해 주세요.",
                        "View Master Pattern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FrmMasterPatternEditor frmEditor = new FrmMasterPatternEditor();
                frmEditor.Show();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion


        #region Button Click
        private void btnCycle_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCPlcCycle");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnErrorLogList_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCErrorLogTable");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnErrorDetail_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCErrorView");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
                ucErrorView.InitialErrorView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnCurrentValue_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCSymbolValue");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRTLadderView_Click(object sender, EventArgs e)
        {

        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCAllErrorAlarmView2");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnSummary_Click_1(object sender, EventArgs e)
        {
            try
            {
                BaseDocument doc = tabView.Documents.SingleOrDefault(x => x.ControlTypeName == "UCFlowChart");

                if (doc == null)
                    return;

                tabView.Controller.Activate(doc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExportPDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FrmReportExporter frmReport = new FrmReportExporter();
                frmReport.ShowDialog();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnExitHMI_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to exit program?", "UDM Tracker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    CMultiProject.Refresh();

                    btnSummary_Click(null, null);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion


        #region Check Box

        private void chkMonitorPatternItem_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            CMultiProject.MonitorType = EMMonitorType.Learning;

            string[] saData = { "Tracker", "MonitorType", "Learning" };
            m_cTrackerClient.SendStatusToServer(saData);
        }

        private void chkMonitorMasterPattern_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (!CheckAllProcessMasterPatternExist())
            {
                chkLearningMode.Checked = true;
                return;
            }

            CMultiProject.MonitorType = EMMonitorType.Detection;

            string[] saData = { "Tracker", "MonitorType", "Detection" };
            m_cTrackerClient.SendStatusToServer(saData);
        }

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


        #endregion


        private void btnMonitorStart_Click(object sender, EventArgs e)
        {
            try
            {
                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                if (!m_bLoadSPDSingle)
                {
                    XtraMessageBox.Show(
                        "SPD Single이 Load되지 않았습니다.\r\nSPD Manager 속 SPD Single이 제대로 Load 되었는지 확인하시길 바랍니다.",
                        "SPD Single Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (!CheckLSOPCServerOpen())
                //    return;

                if (!m_bMntAutoStart)
                {
                    string sMonitorType = string.Empty;
                    if (CMultiProject.MonitorType == EMMonitorType.Learning)
                        sMonitorType = "학습모드";
                    else if (CMultiProject.MonitorType == EMMonitorType.Detection)
                        sMonitorType = "감지모드";
                    
                    DialogResult dlgResult =
                        XtraMessageBox.Show(
                            string.Format("현재 Monitoring Mode는 \'{0}\' 입니다.\r\n수집을 시작하시겠습니까?",
                                sMonitorType), "Monitor Start", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                    if (dlgResult == System.Windows.Forms.DialogResult.No)
                        return;
                }

                m_bMntAutoStart = false;


                if (!CheckSPDSingleStateNormal())
                {
                    UpdateSystemMessage("SPD Single", "SPD Single이 반응이 없습니다.");
                    return;
                }

                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);

                UpdateSystemMessage("수집시작", "수집을 시작합니다.");
                HandlingRunningEvent(true);
                AddRecipeCheckTagS();
                CMultiProject.UserDeviceS.ClearCurrentValue();
                CMultiProject.ClearCurrentID();
                CMultiProject.ClearMemory();
                //CMultiProject.Refresh();

                UpdateSystemMessage("Frm Main", string.Format("Start Total Memory : {0:N0}", GC.GetTotalMemory(false)));
                
                CMultiProject.CurrentCollectSymbolS = new CCollectSymbolS();
                CMultiProject.CreateCollectSymbolS();

                if (m_cErrorAnalyzer.LogWriter == null)
                    m_cErrorAnalyzer.LogWriter = m_cLogWriter;
                m_dicCycleCount.Clear();
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (!m_dicProcessCycleStart.ContainsKey(who.Key))
                        m_dicProcessCycleStart.Add(who.Key, DateTime.MinValue);

                    if (!m_dicProcessRecipe.ContainsKey(who.Key))
                        m_dicProcessRecipe.Add(who.Key, string.Empty);

                    if (!m_dicCycleCount.ContainsKey(who.Key))
                        m_dicCycleCount.Add(who.Key, 0);
                }
                bOK = m_cLogWriter.Run();
                if (bOK == false)
                {
                    UpdateSystemMessage("시작실패", "LogWriter 시작 실패");
                    return;
                }

                bOK = m_cErrorAnalyzer.Run();
                if (!bOK)
                {
                    UpdateSystemMessage("시작실패", "Error Anlayzer 시작 실패");
                    m_cLogWriter.Stop();
                    return;
                }

                m_cAnalyzer.IsOptimizeMode = m_bOptimizerMode;
                m_cAnalyzer.SelectedProcess = m_sSelectedProcess;
                m_cAnalyzer.IsAutoDetect = m_bCycleOverAutoDetect;
                bOK = m_cAnalyzer.Run();
                if (bOK == false)
                {
                    UpdateSystemMessage("시작실패", "분석기 시작 실패");
                    m_cLogWriter.Stop();
                    m_cErrorAnalyzer.Stop();
                    return;
                }

                m_cTrackerServer.IsOptimizeMode = m_bOptimizerMode;
                m_cTrackerServer.SelectedProcess = m_sSelectedProcess;
                bOK = m_cTrackerServer.Run();
                if (bOK == false)
                {
                    UpdateSystemMessage("시작실패", "SPD 시작 실패");
                    m_cLogWriter.Stop();
                    m_cErrorAnalyzer.Stop();
                    m_cAnalyzer.Stop();
                    return;
                }

                if (CMultiProject.IsAutoUpdateRecipe)
                {
                    bOK = m_cRecipeChecker.Run();
                    if (bOK == false)
                    {
                        UpdateSystemMessage("시작실패", "RecipeChecker 시작 실패");
                        m_cLogWriter.Stop();
                        m_cErrorAnalyzer.Stop();
                        m_cAnalyzer.Stop();
                        m_cRecipeChecker.Stop();
                        return;
                    }
                }

                //PLC Connection 확인
                CheckOPCConnection(false);

                Thread.Sleep(10);

                if (CMultiProject.MonitorType == EMMonitorType.Detection)
                {
                    if (ucPlcCycle != null)
                        ucPlcCycle.Run();
                }

                if (ucSummary != null)
                    ucSummary.Run();

                if (ucFlowChart != null)
                {
                    ucFlowChart.Run();
                    ucFlowChart.ClearFlowChartActive();
                }

                Thread.Sleep(10);

                m_dicSendedSubDepth.Clear();

                foreach (var who in CMultiProject.TotalTagS)
                    who.Value.LogCount = 0;

                mnuDatabase.Enabled = false;
                ucSystemLogTable.AddMessage(DateTime.Now, "UDM Tracker", "Monitoring Start!!");
                btnMonitorStart.Enabled = false;
                btnMonitorStop.Enabled = true;

                if (CMultiProject.MonitorType == EMMonitorType.Learning)
                    btnCurrentValue_Click(null, null);
                else
                    btnSummary_Click_1(null, null);

                toggMainEditorMode.Checked = false;
                btnShowLogView.Enabled = false;
                btnOption.Enabled = false;
                mnuHomeFile.Enabled = false;

                string[] saData = { "Tracker", "Monitoring", "Start" };
                m_cTrackerClient.SendStatusToServer(saData);

                CMultiProject.IsRun = m_cTrackerServer.IsRunning;

                CMultiProject.LineInfoS.UEventLineInfoValueChanged += LineInfoS_UEventValueChanged;
                LineInfoS_UEventValueChanged(null);

            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        private void LineInfoS_UEventValueChanged(List<CLineInfoTag> lstLineTag)
        {
            //foreach (Form frm in Application.OpenForms)
            //{
            //    if (frm.GetType() == typeof(FrmProductionStateInfo))
            //    {
            //        FrmProductionStateInfo frmProductioninfo = (FrmProductionStateInfo)frm;
            //        frmProductioninfo.UpdateProductionStateInfo();// LineInfoValueChanged();
            //    }
            //}
        }


        private void btnMonitorStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cTrackerServer.IsRunning == true)
                {
                    UpdateSystemMessage("수집정지", "모든SPD를 정지 합니다.");

                    m_cTrackerServer.SPDStop();

                    mnuDatabase.Enabled = true;
                    ucSystemLogTable.AddMessage(DateTime.Now, "UDM Tracker", "Monitor Stop");

                    ShowTrackerMode();
                    HandlingRunningEvent(false);
                    m_cLogWriter.Stop();
                    m_cErrorAnalyzer.Stop();
                    m_cAnalyzer.Stop();
                    if (CMultiProject.IsAutoUpdateRecipe)
                        m_cRecipeChecker.Stop();
                    ucPlcCycle.Stop();
                    ucSummary.Stop();
                    ucFlowChart.Stop();

                    //btnSave_ItemClick(null, null);

                    btnMonitorStart.Enabled = true;
                    btnMonitorStop.Enabled = false;
                    btnShowLogView.Enabled = true;
                    btnOption.Enabled = true;
                    mnuHomeFile.Enabled = true;

                    if (CMultiProject.LearningStep != EMMonitorModeType.UpdateEnd || CMultiProject.MasterStep != EMMonitorModeType.UpdateEnd)
                        toggMainEditorMode.Checked = true;

                    UpdateSystemMessage("Frm Main",
                        string.Format("GC Collect 수행 Start {0:N0}", GC.GetTotalMemory(false)));
                    GC.Collect();
                    UpdateSystemMessage("Frm Main", string.Format("GC Collect 수행 End {0:N0}", GC.GetTotalMemory(true)));

                    string[] saData = { "Tracker", "Monitoring", "Stop" };
                    m_cTrackerClient.SendStatusToServer(saData);

                    CMultiProject.IsRun = m_cTrackerServer.IsRunning;

                    //CMultiProject.LineInfo.UEventValueChanged -= LineInfo_UEventValueChanged;
                    CMultiProject.LineInfoS.UEventLineInfoValueChanged -= LineInfoS_UEventValueChanged;
                    LineInfoS_UEventValueChanged(null);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }


        private void toggMainEditorMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (toggMainEditorMode.Checked == false)
                this.exRibbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            else
                this.exRibbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
        }

        private void toggAdministratorMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (toggAdministratorMode.Checked == true)
            {
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                DialogResult result;
                FrmLogin loginForm = new FrmLogin();

                loginForm.TopMost = true;
                result = loginForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    toggMainEditorMode.Enabled = true;
                    toggMainEditorMode.Checked = true;
                    btnExportPDF.Enabled = true;
                    btnCycle.Visible = true;
                    ucPlcCycle.Visible = true;
                    pnlCycle.Visible = true;
                    btnExitHMI.Visible = true;
                    this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})   <<Account : Administrator>>", CMultiProject.ProjectName, CMultiProject.ProjectPath);
                }
                else
                    toggAdministratorMode.Checked = false;

                loginForm.Dispose();
                loginForm = null;
            }
            else
            {
                if (toggMainEditorMode.Checked == true)
                {
                    exRibbon.Minimized = true;
                    toggMainEditorMode.Checked = false;
                }
                toggMainEditorMode.Enabled = false;
                btnExportPDF.Enabled = false;
                btnCycle.Visible = false;
                ucPlcCycle.Visible = false;
                pnlCycle.Visible = false;
                btnExitHMI.Visible = false;
                this.Text = string.Format("UDM Tracker (UDMTEK)  Project Name : ( {0} ) File Path : ({1})   <<Account : User>>", CMultiProject.ProjectName, CMultiProject.ProjectPath);
            }
            CMultiProject.Account = false;

        }

        private void tmrSPDStatusCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrSPDStatusCheck.Enabled = false;

                foreach (var who in m_dicSPDStatusCheck)
                {
                    if (who.Value == false)
                    {
                        UpdateSystemMessage("SPD Single", "연결 상태 반응이 없습니다. ID : " + who.Key);
                        //dpnlSystemLog.Show();
                        chkShowSysLog.Checked = true;

                        if (m_dicSPDStatusDisconnectCount.ContainsKey(who.Key))
                            m_dicSPDStatusDisconnectCount[who.Key]++;
                    }
                }

                m_dicSPDStatusCheck.Clear();

                if (m_cTrackerServer.IsRunning && m_dicSPDStatusDisconnectCount.Any(x => x.Value >= 12))
                    m_cTrackerClient.SendUnknownErrorActionToServer();

                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    if(!m_dicSPDStatusCheck.ContainsKey(who.Key))
                        m_dicSPDStatusCheck.Add(who.Key, false);

                    if(!m_dicSPDStatusDisconnectCount.ContainsKey(who.Key))
                        m_dicSPDStatusDisconnectCount.Add(who.Key, 0);
                }

                tmrSPDStatusCheck.Enabled = true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrLoadFirst_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrLoadFirst.Enabled = false;

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
                    CMultiProject.SystemLog.WriteLog("자동열기", "기존 UMPP 경로 : " + m_sAutoOpenUpmPath);
                    btnOpen_ItemClick(null, null);
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrLoadSecond_Tick(object sender, EventArgs e)
        {
            tmrLoadSecond.Enabled = false;
            try
            {
                //SPD Single실행
                //Commit
                SendAllTagSToTrackerReader();

                m_bLoadSPDSingle = m_cTrackerServer.SendCollectList();
                tmrSPDStatusCheck.Start();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnGenerateAllMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                if (XtraMessageBox.Show("Master Pattern을 생성하시겠습니까?\r\n기존 Master Pattern이 존재하더라도 새롭게 Master Pattern을 생성합니다.", "MasterPattern 생성", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)
                    == DialogResult.No)
                    return;

                UpdateSystemMessage("MastarPattern", "생성요청");

                FrmMasterPatternUpdate frmMasterpattern = new FrmMasterPatternUpdate();
                frmMasterpattern.UMasterPatternGenerateEvent += FrmMasterPatternUpdate_MasterPatternGenerateEvent;
                frmMasterpattern.SetDescription("Master Pattern 자동 생성 중입니다.");
                frmMasterpattern.TopMost = true;
                frmMasterpattern.Show();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void cboGenerateSelectedMasterPattern_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void cboGenerateSelectedMasterPattern_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                bool bOK = VerifyParameter();

                if (!bOK)
                    return;

                object obj = cboGenerateSelectedMasterPattern.EditValue;

                if (obj == null)
                    return;

                string sName = (string)obj;



                if (XtraMessageBox.Show("\'" + sName + "\'공정의 Master Pattern을 생성하시겠습니까?", "개별 공정 MasterPattern 생성", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;

                UpdateSystemMessage("\'" + sName + "\'공정 MastarPattern", "생성요청");

                FrmMasterPatternUpdate frmMasterpattern = new FrmMasterPatternUpdate();
                frmMasterpattern.UMasterPatternGenerateEvent += FrmMasterPatternUpdate_MasterPatternGenerateEvent;
                frmMasterpattern.IsIndividual = true;
                frmMasterpattern.IndividualProcessName = sName;
                frmMasterpattern.TopMost = true;

                frmMasterpattern.SetDescription("\'" + sName + "\' 공정 Master Pattern 자동 생성 중입니다.");
                frmMasterpattern.Show();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrNewRecipe_Tick(object sender, EventArgs e)
        {
            try
            {
                DisposeRecipeViewer();

                m_bMntAutoStart = true;
                btnMonitorStart_Click(null, null);
                tmrNewRecipe.Stop();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        #region User Event

        #region Analyzer Event

        private void UEventManualCycleOverError(string sProcessKey, string sTagKey)
        {
            int iStep = 0;
            try
            {
                if (!CMultiProject.PlcProcS[sProcessKey].KeySymbolS.ContainsKey(sTagKey))
                    return;

                CKeySymbol cSymbol = CMultiProject.PlcProcS[sProcessKey].KeySymbolS[sTagKey];
                CErrorInfo cErrorInfo = CreateCycleOverErrorInfo(sProcessKey, cSymbol, null);

                if (m_dicSendedSubDepth.ContainsKey(cSymbol.Tag.Key) == false)
                {
                    iStep++;
                    if (cSymbol.AllSubDepthTagKeyList.Count > 0)
                    {
                        m_cTrackerServer.GetSubDepthStateValue(cSymbol);
                        iStep++;
                        m_dicSendedSubDepth.Add(cSymbol.Tag.Key, cErrorInfo);
                        UpdateSystemMessage("CycleManualErrorEvent", string.Format("{0}", cSymbol.Tag.Key));
                    }
                    iStep++;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventInterlockError", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventCycleCheck(string sProcessKey, DateTime dtActTime)
        {
            try
            {
                CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];

                if (cProcess.CycleErrorFlag)
                {
                    ucSummary.ClearError(sProcessKey);
                    ucFlowChart.ClearAlarmPanel(sProcessKey);
                    cProcess.CycleErrorFlag = false;
                }

                UpdateSystemMessage("Error Monitoring Process", "Reset 완료");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventCycleCheck", string.Format("Error FrmMain Roof = {0}", ex.Message));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventCycleEnd(string sProcessKey, DateTime dtActTime)
        {
            int iStep = 0;
            try
            {
                if (CMultiProject.TotalCycleInfoS.ContainsKey(sProcessKey))
                {
                    CCycleInfoS cCycleInfoS = CMultiProject.TotalCycleInfoS[sProcessKey];
                    CCycleInfo cCycleInfo = cCycleInfoS.CurrentCycleInfo;

                    cCycleInfo.CycleEnd = dtActTime;

                    ucPlcCycle.UpdateCycleState(sProcessKey, EMCycleRunType.End);

                    cCycleInfoS = null;
                    cCycleInfo = null;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventCycleEnd", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventCycleStart(string sProcessKey, DateTime dtActTime)
        {
            int iStep = 0;
            try
            {
                if (CMultiProject.TotalCycleInfoS.ContainsKey(sProcessKey))
                {
                    bool bOK = false;

                    iStep++;


                    CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];
                    ucPlcCycle.UpdateCycleEnd(sProcessKey, dtActTime, cProcess.CycleErrorFlag, cProcess.MaxTactTime);
                    iStep++;

                    if (cProcess.CycleErrorFlag)
                    {
                        ucSummary.ClearError(sProcessKey);
                        ucFlowChart.ClearAlarmPanel(sProcessKey);
                    }

                    iStep++;

                    CCycleInfoS cCycleInfoS = CMultiProject.TotalCycleInfoS[sProcessKey];
                    CCycleInfo cCycleInfo = cCycleInfoS.CurrentCycleInfo;
                    //이미 생성되어 있으므로 값만 채워 넣음.
                    cCycleInfo.ProjectID = CMultiProject.ProjectID;
                    cCycleInfo.CycleID = cCycleInfoS.LastCycleID;
                    cCycleInfo.GroupKey = sProcessKey;

                    ucPlcCycle.UpdateCycleState(sProcessKey, EMCycleRunType.Start);

                    if (cProcess.CycleEndFlag == false || cCycleInfo.CycleStart == DateTime.MinValue)
                    {
                        m_dicProcessCycleStart[sProcessKey] = dtActTime;
                        cCycleInfo.CycleStart = dtActTime;
                        ucPlcCycle.UpdateCycleStart(sProcessKey, dtActTime);
                        return;
                    }
                    iStep++;
                    ucPlcCycle.UpdateCycleStart(sProcessKey, dtActTime);

                    cCycleInfo.NextCycleStart = dtActTime;
                    cCycleInfo.CycleCount = m_dicCycleCount[sProcessKey]++;

                    ucPlcCycle.UpdateCycleInfoS(sProcessKey, cCycleInfo);
                    cProcess.CycleID = cCycleInfo.CycleID;

                    if (cProcess.CycleErrorFlag)
                    {
                        cCycleInfo.CycleType = EMCycleRunType.Error;
                        cProcess.CycleErrorFlag = false;
                    }
                    else if(m_bOptimizerMode)
                        cCycleInfo.CycleType = EMCycleRunType.Learning;
                    else
                        cCycleInfo.CycleType = EMCycleRunType.Complete;

                    CCycleInfo cLastCycleInfo = (CCycleInfo)cCycleInfo.Clone();
                    ucPlcCycle.UpdateCycleStatisticS(cLastCycleInfo);
                    cLastCycleInfo = null;

                    if (m_cLogWriter.IsConnected == false)
                    {
                        UpdateSystemMessage("CycleInfo", "LogWriter Fail");
                        return;
                    }
                    iStep++;

                    m_dicProcessRecipe[sProcessKey] = cProcess.CurrentRecipe;
                    cCycleInfo.CurrentRecipe = cProcess.CurrentRecipe;
                    m_cLogWriter.EnQue((CCycleInfo)cCycleInfo.Clone());

                    if (CMultiProject.IsAutoUpdateRecipe && cProcess.CurrentRecipe != null && cProcess.CurrentRecipe != string.Empty &&
                        cProcess.CurrentRecipe != "0")
                    {
                        if (CMultiProject.MasterPatternS != null &&
                            CMultiProject.MasterPatternS.ContainsKey(cProcess.Name)
                            && !CMultiProject.MasterPatternS[cProcess.Name].ContainsKey(cProcess.CurrentRecipe))
                            m_cRecipeChecker.EnQue((CCycleInfo)cCycleInfo.Clone());
                    }

                    if (m_bOptimizerMode && m_frmCollectOptimizer.IsLoad && m_cOptimizer.IsRunning)
                        m_cOptimizer.EnQue((CCycleInfo) cCycleInfo.Clone());

                    int iCycleLastID = cCycleInfoS.LastCycleID;
                    iStep++;

                    //Memory 최적화
                    cCycleInfoS.Clear();
                    cCycleInfo = null;

                    //UpdateSystemMessage("CycleStartEvent",
                    //    string.Format("CycleInfoS를 Clear합니다. 마지막 ID = {0}", iCycleLastID));

                    //다음 Cycle Info 추가
                    CCycleInfo cNextCycleInfo = new CCycleInfo();
                    cNextCycleInfo.CycleStart = dtActTime;
                    cNextCycleInfo.CycleID = iCycleLastID + 1;
                    cCycleInfoS.Add(cNextCycleInfo.CycleID, cNextCycleInfo);

                    //UpdateSystemMessage("CycleStartEvent", string.Format("새로운 ID를 발급합니다. {0}", cNextCycleInfo.CycleID));
                    m_dicProcessCycleStart[sProcessKey] = dtActTime;
                    iStep++;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventCycleStart", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventMessage(string sSender, string sMessage)
        {
            try
            {
                UpdateSystemMessage(sSender, sMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventMaxCycleOver(string sProcessKey, CTimeLogS cLogS, bool bAuto)
        {
            int iStep = 0;
            try
            {
                ucPlcCycle.UpdateCycleOver(sProcessKey);
                ucFlowChart.UpdateError(sProcessKey);

                if (bAuto)
                    return;

                CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];
                List<string> lstSubTag = new List<string>();
                string sMasterKey = "";
                CKeySymbol cFirstKeySymbol = null;
                bool bFirst = true;
                int iMasterCount = 0;
                CFlowItemS cItemS = GetMasterFlowItemS(cProcess.Name, cProcess.CurrentRecipe);
                string sFlowKey = string.Empty;

                if (cItemS == null)
                {
                    UpdateSystemMessage("MaxCycleOver", "해당 Recipe의 FlowItemS가 존재하지 않습니다.");
                    return;
                }

                for (int i = 0; i < cItemS.Count; i++)
                {
                    sFlowKey = cItemS[i].Key;

                    if (!cProcess.KeySymbolS.ContainsKey(sFlowKey))
                        continue;

                    if (cLogS.Where(x => x.Key == sFlowKey && x.Value > 0).Count() == 0)
                    {
                        if (cProcess.KeySymbolS[sFlowKey].AllSubDepthTagKeyList.Count > 0)
                        {
                            if (iMasterCount < 3)
                            {
                                sMasterKey += sFlowKey + "/";
                                iMasterCount++;
                            }
                            else break;

                            if (bFirst && CheckLastOFFKeySymbol(i, cLogS, cItemS))
                            {
                                cFirstKeySymbol = cProcess.KeySymbolS[sFlowKey];
                                bFirst = false;

                                lstSubTag.AddRange(cProcess.KeySymbolS[sFlowKey].AllSubDepthTagKeyList);
                            }
                        }
                    }
                }

                iStep++;
                UpdateSystemMessage("CycleOverEvent", string.Format("{0} 의 KeySymbol 모든 SubDepth를 모음 {1}", sProcessKey, lstSubTag.Count));

                if (cFirstKeySymbol == null)
                {
                    UpdateSystemMessage("Cycle Over", "First Key Symbol이 Null 입니다.");
                    return;
                }

                iStep++;
                CErrorInfo cErrorInfo = CreateCycleOverErrorInfo(sProcessKey, cFirstKeySymbol, cLogS);
                if (cErrorInfo == null) return;
                iStep++;

                if (!m_dicSendedSubDepth.ContainsKey(sMasterKey))
                {
                    m_cTrackerServer.GetSubDepthStateValue(sMasterKey, lstSubTag);
                    m_dicSendedSubDepth.Add(sMasterKey, cErrorInfo);
                }
                UpdateSystemMessage("CycleOverEvent", string.Format("{0} 전송 Tag = {1}", sProcessKey, lstSubTag.Count));
                iStep++;

                lstSubTag.Clear();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventMaxCycleOver", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                Console.WriteLine("UEventMaxCycleOver " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventInterlockError(CAbnormalSymbol cSymbol, CErrorInfo cErrorInfo)
        {
            int iStep = 0;
            try
            {
                if (m_dicSendedSubDepth.ContainsKey(cSymbol.Tag.Key) == false)
                {
                    if (CMultiProject.PlcProcS.ContainsKey(cErrorInfo.GroupKey))//&& CMultiProject.PlcProcS[cErrorInfo.GroupKey].CycleStartFlag)
                        ucPlcCycle.UpdateCycleOver(cErrorInfo.GroupKey);

                    iStep++;
                    if (cSymbol.AllSubDepthTagKeyList.Count > 0)
                    {
                        m_cTrackerServer.GetSubDepthStateValue(cSymbol);
                        iStep++;
                        m_dicSendedSubDepth.Add(cSymbol.Tag.Key, cErrorInfo);
                        UpdateSystemMessage("CycleInterlockEvent", string.Format("{0}", cSymbol.Tag.Key));
                    }
                    iStep++;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventInterlockError", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEventRobotCycleOn(string sTagKey, string sState)
        {
            int iStep = 0;
            try
            {
                iStep++;
                UpdateSystemMessage("CycleRobotEvent", string.Format("{0}", sTagKey));
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventRobotCycleOn", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cAnalyzer_UEVentUpdateFlowChart(string sProcessKey, CTimeLog cLog)
        {
            try
            {
                if (CMultiProject.MonitorType == EMMonitorType.Detection)
                    UpdateFlowChart(sProcessKey, cLog);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        #region Server Event

        private void m_cTrackerServer_UEventMessage(string sSender, string sMessage)
        {
            try
            {
                UpdateSystemMessage(sSender, sMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cTrackerServer_UEventTimeLogS(EMTrackerLogType emLogType, CTimeLogS cLogS)
        {
            int iStep = 0;
            try
            {
                if (cLogS == null || cLogS.Count == 0)
                {
                    UpdateSystemMessage("TimeLogEvent", "cLogS가 Null이거나 Count가 0입니다.");
                    return;
                }
                Dictionary<EMTrackerLogType, CTimeLogS> dicData = new Dictionary<EMTrackerLogType, CTimeLogS>();
                dicData.Add(emLogType, (CTimeLogS)cLogS.Clone());
                m_cLogWriter.EnQue((CTimeLogS)cLogS.Clone());
                iStep++;
                m_cAnalyzer.EnQue(dicData);
                iStep++;
                //lblMonitorCount.Caption = cLogS.Count.ToString();

                //if (CMultiProject.MonitorType == EMMonitorType.Detection)
                //    UpdateFlowChart((CTimeLogS)cLogS.Clone());

                iStep++;

                cLogS.Clear();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventTimeLogS", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cTrackerServer_UEventEmergTimeLogS(EMTrackerLogType emLogType, string sKey, CTimeLogS cLogS)
        {
            int iStep = 0;

            try
            {
                if (m_dicSendedSubDepth.ContainsKey(sKey))
                {
                    CErrorInfo cErrorInfo = m_dicSendedSubDepth[sKey];
                    UpdateSystemMessage("EmergTimeLogS",
                        string.Format("{0} Event 진입 / Error Type : {1}", sKey, cErrorInfo.ErrorType));
                    iStep++;
                    int iCycleLog = cErrorInfo.ErrorLogS.Count;
                    if (cErrorInfo.ErrorType == "CycleOver")
                        cErrorInfo.ErrorLogS.AddRange((CTimeLogS)cLogS.Clone());
                    else
                    {
                        cErrorInfo.ErrorLogS = (CTimeLogS)cLogS.Clone();
                        cErrorInfo.CycleStart = m_dicProcessCycleStart[cErrorInfo.GroupKey];
                        cErrorInfo.CurrentRecipe = m_dicProcessRecipe[cErrorInfo.GroupKey];
                    }
                    iStep++;
                    UpdateSystemMessage("EmergTimeLogS", string.Format("{0} 하위Depth수집결과 : Cycle Log = {1} / Error Log = {2}", sKey, iCycleLog, cLogS.Count));

                    if (cErrorInfo.ErrorType == "CycleOver")
                    {
                        if (m_cLogWriter != null && m_cLogWriter.IsConnected)
                        {
                            m_cLogWriter.EnQue((CErrorInfo)cErrorInfo.Clone());
                            UpdateSystemMessage("EmergTimeLogS", "Error Log Write");
                        }
                        else
                            UpdateSystemMessage("EmergTimeLogS", "DB연결이 실패했습니다");

                        cErrorInfo.IsVisible = true;

                        CMultiProject.ErrorInfoS.Add(cErrorInfo);
                        UpdateSystemMessage("CycleOver EmergTimeLogS", "ErrorInfo Add OK");
                        CMultiProject.ErrorView.UpdateView(cErrorInfo);
                        ucFlowChart.UpdateError(cErrorInfo.GroupKey);
                        ucSummary.UpdateError(cErrorInfo);
                    }
                    else
                    {
                        m_cErrorAnalyzer.EnQue((CErrorInfo)cErrorInfo.Clone());
                        UpdateErrorTab();
                    }

                    iStep++;

                    //Memory 최적화
                    cErrorInfo.ErrorLogS.Clear();
                    cErrorInfo = null;
                    iStep++;
                    m_dicSendedSubDepth.Remove(sKey);
                }
                else
                    UpdateSystemMessage("EmergTimeLogS", "해당키가 없습니다.  " + sKey);

                //Memory 최적화
                cLogS.Clear();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventEmergTimeLogS", string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cTrackerServer_UEventClientConnect(bool bConnect)
        {
            int iStep = 0;
            try
            {
                if (bConnect)
                {
                    UpdateSystemMessage("Tracker Reader", "연결 성공");
                    if (m_cAnalyzer.IsRunning == false)
                        btnMonitorStart.Enabled = true;
                    iStep = 1;
                }
                else
                {
                    UpdateSystemMessage("Tracker Reader", "연결 실패");
                    if (m_cAnalyzer.IsRunning == false)
                        btnMonitorStart.Enabled = false;

                    iStep = 2;
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventClientConnect",
                    string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cTrackerServer_UEventSPDStatus(string[] saData)
        {
            int iStep = 0;
            try
            {
                iStep++;
                //UpdateSystemMessage("SPD 상태", string.Format("{0}상태변화 : {1}", saData[0], saData[1]));
                if (m_dicSPDStatusCheck.ContainsKey(saData[0]) == false)
                    m_dicSPDStatusCheck.Add(saData[0], true);
                else
                    m_dicSPDStatusCheck[saData[0]] = true;

                if (m_dicSPDStatusDisconnectCount.ContainsKey(saData[0]))
                    m_dicSPDStatusDisconnectCount[saData[0]] = 0;

                iStep++;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("UEventSPDStatus",
                    string.Format("Error FrmMain Roof = {0}, FailStep {1}", ex.Message, iStep));
                ex.Data.Clear();
            }
        }

        private void m_cTrackerServer_UEventLadderViewSPDStatus(string[] saData)
        {
            ucStepLadderView.SetLadderViewSPDStatus(saData[0], saData[1]);
        }

        private void m_cTrackerServer_UEventLadderViewTimeLogS(EMTrackerLogType emLogType, CTimeLogS cLogS)
        {
            //UCStepLadderView로 전달
            ucStepLadderView.SetLadderViewTimeLogS(emLogType, cLogS);
        }

        #endregion

        #region Client Event

        private void m_cTrackerClient_UEventMessage(string sSender, string sMessage)
        {
            try
            {
                UpdateSystemMessage(sSender, sMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cTrackerClient_UEventMonitoringStart(bool bConnect)
        {
            try
            {
                if (!bConnect) return;

                if (!m_cTrackerServer.IsRunning)
                {
                    m_bMntAutoStart = true;
                    btnMonitorStart_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void m_cTrackerClient_UEventMonitoringStop(bool bExportReport)//bConnect)
        {
            try
            {
                //if (!bConnect) return;

                btnMonitorStop_Click(null, null);

                DateTime dtNow = DateTime.Now;
                if (bExportReport && dtNow.Day == 1)
                {
                    //FrmReportExporter frmReport = new FrmReportExporter();
                    //frmReport.IsAuto = true;
                    //frmReport.AutoExportPLCMonitoringInfo();
                }

                this.Close();

                //if (m_cTrackerServer.IsRunning)
                //{
                //    btnMonitorStop_Click(null, null);

                //    if (!m_cTrackerServer.IsRunning)
                //    {
                //        this.Close();
                //    }
                //}
                //else
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        private void picMain_EditValueChanged(object sender, EventArgs e)
        {
            //if (picMain.EditValue != null && picMain.EditValue is Image)
            //    WriteLastMainImage();
        }

        private void picMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PictureEdit picEdit = sender as PictureEdit;
                DXPopupMenu menu = new DXPopupMenu();

                PropertyInfo info = typeof(PictureEdit).GetProperty("Menu", BindingFlags.NonPublic | BindingFlags.Instance);
                menu = info.GetValue(picEdit, null) as DXPopupMenu;
                foreach (DXMenuItem item in menu.Items)
                {
                    if (item.Caption != "Load")
                        item.Visible = false;
                }
            }
        }

        #endregion

        private void chkPlcBaseView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (chkPlcBaseView.Checked)
                {
                    chkProjectBaseView.Checked = false;
                    CMultiProject.IsProjectBaseView = false;
                }
                else
                {
                    chkProjectBaseView.Checked = true;
                    CMultiProject.IsProjectBaseView = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void chkProjectBaseView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chkProjectBaseView.Checked)
            {
                chkPlcBaseView.Checked = false;
                CMultiProject.IsProjectBaseView = true;
            }
            else
            {
                chkPlcBaseView.Checked = true;
                CMultiProject.IsProjectBaseView = false;
            }
        }

        #endregion

        private void btnScreenViewApply_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    CMultiProject.Refresh();
                    btnSummary_Click(null, null);
                }
                SplashScreenManager.CloseForm(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tabView_QueryControl(object sender, QueryControlEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Document.ControlTypeName))
                {
                    string sControlType = e.Document.ControlTypeName;

                    switch (sControlType)
                    {
                        case "UCAllErrorAlarmView2":
                            e.Control = ucSummary;
                            break;
                        case "UCPlcCycle":
                            e.Control = ucPlcCycle;
                            break;
                        case "UCFlowChart":
                            e.Control = ucFlowChart;
                            break;
                        case "UCSymbolValue":
                            e.Control = ucSymbolValue;
                            break;
                        case "UCStepLadderView":
                            e.Control = ucStepLadderView;
                            break;
                        case "UCErrorView":
                            e.Control = ucErrorView;
                            break;
                        case "UCErrorLogTable":
                            e.Control = ucErrorLogTable;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tabView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            try
            {
                if(e.Menu.Items.Count >= 1)
                    if (e.Menu.Items[1].Caption == "Windows...")
                        e.Menu.Items[1].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                ex.Data.Clear();
            }
        }
        
        private void btnCollectOptimization_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                {
                    XtraMessageBox.Show("공정 설정 및 공정 별 CANDIDATE KEY, CYCLE START/END를 먼저 설정해주세요!!!", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool bOK = true;
                string sCandidateKey = string.Empty;
                string sCycleStartEnd = string.Empty;
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    if (cProcess.CollectCandidateTagS == null || cProcess.CollectCandidateTagS.Count == 0)
                        sCandidateKey += string.Format("{0},", cProcess.Name);

                    if (cProcess.CycleStartConditionS.Count == 0 || cProcess.CycleEndConditionS.Count == 0)
                        sCycleStartEnd += string.Format("{0},", cProcess.Name);
                }

                if (sCandidateKey != string.Empty && sCycleStartEnd != string.Empty)
                {
                    sCycleStartEnd = sCycleStartEnd.Substring(0, sCycleStartEnd.Length - 1);
                    sCandidateKey = sCandidateKey.Substring(0, sCandidateKey.Length - 1);

                    XtraMessageBox.Show(
                        string.Format(
                            "\'{0}\' 공정은 CANDIDATE KEY가 정의되지 않았으며, \'{1}\' 공정은 CYCLE START/END가 정의되지 않았습니다.\r\nCANDIDATE KEY와 CYCLE START/END를 먼저 정의해주세요!!!",
                            sCandidateKey, sCycleStartEnd), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                }
                else if (sCandidateKey != string.Empty)
                {
                    sCandidateKey = sCandidateKey.Substring(0, sCandidateKey.Length - 1);
                    XtraMessageBox.Show(
                        string.Format("\'{0}\' 공정의 CANDIDATE KEY 가 정의되지 않았습니다.\r\nCANDIDATE KEY를 먼저 정의해주세요!!!",
                            sCandidateKey), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }
                else if (sCycleStartEnd != string.Empty)
                {
                    sCycleStartEnd = sCycleStartEnd.Substring(0, sCycleStartEnd.Length - 1);
                    XtraMessageBox.Show(
                        string.Format("\'{0}\' 공정의 CYCLE START/END 가 정의되지 않았습니다.\r\nCYCLE START/END를 먼저 정의해주세요!!!",
                            sCycleStartEnd), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }

                if (!bOK)
                    return;

                if (!m_frmCollectOptimizer.IsLoad)
                {
                    m_frmCollectOptimizer.Show();
                    m_frmCollectOptimizer.IsLoad = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                ex.Data.Clear();
            }
        }

        private void btnCollectOptiSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                ex.Data.Clear();
            }
        }

        private void chkOptimizationMode_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!chkOptimizationMode.Checked)
                    return;

                if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
                {
                    XtraMessageBox.Show("공정 설정 및 공정 별 CANDIDATE KEY, CYCLE START/END를 먼저 설정해주세요!!!", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkOptimizationMode.Checked = false;
                    return;
                }

                bool bOK = true;
                string sCandidateKey = string.Empty;
                string sCycleStartEnd = string.Empty;
                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    if (cProcess.CollectCandidateTagS == null || cProcess.CollectCandidateTagS.Count == 0)
                        sCandidateKey += string.Format("{0},", cProcess.Name);

                    if (cProcess.CycleStartConditionS.Count == 0 || cProcess.CycleEndConditionS.Count == 0)
                        sCycleStartEnd += string.Format("{0},", cProcess.Name);
                }

                if (sCandidateKey != string.Empty && sCycleStartEnd != string.Empty)
                {
                    sCycleStartEnd = sCycleStartEnd.Substring(0, sCycleStartEnd.Length - 1);
                    sCandidateKey = sCandidateKey.Substring(0, sCandidateKey.Length - 1);

                    XtraMessageBox.Show(
                        string.Format(
                            "\'{0}\' 공정은 CANDIDATE KEY가 정의되지 않았으며, \'{1}\' 공정은 CYCLE START/END가 정의되지 않았습니다.\r\nCANDIDATE KEY와 CYCLE START/END를 먼저 정의해주세요!!!",
                            sCandidateKey, sCycleStartEnd), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    bOK = false;
                }
                else if (sCandidateKey != string.Empty)
                {
                    sCandidateKey = sCandidateKey.Substring(0, sCandidateKey.Length - 1);
                    XtraMessageBox.Show(
                        string.Format("\'{0}\' 공정의 CANDIDATE KEY 가 정의되지 않았습니다.\r\nCANDIDATE KEY를 먼저 정의해주세요!!!",
                            sCandidateKey), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }
                else if (sCycleStartEnd != string.Empty)
                {
                    sCycleStartEnd = sCycleStartEnd.Substring(0, sCycleStartEnd.Length - 1);
                    XtraMessageBox.Show(
                        string.Format("\'{0}\' 공정의 CYCLE START/END 가 정의되지 않았습니다.\r\nCYCLE START/END를 먼저 정의해주세요!!!",
                            sCycleStartEnd), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }

                if (!bOK)
                {
                    chkOptimizationMode.Checked = false;
                    return;
                }

                if (!m_frmCollectOptimizer.IsLoad)
                {
                    m_frmCollectOptimizer.Show();
                    m_frmCollectOptimizer.IsLoad = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                ex.Data.Clear();
            }
        }


    }
}