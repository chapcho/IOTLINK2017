using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CTagGroupRole : IDisposable
    {

        #region Member Variables

        private string m_sGroupKey = null;
        private EMGroupRoleType m_emRoleType = EMGroupRoleType.General;

        #endregion


        #region Initialize/Dispose

        public CTagGroupRole()
        {

        }

        public CTagGroupRole(string sGroupKey, EMGroupRoleType emRoleType)
        {
            m_sGroupKey = sGroupKey;
            m_emRoleType = emRoleType;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { m_sGroupKey = value; }
        }

        public EMGroupRoleType RoleType
        {
            get { return m_emRoleType; }
            set { m_emRoleType = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Mehtods


        #endregion
    }
}
