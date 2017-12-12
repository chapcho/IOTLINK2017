using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.UDL;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CABL5KAnalysis
    {
        private List<string> m_lstFile = null;
        private CUDL m_cUDL = new CUDL();
        private Dictionary<string, CInstruction> m_DicInstructionList = null;
        private Dictionary<string, List<CInstruction>> m_DicRepeatedInstructionList = null;
        private List<string> m_lstNoFoundAlias = null;
        private int m_iSameNameModuleCount = 0;
        private string m_sChannel = "CH_DV";

        #region Initialize/Dispose

        public CABL5KAnalysis(List<string> lstFile, Dictionary<string, CInstruction> InstructionList, Dictionary<string, List<CInstruction>> RepeatedInstructionList)
        {
            m_lstFile = lstFile;
            m_DicInstructionList = InstructionList;
            m_DicRepeatedInstructionList = RepeatedInstructionList;
            m_lstNoFoundAlias = new List<string>();

            CreateABUDL();
        }

        #endregion

        #region Properties

        public CUDL UDL
        {
            get { return m_cUDL; }
        }

        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        #endregion

        #region Public Methods

        public CTagS CreateABTagS() //완성 X
        {
            CTagS cTagS = null;

            try
            {
                cTagS = new CTagS();
                CTag cTag = null;

                foreach(CUDLTag UDLTag in m_cUDL.Tags)
                {
                    cTag = new CTag();

                    cTag.Channel = "["+ m_sChannel +"]";
                }


            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTagS;
        }

        #endregion

        #region Private Methods

        private void CreateABUDL()
        {
            string sLineDebug = string.Empty;

            try
            {
                for(int iLine = 0 ; iLine < m_lstFile.Count ; iLine++)
                {
                    sLineDebug = m_lstFile[iLine];

                    if (m_lstFile[iLine].StartsWith("CONTROLLER"))
                        m_cUDL.ProjectName = GetName(m_lstFile[iLine], "CONTROLLER"); 
                    else if (m_lstFile[iLine].StartsWith("DATATYPE"))
                        iLine = MakeDATATYPE(iLine);
                    else if (m_lstFile[iLine].StartsWith("MODULE"))
                        iLine = MakeMODULE(iLine);
                    else if (m_lstFile[iLine].StartsWith("TAG"))
                        iLine = MakeTAG(iLine);
                    else if (m_lstFile[iLine].StartsWith("PROGRAM"))
                        iLine = MakePROGRAM(iLine);
                    else if (m_lstFile[iLine].StartsWith("ADD_ON_INSTRUCTION_DEFINITION"))
                        iLine = MakeADD_ON_INSTRUCTION(iLine);
                }
            }
            catch(System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name, sLineDebug);
                ex.Data.Clear();
            }
        }

        private int MakeDATATYPE(int iLine)
        {
            int iDATATYPE_END = iLine;

            try
            {               

                CUDLUDT cUDT = new CUDLUDT();
                cUDT.UDTName = GetName(m_lstFile[iDATATYPE_END], "DATATYPE"); 

                while(!m_lstFile[iDATATYPE_END].StartsWith("END_DATATYPE"))
                {
                    string sLine = m_lstFile[iDATATYPE_END];

                    if (sLine.StartsWith("\t"))
                    {
                        CUDLTag cUDLTag = GetDataTypeTag(sLine);
                        cUDLTag.Program = string.Format("{0}.{1}", m_cUDL.ProjectName, cUDT.UDTName);
                        cUDT.MemTags.Add(cUDLTag);
                    }
                    iDATATYPE_END++;
                }
                m_cUDL.UDTs.Add(cUDT.UDTName,cUDT);                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iDATATYPE_END;
        }

        private int MakeMODULE(int iLine)
        {
            int iMODULE_END = iLine;

            try
            {
                CUDLModule cModule = new CUDLModule();
                cModule.ModuleName = GetName(m_lstFile[iMODULE_END], "MODULE");

                while(!m_lstFile[iMODULE_END].StartsWith("END_MODULE"))
                {
                    string sLine = m_lstFile[iMODULE_END];

                    if (sLine.Contains("CatalogNumber ") && !sLine.Contains("UserDefinedCatalogNumber"))
                    {
                        string sCatalogNum = string.Empty;
                        int iPos = sLine.IndexOf(":= \"")+4;

                        string sTemp =  sLine.Substring(iPos);

                        iPos = sTemp.IndexOf("\",");

                        sCatalogNum = sTemp.Remove(iPos);

                        cModule.CatalogNum = sCatalogNum;

                    }
                    else if(sLine.Contains("Parent "))
                    {
                        string sParent = string.Empty;
                        int iPos = sLine.IndexOf(":= \"") + 4;

                        string sTemp = sLine.Substring(iPos);

                        iPos = sTemp.IndexOf("\",");

                        sParent = sTemp.Remove(iPos);

                        cModule.Parent = sParent;
                    }
                    else if(sLine.Contains("Slot "))
                    {
                        string sSlotNum = string.Empty;

                        int iPos = sLine.IndexOf(":= ")+3;
                        string sTemp = sLine.Substring(iPos);
                        iPos = sTemp.IndexOf(",");

                        sSlotNum = sTemp.Remove(iPos);
                        cModule.Slot = sSlotNum;
                    }

                    iMODULE_END++;
                }

                if(m_cUDL.Modules.ContainsKey(cModule.ModuleName))
                {
                    m_iSameNameModuleCount++;
                    cModule.ModuleName = cModule.ModuleName + m_iSameNameModuleCount.ToString();
                }
                
                if(cModule.ModuleName!="")
                    m_cUDL.Modules.Add(cModule.ModuleName,cModule);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iMODULE_END;
        }

        private int MakeTAG(int iLine)
        {
            int iTAG_END = iLine + 1;

            try
            {
                if (m_cUDL.Tags == null)
                    m_cUDL.Tags = new List<CUDLTag>();

                CUDLTag cUDLTag = null;

                while(!m_lstFile[iTAG_END].StartsWith("END_TAG"))
                {
                    string sLine = string.Empty;

                    if(m_lstFile[iTAG_END].EndsWith(";"))
                    {
                        sLine = m_lstFile[iTAG_END];
                        cUDLTag = GetTag(sLine);
                        m_cUDL.Tags.Add(cUDLTag);
                    }
                    else
                    {
                        while(!m_lstFile[iTAG_END].EndsWith(";"))
                        {
                            sLine = sLine + m_lstFile[iTAG_END];
                            iTAG_END++;
                        }

                        sLine = sLine + m_lstFile[iTAG_END];
                        cUDLTag = GetTag(sLine);
                        m_cUDL.Tags.Add(cUDLTag);
                    }

                    //if (!m_lstFile[iTAG_END + 1].StartsWith(",") && !m_lstFile[iTAG_END + 1].StartsWith(" ")
                    //        && !m_lstFile[iTAG_END + 1].StartsWith("]") && !m_lstFile[iTAG_END + 1].StartsWith("TagForceData")
                    //        && !m_lstFile[iTAG_END + 1].StartsWith("\t\t") && !m_lstFile[iTAG_END + 1].StartsWith("\tTagForceData"))
                    //{
                    //    sLine = m_lstFile[iTAG_END];
                    //    cUDLTag = GetTag(sLine);
                    //    m_cUDL.Tags.Add(cUDLTag);
                    //}
                    //else
                    //{
                    //    while(m_lstFile[iTAG_END+1].StartsWith(",")|| m_lstFile[iTAG_END+1].StartsWith(" ") 
                    //        || m_lstFile[iTAG_END+1].StartsWith("]") || m_lstFile[iTAG_END+1].StartsWith("TagForceData")
                    //        || m_lstFile[iTAG_END+1].StartsWith("\t\t") || m_lstFile[iTAG_END+1].StartsWith("\tTagForceData"))
                    //    {
                    //        sLine = sLine + m_lstFile[iTAG_END];
                    //        iTAG_END++;
                    //    }

                    //    sLine = sLine + m_lstFile[iTAG_END];
                    //    cUDLTag = GetTag(sLine);
                    //    m_cUDL.Tags.Add(cUDLTag);
                    //}

                    iTAG_END++;
                }

                UnfoundAliasTagRework();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iTAG_END;
        }

        private int MakeLOCAL_TAG(int iLine, CUDLBlock cUDLBlock)
        {
            int iLOCAL_TAGS_END = iLine + 1;

            try
            {
                CUDLTag cUDLTag = null;

                while (!m_lstFile[iLOCAL_TAGS_END].StartsWith("END_TAG"))
                {
                    string sLine = m_lstFile[iLOCAL_TAGS_END];

                    if (!sLine.StartsWith(",") && !sLine.StartsWith(" ") && !sLine.StartsWith("]") && !sLine.StartsWith("TagForceData") && !sLine.StartsWith("\t\t") && !sLine.StartsWith("\tTagForceData"))
                    {
                        cUDLTag = GetTag(sLine);
                        cUDLBlock.TempTags.Add(cUDLTag);
                    }
                    iLOCAL_TAGS_END++;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return iLOCAL_TAGS_END;
        }

        private int MakePROGRAM(int iLine)
        {
            int iPROGRAM_END = iLine;

            try
            {
                CUDLBlock cUDLBlock = new CUDLBlock();
                cUDLBlock.BlockName = GetName(m_lstFile[iPROGRAM_END], "PROGRAM");
                cUDLBlock.BlockType = EMBlockType.Function;
                cUDLBlock.MainRoutine = GetMainRoutine(m_lstFile[iPROGRAM_END]);

                while(!m_lstFile[iPROGRAM_END].StartsWith("END_PROGRAM"))
                {
                    string sLine = m_lstFile[iPROGRAM_END];

                    if (sLine.StartsWith("ROUTINE"))
                        iPROGRAM_END = MakeROUTINE(iPROGRAM_END, cUDLBlock);
                    else if (sLine.StartsWith("TAG"))
                        iPROGRAM_END = MakeLOCAL_TAG(iPROGRAM_END, cUDLBlock);

                    iPROGRAM_END++;
                }
                m_cUDL.Blocks.Add(cUDLBlock.BlockName,cUDLBlock);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iPROGRAM_END;
        }

        private int MakeROUTINE(int iLine, CUDLBlock cBlock)
        {
            int iROUTINE_END = iLine;

            try
            {
                CUDLRoutine cRoutine = new CUDLRoutine();
                cRoutine.RoutineName = GetName(m_lstFile[iROUTINE_END], "ROUTINE");
                int iStepIndex = 0;

                while(!m_lstFile[iROUTINE_END].StartsWith("END_ROUTINE"))
                {
                    string sLine = m_lstFile[iROUTINE_END];

                    if(sLine.StartsWith("\t\tN: "))
                    {
                        CUDLLogic cLogic = new CUDLLogic();

                        while(!sLine.EndsWith(";"))
                        {
                            string sTemp = m_lstFile[iROUTINE_END+1];
                            sLine = sLine + sTemp;

                            iROUTINE_END++;
                        }

                        string sLogic = GetLogic(sLine);

                        cLogic.Logic = sLogic;
                        cLogic.StepIndex = iStepIndex;
                        cRoutine.Logics.Add(cLogic);
                        iStepIndex++;
                    }

                    iROUTINE_END++;
                }
                cBlock.Routines.Add(cRoutine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iROUTINE_END;
        }

        private int MakeADD_ON_INSTRUCTION(int iLine)
        {
            int iADD_ON_INSTRUCTION_END = iLine;

            try
            {               

                CUDLBlock cUDLBlock = new CUDLBlock();
                cUDLBlock.BlockName = GetName(m_lstFile[iADD_ON_INSTRUCTION_END], "ADD_ON_INSTRUCTION_DEFINITION");
                cUDLBlock.BlockType = EMBlockType.FunctionBlock;
                cUDLBlock.Comment = GetDescription(m_lstFile[iADD_ON_INSTRUCTION_END]);

                while (!m_lstFile[iADD_ON_INSTRUCTION_END].StartsWith("END_ADD_ON_INSTRUCTION_DEFINITION"))
                {
                    string sLine = m_lstFile[iADD_ON_INSTRUCTION_END];

                    if (sLine.StartsWith("PARAMETERS"))
                        iADD_ON_INSTRUCTION_END = MakePARAMETERS(iADD_ON_INSTRUCTION_END, cUDLBlock);
                    else if (sLine.StartsWith("LOCAL_TAGS"))
                        iADD_ON_INSTRUCTION_END = MakeLOCAL_TAGS(iADD_ON_INSTRUCTION_END, cUDLBlock);
                    else if (sLine.StartsWith("ROUTINE"))
                        iADD_ON_INSTRUCTION_END = MakeROUTINE(iADD_ON_INSTRUCTION_END, cUDLBlock);

                    iADD_ON_INSTRUCTION_END++;
                }
                m_cUDL.Blocks.Add(cUDLBlock.BlockName,cUDLBlock);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iADD_ON_INSTRUCTION_END;
        }

        private int MakeLOCAL_TAGS(int iLine, CUDLBlock cUDLBlock)
        {
            int iLOCAL_TAGS_END = iLine + 1;

            try
            {
                CUDLTag cUDLTag = null;

                while (!m_lstFile[iLOCAL_TAGS_END].StartsWith("END_LOCAL_TAGS"))
                {
                    string sLine = m_lstFile[iLOCAL_TAGS_END];

                    if (!sLine.StartsWith(",") && !sLine.StartsWith(" ") && !sLine.StartsWith("]") && !sLine.StartsWith("TagForceData"))
                    {
                        cUDLTag = GetTag(sLine);
                        cUDLBlock.TempTags.Add(cUDLTag);
                    }
                    iLOCAL_TAGS_END++;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return iLOCAL_TAGS_END;
        }

        private int MakePARAMETERS(int iLine, CUDLBlock cUDLBlock)
        {
            int iPARAMETERS_END = iLine + 1;

            try
            {
                CUDLTag cUDLTag = null;

                while (!m_lstFile[iPARAMETERS_END].StartsWith("END_PARAMETERS"))
                {
                    string sLine = m_lstFile[iPARAMETERS_END];

                    if (!sLine.StartsWith(",") && !sLine.StartsWith(" ") && !sLine.StartsWith("]") && !sLine.StartsWith("TagForceData"))
                    {
                        cUDLTag = new CUDLTag();
                        cUDLTag.Program = string.Format("{0}.{1}", m_cUDL.ProjectName, cUDLBlock.BlockName);
                        cUDLTag.PLCMaker = EMPLCMaker.Rockwell;

                        if (sLine.Contains("(Description := "))
                            cUDLTag.Description = GetDescription(sLine);

                        string sLineTagInformation = sTagLineEdit(sLine);

                        SetNormalTag(cUDLTag, sLineTagInformation,sLineTagInformation);
                    }

                    if (sLine.Contains("Usage := "))
                        SetPARAMETERSType(sLine, cUDLTag, cUDLBlock);

                    iPARAMETERS_END++;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return iPARAMETERS_END;
        }

        private void SetPARAMETERSType(string sLine, CUDLTag cUDLTag, CUDLBlock cUDLBlock)
        {
            try
            {
                string sType = GetUsage(sLine);

                switch(sType)
                {
                    case "Input": cUDLBlock.InputTags.Add(cUDLTag); break;
                    case "Output": cUDLBlock.OutputTags.Add(cUDLTag); break;
                    case "InOut": cUDLBlock.InOutTags.Add(cUDLTag); break;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetUsage(string sLine)
        {
            string sUsage = string.Empty;

            try
            {
                string IndexString = "Usage := ";
                int Index = sLine.IndexOf(IndexString);

                string sTemp = sLine.Remove(0, Index + IndexString.Length);

                if (sTemp.Contains(") := "))
                {
                    Index = sTemp.IndexOf(") := ");
                    sUsage = sTemp.Substring(0, Index);
                }
                else
                    sUsage = sTemp.Substring(0, sTemp.Length - 1);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sUsage;
        }

        private void MakeCommentGlobalTag(string sLine, CUDLTag ParentTag)
        {
            try
            {
                int iPos = sLine.IndexOf("(COMMENT");

                if (iPos == -1)
                    iPos = sLine.IndexOf(" COMMENT");

                string sParentName = GetUDLTagName(ParentTag);
                string sParentAddress = GetUDLTagAddress(ParentTag);

                if(iPos>-1)
                {
                    sLine = sLine.Substring(iPos + 8);
                    iPos = sLine.IndexOf(" := \"");
                    string sCommentAddress = sLine.Remove(iPos);

                    sLine = sLine.Substring(iPos + 5);

                    iPos = sLine.IndexOf("\",");
                    if (iPos == -1)
                        iPos = sLine.IndexOf("\")");

                    string sCommentDes = sLine.Remove(iPos);
                    sCommentDes = sCommentDes.Replace("$N", " ");

                    sLine = sLine.Substring(iPos + 2);

                    CUDLTag cCommentTag = new CUDLTag();

                    cCommentTag.Name = sParentName + sCommentAddress;
                    cCommentTag.Address = sParentAddress + sCommentAddress;
                    cCommentTag.Description = sCommentDes;
                    cCommentTag.Note = "COMMENT";

                    cCommentTag.Datatype = CommentTagDatatypeChecker(sCommentAddress, ParentTag);
                    cCommentTag.PLCMaker = EMPLCMaker.Rockwell;

                    if (ParentTag.Alias != string.Empty)
                        cCommentTag.Alias = sParentAddress + sCommentAddress;

                    m_cUDL.Tags.Add(cCommentTag);

                    while(sLine.Contains("  COMMENT"))
                    {
                        iPos = sLine.IndexOf("  COMMENT");
                        sLine = sLine.Substring(iPos + 9);

                        iPos = sLine.IndexOf(" := \"");
                        sCommentAddress = sLine.Remove(iPos);

                        sLine = sLine.Substring(iPos + 5);

                        iPos = sLine.IndexOf("\",");
                        if (iPos == -1)
                            iPos = sLine.IndexOf("\")");

                        sCommentDes = sLine.Remove(iPos);
                        sCommentDes = sCommentDes.Replace("$N", " ");

                        sLine = sLine.Substring(iPos + 2);

                        cCommentTag = new CUDLTag();

                        cCommentTag.Name = sParentName + sCommentAddress;
                        cCommentTag.Address = sParentAddress + sCommentAddress;
                        cCommentTag.Description = sCommentDes;
                        cCommentTag.Datatype = CommentTagDatatypeChecker(sCommentAddress, ParentTag);
                        cCommentTag.PLCMaker = EMPLCMaker.Rockwell;
                        cCommentTag.Note = "COMMENT";

                        if (ParentTag.Alias != string.Empty)
                            cCommentTag.Alias = sParentAddress + sCommentAddress;

                        m_cUDL.Tags.Add(cCommentTag);
                    }
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private EMDataType CommentTagDatatypeChecker(string sCommentAddress, CUDLTag cParentTag)
        {
            EMDataType datatype = EMDataType.None;

            try
            {
                if (sCommentAddress.Contains(".EN") || sCommentAddress.Contains(".DN"))
                    datatype = EMDataType.Bool;
                else if(sCommentAddress.Contains("."))
                {
                    int iPos = sCommentAddress.LastIndexOf(".");
                    bool bIsNum = true;

                    for(int i = iPos+1;i<sCommentAddress.Length;i++)
                    {
                        if(!char.IsDigit(sCommentAddress[i]))
                        {
                            bIsNum = false;
                            break;
                        }
                    }

                    if (bIsNum)
                        datatype = EMDataType.Bool;
                }

                if (datatype == EMDataType.None)
                    datatype = cParentTag.Datatype;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return datatype;
        }

        private CUDLTag GetTag(string sLine)
        {
            CUDLTag cUDLTag = null;

            try
            {
                cUDLTag = new CUDLTag();
                cUDLTag.PLCMaker = EMPLCMaker.Rockwell;
                cUDLTag.Program = m_cUDL.ProjectName;

                if (sLine.Contains("(Description := "))
                    cUDLTag.Description = GetDescription(sLine);

                string sEditedLine = sTagLineEdit(sLine);
                bool bOK = false;
                if (sLine.Contains(" OF "))
                {
                    bOK = SetAliasTag(cUDLTag, sEditedLine, sLine);
                    if(bOK == false)
                        SetNormalTag(cUDLTag, sEditedLine, sLine);
                }
                else
                    SetNormalTag(cUDLTag, sEditedLine, sLine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cUDLTag;
        }

        private string sTagLineEdit(string sLine)
        {
            string sLineEdit = string.Empty;
            try
            {
                if(sLine.Contains(" ("))
                {
                    int Index = sLine.IndexOf(" (");
                    sLineEdit = sLine.Substring(0, Index);
                }
                else if (sLine.Contains("  :="))
                {
                    int Index = sLine.IndexOf("  :=");
                    sLineEdit = sLine.Substring(0, Index);
                }
                else if (sLine.EndsWith(" ;"))
                    sLineEdit = sLine.Substring(0, sLine.Length - 2);
                else
                    Console.WriteLine("sTagEdit 함수에서 Edit하지 못하는 Line이 존재합니다. \n Line : {0}", sLine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sLineEdit;
        }

        private string GetDescription(string sLine)
        {
            string sDescription = string.Empty;
            try
            {
                string IndexString = "(Description := ";
                int Index = sLine.IndexOf(IndexString);

                string sTemp = sLine.Remove(0, Index + IndexString.Length);

                if(sTemp.Contains(") := "))
                {
                    Index = sTemp.IndexOf(") := ");
                    sDescription = sTemp.Substring(0, Index);
                }                
                else if(sTemp.Contains("\","))
                {
                    Index = sTemp.IndexOf("\",");
                    sDescription = sTemp.Remove(Index);
                }

                if(sDescription!= string.Empty)
                {
                    if(sDescription.Contains("\","))
                    {
                        Index = sDescription.IndexOf("\",");
                        sDescription = sDescription.Remove(Index);
                    }
                }
                else
                    sDescription = sTemp.Substring(0, sTemp.Length - 1);


                sDescription = sDescription.Replace("\"", string.Empty);
                sDescription = sDescription.Replace("$N", " ");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sDescription;
        }

        private string GetUDLTagAddress(CUDLTag cUdlTag)
        {
            string sTagAddress = string.Empty;
            try
            {
                if(cUdlTag.ArrayEndPoint!=string.Empty)
                {
                    int iPos = cUdlTag.Address.LastIndexOf("[");
                    sTagAddress = cUdlTag.Address.Remove(iPos);
                }
                else
                {
                    sTagAddress = cUdlTag.Address;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sTagAddress;
        }

        private string GetUDLTagName(CUDLTag cUdlTag)
        {
            string sTagName = string.Empty;
            try
            {
                if (cUdlTag.ArrayEndPoint != string.Empty)
                {
                    int iPos = cUdlTag.Name.LastIndexOf("[");
                    sTagName = cUdlTag.Name.Remove(iPos);
                }
                else
                {
                    sTagName = cUdlTag.Name;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sTagName;
        }

        private bool SetAliasTag(CUDLTag cUDLTag, string sEditedLine, string sOriginalLine)
        {
            bool bOK = false;
            try
            {
                int iOFIndex = sEditedLine.IndexOf(" OF ");

                if (iOFIndex == -1)
                    return bOK;
                string sName = sEditedLine.Substring(0, iOFIndex);
                string sAddress = sEditedLine.Remove(0, iOFIndex + 4);

                cUDLTag.Name = sName;
                cUDLTag.Address = sAddress;
                cUDLTag.Alias = sAddress;
                cUDLTag.Datatype = AliasTagDatatypeChecker(sName,sAddress);
                cUDLTag.Note = "ALIAS";

                if (sOriginalLine.Contains("COMMENT"))
                    MakeCommentGlobalTag(sOriginalLine, cUDLTag);
                bOK = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return bOK;
        }

        private void SetNormalTag(CUDLTag cUDLTag, string sEditedLine, string sOriginalLine)
        {
            try
            {
                string sLength = string.Empty;
                string sDataType = string.Empty;

                int Index = sEditedLine.IndexOf(" : ");
                string sName = sEditedLine.Substring(0, Index);
                string sDataTypeTemp = sEditedLine.Remove(0, Index + 3);

                if (sDataTypeTemp.Contains("["))
                {
                    sDataType = sDataTypeTemp.Split('[')[0];
                    sLength = sDataTypeTemp.Split('[')[1].Replace("]", string.Empty);
                    sName = string.Format("{0}[{1}]", sName, sLength);
                }
                else
                    sDataType = sDataTypeTemp;

                cUDLTag.Name = sName;
                cUDLTag.Address = sName;
                cUDLTag.Datatype = GetDataType(sDataType);
                cUDLTag.Note = "TAG";

                if (cUDLTag.Datatype == EMDataType.UserDefDataType)
                    cUDLTag.UDTType = sDataType;

                if(sLength != string.Empty)
                    SetArrayStartEndPoint(cUDLTag, sLength);

                if (sOriginalLine.Contains("COMMENT"))
                    MakeCommentGlobalTag(sOriginalLine, cUDLTag);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private void SetArrayStartEndPoint(CUDLTag cUDLTag, string sLength)
        {
            try
            {
                int iEndPoint = 0;
                string sStartPoint = string.Empty;
                string sEndPoint = string.Empty;

                if(sLength.Contains(","))
                {
                    string[] arrLength = sLength.Split(',');
                    
                    iEndPoint = Int32.Parse(arrLength[0]) - 1;

                    sStartPoint = "0";
                    sEndPoint = iEndPoint.ToString();

                    for(int i = 1 ; i < arrLength.Length ; i++)
                    { 
                        iEndPoint = Int32.Parse(arrLength[i]) - 1;
                        string sEndTemp = string.Format(",{0}", iEndPoint);
                        string sStartTemp = ",0";

                        sStartPoint += sStartTemp;
                        sEndPoint += sEndTemp;
                    }
                }
                else
                {
                    sStartPoint = "0";
                    iEndPoint = Int32.Parse(sLength) - 1;
                    sEndPoint = iEndPoint.ToString();
                }

                cUDLTag.ArrayStartPoint = sStartPoint;
                cUDLTag.ArrayEndPoint = sEndPoint;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private string GetLogic(string sLine)
        {
            string sLogic = string.Empty;
            try
            {
                string sTemp = "\t\tN: ";
                int index = sLine.IndexOf(sTemp);

                if (index >= 0)
                {
                    string sLogicTemp = sLine.Substring(index + sTemp.Length);
                    sLogic = sLogicTemp.Replace("\"", string.Empty).Replace(";", string.Empty).Replace(" ", string.Empty);
                    sLogic = ChangeInstruName(sLogic);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sLogic;
        }

        private string GetName(string sLine, string sFindType)
        {
            string sName = string.Empty;

            try
            {
                if(sLine.Contains("("))
                    sName = sLine.Split('(')[0].Remove(0, sFindType.Length).Replace(" ", string.Empty);                
                else
                    sName = sLine.Remove(0, sFindType.Length).Replace(" ", string.Empty).Replace("\"", string.Empty);                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return sName;
        }

        private CUDLTag GetDataTypeTag(string sLine)
        {
            CUDLTag cUDLTag = null;
            try
            {
                cUDLTag = new CUDLTag();
                string sDataType = string.Empty;
                string sName = string.Empty;


                sLine = sLine.Remove(0, 2);
                int Index = sLine.IndexOf(" ");
                sDataType = sLine.Substring(0, Index);
                string sTemp = sLine.Remove(0, Index + 1);

                if (sTemp.Contains("(Description := "))
                {
                    cUDLTag.Description = GetDescription(sTemp);
                    sName = sTagLineEdit(sTemp);
                }
                else
                    sName = sTemp.Replace(";", string.Empty);                

                cUDLTag.Name = sName;
                cUDLTag.Datatype = GetDataType(sDataType);
                cUDLTag.PLCMaker = EMPLCMaker.Rockwell;

                if (cUDLTag.Datatype == EMDataType.UserDefDataType)
                    cUDLTag.UDTType = sDataType;                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cUDLTag;
        }

        private void UnfoundAliasTagRework()
        {
            int iCount = m_cUDL.Tags.Count;

            for(int i =0;i<iCount;i++)
            {
                CUDLTag tempTag = m_cUDL.Tags[i];
                string sTemp = tempTag.Name;
                bool bIsFind = false;

                if(m_lstNoFoundAlias.Contains(sTemp))
                {
                    bIsFind = AliasTagDatatypeRechecker(tempTag);
                }

                if (bIsFind)
                    m_lstNoFoundAlias.Remove(tempTag.Name);
            }
        }

        private EMDataType GetDataType(string sDataType)
        {
            EMDataType tempType = EMDataType.Bool;
            try
            {
                if (sDataType.Contains("BOOL"))
                    tempType = EMDataType.Bool;
                else if (sDataType.Contains("DINT"))
                    tempType = EMDataType.DInt;
                else if (sDataType.Contains("SINT"))
                    tempType = EMDataType.SInt;
                else if (sDataType.Contains("INT"))
                    tempType = EMDataType.Int;
                else if (sDataType.Contains("REAL"))
                    tempType = EMDataType.Real;
                else if (sDataType.Contains("CONTROL"))
                    tempType = EMDataType.Control;
                else if (sDataType.Contains("COUNTER"))
                    tempType = EMDataType.Counter;
                else if (sDataType.Contains("TIMER"))
                    tempType = EMDataType.Timer;
                else if (sDataType.Contains("MESSAGE"))
                    tempType = EMDataType.Message;
                else if (sDataType.Contains("STRING"))
                    tempType = EMDataType.String;
                else
                    tempType = EMDataType.UserDefDataType;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return tempType;
        }

        private bool AliasTagDatatypeRechecker(CUDLTag TaskTag)
        {
            bool bIsFind = false;

            try
            {
                string sTagName = TaskTag.Name;
                string sAliasName = TaskTag.Alias;

                if (sAliasName.Contains("]."))
                {
                    int iPos = sAliasName.LastIndexOf("].");
                    string sTemp = sAliasName.Substring(iPos+2);
                    bool bIsNum = true;

                    for (int i = 0; i < sTemp.Length; i++)
                    {
                        if (!Char.IsDigit(sTemp[i]))
                        {
                            bIsNum = false;
                            break;
                        }
                    }

                    if (bIsNum)
                    {
                        TaskTag.Datatype = EMDataType.Bool;
                        bIsFind = true;
                    }
                }

                if (sAliasName.Contains("[") && !bIsFind)
                {
                    int iPos = sAliasName.IndexOf("[");
                    string sAlias = sAliasName.Remove(iPos);

                    foreach (CUDLTag tempTag in m_cUDL.Tags)
                    {
                        if (tempTag.Name.Contains(sAlias))
                        {
                            int iLenght = sAlias.Length;

                            if (tempTag.Name[iLenght] == '[')
                            {
                                TaskTag.Datatype = tempTag.Datatype;
                                bIsFind = true;
                                break;
                            }
                        }
                    }
                }

                if (!bIsFind && sAliasName.Contains(":"))
                {
                    int iPos = sAliasName.IndexOf(":");
                }

                if (!bIsFind)
                {
                    foreach (CUDLTag tempTag in m_cUDL.Tags)
                    {
                        if (tempTag.Name == sAliasName)
                        {
                            TaskTag.Datatype = tempTag.Datatype;
                            bIsFind = true;
                            break;
                        }
                    }
                }

            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }
            return bIsFind;
        }

        private EMDataType AliasTagDatatypeChecker(string sTagName,string sAliasName)
        {
            EMDataType Datatype = EMDataType.Bool;

            try
            {
                bool bIsFind = false;

                if(sAliasName.Contains("]."))
                {
                    int iPos = sAliasName.LastIndexOf("].");
                    string sTemp = sAliasName.Substring(iPos+2);
                    bool bIsNum = true;

                    for(int i=0;i<sTemp.Length;i++)
                    {
                        if(!Char.IsDigit(sTemp[i]))
                        {
                            bIsNum = false;
                            break;
                        }
                    }

                    if(bIsNum)
                    {
                        Datatype = EMDataType.Bool;
                        bIsFind = true;
                    }
                }

                if (!bIsFind && sAliasName.Contains(":"))
                {
                    if (sAliasName.EndsWith("]"))
                    {
                        Datatype = EMDataType.DInt;
                        bIsFind = true;
                    }

                    if(!bIsFind)
                    {
                        int iPos = sAliasName.LastIndexOf(":");

                        string sTemp = sAliasName.Substring(iPos + 1);

                        if (sTemp == "I" || sTemp == "O")
                        {
                            Datatype = EMDataType.DInt;
                            bIsFind = true;
                        }
                    }

                    if(!bIsFind&& sAliasName.Contains("."))
                    {
                        int iPos = sAliasName.LastIndexOf(".");
                        string sTemp = sAliasName.Substring(iPos + 1);

                        if(sTemp == "RUN")
                        {
                            Datatype = EMDataType.Bool;
                            bIsFind = true;
                        }

                    }
                    
                }

                if (sAliasName.Contains("[")&& !bIsFind)
                {
                    int iPos = sAliasName.IndexOf("[");
                    string sAlias = sAliasName.Remove(iPos);

                    foreach (CUDLTag tempTag in m_cUDL.Tags)
                    {
                        if (tempTag.Name.Contains(sAlias))
                        {
                            int iLenght = sAlias.Length;

                            if (tempTag.Name[iLenght] == '[')
                            {
                                Datatype = tempTag.Datatype;
                                bIsFind = true;
                                break;
                            }
                        }
                    }
                }                

                if(!bIsFind)
                {
                    foreach(CUDLTag tempTag in m_cUDL.Tags)
                    {
                        if(tempTag.Name == sAliasName)
                        {
                            Datatype = tempTag.Datatype;
                            bIsFind = true;
                            break;
                        }
                    }
                }

                if(!bIsFind)
                {
                    m_lstNoFoundAlias.Add(sTagName);
                }

            }
            catch (System.Exception error)
            {
                Console.WriteLine("Error:{0}\t{1}", error.Message, System.Reflection.MethodBase.GetCurrentMethod()); error.Data.Clear();
            }

            return Datatype;
        }

        private string GetMainRoutine(string sLine)
        {
            string sMainRoutine = string.Empty;

            try
            {
                string sTemp = "MAIN := \"";
                int index = sLine.IndexOf(sTemp);

                if(index > 0)
                {
                    string sTemp2 = sLine.Substring(index + sTemp.Length);
                    index = sTemp2.IndexOf("\"");
                    sMainRoutine = sTemp2.Substring(0, index);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sMainRoutine;
        }
      
        private string ChangeInstruName(string sLine)
        {
            string sLogic = string.Empty;

            try
            {
                string sLogicUnit = string.Empty;
      
                int iLength = sLine.Length;
                int iLevel = 0;

                bool bInBracket = false;

                for(int i =0;i<iLength;i++)
                {
                    if(sLine[i] =='(')
                    {
                        iLevel = iLevel + 1;
                        sLogic = sLogic + sLine[i];

                        if(iLevel>0)
                            bInBracket = true;
                    }
                    else if(sLine[i] ==')')
                    {
                        iLevel = iLevel - 1;
                        sLogic = sLogic + sLine[i];

                        if(iLevel==0)
                            bInBracket = false;
                    }
                    else
                    {
                        if (bInBracket)
                            sLogic = sLogic + sLine[i];
                        else if (sLine[i] == '[' || sLine[i] == ',' || sLine[i] == ']')
                            sLogic = sLogic + sLine[i];
                        else
                        {
                            sLogicUnit = sLogicUnit + sLine[i];

                            if(sLine[i+1]=='(')
                            {
                                sLogicUnit = FindStandardInstruName(sLogicUnit);
                                sLogic = sLogic + sLogicUnit;
                                sLogicUnit = string.Empty;
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return sLogic;
        }

        private string FindStandardInstruName(string sLogicName)
        {
            string sStandName = string.Empty;

            if (m_DicInstructionList.ContainsKey(sLogicName))
                sStandName = m_DicInstructionList[sLogicName].Instruction;
            else
                sStandName = sLogicName;

            return sStandName;
        }

        #endregion

    }
}
