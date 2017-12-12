using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowLinkS : List<CFlowLink>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CFlowLinkS()
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

        public object Clone(CFlowItemS cItemS)
        {
            CFlowLinkS cLinkSClone = new CFlowLinkS();
            CFlowLink cLink;
            CFlowLink cLinkClone;
            for (int i = 0; i < this.Count; i++)
            {
                cLink = this[i];
                cLinkClone = (CFlowLink)cLink.Clone(cItemS);

                if (cLinkClone != null)
                    cLinkSClone.Add(cLinkClone);
            }

            return cLinkSClone;
        }

        #endregion

    }
}
