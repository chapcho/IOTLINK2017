using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CLadderCell
    {
        #region Private Members

        protected int m_nRowOccupied = 1;
        protected int m_nColOccupied = 1;
        protected int m_nRow = 0;
        protected int m_nCol = 0;
        protected int m_nRowRelative = 0;
        protected int m_nColRelative = 0;
        protected bool m_bSelectable = true;
        protected bool m_bDrawable = true;
        protected CEdgeS m_cEdgesS = null;

        #endregion

        #region Public Methods

        public CLadderCell() {  }
        public CLadderCell(int r, int c) { m_nRow = r; m_nCol = c; }
        
        public void AddLine(int x1, int y1, int x2, int y2)
        {
            if (m_cEdgesS == null) { m_cEdgesS = new CEdgeS(); }
            m_cEdgesS.Add(new CEdge(new CVertex(x1, y1), new CVertex(x2, y2)));
        }

        public void ClearLines()
        {
            m_cEdgesS = null;
        }

        #endregion

        #region Public Properties

        public int RowRelative { get { return m_nRowRelative; } set { m_nRowRelative = value; } }
        public int ColumnRelative { get { return m_nColRelative; } set { m_nColRelative = value; } }
        public int Row { get { return m_nRow; } set { m_nRow = value; } }
        public int Column { get { return m_nCol; } set { m_nCol = value; } }
        public int RowOccupied { get { return m_nRowOccupied; } set { m_nRowOccupied = value; } }
        public int ColumnOccupied { get { return m_nColOccupied; } set { m_nColOccupied = value; } }
        public bool Selectable { get { return m_bSelectable; } set { m_bSelectable = value; } }
        public bool Drawable { get { return m_bDrawable; } set { m_bDrawable = value; } }
        public CEdgeS Lines { get { return m_cEdgesS; } }

        #endregion
    }
}
