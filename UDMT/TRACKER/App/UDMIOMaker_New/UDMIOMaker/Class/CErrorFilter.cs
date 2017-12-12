using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMIOMaker
{
    [Serializable]
    public class CErrorFilter
    {
        private string m_sSheetName = string.Empty;
        private List<string> m_lstErrorFilter = new List<string>();
        private List<string> m_lstErrorFIlterNotContain = new List<string>(); 


        public string SheetName
        {
            get { return m_sSheetName;}
            set { m_sSheetName = value; }
        }

        public List<string> ErrorNotContainFilter
        {
            get { return m_lstErrorFIlterNotContain;}
            set { m_lstErrorFIlterNotContain = value; }
        }

        public List<string> ErrorFilter
        {
            get { return m_lstErrorFilter;}
            set { m_lstErrorFilter = value; }
        }
    }
}
