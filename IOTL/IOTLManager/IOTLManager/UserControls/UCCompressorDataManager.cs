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

namespace IOTLManager.UserControls
{
    public partial class UCCompressorDataManager : UserControl
    {
        public UCCompressorDataManager()
        {
            InitializeComponent();

            // UserControl에서 Form에 보내는 메시지
            ucSocketServer1.UEventMessage += UcSocketServer1_UEventMessage;
            ucSocketServer1.UEventFileLog += UcSocketServer1_UEventFileLog;
            ucSocketServer1.UEventMachineStateTimeLog += UcSocketServer1_UEventMachineStateTimeLog;

        }

        private void UcSocketServer1_UEventMachineStateTimeLog(CTimeLog cLog)
        {
            throw new NotImplementedException();
        }

        private void UcSocketServer1_UEventFileLog(EMFileLogType emFileLogType, EMFileLogDepth emFileLogDepth, string logMessage)
        {
            WriteMessageToLogfile(emFileLogType, emFileLogDepth, logMessage);
        }

        private void UcSocketServer1_UEventMessage(string sender, string message)
        {
            UpdateSystemMessage(sender, message);
        }
    }
}
