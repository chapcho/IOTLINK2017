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

namespace IOTLManager.UserControls
{
    public partial class UCCompressorDataManager : UserControl
    {
        public event UEventHandlerFileLog UEventFileLog = null;
        public event UEventHandlerIOTLMessage UEventMessage = null;
        // public event UIEventHandlerCompressMonitoringEvent UEventCompressMonitor = null;

        // Compressor Monitoring 이벤트를 처리하는 처리자.
        private IOTLCompressorLogWriter compressorLogWriter;

        public UCCompressorDataManager()
        {
            InitializeComponent();
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
                }
            }

            // UserControl에서 Form에 보내는 메시지
            ucSocketServer1.UEventMessage += UpdateSystemMessage;
            ucSocketServer1.UEventFileLog += WriteMessageToLogfile;

            // Comp에서 수신한 데이터를 기록 대기 합니다.
            ucSocketServer1.UEventMachineStateTimeLog += UcSocketServer1_UEventMachineStateTimeLog;

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
            }
            else
            {
                ucSocketServer1.UEventMessage -= UpdateSystemMessage;
                ucSocketServer1.UEventFileLog -= WriteMessageToLogfile;
                ucSocketServer1.UEventMachineStateTimeLog -= UcSocketServer1_UEventMachineStateTimeLog;

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
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (btnStartStop.Text.ToUpper().Equals("MONITOR STOP"))
            {
                ucSocketServer1.UEventMessage -= UpdateSystemMessage;
                ucSocketServer1.UEventFileLog -= WriteMessageToLogfile;
                ucSocketServer1.UEventMachineStateTimeLog -= UcSocketServer1_UEventMachineStateTimeLog;

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

        private void UcSocketServer1_UEventMachineStateTimeLog(CTimeLog cLog)
        {
            if (compressorLogWriter != null)
                compressorLogWriter.EnQue(cLog);
        }
    }
}
