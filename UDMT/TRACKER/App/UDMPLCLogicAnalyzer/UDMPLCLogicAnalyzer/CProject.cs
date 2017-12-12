using Ionic.Zip;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerCommon;
using UDM.Common;
using UDM.General.Serialize;

namespace UDMPLCLogicAnalyzer
{
    public static class CProject
    {
        #region Member Variables

        private static string m_sProjectBaseFolder = "";
        private static CBaseData m_cBaseData = new CBaseData();
        private static CAnalyzeDataS m_cAnalyzeDataS = new CAnalyzeDataS();
        private static CPlcLogicDataS m_cPlcLogicDataS = new CPlcLogicDataS();
        private static CTagS m_cTotalTagS = new CTagS();

        private static CPlcLogicDataS m_cLogicSCompare1 = new CPlcLogicDataS();

        #endregion


        #region Properties

        public static CBaseData BaseData
        {
            get { return m_cBaseData; }
            set { m_cBaseData = value; }
        }

        public static CAnalyzeDataS AnalyzeDataS
        {
            get { return m_cAnalyzeDataS; }
            set { m_cAnalyzeDataS = value; }
        }

        public static CPlcLogicDataS PLCLogicDataS
        {
            get { return m_cPlcLogicDataS; }
            set { m_cPlcLogicDataS = value; }
        }

        public static string ProjectPath
        {
            get { return m_cBaseData.ProjectPath; }
            set { m_cBaseData.ProjectPath = value; }
        }

        public static string ProjectID
        {
            get { return m_cBaseData.ProjectID; }
            set { m_cBaseData.ProjectID = value; }
        }

        public static CTagS TotalTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        public static CPlcLogicDataS LoogicSCompare1
        {
            get { return m_cLogicSCompare1; }
            set { m_cLogicSCompare1 = value; }
        }

        #endregion


        #region Public Method

        public static bool Open(string sPath, out string sMessage)
        {
            bool bOK = false;
            sMessage = "";
            if (!File.Exists(sPath))
                return false;
            
            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            if (Directory.Exists(sFolderPath))
                DeleteProjectFolder(sFolderPath);

            if (Directory.Exists(sFolderPath) == false)
            {
                bOK = ExtractFileToDirectory(sPath, sFolderPath);
                if (!bOK)
                {
                    sMessage = "압축을 푸는데 실패했습니다.";
                    if (Directory.Exists(sFolderPath))
                        DeleteProjectFolder(sFolderPath);
                    return false;
                }
            }

            string sProjectPath = GetProjectFilePath(sFolderPath);

            bOK = OpenBaseInfo(sProjectPath);
            if (!bOK)
                sMessage += "Base Project를 여는데 실패했습니다.";

            bOK = OpenAnalyzeData(sFolderPath);
            if (bOK == false)
                sMessage += "Analyze Data를 여는데 실패했습니다.";

            bOK = OpenPlcLogicData(out sMessage, sFolderPath);
            if (!bOK)
                sMessage += "PLC Data를 여는데 실패했습니다.";
            else
            {
                foreach (var who in m_cPlcLogicDataS)
                    m_cTotalTagS.AddRange(who.Value.TagS);
            }

            if (bOK == false)
            {
                if (Directory.Exists(sFolderPath))
                    DeleteProjectFolder(sFolderPath);
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

        public static bool Save(string sPath, out string sMessage)
        {
            bool bOK = false;

            sMessage = "";

            string sFolderPath = sPath.Substring(0, sPath.LastIndexOf("."));
            string sFileName = sPath.Remove(0, sPath.LastIndexOf("\\"));

            if (!Directory.Exists(sFolderPath))
                Directory.CreateDirectory(sFolderPath);

            string sBasePath = sFolderPath + sFileName;
            bOK = SaveBaseInfo(sBasePath);
            if (!bOK)
            {
                sMessage = "기본 프로젝트를 저장하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }

            bOK = SaveAnalyzeData(sFolderPath);
            if (bOK == false)
                sMessage += "Analyze Data를 저장하는데 실패했습니다.";

            bOK = SavePlcLogicData(out sMessage, sFolderPath);
            if (!bOK)
            {
                sMessage += "PLC 데이터를 Project Start Path에 저장하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
                return false;
            }

            bOK = ZipCompression(sFolderPath);
            if (!bOK)
            {
                sMessage = "데이터를 압축하는데 실패했습니다.";
                DeleteProjectFolder(sFolderPath);
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

        public static void Clear()
        {
            m_sProjectBaseFolder = "";
            m_cBaseData = new CBaseData();
            m_cAnalyzeDataS.Clear();
            m_cPlcLogicDataS.Clear();
            m_cTotalTagS.Clear();
        }

        /// <summary>
        /// Project ID + PlcLogicData 갯수
        /// </summary>
        /// <returns>PlcLogicData에 있는 값이면 Empty Return</returns>
        public static string CreatePlcId()
        {
            int iCount = m_cPlcLogicDataS.Count + 1;
            string sResult = ProjectID + "-" + iCount.ToString();

            if (m_cPlcLogicDataS.ContainsKey(sResult))
                return "";

            m_cBaseData.PLCIDList.Add(sResult);

            return sResult;
        }


        #endregion


        #region Private Method

        private static bool OpenPlcLogicData(out string sMessage, string sPath)
        {
            bool bOK = false;
            sMessage = string.Empty;

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);

                List<string> lstOpenError = OpenPlcLogicDataList(m_cBaseData.PLCIDList, sPath);
                if (lstOpenError.Count > 0)
                {
                    for (int i = 0; i < lstOpenError.Count; i++)
                        Console.WriteLine(string.Format("Open Plc Logic Fail -> {0}", lstOpenError[i]));
                    sMessage = "LogicData를 오픈하는데 실패했습니다.";
                    bOK = false;
                }
                else
                    bOK = true;

                lstOpenError = OpenComparePlcLogicDataList(m_cBaseData.PLCIDList, sPath);
                if (lstOpenError.Count > 0)
                {
                    for (int i = 0; i < lstOpenError.Count; i++)
                        Console.WriteLine(string.Format("Open Plc Logic Fail -> {0}", lstOpenError[i]));
                    sMessage = "Compare LogicData를 오픈하는데 실패했습니다.";
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("OpenPlcInfoS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private static bool SavePlcLogicData(out string sMessage, string sPath)
        {
            bool bOK = false;
            sMessage = "";

            try
            {
                if (Directory.Exists(sPath) == false)
                    Directory.CreateDirectory(sPath);

                List<string> lstSaveError = SavePlcLogicDataList(m_cBaseData.PLCIDList, sPath);
                if (lstSaveError.Count > 0)
                {
                    for (int i = 0; i < lstSaveError.Count; i++)
                        Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstSaveError[i]));
                    sMessage = "LogicData를 저장하는데 실패했습니다.";
                    bOK = false;
                }
                else
                    bOK = true;

                lstSaveError = SaveComparePlcLogicDataList(m_cBaseData.PLCIDList, sPath);
                if (lstSaveError.Count > 0)
                {
                    for (int i = 0; i < lstSaveError.Count; i++)
                        Console.WriteLine(string.Format("Save Plc Logic Fail -> {0}", lstSaveError[i]));
                    sMessage = "Compare LogicData를 저장하는데 실패했습니다.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SavePlcInfoS Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool OpenBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            CBaseData cBaseData = (CBaseData)(cSerializer.Read(sPath));
            if (cBaseData != null)
            {
                m_cBaseData = cBaseData;
                m_sProjectBaseFolder = System.Windows.Forms.Application.StartupPath + "\\" + m_cBaseData.ProjectID;
                m_cBaseData.ProjectPath = sPath;

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            return bOK;
        }

        private static bool SaveBaseInfo(string sPath)
        {
            bool bOK = false;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cBaseData);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private static bool OpenAnalyzeData(string sPath)
        {
            bool bOK = false;

            if (m_cAnalyzeDataS == null) return false;

            string sFilePath = string.Format("{0}\\AnalyzeData.ald", sPath);
            if (File.Exists(sFilePath) == false) return bOK;

            CNetSerializer cSerializer = new CNetSerializer();
            CAnalyzeDataS cData = (CAnalyzeDataS)(cSerializer.Read(sPath));
            if (cData != null)
            {
                m_cAnalyzeDataS = cData;

                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }

            return bOK;
        }

        private static bool SaveAnalyzeData(string sPath)
        {
            bool bOK = false;

            if (m_cAnalyzeDataS == null) return bOK;

            string sFilePath = string.Format("{0}\\AnalyzeData.ald", sPath);
            if (File.Exists(sFilePath) == false) return bOK;

            CNetSerializer cSerializer = new CNetSerializer();

            bOK = cSerializer.Write(sPath, m_cAnalyzeDataS);

            cSerializer.Dispose();
            cSerializer = null;

            return bOK;
        }

        private static List<string> OpenPlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            if (m_cPlcLogicDataS == null)
                m_cPlcLogicDataS = new CPlcLogicDataS();
            else
                m_cPlcLogicDataS.Clear();

            List<string> sLoadError = new List<string>();
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(lstPlcID, sID =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                string sFilePath = sPath + "\\" + sID + ".pcd";
                string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO" + ".pcd";
                string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO" + ".pcd";

                try
                {
                    if (File.Exists(sFilePath))
                    {
                        CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sFilePath));
                        if (cPlcLogicData != null)
                        {
                            cPlcLogicData.Compose();
                            m_cPlcLogicDataS.Add(cPlcLogicData.PLCID, cPlcLogicData);
                        }
                        else
                            sLoadError.Add(sFilePath);

                        cSerializer.Dispose();
                        cSerializer = null;

                    }
                    else if (File.Exists(sFileStepPath))
                    {
                        CPlcLogicData cData = new CPlcLogicData();
                        cData.PLCID = sID;
                        cData.TagS = (CTagS)(cSerializer.Read(sFileTagPath));

                        if (cData.TagS == null)
                            sLoadError.Add(sFileTagPath);

                        else
                        {
                            cData.Maker = cData.TagS.Values.First().PLCMaker;
                            cData.PlcChannel = cData.TagS.Values.First().Channel;
                        }

                        cData.StepS = (CStepS)(cSerializer.Read(sFileStepPath));

                        if (cData.StepS == null)
                            sLoadError.Add(sFileStepPath);

                        cData.Compose();
                        m_cPlcLogicDataS.Add(cData.PLCID, cData);

                        cSerializer.Dispose();
                        cSerializer = null;
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        private static List<string> OpenComparePlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            if (m_cLogicSCompare1 == null)
                m_cLogicSCompare1 = new CPlcLogicDataS();
            else
                m_cLogicSCompare1.Clear();

            List<string> sLoadError = new List<string>();
            var exceptions = new ConcurrentQueue<Exception>();

            Parallel.ForEach(lstPlcID, sID =>
            {
                CNetSerializer cSerializer = new CNetSerializer();
                string sFilePath = sPath + "\\" + sID + "_Compare" + ".pcd";
                string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO_Compare" + ".pcd";
                string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO_Compare" + ".pcd";

                try
                {
                    if (File.Exists(sFilePath))
                    {
                        CPlcLogicData cPlcLogicData = (CPlcLogicData)(cSerializer.Read(sFilePath));
                        if (cPlcLogicData != null)
                        {
                            cPlcLogicData.Compose();
                            m_cLogicSCompare1.Add(cPlcLogicData.PLCID, cPlcLogicData);
                        }
                        else
                            sLoadError.Add(sFilePath);

                        cSerializer.Dispose();
                        cSerializer = null;

                    }
                    else if (File.Exists(sFileStepPath))
                    {
                        CPlcLogicData cData = new CPlcLogicData();
                        cData.PLCID = sID;
                        cData.TagS = (CTagS)(cSerializer.Read(sFileTagPath));

                        if (cData.TagS == null)
                            sLoadError.Add(sFileTagPath);
                        else
                        {
                            foreach (var who in cData.TagS)
                            {
                                who.Value.Creator = cData.PLCID;
                            }
                        }

                        cData.StepS = (CStepS)(cSerializer.Read(sFileStepPath));

                        if (cData.StepS == null)
                            sLoadError.Add(sFileStepPath);

                        cData.Compose();
                        m_cLogicSCompare1.Add(cData.PLCID, cData);

                        cSerializer.Dispose();
                        cSerializer = null;
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            });

            if (exceptions.Count > 0) throw new AggregateException(exceptions);

            return sLoadError;
        }

        private static List<string> SavePlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            List<string> lstResult = new List<string>();
            if (m_cPlcLogicDataS == null)
                lstResult.Add("m_cPlcLogicDataS = null");
            else
            {
                var exceptions = new ConcurrentQueue<Exception>();

                string[] saExistFiles = Directory.GetFiles(sPath);
                foreach (string sfile in saExistFiles)
                {
                    if (sfile.Contains("pcd"))  // 기존pcd 파일 삭제
                    {
                        File.Delete(sfile);
                    }
                }

                foreach (string sID in lstPlcID)
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO" + ".pcd";
                    string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO" + ".pcd";

                    if (m_cPlcLogicDataS.ContainsKey(sID))
                    {
                        bool bOK = cSerializer.Write(sFileTagPath, m_cPlcLogicDataS[sID].TagS);

                        if (bOK == false)
                            lstResult.Add(sFileTagPath);

                        bOK = cSerializer.Write(sFileStepPath, m_cPlcLogicDataS[sID].StepS);

                        if (bOK == false)
                            lstResult.Add(sFileStepPath);
                    }
                    else
                        lstResult.Add(sID + "  Not Found !! ");

                    cSerializer.Dispose();
                    cSerializer = null;
                }
                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }

            return lstResult;
        }

        private static List<string> SaveComparePlcLogicDataList(List<string> lstPlcID, string sPath)
        {
            List<string> lstResult = new List<string>();
            if (m_cLogicSCompare1 == null)
                lstResult.Add("CompareLogic = null");
            else
            {
                var exceptions = new ConcurrentQueue<Exception>();

                foreach (string sID in lstPlcID)
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    string sFileTagPath = sPath + "\\" + sID + "_TAG_INFO_Compare" + ".pcd";
                    string sFileStepPath = sPath + "\\" + sID + "_STEP_INFO_Compare" + ".pcd";

                    if (m_cLogicSCompare1.ContainsKey(sID))
                    {
                        bool bOK = cSerializer.Write(sFileTagPath, m_cLogicSCompare1[sID].TagS);

                        if (bOK == false)
                            lstResult.Add(sFileTagPath);

                        bOK = cSerializer.Write(sFileStepPath, m_cLogicSCompare1[sID].StepS);

                        if (bOK == false)
                            lstResult.Add(sFileStepPath);
                    }
                    else
                        lstResult.Add(sID + "  Not Found !! ");

                    cSerializer.Dispose();
                    cSerializer = null;
                }
                if (exceptions.Count > 0) throw new AggregateException(exceptions);
            }

            return lstResult;
        }

        #region Zip

        private static bool ZipCompression(string sFolderPath)
        {
            bool bOK = false;
            try
            {
                ZipFile zip = new ZipFile();
                zip.UseUnicodeAsNecessary = true;
                zip.AddDirectory(sFolderPath);
                zip.Save(sFolderPath + ".umpp");

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
                Console.WriteLine("DeleteProjectFolder Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool CopyAndPasteFolder(string sCopyPath, string sPastePath)
        {
            bool bOK = false;

            try
            {
                if (!Directory.Exists(sPastePath))
                    Directory.CreateDirectory(sPastePath);

                string[] sFiles = Directory.GetFiles(sCopyPath);
                string[] sFolders = Directory.GetDirectories(sCopyPath);

                string sName = string.Empty;
                string sDest = string.Empty;

                foreach (string sFile in sFiles)
                {
                    sName = Path.GetFileName(sFile);

                    if (sName.Contains(".umpp"))
                        continue;

                    sDest = Path.Combine(sPastePath, sName);

                    if (!File.Exists(sDest))
                        File.Copy(sFile, sDest);

                    bOK = true;
                }

                foreach (string sFolder in sFolders)
                {
                    sName = Path.GetFileName(sFolder);
                    sDest = Path.Combine(sPastePath, sName);
                    bOK = CopyAndPasteFolder(sFolder, sDest);

                    if (!bOK)
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteProjectFolder Error " + ex.Message);
                ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        private static bool ExtractFileToDirectory(string sZipPath, string sDirectory)
        {
            bool bOK = false;

            try
            {
                ZipFile zip = new ZipFile(sZipPath);

                if (Directory.Exists(sDirectory))
                    Directory.Delete(sDirectory, true);

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

        private static string GetProjectFilePath(string sFolderPath)
        {
            string sPath = string.Empty;

            string[] sFiles = Directory.GetFiles(sFolderPath);

            string sName = string.Empty;

            foreach (string sFile in sFiles)
            {
                sName = Path.GetFileName(sFile);

                if (sName.Contains(".umpp"))
                {
                    sPath = sName;
                    break;
                }
            }

            sPath = sFolderPath + "\\" + sPath;

            return sPath;
        }

        #endregion

        #endregion


    }
}
