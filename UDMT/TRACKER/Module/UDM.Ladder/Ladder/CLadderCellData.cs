using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public class CLadderCellData : CLadderCell
    {
        #region Private Members

        private object m_oData = null;
        private List<CLadderCellConnector> m_listConnector = null;

        #endregion

        #region Public Methods

        public CLadderCellData() {  }
        public CLadderCellData(int r, int c, object o) 
            : base (r, c)
        { 
            m_oData = o; 
        }
        
        #endregion

        #region Public Properties

        public object Data { get { return m_oData; } }
        public List<CLadderCellConnector> Connectors { get { return m_listConnector; } set { m_listConnector = value; } }

        #endregion
    }
}
