using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.Log;

namespace UDM.Ladder
{
    public static class SiemensContactFunctionBlock 
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

        static SiemensContactFunctionBlock()
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
            m_cVertexS.Add(new CVertex(-40, 35));   // 0
            m_cVertexS.Add(new CVertex(-40, -35));  // 1
            m_cVertexS.Add(new CVertex(40, 35));    // 2
            m_cVertexS.Add(new CVertex(40, -35));   // 3

            m_cVertexS.Add(new CVertex(40, 0));     // 4
            m_cVertexS.Add(new CVertex(50, 0));     // 5

            m_cVertexS.Add(new CVertex(-35, -30));  // 6
            m_cVertexS.Add(new CVertex(-35, 30));   // 7
            m_cVertexS.Add(new CVertex(35, 30));    // 8
            m_cVertexS.Add(new CVertex(35, -30));   // 9

        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[2])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[1], m_cVertexS[3])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3])); //3

                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //4
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
                polygon0.Add(m_cVertexS[6]);
                polygon0.Add(m_cVertexS[7]);
                polygon0.Add(m_cVertexS[8]);
                polygon0.Add(m_cVertexS[9]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, CContact cContact, Font font, Brush brush, CTimeLogS cLogS)
        {
            try
            {
                // If value
                Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90, Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                if (m_cPolygonS.Count > 0)
                {
                    CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                    graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());
                }

                string strAddress = cContact.RefTagS.GetBaseAddress();
                string strDescription = cContact.RefTagS.GetBaseDescription();

                if (strAddress == "" || strAddress == string.Empty)
                {
                    if (cContact.ContentS.Count > 0)
                        strAddress = cContact.ContentS[0].Argument;
                }

                if (strDescription == string.Empty) strDescription = " ";

                if (bValue)
                    brush = new SolidBrush(Color.Black);
                else
                    brush = new SolidBrush(Color.Green);

                SizeF sizeFont = graphics.MeasureString(strAddress, font);

                int nWrapBoxHeight = (int)(2.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);
                
                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // Address
                graphics.DrawString(strAddress, new Font(font.SystemFontName, (int)(0.9 * font.Size)), brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.5f), point.Y - (int)Math.Round(sizeFont.Height * 2), (int)(nWrapBoxWidth * 2 / 2.5f), nWrapBoxHeight), stringFormat);

                // Comment
                float levelHeight = 0F;
                Font fontComment = new Font(font.SystemFontName, (float)(0.8 * font.Size));
                sizeFont = graphics.MeasureString(strDescription, fontComment);
                graphics.DrawString(strDescription, fontComment, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.5f), point.Y - (int)Math.Round(sizeFont.Height * 0.5), (int)(nWrapBoxWidth * 2 / 2.5f), nWrapBoxHeight), stringFormat);

                // time
                levelHeight += 15F + (sizeFont.Height*2);
                brush = new SolidBrush(Color.Green);
                Font fontTime = new Font(font.SystemFontName, (int)(0.7 * font.Size));
                sizeFont = graphics.MeasureString(strTime, fontTime);
                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.5f), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
