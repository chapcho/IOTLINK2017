using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.UI.TimeChart;

namespace UDMEnergyViewer
{
    public partial class FrmChartViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private CTagItemS m_cTagItemS = null;
        private CMeterItemS m_cMeterItemS = null;
        //private CTagItemS m_cCoilTagItemS = null;
        private Dictionary<string, CTagItemS> m_DicUnitTagItemS = null;

        #endregion


        #region Initialize/Dispose

        public FrmChartViewer()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CTagItemS TagItemS
        {
            get { return m_cTagItemS; }
            set { SetTagItemS(value); }
        }

        //public CTagItemS CoilTagItemS
        //{
        //    get { return m_cCoilTagItemS; }
        //    set { SetCoilTagItemS(value); }
        //}

        public CMeterItemS MeterItemS
        {
            get { return m_cMeterItemS; }
            set { SetMeterItemS(value); }
        }

        #endregion


        #region Public Methods



        #endregion


        #region Private Methods

        private void InitChart()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colGanttDescription", "Description");
            cColumn.IsReadOnly = true;
            ucChart.GanttTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesItem", "Item");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMin", "Min");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesMax", "Max");
            cColumn.IsReadOnly = true;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesColor", "Color");
            cColumn.IsReadOnly = false;
            cColumn.Editor = exEditorColor;
            ucChart.SeriesTree.ColumnS.Add(cColumn);

            cColumn = new CColumnItem("colSeriesScale", "Scale");
            cColumn.IsReadOnly = false;
            ucChart.SeriesTree.ColumnS.Add(cColumn);
        }

        private void InitTimeRange()
        {
            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;
            if (m_cTagItemS != null && m_cTagItemS.FirstTime != DateTime.MinValue)
            {
                dtFrom = m_cTagItemS.FirstTime;
                dtTo = m_cTagItemS.LastTime;
            }

            if(m_cMeterItemS != null && m_cMeterItemS.FirstTime != DateTime.MinValue )
            {
                if(dtFrom == DateTime.MinValue)
                {
                    dtFrom = m_cMeterItemS.FirstTime;
                    dtTo = m_cMeterItemS.LastTime;
                }
            }

            if (dtFrom != DateTime.MinValue)
                dtFrom = dtFrom.AddMinutes(-1);

            dtpkFrom.EditValue = dtFrom;
            dtpkTo.EditValue = dtTo;
        }

        private void InitDisaggregation()
        {
            if (m_cMeterItemS.Count != 0)
            {
                RepositoryItemComboBox exEditorDisaggregation = (RepositoryItemComboBox)cboDisaggregation.Edit;
                exEditorDisaggregation.Items.AddRange(m_cMeterItemS.Keys);
            }

            m_DicUnitTagItemS = CProjectManager.Project.UnitTagItemS;
        }

        private void RegisterTimeChartEventS()
        {
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
            ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;

        }

        //private void SetCoilTagItemS(CTagItemS cCoilItemS)
        //{
        //    if (cCoilItemS.Count == 0)
        //        return;

        //    m_cCoilTagItemS = cCoilItemS;

        //    gcTagTable.DataSource = m_cCoilTagItemS.Values.ToList();
        //    gcTagTable.RefreshDataSource();
        //}

        private void SetTagItemS(CTagItemS cItemS)
        {
            m_cTagItemS = cItemS;

            gcTagTable.DataSource = m_cTagItemS.Values.ToList();
            gcTagTable.RefreshDataSource();
        }

        private void SetMeterItemS(CMeterItemS cItemS)
        {
            m_cMeterItemS = cItemS;

            List<CMeterUnit> lstUnit = new List<CMeterUnit>();
            CMeterItem cItem;
            for (int i = 0; i < m_cMeterItemS.Count;i++ )
            {
                cItem = m_cMeterItemS.ElementAt(i).Value;
                lstUnit.AddRange(cItem);
            }

            gcMeterTable.DataSource = lstUnit;
            gcMeterTable.RefreshDataSource();
        }

        private void SetMeterItem(CMeterItem cItem)
        {
            gcMeterTable.DataSource = cItem;
            gcMeterTable.RefreshDataSource();          
        }

        private CMeterUnit GetMeterUnit(string sUnitKey)
        {
            CMeterUnit cMeterUnit = null;
            List<CMeterUnit> lstMeterUnit = (List<CMeterUnit>)gvMeterTable.DataSource;

            foreach(CMeterUnit cUnit in lstMeterUnit)
            {
                if(cUnit.Key == sUnitKey)
                {
                    cMeterUnit = cUnit;
                    break;
                }
            }
            return cMeterUnit;
        }

        private void ShowGantt(List<CTagItem> lstItem, DateTime dtFrom, DateTime dtTo)
        {
            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                CTagItem cTagItem;
                CTimeNodeS cNodeS;
                CTimeNode cNode;
                CGanttBar cBar;
                for(int i=0;i<lstItem.Count;i++)
                {
                    cTagItem = lstItem[i];

                    cItem = new CGanttItem(new object[] { cTagItem.Address, cTagItem.Description });
                    cItem.Data = cTagItem;

                    cNodeS = new CTimeNodeS(cTagItem.Tag, cTagItem.LogS, dtFrom, dtTo);
                    for(int j=0;j<cNodeS.Count;j++)
                    {
                        cNode = cNodeS[j];
                        cBar = new CGanttBar();
                        cBar.StartTime = cNode.Start;
                        cBar.EndTime = cNode.End;
                        cItem.BarS.Add(cBar);
                    }
                    ucChart.GanttTree.ItemS.Add(cItem);
                    cNodeS.Clear();
                }

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;
                ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShwGanttRelatedTag(List<string> lstTagKey, DateTime dtFrom, DateTime dtTo)
        {
            List<CTagItem> lstSelectedTagItem = new List<CTagItem>();

            foreach(string sKey in lstTagKey)
            {
                //if(m_cCoilTagItemS.ContainsKey(sKey))
                //    lstSelectedTagItem.Add(m_cCoilTagItemS[sKey]);
                if(m_cTagItemS.ContainsKey(sKey))
                    lstSelectedTagItem.Add(m_cTagItemS[sKey]);
            }

            ucChart.GanttTree.ItemS.Clear();
            ShowGantt(lstSelectedTagItem, dtFrom, dtTo);
        }

        private void ShowMeter(List<CMeterUnit> lstUnit, DateTime dtFrom, DateTime dtTo)
        {
            ucChart.BeginUpdate();
            {
                CSeriesItem cItem;
                CMeterUnit cUnit;
                CTimeLogS cLogS;
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nAxisMax = 0f;
                float nAxisMin = 0f;
                float nMax = 0f;
                float nMin = 0f;
                for (int i = 0; i < lstUnit.Count; i++)
                {
                    cUnit = lstUnit[i];
                    nMax = -1;
                    nMax = -1;

                    cItem = new CSeriesItem(null);
                    cLogS = cUnit.LogS.GetTimeLogS(dtFrom, dtTo);
                    
                    cItem.Color = cUnit.Color;
                    for(int j=0;j<cLogS.Count;j++)
                    {
                        cLog = cLogS[j];

                        if(j==0)
                        {
                            nMax = cLog.FValue;
                            nMin = cLog.FValue;
                        }
                        else if(cLog.FValue > nMax)
                        {
                            nMax = cLog.FValue;
                        }
                        else if(nMin > cLog.FValue)
                        {
                            nMin = cLog.FValue;
                        }

                        if (cLog.FValue > nAxisMax)
                            nAxisMax = cLog.FValue;
                        else if (cLog.FValue < nAxisMin)
                            nAxisMin = cLog.FValue;

                        cPoint = new CSeriesPoint(cLog.Time, cLog.FValue);
                        cPoint.Data = cLog.FValue;
                        cItem.PointS.Add(cPoint);
                    }
                    cItem.Values = new object[] { cUnit.Key, nMin, nMax, cUnit.Color, 1f };

                    ucChart.SeriesTree.ItemS.Add(cItem);

                    cLogS.Clear();
                }
                ucChart.SeriesChart.Axis.Maximum = nAxisMax;
                ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

                spnAxisMin.EditValue = nAxisMin;
                spnAxisMax.EditValue = nAxisMax;

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;
                ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private List<CTagItem> GetCheckedTagItem()
        {
            List<CTagItem> lstTotalItem = (List<CTagItem>)gcTagTable.DataSource;
            if (lstTotalItem == null)
                return null;

            List<CTagItem> lstItem = new List<CTagItem>();
            CTagItem cItem;
            for (int i = 0; i < lstTotalItem.Count; i++)
            {
                cItem = lstTotalItem[i];
                if (cItem.IsVisible)
                    lstItem.Add(cItem);
            }

            return lstItem;
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

        private void Clear()
        {
            ucChart.Clear();
        }

        #endregion


        #region Event Methods

        private void FrmChartViewer_Load(object sender, EventArgs e)
        {
            InitChart();
            InitTimeRange();
            RegisterTimeChartEventS();
            InitDisaggregation();

            ucChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
            ucChart.SeriesTree.ContextMenuStrip = cntxSeriesTreeMenu;
        }

        private void dtpkFrom_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpkTo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            if (dtFrom >= dtTo)
                dtTo = dtFrom.AddMinutes(1);

            ucChart.TimeLine.BeginUpdate();
            {
                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;
            }
            ucChart.TimeLine.EndUpdate();
            ucChart.TimeLine.Refresh();

            Clear();

            btnAllTagShow_Click(sender, e);

            List<CMeterUnit> lstUnitItem = GetCheckedUnitItem();
            if (lstUnitItem != null && lstUnitItem.Count > 0)
            {
                ShowMeter(lstUnitItem, dtFrom, dtTo);
                //lstUnitItem.Clear();
            }
        }

        private void btnAllTagShow_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            if (dtFrom >= dtTo)
                dtTo = dtFrom.AddMinutes(1);

            ucChart.TimeLine.BeginUpdate();
            {
                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;
            }
            ucChart.TimeLine.EndUpdate();
            ucChart.TimeLine.Refresh();

            ucChart.GanttTree.ItemS.Clear();

            List<CTagItem> lstTagItem = (List<CTagItem>)gcTagTable.DataSource;
            if (lstTagItem != null && lstTagItem.Count > 0)
            {
                ShowGantt(lstTagItem, dtFrom, dtTo);
            }
        }

        private void btnSelectedMeterShow_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = m_cMeterItemS.FirstTime;
            DateTime dtTo = m_cMeterItemS.LastTime;

            ucChart.SeriesTree.ItemS.Clear();

            List<CMeterUnit> lstUnitItem = GetCheckedUnitItem();
            if (lstUnitItem != null && lstUnitItem.Count > 0)
            {
                ShowMeter(lstUnitItem, dtFrom, dtTo);
                //lstUnitItem.Clear();
            }
        } 
       
        private void grvTagTable_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvMeterTable_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucChart.TimeLine.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucChart.TimeLine.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void btnAxisApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucChart.SeriesChart.BeginUpdate();
            {
                string sMin = spnAxisMin.EditValue.ToString();
                string sMax = spnAxisMax.EditValue.ToString();
                double nMin = double.Parse(sMin);
                double nMax = double.Parse(sMax);

                ucChart.SeriesChart.Axis.Minimumn = (float)(nMin);
                ucChart.SeriesChart.Axis.Maximum = (float)(nMax);
            }
            ucChart.SeriesChart.EndUpdate();
            ucChart.SeriesTree.UpdateLayout();
        }
     
        private void cboDisaggregation_EditValueChanged(object sender, EventArgs e)
        {
            Clear();

            string sUnit = cboDisaggregation.EditValue.ToString();
            CTagItemS cUnitTagItemS = m_DicUnitTagItemS[sUnit];
            CMeterItem cUnitMeterItem = m_cMeterItemS[sUnit];

            //SetCoilTagItemS(cUnitTagItemS);
            SetTagItemS(cUnitTagItemS);
            SetMeterItem(cUnitMeterItem);            
        }

        private void btnAllTagViewer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();

            gcTagTable.DataSource = m_cTagItemS.Values.ToList();
            gcTagTable.RefreshDataSource();

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

        private void btnAnalysis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucChart.SeriesTree.ItemS.Count == 1)
            {
                MessageBox.Show("Disaggregate Energy Item First!!", "Analysis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstSelectItem == null || lstSelectItem.Count == 0)
                return;

            FrmAnalysis frmAnalysis = new FrmAnalysis();

            foreach (CRowItem row in lstSelectItem) //우선은 하나만 클릭했다고 가정
                frmAnalysis.Tag = (CTag)row.Data;

            string sEnergyItem = cboDisaggregation.EditValue.ToString();
            //CTimeLogS cLogS = m_cMeterItemS[sEnergyItem][0].LogS.GetTimeLogS()
        }

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar)
        {
            txtWordValue.Text = "";
            txtWordValue.Text = cBar.Text;
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar)
        {
            ucChart.TimeLine.TimeIndicatorS.Clear();
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

            dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

            TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
            txtInterval.Text = nInterval.ToString();

            ucChart.TimeLine.UpdateLayout();
        }

        private void SeriesTree_UEventCellValueChagned(object sender, CColumnItem cCol, CRowItem cRow, object oValue)
        {
            if(cCol.Name == "colSeriesScale")
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

                ucChart.SeriesTree.UpdateLayout();
            }
            else if(cCol.Name == "colSeriesColor")
            {
                CSeriesItem cItem = (CSeriesItem)cRow;

                cItem.Color = (Color)oValue;
                ucChart.SeriesTree.UpdateLayout();
            }
        }

        private void SeriesChart_UEventPointClicked(object sender, CSeriesPoint cPoint)
        {
            float fPointValue = (float)cPoint.Data;
            DateTime dtTime = cPoint.Time;

            txtPointValue.EditValue = fPointValue;
            dtSeriesPointTime.EditValue = dtTime;
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucChart.TimeLine.TimeIndicatorS.Count == 0) return;
            else if (ucChart.TimeLine.TimeIndicatorS.Count == 1)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
            else
            {
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);

            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucChart.TimeLine.UpdateLayout();


            if (ucChart.TimeLine.TimeIndicatorS.Count > 0)
                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
            {
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
            else
            {
                txtInterval.Text = "0";
            }
        }

        #endregion

        private void gvTagTable_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column == colIsTagShow)
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

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            foreach (CRowItem item in lstSelectItem)
                ucChart.GanttTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.SeriesTree.GetSelectedItemList();

            foreach (CRowItem item in lstSelectItem)
                ucChart.SeriesTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        private void btnCoilView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Clear();

            //gcTagTable.DataSource = m_cCoilTagItemS.Values.ToList();
            //gcTagTable.RefreshDataSource();

            //List<CMeterUnit> lstUnit = new List<CMeterUnit>();
            //CMeterItem cItem;
            //for (int i = 0; i < m_cMeterItemS.Count; i++)
            //{
            //    cItem = m_cMeterItemS.ElementAt(i).Value;
            //    lstUnit.AddRange(cItem);
            //}

            //gcMeterTable.DataSource = lstUnit;
            //gcMeterTable.RefreshDataSource();
        }

        private void munRelatedTagView_Click(object sender, EventArgs e)
        {
            List<string> lstSelectedTagKey = null;
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            List<CRowItem> lstSelectItem = ucChart.SeriesTree.GetSelectedItemList();
            string sUnitKey = lstSelectItem[0].Values[0].ToString();    
            CMeterUnit cMeterUnit = GetMeterUnit(sUnitKey);

            if (lstSelectItem.Count != 1)
            {
                MessageBox.Show("Meter Item을 한 개만 선택하시오.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmBaseEnergySelector frmBaseEnergy = new FrmBaseEnergySelector();
            frmBaseEnergy.SelectedItem = lstSelectItem[0];
            frmBaseEnergy.MeterUnit = cMeterUnit;
            double dBaseEnergy = BaseEnergyLineAnalysis(cMeterUnit.LogS);
            frmBaseEnergy.BaseEnergy = float.Parse(dBaseEnergy.ToString());

            frmBaseEnergy.ShowDialog();

            if (!frmBaseEnergy.IsOK)
                return;

            FrmTagRecommand frmTag = new FrmTagRecommand();
            frmTag.StartTime = dtFrom;
            //frmTag.AllCoilTagItemS = m_cCoilTagItemS;
            frmTag.MeterUnit = cMeterUnit;
            frmTag.AllItem = ucChart.GanttTree.ItemS;
            frmTag.BaseEnergy = frmBaseEnergy.BaseEnergy;

            if(frmTag.ShowDialog() == DialogResult.OK)
            {
                lstSelectedTagKey = frmTag.SelectedTagKeyS;
                ShwGanttRelatedTag(lstSelectedTagKey, dtFrom, dtTo);
            }
        }

        private void mnuItemDelete_Click(object sender, EventArgs e)
        {
            int[] index = gvTagTable.GetSelectedRows();
            string sKey = string.Empty;

            foreach(int i in index)
            {
                sKey = m_cTagItemS.ElementAt(i).Key;
                m_cTagItemS.Remove(sKey);
                m_cTagItemS.UpdateTimeRange();
            }
            gcTagTable.RefreshDataSource();
        }

        private void mnuItemAdd_Click(object sender, EventArgs e)
        {
            CTagItem cSelectedTagItem = null;
            CMeterItem cMeterItem = new CMeterItem();
            CMeterUnit cMeterUnit = new CMeterUnit();

            int[] index = gvTagTable.GetSelectedRows();

            string sKey = string.Empty;

            foreach (int i in index)
            {
                sKey = m_cTagItemS.ElementAt(i).Key;
                cSelectedTagItem = m_cTagItemS[sKey];
                m_cTagItemS.Remove(sKey);
                m_cTagItemS.UpdateTimeRange();
            }
            SetTagItemS(m_cTagItemS);

            cMeterUnit.Key = cSelectedTagItem.Key;
            cMeterUnit.Parent = cSelectedTagItem.Description;
            cMeterUnit.LogS = cSelectedTagItem.LogS;
            UpdateLogS(cMeterUnit.LogS);

            cMeterItem.Add(cMeterUnit);
            cMeterItem.Key = cSelectedTagItem.Key;
            cMeterItem.UnitName = cSelectedTagItem.Address;
            cMeterItem.UpdateTimeRange();

            m_cMeterItemS.Add(cMeterItem.Key, cMeterItem);
            m_cMeterItemS.UpdateTimeRange();

            SetMeterItemS(m_cMeterItemS);
        }

        private void UpdateLogS(CTimeLogS cLogS)
        {
            foreach(CTimeLog cLog in cLogS)
                cLog.FValue = cLog.Value;
        }

        private double BaseEnergyLineAnalysis(CTimeLogS cLogS)
        {
            List<double> lstHeartBeat = new List<double>();
            List<double> lstD1 = new List<double>();
            List<double> lstD2 = new List<double>();
            Dictionary<double, int> SquaredD = new Dictionary<double, int>();
            List<double> lstSquaredD = new List<double>();
            List<double> lstPeakSquaredD = new List<double>();
            List<double> lstBaseEnergyValue = new List<double>();
            int iIndex = 0;
            int iPeakValueCount = 0;
            int iOutlierValueCount = 0;
            double dBaseEnergyAvr = 0;

            //D1, D2는 각 Value 간의 Noise를 증폭시키기 위해 하는 작업.
            for(int i = 0 ; i < cLogS.Count - 1 ; i++)
                lstHeartBeat.Add(cLogS[i + 1].FValue - cLogS[i].FValue);

            for (int i = 0; i < lstHeartBeat.Count - 1; i++)
                lstD1.Add(lstHeartBeat[i + 1] - lstHeartBeat[i]);

            for (int i = 0; i < lstD1.Count - 1; i++)
                lstD2.Add(lstD1[i + 1] - lstD1[i]);

            foreach (double dValue in lstD2)
            {
                double dSquared = dValue * dValue;
                lstSquaredD.Add(dSquared);

                if (!SquaredD.ContainsKey(dSquared))
                    SquaredD.Add(dSquared, iIndex++);
            }

            lstSquaredD.Sort();
            lstSquaredD.Reverse();

            //Peak Variable 추출(QRS 에서 R Value)

            iOutlierValueCount = Convert.ToInt32(SquaredD.Count * 0.05);
            iPeakValueCount = Convert.ToInt32(SquaredD.Count * 0.3);
            lstPeakSquaredD.AddRange(lstSquaredD.GetRange(iOutlierValueCount, iPeakValueCount));

            foreach(double dValue in lstPeakSquaredD)
            {
                if (SquaredD.ContainsKey(dValue))
                {
                    int iPeakIndex = SquaredD[dValue];
                    double dVariationStartValue = cLogS[iPeakIndex].FValue;
                    double dVariationEndValue = cLogS[iPeakIndex + 2].FValue;

                    if (dVariationStartValue > dVariationEndValue)
                        lstBaseEnergyValue.Add(dVariationEndValue);
                    else
                        lstBaseEnergyValue.Add(dVariationStartValue);
                }
            }

            dBaseEnergyAvr = lstBaseEnergyValue.Sum() / lstBaseEnergyValue.Count;

            return dBaseEnergyAvr;
        }
    }
}