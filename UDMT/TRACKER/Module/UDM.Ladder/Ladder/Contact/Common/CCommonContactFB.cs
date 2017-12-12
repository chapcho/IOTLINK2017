using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Ladder
{
    public static class CCommonContactFB
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
        public static int ColumnOccupied { get { return 3; } }

        static CCommonContactFB()
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
            m_cVertexS.Add(new CVertex(-30, 20)); // 0
            m_cVertexS.Add(new CVertex(-20, -20)); // 1
            m_cVertexS.Add(new CVertex(-20, 20)); // 2
            m_cVertexS.Add(new CVertex(-30, 0)); // 3
            m_cVertexS.Add(new CVertex(-50, 0)); // 4
            m_cVertexS.Add(new CVertex(-30, -20)); // 5
            m_cVertexS.Add(new CVertex(250, 0)); // 6
            m_cVertexS.Add(new CVertex(230, 0)); // 7
            m_cVertexS.Add(new CVertex(230, -20)); // 8
            m_cVertexS.Add(new CVertex(230, 20)); // 9
            m_cVertexS.Add(new CVertex(220, 20)); // 10
            m_cVertexS.Add(new CVertex(220, -20)); // 11
            m_cVertexS.Add(new CVertex(-10, -10)); // 12
            m_cVertexS.Add(new CVertex(-10, 10)); // 13
            m_cVertexS.Add(new CVertex(210, 10)); // 14
            m_cVertexS.Add(new CVertex(210, -10)); // 15

        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[0])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[5], m_cVertexS[1])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[5], m_cVertexS[0])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[3], m_cVertexS[4])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[9], m_cVertexS[10])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[11], m_cVertexS[8])); //6
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[9])); //7
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
                polygon0.Add(m_cVertexS[12]);
                polygon0.Add(m_cVertexS[13]);
                polygon0.Add(m_cVertexS[14]);
                polygon0.Add(m_cVertexS[15]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, CContact cContact, Font font, Brush brush)
        {
            try
            {
                // If value
                Brush brushValue = bValue ? new SolidBrush(Color.Blue) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                List<Point> pointsPolygon = new List<Point>();
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());
                
                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // Base
                int h = Math.Abs(m_cBoundingBoxeS[0].Y - m_cBoundingBoxeS[3].Y);
                int w = Math.Abs(m_cBoundingBoxeS[0].X - m_cBoundingBoxeS[1].X);
                float segment = w / 6f; // (3 cells * 2 segments)

                // Size font comparer
                string strComparer = cContact.Operator;
               
                SizeF sizeFont = graphics.MeasureString(strComparer, font);
                graphics.DrawString(strComparer, font, brush, new PointF(point.X + 0 * segment, point.Y - (sizeFont.Height / 2f)), stringFormat);

                // Source 1 and 2
                string strSource1 = "";
                string strSource2 = "";
                string strSource3 = "";

                switch (cContact.ContentS.Count)
                {
                    case 1 :
                        strSource1 = cContact.ContentS[0].Argument;
                        segment = segment*3/2;
                        break;
                    case 2:
                        strSource1 = cContact.ContentS[0].Argument;
                        strSource2 = cContact.ContentS[1].Argument;
                        break;
                    case 3:
                        strSource1 = cContact.ContentS[0].Argument;
                        strSource2 = cContact.ContentS[1].Argument;
                        strSource3 = cContact.ContentS[2].Argument;
                        segment = segment/2;
                        break;
                }

                // Source 1
                if (strSource1 != string.Empty)
                {
                    sizeFont = graphics.MeasureString(strSource1, font);
                    graphics.DrawString(strSource1, font, brush,
                        new PointF(point.X + 2*segment, point.Y - (sizeFont.Height/2f)), stringFormat);
                }

                // Source 2
                if (strSource2 != string.Empty)
                {
                    sizeFont = graphics.MeasureString(strSource2, font);
                    graphics.DrawString(strSource2, font, brush,
                        new PointF(point.X + 4*segment, point.Y - (sizeFont.Height/2f)), stringFormat);
                }

                // Source 3
                if (strSource3 != string.Empty)
                {
                    sizeFont = graphics.MeasureString(strSource3, font);
                    graphics.DrawString(strSource3, font, brush,
                        new PointF(point.X + 6 * segment, point.Y - (sizeFont.Height / 2f)), stringFormat);
                }

//                // Comment and time
//                Font fontComment = new Font(font.SystemFontName, (int)(0.8 * font.Size));
//                sizeFont = graphics.MeasureString(cContact.RefTagS.GetBaseDescription(), fontComment);
//                int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )

//                // Time
//                float levelHeight = 20F;
//                Font fontTime = new Font(font.SystemFontName, (int)(0.8 * font.Size));
//                sizeFont = graphics.MeasureString(strTime, fontTime);
//                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X + 2 * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);
//                levelHeight += sizeFont.Height;

//#if CUSTOM_PAJU
//#else
//                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X + 2 * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);
//#endif
//                // String symbol (comment) --> If we see at GX developer editor, comment if below the Source 2
//                graphics.DrawString(cContact.RefTagS.GetBaseDescription(), fontComment, brush, new RectangleF(point.X + 4 * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }


    }
}
