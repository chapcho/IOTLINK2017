using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDLBlock
    {
        #region Member Variables
        protected EMBlockType m_emBlockType;
        protected bool m_bIsSharedDB = true;
        protected string m_sBlockName = string.Empty;
        protected string m_sBlockAddress = string.Empty;
        protected string m_sMainRoutine = string.Empty;
        protected string m_sComment = string.Empty;
        protected List<CUDLTag> m_lstInputTag = new List<CUDLTag>();
        protected List<CUDLTag> m_lstOutputTag = new List<CUDLTag>();
        protected List<CUDLTag> m_lstInOutTag = new List<CUDLTag>();
        protected List<CUDLTag> m_lstTempTag = new List<CUDLTag>();
        protected List<CUDLTag> m_lstSTATTag = new List<CUDLTag>();
        protected List<CUDLRoutine> m_lstRoutine = new List<CUDLRoutine>();
        protected int m_iParameterLenght = 0;

        #endregion

        #region Intialize/Dispose
        #endregion

        #region Public Properties

        public bool IsSharedDB
        {
            get { return m_bIsSharedDB;}
            set { m_bIsSharedDB = value; }
        }


        public EMBlockType BlockType
        {
            get { return m_emBlockType; }
            set { m_emBlockType = value; }
        }
        public string BlockName
        {
            get { return m_sBlockName; }
            set { m_sBlockName = value; }
        }
        public string BlockAddress
        {
            get { return m_sBlockAddress; }
            set { m_sBlockAddress = value; }
        }
        public string Comment
        {
            get { return m_sComment; }
            set { m_sComment = value; }
        }
        public List<CUDLTag> InputTags
        {
            get { return m_lstInputTag; }
            set { m_lstInputTag = value; }
        }
        public List<CUDLTag> InOutTags
        {
            get { return m_lstInOutTag; }
            set { m_lstInOutTag = value; }
        }
        public List<CUDLTag> OutputTags
        {
            get { return m_lstOutputTag; }
            set { m_lstOutputTag = value; }
        }
        public List<CUDLTag> STATTags
        {
            get { return m_lstSTATTag; }
            set { m_lstSTATTag = value; }
        }
        public List<CUDLTag> TempTags
        {
            get { return m_lstTempTag; }
            set { m_lstTempTag = value; }
        }
        public string MainRoutine
        {
            get { return m_sMainRoutine; }
            set { m_sMainRoutine = value; }
        }
        public int ParameterLenght
        {
            get { return m_iParameterLenght; }
            set { m_iParameterLenght = value; }
        }
        /// <summary>
        /// Internal Logics
        /// </summary>
        public List<CUDLRoutine> Routines
        {
            get { return m_lstRoutine; }
            set { m_lstRoutine = value; }
        }
        #endregion

        #region Public Methods

        public List<string> GetFullBlocks()
        {
            List<string> FullFile = new List<string>();

            try
            {
                if(m_emBlockType == EMBlockType.Datablock)
                {
                    FullFile.Add("DATABLOCK  "+ m_sBlockName);

                    if (m_lstInputTag.Count>0)
                    {
                        int iCount = m_lstInputTag.Count;

                        FullFile.Add("LOCAL_TAGS");
                        string sTemp = string.Empty;

                        for(int i=0;i<iCount;i++)
                        {
                            sTemp = m_lstInputTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_LOCAL_TAGS");

                    }

                    FullFile.Add("END_DATABLOCK");
                }
                else 
                {
                    if (m_emBlockType == EMBlockType.Function)
                    {
                        FullFile.Add("FUNCTION  " + m_sBlockName);
                    }
                    else if (m_emBlockType == EMBlockType.FunctionBlock)
                    {
                        FullFile.Add("FUNCTIONBLOCK  " + m_sBlockName);
                    }
                    else if (m_emBlockType == EMBlockType.DummryBlock)
                    {
                        FullFile.Add("DUMMRY_BLOCK");
                    }

                    if (m_lstInputTag.Count>0)
                    {
                        int iCount = m_lstInputTag.Count;

                        FullFile.Add("INPUT_TAGS");
                        string sTemp = string.Empty;

                        for (int i = 0; i < iCount; i++)
                        {
                            sTemp = m_lstInputTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_INPUT_TAGS");
                    }

                    if (m_lstOutputTag.Count > 0)
                    {
                        int iCount = m_lstOutputTag.Count;

                        FullFile.Add("OUTPUT_TAGS");
                        string sTemp = string.Empty;

                        for (int i = 0; i < iCount; i++)
                        {
                            sTemp = m_lstOutputTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_OUTPUT_TAGS");
                    }

                    if (m_lstInOutTag.Count > 0)
                    {
                        int iCount = m_lstInOutTag.Count;

                        FullFile.Add("INOUT_TAGS");
                        string sTemp = string.Empty;

                        for (int i = 0; i < iCount; i++)
                        {
                            sTemp = m_lstInOutTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_INOUT_TAGS");
                    }


                    if (m_lstSTATTag.Count > 0)
                    {
                        int iCount = m_lstSTATTag.Count;

                        FullFile.Add("STAT_TAGS");
                        string sTemp = string.Empty;

                        for (int i = 0; i < iCount; i++)
                        {
                            sTemp = m_lstSTATTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_STAT_TAGS");
                    }


                    if (m_lstTempTag.Count > 0)
                    {
                        int iCount = m_lstTempTag.Count;

                        FullFile.Add("TEMP_TAGS");
                        string sTemp = string.Empty;

                        for (int i = 0; i < iCount; i++)
                        {
                            sTemp = m_lstTempTag[i].GetLocalTag();
                            FullFile.Add(sTemp);
                        }
                        FullFile.Add("END_TEMP_TAGS");
                    }

                    if (m_lstRoutine.Count > 0)
                    {
                        int iCount = m_lstRoutine.Count;

                        FullFile.Add("LOCAL_LOGICS");
                        List<string> sTempList = new List<string>();

                        for (int i=0;i<iCount;i++)
                        {
                            sTempList = m_lstRoutine[i].GetStringsRotineLogicS();
                            FullFile.AddRange(sTempList);
                        }
                        FullFile.Add("END_LOCAL_LOGICS");
                    }

                    if (m_emBlockType == EMBlockType.Function)
                    {
                        FullFile.Add("END_FUNCTION");
                    }
                    else if (m_emBlockType == EMBlockType.FunctionBlock)
                    {
                        FullFile.Add("END_FUNCTION_BLOCK");
                    }
                    else if (m_emBlockType == EMBlockType.DummryBlock)
                        FullFile.Add("END_DUMMRY_BLOCK");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            return FullFile;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
