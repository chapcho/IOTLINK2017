using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CParameterS:Dictionary<string,EMFunctionParaType>,ICloneable
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
            CParameterS tempParameterS = new CParameterS();

            foreach (string stempKey in this.Keys)
                tempParameterS.Add(stempKey, this[stempKey]);

            return tempParameterS;
        }

            #endregion

            #region Private Methods

            #endregion
    }
}
