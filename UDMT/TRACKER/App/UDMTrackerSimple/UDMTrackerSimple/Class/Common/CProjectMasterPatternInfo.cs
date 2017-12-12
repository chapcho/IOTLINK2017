using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Flow;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CProjectMasterPatternInfo
    {
        private int m_iUpdateCount = 10;
        private bool m_bAutoUpdateRecipe = true;
        private string m_sProjectName = string.Empty;
        private string m_sProjectID = "00000000";
        private CMasterPatternS m_cMasterPatternS = null;

        public bool IsAutoUpdateRecipe
        {
            get { return m_bAutoUpdateRecipe;}
            set { m_bAutoUpdateRecipe = value; }
        }

        public int RecipeUpdateCount
        {
            get { return m_iUpdateCount; }
            set { m_iUpdateCount = value; }
        }

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

        public CMasterPatternS MasterPatternS
        {
            get { return m_cMasterPatternS; }
            set { m_cMasterPatternS = value; }
        }

        public void Clear()
        {
            if (m_cMasterPatternS != null)
                m_cMasterPatternS.Clear();

            m_sProjectName = string.Empty;
            m_sProjectID = string.Empty;
            m_iUpdateCount = 10;
            m_bAutoUpdateRecipe = true;
        }

    }
}
