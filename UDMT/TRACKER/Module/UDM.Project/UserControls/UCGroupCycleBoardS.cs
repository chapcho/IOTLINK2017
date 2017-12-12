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
	public partial class UCGroupCycleBoardS : DevExpress.XtraEditors.XtraUserControl
	{
		#region Member Variables

		protected Timer m_tmrTicker = new Timer();
		protected int m_iRowCount = -1;
		protected int m_iMinHeight = 225;

		protected CGroupS m_cGroupS = null;
        protected CMonitorViewer m_cMonitorViewer = null;

		public event UEventHandlerGroupStateChartItemClicked UEventGroupItemClicked;

		#endregion


		#region Initialize/Dispose

		public UCGroupCycleBoardS()
		{
			InitializeComponent();
		}

		#endregion

		#region Public Properties

		public CGroupS GroupS
		{
			get { return m_cGroupS; }
			set { m_cGroupS = value; }
		}

		public CMonitorViewer MonitorViewer
		{
			get { return m_cMonitorViewer; }
			set { m_cMonitorViewer = value; }
		}

		#endregion


		#region Public Methods

        public void ShowBoard()
        {
            Clear();
            SetGroupS();
        }

		public void Clear()
		{
			pnlView.Controls.Clear();

			pnlView.Refresh();
		}
        
        public void Run()
        {
			try
			{
				Clear();

				SetGroupS();

				if (m_cMonitorViewer != null)
					m_cMonitorViewer.UEventGroupStateChanged += m_cMonitorViewer_UEventGroupStateChanged;

				m_tmrTicker.Interval = 1000;
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
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

		#endregion


		#region Private Methods

		private void AddGroup(CGroup cGroup)
		{
			try
			{
				UCGroupCycleBoard ucViewer = new UCGroupCycleBoard();
				Panel pnlSplitter = new Panel();
				pnlSplitter.Dock = DockStyle.Top;
				pnlSplitter.Height = 5;

				ucViewer.Name = cGroup.Key;
				ucViewer.Title = cGroup.Key;
				ucViewer.Dock = DockStyle.Top;
				ucViewer.MaxCycleTime = cGroup.MaxCycleTime/1000;
				ucViewer.Height = m_iMinHeight;

				pnlView.Controls.Add(pnlSplitter);
				pnlView.Controls.Add(ucViewer);
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void RemoveGroup(string sName)
		{
			pnlView.Controls.RemoveByKey(sName);
		}


        private void SetGroupS()
        {	
			try
			{
                if (m_cGroupS == null) return;
				CGroup cGroup;
				for(int i=0;i<m_cGroupS.Count;i++)
				{
					cGroup = m_cGroupS[i];
					AddGroup(cGroup);
				}

				SetUnitSize();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

		private void SetUnitSize()
		{
			ControlCollection controls = pnlView.Controls;
			if (controls.Count == 0)
				return;

			try
			{
                int iUnitHeight = 0;
                if (controls.Count > 7)
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / controls.Count;
                else
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / 8;
				if (iUnitHeight < m_iMinHeight)
					iUnitHeight = m_iMinHeight;

				Control control;
				for (int i = 0; i < controls.Count; i++)
				{
					control = controls[i];
					if(control.GetType() == typeof(UCGroupCycleBoard))
						control.Height = iUnitHeight - 5;
				}

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
			UCGroupCycleBoard ucUnit = (UCGroupCycleBoard)pnlView.Controls[cGroupLog.Key];

			try
			{
				if(cGroupLog.StateType == EMGroupStateType.End || cGroupLog.StateType == EMGroupStateType.ErrorEnd)
					ucUnit.SetGroupStatus(cGroupLog.StateType, cGroupLog.CycleEnd.Subtract(cGroupLog.CycleStart).TotalSeconds);
				else
					ucUnit.SetGroupStatus(cGroupLog.StateType, 0);
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

			double nElapseTime = (double)m_tmrTicker.Interval / 1000;

			try
			{
				Control control;
				for (int i = 0; i < controls.Count; i++)
				{
					control = controls[i];
					if(control.GetType() == typeof(UCGroupCycleBoard))
						((UCGroupCycleBoard)control).ElapseTime();
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
