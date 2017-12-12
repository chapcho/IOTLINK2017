using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMPLCLogicAnalyzer
{
    [Serializable]
    public class CAnalyzeData
    {
        #region Member Variables

        private CDoubleCoilDataS m_cFirstDoubleCoilData = new CDoubleCoilDataS();
        private CDoubleCoilDataS m_cSecondDoubleCoilData = new CDoubleCoilDataS();
        private List<CCompareTag> m_lstCompareTag = new List<CCompareTag>();
        private List<string> m_lstLogicAnalysisResult = new List<string>();

        #endregion


        #region Properties

        public CDoubleCoilDataS FirstDoubleCoilDataS
        {
            get { return m_cFirstDoubleCoilData; }
            set { m_cFirstDoubleCoilData = value; }
        }

        public CDoubleCoilDataS SecondDoubleCoilDataS
        {
            get { return m_cSecondDoubleCoilData; }
            set { m_cSecondDoubleCoilData = value; }
        }

        public List<CCompareTag> CompareTagList
        {
            get { return m_lstCompareTag; }
            set { m_lstCompareTag = value; }
        }

        public List<string> LogicAnalysisResultList
        {
            get { return m_lstLogicAnalysisResult; }
            set { m_lstLogicAnalysisResult = value; }
        }

        #endregion


        #region Public Method

        #endregion
    }
}
