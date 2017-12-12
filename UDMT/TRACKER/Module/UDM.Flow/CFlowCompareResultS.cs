using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Flow
{
    public class CFlowCompareResultS : List<CFlowCompareResult>, IDisposable
    {

        #region Member Variables

        protected string m_sKey = "";
        protected CFlow m_cMasterFlow = null;
        protected CFlowItemS m_cItemS = null;

        #endregion


        #region Initialize/Dispose

        public CFlowCompareResultS()
        {

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

        public CFlow MasterFlow
        {
            get { return m_cMasterFlow; }
            set { m_cMasterFlow = value; }
        }

        public CFlowItemS FlowItemS
        {
            get { return m_cItemS; }
            set { m_cItemS = value; }
        }

        #endregion


        #region Public Methods

        public bool IsContainsKey(string sKey)
        {
            bool bOK = false;
            for(int i=0;i<this.Count;i++)
            {
                if(this[i].Key == sKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        public CFlowCompareResult GetResult(string sKey)
        {
            CFlowCompareResult cResult = null;
            for(int i=0;i<this.Count;i++)
            {
                if(this[i].Key == sKey)
                {
                    cResult = this[i];
                    break;
                }
            }

            return cResult;
        }


        #endregion


        #region Private Methdos


        #endregion
    }
}
