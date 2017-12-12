using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCTimeLine : UCCanvas
	{

		#region Member Variables

		protected DateTime m_dtRangeFrom = DateTime.MinValue;
		protected DateTime m_dtRangeTo = DateTime.MinValue;
		protected DateTime m_dtFirstVisible = DateTime.MinValue;
		protected DateTime m_dtLastVisible = DateTime.MinValue;

		protected float m_nVisibleUnitWidth = 20;
		protected float m_nUnitWidth = 20;		

		protected CTimeZoneS m_cTimeZoneS = new CTimeZoneS();
		protected CTimeIndicatorS m_cTimeIndicatorS = new CTimeIndicatorS();

		protected CTimeIndicator m_cSelectedIndicator = null;
		protected EMActionType m_emActionType = EMActionType.None;
		protected PointF m_pntMousePos = new PointF();

		protected float m_nZoomFactor = 1f; 
		protected int m_iScrollMaxValue = 1;
		protected int m_iScrollMinValue = 0;
		protected int m_iScrollValue = 0;
		protected int m_iScrollLargeChange = 10;

		public event UEventHandlerTimeLineFirstVisibleTimeChanged UEventFirstVisibleTimeChanged;
		public event UEventHandlerTimeLineScrollChanged UEventTimeScrollChanged;
		public event UEventHandlerTimeLineTimeIndicatorMoved UEventTimeIndicatorMoved;
		public event UEventHandlerTimeLineZoomIn UEventZoomIn;
		public event UEventHandlerTimeLineZoomOut UEventZoomOut;

		#endregion


		#region Initialize/Dispose

		public UCTimeLine()
		{
			InitializeComponent();

			InitVariables();
		}

		public UCTimeLine(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			InitVariables();
		}

		#endregion


		#region Public Properties

		public DateTime RangeFrom
		{
			get { return m_dtRangeFrom; }
			set { m_dtRangeFrom = value; SetTimeRange(); }
		}

		public DateTime RangeTo
		{
			get { return m_dtRangeTo; }
			set { m_dtRangeTo = value; SetTimeRange(); }
		}

		public DateTime FirstVisibleTime
		{
			get { return m_dtFirstVisible; }
			set { m_dtFirstVisible = value; SetFirstVisibleTime(); }
		}

		public DateTime LastVisibleTime
		{
			get { return m_dtLastVisible; }
		}

		public CTimeZoneS TimeZoneS
		{
			get { return m_cTimeZoneS; }
		}

		public CTimeIndicatorS TimeIndicatorS
		{
			get { return m_cTimeIndicatorS; }
		}

		public float UnitWidth
		{
			get { return m_nUnitWidth; }
			set { m_nUnitWidth = value; m_nVisibleUnitWidth = m_nUnitWidth * m_nZoomFactor; UpdateLayout(); }
		}
		
		public float VisibleUnitWidth
		{
			get { return m_nVisibleUnitWidth; }
		}

		public float ZoomFactor
		{
			get { return m_nZoomFactor; }
		}

		public int ScrollMaxValue
		{
			get { return m_iScrollMaxValue; }
		}

		public int ScrollMinValue
		{
			get { return m_iScrollMinValue; }
		}

		public int ScrollValue
		{
			get { return m_iScrollValue; }
			set { SetScrollValue(value); }
		}

		public int ScrollLargeChange
		{
			get { return m_iScrollLargeChange; }
		}

		#endregion


		#region Public Methods

		#region Layout

		public new void UpdateLayout()
		{
			double nElapseTime = (double)((float)this.Width / m_nVisibleUnitWidth);
			m_dtLastVisible = m_dtFirstVisible.AddSeconds(nElapseTime);

			this.Refresh();

			GenerateLayoutUpdatedEvent();
		}

		public new void BeginUpdate()
		{

		}

		public new void EndUpdate()
		{
			UpdateLayout();
		}

		public void ZoomIn()
		{
			if (m_nZoomFactor >= 128)
				return;

			m_nZoomFactor = m_nZoomFactor * 2;
			if (m_nZoomFactor >= 128)
				m_nZoomFactor = 128;

			m_nVisibleUnitWidth = m_nUnitWidth * m_nZoomFactor;

			GenerateZoomInEvent();

			UpdateLayout();
		}

		public void ZoomOut()
		{
			if (m_nVisibleUnitWidth <= 2f)
				return;

			m_nZoomFactor = m_nZoomFactor / 2;

			m_nVisibleUnitWidth = m_nUnitWidth * m_nZoomFactor;

			GenerateZoomOutEvent();

			UpdateLayout();
		}

		#endregion

		#region Item

		public void MoveTime(float nDelta)
		{
			TimeSpan tsSpan = CalcTimeSpan(nDelta);
			MoveTime(tsSpan);
		}

		public void MoveTime(TimeSpan tsSpan)
		{
			bool bOK = TryToMoveFirstTime(tsSpan);
			if(bOK == false)
			{
				tsSpan = m_dtFirstVisible.Subtract(DateTime.MinValue);
				m_dtFirstVisible = DateTime.MinValue;
			}
		}

		public void MoveTimeIndicator(CTimeIndicator cIndicator, float nDelta)
		{
			TimeSpan tsSpan = CalcTimeSpan(nDelta);
			MoveTimeIndicator(cIndicator, tsSpan);
		}

		public void MoveTimeIndicator(CTimeIndicator cIndicator, TimeSpan tsSpan)
		{
			cIndicator.Time = cIndicator.Time.Add(tsSpan);
			UpdateLayout();

			GenerateTimeIndicatorMovedEvent(cIndicator);
		}

		public CTimeIndicator PickTimeIndicator(float nPosX)
		{
			CTimeIndicator cIndicator = null;

			float nTimePosX = 0;
			CTimeIndicator cTemp;
			for (int i = 0; i < m_cTimeIndicatorS.Count; i++)
			{
				cTemp = m_cTimeIndicatorS[i];
				if (cTemp.Time < m_dtFirstVisible || cTemp.Time > m_dtLastVisible)
					continue;

				nTimePosX = CalcPosition(cTemp.Time);
				if (nTimePosX + 5 > nPosX && nPosX > nTimePosX - 5)
				{
					cIndicator = cTemp;
					break;
				}
			}

			return cIndicator;
		}

		public float CalcPosition(DateTime dtTime)
		{
			TimeSpan tsTime = dtTime.Subtract(m_dtFirstVisible);
			float nPosX = (float)(tsTime.TotalSeconds) * m_nVisibleUnitWidth;
			return nPosX;
		}

		public DateTime CalcTime(float nPosX)
		{
			float nUnit = nPosX / m_nVisibleUnitWidth;
			DateTime dtTime = m_dtFirstVisible.AddSeconds((double)nUnit);
			return dtTime;
		}

		public TimeSpan CalcTimeSpan(float nWidth)
		{
			double nTimeTick = (double)(1000 * nWidth / m_nVisibleUnitWidth);

			TimeSpan tsSpan = TimeSpan.FromMilliseconds(nTimeTick);

			return tsSpan;
		}

		#endregion


		#endregion


		#region Private Methods

		#region Layout

		protected void InitVariables()
		{
			m_dtFirstVisible = DateTime.Now;
		}

		protected void SetFirstVisibleTime()
		{	
			if (m_dtRangeFrom > m_dtFirstVisible)
				m_iScrollValue = m_iScrollMinValue;
			else if (m_dtFirstVisible > m_dtRangeTo)
				m_iScrollValue = m_iScrollMaxValue;
			else
				m_iScrollValue = (int)(m_dtFirstVisible.Subtract(m_dtRangeFrom).TotalSeconds);

			UpdateLayout(); 
			
			GenerateFirstVisibleTimeChangedEvent();

			GenerateTimeScrollChangedEvent();
		}

		protected void SetTimeRange()
		{
			if (m_dtRangeFrom > m_dtRangeTo)
				m_dtRangeTo = m_dtRangeFrom.AddSeconds(1);

			m_iScrollMaxValue = (int)(m_dtRangeTo.Subtract(m_dtRangeFrom).TotalSeconds) + m_iScrollLargeChange;
			m_iScrollMinValue = 0;

			if (m_dtRangeFrom > m_dtFirstVisible)
				m_iScrollValue = m_iScrollMinValue;
			else if (m_dtFirstVisible > m_dtRangeTo)
				m_iScrollValue = m_iScrollMaxValue;
			else
				m_iScrollValue = (int)(m_dtFirstVisible.Subtract(m_dtRangeFrom).TotalSeconds);

			UpdateLayout();

			GenerateTimeScrollChangedEvent();
		}

		protected void SetScrollValue(int iValue)
		{
			if (m_iScrollValue != iValue)
			{
				if (iValue > m_iScrollMaxValue)
					m_iScrollValue = m_iScrollMaxValue;
				else if (iValue < m_iScrollMinValue)
					m_iScrollValue = m_iScrollMinValue;
				else
					m_iScrollValue = iValue;

				DateTime dtTime = m_dtRangeFrom.AddSeconds(m_iScrollValue);
				if (dtTime != m_dtFirstVisible)
				{
					m_dtFirstVisible = dtTime;

					UpdateLayout();

					GenerateFirstVisibleTimeChangedEvent();
				}

				GenerateTimeScrollChangedEvent();
			}
		}

		#endregion

		#region User Action

		protected void HitTestBy(Point pntPos)
		{
			m_cSelectedIndicator = PickTimeIndicator(pntPos.X);
		}

		protected void MoveTimeBy(float nDelta)
		{
			MoveTime(nDelta); 
		}

		protected void MoveTimeIndicatorBy(CTimeIndicator cIndicator, float nDelta)
		{
			MoveTimeIndicator(cIndicator, nDelta);
		}
		
		#endregion

		#region Util

		protected bool TryToMoveFirstTime(TimeSpan tsSpan)
		{
			bool bOK = true;

			try
			{
				this.FirstVisibleTime = m_dtFirstVisible.Add(tsSpan);
			}
			catch (System.Exception ex)
			{
				ex.Data.Clear();
				bOK = false;
			}

			return bOK;
		}

		#endregion

		#region Raising Event

		protected void GenerateFirstVisibleTimeChangedEvent()
		{
			if (UEventFirstVisibleTimeChanged != null)
				UEventFirstVisibleTimeChanged(this);
		}

		protected void GenerateTimeIndicatorMovedEvent(CTimeIndicator cIndicator)
		{
			if (UEventTimeIndicatorMoved != null)
				UEventTimeIndicatorMoved(this, cIndicator);
		}

		protected void GenerateTimeScrollChangedEvent()
		{
			if (UEventTimeScrollChanged != null)
				UEventTimeScrollChanged(this);
		}

		protected void GenerateZoomInEvent()
		{
			if (UEventZoomIn != null)
				UEventZoomIn(this);
		}

		protected void GenerateZoomOutEvent()
		{
			if (UEventZoomOut != null)
				UEventZoomOut(this);
		}

		#endregion

		#region Drawing

		protected void DrawLayout(Graphics g)
		{
			float nHalfY = (this.Height-1) / 2;

			//g.DrawRectangle(Pens.Gray, 0, 0, this.Width - 1, this.Height - 1);
			g.DrawLine(Pens.Gray, 0, this.Height - 1, this.Width - 1, this.Height - 1);
			g.DrawLine(Pens.Gray, 0, nHalfY, this.Width - 1, nHalfY);
			g.DrawLine(Pens.Gray, 0, 0, 0, this.Height - 1);
		}

		protected void DrawTimeLine(Graphics g)
		{
			float nMaxX = this.Width - 1;
			float nMaxY = this.Height - 1;
			float nHalfY = nMaxY / 2;

			int iTopTime = m_dtFirstVisible.Hour;
			int iMajorTime = m_dtFirstVisible.Minute;
			int iMinorTime = m_dtFirstVisible.Second;
			float nTimePosX = -1 * m_nVisibleUnitWidth * ((float)m_dtFirstVisible.Millisecond / 1000);

			string sMajorTimeUnit = "";
			string sMinorTimeUnit = "";
			float nMajorOffSetX = (m_nVisibleUnitWidth * 60 - CTimeChartUtil.MeasureStringWidth(g, "00:00", m_fntFont)) / 2;
			float nMajorOffSetY = (nHalfY - CTimeChartUtil.MeasureStringHeight(g, "00:00", m_fntFont)) / 2;
			float nMinorOffSetX = (m_nVisibleUnitWidth - CTimeChartUtil.MeasureStringWidth(g, "00", m_fntFont)) / 2;
			float nMinorOffSetY = (nHalfY - CTimeChartUtil.MeasureStringHeight(g, "00", m_fntFont)) / 2;

			if (nTimePosX != 0)
			{
				sMajorTimeUnit = iTopTime.ToString("00") + ":" + iMajorTime.ToString("00");
				float nMajorTimePosX = nTimePosX - m_nVisibleUnitWidth * (float)iMinorTime;
				g.DrawString(sMajorTimeUnit, this.Font, Brushes.Black, nMajorTimePosX + nMajorOffSetX, nMajorOffSetY);
			}

			while (nMaxX >= nTimePosX)
			{
				if (iMinorTime == 0)
				{
					sMajorTimeUnit = iTopTime.ToString("00") + ":" + iMajorTime.ToString("00");
					g.DrawString(sMajorTimeUnit, m_fntFont, Brushes.Black, nTimePosX + nMajorOffSetX, nMajorOffSetY);

					g.DrawLine(Pens.Gray, nTimePosX, 0, nTimePosX, nMaxY);
				}
				else
				{
					g.DrawLine(Pens.Gray, nTimePosX, nHalfY, nTimePosX, nMaxY);
				}

				sMinorTimeUnit = iMinorTime.ToString("00");
				g.DrawString(sMinorTimeUnit, m_fntFont, Brushes.Black, nTimePosX + nMinorOffSetX, nHalfY + nMinorOffSetY);

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

				nTimePosX += m_nVisibleUnitWidth;
			}
		}

		public void DrawTimeIndicatorS(Graphics g)
		{
			float nBoundX = this.ClientRectangle.Width;
			float nBoundY = this.ClientRectangle.Height;

			Pen penIndicator = new Pen(Color.Black, 2);

			float nTemp;
			CTimeIndicator cIndicator;
			for (int i = 0; i < m_cTimeIndicatorS.Count; i++)
			{
				cIndicator = m_cTimeIndicatorS[i];
				if (cIndicator.Time < m_dtFirstVisible || cIndicator.Time > m_dtLastVisible)
					continue;

				nTemp = CalcPosition(cIndicator.Time);

				penIndicator.Color = cIndicator.Color;
				g.DrawLine(penIndicator, nTemp, 0, nTemp, nBoundY);
			}

			penIndicator.Dispose();
			penIndicator = null;
		}

		#endregion

		#endregion


		#region Event Methods

		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

			DrawLayout(pe.Graphics);
			DrawTimeLine(pe.Graphics);
			DrawTimeIndicatorS(pe.Graphics);
		}

		protected override void OnResize(EventArgs e)
		{
			UpdateLayout();

			base.OnResize(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				HitTestBy(e.Location);

				if (m_cSelectedIndicator != null)
					m_emActionType = EMActionType.MoveTimeIndicator;
				else
					m_emActionType = EMActionType.MoveTime;

				m_pntMousePos = e.Location;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (m_emActionType == EMActionType.MoveTime)
			{
				float nDelta = m_pntMousePos.X - e.Location.X;
				m_pntMousePos = e.Location;

				MoveTimeBy(nDelta);
			}
			else if(m_emActionType == EMActionType.MoveTimeIndicator)
			{
				float nDelta = e.Location.X - m_pntMousePos.X;
				m_pntMousePos = e.Location;

				MoveTimeIndicatorBy(m_cSelectedIndicator, nDelta);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			m_emActionType = EMActionType.None;
		}

		#endregion
	}
}
