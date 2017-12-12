using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CBezierS : HashSet<CBezier>
    {
        #region Public Methods

        public CBezierS() { }
        
        public CBezier GetBezier(int index)
        {
            int i = -1;
            foreach (CBezier bezier in this)
            {
                i++;
                if (i == index) { return bezier; }
            }
            return null;
        }
        #endregion
    }
}
