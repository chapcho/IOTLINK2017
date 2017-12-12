using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMOptimizer
{
    [Serializable]
    public class CAnalyzeProc : TrackerProject.CPlcProc
    {
        private CTagS m_cProcessTagS = new CTagS();
        private List<string> m_lstProcessTotalTagKey = new List<string>();

        public CTagS ProcessTagS
        {
            get { return m_cProcessTagS; }
            set { m_cProcessTagS = value; }
        }

        public List<string> ProcessTotalTagKey
        {
            get { return m_lstProcessTotalTagKey; }
            set { m_lstProcessTotalTagKey = value; }
        }
    }
}
