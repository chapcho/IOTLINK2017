using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{

#if USE_AB

    public class ABContact : CLadderItem, ILadderItemContact
    {
        #region Private Members

        private bool m_bValue = false;
        private DateTime m_dtTime = DateTime.MinValue;
        private string m_sFormatDate = "";
        private CContact m_cContact = null;

        #endregion

        #region Public Properties

        public CContact Contact { get { return m_cContact; } set { m_cContact = value; Update(); } }
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
                switch (m_cContact.ContactType) 
                {
                    default: DrawAdditional(graphics, point, m_bValue, m_cContact.Tag as CABTag, m_font, m_brushText); return;
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
            if (m_cContact == null) { return; }
            switch (m_cContact.ContactType)
            {
                case EMContactType.Open: ContactOpen(); break;
                case EMContactType.Close: ContactClose(); break;
                case EMContactType.ONS: ContactOns(); break;

                default: ClearResources(); break;
            }
        }

        private void ClearResources()
        {
            // Dont clear !!, because if we use clear, it means we clear up the previous reference static variable from ABContactOpen, ABContactClose, etc ...
            // So, just assign a new empty
            m_cVertexS = new CVertexS();
            m_cEdgeS = new CEdgeS();
            m_cPolygonS = new CPolygonS();
            m_cBoundingBoxeS = new CVertexS();
            m_hashExcludedPolygons = new HashSet<int>();
        }

        private void ContactOpen()
        {
            m_cVertexS = ABContactOpen.Vertexs;
            m_cEdgeS = ABContactOpen.Edges;
            m_cPolygonS = ABContactOpen.Polygons;
            m_cBoundingBoxeS = ABContactOpen.BoundingBoxes;
            m_hashExcludedPolygons = ABContactOpen.ExcludedPolygons;
        }

        private void ContactClose()
        {
            m_cVertexS = ABContactClose.Vertexs;
            m_cEdgeS = ABContactClose.Edges;
            m_cPolygonS = ABContactClose.Polygons;
            m_cBoundingBoxeS = ABContactClose.BoundingBoxes;
            m_hashExcludedPolygons = ABContactClose.ExcludedPolygons;
        }

        private void ContactOns()
        {
            m_cVertexS = ABContactOns.Vertexs;
            m_cEdgeS = ABContactOns.Edges;
            m_cPolygonS = ABContactOns.Polygons;
            m_cBoundingBoxeS = ABContactOns.BoundingBoxes;
            m_hashExcludedPolygons = ABContactOns.ExcludedPolygons;
        }

        private void DrawAdditional(Graphics graphics, Point point, bool bValue, CABTag cABTag, Font font, Brush brush)
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

        public ABContact()
        {

        }

        #endregion
    }

#endif

}
