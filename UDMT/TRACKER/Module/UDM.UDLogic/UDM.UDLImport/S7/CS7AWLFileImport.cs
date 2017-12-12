using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CS7AWLFileImport
    {
        protected List<string> m_lstAWLFile = null;
        protected Dictionary<string,CUDLUDT> m_lstUDT = null;
        protected Dictionary<string,CUDLBlock> m_lstBlock = null;

        protected CS7UDLBlockAnalysis m_cBlockAnalysis = null;
        protected CS7UDLDBAnalysis m_cDBAnalysis = null;
        protected CS7UDLUDTAnalysis m_cUDTAnalysis = null;
        protected Dictionary<string, CInstruction> m_DicInstructionList = null;
        protected Dictionary<string, CUDLBlock> m_dicSystemFunctS = null;
        protected List<string> m_lstAnalysisDBName = null;
        protected List<string> m_lstProtectedFBList = null;

        #region Initialze/Dispose

        public CS7AWLFileImport(List<string> sFile,Dictionary<string,CInstruction> tempDicints,List<CUDLTag> udlTag,List<string> AnalysisDBS,CUDL temUDL)
        {
            m_lstAWLFile = sFile;
            m_lstAnalysisDBName = AnalysisDBS;
            m_lstUDT = temUDL.UDTs;
            m_lstBlock = temUDL.Blocks;
            m_DicInstructionList = tempDicints;
            m_cBlockAnalysis = new CS7UDLBlockAnalysis(tempDicints);
            m_cDBAnalysis = new CS7UDLDBAnalysis(m_lstAnalysisDBName);
            m_cUDTAnalysis = new CS7UDLUDTAnalysis();
            CSfcXmlOpen systemFucnAnaly = new CSfcXmlOpen(EMPLCMaker.Siemens);
            m_dicSystemFunctS = systemFucnAnaly.SystemBlockS;
           

            m_cBlockAnalysis.UDTList = m_lstUDT;
            m_cBlockAnalysis.BlockList = m_lstBlock;
            m_cBlockAnalysis.TagList = udlTag;
            m_cBlockAnalysis.SystemFunctionS = m_dicSystemFunctS;

            m_cDBAnalysis.UDTList = m_lstUDT;
            m_cDBAnalysis.BlockList = m_lstBlock;
            m_cDBAnalysis.TagList = udlTag;
            m_cDBAnalysis.SystemFunctionS = m_dicSystemFunctS;

            m_cUDTAnalysis.UDTList = m_lstUDT;

            m_lstProtectedFBList = m_cBlockAnalysis.ProtectedFBList;
            temUDL.ProtectedFBList = m_lstProtectedFBList;
        }

        #endregion

        #region Public Properites

        public Dictionary<string,CUDLUDT> UDTList
        {
            get { return m_lstUDT; }
            set { m_lstUDT = value; }
        }

        public Dictionary<string, CUDLBlock> BlockList
        {
            get { return m_lstBlock; }
            set { m_lstBlock = value; }
        }

        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }

        #endregion

        #region Public Methods

        public void AWLFileAnalysis()
        {
            try
            {
                int iCount = m_lstAWLFile.Count;

                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, "Start UDL Analysis");

                for(int i=0;i<iCount;i++)
                {
                    if(m_lstAWLFile[i].StartsWith("DATA_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lstFilePart = new List<string>();
                        lstFilePart.Add(m_lstAWLFile[i]);

                        while(m_lstAWLFile[j]!="END_DATA_BLOCK")
                        {
                            lstFilePart.Add(m_lstAWLFile[j]);
                            j++;
                        }

                        lstFilePart.Add(m_lstAWLFile[j]);
                        i = j;

                        m_cDBAnalysis.DatablockAnalysis(lstFilePart);

                        lstFilePart.Clear();
                    }
                    else if (m_lstAWLFile[i].StartsWith("FUNCTION_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lstFilePart = new List<string>();
                        lstFilePart.Add(m_lstAWLFile[i]);

                        while (m_lstAWLFile[j] != "END_FUNCTION_BLOCK")
                        {
                            lstFilePart.Add(m_lstAWLFile[j]);
                            j++;
                        }

                        lstFilePart.Add(m_lstAWLFile[j]);
                        i = j;

                        m_cBlockAnalysis.BlockAnalysis(lstFilePart);

                        lstFilePart.Clear();
                    }
                    else if(m_lstAWLFile[i].StartsWith("FUNCTION"))
                    {
                        int j = i + 1;
                        List<string> lstFilePart = new List<string>();
                        lstFilePart.Add(m_lstAWLFile[i]);

                        while (m_lstAWLFile[j] != "END_FUNCTION")
                        {
                            lstFilePart.Add(m_lstAWLFile[j]);
                            j++;
                        }

                        lstFilePart.Add(m_lstAWLFile[j]);
                        i = j;

                        m_cBlockAnalysis.BlockAnalysis(lstFilePart);

                        lstFilePart.Clear();
                    }
                    else if(m_lstAWLFile[i].StartsWith("TYPE"))
                    {
                        int j = i + 1;
                        List<string> lstFilePart = new List<string>();
                        lstFilePart.Add(m_lstAWLFile[i]);

                        while (m_lstAWLFile[j] != "END_TYPE")
                        {
                            lstFilePart.Add(m_lstAWLFile[j]);
                            j++;
                        }

                        lstFilePart.Add(m_lstAWLFile[j]);
                        i = j;

                        m_cUDTAnalysis.UDTListAnalysis(lstFilePart);

                        lstFilePart.Clear();
                    }
                    else if(m_lstAWLFile[i].StartsWith("ORGANIZATION_BLOCK"))
                    {
                        int j = i + 1;
                        List<string> lstFilePart = new List<string>();
                        lstFilePart.Add(m_lstAWLFile[i]);

                        while (m_lstAWLFile[j] != "END_ORGANIZATION_BLOCK")
                        {
                            lstFilePart.Add(m_lstAWLFile[j]);
                            j++;
                        }

                        lstFilePart.Add(m_lstAWLFile[j]);
                        i = j;

                        m_cBlockAnalysis.BlockAnalysis(lstFilePart);
                        lstFilePart.Clear();
                    }
                }

                string sLogMassage = string.Format("Finish UDL Analysis. Created {0} Tags, {1} Blocks", m_cBlockAnalysis.TagList.Count, m_cBlockAnalysis.BlockList.Count);
                CConverterLogWriter.WriteLogEvent(System.Reflection.MethodBase.GetCurrentMethod().Name, sLogMassage);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
