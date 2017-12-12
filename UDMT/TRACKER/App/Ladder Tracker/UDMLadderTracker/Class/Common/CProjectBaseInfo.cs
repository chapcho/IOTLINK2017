using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;

namespace UDMLadderTracker
{
    [Serializable]
    public class CProjectBaseInfo
    {
        #region Member Variables

        private string m_sProjectName = "";
        private string m_sProrjctPath = "";
        private string m_sProjectID = "00000000";
        private CUserDeviceS m_cUserDeviceS = new CUserDeviceS();
        private Dictionary<int, CRecipeWord> m_dicRecipeWord = new Dictionary<int, CRecipeWord>();
        private CRecipeSection m_cRunViewRecipeSection = null;
        private CPlcProcS m_cPlcProcS = new CPlcProcS();
        private List<string> m_lstPlcID = new List<string>();
        private EMMonitorModeType m_emPatternItemStep = EMMonitorModeType.None;
        private EMMonitorType m_emMonitorType = EMMonitorType.FlowItem;
        private CTagS m_cRobotCycleTagS = new CTagS();
        private CMasterPatternS m_cMasterPatternS = null;

        #endregion

        #region Properties


        public CMasterPatternS MasterPatternS
        {
            get { return m_cMasterPatternS;}
            set { m_cMasterPatternS = value; }
        }

        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }

        public string ProjectID
        {
            get { return m_sProjectID; }
            set { m_sProjectID = value; }
        }

        public string ProjectPath
        {
            get { return m_sProrjctPath; }
            set { m_sProrjctPath = value; }
        }

        public CUserDeviceS UserDeviceS
        {
            get { return m_cUserDeviceS; }
            set { m_cUserDeviceS = value; }
        }

        public Dictionary<int, CRecipeWord> RecipeWordList
        {
            get { return m_dicRecipeWord; }
            set { m_dicRecipeWord = value; }
        }

        public CPlcProcS PlcProcS
        {
            get { return m_cPlcProcS; }
            set { m_cPlcProcS = value; }
        }

        public List<string> PlcIDList
        {
            get { return m_lstPlcID; }
            set { m_lstPlcID = value; }
        }

        public EMMonitorModeType PatternItemStep
        {
            get { return m_emPatternItemStep; }
            set { m_emPatternItemStep = value; }
        }

        public EMMonitorType MonitorType
        {
            get { return m_emMonitorType; }
            set { m_emMonitorType = value; }
        }

        public CTagS RobotCycleTagS
        {
            get { return m_cRobotCycleTagS; }
            set { m_cRobotCycleTagS = value; }
        }

        public CRecipeSection ViewRecipe
        {
            get { return m_cRunViewRecipeSection; }
            set { m_cRunViewRecipeSection = value; }
        }

        #endregion


        #region Public Method

        public void Clear()
        {
            m_sProjectID = "";
            m_lstPlcID.Clear();
            m_cUserDeviceS.Clear();
            m_dicRecipeWord.Clear();
            m_cPlcProcS.Clear();
            m_cRobotCycleTagS.Clear();

            if(m_cMasterPatternS != null)
                m_cMasterPatternS.Clear();

            m_emPatternItemStep = EMMonitorModeType.None;
            m_emMonitorType = EMMonitorType.FlowItem;
        }

        public void Compose()
        {

        }

        /// <summary>
        /// User DeviceS, Robot Cycle TagS Key를 추출
        /// </summary>
        /// <returns></returns>
        public List<string> GetCollectTagKeyList()
        {
            List<string> lstResult = new List<string>();

            lstResult.AddRange(m_cUserDeviceS.Values.Select(b => b.Tag.Key).ToList());
            lstResult.AddRange(m_cRobotCycleTagS.Values.Select(b => b.Key).ToList());

            return lstResult;
        }

        #endregion
    }
}
