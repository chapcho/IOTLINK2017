using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class MELSECContactPulseOnClose
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

        static MELSECContactPulseOnClose()
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
            m_cVertexS.Add(new CVertex(-15, -20)); // 0
            m_cVertexS.Add(new CVertex(-15, 20)); // 1
            m_cVertexS.Add(new CVertex(15, 20)); // 2
            m_cVertexS.Add(new CVertex(15, -20)); // 3
            m_cVertexS.Add(new CVertex(15, 0)); // 4
            m_cVertexS.Add(new CVertex(50, 0)); // 5
            m_cVertexS.Add(new CVertex(-15, 0)); // 6
            m_cVertexS.Add(new CVertex(-50, 0)); // 7
            m_cVertexS.Add(new CVertex(-11, -15)); // 8
            m_cVertexS.Add(new CVertex(-11, 15)); // 9
            m_cVertexS.Add(new CVertex(11, -15)); // 10
            m_cVertexS.Add(new CVertex(11, 15)); // 11
            m_cVertexS.Add(new CVertex(-10, -5)); // 12
            m_cVertexS.Add(new CVertex(10, -5)); // 13
            m_cVertexS.Add(new CVertex(0, -17)); // 14
            m_cVertexS.Add(new CVertex(0, 20)); // 15
            m_cVertexS.Add(new CVertex(0, -20)); // 16
            m_cVertexS.Add(new CVertex(0, 17)); // 17
            m_cVertexS.Add(new CVertex(-25, 20)); // 18
            m_cVertexS.Add(new CVertex(25, -20)); // 19
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[15], m_cVertexS[14])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[18], m_cVertexS[19])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[16], m_cVertexS[17])); //6
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
                polygon0.Add(m_cVertexS[9]);
                polygon0.Add(m_cVertexS[8]);
                polygon0.Add(m_cVertexS[10]);
                polygon0.Add(m_cVertexS[11]);
                m_cPolygonS.Add(polygon0);

                CPolygon polygon1 = new CPolygon();
                polygon1.Add(m_cVertexS[16]);
                polygon1.Add(m_cVertexS[13]);
                polygon1.Add(m_cVertexS[12]);
                m_cPolygonS.Add(polygon1);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
