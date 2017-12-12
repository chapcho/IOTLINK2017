using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CParaMappingInfo:Dictionary<string,int>,ICloneable
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
            CParaMappingInfo cTempInfo = new CParaMappingInfo();

            foreach (string sTemp in this.Keys)
                cTempInfo.Add(sTemp, this[sTemp]);

            return cTempInfo;
        }

            #endregion

            #region Private Methods

            #endregion
    }
}
