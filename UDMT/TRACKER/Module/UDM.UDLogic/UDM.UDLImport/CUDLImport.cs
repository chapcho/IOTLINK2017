using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CUDLImport
    {
        CFileOpen m_cFileOpen = null;

        protected List<string> m_lstFile = null;
        protected DataSet m_dbMelsecCSV = null;
        protected CABL5KAnalysis m_cABConvert = null;
        protected CMelsecILConvert m_cMelsecILConvert = null;
        protected DataSet m_dbLS = null;
        protected CLSILConvert m_cLSILConvert = null;
        protected EMPLCMaker m_emPLCMaker;
        protected CTagS m_cGlobalTagS = null;
        protected CTagS m_cLocalTagS = null;
        protected CStepS m_cStepS = null;
        protected CUDL m_cUDL = new CUDL();
        protected Dictionary<string, CInstruction> m_DicInstructionList = null;
        protected Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;
        protected List<string> m_lstProtectedFBList = null;
        protected List<string> m_lstAnalysisDBName = new List<string>();
        protected string m_sChannel = "CH.DV";
        protected bool m_bFileOpenCheck = false;
        protected bool m_bLsDDEA = false;

        #region Initialize/Dispose

        public CUDLImport(EMPLCMaker emMaker, bool bTagGenerate)
        {
            m_cFileOpen = new CFileOpen(emMaker, bTagGenerate);

            m_bFileOpenCheck = m_cFileOpen.FileOpenCheck;

            if (m_bFileOpenCheck)
            {
                m_emPLCMaker = m_cFileOpen.PLCMaker;
                CInstruXmlOpen xmlOpen = new CInstruXmlOpen(m_emPLCMaker);
                m_DicInstructionList = xmlOpen.DicInstructionList;

                if (xmlOpen.DicRepeatedInstructionList != null)
                    m_DicRepeatedInstructionList = xmlOpen.DicRepeatedInstructionList;
            }
        }

        public CUDLImport(CFileOpen cFileOpen)
        {
            m_cFileOpen = cFileOpen;
            m_bFileOpenCheck = m_cFileOpen.FileOpenCheck;

            if (m_bFileOpenCheck)
            {
                m_emPLCMaker = m_cFileOpen.PLCMaker;
                CInstruXmlOpen xmlOpen = new CInstruXmlOpen(m_emPLCMaker);
                m_DicInstructionList = xmlOpen.DicInstructionList;

                if (xmlOpen.DicRepeatedInstructionList != null)
                    m_DicRepeatedInstructionList = xmlOpen.DicRepeatedInstructionList;
            }
        }
        
        #endregion

        #region Properties

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

        public CLSILConvert DEBUG_LS
        {
            get { return m_cLSILConvert; }
        }

        public CMelsecILConvert DEBUG_Melsec
        {
            get { return m_cMelsecILConvert; }
        }

        public bool FileOpenCheck
        {
            get { return m_bFileOpenCheck; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
        }

        public CTagS GlobalTags
        {
            get { return m_cGlobalTagS; }
        }
        public CTagS LocalTags
        {
            get { return m_cLocalTagS; }
        }
        public CUDL CUDL
        {
            get { return m_cUDL; }
        }

        public Dictionary<string, CInstruction> DicInstructionList
        {
            get { return m_DicInstructionList; }
        }

        public Dictionary<string, List<CInstruction>> DicRepeatedInstructionList
        {
            get { return m_DicRepeatedInstructionList; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }

        public bool LsDDEAConnect
        {
            get { return m_bLsDDEA; }
            set { m_bLsDDEA = value; }
        }

        public bool IsNeedLog
        {
            get { return CConverterLogWriter.bIsNeedLog; }
            set { CConverterLogWriter.bIsNeedLog = value; }
        }

        public CFileOpen FileOpenClass
        {
            get { return m_cFileOpen; }
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// bSymbolTag가 true면 Key에 Symbol이 포함, false면 Address가 포함
        /// </summary>
        /// <param name="bAddressTag"></param>
        /// <returns></returns>
        public bool UDLGenerate()
        {
            bool bOK = false;
            try
            {
                CConverterLogWriter.WrteFileStart();

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                    CreateSiemensUDL();
                else if (m_emPLCMaker == EMPLCMaker.LS)
                    CreateLSUDL();
                else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    CreateMelsecUDL();
                else if (m_emPLCMaker == EMPLCMaker.Rockwell)
                    CreateABUDL();

                CUDLConvert cUDLConverter = new CUDLConvert(m_cUDL, m_emPLCMaker); // True is Address key False is symbol Key

                cUDLConverter.Channel = m_sChannel;

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                    cUDLConverter.AnalysisDBS = m_lstAnalysisDBName;

                bOK = cUDLConverter.CreateGlobalTagS(true, m_bLsDDEA);
                bOK = cUDLConverter.CreateLocalTagS(true);

                m_cGlobalTagS = cUDLConverter.GlobalTagS;
                //m_cLocalTagS = cUDLConverter.LocalTagS;

                cUDLConverter.LogicAnalysis();

                //m_cGlobalTagS = cUDLConverter.UsedGlobalTagS;
                m_cStepS = cUDLConverter.StepS;

                CConverterLogWriter.WriteFileEnd();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                return false;
            }
            return bOK;
        }

        public bool MakeGlobelAndLocalTags()
        {
            bool bOK = false;
            try
            {
                CConverterLogWriter.WrteFileStart();

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                    CreateSiemensUDL();
                else if (m_emPLCMaker == EMPLCMaker.LS)
                    CreateLSUDL();
                else if (m_emPLCMaker.ToString().Contains("Mitsubishi"))
                    CreateMelsecUDL();
                else if (m_emPLCMaker == EMPLCMaker.Rockwell)
                    CreateABUDL();

                CUDLConvert cUDLConverter = new CUDLConvert(m_cUDL, m_emPLCMaker); // True is Address key False is symbol Key

                cUDLConverter.Channel = m_sChannel;

                if (m_emPLCMaker == EMPLCMaker.Siemens)
                    cUDLConverter.AnalysisDBS = m_lstAnalysisDBName;

                //bOK = cUDLConverter.CreateLocalTagS(false);
                bOK = cUDLConverter.CreateGlobalTagS(true, m_bLsDDEA);
                
                m_cGlobalTagS = cUDLConverter.GlobalTagS;
                //m_cLocalTagS = cUDLConverter.LocalTagS;

                CConverterLogWriter.WriteFileEnd();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return bOK;
        }

        #endregion

        #region Private Methods

        private void CreateABUDL()
        {
            try
            {
                m_lstFile = m_cFileOpen.L5kFile;
                m_cABConvert = new CABL5KAnalysis(m_lstFile, m_DicInstructionList, m_DicRepeatedInstructionList);

                m_cUDL = m_cABConvert.UDL;

                //CreateCommonClass();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateMelsecUDL()
        {
            try
            {
                m_dbMelsecCSV = m_cFileOpen.dbMelsecCSV;

                m_cMelsecILConvert = new CMelsecILConvert(m_dbMelsecCSV, m_DicInstructionList, m_DicRepeatedInstructionList);
                m_cUDL = m_cMelsecILConvert.UDL;

                //CreateCommonClass();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateLSUDL()
        {
            try
            {
                m_dbLS = m_cFileOpen.dbLS;

                m_cLSILConvert = new CLSILConvert();
                m_cLSILConvert.Channel = m_sChannel;
                m_cLSILConvert.CreateInit(m_dbLS, m_DicInstructionList, m_DicRepeatedInstructionList);
                m_cUDL = m_cLSILConvert.UDL;

                //CreateCommonClass();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateCommonClass()
        {
            try
            {
                CUDLConvert cUDLConvert = new CUDLConvert(m_cUDL, m_emPLCMaker);

                cUDLConvert.Channel = m_sChannel;

                cUDLConvert.CreateGlobalTagS(true, m_bLsDDEA);
                cUDLConvert.CreateLocalTagS(true);

                //m_cTagS = cUDLConvert.GlobalTagS;
                m_cStepS = cUDLConvert.StepS;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void CreateSiemensUDL()
        {
            try
            {
                m_lstFile = m_cFileOpen.SDFFile;

                CS7TagImport cS7TagImprot = new CS7TagImport(m_lstFile);
                cS7TagImprot.TagFileAnalysis();
                m_cUDL.Tags = cS7TagImprot.UDLTagList;

                m_lstFile = m_cFileOpen.AWLFile;

                if (m_lstFile != null)
                {
                    CS7AWLFileImport cS7AWlIm = new CS7AWLFileImport(m_lstFile, m_DicInstructionList,
                        cS7TagImprot.UDLTagList, m_lstAnalysisDBName, m_cUDL);
                    cS7AWlIm.AWLFileAnalysis();
                }

                //if (cS7AWlIm.UDTList.Count > 0)
                //    m_cUDL.UDTs = cS7AWlIm.UDTList;

                //if (cS7AWlIm.BlockList.Count > 0)
                //    m_cUDL.Blocks = cS7AWlIm.BlockList;

                //if (cS7AWlIm.ProtectedFBList.Count > 0)
                //    m_cUDL.ProtectedFBList = cS7AWlIm.ProtectedFBList;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

       

        #endregion


    }
}
