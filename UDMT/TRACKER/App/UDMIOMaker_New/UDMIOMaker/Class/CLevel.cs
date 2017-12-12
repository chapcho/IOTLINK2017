using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CLevel
    {
        private string m_sCurrentParse = string.Empty;
        private string m_sTargetParse = string.Empty;
        private bool m_bStdExist = false;
        private bool m_bChange = false;

        private bool m_bViewCurrent = false;

        public bool IsCurrentView
        {
            get { return m_bViewCurrent;}
            set { m_bViewCurrent = value; }
        }

        public string CurrentParse
        {
            get { return m_sCurrentParse;}
            set { m_sCurrentParse = value; }
        }

        public string TargetParse
        {
            get { return m_sTargetParse; }
            set { m_sTargetParse = value; }
        }

        public bool IsStdExist
        {
            get { return m_bStdExist;}
            set { m_bStdExist = value; }
        }

        public bool IsChanged
        {
            get { return m_bChange;}
            set { m_bChange = value; }
        }

        public void Clear()
        {
            m_sTargetParse = string.Empty;
            m_sCurrentParse = string.Empty;
            m_bChange = false;
            m_bStdExist = false;
            m_bViewCurrent = false;
        }

        public CLevel Clone()
        {
            CLevel cLv = new CLevel();

            cLv.CurrentParse = m_sCurrentParse;
            cLv.TargetParse = m_sTargetParse;
            cLv.IsStdExist = m_bStdExist;
            cLv.IsChanged = m_bChange;
            cLv.IsCurrentView = m_bViewCurrent;

            return cLv;
        }

    }
}
