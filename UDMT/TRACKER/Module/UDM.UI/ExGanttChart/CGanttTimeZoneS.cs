using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttTimeZoneS : Dictionary<string, CGanttTimeZone>, IDisposable
    {
        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CGanttTimeZoneS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods


        #endregion
    }
}
