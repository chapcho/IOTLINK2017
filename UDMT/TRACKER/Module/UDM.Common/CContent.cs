using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]    
    public class CContent : ITagComposable, IDisposable
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

        public string Parameter
        {
            get { return m_sParameter; }
            set { m_sParameter = value; }
        }

        public string Argument
        {
            get { return m_sArgument; }
            set { m_sArgument = value; }
        }

        public EMArgumentType ArgumentType
        {
            get { return m_emArgumentType; }
            set { m_emArgumentType = value; }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        #endregion


        #region Public Methods

        public void Compose(CTagS cTagS)
        {
            m_cTag = null;

            if (m_emArgumentType == EMArgumentType.Tag && cTagS != null)
            {
                m_cTag = cTagS.GetFirst(m_sArgument);
            }
        }

        public void Compose(CRefTagS cRefTagS)
        {
            m_cTag = null;

            if (m_emArgumentType == EMArgumentType.Tag && cRefTagS != null)
            {
                m_cTag = cRefTagS.GetFirstTag(m_sArgument);
            }
        }

        public void ComposeTagRoleS(CTagStepRole cTagRole)
        {
            if (m_cTag != null)
            {
                if (m_cTag.StepRoleS == null)
                    m_cTag.StepRoleS = new CTagStepRoleS();

                m_cTag.StepRoleS.Add(cTagRole);
            }
        }

        #endregion
    }
}
