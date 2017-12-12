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

namespace UDMTrackerSimple
{
    public partial class FrmCycleLogViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Varialbes

        private bool m_bVerified = false;
        private int m_iSplitChartPos = 0;
        private CMySqlLogReader m_cReader = null;

        #endregion


        #region Initialize/Dispose

        public FrmCycleLogViewer()
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
            ucProcessLogTable.Clear();
            InitChart();
        }

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

                m_bVerified = false;
            }
            else
            {
                dtpkFrom.EditValue = (DateTime)dtLast.AddMinutes(-30);
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
        }

        private void ShowGroupList()
        {   
            cmbGroup.EditValue = null;
            exEditorGroup.Items.Clear();

            string sProcess;
            for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
            {
                sProcess = CMultiProject.PlcProcS.ElementAt(i).Key;
                exEditorGroup.Items.Add(sProcess);
            }

            if (exEditorGroup.Items.Count > 0)
                cmbGroup.EditValue = exEditorGroup.Items[0];
        }

        private void ShowRecipeWord(string sProcess)
        {
            ucRecipeView.Clear();

            CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
            ucRecipeView.SetRecipeWord(cProcess.RecipeWordS);
        }

        private void ShowRecipeInformation(CCycleInfo cInfo)
        {
            CPlcProc cProcess = CMultiProject.PlcProcS[cInfo.GroupKey];
            CTimeLogS cLogS = m_cReader.GetTimeLogS(cProcess.RecipeWordS.Keys.ToList(), cInfo.CycleStart, cInfo.CycleEnd);

            ucRecipeView.SetRecipeInformation(cLogS);
        }

        private void ShowGroupLogTable(string sProcess, DateTime dtFrom, DateTime dtTo)
        {
            ucProcessLogTable.Clear();

            CCycleInfoS cLogS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, sProcess, dtFrom, dtTo);

            if (cLogS == null || cLogS.Count == 0)
                return;

            ucProcessLogTable.CycleInfoS = cLogS;
            ucProcessLogTable.ShowTable();
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

                if(cResultS.MasterFlow != null)
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
                                cBar.OffSet = 4;
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


        #endregion


        #region Event Methods

        private void FrmCycleLogViewer_Load(object sender, EventArgs e)
        {
            try
            {
                m_bVerified = VerifyParameter();
                if (m_bVerified == false)
                    return;

                InitComponent();
                InitChart();
                ShowGroupList();

                ucChart.TimeLine.MouseDoubleClick += TimeLine_MouseDoubleClick;
                pnlRecipe.Height = 205;
                m_iSplitChartPos = sptChart.SplitterPosition;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog("FrmCycleLogViewer",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));
                ex.Data.Clear();
            }
        }

		private void btnShowCycleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			if (m_bVerified == false)
				return;

		    if (cmbGroup.EditValue == null)
		        return;

			string sGroup = cmbGroup.EditValue.ToString();
			DateTime dtFrom = (DateTime)dtpkFrom.EditValue;
			DateTime dtTo = (DateTime)dtpkTo.EditValue;

			ShowGroupLogTable(sGroup, dtFrom, dtTo);
            ShowRecipeWord(sGroup);
		}

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_bVerified == false)
                return;

            Clear();
            ucRecipeView.Clear();
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

        private void ucProcessLogTable_UEventRowDoubleClicked(object sender, CCycleInfo cCycleInfo)
        {
            if (m_bVerified == false)
                return;

            CShowWaitForm.ShowForm("Cycle Open", string.Format("Process : {1}, Cycle {0}", cCycleInfo.CycleID,cCycleInfo.GroupKey), "Start...", true);
            {
                ShowRecipeInformation(cCycleInfo);
                ShowAnalysisResult(cCycleInfo);
            }
            CShowWaitForm.CloseForm();
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucChart.TimeLine.CalcTime(e.X);

            if (ucChart.TimeLine.TimeIndicatorS.Count > 1)
                ucChart.TimeLine.TimeIndicatorS.RemoveAt(0);

            ucChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucChart.TimeLine.UpdateLayout();
        }

        #endregion

        private void FrmCycleLogViewer_Resize(object sender, EventArgs e)
        {
            pnlRecipe.Height = 205;
        }

        private void sptChart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptChart.SplitterPosition > 0)
            {
                m_iSplitChartPos = sptChart.SplitterPosition;
                sptChart.SplitterPosition = 0;
            }
            else
            {
                sptChart.SplitterPosition = m_iSplitChartPos;
            }
        }

    }
}