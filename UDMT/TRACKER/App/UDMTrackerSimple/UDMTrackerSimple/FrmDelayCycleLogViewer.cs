using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;
using UDM.UI.TimeChart;

namespace UDMTrackerSimple
{
    public partial class FrmDelayCycleLogViewer : DevExpress.XtraEditors.XtraForm
    {
        private CCycleInfo m_cCycleInfo = null;
        private CMySqlLogReader m_cReader = null;

        public FrmDelayCycleLogViewer()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        public CCycleInfo CycleInfo
        {
            get { return m_cCycleInfo; }
            set { m_cCycleInfo = value; }
        }

        private void InitTimeRange()
        {
            dtpkFrom.EditValue = m_cCycleInfo.CycleStart;
            dtpkTo.EditValue = m_cCycleInfo.CycleEnd;
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

        private void ShowAnalysisResult(CCycleInfo cCycleInfo)
        {
            ucChart.GanttTree.ItemS.Clear();

            CPlcProc cProcess = CMultiProject.PlcProcS[cCycleInfo.GroupKey];

            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cProcess.Name, cProcess.KeySymbolS, cCycleInfo, false);
            if (cItemS == null || cItemS.Count == 0)
                return;

            CFlowCompareResultS cResultS = CMultiProject.MasterPatternS.Compare(cProcess.Name, cCycleInfo.CurrentRecipe, cItemS, false);
            if (cResultS == null)
            {
                cResultS = new CFlowCompareResultS();
                cResultS.FlowItemS = cItemS;
            }

            cResultS.Key = cProcess.Name;
            if (cResultS.MasterFlow != null)
                cResultS.MasterFlow.Normalize(cCycleInfo.CycleStart);

            ShowFlowCompareResultChart(cProcess.Name, cCycleInfo, cResultS);
        }

        private void ShowFlowCompareResultChart(string sGroup, CCycleInfo cCycleInfo, CFlowCompareResultS cResultS)
        {
            ucChart.BeginUpdate();
            {
                //Draw Group
                CGanttItem cGanttGroup = (CGanttItem)ucChart.GanttTree.ItemS.FindHasData(sGroup);
                if (cGanttGroup == null)
                {
                    cGanttGroup = new CGanttItem(new string[] { sGroup, "" });
                    cGanttGroup.Data = sGroup;
                    ucChart.GanttTree.ItemS.Add(cGanttGroup);
                }

                cGanttGroup.BarS.Clear();
                CGanttBar cBar = new CGanttBar();
                cBar.StartTime = cCycleInfo.CycleStart;
                cBar.EndTime = cCycleInfo.CycleEnd;
                cBar.Data = cCycleInfo;
                cBar.Color = Color.Red;
                cGanttGroup.BarS.Add(cBar);

                if (cResultS.FlowItemS == null)
                    return;

                if (cResultS.MasterFlow != null)
                {
                    ShowMasterFlow(cGanttGroup, cResultS.MasterFlow, Color.DodgerBlue, false);
                    ShowResult(cGanttGroup, cResultS, Color.Gold);
                }

                ShowLog(cGanttGroup, cResultS.FlowItemS, Color.LawnGreen);

                cGanttGroup.Expand();

                UpdateTimeRange(cResultS.MasterFlow);
            }
            ucChart.EndUpdate();
        }

        private void ShowMasterFlow(CGanttItem cGanttParent, CFlow cFlow, Color cColor, bool bExpand)
        {
            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            List<CGanttBar> lstBar;
            for (int i = 0; i < cFlow.FlowItemS.Count; i++)
            {
                cFlowItem = cFlow.FlowItemS[i];

                cGanttItem = new CGanttItem(new object[] { cFlowItem.Key, cFlowItem.Description });
                cGanttItem.Data = cFlowItem.Key;
                cGanttParent.ItemS.Add(cGanttItem);

                lstBar = CreateBarList(cFlowItem, cColor, false);
                cGanttItem.BarS.AddRange(lstBar);
                lstBar.Clear();

                if (cFlowItem.SubFlow != null)
                    ShowMasterFlow(cGanttItem, cFlowItem.SubFlow, Color.LightBlue, false);
            }

            // Draw BarLinkS
            CGanttLink cGanttLink;
            CFlowLink cLink;
            for (int i = 0; i < cFlow.FlowLinkS.Count; i++)
            {
                cLink = cFlow.FlowLinkS[i];
                cGanttLink = CreateBarLink(cGanttParent, cLink);
                cGanttLink.Text = cLink.Interval.ToString();
                ucChart.GanttTree.LinkS.Add(cGanttLink);
            }

            if (bExpand)
                cGanttParent.Expand();
        }

        private void ShowResult(CGanttItem cGanttParent, CFlowCompareResultS cResultS, Color cColor)
        {
            if (cResultS == null)
                return;

            CGanttItem cGanttItem;
            CGanttBar cBar;
            CTimeNode cNode;
            CFlowCompareResult cResult;
            CFlowCompareResultUnit cResultUnit;

            for (int i = 0; i < cResultS.Count; i++)
            {
                cResult = cResultS[i];
                cGanttItem = (CGanttItem)cGanttParent.ItemS.FindHasData(cResult.Key);
                if (cGanttItem != null)
                {
                    for (int j = 0; j < cResult.Count; j++)
                    {
                        cResultUnit = cResult[j];
                        cNode = cResultUnit.TimeNode;
                        if (cNode != null)
                        {
                            //cBar = (CGanttBar) cGanttItem.BarS.FindHasData(cNode);

                            if (cResultUnit.DifferenceType == EMDifferenceType.Missing)
                            {
                                cBar = new CGanttBar();
                                cBar.StartTime = cNode.Start;
                                cBar.EndTime = cNode.End;
                                cBar.OffSet = -4;
                                cBar.Height = 6;
                                cBar.Color = cColor;
                                cGanttItem.BarS.Add(cBar);
                            }
                        }
                    }

                    if (cResult.SubResultS != null && cResult.SubResultS.Count > 0)
                        ShowResult(cGanttItem, cResult.SubResultS, Color.Gold);
                }
            }

        }

        private void ShowLog(CGanttItem cGanttParent, CFlowItemS cFlowItemS, Color cColor)
        {
            if (cFlowItemS == null || cFlowItemS.Count == 0)
                return;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            List<CGanttBar> lstBar;

            for (int i = 0; i < cFlowItemS.Count; i++)
            {
                cFlowItem = cFlowItemS[i];

                cGanttItem = (CGanttItem)cGanttParent.ItemS.FindHasData(cFlowItem.Key);

                if (cGanttItem == null)
                {
                    cGanttItem = new CGanttItem(new object[] { cFlowItem.Key, cFlowItem.Description });
                    cGanttItem.Data = cFlowItem.Key;
                    cGanttParent.ItemS.Add(cGanttItem);
                }

                lstBar = CreateBarList(cFlowItem, cColor, true);
                cGanttItem.BarS.AddRange(lstBar);
                lstBar.Clear();

                if (cFlowItem.SubFlow != null)
                    ShowLog(cGanttItem, cFlowItem.SubFlow.FlowItemS, cColor);
            }
        }

        private List<CGanttBar> CreateBarList(CFlowItem cItem, Color cColor, bool bPositiveOffset)
        {
            List<CGanttBar> lstBar = new List<CGanttBar>();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cItem.TimeNodeS.Count; i++)
            {
                cNode = cItem.TimeNodeS[i];
                cBar = CreateBar(cNode, cColor);

                if (bPositiveOffset)
                    cBar.OffSet = 3;
                else
                    cBar.OffSet = -3;

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
            cBar.Height = 6;

            return cBar;
        }

        private CGanttLink CreateBarLink(CGanttItem cParentItem, CFlowLink cLink)
        {
            CGanttItem cGanttFrom = (CGanttItem)cParentItem.ItemS.Find(0, cLink.NodeFrom.Key);
            CGanttItem cGanttTo = (CGanttItem)cParentItem.ItemS.Find(0, cLink.NodeTo.Key);

            if (cGanttFrom == null || cGanttTo == null)
                return null;

            CGanttBar cBarFrom = cGanttFrom.BarS.FindHasData(cLink.NodeFrom);
            CGanttBar cBarTo = cGanttTo.BarS.FindHasData(cLink.NodeTo);

            if (cBarFrom == null || cBarTo == null)
                return null;

            CGanttLink cBarLink = new CGanttLink();
            cBarLink.BarFrom = cBarFrom;
            cBarLink.BarTo = cBarTo;
            cBarLink.Data = cLink;

            if (cLink.PointTypeFrom == EMLinkPointType.Start)
                cBarLink.PointTypeFrom = EMGanttLinkPointType.Start;
            else
                cBarLink.PointTypeFrom = EMGanttLinkPointType.End;

            if (cLink.PointTypeTo == EMLinkPointType.Start)
                cBarLink.PointTypeTo = EMGanttLinkPointType.Start;
            else
                cBarLink.PointTypeTo = EMGanttLinkPointType.End;

            return cBarLink;
        }

        private void UpdateTimeRange(CFlow cFlow)
        {
            ucChart.TimeLine.FirstVisibleTime = cFlow.First;
            ucChart.TimeLine.RangeFrom = cFlow.First;
            if (cFlow.Last > ucChart.TimeLine.RangeTo)
                ucChart.TimeLine.RangeTo = cFlow.Last;

            //dtpkFrom.EditValue = ucChart.TimeLine.RangeFrom;
            //dtpkTo.EditValue = ucChart.TimeLine.RangeTo;
        }

        private void FrmDelayCycleLogViewer_Load(object sender, EventArgs e)
        {
            if (m_cCycleInfo == null)
                return;

            InitTimeRange();
            InitChart();
            ShowAnalysisResult(m_cCycleInfo);
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

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}