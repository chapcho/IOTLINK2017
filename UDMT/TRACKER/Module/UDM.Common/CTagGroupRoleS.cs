using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CTagGroupRoleS : List<CTagGroupRole>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CTagGroupRoleS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties
        

        #endregion


        #region Public Methods

        public new void Add(CTagGroupRole cRole)
        {
            if (cRole.GroupKey.Trim() == "")
                return;

            if(IsContains(cRole.GroupKey) == false)
                base.Add(cRole);
        }

        public CTagGroupRole GetRole(string sGroupKey)
        {
            CTagGroupRole cRole = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].GroupKey == sGroupKey)
                {
                    cRole = this[i];
                    break;
                }
            }

            return cRole;
        }

        public void Remove(string sGroupKey)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].GroupKey == sGroupKey)
                {
                    this.RemoveAt(i);
                    break;
                }
            }
        }

		public void Rename(string sOldGroupKey, string sNewGroupKey)
		{
			CTagGroupRole cRole;
			for (int i = 0; i < this.Count; i++)
			{
				cRole = this[i];
				if (cRole.GroupKey == sOldGroupKey)
				{
					cRole.GroupKey = sNewGroupKey;
					break;
				}
			}
		}

        public bool IsContains(string sGroupKey)
        {
            bool bOK = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].GroupKey == sGroupKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        public bool IsContains(EMGroupRoleType emRoleType)
        {
            bool bOK = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].RoleType == emRoleType)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        #endregion
    }
}
