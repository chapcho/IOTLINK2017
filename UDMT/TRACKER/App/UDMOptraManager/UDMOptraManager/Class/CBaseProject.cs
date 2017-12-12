using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerCommon;
using UDM.General.Serialize;
using UDM.Log;

namespace UDMOptraManager
{
    [Serializable]
    public class CBaseProject
    {
        #region Member Variables

        private bool m_bAutoControl = false;
        private string m_sProjectPath;
        private string m_sProjectName;
        private string m_sExcuteFilePath;
        private string m_sTrackerStartupPath;
        private string m_sDBBackupPath = "";


        private int m_iOperCount = 0;
        private int m_iPlcCount = 0;
        private int n_iDBBackupCycle = 1;

        private List<string> m_lstPlcProcS = new List<string>();
        private CPlcConfigS m_cPlcConfigS = new CPlcConfigS();
        
        private DateTime m_dtProjectSaveTime; //Tracker Project 저장 시간
        private DateTime m_dtOperStartTime;
        private DateTime m_dtOperEndTime;

        private EMMonitorType m_EmMonitorType = EMMonitorType.Detection;

        #endregion

        public CBaseProject()
        {
            if (Environment.Is64BitOperatingSystem)
                m_sExcuteFilePath = @"C:\Program Files (x86)\UDMTek\UDM Tracker\UDMTrackerSimple.exe";
            else
                m_sExcuteFilePath = @"C:\Program Files\UDMTek\UDM Tracker\UDMTrackerSimple.exe";
            //m_sExcuteFilePath = 
        }

        #region Properties
        public bool IsAutoControl
        {
            get { return m_bAutoControl; }
            set { m_bAutoControl = value; }
        }
        public string ProjectPath
        {
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
        }
        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }
        public string ExcuteFilePath
        {
            get { return m_sExcuteFilePath; }
            set { m_sExcuteFilePath = value; }
        }
        public string TrackerStartupPath
        {
            get { return m_sTrackerStartupPath; }
            set { m_sTrackerStartupPath = value; }
        }
        public EMMonitorType MonitorType
        {
            get { return m_EmMonitorType; }
            set { m_EmMonitorType = value; }
        }

        public DateTime ProjectSaveTime
        {
            get { return m_dtProjectSaveTime; }
            set { m_dtProjectSaveTime = value; }
        }
        public DateTime OperStartTime
        {
            get { return m_dtOperStartTime; }
            set { m_dtOperStartTime = value; }
        }

        public DateTime OperEndTime
        {
            get { return m_dtOperEndTime; }
            set { m_dtOperEndTime = value; }
        }
        public int OperationCount
        {
            get { return m_iOperCount; }
            set { m_iOperCount = value; }
        }

        public int PlcCount
        {
            get { return m_iPlcCount; }
            set { m_iPlcCount = value; }
        }

        public int DBBackupCycle
        {
            get { return n_iDBBackupCycle; }
            set { n_iDBBackupCycle = value; }
        }

        public List<string> PlcProcList
        {
            get { return m_lstPlcProcS; }
            set { m_lstPlcProcS = value; }
        }
        public CPlcConfigS PlcConfigS
        {
            get { return m_cPlcConfigS; }
            set { m_cPlcConfigS = value; }
        }

        public string DBBackupPath
        {
            get { return m_sDBBackupPath; }
            set { m_sDBBackupPath = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Method
        #endregion

    }
}
