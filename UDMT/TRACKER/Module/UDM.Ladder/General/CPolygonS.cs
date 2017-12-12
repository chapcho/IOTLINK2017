using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CPolygonS : HashSet<CPolygon>
    {
        #region Public Methods

        public CPolygonS() { }
        
        public CPolygon GetPolygon(int index)
        {
            int i = -1;
            foreach (CPolygon polygon in this)
            {
                i++;
                if (i == index) { return polygon; }
            }
            return null;
        }
        #endregion
    }
}
