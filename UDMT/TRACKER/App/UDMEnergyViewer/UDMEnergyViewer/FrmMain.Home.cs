using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source;
using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;
using System.Diagnostics;
using System.IO;

namespace UDMEnergyViewer
{
	partial class FrmMain
    {

        #region Member Variables

        private CMonitorTask m_cMonitorTask = null;

        #endregion

        #region Private Methods

        private void New()
		{
			FrmInputDialog dlgInput = new FrmInputDialog("Input Text", "Please input new project name below..");
			dlgInput.ShowDialog();

			string sText = dlgInput.InputText;
			if (sText == "")
				return;

			CProjectManager.New(sText);
			CProjectManager.TagTable = ucTagTable;
			CProjectManager.SymbolTable = ucSymbolTable;
			UpdateSystemMessage("Project 생성", sText + " 프로젝트가 생성되었습니다.");
		}

		private void Open()
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Presenter Project File|*.upm";

            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            if (dlgOpen.FileNames.Length == 0) return;

            bool bOK = false;
            exScreenManager.ShowWaitForm();
            exScreenManager.SetWaitFormCaption("Open");
            exScreenManager.SetWaitFormDescription("Presenter Project File Opening...");
            {
                bOK = CProjectManager.Open(dlgOpen.FileName);
            }
            exScreenManager.CloseWaitForm();

            if (bOK == false)
            {
                UpdateSystemMessage("Project열기", "파일 열기에 실패!!!");
            }
            else
            {
                if (CProjectManager.TagTable != null && CProjectManager.SymbolTable != null)
                {
                    CProjectManager.UpdateView();
                }
                else
                {
                    CProjectManager.TagTable = ucTagTable;
                    CProjectManager.SymbolTable = ucSymbolTable;
                    CProjectManager.UpdateView();
                }

                ShowPlcConfig();
                ShowLogConfig();

                UpdateSystemMessage("Project열기", "파일 열기에 성공했습니다.");
            }
        }


		private void Save()
		{
			if (CheckProjectAvailable() == false) return;

			SaveFileDialog dlgSave = new SaveFileDialog();
			dlgSave.Filter = "Project File|*.upm";

			if (dlgSave.ShowDialog() != DialogResult.OK) return;
			if (dlgSave.FileNames.Length == 0) return;

			string sPath = dlgSave.FileName;

			exScreenManager.ShowWaitForm();
			exScreenManager.SetWaitFormCaption("Save");
			exScreenManager.SetWaitFormDescription("Project File Saving...");
			{
				bool bOK = CProjectManager.Save(sPath);
				if (bOK == false)
					UpdateSystemMessage("Project저장", "파일 저장에 실패!!!");
				else
					UpdateSystemMessage("Project저장", "파일 저장에 성공했습니다.");
			}
			exScreenManager.CloseWaitForm();
		}

		private void StartMonitor()
		{
            if (CheckProjectAvailable() == false) return;
            if (m_bRun) return;

            //if (CProjectManager.Project.SymbolS.Count == 0)
            //{
            //    UpdateSystemMessage("수집", "수집대상이 없습니다");
            //    return;
            //}

            if (m_cMonitorTask != null)
            {
                m_cMonitorTask.Dispose();
                m_cMonitorTask = null;
            }

            m_cMonitorTask = new CMonitorTask();
            m_cMonitorTask.Project = CProjectManager.Project;
            m_bRun = m_cMonitorTask.Run();
            if (!m_bRun)
            {
                UpdateSystemMessage("Monitor", "Fail to monitor!!");
                MessageBox.Show("Fail to monitor!!");
                return;
            }
            else
            {
                if(m_cMonitorTask.IsMeterRunning == false)
                    UpdateSystemMessage("Monitor", "Fail to meter monitor!!");

                if(m_cMonitorTask.IsPlcRunning == false)
                    UpdateSystemMessage("Monitor", "Fail to plc monitor!!");
            }

            ucMonitorLight.Run();

            btnMonitorStart.Enabled = false;
            btnMonitorStop.Enabled = true;
            mnuProject.Enabled = false;
            mnuTag.Enabled = false;
            mnuPLCInterface.Enabled = false;
            mnuLogging.Enabled = false;
            mnuChart.Enabled = false;
            munExit.Enabled = false;
            mnuOpenLogFolder.Enabled = false;
		}

		private void StopMonitor()
		{
            if (!m_bRun) return;

            m_cMonitorTask.Stop();
            m_cMonitorTask.Dispose();
            m_cMonitorTask = null;

            ucMonitorLight.Stop();

            m_bRun = false;

            btnMonitorStart.Enabled = true;
            btnMonitorStop.Enabled = false;
            mnuProject.Enabled = true;
            mnuTag.Enabled = true;
            mnuPLCInterface.Enabled = true;
            mnuLogging.Enabled = true;
            mnuChart.Enabled = true;
            munExit.Enabled = true;
            mnuOpenLogFolder.Enabled = true;
		}

        private void OpenLogFolder()
        {
            if (CheckProjectAvailable() == false)
                return;

            string sPath = CProjectManager.Project.LogConfig.SavePath;

            if(sPath != null || sPath != "")
            {
                if (!Directory.Exists(sPath))
                    Directory.CreateDirectory(sPath);

                Process.Start(sPath);
            }
            else
                MessageBox.Show("Apply Data Logging Folder Path First!", "Data Logging", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Event

        private void m_cLogTask_UEventMessage(object sender, string sSender, string sMessage)
        {
            if (m_cLogTask != null)
            {
                UpdateSystemMessage(sSender, sMessage);
            }
        }


        #endregion

        #endregion
    }
}
