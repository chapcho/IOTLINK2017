using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using System.Windows.Forms;
using UDM.Log;

namespace UDM.Ladder
{
    public static class MELSECCoilSpecial
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
        public static int ColumnOccupied { get { return 4; } }

        static MELSECCoilSpecial()
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
            m_cVertexS.Add(new CVertex(320, 20)); // 1
            m_cVertexS.Add(new CVertex(-20, -20)); // 2
            m_cVertexS.Add(new CVertex(-20, 20)); // 3
            m_cVertexS.Add(new CVertex(330, 20)); // 4
            m_cVertexS.Add(new CVertex(330, -20)); // 5
            m_cVertexS.Add(new CVertex(-30, 0)); // 6
            m_cVertexS.Add(new CVertex(-50, 0)); // 7
            m_cVertexS.Add(new CVertex(320, -20)); // 8
            m_cVertexS.Add(new CVertex(-30, -20)); // 9
            m_cVertexS.Add(new CVertex(330, 0)); // 10
            m_cVertexS.Add(new CVertex(350, 0)); // 11
            m_cVertexS.Add(new CVertex(-10, 10)); // 12
            m_cVertexS.Add(new CVertex(-10, -10)); // 13
            m_cVertexS.Add(new CVertex(310, 10)); // 14
            m_cVertexS.Add(new CVertex(310, -10)); // 15
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[3], m_cVertexS[0])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[9], m_cVertexS[2])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[9], m_cVertexS[0])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[5], m_cVertexS[4])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[1])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[5])); //6
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[11])); //7
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
                polygon0.Add(m_cVertexS[13]);
                polygon0.Add(m_cVertexS[12]);
                polygon0.Add(m_cVertexS[14]);
                polygon0.Add(m_cVertexS[15]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public static void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, CCoil cCoil, Font font, Brush brush, CTimeLogS cLogS)
        {
            try
            {
                // If value
                //Brush brushValue = bValue ? new SolidBrush(Color.Blue) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90, Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                List<Point> pointsPolygon = new List<Point>();
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());
                
                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // Base
                int h = Math.Abs(m_cBoundingBoxeS[0].Y - m_cBoundingBoxeS[3].Y);
                int w = Math.Abs(m_cBoundingBoxeS[0].X - m_cBoundingBoxeS[1].X);
                string sInstruction = cCoil.Instruction;
                float segment = w / ((sInstruction.Split('\t').Where(x => x != string.Empty).Count()) * 2);

                //Draw Command
                string sOperator = cCoil.Command;
                SizeF sizeFont = graphics.MeasureString(sOperator, font);
                graphics.DrawString(sOperator, font, brush, new PointF(point.X, point.Y - (sizeFont.Height / 2f)), stringFormat);

                string sArgument = string.Empty;
                int iContentPosition = 2; //cCoil.ContentS.Count;
                CTag cTag = null;
                Font fontComment = null;
                Font fontTime = null;
                Font fontWordValue = null;
                int nWrapBoxHeight = -1;
                float levelHeight = 20F;

                foreach (CContent cContent in cCoil.ContentS)
                {
                    sArgument = cContent.Argument;

                    //Draw Argument(Address)
                    sizeFont = graphics.MeasureString(sArgument, font);
                    graphics.DrawString(sArgument, font, brush, new PointF(point.X + iContentPosition * segment, point.Y - (sizeFont.Height / 2f)), stringFormat);

                    //if (cContent.Parameter == string.Empty)
                    //    continue;

                    if (cContent.Tag != null)
                    {
                        cTag = cContent.Tag;

                        // Comment and time Size
                        fontComment = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                        sizeFont = graphics.MeasureString(cTag.GetDescription(), fontComment);
                        nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )

                        if(cLogS != null && cLogS.Count > 0)
                        {
                            foreach(CTimeLog cLog in cLogS)
                            {
                                if (cTag.Key == cLog.Key)
                                {
                                    strTime = cLog.Time.ToString("yyyy-MM-dd\nHH:mm:ss;fff");

                                    levelHeight = -20F;
                                    fontWordValue = new Font(font.SystemFontName, (int)(0.8 * font.Size), FontStyle.Bold);
                                    graphics.DrawString(cLog.Value.ToString(), fontWordValue, new SolidBrush(Color.Fuchsia), new RectangleF(point.X + iContentPosition * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);
                                }
                            }
                        }

                        //Draw Time
                        levelHeight = 20F;
                        fontTime = new Font(font.SystemFontName, (int)(0.7 * font.Size));
                        sizeFont = graphics.MeasureString(strTime, fontTime);
                        graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X + iContentPosition * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);
                        levelHeight += sizeFont.Height;

                        //Draw Comment
                        fontComment = new Font(font.SystemFontName, (float)(0.75 * font.Size));
                        graphics.DrawString(cTag.GetDescription(), fontComment, brush, new RectangleF(point.X + iContentPosition * segment - (int)(sizeFont.Width / 2), point.Y + levelHeight, sizeFont.Width, nWrapBoxHeight), stringFormat);

                    }
                    iContentPosition += 2;
                    //iContentPosition += cCoil.ContentS.Count;
                }

                //// Command
                //string strInstruction = cCoil.Instruction.Replace("\t", "     ");
                //sizeFont = graphics.MeasureString(strInstruction, font);
                //graphics.DrawString(strInstruction, font, brushInfo, new PointF(xLeftMost + nCounter * segment, point.Y - (sizeFont.Height / 2f)), stringFormat);
                //nCounter++;

                //// Comment and time
                //Font fontComment = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                //sizeFont = graphics.MeasureString(cCoil.RefTagS.GetBaseDescription(), fontComment);
                //int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )

                //// Time
                //float levelHeight = 20F;
                //    Font fontTime = new Font(font.SystemFontName, (int)(0.8 * font.Size));
                //    sizeFont = graphics.MeasureString(strTime, fontTime);
                //    graphics.DrawString(strTime, fontTime, brush, new RectangleF(xLeftMost, point.Y + levelHeight, w, nWrapBoxHeight), stringFormat);
                //    levelHeight += sizeFont.Height;

                //// String symbol (comment)
                //    graphics.DrawString(cCoil.RefTagS.GetBaseDescription(), fontComment, brush, new RectangleF(xLeftMost, point.Y + levelHeight, w, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
