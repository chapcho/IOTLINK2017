using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDMOptimizer
{
    public class CRTtestResult : IRTtestResult
    {
        #region Member Variables

        //평균
        private float[] m_nGroupM = { 0f, 0f };
        //표준편차
        private float[] m_nGroupSD = { 0f, 0f };
        //표준오차
        private float[] m_nGroupSE = { 0f, 0f };
        //자유도
        private float m_nDF = 0f;
        //T값
        private float m_nTValue = 0f;
        //P값
        private float m_nPValue = 0f;

        #endregion

        #region Intialize/Dispose
        public CRTtestResult()
        {

        }

        #endregion


        #region Public Properties

        public float[] GroupM
        {
            get { return m_nGroupM; }
            set { m_nGroupM = value; }
        }

        public float[] GroupSD
        {
            get { return m_nGroupSD; }
            set { m_nGroupSD = value; }
        }

        public float[] GroupSE
        {
            get { return m_nGroupSE; }
            set { m_nGroupSE = value; }
        }

        public float DF
        {
            get { return m_nDF; }
            set { m_nDF = value; }
        }

        public float TValue
        {
            get { return m_nTValue; }
            set { m_nTValue = value; }
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
            CRTtestResult cResult = new CRTtestResult();
            cResult.GroupM = m_nGroupM;
            cResult.GroupSD = m_nGroupSD;
            cResult.GroupSE = m_nGroupSE;
            cResult.DF = m_nDF;
            cResult.TValue = m_nTValue;
            cResult.PValue = m_nPValue;

            return cResult;
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
