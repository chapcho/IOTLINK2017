using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowLink : CTimeNodeLink
    {

        #region Member Variables


        #endregion


        #region Intiialize/Dispose

        public CFlowLink()
        {

        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public object Clone(CFlowItemS cItemS)
        {
            CFlowLink cLinkClone = new CFlowLink();
            cLinkClone.NodeFrom = cItemS.GetNode(m_cNodeFrom.Key, m_cNodeFrom.Start);
            cLinkClone.NodeTo = cItemS.GetNode(m_cNodeTo.Key, m_cNodeTo.Start);

            cLinkClone.PointTypeFrom = m_emPointTypeFrom;
            cLinkClone.PointTypeTo = m_emPointTypeTo;
            cLinkClone.Interval = m_nInterval;

            return cLinkClone;
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
