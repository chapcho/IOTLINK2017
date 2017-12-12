using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CProjectBaseInfo
    {
        #region Member Variables

        private string m_sProjectName = "";
        private string m_sProjectPath = "";
        private string m_sProjectID = "00000000";
        private CUserDeviceS m_cUserDeviceS = new CUserDeviceS();
        private Dictionary<int, CRecipeWord> m_dicRecipeWord = new Dictionary<int, CRecipeWord>();
        private CRecipeSection m_cRunViewRecipeSection = new CRecipeSection();
        private CPlcProcS m_cPlcProcS = new CPlcProcS();
        private List<string> m_lstPlcID = new List<string>();

        private EMMonitorType m_emMonitorType = EMMonitorType.Learning;
        private CTagS m_cRobotCycleTagS = new CTagS();

        private EMMonitorModeType m_emLearningStep = EMMonitorModeType.None;
        private EMMonitorModeType m_emMasterStep = EMMonitorModeType.None;

        private string m_sDBPath = string.Empty;
        private string m_sDBBackupPath = string.Empty;
        private bool m_bApplyAbnormalPriority = false;
        private bool m_bProjectBaseView = false;
        private bool m_bAccount = true;
        private CNonDetectTimeS m_cNonDetectTimeS = null;
        private int m_iCollectSymbolSubDepth = 5;
        private COptimizationOption m_cOptimizationOption = new COptimizationOption();

        //[NonSerialized]
        //private CMasterPatternS m_cMasterPatternS = null;

        #endregion

        #region Properties

        public COptimizationOption OptimizationOption
        {
            get { return m_cOptimizationOption;}
            set { m_cOptimizationOption = value; }
        }

        public int CollectSymbolSubDepth
        {
            get { return m_iCollectSymbolSubDepth;}
            set { m_iCollectSymbolSubDepth = value; }
        }

        public CNonDetectTimeS NonDetectTimeS
        {
            get { return m_cNonDetectTimeS;}
            set { m_cNonDetectTimeS = value; }
        }


        public bool ProjectBaseView
        {
            get { return m_bProjectBaseView;}
            set { m_bProjectBaseView = value; }
        }

        public bool ApplyAbnormalPriority
        {
            get { return m_bApplyAbnormalPriority;}
            set { m_bApplyAbnormalPriority = value; }
        }

        public string DBPath
        {
            get { return m_sDBPath;}
            set { m_sDBPath = value; }
        }

        public string DBBackupPath
        {
            get { return m_sDBBackupPath; }
            set { m_sDBBackupPath = value; }
        }

        public EMMonitorModeType LearningStep
        {
            get { return m_emLearningStep;}
            set { m_emLearningStep = value; }
        }

        public EMMonitorModeType MasterStep
        {
            get { return m_emMasterStep;}
            set { m_emMasterStep = value; }
        }

        //public CMasterPatternS MasterPatternS
        //{
        //    get { return m_cMasterPatternS;}
        //    set { m_cMasterPatternS = value; }
        //}

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
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
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

        public bool Account
        {
            get { return m_bAccount; }
            set { m_bAccount = value; }
        }

        #endregion


        #region Public Method

        public void Clear()
        {
            m_sProjectName = string.Empty;
            m_sProjectID = string.Empty;
            m_lstPlcID.Clear();
            m_cUserDeviceS.Clear();
            m_dicRecipeWord.Clear();
            m_cPlcProcS.Clear();
            m_cRobotCycleTagS.Clear();

            m_emMonitorType = EMMonitorType.Learning;
            m_emLearningStep = EMMonitorModeType.None;
            m_emMasterStep = EMMonitorModeType.None;

            m_bApplyAbnormalPriority = false;
            m_bProjectBaseView = false;
            m_bAccount = true;

            if(m_cNonDetectTimeS != null)
                m_cNonDetectTimeS.Clear();

            m_cNonDetectTimeS = null;
            m_iCollectSymbolSubDepth = 5;
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
