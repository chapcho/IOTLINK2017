using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.DDEA;

namespace UDMPresenter
{
    public partial class FrmPlcConfig : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        protected CDDEAConfigMS m_cConfig = null;
        protected int m_iSelectedIndex = -1;

        #endregion


        #region Initialize

        public FrmPlcConfig(CDDEAConfigMS cConfig)
        {
            InitializeComponent();
            m_cConfig = cConfig;
        }

        #endregion


        #region Form Event

        private void FrmPlcConfig_Load(object sender, EventArgs e)
        {
            //if (m_bDDEAMode)
            {
                ucConnectionTest.PLCType = EMPlcConnettionType.Melsec_RSeries;
                ucConnectionTest.Config = m_cConfig;
                ucConnectSetMxCom4.Config = m_cConfig;
                ucConnectionTest.UEventConnect += new UEventHandlerConnect(ucConnectionTest_UEventConnect);
            }
            //else
            //{
            //    ucConnectionTest.Enabled = false;
            //    ucConnectSetMxCom4.Enabled = false;
            //}
            txtLogPath.Text = CProjectManager.SelectedProject.SaveLogPath;
            spnLogFileSaveTime.Value = CProjectManager.SelectedProject.SaveLogFileTime;
            txtProjectName.Text = CProjectManager.SelectedProject.Name;
        }


        #endregion


        #region Properties

        public int SelectedIndex
        {
            get { return ucConnectSetMxCom4.SelectedIndex; }
            set { ucConnectSetMxCom4.SelectedIndex = value; }
        }

        public double ScanTime
        {
            get { return ucConnectionTest.ScanTime; }
        }

        #endregion


        private void ucConnectionTest_UEventConnect(object sender)
        {
            ucConnectionTest.Config.MxCom4SelectedIndex = ucConnectSetMxCom4.SelectedIndex;
        }

        private void btnChangePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.SelectedPath = CProjectManager.SelectedProject.SaveLogPath;
            DialogResult dlgResult = dlgFolder.ShowDialog();
            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            CProjectManager.SelectedProject.SaveLogPath = dlgFolder.SelectedPath;
            txtLogPath.Text = CProjectManager.SelectedProject.SaveLogPath;
        }

        private void FrmPlcConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            CProjectManager.SelectedProject.SaveLogFileTime = (int)spnLogFileSaveTime.Value;
            CProjectManager.SelectedProject.Name = txtProjectName.Text;
        }
    }
}