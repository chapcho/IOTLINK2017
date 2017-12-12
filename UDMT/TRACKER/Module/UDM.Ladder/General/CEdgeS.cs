using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CEdgeS : HashSet<CEdge>
    {
        #region Public Methods

        public CEdgeS() { }

        public CEdge GetEdge(int index)
        {
            int i = -1;
            foreach (CEdge edge in this)
            {
                i++;
                if (i == index) { return edge; }
            }
            return null;
        }
        #endregion
    }
}
