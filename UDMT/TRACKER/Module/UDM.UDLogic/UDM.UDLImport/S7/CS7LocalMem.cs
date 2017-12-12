using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDLImport
{
    public class CS7LocalMem
    {
        protected string m_sLocalName = string.Empty;
        protected string m_sSubLogic = string.Empty;
        protected List<string> m_lstNextLogic = null;
        protected bool m_bIsUsed = false;

        #region Intialize/Dispose

        public CS7LocalMem(string localName)
        {
            m_sLocalName = localName;
            m_lstNextLogic = new List<string>();
        }

        public CS7LocalMem(string localName, string subLogic)
        {
            m_sLocalName = localName;
            m_sSubLogic = subLogic;
            m_lstNextLogic = new List<string>();
        }

        #endregion

        #region Public Properties

        public string LocalName
        {
            get { return m_sLocalName; }
            set { m_sLocalName = value; }
        }

        public string SubLogic
        {
            get { return m_sSubLogic; }
            set { m_sSubLogic = value; }
        }

        public List<string> NextLogic
        {
            get { return m_lstNextLogic; }
            set { m_lstNextLogic = value; }
        }

        public bool IsUsed
        {
            get { return m_bIsUsed; }
            set { m_bIsUsed = value; }
        }

        #endregion
    }
}
