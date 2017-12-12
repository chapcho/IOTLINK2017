using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CEdge : ICanvasItemEntity
    {
        #region Private Members
        
        private CVertex m_nVertex1 = null;
        private CVertex m_nVertex2 = null;
        
        #endregion

        #region Public Methods

        public CEdge() {  }
        public CEdge(CVertex v1, CVertex v2) { m_nVertex1 = v1; m_nVertex2 = v2; }

        #endregion

        #region Public Properties

        public CVertex V1 { get { return m_nVertex1; } set { m_nVertex1 = value; } }
        public CVertex V2 { get { return m_nVertex2; } set { m_nVertex2 = value; } }
        
        public CVertexS ToVertexS() 
        { 
            CVertexS cVertexS = new CVertexS();
            cVertexS.Add(m_nVertex1);
            cVertexS.Add(m_nVertex2);
            return cVertexS;
        }

        #endregion
    }
}
