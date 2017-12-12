using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Log;

namespace UDM.Ladder
{
    public abstract class CLadderItem : IDisposable
    {
        #region Private Members

        private bool m_bDisposed = false;

        #endregion

        #region Public Properties

        public CVertex TopLeft { get { return m_cBoundingBoxeS[0]; } }
        public CVertex TopRight { get { return m_cBoundingBoxeS[1]; } }
        public CVertex BottomRight { get { return m_cBoundingBoxeS[2]; } }
        public CVertex BottomLeft { get { return m_cBoundingBoxeS[3]; } }
        public Font Font { get { return m_font; } set { m_font = value; } }
        public Pen Pen { get { return m_pen; } set { m_pen = value; } }
        public Brush BrushSelected { get { return m_brushSelected; } set { m_brushSelected = value; } }
        public Brush BrushText { get { return m_brushText; } set { m_brushText = value; } }
        public int ColumnOccupied { get { return m_nColumnOccupied; } }
        public int RowOccupied { get { return m_nRowOccupied; } }

        #endregion

        #region Protected Members

        protected Brush m_brushText = new SolidBrush(Color.Green);
        protected Brush m_brushSelected = new SolidBrush(Color.Blue); 
        protected Pen m_pen = new Pen(Color.Black);
        protected Font m_font = new Font("Arial", 9);
        protected CVertexS m_cBoundingBoxeS = new CVertexS();
        protected CVertexS m_cVertexS = new CVertexS();
        protected CEdgeS m_cEdgeS = new CEdgeS();
        protected CPolygonS m_cPolygonS = new CPolygonS();
        protected CBezierS m_cBezierS = new CBezierS();
        protected HashSet<int> m_hashExcludedPolygons = new HashSet<int>();
        protected HashSet<int> m_hashExcludedEdges = new HashSet<int>();
        protected HashSet<int> m_hashExcludedBeziers = new HashSet<int>();
        protected int m_nColumnOccupied = 1;
        protected int m_nRowOccupied = 1;

        #endregion

        #region Protected Methods

        protected abstract void Vertexes();
        protected abstract void Edges();
        protected abstract void Polygons();
        protected abstract void Beziers();
        protected virtual void DrawAdditional(Graphics graphics, Point point, CTimeLogS cLogS) { }
        protected virtual void DisposeAdditional() { }
        protected virtual void LoadAdditional() { }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_bDisposed)
            {
                if (disposing)
                {
                    m_pen.Dispose();
                    m_brushSelected.Dispose();
                    m_brushText.Dispose();
                    DisposeAdditional();
                }

                // Free your own state (unmanaged objects).
                // Set large fields to null.
                m_bDisposed = true;
            }
        }

        #endregion

        #region Private Methods

        ~CLadderItem()
        {
            Dispose(false);
        }

        private void BoundingBox()
        {
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
        }

        #endregion

        #region Public Methods

        public CLadderItem()
        {
            m_pen.Width = m_pen.Width * 2;
            Vertexes();
            Edges();
            Polygons();
            Beziers();
            BoundingBox();
            LoadAdditional();
        }

        public void Draw(Graphics graphics, Point point, CTimeLogS cLogS)
        {
            try
            {
                // Lines
                int nEdges = -1;
                foreach (CEdge e in m_cEdgeS)
                {
                    nEdges++;

                    // The excluded edges
                    if (m_hashExcludedEdges.Contains(nEdges)) { continue; }

                    graphics.DrawLine(m_pen, e.V1.X + point.X, e.V1.Y + point.Y, e.V2.X + point.X, e.V2.Y + point.Y);
                }

                // Polygons
                int nPolygon = -1;
                Brush brushPolygon = new SolidBrush(Pen.Color);
                foreach (CPolygon p in m_cPolygonS)
                {
                    nPolygon++;

                    // The excluded polygons
                    if (m_hashExcludedPolygons.Contains(nPolygon)) { continue; }
                    
                    // Draw
                    CVertexS cOffsetedVertexS = p.OffsetAllPointsTemporary(point.X, point.Y);
                    graphics.FillPolygon(brushPolygon, cOffsetedVertexS.ConvertToPointArray());
                }

                // Beziers
                int nBezier = -1;
                Brush brushBezier = new SolidBrush(Pen.Color);
                foreach (CBezier p in m_cBezierS)
                {
                    nBezier++;

                    // The excluded beziers
                    if (m_hashExcludedBeziers.Contains(nBezier)) { continue; }

                    // Draw
                    CVertexS cOffsetedVertexS = p.OffsetAllPointsTemporary(point.X, point.Y);
                    graphics.DrawBeziers(m_pen, cOffsetedVertexS.ConvertToPointArray());
                }

                // Draw more
                DrawAdditional(graphics, point, cLogS);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public void Dispose()
        {
            // http://msdn.microsoft.com/en-us/library/vstudio/b1yfkh5e(v=vs.100).aspx
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void PutInExcludedPolygons(int i)
        {
            m_hashExcludedPolygons.Add(i);
        }

        public void PutInExcludedEdges(int i)
        {
            m_hashExcludedEdges.Add(i);
        }

        public void PutInExcludedBeziers(int i)
        {
            m_hashExcludedBeziers.Add(i);
        }

        public void RemoveFromExcludedPolygons(int i)
        {
            m_hashExcludedPolygons.Remove(i);
        }

        public void RemoveFromExcludedEdges(int i)
        {
            m_hashExcludedEdges.Remove(i);
        }

        public void RemoveFromExcludedBeziers(int i)
        {
            m_hashExcludedBeziers.Remove(i);
        }

        #endregion
    }
}
