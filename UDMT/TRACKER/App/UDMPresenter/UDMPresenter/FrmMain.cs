using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.DDEA;
using UDM.Log;
using UDM.Log.Csv;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source.OPC;

namespace UDMPresenter
{
	public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
	{

		#region Member Variables

        protected string m_sLogSavePathFile = Application.StartupPath + "\\LogFilePath.txt";
        protected Dictionary<string, List<string>> m_dicProjectLogPath = new Dictionary<string, List<string>>();

        protected bool m_bRun = false;
        protected delegate void UpdateTextCallBack(string sSender, string sMessage);
        protected delegate void ShowTagListCallBack(CDDEASymbolS cSymbolS);
        protected delegate void ShowSymbolListCallBack(CSymbolS cSymbolS);

		#endregion


		#region Initialize/Dispose

		public FrmMain()
		{
			InitializeComponent();

		}

		#endregion


		#region Public Properties

		private bool CheckProjectAvailable()
		{
            if (CProjectManager.SelectedProject == null || CProjectManager.SelectedProject.Name == "")
			{
				MessageBox.Show("Please Create New Project First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
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

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        /// <summary>
        /// 1개의 Form만 Open하기 위해서 확인
        /// </summary>
        /// <param name="frmType"></param>
        /// <returns></returns>
        private Form IsFormOpened(Type frmType)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                    return frm;
            }
            return null;
        }

        protected void UpdateSystemMessage(string sSender, string sMessage)
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
                    if (sMessage.Contains(","))
                    {
                        string[] sSplit = sMessage.Split(',');
                        if (sSplit.Length > 1)
                        {
                            switch (sSplit[0])
                            {
                                case "StartError":
                                    btnStop_ItemClick(null, null);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ucSystemMessage.AddMessage(DateTime.Now, sSender, sMessage);
                        //SetSystemLog(sSender, sMessage);
                        if (sMessage.Contains("ALL STOP"))
                        {
                            btnStop_ItemClick(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }

        private List<CDDEASymbol> FindShowDDEASymbolList(CDDEASymbolS cSymbolS)
        {
            List<CDDEASymbol> lstSymbol = cSymbolS.Select(x => x.Value).ToList();

            List<CDDEASymbol> lstReturnValue = lstSymbol.FindAll(b => b.AddressCount >= 1);

            return lstReturnValue;
        }

		#endregion

        private void btnSaveLogPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            dlgFolder.RootFolder = Environment.SpecialFolder.Desktop;
            dlgFolder.ShowDialog();

            CProjectManager.SelectedProject.SaveLogPath = dlgFolder.SelectedPath;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = AssemblyTitle + "  V" + AssemblyVersion;
            ucSymbolTable.UEventSymbolAdded += ucSymbolTable_UEventSymbolAdded;
            ucSymbolTable.UEventSymbolRemoved += ucSymbolTable_UEventSymbolRemoved;
            
            if (File.Exists(m_sLogSavePathFile) == false)
            {
                FileStream stream = File.Create(m_sLogSavePathFile);
                stream.Dispose();
                stream = null;
            }
            CProjectManager.TagTable = ucTagTable;
            CProjectManager.SymbolTable = ucSymbolTable;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bRun)
            {
                MessageBox.Show("수집 중입니다. 먼저 정지하세요", "UDM Present", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void tmrDataRefresh_Tick(object sender, EventArgs e)
        {
            tmrDataRefresh.Enabled = false;

            grdRunSymbolView.RefreshDataSource();
            grvRunSymbolView.RefreshData();

            tmrDataRefresh.Enabled = true;
        }

        private void pnlTagTable_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void pnlSymbolTable_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckProjectAvailable() == false)
                return;

            if (CProjectManager.SelectedProject.StepS.Count == 0)
            {
                MessageBox.Show("Step이 없어 실행할 수 없습니다.");
                UpdateSystemMessage("Model", "Step이 없어 실행할 수 없습니다. Import Logic해야 합니다.");
                return;
            }
            FrmModeler frmModel = new FrmModeler();
            frmModel.ShowDialog();
            CProjectManager.UpdateView();
        }

        private void radioGroupProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iIndex = radioGroupProjectList.SelectedIndex;
            if (iIndex < 0) return;

            CProjectManager.SelectProject(iIndex);
            
            SetRadioItemDescription();

            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.OPC)
                ShowSymbolStatusTable(CProjectManager.SelectedProject.SymbolS);
            else
                ShowTagList(CProjectManager.SelectedProject.DDEASymbolS);

            CProjectManager.UpdateView();
        }

        private void btnOpenTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void btnSaveTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grvRunSymbolView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void exRibbonMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLogFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.SelectedProject.SaveLogPath == "") return;
            try
            {
                System.Diagnostics.Process.Start(CProjectManager.SelectedProject.SaveLogPath);
            }
            catch (Exception ex)
            {
                UpdateSystemMessage("Open Log Folder", "경로를 찾을 수 없습니다.");
            }
        }

        private void btnProjectClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CProjectManager.Clear();
            radioGroupProjectList.Properties.Items.Clear();
            btnRemoveProject.Enabled = false;
            ActiveIconNew(false);
            CProjectManager.SelectedProject = null;
        }

        private void btnConfigEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.DDEA)
            {
                FrmDDEAProperty frmDDEA = new FrmDDEAProperty();
                frmDDEA.Project = CProjectManager.SelectedProject;
                frmDDEA.ShowDialog();
            }
            else if (CProjectManager.SelectedProject.CollectorType == UDM.Monitor.Plc.Source.EMSourceType.LS)
            {
                FrmLsPlcConfig frmLs = new FrmLsPlcConfig();
                frmLs.Project = CProjectManager.SelectedProject;
                frmLs.ShowDialog();
            }
            else
            {
                FrmOpcConfig frmOpc = new FrmOpcConfig();
                frmOpc.Project = CProjectManager.SelectedProject;
                frmOpc.ShowDialog();
            }
        }
	}
}
