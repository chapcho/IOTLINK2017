using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Monitor.Plc;
using UDM.Log.DB;
using UDM.Log;

namespace UDMTracker
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        #region Member Variables

        private CTracker m_cTracker = new CTracker();
        private CMySqlLogReader m_cReader = new CMySqlLogReader();

        private FrmAlertViewer m_frmAlertView = null;
        private FrmGroupProperty m_frmGroupProperty = null;
        private FrmTrendProperty m_frmTrendProperty = null;

        private List<string> m_lstAddressFilter = new List<string>();
        private List<string> m_lstDescriptionFilter = new List<string>();

        private CTimeLogS m_cTimeLogS = new CTimeLogS();
        #endregion

        #region Initialize/Dispose

        public FrmMain()
        {
            InitializeComponent();

            SkinHelper.InitSkinGallery(exRibbonGallery, true);

            dtpkExportFrom.EditValue = System.DateTime.Now.AddMinutes(-30);
            dtpkExportTo.EditValue = System.DateTime.Now;			
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void WriteEventLogTable(DateTime dtTime, string sSender, string sMessage)
        {
            ucSystemLogTable.AddMessage(dtTime, sSender, sMessage);
        }

        #endregion


        #region Private Methods

        private bool CheckProjectAvailable()
        {
            if (ucProjectManager.Project == null || ucProjectManager.Project.Name == "")
            {
                MessageBox.Show("Please Create New Project First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private bool CheckProjectEditable()
        {
            if (m_cTracker.IsRunning)
            {
                MessageBox.Show("Please Stop Monitoring First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckDataBaseAvailable()
        {
            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        protected void UpdateSystemMessage(string sSender, string sMessage)
        {
            if (this.InvokeRequired)
            {
                UpdateTextCallBack cbUpdateText = new UpdateTextCallBack(UpdateSystemMessage);
                this.Invoke(cbUpdateText, new object[] { sSender, sMessage });
            }
            else
                ucSystemLogTable.AddMessage(DateTime.Now, sSender, sMessage);
        }
    
        protected void InitFilter()
        {
            txtAddressFilter.EditValue = "S\r\nU";
            txtDescriptionFilter.EditValue = "";
        }
        
        #endregion


        #region Event Methods

        #region Form Event

        private void FrmMain_Load(object sender, EventArgs e)
        {   
            ucProjectManager.Editable = true;
            ucProjectManager.Project = new UDM.Project.CProject();
            m_cTracker.ProjectManager = ucProjectManager;
            m_cTracker.GroupStateTable = ucGroupStateTable;
            m_cTracker.MonitorStatusView = ucMonitorStatus;            
			// 20150729 MH Kim StepArea
			m_cTracker.GroupCycleBoardS = ucGroupCycleBoardS;

            bool bOK = m_cReader.Connect();
            if (bOK == false)
            {
                MessageBox.Show("Can't connect Database!! Please check Database installation", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_cTracker.UEventCycleStarted += new UEventHandlerTrackerCycleStarted(m_cTracker_UEventCycleStarted);
            m_cTracker.UEventErrorDetected += new UEventHandlerTrackerErrorDetected(m_cTracker_UEventErrorDetected);

            InitFilter();
            UpdateAddressFilter();
            UpdateDescriptionFilter();
        }

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (m_cTracker.IsRunning)
			{
				MessageBox.Show("Please stop monitoring first!!", "UDMTracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
				e.Cancel = true;
			}
		}

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            lblMonitorCount.Caption = UDM.Monitor.Plc.CMonitorStatus.RecieveDataCount.ToString();
            lblMonitorCount.Refresh();

            UDM.Monitor.Plc.CMonitorStatus.RecieveDataCount = 0;
        }

        private void m_cTracker_UEventCycleStarted(string sGroupKey)
        {
            if(m_frmAlertView != null && m_frmAlertView.GroupKey == sGroupKey)
            {
                m_frmAlertView.Close();
                m_frmAlertView = null;
            }
        }

        private void m_cTracker_UEventErrorDetected(CGroupLog cGroupLog, CMonitorErrorInfo cErrorInfo)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            if (m_cTracker.MonitorType != EMMonitorType.Detection)
                return;

            if (m_frmAlertView == null)
            {
                m_frmAlertView = new FrmAlertViewer(cGroupLog.Key, ucProjectManager.Project, m_cReader, cGroupLog, cErrorInfo, m_cTracker.Monitor);
                m_frmAlertView.WindowState = FormWindowState.Maximized;
                m_frmAlertView.FormClosed += new FormClosedEventHandler(m_frmAlertView_FormClosed);
                this.Invoke((MethodInvoker)delegate() { m_frmAlertView.Show(); });
            }
            else
            {
                m_frmAlertView.GroupLog = cGroupLog;
                m_frmAlertView.ErrorInfo = cErrorInfo;
                m_frmAlertView.Refresh();
            }
        }

        private void m_frmAlertView_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_frmAlertView.FormClosed -= new FormClosedEventHandler(m_frmAlertView_FormClosed);
            m_frmAlertView = null;
        }

        private void chkLsPlc_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            SetCheckBox();
        }
        
        #endregion

		#region UC Event

        private void ucProjectManager_UEventProjectCleared(object sender)
        {
            if (ucProjectManager.Project == null)
                return;

            ucGroupStateTable.Clear();
			ucGroupCycleBoardS.Clear();
        }

        private void ucProjectManager_UEventProjectCreated(object sender)
        {
            if (ucProjectManager.Project == null)
                return;

            ucGroupStateTable.GroupS = ucProjectManager.Project.GroupS;
            ucGroupStateTable.ShowTable();

			ucGroupCycleBoardS.GroupS = ucProjectManager.Project.GroupS;
			ucGroupCycleBoardS.ShowBoard();
        }

        private void ucProjectManager_UEventProjectOpened(object sender)
        {
            if (ucProjectManager.Project == null)
                return;

            ucGroupStateTable.GroupS = ucProjectManager.Project.GroupS;
            ucGroupStateTable.ShowTable();

			ucGroupCycleBoardS.GroupS = ucProjectManager.Project.GroupS;
			ucGroupCycleBoardS.ShowBoard();
        }

		private void ucGroupTree_UEventGroupUpdated(object sender, CGroup cGroup)
		{
            ucGroupStateTable.GroupS = ucProjectManager.Project.GroupS;
            ucGroupStateTable.ShowTable();

			ucGroupCycleBoardS.GroupS = ucProjectManager.Project.GroupS;
			ucGroupCycleBoardS.ShowBoard();
		}

        private void ucGrouplTree_UEventGroupDoubleClicked(object sender, CGroup cGroup)
        {
            if (cGroup == null)
                return;

            if (m_frmGroupProperty != null)
            {
                m_frmGroupProperty.Close();
                m_frmGroupProperty.Dispose();
                m_frmGroupProperty = null;
            }

            m_frmGroupProperty = new FrmGroupProperty();
			m_frmGroupProperty.Editable = !m_cTracker.IsRunning;
            m_frmGroupProperty.Group = cGroup;
            m_frmGroupProperty.TopMost = true;
            m_frmGroupProperty.Show();
        }

		private void ucGroupTree_UEventSymbolAdding(object sender, string sGroup, CTagS cTagS, EMGroupRoleType emRoleType)
		{	
			if(emRoleType == EMGroupRoleType.Key)
			{
				CTag cTag;
				bool bFiltered = false;
				for(int i=0;i<cTagS.Count;i++)
				{	
					cTag = cTagS[i];

					bFiltered = false;
					if(cTag.DataType != EMDataType.Bool || cTag.IsEndContact())
						bFiltered = true;
					else if(CTrackerHelper.IsAddressFiltered(cTag, m_lstAddressFilter))
						bFiltered = true;
					else if( CTrackerHelper.IsDescriptionFiltered(cTag, m_lstDescriptionFilter))
						bFiltered = true;

					if(bFiltered)
					{
						cTagS.Remove(cTag.Key);
						i--;
					}					
				}
			}
			else if(emRoleType == EMGroupRoleType.General)
			{
				CTag cTag;
				bool bFiltered = false;
				for (int i = 0; i < cTagS.Count; i++)
				{
					cTag = cTagS[i];

					bFiltered = false;
					if (CTrackerHelper.IsAddressFiltered(cTag, m_lstAddressFilter))
						bFiltered = true;
					else if (CTrackerHelper.IsDescriptionFiltered(cTag, m_lstDescriptionFilter))
						bFiltered = true;

					if (bFiltered)
					{
						cTagS.Remove(cTag.Key);
						i--;
					}
				}
			}
			else if(emRoleType == EMGroupRoleType.Abnormal)
			{
				CTag cTag;
				bool bFiltered = false;
				for (int i = 0; i < cTagS.Count; i++)
				{
					cTag = cTagS[i];

					bFiltered = false;
					if (cTag.DataType != EMDataType.Bool)
						bFiltered = true;
					else if (CTrackerHelper.IsAddressFiltered(cTag, m_lstAddressFilter))
						bFiltered = true;

					if (bFiltered)
					{
						cTagS.Remove(cTag.Key);
						i--;
					}
				}
			}
			else if(emRoleType == EMGroupRoleType.Trend)
			{
				CTag cTag;
				bool bFiltered = false;
				for (int i = 0; i < cTagS.Count; i++)
				{
					cTag = cTagS[i];

					bFiltered = false;
					if (cTag.DataType != EMDataType.Word && cTag.DataType != EMDataType.DWord)
						bFiltered = true;
					else if (CTrackerHelper.IsAddressFiltered(cTag, m_lstAddressFilter))
						bFiltered = true;
					else if (CTrackerHelper.IsDescriptionFiltered(cTag, m_lstDescriptionFilter))
						bFiltered = true;

					if (bFiltered)
					{
						cTagS.Remove(cTag.Key);
						i--;
					}
				}
			}
		}

        private void ucGrouplTree_UEventSymbolDoubleClicked(object sender, string sGroup, CSymbol cSymbol)
        {
            if (cSymbol == null)
                return;

            if (sGroup == "")
                return;

            if (cSymbol.RoleType == EMGroupRoleType.Trend)
            {
                if (m_frmTrendProperty != null)
                {
                    m_frmTrendProperty.Close();
                    m_frmTrendProperty.Dispose();
                    m_frmTrendProperty = null;
                }

                m_frmTrendProperty = new FrmTrendProperty();
                m_frmTrendProperty.Symbol = cSymbol;
                m_frmTrendProperty.TopMost = true;
                m_frmTrendProperty.Show();
            }
        }

        private string ucGrouplTree_UEventInputTextRequest(object sender)
        {
			string sText = GetUserInputText("Input Text", "Please enter text below...");

            return sText;
        }        

        private string ucTagTable_UEventInputTextRequest(object sender)
        {
			string sText = GetUserInputText("Input Text", "Please enter text below...");

            return sText;
        }

        #endregion
		
        #endregion

        private void btnMonitorEventViewer_Click(object sender, ItemClickEventArgs e)
        {
            FrmMonitorHistoryViewer frmMonitorEvent = new FrmMonitorHistoryViewer();

            frmMonitorEvent.DBReader = m_cReader;
            frmMonitorEvent.ShowDialog();
        }

    }
}