using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDL
    {
        protected Dictionary<string,CUDLModule> m_dicModule = null;
        protected Dictionary<string,CUDLUDT> m_dicUDT = null;
        protected List<CUDLTag> m_lstTag = null;
        protected Dictionary<string,CUDLBlock> m_dicBlock = null;
        protected string m_sMainProgram = string.Empty;
        protected string m_sProjectName = string.Empty;

        protected List<string> m_lstProtectedFBList = null;

        #region Intialize/Dispose

        public CUDL()
        {
            m_dicModule = new Dictionary<string, CUDLModule>();
            m_dicUDT = new Dictionary<string, CUDLUDT>();
            m_dicBlock = new Dictionary<string, CUDLBlock>();

        }
        
        #endregion

        #region Public Properties

        public Dictionary<string,CUDLModule> Modules
        {
            get { return m_dicModule; }
            set { m_dicModule = value; }
        }

        public Dictionary<string,CUDLUDT> UDTs
        {
            get { return m_dicUDT; }
            set { m_dicUDT = value; }
        }
        public List<CUDLTag> Tags
        {
            get { return m_lstTag; }
            set { m_lstTag = value; }
        }
        public Dictionary<string,CUDLBlock> Blocks
        {
            get { return m_dicBlock; }
            set { m_dicBlock = value; }
        }
        public List<string> ProtectedFBList
        {
            get { return m_lstProtectedFBList; }
            set { m_lstProtectedFBList = value; }
        }

        public string MainProgram
        {
            get { return m_sMainProgram; }
            set { m_sMainProgram = value; }
        }
        public string ProjectName
        {
            get { return m_sProjectName; }
            set { m_sProjectName = value; }
        }
        #endregion

        #region Public Methods

        public List<string> GetFullFile()
        {
            List<string> FullFile = new List<string>();
            try
            {
                FullFile.Add("PROJECT");

                if (m_dicModule.Count > 0)
                {
                    FullFile.Add("MODULES");

                    foreach(CUDLModule tempModule in m_dicModule.Values)
                    {
                        string sTemp = string.Empty;
                        sTemp = tempModule.ModuleInfo();
                        FullFile.Add(sTemp);
                    }

                    FullFile.Add("END_MODULES");
                }

                if (m_dicUDT.Count > 0)
                {
                    FullFile.Add("UDTS");

                    foreach(CUDLUDT tempUdt in m_dicUDT.Values)
                    {
                        List<string> sStringTempS = null;
                        sStringTempS = tempUdt.GetStringUDT();
                        FullFile.AddRange(sStringTempS);
                    }
                    FullFile.Add("END_UDTS");
                }

                if (m_lstTag.Count > 0)
                {
                    FullFile.Add("TAGS");

                    int iCount = m_lstTag.Count;
                    string sTemp = string.Empty;

                    for (int i = 0; i < iCount;i++ )
                    {
                        sTemp = m_lstTag[i].GetFullTag();
                        FullFile.Add(sTemp);
                    }

                    FullFile.Add("END_TAGS");
                }

                if (m_dicBlock.Count > 0)
                {
                    FullFile.Add("BLOCKS");

                    foreach(CUDLBlock tempBlock in m_dicBlock.Values)
                    {
                        List<string> sStringTempS = null;
                        sStringTempS = tempBlock.GetFullBlocks();
                        FullFile.AddRange(sStringTempS);
                    }

                    FullFile.Add("END_BlOCKS");
                }

                FullFile.Add("END_PROJECT");
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
