using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Monitor.Plc;
using UDM.Monitor.Plc.Source.LS;
using UDM.Log;
using UDM.Log.Csv;
using UDM.DDEA;

namespace UDMEnergyViewer
{
	public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
	{

		#region Member Variables

        protected bool m_bRun = false;
        protected CTagItemS m_cTagItemS = new CTagItemS();
        protected CMeterItemS m_cMeterItemS = new CMeterItemS();
        protected CDDEATask m_cLogTask = null;
        protected Dictionary<string, List<string>> m_dicProjectLogPath = new Dictionary<string, List<string>>();

        protected string m_sLogSavePathFile = Application.StartupPath + "\\LogFilePath.txt";
		protected delegate void UpdateTextCallBack(string sSender, string sMessage);

		#endregion


		#region Initialize/Dispose

		public FrmMain()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties


		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		private void InitLayout()
		{
			CProjectManager.TagTable = ucTagTable;
			CProjectManager.SymbolTable = ucSymbolTable;

			exEditorLogPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(exEditorLogPath_ButtonClick);
		}

		private bool CheckProjectAvailable()
		{
			if (CProjectManager.Project == null || CProjectManager.Project.Name == "")
			{
				MessageBox.Show("Please Create New Project First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return false;
			}

			return true;
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
					ucLogTable.AddMessage(DateTime.Now, sSender, sMessage);
				}
			}
			catch (Exception ex)
			{
				ex.Data.Clear();
			}
		}

        private bool CheckAnalysisAvailable()
        {
            //if(CProjectManager.Project.UnitTagItemS.Count != m_cMeterItemS.Count)
            //{
            //    MessageBox.Show("Please Classify Unit Tag First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return true;
        }

		#endregion
		

		#region Event Methods

		private void FrmMain_Load(object sender, EventArgs e)
		{
			InitLayout();

			ShowModelConfig();
		}

		#region Home

		private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			New();
		}

		private void btnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Open();
		}

		private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			Save();
		}

		private void btnMonitorStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			StartMonitor();
		}

		private void btnMonitorStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			StopMonitor();
		}

        private void btnOpenLogFolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenLogFolder();
        }
        
        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

		#endregion

		#region Model

		private void btnImportLogic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            ImportLogic();           
		}

		private void btnImportTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            ImportMelsecTag();
            //ImportTag();
		}

        private void btnExportTag_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportTag();
        }

		private void btnApplyPlcConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ApplyPlcConfig();
            ApplyEnergyConfig();
		}

		private void btnPlcTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			TestPlcConnect();
            TestEnergyConnect();
		}

		private void btnApplyLogConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ApplyLogConfig();	
		}

		private void exEditorLogPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			ChangeLogPath();
		}

        private void cmbPlcSourceType_EditValueChanged(object sender, EventArgs e)
        {
            if(cmbPlcSourceType.EditValue.ToString().StartsWith("USB"))
            {
                txtPlcIP.Enabled = false;
                txtPlcPort.Enabled = false;
            }
            else if (cmbPlcSourceType.ToString().StartsWith("Ethernet"))
            {
                txtPlcIP.Enabled = true;
                txtPlcPort.Enabled = true;
            }
        }

		#endregion

		#region View

		private void btnAddPlcLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            AddPlcLog();
		}

        private void btnClearPlcLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearPlcLog();
        }

		private void btnAddMeterLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            AddMeterLog();
		}

        private void btnClearMeterLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearMeterLog();
        }

		private void btnShowChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
            //if (CheckAnalysisAvailable() == false)
            //    return;

            ShowChart();            
		}

        private void btnClassifyCoil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClassifyCoil();
        }

        private void btnCalibration_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.Project.MeterItemS.Count == 0 || CProjectManager.Project.TagItemS.Count == 0)
            {
                MessageBox.Show("Please Import Energy/PLC Log First!!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool bOK = Calibration();

            if (bOK)
                UpdateSystemMessage("Data Calibration", "Calibration Success!");
            else
                MessageBox.Show("Can't Calibrate Energy/PLC Log Data", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnEnergyAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckAnalysisAvailable() == false)
                return;

            EnergyAnalysis();
        }

        private void btnRegressionUnitView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CProjectManager.Project.RegressionUnitS.Count == 0)
            {
                MessageBox.Show("Please Analysis Energy Unit First!!", "Regression Unit View", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
        }

		#endregion






		#endregion


	}
}
