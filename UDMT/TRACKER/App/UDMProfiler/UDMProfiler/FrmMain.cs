using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMProfiler
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private string m_sSysLogPath = Application.StartupPath + "\\ProfilerSystemLog";
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);

        #endregion

        #region Initialize/Dipose

        public FrmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        private bool CheckProjectExist()
        {
            bool bOK = true;

            if (CProjectManager.Project == null || CProjectManager.Project.ProjectName == string.Empty)
            {
                XtraMessageBox.Show("현재 프로젝트가 생성되지 않은 상태입니다.\r\nNew 버튼을 눌러 프로젝트를 생성하세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                bOK = false;
            }

            return bOK;
        }

        private void UpdateSystemMessage(string sSender, string sMessage)
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
                    //ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
                    CProjectManager.SystemLog.WriteLog(sSender, sMessage);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void InitSetting()
        {
            CProjectManager.MainTree = ucMainTree;
        }

        #endregion


        #region Event Methods

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CProjectManager.SystemLog = new CSystemLog(m_sSysLogPath, "Profiler");
            tmrSystemLog.Start();

            InitSetting();
        }

        private void tmrSystemLog_Tick(object sender, EventArgs e)
        {
            tmrSystemLog.Enabled = false;

            try
            {
                if (CProjectManager.SystemLog != null)
                {
                    CProjectManager.SystemLog.WriteLog("SystemLog", "새로운 파일을 생성합니다.(주기 1시간)");
                    string sFileName = CProjectManager.SystemLog.FileName;
                    CProjectManager.SystemLog.WriteEndLog();

                    CProjectManager.SystemLog = new CSystemLog(m_sSysLogPath, "Profiler");

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

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrSystemLog.Stop();

            if (CProjectManager.SystemLog != null)
            {
                CProjectManager.SystemLog.WriteLog("FormClose", "모든 프로세스를 종료 했습니다.");
                CProjectManager.SystemLog.WriteEndLog();
            }
        }

        #endregion
         

    }
}