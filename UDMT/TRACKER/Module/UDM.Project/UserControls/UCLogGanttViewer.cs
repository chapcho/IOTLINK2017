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
    public partial class UCLogGanttViewer : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public UCLogGanttViewer()
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

        public void ShowChart(string sGroup, CFlowItemS cFlowItemS)
        {
            bool bOK = true;

            ucGanttChart.BeginUpdate();

            if (sGroup != "")
            {
                // Draw Group
                CGanttItem cGanttGroup = ucGanttChart.GetItemHasData(sGroup);
                if (cGanttGroup == null)
                {
                    cGanttGroup = new CGanttItem(sGroup);
                    cGanttGroup.CellTextS = new string[] { sGroup};
                    cGanttGroup.Data = sGroup;

                    bOK = ucGanttChart.AddItem(cGanttGroup);
                    if (bOK == false)
                    {
                        ucGanttChart.EndUpdate();
                        return;
                    }
                }

                // Draw ItemS
                ShowLog(cGanttGroup, cFlowItemS);

                ucGanttChart.ExpandItem(cGanttGroup);
            }
            else
            {
                ShowLog(cFlowItemS);
            }

            ucGanttChart.EndUpdate();
        }

        public bool GetTimeIndicatePeriod(out DateTime dtStart, out DateTime dtEnd)
        {
            return ucGanttChart.GetTimeIndicatePeriod(out dtStart, out dtEnd);
        }

        public List<string>GetGanttChartDisplayedItemKeyList()
        {
            return ucGanttChart.GetGanttChartDisplayedItemKeyList();
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

        public void RemoveSelectedItem()
        {
            ucGanttChart.RemoveSelectedGanttItem();
        }


        #endregion


        #region Private Methods

        private void ShowLog(CGanttItem cGanttParent, CFlowItemS cFlowItemS )
        {
            bool bOK = false;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            CGanttBarS cBarS;
            for (int i = 0; i < cFlowItemS.Count; i++)
            {
                cFlowItem = cFlowItemS.ElementAt(i).Value;

                cGanttItem = ucGanttChart.GetChildItemHasData(cGanttParent, cFlowItem.Key);
                if (cGanttItem == null)
                {
                    cGanttItem = new CGanttItem(cFlowItem.Key);
                    cGanttItem.CellTextS = new string[] { cFlowItem.Key, cFlowItem.Description };
                    cGanttItem.Data = cFlowItem.Key;
                    
                    bOK = ucGanttChart.InsertItem(cGanttParent, cGanttItem);
                }

                cBarS = CreateBarS(cFlowItem, EMGanttBarType.GTask);
                ucGanttChart.AddBarS(cGanttItem, cBarS);
            }
        }

        private void ShowLog(CFlowItemS cFlowItemS)
        {
            bool bOK = false;

            // Draw BarS
            CGanttItem cGanttItem;
            CFlowItem cFlowItem;
            CGanttBarS cBarS;
            for (int i = 0; i < cFlowItemS.Count; i++)
            {
                cFlowItem = cFlowItemS.ElementAt(i).Value;

                cGanttItem = ucGanttChart.GetItemHasData(cFlowItem.Key);
                if (cGanttItem == null)
                {
                    cGanttItem = new CGanttItem(cFlowItem.Key);
                    cGanttItem.CellTextS = new string[] { cFlowItem.Key, cFlowItem.Description };
                    cGanttItem.Data = cFlowItem.Key;

                    bOK = ucGanttChart.AddItem(cGanttItem);
                }

                cBarS = CreateBarS(cFlowItem, EMGanttBarType.GTask);
                ucGanttChart.AddBarS(cGanttItem, cBarS);
            }
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

        #endregion


        #region Event Methods

        private void UCPatternResultGanttViewer_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
