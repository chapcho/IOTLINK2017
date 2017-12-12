using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.General.Statistics;

namespace UDM.Flow
{
    [Serializable]
    /// <summary>
    /// Key == Order
    /// </summary>
    public class CMasterSequenceUnit
    {
        private int m_iOrder = -1;
        private string m_sTagKey = string.Empty;
        private int m_iActiveCount = 0;
        private int m_iFirstValue = -1;
        private int m_iLogCount = 0;
        private List<double> m_lstDuration = new List<double>();
        private CMasterSequenceBlock m_cSubMasterSequenceBlock = new CMasterSequenceBlock(); 


        #region Public Properties

        public CMasterSequenceBlock SubMasterSequenceBlock
        {
            get { return m_cSubMasterSequenceBlock; }
            set { m_cSubMasterSequenceBlock = value; }
        }

        public int Order
        {
            get { return m_iOrder;}
            set { m_iOrder = value; }
        }

        public string TagKey
        {
            get { return m_sTagKey; }
            set { m_sTagKey = value; }
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
