using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;

namespace UDM.Ladder
{
    public class CText : ICanvasItemEntity
    {
        #region Private Members

        private string m_sText = "";
        private int m_nX = 0;
        private int m_nY = 0;
        private float m_scaleWidth = 1;
        private float m_scaleHeight = 1;
        private Font m_font = new Font("Arial", 10, FontStyle.Regular);
        
        #endregion

        #region Public Methods

        public CText() {  }

        #endregion

        #region Public Properties
        
        public string Text { get { return m_sText; } set { m_sText = value; } }
        public int X { get { return m_nX; } set { m_nX = value; } }
        public int Y { get { return m_nY; } set { m_nY = value; } }
        public float ScaleWidth { get { return m_scaleWidth; } set { m_scaleWidth = value; } }
        public float ScaleHeight { get { return m_scaleHeight; } set { m_scaleHeight = value; } }
        public Font Font { get { return m_font; } set { m_font = value; } }
        public CVertexS ToVertexS() { return null; }

        #endregion
    }
}
