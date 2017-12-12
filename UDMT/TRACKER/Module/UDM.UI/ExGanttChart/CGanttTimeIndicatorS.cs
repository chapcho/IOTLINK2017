using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttTimeIndicatorS : List<CGanttTimeIndicator>, IDisposable
    {
        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CGanttTimeIndicatorS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public CGanttTimeIndicator this[string sKey]
        {
            get { return GetValue(sKey); }
        }

        #endregion


        #region Public Methods

        public bool ContainsKey(string sKey)
        {
            bool bOK = false;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == sKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        #endregion


        #region Private Methods

        private CGanttTimeIndicator GetValue(string sKey)
        {
            CGanttTimeIndicator cIndicator = null;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == sKey)
                {
                    cIndicator = this[i];
                    break;
                }
            }

            return cIndicator;
        }


        #endregion
    }
}
