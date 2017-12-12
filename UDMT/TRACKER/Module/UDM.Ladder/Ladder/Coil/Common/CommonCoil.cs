using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.Log;

namespace UDM.Ladder
{
    public class CommonCoil : CLadderItem, ILadderItemCoil
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

        protected override void DrawAdditional(Graphics graphics, Point point, CTimeLogS cLogS)
        {
            try
            {
                if (m_cCoil.Command == "SET")
                    MELSECCoilSet.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cCoil, m_font, m_brushText, cLogS);
                else if (m_cCoil.Command == "RST")
                    MELSECCoilReset.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cCoil, m_font, m_brushText, cLogS);
                else if (m_cCoil.CoilType == EMCoilType.Bit)
                    MELSECCoilNormal.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cCoil, m_font, m_brushText);
                else
                    MELSECCoilSpecial.DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cCoil, m_font, m_brushText, cLogS);
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
            ClearResources();

            //CoilEmpty();    
            if (m_cCoil.Command == "SET") { CoilSet(); }
            else if (m_cCoil.Command == "RST") { CoilReset(); }
            else if (m_cCoil.CoilType.Equals(EMCoilType.Bit)) CoilNormal();
            else { CoilSpecial(); }
        }

        private void ClearResources()
        {
            // Dont clear !!, because if we use clear, it means we clear up the previous reference static variable from MELSECContactOpen, MELSECContactClose, etc ...
            // So, just assign a new empty
            m_cVertexS = new CVertexS();
            m_cEdgeS = new CEdgeS();
            m_cPolygonS = new CPolygonS();
            m_cBezierS = new CBezierS();
            m_cBoundingBoxeS = new CVertexS();
            m_hashExcludedPolygons = new HashSet<int>();
            m_nColumnOccupied = 1;
        }

        private void CoilNormal()
        {
            m_cVertexS = MELSECCoilNormal.Vertexs;
            m_cEdgeS = MELSECCoilNormal.Edges;
            m_cPolygonS = MELSECCoilNormal.Polygons;
            m_cBezierS = MELSECCoilNormal.Beziers;
            m_cBoundingBoxeS = MELSECCoilNormal.BoundingBoxes;
            m_hashExcludedPolygons = MELSECCoilNormal.ExcludedPolygons;
            m_nColumnOccupied = MELSECCoilNormal.ColumnOccupied;
        }

        private void CoilSet()
        {
            m_cVertexS = MELSECCoilSet.Vertexs;
            m_cEdgeS = MELSECCoilSet.Edges;
            m_cPolygonS = MELSECCoilSet.Polygons;
            m_cBoundingBoxeS = MELSECCoilSet.BoundingBoxes;
            m_hashExcludedPolygons = MELSECCoilSet.ExcludedPolygons;
            m_nColumnOccupied = MELSECCoilSet.ColumnOccupied;
        }

        private void CoilReset()
        {
            m_cVertexS = MELSECCoilReset.Vertexs;
            m_cEdgeS = MELSECCoilReset.Edges;
            m_cPolygonS = MELSECCoilReset.Polygons;
            m_cBoundingBoxeS = MELSECCoilReset.BoundingBoxes;
            m_hashExcludedPolygons = MELSECCoilReset.ExcludedPolygons;
            m_nColumnOccupied = MELSECCoilReset.ColumnOccupied;
        }

        private void CoilSpecial()
        {
            m_cVertexS = MELSECCoilSpecial.Vertexs;
            m_cEdgeS = MELSECCoilSpecial.Edges;
            m_cPolygonS = MELSECCoilSpecial.Polygons;
            m_cBoundingBoxeS = MELSECCoilSpecial.BoundingBoxes;
            m_hashExcludedPolygons = MELSECCoilSpecial.ExcludedPolygons;
            m_nColumnOccupied = MELSECCoilSpecial.ColumnOccupied;
        }

        private void CoilEmpty()
        {
            m_cVertexS = MELSECCoilEmpty.Vertexs;
            m_cEdgeS = MELSECCoilEmpty.Edges;
            m_cPolygonS = MELSECCoilEmpty.Polygons;
            m_cBoundingBoxeS = MELSECCoilEmpty.BoundingBoxes;
            m_hashExcludedPolygons = MELSECCoilEmpty.ExcludedPolygons;
            m_nColumnOccupied = MELSECCoilEmpty.ColumnOccupied;
        }

        #endregion

        #region Public Methods

        public CommonCoil()
        {

        }

        #endregion
    }
}