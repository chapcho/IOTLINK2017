using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using UDM.Common;

namespace UDM.Ladder
{
    public class CValidatorSingle
    {
        private CStep m_cStep = null;
        private DataTable m_dtTableValidation = new DataTable();
        private int m_nData = 0;
        private int m_nNotMatch = 0;
        private int m_nNotAvailable = 0;

        public CStep Step { get { return m_cStep; } }
        public DataTable ResultData { get { return m_dtTableValidation; } }
        public int NoData { get { return m_nData; } }
        public int NotMatch { get { return m_nNotMatch; } }
        public int NotAvailable { get { return m_nNotAvailable; } }
        public int NoMatch { get { return m_nData - m_nNotMatch - m_nNotAvailable; } }
        public bool IsProblem { get { return NoData != NoMatch; } }

        public CValidatorSingle(CStep cStep)
        {
            Initialize();
            m_cStep = cStep;
            Validate(m_cStep);
        }

        private void Initialize()
        {
            m_dtTableValidation.Columns.Add("ContactClass", typeof(CContact));
            m_dtTableValidation.Columns.Add("ContactName", typeof(string));
            m_dtTableValidation.Columns.Add("ContactX", typeof(int));
            m_dtTableValidation.Columns.Add("ContactY", typeof(int));

            m_dtTableValidation.Columns.Add("CellClass", typeof(CLadderCell));
            m_dtTableValidation.Columns.Add("CellName", typeof(string));
            m_dtTableValidation.Columns.Add("CellRow", typeof(int));
            m_dtTableValidation.Columns.Add("CellColumn", typeof(int));

            m_dtTableValidation.Columns.Add("Status", typeof(string));

            m_dtTableValidation.Clear();
        }

        private void Validate (CStep cStep)
        {
           
        }
    }
}
