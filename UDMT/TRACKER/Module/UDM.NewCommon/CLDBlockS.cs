using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDBlockS:Dictionary<string,CLDBlock>,ICloneable
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
            CLDBlockS tempBlockS = new CLDBlockS();

            foreach (string sTempKey in this.Keys)
                tempBlockS.Add(sTempKey, (CLDBlock)this[sTempKey].Clone());

            return tempBlockS;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
