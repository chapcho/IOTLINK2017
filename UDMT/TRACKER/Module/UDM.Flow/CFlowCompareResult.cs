using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Flow
{
    public class CFlowCompareResult : List<CFlowCompareResultUnit>, IDisposable
    {

        #region Member Variables

        protected string m_sKey = "";
        protected CFlowCompareResultS m_cSubResultS = null;

        #endregion


        #region Initialize/Dispose

        public CFlowCompareResult()
        {

        }

        public CFlowCompareResult(string sKey, CFlowCompareResultS cSubResultS)
        {
            m_sKey = sKey;
            m_cSubResultS = cSubResultS;
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public CFlowCompareResultS SubResultS
        {
            get { return m_cSubResultS; }
            set { m_cSubResultS = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
