using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using UDM.Log.DB;
using UDM.Log;
using System.Diagnostics;

namespace UDMLadderTracker
{
    partial class FrmMain
    {

        #region Member Variables


        #endregion


        #region Private Methods
        

        #endregion


        #region Event Methods

        private void btnCreateDataBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("All Data will be removed, Continue ??", Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) != DialogResult.OK)
            {
                return;
            }

            bool bOK = true;

            CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
            bOK = cLogWriter.CreateDB();

            CMultiProject.ErrorIDCur = 0;
            if (CMultiProject.ErrorInfoS != null)
                CMultiProject.ErrorInfoS.Clear();
            ucErrorLogTable.Clear();
            //ucErrorGrid.ClearGrid();

            cLogWriter.Dispose();
            cLogWriter = null;

            if (bOK == false)
            {
                MessageBox.Show("Can't Create DB. Please Check Mysql Installation!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Successfully DB Created!!\r\nApplication Close", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (m_cReader != null)
                {
                    m_cReader.Disconnect();
                    m_cReader.Dispose();
                    m_cReader = null;
                }

                this.Close();
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
        #endregion
    }
}
