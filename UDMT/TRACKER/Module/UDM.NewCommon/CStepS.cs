using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CStepS:Dictionary<string,CStep>,ICloneable
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
            CStepS tempStepS = new CStepS();

            foreach(string tempKey in this.Keys)
            {
                tempStepS.Add(tempKey, (CStep)this[tempKey].Clone());
            }

            return tempStepS;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
