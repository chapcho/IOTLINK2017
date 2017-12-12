using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class ABContactOns
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

        static ABContactOns()
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
            m_cVertexS.Add(new CVertex(-6, -13)); // 4
            m_cVertexS.Add(new CVertex(-6, 13)); // 5
            m_cVertexS.Add(new CVertex(6, 13)); // 6
            m_cVertexS.Add(new CVertex(6, -13)); // 7
            m_cVertexS.Add(new CVertex(-10, -13)); // 8
            m_cVertexS.Add(new CVertex(-10, 13)); // 9
            m_cVertexS.Add(new CVertex(-22, 13)); // 10
            m_cVertexS.Add(new CVertex(-22, -13)); // 11
            m_cVertexS.Add(new CVertex(10, -13)); // 12
            m_cVertexS.Add(new CVertex(22, -13)); // 13
            m_cVertexS.Add(new CVertex(10, 0)); // 14
            m_cVertexS.Add(new CVertex(22, 0)); // 15
            m_cVertexS.Add(new CVertex(22, 13)); // 16
            m_cVertexS.Add(new CVertex(10, 13)); // 17
            m_cVertexS.Add(new CVertex(-23, -15)); // 18
            m_cVertexS.Add(new CVertex(-32, -15)); // 19
            m_cVertexS.Add(new CVertex(-32, 15)); // 20
            m_cVertexS.Add(new CVertex(-23, 15)); // 21
            m_cVertexS.Add(new CVertex(24, -15)); // 22
            m_cVertexS.Add(new CVertex(32, -15)); // 23
            m_cVertexS.Add(new CVertex(32, 15)); // 24
            m_cVertexS.Add(new CVertex(25, 15)); // 25
            m_cVertexS.Add(new CVertex(32, 0)); // 26
            m_cVertexS.Add(new CVertex(50, 0)); // 27
            m_cVertexS.Add(new CVertex(-32, 0)); // 28
            m_cVertexS.Add(new CVertex(-50, 0)); // 29
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[24], m_cVertexS[25])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[28], m_cVertexS[29])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[26], m_cVertexS[27])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[22], m_cVertexS[23])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[20], m_cVertexS[21])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[24], m_cVertexS[23])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[20], m_cVertexS[19])); //6
                m_cEdgeS.Add(new CEdge(m_cVertexS[18], m_cVertexS[19])); //7
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[6])); //8
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //9
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //10
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[9])); //11
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[9])); //12
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[11])); //13
                m_cEdgeS.Add(new CEdge(m_cVertexS[11], m_cVertexS[8])); //14
                m_cEdgeS.Add(new CEdge(m_cVertexS[12], m_cVertexS[13])); //15
                m_cEdgeS.Add(new CEdge(m_cVertexS[12], m_cVertexS[14])); //16
                m_cEdgeS.Add(new CEdge(m_cVertexS[15], m_cVertexS[16])); //17
                m_cEdgeS.Add(new CEdge(m_cVertexS[17], m_cVertexS[16])); //18
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
