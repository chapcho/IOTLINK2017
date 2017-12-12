using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class MELSECContactClose
    {
        static private HashSet<int> m_hashExcludedPolygons = new HashSet<int>();
        static private CVertexS m_cVertexS = new CVertexS();
        static private CEdgeS m_cEdgeS = new CEdgeS();
        static private CPolygonS m_cPolygonS = new CPolygonS();
        static private CVertexS m_cBoundingBoxeS = new CVertexS();

        public static CVertexS Vertexs { get { return m_cVertexS; } }
        public static CEdgeS Edges { get { return m_cEdgeS; } }
        public static CPolygonS Polygons { get { return m_cPolygonS; } }
        public static CVertexS BoundingBoxes { get { return m_cBoundingBoxeS; } }
        public static HashSet<int> ExcludedPolygons { get { return m_hashExcludedPolygons; } }
        public static int ColumnOccupied { get { return 1; } }

        static MELSECContactClose()
        {
            InitVertexes();
            InitEdges();
            InitPolygons();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        private static void InitVertexes()
        {
            // Vertexes
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
            m_cVertexS.Add(new CVertex(-25, 20)); // 12
            m_cVertexS.Add(new CVertex(25, -20)); // 13
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[12], m_cVertexS[13])); //4

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
                polygon0.Add(m_cVertexS[9]);
                polygon0.Add(m_cVertexS[8]);
                polygon0.Add(m_cVertexS[10]);
                polygon0.Add(m_cVertexS[11]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, string strAddress, string strDescription, Font font, Brush brush)
        {
            try
            {
                // If value
                Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90,Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());

                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // String address
                SizeF sizeFont = graphics.MeasureString(strAddress, font);
                graphics.DrawString(strAddress, font, brush, new Point(point.X, point.Y - 20 - (int)Math.Round(sizeFont.Height)), stringFormat);

                // Comment and time
                Font fontComment = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                sizeFont = graphics.MeasureString(strDescription, fontComment);
                int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);

                // Time
                float levelHeight = 20F;
                Font fontTime = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                sizeFont = graphics.MeasureString(strTime, fontTime);
                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X - (int)(nWrapBoxWidth/ 2.0f), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
                levelHeight += sizeFont.Height;

                // String symbol (comment)
                graphics.DrawString(strDescription, fontComment, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
