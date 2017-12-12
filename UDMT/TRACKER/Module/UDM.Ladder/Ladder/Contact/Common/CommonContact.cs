using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.Log;

namespace UDM.Ladder
{
    public class CommonContact : CLadderItem, ILadderItemContact
    {
        #region Private Members
        private bool m_bValue = false;
        private DateTime m_dtTime = DateTime.MinValue;
        private string m_sFormatDate = "";
        private CContact m_cContact = null;
        private CFB_Info m_cFB_Info = null;
        #endregion

        #region Public Properties

        public CContact Contact { get { return m_cContact; } set { m_cContact = value; Update(); } }
        public bool Value { get { return m_bValue; } set { m_bValue = value; } }
        public DateTime Date { get { return m_dtTime; } set { m_dtTime = value; } }
        public string DateFormat { get { return m_sFormatDate; } set { m_sFormatDate = value; } }

        public CFB_Info FB_Info { get { return m_cFB_Info; } set { m_cFB_Info = value; } }

        #endregion

        #region Protected Methods

        protected override void Vertexes() { }
        protected override void Edges() { }
        protected override void Polygons() { }
        protected override void Beziers() { }

        protected override void DrawAdditional(Graphics graphics, Point point, CTimeLogS cLogS)
        {
            try
            {
                switch (m_cContact.ContactType)
                {
                    case EMContactType.Compare: MELSECContactCompare.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cContact, m_font, m_brushText, cLogS); break;
                    case EMContactType.SystemFunction: CCommonContactFB.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cContact, m_font, m_brushText); break;//EMContactType.Function
                    case EMContactType.Function: SiemensContactFunctionBlock.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cContact, m_font, m_brushText, cLogS); break;
                    case EMContactType.Constant: break;
                    default: DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cContact.RefTagS.GetBaseAddress(), m_cContact.RefTagS.GetBaseDescription(), m_font, m_brushText); return;
                }
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        #endregion

        #region Private Methods

        private void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, string strAddress, string strDescription, Font font, Brush brush)
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

                if(strAddress == "" || strAddress == string.Empty)
                {
                    if (m_cContact.ContentS.Count > 0)
                        strAddress = m_cContact.ContentS[0].Argument;
                }

                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;

                // String address
                SizeF sizeFont = graphics.MeasureString(strAddress, font);
                graphics.DrawString(strAddress, font, brush, new Point(point.X, point.Y - 20 - (int)Math.Round(sizeFont.Height)), stringFormat);

                // Comment and time
                Font fontComment = new Font(font.SystemFontName, (float)(0.8 * font.Size));
                sizeFont = graphics.MeasureString(strDescription, fontComment);
                int nWrapBoxHeight = (int)(2 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);

                // Time
                float levelHeight = 20f;

//#if CUSTOM_PAJU
//                // NOTHING (for skipping ..)
//#else
                Font fontTime = new Font(font.SystemFontName, (float)(0.7 * font.Size));
                sizeFont = graphics.MeasureString(strTime, fontTime);
                graphics.DrawString(strTime, fontTime, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0f), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
                levelHeight += levelHeight;//sizeFont.Height;
//#endif
                // String symbol (comment)
                fontComment = new Font(font.SystemFontName, (float)(0.75 * font.Size));
                graphics.DrawString(strDescription, fontComment, brush, new RectangleF(point.X - (int)(nWrapBoxWidth / 2.0f), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private void Update()
        {
            if (m_cContact == null) { return; }
            ClearResources();

            m_cContact.Operator = m_cContact.Operator.Replace("[", string.Empty).Replace("]", string.Empty);

            if (m_cContact.ContactType == EMContactType.Compare)
                ContactCompare();

            else if (m_cContact.ContactType == EMContactType.SystemFunction)
                ContactSystemFB();

            else if (m_cContact.ContactType == EMContactType.Function)
                ContactSiemensFB();

            else if (m_cContact.ContactType == EMContactType.Bit)
            {
                if (m_cContact.Operator == "XIC")
                    ContactOpen();
                else if (m_cContact.Operator == "XIO")
                    ContactClose();
                else if (m_cContact.Operator == "XIOF")
                    ContactPulseOffClose();
                else if (m_cContact.Operator == "XICF")
                    ContactPulseOffOpen();
                else if (m_cContact.Operator == "XIOP")
                    ContactPulseOnClose();
                else if (m_cContact.Operator == "XICP")
                    ContactPulseOnOpen();
                else
                    ContactNone();
            }
            else if (m_cContact.ContactType == EMContactType.Logical)
            {
                if (m_cContact.Operator == "INV")
                    ContactLogicalINV();
                else if (m_cContact.Operator == "ONSP")
                {
                    //if (m_cContact.ContentS.Count > 0)
                    //    ContactLogicalEGP();
                    //else
                        ContactLogicalMEP();
                }
                else if (m_cContact.Operator == "ONSF")
                {
                    //if (m_cContact.ContentS.Count > 0)
                    //    ContactLogicalEGF();
                    //else
                        ContactLogicalMEF();
                }
                else if (m_cContact.Operator == "AFI")
                    ContactLogicalAFI();
                else
                    ContactNone();
            }
            else if (m_cContact.ContactType == EMContactType.Constant)
            {

            }
            else
            {
                if (m_cContact.Operator == "LOAD")
                    ContactOpen();
                else
                    ContactNone();
            }
        }

        private void ClearResources()
        {
            // Dont clear !!, because if we use clear, it means we clear up the previous reference static variable from MELSECContactOpen, MELSECContactClose, etc ...
            // So, just assign a new empty
            m_cVertexS = new CVertexS();
            m_cEdgeS = new CEdgeS();
            m_cPolygonS = new CPolygonS();
            m_cBoundingBoxeS = new CVertexS();
            m_cBezierS = new CBezierS();
            m_hashExcludedPolygons = new HashSet<int>();
            m_nColumnOccupied = 1;
        }

        private void ContactOpen()
        {
            m_cVertexS = MELSECContactOpen.Vertexs;
            m_cEdgeS = MELSECContactOpen.Edges;
            m_cPolygonS = MELSECContactOpen.Polygons;
            m_cBoundingBoxeS = MELSECContactOpen.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactOpen.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactOpen.ColumnOccupied;
        }

        private void ContactClose()
        {
            m_cVertexS = MELSECContactClose.Vertexs;
            m_cEdgeS = MELSECContactClose.Edges;
            m_cPolygonS = MELSECContactClose.Polygons;
            m_cBoundingBoxeS = MELSECContactClose.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactClose.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactClose.ColumnOccupied;
        }

        private void ContactPulseOffClose()
        {
            m_cVertexS = MELSECContactPulseOffClose.Vertexs;
            m_cEdgeS = MELSECContactPulseOffClose.Edges;
            m_cPolygonS = MELSECContactPulseOffClose.Polygons;
            m_cBoundingBoxeS = MELSECContactPulseOffClose.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactPulseOffClose.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactPulseOffClose.ColumnOccupied;
        }

        private void ContactPulseOffOpen()
        {
            m_cVertexS = MELSECContactPulseOffOpen.Vertexs;
            m_cEdgeS = MELSECContactPulseOffOpen.Edges;
            m_cPolygonS = MELSECContactPulseOffOpen.Polygons;
            m_cBoundingBoxeS = MELSECContactPulseOffOpen.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactPulseOffOpen.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactPulseOffOpen.ColumnOccupied;
        }

        private void ContactPulseOnClose()
        {
            m_cVertexS = MELSECContactPulseOnClose.Vertexs;
            m_cEdgeS = MELSECContactPulseOnClose.Edges;
            m_cPolygonS = MELSECContactPulseOnClose.Polygons;
            m_cBoundingBoxeS = MELSECContactPulseOnClose.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactPulseOnClose.ExcludedPolygons;
        }

        private void ContactPulseOnOpen()
        {
            m_cVertexS = MELSECContactPulseOnOpen.Vertexs;
            m_cEdgeS = MELSECContactPulseOnOpen.Edges;
            m_cPolygonS = MELSECContactPulseOnOpen.Polygons;
            m_cBoundingBoxeS = MELSECContactPulseOnOpen.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactPulseOnOpen.ExcludedPolygons;
        }

        private void ContactCompare()
        {
            m_cVertexS = MELSECContactCompare.Vertexs;
            m_cEdgeS = MELSECContactCompare.Edges;
            m_cPolygonS = MELSECContactCompare.Polygons;
            m_cBoundingBoxeS = MELSECContactCompare.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactCompare.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactCompare.ColumnOccupied;
        }

        /// <summary>
        /// XGI Series에 국한됨
        /// </summary>
        private void ContactSystemFB()
        {
            m_cVertexS = MELSECContactCompare.Vertexs;
            m_cEdgeS = MELSECContactCompare.Edges;
            m_cPolygonS = MELSECContactCompare.Polygons;
            m_cBoundingBoxeS = MELSECContactCompare.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactCompare.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactCompare.ColumnOccupied;
        }

        private void ContactLogicalAFI()
        {
            m_cVertexS = CCommonContactLogicalAFI.Vertexs;
            m_cEdgeS = CCommonContactLogicalAFI.Edges;
            m_cPolygonS = CCommonContactLogicalAFI.Polygons;
            m_cBoundingBoxeS = CCommonContactLogicalAFI.BoundingBoxes;
            m_hashExcludedPolygons = CCommonContactLogicalAFI.ExcludedPolygons;
            m_nColumnOccupied = CCommonContactLogicalAFI.ColumnOccupied;
        }

        private void ContactLogicalINV()
        {
            m_cVertexS = MELSECContactLogicalINV.Vertexs;
            m_cEdgeS = MELSECContactLogicalINV.Edges;
            m_cPolygonS = MELSECContactLogicalINV.Polygons;
            m_cBoundingBoxeS = MELSECContactLogicalINV.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactLogicalINV.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactLogicalINV.ColumnOccupied;
        }

        private void ContactLogicalMEP()
        {
            m_cVertexS = MELSECContactLogicalMEP.Vertexs;
            m_cEdgeS = MELSECContactLogicalMEP.Edges;
            m_cPolygonS = MELSECContactLogicalMEP.Polygons;
            m_cBoundingBoxeS = MELSECContactLogicalMEP.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactLogicalMEP.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactLogicalMEP.ColumnOccupied;
        }

        private void ContactLogicalMEF()
        {
            m_cVertexS = MELSECContactLogicalMEF.Vertexs;
            m_cEdgeS = MELSECContactLogicalMEF.Edges;
            m_cPolygonS = MELSECContactLogicalMEF.Polygons;
            m_cBoundingBoxeS = MELSECContactLogicalMEF.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactLogicalMEF.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactLogicalMEF.ColumnOccupied;
        }

        private void ContactLogicalEGP()
        {
            m_cVertexS = MELSECContactLogicalEGP.Vertexs;
            m_cEdgeS = MELSECContactLogicalEGP.Edges;
            m_cPolygonS = MELSECContactLogicalEGP.Polygons;
            m_cBoundingBoxeS = MELSECContactLogicalEGP.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactLogicalEGP.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactLogicalEGP.ColumnOccupied;
        }

        private void ContactLogicalEGF()
        {
            m_cVertexS = MELSECContactLogicalEGF.Vertexs;
            m_cEdgeS = MELSECContactLogicalEGF.Edges;
            m_cPolygonS = MELSECContactLogicalEGF.Polygons;
            m_cBoundingBoxeS = MELSECContactLogicalEGF.BoundingBoxes;
            m_hashExcludedPolygons = MELSECContactLogicalEGF.ExcludedPolygons;
            m_nColumnOccupied = MELSECContactLogicalEGF.ColumnOccupied;
        }

        private void ContactNone()
        {
            m_cVertexS = CContactNone.Vertexs;
            m_cEdgeS = CContactNone.Edges;
            m_cBoundingBoxeS = CContactNone.BoundingBoxes;
            m_nColumnOccupied = CContactNone.ColumnOccupied;
        }

        private void ContactSiemensFB()
        {
            m_cVertexS = SiemensContactFunctionBlock.Vertexs;
            m_cEdgeS = SiemensContactFunctionBlock.Edges;
            m_cPolygonS = SiemensContactFunctionBlock.Polygons;
            m_cBoundingBoxeS = SiemensContactFunctionBlock.BoundingBoxes;
            m_hashExcludedPolygons = SiemensContactFunctionBlock.ExcludedPolygons;
            m_nColumnOccupied = SiemensContactFunctionBlock.ColumnOccupied;
        }
            
        #endregion

        #region Public Methods

        public CommonContact()
        {

        }

        #endregion
    }
}
