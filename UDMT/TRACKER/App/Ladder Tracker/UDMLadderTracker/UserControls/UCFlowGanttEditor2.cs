using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;
using UDM.Log;
using UDM.Flow;
using UDM.UI.TimeChart;

namespace UDMLadderTracker
{
    public delegate void UEventHandlerFlowEditorNodeDoubleClicked(object sender, CTimeNode cNode);
    public delegate void UEventHandlerFlowEditorLinkDoubleClicked(object sender, CTimeNodeLink cLink);
	public partial class UCFlowGanttEditor2 : UserControl
	{

		#region Member Variables

		public event UEventHandlerFlowEditorNodeDoubleClicked UEventNodeDoubleClicked;
		public event UEventHandlerFlowEditorLinkDoubleClicked UEventLinkDoubleClicked;

		#endregion


		#region Initialize/Dispose

		public UCFlowGanttEditor2()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties


		#endregion


		#region Public Methods


		public void ShowChart(string sGroup, string sRecipe, int iIndex, CFlow cFlow)
		{	
			ucTimeChart.BeginUpdate();
			{
				// Draw Group
				CGanttItem cGanttGroup = (CGanttItem)ucTimeChart.GanttTree.ItemS.FindHasData(sGroup);
				if (cGanttGroup == null)
				{
					cGanttGroup = new CGanttItem(new string[] {sGroup, ""});
					cGanttGroup.Data = sGroup;
					ucTimeChart.GanttTree.ItemS.Add(cGanttGroup);
				}

				// Draw Recipe
				CGanttItem cGanttRecipe = (CGanttItem)cGanttGroup.ItemS.FindHasData(sRecipe);
				if (cGanttRecipe == null)
				{
					cGanttRecipe = new CGanttItem(new string[] { sRecipe, "" });
					cGanttRecipe.Data = sRecipe;
					cGanttGroup.ItemS.Add(cGanttRecipe);
                    cGanttGroup.Expand();
				}

				// Draw Index
				CGanttItem cGanttIndex = (CGanttItem)cGanttRecipe.ItemS.FindHasData(cFlow);
				if (cGanttIndex == null)
				{
					cGanttIndex = new CGanttItem(new string[] { iIndex.ToString(), "" });
					cGanttIndex.Data = cFlow;
					cGanttRecipe.ItemS.Add(cGanttIndex);
                    cGanttRecipe.Expand();
				}

				ShowFlow(cGanttIndex, cFlow, Color.DodgerBlue, false);

                cGanttIndex.Expand();
				UpdateTimeRange(cFlow);
				
			}
			ucTimeChart.EndUpdate();
		}
		
		public List<CRowItem> GetSelectedItemList()
		{
			return ucTimeChart.GanttTree.GetSelectedItemList();
		}

		public void Clear()
		{
			ucTimeChart.Clear();
		}

		public void ZoomIn()
		{
			ucTimeChart.TimeLine.ZoomIn();
		}

		public void ZoomOut()
		{
			ucTimeChart.TimeLine.ZoomOut();
		}

		public void ItemUp()
		{
			List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
			ucTimeChart.GanttTree.ItemUp(lstItem);

			lstItem.Clear();
		}

		public void ItemDown()
		{
			List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
			ucTimeChart.GanttTree.ItemDown(lstItem);

			lstItem.Clear();
		}

		#endregion


		#region Private Methods

		private void ShowFlow(CGanttItem cGanttParent, CFlow cFlow, Color cColor, bool bExpand)
		{
			// Draw BarS
			CGanttItem cGanttItem;
			CFlowItem cFlowItem;
			List<CGanttBar> lstBar;
			for (int i = 0; i < cFlow.FlowItemS.Count; i++)
			{
				cFlowItem = cFlow.FlowItemS[i];

				cGanttItem = new CGanttItem(new object[] { cFlowItem.Key, cFlowItem.Description });
				cGanttItem.Data = cFlowItem;
				cGanttParent.ItemS.Add(cGanttItem);

				lstBar = CreateBarList(cFlowItem, cColor);
				cGanttItem.BarS.AddRange(lstBar);
				lstBar.Clear();

				if (cFlowItem.SubFlow != null)
					ShowFlow(cGanttItem, cFlowItem.SubFlow, Color.LightBlue, false);
			}

			// Draw BarLinkS
			CGanttLink cGanttLink;
			CFlowLink cLink;
			for (int i = 0; i < cFlow.FlowLinkS.Count; i++)
			{
				cLink = cFlow.FlowLinkS[i];
				cGanttLink = CreateBarLink(cGanttParent, cLink);
				cGanttLink.Text = cLink.Interval.ToString();
				ucTimeChart.GanttTree.LinkS.Add(cGanttLink);
			}

			if (bExpand)
				cGanttParent.Expand();
		}

		private List<CGanttBar> CreateBarList(CFlowItem cItem, Color cColor)
		{
			List<CGanttBar> lstBar = new List<CGanttBar>();

			CGanttBar cBar;
			CTimeNode cNode;
			for (int i = 0; i < cItem.TimeNodeS.Count; i++)
			{
				cNode = cItem.TimeNodeS[i];
				cBar = CreateBar(cNode, cColor);
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

		private CTimeNode CreateNode(string sKey, CGanttBar cBar)
		{
			CTimeNode cNode = new CTimeNode();
			cNode.Key = sKey;
			cNode.Start = cBar.StartTime;
			cNode.End = cBar.EndTime;
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

			if (cBarLink.PointTypeFrom == EMGanttLinkPointType.Start)
			{
				cLink.PointTypeFrom = EMLinkPointType.Start;
				dtFrom = cLink.NodeFrom.Start;
			}
			else
			{
				cLink.PointTypeFrom = EMLinkPointType.End;
				dtFrom = cLink.NodeFrom.End;
			}

			if (cBarLink.PointTypeTo == EMGanttLinkPointType.Start)
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

		protected void UpdateTimeRange(CFlow cFlow)
		{
			ucTimeChart.TimeLine.FirstVisibleTime = cFlow.First;
			ucTimeChart.TimeLine.RangeFrom = cFlow.First;
			if (cFlow.Last > ucTimeChart.TimeLine.RangeTo)
				ucTimeChart.TimeLine.RangeTo = cFlow.Last;
		}


		#endregion


		#region Event Methods

		private void UCFlowGanttEditor2_Load(object sender, EventArgs e)
		{
			ucTimeChart.BeginUpdate();
			{
				CColumnItem cColumn1 = new CColumnItem("colAddress", "Address");
				CColumnItem cColumn2 = new CColumnItem("colDescription", "Description");

				ucTimeChart.GanttTree.ColumnS.Add(cColumn1);
				ucTimeChart.GanttTree.ColumnS.Add(cColumn2);

				ucTimeChart.GanttChart.IsEditable = true;
			}
			ucTimeChart.EndUpdate();

			ucTimeChart.GanttChart.UEventBarCreated += GanttChart_UEventBarCreated;
			ucTimeChart.GanttChart.UEventBarMoved += GanttChart_UEventBarMoved;
			ucTimeChart.GanttChart.UEventBarResized += GanttChart_UEventBarResized;
			ucTimeChart.GanttChart.UEventBarRemoved += GanttChart_UEventBarRemoved;
			ucTimeChart.GanttChart.UEventLinkCreated += GanttChart_UEventLinkCreated;
			ucTimeChart.GanttChart.UEventLinkRemoved += GanttChart_UEventLinkRemoved;
			ucTimeChart.GanttChart.UEventBarDoubleClicked += GanttChart_UEventBarDoubleClicked;
			ucTimeChart.GanttChart.UEventLinkDoubleClicked += GanttChart_UEventLinkDoubleClicked;
		}

		private void GanttChart_UEventBarCreated(object sender, CGanttBar cBar)
		{
			CGanttItem cItem = cBar.Item;
			if (cItem == null || cItem.Data == null)
				return;

			CGanttItem cItemParent = (CGanttItem)cItem.Parent;
			if (cItemParent == null || cItemParent.Data == null)
				return;

			if (cItemParent.Data.GetType() == typeof(CFlowItem))
				cBar.Color = Color.LightBlue;

			CFlowItem cFlowItem = (CFlowItem)cItem.Data;
			CTimeNode cNode = CreateNode(cFlowItem.Key, cBar);
			cFlowItem.TimeNodeS.Add(cNode);

			ucTimeChart.GanttChart.UpdateLayout();
		}

		private void GanttChart_UEventBarMoved(object sender, CGanttBar cBar)
		{
			CGanttItem cItem = cBar.Item;
			if (cItem == null)
				return;

			CTimeNode cNode = (CTimeNode)cBar.Data;
			cNode.Start = cBar.StartTime;
			cNode.End = cBar.EndTime;
		}

		private void GanttChart_UEventBarResized(object sender, CGanttBar cBar)
		{
			CGanttItem cItem = cBar.Item;
			if (cItem == null)
				return;

			CTimeNode cNode = (CTimeNode)cBar.Data;
			cNode.Start = cBar.StartTime;
			cNode.End = cBar.EndTime;
		}

		private void GanttChart_UEventBarRemoved(object sender, CGanttBar cBar)
		{
			CGanttItem cItem = cBar.Item;
			if (cItem == null || cItem.Data == null)
				return;

			CFlowItem cFlowItem = (CFlowItem)cItem.Data;
			CTimeNode cNode = (CTimeNode)cBar.Data;
			cFlowItem.TimeNodeS.Remove(cNode);
		}

		private void GanttChart_UEventLinkCreated(object sender, CGanttLink cLink) 
		{
			CGanttItem cGanttFrom = cLink.BarFrom.Item;
			CGanttItem cGanttTo = cLink.BarTo.Item;
			if(cGanttFrom == cGanttTo || cGanttFrom.Level != cGanttTo.Level || cGanttFrom.Parent != cGanttTo.Parent)
			{
				ucTimeChart.GanttTree.LinkS.Remove(cLink);
				return;
			}

			CGanttItem cGanttFromParent = (CGanttItem)cGanttFrom.Parent;
			if (cGanttFromParent.Data == null || cGanttFromParent.Data.GetType() != typeof(CFlow))
			{
				ucTimeChart.GanttTree.LinkS.Remove(cLink);
				return;
			}

			CGanttItem cGanttToParent = (CGanttItem)cGanttTo.Parent;
			if (cGanttToParent.Data == null || cGanttToParent.Data.GetType() != typeof(CFlow))
			{
				ucTimeChart.GanttTree.LinkS.Remove(cLink);
				return;
			}

			CGanttItem cGanttFlow = (CGanttItem)cGanttFrom.Parent;
			if (cGanttFlow == null)
				return;

			CFlow cFlow = (CFlow)cGanttFlow.Data;
			CFlowLink cFlowLink = CreateLink(cLink);
			cFlow.FlowLinkS.Add(cFlowLink);
		}

		private void GanttChart_UEventLinkRemoved(object sender, CGanttLink cLink)
		{
			CGanttItem cGanttFrom = cLink.BarFrom.Item;
			if (cGanttFrom == null)
				return;

			CGanttItem cGanttTo = cLink.BarTo.Item;
			if (cGanttTo == null)
				return;

			CGanttItem cGanttFlow = (CGanttItem)cGanttFrom.Parent;
			if (cGanttFlow == null)
				return;

			CFlow cFlow = (CFlow)cGanttFlow.Data;
			CFlowLink cFlowLink = (CFlowLink)cLink.Data;
			cFlow.FlowLinkS.Remove(cFlowLink);
		}

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar, EventArgs e)
		{
			if (UEventNodeDoubleClicked != null)
				UEventNodeDoubleClicked(this, (CTimeNode)cBar.Data);
		}

		private void GanttChart_UEventLinkDoubleClicked(object sender, CGanttLink cLink, EventArgs e)
		{
			if (UEventLinkDoubleClicked != null)
				UEventLinkDoubleClicked(this, (CTimeNodeLink)cLink.Data);
		}

		#endregion
	}
}
