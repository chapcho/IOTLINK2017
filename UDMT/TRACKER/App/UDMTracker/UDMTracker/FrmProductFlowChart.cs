using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;

namespace UDMTracker
{
	public partial class FrmProductFlowChart : Form
	{
		#region Member Verialbes
		protected bool m_bVerified = false;
		protected CProject m_cProject = null;
		protected CMySqlLogReader m_cReader = null;

		protected string m_sData = string.Empty;
		#endregion

		#region Properties
		public CProject Project
		{
			get { return m_cProject; }
			set { m_cProject = value; }
		}

		public CMySqlLogReader Reader
		{
			get { return m_cReader; }
			set { m_cReader = value; }
		}

		public string Data
		{
			get { return m_sData; }
			set { m_sData = value; }
		}
		#endregion

		#region Initialize/Dispose
		public FrmProductFlowChart()
		{
			InitializeComponent();
		}
		#endregion

		#region Public Methods
		public void sampleTest(string sGroup)
		{

		}
		#endregion

		#region Private methods
		private bool VerifyParameter()
		{
			if(m_cProject == null)
			{
				MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			if(m_cReader == null || m_cReader.IsConnected == false)
			{
				MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void InitComponent()
		{
			DateTime dtLast = m_cReader.GetLastTimeLogTime();

			if(dtLast == DateTime.MinValue)
			{
				dtpkFrom.EditValue = null;
				dtpkTo.EditValue = null;
			}
			else
			{
				dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
				dtpkTo.EditValue = (DateTime)dtLast;
			}
		}
		
		private void ExtractGroup(CGroupS cGroupS)
		{
			if (cGroupS == null)
				return;

			CFlowItemS cFlowGroupItemS = new CFlowItemS();
			CFlowItem cFlowGroupItem = null;
			DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;

			CGroupLogS cGroupLogS = null;
			for(int i = 0; i < cGroupS.Count; i++)
			{
				cGroupLogS = m_cReader.GetGroupLogS(cGroupS[i].Key, dtFrom, dtTo);
				CFlowItemS cItemS = ExtractSymbol(cGroupS[i], dtFrom, dtTo);
				cItemS.Sort();

				cFlowGroupItem = ucFlowGanttViewer.CreateGanttChart(cGroupS[i].Key, cGroupLogS, cItemS);
				cFlowGroupItemS.Add(cGroupS[i].Key, cFlowGroupItem);
			}

			ucFlowGanttViewer.CreateBarLinkS(cFlowGroupItemS);
		}

		private CFlowItemS ExtractSymbol(CGroup cGroup, DateTime dtFrom, DateTime dtTo)
		{
			CFlowItemS cItemS = null;
			cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cGroup.GetTotalTagS(), dtFrom, dtTo);
			return cItemS;
		}

		#endregion

		#region Event methods
		private void FrmGroupProductFlowChart_Load(object sender, EventArgs e)
		{
			m_bVerified = VerifyParameter();
			if (!m_bVerified)
				return;

			InitComponent();
		}

		private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_bVerified)
                return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ExtractGroup(m_cProject.GroupS);
            }
            SplashScreenManager.CloseForm(false);
        }

		private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!m_bVerified)
				return;

			ucFlowGanttViewer.Clear();
		}

		private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!m_bVerified)
				return;

			ucFlowGanttViewer.ZoomIn();
		}

		private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!m_bVerified)
				return;

			ucFlowGanttViewer.ZoomOut();
		}

		private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!m_bVerified)
				return;

			ucFlowGanttViewer.ItemUp();
		}

		private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (!m_bVerified)
				return;

			ucFlowGanttViewer.ItemDown();
		}

		private void ucFlowGanttViewer_UEventHandlerFindItem(object sender, string sGroup)
		{
			//MessageBox.Show(sGroup);
		}

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

		#endregion
	}
}
