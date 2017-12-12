using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Log;
using UDM.UI.TimeChart;

namespace UDMPresenter
{
	public partial class FrmTimeChartViewer : DevExpress.XtraEditors.XtraForm
	{

		#region Member Variables

		private CTagS m_cTagS = null;
        private List<CStepTagList> m_lstStepTagList = null;
		private CTimeLogS m_cLogS = null;
        private List<string> m_lstShowTagKey = new List<string>();

		#endregion


		#region Initialize/Dispose

		public FrmTimeChartViewer()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public CTagS TagS
		{
            set { m_cTagS = value; }
		}

		public CTimeLogS TimeLogS
		{
			get { return m_cLogS; }
			set { m_cLogS = value; }
		}

        public List<CStepTagList> StepTagList
        {
            set { m_lstStepTagList = value; }
        }

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		private void InitTimeRange()
		{
			if (m_cLogS == null || m_cLogS.Count == 0)
				return;

			int iLastIndex = m_cLogS.Count - 1;

			DateTime dtFrom = (DateTime)m_cLogS[0].Time;
			DateTime dtTo = (DateTime)m_cLogS[iLastIndex].Time;

			if(dtTo.Subtract(dtFrom).TotalMinutes > 30)
			{
				dtpkTo.EditValue = (DateTime)dtTo;
				dtpkFrom.EditValue = (DateTime)dtTo.AddMinutes(-30);
			}
			else
			{
				dtpkTo.EditValue = (DateTime)dtTo;
				dtpkFrom.EditValue = (DateTime)dtFrom;
			}
		}

		private void InitTimeChart()
		{
			ucTimeChart.BeginUpdate();
			{
				CColumnItem colGAddress = new CColumnItem("colGAddress", "Address");
				CColumnItem colGDescription = new CColumnItem("colGDescription", "Description");
				colGAddress.IsReadOnly = true;
				colGDescription.IsReadOnly = true;

				ucTimeChart.GanttTree.ColumnS.Add(colGAddress);
				ucTimeChart.GanttTree.ColumnS.Add(colGDescription);

				DevExpress.XtraEditors.Repository.RepositoryItemColorEdit exColorEditor = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
				CColumnItem colSAddress = new CColumnItem("colSAddress", "Address");
				CColumnItem colSDescription = new CColumnItem("colSDescription", "Description");
				CColumnItem colSScale = new CColumnItem("colSScale", "Scale");
				CColumnItem colSColor = new CColumnItem("colSColor", "Color");
				colSAddress.IsReadOnly = true;
				colSAddress.IsReadOnly = true;
				colSScale.IsReadOnly = false;
				colSColor.IsReadOnly = false;
				colSColor.Editor = exColorEditor;

				ucTimeChart.SeriesTree.ColumnS.Add(colSAddress);
				ucTimeChart.SeriesTree.ColumnS.Add(colSDescription);
				ucTimeChart.SeriesTree.ColumnS.Add(colSScale);
				ucTimeChart.SeriesTree.ColumnS.Add(colSColor);
			}
			ucTimeChart.EndUpdate();
		}

		private void RegisterTimeChartEventS()
		{
			ucTimeChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucTimeChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
			ucTimeChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucTimeChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucTimeChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
            
		}


		private void ShowChart(List<CTag> lstTag, CTimeLogS cLogS, DateTime dtFrom, DateTime dtTo)
		{
			ucTimeChart.BeginUpdate();
			{
				CGanttItem cItem = null;
				List<CGanttBar> lstBar = null;
				CTag cTag;
				CTimeNodeS cNodeS = null;

				for (int i = 0; i < lstTag.Count; i++)
				{
					cTag = lstTag[i];
                    if (cTag.LogCount == 0) continue;
                    if (m_lstShowTagKey.Contains(cTag.Key)) continue;
                    else
                        m_lstShowTagKey.Add(cTag.Key);
					
                    cItem = CreateGanttItem(cTag);
					if (cLogS != null)
					{
						cNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
						if (cNodeS == null)
							cNodeS = new CTimeNodeS();
                        
					}
					else
						cNodeS = new CTimeNodeS();
                    bool bShowBarText = false;
                    if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord) bShowBarText = true;
                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    ucTimeChart.GanttTree.ItemS.Add(cItem);

                    lstBar.Clear();
                    lstBar = null;
				}
                
                ucTimeChart.TimeLine.RangeFrom = dtFrom;
				ucTimeChart.TimeLine.RangeTo = dtTo;
				ucTimeChart.TimeLine.FirstVisibleTime = dtFrom;
			}
			ucTimeChart.EndUpdate();
		}

        private void ShowChart(List<CStepTagList> lstStepList, CTimeLogS cLogS, DateTime dtFrom, DateTime dtTo)
        {
            CGanttItem cItem = null;
            List<CGanttBar> lstBar = null;
            CTimeNodeS cNodeS = null;
            ucTimeChart.BeginUpdate();
            {
                for (int i = 0; i < lstStepList.Count; i++)
                {
                    CTag cCoilTag = lstStepList[i].CoilTag;
                    //if (cCoilTag.LogCount == 0) continue;

                    cItem = CreateGanttItem(cCoilTag);
                    if (cLogS != null)
                    {
                        cNodeS = new CTimeNodeS(cCoilTag, cLogS, dtFrom, dtTo);
                        if (cNodeS == null)
                            continue;
                    }
                    else
                        continue;


                    ucTimeChart.GanttTree.ItemS.Add(cItem);

                    bool bShowBarText = false;
                    if (cCoilTag.DataType == EMDataType.Word || cCoilTag.DataType == EMDataType.DWord) bShowBarText = true;
                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    for (int k = 0; k < lstStepList[i].ContactTagList.Count; k++)
                    {
                        CTag cContentTag = lstStepList[i].ContactTagList[k];
                        CGanttItem cSubItem = CreateGanttItem(cContentTag);
                        CTimeNodeS cSubNodeS = null;
                        List<CGanttBar> lstSubBar = null;
                        if (cLogS != null)
                        {
                            cSubNodeS = new CTimeNodeS(cContentTag, cLogS, dtFrom, dtTo);
                            if (cSubNodeS == null)
                                cSubNodeS = new CTimeNodeS();
                        }
                        else
                            cSubNodeS = new CTimeNodeS();

                        if (cContentTag.DataType == EMDataType.Word || cContentTag.DataType == EMDataType.DWord) bShowBarText = true;
                        lstSubBar = CreateBarList(cSubNodeS, Color.DodgerBlue, bShowBarText);
                        cSubItem.BarS.AddRange(lstSubBar);
                        cItem.ItemS.Add(cSubItem);
                        lstSubBar.Clear();
                        lstSubBar = null;
                    }

                    lstBar.Clear();
                    lstBar = null;
                    ucTimeChart.TimeLine.RangeFrom = dtFrom;
                    ucTimeChart.TimeLine.RangeTo = dtTo;
                    ucTimeChart.TimeLine.FirstVisibleTime = dtFrom;
                }
                ucTimeChart.EndUpdate();
            }

        }

        private bool ShowSubItemChart(CGanttItem cBaseItem, CStepTagList cSelectStep, CTimeLogS cLogS, DateTime dtFrom, DateTime dtTo)
        {
            ucTimeChart.BeginUpdate();
            {
                bool bShowBarText = false;

                for (int k = 0; k < cSelectStep.ContactTagList.Count; k++)
                {
                    CTag cContentTag = cSelectStep.ContactTagList[k];
                    CGanttItem cSubItem = CreateGanttItem(cContentTag);
                    CTimeNodeS cSubNodeS = null;
                    List<CGanttBar> lstSubBar = null;
                    if (cLogS != null)
                    {
                        cSubNodeS = new CTimeNodeS(cContentTag, cLogS, dtFrom, dtTo);
                        if (cSubNodeS == null)
                            cSubNodeS = new CTimeNodeS();
                    }
                    else
                        cSubNodeS = new CTimeNodeS();

                    if (cContentTag.DataType == EMDataType.Word || cContentTag.DataType == EMDataType.DWord) bShowBarText = true;
                    lstSubBar = CreateBarList(cSubNodeS, Color.DodgerBlue, bShowBarText);
                    cSubItem.BarS.AddRange(lstSubBar);

                    cBaseItem.ItemS.Add(cSubItem);
                    lstSubBar.Clear();
                    lstSubBar = null;
                }
                
            ucTimeChart.EndUpdate();
            }
            return true;
        }

        private bool SetLogCount()
        {
            if (m_cLogS == null || m_cLogS.Count == 0)
            {
                MessageBox.Show("Please Import Log First!!", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (m_cTagS == null || m_cTagS.Count == 0)
            {
                MessageBox.Show("Tag가 없습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;
            List<string> lstSameKey = new List<string>();
            List<string> lstNotFoundKey = new List<string>();
            foreach (var who in m_cLogS)
            {
                if(lstSameKey.Contains(who.Key) == false)
                {
                    if (m_cTagS.ContainsKey(who.Key))
                    {
                        CTimeLogS cLogS = m_cLogS.GetTimeLogS(who.Key, dtFrom, dtTo);
                        m_cTagS[who.Key].LogCount = cLogS.Count;
                    }
                    else
                    {
                        lstNotFoundKey.Add(who.Key);
                    }
                    lstSameKey.Add(who.Key);
                }
                
            }
            if (lstNotFoundKey.Count > 0)
            {
                MessageBox.Show("Tag에서 찾지 못한 접점 = " + lstNotFoundKey.Count.ToString());
            }
            CProjectManager.UpdateView();
            return true;
        }

		private CGanttItem CreateGanttItem(CTag cTag)
		{
			CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
			cItem.Data = cTag;

			return cItem;
		}

        private CSeriesItem CreateRowItem(CTag cTag)
        {
            CSeriesItem cItem = new CSeriesItem(new object[] { cTag.Address, cTag.Description, 1, Color.Blue });
            cItem.Data = cTag;

            return cItem;
        }

		private List<CGanttBar> CreateBarList(CTimeNodeS cNodeS, Color cColor, bool bShowBarText)
		{
			List<CGanttBar> lstBar = new List<CGanttBar>();

			CGanttBar cBar;
			CTimeNode cNode;
			for (int i = 0; i < cNodeS.Count; i++)
			{
				cNode = cNodeS[i];
				cBar = CreateBar(cNode, cColor);
                if (bShowBarText)
                    cBar.Text = cNode.Value.ToString();
				lstBar.Add(cBar);
			}

			return lstBar;
		}

		private CGanttBar CreateBar(CTimeNode cNode, Color cColor)
		{
			CGanttBar cBar = new CGanttBar();
			cBar.StartTime = cNode.Start;
			cBar.EndTime = cNode.End;
			cBar.Data = cNode;
			cBar.Color = cColor;

			return cBar;
		}

		#endregion


		#region Event Methods

		private void FrmTimeChartViewer_Load(object sender, EventArgs e)
		{
			InitTimeRange();
			InitTimeChart();
            bool bOK = SetLogCount();
            if (bOK == false) this.Close();
            RegisterTimeChartEventS();
            ucTagTable.ShowTable(m_cTagS);
            ucTimeChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
            ucTimeChart.SeriesTree.ContextMenuStrip = cntxSeriesTreeMenu;

            grdCoilTagList.DataSource = m_lstStepTagList;
            grdCoilTagList.RefreshDataSource();
		}		

		private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (m_cTagS == null)
				return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            if (tabTable.SelectedTabPage == tpTagTable)
            {
                List<CTag> lstTag = ucTagTable.GetSelectedTagList();
                if (lstTag == null || lstTag.Count == 0)
                    return;

                ShowChart(lstTag, m_cLogS, dtFrom, dtTo);

                lstTag.Clear();
            }
            else
            {
                List<CStepTagList> lstSelectStep = new List<CStepTagList>();
                int[] iaRowIndex = grvCoilTagList.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    CStepTagList cStepTag;
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        cStepTag = (CStepTagList)grvCoilTagList.GetRow(iaRowIndex[i]);
                        if (cStepTag != null && cStepTag.CoilCollectUsed)
                            lstSelectStep.Add(cStepTag);
                    }
                }

                ShowChart(lstSelectStep, m_cLogS, dtFrom, dtTo);

                lstSelectStep.Clear();

            }

		}

		private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ucTimeChart.Clear();
            m_lstShowTagKey.Clear();
            dtpkIndicator1.EditValue = 0;
            dtpkIndicator2.EditValue = 0;
            txtInterval.Text = "0";
		}

		private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ucTimeChart.TimeLine.ZoomIn();
		}

		private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ucTimeChart.TimeLine.ZoomOut();
		}

		private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
			if (lstItem == null || lstItem.Count == 0)
				return;

			ucTimeChart.GanttTree.ItemUp(lstItem);
			lstItem.Clear();
		}

		private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
			if (lstItem == null || lstItem.Count == 0)
				return;

			ucTimeChart.GanttTree.ItemDown(lstItem);
			lstItem.Clear();
		}

        void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            txtWordValue.Text = "";
            txtWordValue.Text = cBar.Text;
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            ucTimeChart.TimeLine.TimeIndicatorS.Clear();
            ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
            ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

            dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
            dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

            TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
            txtInterval.Text = nInterval.ToString();

            ucTimeChart.TimeLine.UpdateLayout();
            
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucTimeChart.TimeLine.TimeIndicatorS.Count == 0) return;
            else if (ucTimeChart.TimeLine.TimeIndicatorS.Count == 1)
                dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
            else
            {
                dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

		private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			DateTime dtTime = ucTimeChart.TimeLine.CalcTime(e.X);

			if(ucTimeChart.TimeLine.TimeIndicatorS.Count > 1)
				ucTimeChart.TimeLine.TimeIndicatorS.RemoveAt(0);
			
			ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
			ucTimeChart.TimeLine.UpdateLayout();

			
			if (ucTimeChart.TimeLine.TimeIndicatorS.Count > 0)
				dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;

			if (ucTimeChart.TimeLine.TimeIndicatorS.Count > 1)
			{
				dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

				TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
				double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
				txtInterval.Text = nInterval.ToString();
			}
			else
			{
				txtInterval.Text = "0";
			}
		}

		private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cColumn, CRowItem cItem, object oValue)
		{
			if (cColumn.Caption == "Color")
			{
				CSeriesItem cSeries = (CSeriesItem)cItem;
				cSeries.Color = (Color)oValue;

				ucTimeChart.SeriesChart.UpdateLayout();
			}
			else if (cColumn.Caption == "Scale")
			{
				CSeriesItem cSeries = (CSeriesItem)cItem;
				float nValue = 0;
				bool bOK = float.TryParse(oValue.ToString(), out nValue);
				if (bOK)
				{
					cSeries.Scale = nValue;
					ucTimeChart.SeriesChart.UpdateLayout();
				}
			}
		}

        private void mnuShowSeriesChart_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucTimeChart.GanttTree.GetSelectedItemList();
            if (lstSelectItem == null || lstSelectItem.Count == 0)
                return;

            float fMax = ucTimeChart.SeriesChart.Axis.Maximum;
            float fMin = ucTimeChart.SeriesChart.Axis.Minimumn;

            foreach (CRowItem row in lstSelectItem)
            {
                CTag cTag = (CTag)row.Data;
                if (cTag.DataType == EMDataType.Bool) continue;

                DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
                DateTime dtTo = (DateTime)dtpkTo.EditValue;

                CSeriesItem cSeriesItem = CreateRowItem(cTag);
                CSeriesPoint cSeriesPoint = new CSeriesPoint();
                cSeriesPoint.Time = dtFrom;
                cSeriesPoint.Value = 0;
                cSeriesItem.PointS.Add(cSeriesPoint);

                CTimeLogS cItemLogS = m_cLogS.GetTimeLogS(cTag.Key, dtFrom, dtTo);

                bool bZeroData = false;
                bool bFirst = true;
                if (cItemLogS.Count > 0)
                {
                    foreach (CTimeLog cLog in cItemLogS)
                    {
                        if (bFirst)
                        {
                            cSeriesPoint = new CSeriesPoint();
                            cSeriesPoint.Time = cLog.Time;
                            cSeriesPoint.Value = 0;
                            cSeriesItem.PointS.Add(cSeriesPoint);
                            bFirst = false;
                        }
                        cSeriesPoint = new CSeriesPoint();
                        cSeriesPoint.Time = cLog.Time;
                        cSeriesPoint.Value = cLog.Value;
                        
                        if (cLog.Value > fMax) fMax = cLog.Value;
                        else if (cLog.Value < fMin) fMin = cLog.Value;
                        if (cLog.Value == 0 && bZeroData == false)
                            bZeroData = true;
                        else if(bZeroData)
                        {
                            bZeroData = false;
                            CSeriesPoint cSeriesZeroPoint = new CSeriesPoint();
                            cSeriesZeroPoint.Time = cLog.Time;
                            cSeriesZeroPoint.Value = 0;
                            cSeriesItem.PointS.Add(cSeriesZeroPoint);
                        }
                        cSeriesItem.PointS.Add(cSeriesPoint);
                    }
                    cSeriesItem.Color = Color.Blue;

                    ucTimeChart.SeriesChart.SeriesTree.ItemS.Add(cSeriesItem);
                }
            }

            ucTimeChart.SeriesChart.Axis.Maximum = fMax;
            ucTimeChart.SeriesChart.Axis.Minimumn = fMin;

            ucTimeChart.EndUpdate();
        }

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucTimeChart.GanttTree.GetSelectedItemList();
            foreach (CRowItem item in lstSelectItem)
            {
                CTag cTag = (CTag)item.Data;
                m_lstShowTagKey.Remove(cTag.Key);
                ucTimeChart.GanttTree.ItemS.Remove(item);
            }
        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucTimeChart.SeriesTree.GetSelectedItemList();
            
            foreach (CRowItem item in lstSelectItem)
                ucTimeChart.SeriesTree.ItemS.Remove(item);
            ucTimeChart.EndUpdate();
        }

        #endregion

        private void mnuItemSubDepthView_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucTimeChart.GanttTree.GetSelectedItemList();
            if (lstSelectItem.Count > 1 || lstSelectItem.Count == 0) return;
            if (lstSelectItem[0].ItemS != null && lstSelectItem[0].ItemS.Count > 0) return;

            CTag cTag = (CTag)lstSelectItem[0].Data;
            List<CStepTagList> clstStepTag = m_lstStepTagList.FindAll(x => x.CoilTag == cTag);

            CStepTagList cStepTag = null;

            if (clstStepTag == null || clstStepTag.Count == 0)
            {
                MessageBox.Show("하위 조건이 존재하지 않습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (clstStepTag.Count == 1)
                cStepTag = clstStepTag[0];
            else
            {
                FrmStepSelector frmSelector = new FrmStepSelector();
                frmSelector.StepList = clstStepTag;
                frmSelector.ShowDialog();

                cStepTag = frmSelector.SelectedStep;

                frmSelector.Dispose();
                frmSelector = null;
            }

            if (cStepTag == null) return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            ShowSubItemChart((CGanttItem)lstSelectItem[0], cStepTag, m_cLogS, dtFrom, dtTo);
        }

        private void grvCoilTagList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void btnStepAllView_Click(object sender, EventArgs e)
        {
            grvCoilTagList.SelectAll();
            btnShow_ItemClick(null, null);
        }

        private void btnTagAllView_Click(object sender, EventArgs e)
        {
            ucTagTable.SelectAll();
            btnShow_ItemClick(null, null);
        }

	}
}