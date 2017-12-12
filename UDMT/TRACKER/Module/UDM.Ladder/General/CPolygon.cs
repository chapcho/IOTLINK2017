using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CPolygon : CVertexS, ICanvasItemEntity
    {
        public CPolygon() {  }
        public CPolygon(CVertexS cVertexS) : base(cVertexS) { }
        public CVertexS ToVertexS() { return this; }
    }
}
