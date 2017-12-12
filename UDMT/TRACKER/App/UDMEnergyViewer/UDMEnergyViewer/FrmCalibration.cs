using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.UI.TimeChart;

namespace UDMEnergyViewer
{
    public partial class FrmCalibration : DevExpress.XtraEditors.XtraForm
    {
        private CTagItemS m_cTagItemS = null;
        private CTagItemS m_cCoilTagItemS = new CTagItemS();
        private CMeterItemS m_cMeterItemS = null;
        bool m_bApplyCheck = false;

        #region Initialize/Dispose

        public FrmCalibration()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public CTagItemS TagItemS
        {
            get { return m_cTagItemS; }
            set { SetTagItemS(value); }
        }

        public CMeterItemS MeterItemS
        {
            get { return m_cMeterItemS; }
            set { SetMeterItemS(value); }
        }

        #endregion

        #region Private Methods

        private void InitChart()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucGanttChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucGanttChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesItem", "Item");
            cColumn.IsReadOnly = true;
            ucSeriesChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMin", "Min");
            cColumn.IsReadOnly = true;
            ucSeriesChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMax", "Max");
            cColumn.IsReadOnly = true;
            ucSeriesChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesColor", "Color");
            cColumn.IsReadOnly = false;
            cColumn.Editor = exEditorColor;
            ucSeriesChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesScale", "Scale");
            cColumn.IsReadOnly = false;
            ucSeriesChart.SeriesTree.ColumnS.Add(cColumn);
        }

        private void RegisterTimeChartEventS()
        {
            ucGanttChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucGanttChart.TimeLine.UEventTimeIndicatorMoved += GanttChart_TimeLine_UEventTimeIndicatorMoved;
            ucGanttChart.TimeLine.MouseDoubleClick += Gantt_TimeLine_MouseDoubleClick;
        }

        private void SetGanttTimeIndicator(DateTime dtFrom)
        {
            ucGanttChart.TimeLine.TimeIndicatorS.Clear();

            ucGanttChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtFrom, Color.Red));
            dtRefTime.EditValue = (DateTime)ucGanttChart.TimeLine.TimeIndicatorS[0].Time;

            ucGanttChart.TimeLine.UpdateLayout();
        }

        private void SetSeriesTimeIndicator(DateTime dtFrom)
        {
            ucSeriesChart.TimeLine.TimeIndicatorS.Clear();
            ucSeriesChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtFrom, Color.Red));
            dtCalibTime.EditValue = (DateTime)ucSeriesChart.TimeLine.TimeIndicatorS[0].Time;

            ucSeriesChart.TimeLine.UpdateLayout();

            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }

        private void SetTagItemS(CTagItemS cItemS)
        {
            m_cTagItemS = cItemS;

            //foreach (CTag cTag in CProjectManager.Project.StepCoilList)
            //{
            //    if(!m_cCoilTagItemS.ContainsKey(cTag.Key))
            //        m_cCoilTagItemS.Add(cTag.Key, m_cTagItemS[cTag.Key]);
            //}

            gcTagTable.DataSource = m_cTagItemS.Values.ToList();
            gcTagTable.RefreshDataSource();

            //CProjectManager.Project.CoilTagItemS = m_cCoilTagItemS;
        }

        private void SetMeterItemS(CMeterItemS cItemS)
        {
            m_cMeterItemS = cItemS;

            List<CMeterUnit> lstUnit = new List<CMeterUnit>();
            CMeterItem cItem;
            for (int i = 0; i < m_cMeterItemS.Count; i++)
            {
                cItem = m_cMeterItemS.ElementAt(i).Value;
                lstUnit.AddRange(cItem);
            }

            gcMeterTable.DataSource = lstUnit;
            gcMeterTable.RefreshDataSource();
        }

        private void ShowGantt(List<CTagItem> lstItem, DateTime dtFrom, DateTime dtTo)
        {
            ucGanttChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                CTagItem cTagItem;
                CTimeNodeS cNodeS;
                CTimeNode cNode;
                CGanttBar cBar;
                for (int i = 0; i < lstItem.Count; i++)
                {
                    cTagItem = lstItem[i];

                    cItem = new CGanttItem(new object[] { cTagItem.Address, cTagItem.Description });
                    cNodeS = new CTimeNodeS(cTagItem.Tag, cTagItem.LogS, dtFrom, dtTo);
                    for (int j = 0; j < cNodeS.Count; j++)
                    {
                        cNode = cNodeS[j];
                        cBar = new CGanttBar();
                        cBar.StartTime = cNode.Start;
                        cBar.EndTime = cNode.End;
                        cItem.BarS.Add(cBar);
                    }
                    ucGanttChart.GanttTree.ItemS.Add(cItem);
                    cNodeS.Clear();
                }

                ucGanttChart.TimeLine.RangeFrom = dtFrom;
                ucGanttChart.TimeLine.RangeTo = dtTo;
                ucGanttChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucGanttChart.EndUpdate();
        }

        private void ShowMeter(List<CMeterUnit> lstUnit, DateTime dtFrom, DateTime dtTo)
        {
            ucSeriesTree.BeginUpdate();
            {
                CSeriesItem cItem;
                CMeterUnit cUnit;
                CTimeLogS cLogS;
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                for (int i = 0; i < lstUnit.Count; i++)
                {
                    cUnit = lstUnit[i];
                    nMax = -1;
                    nMin = -1;

                    cItem = new CSeriesItem(null);
                    cLogS = cUnit.LogS.GetTimeLogS(dtFrom, dtTo);

                    cItem.Color = cUnit.Color;
                    for (int j = 0; j < cLogS.Count; j++)
                    {
                        cLog = cLogS[j];
                        if (j == 0)
                        {
                            nMin = cLog.FValue;
                            nMax = cLog.FValue;
                        }
                        else if (cLog.FValue > nMax)
                        {
                            nMax = cLog.FValue;
                        }
                        else if (nMin > cLog.FValue)
                        {
                            nMin = cLog.FValue;
                        }

                        cPoint = new CSeriesPoint(cLog.Time, cLog.FValue);
                        cPoint.Data = cLog.FValue;
                        cItem.PointS.Add(cPoint);
                    }
                    cItem.Values = new object[] { cUnit.Key, nMin, nMax, cUnit.Color, 1f };

                    ucSeriesChart.SeriesTree.ItemS.Add(cItem);

                    cLogS.Clear();
                }
                ucSeriesChart.Axis.Maximum = nMax;
                ucSeriesChart.Axis.Minimumn = nMin;

                ucSeriesChart.TimeLine.RangeFrom = dtFrom;
                ucSeriesChart.TimeLine.RangeTo = dtTo;
                ucSeriesChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucSeriesTree.EndUpdate();
        }

        private List<CMeterUnit> GetCheckedUnitItem()
        {
            List<CMeterUnit> lstTotalItem = (List<CMeterUnit>)gcMeterTable.DataSource;
            if (lstTotalItem == null)
                return null;

            List<CMeterUnit> lstItem = new List<CMeterUnit>();
            CMeterUnit cItem;
            for (int i = 0; i < lstTotalItem.Count; i++)
            {
                cItem = lstTotalItem[i];
                if (cItem.IsVisible)
                    lstItem.Add(cItem);
            }

            return lstItem;
        }

        private void Apply()
        {
            if (txtTimeSpan.EditValue == null)
                return;

            double dCalibrationValue = double.Parse(txtTimeSpan.EditValue.ToString());

            foreach (CTagItem cItem in CProjectManager.Project.TagItemS.Values)
            {
                foreach (CTimeLog cLog in cItem.LogS)
                    cLog.Time = cLog.Time.AddMilliseconds(dCalibrationValue);
            }
            CProjectManager.Project.TagItemS.UpdateTimeRange();

            MessageBox.Show("Apply Success!", "Calibration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            m_bApplyCheck = true;
        }


        #endregion

        private void FrmCalibration_Load(object sender, EventArgs e)
        {
            InitChart();
            RegisterTimeChartEventS();

            ucGanttChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
            ucSeriesChart.SeriesTree.ContextMenuStrip = cntxSeriesTreeMenu;
        }

        private void btnMeterShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtFrom = m_cTagItemS.FirstTime;
            DateTime dtTo = m_cTagItemS.LastTime;

            ucGanttChart.GanttTree.ItemS.Clear();
            ucSeriesChart.SeriesTree.ItemS.Clear();

            List<CTagItem> lstAllTagItem = (List<CTagItem>)gcTagTable.DataSource;

            if (lstAllTagItem != null && lstAllTagItem.Count > 0)
            {
                ShowGantt(lstAllTagItem, dtFrom, dtTo);
                SetGanttTimeIndicator(dtFrom);
            }

            dtFrom = m_cMeterItemS.FirstTime;
            dtTo = m_cMeterItemS.LastTime;

            List<CMeterUnit> lstUnitItem = GetCheckedUnitItem();
            if (lstUnitItem != null && lstUnitItem.Count > 0)
            {
                ShowMeter(lstUnitItem, dtFrom, dtTo);
                SetSeriesTimeIndicator(dtFrom);
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucGanttChart.GanttTree.ItemS.Clear();
            ucSeriesChart.SeriesTree.ItemS.Clear();
        }

        private void btnApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                Apply();
            }
            SplashScreenManager.CloseForm();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!m_bApplyCheck)
            {
                if (MessageBox.Show("Calibration을 적용하지 않았습니다.\n 정말로 끝내시겠습니까?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void gvTagTable_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsTagShow)
            {
                CTagItem cTagItem = (CTagItem)gvTagTable.GetRow(e.RowHandle);
                if (cTagItem == null)
                    return;

                cTagItem.IsVisible = !cTagItem.IsVisible;
            }
        }

        private void gvMeterTable_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colIsMeterShow)
            {
                CMeterUnit cUnit = (CMeterUnit)gvMeterTable.GetRow(e.RowHandle);
                if (cUnit == null)
                    return;

                cUnit.IsVisible = !cUnit.IsVisible;
            }
        }

        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            if (cCol.Name == "colSeriesScale")
            {
                float nScale = 1f;
                bool bOK = float.TryParse(oValue.ToString(), out nScale);
                CSeriesItem cItem = (CSeriesItem)cRow;
                CSeriesPoint cPoint;
                for (int i = 0; i < cItem.PointS.Count; i++)
                {
                    cPoint = cItem.PointS[i];
                    cPoint.Value = (float)cPoint.Data * nScale;
                }

                ucSeriesChart.SeriesTree.UpdateLayout();
            }
            else if (cCol.Name == "colSeriesColor")
            {
                CSeriesItem cItem = (CSeriesItem)cRow;

                cItem.Color = (Color)oValue;
                ucSeriesChart.SeriesTree.UpdateLayout();
            }
        }

        private void GanttChart_TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucGanttChart.TimeLine.TimeIndicatorS.Count == 0) return;
             
            dtRefTime.EditValue = (DateTime)ucGanttChart.TimeLine.TimeIndicatorS[0].Time;
            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }

        private void SeriesChart_TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucGanttChart.TimeLine.TimeIndicatorS.Count == 0) return;

            dtRefTime.EditValue = (DateTime)ucGanttChart.TimeLine.TimeIndicatorS[0].Time;
            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }

        private void Gantt_TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucGanttChart.TimeLine.CalcTime(e.X);

            ucGanttChart.TimeLine.TimeIndicatorS.Clear();

            ucGanttChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucGanttChart.TimeLine.UpdateLayout();

            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }

        private void Series_TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucSeriesChart.TimeLine.CalcTime(e.X);

            ucSeriesChart.TimeLine.TimeIndicatorS.Clear();

            ucSeriesChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucSeriesChart.TimeLine.UpdateLayout();

            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucGanttChart.GanttTree.GetSelectedItemList();
            foreach (CRowItem item in lstSelectItem)
                ucGanttChart.GanttTree.ItemS.Remove(item);
            ucGanttChart.EndUpdate();
        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucSeriesChart.SeriesTree.GetSelectedItemList();

            foreach (CRowItem item in lstSelectItem)
                ucSeriesChart.SeriesTree.ItemS.Remove(item);
            ucSeriesChart.SeriesTree.EndUpdate();
            ucSeriesChart.EndUpdate();
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar)
        {
            ucGanttChart.TimeLine.TimeIndicatorS.Clear();
            ucGanttChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
            ucGanttChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));
            ucGanttChart.TimeLine.UpdateLayout();

            TimeSpan tsSpan = ucSeriesChart.TimeLine.TimeIndicatorS[0].Time.Subtract(ucGanttChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = tsSpan.TotalMilliseconds;
            txtTimeSpan.EditValue = nInterval.ToString();
        }
    }
}