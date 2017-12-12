using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.UI
{
    class CLadderItemContact : CLadderItem
    {
        #region Private Members

        private bool m_bValue = false;
        private CContact m_cContact = null;

        #endregion

        #region Public Properties

        public CContact Contact { get { return m_cContact; } set { m_cContact = value; } }
        public bool Value { get { return m_bValue; } set { m_bValue = value; } }

        #endregion

        #region Protected Methods

        protected override void Vertexes()
        {
            m_cVertexS.Add(new CVertex(-15, -20)); // 0
            m_cVertexS.Add(new CVertex(-15, 20)); // 1
            m_cVertexS.Add(new CVertex(15, 20)); // 2
            m_cVertexS.Add(new CVertex(15, -20)); // 3
            m_cVertexS.Add(new CVertex(15, 0)); // 4
            m_cVertexS.Add(new CVertex(50, 0)); // 5
            m_cVertexS.Add(new CVertex(-15, 0)); // 6
            m_cVertexS.Add(new CVertex(-50, 0)); // 7
            m_cVertexS.Add(new CVertex(-11, -15)); // 8
            m_cVertexS.Add(new CVertex(-11, 15)); // 9
            m_cVertexS.Add(new CVertex(11, -15)); // 10
            m_cVertexS.Add(new CVertex(11, 15)); // 11
            m_cVertexS.Add(new CVertex(-10, -5)); // 12
            m_cVertexS.Add(new CVertex(10, -5)); // 13
            m_cVertexS.Add(new CVertex(0, -17)); // 14
            m_cVertexS.Add(new CVertex(10, 5)); // 15
            m_cVertexS.Add(new CVertex(-10, 5)); // 16
            m_cVertexS.Add(new CVertex(0, 20)); // 17
            m_cVertexS.Add(new CVertex(0, -20)); // 18
            m_cVertexS.Add(new CVertex(0, 17)); // 19
            m_cVertexS.Add(new CVertex(-25, 20)); // 20
            m_cVertexS.Add(new CVertex(25, -20)); // 21
        }

        protected override void Edges()
        {
            try
            {
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[17], m_cVertexS[14]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[20], m_cVertexS[21]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[18], m_cVertexS[19]));
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        protected override void Polygons()
        {
            try
            {
                CPolygon polygon0 = new CPolygon();
                polygon0.Add(m_cVertexS[9]);
                polygon0.Add(m_cVertexS[8]);
                polygon0.Add(m_cVertexS[10]);
                polygon0.Add(m_cVertexS[11]);
                m_cPolygonS.Add(polygon0);

                CPolygon polygon1 = new CPolygon();
                polygon1.Add(m_cVertexS[18]);
                polygon1.Add(m_cVertexS[13]);
                polygon1.Add(m_cVertexS[12]);
                m_cPolygonS.Add(polygon1);

                CPolygon polygon2 = new CPolygon();
                polygon2.Add(m_cVertexS[17]);
                polygon2.Add(m_cVertexS[16]);
                polygon2.Add(m_cVertexS[15]);
                m_cPolygonS.Add(polygon2);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        protected override void DrawAdditional(Graphics graphics, Point point)
        {
            try
            {
                // If value
                Brush brushValue = m_bValue ? new SolidBrush(Color.FromArgb(90,Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());

                // Normally OPEN/CLOSE/Other type ?
                switch (m_cContact.ContactType)
                {
                    case EMContactType.Close:
                        DrawContactCLOSE(graphics, point);
                        break;

                    case EMContactType.PulseOffClose:
                        DrawContactPULSEOFF(graphics, point);
                        DrawContactCLOSE(graphics, point);
                        break;

                    case EMContactType.PulseOnClose:
                        DrawContactPULSEON(graphics, point);
                        DrawContactCLOSE(graphics, point);
                        break;

                    case EMContactType.PulseOnOpen:
                        DrawContactPULSEON(graphics, point);
                        break;

                    case EMContactType.PulseOffOpen:
                        DrawContactPULSEOFF(graphics, point);
                        break;

                    case EMContactType.Open:
                        /* NOTHING */
                        break;

                    // So on ...
                }

                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // String address
                SizeF sizeFont = graphics.MeasureString(m_cContact.Tag.Address, m_font);
                graphics.DrawString(m_cContact.Tag.Address, m_font, BrushText, new Point(point.X, point.Y - 20 - (int)Math.Round(sizeFont.Height)), stringFormat);

                // String symbol (comment)
                Font fontComment = new Font(m_font.SystemFontName,(int)(0.8 * m_font.Size));
                sizeFont = graphics.MeasureString("DEFAULT", fontComment);
                int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(TopRight.X - TopLeft.X);
                sizeFont = graphics.MeasureString(m_cContact.Tag.Description, fontComment);
                graphics.DrawString(m_cContact.Tag.Description, fontComment, m_brushText, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0), point.Y + 20F, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        protected override void LoadAdditional()
        {
            PutInExcludedPolygons(0); // For value indicator
            PutInExcludedPolygons(1); // Arrow head UP
            PutInExcludedPolygons(2); // Arrow head DOWN
            PutInExcludedEdges(4); // Arrow line UP
            PutInExcludedEdges(5); // CLOSE line
            PutInExcludedEdges(6); // Arrow line DOWN
        }

        protected override void DisposeAdditional()
        {
 
        }

        #endregion

        #region Private Methods

        private void DrawContactCLOSE(Graphics graphics, Point point)
        {
            // Using the edge no 5
            CEdge edge = m_cEdgeS.GetEdge(5);
            System.Diagnostics.Debug.Assert(edge != null);
            graphics.DrawLine(m_pen, edge.V1.X + point.X, edge.V1.Y + point.Y, edge.V2.X + point.X, edge.V2.Y + point.Y);
        }

        private void DrawContactPULSEON(Graphics graphics, Point point)
        {
            DrawContactPULSELINE(graphics, point, 4); // using the edge no 4
            DrawContactPULSE(graphics, point, 1); // Using the polygon no 1
        }

        private void DrawContactPULSEOFF(Graphics graphics, Point point)
        {
            DrawContactPULSELINE(graphics, point, 6); // using the edge no 6
            DrawContactPULSE(graphics, point, 2); // Using the polygon no 2
        }

        private void DrawContactPULSE(Graphics graphics, Point point, int nPoly)
        {
            CPolygon polygon = m_cPolygonS.GetPolygon(nPoly);
            if (polygon != null)
            {
                Brush brush = new SolidBrush(m_pen.Color);
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brush, cOffsetedVertexS.ConvertToPointArray());
                brush.Dispose();
            }
        }

        private void DrawContactPULSELINE(Graphics graphics, Point point, int nEdge)
        {
            // Using the edge no 4
            CEdge edge = m_cEdgeS.GetEdge(nEdge);
            System.Diagnostics.Debug.Assert(edge != null);
            graphics.DrawLine(m_pen, edge.V1.X + point.X, edge.V1.Y + point.Y, edge.V2.X + point.X, edge.V2.Y + point.Y);
        }
            
        #endregion

        #region Public Methods

        public CLadderItemContact()
        {

        }

        #endregion
    }
}
