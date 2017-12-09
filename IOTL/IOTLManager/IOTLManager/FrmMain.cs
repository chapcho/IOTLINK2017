using IOTL.Common.Log;
using System;
using System.Text;
using System.Windows.Forms;

using IOTL.Socket;
using SuperSocket.SocketBase.Config;
using IOTL.Socket.ClientSession;
using SocketGlobal;
using IOTL.Common;
using IOTL.Common.DB;
using IOTLManager.Util;
using IOTL.Common.Framework;
using MySql.Data.MySqlClient;
using IOTL.Common.Util;
using IOTLManager.UserControls;
using System.Data;

namespace IOTLManager
{
    public partial class FrmMain : Form
    {
        public const string APPLICATION_NAME = "IOTLink Data Manager";
        #region private value define
        private MySqlLogReader DBReader = new MySqlLogReader();
        private LogManager LOG = new LogManager();
        private LogProcessor logProcessor;

        protected delegate void UpdateTextCallBack(string sSender, string sMessage);

        #endregion

        public FrmMain()
        {
            InitializeComponent();

            // Initialize Other Configuration...
            // Start System Log Configuration Path : AppPath\LogConfig.xml

            LOG.AppLog.appendInfoLog("Starting...");

            // UserControl에서 Form에 보내는 메시지
            ucSocketServer1.UEventMessage += UpdateSystemMessage;
            ucSocketServer1.UEventFileLog += WriteMessageToLogfile;
            ucSocketServer1.UEventMachineStateTimeLog += EventHandler_UEventMachineStateTimeLog;
            // Socket Control에서 Form에 보내는 수신 데이터.

            // Log(DataBase) 기록을 시작한다.
            if (logProcessor == null)
            {
                bool bOK = false;

                logProcessor = new LogProcessor();
                logProcessor.UEventIOTLMessage += UpdateSystemMessage;
                logProcessor.UEventFileLog += WriteMessageToLogfile;
                
                bOK = logProcessor.Run();
                if (bOK == false)
                {
                    UpdateSystemMessage("Main", "DB Writer 시작 실패");
                    // return bOK;
                }
            }

            DBReader.Connect();
            if(DBReader.IsConnected)
            {
                UpdateSystemMessage("Main", "DB Reader Connected!");
            }
            else
            {
                UpdateSystemMessage("Main", "DB Reader NotConnected!");
            }

            // Compressor Monitor에서 발생하는 이벤트 처리자 연결.
            ucCompressorDataManager1.UEventMessage += UpdateSystemMessage;
            ucCompressorDataManager1.UEventFileLog += WriteMessageToLogfile;

        }

        /// <summary>
        /// 소켓으로 부터 수신한 데이터를 로그 처리기에 저장합니다.
        /// 메시지와 바이트 문자열이 들어 있습니다.
        /// 로그 처리기에서 파싱해서 처리하도록 합니다.
        /// </summary>
        /// <param name="emLogType"></param>
        /// <param name="cLog"></param>
        private void EventHandler_UEventMachineStateTimeLog(CTimeLog cLog)
        {
            if (logProcessor != null)
                logProcessor.EnQue(cLog);
        }

        public void WriteMessageToLogfile(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string sLogMessage)
        {
            LogFuncDelegate logFunc = null;

            switch (emFileLogType)
            {
                case EMFileLogType.ApplicationLog:
                    switch (emFileLogDepth)
                    {
                        case EMFileLogDepth.Debug: logFunc = LOG.AppLog.appendDebugLog; break;
                        case EMFileLogDepth.Error: logFunc = LOG.AppLog.appendErrorLog; break;
                        case EMFileLogDepth.Fatal: logFunc = LOG.AppLog.appendFatalLog; break;
                        case EMFileLogDepth.Info: logFunc = LOG.AppLog.appendInfoLog; break;
                        case EMFileLogDepth.Warn: logFunc = LOG.AppLog.appendWarnLog; break;
                    }
                    break;
                case EMFileLogType.CommunicationLog:
                    switch (emFileLogDepth)
                    {
                        case EMFileLogDepth.Debug: logFunc = LOG.SocketLog.appendDebugLog; break;
                        case EMFileLogDepth.Error: logFunc = LOG.SocketLog.appendErrorLog; break;
                        case EMFileLogDepth.Fatal: logFunc = LOG.SocketLog.appendFatalLog; break;
                        case EMFileLogDepth.Info: logFunc = LOG.SocketLog.appendInfoLog; break;
                        case EMFileLogDepth.Warn: logFunc = LOG.SocketLog.appendWarnLog; break;
                    }
                    break;
                case EMFileLogType.DatabaseLog:
                    switch (emFileLogDepth)
                    {
                        case EMFileLogDepth.Debug: logFunc = LOG.DbLog.appendDebugLog; break;
                        case EMFileLogDepth.Error: logFunc = LOG.DbLog.appendErrorLog; break;
                        case EMFileLogDepth.Fatal: logFunc = LOG.DbLog.appendFatalLog; break;
                        case EMFileLogDepth.Info: logFunc = LOG.DbLog.appendInfoLog; break;
                        case EMFileLogDepth.Warn: logFunc = LOG.DbLog.appendWarnLog; break;
                    }
                    break;
            }

            if (logFunc != null) logFunc(sLogMessage);

            // 시스템 메시지에도 출력한다면..
            // UpdateSystemMessage(emFileLogType.ToString(), sLogMessage);
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IOTL DataManager Ver 1.0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            LOG.AppLog.appendErrorLog("Log Sample");

            
            // 이 스플레쉬 윈도우의 타이틀을 로딩시에 바꿀수 있도록 해야 겠다.
            SplashWnd.SplashShow();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 사용자가 상태 변경 해야 하는 서비스가 중지 되었는지 확인

            ucSocketServer1.UEventMessage -= UpdateSystemMessage;
            ucSocketServer1.UEventFileLog -= WriteMessageToLogfile;
            ucSocketServer1.UEventMachineStateTimeLog -= EventHandler_UEventMachineStateTimeLog;

            LOG.AppLog.appendInfoLog("Normal Closed!!!");

            if (logProcessor != null)
            {
                logProcessor.Stop();
                while(logProcessor.IsRunning)
                {
                    System.Threading.Thread.Sleep(10);
                }

                LOG.AppLog.appendInfoLog("DB Writer Closed.");
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
                    ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    // CMultiProject.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CreateIOTLManagerDB()
        {
            string sMessage = "데이터 베이스를 새롭게 생성합니다.\r\n데이터 베이스 생성시 저장된 모든 데이터가 지워집니다.\r\n데이터 베이스를 생성하시겠습니까?";
            bool bOK = true;

            if (MessageBox.Show(sMessage, APPLICATION_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {

                MySqlLogWriter cLogWriter = new MySqlLogWriter();
                bOK = cLogWriter.CreateDB();

                cLogWriter.Dispose();
                cLogWriter = null;

                if (bOK == false)
                {
                    MessageBox.Show("DB를 생성할 수 없습니다. DB 설치를 다시 확인해주세요!!", APPLICATION_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("DB 생성 성공!!\r\n종료합니다.", APPLICATION_NAME,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (DBReader != null)
                    {
                        DBReader.Disconnect();
                        DBReader.Dispose();
                        DBReader = null;
                    }

                    this.Close();
                    DBReader = new MySqlLogReader();
                    DBReader.Connect();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            UpdateSystemMessage(Application.ProductName, "IOTLink Manager DB 생성 완료");
        }


        private void CreateDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// 데이터 베이스 생성
            /// 
            CreateIOTLManagerDB();
        }

        private void menuServerConfig_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// MySQL Database의 백업과 복원에 관한 절차
        /// 외부 참조
        /// https://stackoverflow.com/questions/12311492/backing-up-database-in-mysql-using-c-sharp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuBackupDatabase_Click(object sender, EventArgs e)
        {
            using (MySQLBackupForm frm = new MySQLBackupForm(DBReader.GetDbConnection()))
            {
                frm.ShowDialog();
            }
        }

        private void menuRestoreDatabase_Click(object sender, EventArgs e)
        {
            MessageBox.Show("데이터베이스를 복원합니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SplashWnd.SplashClose(this);
        }

        private void btnClientStatusRefresh_Click(object sender, EventArgs e)
        {
            string strQuery = "Select * From machinestate";
            DisplayToDataGridReportWithQuery(strQuery);
        }

        private void btnClientHistoryRefresh_Click(object sender, EventArgs e)
        {
            string strQuery = "Select * From machinestatelog order by LastEventTime desc Limit 100 offset 100";
            DisplayToDataGridReportWithQuery(strQuery);
        }

        private void btnMachineList_Click(object sender, EventArgs e)
        {
            string strQuery = "Select * From machineInfo";
            DisplayToDataGridReportWithQuery(strQuery);
        }

        private void DisplayToDataGridReportWithTableName(string tableName)
        {
            string strQuery = string.Empty;

            switch(tableName.ToLower())
            {
                case "iotlink.machinestatelog":
                    strQuery = "Select * From iotlink.machinestatelog order by LastEventTime desc Limit 100 offset 100;";
                    break;
                default:
                    strQuery = string.Format("select * From {0};", tableName);
                    break;
            }

            DisplayToDataGridReportWithQuery(strQuery);
        }

        private void DisplayToDataGridReportWithQuery(string sqlQuery)
        {
            try
            {
                dataGridReport.Columns.Clear();

                dataGridReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                DataTable dt = DBReader.GetQueryResult(sqlQuery);
                dataGridReport.DataSource = dt;

                txtQueryString.Text = sqlQuery;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                UpdateSystemMessage("Main", "데이터 표시에 문제가 있습니다.");
            }
        }

        private string GetDatabaseNames()
        {
            string databaseNames = string.Empty;

            DataTable dt = DBReader.GetQueryResult("SHOW DATABASES;");
            foreach (DataRow dr in dt.Rows)
            {
                databaseNames += dr.Field<string>(0) + ",";
            }
            return databaseNames;
        }

        private void LoadIotlTableListInTreeView()
        {
            try
            {

                string databaseNames = GetDatabaseNames();

                string[] arrDatabase = databaseNames.Split(',');

                tvIotlTable.BeginUpdate();
                tvIotlTable.Nodes.Clear();

                int iDbIndex = 0;
                foreach (string dbName in databaseNames.Split(','))
                {
                    string queryString = string.Format("SELECT Table_Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = '{0}'", dbName);
                    tvIotlTable.Nodes.Add(dbName);
                    tvIotlTable.Nodes[iDbIndex].Nodes.Add("Tables");
                    DataTable dt = DBReader.GetQueryResult(queryString);
                    foreach (DataRow dr in dt.Rows)
                    {
                        tvIotlTable.Nodes[iDbIndex].Nodes[0].Nodes.Add(dr.Field<string>(0));
                    }
                    iDbIndex++;
                }
 
                tvIotlTable.EndUpdate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                UpdateSystemMessage("Main", "데이터 표시에 문제가 있습니다.");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadIotlTableListInTreeView();
        }

        private void tvIotlTable_DoubleClick(object sender, EventArgs e)
        {
            string dbName = "iotlink";

            TreeNode node = tvIotlTable.SelectedNode;
            if(node.Parent != null && node.Parent.GetType() == typeof(TreeNode))
            {
                if(node.Parent.Text.Equals("Tables"))
                {
                    dbName = node.Parent.Parent.Text;
                }
            }

            DisplayToDataGridReportWithTableName(dbName+"." +tvIotlTable.SelectedNode.Text);
        }

        private void tvIotlTable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            {
                Console.WriteLine("parrent : " + tvIotlTable.SelectedNode.Parent.Text);
            }
        }
    }
}
