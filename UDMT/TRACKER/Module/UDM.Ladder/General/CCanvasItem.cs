using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public abstract class CCanvasItem
    {
        protected CVertex m_cVertexOrigin = new CVertex();
        protected CVertexS m_cVertexSBoundingBoxes = new CVertexS();

        public int X { get { return m_cVertexOrigin.X; } set { UpdateOriginX(value); m_cVertexOrigin.X = value; } }
        public int Y { get { return m_cVertexOrigin.Y; } set { UpdateOriginY(value); m_cVertexOrigin.Y = value; } }
        public CVertex Origin 
        { 
            set 
            { 
                CVertex v = value as CVertex;
                UpdateOriginXY(v.X, v.Y);
                m_cVertexOrigin = value;
            }
        }

        public CVertexS BoundingBoxes { get { return CalculateBoundingBoxes(); } }

        public virtual void Draw(Graphics graphics) { }
        public virtual void OnClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k) { } // WCS
        public virtual void OnRClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k) { } // WCS

        public virtual void OnRDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k) { } // WCS
        public virtual void OnDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k) { } // WCS

        private void UpdateOriginX(int xNew)
        {
            foreach(CVertex cVertex in m_cVertexSBoundingBoxes)
            {
                cVertex.X = cVertex.X - m_cVertexOrigin.X + xNew;
            }
        }

        private void UpdateOriginY(int yNew)
        {
            foreach (CVertex cVertex in m_cVertexSBoundingBoxes)
            {
                cVertex.Y = cVertex.Y - m_cVertexOrigin.Y + yNew;
            }
        }

        private void UpdateOriginXY(int xNew, int yNew)
        {
            foreach (CVertex cVertex in m_cVertexSBoundingBoxes)
            {
                cVertex.X = cVertex.X - m_cVertexOrigin.X + xNew;
                cVertex.Y = cVertex.Y - m_cVertexOrigin.Y + yNew;
            }
        }

        protected virtual CVertexS CalculateBoundingBoxes()
        {
            return m_cVertexSBoundingBoxes;
        }
    }
}
