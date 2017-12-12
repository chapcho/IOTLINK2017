using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class ABContactOpen
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

        static ABContactOpen()
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
            m_cVertexS.Add(new CVertex(-11, -15)); // 0
            m_cVertexS.Add(new CVertex(-11, 15)); // 1
            m_cVertexS.Add(new CVertex(11, -15)); // 2
            m_cVertexS.Add(new CVertex(11, 15)); // 3
            m_cVertexS.Add(new CVertex(-5, -15)); // 4
            m_cVertexS.Add(new CVertex(-15, -15)); // 5
            m_cVertexS.Add(new CVertex(-5, 15)); // 6
            m_cVertexS.Add(new CVertex(-15, 15)); // 7
            m_cVertexS.Add(new CVertex(5, -15)); // 8
            m_cVertexS.Add(new CVertex(15, -15)); // 9
            m_cVertexS.Add(new CVertex(5, 15)); // 10
            m_cVertexS.Add(new CVertex(15, 15)); // 11
            m_cVertexS.Add(new CVertex(-5, 0)); // 12
            m_cVertexS.Add(new CVertex(-50, 0)); // 13
            m_cVertexS.Add(new CVertex(5, 0)); // 14
            m_cVertexS.Add(new CVertex(50, 0)); // 15
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[12], m_cVertexS[13])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[14], m_cVertexS[15])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[10])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[11])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[6])); //6
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
