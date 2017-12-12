using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using TrackerCommon;
using TrackerWCF;
using UDM.General.Remote;
using UDM.Log;
using Microsoft.Win32;
using UDM.Log.DB;
using System.ServiceModel;
using System.Reflection;
using System.Runtime.InteropServices;


namespace UDMOptraManager
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private bool m_bManagerAlive = false;
        private bool m_bAutoRun = false;
        private bool m_bUnknownErrorAction = false;

        private string m_sSysLogPath = Application.StartupPath + "\\TrackerManagerSystemLog";

        private DataTable m_tblProjectInfo = new DataTable();
        private CServer<IMyService, CMyService> m_cServer = null;

        protected Dictionary<string, CService> m_dicClient = new Dictionary<string, CService>();
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);

        #endregion

        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();

            this.Visible = false;
            this.Hide();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            notifyIcon.Visible = true;

            RegistryKey registryKey;

            // 운영체제 check
            if (Environment.Is64BitOperatingSystem)
            {
                registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", true);
            }
            else
            {
                registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            }

            //레지스트리 등록
            if (registryKey.GetValue("UDMTrackerManager") == null)
            {
                registryKey.SetValue("UDMTrackerManager", Application.ExecutablePath.ToString());
            }

            registryKey.Close();
        }

        #endregion

        #region Public Methods

        public bool StartServer()
        {
            bool bOK = true;

            try
            {
                if (m_cServer == null)
                {
                    m_cServer = new CServer<IMyService, CMyService>();
                    m_cServer.Port -= 3;
                    m_cServer.ServiceName = "UDMTrackerManager";
                }

                if (m_cServer.IsRunning == false)
                    bOK = m_cServer.Start();

                if (bOK)
                {
                    m_cServer.Service.UEventReceiveClientMessage += Service_UEventReceiveClientMessage;
                    m_cServer.Service.UEventClientDisconnected += Service_UEventClientDisconnected;
                    m_cServer.Service.UEventClientConnected += Service_UEventClientConnected;
                    m_cServer.Service.UEventReceiveStatus += Service_UEventReceiveStatus;
                    m_cServer.Service.UEventReceiveProjectInfo += Service_UEventReceiveProjectInfo;
                    m_cServer.Service.UEventReceivceUnknownErrorAction += Service_UEventReceiveUnkownErrorAction;

                    UpdateSystemMessage("Tracker Manager", "Server Start Success!!");
                }
            }
            catch (System.Exception ex)
            {
                UpdateSystemMessage("Tracker Manager", "Server Start Fail!! : " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public void StopServer()
        {
            try
            {
                if (m_cServer != null && m_cServer.IsRunning)
                {
                    m_cServer.Service.UEventClientConnected -= Service_UEventClientConnected;
                    m_cServer.Service.UEventClientDisconnected -= Service_UEventClientDisconnected;
                    m_cServer.Service.UEventReceiveClientMessage -= Service_UEventReceiveClientMessage;
                    m_cServer.Service.UEventReceiveStatus -= Service_UEventReceiveStatus;
                    m_cServer.Service.UEventReceiveProjectInfo -= Service_UEventReceiveProjectInfo;
                    m_cServer.Service.UEventReceivceUnknownErrorAction -= Service_UEventReceiveUnkownErrorAction;

                    m_cServer.Stop();
                    m_cServer.Dispose();
                    m_cServer = null;
                }
            }
            catch (System.Exception ex)
            {
                UpdateSystemMessage("Tracker Manager", "Server Stop Fail!! : " + ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods

        private void ProjectInfoSetting()
        {
            try
            {
                if (CProjectManager.BaseProject != null && CProjectManager.BaseProject.ProjectName != null)
                {
                    dtpkOperStart.EditValue = CProjectManager.BaseProject.OperStartTime;
                    dtpkOperEnd.EditValue = CProjectManager.BaseProject.OperEndTime;
                    btnExcuteFilePath.EditValue = CProjectManager.BaseProject.ExcuteFilePath;
                    if(CProjectManager.BaseProject.DBBackupPath == "")
                        CProjectManager.BaseProject.DBBackupPath = CProjectManager.BaseProject.TrackerStartupPath + "\\TrackerDBBackup";
                    btnDBFilePath.EditValue = CProjectManager.BaseProject.DBBackupPath;
                    chkAutoControlApply.Checked = CProjectManager.BaseProject.IsAutoControl;

                    switch(CProjectManager.BaseProject.DBBackupCycle)
                    {
                        case 1:
                            cmbCBBackCycle.EditValue = "Monthly";
                            break;
                        case 3:
                            cmbCBBackCycle.EditValue = "Quarterly";
                            break;
                        case 6:
                            cmbCBBackCycle.EditValue = "Half a year";
                            break;
                    }
                }
                else
                    btnExcuteFilePath.EditValue = Application.StartupPath + "\\UDMTrackerSimple.exe";
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private bool CheckTrackerProcess()
        {
            bool bOK = false;

            try
            {
                Process[] aProcessTracker = Process.GetProcessesByName("UDMTrackerSimple");
                if (aProcessTracker != null && aProcessTracker.Length > 0)
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

        private bool CheckSPDProcess()
        {
            bool bOK = false;

            try
            {
                Process[] aProcessSPD= Process.GetProcessesByName("UDMSPDManager");
                if (aProcessSPD != null && aProcessSPD.Length > 0)
                    bOK = true;

                aProcessSPD = Process.GetProcessesByName("UDMSPDSingle");
                if (aProcessSPD != null && aProcessSPD.Length > 0)
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


        private bool CheckTrackerManagerProcess()
        {
            bool bOK = false;

            try
            {
                Process[] arrProcessManager = Process.GetProcessesByName("UDMTrackerManager");
                if (arrProcessManager != null && arrProcessManager.Length > 1)
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

        private bool TerminateOptraTracker()
        {
            try
            {
                Process[] aProcessTracker = Process.GetProcessesByName("UDMTrackerSimple");
                foreach (Process pro in aProcessTracker)
                    pro.Kill();

                Process[] aProcessSPDManager = Process.GetProcessesByName("UDMSPDManager");
                foreach (Process pro in aProcessSPDManager)
                    pro.Kill();

                Process[] aProcessSPDSingle = Process.GetProcessesByName("UDMSPDSingle");
                foreach (Process pro in aProcessSPDSingle)
                    pro.Kill();

                return true;

            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Tracker Manager", "UDM Tracker 종료에 실패했습니다. : " + ex.Message);
                ex.Data.Clear();
                return false;
            }
        }

        private void StartOptraTracker()
        {
            try
            {
                if (!File.Exists(CProjectManager.BaseProject.ExcuteFilePath))
                {
                    XtraMessageBox.Show("실행 파일 경로의 실행 파일이 존재하지 않습니다.", "UDM Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    UpdateInnerSystemMessage("Tracker Manager", "실행 파일 경로의 실행 파일이 존재하지 않음!");
                    return;
                }

                UpdateSystemMessage("Tracker Manager", "Tracker를 실행합니다.");
                UpdateInnerSystemMessage("Tracker Manager", "Tracker Process Start Command Start");

                Process processTracker = new Process();
                processTracker.StartInfo.FileName = CProjectManager.BaseProject.ExcuteFilePath;
                processTracker.Start();

                UpdateInnerSystemMessage("Tracker Manager", "Tracker Process Start Command End");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Tracker Manager", "UDM Tracker 실행에 실패했습니다. : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void CreateInfoTable()
        {
            try
            {
                m_tblProjectInfo = new DataTable();
                m_tblProjectInfo.Columns.Add("Group");
                m_tblProjectInfo.Columns.Add("Item");
                m_tblProjectInfo.Columns.Add("Value");

                if (CProjectManager.BaseProject != null)
                {
                    m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "이름", CProjectManager.BaseProject.ProjectName });
                    m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "경로", CProjectManager.BaseProject.ProjectPath });

                    if (CProjectManager.BaseProject.ProjectName == null)
                    {
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "모니터 타입", "" });
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "공정 개수", "" });
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "PLC 개수", "" });
                    }
                    else
                    {
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "모니터 타입", CProjectManager.BaseProject.MonitorType });
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "공정 개수", CProjectManager.BaseProject.OperationCount });
                        m_tblProjectInfo.Rows.Add(new object[] { "PROJECT", "PLC 개수", CProjectManager.BaseProject.PlcCount });
                    }

                    grdProjectInfo.DataSource = m_tblProjectInfo;
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

        private void SaveProject()
        {
            try
            {
                bool bOK = false;

                //UpdateSystemMessage("Tracker Manager", "Project 저장");

                bOK = CProjectManager.Save(CProjectManager.ManagerProjectPath);

                if (!bOK)
                {
                    UpdateSystemMessage("Tracker Manager", "Project 저장 실패");
                    return;
                }
                CreateInfoTable();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void OpenProject()
        {
            try
            {
                bool bOK = false;

                //UpdateSystemMessage("Tracker Manager", "프로젝트 열기 : " + CProjectManager.ManagerProjectPath);

                bOK = CProjectManager.Open(CProjectManager.ManagerProjectPath);

                if (!bOK)
                {
                    UpdateSystemMessage("Tracker Manager", "Project 열기 실패");
                    return;
                }
                CreateInfoTable();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
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
                    ucManagerSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    CProjectManager.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void UpdateInnerSystemMessage(string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateInnerSystemMessage);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    CProjectManager.SystemLog.WriteLog("Inner System : " + sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        protected void UpdateTrackerSystemMessage(string sSender, string sMessage)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateTrackerSystemMessage);
                    this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
                }
                else
                {
                    ucTrackerSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    CProjectManager.SystemLog.WriteLog("Tracker Sytem : " + sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private bool IsLSOPCServerOpen()
        {
            bool bOK = false;

            try
            {
                Process[] arrOPCProcess = System.Diagnostics.Process.GetProcessesByName("LGOPCConfig");

                if (arrOPCProcess.Length > 0)
                    bOK = true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("LS산전 OPC 확인 에러", ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private void AutoDatabaseBackup()
        {
            try
            {
                int iCycle = CProjectManager.BaseProject.DBBackupCycle;
                DateTime dtNow = DateTime.Now;

                if (dtNow.Day == 1)
                {
                    if (iCycle == 3)
                        if (dtNow.Month != 1 && dtNow.Month != 4 && dtNow.Month != 7 && dtNow.Month != 10) return;

                    else if (iCycle == 6)
                        if (dtNow.Month != 1 && dtNow.Month != 7) return;

                    bool bOK = TrackerDBBackup();
                    if (bOK)
                    {
                        //DB Backup 5분 후 DataBase Recreate
                        tmrAutoDBRecreate.Enabled = true;
                        tmrAutoDBRecreate.Start();
                    }
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

        private bool TrackerDBBackup()
        {
            try
            {
                if (CProjectManager.BaseProject.TrackerStartupPath == null || CProjectManager.BaseProject.TrackerStartupPath == "") return false;

                string sSQLDumpPath = @"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                //string sSQLDumpPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                string sDBBackupPath = CProjectManager.BaseProject.DBBackupPath;
                string sFileName = "\\" + string.Format("DB_Backup_{0}", DateTime.Now.ToString("yyyyMMdd")) + ".sql";
                string sPath = sDBBackupPath + sFileName;
                string sError = string.Empty;

                if (!File.Exists(sSQLDumpPath))
                {
                    //UpdateSystemMessage("Auto DBBackup", "DB Dump Path가 존재하지 않습니다.");
                    sSQLDumpPath = @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                    if (!File.Exists(sSQLDumpPath))
                    {
                        UpdateSystemMessage("Auto DBBackup", "DB Dump Path가 존재하지 않습니다.");
                        return false;
                    }
                }

                if (!Directory.Exists(sDBBackupPath))
                    Directory.CreateDirectory(sDBBackupPath);

                using (Process mysqlDump = new Process())
                {
                    SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                    {
                        mysqlDump.StartInfo.FileName = sSQLDumpPath;
                        mysqlDump.StartInfo.UseShellExecute = false;
                       
                        //mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms tblTimeLog -r \"{0}\"", sPath);  //tblTimeLog만 Dump
                        mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -r \"{0}\"", sPath);
                        mysqlDump.StartInfo.RedirectStandardInput = false;
                        mysqlDump.StartInfo.RedirectStandardOutput = false;
                        mysqlDump.StartInfo.RedirectStandardError = true;
                        mysqlDump.StartInfo.CreateNoWindow = true;
                        mysqlDump.Start();

                        sError = mysqlDump.StandardError.ReadToEnd();
                    }
                    SplashScreenManager.CloseForm(false);

                    if (sError != string.Empty)
                    {
                        UpdateSystemMessage("DB Backup", "Error : " + sError);
                        return false;
                    }
                    else
                        UpdateSystemMessage("DB Backup", "DB Backup Success!!");

                    mysqlDump.WaitForExit();
                    mysqlDump.Close();
                }

                string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                if (sError == string.Empty && Directory.Exists(sFolderPath))
                    Process.Start(sFolderPath);

                return true;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
                return false;
            }
        }

        private void DeleteTimeLog()
        {
            CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
            try
            {
                DateTime dtFrom = DateTime.Now.AddDays(-7); // 7일 전 Data 까지만 Delete
                bool bOK = cLogWriter.Connect();

                if (bOK)
                    bOK = cLogWriter.ClearTimeLogS(dtFrom);

                if (!bOK)
                    UpdateSystemMessage("Delete TimeLogS", "Failed to delete TimeLogS.");
            }
            catch(Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
            finally
            {
                cLogWriter.Disconnect();
                cLogWriter.Dispose();
                cLogWriter = null;
            }
        }

        private void RecreateDataBase()
        {
            CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
            try
            {
                bool bOK = cLogWriter.Connect();
                if (bOK)
                {
                    bOK = cLogWriter.DropDataBase();
                    if (bOK)
                        cLogWriter.CreateDB();

                    UpdateSystemMessage("Recreate DB", "Succeed.");
                }

                if (!bOK)
                    UpdateSystemMessage("Recreate DB", "Failed.");
            }
            catch (Exception ex)
            {
                UpdateSystemMessage(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
            finally
            {
                cLogWriter.Disconnect();
                cLogWriter.Dispose();
                cLogWriter = null;
            }
        }

        #endregion

        #region Event Methods

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                bool bOK = false;

                if (CheckTrackerManagerProcess())
                {
                    XtraMessageBox.Show("이미 Tracker Manager가 실행 중입니다.", "Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    m_bManagerAlive = true;
                    this.Close();
                    return;
                }
                else
                    m_bManagerAlive = false;

                CProjectManager.SystemLog = new CSystemLog(m_sSysLogPath, "TrackerManager");
                tmrSystemLog.Start();

                bOK = StartServer();

                if (!bOK)
                {
                    XtraMessageBox.Show("Server 실행에 실패했습니다.", "Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(CProjectManager.ManagerProjectPath))
                    SaveProject();

                else
                    OpenProject();

                ProjectInfoSetting();

                Application.ApplicationExit += Application_ApplicationExit;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!m_bManagerAlive)
                {
                    StopServer();
                    tmrSystemLog.Stop();
                    CProjectManager.SystemLog.WriteLog("FormClose", "모든 프로세스를 종료 했습니다.");
                    CProjectManager.SystemLog.WriteEndLog();
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

        private void btnManualStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_dicClient != null && m_dicClient.Count != 0)
                {
                    XtraMessageBox.Show("Tracker가 이미 실행 중 입니다.", "UDM Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                if (CheckTrackerProcess())
                {
                    XtraMessageBox.Show("Tracker가 이미 실행 중 입니다.", "UDM Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                ////쌍용 대응 코드
                //if (!IsLSOPCServerOpen())
                //{
                //    XtraMessageBox.Show("LS OPC Server가 꺼져 있습니다.\r\nLS OPC Server를 먼저 실행시켜주세요.", "OPC Connect Error",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                DialogResult dlgResult = XtraMessageBox.Show("Tracker를 실행하시겠습니까?", "UDM Tracker Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    return;

                UpdateInnerSystemMessage("Tracker Manager", "수동 시작 Start");

                StartOptraTracker();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnManualStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_dicClient == null || m_dicClient.Count == 0)
                {
                    XtraMessageBox.Show("실행중인 Tracker가 없습니다.", "UDM Tracker Manager", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult dlgResult = XtraMessageBox.Show("Tracker를 종료하시겠습니까?", "UDM Tracker Manager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    return;

                UpdateInnerSystemMessage("Tracker Manager", "수동 종료 Start");

                SendStopCommand();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Opacity = 100;
                this.Show();
                this.Activate();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Opacity = 100;
                this.Show();
                this.Activate();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            btnExit_ItemClick(null, null);
        }

        private void mnuHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (m_dicClient.Count > 0 || IndiOptra.StateIndex == 3)
                {
                    XtraMessageBox.Show("Tracker가 연결되어 있습니다.\nTracker 종료 후 종료 해 주세요.", "UDM Tracker Manager",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (
                    XtraMessageBox.Show("Tracker Manager를 종료하시겠습니까?", "UDMTrackerManager", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                notifyIcon.Visible = false;
                notifyIcon.Dispose();

                SaveProject();
                Application.Exit();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                StopServer();
                tmrSystemLog.Stop();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnExcuteFilePath_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(*.exe)|*.exe";
                ofd.ShowDialog();

                if (ofd.FileName != null && ofd.FileName != "")
                {
                    btnExcuteFilePath.EditValue = ofd.FileName;
                    CProjectManager.BaseProject.ExcuteFilePath = btnExcuteFilePath.EditValue.ToString();
                    SaveProject();
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

        private void chkAutoControlApply_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (chkAutoControlApply.Checked)
                {
                    if (btnExcuteFilePath.EditValue != null && !File.Exists(btnExcuteFilePath.EditValue.ToString()))
                    {
                        XtraMessageBox.Show("실행 파일 경로의 실행 파일이 존재하지 않습니다.", "UDM Tracker Manager", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        chkAutoControlApply.Checked = false;
                        return;
                    }

                    if (CProjectManager.BaseProject.MonitorType != EMMonitorType.Detection)
                    {
                        XtraMessageBox.Show("Tracker의 MonitorType이 Detection일 때만 적용 가능합니다.", "UDM Tracker Manager",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        chkAutoControlApply.Checked = false;
                        return;
                    }
                }

                if (chkAutoControlApply.Checked)
                {
                    CProjectManager.BaseProject.IsAutoControl = true;
                    IndiAutoControl.StateIndex = 3;
                    tmrAutoRestart.Start();
                    dtpkOperStart.Enabled = false;
                    dtpkOperEnd.Enabled = false;

                    UpdateSystemMessage("Tracker Manager", "자동 제어 옵션이 적용되었습니다.");
                }
                else
                {
                    CProjectManager.BaseProject.IsAutoControl = false;
                    IndiAutoControl.StateIndex = 0;
                    tmrAutoRestart.Stop();
                    dtpkOperStart.Enabled = true;
                    dtpkOperEnd.Enabled = true;

                    m_bAutoRun = false;

                    UpdateSystemMessage("Tracker Manager", "자동 제어 옵션이 해제되었습니다.");
                }
                SaveProject();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }



        private void dtpkOperStart_EditValueChanged(object sender, EventArgs e)
        {
            CProjectManager.BaseProject.OperStartTime = (DateTime)dtpkOperStart.EditValue;
        }

        private void dtpkOperEnd_EditValueChanged(object sender, EventArgs e)
        {
            CProjectManager.BaseProject.OperEndTime = (DateTime)dtpkOperEnd.EditValue;
        }

        private void btnLSOPCOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Process[] arrOPCProcess = System.Diagnostics.Process.GetProcessesByName("LGOPCConfig");

                if (arrOPCProcess.Length > 0)
                {
                    XtraMessageBox.Show("LS OPC 서버가 이미 실행중입니다.\r\n작업 관리자를 통해 OPC 서버 실행 여부를 확인하세요.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(@"C:\LSIS_OPC\LGEDrv.exe") || !File.Exists(@"C:\LSIS_OPC\LGOPCConfig.EXE"))
                {
                    XtraMessageBox.Show("LS OPC 서버가 설치되지 않았습니다.\r\nLS OPC 서버를 설치해주세요.", "OPC 열기 에러",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (System.Diagnostics.Process cmd = new Process())
                {
                    cmd.StartInfo.FileName = @"cmd";
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardError = true;
                    cmd.StartInfo.RedirectStandardOutput = false;

                    cmd.Start();

                    cmd.StandardInput.Write(@"C:\LSIS_OPC\LGEDrv.exe" + Environment.NewLine);
                    cmd.StandardInput.Write(@"C:\LSIS_OPC\LGOPCConfig.EXE" + Environment.NewLine);

                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    cmd.Close();
                }
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("LS산전 OPC 열기 에러", ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnLogicExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Title = "LS 산전 프로젝트 파일 열기";
                dlgOpen.Filter = ".xgwx|*.xgwx";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    dlgOpen.Dispose();
                    dlgOpen = null;
                    return;
                }

                string sPath = dlgOpen.FileName;
                string sError = string.Empty;

                if (sPath != string.Empty)
                {
                    using (System.Diagnostics.Process cmd = new Process())
                    {
                        SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                        {
                            cmd.StartInfo.FileName = @"cmd";
                            cmd.StartInfo.CreateNoWindow = true;
                            cmd.StartInfo.UseShellExecute = false;
                            cmd.StartInfo.RedirectStandardInput = true;
                            cmd.StartInfo.RedirectStandardError = true;
                            cmd.StartInfo.RedirectStandardOutput = true;

                            cmd.Start();

                            string sCommand = string.Format("C:\\XG5000\\XG5000.exe /convert:il {0}", sPath);

                            cmd.StandardInput.Write(sCommand + Environment.NewLine);

                            cmd.StandardInput.Close();
                            sError = cmd.StandardError.ReadToEnd();
                        }
                        SplashScreenManager.CloseForm(false);

                        if (sError != string.Empty)
                            XtraMessageBox.Show(sError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            XtraMessageBox.Show("Export Success!!", "Logic Export", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        cmd.WaitForExit();
                        cmd.Close();

                        string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("\\"));
                        if (sError == string.Empty && Directory.Exists(sFolderPath))
                            Process.Start(sFolderPath);
                    }
                }

                dlgOpen.Dispose();
                dlgOpen = null;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("LS로직 추출 에러", ex.Message);
                ex.Data.Clear();
            }
        }

        private void tmrAutoRestart_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoControlApply.Checked && CProjectManager.BaseProject.MonitorType == EMMonitorType.Detection)
                {
                    DateTime dtNow = DateTime.Now;

                    // 라인 Stop 시간에 Monitoring Stop / Optra Stop
                    if (CProjectManager.BaseProject.OperEndTime.Hour == dtNow.Hour &&
                        CProjectManager.BaseProject.OperEndTime.Minute == dtNow.Minute)
                    {
                        SendStopCommand();
                        AutoDatabaseBackup();
                    }

                    // 라인 Start 시간 Monitoring 시작 // Monitoring Mode가 Detection 일 때 실행
                    if (CProjectManager.BaseProject.OperStartTime.Hour == dtNow.Hour &&
                        CProjectManager.BaseProject.OperStartTime.Minute == dtNow.Minute)
                    {
                        m_bAutoRun = true;

                        //if (CheckTrackerProcess()) // Tracker가 실행중인 경우
                        //    SendMonitoringStartCommand();
                        //else // Tracker가 실행중이 아닌 경우
                        //    StartOptraTracker();

                        if (CheckTrackerProcess())// && !CheckSPDProcess()) //Tracker Process만 실행중인 경우
                        {
                            TerminateOptraTracker();

                            m_dicClient.Clear();
                            IndiOptra.StateIndex = 0;
                            IndiMonitoring.StateIndex = 0;
                            IndiOPC.StateIndex = 0;

                            StartOptraTracker();
                        }
                        //else if (CheckTrackerProcess() && CheckSPDProcess()) // Tracker & SPD Process가 모두 실행중인 경우
                        //    SendMonitoringStartCommand();

                        else // 모두 실행중이지 않은 경우
                            StartOptraTracker();
                    }
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
                    if (CProjectManager.SystemLog != null)
                    {
                        CProjectManager.SystemLog.WriteLog("SystemLog", "새로운 파일을 생성합니다.(주기 1시간)");
                        string sFileName = CProjectManager.SystemLog.FileName;
                        CProjectManager.SystemLog.WriteEndLog();
                        CProjectManager.SystemLog = new CSystemLog(m_sSysLogPath, "TrackerManager");
                        CProjectManager.SystemLog.WriteLog("SystemLog", "이전 파일 : " + sFileName);
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
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrStartMonitoring_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoControlApply.Checked || m_bUnknownErrorAction)
                {
                    SendMonitoringStartCommand();
                    tmrStartMonitoring.Stop();
                    m_bUnknownErrorAction = false;
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

        private void cmbCBBackCycle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int iCycle = 0;
                switch (cmbCBBackCycle.EditValue.ToString())
                {
                    case "Monthly":
                        iCycle = 1;
                        break;
                    case "Quarterly":
                        iCycle = 3;
                        break;
                    case "Half a year":
                        iCycle = 6;
                        break;
                }
                CProjectManager.BaseProject.DBBackupCycle = iCycle;
                SaveProject();
            }
            catch(Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                    ex.Message));
                ex.Data.Clear();
            }
        }


        #region User Event

        private void Service_UEventClientConnected(object sender, string sClient)
        {
            try
            {
                CService cService = (CService)sender;
                if (m_dicClient.ContainsKey(sClient) == false)
                {
                    //SplashScreenManager.ShowForm(this, typeof (FrmWaitForm), true, true, false);
                    //{
                    m_dicClient.Add(sClient, cService);
                    string sCount = m_dicClient.Count.ToString();
                    UpdateSystemMessage(sClient, "Connect Success!!");

                    IndiOptra.StateIndex = 3;

                    DateTime dtNow = DateTime.Now;

                    if (CProjectManager.BaseProject.OperStartTime.Hour != dtNow.Hour ||
                        CProjectManager.BaseProject.OperStartTime.Minute != dtNow.Minute)
                        m_bAutoRun = false;

                    //}
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Service_UEventClientDisconnected(object sender, string sClient)
        {
            try
            {
                if (m_dicClient.ContainsKey(sClient))
                {
                    m_dicClient.Remove(sClient);
                    string sCount = m_dicClient.Count.ToString();
                    UpdateSystemMessage(sClient, "Disconnect Success!!");

                    IndiOptra.StateIndex = 0;
                    IndiMonitoring.StateIndex = 0;
                    IndiOPC.StateIndex = 0;

                    //SplashScreenManager.CloseForm(false); // 종료 할 때 실행 된 WaitForm 종료

                    //if (chkAutoControlApply.Checked)
                    //    chkAutoControlApply.Checked = false;
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveClientMessage(object sender, string[] saData)
        {
            try
            {
                string sData = "";
                for (int i = 1; i < saData.Length; i++)
                    sData += saData[i] + ", ";

                sData = sData.Substring(0, sData.LastIndexOf(','));
                if (sData.Contains("ALIVE"))
                    UpdateInnerSystemMessage(saData[0], sData);
                else
                    UpdateTrackerSystemMessage(saData[0], sData);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveStatus(object sender, string[] saData)
        {
            try
            {
                if (saData != null)
                {
                    string sData = "";
                    for (int i = 1; i < saData.Length; i++)
                        sData += saData[i] + " ";

                    string sMode = saData[1];
                    string sStatus = saData[2];

                    //Monitoring
                    if (sMode.Equals("Monitoring"))
                    {
                        if (sStatus.Equals("Start"))
                            IndiMonitoring.StateIndex = 3;
                        else
                            IndiMonitoring.StateIndex = 0;

                        UpdateSystemMessage(saData[0], sData);
                    }

                    // OPC Connection
                    else if (sMode.Equals("OPC"))
                    {
                        string sValue = saData[3];
                        bool bCallLoadMethod = sValue == "True" ? true : false;

                        if (sStatus.Contains("Nonconnect"))
                            IndiOPC.StateIndex = 1;
                        else
                            IndiOPC.StateIndex = 3;

                        if (bCallLoadMethod)
                        {
                            tmrUnkownErrorAction.Stop();
                            sData = sData.Replace("True ", string.Empty);
                        }
                        else
                            sData = sData.Replace("False ", string.Empty);

                        //SplashScreenManager.CloseForm(false); // Optra Start 때 실행 된 WaitForm OPC Connection 까지 진행되고 종료

                        if (m_bUnknownErrorAction)
                            tmrStartMonitoring.Start();
                        else
                        {
                            if (m_bAutoRun && bCallLoadMethod)
                                tmrStartMonitoring.Start(); // 자동제어옵션이 적용된 경우에만 Optra 실행 60초 후에 Monitoring 시작
                            else
                                m_bAutoRun = false;
                        }

                        UpdateSystemMessage(saData[0], sData);
                    }
                    else if (sMode.Equals("MonitorType"))
                    {
                        CProjectManager.BaseProject.MonitorType =
                            (EMMonitorType)Enum.Parse(typeof(EMMonitorType), sStatus);
                        SaveProject();

                        if (chkAutoControlApply.Checked)
                        {
                            if (!sStatus.Equals("Detection")) //Detection Mode가 아닌데 자동제어가 적용되어 있을 경우 해제
                                chkAutoControlApply.Checked = false;
                        }
                    }
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveProjectInfo(object sender, string[] saData)
        {
            try
            {
                if (saData != null)
                {
                    string[] saInfo = saData[1].Split(',');
                    CProjectManager.BaseProject.ProjectName = saInfo[0];
                    CProjectManager.BaseProject.ProjectPath = saInfo[1];
                    CProjectManager.BaseProject.MonitorType =
                        (EMMonitorType)Enum.Parse(typeof(EMMonitorType), saInfo[2]);
                    CProjectManager.BaseProject.OperationCount = Int32.Parse(saInfo[3]);
                    CProjectManager.BaseProject.PlcCount = Int32.Parse(saInfo[4]);
                    CProjectManager.BaseProject.TrackerStartupPath = saInfo[5];
                    CProjectManager.BaseProject.ProjectSaveTime = DateTime.Now;
                    //CProjectManager.BaseProject.ProjectID = saInfo[6];

                    SaveProject();
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        private void Service_UEventReceiveUnkownErrorAction(object sender, string[] saData)
        {
            try
            {
                UpdateSystemMessage("TrackerManager", "Unknown Error가 발생하여 Tracker를 재시작 합니다.");

                SendStopCommand();
                tmrUnkownErrorAction.Start();
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        /// <summary>
        /// Optra Manager -> Tracker
        /// </summary>
        /// <param name="saData"></param>
        private void SendMonitoringStartCommand()
        {
            try
            {
                if (m_cServer != null && m_cServer.IsRunning)
                {
                    if (m_cServer.Service != null)
                    {
                        try
                        {
                            if (CProjectManager.BaseProject.MonitorType != EMMonitorType.Detection)
                            {
                                //XtraMessageBox.Show("Monitoring을 시작 할 수 없습니다.\nTracker의 수집모드가 Detection이 아닙니다.",
                                //  "UDM Tracker Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            if (IndiMonitoring.StateIndex == 3)
                                return;

                            UpdateInnerSystemMessage("Tracker Manager", "SendMonitoringStartCommandToTracker Start");

                            string[] saData = { "Tracker Manager", "Monitoring Start" };
                            m_cServer.Service.SendStartCommandToClient(saData);

                            UpdateSystemMessage("Tracker Manager", "Tracker Monitoring을 시작합니다.");
                            UpdateInnerSystemMessage("Tracker Manager", "SendMonitoringStartCommandToTracker END");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                            Console.WriteLine("Error : {0} [{1}]", ex.Message,
                                System.Reflection.MethodBase.GetCurrentMethod().Name);
                            ex.Data.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                    }
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        /// <summary>
        /// Optra Manager -> Tracker
        /// </summary>
        /// <param name="saData"></param>
        private void SendStopCommand()
        {
            try
            {
                if (m_cServer != null && m_cServer.IsRunning)
                {
                    if (m_cServer.Service != null)
                    {
                        try
                        {
                            string sExportReport = "Report";
                            if (chkAutoControlApply.Checked && chkAutoReportExport.Checked && DateTime.Now.Day == 1)
                                sExportReport = "ExportReport";
                            
                            
                            UpdateInnerSystemMessage("Tracker Manager", "SendStopCommandToTracker 시작");

                            string[] saData = { "Tracker Manager", "Stop", sExportReport };

                            m_cServer.Service.SendStopCommandToClient(saData);

                            UpdateInnerSystemMessage("Tracker Manager", "SendStopCommandToTracker 완료");

                            UpdateSystemMessage("Tracker Manager", "Tracker를 종료합니다.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("CMyService SendToClient Error: {0}", ex.Message);
                            Console.WriteLine("Error : {0} [{1}]", ex.Message,
                                System.Reflection.MethodBase.GetCurrentMethod().Name);
                            UpdateInnerSystemMessage("Tracker Manager Error", "CMyService SendToClient Error: " + ex.Message);
                            ex.Data.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("CMyService SendToClient Error: No Services !!!");
                    }
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                UpdateSystemMessage("Server", "Tracker와 연결이 끊겼습니다. 다시 연결합니다." + ex.Message);

                StopServer();
                StartServer();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain",
                    string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                        ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion

        #endregion

        private void btnDBFilePath_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
                DialogResult dlgResult = dlgFolder.ShowDialog();
                if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

                btnDBFilePath.EditValue = dlgFolder.SelectedPath;
                CProjectManager.BaseProject.DBBackupPath = dlgFolder.SelectedPath;
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrAutoDBRecreate_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrAutoDBRecreate.Stop();
                tmrAutoDBRecreate.Enabled = false;

                RecreateDataBase();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void tmrUnkownErrorAction_Tick(object sender, EventArgs e)
        {
            try
            {
                tmrUnkownErrorAction.Stop();
                m_bUnknownErrorAction = true;

                if (CheckTrackerProcess())// && !CheckSPDProcess()) //Tracker Process만 실행중인 경우
                {
                    TerminateOptraTracker();

                    m_dicClient.Clear();
                    IndiOptra.StateIndex = 0;
                    IndiMonitoring.StateIndex = 0;
                    IndiOPC.StateIndex = 0;

                    StartOptraTracker();
                }
                else // 모두 실행중이지 않은 경우
                    StartOptraTracker();
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("FrmMain", string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

    }
}
