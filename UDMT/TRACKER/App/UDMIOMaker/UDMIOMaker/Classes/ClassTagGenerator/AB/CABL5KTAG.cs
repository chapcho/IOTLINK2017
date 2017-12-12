using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class CABL5KTAG
    {
        #region Member Variables

        protected List<string> m_GlobalTags;
        protected List<string> m_LocalTags;

        protected List<string> m_BaseTags = new List<string>();
        protected List<string> m_CommentTags = new List<string>();
        protected List<string> m_AliasTags = new List<string>();

        protected string m_PreGlobalTags = string.Empty;
        protected string m_value = string.Empty;

        protected string m_sBaseParser = " : ";
        protected string m_sCommentParser = "COMMENT";
        protected string m_sAliasParser = " OF ";
        protected string m_Global = "Global:";
        protected string m_Local = "Local:";

        protected string m_Base = "Base:";
        protected string m_Alias = "Alias:";
        protected string m_Comment = "Comment:";


        #endregion

        #region Initialize/Dispose

        public CABL5KTAG(List<string> GlobalTAG, List<string> LocalTAG)
        {
            m_GlobalTags = GlobalTAG;
            m_LocalTags = LocalTAG;
        }


        #endregion

        #region Public Properites

        public List<string> BaseTags
        {
            get { return m_BaseTags; }
            set { m_BaseTags = value; }
        }

        public List<string> CommentTags
        {
            get { return m_CommentTags; }
            set { m_CommentTags = value; }
        }

        public List<string> AliasTags
        {
            get { return m_AliasTags; }
            set { m_AliasTags = value; }
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods


        #region TAGAnalysis

        public void GlobalTAGAnalysis()
        {
            bool bOKBase = false;
            bool bOKAlias = false;
            bool bOKComment = false;

            foreach (string GlobalTags in m_GlobalTags)
            {
                if (GlobalTags.Contains(m_sBaseParser))
                {
                    bOKBase = true;
                }
                else if (GlobalTags.Contains(m_sAliasParser))
                {
                    bOKAlias = true;
                }
                else if (GlobalTags.Contains(m_sCommentParser))
                {
                    bOKComment = true;
                }

                beforeCheck(m_value);

                TAGinput(bOKBase, bOKComment, bOKAlias, GlobalTags, m_Global);

                bOKBase = false;
                bOKAlias = false;
                bOKComment = false;

                m_value = GlobalTags;
            }
        }

        #endregion

        #region Input

        public void TAGinput(bool bOKBase, bool bOKComment, bool bOKAlias, string Tags, string Scope)
        {

            if (bOKBase)
                BaseInput(Tags, Scope);

            if (bOKComment)
                CommentInput(Tags, Scope);

            if (bOKAlias)
                AliasInput(Tags, Scope);

        }

        public void BaseInput(string tag, string Scope)
        {
            m_BaseTags.Add(m_Base + Scope + tag);
        }

        public void CommentInput(string tag, string Scope)
        {
            string Group = Convertor(m_PreGlobalTags);
            string tags = tag.Replace(m_sCommentParser, "");
            m_CommentTags.Add(m_Comment + Scope + Group + tags.Replace(" ", ""));
        }

        public void AliasInput(string tag, string Scope)
        {
            m_AliasTags.Add(m_Alias + Scope + tag);
        }

        #endregion

        #region Check & Convertor

        public string beforeCheck(string value)
        {
            if (value.Contains(m_sBaseParser) || value.Contains(m_sAliasParser))
            {
                m_PreGlobalTags = value;
            }

            return m_PreGlobalTags;
        }

        public string Convertor(string str)
        {
            string[] array = str.Split(' ');

            return array[0];
        }

        #endregion


        #endregion
    }
}
