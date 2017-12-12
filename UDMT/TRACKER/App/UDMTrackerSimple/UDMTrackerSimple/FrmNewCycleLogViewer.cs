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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

namespace UDMTrackerSimple
{
    public partial class FrmNewCycleLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Varialbes

        private string m_sGroup = "";
        private bool m_bVerified = false;
        private CGanttItem m_cGanttGroup = null;
        private CMySqlLogReader m_cReader = null;
        protected CPlcProc m_cProcess = null;

        #endregion


        #region Initialize/Dispose

        public FrmNewCycleLogViewer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void Clear()
        {
            ucChart.Clear();
            ucChart.GanttTree.ColumnS.Clear();

            InitInterval();
            InitChart();
        }

        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(CMultiProject.PlcProcS.Count == 0)
            {
                MessageBox.Show("Process is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void InitInterval()
        {
            txtInterval.Text = "";
            dtpkIndicator1.EditValue = "00:00:00.000";
            dtpkIndicator2.EditValue = "00:00:00.000";
        }
        private void InitComponent()
        {
            DateTime dtLast = m_cReader.GetLastTimeLogTime();

            if (dtLast == DateTime.MinValue)
            {
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;

                m_bVerified = false;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-10);
                dtpkTo.EditValue = (DateTime)dtLast;
            }
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

            ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
            ucChart.TimeLine.UEventTimeIndicatorMoved += TimeLine_UEventTimeIndicatorMoved;
            ucChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
            ucChart.GanttChart.UEventBarClicked += GanttChart_UEventBarClicked;
            ucChart.GanttChart.MouseDown += GanttChart_MouseDown;

            ucChart.GanttChart.ContextMenuStrip = cntxCycle;
        }

        private void ShowGroupList()
        {   
            cmbGroup.EditValue = null;
            exEditorGroup.Items.Clear();

            string sProcess;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                if (CMultiProject.PlcProcS.ElementAt(i).Value.IsErrorMonitoring)
                    continue;

                sProcess = CMultiProject.PlcProcS.ElementAt(i).Key;
                exEditorGroup.Items.Add(sProcess);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private CTagS GetSortTagS(CTagS cTagS, CCycleInfo cInfo)
        {
            CTagS cSortTagS = new CTagS();

            CTimeLogS cLogS = CMultiProject.LogReader.GetTimeLogS(cTagS.Keys.ToList(), cInfo.CycleStart, cInfo.CycleEnd);

            if (cLogS == null || cLogS.Count == 0)
                return null;

            CTimeLogS cOnLogS = new CTimeLogS();

            foreach (var who in cTagS)
            {
                CTimeLogS cSumLogS = cLogS.GetTimeLogS(who.Key, 1);
                if (cSumLogS != null && cSumLogS.Count > 0)
                    cOnLogS.AddRange(cSumLogS);
            }

            cOnLogS.Sort();

            foreach (var who in cOnLogS)
            {
                if (CMultiProject.PlcProcS[m_sGroup].ChartViewTagS.ContainsKey(who.Key))
                    cSortTagS.Add(CMultiProject.PlcProcS[m_sGroup].ChartViewTagS[who.Key]);
            }

            return cSortTagS;
        }

        private void ShowGanttChart(CTagS cTagS, DateTime dtFrom, DateTime dtTo, Color color)
        {
            DateTime dtFirstVisible = DateTime.MinValue;
            CGanttItem cItem = null;
            List<CGanttBar> lstBar = null;
            CTimeNodeS cNodeS = null;
            CTimeLogS cLogS = null;
            bool bShowBarText = false;
            bool bFirst = true;

            try
            {
                CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, m_sGroup, dtFrom, dtTo);

                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                    return;

                CTagS cSortTagS = GetSortTagS(cTagS, cCycleInfoS.First().Value);

                InitInterval();
                ucChart.GanttTree.ItemS.Clear();
                ucChart.Clear();
                ucChart.BeginUpdate();

                CreateMasterGanttItem(dtFrom, dtTo);

                foreach (CTag cTag in cSortTagS.Values)
                {
                    cItem = CreateGanttItem(cTag);
                    cLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, dtFrom, dtTo);

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

                    lstBar = CreateBarList(cNodeS, Color.DodgerBlue, bShowBarText);
                    cItem.BarS.AddRange(lstBar);
                    //ucChart.GanttTree.ItemS.Add(cItem);
                    m_cGanttGroup.ItemS.Add(cItem);
                    m_cGanttGroup.Expand();

                    lstBar.Clear();
                    lstBar = null;
                }

                ucChart.TimeLine.RangeFrom = dtFrom;
                ucChart.TimeLine.RangeTo = dtTo;


                if (dtFirstVisible != DateTime.MinValue)
                    ucChart.TimeLine.FirstVisibleTime = dtFirstVisible;
                else
                    ucChart.TimeLine.FirstVisibleTime = dtFrom;

                ucChart.EndUpdate();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void CreateMasterGanttItem(DateTime dtFrom, DateTime dtTo)
        {
            CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, m_sGroup, dtFrom, dtTo);

            m_cGanttGroup = (CGanttItem)ucChart.GanttTree.ItemS.FindHasData(m_sGroup);
            if (m_cGanttGroup == null)
            {
                m_cGanttGroup = new CGanttItem(new string[] { m_sGroup, "" });
                m_cGanttGroup.Data = m_sGroup;
                ucChart.GanttTree.ItemS.Add(m_cGanttGroup);
            }

            m_cGanttGroup.BarS.Clear();

            foreach (CCycleInfo cCycleInfo in cCycleInfoS.Values)
            {
                CGanttBar cBar = new CGanttBar();
                cBar.StartTime = cCycleInfo.CycleStart;
                cBar.EndTime = cCycleInfo.CycleEnd;
                cBar.Data = cCycleInfo;
                cBar.Color = Color.Red;
                m_cGanttGroup.BarS.Add(cBar);
            }
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

        private CGanttItem CreateGanttItem(CTag cTag)
        {
            CGanttItem cItem = new CGanttItem(new object[] { cTag.Address, cTag.Description });
            cItem.Data = cTag;

            return cItem;
        }
        #endregion


        #region Event Methods

        private void FrmNewCycleLogViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                this.Close();

            InitComponent();
            InitChart();
            ShowGroupList();
        }

		private void btnShowCycleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (m_bVerified == false)
				return;
            
		    if (cmbGroup.EditValue == null)
		        return;

            m_sGroup = cmbGroup.EditValue.ToString();
			DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;

            if(CMultiProject.PlcProcS[m_sGroup].KeySymbolS.Count == 0)
            {
                MessageBox.Show("Master Pattern Data is not Created.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
                return;
            }

            CTagS cKeyTags = CMultiProject.PlcProcS[m_sGroup].KeySymbolS.GetTagS();

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            ShowGanttChart(cKeyTags, dtFrom, dtTo, Color.DodgerBlue);
            SplashScreenManager.CloseForm(false);
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

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (mouseEvent.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (cBar.Color == Color.Red)
                {
                    toolTipConMasterBar.HideHint();

                    string sTooltip = "";

                    CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, m_sGroup, cBar.StartTime, cBar.EndTime);

                    foreach (CCycleInfo cCycleInfo in cCycleInfoS.Values)
                    {
                        sTooltip = "Process : " + cCycleInfo.GroupKey + "\r\n" +
                                "CycleID : " + cCycleInfo.CycleID + "\r\n" +
                                "State : " + cCycleInfo.CycleType + "\r\n" +
                                "Cycle Start : " + cCycleInfo.CycleStart + "\r\n" +
                                "Cycle End : " + cCycleInfo.CycleEnd + "\r\n" +
                                "Recipe : " + cCycleInfo.CurrentRecipe;
                    }
                    toolTipConMasterBar.SetToolTip(ucChart, "Cycle Info");
                    toolTipConMasterBar.ShowHint(sTooltip, "Cycle Info");
                }
            }
        }


        private void mnuCycleStart_Click(object sender, EventArgs e)
        {
            if (ucChart.GanttChart.FocusedBar == null) return;

            if (ucChart.TimeLine.TimeIndicatorS.Count == 0)
            {
                ucChart.TimeLine.TimeIndicatorS.Clear();
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(ucChart.GanttChart.FocusedBar.StartTime, Color.Red));
                ucChart.TimeLine.UpdateLayout();

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;

            }
            else
            {
                if (ucChart.TimeLine.TimeIndicatorS.Count == 2)
                {
                    DateTime dtStart = ucChart.GanttChart.FocusedBar.StartTime;

                    if (dtStart > ucChart.TimeLine.TimeIndicatorS[0].Time &&
                        dtStart < ucChart.TimeLine.TimeIndicatorS[1].Time)
                        ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);
                    else if (dtStart > ucChart.TimeLine.TimeIndicatorS[1].Time &&
                    dtStart < ucChart.TimeLine.TimeIndicatorS[0].Time)
                        ucChart.TimeLine.TimeIndicatorS.RemoveAt(1);
                    else
                    {
                        double dDuration1 =
                            Math.Abs(ucChart.TimeLine.TimeIndicatorS[0].Time.Subtract(dtStart).TotalMilliseconds);
                        double dDuration2 =
                            Math.Abs(ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(dtStart).TotalMilliseconds);

                        if (dDuration1 <= dDuration2)
                            ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);
                        else
                            ucChart.TimeLine.TimeIndicatorS.RemoveAt(1);
                    }
                }

                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(ucChart.GanttChart.FocusedBar.StartTime, Color.Red));
                ucChart.TimeLine.UpdateLayout();

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

        private void mnuCycleEnd_Click(object sender, EventArgs e)
        {
            if (ucChart.GanttChart.FocusedBar == null) return;

            if (ucChart.TimeLine.TimeIndicatorS.Count == 0)
            {
                ucChart.TimeLine.TimeIndicatorS.Clear();
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(ucChart.GanttChart.FocusedBar.EndTime, Color.Red));
                ucChart.TimeLine.UpdateLayout();

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;

            }
            else
            {
                if (ucChart.TimeLine.TimeIndicatorS.Count == 2)
                {
                    DateTime dtEnd = ucChart.GanttChart.FocusedBar.EndTime;

                    if (dtEnd > ucChart.TimeLine.TimeIndicatorS[0].Time &&
                        dtEnd < ucChart.TimeLine.TimeIndicatorS[1].Time)
                        ucChart.TimeLine.TimeIndicatorS.RemoveAt(1);
                    else if (dtEnd > ucChart.TimeLine.TimeIndicatorS[1].Time && dtEnd < ucChart.TimeLine.TimeIndicatorS[0].Time)
                        ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);
                    else
                    {
                        double dDuration1 =
                            Math.Abs(ucChart.TimeLine.TimeIndicatorS[0].Time.Subtract(dtEnd).TotalMilliseconds);
                        double dDuration2 =
                            Math.Abs(ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(dtEnd).TotalMilliseconds);

                        if (dDuration1 <= dDuration2)
                            ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);
                        else
                            ucChart.TimeLine.TimeIndicatorS.RemoveAt(1);
                    }
                }
                ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(ucChart.GanttChart.FocusedBar.EndTime, Color.Red));
                ucChart.TimeLine.UpdateLayout();

                dtpkIndicator1.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }
        void GanttChart_MouseDown(object sender, MouseEventArgs e)
        {
            toolTipConMasterBar.HideHint();
        }
        #endregion
    }
}