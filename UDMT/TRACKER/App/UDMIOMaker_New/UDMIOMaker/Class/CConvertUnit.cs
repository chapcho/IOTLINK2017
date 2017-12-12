using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CConvertUnit
    {
        private string m_sCurrent = string.Empty;
        private string m_sTarget = string.Empty;

        private string m_sConvertCurrent = string.Empty;
        private string m_sConvertTarget = string.Empty;

        public CConvertUnit(string sCurrent, string sTarget)
        {
            m_sCurrent = sCurrent;
            m_sTarget = sTarget;
        }

        public string ConvertCurrent
        {
            get { return m_sConvertCurrent;}
            set { m_sConvertCurrent = value; }
        }

        public string ConvertTarget
        {
            get { return m_sConvertTarget;}
            set { m_sConvertTarget = value; }
        }


        public string Current
        {
            get { return m_sCurrent;}
            set { m_sCurrent = value; }
        }

        public string Target
        {
            get { return m_sTarget;}
            set { m_sTarget = value; }
        }
    }
}
