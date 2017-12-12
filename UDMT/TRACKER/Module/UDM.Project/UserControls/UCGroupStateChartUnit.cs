using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;
using DevExpress.XtraCharts;

namespace UDM.Project
{
	public partial class UCGroupStateChartUnit : DevExpress.XtraEditors.XtraUserControl
	{
		#region Member Variables

		protected bool m_bRun = false;
		protected Series m_exSeries = null;
		protected SeriesPoint m_exPoint = null;
		protected CGroupLog m_cLog = null;
		protected double m_nElapseTime = 0;
		protected string m_sRecipe = string.Empty;

		private delegate void UpdateGroupStateCallback();
		private delegate void UpdateGroupCycleElapseTimeCallback(double nValue);

		public event UEventHandlerGroupStateChartItemClicked UEventChartItemClicked;

		#endregion

		#region Initialize/Dispose
		public UCGroupStateChartUnit()
		{
			InitializeComponent();
			m_exSeries = new Series();
			m_exSeries = exChart.Series["Series1"];
		}
		
		#endregion


		#region Public Properties

		public CGroupLog GroupLog
		{
			get { return m_cLog; }
			set { SetGroupLog(value); }
		}

		#endregion


		#region Public Methods

		public void Clear()
		{
			txtCycleTime.Text = "00.00";

			m_exSeries.Points.Clear();

			try
			{
				if (m_exSeries != null)
					m_exSeries.Points.Clear();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void Run()
		{
			if (this.InvokeRequired)
			{
				UpdateGroupStateCallback cbUpdateState = new UpdateGroupStateCallback(Run);
				this.Invoke(cbUpdateState);
			}
			else
			{
				m_bRun = true;
				XYDiagram diagram = (XYDiagram)exChart.Diagram;

				lblStatus.Appearance.BackColor = Color.GreenYellow;
				lblStatus.Text = "RUN";

				try
				{
					if (m_exSeries.Points.Count > 10)
						m_exSeries.Points.RemoveAt(0);

					SeriesPoint exPoint = null;
					for (int i = 0; i < m_exSeries.Points.Count; i++)
					{
						exPoint = m_exSeries.Points[i];
						exPoint.NumericalArgument = exPoint.NumericalArgument - 1;
					}

					m_nElapseTime = 0;
					txtCycleTime.Text = String.Format("{0:0.00}", m_nElapseTime);

					m_exPoint = new SeriesPoint(0, m_nElapseTime);
					m_exPoint.Tag = m_cLog;
					m_exPoint.ToolTipHint = m_sRecipe;
					m_exSeries.Points.Add(m_exPoint);

					exChart.RefreshData();
				}
				catch (System.Exception ex)
				{
					Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				}
			}
		}

		public void Stop()
		{
			if (this.InvokeRequired)
			{
				UpdateGroupStateCallback cbUpdateState = new UpdateGroupStateCallback(Stop);
				this.Invoke(cbUpdateState);
			}
			else
			{

				try
				{
					if (m_bRun)
					{

						m_bRun = false;
						lblStatus.Text = "WAIT";
						if (m_cLog.StateType == EMGroupStateType.Start || m_cLog.StateType == EMGroupStateType.End)
							lblStatus.Appearance.BackColor = Color.LightGray;
						else
							lblStatus.Appearance.BackColor = Color.OrangeRed;

						if (m_cLog.CycleStart != DateTime.MinValue && m_cLog.CycleEnd != DateTime.MinValue)
							m_nElapseTime = (double)m_cLog.CycleEnd.Subtract(m_cLog.CycleStart).TotalSeconds;

						if (m_nElapseTime < 0)
							m_nElapseTime = 0;

						m_nElapseTime = Math.Round(m_nElapseTime, 2);
						txtCycleTime.Text = String.Format("{0:0.00}", m_nElapseTime);

						m_exPoint.Values = new double[] { m_nElapseTime };
						m_exPoint.Tag = m_cLog;

						exChart.RefreshData();

						m_exPoint = null;
					}
				}
				catch (System.Exception ex)
				{
					Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				}
			}
		}

		public void ElapseTime(double nSecond)
		{
			if (this.InvokeRequired)
			{
				UpdateGroupCycleElapseTimeCallback cbUpdateState = new UpdateGroupCycleElapseTimeCallback(ElapseTime);
				this.Invoke(cbUpdateState, new object[] {nSecond});
			}
			else
			{
				try
				{
					if (m_cLog == null)
						return;

					if (m_cLog.StateType == EMGroupStateType.Start)
					{
						if (m_bRun)
						{
							m_nElapseTime += nSecond;
							m_nElapseTime = Math.Round(m_nElapseTime, 2);
							txtCycleTime.Text = String.Format("{0:0.00}", m_nElapseTime);

							if (m_exPoint != null)
							{
								m_exPoint.Values = new double[] { m_nElapseTime };
								exChart.RefreshData();
							}
						}
					}
				}
				catch (System.Exception ex)
				{
					Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
				}
			}
				
		}
		#endregion


		#region Private Methods

		private void SetGroupLog(CGroupLog cLog)
		{
			m_cLog = cLog;
			if (m_cLog == null)
				return;

			try
			{
				if(m_cLog.StateType == EMGroupStateType.Start)
					m_sRecipe = m_cLog.Recipe;
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void GenerateChartItemClickEvent(CGroupLog cLog)
		{
			if (UEventChartItemClicked != null)
				UEventChartItemClicked(this, cLog);
		}

		#endregion


		#region Event Methods

		private void UCGroupStateChartUnit_Load(object sender, EventArgs e)
		{
			lblGroupName.Text = Name;
		}

		private void exChart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
		{
			BarDrawOptions barDraw = e.SeriesDrawOptions as BarDrawOptions;
			e.LabelText = string.Format("[{0}] {1}", m_sRecipe, e.LabelText);

			try
			{
				CGroupLog cLog = (CGroupLog)e.SeriesPoint.Tag;

				if (barDraw == null)
					return;

				if (cLog == null)
					return;

				if(cLog.StateType == EMGroupStateType.Start)
				{
					barDraw.Color = Color.GreenYellow;
					barDraw.FillStyle.FillMode = FillMode.Solid;
				}
				else if (cLog.StateType == EMGroupStateType.End)
				{
					barDraw.Color = Color.LightGray;
					barDraw.FillStyle.FillMode = FillMode.Solid;
				}
				else
				{
					barDraw.Color = Color.OrangeRed;
					barDraw.FillStyle.FillMode = FillMode.Solid;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void exChart_ObjectSelected(object sender, HotTrackEventArgs e)
		{
			if (e.HitInfo.InSeries && e.HitInfo.SeriesPoint != null)
			{
				CGroupLog cLog = (CGroupLog)e.HitInfo.SeriesPoint.Tag;
				if (cLog == null)
					return;

				GenerateChartItemClickEvent(cLog);
			}
		}

		#endregion
	}
}
