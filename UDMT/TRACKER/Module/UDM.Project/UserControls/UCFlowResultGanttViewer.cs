using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Log;
using UDM.Flow;
using UDM.UI.ExGanttChart;

namespace UDM.Project
{
    public partial class UCFlowResultGanttViewer : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public UCFlowResultGanttViewer()
        {
            InitializeComponent();
            
        }

        #endregion


        #region Public Properties

        public int UnitHeight
        {
            get { return ucGanttChart.UnitHeight; }
            set { ucGanttChart.UnitHeight = value; }
        }

        public int UnitWidth
        {
            get { return ucGanttChart.UnitWidth; }
            set { ucGanttChart.UnitWidth = value; }
        }

        public int OverViewHeight
        {
            get { return ucGanttChart.OverViewHeight; }
            set { ucGanttChart.OverViewHeight = value; }
        }

        public int BarHeight
        {
            get { return ucGanttChart.OverViewHeight; }
            set { ucGanttChart.OverViewHeight = value; }
        }

        #endregion


        #region Public Methods

        public void ShowChart(CFlowCompareResultS cResultS)
        {
            bool bOK = true;

            ucGanttChart.BeginUpdate();

            // Draw Group
            CGanttItem cGanttGroup = ucGanttChart.GetItemHasData(cResultS.Key);
            if (cGanttGroup == null)
            {
                cGanttGroup = new CGanttItem(cResultS.Key);
                cGanttGroup.CellTextS = new string[] { cResultS.Key };
				cGanttGroup.Data = cResultS.Key;
                bOK = ucGanttChart.AddItem(cGanttGroup);
                if (bOK == false)
                {
                    ucGanttChart.EndUpdate();
                    return;
                }
            }

            if (cResultS.FlowItemS == null)
                return;

			if (cResultS.MasterFlow != null)
				ShowMasterFlow(cGanttGroup, cResultS.MasterFlow, EMGanttBarType.BTask, true);

			if (cResultS.MasterFlow != null)
				ShowResult(cGanttGroup, cResultS, EMGanttBarType.FocusedBTask);

			ShowLog(cGanttGroup, cResultS.FlowItemS, EMGanttBarType.GTask);

			ucGanttChart.ExpandItem(cGanttGroup);

            ucGanttChart.EndUpdate();
        }

        public void Clear()
        {
            ucGanttChart.BeginUpdate();

            ucGanttChart.Clear();

            ucGanttChart.EndUpdate();
        }

        public void ZoomIn()
        {
            ucGanttChart.ZoomInWidth();
        }

        public void ZoomOut()
        {
            ucGanttChart.ZoomOutWidth();
        }

        public void ItemUp()
        {
            ucGanttChart.ItemUp();
        }

        public void ItemDown()
        {
            ucGanttChart.ItemDown();
        }


        #endregion


        #region Private Methods

        private void ShowMasterFlow(CGanttItem cGanttParent, CFlow cFlow, EMGanttBarType emBarType, bool bExpand)
        {
            if (cFlow == null || cFlow.FlowItemS.Count == 0)
                return;

            bool bOK = false;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            CGanttBarS cBarS;
            if (cFlow == null || cFlow.FlowItemS == null)
            {
                Console.WriteLine("UCFlowResultGanttViewer::ShowFlow FlowItem is Empty");
                return;
            }

            for (int i = 0; i < cFlow.FlowItemS.Count; i++)
            {
                cFlowItem = cFlow.FlowItemS[i];
				cGanttItem = ucGanttChart.GetChildItem(cGanttParent, cFlowItem.Key);
				if (cGanttItem == null)
				{
					cGanttItem = new CGanttItem(cFlowItem.Key);
					cGanttItem.BarType = emBarType;
					cGanttItem.CellTextS = new string[] { cFlowItem.Key, cFlowItem.Description };

					bOK = ucGanttChart.InsertItem(cGanttParent, cGanttItem);
					if (bOK == false)
						continue;
				}

				cGanttItem.OffSet = -6;

				cBarS = CreateBarS(cFlowItem, emBarType);
				ucGanttChart.AddBarS(cGanttItem, cBarS);

				if (cFlowItem.SubFlow != null)
					ShowMasterFlow(cGanttItem, cFlowItem.SubFlow, EMGanttBarType.LBTask, false);
            }

            // Draw BarLinkS
            CGanttLink cGanttLink;
            CFlowLink cLink;
            for (int i = 0; i < cFlow.FlowLinkS.Count; i++)
            {
                cLink = cFlow.FlowLinkS[i];
                cGanttLink = CreateBarLink(cGanttParent, cLink);
                cGanttLink.Text = cLink.Interval.ToString();
                ucGanttChart.AddLink(cGanttLink);
            }

            if (bExpand)
                ucGanttChart.ExpandItem(cGanttParent);

            ucGanttChart.FirstVisibleTime = cFlow.FlowItemS.First;
        }

        private void ShowLog(CGanttItem cGanttParent, CFlowItemS cFlowItemS, EMGanttBarType emBarType )
        {
            if(cFlowItemS == null || cFlowItemS.Count == 0)
                return;

            bool bOK = false;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            CGanttBarS cBarS;
            for (int i = 0; i < cFlowItemS.Count; i++)
            {   
                cFlowItem = cFlowItemS[i];

                cGanttItem = ucGanttChart.GetChildItem(cGanttParent, cFlowItem.Key);
                if (cGanttItem == null)
                {
                    cGanttItem = new CGanttItem(cFlowItem.Key);
					cGanttItem.BarType = emBarType;
                    cGanttItem.CellTextS = new string[] { cFlowItem.Key, cFlowItem.Description };
                    
                    bOK = ucGanttChart.InsertItem(cGanttParent, cGanttItem);
					if (bOK == false)
						continue;
                }

				cGanttItem.OffSet = 6;

				cBarS = CreateBarS(cFlowItem, emBarType);
				ucGanttChart.AddBarS(cGanttItem, cBarS);

				if (cFlowItem.SubFlow != null)
					ShowLog(cGanttItem, cFlowItem.SubFlow.FlowItemS, EMGanttBarType.GTask);
            }
        }

        private void ShowResult(CGanttItem cGanttParent, CFlowCompareResultS cResultS, EMGanttBarType emBarType)
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
                cGanttItem = ucGanttChart.GetChildItem(cGanttParent, cResult.Key);
                if(cGanttItem != null)
                {
                    for (int j = 0; j < cResult.Count; j++)
                    {
                        cResultUnit = cResult[j];
                        cNode = cResultUnit.TimeNode;
                        if (cNode != null)
                        {
                            cBar = ucGanttChart.GetBarHasData(cGanttItem, cNode);
                            if (cBar != null)
                            {
                                cBar.BarType = emBarType;
                                cBar.EdgeType = EMGanttEdgeType.Both;
                                ucGanttChart.UpdateBar(cBar);
                                ucGanttChart.AddNote(cBar, cResultUnit.DifferenceType.ToString(), 20, -50);
                            }

                            if (cResultUnit.DifferenceType == EMDifferenceType.Missing)
                            {
                                cGanttItem.OffSet = 6;

                                cBar = new CGanttBar();
                                cBar.BarType = EMGanttBarType.BlankTask;
                                cBar.Start = cNode.Start;
                                cBar.End = cNode.End;                                
                                ucGanttChart.AddBar(cGanttItem, cBar);
                            }
                        }
                    }

                    if (cResult.SubResultS != null && cResult.SubResultS.Count > 0)
                        ShowResult(cGanttItem, cResult.SubResultS, EMGanttBarType.FocusedLBTask);
                }
            }
        }        

        private CGanttBarS CreateBarS(CFlowItem cItem, EMGanttBarType emBarType)
        {
			if (cItem == null)
				return null;

			bool bCycleProcessItem = false;
			if (cItem.Key.StartsWith("[PRD]") || cItem.Key.StartsWith("[RCP]"))
				bCycleProcessItem = true;

            CGanttBarS cBarS = new CGanttBarS();
            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cItem.TimeNodeS.Count; i++)
            {
                cNode = cItem.TimeNodeS[i];
                cBar = CreateBar(cNode);

				if(bCycleProcessItem)
					cBar.BarType = EMGanttBarType.LGTask;
				else
					cBar.BarType = emBarType;

                if (cBar != null)
                    cBarS.Add(cBar);
            }

            return cBarS;
        }

        private CGanttBar CreateBar(CTimeNode cNode)
        {
            CGanttBar cBar = new CGanttBar();
            cBar.Start = cNode.Start;
            cBar.End = cNode.End;

            if (cNode.IsStart == false)
            {
                cBar.EdgeShapeType = EMGanttEdgeShapeType.FillArrowLeft;
                cBar.EdgeType = EMGanttEdgeType.Start;
            }

            if (cNode.IsEnd == false)
            {
                cBar.EdgeShapeType = EMGanttEdgeShapeType.FillArrowRight;
                cBar.EdgeType = EMGanttEdgeType.End;
            }

            cBar.Text = cNode.Text;
            cBar.Data = cNode;

            return cBar;
        }

        private CGanttLink CreateBarLink(CGanttItem cParentItem, CFlowLink cLink)
        {
            CGanttItem cGanttFrom = ucGanttChart.GetChildItem(cParentItem, cLink.NodeFrom.Key);
            CGanttItem cGanttTo = ucGanttChart.GetChildItem(cParentItem, cLink.NodeTo.Key);

            if (cGanttFrom == null || cGanttTo == null)
                return null;

            CGanttBar cBarFrom = ucGanttChart.GetBarHasData(cGanttFrom, cLink.NodeFrom);
            CGanttBar cBarTo = ucGanttChart.GetBarHasData(cGanttTo, cLink.NodeTo);

            if (cBarFrom == null || cBarTo == null)
                return null;

            CGanttLink cBarLink = new CGanttLink();
            cBarLink.BarFrom = cBarFrom;
            cBarLink.BarTo = cBarTo;
            cBarLink.Data = cLink;

            if (cLink.PointTypeFrom == EMLinkPointType.Start)
                cBarLink.PointTypeFrom = EMGanttPointType.Start;
            else
                cBarLink.PointTypeFrom = EMGanttPointType.End;

            if (cLink.PointTypeTo == EMLinkPointType.Start)
                cBarLink.PointTypeTo = EMGanttPointType.Start;
            else
                cBarLink.PointTypeTo = EMGanttPointType.End;

            return cBarLink;
        }

        #endregion


        #region Event Methods

        private void UCPatternResultGanttViewer_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
