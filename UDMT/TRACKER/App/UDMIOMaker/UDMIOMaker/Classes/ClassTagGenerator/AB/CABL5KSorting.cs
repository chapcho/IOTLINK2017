using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class CABL5KSorting
    {
        #region Member Variables

        protected List<string> m_ABInfo = new List<string>();
        protected List<string> m_ABModule = new List<string>();
        protected List<string> m_ABModuleList = new List<string>();
        protected List<string> m_ABProgramList = new List<string>();
        protected List<string> m_ABRoutineList = new List<string>();
        protected List<string> m_ABRoutine = new List<string>();
        protected List<string> m_ABGlobalTAG = new List<string>();
        protected List<string> m_ABLocalTAG = new List<string>();

        protected List<string> m_Base = new List<string>();
        protected List<string> m_Alias = new List<string>();
        protected List<string> m_Comment = new List<string>();

        #endregion

        #region Initialize/Dispose

        public CABL5KSorting()
        {

        }

        #endregion

        #region Public Properites


        public List<string> ABInfo
        {
            get { return m_ABInfo; }
            set { m_ABInfo = value; }
        }

        public List<string> ABModule
        {
            get { return m_ABModule; }
            set { m_ABModule = value; }
        }

        public List<string> ABModuleList
        {
            get { return m_ABModuleList; }
            set { m_ABModuleList = value; }
        }

        public List<string> ABRoutineList
        {
            get { return m_ABRoutineList; }
            set { m_ABRoutineList = value; }
        }

        public List<string> ABRoutine
        {
            get { return m_ABRoutine; }
            set { m_ABRoutine = value; }
        }

        public List<string> Base
        {
            get { return m_Base; }
            set { m_Base = value; }
        }

        public List<string> Alias
        {
            get { return m_Alias; }
            set { m_Alias = value; }
        }

        public List<string> Comment
        {
            get { return m_Comment; }
            set { m_Comment = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #region TAGAnalysis

        public void ABSorting()
        {
            //m_cTags = abFile;
            //m_cTagsGlobal = new CTagS();
            //m_cTagsModule = new CTagS();
            //m_cTagsPrograms = new CTagS();
            //m_cTagsETC = new CTagS();
        }

        public void ABInformation(List<string> file)
        {
            bool bOKInfo = true;
            bool bOKModule = false;
            bool bOKTAG = false;
            bool bOKProgram = false;
            bool bOKDataType = false;
            bool bOKRoutine = false;
            //bool bOKRoutine = false;

            string ProgramName = string.Empty;

            foreach (string files in file)
            {
                if (files.Contains("MODULE "))
                {
                    bOKInfo = false;
                    bOKModule = true;
                    string[] str = files.Split(' ');
                    m_ABModuleList.Add(str[1]);
                }
                else if (files.Contains("END_MODULE"))
                {
                    bOKModule = false;
                }

                else if (files.Equals("TAG"))
                {
                    bOKTAG = true;
                }

                else if (files.Equals("END_TAG"))
                {
                    bOKTAG = false;
                }
                else if (files.StartsWith("PROGRAM "))
                {
                    bOKProgram = true;
                    m_ABProgramList.Add(files);
                }
                else if (files.StartsWith("END_PROGRAM"))
                {
                    bOKProgram = false;
                }

                else if (files.StartsWith("ROUTINE "))
                {
                    bOKRoutine = true;
                    m_ABRoutineList.Add(files);
                }
                else if (files.StartsWith("END_ROUTINE"))
                {
                    bOKRoutine = false;
                }
                else if (files.StartsWith("DATATYPE "))
                {
                    bOKDataType = true;
                    bOKInfo = false;
                }
                else if (files.StartsWith("END_DATATYPE"))
                {
                    bOKDataType = false;
                }

                Input(files, bOKModule, bOKInfo, bOKTAG, bOKProgram, bOKRoutine);
            }

            ABTAg();
        }

        #endregion

        #region Input

        public void Input(string files, bool bOKModule, bool bOKInfo, bool bOKTAG, bool bOKProgram, bool bOKRoutine)
        {
            if (bOKModule)
                m_ABModule.Add(files);

            if (bOKInfo)
                m_ABInfo.Add(files);

            if (bOKTAG && !bOKProgram)
                m_ABGlobalTAG.Add(files);

            if (bOKTAG && bOKProgram)
            {
                m_ABLocalTAG.Add(files);
            }
            if (bOKRoutine)
            {
                m_ABRoutine.Add(files);
            }
        }

        public void ABTAg()
        {
            CABL5KTAG cABtag = new CABL5KTAG(m_ABGlobalTAG, m_ABLocalTAG);
            cABtag.GlobalTAGAnalysis();
            m_Base = cABtag.BaseTags;
            m_Alias = cABtag.AliasTags;
            m_Comment = cABtag.CommentTags;

            /// 하나의 라인에 두개의 정보가 있는 경우 Comment Check
            ABbaseCheck();
            ABAliasCheck();

            m_ABGlobalTAG.Clear();
            m_ABLocalTAG.Clear();
        }

        public void ABbaseCheck()
        {
            foreach (string Bases in m_Base)
            {
                if (Bases.Contains("COMMENT"))
                {
                    string[] group = Bases.Split(' ');
                    string[] comment = Bases.Split('(');
                    string Add = comment[1].Replace("COMMENT", group[0]);
                    string AddComment = Add.Replace("Base", "Comment");

                    m_Comment.Add(AddComment);
                }
            }
        }

        public void ABAliasCheck()
        {
            foreach (string Aliases in m_Alias)
            {
                if (Aliases.Contains("COMMENT"))
                {
                    string[] group = Aliases.Split(' ');
                    string[] comment = Aliases.Split('(');
                    string Add = comment[1].Replace("COMMENT", group[0]);
                    string AddComment = Add.Replace("Alias", "Comment");

                    m_Comment.Add(AddComment);
                }
            }
        }



        #endregion

        #endregion
    }
}
