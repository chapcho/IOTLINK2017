using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class ABCoilOutputUnLatch
    {
        static private HashSet<int> m_hashExcludedPolygons = new HashSet<int>();
        static private CVertexS m_cVertexS = new CVertexS();
        static private CEdgeS m_cEdgeS = new CEdgeS();
        static private CPolygonS m_cPolygonS = new CPolygonS();
        static private CBezierS m_cBezierS = new CBezierS();
        static private CVertexS m_cBoundingBoxeS = new CVertexS();

        public static CVertexS Vertexs { get { return m_cVertexS; } }
        public static CEdgeS Edges { get { return m_cEdgeS; } }
        public static CPolygonS Polygons { get { return m_cPolygonS; } }
        public static CBezierS Beziers { get { return m_cBezierS; } }
        public static CVertexS BoundingBoxes { get { return m_cBoundingBoxeS; } }
        public static HashSet<int> ExcludedPolygons { get { return m_hashExcludedPolygons; } }

        static ABCoilOutputUnLatch()
        {
            InitVertexes();
            InitEdges();
            InitPolygons();
            InitBeziers();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        private static void InitVertexes()
        {
            // Vertexes
            m_cVertexS.Add(new CVertex(-11, -20)); // 0
            m_cVertexS.Add(new CVertex(-11, 20)); // 1
            m_cVertexS.Add(new CVertex(-24, -9)); // 2
            m_cVertexS.Add(new CVertex(-24, 9)); // 3
            m_cVertexS.Add(new CVertex(-21, 0)); // 4
            m_cVertexS.Add(new CVertex(-49, 0)); // 5
            m_cVertexS.Add(new CVertex(21, 0)); // 6
            m_cVertexS.Add(new CVertex(50, 0)); // 7
            m_cVertexS.Add(new CVertex(11, -20)); // 8
            m_cVertexS.Add(new CVertex(24, -9)); // 9
            m_cVertexS.Add(new CVertex(24, 9)); // 10
            m_cVertexS.Add(new CVertex(11, 20)); // 11
            m_cVertexS.Add(new CVertex(-9, -20)); // 12
            m_cVertexS.Add(new CVertex(9, -20)); // 13
            m_cVertexS.Add(new CVertex(9, 20)); // 14
            m_cVertexS.Add(new CVertex(-9, 20)); // 15
            m_cVertexS.Add(new CVertex(-6, 9)); // 16
            m_cVertexS.Add(new CVertex(-2, 13)); // 17
            m_cVertexS.Add(new CVertex(2, 13)); // 18
            m_cVertexS.Add(new CVertex(6, 9)); // 19
            m_cVertexS.Add(new CVertex(-6, -13)); // 20
            m_cVertexS.Add(new CVertex(6, -13)); // 21
        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[19], m_cVertexS[21])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[16], m_cVertexS[20])); //3
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
                polygon0.Add(m_cVertexS[12]);
                polygon0.Add(m_cVertexS[13]);
                polygon0.Add(m_cVertexS[14]);
                polygon0.Add(m_cVertexS[15]);
                m_cPolygonS.Add(polygon0);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private static void InitBeziers()
        {
            try
            {
                // Beziers
                CBezier bezier0 = new CBezier();
                bezier0.Add(m_cVertexS[0]);
                bezier0.Add(m_cVertexS[2]);
                bezier0.Add(m_cVertexS[3]);
                bezier0.Add(m_cVertexS[1]);
                m_cBezierS.Add(bezier0);

                CBezier bezier1 = new CBezier();
                bezier1.Add(m_cVertexS[8]);
                bezier1.Add(m_cVertexS[9]);
                bezier1.Add(m_cVertexS[10]);
                bezier1.Add(m_cVertexS[11]);
                m_cBezierS.Add(bezier1);

                CBezier bezier2 = new CBezier();
                bezier2.Add(m_cVertexS[16]);
                bezier2.Add(m_cVertexS[17]);
                bezier2.Add(m_cVertexS[18]);
                bezier2.Add(m_cVertexS[19]);
                m_cBezierS.Add(bezier2);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
