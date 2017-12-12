using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDMProfiler
{
    [Serializable]
    public class CProjectBase
    {
        private string m_sProjectName = string.Empty;
        private string m_sProjectID = string.Empty;
        private string m_sProjectPath = string.Empty;
        private string m_sLogFilePath = string.Empty;
        private List<string> m_lstPlcID = new List<string>(); 

        #region Initialize/Dispose

        #endregion

        #region Properties

        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }

        public string ProjectID
        {
            get { return m_sProjectID;}
            set { m_sProjectID = value; }
        }

        public string LogFilePath
        {
            get { return m_sLogFilePath;}
            set { m_sLogFilePath = value; }
        }

        public string ProjectPath
        {
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
        }

        public List<string> PlcIDList
        {
            get { return m_lstPlcID; }
            set { m_lstPlcID = value; }
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            m_lstPlcID.Clear();
        }

        #endregion

        #region Private Methods

        #endregion

    }
}

