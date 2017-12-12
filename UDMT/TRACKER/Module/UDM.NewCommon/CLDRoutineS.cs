using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDRoutineS:Dictionary<string,CLDRoutine>,ICloneable
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
            CLDRoutineS tempRoutineS = new CLDRoutineS();

            foreach (string sTempKey in this.Keys)
                tempRoutineS.Add(sTempKey, (CLDRoutine)this[sTempKey].Clone());

            return tempRoutineS;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
