using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassMultiCopy
{
    public class CMultiCopyCombination
    {
        #region Initialize/Dispose

        public CMultiCopyCombination()
        {

        }

        #endregion

        #region Public Methods

        public string KeyFuntion(string sKey, object oSelect)
        {
            string[] Value = oSelect.ToString().Split(',');

            foreach (string Values in Value)
            {
                sKey = sKey + Values.Replace(" ", "") + "+";
            }
            return sKey;
        }

        #endregion
    }
}
