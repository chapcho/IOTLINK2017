using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.General.Statistics;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CCyclePresentUnit : IDisposable
    {

        #region Member Variables

        private string m_sRecipe = "";
        private int m_iActiveCount = 0;
        private int m_iFirstValue = -1;
        private int m_iLogCount = 0;
        private List<double> m_lstDuration = new List<double>(); 

        #endregion


        #region Initialize/Dispose

        public CCyclePresentUnit(string sRecipe, int iActiveCount)
        {
            m_sRecipe = sRecipe;
            m_iActiveCount = iActiveCount;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Recipe
        {
            get { return m_sRecipe; }
            set { m_sRecipe = value; }
        }

        public List<double> DurationS
        {
            get { return m_lstDuration; }
            set { m_lstDuration = value; }
        }

        public double LowerDuration
        {
            get { return GetLowerDuration(); }
        }

        public double UpperDuration
        {
            get { return GetUpperDuration(); }
        }

        public double MeanDuration
        {
            get { return GetMeanDuration(); }
        }

        public int FirstValue
        {
            get { return m_iFirstValue; }
            set { m_iFirstValue = value; }
        }

        public int ActiveCount
        {
            get { return m_iActiveCount; }
            set { m_iActiveCount = value; }
        }

        public int LogCount
        {
            get { return m_iLogCount; }
            set { m_iLogCount = value; }
        }

        #endregion


        #region Public Methods

        public bool IsSameUnit(CCyclePresentUnit cCurUnit)
        {
            bool bOK = true;

            if (this.LogCount != cCurUnit.LogCount || this.FirstValue != cCurUnit.FirstValue
                || this.ActiveCount != cCurUnit.ActiveCount)
                bOK = false;

            return bOK;
        }


        #endregion


        #region Private Methods

        private double GetLowerDuration()
        {
            double dLower = -1;

            if (m_lstDuration.Count == 0)
                return 0;
            else
                dLower = m_lstDuration.Min();

            return dLower;
        }

        private double GetUpperDuration()
        {
            double dUpper = -1;

            if (m_lstDuration.Count == 0)
                return 0;
            else
                dUpper = m_lstDuration.Max();

            return dUpper;
        }

        private double GetMeanDuration()
        {
            double dMean = -1;

            if (m_lstDuration.Count == 0)
                return 0;
            else
                dMean = CStatics.Mean(m_lstDuration);

            return dMean;
        }


        #endregion
    }
}
