using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.General.Serialize;
using UDM.Log;
using UDM.Log.DB;
using UDM.Project;
using UDMTrackerSimple.UserControls;

namespace UDMTrackerSimple
{
    public static class CProjectManager
    {
        #region Member Variables

        private static bool m_bEditable = true;
        private static CTProject m_cProject = new CTProject();
        private static UCGroupTree m_ucGroupTree = null;
        private static UCTagTable m_ucTagTable = null;
        private static UCGroupCycleBoardS m_ucGroupCycleBoard = null;
        private static UCGroupStateTable m_ucGroupStateTable = null;
        private static List<string> m_lstUsedProjectID = new List<string>();

        private static CMySqlLogReader m_cReader = null;

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public static bool Editable
        {
            get { return m_bEditable; }
            set { SetEditable(value); }
        }

        public static CMySqlLogReader LogReader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        public static CTProject Project
        {
            get { return m_cProject; }
            set { SetProject(value); }
        }

        public static UCGroupTree GroupTreeView
        {
            get { return m_ucGroupTree; }
            set { SetGroupTreeView(value); }
        }

        public static UCTagTable TagTableView
        {
            get { return m_ucTagTable; }
            set { SetTagTableView(value); }
        }

        public static UCGroupCycleBoardS GroupCycleBoard
        {
            get { return m_ucGroupCycleBoard; }
            set { m_ucGroupCycleBoard = value; }
        }

        public static UCGroupStateTable GroupStateTable
        {
            get { return m_ucGroupStateTable; }
            set { m_ucGroupStateTable = value; }
        }

        public static List<string> UsedProjectID
        {
            get { return m_lstUsedProjectID; }
            set { m_lstUsedProjectID = value; }
        }

        #endregion


        #region Public Method

        public static void Create(string sName)
        {
            Clear();
            m_cProject.Name = sName;
            
            if (m_ucGroupStateTable != null)
                m_ucGroupStateTable.GroupS = m_cProject.GroupS;
            if (m_ucGroupCycleBoard != null)
                m_ucGroupCycleBoard.GroupS = m_cProject.GroupS;

            ReadDBErrorInfoS();

            CreateProjectID();
            m_cProject.GroupCycleInfo.Clear();
        }

        public static bool Open(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CTProject cProject = (CTProject)(cSerializer.Read(sPath));
            if (cProject != null)
            {
                cProject.Path = sPath;

                m_cProject = cProject;
                m_cProject.Compose();

                ReadDBErrorInfoS();

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;

                if (m_ucGroupStateTable != null)
                    m_ucGroupStateTable.GroupS = m_cProject.GroupS;
                if (m_ucGroupCycleBoard != null)
                    m_ucGroupCycleBoard.GroupS = m_cProject.GroupS;
            }

            return bOK;
        }

        public static bool OpenParallelTest(List<string> lstPath)
        {
            bool bOK = false;

            List<CTProject> lstProject = new List<CTProject>();
            Stopwatch swTime = new Stopwatch();
            swTime.Start();
            Parallel.ForEach(lstPath, sPath =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                CTProject cProject = (CTProject)(cSerializer.Read(sPath));
                if (cProject != null)
                {
                    cProject.Path = sPath;
                    cProject.Compose();

                    lstProject.Add(cProject);
                }

                cSerializer.Dispose();
                cSerializer = null;

            });
            swTime.Stop();
            string sTime = string.Format("OpenParallelTest 열기 시간 : {0} ms", swTime.ElapsedMilliseconds);
            Console.WriteLine(sTime);
            return bOK;
        }

        public static bool OpenSeriallTest(List<string> lstPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = null;
            List<CTProject> lstProject = new List<CTProject>();
            Stopwatch swTime = new Stopwatch();
            swTime.Start();
            foreach(string sPath in lstPath)
            {
                cSerializer = new CNetSerializer();
                CTProject cProject = (CTProject)(cSerializer.Read(sPath));
                if (cProject != null)
                {
                    cProject.Path = sPath;
                    cProject.Compose();

                    lstProject.Add(cProject);
                }

                cSerializer.Dispose();
                cSerializer = null;

            }
            swTime.Stop();
            string sTime = string.Format("OpenSeriallTest 열기 시간 : {0} ms", swTime.ElapsedMilliseconds);
            Console.WriteLine(sTime);
            return bOK;
        }

        public static bool Save(string sPath)
        {
            bool bOK = true;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cProject);
            m_cProject.Path = sPath;

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        public static void Clear()
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.Clear();

            if (m_ucTagTable != null)
                m_ucTagTable.Clear();

            if (m_cProject != null)
            {
                m_cProject.UserDevice.Clear();
                m_cProject.Clear();
            }

            if (m_ucGroupCycleBoard != null)
                m_ucGroupCycleBoard.Clear();

            if (m_ucGroupStateTable != null)
                m_ucGroupStateTable.Clear();

        }

        public static void Refresh()
        {
            if (m_ucGroupTree != null)
            {
                m_ucGroupTree.Project = m_cProject;
                m_ucGroupTree.ShowTree();
            }
            if (m_ucTagTable != null)
            {
                m_ucTagTable.Project = m_cProject;
                m_ucTagTable.ShowTable();
            }

            if (m_ucGroupCycleBoard != null)
                m_ucGroupCycleBoard.ShowBoard();
            if (m_ucGroupStateTable != null)
                m_ucGroupStateTable.ShowTable();
        }

        public static CTagS GetSelectedTagS()
        {
            CTagS cTagS = null;
            if (m_ucTagTable != null)
                cTagS = m_ucTagTable.GetSelectedTagS();

            return cTagS;
        }

        #endregion


        #region Private Methods

        private static void ReadDBErrorInfoS()
        {
            try
            {
                m_cProject.ErrorInfoS = m_cReader.GetErrorInfoS(m_cProject.ProjectID);

                if (m_cProject.ErrorInfoS == null)
                    m_cProject.ErrorInfoS = new CErrorInfoS();

                CreateNextErrorID();
                CreateNextCycleID();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CreateNextErrorID()
        {
            try
            {
                int iLastErrorID = m_cReader.GetLastErrorInfoID(m_cProject.ProjectID);

                if (++iLastErrorID != m_cProject.ErrorIDCur)
                    m_cProject.ErrorIDCur = iLastErrorID;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        public static void CreateNextCycleID()
        {
            try
            {
                if (m_cProject.GroupS == null) return;
                m_cProject.GroupCycleInfo = new Dictionary<string, CCycleInfo>();
                foreach (var who in m_cProject.GroupS)
                {
                    CCycleInfo cCycleInfo = new CCycleInfo();
                    cCycleInfo.GroupKey = who.Key;
                    cCycleInfo.CycleID = 0;
                    m_cProject.GroupCycleInfo.Add(who.Key, new CCycleInfo());
                }

                foreach (var who in m_cProject.GroupCycleInfo)
                {
                    int iLastCycleID = m_cReader.GetLastCycleID(m_cProject.ProjectID, who.Key);

                    if (++iLastCycleID != m_cProject.CycleIDCur)
                        who.Value.CycleID = iLastCycleID;
                }
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static bool CreateProjectID()
        {
            List<string> lstUsedPID = m_cReader.GetUsedProjectIDList();
            while (true)
            {
                Random iRandom = new Random();
                int iValue = iRandom.Next();
                string sResult = string.Format("{0:x8}", iValue).ToUpper();
                if (lstUsedPID.Contains(sResult) == false)
                {
                    m_cProject.ProjectID = sResult;
                    break;
                }
            }
            return true;
        }

        private static void SetProject(CTProject cProject)
        {
            Clear();
            m_cProject = cProject;
        }

        private static void SetEditable(bool bEditable)
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.Editable = bEditable;

            if (m_ucTagTable != null)
                m_ucTagTable.Editable = bEditable;
        }

        private static void SetGroupTreeView(UCGroupTree ucTreeView)
        {
            if (m_ucGroupTree != null)
            {
                m_ucGroupTree.UEventSymbolAdded -= new UEventHandlerGroupTreeSymbolAdded(m_ucGroupTree_UEventSymbolAdded);
                m_ucGroupTree.UEventSymbolUpdated -= new UEventHandlerGroupTreeSymbolUpdated(m_ucGroupTree_UEventSymbolUpdated);
                m_ucGroupTree.UEventSymbolRemoved -= new UEventHandlerGroupTreeSymbolRemoved(m_ucGroupTree_UEventSymbolRemoved);
                m_ucGroupTree = null;
            }

            m_ucGroupTree = ucTreeView;
            if (m_ucGroupTree != null)
            {
                m_ucGroupTree.TagTable = m_ucTagTable;
                m_ucGroupTree.UEventSymbolAdded += new UEventHandlerGroupTreeSymbolAdded(m_ucGroupTree_UEventSymbolAdded);
                m_ucGroupTree.UEventSymbolUpdated += new UEventHandlerGroupTreeSymbolUpdated(m_ucGroupTree_UEventSymbolUpdated);
                m_ucGroupTree.UEventSymbolRemoved += new UEventHandlerGroupTreeSymbolRemoved(m_ucGroupTree_UEventSymbolRemoved);
            }
        }

        private static void SetTagTableView(UCTagTable ucTagTable)
        {
            if (m_ucTagTable != null)
            {
                m_ucTagTable.UEventTagAdded -= new UEventHandlerTagTableTagAdded(m_ucTagTable_UEventTagAdded);
                m_ucTagTable.UEventTagUpdated -= new UEventHandlerTagTableTagUpdated(m_ucTagTable_UEventTagUpdated);
                m_ucTagTable.UEventTagRemoved -= new UEventHandlerTagTableTagRemoved(m_ucTagTable_UEventTagRemoved);
                m_ucTagTable = null;
            }

            m_ucTagTable = ucTagTable;
            if (m_ucTagTable != null)
            {
                m_ucTagTable.UEventTagAdded += new UEventHandlerTagTableTagAdded(m_ucTagTable_UEventTagAdded);
                m_ucTagTable.UEventTagUpdated += new UEventHandlerTagTableTagUpdated(m_ucTagTable_UEventTagUpdated);
                m_ucTagTable.UEventTagRemoved += new UEventHandlerTagTableTagRemoved(m_ucTagTable_UEventTagRemoved);
            }
        }

        #endregion

        #region Event Methods

        #region Group Tree Event

        private static void m_ucGroupTree_UEventSymbolAdded(object sender, string sGroup, CSymbolS cSymbolS)
        {

        }

        private static void m_ucGroupTree_UEventSymbolUpdated(object sender, string sGroup, CSymbolS cSymbolS)
        {
            if (m_ucTagTable != null)
                m_ucTagTable.ShowTable();
        }

        private static void m_ucGroupTree_UEventSymbolRemoved(object sender, string sGroup, CSymbolS cSymbolS)
        {

        }

        #endregion

        #region Tag Table Event

        private static void m_ucTagTable_UEventTagAdded(object sender, CTagS cTagS)
        {

        }

        private static void m_ucTagTable_UEventTagUpdated(object sender, CTagS cTagS)
        {

        }

        private static void m_ucTagTable_UEventTagRemoved(object sender, CTagS cTagS)
        {
            if (m_ucGroupTree != null)
                m_ucGroupTree.RemoveAllSymbolS(cTagS);
        }

        #endregion

        #endregion
    }
}
