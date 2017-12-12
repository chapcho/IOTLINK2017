using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CLadderCellConnector : CLadderCell
    {
        #region Private Members

        private List<CLadderCell> m_listCellConnected = null;
        private bool m_bFull = false;

        #endregion

        #region Public Methods

        public CLadderCellConnector() {  }
        public CLadderCellConnector(int r, int c) : base(r, c) {  }
        
        #endregion

        #region Public Properties

        public List<CLadderCell> CellConnected { get { return m_listCellConnected; } set { m_listCellConnected = value; } }
        public bool Full { get { return m_bFull; } set { m_bFull = value; } }

        #endregion
    }
}
