using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CStd
    {
        private string m_sCurrent = string.Empty;
        private string m_sTarget = string.Empty;
        private string m_sDescription = string.Empty;


        /// <summary>
        /// Key
        /// </summary>
        public string CurrentName
        {
            get { return m_sCurrent;}
            set { m_sCurrent = value; }
        }

        public string TargetName
        {
            get { return m_sTarget; }
            set { m_sTarget = value; }
        }

        public string Description
        {
            get { return m_sDescription;}
            set { m_sDescription = value; }
        }

    }
}
