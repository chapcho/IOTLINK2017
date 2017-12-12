using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraNavBar;

namespace UDMTrackerSimple
{
	public partial class FrmStatisticsChartViewer : Form
	{
		#region Member Variables
		protected List<CStatisticsViewRow> m_lstRowS = null;
		#endregion

		#region Properties
		public List<CStatisticsViewRow> StatisticsViewRowS
		{
			get { return m_lstRowS; }
			set { m_lstRowS = value; }
		}
		#endregion

		#region Initialize
		public FrmStatisticsChartViewer()
		{
			InitializeComponent();
		}
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		private void SetNavItemTag()
		{
			if (m_lstRowS == null)
				return;

			SortedList<string, double> lstTotalValueS = new SortedList<string, double>();
			SortedList<string, double> lstErrorValueS = new SortedList<string, double>();
			SortedList<string, double> lstCMeanValueS = new SortedList<string, double>();
			SortedList<string, double> lstCMinValueS = new SortedList<string, double>();
			SortedList<string, double> lstCMaxValueS = new SortedList<string, double>();
			SortedList<string, double> lstStdValueS = new SortedList<string, double>();
			SortedList<string, double> lstCpValueS = new SortedList<string, double>();
			SortedList<string, double> lstCpkValueS = new SortedList<string, double>();
			SortedList<string, double> lstIMeanValueS = new SortedList<string, double>();
			SortedList<string, double> lstIMinValueS = new SortedList<string, double>();
			SortedList<string, double> lstIMaxValueS = new SortedList<string, double>();
			SortedList<string, double> lstRAllValueS = new SortedList<string, double>();
			SortedList<string, double> lstRMeanValueS = new SortedList<string, double>();
			SortedList<string, double> lstRMinValueS = new SortedList<string, double>();
			SortedList<string, double> lstRMaxValueS = new SortedList<string, double>();

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstCMeanValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.Mean);
			}
			itemCycleMean.Tag = lstCMeanValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstCMinValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.Minimum);
			}
			itemCycleMin.Tag = lstCMinValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstCMaxValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.Maximum);
			}
			itemCycleMax.Tag = lstCMaxValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstStdValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.StandardDev);
			}
			itemCycleStd.Tag = lstStdValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstCpValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.Cp);
			}
			itemCycleCp.Tag = lstCpValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstCpkValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].CycleInfoView.Cpk);
			}
			itemCycleCpk.Tag = lstCpkValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstIMeanValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].IdleInfo.Mean);
			}
			itemIdleMean.Tag = lstIMeanValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstIMinValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].IdleInfo.Minimum);
			}
			itemIdleMin.Tag = lstIMinValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstIMaxValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].IdleInfo.Maximum);
			}
			itemIdleMax.Tag = lstIMaxValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstRMeanValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].RecoveryInfo.Mean);
			}
			itemRecoveryMean.Tag = lstRMeanValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstRMinValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].RecoveryInfo.Minimum);
			}
			itemRecoveryMin.Tag = lstRMinValueS;

			for (int i = 0; i < m_lstRowS.Count; i++)
			{
				lstRMaxValueS.Add(m_lstRowS[i].GroupInfo.GroupKey, m_lstRowS[i].RecoveryInfo.Maximum);
			}
			itemRecoveryMax.Tag = lstRMaxValueS;
		}

		private void Clear()
		{
			exChart.Series.Clear();
		}

		private Series CreateSeries(string sName)
		{
			exChart.BeginInit();
			Series exSeries = new Series(sName, ViewType.Bar);
			SideBySideBarSeriesLabel exLabel = null;
			((System.ComponentModel.ISupportInitialize)(exSeries)).BeginInit();
			{
				exSeries.ArgumentScaleType = ScaleType.Auto;
				exSeries.ValueScaleType = ScaleType.Numerical;
				exLabel = new SideBySideBarSeriesLabel();
				exLabel.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.TopInside;
				exLabel.ShowForZeroValues = true;
				exSeries.Label = exLabel;
				exSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
			}
			((System.ComponentModel.ISupportInitialize)(exSeries)).EndInit();
			exChart.Series.Add(exSeries);
			exChart.EndInit();

			return exSeries;
		}

		private void CreateSeriesPoint(Series series, SortedList<string, double> lstValueS)
		{
			SeriesPoint exPoint = null;

			for (int i = 0; i < lstValueS.Count; i++)
			{
				exPoint = new SeriesPoint(lstValueS.Keys[i], new object[] { lstValueS.Values[i] });
				exPoint.ToolTipHint = "[" + lstValueS.Keys[i] + "] : " + lstValueS.Values[i];
				series.Points.Add(exPoint);
				exPoint.Tag = series.Points.IndexOf(exPoint);
			}
		}
		#endregion

		#region Event Methods

		private void FrmStatisticsChartViewer_Load(object sender, EventArgs e)
		{
			Clear();
			SetNavItemTag();
		}
		#endregion

		private void ucCheckNavBarControl1_CheckedChaged(object sender, NavBarStateEventsArgs e)
		{
			if (m_lstRowS == null)
				return;

			if(e.Link == null)
			{
				//Group Checked

				Series exSeries = null;
				if (e.State)
				{
					foreach (NavBarItemLink link in e.Group.ItemLinks)
					{
						string sName = "[" + link.Group.Caption + "]" + link.Item.Caption;
						SortedList<string, double> lstValueS = (SortedList<string, double>)link.Item.Tag;
						if (exChart.GetSeriesByName(sName) == null)
						{
							exSeries = CreateSeries(sName);
							CreateSeriesPoint(exSeries, lstValueS);
						}

						link.Item.Hint = "";
					}
				}
				else
				{
					foreach (NavBarItemLink link in e.Group.ItemLinks)
					{
						string sName = "[" + link.Group.Caption + "]" + link.Item.Caption;
						exSeries = exChart.GetSeriesByName(sName);
						exChart.Series.Remove(exSeries);
						exChart.RefreshData();

						link.Item.Hint = "0";
					}
				}
				ucCheckNavBarControl1.GroupChecekdChange(e.Group.ItemLinks);
				ucCheckNavBarControl1.Refresh();
			}
			else
			{
				//item Checked
				int itemCount = 0;
				Series exSeries = null;
				string sName = "[" + e.Link.Group.Caption + "]" + e.Link.Item.Caption;
				SortedList<string, double> lstValueS = (SortedList<string, double>)e.Link.Item.Tag;

				if (e.State)
				{
					e.Link.Item.Hint = "0";
					if (exChart.GetSeriesByName(sName) == null)
					{
						exSeries = CreateSeries(sName);
						CreateSeriesPoint(exSeries, lstValueS);
					}
				}
				else
				{
					e.Link.Item.Hint = "";
					exSeries = exChart.GetSeriesByName(sName);
					exChart.Series.Remove(exSeries);
					exChart.RefreshData();
				}

				foreach (NavBarItemLink link in e.Link.Group.ItemLinks)
				{
					if (link.Item.Hint != "")
					{
						itemCount++;
					}
				}

				if (itemCount == e.Link.Group.ItemLinks.Count)
					e.Link.Group.Tag = null;
				else
					e.Link.Group.Tag = itemCount;

				ucCheckNavBarControl1.ItemChecekdChange(e.Link.Group);
				ucCheckNavBarControl1.Refresh();
			}
		}

	}
}