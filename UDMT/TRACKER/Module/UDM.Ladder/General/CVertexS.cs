using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public delegate void DelegateVertexIteration(CVertex cVertex);

    public class CVertexS : List<CVertex>
    {
        #region Public Methods 

        public CVertexS() {  }
        public CVertexS(List<CVertex> list) : base(list) { }

        #endregion
        
        #region Public Properties

        public Point[] ConvertToPointArray()
        {
            Point[] arrayPoint = new Point[this.Count];
            int i = 0;
            foreach (CVertex vertex in this)
            {
                arrayPoint[i++] = new Point(vertex.X, vertex.Y);
            }
            return arrayPoint;
        }

        public void OffsetAllPointsPermanent(CVertex v)
        {
            OffsetAllPointsPermanent(v.X, v.Y);
        }
        
        public void OffsetAllPointsPermanent(int x, int y)
        {
            foreach (CVertex vertex in this)
            {
                vertex.X += x;
                vertex.Y += y;
            }
        }

        public void OffsetAllPointsTemporary(CVertex v)
        {
            OffsetAllPointsTemporary(v.X, v.Y);
        }

        public CVertexS OffsetAllPointsTemporary(int x, int y)
        {
            CVertexS cVertexS = new CVertexS();
            foreach (CVertex vertex in this)
            {
                cVertexS.Add(new CVertex(vertex.X + x, vertex.Y + y));
            }

            return cVertexS;
        }

        public CVertex IsPointInList(int x, int y)
        {
            foreach (CVertex v in this)
            {
                if ((v.X == x) && (v.Y == y)) { return v; }
            }

            return null;
        }

        public void DoThisToEveryVertex(DelegateVertexIteration delegateVertexIteration)
        {
            foreach (CVertex cVertex in this)
            {
                delegateVertexIteration(cVertex);
            }
        }

        #endregion
    }
}
