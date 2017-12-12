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
	public partial class UCSeriesChart : UCCanvas
	{

		#region Member Variables

		protected UCTimeLine m_ucTimeLine = null;
		protected UCSeriesTree m_ucSeriesTree = null;
		protected CSeriesAxis m_cAxis = null;

		protected EMSeriesChartType m_emChartType = EMSeriesChartType.Line;
		protected CSeriesViewItemInfoS m_cViewItemS = new CSeriesViewItemInfoS();
		protected CSeriesItem m_cSelectedItem = null;
		protected CSeriesPoint m_cSelectedPoint = null;
		protected EMActionType m_emActionType = EMActionType.None;
		protected PointF m_pntMousePos = new PointF();

		protected int m_iAxisOffSet = 5;
		protected float m_nAxisFirstVisibleValue = 0f;
		protected float m_nAxisLastVisibleValue = 0f;
		protected float m_nAxisUnitHeight = 0f;
		protected float m_nAxisUnitValue = 0f;

		protected int m_iAxisScrollMaxValue = 1;
		protected int m_iAxisScrollMinValue = 0;
		protected int m_iAxisScrollValue = 0;
		protected int m_iAxisScrollLargeChange = 1;

		public event UEventHandlerSeriesChartPointClicked UEventPointClicked;
		public event UEventHandlerSeriesChartPointDoubleClicked UEventPointDoubleClicked;
		public event UEventHandlerSeriesChartAxisScrollChanged UEventAxisScrollChanged;

		#endregion


		#region Initalize/Dispose

		public UCSeriesChart()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCSeriesChart(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public UCTimeLine TimeLine
		{
			get { return m_ucTimeLine; }
			set { SetTimeLine(value); }
		}

		public UCSeriesTree SeriesTree
		{
			get { return m_ucSeriesTree; }
			set { SetSeriesTree(value); }
		}

		public CSeriesAxis Axis
		{
			get { return m_cAxis; }
			set { m_cAxis = value; }
		}

		public EMSeriesChartType ChartType
		{
			get { return m_emChartType; }
			set { m_emChartType = value; }
		}

		public CSeriesItem FocusedItem
		{
			get { return m_cSelectedItem; }
		}

		public CSeriesPoint FocusedPoint
		{
			get { return m_cSelectedPoint; }
		}

		public float MajorUnitHeight
		{
			get { return m_nAxisUnitHeight; }
		}

		public float MajorUnitValue
		{
			get { return m_nAxisUnitValue; }
		}

		public int AxisScrollMaxValue
		{
			get { return m_iAxisScrollMaxValue; }
		}

		public int AxisScrollMinValue
		{
			get { return m_iAxisScrollMinValue; }
		}

		public int AxisScrollValue
		{
			get { return m_iAxisScrollValue; }
			set { SetScrollValue(value); }
		}

		public int AxisScrollLargeChange
		{
			get { return m_iAxisScrollLargeChange; }
		}

		#endregion


		#region Public Methods

		#region Layout

		public new void UpdateLayout()
		{
			UpdateViewInfoS();

			this.Refresh();

			GenerateLayoutUpdatedEvent();
		}

		#endregion


		#region Item

		public float CalcValue(float nPosY)
		{
			if (m_ucSeriesTree == null)
				return -1;

			if (m_nAxisUnitHeight == 0)
				return -1;

			float nDiffY = (float)(this.ClientRectangle.Height - m_iAxisOffSet) - nPosY;
			float nValue = m_nAxisFirstVisibleValue + nDiffY * m_nAxisUnitValue / m_nAxisUnitHeight;

			return nValue;
		}

		public float CalcPositionY(float nValue)
		{
			if (m_ucSeriesTree == null)
				return -1;

			if (m_nAxisUnitValue == 0)
				return -1;

			float nDiffValue = nValue - m_nAxisFirstVisibleValue;
			float nPosY = (float)(this.ClientRectangle.Height - m_iAxisOffSet) - nDiffValue * m_nAxisUnitHeight / m_nAxisUnitValue;

			return nPosY;
		}

		public CSeriesItem PickItem(Point pntPos)
		{
			Pen penItem = new Pen(Color.Black, 8f);

			CSeriesViewItemInfo cItemInfo = null;
			CSeriesItem cItem = null;
			for(int i=0;i<m_cViewItemS.Count;i++)
			{
				cItemInfo = m_cViewItemS.ElementAt(i).Value;
				if (cItemInfo.PathInfo.IsOutlineVisible(pntPos, penItem))
				{
					cItem = m_cViewItemS.ElementAt(i).Key;
					break;
				}
			}

			penItem.Dispose();
			penItem = null;

			return cItem;
		}

		public CSeriesPoint PickPoint(CSeriesItem cItem, Point pntPos)
		{
			if (m_cViewItemS.ContainsKey(cItem) == false)
				return null;

			CSeriesViewItemInfo cItemInfo = m_cViewItemS[cItem];
			if (cItemInfo.PathInfo.PointCount == 0)
				return null;

			CSeriesPoint cPoint = null;
	
			float nHalfSize = cItem.PointSize/2;
			RectangleF rctPoint = new RectangleF();
			PointF[] pntPointS = cItemInfo.PathInfo.PathPoints;
			PointF pntPoint;
			for(int i=0;i<pntPointS.Length;i++)
			{
				pntPoint = pntPointS[i];
				rctPoint.X = pntPoint.X - nHalfSize;
				rctPoint.Y = pntPoint.Y - nHalfSize;
				rctPoint.Width = cItem.PointSize;
				rctPoint.Height = cItem.PointSize;

				if(rctPoint.Contains(pntPos))
				{
					int iPointIndex = cItemInfo.PointIndexFrom + i;
					cPoint = cItem.PointS[iPointIndex];
					break;
				}
			}

			return cPoint;
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

		protected  void InitVariables()
		{	
			m_cAxis = new CSeriesAxis();
			CBaseMouseWheelControlHelper.Add(this, OnMouseWheelEvent);
		}

		protected void SetTimeLine(UCTimeLine ucTimeLine)
		{
			if (m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventLayoutUpdated -= m_ucTimeLine_UEventLayoutUpdated;
				m_ucTimeLine.UEventZoomIn -= m_ucTimeLine_UEventZoomIn;
				m_ucTimeLine.UEventZoomOut -= m_ucTimeLine_UEventZoomOut;
			}

			m_ucTimeLine = ucTimeLine;
			if (m_ucTimeLine != null)
			{
				m_ucTimeLine.UEventLayoutUpdated += m_ucTimeLine_UEventLayoutUpdated;
				m_ucTimeLine.UEventZoomIn += m_ucTimeLine_UEventZoomIn;
				m_ucTimeLine.UEventZoomOut += m_ucTimeLine_UEventZoomOut;
			}
		}

		protected void SetSeriesTree(UCSeriesTree ucSeriesTree)
		{
			if (m_ucSeriesTree != null)
			{	
				m_ucSeriesTree.UEventLayoutUpdated -= m_ucSeriesTree_UEventLayoutUpdated;
			}

			m_ucSeriesTree = ucSeriesTree;
			if (m_ucSeriesTree != null)
			{
				m_ucSeriesTree.UEventLayoutUpdated += m_ucSeriesTree_UEventLayoutUpdated;
			}
		}

		protected void SetScrollValue(int iValue)
		{
			if (m_iAxisScrollValue != iValue)
			{
				if (iValue > m_iAxisScrollMaxValue)
					m_iAxisScrollValue = m_iAxisScrollMaxValue;
				else if (iValue < m_iAxisScrollMinValue)
					m_iAxisScrollValue = m_iAxisScrollMinValue;
				else
					m_iAxisScrollValue = iValue;

				m_nAxisFirstVisibleValue = (m_cAxis.Maximum - m_cAxis.Minimumn) * m_iAxisScrollValue / m_iAxisScrollMaxValue + m_cAxis.Minimumn;

				UpdateLayout();

				GenerateAxisScrollChangedEvent();
			}
		}

		#endregion

		#region Item

		protected void UpdateViewInfoS()
		{
			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			m_nAxisUnitHeight = m_ucTimeLine.ZoomFactor * (float)(this.ClientRectangle.Height - 2 * m_iAxisOffSet) / (float)m_cAxis.MajorTickCount;
			m_nAxisUnitValue = (m_cAxis.Maximum - m_cAxis.Minimumn) / m_cAxis.MajorTickCount;

			m_cViewItemS.Clear();

			CSeriesItem cItem;
			CSeriesViewItemInfo cItemInfo;
			for (int i = 0; i < m_ucSeriesTree.ItemS.Count; i++)
			{
				cItem = (CSeriesItem)m_ucSeriesTree.ItemS[i];
				cItemInfo = new CSeriesViewItemInfo(-1, -1);

				UpdateViewInfo(cItem, cItemInfo);
				m_cViewItemS.Add(cItem, cItemInfo);
			}
		}

		protected void UpdateViewInfo(CSeriesItem cItem, CSeriesViewItemInfo cItemInfo)
		{
			bool bDrawStart = false;
			bool bDrawEnd = false;

			float nPosX1 = 0f;
			float nPosX2 = 0f;
			float nPosY1 = 0f;
			float nPosY2 = 0f;
			CSeriesPoint cPoint1 = null;
			CSeriesPoint cPoint2 = null;
			for (int i = 0; i < cItem.PointS.Count; i++)
			{
				cPoint2 = cItem.PointS[i];
				if (bDrawStart == false && IsInsideViewRange(cPoint2))
				{
					bDrawStart = true;
					nPosX2 = m_ucTimeLine.CalcPosition(cPoint2.Time);
					nPosY2 = CalcPositionY(cPoint2.Value * cItem.Scale);

					if (cPoint1 != null)
						cItemInfo.PointIndexFrom = i - 1;
					else
						cItemInfo.PointIndexFrom = i;

					cItemInfo.PointIndexTo = i;

					if(cPoint1 != null)
					{
						nPosX1 = m_ucTimeLine.CalcPosition(cPoint1.Time);
						nPosY1 = CalcPositionY(cPoint1.Value*cItem.Scale);

						cItemInfo.PathInfo.AddLine(nPosX1, nPosY1, nPosX2, nPosY2);
					}
				}
				else if (bDrawStart && IsInsideViewRange(cPoint2))
				{
					nPosX2 = m_ucTimeLine.CalcPosition(cPoint2.Time);
					nPosY2 = CalcPositionY(cPoint2.Value * cItem.Scale);

					cItemInfo.PointIndexTo = i;
					cItemInfo.PathInfo.AddLine(nPosX1, nPosY1, nPosX2, nPosY2);
				}
				else if (bDrawStart && bDrawEnd == false && cPoint2.Time > m_ucTimeLine.LastVisibleTime)
				{
					nPosX2 = m_ucTimeLine.CalcPosition(cPoint2.Time);
					nPosY2 = CalcPositionY(cPoint2.Value * cItem.Scale);

					cItemInfo.PointIndexTo = i;
					cItemInfo.PathInfo.AddLine(nPosX1, nPosY1, nPosX2, nPosY2);

					break;
				}

				cPoint1 = cPoint2;
				nPosX1 = nPosX2;
				nPosY1 = nPosY2;
			}
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

		protected void HitTestBy(Point pntPos)
		{
			m_cSelectedItem = null;
			m_cSelectedPoint = null;

			m_cSelectedItem = PickItem(pntPos);
			if (m_cSelectedItem != null)
			{
				m_cSelectedPoint = PickPoint(m_cSelectedItem, pntPos);
			}

			UpdateLayout();
		}

		#endregion

		#region Util

		protected bool IsInsideViewRange(CSeriesPoint cPoint)
		{
			if (cPoint.Time >= m_ucTimeLine.FirstVisibleTime && cPoint.Time < m_ucTimeLine.LastVisibleTime)
				return true;
			else
				return false;
		}

		#endregion

		#region Raising Event

		protected void GenerateSeriesPointClickEvent(CSeriesPoint cPoint)
		{
			if (UEventPointClicked != null)
				UEventPointClicked(this, cPoint);
		}

		protected void GenerateSeriesPointDoubleClickEvent(CSeriesPoint cPoint)
		{
			if (UEventPointDoubleClicked != null)
				UEventPointDoubleClicked(this, cPoint);
		}

		protected void GenerateAxisScrollChangedEvent()
		{
			if (UEventAxisScrollChanged != null)
				UEventAxisScrollChanged(this);
		}

		#endregion

		#region Drawing

		#region Layout

		protected void DrawLayout(Graphics g)
		{
			g.DrawRectangle(Pens.LightGray, 0, 0, this.Width - 1, this.Height - 1);
		}

		#endregion

		#region Time Line

		public void DrawTimeLine(Graphics g, bool bShowMinorGrid)
		{
			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.VisibleUnitWidth || this.Height < m_ucSeriesTree.ColumnHeight)
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
			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucSeriesTree.ColumnHeight)
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
			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucSeriesTree.ColumnHeight)
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

		#region Axis

		protected void DrawAxis(Graphics g)
		{
			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucSeriesTree.ColumnHeight)
				return;

			Pen penMajorLine = new Pen(Color.LightGray);
			Pen penMinorLine = new Pen(Color.WhiteSmoke);
			Brush brsTick = Brushes.Black;


			float nWidth = this.ClientRectangle.Width - 2 * m_iAxisOffSet;
			float nHeight = this.ClientRectangle.Height - 2 * m_iAxisOffSet;
			float nLineEndPosX = this.ClientRectangle.Width - m_iAxisOffSet;
			float nTextOffSetY = CTimeChartUtil.MeasureStringHeight(g, "00", this.Font) / 2;

			float nMinorUnitHeight = m_nAxisUnitHeight / m_cAxis.MinorTickCount;
			m_nAxisLastVisibleValue = m_nAxisUnitValue * (float)(this.ClientRectangle.Height - 2 * m_iAxisOffSet) / m_nAxisUnitHeight + m_nAxisFirstVisibleValue;

			int iMinorTickCount = 0;
			float nMajorValue = m_nAxisFirstVisibleValue - m_nAxisFirstVisibleValue % m_nAxisUnitValue;
			float nLinePosY = this.ClientRectangle.Height - m_iAxisOffSet + (m_nAxisFirstVisibleValue % m_nAxisUnitValue) * m_nAxisUnitHeight / m_nAxisUnitValue;
			while (nLinePosY > (float)(this.ClientRectangle.Height - m_iAxisOffSet))
			{
				nLinePosY -= nMinorUnitHeight;
				iMinorTickCount += 1;
				if (iMinorTickCount == m_cAxis.MinorTickCount)
				{
					nMajorValue += m_nAxisUnitValue;
					iMinorTickCount = 0;
				}
			}

			while (nLinePosY >= m_iAxisOffSet)
			{
				if (iMinorTickCount == 0)	// Major Tick
				{
					g.DrawLine(penMajorLine, m_iAxisOffSet, nLinePosY, nLineEndPosX, nLinePosY);

					if(nLinePosY > nTextOffSetY)
						g.DrawString(nMajorValue.ToString(), this.Font, brsTick, new PointF(m_iAxisOffSet, nLinePosY - nTextOffSetY));
				}
				else
				{
					g.DrawLine(penMinorLine, m_iAxisOffSet, nLinePosY, nLineEndPosX, nLinePosY);
				}

				iMinorTickCount += 1;
				if (iMinorTickCount == m_cAxis.MinorTickCount)
				{
					nMajorValue += m_nAxisUnitValue;
					nMajorValue = CTimeChartUtil.ToDecimal2(nMajorValue);
					iMinorTickCount = 0;
				}

				nLinePosY -= nMinorUnitHeight;
				nLinePosY = CTimeChartUtil.ToDecimal2(nLinePosY);
			}

			g.DrawRectangle(Pens.Gray, m_iAxisOffSet, m_iAxisOffSet, nWidth, nHeight);
		}

		#endregion

		#region Series

		protected void DrawSeries(Graphics g)
		{
			if (m_ucSeriesTree == null || m_cAxis == null)
				return;

			if (this.Width < m_ucTimeLine.UnitWidth || this.Height < m_ucSeriesTree.ColumnHeight)
				return;


			CSeriesItem cItem;
			CSeriesViewItemInfo cItemInfo;
			for(int i=0;i<m_cViewItemS.Count;i++)
			{
				cItem = m_cViewItemS.ElementAt(i).Key;
				cItemInfo = m_cViewItemS.ElementAt(i).Value;
				DrawSeries(g, cItem, cItemInfo);
			}
		}

		protected void DrawSeries(Graphics g, CSeriesItem cItem, CSeriesViewItemInfo cItemInfo)
		{
			if (cItemInfo.PathInfo.PointCount == 0)
				return;

			PointF[] pntPointS = cItemInfo.PathInfo.PathPoints;

			Pen penSeries = new Pen(cItem.Color);
			g.DrawPath(penSeries, cItemInfo.PathInfo);

			if (cItem.ShowPoint)
			{
				Brush brsBrush = new SolidBrush(cItem.Color);
				float nHalfSize = cItem.PointSize / 2;

				RectangleF rctPoint = new RectangleF();
				PointF pntPoint;
				for (int i = 0; i < pntPointS.Length; i++)
				{
					pntPoint = pntPointS[i];
					rctPoint.X = pntPoint.X - nHalfSize;
					rctPoint.Y = pntPoint.Y - nHalfSize;
					rctPoint.Width = cItem.PointSize;
					rctPoint.Height = cItem.PointSize;

					g.FillEllipse(brsBrush, rctPoint);
					g.DrawEllipse(Pens.Black, rctPoint);
				}

				brsBrush.Dispose();
				brsBrush = null;
			}

			penSeries.Dispose();
			penSeries = null;
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

			DrawAxis(pe.Graphics);
			DrawSeries(pe.Graphics);

			DrawTimeLine(pe.Graphics, false);
			DrawTimeIndicatorS(pe.Graphics);

			DrawLayout(pe.Graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			UpdateLayout();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (m_ucSeriesTree == null || m_ucTimeLine == null)
				return;

			HitTestBy(e.Location);

			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				m_emActionType = EMActionType.MoveTime;
			}
			else if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				m_emActionType = EMActionType.Zoom;
			}

			m_pntMousePos = e.Location;
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{	
			if (m_emActionType == EMActionType.MoveTime)
			{
				float nDelta = m_pntMousePos.X - e.Location.X;
				m_pntMousePos = e.Location;

				MoveTimeBy(nDelta);
			}
			else if (m_emActionType == EMActionType.Zoom)
			{
				//ShowRubberBand();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			if (m_emActionType == EMActionType.Zoom)
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

			if (m_cSelectedPoint != null)
				GenerateSeriesPointClickEvent(m_cSelectedPoint);
		}

		protected void OnMouseWheelEvent(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				if(m_iAxisScrollValue >= m_iAxisScrollMaxValue)
					return;
				else
					m_iAxisScrollValue += 1;
			}
			else
			{
				if(m_iAxisScrollValue == 0)
					return;
				else
					m_iAxisScrollValue -= 1;
			}

			m_nAxisFirstVisibleValue = (m_cAxis.Maximum - m_cAxis.Minimumn) * m_iAxisScrollValue / m_iAxisScrollMaxValue + m_cAxis.Minimumn;

			base.OnMouseWheel(e);

			UpdateLayout();

			GenerateAxisScrollChangedEvent();
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			if (m_cSelectedPoint != null)
				GenerateSeriesPointDoubleClickEvent(m_cSelectedPoint);
		}

		#endregion

		#region Time Line

		protected void m_ucTimeLine_UEventLayoutUpdated(object sender)
		{
			UpdateLayout();
		}

		protected void m_ucTimeLine_UEventZoomIn(object sender)
		{
			if (m_iAxisScrollMaxValue == 0)
				m_iAxisScrollMaxValue = 0;
			else
				m_iAxisScrollValue = (int)((float)m_iAxisScrollValue * m_ucTimeLine.ZoomFactor / (float)m_iAxisScrollMaxValue);

			m_iAxisScrollMaxValue = (int)m_ucTimeLine.ZoomFactor;

			GenerateAxisScrollChangedEvent();
		}

		protected void m_ucTimeLine_UEventZoomOut(object sender)
		{
			if (m_iAxisScrollMaxValue == 0)
				m_iAxisScrollMaxValue = 0;
			else
				m_iAxisScrollValue = (int)((float)m_iAxisScrollValue * m_ucTimeLine.ZoomFactor / (float)m_iAxisScrollMaxValue);

			m_iAxisScrollMaxValue = (int)m_ucTimeLine.ZoomFactor;

			GenerateAxisScrollChangedEvent();
		}

		#endregion

		#region Series Tree

		protected void m_ucSeriesTree_UEventLayoutUpdated(object sender)
		{
			UpdateLayout();
		}

		#endregion

		#endregion
	}
}
