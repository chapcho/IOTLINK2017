using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CRAnovaResult : IRAnovaResult
    {

        #region Member Variables

        private float m_nGroupDF = 0f;
        private float m_nErrorDF = 0f;
        private float m_nGroupSS = 0f;
        private float m_nErrorSS = 0f;
        private float m_nGroupMS = 0f;
        private float m_nErrorMS = 0f;
        private float m_nFValue = 0f;
        private float m_nPValue = 0f;

        #endregion


        #region Intialize/Dispose

        public CRAnovaResult()
        {

        }

        #endregion


        #region Public Properties

        public float GroupDF
        {
            get { return m_nGroupDF; }
            set { m_nGroupDF = value; }
        }

        public float GroupSS
        {
            get { return m_nGroupSS; }
            set { m_nGroupSS = value; }
        }

        public float GroupMS
        {
            get { return m_nGroupMS; }
            set { m_nGroupMS = value; }
        }

        public float ErrorDF
        {
            get { return m_nErrorDF; }
            set { m_nErrorDF = value; }
        }

        public float ErrorSS
        {
            get { return m_nErrorSS; }
            set { m_nErrorSS = value; }
        }

        public float ErrorMS
        {
            get { return m_nErrorMS; }
            set { m_nErrorMS = value; }
        }

        public float FValue
        {
            get { return m_nFValue; }
            set { m_nFValue = value; }
        }

        public float PValue
        {
            get { return m_nPValue; }
            set { m_nPValue = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CRAnovaResult cResult = new CRAnovaResult();
            cResult.GroupDF = m_nGroupDF;
            cResult.GroupSS = m_nGroupSS;
            cResult.GroupMS = m_nGroupMS;
            cResult.ErrorDF = m_nErrorDF;
            cResult.ErrorSS = m_nErrorSS;
            cResult.ErrorMS = m_nErrorMS;
            cResult.FValue = m_nFValue;
            cResult.PValue = m_nPValue;

            return cResult;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
