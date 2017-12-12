using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.General.Serialize;
using System.IO.Compression;
using System.Windows.Forms;
using DevExpress.Charts.Native;
using DevExpress.Utils.Zip;
using Ionic.Zip;
using UDM.Log;

namespace UDMProfiler
{
    static class CProjectManager
    {
        //Project Base Info (단일파일)
        private static CProjectBase m_cProject = null;
        //PLC별 Logic, 통신설정 (개별파일)
        private static CPlcS m_cPlcS = new CPlcS();

        //휘발성 데이터
        private static CTagS m_cTotalTagS = new CTagS();
        private static CSystemLog m_cSysLog = null;
        private static UCProjectTree m_ucMainTree = null;

        #region Initialize/Dispose

        #endregion

        #region Properties

        public static CProjectBase Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        /// <summary>
        /// Project ID는 내부적으로 사용
        /// </summary>
        public static string ProjectID
        {
            get { return m_cProject.ProjectID; }
            set { m_cProject.ProjectID = value; }
        }

        public static string ProjectName
        {
            get { return m_cProject.ProjectName; }
            set { m_cProject.ProjectName = value; }
        }

        public static string ProjectPath
        {
            get { return m_cProject.ProjectPath; }
            set { m_cProject.ProjectPath = value; }
        }

        public static string LogFilePath
        {
            get { return m_cProject.LogFilePath; }
            set { m_cProject.LogFilePath = value; }
        }

        public static CTagS TotalTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        public static CPlcS PlcS
        {
            get { return m_cPlcS;}
            set { m_cPlcS = value; }
        }

        public static CSystemLog SystemLog
        {
            get { return m_cSysLog;}
            set { m_cSysLog = value; }
        }

        public static UCProjectTree MainTree
        {
            get { return m_ucMainTree;}
            set { m_ucMainTree = value; }
        }

        #endregion

        #region Public Methods

        public static string GetPlcID()
        {
            string sPlcID = string.Empty;

            sPlcID = string.Format("{0}-{1}", m_cProject.ProjectID, m_cPlcS.Count.ToString());

            if (CProjectManager.PlcS.ContainsKey(sPlcID))
            {
                string sIndex = CProjectManager.PlcS.Last().Key.Split('-')[1];
                int iIndex = Convert.ToInt32(sIndex);

                sPlcID = string.Format("{0}-{1}", m_cProject.ProjectID, iIndex.ToString());
            }

            return sPlcID;
        }

        public static void Clear()
        {
            if (m_cProject == null)
                return;

            m_cProject.Clear();
            m_cPlcS.Dispose();
            m_cTotalTagS.Dispose();

            if(m_ucMainTree != null)
                m_ucMainTree.Clear();
        }

        public static bool Create(string sProjectName)
        {
            //Clear Form

            bool bOK = false;

            if(m_cProject == null)
                m_cProject = new CProjectBase();

            m_cProject.ProjectName = sProjectName;
            m_cProject.ProjectID = GetProjectID();

            return bOK;
        }

        public static bool Save(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = string.Empty;

            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            if (!Directory.Exists(sFolderPath))
                Directory.CreateDirectory(sFolderPath);

            string sBasePath = sFolderPath + sFileName;
            bOK = SaveBaseInfo(sBasePath);
            if (!bOK)
            {
                sMessage = "기본 프로젝트를 저장하는데 실패했습니다.";
                return false;
            }

            bOK = SavePlcS(sFolderPath);
            if (!bOK)
            {
                sMessage = "PLC 데이터를 저장하는데 실패했습니다.";
                return false;
            }

            bOK = ZipCompression(sFolderPath);
            if (!bOK)
            {
                sMessage = "데이터를 압축하는데 실패했습니다.";
                return false;
            }

            m_cProject.ProjectPath = string.Format("{0}.upr", sFolderPath);

            bOK = DeleteProjectFolder(sFolderPath);
            if (!bOK)
            {
                sMessage = "프로젝트 폴더를 지우는데 실패했습니다.";
                return false;
            }

            return bOK;
        }

        public static bool Open(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = string.Empty;
            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            bOK = ExtractFileToDirectory(sPath, sFolderPath);
            if (!bOK)
            {
                sMessage = "압축을 푸는데 실패했습니다.";
                return false;
            }

            bOK = OpenBaseInfo(sFolderPath + sFileName);
            if (!bOK)
            {
                sMessage = "Base Project를 여는데 실패했습니다.";
                return false;
            }

            bOK = OpenPlcS(sFolderPath);
            if (!bOK)
            {
                sMessage = "PLC 데이터를 여는데 실패했습니다.";
                return false;
            }

            bOK = DeleteProjectFolder(sFolderPath);
            if (!bOK)
            {
                sMessage = "프로젝트 폴더를 지우는데 실패했습니다.";
                return false;
            }

            return bOK;
        }

        public static void Refresh()
        {
            if(m_ucMainTree != null)
                m_ucMainTree.ShowTree();
        }

        #endregion

        #region Private Methods

        #region Save File(upr) Related Project

        private static bool SaveBaseInfo(string sPath)
        {
            bool bOK = false;

            try
            {
                CNetSerializer cSerializer = new CNetSerializer();

                bOK = cSerializer.Write(sPath, m_cProject);

                cSerializer.Dispose();
                cSerializer = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save Base Info Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool SavePlcS(string sFolderPath)
        {
            bool bOK = false;

            try
            {
                if (!Directory.Exists(sFolderPath))
                    Directory.CreateDirectory(sFolderPath);

                List<string> lstSaveError = SavePlcDataList(sFolderPath, m_cPlcS.Keys.ToList());

                if (lstSaveError.Count > 0)
                {
                    for (int i = 0; i < lstSaveError.Count; i++)
                        Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstSaveError[i]));
                    bOK = false;
                }
                else
                    bOK = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save PlcS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool ZipCompression(string sFolderPath)
        {
            bool bOK = false;
            try
            {
                ZipFile zip = new ZipFile();
                zip.UseUnicodeAsNecessary = true;
                zip.AddDirectory(sFolderPath);
                zip.Save(sFolderPath + ".upr");

                bOK = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Compression Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool DeleteProjectFolder(string sFolderPath)
        {
            bool bOK = false;

            try
            {
                if (Directory.Exists(sFolderPath))
                {
                    Directory.Delete(sFolderPath, true);
                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteProjectFolder Error " + ex.Message );
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static List<string> SavePlcDataList(string sPath, List<string> lstPlcID)
        {
            List<string> lstResult = new List<string>();
            if (m_cPlcS == null)
                lstResult.Add("m_cPlcS = null");
            else
            {
                var exceptions = new ConcurrentQueue<Exception>();

                Parallel.ForEach(lstPlcID, sID =>
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFilePath = sPath + "\\" + sID + ".pcd";
                    try
                    {
                        if (m_cPlcS.ContainsKey(sID))
                        {
                            bool bOK = cSerializer.Write(sFilePath, m_cPlcS[sID]);

                            if (bOK == false)
                                lstResult.Add(sFilePath);
                        }
                        else
                            lstResult.Add(sID + "  Not Found !! ");
                        cSerializer.Dispose();
                        cSerializer = null;
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }

                });

                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }

            return lstResult;
        }

        #endregion

        #region Open File(upr)

        private static bool ExtractFileToDirectory(string sZipPath, string sDirectory)
        {
            bool bOK = false;

            try
            {
                ZipFile zip = new ZipFile(sZipPath);
                Directory.CreateDirectory(sDirectory);
                zip.ExtractAll(sDirectory, ExtractExistingFileAction.OverwriteSilently);

                bOK = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("ExtractFileToDirectory Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool OpenBaseInfo(string sPath)
        {
            bool bOK = false;

            try
            {
                CNetSerializer cSerializer = new CNetSerializer();
                CProjectBase cProject = (CProjectBase) (cSerializer.Read(sPath));
                if (cProject != null)
                {
                    m_cProject = cProject;

                    cSerializer.Dispose();
                    cSerializer = null;

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenBaseInfo Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private static bool OpenPlcS(string sFolderPath)
        {
            bool bOK = false;

            try
            {
                List<string> lstLoadError = OpenPlcLogicDataList(sFolderPath, m_cProject.PlcIDList);
                if (lstLoadError.Count > 0)
                {
                    for (int i = 0; i < lstLoadError.Count; i++)
                        Console.WriteLine(string.Format("Open Plc Logic Fail -> {0}", lstLoadError[i]));
                    bOK = false;
                }
                foreach (var who in m_cPlcS)
                    m_cTotalTagS.AddRange(who.Value.TagS);

                bOK = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenPlcS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private static List<string> OpenPlcLogicDataList(string sFolderPath, List<string> lstPlcID)
        {
            if (m_cPlcS == null)
                m_cPlcS = new CPlcS();
            else
                m_cPlcS.Clear();

            List<string> sLoadError = new List<string>();
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(lstPlcID, sID =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                string sFilePath = sFolderPath + "\\" + sID + ".pcd";
                try
                {
                    CPlc cPlc = (CPlc)(cSerializer.Read(sFilePath));
                    if (cPlc != null)
                    {
                        cPlc.Compose();
                        m_cPlcS.Add(cPlc.PlcID, cPlc);
                    }
                    else
                        sLoadError.Add(sFilePath);

                    cSerializer.Dispose();
                    cSerializer = null;
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        #endregion


        private static string GetProjectID()
        {
            string sID = string.Empty;

            Random rand = new Random();
            int iValue = rand.Next();
            sID = string.Format("{0:x8}", iValue).ToUpper();

            return sID;
        }

        #endregion
    }
}
