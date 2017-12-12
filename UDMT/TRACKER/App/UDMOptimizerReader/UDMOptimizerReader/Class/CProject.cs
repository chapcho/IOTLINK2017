using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerCommon;
using UDM.Common;
using UDM.General.Serialize;

namespace UDMOptimizerReader
{
    [Serializable]
    public class CProject
    {
        #region Member Veriables

        private bool m_bAutoMode = false;
        private DateTime m_dtAutoStart = DateTime.MinValue;
        private DateTime m_dtAutoStop = DateTime.MinValue;
        private string m_sDBBackupPath = Application.StartupPath + "\\DB Backup";

        private List<string> m_lstUserAddTagKey = new List<string>();
        private List<string> m_lstAutoAddTagKey = new List<string>();
        private string m_sAutoOpenFilePath = "";
        private string m_sAutoConfigPath = "";
        private List<string> m_lstLogicFilePath = new List<string>();
        private bool m_bInputAddCheck = true;
        private bool m_bOutputAddCheck = true;
        private bool m_bM_AddCheck = true;
        private bool m_bUseOnlyInLogic = false;
        private EMCollectModeType m_emCollectMode = EMCollectModeType.AllSymbolWordMode;
        [NonSerialized]
        protected Dictionary<string, CPlcConfig> m_dicSPDConfig = new Dictionary<string, CPlcConfig>();
        [NonSerialized]
        protected Dictionary<string, CTagS> m_dicLogicTagS = new Dictionary<string, CTagS>();
        [NonSerialized]
        protected Dictionary<string, CViewTag> m_dicViewTag = new Dictionary<string, CViewTag>();

        #endregion


        #region Properties

        public bool IsAutoMode
        {
            get { return m_bAutoMode; }
            set { m_bAutoMode = value; }
        }

        public DateTime AutoStartTime
        {
            get { return m_dtAutoStart; }
            set { m_dtAutoStart = value; }
        }

        public DateTime AutoStopTime
        {
            get { return m_dtAutoStop; }
            set { m_dtAutoStop = value; }
        }

        public string DBBackupPath
        {
            get { return m_sDBBackupPath; }
            set { m_sDBBackupPath = value; }
        }

        public List<string> UserAddTagKeyList
        {
            get { return m_lstUserAddTagKey; }
            set { m_lstUserAddTagKey = value; }
        }

        public List<string> AutoAddTagKeyList
        {
            get { return m_lstAutoAddTagKey; }
            set { m_lstAutoAddTagKey = value; }
        }

        /// <summary>
        /// 통신 설정 파일도 같이 열기..통신설정 파일은 Tracker에서 생성된 파일을 사용함.
        /// </summary>
        public string AutoOpenPath
        {
            get { return m_sAutoOpenFilePath; }
            set { m_sAutoOpenFilePath = value; }
        }

        public string AutoConfigPath
        {
            get { return m_sAutoConfigPath; }
            set { m_sAutoConfigPath = value; }
        }

        public List<string> AutoLogicFilePathList
        {
            get { return m_lstLogicFilePath; }
            set { m_lstLogicFilePath = value; }
        }

        public bool InputBitAddCheck
        {
            get { return m_bInputAddCheck; }
            set { m_bInputAddCheck = value; }
        }

        public bool OutputBitAddCheck
        {
            get { return m_bOutputAddCheck; }
            set { m_bOutputAddCheck = value; }
        }

        public bool M_BitAddCheck
        {
            get { return m_bM_AddCheck; }
            set { m_bM_AddCheck = value; }
        }

        public bool UseOnlyInLogicCheck
        {
            get { return m_bUseOnlyInLogic; }
            set { m_bUseOnlyInLogic = value; }
        }

        public Dictionary<string, CPlcConfig> SPDConfigS
        {

            get { return m_dicSPDConfig; }
            set { m_dicSPDConfig = value; }
        }

        public Dictionary<string, CTagS> LogicTagS
        {
            get { return m_dicLogicTagS; }
            set { m_dicLogicTagS = value; }
        }
        
        public Dictionary<string, CViewTag> ViewTagS
        {
            get { return m_dicViewTag; }
            set { m_dicViewTag = value; }
        }

        public EMCollectModeType CollectMode
        {
            get { return m_emCollectMode; }
            set { m_emCollectMode = value; }
        }

        #endregion

        #region Public Method

        public int Open(string sPath)
        {
            bool bOK = false;
            try
            {
                bOK = OpenProject(sPath);
                if (bOK == false)
                {
                    MessageBox.Show("프로젝트 열기 실패");
                    return -1;
                }
                if (File.Exists(m_sAutoConfigPath))
                {
                    List<string> lstError = OpenPlcLogicDataList(m_lstLogicFilePath);
                    if (lstError == null || lstError.Count > 0)
                    {
                        string ErrorPath = "";
                        for (int i = 0; i < lstError.Count; i++)
                            ErrorPath += lstError[i] + "  /  ";
                        MessageBox.Show("로직 열기 실패 : " + ErrorPath);
                        return -1;
                    }

                    bOK = OpenConfigS(m_sAutoConfigPath);
                    if (bOK == false)
                    {
                        MessageBox.Show("통신 설정 열기 실패");
                        return -1;
                    }
                }
                else
                {

                    DialogResult dlgResult = MessageBox.Show("Config, Logic파일이 경로 없습니다.\r\n파일을 다시 Load 하겠습니까?", "OPEN Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.Yes)
                        return 0;
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return 1;
        }

        public bool OpenReloadLogic(List<string> sLogicPath)
        {
            bool bOK = false;
            try
            {
                if (sLogicPath.Count == 0)
                    return false;
                if (File.Exists(sLogicPath[0]))
                {
                    List<string> lstError = OpenPlcLogicDataList(sLogicPath);
                    if (lstError == null || lstError.Count > 0)
                    {
                        string ErrorPath = "";
                        for (int i = 0; i < lstError.Count; i++)
                            ErrorPath += lstError[i] + "  /  ";
                        MessageBox.Show("로직 열기 실패 : " + ErrorPath);
                        return bOK;
                    }
                }
                else
                {
                    MessageBox.Show("Config, Logic파일이 경로 없습니다. 임의로 로드해주세요");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return bOK;
        }

        public bool OpenReloadConfig(string sConfigPath)
        {
            bool bOK = false;
            try
            {
                if (File.Exists(sConfigPath))
                {
                    bOK = OpenConfigS(sConfigPath);
                    if (bOK == false)
                    {
                        MessageBox.Show("통신 설정 열기 실패");
                        return bOK;
                    }
                }
                else
                {
                    MessageBox.Show("Config, Logic파일이 경로 없습니다. 임의로 로드해주세요");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return bOK;
        }

        public bool Save(string sPath)
        {
            bool bOK = false;

            bOK = SaveProject(sPath);
            if (bOK == false)
            {
                MessageBox.Show("프로젝트 저장 실패");
                return bOK;
            }

            return bOK;
        }

        #endregion


        #region Private Method

        private bool OpenProject(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CProject cProject = (CProject)(cSerializer.Read(sPath));
            if (cProject != null)
            {
                m_bAutoMode = cProject.IsAutoMode;
                m_dtAutoStart = cProject.AutoStartTime;
                m_dtAutoStop = cProject.AutoStopTime;
                m_sDBBackupPath = cProject.DBBackupPath;

                m_lstUserAddTagKey = cProject.UserAddTagKeyList;
                m_lstAutoAddTagKey = cProject.AutoAddTagKeyList;
                m_sAutoOpenFilePath = cProject.AutoOpenPath;
                m_sAutoConfigPath = cProject.AutoConfigPath;
                m_lstLogicFilePath = cProject.AutoLogicFilePathList;
                m_bInputAddCheck = cProject.InputBitAddCheck;
                m_bOutputAddCheck = cProject.OutputBitAddCheck;
                m_bM_AddCheck = cProject.M_BitAddCheck;
                m_bUseOnlyInLogic = cProject.UseOnlyInLogicCheck;
                m_emCollectMode = cProject.m_emCollectMode;
                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            return bOK;
        }

        private bool SaveProject(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CProject cProject = new CProject();

            cProject.IsAutoMode = m_bAutoMode;
            cProject.AutoStartTime = m_dtAutoStart;
            cProject.AutoStopTime = m_dtAutoStop;
            cProject.DBBackupPath = m_sDBBackupPath;

            cProject.UserAddTagKeyList = m_lstUserAddTagKey;
            cProject.AutoAddTagKeyList = m_lstAutoAddTagKey;
            cProject.AutoOpenPath = m_sAutoOpenFilePath;
            cProject.AutoConfigPath = m_sAutoConfigPath;
            cProject.AutoLogicFilePathList = m_lstLogicFilePath;
            cProject.InputBitAddCheck = m_bInputAddCheck;
            cProject.OutputBitAddCheck = m_bOutputAddCheck;
            cProject.M_BitAddCheck = m_bM_AddCheck;
            cProject.UseOnlyInLogicCheck = m_bUseOnlyInLogic;
            cProject.CollectMode = m_emCollectMode;
            bOK = cSerializer.Write(sPath, cProject);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private List<string> OpenPlcLogicDataList(List<string> lstFilePath)
        {
            if (m_dicLogicTagS == null)
                m_dicLogicTagS = new Dictionary<string,CTagS>();
            else
                m_dicLogicTagS.Clear();

            List<string> sLoadError = new List<string>();
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(lstFilePath, sPath =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                
                try
                {
                    CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sPath));
                    if (cPlcLogicData != null)
                    {
                        cPlcLogicData.Compose();
                        cPlcLogicData.Compose();
                        m_dicLogicTagS.Add(cPlcLogicData.PLCID, cPlcLogicData.TagS);
                    }
                    else
                        sLoadError.Add(sPath);

                    foreach (CTag cTag in cPlcLogicData.TagS.Values)
                    {
                        CViewTag cViewTag = new CViewTag();
                        cViewTag.CollectUse = false;
                        cViewTag.Tag = cTag;

                        m_dicViewTag.Add(cTag.Key, cViewTag);
                    }
                    
                    cSerializer.Dispose();
                    cSerializer = null;

                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }

            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        public bool OpenConfigS(string sPath)
        {
            bool bOK = false;

            foreach (var who in m_dicLogicTagS)
            {
                bOK = OpenConfig(sPath, who.Key);
            }

            return bOK;
        }

        private bool OpenConfig(string sPath, string sID)
        {
            CPlcConfigS cConfigS = new CPlcConfigS();
            if (m_dicSPDConfig.ContainsKey(sID) == false)
            {
                CPlcConfig cConfigBuf = cConfigS.OpenPlcConfigS(sPath, sID);
                if (cConfigBuf != null)
                    m_dicSPDConfig.Add(sID, cConfigBuf);
                else
                    return false;
            }

            return true;
        }

        #endregion

    }
}
