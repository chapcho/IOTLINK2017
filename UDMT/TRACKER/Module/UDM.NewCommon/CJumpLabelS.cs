using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CJumpLabelS:Dictionary<string,string>,ICloneable
    {
        #region Member Variables

        #endregion

        #region Initialize/Dispose

        public void Dispose()
        {
            this.Clear();
        }

        #endregion

            #region Public Properties

            #endregion

            #region Public Methods

        public object Clone()
        {
            CJumpLabelS ctemp = new CJumpLabelS();

            foreach (string sTemp in this.Keys)
                ctemp.Add(sTemp, this[sTemp]);

            return ctemp;
        }

            #endregion

            #region Private Methods

            #endregion
    }
}
