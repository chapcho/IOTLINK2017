using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class MELSECCoilEmpty
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
        public static int ColumnOccupied { get { return 1; } }

        static MELSECCoilEmpty()
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
            m_cVertexS.Add(new CVertex(-50,0)); // 0
            m_cVertexS.Add(new CVertex(50,0)); // 1
        }

        private static void InitEdges()
        {
            try
            {
                m_cEdgeS.Add(new CEdge(m_cVertexS[0],m_cVertexS[1])); //0
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

            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
