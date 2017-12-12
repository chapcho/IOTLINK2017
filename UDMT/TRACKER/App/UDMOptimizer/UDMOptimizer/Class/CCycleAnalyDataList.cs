using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMOptimizer
{
    public class CCycleAnalyDataList : List<CCycleAnalyData>
    {
        private CCycleAnalyzedData m_cCycleAnalyzedData = new CCycleAnalyzedData();

        public CCycleAnalyzedData CycleAnalyzedData
        {
            get { return m_cCycleAnalyzedData; }
            set { m_cCycleAnalyzedData = value; }
        }
    }
}
