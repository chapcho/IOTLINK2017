using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.UI.TimeChart;
using TrackerCommon;

namespace UDMLadderTracker
{
    public partial class FrmSymbolLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;

        private CTagS m_cCoilTagS = null;
        private CPlcLogicData m_cDataCur = null;

        #endregion


        #region Initialize/Dispose

        public FrmSymbolLogViewer()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Prooperties

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
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

        private void InitPLC()
        {
            foreach (var who in CMultiProject.PlcLogicDataS)
                exEditorPLC.Items.Add(who.Value.PlcName);

            cboPLC.EditValue = exEditorPLC.Items[0];
        }

        private void ShowCoilTagTable()
        {
            ucCoilTagTable.PlcLogicData = m_cDataCur;
            
            CTagS cCoilTagS = new CTagS();

            foreach (CStep cStep in m_cDataCur.StepS.Values)
            {
                if (cStep.CoilS[0].CoilType == EMCoilType.Timer || cStep.CoilS[0].CoilType == EMCoilType.Counter || cStep.CoilS[0].RefTagS.Count == 0)
                    continue;

                for (int i = 0; i < cStep.CoilS[0].RefTagS.KeyList.Count; i++)
                {
                    string sKey = cStep.CoilS[0].RefTagS.KeyList[i];
                    if (!cCoilTagS.ContainsKey(sKey))
                        cCoilTagS.Add(sKey, m_cDataCur.TagS[sKey]);
                }
            }
            ucCoilTagTable.ShowTable(cCoilTagS);
            m_cCoilTagS = cCoilTagS;
        }

        private void ShowTagTable()
        {
            ucTagTable.PlcLogicData = m_cDataCur;
			ucTagTable.ShowTable();
        }

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

            cColumn = new CColumnItem("colSeriesDescription", "Description");
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

        private void RegisterTimeChartEventS()
        {
            ucChart.SeriesTree.UEventCellValueChagned += SeriesTree_UEventCellValueChagned;
            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
        }

        private Color GetColor()
        {
            Random rand = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[rand.Next(names.Length)];
            Color randColor = Color.FromKnownColor(randomColorName);

            return randColor;
        }

        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
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

        private void ShowGanttChart(CTagS cTagS, DateTime dtFrom, DateTime dtTo, bool bCoilTagShow)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cNodeS = null;
                CTimeLogS cLogS = null;
                CTag cTag = null;
                bool bShowBarText = false;

                for (int i = 0 ; i < cTagS.Count; i ++)
                {
                    cTag = cTagS[i];

                    cItem = CreateGanttItem(cTag);
                    cLogS = m_cReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);

                    if (cLogS != null)
                    {
                        cLogS.UpdateTimeRange();

                        if(i == 0)
                            dtFirstVisible = cLogS.FirstTime;
                        else
                        {
                            if (dtFirstVisible > cLogS.FirstTime)
                                dtFirstVisible = cLogS.FirstTime;
                        }

                        cNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                        if (cNodeS == null)
                            cNodeS = new CTimeNodeS();
                    }
                    else
                        cNodeS = new CTimeNodeS();

                    if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                        bShowBarText = true;

                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    ucChart.GanttTree.ItemS.Add(cItem);

                    if(bCoilTagShow)
                        ShowSubItemChart(cItem, dtFrom, dtTo);

                    lstBar.Clear();
                    lstBar = null;
                }

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShowSubItemChart(CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            CTag cCoilTag = (CTag) cParentItem.Data;
            List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cCoilTag);
            CStep cStep = null;

            if (lstCoilStep == null || lstCoilStep.Count == 0)
                return;
            else
                cStep = lstCoilStep[0];

            CreateStepSubDepthItem(cStep, cCoilTag, cParentItem, dtFrom, dtTo);
        }

        private void CreateStepSubDepthItem(CStep cStep, CTag cCoilTag, CGanttItem cParentItem, DateTime dtFrom, DateTime dtTo)
        {
            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cSubNodeS = null;
                CTimeLogS cLogS = null;
                CTag cTag = null;
                bool bShowBarText = false;

                foreach (string sKey in cStep.RefTagS.KeyList)
                {
                    if (sKey == cCoilTag.Key)
                        continue;

                    cTag = m_cDataCur.TagS[sKey];
                    cItem = CreateGanttItem(cTag);
                    cLogS = m_cReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);

                    if (cLogS != null)
                    {
                        cSubNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
                        if (cSubNodeS == null)
                            cSubNodeS = new CTimeNodeS();
                    }
                    else
                        cSubNodeS = new CTimeNodeS();

                    if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                        bShowBarText = true;

                    lstBar = CreateBarList(cSubNodeS, Color.LightBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);

                    cParentItem.ItemS.Add(cItem);

                    lstBar.Clear();
                    lstBar = null;
                }
            }
            ucChart.EndUpdate();
        }

        private void ShowSeriesChart(List<string> lstTagKey, DateTime dtFrom, DateTime dtTo)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CSeriesItem cItem;
                CTimeLogS cLogS;
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                float nAxisMax = 0f;
                float nAxisMin = 0f;

                foreach (string sKey in lstTagKey)
                {
                    nMax = -1;
                    nMax = -1;

                    CTag cTag = m_cDataCur.TagS[sKey];

                    if (cTag == null || cTag.DataType == EMDataType.Bool)
                        continue;

                    cItem = new CSeriesItem(null);
                    cLogS = m_cReader.GetTimeLogS(sKey, dtFrom, dtTo);

                    cItem.Color = GetColor();
                    for (int j = 0; j < cLogS.Count; j++)
                    {
                        cLog = cLogS[j];

                        if (j == 0)
                        {
                            dtFirstVisible = cLog.Time;

                            nMax = cLog.Value;
                            nMin = cLog.Value;
                        }
                        else if (cLog.Value > nMax)
                            nMax = cLog.Value;
                        else if (nMin > cLog.Value)
                            nMin = cLog.Value;

                        if (cLog.Value > nAxisMax)
                            nAxisMax = cLog.Value;
                        else if (cLog.Value < nAxisMin)
                            nAxisMin = cLog.Value;

                        cPoint = new CSeriesPoint(cLog.Time, cLog.Value);
                        cPoint.Data = cLog.Value;
                        cItem.PointS.Add(cPoint);
                    }
                    cItem.Values = new object[] { sKey, m_cDataCur.TagS[sKey].Description, nMin, nMax, cItem.Color, 1f };

                    ucChart.SeriesTree.ItemS.Add(cItem);

                    cLogS.Clear();
                }

                ucChart.SeriesChart.Axis.Maximum = nAxisMax;
                ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

                spnAxisMin.EditValue = nAxisMin;
                spnAxisMax.EditValue = nAxisMax;

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShowSeriesChart(CTagS cTagS, DateTime dtFrom, DateTime dtTo)
        {
            DateTime dtFirstVisible = DateTime.MinValue;

            ucChart.BeginUpdate();
            {
                CSeriesItem cItem;
                CTimeLogS cLogS;
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                float nAxisMax = 0f;
                float nAxisMin = 0f;

                foreach (CTag cTag in cTagS.Values)
                {
                    nMax = -1;
                    nMax = -1;

                    if (cTag.DataType == EMDataType.Bool)
                        continue;

                    cItem = new CSeriesItem(null);
                    cLogS = m_cReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);

                    cItem.Color = GetColor();
                    for (int j = 0; j < cLogS.Count; j++)
                    {
                        cLog = cLogS[j];

                        if (j == 0)
                        {
                            dtFirstVisible = cLog.Time;

                            nMax = cLog.Value;
                            nMin = cLog.Value;
                        }
                        else if (cLog.Value > nMax)
                            nMax = cLog.Value;
                        else if (nMin > cLog.Value)
                            nMin = cLog.Value;

                        if (cLog.Value > nAxisMax)
                            nAxisMax = cLog.Value;
                        else if (cLog.Value < nAxisMin)
                            nAxisMin = cLog.Value;

                        cPoint = new CSeriesPoint(cLog.Time, cLog.Value);
                        cPoint.Data = cLog.Value;
                        cItem.PointS.Add(cPoint);
                    }
                    cItem.Values = new object[] { cTag.Key, cTag.Description, nMin, nMax, cItem.Color, 1f };

                    ucChart.SeriesTree.ItemS.Add(cItem);

                    cLogS.Clear();
                }

                ucChart.SeriesChart.Axis.Maximum = nAxisMax;
                ucChart.SeriesChart.Axis.Minimumn = nAxisMin;

                spnAxisMin.EditValue = nAxisMin;
                spnAxisMax.EditValue = nAxisMax;

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ClearChart()
        {
            ucChart.Clear();
        }

        #endregion


        #region Event Methods

        private void FrmSymbolLogViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            InitComponent();
            InitChart();
            RegisterTimeChartEventS();

            InitPLC();

            ucChart.GanttTree.ContextMenuStrip = cntxGanttTreeMenu;
            ucChart.SeriesTree.ContextMenuStrip = cntxSeriesTreeMenu;
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false || m_cDataCur == null)
                return;

            if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
            {
                MessageBox.Show("Select Start/End Time first!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;
            bool bCoilTagShow = false;
            CTagS cTagS = null;

            if (tabTable.SelectedTabPage == tpAllTable)
            {
                cTagS = ucTagTable.GetSelectedTagS();
                bCoilTagShow = false;
            }
            else
            {
                cTagS = ucCoilTagTable.GetSelectedTagS();
                bCoilTagShow = true;
            }

            if (cTagS == null || cTagS.Count == 0)
            {
                MessageBox.Show("Select symbols first!!", "UDMTracker Simple", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowGanttChart(cTagS, dtFrom, dtTo, bCoilTagShow);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnShowSeries_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false || m_cDataCur == null)
                return;

            CTagS cTagS = ucTagTable.GetSelectedTagS();
            if (cTagS == null || cTagS.Count == 0)
            {
                MessageBox.Show("Select symbols first!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
            {
                MessageBox.Show("Select Start/End Time first!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                if (dtFrom >= dtTo)
                    dtTo = dtFrom.AddMinutes(1);

                ShowSeriesChart(cTagS, dtFrom, dtTo);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucChart.Clear();
        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucChart.TimeLine.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            ucChart.TimeLine.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

                ucChart.SeriesTree.UpdateLayout();
            }
            else if (cCol.Name == "colSeriesColor")
            {
                CSeriesItem cItem = (CSeriesItem)cRow;

                cItem.Color = (Color)oValue;
                ucChart.SeriesTree.UpdateLayout();
            }
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

        private void mnuGanttItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            foreach (CRowItem item in lstSelectItem)
                ucChart.GanttTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        private void mnuSeriesChartView_Click(object sender, EventArgs e)
        {
            List<string> lstTagKey = new List<string>();
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;
            CTag cTag;

            foreach (CRowItem item in lstSelectItem)
            {
                cTag = (CTag) item.Data;

                if(!lstTagKey.Contains(cTag.Key))
                    lstTagKey.Add(cTag.Key);
            }

            if(lstTagKey.Count != 0)
                ShowSeriesChart(lstTagKey, dtFrom, dtTo);
        }

        private void mnuSeriesItemDelete_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.SeriesTree.GetSelectedItemList();

            foreach (CRowItem item in lstSelectItem)
                ucChart.SeriesTree.ItemS.Remove(item);
            ucChart.EndUpdate();
        }

        #endregion        

        private void btnAxisApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (spnAxisMax.EditValue == null || spnAxisMin.EditValue == null)
                return;

            string sMax = spnAxisMax.EditValue.ToString();
            string sMin = spnAxisMin.EditValue.ToString();

            ucChart.SeriesChart.Axis.Maximum = Convert.ToSingle(sMax);
            ucChart.SeriesChart.Axis.Minimumn = Convert.ToSingle(sMin);
        }

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar)
        {
                txtWordValue.Text = "";
                txtWordValue.Text = cBar.Text;
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
            {

                ucChart.TimeLine.TimeIndicatorS.Clear();
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

                dtpkIndicator1.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime) ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan =
                    ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();

                ucChart.TimeLine.UpdateLayout();
            }
        }

        private void mnuSubDepthView_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstSelectItem.Count > 1 || lstSelectItem.Count == 0) return;

            lstSelectItem[0].ItemS.Clear();

            CTag cCoilTag = (CTag)lstSelectItem[0].Data;
            List<CStep> lstCoilStep = CMultiProject.GetCoilStepList(cCoilTag);
            CStep cStep = null;

            if (lstCoilStep == null || lstCoilStep.Count == 0)
            {
                MessageBox.Show("하위 조건이 존재하지 않습니다.", "UDM Presenter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(lstCoilStep.Count == 1)
                cStep = lstCoilStep[0];
            else
            {
                FrmStepSelector frmSelector = new FrmStepSelector();
                frmSelector.StepList = lstCoilStep;
                frmSelector.ShowDialog();

                cStep = frmSelector.GetSelectedStep();

                frmSelector.Dispose();
                frmSelector = null;
            }

            if (cStep == null)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CreateStepSubDepthItem(cStep, cCoilTag, (CGanttItem)lstSelectItem[0], dtFrom, dtTo);
        }

        private void btnStepAllView_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CTagS cTagS = ucCoilTagTable.GetViewTagS();

            if (cTagS == null || cTagS.Count == 0)
                return;

            ucChart.GanttTree.ItemS.Clear();

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowGanttChart(cTagS, dtFrom, dtTo, true);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnTagAllView_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CTagS cTagS = ucTagTable.GetViewTagS();

            if (cTagS == null || cTagS.Count == 0)
                return;

            ucChart.GanttTree.ItemS.Clear();

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            {
                ShowGanttChart(cTagS, dtFrom, dtTo, false);
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sPLC = string.Empty;

            if (cboPLC.EditValue == null || (string)cboPLC.EditValue == string.Empty)
                return;

            sPLC = (string)cboPLC.EditValue;
            CPlcLogicData cData = null;

            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                if (who.Value.PlcName == sPLC)
                {
                    cData = who.Value;
                    break;
                }
            }

            if (cData == null)
                return;

            m_cDataCur = cData;

            ShowCoilTagTable();
            ShowTagTable();
        }
    }
}