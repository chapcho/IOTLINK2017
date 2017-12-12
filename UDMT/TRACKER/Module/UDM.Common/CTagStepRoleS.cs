using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CTagStepRoleS : List<CTagStepRole>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CTagStepRoleS()
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

        public new void Add(CTagStepRole cRole)
        {
            bool bOK = true;

            List<CTagStepRole> lstRole = this.Where(x => x.StepKey == cRole.StepKey).ToList();
            if (lstRole != null && lstRole.Count > 0)
            {
                CTagStepRole cRoleExist;
                for (int i = 0; i < lstRole.Count; i++)
                {
                    cRoleExist = lstRole[i];
                    if (cRoleExist.RoleType == EMStepRoleType.Both)
                    {
                        bOK = false;
                        break;
                    }
                    else if (cRole.RoleType == cRoleExist.RoleType)
                    {
                        bOK = false;
                        break;
                    }
                    else
                    {
                        cRoleExist.RoleType = EMStepRoleType.Both;
                        bOK = false;
                        break;
                    }
                }
            }

            if (bOK)
                base.Add(cRole);
        }

        public CTagStepRole GetRole(string sStepKey)
        {
            CTagStepRole cRole = null;
            for(int i=0;i<this.Count;i++)
            {
                if(this[i].StepKey == sStepKey)
                {
                    cRole = this[i];
                    break;
                }
            }

            return cRole;
        }

        public bool IsContains(string sStepKey)
        {
            bool bOK = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].StepKey == sStepKey)
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
