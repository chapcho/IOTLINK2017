using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;
using UDM.General.Serialize;

namespace UDMIOMaker
{
    public static class CProjectManager
    {
        private static string m_sVerifPath = Application.StartupPath + "\\ExcelTemplate\\PLCVerification_Template.xls";
        private static string m_sVerifPathUser = System.Windows.Forms.Application.StartupPath + "\\ExcelTemplate\\PLCVerification_User_Template.xls";
        private static string m_sSysLogPath = Application.StartupPath + "\\IOMakerSystemLog";

        private static string m_sMappingLogPath = Application.StartupPath + "\\IOMakerMappingLog";

        private static string m_sSTDLibraryPath = Application.StartupPath + "\\IO_Maker_표준_라이브러리.csv";

        private static string m_sMelsecModuleConfigPath = Application.StartupPath + "\\Configuration\\ModuleConfig_Melsec.xml";
        private static string m_sABModuleConfigPath = Application.StartupPath + "\\Configuration\\ModuleConfig_AB.xml";
        private static string m_sS7ModuleConfigPath = Application.StartupPath + "\\Configuration\\ModuleConfig_S7.xml";

        private static string m_sIOListPath = Application.StartupPath + "\\ExcelTemplate\\IO_LIST_TEMP.xls";
        private static string m_sDummyListPath = Application.StartupPath + "\\ExcelTemplate\\DUMMY_LIST_TEMP.xls";

        private static CSystemLog m_cSysLog = null;
        private static CSystemLog m_cMappingLog = null;
        private static CProject m_cProject = null;

        private static Dictionary<string, CVerifTagS> m_dicAutoMappingPLCTagS = new Dictionary<string, CVerifTagS>();
        

        private static string m_sProjectPath = string.Empty;
        private static bool m_bDialogCancel = false;
        private static bool m_bOptionApply = true;


        #region Initialize/Dispose

        #endregion

        #region Properties

        public static List<CReportElement> ReportElementS
        {
            get { return m_cProject.ReportElementS; }
            set { m_cProject.ReportElementS = value; }
        }

        public static string IOListPath
        {
            get { return m_sIOListPath;}
            set { m_sIOListPath = value; }
        }

        public static string DummyListPath
        {
            get { return m_sDummyListPath;}
            set { m_sDummyListPath = value; }
        }

        public static string ProjectPath
        {
            get { return m_sProjectPath; }
            set { m_sProjectPath = value; }
        }

        public static EMIOMakerMode IOMakerMode
        {
            get { return m_cProject.IOMakerMode; }
            set { m_cProject.IOMakerMode = value; }
        }

        public static string MelsecModuleConfigPath
        {
            get { return m_sMelsecModuleConfigPath;}
            set { m_sMelsecModuleConfigPath = value; }
        }

        public static string ABModuleConfigPath
        {
            get { return m_sABModuleConfigPath;}
            set { m_sABModuleConfigPath = value; }
        }

        public static string S7ModuleConfigPath
        {
            get { return m_sS7ModuleConfigPath; }
            set { m_sS7ModuleConfigPath = value; }
        }


        public static CErrorFilterS ErrorFilterS
        {
            get { return m_cProject.ErrorFilterS; }
            set { m_cProject.ErrorFilterS = value; }
        }

        public static string StdLibraryPath
        {
            get { return m_sSTDLibraryPath; }
            set { m_sSTDLibraryPath = value; }
        }

        public static CStdS StdS
        {
            get { return m_cProject.StdS; }
            set { m_cProject.StdS = value; }
        }

        public static CStdTagS StdTagS
        {
            get { return m_cProject.StdTagS; }
            set { m_cProject.StdTagS = value; }
        }

        public static Dictionary<string, CVerifTagS> AutoMappingPLCTagS
        {
            get { return m_dicAutoMappingPLCTagS; }
            set { m_dicAutoMappingPLCTagS = value; }
        }

        public static Dictionary<string, CConvertUnitS> GroupConvertUnitS
        {
            get { return m_cProject.GroupConvertUnitS; }
            set { m_cProject.GroupConvertUnitS = value; }
        }

        public static bool IsOptionApply
        {
            get { return m_bOptionApply; }
            set { m_bOptionApply = value; }
        }

        public static string VerifPath
        {
            get { return m_sVerifPath;}
            set { m_sVerifPath = value; }
        }

        public static string VerifPathUser
        {
            get { return m_sVerifPathUser; }
            set { m_sVerifPathUser = value; }
        }

        public static bool DialogCancel
        {
            get { return m_bDialogCancel;}
            set { m_bDialogCancel = value; }
        }

        public static CSystemLog SysemLogWriter
        {
            get { return m_cSysLog; }
            set { m_cSysLog = value; }
        }

        public static CProject Project
        {
            get { return m_cProject;}
            set { m_cProject = value; }
        }

        public static CHMITagS HMITagS
        {
            get { return m_cProject.HMITagS; }
            set { m_cProject.HMITagS = value; }
        }

        public static CTagS PLCTagS
        {
            get { return m_cProject.PLCTagS; }
            set { m_cProject.PLCTagS = value; }
        }

        public static CVerifTagS VerifTagS
        {
            get { return m_cProject.VerifTagS; }
            set { m_cProject.VerifTagS = value; }
        }

        public static CPlcLogicDataS LogicDataS
        {
            get { return m_cProject.LogicDataS; }
            set { m_cProject.LogicDataS = value; }
        }

        #endregion

        #region Public Methods

        public static void UpdateSystemMessage(string sSender, string sMessage)
        {
            try
            {
                if (m_cSysLog == null)
                    m_cSysLog = new CSystemLog(m_sSysLogPath, "IO Maker");

                m_cSysLog.WriteLog(sSender, sMessage);
            }
            catch (System.Exception ex)
            {
                m_cSysLog.WriteLog("Error Message", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        public static void UpdateMappingMessage(EMMappingMessage emMessage, CTag cPLCTag, CHMITag cHMITag)
        {
            try
            {
                string sMessage = string.Empty;

                switch (emMessage)
                {
                    case EMMappingMessage.Mapping_Cancel:
                        sMessage = string.Format("HMI (Name : {0}, Description : {1} ) {2}", cHMITag.Name,
                            cHMITag.Description, emMessage.ToString());
                        break;
                    default:
                        sMessage =
                            string.Format(
                                "PLC ( Address : {0}, Description : {1}, Name : {2}) - HMI ( Name : {3}, Description : {4} ) {5}",
                                cPLCTag.Address, cPLCTag.Description, cPLCTag.Name, cHMITag.Name, cHMITag.Description,
                                emMessage.ToString());
                        break;
                }

                if (m_cMappingLog == null)
                    m_cMappingLog = new CSystemLog(m_sMappingLogPath, "IO Maker");

                m_cMappingLog.WriteLog(emMessage.ToString(), sMessage);
            }
            catch (System.Exception ex)
            {
                m_cSysLog.WriteLog("Mapping Log Error Message", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                ex.Data.Clear();
            }
        }

        public static bool Open()
        {
            bool bOK = false;

            try
            {
                m_bDialogCancel = false;

                OpenFileDialog dlgOpen = new OpenFileDialog();
                dlgOpen.Filter = @"IO Maker Project Files(*.uim)|*.uim";

                if (dlgOpen.ShowDialog() == DialogResult.Cancel)
                {
                    m_bDialogCancel = true;
                    return false;
                }

                string sPath = dlgOpen.FileName;

                if (sPath == string.Empty)
                {
                    m_bDialogCancel = true;
                    return false;
                }

                m_cProject.Clear();
                m_cProject = null;

                CNetSerializer cSerializer = new CNetSerializer();
                m_cProject = (CProject) (cSerializer.Read(sPath));

                if (m_cProject == null)
                    return false;

                m_sProjectPath = sPath;
                cSerializer.Dispose();
                cSerializer = null;

                bOK = true;
            }
            catch (System.Exception ex)
            {
                m_cSysLog.WriteLog("Error Message", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                bOK = false;
                ex.Data.Clear();
            }
            return bOK;
        }

        public static bool Save()
        {
            bool bOK = false;

            try
            {
                if (m_sProjectPath != string.Empty)
                {
                    CNetSerializer cSerializer = new CNetSerializer();
                    bOK = cSerializer.Write(m_sProjectPath, m_cProject);

                    if (!bOK)
                        return false;

                    cSerializer.Dispose();
                    cSerializer = null;
                }
                else
                    bOK = SaveAs();

            }
            catch (System.Exception ex)
            {
                m_cSysLog.WriteLog("Error Message", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                bOK = false;
                ex.Data.Clear();
            }
            return bOK;
        }

        public static bool SaveAs()
        {
            bool bOK = false;

            try
            {
                m_bDialogCancel = false;

                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = @"IO Maker Project Files(*.uim)|*.uim";
                dlgSave.FileName = string.Format("{0}_{1}_", m_cProject.FactoryName, m_cProject.LineName);

                if (dlgSave.ShowDialog() == DialogResult.Cancel)
                {
                    m_bDialogCancel = true;
                    return false;
                }

                string sPath = dlgSave.FileName;

                if (sPath == string.Empty)
                {
                    m_bDialogCancel = true;
                    return false;
                }

                CNetSerializer cSerializer = new CNetSerializer();
                bOK = cSerializer.Write(sPath, m_cProject);

                if (!bOK)
                    return false;

                m_sProjectPath = sPath;

                cSerializer.Dispose();
                cSerializer = null;
            }
            catch (System.Exception ex)
            {
                m_cSysLog.WriteLog("Error Message", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                bOK = false;
                ex.Data.Clear();
            }
            return bOK;
        }


        #endregion

        #region Private Methods

        #endregion
        

    }
}
