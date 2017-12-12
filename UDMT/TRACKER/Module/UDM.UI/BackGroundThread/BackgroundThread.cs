using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UDM.UI
{
    public partial class BackgroundThread
    {
        private FrmProcess frmProcess;

        public BackgroundThread(BackgroundWorker bg, string ProcessName, object sender)
        {
            frmProcess = new FrmProcess(ProcessName);

            bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            bg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_ProgressChanged);
            bg.WorkerReportsProgress = true;
            bg.RunWorkerAsync(sender);
        }

        public void SetMessage(string sMessage)
        {

        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frmProcess.EndProcessing();
        }

        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            frmProcess.SetProcessing(e.ProgressPercentage.ToString());
            if (e.UserState != null)
                frmProcess.SetMessage((string)e.UserState);
        }

    }
}
