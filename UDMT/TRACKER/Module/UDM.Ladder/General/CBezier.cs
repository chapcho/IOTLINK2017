using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CBezier : CVertexS, ICanvasItemEntity
    {
        #region Public Methods

        public CBezier() {  }
        public CBezier(CVertexS cVertexS) : base(cVertexS) { }
        public CVertexS ToVertexS() { return this; }
        #endregion
    }
}
