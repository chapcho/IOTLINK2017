using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7LocalMem
    {
        #region Member Variables

        protected CContactS m_cTotalContactS = null;
        protected CCoilS m_cTotalCoilS = null;
        protected List<int> m_lLastContactS = null;
        protected List<int> m_lLastCoilS = null;

        #endregion

        #region Initialize/Dispose

        public CS7LocalMem()
        {
            m_cTotalCoilS = new CCoilS();
            m_cTotalContactS = new CContactS();
            m_lLastCoilS = new List<int>();
            m_lLastContactS = new List<int>();
        }

        #endregion

        #region Public Properties

        public CContactS TotalContactS
        {
            get { return m_cTotalContactS; }
            set { m_cTotalContactS = value; }
        }

        public CCoilS TotalCoilS
        {
            get { return m_cTotalCoilS; }
            set { m_cTotalCoilS = value; }
        }

        public List<int> LastContactS
        {
            get { return m_lLastContactS; }
            set { m_lLastContactS = value; }
        }

        public List<int> LastCoilS
        {
            get { return m_lLastCoilS; }
            set { m_lLastCoilS = value; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
