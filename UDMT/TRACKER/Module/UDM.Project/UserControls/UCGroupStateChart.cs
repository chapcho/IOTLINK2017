using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Monitor.Plc;
using UDM.Log;

namespace UDM.Project
{
	public partial class UCGroupStateChart : DevExpress.XtraEditors.XtraUserControl
	{
		#region Member Variables

		protected Timer m_tmrTicker = new Timer();
		protected int m_iRowCount = -1;
		protected int m_iMinHeight = 150;

		protected CGroupS m_cGroupS = null;
        protected CMonitorViewer m_cMonitorViewer = null;

		public event UEventHandlerGroupStateChartItemClicked UEventGroupItemClicked;

		#endregion


		#region Public Properties
        public CGroupS GroupS
        {
            get { return m_cGroupS; }
            set {m_cGroupS = value; }
        }

        public CMonitorViewer MonitorViewer
        {
            get { return m_cMonitorViewer; }
            set { m_cMonitorViewer = value; }
        }
		#endregion


		#region Initialize/Dispose

		public UCGroupStateChart()
		{
			InitializeComponent();
		}

        public void InitializeSetting()
        {
            m_tmrTicker.Interval = 500;
			pnlView.HorizontalScroll.Visible = false;
        }

		#endregion


		#region Public Methods

        public void ShowChart()
        {
            Clear();
            SetGroupS();
        }

		public void Clear()
		{
			if(pnlView.Controls.Count > 0)
			{
				for(int i =0; i < pnlView.Controls.Count; i++)
				{
					UCGroupStateChartUnit ucUnit = (UCGroupStateChartUnit)pnlView.Controls[i];
					ucUnit.Clear();
				}
			}

			pnlView.Controls.Clear();

			pnlView.Refresh();
		}

        public void AddGroup(string sName)
        {
			UCGroupStateChartUnit ucViewer = new UCGroupStateChartUnit();

			try
			{
				ucViewer.Name = sName;
				pnlView.Controls.Add(ucViewer);

				ucViewer.UEventChartItemClicked += ucViewer_UEventChartItemClicked;

				SetUnitSize();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

        public void RemoveGroup(string sName)
        {
			pnlView.Controls.RemoveByKey(sName);
        }

        public void Run()
        {
			try
			{
				Clear();

				SetGroupS();

				if (m_cMonitorViewer != null)
					m_cMonitorViewer.UEventGroupStateChanged += m_cMonitorViewer_UEventGroupStateChanged;

				m_tmrTicker.Tick += m_tmrTicker_Tick;
				m_tmrTicker.Start();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }
		

        public void Stop()
        {
			try
			{
				if (m_cMonitorViewer != null)
					m_cMonitorViewer.UEventGroupStateChanged -= m_cMonitorViewer_UEventGroupStateChanged;

				if (m_tmrTicker.Enabled)
					m_tmrTicker.Stop();
				
				m_tmrTicker.Tick -= m_tmrTicker_Tick;

				if (pnlView.Controls.Count > 0)
				{
					for (int i = 0; i < pnlView.Controls.Count; i++)
					{
						UCGroupStateChartUnit ucUnit = (UCGroupStateChartUnit)pnlView.Controls[i];
						ucUnit.Stop();
					}
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }
		#endregion

		#region Private Methods

        private void SetGroupS()
        {	
			try
			{
                if (m_cGroupS == null) return;
				foreach (string sKey in m_cGroupS.Keys)
					AddGroup(sKey);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

		private void SetUnitSize()
		{
			pnlView.HorizontalScroll.Visible = false;

			ControlCollection controls = pnlView.Controls;
			if (controls.Count == 0)
				return;

			bool bShowScrollBar = false;

			try
			{	
				int iUnitHeight = pnlView.ClientRectangle.Height / controls.Count;
				int iTotalHeight = pnlView.ClientRectangle.Height;
				
				if (iUnitHeight < m_iMinHeight)
				{
					iUnitHeight = m_iMinHeight;
					iTotalHeight = m_iMinHeight * controls.Count;
					bShowScrollBar = true;
				}

				int iUnitWidth = pnlView.Width;
				if(bShowScrollBar)
				{
					pnlView.VerticalScroll.Visible = true;
					iUnitWidth = iUnitWidth - 20;
				}
				else
				{
					pnlView.VerticalScroll.Visible = false;
				}
				
				int iPosY = 0;
				for (int i = 0; i < controls.Count - 1; i++)
				{
					controls[i].Location = new Point(0, iPosY);
					controls[i].Width = iUnitWidth;
					controls[i].Height = iUnitHeight;

					iPosY += iUnitHeight;
				}

				int iUnitCount = controls.Count;
				controls[iUnitCount - 1].Location = new Point(0, iPosY);
				controls[iUnitCount - 1].Width = iUnitWidth;
				controls[iUnitCount - 1].Height = iTotalHeight - iPosY;

				pnlView.Refresh();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void GenerateGroupItemClickEvent(CGroupLog cLog)
		{
			if (UEventGroupItemClicked != null)
				UEventGroupItemClicked(this, cLog);
		}

		#endregion


        #region Event Methods

		private void UCGroupStateChart_Load(object sender, EventArgs e)
		{

		}

		private void UCGroupStateChart_Resize(object sender, EventArgs e)
		{
			try
			{
				SetUnitSize();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}


        private void m_cMonitorViewer_UEventGroupStateChanged(object sender, Log.CGroupLog cLog)
        {
            if (cLog.Key == null || cLog.Key == "")
                return;
           
            CGroupLog cGroupLog = (CGroupLog)cLog.Clone();            
			UCGroupStateChartUnit ucUnit = (UCGroupStateChartUnit) pnlView.Controls[cGroupLog.Key];

			try
			{
				if (cGroupLog.StateType == EMGroupStateType.Start)
				{
					ucUnit.GroupLog = cGroupLog;
					ucUnit.Run();
				}
				else
				{
					ucUnit.GroupLog = cGroupLog;
					ucUnit.Stop();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

		private void m_tmrTicker_Tick(object sender, EventArgs e)
		{
			m_tmrTicker.Stop();

			ControlCollection controls = pnlView.Controls;
			UCGroupStateChartUnit ucUnit = null;

			double nElapseTime = (double)m_tmrTicker.Interval / 1000;

			try
			{
				for (int i = 0; i < controls.Count; i++)
				{
					ucUnit = (UCGroupStateChartUnit)controls[i];
					ucUnit.ElapseTime(nElapseTime);
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

			m_tmrTicker.Start();
		}

		private void ucViewer_UEventChartItemClicked(object sender, CGroupLog cLog)
		{
			GenerateGroupItemClickEvent(cLog);
		}

		#endregion
	}
}
