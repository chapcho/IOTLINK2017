using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class MELSECCoilNormal
    {
        static private HashSet<int> m_hashExcludedPolygons = new HashSet<int>();
        static private CVertexS m_cVertexS = new CVertexS();
        static private CEdgeS m_cEdgeS = new CEdgeS();
        static private CPolygonS m_cPolygonS = new CPolygonS();
        static private CBezierS m_cBezierS = new CBezierS();
        static private CVertexS m_cBoundingBoxeS = new CVertexS();

        public static CVertexS Vertexs { get { return m_cVertexS; } }
        public static CEdgeS Edges { get { return m_cEdgeS; } }
        public static CPolygonS Polygons { get { return m_cPolygonS; } }
        public static CBezierS Beziers { get { return m_cBezierS; } }
        public static CVertexS BoundingBoxes { get { return m_cBoundingBoxeS; } }
        public static HashSet<int> ExcludedPolygons { get { return m_hashExcludedPolygons; } }
        public static int ColumnOccupied { get { return 1; } }

        static MELSECCoilNormal()
        {
            InitVertexes();
            InitEdges();
            InitPolygons();
            InitBeziers();

            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        private static void InitVertexes()
        {
            // Vertexes
            m_cVertexS.Add(new CVertex(-36, 0)); // 0
            m_cVertexS.Add(new CVertex(36, 0)); // 1
            m_cVertexS.Add(new CVertex(-50, 0)); // 2
            m_cVertexS.Add(new CVertex(50, 0)); // 3
            m_cVertexS.Add(new CVertex(-32, -22)); // 4
            m_cVertexS.Add(new CVertex(-35, -13)); // 5
            m_cVertexS.Add(new CVertex(-36, -4)); // 6
            m_cVertexS.Add(new CVertex(-36, 4)); // 7
            m_cVertexS.Add(new CVertex(-35, 13)); // 8
            m_cVertexS.Add(new CVertex(-32, 22)); // 9
            m_cVertexS.Add(new CVertex(32, -22)); // 10
            m_cVertexS.Add(new CVertex(35, -13)); // 11
            m_cVertexS.Add(new CVertex(36, -4)); // 12
            m_cVertexS.Add(new CVertex(36, 4)); // 13
            m_cVertexS.Add(new CVertex(35, 13)); // 14
            m_cVertexS.Add(new CVertex(32, 22)); // 15
            m_cVertexS.Add(new CVertex(-30, -20)); // 16
            m_cVertexS.Add(new CVertex(30, -20)); // 17
            m_cVertexS.Add(new CVertex(30, 20)); // 18
            m_cVertexS.Add(new CVertex(-30, 20)); // 19
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[1], m_cVertexS[3])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[2])); //1
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private static void InitPolygons()
        {
            try
            {
                // Polygons
                CPolygon polygon0 = new CPolygon();
                polygon0.Add(m_cVertexS[16]);
                polygon0.Add(m_cVertexS[17]);
                polygon0.Add(m_cVertexS[18]);
                polygon0.Add(m_cVertexS[19]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private static void InitBeziers()
        {
            try
            {
                // Beziers
                CBezier bezier0 = new CBezier();
                bezier0.Add(m_cVertexS[4]);
                bezier0.Add(m_cVertexS[5]);
                bezier0.Add(m_cVertexS[6]);
                bezier0.Add(m_cVertexS[0]);
                bezier0.Add(m_cVertexS[7]);
                bezier0.Add(m_cVertexS[8]);
                bezier0.Add(m_cVertexS[9]);
                m_cBezierS.Add(bezier0);

                CBezier bezier1 = new CBezier();
                bezier1.Add(m_cVertexS[10]);
                bezier1.Add(m_cVertexS[11]);
                bezier1.Add(m_cVertexS[12]);
                bezier1.Add(m_cVertexS[1]);
                bezier1.Add(m_cVertexS[13]);
                bezier1.Add(m_cVertexS[14]);
                bezier1.Add(m_cVertexS[15]);
                m_cBezierS.Add(bezier1);

            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, CCoil cCoil, Font font, Brush brush)
        {
            try
            {
                // If value
                Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90, Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                List<Point> pointsPolygon = new List<Point>();
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());

                string strAddress = cCoil.RefTagS.GetBaseAddress();
                string strDescription = cCoil.RefTagS.GetBaseDescription();

                if (strAddress == "" || strAddress == string.Empty)
                {
                    if (cCoil.ContentS.Count > 0)
                        strAddress = cCoil.ContentS[0].Argument;
                }

                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                
                Brush brushInfo = bValue ? new SolidBrush(Color.Yellow) : brush;

                // Info
                SizeF sizeFont = graphics.MeasureString(strAddress, font);

                int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);

                int nOffset = (int)(Math.Abs(m_cVertexS[10].X - m_cVertexS[0].X) / 4.0);
                int nRef = m_cVertexS[10].X < m_cVertexS[0].X ? m_cVertexS[10].X : m_cVertexS[0].X;
                nRef += 10;

                // Address
                stringFormat.LineAlignment = StringAlignment.Center;
                graphics.DrawString(strAddress, font, brushInfo, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.5f), point.Y - (int)Math.Round(sizeFont.Height * 2), nWrapBoxWidth - 20, nWrapBoxHeight), stringFormat);
                //graphics.DrawString(strAddress, font, brushInfo, new Point(point.X, point.Y - (int)Math.Round(0.5 * sizeFont.Height)), stringFormat);

                // Commend and time
                stringFormat.LineAlignment = StringAlignment.Near;

                Font fontComment = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                sizeFont = graphics.MeasureString(strDescription, fontComment);
                nWrapBoxHeight = (int)(2.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                //int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);

                // Time
                float levelHeight = 19F;
                Font fontTime = new Font(font.SystemFontName, (int)(0.7 * font.Size));
                sizeFont = graphics.MeasureString(strTime, fontTime);
                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0f), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
                levelHeight += levelHeight;//sizeFont.Height;

                // String symbol (comment)
                fontComment = new Font(font.SystemFontName, (float)(0.75 * font.Size));
                graphics.DrawString(strDescription, fontComment, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
