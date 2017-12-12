using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CTagS:Dictionary<string,CTag>,ICloneable
    {
        #region Member Variables

        #endregion

        #region Initialize/Dispose

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        public object Clone()
        {
            CTagS cTagS = new CTagS();

            foreach(string sTempKey in this.Keys)
            {
                cTagS.Add(sTempKey, (CTag)this[sTempKey].Clone());
            }

            return cTagS;
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
