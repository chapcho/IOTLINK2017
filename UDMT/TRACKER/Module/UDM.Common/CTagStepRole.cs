using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CTagStepRole : IDisposable
    {

        #region Member Variables

        protected string m_sStepKey = "";
        protected EMStepRoleType m_emRoleType = EMStepRoleType.None;        

        #endregion


        #region Initialize/Dispose

        public CTagStepRole()
        {

        }

        public CTagStepRole(string sStepKey, EMStepRoleType emRoleType)
        {
            m_sStepKey = sStepKey;
            m_emRoleType = emRoleType;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string StepKey
        {
            get { return m_sStepKey; }
            set { m_sStepKey = value; }
        }

        public EMStepRoleType RoleType
        {
            get { return m_emRoleType; }
            set { m_emRoleType = value; }
        }

        #endregion


        #region Public Methods


        #endregion
    }
}
