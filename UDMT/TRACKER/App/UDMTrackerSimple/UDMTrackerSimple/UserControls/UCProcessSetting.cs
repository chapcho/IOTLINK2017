using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;
using UDM.Common;
using UDM.UI.TimeChart;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public partial class UCProcessSetting : DevExpress.XtraEditors.XtraUserControl, IDisposable
    {
        #region Member Variables

        protected CTimeLogS m_cTimeLogS = null;
        protected CPlcProc m_cProcess = null;
        protected CPlcLogicDataS m_cPlcLogicDataS = null;
        protected CTagS m_cTotalTagS = null;
        protected Dictionary<string, CActiveTimeS> m_dicTagActiveTimeS = new Dictionary<string, CActiveTimeS>();
        protected CTimeIndicator m_cDurationStartTimeLine = null;
        protected CTimeIndicator m_cDurationEndTimeLine = null;
        protected CTimeIndicator m_cCycleStartTimeLine = null;
        protected CTimeIndicator m_cCycleEndTimeLine = null;

        #endregion


        #region Initialize

        public UCProcessSetting()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            if (m_cTimeLogS != null)
            {
                m_cTimeLogS.Clear();
                m_cTimeLogS = null;
            }

            ucChart.Clear();

            m_cProcess = null;
            m_cPlcLogicDataS = null;
            m_cTotalTagS = null;
            
            m_dicTagActiveTimeS.Clear();
            m_dicTagActiveTimeS = null;
            m_cDurationStartTimeLine = null;
            m_cDurationEndTimeLine = null;
            m_cCycleStartTimeLine = null;
            m_cCycleEndTimeLine = null;
        }

        #endregion


        #region Properties

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        public CPlcProc PlcProcess
        {
            get { return m_cProcess; }
            set { m_cProcess = value; }
        }

        public CPlcLogicDataS PlcLogicDataS
        {
            get { return m_cPlcLogicDataS; }
            set { m_cPlcLogicDataS = value; }
        }

        public CTagS TotalTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        #endregion


        #region Public Method

        public void InitialData()
        {
            try
            {
                ucChart.GanttChart.ContextMenuStrip = cntxCycle;
                ucChart.GanttTree.ContextMenuStrip = cntxGanttTree;

                grdProperty.SelectedObject = m_cProcess;

                grdCycleStartConditionS.DataSource = null;
                grdCycleStartConditionS.DataSource = m_cProcess.CycleStartConditionS;
                grvCycleStartConditionS.BestFitColumns();
                grdCycleStartConditionS.RefreshDataSource();

                grdCycleEndConditionS.DataSource = null;
                grdCycleEndConditionS.DataSource = m_cProcess.CycleEndConditionS;
                grvCycleEndConditionS.BestFitColumns();
                grdCycleEndConditionS.RefreshDataSource();

                grdKeySymbolS.DataSource = null;
                grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
                grvKeySymbolS.BestFitColumns();
                grdKeySymbolS.RefreshDataSource();

                cmbSelectView.SelectedIndex = -1;

                //if (m_cProcess.CycleStartConditionS.Count == 0 || m_cProcess.KeySymbolS.Count == 0)
                //{
                    SetTimeRange();
                    ucChart.Clear();

                    cmbSelectView.SelectedIndex = 0;

                    m_cProcess.CycleStartTimeLine = m_cCycleStartTimeLine.Time;
                    m_cProcess.CycleEndTimeLine = m_cCycleEndTimeLine.Time;
                    InitTimeLine();
                    txtCycle.Text = "";
                //}
                //else
                //    SetCycle(btnApply.Visible);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting InitData Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        #endregion


        #region Private Method

        private void SetCycle(bool bCycleOnly)
        {
            try
            {
                //if (bCycleOnly)
                //{
                //    btnRestore.Visible = true;
                //    btnApply.Visible = false;
                //}
                //else
                //{
                //    btnRestore.Visible = false;
                //    btnApply.Visible = true;
                //}

                //cmbSelectView.Enabled = false;
                btnRefresh.Enabled = false;
                //btnTimeRangeApply.Enabled = false;
                //dtpkFrom.Enabled = false;
                //dtpkTo.Enabled = false;

                dtpkFrom.EditValue = m_cProcess.ChartStartTime;
                dtpkTo.EditValue = m_cProcess.ChartEndTime;

                ucChart.Clear();

                CTagS cKeyTagS = m_cProcess.ChartViewTagS;

                if (bCycleOnly)
                    cKeyTagS = m_cProcess.KeySymbolS.GetTagS();

                m_cProcess.ChartViewTimeLogS = m_cTimeLogS.GetTimeLogS(cKeyTagS.Keys.ToList(), m_cProcess.ChartStartTime,
                    m_cProcess.ChartEndTime);

                ShowGanttChart(cKeyTagS, m_cProcess.ChartStartTime, m_cProcess.ChartEndTime,
                    m_cProcess.ChartViewTimeLogS, Color.DodgerBlue);

                InitTimeLine();
                m_cCycleStartTimeLine.Time = m_cProcess.CycleStartTimeLine;
                m_cCycleEndTimeLine.Time = m_cProcess.CycleEndTimeLine;
                ucChart.TimeLine.UpdateLayout();

                TimeSpan tsSpan = m_cProcess.CycleEndTimeLine.Subtract(m_cProcess.CycleStartTimeLine);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtCycle.Text = nInterval.ToString();

                grdKeySymbolS.DataSource = null;
                grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
                grdKeySymbolS.RefreshDataSource();
                grvKeySymbolS.BestFitColumns();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting SetCycle Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetTimeRange()
        {
            if (m_cTimeLogS == null || m_cTimeLogS.Count == 0)
            {
                DateTime dtLast = CMultiProject.LogReader.GetLastTimeLogTime();

                if (dtLast != DateTime.MinValue)
                {
                    dtpkTo.EditValue = dtLast;
                    dtpkFrom.EditValue = dtLast.AddMinutes(-30);
                }
                return;
            }

            m_cTimeLogS.Sort();
            m_cTimeLogS.UpdateTimeRange();

            dtpkTo.EditValue = m_cTimeLogS.LastTime;
            dtpkFrom.EditValue = m_cTimeLogS.FirstTime;

        }

        protected void InitTimeLine()
        {
            //0,1은 간격확인용
            ucChart.TimeLine.TimeIndicatorS.Clear();
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(DateTime.MinValue, Color.Red, EMTimeLineType.Duration));
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(DateTime.MinValue, Color.Red, EMTimeLineType.Duration));

            m_cDurationStartTimeLine = ucChart.TimeLine.TimeIndicatorS[0];
            m_cDurationEndTimeLine = ucChart.TimeLine.TimeIndicatorS[1];

            //2,3은 Cycle지정용
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(DateTime.MinValue, Color.Brown, EMTimeLineType.Cycle));
            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(DateTime.MinValue, Color.Brown, EMTimeLineType.Cycle));

            m_cCycleStartTimeLine = ucChart.TimeLine.TimeIndicatorS[2];
            m_cCycleEndTimeLine = ucChart.TimeLine.TimeIndicatorS[3];
            
            ucChart.TimeLine.UpdateLayout();
            ucChart.TimeLine.UpdateLayout();
        }


        private void InitChart()
        {
            CColumnItem cColumn = null;

            cColumn = new CColumnItem("colGanttAddress", "Address");
            cColumn.IsReadOnly = true;
            cColumn.Width = 70;
            ucChart.GanttTree.ColumnS.Add(cColumn);
            cColumn.AllowSort = false;

            cColumn = new CColumnItem("colGanttDescription", "Comment");
            cColumn.IsReadOnly = true;
            cColumn.Width = 200;
            ucChart.GanttTree.ColumnS.Add(cColumn);
            cColumn.AllowSort = false;
            
            ucChart.GanttTree.Update();

            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
            InitTimeLine();
        }

        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
            cItem.Data = cTag;

            return cItem;
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

        private void ShowGanttChart(CTagS cInoutTagS, DateTime dtFrom, DateTime dtTo, bool bCoilTagShow)
        {
            DateTime dtFirstVisible = DateTime.MinValue;
            m_dicTagActiveTimeS.Clear();
            m_cTimeLogS.Clear();

            ucChart.BeginUpdate();
            {
                CGanttItem cItem = null;
                List<CGanttBar> lstBar = null;
                CTimeNodeS cNodeS = null;
                CTimeLogS cLogS = null;
                CTag cTag = null;
                bool bShowBarText = false;
                bool bFirst = true;
                foreach (var who in cInoutTagS)
                {
                    cTag = who.Value;
                    CActiveTimeS cTagActiveTimeS = new CActiveTimeS();

                    cItem = CreateGanttItem(cTag);
                    cLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);
                    if (cLogS != null)
                    {
                        if (cLogS.Count < 2) continue;

                        //List<CTimeLog> cOnLogS = cLogS.Where(x => x.Value == 1).ToList();
                        //if (cOnLogS == null || cOnLogS.Count == 0) continue;

                        //List<CTimeLog> cOffLogS = cLogS.Where(x => x.Value == 0).ToList();
                        //if (cOffLogS == null || cOffLogS.Count == 0) continue;

                        m_cTimeLogS.AddRange(cLogS);
                        cLogS.UpdateTimeRange();

                        if (bFirst)
                        {
                            dtFirstVisible = cLogS.FirstTime;
                            bFirst = false;
                        }
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

                    //if (cTag.DataType == EMDataType.Word || cTag.DataType == EMDataType.DWord)
                        bShowBarText = true;

                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);
                    cTagActiveTimeS.AddRange(lstBar.Select(b => b.StartTime).ToList(), lstBar.Select(b => b.EndTime).ToList());
                    if (cTagActiveTimeS.Count > 0) 
                        m_dicTagActiveTimeS.Add(cTag.Key, cTagActiveTimeS);
                    ucChart.GanttTree.ItemS.Add(cItem);

                    if (bCoilTagShow)
                        ShowSubItemChart(cItem, dtFrom, dtTo);

                    lstBar.Clear();
                    lstBar = null;

                    if (cLogS != null)
                    {
                        cLogS.Clear();
                        cLogS = null;
                    }

                    if (cNodeS != null)
                    {
                        cNodeS.Clear();
                        cNodeS = null;
                    }
                }

                m_cTimeLogS.UpdateTimeRange();

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;

                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;
            }
            ucChart.EndUpdate();
        }

        private void ShowGanttChart(CTagS cTagS, DateTime dtFrom, DateTime dtTo, CTimeLogS cBaseLogS, Color color)
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
                bool bFirst = true;
                foreach (var who in cTagS)
                {
                    cTag = who.Value;

                    cItem = CreateGanttItem(cTag);
                    cLogS = cBaseLogS.GetTimeLogS(cTag.Key, dtFrom, dtTo);

                    if (cLogS != null)
                    {
                        if (cLogS.Count < 2) continue;

                        cLogS.UpdateTimeRange();

                        if (bFirst)
                        {
                            dtFirstVisible = cLogS.FirstTime;
                            bFirst = false;
                        }
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

                    lstBar = CreateBarList(cNodeS, color, bShowBarText);
                    cItem.BarS.AddRange(lstBar);
                    ucChart.GanttTree.ItemS.Add(cItem);

                    lstBar.Clear();
                    lstBar = null;

                    if (cLogS != null)
                    {
                        cLogS.Clear();
                        cLogS = null;
                    }

                    if (cNodeS != null)
                    {
                        cNodeS.Clear();
                        cNodeS = null;
                    }
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
            CTag cCoilTag = (CTag)cParentItem.Data;
            if (m_cPlcLogicDataS.ContainsKey(cCoilTag.Creator) == false) return;

            List<CStep> lstCoilStep = m_cPlcLogicDataS[cCoilTag.Creator].GetCoilStepList(cCoilTag);
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

                    cTag = m_cTotalTagS[sKey];
                    cItem = CreateGanttItem(cTag);
                    //cLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key);
                    cLogS = m_cTimeLogS.GetTimeLogS(cTag.Key);
                    if (cLogS != null)
                    {
                        if (cLogS.Count < 2) continue;

                        m_cTimeLogS.AddRange(cLogS);

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

                m_cTimeLogS.UpdateTimeRange();
            }
            ucChart.EndUpdate();
        }

        private DateTime CheckConditionS(CConditionS cConditionS, DateTime dtSelectTime, out CCondition cSelectCondition)
        {
            cSelectCondition = new CCondition();
            List<CCondition> lstAndCondition = cConditionS.Where(b => b.OperatorType == EMOperaterType.And).ToList();
            List<CCondition> lstOrCondition = cConditionS.Where(b => b.OperatorType == EMOperaterType.Or).ToList();

            DateTime dtCycleTimeLine = DateTime.MinValue;
            DateTime dtOrLastTime = DateTime.MinValue;
            foreach (CCondition con in lstOrCondition)
            {
                CTag cTag = m_cTotalTagS[con.Key];
                if (m_dicTagActiveTimeS.ContainsKey(cTag.Key))
                {
                    CActiveTime cActTime = m_dicTagActiveTimeS[cTag.Key].GetActiveTime(dtSelectTime, con.TargetValue);
                    if (cActTime != null)
                    {
                        if (con.TargetValue > 0)
                        {
                            if (cActTime.OnTime > dtOrLastTime)
                            {
                                dtOrLastTime = cActTime.OnTime;
                                cSelectCondition = con;
                            }
                        }
                        else
                        {
                            if (cActTime.OffTime > dtOrLastTime)
                            {
                                dtOrLastTime = cActTime.OffTime;
                                cSelectCondition = con;
                            }
                        }
                    }
                }
            }

            foreach (CCondition con in lstAndCondition)
            {
                CTag cTag = m_cTotalTagS[con.Key];
                if (m_dicTagActiveTimeS.ContainsKey(cTag.Key))
                {
                    CActiveTime cActTime = m_dicTagActiveTimeS[cTag.Key].GetActiveTime(dtSelectTime, con.TargetValue);
                    if (cActTime == null)
                    {
                        return DateTime.MinValue;
                    }
                    if (con.TargetValue > 0)
                    {
                        if (cActTime.OnTime > dtCycleTimeLine)
                        {
                            if (dtOrLastTime < cActTime.OnTime)
                            {
                                dtCycleTimeLine = cActTime.OnTime;
                                cSelectCondition = con;
                            }
                        }
                    }
                    else
                    {
                        if (cActTime.OffTime > dtCycleTimeLine)
                        {
                            if (dtOrLastTime < cActTime.OffTime)
                            {
                                dtCycleTimeLine = cActTime.OffTime;
                                cSelectCondition = con;
                            }
                        }
                    }
                }
            }

            return dtCycleTimeLine;
        }

        private CTagS GetUsedCycleTagS(CTimeLogS cLogS)
        {
            CTagS cTagS = new CTagS();
            CTimeLogS cOnLog = new CTimeLogS();

            foreach (var who in m_cProcess.ChartViewTagS)
            {
                CTimeLogS cSumLogS = null;
                if(who.Value.DataType == EMDataType.Bool)
                    cSumLogS = cLogS.GetTimeLogS(who.Key, 1);
                else
                    cSumLogS = cLogS.GetNTimeLogS(who.Key, 0);

                if (cSumLogS.Count > 0)
                        cOnLog.AddRange(cSumLogS);
            }

            cOnLog.Sort();

            foreach (var who in cOnLog)
            {
                if (m_cProcess.ChartViewTagS.ContainsKey(who.Key) && cTagS.ContainsKey(who.Key) == false)
                    cTagS.Add(who.Key, m_cProcess.ChartViewTagS[who.Key]);
            }

            return cTagS;
        }
        
        #endregion


        #region Form Event

        private void grdCycleStartConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.TreeListMultiSelection)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;            
        }

        private void grdCycleEndConditionS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.TreeListMultiSelection)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdKeySymbolS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.TreeListMultiSelection)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdCycleStartConditionS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (btnRefresh.Enabled == false) return;
                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof (DevExpress.XtraTreeList.TreeListMultiSelection)))
                    {
                        TreeListMultiSelection exSelection =
                            (DevExpress.XtraTreeList.TreeListMultiSelection)
                                e.Data.GetData(typeof (DevExpress.XtraTreeList.TreeListMultiSelection));
                        TreeListNode trnNode;
                        CRowItem cItem;
                        for (int i = 0; i < exSelection.Count; i++)
                        {
                            trnNode = exSelection[i];
                            if (trnNode.Tag != null)
                            {
                                cItem = (CRowItem) trnNode.Tag;
                                if (cItem.Data.GetType() == typeof (CTag))
                                {
                                    CTag cTag = (CTag) cItem.Data;
                                    CCondition cCondition = new CCondition(cTag.Key, cTag.Address, 1, EMOperaterType.And);
                                    m_cProcess.CycleStartConditionS.Add(cCondition);
                                }
                            }
                        }

                        //if (m_cProcess.CycleStartConditionS.Count > 0)
                        //    m_cProcess.StartCompareCondition = m_cProcess.CycleStartConditionS.First();

                        //SetStartConditionTimeLine();
                        grdCycleStartConditionS.RefreshDataSource();
                        grvCycleStartConditionS.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdCycleEndConditionS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (btnRefresh.Enabled == false) return;
                if (e.Data != null)
                {
                    if (e.Data.GetDataPresent(typeof (DevExpress.XtraTreeList.TreeListMultiSelection)))
                    {
                        TreeListMultiSelection exSelection =
                            (DevExpress.XtraTreeList.TreeListMultiSelection)
                                e.Data.GetData(typeof (DevExpress.XtraTreeList.TreeListMultiSelection));
                        TreeListNode trnNode;
                        CRowItem cItem;
                        for (int i = 0; i < exSelection.Count; i++)
                        {
                            trnNode = exSelection[i];
                            if (trnNode.Tag != null)
                            {
                                cItem = (CRowItem) trnNode.Tag;
                                if (cItem.Data.GetType() == typeof (CTag))
                                {
                                    CTag cTag = (CTag) cItem.Data;
                                    CCondition cCondition = new CCondition(cTag.Key, cTag.Address, 1, EMOperaterType.And);
                                    m_cProcess.CycleEndConditionS.Add(cCondition);
                                }
                            }
                        }

                        //if (m_cProcess.CycleEndConditionS.Count > 0)
                        //    m_cProcess.EndCompareCondition = m_cProcess.CycleEndConditionS.First();

                        //SetEndConditionTimeLine();
                        grdCycleEndConditionS.RefreshDataSource();
                        grvCycleEndConditionS.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void grdKeySymbolS_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (btnRefresh.Enabled) return;

                if (e.Data != null)
                {
                    if (m_cProcess.KeySymbolS.Count > 0)
                    {
                        DialogResult dlgResult =
                            XtraMessageBox.Show(
                                "해당 Process의 Key Symbol이 이미 존재합니다.\r\nDrag&Drop 하신 Tag로 Key Symbol을 Update 하시겠습니까?",
                                "Key Symbol Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlgResult == DialogResult.No)
                            return;
                        else
                            m_cProcess.KeySymbolS.Clear();
                    }

                    if (e.Data.GetDataPresent(typeof (DevExpress.XtraTreeList.TreeListMultiSelection)))
                    {
                        TreeListMultiSelection exSelection =
                            (DevExpress.XtraTreeList.TreeListMultiSelection)
                                e.Data.GetData(typeof (DevExpress.XtraTreeList.TreeListMultiSelection));
                        TreeListNode trnNode;
                        CRowItem cItem;
                        CTagS cAddedTagS = new CTagS();
                        for (int i = 0; i < exSelection.Count; i++)
                        {
                            trnNode = exSelection[i];
                            if (trnNode.Tag != null)
                            {
                                cItem = (CRowItem) trnNode.Tag;
                                if (cItem.Data.GetType() == typeof (CTag))
                                {
                                    CTag cTag = (CTag) cItem.Data;
                                    cAddedTagS.Add(cTag);
                                }
                            }
                        }
                        //Sort

                        SplashScreenManager.ShowDefaultWaitForm();
                        {
                            CTimeLogS cInCycleLogS = m_cProcess.ChartViewTimeLogS.GetTimeLogS(
                                m_cCycleStartTimeLine.Time, m_cProcess.ChartEndTime);
                            CTagS cCycleTagS = GetUsedCycleTagS(cInCycleLogS);

                            foreach (var who in cCycleTagS)
                            {
                                if (cAddedTagS.ContainsKey(who.Key) &&
                                    m_cProcess.KeySymbolS.ContainsKey(who.Key) == false)
                                {
                                    CKeySymbol cKeySymbol = new CKeySymbol(who.Value);
                                    m_cProcess.KeySymbolS.Add(who.Key, cKeySymbol);
                                }
                            }
                            m_cProcess.UpdateKeySymbolS();
                        }
                        SplashScreenManager.CloseDefaultWaitForm();

                        grdKeySymbolS.DataSource = null;
                        grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
                        grdKeySymbolS.RefreshDataSource();
                        grvKeySymbolS.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cProcess == null) return;

                if (cntxMenu.SourceControl == grdCycleStartConditionS)
                {
                    m_cProcess.CycleStartConditionS.Clear();
                    //m_cProcess.StartCompareCondition = null;
                    grdCycleStartConditionS.RefreshDataSource();
                    m_cCycleStartTimeLine.Time = DateTime.MinValue;
                    m_cProcess.CycleStartTimeLine = DateTime.MinValue;

                    ucChart.TimeLine.UpdateLayout();
                }
                else if (cntxMenu.SourceControl == grdCycleEndConditionS)
                {
                    m_cProcess.CycleEndConditionS.Clear();
                    //m_cProcess.EndCompareCondition = null;
                    grdCycleEndConditionS.RefreshDataSource();
                    m_cCycleEndTimeLine.Time = DateTime.MinValue;
                    m_cProcess.CycleEndTimeLine = DateTime.MinValue;

                    ucChart.TimeLine.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void cmbSelectView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSelectView.SelectedIndex < 0) return;

                SplashScreenManager.ShowDefaultWaitForm("Please Waiting...", "Gantt Chart를 그리는 중입니다.");
                {
                    DateTime dtFrom = (DateTime) dtpkFrom.EditValue;
                    DateTime dtTo = (DateTime) dtpkTo.EditValue;

                    ucChart.Clear();

                    if (cmbSelectView.SelectedIndex == 0)
                    {
                        if (m_cProcess.PlcLogicDataS != null)
                        {
                            if (m_cProcess.ChartViewTagS.Count == 0)
                                m_cProcess.ChartViewTagS.AddRange(m_cProcess.KeySymbolS.GetTagS());

                                ShowGanttChart(m_cProcess.ChartViewTagS, dtFrom, dtTo, false);
                        }
                    }

                    InitTimeLine();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuCycleStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucChart.GanttChart.FocusedBar == null) return;

                CRowItem cItem = ucChart.GanttChart.FocusedBar.Item;
                if (cItem.Data != null)
                {
                    CTag cTag = (CTag) cItem.Data;
                    if (m_cProcess.CycleStartConditionS.ContainsKey(cTag.Key))
                    {
                        CCondition cCondi = m_cProcess.CycleStartConditionS.GetSelectedKeyData(cTag.Key);
                        DateTime dtTime = DateTime.MinValue;
                        if (cCondi.TargetValue == 1)
                            dtTime = ucChart.GanttChart.FocusedBar.EndTime;
                        else
                            dtTime = ucChart.GanttChart.FocusedBar.StartTime;

                        CCondition cSelectedCondi = new CCondition();
                        DateTime dtResult = CheckConditionS(m_cProcess.CycleStartConditionS, dtTime, out cSelectedCondi);
                        if (cSelectedCondi.Key != "")
                        {
                            //m_cProcess.StartCompareCondition = cSelectedCondi;
                        }
                        else
                        {
                            MessageBox.Show("선택된 Condition이 없습니다.");
                            return;
                        }

                        if (dtResult == DateTime.MinValue)
                        {
                            MessageBox.Show("연산이 잘못되었습니다.");
                            return;
                        }

                        m_cCycleStartTimeLine.Time = dtResult;
                        m_cProcess.CycleStartTimeLine = dtResult;

                        ucChart.TimeLine.UpdateLayout();
                        ucChart.TimeLine.UpdateLayout();
                    }
                    else
                    {
                        MessageBox.Show("Cycle Start Condition에 등록된 접점이 아닙니다.\r\n먼저 Bar옆 항목을 선택해서 Drag해서 추가하세요");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void mnuCycleEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucChart.GanttChart.FocusedBar == null) return;
                if (m_cProcess.CycleStartTimeLine == DateTime.MinValue)
                {
                    MessageBox.Show("Start시점을 먼저 설정하세요");
                    return;
                }
                CRowItem cItem = ucChart.GanttChart.FocusedBar.Item;
                if (cItem.Data != null)
                {
                    CTag cTag = (CTag) cItem.Data;
                    if (m_cProcess.CycleEndConditionS.ContainsKey(cTag.Key))
                    {
                        CCondition cCondi = m_cProcess.CycleEndConditionS.GetSelectedKeyData(cTag.Key);
                        DateTime dtTime = DateTime.MinValue;
                        if (cCondi.TargetValue == 1)
                            dtTime = ucChart.GanttChart.FocusedBar.StartTime;
                        else
                            dtTime = ucChart.GanttChart.FocusedBar.EndTime;

                        CCondition cSelectedCondi = new CCondition();
                        DateTime dtResult = CheckConditionS(m_cProcess.CycleEndConditionS, dtTime, out cSelectedCondi);
                        if (cSelectedCondi.Key != "")
                        {
                            //m_cProcess.EndCompareCondition = cSelectedCondi;
                        }
                        else
                        {
                            MessageBox.Show("선택된 Condition이 없습니다.");
                            return;
                        }

                        if (dtResult < m_cProcess.CycleStartTimeLine)
                        {
                            MessageBox.Show("시작시간보다 빠를 수 없습니다.");
                            return;
                        }

                        if (dtResult == DateTime.MinValue)
                        {
                            MessageBox.Show("연산이 잘못되었습니다.");
                            return;
                        }

                        m_cCycleEndTimeLine.Time = dtResult;
                        m_cProcess.CycleEndTimeLine = dtResult;
                        ucChart.TimeLine.UpdateLayout();
                        ucChart.TimeLine.UpdateLayout();

                        TimeSpan tsSpan = m_cProcess.CycleEndTimeLine.Subtract(m_cProcess.CycleStartTimeLine);
                        double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                        txtCycle.Text = nInterval.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cycle Start Condition에 등록된 접점이 아닙니다.\r\n먼저 Bar옆 항목을 선택해서 Drag해서 추가하세요");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_cCycleStartTimeLine.Time == DateTime.MinValue || m_cCycleEndTimeLine.Time == DateTime.MinValue)
                    return;
                //Sort진행(Cycle Start Condition에 있는 접점부터 오름차순
                CTag cCycleStartTag = null;
                CTag cCycleEndTag = null;
                foreach (var who in m_cProcess.CycleStartConditionS)
                {
                    List<CTimeLog> lstLog =
                        m_cTimeLogS.Where(b => b.Key == who.Key && b.Time == m_cCycleStartTimeLine.Time).ToList();
                    if (lstLog.Count > 0)
                    {
                        cCycleStartTag = m_cTotalTagS[who.Key];
                        break;
                    }

                    lstLog.Clear();
                    lstLog = null;
                }
                if (cCycleStartTag == null)
                {
                    MessageBox.Show("Cycle Start조건을 찾을 수 없습니다.");
                    return;
                }

                foreach (var who in m_cProcess.CycleEndConditionS)
                {
                    List<CTimeLog> lstLog =
                        m_cTimeLogS.Where(b => b.Key == who.Key && b.Time == m_cCycleEndTimeLine.Time).ToList();
                    if (lstLog.Count > 0)
                    {
                        cCycleEndTag = m_cTotalTagS[who.Key];
                        break;
                    }

                    lstLog.Clear();
                    lstLog = null;
                }
                if (cCycleEndTag == null)
                {
                    MessageBox.Show("Cycle Start조건을 찾을 수 없습니다.");
                    return;
                }

                ucChart.Clear();

                m_cTimeLogS.UpdateTimeRange();

                DateTime dtPrev =
                    m_dicTagActiveTimeS[cCycleStartTag.Key].GetCycleStartPrevOnTime(m_cCycleStartTimeLine.Time);
                DateTime dtNext = m_dicTagActiveTimeS[cCycleEndTag.Key].GetCycleStartNextOnTime(
                    m_cCycleEndTimeLine.Time, m_dicTagActiveTimeS[cCycleStartTag.Key]);

                CTimeLogS cCycleLogS = m_cTimeLogS.GetTimeLogS(m_dicTagActiveTimeS.Keys.ToList(), dtPrev, dtNext);
                CTimeLogS cPrevLogS = m_cTimeLogS.GetTimeLogS(m_dicTagActiveTimeS.Keys.ToList(), dtPrev,
                    m_cCycleStartTimeLine.Time);
                CTimeLogS cInCycleLogS = m_cTimeLogS.GetTimeLogS(m_dicTagActiveTimeS.Keys.ToList(),
                    m_cCycleStartTimeLine.Time, dtNext);
                InitTimeLine();
                cCycleLogS.Sort();

                CTagS cCycleTagS = GetUsedCycleTagS(cInCycleLogS);
                CTagS cPrevTagS = GetUsedCycleTagS(cPrevLogS);

                cCycleTagS.AddRange(cPrevTagS);

                m_cProcess.ChartStartTime = dtPrev;
                m_cProcess.ChartEndTime = dtNext;
                //m_cProcess.ChartViewTagS = cCycleTagS;
                m_cProcess.ChartViewTimeLogS = cCycleLogS;

                ShowGanttChart(cCycleTagS, dtPrev, dtNext, cCycleLogS, Color.DodgerBlue);


                m_cCycleStartTimeLine.Time = m_cProcess.CycleStartTimeLine;
                m_cCycleEndTimeLine.Time = m_cProcess.CycleEndTimeLine;

                btnRefresh.Enabled = false;
                //cmbSelectView.Enabled = false;
                //btnTimeRangeApply.Enabled = false;
                //dtpkFrom.Enabled = false;
                //dtpkTo.Enabled = false;

                dtpkFrom.EditValue = dtPrev;
                dtpkTo.EditValue = dtNext;

                cPrevLogS.Clear();
                cPrevLogS = null;
                
                cInCycleLogS.Clear();
                cInCycleLogS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnInitChart_Click(object sender, EventArgs e) 
        {
            try
            {
                DialogResult dlgResult = MessageBox.Show("초기화를 진행하시겠습니까?\r\n\n초기화를 진행하면 공정 사이클 시작/끝 조건이 초기화되며,\r\nKey Symbol은 공정 생성 시 자동/수동으로 포함되었던 Key Symbol의 상태로 되돌아갑니다.", "UDM Tracker", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dlgResult == DialogResult.Yes)
                {
                    m_cProcess.CycleEndConditionS.Clear();
                    //m_cProcess.StartCompareCondition = null;
                    m_cProcess.CycleStartConditionS.Clear();
                    //m_cProcess.EndCompareCondition = null;
                    m_cProcess.TargetTactTime = 60000;

                    grdProperty.SelectedObject = null;
                    grdProperty.SelectedObject = m_cProcess;
                    grdProperty.UpdateData();

                    btnRefresh.Enabled = true;
                    //cmbSelectView.Enabled = true;
                    //btnApply.Visible = true;
                    //btnRestore.Visible = false;
                    //btnTimeRangeApply.Enabled = true;
                    //dtpkFrom.Enabled = true;
                    //dtpkTo.Enabled = true;

                    SplashScreenManager.ShowDefaultWaitForm("Please Waiting...", "공정 정보를 초기화 하는 중입니다.");
                    {
                        //ChartView Tag를 Key Symbol로 Changeekgi0705

                        m_cProcess.KeySymbolS.Clear();
                        CKeySymbol cSymbol;
                        foreach (var who in m_cProcess.ChartViewTagS)
                        {
                            cSymbol = new CKeySymbol(who.Value);
                            m_cProcess.KeySymbolS.Add(who.Key, cSymbol);
                        }
                        m_cProcess.UpdateKeySymbolS();
                    }
                    SplashScreenManager.CloseDefaultWaitForm();

                    InitialData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (m_cProcess.CycleStartConditionS.Count == 0 || m_cProcess.CycleEndConditionS.Count == 0)
            {
                XtraMessageBox.Show("Cycle Start/End 조건을 먼저 설정하여야 합니다!!!", "Cycle Tag View", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            SetCycle(true);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = true;
            //cmbSelectView.Enabled = true;
            //btnApply.Visible = true;
            //btnRestore.Visible = false;
            //btnTimeRangeApply.Enabled = true;
            //dtpkFrom.Enabled = true;
            //dtpkTo.Enabled = true;

            cmbSelectView.SelectedIndex = -1;

            SetTimeRange();
            ucChart.Clear();

            cmbSelectView.SelectedIndex = 0;

            m_cProcess.CycleStartTimeLine = m_cCycleStartTimeLine.Time;
            m_cProcess.CycleEndTimeLine = m_cCycleEndTimeLine.Time;
            InitTimeLine();
            txtCycle.Text = "";

            //if (m_cProcess.CycleStartConditionS.Count == 0 || m_cProcess.CycleEndConditionS.Count == 0)
            //{
            //    XtraMessageBox.Show("Cycle Start/End 조건을 먼저 설정하여야 합니다!!!", "All Tag View", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    return;
            //}

            //SetCycle(false);
        }

        #endregion


        #region User Event

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {

        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

            //List<CTimeIndicator> clstTimeLine = ucChart.TimeLine.TimeIndicatorS.Where(b => b.TimeLineType == EMTimeLineType.Duration).ToList();
            //if (clstTimeLine.Count > 1)
            //    clstTimeLine.RemoveAt(0);

            //ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red, EMTimeLineType.Duration));
            //ucChart.TimeLine.UpdateLayout();



            //if (clstTimeLine.Count > 0)
            //    dtpkIndicator1.EditValue = (DateTime)clstTimeLine[0].Time;

            //if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
            //{
            //    dtpkIndicator2.EditValue = (DateTime)clstTimeLine[1].Time;

            //    TimeSpan tsSpan = clstTimeLine[1].Time.Subtract(clstTimeLine[0].Time);
            //    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
            //    txtInterval.Text = nInterval.ToString();
            //}
            //else
            //{
            //    txtInterval.Text = "0";
            //}
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            try
            {
                MouseEventArgs mouseEvent = (MouseEventArgs) e;
                if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    m_cDurationStartTimeLine.Time = cBar.StartTime;
                    m_cDurationEndTimeLine.Time = cBar.EndTime;

                    dtpkIndicator1.EditValue = (DateTime) m_cDurationStartTimeLine.Time;
                    dtpkIndicator2.EditValue = (DateTime) m_cDurationEndTimeLine.Time;

                    TimeSpan tsSpan = m_cDurationEndTimeLine.Time.Subtract(m_cDurationStartTimeLine.Time);
                    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                    txtInterval.Text = nInterval.ToString();

                    ucChart.TimeLine.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            try
            {
                if (cIndicator.TimeLineType == EMTimeLineType.Duration)
                {
                    dtpkIndicator1.EditValue = (DateTime) m_cDurationStartTimeLine.Time;
                    dtpkIndicator2.EditValue = (DateTime) m_cDurationEndTimeLine.Time;

                    TimeSpan tsSpan = m_cDurationEndTimeLine.Time.Subtract(m_cDurationStartTimeLine.Time);
                    double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                    txtInterval.Text = nInterval.ToString();
                }
                else
                {
                    m_cCycleStartTimeLine.Time = m_cProcess.CycleStartTimeLine;
                    m_cCycleEndTimeLine.Time = m_cProcess.CycleEndTimeLine;
                    ucChart.TimeLine.UpdateLayout();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        #endregion

        private void grvKeySymbolS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void mnuKeySymbolRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int[] iaRowIndex = grvKeySymbolS.GetSelectedRows();

                if (iaRowIndex != null && iaRowIndex.Length > 0)
                {
                    DialogResult dlgResult = XtraMessageBox.Show("선택하신 " + iaRowIndex.Length + "개의 Key Symbol을 제거하시겠습니까?", "Delete Key Symbol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dlgResult == DialogResult.No)
                        return;

                    ucChart.BeginUpdate();
                    {
                        for (int i = 0; i < iaRowIndex.Length; i++)
                        {
                            CKeySymbol cKeySymbol = (CKeySymbol) grvKeySymbolS.GetRow(iaRowIndex[i]);

                            if (m_cProcess.CycleStartConditionS.ContainsKey(cKeySymbol.Tag.Key))
                            {
                                XtraMessageBox.Show(string.Format("해당 Address : \'{0}\', Description : \'{1}\' Key Symbol은 Cycle Start 조건으로 사용되어 지울 수 없습니다.",
                                        cKeySymbol.Tag.Address, cKeySymbol.Tag.Description), "Remove Key Symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }
                            else if (m_cProcess.CycleEndConditionS.ContainsKey(cKeySymbol.Tag.Key))
                            {
                                XtraMessageBox.Show(string.Format("해당 Address : \'{0}\', Description : \'{1}\' Key Symbol은 Cycle End 조건으로 사용되어 지울 수 없습니다.",
                                        cKeySymbol.Tag.Address, cKeySymbol.Tag.Description), "Remove Key Symbol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                continue;
                            }

                            if (m_cProcess.KeySymbolS.ContainsKey(cKeySymbol.Tag.Key))
                            {
                                m_cProcess.KeySymbolS.Remove(cKeySymbol.Tag.Key);

                                if(m_cProcess.ChartViewTagS != null && m_cProcess.ChartViewTagS.ContainsKey(cKeySymbol.Tag.Key))
                                    m_cProcess.ChartViewTagS.Remove(cKeySymbol.TagKey);

                                CTag cTag = null;
                                foreach (CRowItem cItem in ucChart.GanttTree.ItemS)
                                {
                                    if (cItem.Data.GetType() == typeof (CTag))
                                    {
                                        cTag = (CTag) cItem.Data;

                                        if (cTag.Key == cKeySymbol.Tag.Key)
                                        {
                                            ucChart.GanttTree.ItemS.Remove(cItem);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    ucChart.EndUpdate();

                    grdKeySymbolS.DataSource = null;
                    grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
                    grvKeySymbolS.BestFitColumns();
                    grdKeySymbolS.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnTimeRangeApply_Click(object sender, EventArgs e)
        {
            cmbSelectView.SelectedIndex = -1;
            cmbSelectView.SelectedIndex = 0;
        }

        private void ucChart_Load(object sender, EventArgs e)
        {
            InitChart();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<CRowItem> lstSelectItem = ucChart.GanttTree.GetSelectedItemList();

                DialogResult dlgResult = XtraMessageBox.Show("선택하신 " + lstSelectItem.Count + "개의 Chart Item을 제거하시겠습니까?",
                    "Delete Chart Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlgResult == DialogResult.No)
                    return;

                ucChart.BeginUpdate();
                CTag cTag = null;
                foreach (CRowItem item in lstSelectItem)
                {
                    if (item.Data.GetType() == typeof (CTag))
                    {
                        cTag = (CTag) item.Data;

                        if (m_dicTagActiveTimeS.ContainsKey(cTag.Key))
                            m_dicTagActiveTimeS.Remove(cTag.Key);
                    }

                    ucChart.GanttTree.ItemS.Remove(item);
                }
                ucChart.EndUpdate();

                //grdKeySymbolS.DataSource = null;
                //grdKeySymbolS.DataSource = m_cProcess.KeySymbolS.Values.ToList();
                //grvKeySymbolS.BestFitColumns();
                //grdKeySymbolS.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process Setting Error : " + string.Format("Method : {0}, Message : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                ex.Data.Clear();
            }
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
            List<CRowItem> lstItem = ucChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void UCProcessSetting_Load(object sender, EventArgs e)
        {

        }

    }
}
