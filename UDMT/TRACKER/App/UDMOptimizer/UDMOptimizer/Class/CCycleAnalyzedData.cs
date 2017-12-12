using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CCycleAnalyzedData
    {
        #region Member Veriables

        private TimeSpan m_tsAverage = TimeSpan.MinValue;
        private TimeSpan m_tsMinCycle = TimeSpan.MinValue;
        private TimeSpan m_tsMaxCycle = TimeSpan.MinValue;
        private int m_iCycleOverCount = 0;
        private bool m_bPatternFail = false;
        private List<string> m_lstPatternFailKey = new List<string>();

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public TimeSpan Average
        {
            get { return m_tsAverage; }
            set { m_tsAverage = value; }
        }

        public TimeSpan MinCycle
        {
            get { return m_tsMinCycle; }
            set { m_tsMinCycle = value; }
        }

        public TimeSpan MaxCycle
        {
            get { return m_tsMaxCycle; }
            set { m_tsMaxCycle = value; }
        }

        public int OverCount
        {
            get { return m_iCycleOverCount; }
            set { m_iCycleOverCount = value; }

        }

        public bool IsPatternFail
        {
            get { return m_bPatternFail; }
            set { m_bPatternFail = value; }
        }

        public List<string> PatternFailKeyList
        {
            get { return m_lstPatternFailKey; }
            set { m_lstPatternFailKey = value; }
        }

        #endregion


        #region Public Method

        #endregion
    }
}
