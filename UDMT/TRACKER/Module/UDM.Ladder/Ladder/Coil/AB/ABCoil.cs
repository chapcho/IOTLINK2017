using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{

#if USE_AB

    public class ABCoil : CLadderItem, ILadderItemCoil
    {
        #region Private Members

        private bool m_bValue = false;
        private DateTime m_dtTime = DateTime.MinValue;
        private string m_sFormatDate = "";
        private CCoil m_cCoil = null;

        #endregion

        #region Public Properties

        public CCoil Coil { get { return m_cCoil; } set { m_cCoil = value; Update(); } }
        public bool Value { get { return m_bValue; } set { m_bValue = value; } }
        public DateTime Date { get { return m_dtTime; } set { m_dtTime = value; } }
        public string DateFormat { get { return m_sFormatDate; } set { m_sFormatDate = value; } }

        #endregion

        #region Protected Methods

        protected override void Vertexes() { }
        protected override void Edges() { }
        protected override void Polygons() { }
        protected override void Beziers() { }

        protected override void DrawAdditional(Graphics graphics, Point point)
        {
            try
            {
                switch (m_cCoil.CoilType) 
                { 
                    default:
                        DrawAdditional(graphics, point, m_bValue, m_cCoil.Tag as CABTag, m_font, m_brushText);
                        break;
                }
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        #endregion

        #region Private Methods

        private void Update()
        {
            if (m_cCoil == null) { return; }
            switch (m_cCoil.CoilType)
            {
                case EMCoilType.Normal: CoilNormal(); break;
                case EMCoilType.OutputLatch: CoilOutputLatch(); break;
                case EMCoilType.OutputUnlatch: CoilOutputUnLatch(); break;
            }
        }

        private void CoilNormal()
        {
            m_cVertexS = ABCoilNormal.Vertexs;
            m_cEdgeS = ABCoilNormal.Edges;
            m_cPolygonS = ABCoilNormal.Polygons;
            m_cBezierS = ABCoilNormal.Beziers;
            m_cBoundingBoxeS = ABCoilNormal.BoundingBoxes;
            m_hashExcludedPolygons = ABCoilNormal.ExcludedPolygons;
        }

        private void CoilOutputLatch()
        {
            m_cVertexS = ABCoilOutputLatch.Vertexs;
            m_cEdgeS = ABCoilOutputLatch.Edges;
            m_cPolygonS = ABCoilOutputLatch.Polygons;
            m_cBezierS = ABCoilOutputLatch.Beziers;
            m_cBoundingBoxeS = ABCoilOutputLatch.BoundingBoxes;
            m_hashExcludedPolygons = ABCoilOutputLatch.ExcludedPolygons;
        }

        private void CoilOutputUnLatch()
        {
            m_cVertexS = ABCoilOutputUnLatch.Vertexs;
            m_cEdgeS = ABCoilOutputUnLatch.Edges;
            m_cPolygonS = ABCoilOutputUnLatch.Polygons;
            m_cBezierS = ABCoilOutputUnLatch.Beziers;
            m_cBoundingBoxeS = ABCoilOutputUnLatch.BoundingBoxes;
            m_hashExcludedPolygons = ABCoilOutputUnLatch.ExcludedPolygons;
        }

        public void DrawAdditional(Graphics graphics, Point point, bool bValue, CABTag cABTag, Font font, Brush brush)
        {
            // If value
            Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90, Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
            CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
            graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());

            // String format 
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;

            // String address
            SizeF sizeFont = graphics.MeasureString(cABTag.Address, font);
            graphics.DrawString(cABTag.Address, font, brush, new Point(point.X, point.Y - 20 - (int)Math.Round(sizeFont.Height)), stringFormat);
        }
     
        #endregion

        #region Public Methods

        public ABCoil()
        {

        }

        #endregion
    }

#endif

}