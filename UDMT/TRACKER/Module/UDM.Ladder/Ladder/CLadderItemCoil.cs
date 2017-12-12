using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.UI
{
    class CLadderItemCoil : CLadderItem
    {
        #region Private Members

        private bool m_bValue = false;
        private CCoil m_cCoil = null;

        #endregion

        #region Public Properties

        public CCoil Coil { get { return m_cCoil; } set { m_cCoil = value; } }
        public bool Value { get { return m_bValue; } set { m_bValue = value; } }

        #endregion

        #region Protected Methods

        protected override void Vertexes()
        {
            m_cVertexS.Add(new CVertex(-30, 20)); // 0
            m_cVertexS.Add(new CVertex(320, 20)); // 1
            m_cVertexS.Add(new CVertex(-20, -20)); // 2
            m_cVertexS.Add(new CVertex(-20, 20)); // 3
            m_cVertexS.Add(new CVertex(330, 20)); // 4 *
            m_cVertexS.Add(new CVertex(330, -20)); // 5 *
            m_cVertexS.Add(new CVertex(-30, 0)); // 6 *
            m_cVertexS.Add(new CVertex(-50, 0)); // 7
            m_cVertexS.Add(new CVertex(320, -20)); // 8
            m_cVertexS.Add(new CVertex(-30, -20)); // 9
            m_cVertexS.Add(new CVertex(330, 0)); // 10 *
            m_cVertexS.Add(new CVertex(350, 0)); // 11
            m_cVertexS.Add(new CVertex(-10, 10)); // 12
            m_cVertexS.Add(new CVertex(-10, -10)); // 13
            m_cVertexS.Add(new CVertex(310, 10)); // 14
            m_cVertexS.Add(new CVertex(310, -10)); // 15
        }

        protected override void Edges()
        {
            try
            {
                m_cEdgeS.Add(new CEdge(m_cVertexS[3], m_cVertexS[0]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[9], m_cVertexS[2]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[9], m_cVertexS[0]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[5], m_cVertexS[4]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[1]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[5]));
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[11]));
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

        protected override void DrawAdditional(Graphics graphics, Point point)
        {
            try
            {
                // If value
                Brush brushValue = m_bValue ? new SolidBrush(Color.Blue) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                List<Point> pointsPolygon = new List<Point>();
                CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());
                
                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // Info
                SizeF sizeFontAddress = graphics.MeasureString(m_cCoil.Tag.Address, m_font);
                SizeF sizeFontCommand = graphics.MeasureString(m_cCoil.Command, m_font);
                SizeF sizeFontProgram = graphics.MeasureString(m_cCoil.Program + " -> " + "/* fill ? */", m_font);

                int nOffset = (int)(Math.Abs(m_cVertexS[10].X - m_cVertexS[0].X) / 4.0);
                int nRef = m_cVertexS[10].X < m_cVertexS[0].X ? m_cVertexS[10].X : m_cVertexS[0].X;
                nRef += 10;

                graphics.DrawString(m_cCoil.Command, m_font, m_brushText, new Point(point.X + nRef + 1 * nOffset, point.Y - (int)Math.Round(0.5 * sizeFontCommand.Height)), stringFormat);
                graphics.DrawString(m_cCoil.Tag.Address, m_font, m_brushText, new Point(point.X + nRef + 2 * nOffset, point.Y - (int)Math.Round(0.5 * sizeFontAddress.Height)), stringFormat);
                graphics.DrawString(m_cCoil.Program + " -> " + "/* fill ? */", m_font, m_brushText, new Point(point.X + nRef + 3 * nOffset, point.Y - (int)Math.Round(0.5 * sizeFontProgram.Height)), stringFormat);

                // String symbol (comment)
                Font fontComment = new Font(m_font.SystemFontName, (int)(0.8 * m_font.Size));
                SizeF sizeFontSymbol = graphics.MeasureString("DEFAULT", fontComment);
                int nWrapBoxHeight = (int)(2.5 * sizeFontSymbol.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = (int)Math.Abs(m_cVertexS[10].X - m_cVertexS[0].X);
                int nOffsetVertical = (int)(Math.Abs(m_cVertexS[4].X - m_cVertexS[5].X) / 2.0);
                sizeFontSymbol = graphics.MeasureString(m_cCoil.Tag.Description, fontComment);
                graphics.DrawString(m_cCoil.Tag.Description, fontComment, m_brushText, new RectangleF(point.X + nRef, point.Y + nOffsetVertical + 20F, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
                
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        protected override void LoadAdditional()
        {
            PutInExcludedPolygons(0); // For value indicator
        }

        protected override void DisposeAdditional()
        {

        }

        #endregion

        #region Public Methods

        public CLadderItemCoil()
        {

        }

        #endregion
    }
}
