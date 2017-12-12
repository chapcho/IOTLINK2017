using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using UDM.Common;

namespace UDM.Ladder
{
    public class CValidatorMultiple
    {
        private List<CValidatorSingle> m_listValidatorSingleS = new List<CValidatorSingle>();
        private List<int> m_listProblemStepS = new List<int>();

        public List<CValidatorSingle> ResultData { get { return m_listValidatorSingleS; } }
        public List<int> IndexProblemStep { get { return m_listProblemStepS; } }

        public CValidatorMultiple(CStepS cStepS)
        {
            Validate(cStepS);
        }

        private void Validate (CStepS cStepS)
        {
            m_listValidatorSingleS.Clear();
            m_listProblemStepS.Clear();
            foreach (CStep cStep in cStepS.Values)
            {
                CValidatorSingle cValidatorSingle = new CValidatorSingle(cStep);
                m_listValidatorSingleS.Add(cValidatorSingle);
                if (cValidatorSingle.IsProblem) { m_listProblemStepS.Add(m_listValidatorSingleS.Count-1); }
            }
        }
    }
}
