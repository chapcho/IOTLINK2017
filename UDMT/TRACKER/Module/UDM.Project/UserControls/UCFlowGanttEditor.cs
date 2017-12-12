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
    public partial class UCFlowGanttEditor : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public UCFlowGanttEditor()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        int UnitHeight
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

        public void ShowChart(string sGroup, string sRecipe, int iIndex, CFlow cFlow)
        {
            bool bOK = false;

            ucGanttChart.BeginUpdate();

            // Draw Group
            CGanttItem cGanttGroup = ucGanttChart.GetItemHasData(sGroup);
            if (cGanttGroup == null)
            {
                cGanttGroup = new CGanttItem(sGroup);
                cGanttGroup.Data = sGroup;
                cGanttGroup.CellTextS = new string[] { sGroup };

                bOK = ucGanttChart.AddItem(cGanttGroup);
                if (bOK == false)
                {
                    ucGanttChart.EndUpdate();
                    return;
                }
            }

            // Draw Recipe
            CGanttItem cGanttRecipe = ucGanttChart.GetChildItemHasData(cGanttGroup, sRecipe);
            if(cGanttRecipe == null)
            {
                cGanttRecipe = new CGanttItem(sRecipe);
                cGanttRecipe.Data = sRecipe;
                cGanttRecipe.CellTextS = new string[] { sRecipe };

                bOK = ucGanttChart.InsertItem(cGanttGroup, cGanttRecipe);
                if(bOK == false)
                {
                    ucGanttChart.EndUpdate();
                    return;
                }
            }

            // Draw Index
            CGanttItem cGanttIndex = ucGanttChart.GetChildItemHasData(cGanttRecipe, cFlow);
            if (cGanttIndex == null)
            {
                cGanttIndex = new CGanttItem(iIndex.ToString());
                cGanttIndex.Data = cFlow;
                cGanttIndex.CellTextS = new string[] { iIndex.ToString() };

                bOK = ucGanttChart.InsertItem(cGanttRecipe, cGanttIndex);
                if (bOK == false)
                {
                    ucGanttChart.EndUpdate();
                    return;
                }
            }
            else
            {
                ucGanttChart.EndUpdate();
                return;
            }

            ShowFlow(cGanttIndex, cFlow, EMGanttBarType.BTask, true);
            
            ucGanttChart.ExpandItem(cGanttIndex);
            ucGanttChart.ExpandItem(cGanttRecipe);
            ucGanttChart.ExpandItem(cGanttGroup);

            ucGanttChart.EndUpdate();
        }

        public CGanttItemS GetSelectedItemS()
        {
            CGanttItemS cItemS = ucGanttChart.GetSelectedItemS();
            if (cItemS == null)
                return null;

            return cItemS;
        }

        public CGanttItem GetParentItem(CGanttItem cItem)
        {
            return ucGanttChart.GetParentItem(cItem);
        }

        public void RemoveItem(CGanttItem cItem)
        {
            if (cItem.Data == null)
                return;

            ucGanttChart.RemoveItem(cItem);
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

        private void ShowFlow(CGanttItem cGanttParent, CFlow cFlow, EMGanttBarType emBarType, bool bExpand)
        {
            bool bOK = false;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            CGanttBarS cBarS;
            for (int i = 0; i < cFlow.FlowItemS.Count; i++)
            {
                cFlowItem = cFlow.FlowItemS[i];

                cGanttItem = new CGanttItem(cFlowItem.Key);
                cGanttItem.IsBarAddable = true;
                cGanttItem.BarType = emBarType;
                cGanttItem.Data = cFlowItem;
                cGanttItem.CellTextS = new string[] { cFlowItem.Key, cFlowItem.Description };

                bOK = ucGanttChart.InsertItem(cGanttParent, cGanttItem);
                if (bOK)
                {
                    cBarS = CreateBarS(cFlowItem, emBarType);
                    ucGanttChart.AddBarS(cGanttItem, cBarS);

                    if (cFlowItem.SubFlow != null)
                        ShowFlow(cGanttItem, cFlowItem.SubFlow, EMGanttBarType.LBTask, false);
                }
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

            if(bExpand)
                ucGanttChart.ExpandItem(cGanttParent);

            ucGanttChart.FirstVisibleTime = cFlow.FlowItemS.First;
        }

        private CGanttBarS CreateBarS(CFlowItem cItem, EMGanttBarType emBarType)
        {
            CGanttBarS cBarS = new CGanttBarS();

            CGanttBar cBar;
            CTimeNode cNode;
            for (int i = 0; i < cItem.TimeNodeS.Count; i++)
            {
                cNode = cItem.TimeNodeS[i];
                cBar = CreateBar(cNode);
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

        private CTimeNode CreateNode(string sKey, CGanttBar cBar)
        {
            CTimeNode cNode = new CTimeNode();
            cNode.Key = sKey;
            cNode.Start = cBar.Start;
            cNode.End = cBar.End;
            cBar.Data = cNode;
            
            return cNode;
        }

        private CFlowLink CreateLink(CGanttLink cBarLink)
        {
            CFlowLink cLink = new CFlowLink();
            cLink.NodeFrom = (CTimeNode)cBarLink.BarFrom.Data;
            cLink.NodeTo = (CTimeNode)cBarLink.BarTo.Data;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;

            if (cBarLink.PointTypeFrom == EMGanttPointType.Start)
            {
                cLink.PointTypeFrom = EMLinkPointType.Start;
                dtFrom = cLink.NodeFrom.Start;
            }
            else
            {
                cLink.PointTypeFrom = EMLinkPointType.End;
                dtFrom = cLink.NodeFrom.End;
            }

            if (cBarLink.PointTypeTo == EMGanttPointType.Start)
            {
                cLink.PointTypeTo = EMLinkPointType.Start;
                dtTo = cLink.NodeTo.Start;
            }
            else
            {
                cLink.PointTypeTo = EMLinkPointType.End;
                dtTo = cLink.NodeTo.End;
            }

            cLink.Interval = dtTo.Subtract(dtFrom).TotalMilliseconds;
            cBarLink.Data = cLink;

            return cLink;
        }

        #endregion


        #region Event Methods

        private void UCPatternGanttEditor_Load(object sender, EventArgs e)
        {
            ucGanttChart.UEventBarCreated += new UEventHandlerGanttBarCreated(ucGanttChart_UEventBarCreated);
            ucGanttChart.UEventBarRemoved += new UEventHandlerGanttBarRemoved(ucGanttChart_UEventBarRemoved);
            ucGanttChart.UEventBarTimeChanged += new UEventHandlerGanttBarTimeChanged(ucGanttChart_UEventBarTimeChanged);
            ucGanttChart.UEventLinkCreated += new UEventHandlerGanttLinkCreated(ucGanttChart_UEventLinkCreated);
            ucGanttChart.UEventLinkRemoved += new UEventHandlerGanttLinkRemoved(ucGanttChart_UEventLinkRemoved);
            ucGanttChart.UEventLinkUpdated += new UEventHandlerGanttLinkUpdated(ucGanttChart_UEventLinkUpdated);
        }

        private void ucGanttChart_UEventBarCreated(object sender, CGanttBar cBar)
        {
            CGanttItem cItem = ucGanttChart.GetItem(cBar);
            if (cItem == null || cItem.Data == null)
                return;

            CGanttItem cItemParent = ucGanttChart.GetParentItem(cItem);
            if (cItemParent == null || cItemParent.Data == null)
                return;

            if(cItemParent.Data.GetType() == typeof(CFlowItem))
            {
                cBar.BarType = EMGanttBarType.LBTask;
                ucGanttChart.UpdateBar(cBar);
            }

            CFlowItem cFlowItem = (CFlowItem)cItem.Data;
            CTimeNode cNode = CreateNode(cFlowItem.Key, cBar);
            cFlowItem.TimeNodeS.Add(cNode);
        }

        private void ucGanttChart_UEventBarRemoved(object sender, CGanttBar cBar)
        {
            CGanttItem cItem = ucGanttChart.GetItem(cBar);
            if (cItem == null || cItem.Data == null)
                return;
            
            CFlowItem cFlowItem = (CFlowItem)cItem.Data;
            CTimeNode cNode = (CTimeNode)cBar.Data;
            cFlowItem.TimeNodeS.Remove(cNode);
        }

        private void ucGanttChart_UEventBarTimeChanged(object sender, CGanttBar cBar)
        {
            CGanttItem cItem = ucGanttChart.GetItem(cBar);
            if (cItem == null)
                return;

            CTimeNode cNode = (CTimeNode)cBar.Data;
            cNode.Start = cBar.Start;
            cNode.End = cBar.End;
        }

        private void ucGanttChart_UEventLinkCreated(object sender, CGanttLink cBarLink)
        {
            CGanttItem cGanttFrom = ucGanttChart.GetItem(cBarLink.BarFrom);
            if (cGanttFrom == null)
                return;

            CGanttItem cGanttTo = ucGanttChart.GetItem(cBarLink.BarTo);
            if (cGanttTo == null)
                return;

            CGanttItem cGanttFromParent = ucGanttChart.GetParentItem(cGanttFrom);
            if (cGanttFromParent.Data == null || cGanttFromParent.Data.GetType() != typeof(CFlow))
                return;

            CGanttItem cGanttToParent = ucGanttChart.GetParentItem(cGanttTo);
            if (cGanttToParent.Data == null || cGanttToParent.Data.GetType() != typeof(CFlow))
                return;

            if (cGanttFromParent.Data != cGanttToParent.Data)
                return;

            CGanttItem cGanttFlow = ucGanttChart.GetParentItem(cGanttFrom);
            if (cGanttFlow == null)
                return;

            CFlow cFlow = (CFlow)cGanttFlow.Data;
            CFlowLink cLink = CreateLink(cBarLink);
            cFlow.FlowLinkS.Add(cLink);
        }

        private void ucGanttChart_UEventLinkRemoved(object sender, CGanttLink cBarLink)
        {
            CGanttItem cGanttFrom = ucGanttChart.GetItem(cBarLink.BarFrom);
            if (cGanttFrom == null)
                return;

            CGanttItem cGanttTo = ucGanttChart.GetItem(cBarLink.BarTo);
            if (cGanttTo == null)
                return;

            CGanttItem cGanttFlow = ucGanttChart.GetParentItem(cGanttFrom);
            if (cGanttFlow == null)
                return;

            CFlow cFlow = (CFlow)cGanttFlow.Data;
            CFlowLink cLink = (CFlowLink)cBarLink.Data;
            cFlow.FlowLinkS.Remove(cLink);
        }

        private void ucGanttChart_UEventLinkUpdated(object sender, CGanttLink cBarLink)
        {
            CFlowLink cLink = (CFlowLink)cBarLink.Data;
            double nInterval = 0;
            bool bOK = double.TryParse(cBarLink.Text, out nInterval);
            if (bOK)
                cLink.Interval = nInterval;
            
            if (cBarLink.PointTypeFrom == EMGanttPointType.Start)
                cLink.PointTypeFrom = EMLinkPointType.Start;
            else
                cLink.PointTypeFrom = EMLinkPointType.End;

            if (cBarLink.PointTypeTo == EMGanttPointType.Start)
                cLink.PointTypeTo = EMLinkPointType.Start;
            else
                cLink.PointTypeTo = EMLinkPointType.End;
        }

        #endregion
    }
}
