using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CRLeveneResult : IRLeveneResult
    {

        #region Member Variables

        private float m_nStatistic = 0f;
        private float m_nPValue = 0f;

        #endregion

        #region Intialize/Dispose
        public CRLeveneResult()
        {

        }
        #endregion

        #region Public Properties

        public float Statistic
        {
            get { return m_nStatistic; }
            set { m_nStatistic = value; }
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
            CRLeveneResult cResult = new CRLeveneResult();
            cResult.Statistic = m_nStatistic;
            cResult.PValue = m_nPValue;

            return cResult;
        }
        #endregion
            
        #region Private Methods
        #endregion
    }
}
