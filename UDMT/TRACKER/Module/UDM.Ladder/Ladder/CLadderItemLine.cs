using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI
{
    class CLadderItemLine : CLadderItem
    {
        #region Protected Methods

        protected override void Vertexes() 
        {
            m_cVertexS.Add(new CVertex(-50, 0)); // 0
            m_cVertexS.Add(new CVertex(50, 0)); // 1
        }

        protected override void Edges() 
        {
            m_cEdgeS.Add(new CEdge(m_cVertexS[0], m_cVertexS[1]));
        }

        protected override void Polygons() 
        {
 
        }

        protected override void DrawAdditional(Graphics graphics, Point point)
        {
            
        }

        protected override void DisposeAdditional()
        {

        }

        #endregion

        #region Public Methods

        public CLadderItemLine()
        {

        }

        #endregion
    }
}
