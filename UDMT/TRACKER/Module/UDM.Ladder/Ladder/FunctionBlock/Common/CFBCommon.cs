using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public class CFBCommon
    {
        #region Member Variables

        private int m_iRowOccupied = 2;
        private int m_iCellHeight = 100;
        private int m_iTotalHeight = 200;

        private HashSet<int> m_hashExcludedPolygons = new HashSet<int>();
        private CVertexS m_cVertexS = new CVertexS();
        private CEdgeS m_cEdgeS = new CEdgeS();
        private CPolygonS m_cPolygonS = new CPolygonS();
        private CVertexS m_cBoundingBoxeS = new CVertexS();

        #endregion

        public CVertexS Vertexs { get { return m_cVertexS; } }
        public CEdgeS Edges { get { return m_cEdgeS; } }
        public CPolygonS Polygons { get { return m_cPolygonS; } }
        public CVertexS BoundingBoxes { get { return m_cBoundingBoxeS; } }
        public HashSet<int> ExcludedPolygons { get { return m_hashExcludedPolygons; } }
        public int RowOccupied { get { return m_iRowOccupied; } set { m_iRowOccupied = value; } }
        public int FBHeight { get { return m_iTotalHeight; } }

        public CFBCommon()
        { 
        }

        public CFBCommon(int iRowOccupied)
        {
            m_iRowOccupied = iRowOccupied;
            
            InitVertexes();
            InitEdges();
            InitPolygons();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        
        private void InitVertexes()
        {
            int iHeight = 140;
            if(m_iRowOccupied > 2)
                iHeight += (m_iRowOccupied - 2) * m_iCellHeight;

            m_iTotalHeight = 40 + iHeight;

            // Vertexes
            m_cVertexS.Add(new CVertex(-30, iHeight)); // 0
            m_cVertexS.Add(new CVertex(-30, -40)); // 1
            m_cVertexS.Add(new CVertex(230, iHeight)); // 2
            m_cVertexS.Add(new CVertex(230, -40)); // 3

            m_cVertexS.Add(new CVertex(-30, 0)); // 4
            m_cVertexS.Add(new CVertex(-50, 0)); // 5
            m_cVertexS.Add(new CVertex(230, 0)); // 6
            m_cVertexS.Add(new CVertex(250, 0)); // 7

            m_cVertexS.Add(new CVertex(-40, -40)); // 8
            m_cVertexS.Add(new CVertex(-40, 140)); // 9
            m_cVertexS.Add(new CVertex(170, 140)); // 10
            m_cVertexS.Add(new CVertex(170, -40)); // 11
        }

        private void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[2])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[1], m_cVertexS[3])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3])); //3

                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //5

            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private void InitPolygons()
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
    }
}

