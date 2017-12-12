using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDMPLCLogicAnalyzer
{
    [Serializable]
    public class CBaseData
    {
        #region Member Variables

        private string m_sProjectID = "00000000";
        private string m_sProjectPath = Application.StartupPath;
        private List<string> m_lstPLCID = new List<string>();

        #endregion


        #region Properties

        public string ProjectPath
        {
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
        }

        public List<string> PLCIDList
        {
            get { return m_lstPLCID; }
            set { m_lstPLCID = value; }
        }

        public string ProjectID
        {
            get { return m_sProjectID; }
            set { m_sProjectID = value; }
        }

        #endregion
    }
}
