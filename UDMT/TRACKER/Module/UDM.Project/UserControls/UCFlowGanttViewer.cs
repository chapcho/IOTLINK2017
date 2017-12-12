using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.UI.ExGanttChart;
using UDM.Log;
using UDM.Flow;
using UDM.Monitor;

namespace UDM.Project
{
	public partial class UCFlowGanttViewer : DevExpress.XtraEditors.XtraUserControl
	{
		#region Member Variables
		protected EMGanttUnitScale m_emGanttUnitScale = EMGanttUnitScale.Second;

		public delegate void UEventHandlerGanttMouseDownFindItem(object sender, string sGroup);

		public event UEventHandlerGanttMouseDownFindItem UEventHandlerFindItem;
		#endregion

		#region Properties
		public EMGanttUnitScale DefaultUnitScale
		{
			get { return m_emGanttUnitScale; }
			set { m_emGanttUnitScale = value; ucGanttChart.DefaultUnitScale = value; }
		}
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

		#region Initialize/Dispose
		public UCFlowGanttViewer()
		{
			InitializeComponent();
		}
		#endregion

		#region Public Methods
		public CFlowItem CreateGanttChart(string sGroup, CGroupLogS cGroupLogS, CFlowItemS cFlowItemS)
		{
			bool bOK = true;
			CGanttBarS cBarS;
			CFlowItem cItem = new CFlowItem();
			if (cGroupLogS != null)
			{
				ucGanttChart.BeginUpdate();
				CGanttItem cGanttGroup = ucGanttChart.GetItemHasData(sGroup);
				if (cGanttGroup == null)
				{
					cGanttGroup = new CGanttItem(sGroup);
					cGanttGroup.CellTextS = new string[] { sGroup, "Group" };
					cGanttGroup.Data = sGroup;
					cItem.Data = cGanttGroup;

					bOK = ucGanttChart.AddItem(cGanttGroup);
					if (bOK)
					{
						ShowFlow(cGanttGroup, cFlowItemS);
					}
					else
					{
						ucGanttChart.EndUpdate();
					}
					
					//ucGanttChart.ExpandItem(cGanttGroup);
				}
				else
				{
					ShowFlow(cFlowItemS);
					cItem.Data = cGanttGroup;
				}

				cBarS = CreateGroupBarS(cGroupLogS);
				ucGanttChart.AddBarS(cGanttGroup, cBarS);
				cItem.TimeNodeS.Data = cBarS;

				//CGanttLinkS cLinkS = CreateLinkS(cBarS);
				//ucGanttChart.AddLinkS(cLinkS);
				ucGanttChart.EndUpdate();

			}
			return cItem;
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
		private void ShowFlow(CGanttItem cGanttParent, CFlowItemS cFlowItemS)
		{
			bool bOK = false;

			CGanttItem cGanttItem;
			CFlowItem cFlowItem;
			for(int i = 0; i < cFlowItemS.Count; i++)
			{
				cFlowItem = cFlowItemS.ElementAt(i).Value;

				cGanttItem = ucGanttChart.GetChildItemHasData(cGanttParent, cFlowItem.Key);
				if(cGanttItem == null)
				{
					cGanttItem = new CGanttItem(cFlowItem.Key);
					cGanttItem.CellTextS = new String[] { cFlowItem.Key, cFlowItem.Description };
					cGanttItem.Data = cFlowItem;

					bOK = ucGanttChart.InsertItem(cGanttParent, cGanttItem);
				}
				
				ucGanttChart.FirstVisibleTime = cFlowItem.First;

			}
		}
		private void ShowFlow(CFlowItemS cFlowItemS)
		{
			bool bOK = false;

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

				cBarS = CreateBarS(cFlowItem);
				ucGanttChart.AddBarS(cGanttItem, cBarS);
			}

		}
		private CGanttBarS CreateGroupBarS(CGroupLogS cGroupLogS)
		{
			CGanttBarS cGanttBarS = new CGanttBarS();
			CGanttBar cGanttBar = null;

			for (int i = 0; i < cGroupLogS.Count; i++)
			{
				cGanttBar = CreateGroupBar(cGroupLogS[i]);
				if (cGanttBar != null)
					cGanttBarS.Add(cGanttBar);
			}
			return cGanttBarS;
		}

		private CGanttBarS CreateBarS(CFlowItem cFlowItem)
		{
			CGanttBarS cGanttBarS = new CGanttBarS();
			CGanttBar cBar = null;
			CTimeNode cNode = null;

			for (int i = 0; i < cFlowItem.TimeNodeS.Count; i++ )
			{
				cNode = cFlowItem.TimeNodeS[i];
				cBar = CreateBar(cNode);
				cBar.BarType = EMGanttBarType.GTask;

				if (cBar != null)
					cGanttBarS.Add(cBar);
			}

				return cGanttBarS;
		}

		private CGanttBar CreateGroupBar(CGroupLog cGroupLog)
		{
			CGanttBar cGanttBar = new CGanttBar();

			cGanttBar.Start = cGroupLog.CycleStart;
			cGanttBar.End = cGroupLog.CycleEnd;

			cGanttBar.Text = string.Format("[{0}]{1}", cGroupLog.Recipe, cGroupLog.Product);
			cGanttBar.Data = cGroupLog;

            if (cGroupLog.StateType == EMGroupStateType.End)
				cGanttBar.BarType = EMGanttBarType.BTask;
            else if (cGroupLog.StateType == EMGroupStateType.Error)
				cGanttBar.BarType = EMGanttBarType.RTask;

			return cGanttBar;
		}

		private CGanttBar CreateBar(CTimeNode cTimeNode)
		{
			CGanttBar cBar= new CGanttBar();
			cBar.Start = cTimeNode.Start;
			cBar.End = cTimeNode.End;

			if(cTimeNode.IsStart == false)
			{
				cBar.EdgeShapeType = EMGanttEdgeShapeType.FillArrowLeft;
				cBar.EdgeType = EMGanttEdgeType.Start;
			}

			if(cTimeNode.IsEnd == false)
			{
				cBar.EdgeShapeType = EMGanttEdgeShapeType.FillArrowRight;
				cBar.EdgeType = EMGanttEdgeType.End;
			}
			cBar.Text = cTimeNode.Text;
			cBar.Data = cTimeNode;

			return cBar;
		}
		#endregion

		#region Event Methods
		private void ucGanttChart_Load(object sender, EventArgs e)
		{
			ucGanttChart.UEventMouseDown += ucGanttChart_UEventMouseDown;
			ucGanttChart.UEventAfterExpandItem += ucGanttChart_UEventAfterExpandItem;
		}

		private void ucGanttChart_UEventAfterExpandItem(object sender, int index, CGanttItem cGanttItem)
		{
			List<CGanttItem> lstChildS = ucGanttChart.GetChildItem(cGanttItem);
			CGanttItem cChildItem;
			CFlowItem cFlowItem;
			CGanttBarS cBarS;
			for(int i = 0; i < lstChildS.Count; i++)
			{
				cChildItem = lstChildS[i];
				cFlowItem = (CFlowItem)cChildItem.Data;
				if (cFlowItem != null)
				{
					cBarS = CreateBarS(cFlowItem);
					ucGanttChart.AddBarS(cChildItem, cBarS);
				}
			}
		}
		private void ucGanttChart_UEventMouseDown(object sender, short iButton, short iShift, int iX, int iY)
		{
			CGanttItem cItem = ucGanttChart.GetItem(iX, iY);

			if (cItem == null)
				return;
			else
			{
				string sGroup = (string)cItem.Data;

				if (UEventHandlerFindItem != null)
					UEventHandlerFindItem(this, sGroup);
			}
		}
		#endregion

		public void CreateBarLinkS(CFlowItemS cFlowItemS)
		{
			CGanttItem cFromItem;
			CGanttItem cToItem;
			CGanttBarS cFromBarS;
			CGanttBarS cToBarS;
			CGanttLinkS cLinkS = new CGanttLinkS();

			for(int i = 0; i < cFlowItemS.Count; i++)
			{
				cFromItem = (CGanttItem)cFlowItemS[i].Data;
				cFromBarS = (CGanttBarS)cFlowItemS[i].TimeNodeS.Data;

				for(int j = 0; j < cFlowItemS.Count; j++)
				{
					cToItem = (CGanttItem)cFlowItemS[j].Data;
					cToBarS = (CGanttBarS)cFlowItemS[j].TimeNodeS.Data;
					if(cFromItem.Key != cToItem.Key)
					{
						if (cFromBarS.Count != 0 && cToBarS.Count != 0)
						{
							for (int k = 0; k < cFromBarS.Count; k++)
							{
								int l = 0;
								while(l < cToBarS.Count)
								{
									if (cFromBarS[k].End <= cToBarS[l].Start)
									{
										CGanttLink cLink = new CGanttLink();
										string sEnd = string.Format("{0:yyyyMMddhhmmssfff}", cToBarS[k].End);
										string sStart = string.Format("{0:yyyyMMddhhmmssfff}", cToBarS[l].Start);
										cLink.Key = string.Format("{0}-{1}", sEnd, sStart);
										if (!cLinkS.ContainsKey(cLink.Key))
										{
											cLink.BarFrom = cFromBarS[k];
											cLink.BarTo = cToBarS[l];
											cLink.PointTypeFrom = EMGanttPointType.End;
											cLink.PointTypeTo = EMGanttPointType.Start;
											ucGanttChart.AddLink(cLink);
											cLinkS.Add(cLink);
										}
										break;
									}
									else
									{
										l++;
										continue;
									}
								}
							}
						}
					}
				}
			}
		}
	}
}