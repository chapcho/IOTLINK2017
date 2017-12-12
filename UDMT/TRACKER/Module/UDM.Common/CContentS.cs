using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CContentS : List<CContent>, ITagComposable, IDisposable
    {

        #region Member Variables

        
        #endregion


        #region Initialize/Dispose

        public CContentS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Propoerties


        #endregion


        #region Public Methods

        public void Compose(CTagS cTagS)
        {
            foreach (CContent cArg in this)
            {
                cArg.Compose(cTagS);
            }
        }

        public void Compose(CRefTagS cRefTagS)
        {
            foreach (CContent cArg in this)
            {
                cArg.Compose(cRefTagS);
            }
        }

        public void ComposeTagRoleS(CTagStepRole cTagRole)
        {
            foreach (CContent cArg in this)
            {
                cArg.ComposeTagRoleS(cTagRole);
            }
        }

        #endregion
    }
}
