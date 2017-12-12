using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using DevComponents.Tree;

using UDM.Log;
using UDM.Log.Csv;
using UDM.Project;
using UDM.Common;
using UDM.UI;


namespace UDMTracker
{
    partial class FrmMain
    {

        #region Member Variables

        protected delegate void UpdateTextCallBack(string sSender, string sMessage);

        #endregion


        #region Private Methods
        
        private void RunMonitorStatus()
        {
            tmrTimer.Start();
        }

        private void StopMonitorStatus()
        {
            tmrTimer.Stop();
        }

        private void ShowTagTable(bool bOK)
        {
            if (bOK)
            {
                if (dpnlTagTable.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlTagTable.Show();
            }
            else
            {
                if (dpnlTagTable.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlTagTable.Hide();
            }
        }

        private void ShowGroupTree(bool bOK)
        {
            if (bOK)
            {
                if (dpnlGroupTree.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlGroupTree.Show();
            }
            else
            {
                if (dpnlGroupTree.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlGroupTree.Hide();
            }
        }

        private void ShowMonitorStatus(bool bOK)
        {
            if (bOK)
            {
                if (dpnlMonitorStatus.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
                    dpnlMonitorStatus.Show();
            }
            else
            {
                if (dpnlMonitorStatus.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    dpnlMonitorStatus.Hide();
            }
        }

		private string GetUserInputText(string sTitle, string sMessage)
		{
			FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
			dlgInput.ShowDialog();
			
			string sName = dlgInput.InputText;

			dlgInput.Dispose();
			dlgInput = null;

			return sName;
		}

        protected void SetPlcMakerCheck(EMPLCMaker emMaker)
        {
            if (emMaker == EMPLCMaker.LS)
                chkLsPlc.Checked = true;
            else if (emMaker == EMPLCMaker.Mitsubishi)
                chkMelsecPlc.Checked = true;
            else if (emMaker == EMPLCMaker.Siemens)
                chkSiemens.Checked = true;
            else
                chkAbPlc.Checked = true;
        }

        protected void SetCheckBox()
        {
            if (chkAbPlc.Checked || chkSiemens.Checked)
            {
                chkDDEA.Enabled = false;
                chkOPC.Checked = true;
            }
            else
            {
                chkDDEA.Enabled = true;
                chkDDEA.Checked = true;
            }
            if (chkLsPlc.Checked)
                ucProjectManager.Project.PLCMaker = UDM.Common.EMPLCMaker.LS;
            else if(chkSiemens.Checked)
                ucProjectManager.Project.PLCMaker = UDM.Common.EMPLCMaker.Siemens;
            else if (chkMelsecPlc.Checked)
                ucProjectManager.Project.PLCMaker = UDM.Common.EMPLCMaker.Mitsubishi;
            else
                ucProjectManager.Project.PLCMaker = UDM.Common.EMPLCMaker.Rockwell;

            if (chkLsPlc.Checked && chkDDEA.Checked)
            {
                ucProjectManager.Project.LsConfig.Use = true;
                ucProjectManager.Project.OPCConfig.Use = false;
            }
            else if (chkMelsecPlc.Checked && chkDDEA.Checked)
            {
                ucProjectManager.Project.LsConfig.Use = false;
                ucProjectManager.Project.OPCConfig.Use = false;
            }
            else if (chkOPC.Checked)
            {
                ucProjectManager.Project.LsConfig.Use = false;
                ucProjectManager.Project.OPCConfig.Use = true;
            }
        }

        #endregion


        #region Event Methods

        private void btnNew_ItemClick(object sender, ItemClickEventArgs e)
        {
			string sName = GetUserInputText("Input Project Name", "Please enter text below...");
            if (sName != "")
            {
                ucProjectManager.Clear();
                ucProjectManager.Create(sName);   
                ucProjectManager.Refresh();
                ucProjectManager.Project.PLCMaker = EMPLCMaker.LS;
                ucProjectManager.Project.LsConfig.Use = true;
            }
        }

        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "*.upm|*.upm";
            dlgOpenFile.ShowDialog();

            string sPath = dlgOpenFile.FileName;
            if (sPath != "")
            {
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    ucProjectManager.Clear();
                    ucProjectManager.Open(sPath);
                    ucProjectManager.Refresh();

                    if (ucProjectManager.Project != null)
                    {
                        if (ucProjectManager.Project.LsConfig.Use)
                            chkDDEA.Checked = true;
                        else
                            chkOPC.Checked = true;

                        SetPlcMakerCheck(ucProjectManager.Project.PLCMaker);
                    }

                    UpdateSystemMessage("Tracker", sPath + " File Open!!!");
                }
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.upm|*.upm";
            dlgSaveFile.ShowDialog();

            string sPath = dlgSaveFile.FileName;
            if (sPath != "")
            {
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bool bOK = ucProjectManager.Save(sPath);
                    if (bOK)
                        UpdateSystemMessage("Tracker", sPath + " File Save OK!!!");
                    else
                        UpdateSystemMessage("Tracker", sPath + " File Save Fail!!!");
                }
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "Upm files (*.upm)|*.upm";
            DialogResult dlgResult = dlgSave.ShowDialog();

            if (dlgResult == DialogResult.Cancel) return;

            string sPath = dlgSave.FileName;
            if (sPath != "")
            {
                SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
                {
                    bool bOK = ucProjectManager.Save(sPath);
                    if (bOK)
                        UpdateSystemMessage("Tracker", sPath + " File Save OK!!!");
                    else
                        UpdateSystemMessage("Tracker", sPath + " File Save Fail!!!");
                }
                SplashScreenManager.CloseForm(false);
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit program?", "UDMTracker", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Process[] ddeaProcess = Process.GetProcessesByName("UDMDDEA");
                if (ddeaProcess.Length > 0)
                    foreach (Process ddea in ddeaProcess)
                        ddea.Kill();

                Application.Exit();
            }
        }

        private void chkViewTagTable_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowTagTable(chkViewTagTable.Checked);
        }

        private void chkViewGroupTree_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowGroupTree(chkViewGroupTree.Checked);
        }

        private void chkViewMonitorStatus_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            ShowMonitorStatus(chkViewMonitorStatus.Checked);
        }

        private void dpnlGroupTree_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                chkViewGroupTree.CheckedChanged -= new ItemClickEventHandler(chkViewTagTable_CheckedChanged);
                chkViewGroupTree.Checked = false;
                chkViewGroupTree.CheckedChanged += new ItemClickEventHandler(chkViewTagTable_CheckedChanged);
            }
        }


        private void dpnlTagTable_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                chkViewTagTable.CheckedChanged -= new ItemClickEventHandler(chkViewTagTable_CheckedChanged);
                chkViewTagTable.Checked = false;
                chkViewTagTable.CheckedChanged += new ItemClickEventHandler(chkViewTagTable_CheckedChanged);
            }
        }

        private void dpnlMonitorStatus_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Hidden)
            {
                chkViewMonitorStatus.CheckedChanged -= new ItemClickEventHandler(chkViewMonitorStatus_CheckedChanged);
                chkViewMonitorStatus.Checked = false;
                chkViewMonitorStatus.CheckedChanged += new ItemClickEventHandler(chkViewMonitorStatus_CheckedChanged);
            }
        }

		private void ChangeMonitorLayout(bool bOK)
		{
			if (bOK)
			{
				//exRibbonControl.Minimized = true;

                dpnlGroupTree.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                dpnlMonitorStatus.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                dpnlTagTable.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                dpnlSystemLog.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                grpMonitorRunView.Visible = true;
			}
			else
			{
				//exRibbonControl.Minimized = false;

                dpnlTagTable.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                dpnlGroupTree.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                dpnlMonitorStatus.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                dpnlSystemLog.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                grpMonitorRunView.Visible = false;
			}

		}

        private void btnStartMonitor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectEditable() == false)
                return;

            if (CheckProjectAvailable() == false)
                return;

            if (CheckDataBaseAvailable() == false)
                return;

            if (chkMonitorDetection.Checked)
                m_cTracker.MonitorType = EMMonitorType.Detection;
            else if (chkMonitorPatternItem.Checked)
                m_cTracker.MonitorType = EMMonitorType.PatternItem;
            else if (chkMonitorMasterPattern.Checked)
                m_cTracker.MonitorType = EMMonitorType.MasterPattern;

            m_cTracker.CollectGrid = grdTag;
            bool bOK = m_cTracker.Run();
            if (bOK == false)
            {
                MessageBox.Show("Can't Run monitoring!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Can't Run monitoring!!");
            }
            else
            {                
                ChangeMonitorLayout(true);

                btnStartMonitor.Enabled = false;
                btnStopMonitor.Enabled = true;
				
				mnuModelTag.Enabled = false;
				mnuModelMasterPattern.Enabled = false;
				mnuMonitorDatabase.Enabled = false;
				mnuMonitorSource.Enabled = false;
				ucGroupTree.Editable = false;
				ucTagTable.Editable = false;
				
                ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Monitoring Start!!");
            }
        }

        private void btnStartSimulation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectEditable() == false)
                return;

            if (CheckProjectAvailable() == false)
                return;

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Multiselect = true;
            dlgOpenFile.Filter = "*.csv|*.csv";
            dlgOpenFile.ShowDialog();

            string[] saFile = dlgOpenFile.FileNames;
            int iIndex = dlgOpenFile.FilterIndex;
            if (saFile != null && saFile.Length > 0)
            {
                bool bOK = true;

                CCsvLogReader cReader = new CCsvLogReader();
                bOK = cReader.Open(saFile);
                if (bOK)
				{
					CTimeLogS cLogS = null;
					SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
					{
						cLogS = cReader.ReadTimeLogS();
					}
					SplashScreenManager.CloseForm();

					cReader.Dispose();
					cReader = null;

					if (cLogS == null || cLogS.Count == 0)
					{
						MessageBox.Show("Can't run simulator(Log count is 0)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
						ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Can't run simulator(Log count is 0)");
						return;
					}

					btnStartMonitor.Enabled = false;
					btnStopMonitor.Enabled = true;
					mnuModelTag.Enabled = false;
					mnuModelMasterPattern.Enabled = false;
					mnuMonitorDatabase.Enabled = false;
					mnuMonitorSource.Enabled = false;
					ucGroupTree.Editable = false;
					ucTagTable.Editable = false;


					System.Threading.Thread.Sleep(100);

					ChangeMonitorLayout(true);

					m_cTracker.Simulate(cLogS);
					

					MessageBox.Show("Simulation is finished!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Simulation is finished!!");

					btnStopMonitor_ItemClick(null, null);
				}
                else
                {
                    cReader.Dispose();
                    cReader = null;

                    MessageBox.Show("Can't run simulator(Log count is 0)", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void btnStopMonitor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (m_cTracker.IsRunning == true)
            {
                m_cTracker.Stop();

                btnStartMonitor.Enabled = true;
                btnStopMonitor.Enabled = false;

				mnuModelTag.Enabled = true;
				mnuModelMasterPattern.Enabled = true;
				mnuMonitorDatabase.Enabled = true;
				mnuMonitorSource.Enabled = true;
				ucGroupTree.Editable = true;
				ucTagTable.Editable = true;
                ChangeMonitorLayout(false);
                ucSystemLogTable.AddMessage(DateTime.Now, Application.ProductName, "Monitor Stop");
            }
        }

		private void ucGroupCycleChart_UEventGroupItemClicked(object sender, CGroupLog cLog)
		{
			FrmCycleLogViewer frmViewer = new FrmCycleLogViewer();
			frmViewer.Project = ucProjectManager.Project;
			frmViewer.Reader = m_cReader;
			frmViewer.Show();
			frmViewer.ShowChart(cLog);
		}

        #endregion
    }
}
