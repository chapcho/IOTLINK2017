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

namespace IOTLManager.UserControls
{
    public partial class UCCompressorDataManager : UserControl
    {
        public event UEventHandlerFileLog UEventFileLog = null;
        public event UEventHandlerIOTLMessage UEventMessage = null;
        // public event UIEventHandlerCompressMonitoringEvent UEventCompressMonitor = null;

        // Compressor Monitoring 이벤트를 처리하는 처리자.
        private IOTLCompressorLogWriter compressorLogWriter;
        private MySqlLogReader DBReader = new MySqlLogReader("compdata");

        public UCCompressorDataManager()
        {
            InitializeComponent();

            btnStartStop.BackColor = Color.WhiteSmoke;
        }


        private void UCCompressorDataManager_Load(object sender, EventArgs e)
        {

        }

        public void InitCompressorDataManager()
        {
            if (compressorLogWriter == null)
            {
                bool bOK = false;

                compressorLogWriter = new IOTLCompressorLogWriter("compdata");
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
                return;
            }

            // UserControl에서 Form에 보내는 메시지
            ucSocketServer1.UEventMessage += UpdateSystemMessage;
            ucSocketServer1.UEventFileLog += WriteMessageToLogfile;

            // Comp에서 수신한 데이터를 기록 대기 합니다.
            ucSocketServer1.UEventMachineStateTimeLog += HandlerCompressorMachineStateLog;

            ucSocketServer1.ServerCaption = "IOTL Compressor Monitor";
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
                InitCompressorDataManager();
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
    }
}
