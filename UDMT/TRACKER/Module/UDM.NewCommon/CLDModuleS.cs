using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDModuleS:Dictionary<string,CLDModule>,ICloneable
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
            CLDModuleS tempModeleS = new CLDModuleS();

            foreach (string sTempKey in this.Keys)
                tempModeleS.Add(sTempKey, (CLDModule)this[sTempKey].Clone());

            return tempModeleS;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
