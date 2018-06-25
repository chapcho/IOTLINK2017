using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOTL.Common;
using IOTL.Common.Log;
using IOTLManager.Util;
using IOTL.Common.DB;
using System.IO;
using IOTLManager.CsvLog;

namespace IOTLManager.UserControls
{
    public partial class UCCompressorDataManager : UserControl
    {
        public event UEventHandlerFileLog UEventFileLog = null;
        public event UEventHandlerIOTLMessage UEventMessage = null;
        public event UEventProgressBarRefreshDelegate UEventProgressBar = null;
        // public event UIEventHandlerCompressMonitoringEvent UEventCompressMonitor = null;

        private ConfigMariaDB m_dbConnInfo = null;
        // Compressor Monitoring 이벤트를 처리하는 처리자.
        private IOTLCompressorLogWriter compressorLogWriter;
        private MySqlLogReader DBReader = null;

        private string logFilePath = "C:\\Log";
        private uint m_LocalTcpServerPort = 9595;
        private BackgroundWorker logFileReader;
        private string m_ServerTitleCaption = "IOTL Compressor Monitor";

        public bool ServerSocketTypeTcp
        {
            get { return ucSocketServer1.SocketModeTcp; }
            set { ucSocketServer1.SocketModeTcp = value; }
        }

        public UCCompressorDataManager()
        {
            InitializeComponent();

            btnStartStop.BackColor = Color.WhiteSmoke;
        }


        public ConfigMariaDB DBConnectionInfo
        {
            get { return m_dbConnInfo; }
            set
            {
                m_dbConnInfo = value;
            }
        }

        public uint LocalTcpServerPort
        {
            get { return m_LocalTcpServerPort; }
            set { m_LocalTcpServerPort = value; }
        }

        public string LogSavedPath
        {
            get { return logFilePath; }
            set { logFilePath = value; }
        }

        public string ServerTitleCaption
        {
            get { return m_ServerTitleCaption; }
            set { m_ServerTitleCaption = value; }
        }

        private void UCCompressorDataManager_Load(object sender, EventArgs e)
        {

        }

        public int InitCompressorDataManager()
        {
            if (DBConnectionInfo is null)
            {
                return 1; // Database Connection Info Needed!
            }
            else
            {
                DBReader = new MySqlLogReader(DBConnectionInfo);
            }

            if (compressorLogWriter == null)
            {
                bool bOK = false;

                compressorLogWriter = new IOTLCompressorLogWriter(DBConnectionInfo);
                compressorLogWriter.ProjectPath = logFilePath;
                compressorLogWriter.UEventIOTLMessage += UpdateSystemMessage;
                compressorLogWriter.UEventFileLog += WriteMessageToLogfile;

                bOK = compressorLogWriter.Run();
                if (bOK == false)
                {
                    UpdateSystemMessage("Compressor Monitor", "DB Writer 시작 실패");
                }
                else
                {
                    UpdateSystemMessage("Compressor Monitor", "DB Writer 시작");

                    DBReader.Connect();
                    if (DBReader.IsConnected)
                    {
                        UpdateSystemMessage("Compressor Monitor", "DB Reader Connected!");
                    }
                    else
                    {
                        UpdateSystemMessage("Compressor Monitor", "DB Reader NotConnected!");
                    }
                }
            }
            else
            {
                return 2; // already initialized
            }

            // UserControl에서 Form에 보내는 메시지
            ucSocketServer1.UEventMessage += UpdateSystemMessage;
            ucSocketServer1.UEventFileLog += WriteMessageToLogfile;

            // Comp에서 수신한 데이터를 기록 대기 합니다.
            ucSocketServer1.UEventMachineStateTimeLog += HandlerCompressorMachineStateLog;
            ucSocketServer1.LocalServerTcpPort = LocalTcpServerPort;
            ucSocketServer1.ServerCaption = ServerTitleCaption;

            return 0; // success initialized
        }

        private void WriteMessageToLogfile(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string logMessage)
        {
            if (UEventFileLog != null)
                UEventFileLog(emFileLogType, emFileLogDepth, logMessage);
        }

        private void UpdateSystemMessage(string sender, string message)
        {
            if (UEventMessage != null)
                UEventMessage(sender, message);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text.ToUpper().Equals("MONITOR START"))
            {
                int iRet = InitCompressorDataManager();

                switch(iRet)
                {
                    case 0:Console.WriteLine("Loading.. Start");
                        break;
                    case 1:
                        MessageBox.Show("Error Database Config Info", "IOTLDataManager");
                        return;
                    case 2:
                        MessageBox.Show("Already Starting", "IOTLDataManager");
                        return;
                    default:
                        MessageBox.Show("Error Database Config Info", "IOTLDataManager");
                        return;
                }

                btnStartStop.Text = "Monitor Stop";
                btnStartStop.BackColor = Color.GreenYellow;
                btnStartStop.Refresh();
            }
            else
            {
                ucSocketServer1.UEventMessage -= UpdateSystemMessage;
                ucSocketServer1.UEventFileLog -= WriteMessageToLogfile;
                ucSocketServer1.UEventMachineStateTimeLog -= HandlerCompressorMachineStateLog;

                if (compressorLogWriter != null)
                {
                    compressorLogWriter.UEventIOTLMessage -= UpdateSystemMessage;
                    compressorLogWriter.UEventFileLog -= WriteMessageToLogfile;

                    compressorLogWriter.Stop();
                    while (compressorLogWriter.IsRunning)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    compressorLogWriter = null;
                }

                if (DBReader != null)
                {
                    DBReader.Disconnect();
                }

                btnStartStop.Text = "Monitor Start";

                btnStartStop.BackColor = Color.WhiteSmoke;
                btnStartStop.Refresh();

                UpdateSystemMessage("Compressor Monitor", "Monitor Stop!");

            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (btnStartStop.Text.ToUpper().Equals("MONITOR STOP"))
            {
                ucSocketServer1.UEventMessage -= UpdateSystemMessage;
                ucSocketServer1.UEventFileLog -= WriteMessageToLogfile;
                ucSocketServer1.UEventMachineStateTimeLog -= HandlerCompressorMachineStateLog;

                if (compressorLogWriter != null)
                {
                    compressorLogWriter.UEventIOTLMessage -= UpdateSystemMessage;
                    compressorLogWriter.UEventFileLog -= WriteMessageToLogfile;

                    compressorLogWriter.Stop();
                    while (compressorLogWriter.IsRunning)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    compressorLogWriter = null;
                }

                btnStartStop.Text = "Monitor Start";
            }

            base.OnHandleDestroyed(e);
        }

        private void HandlerCompressorMachineStateLog(CTimeLog cLog)
        {
            if (compressorLogWriter != null)
                compressorLogWriter.EnQue(cLog);

            // 수신데이터 처리를 했고, 이제 송신 처리를 합니다.
            SendControlMessageToClient(cLog);

        }

        /// <summary>
        /// 단말로 전송할 제어 메시지가 있다면, 여기서 조회하고 전송한다.
        /// 전송한 것 만으로, 전송 성공 처리를 한다.
        /// 즉 필요하면 재 전송하는 방식으로 구현한다.
        /// </summary>
        /// <param name="cLog"></param>
        /// <returns></returns>
        private int SendControlMessageToClient(CTimeLog cLog)
        {
            int iRet = 0;

            string rcvText = Encoding.Default.GetString(cLog.ReceiveData);
            string compId = string.Empty;

            // if compressor Protocol 
            string[] rcvDatas = rcvText.Split(',');

            if(rcvDatas.Length > 2)
            {
                if(rcvDatas[0].Equals("S") && rcvDatas[rcvDatas.Length - 1].Equals("E"))
                {
                    System.Console.WriteLine("Socket Data Receive & Send Sample");

                    compId = rcvDatas[2];
                }
            }

            System.Console.WriteLine("Socket Data Receive & Send Sample");

            // 단말로 보낼 메시지가 있다면 ...
            // 데이터 수신처리는 진행되고 있고, 단말에 보내야할 메시지가 있다면 여기서 전송합니다.

            // Send Sample Message To Session
            byte[] sendData = System.Text.Encoding.UTF8.GetBytes("Data Rcv ::" + compId + " :: " + DateTime.Now.ToLongTimeString());

            cLog.ClientSession.SendData_Client(sendData);
            return iRet;
        }

        private void timerWebCntlSender_Tick(object sender, EventArgs e)
        {
            if(chkWebCntlSendTimer.Checked) 
            {
                string controlVars = GetWebCntlCmd("compdata.controls");
                if(SendWebCntlCmdToClient(controlVars))
                {
                    ResetWebCntlCmd();
                }
            }
        }

        private bool SendWebCntlCmdToClient(string controlVars)
        {
            bool bOK = false;

            byte[] SendData;

            if (controlVars == "0")
            {
                return bOK; // false를 Return 해서 Update 하지 않도록 함.
                //SendData = Encoding.ASCII.GetBytes("C,0,E" + "\r\n");
            }

            if (controlVars == "1")
            {
                SendData = Encoding.ASCII.GetBytes("C,1,E" + "\r\n");
                UpdateSystemMessage("Compress Manager", "웹에서 운전 실행 명령 전송 : " + System.Text.Encoding.Default.GetString(SendData));
            }
            else if (controlVars == "2")
            {
                SendData = Encoding.ASCII.GetBytes("C,2,E" + "\r\n");
                UpdateSystemMessage("Compress Manager", "웹에서 정지 실행 명령 전송 : " + System.Text.Encoding.Default.GetString(SendData));
            }
            else
            {
                return bOK;
            }

            if (ucSocketServer1.SendMessageToAllClients(SendData))
            {
                bOK = true;
            }

            return bOK;
        }

        private string GetWebCntlCmd(string tableName)
        {
            string controlVars = string.Empty;
            if(DBReader.IsConnected)
            {
                string sqlQuery = string.Format("select * From {0};", tableName);
                DataTable dt = DBReader.GetQueryResult(sqlQuery);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    controlVars = dr["cmd"].ToString();
                }
            }
            else
            {
                UpdateSystemMessage("Compress Manager", "DB Reader Not Connected!!");
            }

            return controlVars;
        }

        private void ResetWebCntlCmd()
        {
            string query = "update compdata.controls set cmd = '0' where 1 = 1;";

            if(!DBReader.ExecUpdateQuery(query))
            {
                UpdateSystemMessage("Compress Manager", "Error!!! Update Web Control Message");
                chkWebCntlSendTimer.Checked = false;
                chkWebCntlSendTimer_CheckedChanged(null, null);
                WriteMessageToLogfile(EMFileLogType.DatabaseLog, EMFileLogDepth.Error, "Error!!! Update Web Control Message");
            }
        }

        private void chkWebCntlSendTimer_CheckedChanged(object sender, EventArgs e)
        {
            if(chkWebCntlSendTimer.Checked)
            {
                timerWebCntlSender.Interval = 1000;
                timerWebCntlSender.Start();
                timerWebCntlSender.Tick += timerWebCntlSender_Tick;
            }
            else
            {
                timerWebCntlSender.Tick -= timerWebCntlSender_Tick;
                timerWebCntlSender.Stop();
            }
        }

        private void RefreshProgressBarValue(int iValue)
        {
            if (UEventProgressBar != null)
                UEventProgressBar(iValue);
        }

        // Background Work 를 이용해서 로그파일을 읽어오고 싶다면
        // 디렉토리와 background worker를 파라미터로 전달하고
        // 디렉토리의 파일수를 검토하여 진행.
        private void ReadLogFileWithBgWorker(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] files = Directory.GetFiles(logFilePath, "*.csv");
                List<String> lstLogFile = new List<string>();

                CCsvLogReader logReader = new CCsvLogReader();
                CTimeLogS timeLogs = new CTimeLogS();

                for (int i = 0; i < files.Length; i++)
                {
                    lstLogFile.Add(files[i]);
                }

                if (lstLogFile.Count > 0)
                {
                    logReader.Open(lstLogFile.ToArray());

                    timeLogs = logReader.ReadTimeLogS(logFileReader);

                    logReader.Close();
                }

                // 읽은 로그를 DB에 기록
                foreach(CTimeLog log in timeLogs)
                {
                    if (compressorLogWriter != null)
                        compressorLogWriter.EnQue(log);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private void btnImportLog_Click(object sender, EventArgs e)
        {
            List<String> lstLogFile = new List<string>();

            // 로그가 있는 디렉토리에서 로그 파일의 목록을 가져와서..
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = LogSavedPath;
                fbd.Description = "Compressor 데이터 로그 폴터 선택!";
                DialogResult result = fbd.ShowDialog();

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        logFilePath = fbd.SelectedPath;

                        logFileReader = new BackgroundWorker();
                        logFileReader.WorkerReportsProgress = true;
                        logFileReader.WorkerSupportsCancellation = true;
                        logFileReader.DoWork += new DoWorkEventHandler(ReadLogFileWithBgWorker);
                        logFileReader.ProgressChanged += new ProgressChangedEventHandler(LogFileReadProgress_ChangedEvent);
                        logFileReader.RunWorkerCompleted += new RunWorkerCompletedEventHandler(LogFileReader_RunWorkerCompleted);

                        logFileReader.RunWorkerAsync();
                    }
                }
                catch(Exception ex)
                {
                    ex.Data.Clear();
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void LogFileReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 에러가 있는지 체크
            if (e.Error != null)
            {
                UpdateSystemMessage("Compressor Monitor", "[Fail]LogFileReading." + e.Error.Message);
                return;
            }

            UpdateSystemMessage("Compressor Monitor", "Success LogFiles Reading.");
        }

        private void LogFileReadProgress_ChangedEvent(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Progress Report Changed : " + e.ProgressPercentage);
            RefreshProgressBarValue(e.ProgressPercentage);
        }

        public string GetSocketReportMessage()
        {
            return ucSocketServer1.GetServerStatusReportMessage();
        }

        private void pictureAbout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("IOTLink Socket DataManager");
            sb.Append("\r\nVersion :2018.05.01");
            sb.Append("\r\n2018.04.20 콤프레샤 상태 데이터 수집.");
            sb.Append("\r\n2018.05.01 에어벨브 상태 데이터 수집.");
            sb.Append("\r\n2018.05.01 스봉 온도 데이터 수집.");
            sb.Append("\r\n2018.05.10 TCP/UDP 모드.");
            sb.Append("\r\n2018.05.11 관리자에게 온도데이터 수신 차트 전송.");
            MessageBox.Show(sb.ToString(),"About : IOTLink Socket Data Manager");
        }
    }
}
