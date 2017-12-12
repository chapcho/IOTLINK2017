using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CContactS : List<CContact>, ITagComposable, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CContactS()
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

        public void Compose(CTagS cTagS)
        {
            foreach (CContact cContact in this)
            {
                cContact.Compose(cTagS);
            }
        }

        public void Compose(CRefTagS cRefTagS)
        {
            foreach (CContact cContact in this)
            {
                cContact.Compose(cRefTagS);
            }
        }

        public void ComposeTagRoleS()
        {
            foreach (CContact cContact in this)
            {
                cContact.ComposeTagRoleS();
            }
        }

        #endregion
    }
}
