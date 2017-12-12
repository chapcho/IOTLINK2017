using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCGanttChart : UCCanvas
	{

		#region Member Varialbes
		
		protected bool m_bEditable = false;

		protected UCTimeLine m_ucTimeLine = null;
		protected UCGanttTree m_ucGanttTree = null;

		protected CGanttViewItemInfoS m_cViewItemS = new CGanttViewItemInfoS();
		protected CGanttViewLinkInfoS m_cViewLinkS = new CGanttViewLinkInfoS();
		protected CGanttItem m_cSelectedItem = null;
		protected CGanttBar m_cSelectedBar = null;
		protected CGanttLink m_cSelectedLink = null;
		protected EMActionType m_emActionType = EMActionType.None;
		protected PointF m_pntMousePos = new PointF();

		public event UEventHandlerGanttChartBarCreated UEventBarCreated;
		public event UEventHandlerGanttChartBarRemoved UEventBarRemoved;
		public event UEventHandlerGanttChartBarMoved UEventBarMoved;
		public event UEventHandlerGanttChartBarResized UEventBarResized;
		public event UEventHandlerGanttChartLinkCreated UEventLinkCreated;
		public event UEventHandlerGanttChartLinkRemoved UEventLinkRemoved;
		public event UEventHandlerGanttChartBarClicked UEventBarClicked;
		public event UEventHandlerGanttChartLinkClicked UEventLinkClicked;
		public event UEventHandlerGanttChartBarDoubleClicked UEventBarDoubleClicked;
		public event UEventHandlerGanttChartLinkDoubleClicked UEventLinkDoubleClicked;
		#endregion


		#region Initialize/Dispose

		public UCGanttChart()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCGanttChart(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public bool IsEditable
		{
			get { return m_bEditable; }
			set { m_bEditable = value; }
		}

		public UCTimeLine TimeLine
		{
			get { return m_ucTimeLine; }
			set { SetTimeLine(value); }
		}

		public UCGanttTree GanttTree
		{
			get { return m_ucGanttTree; }
			set { SetGanttTree(value); }
		}

		public CGanttItem FocusedItem
		{
			get { return m_cSelectedItem; }
		}

		public CGanttBar FocusedBar
		{
			get { return m_cSelectedBar; }
		}

		public CGanttLink FocusedLink
		{
			get { return m_cSelectedLink; }
		}

		#endregion


		#region Public Methods

		#region Layout

		public new void UpdateLayout()
		{
			this.Invalidate();

			GenerateLayoutUpdatedEvent();
		}

		public new void BeginUpdate()
		{

		}

		public new void EndUpdate()
		{
			UpdateLayout();
		}

		#endregion


		#region Item

		public CGanttItem PickItem(Point pntPos)
		{
			CGanttItem cItem = (CGanttItem)(m_ucGanttTree.PickItem(pntPos.Y + m_ucGanttTree.ColumnHeight));
			return cItem;
		}

		public CGanttBar PickBar(CGanttItem cItem, Point pntPos)
		{
			DateTime dtTime = m_ucTimeLine.CalcTime(pntPos.X);
			if (dtTime == DateTime.MinValue)
				return null;

			CGanttBar cBar = m_cViewItemS.FindBar(cItem, dtTime);

			return cBar;
		}

		public CGanttLink PickLink(Point pntPos)
		{
			CGanttLink cLink = m_cViewLinkS.FindLink(pntPos);

			return cLink;
		}

		public CTimeIndicator PickIndicator(Point pntPos)
		{
			CTimeIndicator cIndicator = m_ucTimeLine.PickTimeIndicator(pntPos.X);

			return cIndicator;
		}

		#endregion

		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{
			CBaseMouseWheelControlHelper.Add(this, OnMouseWheelEvent);
		}

		protected void SetTimeLine(UCTimeLine ucTimeLine)
		{
			if(m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventLayoutUpdated -= m_ucTimeLine_UEventLayoutUpdated;
			}

			m_ucTimeLine = ucTimeLine;
			if (m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventLayoutUpdated += m_ucTimeLine_UEventLayoutUpdated;
			}
		}

		protected void SetGanttTree(UCGanttTree ucGanttTree)
		{
			if (m_ucGanttTree != null)
			{
				m_ucGanttTree.UEventLayoutUpdated -= m_ucGanttTree_UEventLayoutUpdated;
			}

			m_ucGanttTree = ucGanttTree;
			if (m_ucGanttTree != null)
			{
				m_ucGanttTree.UEventLayoutUpdated += m_ucGanttTree_UEventLayoutUpdated;				
			}
		}

		#endregion

		#region Item

		protected void UpdateViewItemS()
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			List<CRowItem> lstItem = m_ucGanttTree.GetViewItemList();

			CGanttViewItemInfoS cNewViewItemInfoS = new CGanttViewItemInfoS();

			CGanttViewItemInfo cItemInfo = null;
			CGanttItem cItem = null;
			for (int i = 0; i < lstItem.Count; i++)
			{
				cItem = (CGanttItem)lstItem[i];
				if (m_cViewItemS.ContainsKey(cItem))
				{
					cItemInfo = m_cViewItemS[cItem];
				}
				else
				{
					cItemInfo = new CGanttViewItemInfo(-1, -1);
					UpdateViewItemInfo(cItem, cItemInfo);
				}
                if (cNewViewItemInfoS.ContainsKey(cItem) == false)
                    cNewViewItemInfoS.Add(cItem, cItemInfo);
			}

			m_cViewItemS.Clear();
			m_cViewItemS = cNewViewItemInfoS;
		}

		protected void UpdateViewItemInfoS()
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			CGanttViewItemInfo cItemInfo = null;
			CGanttItem cItem = null;
			for (int i = 0; i < m_cViewItemS.Count; i++)
			{
				cItem = m_cViewItemS.ElementAt(i).Key;
				cItemInfo = m_cViewItemS.ElementAt(i).Value;

				UpdateViewItemInfo(cItem, cItemInfo);
			}
		}

		protected void UpdateViewItemInfo(CGanttItem cItem, CGanttViewItemInfo cItemInfo)
		{
			cItemInfo.BarIndexFrom = -1;
			cItemInfo.BarIndexTo = -1;

			CGanttBar cBar = null;
			for (int i = 0; i < cItem.BarS.Count; i++)
			{
				cBar = cItem.BarS[i];
				if (cBar.EndTime < m_ucTimeLine.FirstVisibleTime)
				{
					continue;
				}
				else if (IsInsideViewRange(cBar))
				{
					if (cItemInfo.BarIndexFrom == -1)
					{
						cItemInfo.BarIndexFrom = i;
						cItemInfo.BarIndexTo = i;
					}
					else
					{
						cItemInfo.BarIndexTo = i;
					}
				}
				else if (cBar.StartTime >= m_ucTimeLine.LastVisibleTime)
				{
					break;
				}
			}
		}

		protected void UpdateViewLinkS()
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			m_cViewLinkS.Clear();

			CGanttLinkS cTotalLinkS = m_ucGanttTree.LinkS;

			CGanttLink cLink;
			CGanttViewLinkInfo cLinkInfo;
			for (int i = 0; i < cTotalLinkS.Count; i++)
			{
				cLink = cTotalLinkS[i];
				if ((m_cViewItemS.ContainsKey(cLink.BarFrom.Item) || m_cViewItemS.ContainsKey(cLink.BarTo.Item)) && (IsInsideViewRange(cLink.BarFrom) || IsInsideViewRange(cLink.BarTo)))
				{
					cLinkInfo = new CGanttViewLinkInfo();

					UpdateViewLink(cLink, cLinkInfo);

					m_cViewLinkS.Add(cLink, cLinkInfo);
				}
			}
		}

		protected void UpdateViewLink(CGanttLink cLink, CGanttViewLinkInfo cLinkInfo)
		{
			if (cLink.BarFrom == null || cLink.BarTo == null)
				return;

			cLinkInfo.PathInfo.Reset();

			float nTickWith = 10;
			float nHalfHeight = m_ucGanttTree.ItemHeight / 2;

			float nPosX1 = 0;
			float nPosY1 = 0;
			float nPosX2 = 0;
			float nPosY2 = 0;
			float nTempX = 0;
			float nTempY = 0;
			List<PointF> lstPoint = new List<PointF>();

			nPosY1 = m_ucGanttTree.CalcPosition(cLink.BarFrom.Item) + nHalfHeight + cLink.BarFrom.OffSet;
			nPosY2 = m_ucGanttTree.CalcPosition(cLink.BarTo.Item) + nHalfHeight + cLink.BarTo.OffSet;

			if (cLink.BarFrom.Item == cLink.BarTo.Item)
			{
				if (cLink.PointTypeFrom == EMGanttLinkPointType.Start)
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.StartTime);
					nTempX = nPosX1 - nTickWith;
				}
				else
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.EndTime);
					nTempX = nPosX1 + nTickWith;
				}

				lstPoint.Add(new PointF(nPosX1, nPosY1));
				lstPoint.Add(new PointF(nTempX, nPosY1));

				nTempY = m_ucGanttTree.CalcPosition(cLink.BarFrom.Item) + m_ucGanttTree.ItemHeight;
				lstPoint.Add(new PointF(nTempX, nTempY));

				if (cLink.PointTypeTo == EMGanttLinkPointType.Start)
				{
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.StartTime);
					nTempX = nPosX2 - nTickWith;
				}
				else
				{
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.EndTime);
					nTempX = nPosX2 + nTickWith;
				}

				lstPoint.Add(new PointF(nTempX, nTempY));
				lstPoint.Add(new PointF(nTempX, nPosY2));
				lstPoint.Add(new PointF(nPosX2, nPosY2));
			}
			else
			{
				if (cLink.PointTypeFrom == EMGanttLinkPointType.Start && cLink.PointTypeTo == EMGanttLinkPointType.Start)
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.StartTime);
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.StartTime);
					lstPoint.Add(new PointF(nPosX1, nPosY1));

					if (nPosX2 > nPosX1)
						nTempX = nPosX1 - nTickWith;
					else
						nTempX = nPosX2 - nTickWith;

					lstPoint.Add(new PointF(nTempX, nPosY1));
					lstPoint.Add(new PointF(nTempX, nPosY2));
					lstPoint.Add(new PointF(nPosX2, nPosY2));
				}
				else if (cLink.PointTypeFrom == EMGanttLinkPointType.End && cLink.PointTypeTo == EMGanttLinkPointType.End)
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.EndTime);
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.EndTime);
					lstPoint.Add(new PointF(nPosX1, nPosY1));

					if (nPosX2 > nPosX1)
						nTempX = nPosX2 + nTickWith;
					else
						nTempX = nPosX1 + nTickWith;

					lstPoint.Add(new PointF(nTempX, nPosY1));
					lstPoint.Add(new PointF(nTempX, nPosY2));
					lstPoint.Add(new PointF(nPosX2, nPosY2));
				}
				else if (cLink.PointTypeFrom == EMGanttLinkPointType.Start && cLink.PointTypeTo == EMGanttLinkPointType.End)
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.StartTime);
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.EndTime);
					lstPoint.Add(new PointF(nPosX1, nPosY1));

					if (nPosX2 > nPosX1 - 2 * nTickWith)
					{
						nTempX = nPosX1 - nTickWith;
						lstPoint.Add(new PointF(nTempX, nPosY1));

						if (nPosY2 > nPosY1)
							nTempY = m_ucGanttTree.CalcPosition(cLink.BarTo.Item);
						else
							nTempY = m_ucGanttTree.CalcPosition(cLink.BarTo.Item) + m_ucGanttTree.ItemHeight;

						lstPoint.Add(new PointF(nTempX, nTempY));

						nTempX = nPosX2 + nTickWith;
						lstPoint.Add(new PointF(nTempX, nTempY));
						lstPoint.Add(new PointF(nTempX, nPosY2));
						lstPoint.Add(new PointF(nPosX2, nPosY2));
					}
					else
					{
						nTempX = nPosX2 + nTickWith;
						lstPoint.Add(new PointF(nTempX, nPosY1));
						lstPoint.Add(new PointF(nTempX, nPosY2));
						lstPoint.Add(new PointF(nPosX2, nPosY2));
					}
				}
				else if (cLink.PointTypeFrom == EMGanttLinkPointType.End && cLink.PointTypeTo == EMGanttLinkPointType.Start)
				{
					nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.EndTime);
					nPosX2 = m_ucTimeLine.CalcPosition(cLink.BarTo.StartTime);
					lstPoint.Add(new PointF(nPosX1, nPosY1));

					if (nPosX2 > nPosX1 + 2 * nTickWith)
					{
						nTempX = nPosX1 + nTickWith;
						lstPoint.Add(new PointF(nTempX, nPosY1));

						nTempX = nPosX2 - nTickWith;
						lstPoint.Add(new PointF(nTempX, nPosY1));
						lstPoint.Add(new PointF(nTempX, nPosY2));
						lstPoint.Add(new PointF(nPosX2, nPosY2));
					}
					else
					{
						nTempX = nPosX1 + nTickWith;
						lstPoint.Add(new PointF(nTempX, nPosY1));

						if (nPosY2 > nPosY1)
							nTempY = m_ucGanttTree.CalcPosition(cLink.BarTo.Item);
						else
							nTempY = m_ucGanttTree.CalcPosition(cLink.BarTo.Item) + m_ucGanttTree.ItemHeight;

						lstPoint.Add(new PointF(nTempX, nTempY));

						nTempX = nPosX2 - nTickWith;
						lstPoint.Add(new PointF(nTempX, nTempY));
						lstPoint.Add(new PointF(nTempX, nPosY2));
						lstPoint.Add(new PointF(nPosX2, nPosY2));
					}
				}
			}

			cLinkInfo.PathInfo.AddLines(lstPoint.ToArray());
			lstPoint.Clear();
			lstPoint = null;
		}

		protected void UpdateViewLink(CGanttLink cLink, CGanttViewLinkInfo cLinkInfo, PointF pntPosTo)
		{
			cLinkInfo.PathInfo.Reset();

			float nTickWith = 10;
			float nHalfHeight = m_ucGanttTree.ItemHeight / 2;

			float nPosX1 = 0;
			float nPosY1 = 0;
			float nTempX = 0;
			List<PointF> lstPoint = new List<PointF>();

			nPosY1 = m_ucGanttTree.CalcPosition(cLink.BarFrom.Item) + nHalfHeight + cLink.BarFrom.OffSet;

			if (cLink.PointTypeFrom == EMGanttLinkPointType.Start)
			{
				nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.StartTime);
				lstPoint.Add(new PointF(nPosX1, nPosY1));
				
				nTempX = nPosX1 - nTickWith;
				lstPoint.Add(new PointF(nTempX, nPosY1));
				lstPoint.Add(new PointF(nTempX, pntPosTo.Y));
				lstPoint.Add(new PointF(pntPosTo.X, pntPosTo.Y));
			}
			else if (cLink.PointTypeFrom == EMGanttLinkPointType.End)
			{
				nPosX1 = m_ucTimeLine.CalcPosition(cLink.BarFrom.EndTime);
				lstPoint.Add(new PointF(nPosX1, nPosY1));

				nTempX = nPosX1 + nTickWith;
				lstPoint.Add(new PointF(nTempX, nPosY1));
				lstPoint.Add(new PointF(nTempX, pntPosTo.Y));
				lstPoint.Add(new PointF(pntPosTo.X, pntPosTo.Y));
			}

			cLinkInfo.PathInfo.AddLines(lstPoint.ToArray());
			lstPoint.Clear();
			lstPoint = null;
		}

		protected void UpdateLinkInfo(CGanttBar cBar)
		{
			List<CGanttLink> lstLink = m_cViewLinkS.GetLinkList(cBar);

			CGanttLink cLink;
			CGanttViewLinkInfo cLinkInfo;
			for (int i = 0; i < lstLink.Count; i++)
			{
				cLink = lstLink[i];
				cLinkInfo = m_cViewLinkS[cLink];
				UpdateViewLink(cLink, cLinkInfo);
			}

			lstLink.Clear();
			lstLink = null;
		}

		#endregion

		#region User Action

		protected void MoveTimeBy(float nDelta)
		{
			m_ucTimeLine.MoveTime(nDelta);
		}

		protected void ZoomBy(float nDelta)
		{
			if (nDelta > 0)
				m_ucTimeLine.ZoomOut();
			else
				m_ucTimeLine.ZoomIn();
		}

		protected CGanttBar CreateBarStartBy(CGanttItem cItem, float nPosX)
		{
			CGanttBar cBar = new CGanttBar();
			cBar.Height = m_ucGanttTree.DefaultBarHeight;
			cBar.StartTime = m_ucTimeLine.CalcTime(nPosX);
			cBar.EndTime = cBar.StartTime.AddMilliseconds(10);
			cItem.BarS.Add(cBar);
			cItem.BarS.Sort();

			CGanttViewItemInfo cItemInfo = m_cViewItemS[cItem];
			cItemInfo.BarIndexTo += 1;

			return cBar;
		}

		protected void CreateBarProcessBy(CGanttBar cBar, float nDelta)
		{
			TimeSpan tsSpan = m_ucTimeLine.CalcTimeSpan(nDelta);
			DateTime dtTime = cBar.EndTime.Add(tsSpan);
			DateTime dtLimit = cBar.StartTime.AddMilliseconds(10);
			if (dtTime < dtLimit)
				cBar.EndTime = dtLimit;
			else
				cBar.EndTime = dtTime;

			UpdateLinkInfo(cBar);

			UpdateLayout();
		}

		protected void CreateBarFinishBy(CGanttItem cItem)
		{
			cItem.BarS.Sort();
			UpdateLayout();
		}

		protected CGanttLink CreateLinkStartBy(CGanttBar cBarFrom, Point pntPosFrom)
		{
			CGanttLink cLink = new CGanttLink();
			cLink.BarFrom = cBarFrom;
			cLink.PointTypeFrom = GetPointType(cBarFrom, pntPosFrom);

			CGanttViewLinkInfo cLinkInfo = new CGanttViewLinkInfo();
			UpdateViewLink(cLink, cLinkInfo);

			m_cViewLinkS.Add(cLink, cLinkInfo);

			return cLink;
		}

		protected void CreateLinkProcressBy(CGanttLink cLink, Point pntPosTo)
		{
			CGanttViewLinkInfo cLinkInfo = m_cViewLinkS[cLink];

			UpdateViewLink(cLink, cLinkInfo, pntPosTo);

			UpdateLayout();
		}

		protected void CreateLinkFinishBy(CGanttLink cLink, Point pntPosTo)
		{
			CGanttItem cItemTo = PickItem(pntPosTo);
			if (cItemTo == null)
			{
				m_cViewLinkS.Remove(cLink);
				return;
			}

			CGanttBar cBarTo = PickBar(cItemTo, pntPosTo);
			if(cBarTo == null)
			{
				m_cViewLinkS.Remove(cLink);
				return;
			}

			cLink.BarTo = cBarTo;
			cLink.PointTypeTo = GetPointType(cBarTo, pntPosTo);

			CGanttViewLinkInfo cLinkInfo = m_cViewLinkS[cLink];
			UpdateViewLink(cLink, cLinkInfo);

			m_ucGanttTree.LinkS.Add(cLink);

			UpdateLayout();
		}

		protected void DeleteBarBy(CGanttItem cItem, CGanttBar cBar)
		{
			cItem.BarS.Remove(cBar);

			CGanttViewItemInfo cItemInfo = m_cViewItemS[cItem];
			if (cItemInfo.BarIndexFrom == cItemInfo.BarIndexTo)
			{
				cItemInfo.BarIndexFrom = -1;
				cItemInfo.BarIndexTo = -1;
			}
			else
			{
				cItemInfo.BarIndexTo -= 1;
			}

			m_ucGanttTree.LinkS.Remove(cBar);
			m_cViewLinkS.Remove(cBar);

			UpdateLayout();
		}

		protected void DeleteLinkBy(CGanttLink cLink)
		{
			m_ucGanttTree.LinkS.Remove(cLink);
			m_cViewLinkS.Remove(cLink);

			UpdateLayout();
		}

		protected void MoveBarBy(CGanttItem cItem, CGanttBar cBar, float nDelta)
		{
			TimeSpan tsSpan = m_ucTimeLine.CalcTimeSpan(nDelta);

			cBar.StartTime = m_cSelectedBar.StartTime.Add(tsSpan);
			cBar.EndTime = m_cSelectedBar.EndTime.Add(tsSpan);

			UpdateLinkInfo(cBar);

			UpdateLayout();
		}
		protected void ResizeBarStartPointBy(CGanttBar cBar, float nDelta)
		{
			TimeSpan tsSpan = m_ucTimeLine.CalcTimeSpan(nDelta);
			DateTime dtTime = cBar.StartTime.Add(tsSpan);
			DateTime dtLimit = cBar.EndTime.AddMilliseconds(-10);
			if (dtTime > dtLimit)
				cBar.StartTime = dtLimit;
			else
				cBar.StartTime = dtTime;

			UpdateLinkInfo(cBar);

			UpdateLayout();
		}

		protected void ResizeBarEndPointBy(CGanttBar cBar, float nDelta)
		{
			TimeSpan tsSpan = m_ucTimeLine.CalcTimeSpan(nDelta);
			DateTime dtTime = cBar.EndTime.Add(tsSpan);
			DateTime dtLimit = cBar.StartTime.AddMilliseconds(10);
			if (dtTime < dtLimit)
				cBar.EndTime = dtLimit;
			else
				cBar.EndTime = dtTime;

			UpdateLinkInfo(cBar);

			UpdateLayout();
		}

		protected void HitTestBy(Point pntPos)
		{
			m_cSelectedItem = null;
			m_cSelectedBar = null;
			m_cSelectedLink = null;

			m_cSelectedItem = PickItem(pntPos);
			if (m_cSelectedItem != null)
			{
				m_cSelectedBar = PickBar(m_cSelectedItem, pntPos);
				if (m_cSelectedBar == null)
					m_cSelectedLink = PickLink(pntPos);
			}

			if(m_cSelectedItem != null)
				m_ucGanttTree.FocusedItem = m_cSelectedItem;
			
			UpdateLayout();
		}

		protected void ReArrangeBarBy(CGanttItem cItem)
		{
			cItem.BarS.Sort();
			UpdateLayout();
		}

		#endregion

		#region Util

		protected bool IsInsideViewRange(CGanttBar cBar)
		{
			if (cBar.StartTime >= m_ucTimeLine.FirstVisibleTime && cBar.StartTime < m_ucTimeLine.LastVisibleTime)
				return true;
			else if (cBar.EndTime >= m_ucTimeLine.FirstVisibleTime && cBar.EndTime < m_ucTimeLine.LastVisibleTime)
				return true;
			else
				return false;
		}

		protected bool IsBarStartRange(CGanttBar cBar, Point pntPos)
		{
			bool bOK = false;

			float nPosX = m_ucTimeLine.CalcPosition(cBar.StartTime);
			float nPosY = m_ucGanttTree.CalcPosition(cBar.Item);

			RectangleF rRange = new RectangleF(nPosX - 10f, nPosY, 10, m_ucGanttTree.ItemHeight);
			bOK = rRange.Contains(pntPos);

			return bOK;
		}

		protected bool IsBarEndRange(CGanttBar cBar, Point pntPos)
		{
			bool bOK = false;

			float nPosX = m_ucTimeLine.CalcPosition(cBar.EndTime);
			float nPosY = m_ucGanttTree.CalcPosition(cBar.Item);

			RectangleF rRange = new RectangleF(nPosX, nPosY, 10, m_ucGanttTree.ItemHeight);
			bOK = rRange.Contains(pntPos);

			return bOK;
		}

		protected EMGanttLinkPointType GetPointType(CGanttBar cBar, Point pntPos)
		{
			EMGanttLinkPointType emPointType = EMGanttLinkPointType.Start;

			float nStartX = pntPos.X - m_ucTimeLine.CalcPosition(cBar.StartTime);
			float nEndX = m_ucTimeLine.CalcPosition(cBar.EndTime) - pntPos.X;

			if (nStartX > nEndX)
				emPointType = EMGanttLinkPointType.End;

			return emPointType;
		}

		protected DashStyle ToDashStyle(EMGanttLinkLineType emLineType)
		{
			DashStyle emStyle = DashStyle.Solid;
			if (emLineType == EMGanttLinkLineType.Dot)
				emStyle = DashStyle.Dot;
			else if (emLineType == EMGanttLinkLineType.Dash)
				emStyle = DashStyle.Dash;

			return emStyle;
		}

		protected CustomLineCap ToCapStyle(EMGanttLinkCapType emCapType, float nSize)
		{
			GraphicsPath gPath = new GraphicsPath();
			if (emCapType == EMGanttLinkCapType.Arrow)
			{
				gPath.AddLine(-nSize, -nSize, nSize, -nSize);
				gPath.AddLine(nSize, -nSize, 0, nSize);
				gPath.AddLine(0, nSize, -nSize, -nSize);
			}
			else if (emCapType == EMGanttLinkCapType.Round)
			{
				gPath.AddEllipse(new RectangleF(-nSize, -nSize, 2 * nSize, 2 * nSize));
			}
			else
			{
				gPath.AddLine(-nSize, -nSize, nSize, -nSize);
				gPath.AddLine(nSize, -nSize, nSize, nSize);
				gPath.AddLine(nSize, nSize, -nSize, nSize);
				gPath.AddLine(-nSize, nSize, -nSize, -nSize);
			}

			CustomLineCap cCapStyle = new CustomLineCap(gPath, null);

			return cCapStyle;
		}

		#endregion

		#region Raising Event

		protected void GenerateBarCreatedEvent(CGanttBar cBar)
		{
			if (UEventBarCreated != null)
				UEventBarCreated(this, cBar);
		}

		protected void GenerateBarRemovedEvent(CGanttBar cBar)
		{
			if (UEventBarRemoved != null)
				UEventBarRemoved(this, cBar);
		}

		protected void GenerateBarMovedEvent(CGanttBar cBar)
		{
			if (UEventBarMoved != null)
				UEventBarMoved(this, cBar);
		}

		protected void GenerateBarResizedEvent(CGanttBar cBar)
		{
			if (UEventBarResized != null)
				UEventBarResized(this, cBar);
		}

		protected void GenerateLinkCreatedEvent(CGanttLink cLink)
		{
			if (UEventLinkCreated != null)
				UEventLinkCreated(this, cLink);
		}

		protected void GenerateLinkRemovedEvent(CGanttLink cLink)
		{
			if (UEventLinkRemoved != null)
				UEventLinkRemoved(this, cLink);
		}

        protected void GenerateBarClickedEvent(CGanttBar cBar, EventArgs e)
		{
			if (UEventBarClicked != null)
				UEventBarClicked(this, cBar, e);
		}

		protected void GenerateLinkClickedEvent(CGanttLink cLink)
		{
			if (UEventLinkClicked != null)
				UEventLinkClicked(this, cLink);
		}

        protected void GenerateBarDoubleClickedEvent(CGanttBar cBar, EventArgs e)
		{
			if (UEventBarDoubleClicked != null)
				UEventBarDoubleClicked(this, cBar, e);
		}

		protected void GenerateLinkDoubleClickedEvent(CGanttLink cLink, EventArgs e)
		{
			if (UEventLinkDoubleClicked != null)
				UEventLinkDoubleClicked(this, cLink, e);
		}

		#endregion

		#region Drawing

		#region Layout

		protected void DrawLayout(Graphics g)
		{
			g.DrawRectangle(Pens.LightGray, 0, 0, this.Width - 1, this.Height - 1);
		}

		protected void DrawRubber(Graphics graphics)
		{
			if (MouseButtons == System.Windows.Forms.MouseButtons.Right)
			{
				Point pnt = this.PointToClient(MousePosition);
				Rectangle rctFrame = new Rectangle(
					Math.Min((int)m_pntMousePos.X, pnt.X),
					Math.Min((int)m_pntMousePos.Y, pnt.Y),
					Math.Abs((int)m_pntMousePos.X - pnt.X),
					Math.Abs((int)m_pntMousePos.Y - pnt.Y));

				Pen pnFrame = new Pen(Color.Blue);
				pnFrame.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
				graphics.DrawRectangle(pnFrame, rctFrame);

				pnFrame.Dispose();
				pnFrame = null;
			}
		}

		#endregion

		#region Time Line
		
		public void DrawTimeLine(Graphics g, bool bShowMinorGrid)
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.VisibleUnitWidth || this.Height < m_ucGanttTree.ColumnHeight)
				return;

			float nBoundX = this.ClientRectangle.Width;
			float nBoundY = this.ClientRectangle.Height;
			float nTimePosX = -1 * m_ucTimeLine.VisibleUnitWidth * ((float)m_ucTimeLine.FirstVisibleTime.Millisecond / 1000);

			int iTopTime = m_ucTimeLine.FirstVisibleTime.Hour;
			int iMajorTime = m_ucTimeLine.FirstVisibleTime.Minute;
			int iMinorTime = m_ucTimeLine.FirstVisibleTime.Second;

			while (nBoundX >= nTimePosX)
			{
				if (iMinorTime == 0)
					g.DrawLine(Pens.Gray, nTimePosX, 0, nTimePosX, nBoundY);
				else if (bShowMinorGrid)
					g.DrawLine(Pens.Gray, nTimePosX, 0, nTimePosX, nBoundY);

				iMinorTime += 1;
				if (iMinorTime == 60)
				{
					iMinorTime = 0;
					iMajorTime += 1;
					if (iMajorTime == 60)
					{
						iMajorTime = 0;
						iTopTime += 1;
						if (iTopTime == 24)
							iTopTime = 0;
					}
				}

				nTimePosX += m_ucTimeLine.VisibleUnitWidth;
			}
		}

		public void DrawTimeZoneS(Graphics g)
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucGanttTree.ColumnHeight)
				return;

			float nBoundX = this.ClientRectangle.Width;
			float nBoundY = this.ClientRectangle.Height;

			Pen penZone = new Pen(Color.Black);
			SolidBrush brsZone = new SolidBrush(Color.Black);

			RectangleF rZone = new RectangleF();

			float nTemp;
			CTimeZone cZone;
			for (int i = 0; i < m_ucTimeLine.TimeZoneS.Count; i++)
			{
				cZone = m_ucTimeLine.TimeZoneS[i];
				if (cZone.To < m_ucTimeLine.FirstVisibleTime || cZone.From > m_ucTimeLine.LastVisibleTime)
					continue;

				nTemp = m_ucTimeLine.CalcPosition(cZone.From);
				if (nTemp < 0)
					nTemp = 0;

				rZone.X = nTemp;

				nTemp = m_ucTimeLine.CalcPosition(cZone.To);
				if (nTemp > nBoundX)
					nTemp = nBoundX;

				rZone.Width = nTemp - rZone.X;

				rZone.Y = 0;
				rZone.Height = nBoundY;

				brsZone.Color = cZone.Color;

				g.FillRectangle(brsZone, rZone);
				//g.DrawRectangle(penZone, rZone.X, rZone.Y, rZone.Width, rZone.Height);
			}

			brsZone.Dispose();
			brsZone = null;

			penZone.Dispose();
			penZone = null;
		}

		public void DrawTimeIndicatorS(Graphics g)
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucGanttTree.ColumnHeight)
				return;

			float nBoundX = this.ClientRectangle.Width;
			float nBoundY = this.ClientRectangle.Height;

			Pen penIndicator = new Pen(Color.Black, 2);

			float nTemp;
			CTimeIndicator cIndicator;
			for (int i = 0; i < m_ucTimeLine.TimeIndicatorS.Count; i++)
			{
				cIndicator = m_ucTimeLine.TimeIndicatorS[i];
				if (cIndicator.Time < m_ucTimeLine.FirstVisibleTime || cIndicator.Time > m_ucTimeLine.LastVisibleTime)
					continue;

				nTemp = m_ucTimeLine.CalcPosition(cIndicator.Time);

				penIndicator.Color = cIndicator.Color;
				g.DrawLine(penIndicator, nTemp, 0, nTemp, nBoundY);
			}

			penIndicator.Dispose();
			penIndicator = null;
		}

		#endregion

		#region Grid Line

		protected void DrawGridLine(Graphics g)
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucGanttTree.ColumnHeight)
				return;

			float nBoundX = g.ClipBounds.Width;
			float nBoundY = m_ucGanttTree.TotalVisibleItemCount * (m_ucGanttTree.ItemHeight + 1);

			float nPosY = 0;
			while (nPosY >= 0)
			{
				g.DrawLine(Pens.LightGray, 0, nPosY, nBoundX, nPosY);
				nPosY += m_ucGanttTree.ItemHeight + 1;
				if (nPosY > nBoundY)
					break;
			}
		}

		#endregion

		#region Gantt Bar

		protected void DrawBarS(Graphics g)
		{
			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucGanttTree.ColumnHeight)
				return;

			Pen penBorder = new Pen(Color.Black);

			float nPosY1 = 0;
			float nHeightHalf = (float)m_ucGanttTree.ItemHeight / 2;
			StringFormat sfText = new StringFormat();
			sfText.Alignment = StringAlignment.Center;
			CGanttItem cFocusedItem = (CGanttItem)m_ucGanttTree.FocusedItem;

			CGanttItem cItem;
			CGanttViewItemInfo cItemInfo;
			for (int i = 0; i < m_cViewItemS.Count; i++)
			{
				cItem = m_cViewItemS.ElementAt(i).Key;
				if (cItem == cFocusedItem)
					g.FillRectangle(Brushes.Lavender, 0, nPosY1, this.Width, m_ucGanttTree.ItemHeight + 1);

				cItemInfo = m_cViewItemS.ElementAt(i).Value;
				if (cItemInfo.BarIndexFrom >= 0)
				{
					CGanttBar cBar = null;
					for (int j = cItemInfo.BarIndexFrom; j < cItemInfo.BarIndexTo + 1; j++)
					{
						cBar = cItem.BarS[j];
						DrawBar(g, penBorder, cBar, nPosY1 + nHeightHalf, sfText);
					}
				}

				nPosY1 += m_ucGanttTree.ItemHeight + 1;
			}

			penBorder.Dispose();
			penBorder = null;
		}

		protected void DrawBar(Graphics g, Pen penBorder, CGanttBar cBar, float nCenterY, StringFormat sfText)
		{
			if (cBar.StartTime == DateTime.MinValue || cBar.EndTime == DateTime.MinValue)
				return;

			float nPosX1 = m_ucTimeLine.CalcPosition(cBar.StartTime);
			float nPosX2 = m_ucTimeLine.CalcPosition(cBar.EndTime);
			float nHeight = (float)cBar.Height / 2;
			float nPosY1 = nCenterY - nHeight + cBar.OffSet;
			float nPosY2 = nCenterY + nHeight + cBar.OffSet;
			RectangleF rctBar = new RectangleF(nPosX1, nPosY1, nPosX2 - nPosX1, nPosY2 - nPosY1);

			SolidBrush brsBar = new SolidBrush(cBar.Color);
			g.FillRectangle(brsBar, rctBar);

			if (cBar == m_cSelectedBar)
			{
				penBorder.Width = 2f;
				g.DrawRectangle(penBorder, rctBar.X - 1, rctBar.Y - 1, rctBar.Width + 2, rctBar.Height + 2);
			}
			else
			{
				penBorder.Width = 1f;
				g.DrawRectangle(penBorder, rctBar.X, rctBar.Y, rctBar.Width, rctBar.Height);
			}

			g.DrawString(cBar.Text, m_fntFont, Brushes.Black, rctBar, sfText);

			brsBar.Dispose();
			brsBar = null;
		}

		protected void DrawLinkS(Graphics g)
		{
			Pen penLink = new Pen(Color.Transparent, 1.5f);

			CGanttLink cLink;
			CGanttViewLinkInfo cLinkInfo;
			for (int i = 0; i < m_cViewLinkS.Count; i++)
			{
				cLink = m_cViewLinkS.ElementAt(i).Key;
				cLinkInfo = m_cViewLinkS.ElementAt(i).Value;

				penLink = new Pen(cLink.Color);
				penLink.DashStyle = ToDashStyle(cLink.LineType);
				penLink.CustomStartCap = ToCapStyle(cLink.CapTypeFrom, 1.5f);
				penLink.CustomEndCap = ToCapStyle(cLink.CapTypeTo, 1.5f);

				if (cLink == m_cSelectedLink)
				{
					penLink.Width = 2f;
					g.DrawPath(penLink, cLinkInfo.PathInfo);
				}
				else
				{
					penLink.Width = 1f;
					g.DrawPath(penLink, cLinkInfo.PathInfo);
				}
			}

			penLink.Dispose();
			penLink = null;
		}

		#endregion		

		#endregion

		#endregion


		#region Event Methods

		#region Override

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
		{
			base.OnPaint(pe);

			DrawTimeZoneS(pe.Graphics);

			DrawGridLine(pe.Graphics);

			DrawBarS(pe.Graphics);
			DrawLinkS(pe.Graphics);

			DrawTimeLine(pe.Graphics, false);
			DrawTimeIndicatorS(pe.Graphics);

			DrawRubber(pe.Graphics);

			DrawLayout(pe.Graphics);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (m_ucGanttTree == null || m_ucTimeLine == null)
				return;

			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				m_emActionType = EMActionType.MoveTime;

				if (m_bEditable)
				{
					if (Control.ModifierKeys == Keys.Control)
					{
						HitTestBy(e.Location);
						if(m_cSelectedBar == null)
						{
							m_cSelectedBar = CreateBarStartBy(m_cSelectedItem, e.Location.X);
							m_emActionType = EMActionType.AddBar;
						}
						else
						{
							m_cSelectedLink = CreateLinkStartBy(m_cSelectedBar, e.Location);
							m_emActionType = EMActionType.AddLink;
						}
					}
					else if (m_cSelectedBar != null)
					{
						if (IsBarStartRange(m_cSelectedBar, e.Location))
						{
							this.Cursor = Cursors.SizeWE;
							m_emActionType = EMActionType.ResizeBarStart;
						}
						else if (IsBarEndRange(m_cSelectedBar, e.Location))
						{
							this.Cursor = Cursors.SizeWE;
							m_emActionType = EMActionType.ResizeBarEnd;
						}
						else
						{
							HitTestBy(e.Location);
							if (m_cSelectedBar != null)
								m_emActionType = EMActionType.MoveBar;
						}
					}
					else
					{
						HitTestBy(e.Location);
						if (m_cSelectedBar != null)
							m_emActionType = EMActionType.MoveBar;
					}
				}
				else
				{
					HitTestBy(e.Location);
				}
			}
			else if(e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				m_emActionType = EMActionType.Zoom;
			}

			m_pntMousePos = e.Location;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if(m_emActionType == EMActionType.AddBar)
			{
				float nDelta = e.Location.X - m_pntMousePos.X;
				m_pntMousePos = e.Location;

				CreateBarProcessBy(m_cSelectedBar, nDelta);
			}
			else if (m_emActionType == EMActionType.AddLink)
			{
				m_pntMousePos = e.Location;

				CreateLinkProcressBy(m_cSelectedLink, e.Location);
			}
			else if(m_emActionType == EMActionType.MoveBar)
			{
				float nDelta = e.Location.X - m_pntMousePos.X;
				m_pntMousePos = e.Location;

				MoveBarBy(m_cSelectedItem, m_cSelectedBar, nDelta);
			}
			else if(m_emActionType == EMActionType.ResizeBarStart)
			{
				float nDelta = e.Location.X - m_pntMousePos.X;
				m_pntMousePos = e.Location;

				ResizeBarStartPointBy(m_cSelectedBar, nDelta);
			}
			else if (m_emActionType == EMActionType.ResizeBarEnd)
			{
				float nDelta = e.Location.X - m_pntMousePos.X;
				m_pntMousePos = e.Location;

				ResizeBarEndPointBy(m_cSelectedBar, nDelta);
			}			
			else if(m_emActionType == EMActionType.MoveTime)
			{
				float nDelta = m_pntMousePos.X - e.Location.X;
				m_pntMousePos = e.Location;

				MoveTimeBy(nDelta);
			}
			else if(m_emActionType == EMActionType.Zoom)
			{
				//ShowRubberBand();
			}
			else
			{
				if(Control.MouseButtons == System.Windows.Forms.MouseButtons.None)
				{
					if(m_cSelectedBar != null)
					{
						//Point pntPos = this.PointToClient(e.Location);
						if (IsBarStartRange(m_cSelectedBar, e.Location))
							this.Cursor = Cursors.SizeWE;
						else if (IsBarEndRange(m_cSelectedBar, e.Location))
							this.Cursor = Cursors.SizeWE;
						else
							this.Cursor = Cursors.Default;
					}
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if(m_emActionType == EMActionType.AddBar)
			{	
				CreateBarFinishBy(m_cSelectedItem);
				GenerateBarCreatedEvent(m_cSelectedBar);
			}
			else if (m_emActionType == EMActionType.AddLink)
			{
				CreateLinkFinishBy(m_cSelectedLink, e.Location);
				GenerateLinkCreatedEvent(m_cSelectedLink);
			}
			else if(m_emActionType == EMActionType.MoveBar)
			{
				ReArrangeBarBy(m_cSelectedItem);
				GenerateBarMovedEvent(m_cSelectedBar);
			}
			else if(m_emActionType == EMActionType.ResizeBarStart || m_emActionType == EMActionType.ResizeBarEnd)
			{
				ReArrangeBarBy(m_cSelectedItem);
				GenerateBarResizedEvent(m_cSelectedBar);
			}
			else if(m_emActionType == EMActionType.Zoom)
			{
				float nDelta = m_pntMousePos.X - e.Location.X;
				if (Math.Abs(nDelta) > 10)
				{
					ZoomBy(nDelta);
					if (this.ContextMenuStrip != null)
						this.ContextMenuStrip.Visible = false;
				}
				else
				{
					if (this.ContextMenuStrip != null)
						this.ContextMenuStrip.Visible = true;
				}
			}

			m_emActionType = EMActionType.None;
			this.Cursor = Cursors.Default;

			if (m_cSelectedBar != null)
				GenerateBarClickedEvent(m_cSelectedBar, e);
			else if (m_cSelectedLink != null)
				GenerateLinkClickedEvent(m_cSelectedLink);
		}

		protected void OnMouseWheelEvent(MouseEventArgs e)
		{	
			base.OnMouseWheel(e);

			if (m_ucGanttTree == null)
				return;

			if(e.Delta > 0)
			{
				int iIndex = m_ucGanttTree.FirstVisibleItemIndex - 1;
				if (iIndex < 0)
					return;

				m_ucGanttTree.FirstVisibleItemIndex = iIndex;
				
			}
			else if(e.Delta < 0)
			{
				int iIndex = m_ucGanttTree.FirstVisibleItemIndex + 1;
				if (iIndex > m_ucGanttTree.TotalVisibleItemCount - m_ucGanttTree.PageVisibleItemCount + 1)
					return;

				m_ucGanttTree.FirstVisibleItemIndex = iIndex;
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);

            
			if (m_cSelectedBar != null)
				GenerateBarDoubleClickedEvent(m_cSelectedBar, e);
			else if (m_cSelectedLink != null)
				GenerateLinkDoubleClickedEvent(m_cSelectedLink, e);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			if(e.KeyCode == Keys.Delete )
			{
				if(m_bEditable)
				{
					if (m_cSelectedItem != null && m_cSelectedBar != null)
					{
						DeleteBarBy(m_cSelectedItem, m_cSelectedBar);
						GenerateBarRemovedEvent(m_cSelectedBar);

						m_cSelectedBar = null;
					}
					else if(m_cSelectedLink != null)
					{
						DeleteLinkBy(m_cSelectedLink);
						GenerateLinkRemovedEvent(m_cSelectedLink);

						m_cSelectedLink = null;
					}
				}
			}
		}
		
		#endregion
		
		#region Time Line

		protected void m_ucTimeLine_UEventLayoutUpdated(object sender)
		{
			UpdateViewItemInfoS();
			UpdateViewLinkS();
			UpdateLayout();
		}

		#endregion

		#region Gantt Tree

		protected void m_ucGanttTree_UEventLayoutUpdated(object sender)
		{
			UpdateViewItemS();
			UpdateViewLinkS();
			UpdateLayout();
		}


		#endregion

		#endregion

	}
}
