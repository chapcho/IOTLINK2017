using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CVertex
    {
        #region Privbte Members

        private int m_nX = 0;
        private int m_nY = 0;

        #endregion

        #region Public Methods 

        public CVertex() {  }
        public CVertex(int x, int y) { m_nX = x; m_nY = y; }

        #endregion
        
        #region Public Properties
        
        public int X { get { return m_nX; } set { m_nX = value; } }
        public int Y { get { return m_nY; } set { m_nY = value; } }

        #endregion
    }
}
