using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using UDM.Common;

namespace UDM.Ladder
{
    public static class CMisc
    {
        public static CVertexS BoundingBox(CVertexS cVertexS)
        {
            int xMax, xMin, yMax, yMin;
            xMax = xMin = yMax = yMin = 0;

            // Edges
            foreach (CVertex v in cVertexS)
            {
                xMin = v.X < xMin ? v.X : xMin;
                xMax = v.X > xMax ? v.X : xMax;
                yMin = v.Y < yMin ? v.Y : yMin;
                yMax = v.Y > yMax ? v.Y : yMax;
            }

            CVertexS cNewVertexS = new CVertexS();
            cNewVertexS.Add(new CVertex(xMin, yMin));
            cNewVertexS.Add(new CVertex(xMax, yMin));
            cNewVertexS.Add(new CVertex(xMax, yMax));
            cNewVertexS.Add(new CVertex(xMin, yMax));

            return cNewVertexS;
        }
    }
}
