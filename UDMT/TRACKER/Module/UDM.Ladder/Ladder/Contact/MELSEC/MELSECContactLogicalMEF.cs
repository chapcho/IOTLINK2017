using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class MELSECContactLogicalMEF
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

        static MELSECContactLogicalMEF()
        {
            InitVertexes();
            InitEdges();
            InitPolygons();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
            m_hashExcludedPolygons.Add(0);
        }

        private static void InitVertexes()
        {
            m_cVertexS.Add(new CVertex(-50,0)); // 0
            m_cVertexS.Add(new CVertex(50,0)); // 1
            m_cVertexS.Add(new CVertex(0,20)); // 2
            m_cVertexS.Add(new CVertex(0,-20)); // 3
            m_cVertexS.Add(new CVertex(10,5)); // 4
            m_cVertexS.Add(new CVertex(-10,5)); // 5
        }

        private static void InitEdges()
        {
            try
            {
                m_cEdgeS.Add(new CEdge(m_cVertexS[5],m_cVertexS[2])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[2],m_cVertexS[4])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[0],m_cVertexS[1])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[2],m_cVertexS[3])); //3
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
    }
}
