using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Ladder
{
    public static class CCommonContactLogicalAFI
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

        static CCommonContactLogicalAFI()
        {
            InitVertexes();
            InitEdges();
            InitPolygons();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        private static void InitVertexes()
        {
            m_cVertexS.Add(new CVertex(-11, -15)); // 0
            m_cVertexS.Add(new CVertex(-11, 15)); // 1
            m_cVertexS.Add(new CVertex(11, -15)); // 2
            m_cVertexS.Add(new CVertex(11, 15)); // 3
            m_cVertexS.Add(new CVertex(-25, 20)); // 4
            m_cVertexS.Add(new CVertex(25, -20)); // 5
            m_cVertexS.Add(new CVertex(-25, -20)); // 4-1
            m_cVertexS.Add(new CVertex(25, 20)); // 5 -1
            m_cVertexS.Add(new CVertex(-50, 0)); // 6
            m_cVertexS.Add(new CVertex(50, 0)); // 7

        }

        private static void InitEdges()
        {
            try
            {
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //4-1 - 5-1
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[9])); //6-7
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //4-5

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
                CPolygon polygon0 = new CPolygon();
                polygon0.Add(m_cVertexS[1]);
                polygon0.Add(m_cVertexS[0]);
                polygon0.Add(m_cVertexS[2]);
                polygon0.Add(m_cVertexS[3]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
