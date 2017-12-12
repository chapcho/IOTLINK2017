using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.Ladder
{
    public delegate void UCCanvasEventHandlerScaled(float scale);
    public delegate void UCCanvasEventHandlerDragged(float dX, float dY);

    internal partial class UCCanvas : UserControl
    {
        #region Private Members

        private Pen m_gridPen;
        private bool m_bLoad = false;
        private bool m_bGridShow = false;
        private bool m_bRulerShow = false;
        private bool m_bOriginShow = false;
        private bool m_bInfoShow = false;
        private bool m_bZoomNow = false;
        private bool m_bDebug = true;
        private bool m_bDebuggable = false;
        private int m_gridSize = 50;
        private PointF m_pointZoomStart = new PointF(0, 0);
        private PointF m_pointZoomEnd = new PointF(0, 0);
        private HashSet<CCanvasItem> m_hashElements = new HashSet<CCanvasItem>();
        private HashSet<CCanvasItem> m_hashElementsSelected = new HashSet<CCanvasItem>();

        private bool m_bDrag = true;
        private bool m_bZoom = true;
        private bool m_bScroll = true;

        #endregion

        #region Protected Members

        protected float m_scale = 1.0F;
        protected RectangleF m_rectWindow = new RectangleF();
        protected PointF m_pointMouse = new PointF(0, 0);
        protected PointF m_pointOrigin = new PointF(0, 0);
        protected PointF m_pointOriginInitial = new PointF(0, 0);

        #endregion

        #region Public Properties

        public Pen GridPen { get { return m_gridPen; } set { m_gridPen = value; Invalidate(); } }
        public bool GridShow { get { return m_bGridShow; } set { m_bGridShow = value; Invalidate(); } }
        public bool RulerShow { get { return m_bRulerShow; } set { m_bRulerShow = value;Invalidate(); } }
        public bool OriginShow { get { return m_bOriginShow; } set { m_bOriginShow = value; Invalidate(); } }
        public bool InfoShow { get { return m_bInfoShow; } set { m_bInfoShow = value; this.Invalidate(); } }
        public bool Debugable { get { return m_bDebuggable; } set { m_bDebug = m_bDebuggable = value; this.DebugMode(); } }
        public bool Dragable { get { return m_bDrag; } set { m_bDrag = value; } }
        public bool Zoomable { get { return m_bZoom; } set { m_bZoom = value; } }
        public bool Scrollable { get { return m_bScroll; } set { m_bScroll = value; } }
        public float ScaleFactor { get { return m_scale; } set { m_scale = value; this.Invalidate(); } }
        public float OriginX { get { return m_pointOrigin.X; } }
        public float OriginY { get { return m_pointOrigin.Y; } }

        public event UCCanvasEventHandlerScaled EventScaled;
        public event UCCanvasEventHandlerScaled EventBeforeScaled;
        public event UCCanvasEventHandlerDragged EventDragged;
        public event UCCanvasEventHandlerDragged EventBeforeDragged;

        #endregion

        #region Public Methods

        public UCCanvas()
        {
            InitializeComponent();
            Initialize();
        }

        public void Reset()
        {
            m_scale = 1;
            m_pointOrigin.X = m_pointOriginInitial.X;
            m_pointOrigin.Y = m_pointOriginInitial.Y;
            this.Invalidate();
        }

        public void AddElement(CCanvasItem o)
        {
            m_hashElements.Add(o);
        }

        public void OriginPoint(float x, float y)
        {
            m_pointOrigin.X = x;
            m_pointOrigin.Y = y;
            m_pointOriginInitial.X = m_pointOrigin.X;
            m_pointOriginInitial.Y = m_pointOrigin.Y;
            this.Invalidate();
        }

        public void MoveX(float deltaX)
        {
            m_pointOrigin.X += deltaX;
            this.Invalidate();
        }

        public void MoveY(float deltaY)
        {
            m_pointOrigin.Y += deltaY;
            this.Invalidate();
        }

        public void MoveXY(float deltaX, float deltaY)
        {
            m_pointOrigin.X += deltaX;
            m_pointOrigin.Y += deltaY;
            this.Invalidate();
        }

        public void MoveAbsoluteX(float deltaX)
        {
            m_pointOrigin.X = m_pointOriginInitial.X + deltaX;
            this.Invalidate();
        }

        public void MoveAbsoluteY(float deltaY)
        {
            m_pointOrigin.Y = m_pointOriginInitial.Y + deltaY;
            this.Invalidate();
        }

        public void MoveAbsoluteXY(float deltaX, float deltaY)
        {
            m_pointOrigin.X = m_pointOriginInitial.X + deltaX;
            m_pointOrigin.Y = m_pointOriginInitial.Y + deltaY;
            this.Invalidate();
        }

        public bool IsInsideBoundingBox(float x, float y, CCanvasItem element)
        {
            int xMin, xMax, yMin, yMax;
            xMin = xMax = yMin = yMax = 0;

            // http://stackoverflow.com/questions/217578/point-in-polygon-aka-hit-test
            // This is coarse hit test, assuming rectangle bounding box
            foreach (CVertex v in element.BoundingBoxes)
            {
                xMin = xMin > v.X ? v.X : xMin;
                xMax = xMax < v.X ? v.X : xMax;
                yMin = yMin > v.Y ? v.Y : yMin;
                yMax = yMax < v.Y ? v.Y : yMax;
            }

            if (x < xMin || x > xMax || y < yMin || y > yMax)
            {
                return false;
            }

            return true;
        }

        public PointF ControlAreaToWorkingCoordinateSystem(PointF point)
        {
            PointF ret = new PointF();
            ret.X = -m_pointOrigin.X + (1f / m_scale) * point.X;
            ret.Y = -m_pointOrigin.Y + (1f / m_scale) * point.Y;
            return ret;
        }

        public PointF WorkingCoordinateSystemToControlArea(PointF point)
        {
            PointF ret = new PointF();
            ret.X = (point.X + m_pointOrigin.X) * m_scale;
            ret.Y = (point.Y + m_pointOrigin.Y) * m_scale; 
            return ret;
        }

        // http://tech.pro/tutorial/691/csharp-tutorial-font-scaling
        public static Font ScaleFont(Graphics g, float minFontSize, float maxFontSize, SizeF layoutSizeF, string s, Font f, out SizeF extent)
        {
            if (maxFontSize == minFontSize)
                f = new Font(f.FontFamily, minFontSize, f.Style);

            extent = g.MeasureString(s, f);

            if (maxFontSize <= minFontSize)
                return f;

            float hRatio = layoutSizeF.Height / extent.Height;
            float wRatio = layoutSizeF.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = f.Size * ratio;

            if (newSize < minFontSize)
                newSize = minFontSize;
            else if (newSize > maxFontSize)
                newSize = maxFontSize;

            f = new Font(f.FontFamily, newSize, f.Style);
            extent = g.MeasureString(s, f);

            return f;
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.DoubleBuffered = true;
            InfoShow = true;
            OriginShow = true;
            RulerShow = true;
            GridShow = true;
            GridPen = new Pen(Color.Gray);
            GridPen.Width = 0.5F * GridPen.Width;
            GridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            InitializeAdditional();
        }

        private void LoadControl(Object sender, EventArgs e)
        {
            m_rectWindow.X = 0;
            m_rectWindow.Y = 0;
            m_rectWindow.Width = this.Size.Width;
            m_rectWindow.Height = this.Size.Height;

            m_pointOrigin.X = m_pointOriginInitial.X = this.Size.Width / 2f;
            m_pointOrigin.Y = m_pointOriginInitial.Y = this.Size.Height / 2f;
        }

        private void OnMouseDownDefault(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            OnMouseDown(sender, e);

            switch (e.Button)
            {
                case MouseButtons.Middle:
                    m_pointMouse.X = e.X;
                    m_pointMouse.Y = e.Y;
                    break;

                case MouseButtons.Right:
                    m_bZoomNow = m_bZoom ? true : false;
                    m_pointZoomStart.X = e.X;
                    m_pointZoomStart.Y = e.Y;
                    m_pointZoomEnd.X = -1;
                    m_pointZoomEnd.Y = -1;
                    //RightDownOnElement(e.X, e.Y, e, Control.ModifierKeys);
                    break;

                case MouseButtons.Left:
                    DownOnElement(e.X, e.Y, e, Control.ModifierKeys);
                    break;
            }
        }

        private void OnMouseMoveDefault(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            OnMouseMove(sender, e);

            switch (e.Button)
            {
                case MouseButtons.Middle :
                    float dX = e.X - (int)m_pointMouse.X;
                    float dY = e.Y - (int)m_pointMouse.Y;
                    if (EventBeforeDragged != null) { EventBeforeDragged(dX, dY); }
                    if (m_bDrag)
                    {
                        m_pointOrigin.X += dX;
                        m_pointOrigin.Y += dY;
                    }
                    if (EventDragged != null) { EventDragged(dX, dY); }
                    this.Invalidate();
                    break;

                case MouseButtons.Right :
                    if (m_bZoomNow) 
                    {
                        if ((e.X > 0) && (e.Y > 0) && (e.X < this.Size.Width) && (e.Y < this.Size.Height)) 
                        {
                            if ((m_pointZoomEnd.X != -1) && (m_pointZoomEnd.Y != -1)) { DrawZoomRectangle(m_pointZoomStart, m_pointZoomEnd); }
                            
                            m_pointZoomEnd.X = e.X;
                            m_pointZoomEnd.Y = e.Y;

                            DrawZoomRectangle(m_pointZoomStart, m_pointZoomEnd); 
                        }
                    }
                    break;
            }

            m_pointMouse.X = e.X;
            m_pointMouse.Y = e.Y;
        }

        private void OnMouseUpDefault(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            OnMouseUp(sender, e);

            if ((m_pointZoomEnd.X != -1) && (m_pointZoomEnd.Y != -1) && 
                (Math.Abs(m_pointZoomEnd.X - m_pointZoomStart.X) > 5) && (Math.Abs(m_pointZoomEnd.Y - m_pointZoomStart.Y) > 5)) // Under 5 unit pixels neglected
            {
                DrawZoomRectangle(m_pointZoomStart, m_pointZoomEnd);
                if (m_bZoomNow) { Zooming(); }
            }

            m_pointZoomStart.X = m_pointZoomStart.Y = -1;
            m_pointZoomEnd.X = m_pointZoomEnd.Y = -1;
            m_bZoomNow = false;
        }

        private void OnMouseWheelDefault(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            float scale = 0.05F;
            scale = e.Delta > 0 ? scale : -scale;
            scale = m_scale + scale > 0.05 ? m_scale + scale : m_scale; // To avoid scale zero

            if (scale < 0.5f || scale > 2f) return;

            if (EventBeforeScaled != null) { EventBeforeScaled(scale); }
            if (m_bScroll)
            {
                m_scale = scale;
                this.Invalidate();
                if (EventScaled != null) { EventScaled(m_scale); }
            }
            
            OnMouseWheel(sender, e);
        }

        private void OnKeyDownDefault(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Reset();
                    break;

                case Keys.F1:
                    if (m_bDebuggable) { DebugMode(); }
                    break;
            }

            OnKeyDown(sender, e);
        }

        private void DownOnElement(float x, float y, System.Windows.Forms.MouseEventArgs e, Keys k)
        {
            PointF point = ControlAreaToWorkingCoordinateSystem(new PointF(x, y));

            if (k != Keys.Control)
                m_hashElementsSelected.Clear();

            foreach (CCanvasItem element in m_hashElements)
            {
                if (IsInsideBoundingBox(point.X, point.Y, element))
                {
                    element.OnClick((int) point.X, (int) point.Y, e, k);
                    m_hashElementsSelected.Add(element);
                }
            }
            this.Invalidate();
        }

        private void RightDownOnElement(float x, float y, System.Windows.Forms.MouseEventArgs e, Keys k)
        {
            PointF point = ControlAreaToWorkingCoordinateSystem(new PointF(x, y));

            if (k != Keys.Control)
                m_hashElementsSelected.Clear();

            foreach (CCanvasItem element in m_hashElements)
            {
                if (IsInsideBoundingBox(point.X, point.Y, element))
                {
                    element.OnRClick((int)point.X, (int)point.Y, e, k);
                    m_hashElementsSelected.Add(element);
                }
            }
            this.Invalidate();
        }

        private void DebugMode()
        {
            m_bDebug = !m_bDebug;
            m_bDebug = m_bDebuggable ? m_bDebug : false;

            InfoShow = m_bDebug;
            OriginShow = m_bDebug;
            RulerShow = m_bDebug;
            GridShow = m_bDebug;
        }

        private void Zooming()
        {
            float width = m_pointZoomEnd.X - m_pointZoomStart.X;
            float height = m_pointZoomEnd.Y - m_pointZoomStart.Y;

            if (width > height)
            {
                m_scale = (float)m_rectWindow.Width / width;
            }
            else
            {
                m_scale = (float)m_rectWindow.Height / height;
            }

            m_pointOrigin.X -= m_pointZoomEnd.X < m_pointZoomStart.X ? m_pointZoomEnd.X : m_pointZoomStart.X;
            m_pointOrigin.Y -= m_pointZoomEnd.Y < m_pointZoomStart.Y ? m_pointZoomEnd.Y : m_pointZoomStart.Y;

            Invalidate();
        }

        private void DrawZoomRectangle(PointF p1, PointF p2)
        {
            RectangleF rc = new RectangleF();

            // Convert the points to screen coordinates.
            p1 = PointToScreen(Point.Round(m_pointZoomStart));
            p2 = PointToScreen(Point.Round(m_pointZoomEnd));
            
            // Normalize the rectangle.
            if (p1.X < p2.X)
            {
                rc.X = p1.X;
                rc.Width = p2.X - p1.X;
            }
            else
            {
                rc.X = p2.X;
                rc.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rc.Y = p1.Y;
                rc.Height = p2.Y - p1.Y;
            }
            else
            {
                rc.Y = p2.Y;
                rc.Height = p1.Y - p2.Y;
            }

            ControlPaint.DrawReversibleFrame(Rectangle.Round(rc), Color.Black, FrameStyle.Dashed);
        }

        private void Scale(Graphics graphics)
        {
            graphics.ScaleTransform(m_scale, m_scale);
            m_rectWindow.Width = (1f / m_scale) * this.Size.Width;
            m_rectWindow.Height = (1f / m_scale) * this.Size.Height;
        }

        private void TranslateOrigin(Graphics graphics)
        {
            // Negative sign because we want the window stay, but the graphic moves
            graphics.TranslateTransform(m_pointOrigin.X, m_pointOrigin.Y);
        }

        private void SetClip(Graphics graphics)
        {
            // Construct a region based on the path.
            RectangleF rectViewBox = new RectangleF(-m_pointOrigin.X, -m_pointOrigin.Y, m_rectWindow.Width, m_rectWindow.Height);
            Region region = new Region(rectViewBox);
            
            // Draw the outline of the region.
            Pen pen = Pens.Black;
            graphics.DrawRectangle(pen, m_rectWindow.X, m_rectWindow.Y, m_rectWindow.Width, m_rectWindow.Height);

            // Clip region
            graphics.SetClip(region, System.Drawing.Drawing2D.CombineMode.Replace);
        }

        private void DrawGrid(Graphics graphics)
        {
            if (!GridShow) { return; }

            RectangleF rectViewBox = new RectangleF(-m_pointOrigin.X, -m_pointOrigin.Y, m_rectWindow.Width, m_rectWindow.Height);

            // Major line
            Brush brushMajorLine = new SolidBrush(Color.Black);
            Pen penMajorLine = new Pen(brushMajorLine);
            penMajorLine.Width = penMajorLine.Width * 3;
            graphics.DrawLine(penMajorLine, 0, rectViewBox.Top, 0, rectViewBox.Bottom);
            graphics.DrawLine(penMajorLine, rectViewBox.Left, 0, rectViewBox.Right, 0);

            float x, y;

            // Vertical lines 0+
            x = y = 0;
            while (x < rectViewBox.Right)
            {
                x = x + m_gridSize;
                graphics.DrawLine(GridPen, x, rectViewBox.Top, x, rectViewBox.Bottom);
            }

            // Horizontal lines 0+
            x = y = 0;
            while (y < rectViewBox.Bottom)
            {
                y = y + m_gridSize;
                graphics.DrawLine(GridPen, rectViewBox.Left, y, rectViewBox.Right, y);
            }

            // Vertical lines 0-
            x = y = 0;
            while (x > rectViewBox.Left)
            {
                x = x - m_gridSize;
                graphics.DrawLine(GridPen, x, rectViewBox.Bottom, x, rectViewBox.Top);
            }

            // Horizontal lines 0-
            x = y = 0;
            while (y > rectViewBox.Top)
            {
                y = y - m_gridSize;
                graphics.DrawLine(GridPen, rectViewBox.Right, y, rectViewBox.Left, y);
            }
        }

        private void DrawRuler(Graphics graphics)
        {
            if (!RulerShow) { return; }

            // Font format
            StringFormat fontFormat = new StringFormat();
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;
            fontFormat.FormatFlags = StringFormatFlags.NoWrap;

            // Font type
            Font font = new Font("Arial", 9);

            // Font brush
            Brush brush = new SolidBrush(Color.Black);
                      
            // The rectangle of font
            RectangleF rectFont = new RectangleF(0,0,0,10);

            // Tester font (default)
            SizeF sizeFont = graphics.MeasureString("DEFAULT", font);
            rectFont.Height = 2*sizeFont.Height/2f;

            // Viewing box
            RectangleF rectViewBox = new RectangleF(-m_pointOrigin.X, -m_pointOrigin.Y, m_rectWindow.Width, m_rectWindow.Height);

            // X+
            float x, y, temp;
            x = 0; rectFont.Y = 1;
            while (x < rectViewBox.Right)
            {
                x = x + m_gridSize;
                sizeFont = graphics.MeasureString(x.ToString(), font);
                temp = sizeFont.Width / 2f;
                rectFont.X = x - temp;
                rectFont.Width = 2*temp;
                graphics.DrawString(x.ToString(), font, brush, rectFont, fontFormat);
            }

            // X-
            x = 0; rectFont.Y = 1;
            while (x > rectViewBox.Left)
            {
                x = x - m_gridSize;
                sizeFont = graphics.MeasureString(x.ToString(), font);
                temp = sizeFont.Width / 2f;
                rectFont.X = x - temp;
                rectFont.Width = 2 * temp;
                graphics.DrawString(x.ToString(), font, brush, rectFont, fontFormat);
            }

            // Y+
            rectFont.X = 3; y = 0;
            temp = rectFont.Height / 2f;
            while (y < rectViewBox.Bottom)
            {
                y = y + m_gridSize;
                rectFont.Y = y - temp;
                graphics.DrawString(y.ToString(), font, brush, rectFont, fontFormat);
            }

            // Y-
            rectFont.X = 3; y = 0;
            temp = rectFont.Height / 2f;
            while (y > rectViewBox.Top)
            {
                y = y - m_gridSize;
                rectFont.Y = y - temp;
                graphics.DrawString(y.ToString(), font, brush, rectFont, fontFormat);
            }

            font.Dispose();
            brush.Dispose();
        }

        private void DrawOrigin(Graphics graphics)
        {
            if (!OriginShow) { return; }

            Pen pen;
            
            pen = new Pen(Color.Red, 5F);
            graphics.DrawLine(pen, 0, 0, 75, 0);

            pen.Color = Color.Green;
            graphics.DrawLine(pen, 0, 0, 0, 75);

            Brush brush;

            brush = new SolidBrush(Color.Blue);
            graphics.FillEllipse(brush, -10, -10, 20, 20);

            Font font = new Font("Arial", 12, FontStyle.Bold);
            
            brush = new SolidBrush(Color.Red);
            graphics.DrawString("X+", font, brush, new PointF(75, -20));
           
            brush = new SolidBrush(Color.Green);
            graphics.DrawString("Y+", font, brush, new PointF(-25, 75));

            pen.Dispose();
            brush.Dispose();
        }

        private void DrawInfo(Graphics graphics)
        {
            if (!InfoShow) { return; }

            float x = -m_pointOrigin.X + 5f;
            float y = -m_pointOrigin.Y + 5f;
            float spaceVertical = 2f;
            
            // Origin
            Font font = new Font("Arial", 12, FontStyle.Bold);
            SizeF sizeFont = graphics.MeasureString("DEFAULT", font);
            Brush brush = new SolidBrush(Color.Blue);
            graphics.DrawString("Origin Point = (" + m_pointOrigin.X.ToString() + " , " + m_pointOrigin.Y.ToString() + ")", font, brush, new PointF(x,y));

            // Rectangular window
            y += sizeFont.Height + spaceVertical;
            graphics.DrawString("Viewing Box Pos = (" + (-m_pointOrigin.X).ToString() + " , " + (-m_pointOrigin.Y).ToString() + ")", font, brush, new PointF(x, y));

            // Mouse
            y += sizeFont.Height + spaceVertical;
            graphics.DrawString("Mouse Pos = (" + m_pointMouse.X.ToString() + " , " + m_pointMouse.Y.ToString() + ")", font, brush, new PointF(x, y));

            // Client size
            y += sizeFont.Height + spaceVertical;
            graphics.DrawString("Client Size = ( w : " + this.ClientSize.Width.ToString() + " , h : " + this.ClientSize.Height.ToString() + ")", font, brush, new PointF(x, y));

            font.Dispose();
            brush.Dispose();
        }

        private void DrawElements(Graphics graphics)
        {
            foreach (CCanvasItem e in m_hashElements)
            {
                e.Draw(graphics);
            }
        }

        private void DrawElementsSelected(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color.FromArgb(50, Color.Yellow));

            foreach (CCanvasItem e in m_hashElementsSelected)
            {
                PointF[] points = new PointF[e.BoundingBoxes.Count];
                for (int i = 0; i < e.BoundingBoxes.Count; i++)
                {
                    points[i] = new PointF(e.BoundingBoxes[i].X, e.BoundingBoxes[i].Y);
                }

                graphics.FillPolygon(brush, points);
            }

            brush.Dispose();
        }

        #endregion
        
        #region Protected Methods

        protected virtual void InitializeAdditional()
        {
            // To be overriden;
        }

        protected virtual void DrawAdditional(Graphics graphics)
        {
            // To be overriden;
        }

        protected virtual void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // To be overriden;
        }

        protected virtual void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // To be overriden;
        }

        protected virtual void OnMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // To be overriden;
        }

        protected virtual void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // To be overriden;
        }

        protected virtual void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // To be overriden;
        }

        protected override void Dispose(bool disposing)
        {
            GridPen.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //if (m_bLoad) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Call the OnPaint method of the base class.
            base.OnPaint(e);

            // Scale
            Scale(e.Graphics);

            // Origin of graphic is moved if necessary
            TranslateOrigin(e.Graphics);

            // http://stackoverflow.com/questions/7507602/best-practice-for-onpaint-invalidate-clipping-and-regions
            // Clipping seems doesnt help so much
            // Set clip
            // SetClip(e.Graphics);

            // Show grid
            DrawGrid(e.Graphics);

            // Origin show
            DrawOrigin(e.Graphics);

            // Show ruler
            DrawRuler(e.Graphics);

            // Graphics info
            DrawInfo(e.Graphics);

            // Elements selected
            DrawElementsSelected(e.Graphics);

            // Elements
            DrawElements(e.Graphics);

            // For additional
            DrawAdditional(e.Graphics);

            m_bLoad = true;
        }

        // http://stackoverflow.com/questions/2612487/how-to-fix-the-flickering-in-user-controls
        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                return parms;
            }
        }

        #endregion

        private void UCCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PointF point = ControlAreaToWorkingCoordinateSystem(new PointF(e.X, e.Y));

                foreach (CCanvasItem element in m_hashElements)
                {
                    if (IsInsideBoundingBox(point.X, point.Y, element))
                    {
                        element.OnDClick((int)point.X, (int)point.Y, e, Control.ModifierKeys);
                        m_hashElementsSelected.Add(element);
                    }
                }
            }
            //else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    PointF point = ControlAreaToWorkingCoordinateSystem(new PointF(e.X, e.Y));

            //    foreach (CCanvasItem element in m_hashElements)
            //    {
            //        if (IsInsideBoundingBox(point.X, point.Y, element))
            //        {
            //            element.OnRDClick((int)point.X, (int)point.Y, e, Control.ModifierKeys);
            //            m_hashElementsSelected.Add(element);
            //        }
            //    }
            //}
            this.Invalidate();
        }
    }
}
