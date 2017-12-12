
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CContent : IDisposable,ICloneable
    {

        #region Member Variables

        protected string m_sParameter = "";
        protected string m_sArgument = "";
        protected EMArgumentType m_emArgumentType = EMArgumentType.None;

        [NonSerialized]
        protected CTag m_cTag = null;

        #endregion


        #region Initialize/Dispose

        public CContent()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        /// <summary>
        /// 이 Content 사용하는 명령어
        /// </summary>
        public string Parameter
        {
            get { return m_sParameter; }
            set { m_sParameter = value; }
        }

        /// <summary>
        /// Tag Name, Numeric....
        /// </summary>
        public string Argument
        {
            get { return m_sArgument; }
            set { m_sArgument = value; }
        }

        /// <summary>
        /// Tag, 상수 등
        /// </summary>
        public EMArgumentType ArgumentType
        {
            get { return m_emArgumentType; }
            set { m_emArgumentType = value; }
        }

        /// <summary>
        /// 사용한 Tag
        /// </summary>
        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        #endregion


        #region Public Methods

        public object Clone()
        {
            CContent cContent = new CContent();

            cContent.Tag = (CTag)m_cTag.Clone();
            cContent.Argument = m_sArgument;
            cContent.Parameter = m_sParameter;
            cContent.ArgumentType = m_emArgumentType;

            return cContent;
        }

        #endregion
    }
}
