using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Flow;
using UDM.UI.TimeChart;
using TrackerCommon;
using DevExpress.XtraGrid.Views;
using System.Diagnostics;
using TrackerProject;

namespace UDMOptimizer
{
    public partial class FrmSymbolLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private int m_iSplitPos = 0;
        private bool m_bVerified = false;
        private CMySqlLogReader m_cReader = null;

        private CTagS m_cCoilTagS = null;
        //private CPlcLogicData m_cDataCur = null;

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
                MessageBox.Show("Project is not created!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void InitGroupList()
        {
            cmbGroup.EditValue = null;
            exEditorGroup.Items.Clear();

            foreach(string sKey in CMultiProject.PlcProcS.Keys)
            {
                exEditorGroup.Items.Add(sKey);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private void InitInterval()
        {
            txtInterval.Text = "";
            dtpkIndicator1.EditValue = "00:00:00.000";
            dtpkIndicator2.EditValue = "00:00:00.000";
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
            Clear();

            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cNodeS = null;
                CTimeLogS cLogS = new CTimeLogS();
                CTag cTag = null;
                bool bShowBarText = false;
                
                List<string> lstKey = new List<string>();
                foreach (CTag tag in cTagS.Values)
                    lstKey.Add(tag.Key);

                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstKey, dtFrom, dtTo);

                for (int i = 0 ; i < cTagS.Count; i ++)
                {
                    cLogS.Clear();
                    cTag = cTagS[i];

                    cItem = CreateGanttItem(cTag);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

                    if (cLogS != null && cLogS.Count > 0)
                    {
                        cLogS.UpdateTimeRange();

                        if (i == 0)
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
                        //continue;
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
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(cStep.RefTagS.KeyList, dtFrom, dtTo);
                CTag cTag = null;
                bool bShowBarText = false;

                if (cTotalLogS == null || cTotalLogS.Count == 0)
                    return;

                CTagS cTotalTagS = CMultiProject.TotalTagS;

                foreach (string sKey in cStep.RefTagS.KeyList)
                {
                    if (sKey == cCoilTag.Key)
                        continue;
                    if (cTotalTagS.ContainsKey(sKey) == false)
                    {
                        Console.WriteLine(string.Format("{0} 가 없습니다.Logic 변환 오류 가능성 높음",sKey));
                        continue;
                    }
                    cTag = cTotalTagS[sKey];
                    cItem = CreateGanttItem(cTag);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

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
                    cLogS.Clear();
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
                CTimeLogS cLogS = new CTimeLogS();
                CTimeLog cLog;
                CSeriesPoint cPoint;
                float nMax = 0f;
                float nMin = 0f;
                float nAxisMax = 0f;
                float nAxisMin = 0f;

                CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstTagKey, dtFrom, dtTo);
                
                if (cTotalLogS == null || cTotalLogS.Count == 0)
                    return;

                CTagS cTotalTagS = CMultiProject.TotalTagS;

                foreach (string sKey in lstTagKey)
                {
                    nMax = -1;
                    nMax = -1;
                    if (cTotalTagS.ContainsKey(sKey) == false) continue;
                    CTag cTag = cTotalTagS[sKey];

                    if (cTag == null || cTag.DataType == EMDataType.Bool)
                        continue;

                    cItem = new CSeriesItem(null);
                    cLogS.AddRange(cTotalLogS.FindAll(b => b.Key == cTag.Key));

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
                    cItem.Values = new object[] { sKey, cTotalTagS[sKey].Description, nMin, nMax, cItem.Color, 1f };

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
                cLogS.Clear();
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

        private void Clear()
        {
            ucChart.Clear();
            ucChart.GanttTree.ColumnS.Clear();

            InitInterval();
            InitChart();
        }

        #endregion


        #region Event Methods

        #region Form Event
        private void FrmSymbolLogViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
            {
                this.Close();
                return;
            }

            InitComponent();
            InitChart();
            RegisterTimeChartEventS();

            InitGroupList();

            if (CMultiProject.PlcProcS.Count != 0)
            {
                ucProcessTree.ShowErrorProcess = false;
                ucProcessTree.ShowTree();
            }
            ucProcessTree.UEventUnitShowLogClicked += ucProcessTree_UEventUnitShowLogClicked;
            ucProcessTree.UEventTotalDeviceShowLog += ucProcessTree_UEventTotalDeviceShowLog;
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (m_bVerified == false)
            //    return;
                       
            //if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
            //{
            //    MessageBox.Show("Select Start/End Time first!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //string sProcess = (string)cmbGroup.EditValue;
            //CPlcProc cProcess =  CMultiProject.PlcProcS[sProcess];

            //DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            //DateTime dtTo = (DateTime)dtpkTo.EditValue;

            //CTagS cSumTagS = new CTagS();
            //cSumTagS.AddRange(cProcess.RecipeWordS);
            //cSumTagS.AddRange(cProcess.ProcessTagS);

            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //{
            //    ShowGanttChart(cSumTagS, dtFrom, dtTo, false);
            //}
            //SplashScreenManager.CloseForm(false);
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            Clear();
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

        private void btnAxisApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (spnAxisMax.EditValue == null || spnAxisMin.EditValue == null)
                return;

            string sMax = spnAxisMax.EditValue.ToString();
            string sMin = spnAxisMin.EditValue.ToString();

            ucChart.SeriesChart.Axis.Maximum = Convert.ToSingle(sMax);
            ucChart.SeriesChart.Axis.Minimumn = Convert.ToSingle(sMin);
        }
        private void FrmSymbolLogViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucProcessTree.UEventUnitShowLogClicked -= ucProcessTree_UEventUnitShowLogClicked;
        }

        #endregion

        #region Tree Event

        private void ucProcessTree_UEventUnitShowLogClicked(object sender, CUnitInfo cUnit, CPlcProc cProcess)
        {
            //Unit호출

            if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
            {
                MessageBox.Show("Select Start/End Time first!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CTagS cSumTagS = new CTagS();
            cSumTagS.AddRange(cProcess.RecipeWordS);
            cSumTagS.AddRange(cUnit.TotalTagS);

            CShowWaitForm.ShowForm("Show", string.Format("Process : {0}\r\nShow Gantt Chart : {0}", cProcess.Name), "Start...", true);
            {
                ShowGanttChart(cSumTagS, dtFrom, dtTo, false);
            }
            CShowWaitForm.CloseForm();
        }

        private void ucProcessTree_UEventTotalDeviceShowLog(object sender, CPlcProc cProcess)
        {
            //if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
            //{
            //    MessageBox.Show("Select Start/End Time first!!", "UDM Optimizer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //cmbGroup.EditValue = cProcess.Name;

            //DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            //DateTime dtTo = (DateTime)dtpkTo.EditValue;

            //CTagS cSumTagS = new CTagS();
            //cSumTagS.AddRange(cProcess.RecipeWordS);
            //cSumTagS.AddRange(cProcess.ProcessTagS);

            //SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            //{
            //    ShowGanttChart(cSumTagS, dtFrom, dtTo, false);
            //}
            //SplashScreenManager.CloseForm(false);
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
        #endregion

        #region Chart Event


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

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
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

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

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
            else if (lstCoilStep.Count == 1)
                cStep = lstCoilStep[0];
            else
            {
                FrmStepSelector frmSelector = new FrmStepSelector();
                frmSelector.StepList = lstCoilStep;
                frmSelector.ShowDialog();

                if (frmSelector.IsSelectStep)
                {
                    cStep = frmSelector.GetSelectedStep();
                }
                frmSelector.Dispose();
                frmSelector = null;
            }

            if (cStep == null)
                return;

            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CreateStepSubDepthItem(cStep, cCoilTag, (CGanttItem)lstSelectItem[0], dtFrom, dtTo);
        }
        #endregion

        private void btnTest1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;
            List<string> lstKey = new List<string>();
            foreach (CTag cTag in CMultiProject.TotalTagS.Values)
            {
                if (cTag.DataType == EMDataType.Bool && cTag.Address.Contains("Q"))
                    lstKey.Add(cTag.Key);
            }
            CTimeLogS cLogS = m_cReader.GetTimeLogS(lstKey, dtFrom, dtTo);

            sw.Stop();
            if (cLogS != null)
                MessageBox.Show(string.Format("{0} ms, LogCount : {1}", sw.ElapsedMilliseconds, cLogS.Count));
            else
                MessageBox.Show(string.Format("{0} ms", sw.ElapsedMilliseconds));
        }

        private void btnTest2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
            DateTime dtTo = (DateTime)dtpkTo.EditValue;

            CTimeLogS cLogS = new CTimeLogS();

            foreach (CTag cTag in CMultiProject.TotalTagS.Values)
            {
                if (cTag.DataType == EMDataType.Bool && cTag.Address.Contains("Q"))
                {
                    cLogS.AddRange(m_cReader.GetTimeLogS(cTag.Key, dtFrom, dtTo));
                }
            }

            sw.Stop();
            if (cLogS != null)
                MessageBox.Show(string.Format("{0} ms, LogCount : {1}", sw.ElapsedMilliseconds, cLogS.Count));
            else
                MessageBox.Show(string.Format("{0} ms", sw.ElapsedMilliseconds));
        }

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }

        #endregion

    }
}