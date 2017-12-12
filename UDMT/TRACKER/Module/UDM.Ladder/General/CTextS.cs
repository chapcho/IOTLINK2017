using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CTextS : HashSet<CText>
    {
        #region Public Methods

        public CTextS() { }

        public CText GetPolygon(int index)
        {
            int i = -1;
            foreach (CText text in this)
            {
                i++;
                if (i == index) { return text; }
            }
            return null;
        }
        #endregion
    }
}
