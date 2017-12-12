using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMPLCLogicAnalyzer
{
    [Serializable]
    public class CDoubleCoilData
    {
        #region Member Variables

        private int m_iNumber = 0;
        private string m_sProgram = "";
        private string m_sStepNumber = "";
        private string m_sTagKey = "";
        private CTag m_cTag = null;
        private CStep m_cStep = null;

        #endregion


        #region Properties

        public int Number
        {
            get { return m_iNumber; }
            set { m_iNumber = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public string StepNumber
        {
            get { return m_sStepNumber; }
            set { m_sStepNumber = value; }
        }

        public string TagKey
        {
            get { return m_sTagKey; }
            set { m_sTagKey = value; }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public CStep Step
        {
            get { return m_cStep; }
            set { m_cStep = value; }
        }

        #endregion
    }
}
