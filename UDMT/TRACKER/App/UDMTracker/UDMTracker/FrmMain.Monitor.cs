using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using UDM.Log.DB;
using UDM.Log;
using UDM.DDEA;
using System.Diagnostics;

namespace UDMTracker
{
    partial class FrmMain
    {

        #region Member Variables


        #endregion


        #region Private Methods
        

        #endregion


        #region Event Methods

		private void exEditorUseOPC_CheckStateChanged(object sender, EventArgs e)
		{
			ucProjectManager.Project.OPCConfig.Use = chkOPC.Checked;

		}
		private void exEditorUseDDEA_CheckStateChanged(object sender, EventArgs e)
		{
			ucProjectManager.Project.OPCConfig.Use = chkOPC.Checked;
		}

        private void btnSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectEditable() == false)
                return;

            if (CheckProjectAvailable() == false)
                return;

            if (chkDDEA.Checked && chkLsPlc.Checked)
                ConfigLs();
            else if (chkDDEA.Checked)
                ConfigMelsec();
            else
                ConfigOPC();

        }

        private void btnCreateDataBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("All Data will be removed, Continue ??", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) != DialogResult.OK)
            {
                return;
            }

            bool bOK = true;

            CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
            bOK = cLogWriter.CreateDB();
            cLogWriter.Dispose();
            cLogWriter = null;

            if (bOK == false)
            {
                MessageBox.Show("Can't Create DB. Please Check Mysql Installation!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Successfully DB Created!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (m_cReader != null)
                {
                    m_cReader.Disconnect();
                    m_cReader.Dispose();
                    m_cReader = null;
                }

                m_cReader = new CMySqlLogReader();
                m_cReader.Connect();
            }
        }

        private void btnTestDBConnection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectEditable() == false)
                return;

            if (m_cReader.IsConnected == false)
                m_cReader.Connect();

            if (m_cReader.IsConnected)
                MessageBox.Show("DB Connection Test is OK!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Can't Connect to DB. Please Check Mysql Installation!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExportLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectEditable() == false)
                return;

            if (m_cReader.IsConnected == false)
                m_cReader.Connect();

            CTimeLogS cTimeLog = null;

			SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {	
                cTimeLog = m_cReader.GetTimeLogS((DateTime)dtpkExportFrom.EditValue, (DateTime)dtpkExportTo.EditValue);
            }
			SplashScreenManager.CloseForm();

            if (cTimeLog != null && cTimeLog.Count > 1)
            {
                SaveFileDialog dlgSaveFile = new SaveFileDialog();
                dlgSaveFile.Filter = "*.csv|*.csv";
                dlgSaveFile.ShowDialog();

                string[] saFile = dlgSaveFile.FileNames;
                int iIndex = dlgSaveFile.FilterIndex;
                if (saFile != null && saFile.Length > 0)
                {
                    bool bOK = true;

                    UDM.Log.Csv.CCsvLogWriter cWrite = new UDM.Log.Csv.CCsvLogWriter();

                    cWrite.Open(saFile[0]);
                    bOK = cWrite.WriteTimeLogS(cTimeLog);
                    cWrite.Close();

                    if (bOK)
                    {
                        MessageBox.Show("Export Time Log is OK!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Time Log Not Found!!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigOPC()
        {
			FrmOPCProperty frmProperty = new FrmOPCProperty();
			frmProperty.Editable = !m_cTracker.IsRunning;
			frmProperty.OPCConfig = ucProjectManager.Project.OPCConfig;
			frmProperty.ShowDialog();
        }

        private void ConfigMelsec()
        {
            FrmDDEAProperty frmMelsec = new FrmDDEAProperty(ucProjectManager.Project.MelsecConfig);
            frmMelsec.ShowDialog();
            if (frmMelsec.IsDataChange)
                ucProjectManager.Project.MelsecConfig = frmMelsec.Config;

        }

        private void ConfigLs()
        {
            FrmLsPlcConfig frmLs = new FrmLsPlcConfig(ucProjectManager.Project.LsConfig);
            frmLs.ShowDialog();
            if (frmLs.ChangeConfig)
            {
                frmLs.LsConfig.Use = true;
                ucProjectManager.Project.LsConfig = frmLs.LsConfig;
            }

        }
        #endregion
    }
}
