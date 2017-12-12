using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private Dictionary<string, int> m_dicCycleCount = new Dictionary<string, int>();
        private string m_sFixUpmPath = Application.StartupPath + "\\LastOptimizerProjectPath.txt";
        private string m_sAutoOpenUpmPath = "";
        private string m_sSysLogPath = Application.StartupPath + "\\OptimizerSystemLog";
        private string m_sDBBackupPath = Application.StartupPath + "\\OptimizerDBBackup";
        private bool m_bUpmOpenFirst = true;
        //private COptraClient m_cOptimizerClient = new COptraClient();
        private COptraAnalyzer m_cAnalyzer = new COptraAnalyzer();
        private COptraLogWriter m_cLogWriter = new COptraLogWriter();
        private CMySqlLogReader m_cReader = new CMySqlLogReader();

        private Dictionary<string, CErrorInfo> m_dicSendedSubDepth = new Dictionary<string, CErrorInfo>();
        private Dictionary<string, DateTime> m_dicProcessCycleStart = new Dictionary<string, DateTime>();
        private Dictionary<string, string> m_dicProcessRecipe = new Dictionary<string, string>();
        private Dictionary<string, bool> m_dicSPDStatusCheck = new Dictionary<string, bool>();
        private CTagS m_cRecipeCheckTagS = new CTagS();

        private bool m_bOptimizerAlive = false;

        private RepositoryItemPictureEdit repositoryPic = new RepositoryItemPictureEdit();

        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected delegate void UpdateErrorTabBack();
        protected delegate void UpdatwFlowChartCallback(CTimeLogS cLogS);
        protected delegate void UpdateTagFinderCallback();

        #endregion

        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();

            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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

        private void SaveProject(string sPath)
        {

            //SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format("Openning Project File :\r\n{0}", sPath), "Open");
            CShowWaitForm.ShowForm("Save Project", string.Format("Save File Path :\r\n{0}", sPath), "Start...", true);
            {
                string sMessage = "";
                bool bOK = CMultiProject.Save(sPath, out sMessage);
                if (bOK)
                {
                    UpdateSystemMessage("저장", "저장에 성공했습니다.");
                    WriteLastUpmPath();

                    m_sAutoOpenUpmPath = sPath;
                }
                else
                    UpdateSystemMessage("저장실패", sMessage);
            }
            CShowWaitForm.CloseForm();
        }

        private void DBBackup(string sDBPath, string sPath)
        {
            try
            {
                string sError = string.Empty;

                using (Process mysqlDump = new Process())
                {
                    CShowWaitForm.ShowForm("DB Backup", string.Format("Backup File Path :\r\n{0}", sPath), "Start...", true);
                    {
                        //Maria DB의 경우 Path 다름
                        mysqlDump.StartInfo.FileName = sDBPath;
                        mysqlDump.StartInfo.UseShellExecute = false;
                        mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -r \"{0}\"", sPath);
                        mysqlDump.StartInfo.RedirectStandardInput = false;
                        mysqlDump.StartInfo.RedirectStandardOutput = false;
                        mysqlDump.StartInfo.RedirectStandardError = true;
                        mysqlDump.StartInfo.CreateNoWindow = true;
                        mysqlDump.Start();

                        sError = mysqlDump.StandardError.ReadToEnd();
                    }
                    CShowWaitForm.CloseForm();

                    if (sError != string.Empty)
                        XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        XtraMessageBox.Show("DB Backup Success!!", "DB Backup", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    mysqlDump.WaitForExit();
                    mysqlDump.Close();
                }

                string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                if (sError == string.Empty && Directory.Exists(sFolderPath))
                    Process.Start(sFolderPath);
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private bool CheckProjectAvailable()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "" || CMultiProject.ProjectInfo.ProjectID == "00000000")
            {
                XtraMessageBox.Show("Please Create New Project First!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (CMultiProject.UserDeviceS == null)
                CMultiProject.UserDeviceS = new CUserDeviceS();
            if (CMultiProject.PlcConfigS == null)
                CMultiProject.PlcConfigS = new CPlcConfigS();
            if (CMultiProject.PlcLogicDataS == null)
                CMultiProject.PlcLogicDataS = new CPlcLogicDataS();
            if (CMultiProject.TotalTagS == null)
                CMultiProject.TotalTagS = new CTagS();
            if (CMultiProject.PlcIDList == null)
                CMultiProject.PlcIDList = new List<string>();

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
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void WriteLastUpmPath()
        {
            try
            {
                StreamWriter writer = new StreamWriter(m_sFixUpmPath);
                writer.WriteLine(CMultiProject.ProjectPath);
                m_sAutoOpenUpmPath = CMultiProject.ProjectPath;
                writer.Dispose();
                writer = null;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }    
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

        private void InitSetting()
        {
            CMultiProject.Editable = true;

            bool bOK = m_cReader.Connect();
            if (bOK == false)
            {
                XtraMessageBox.Show("Can't connect Database!! Please check Database installation", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSystemMessage("DBReader", "연결에 실패했습니다.");
                return;
            }

            CMultiProject.LogReader = m_cReader;
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectInfo.ProjectName == "")
            {
                XtraMessageBox.Show("Project is not created!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                XtraMessageBox.Show("Can't connect Database!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
                        //cOPCServer.Config.ABOpc = cConfig.OPCConfig.ABOpc;
                        //cOPCServer.Config.LsOpc = cConfig.OPCConfig.LsOpc;
                        //cOPCServer.Config.ServerName = cConfig.OPCConfig.ServerName;
                        //cOPCServer.Config.ChannelDevice = cConfig.OPCConfig.ChannelDevice;
                        //cOPCServer.Config.UpdateRate = cConfig.OPCConfig.UpdateRate;

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
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void SetSortTest()
        {
            //try
            //{
            //    UpdateSystemMessage("Process 분석", "공정 분석 시작");

            //    //Load
            //    Stopwatch sw = new Stopwatch();
            //    sw.Start();
            //    CMultiProject.CycleAnalyDataS.Clear();

            //    //foreach (var who in CMultiProject.PlcProcS)
            //    for (int iProc = 0; iProc < CMultiProject.PlcProcS.Count; iProc++)
            //    {
            //        if(SplashScreenManager.Default != null)
            //            SplashScreenManager.CloseDefaultSplashScreen();

            //        //CPlcProc cPlcProc = who.Value;
            //        CPlcProc cPlcProc = CMultiProject.PlcProcS.ElementAt(iProc).Value;
            //        string sKey = CMultiProject.PlcProcS.ElementAt(iProc).Key;

            //        //레시피 로드
            //        //Application.DoEvents();
            //        if (cPlcProc.IsErrorMonitoring) continue;
            //        if (cPlcProc.RecipeWordS == null || cPlcProc.RecipeWordS.Count == 0) continue;
            //        CCycleAnalyData cCycleTimeLog = new CCycleAnalyData();
            //        List<string> lstRecipeKey = cPlcProc.RecipeWordS.Select(b => b.Key).ToList();
            //        List<string> lstProcessTotalKey = cPlcProc.ProcessTagS.Select(b => b.Key).ToList();
            //        CCycleAnalyDataList cCycleAnalyDataList = new CCycleAnalyDataList();

            //        if (lstRecipeKey == null || lstRecipeKey.Count == 0) continue;

            //        //SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format("Analyze Process : {0}", who.Key), "Analyze");
            //        SplashScreenManager.ShowDefaultSplashScreen(this, false, false, string.Format("Analyze Process : {0} \n{1}/{2}", sKey, iProc + 1, CMultiProject.PlcProcS.Count), "Analyze");

            //        string sFirstKey = cPlcProc.RecipeWordS.First().Key;

            //        CTimeLogS cRecipeLogS = m_cReader.GetTimeLogS(sFirstKey);
            //        if (cRecipeLogS == null)
            //        {
            //            //UpdateSystemMessage("Process", string.Format("{0} 공정 분석 중 Recipe Log를 찾지 못했습니다. {1}", who.Key, sFirstKey));
            //            UpdateSystemMessage("Process", string.Format("{0} 공정 분석 중 Recipe Log를 찾지 못했습니다. {1}", sKey, sFirstKey));
            //            continue;
            //        }
            //        List<CTimeLog> lstValueOn = cRecipeLogS.FindAll(b => b.Value > 0).ToList();
            //        DateTime dtFirst = DateTime.MinValue;
            //        DateTime dtLast = DateTime.MinValue;
            //        double nSumTime = 0.0;
            //        TimeSpan tsMin = TimeSpan.MaxValue;
            //        TimeSpan tsMax = TimeSpan.MinValue;
            //        if (lstValueOn.Count == 0) continue;

            //        for (int i = 1; i < lstValueOn.Count - 1; i++)
            //        {
            //            CTimeLog cLog = lstValueOn[i];

            //            dtFirst = lstValueOn[i].Time;
            //            dtLast = lstValueOn[i + 1].Time;
            //            cCycleTimeLog = new CCycleAnalyData();

            //            //CTimeLogS cCycleTimeLogS = m_cReader.GetTimeLogS(lstProcessTotalKey, dtFirst, dtLast);
            //            cCycleTimeLog.RecipeKey = cLog.Key;
            //            cCycleTimeLog.StartTime = dtFirst;
            //            cCycleTimeLog.EndTime = dtLast;
            //            cCycleTimeLog.Duration = dtLast.Subtract(dtFirst);
            //            cCycleTimeLog.RecipeValue = lstValueOn[i].Value;
            //            nSumTime += cCycleTimeLog.Duration.TotalSeconds;
            //            cCycleTimeLog.ProcessKey = sKey;

            //            if (cCycleTimeLog.Duration > new TimeSpan(0, 0, 1))
            //            {
            //                if (tsMin > cCycleTimeLog.Duration)
            //                    tsMin = cCycleTimeLog.Duration;
            //                if (tsMax < cCycleTimeLog.Duration)
            //                    tsMax = cCycleTimeLog.Duration;
            //            }

            //            cCycleAnalyDataList.Add(cCycleTimeLog);
            //        }
            //        //Cycle 분석

            //        double nAvgSec = nSumTime / cCycleAnalyDataList.Count;

            //        CMultiProject.CycleAnalyDataS.Add(sKey, cCycleAnalyDataList);
            //        CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.Average = TimeSpan.FromSeconds(nAvgSec);
            //        CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.MinCycle = tsMin;
            //        CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.MaxCycle = tsMax;
            //        int iReCheckCount = 0;
            //        double nSumSec2 = 0.0;
            //        foreach (CCycleAnalyData cData in cCycleAnalyDataList)
            //        {
            //            if (CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.Average < cData.Duration)
            //            {
            //                CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.OverCount++;
            //                cData.IsCycleOver = true;
            //            }
            //            else
            //            {
            //                cData.IsCycleOver = false;
            //                iReCheckCount++;
            //                nSumSec2 += cData.Duration.TotalSeconds;
            //            }
            //        }

            //        if (nSumSec2 == 0) continue;
            //        double nAvgSec2 = nSumSec2 / iReCheckCount;
            //        TimeSpan tsAvg = TimeSpan.FromSeconds(nAvgSec2);

            //        CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.Average = tsAvg;

            //        foreach (CCycleAnalyData cData in cCycleAnalyDataList)
            //        {
            //            if (cData.IsCycleOver) continue;
            //            if (tsAvg < cData.Duration)
            //            {
            //                CMultiProject.CycleAnalyDataS[sKey].CycleAnalyzedData.OverCount++;
            //                cData.IsCycleOver = true;
            //            }
            //        }
            //        UpdateSystemMessage("Process", string.Format("{0} 공정 분석에 성공했습니다. {1}ms", sKey, sw.ElapsedMilliseconds));

            //        SplashScreenManager.CloseDefaultSplashScreen();
            //    }

            //    sw.Stop();
            //}
            //catch (Exception ex)
            //{
            //    CMultiProject.SystemLog.WriteLog("FrmMain",
            //        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            //    ex.Data.Clear();
            //    //SplashScreenManager.CloseDefaultSplashScreen();
            //}
        }

        private bool CheckOptimizerProcess(string sName)
        {
            bool bOK = false;

            try
            {
                Process[] arrProcessOptimizer = Process.GetProcessesByName(sName);
                if (arrProcessOptimizer != null && arrProcessOptimizer.Length > 1)
                    bOK = true;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }

            return bOK;
        }

        private List<string> GetTableList(string sFileName)
        {
            List<string> lstTable = new List<string>();
            try
            {
                StreamReader reader = new StreamReader(sFileName);
                string sLine = "";
                string sTable = "CREATE TABLE";

                while ((sLine = reader.ReadLine()) != null)
                {
                    if (sLine != "" && sLine.Contains(sTable))
                    {
                        sLine = sLine.Replace(sTable, "").Replace(" ", "");
                        string sPattern = @"[^`(]+";
                        
                        MatchCollection mcValues = Regex.Matches(sLine, sPattern);
                        if (mcValues.Count == 0) continue;

                        string sTableName = mcValues[0].Value;
                        lstTable.Add(sTableName);
                    }
                }
                reader.Dispose();
                reader = null;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            return lstTable;
        }

        private void ReadSQLTimeLogS()
        {
            try
            {
                Dictionary<DateTime, CTimeLogS> dicTimeLogS = new Dictionary<DateTime, CTimeLogS>();

                OpenFileDialog dlgOpenFile = new OpenFileDialog();
                dlgOpenFile.Title = "Data 생성을 위한 SQL 파일을 선택 해주세요.";
                dlgOpenFile.Filter = "*.sql|*.sql";
                dlgOpenFile.ShowDialog();

                string sFileName = dlgOpenFile.FileName;
                if (sFileName == null || sFileName == "") return;

                List<string> lstTable = GetTableList(sFileName);
                string sName = GetUserSelectText("Select Table", "Table명을 선택 해주세요.", lstTable);

                StreamReader reader = new StreamReader(sFileName);
                int iCnt = 0;
                string sLine = "";
                string sTimeLogValue = "INSERT INTO `" + sName + "` VALUES";

                CShowWaitForm.ShowForm("SQL Data Analysis", string.Format("SQL File Path :\r\n{0}", sFileName), "Start...", true);
                {
                    while ((sLine = reader.ReadLine()) != null)
                    {
                        CTimeLogS cLogS = new CTimeLogS();

                        if (sLine != "" && sLine.Contains(sTimeLogValue))
                        {
                            sLine = sLine.Replace(sTimeLogValue, "").Replace("),", ")");
                            string sPattern = @"[^()]+";

                            MatchCollection mcValues = Regex.Matches(sLine, sPattern);

                            foreach (Match mValues in mcValues)
                            {
                                string sValues = mValues.Value.Replace(" ", "");
                                if (sValues == string.Empty) continue;

                                sValues = sValues.Replace("'", "");
                                string[] saValues = sValues.Split(',');
                                if (saValues.Length != 4) continue;

                                CTimeLog cLog = new CTimeLog(saValues[1]);
                                cLog.Time = CLogUtil.ToDateTime(decimal.Parse(saValues[0]));
                                cLog.Value = int.Parse(saValues[2]);
                                cLog.Parent = saValues[3];

                                cLogS.Add(cLog);

                                iCnt++;
                            }
                        }

                        CMultiProject.TimeLogS.AddRange(cLogS);

                        cLogS.Clear();
                        cLogS.Dispose();
                        cLogS = null;
                    }
                    reader.Dispose();
                    reader = null;
                }

                if (iCnt == 0) 
                    XtraMessageBox.Show("선택한 SQL 파일에 해당 Table Data가 존재하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                CMultiProject.SystemLog.WriteLog("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            CShowWaitForm.CloseForm();
        }

        private static string GetUserSelectText(string sTitle, string sMessage, List<string> lstTable)
        {
            FrmInputComboDialog dlgInput = new FrmInputComboDialog(sTitle, sMessage, lstTable);
            dlgInput.ShowDialog();

            string sName = dlgInput.SelectItem;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }
        #endregion


        #region Event Methods

        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (CheckOptimizerProcess("UDMOptimizer"))
                {
                    XtraMessageBox.Show("Optimizer가 이미 실행중입니다.", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_bOptimizerAlive = true;
                    this.Close();
                    return;
                }
                else
                    m_bOptimizerAlive = false;

                //Optimizer Client 추가
                CMultiProject.SystemLog = new CSystemLog(m_sSysLogPath, "Optimizer");
                tmrSystemLog.Start();

                //m_cOptimizerClient.UEventMessage += m_cTrackerClient_UEventMessage;
                //m_cOptimizerClient.UEventMonitoringStart += m_cTrackerClient_UEventMonitoringStart;
                //m_cOptimizerClient.UEventMonitoringStop += m_cTrackerClient_UEventMonitoringStop;

                InitSetting();

                m_sAutoOpenUpmPath = ReadLastUpmPath();

                if (m_sAutoOpenUpmPath != "")
                {
                    //tmrChkOpenProject.Enabled = true;
                    //tmrChkOpenProject.Start();
                }

                if (File.Exists(CMultiProject.ExcuteDBPath) == false)
                {
                    CMultiProject.ExcuteDBPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                    CMultiProject.ExcuteDBBackupPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                    if (File.Exists(CMultiProject.ExcuteDBPath) == false)
                    {
                        XtraMessageBox.Show("DB가 설치되지 않았습니다.\r\n프로그램을 종료합니다.", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!m_bOptimizerAlive)
                {
                    //if (m_cOptimizerClient != null && m_cOptimizerClient.IsConnected)
                    //{
                    //    string[] saMess = { "Optimizer", "Optimizer 종료 성공!!" };
                    //    m_cOptimizerClient.SendMessageToServer(saMess);
                    //    m_cOptimizerClient.ClientDisconnect();
                    //}
                    tmrSystemLog.Stop();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #region Button Event

        private void itemOpenProject_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                string sPath = "";
                if (m_bUpmOpenFirst)
                {
                    sPath = m_sAutoOpenUpmPath;
                    m_bUpmOpenFirst = false;
                }

                if (sPath != null && sPath != "")
                {
                    DialogResult dlgResult = MessageBox.Show(string.Format("기존 프로젝트 경로가 존재합니다.\r\n\r\n{0}\r\n\r\n위 경로 파일을 열겠습니까?", sPath), "Load Project",
                                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == System.Windows.Forms.DialogResult.No)
                        sPath = "";
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
                    
                    CShowWaitForm.ShowForm("Open Project", string.Format("Openning Project File :\r\n{0}", sPath), "Start...", true);
                    {
                        bOK = CMultiProject.Open(sPath, out sMessage);
                    }
                    CShowWaitForm.CloseForm();

                    if (bOK)
                    {
                        CheckProjectNullProperties();

                        CMultiProject.ProjectPath = sPath;
                        WriteLastUpmPath();

                        CMultiProject.ComposeProcessLogicData();
                        CMultiProject.ComposePlcProcAbnormalSymbolS();

                        CMultiProject.PlcIDList.Clear();
                        foreach (var who in CMultiProject.PlcLogicDataS)
                            CMultiProject.PlcIDList.Add(who.Key);
                        if (CMultiProject.ProjectInfo.ViewRecipe == null)
                            CMultiProject.ProjectInfo.ViewRecipe = new CRecipeSection();

                        UpdateSystemMessage("열기", "성공");

                        //CheckOPCConnection(true);

                        Thread.Sleep(100);
                        //분석
                        SetSortTest();
                    }
                    else
                        UpdateSystemMessage("열기실패", sMessage + "  문제가 있습니다.");
                }
                else
                    UpdateSystemMessage("열기실패", "경로가 없습니다");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
            this.Text = string.Format("UDM Optimizer (UDMTEK)  Project Name : ( {0} ) File Path : ({1})", CMultiProject.ProjectName, CMultiProject.ProjectPath);
        }

        private void itemOpenDB_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                string sMessage = "저장된 데이터 베이스를 오픈합니다.\r\n오픈 시 기존 데이터 베이스는 모두 지워집니다.\r\n데이터 베이스 오픈을 진행하시겠습니까?";

                if (XtraMessageBox.Show(sMessage, "DB 오픈", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                UpdateSystemMessage("Open DB", "시작");

                if (!m_cReader.IsConnected)
                    m_cReader.Connect();

                if (!m_cReader.IsConnected)
                    XtraMessageBox.Show("Can't Connect to DB. Please Check Mysql Installation!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                sMessage = "DB 불러오기를 진행하기 전 현재까지의 DB를 백업합니다.\r\n진행하시겠습니까?";
                if (XtraMessageBox.Show(sMessage, "DB 백업", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (!Directory.Exists(m_sDBBackupPath))
                        Directory.CreateDirectory(m_sDBBackupPath);

                    DBBackup(CMultiProject.ExcuteDBBackupPath, m_sDBBackupPath + "\\" + string.Format("DB_Backup_{0}.sql", DateTime.Now.ToString("yyyyMMdd")));
                }

                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = ".sql|*.sql";
                dlgOpen.Title = "데이터 베이스 백업 파일 열기";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return;
                }

                string sPath = dlgOpen.FileName;

                if (sPath != string.Empty)
                {
                    string sError = string.Empty;

                    using (Process mysql = new Process())
                    {
                        CShowWaitForm.ShowForm("Open DB", string.Format("Openning DB File :\r\n{0}", sPath), "Start...", true);
                        {
                            //Maria DB의 경우 Path 다름
                            mysql.StartInfo.FileName = CMultiProject.ExcuteDBBackupPath;
                            mysql.StartInfo.UseShellExecute = false;
                            mysql.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -e \"\\. {0}\"", sPath);
                            mysql.StartInfo.RedirectStandardInput = false;
                            mysql.StartInfo.RedirectStandardOutput = false;
                            mysql.StartInfo.RedirectStandardError = true;
                            mysql.StartInfo.CreateNoWindow = true;
                            mysql.Start();

                            sError = mysql.StandardError.ReadToEnd();
                        }
                        CShowWaitForm.CloseForm();


                        if (sError != string.Empty)
                            XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("DB Open Success!!", "DB Open", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        mysql.WaitForExit();
                        mysql.Close();
                    }
                }
                dlgOpen.Dispose();
                dlgOpen = null;

                UpdateSystemMessage("Open DB", "성공");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Open DB", "실패");

                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemSymbolChart_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                FrmSymbolLogViewer frmViwer = new FrmSymbolLogViewer();
                frmViwer.Reader = m_cReader;
                frmViwer.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemCycleChart_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                FrmCycleLogViewer frmCycleLogView = new FrmCycleLogViewer();
                frmCycleLogView.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemSetting_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                FrmModel frmModel = new FrmModel();
                frmModel.UEventMessage += UpdateSystemMessage;
                frmModel.ShowDialog();

                if (frmModel.IsSaveExcute || frmModel.IsChangePlcList)
                    itemSaveProject_ItemClick(null, null); //SaveProject();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemAbnormalChart_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                FrmAbnormalViewer frmAbnormal = new FrmAbnormalViewer();
                frmAbnormal.Show();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemStatisticAnalysis_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                //FrmAnovaAnalysis frmAnova = new FrmAnovaAnalysis();
                //frmAnova.ShowDialog();

                //frmAnova.Dispose();
                //frmAnova = null;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void itemExit_ItemClick(object sender, TileItemEventArgs e)
        {
            if (XtraMessageBox.Show("Do you want to exit program?", "UDM Optimizer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void itemSaveProject_ItemClick(object sender, TileItemEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            string sPath = CMultiProject.ProjectPath;
            if (File.Exists(sPath) == false)
            {
                SaveFileDialog dlgSaveFile = new SaveFileDialog();
                dlgSaveFile.Filter = "*.umpo|*.umpo";
                dlgSaveFile.ShowDialog();

                sPath = dlgSaveFile.FileName;
                CMultiProject.ProjectPath = sPath;
            }

            UpdateSystemMessage("저장", "프로젝트 저장를 시작 : " + sPath);
            if (sPath != "")
                SaveProject(sPath);
            else
            {
                UpdateSystemMessage("저장실패", "경로가 없습니다");
                XtraMessageBox.Show("경로가 없습니다", "저장실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemSortCycle_ItemClick(object sender, TileItemEventArgs e)
        {
            //SetSortTest();
            //FrmWatting frmWait = new FrmWatting();
            //frmWait.Show();
            //원격 Sql 파일 당겨오기
            string sAppPath = Application.StartupPath + "\\원격PC DB Backup";
            if (Directory.Exists(sAppPath) == false)
                Directory.CreateDirectory(sAppPath);
            string sIPAddress = "192.168.0.23";
            string sFilePath = string.Format("{0}\\IP_{1}_{2}.sql", sAppPath, sIPAddress, DateTime.Now.ToString("yyyyMMddHHmmss"));
            
            using (Process mysql = new Process())
            {
                string sError = "";
                CShowWaitForm.ShowForm("원격 DB 백업", string.Format("원격 IP {0}\r\nPath :{1}", sIPAddress, sFilePath), "Reading...", true);
                {
                    //Maria DB의 경우 Path 다름
                    mysql.StartInfo.FileName = CMultiProject.ExcuteDBBackupPath;
                    //mysql.StartInfo.FileName =
                    //@"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysql.exe";
                    mysql.StartInfo.UseShellExecute = false;
                    mysql.StartInfo.Arguments = string.Format("-uroot -pudmt -h {0} plcms -r \"{1}\"", sIPAddress, sFilePath);
                    mysql.StartInfo.RedirectStandardInput = false;
                    mysql.StartInfo.RedirectStandardOutput = false;
                    mysql.StartInfo.RedirectStandardError = true;
                    mysql.StartInfo.CreateNoWindow = true;
                    mysql.Start();

                    sError = mysql.StandardError.ReadToEnd();
                }
                CShowWaitForm.CloseForm();

                if (sError != string.Empty)
                    XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    XtraMessageBox.Show("DB Open Success!!" + "\r\nPath : " + sFilePath, "DB Open", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                mysql.WaitForExit();
                mysql.Close();
            }
        }

        #endregion

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

                        CMultiProject.SystemLog = new CSystemLog(m_sSysLogPath, "Optimizer");

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
                CMultiProject.SystemLog.WriteLog("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrChkOpenProject_Tick(object sender, EventArgs e)
        {
            tmrChkOpenProject.Stop();
            tmrChkOpenProject.Enabled = false;

            //CMultiProject.SystemLog.WriteLog("자동열기", "기존 UMOP 경로 : " + m_sAutoOpenUpmPath);
            //itemOpenProject_ItemClick(null, null);
        }

        private void tileControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                if (XtraMessageBox.Show("Do you want to exit program?", "UDM Optimizer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }
        #endregion

        #region User Event

        #region Client Event

        private void m_cTrackerClient_UEventMessage(string sSender, string sMessage)
        {
            UpdateSystemMessage(sSender, sMessage);
        }

        private void m_cTrackerClient_UEventMonitoringStart(bool bConnect)
        {
            //if (!bConnect) return;

            //if (!m_cOptimizerServer.IsRunning)
            //{
            //    m_bMntAutoStart = true;
            //    btnMonitorStart_Click(null, null);
            //}
        }

        private void m_cTrackerClient_UEventMonitoringStop(bool bConnect)
        {
            //if (!bConnect) return;

            //if (m_cOptimizerServer.IsRunning)
            //{
            //    btnMonitorStop_Click(null, null);

            //    if (!m_cOptimizerServer.IsRunning)
            //    {
            //        this.Close();
            //    }
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        #endregion

        private void itemShowTracker_ItemClick(object sender, TileItemEventArgs e)
        {
            //Tracker 정보를 표시하는 데이터 View 보여줌.
            //수집된 데이터 정보표시 
            FrmShowTrackerInfo frmShowTracker = new FrmShowTrackerInfo();
            frmShowTracker.ShowDialog();

        }

        #endregion

        #endregion
    }
}