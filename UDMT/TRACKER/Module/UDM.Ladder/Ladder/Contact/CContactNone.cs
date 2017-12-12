using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Ladder
{
    public static class CContactNone
    {
        static private CVertexS m_cVertexS = new CVertexS();
        static private CEdgeS m_cEdgeS = new CEdgeS();
        static private CVertexS m_cBoundingBoxeS = new CVertexS();

        public static CVertexS Vertexs { get { return m_cVertexS; } }
        public static CEdgeS Edges { get { return m_cEdgeS; } }
        public static CVertexS BoundingBoxes { get { return m_cBoundingBoxeS; } }
        public static int ColumnOccupied { get { return 1; } }

        static CContactNone()
        {
            InitVertexes();
            InitEdges();
            m_cBoundingBoxeS = CMisc.BoundingBox(m_cVertexS);
        }

        private static void InitVertexes()
        {
            // Vertexes
            m_cVertexS.Add(new CVertex(15, 0)); // 0
            m_cVertexS.Add(new CVertex(50, 0)); // 1
            m_cVertexS.Add(new CVertex(-15, 0)); // 2
            m_cVertexS.Add(new CVertex(-50, 0)); // 3
            m_cVertexS.Add(new CVertex(-13, -5)); // 4
            m_cVertexS.Add(new CVertex(-13, 5)); // 5
            m_cVertexS.Add(new CVertex(-9, 5)); // 6
            m_cVertexS.Add(new CVertex(-9, -5)); // 7
            m_cVertexS.Add(new CVertex(-7, 5)); // 8
            m_cVertexS.Add(new CVertex(-7, -5)); // 9
            m_cVertexS.Add(new CVertex(-3, -5)); // 10
            m_cVertexS.Add(new CVertex(-3, 5)); // 11
            m_cVertexS.Add(new CVertex(-1, 5)); // 12
            m_cVertexS.Add(new CVertex(-1, -5)); // 13
            m_cVertexS.Add(new CVertex(4, -5)); // 14
            m_cVertexS.Add(new CVertex(4, 5)); // 15
            m_cVertexS.Add(new CVertex(6, -5)); // 16
            m_cVertexS.Add(new CVertex(6, 5)); // 17
            m_cVertexS.Add(new CVertex(13, 5)); // 18
            m_cVertexS.Add(new CVertex(13, 0)); // 19
            m_cVertexS.Add(new CVertex(6, 0)); // 20
            m_cVertexS.Add(new CVertex(12, -5)); // 21

        }

        private static void InitEdges()
        {
            try
            {
                // Edges
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[5])); //0
                m_cEdgeS.Add(new CEdge(m_cVertexS[6], m_cVertexS[7])); //1
                m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1])); //2
                m_cEdgeS.Add(new CEdge(m_cVertexS[2], m_cVertexS[3])); //3
                m_cEdgeS.Add(new CEdge(m_cVertexS[4], m_cVertexS[6])); //4
                m_cEdgeS.Add(new CEdge(m_cVertexS[8], m_cVertexS[9])); //5
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[9])); //6
                m_cEdgeS.Add(new CEdge(m_cVertexS[10], m_cVertexS[11])); //7
                m_cEdgeS.Add(new CEdge(m_cVertexS[11], m_cVertexS[8])); //8
                m_cEdgeS.Add(new CEdge(m_cVertexS[12], m_cVertexS[13])); //9
                m_cEdgeS.Add(new CEdge(m_cVertexS[14], m_cVertexS[15])); //10
                m_cEdgeS.Add(new CEdge(m_cVertexS[15], m_cVertexS[13])); //11
                m_cEdgeS.Add(new CEdge(m_cVertexS[16], m_cVertexS[17])); //12
                m_cEdgeS.Add(new CEdge(m_cVertexS[17], m_cVertexS[18])); //13
                m_cEdgeS.Add(new CEdge(m_cVertexS[19], m_cVertexS[20])); //14
                m_cEdgeS.Add(new CEdge(m_cVertexS[16], m_cVertexS[21])); //15
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }
    }
}
