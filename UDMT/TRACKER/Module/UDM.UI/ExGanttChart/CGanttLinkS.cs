using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttLinkS : List<CGanttLink>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CGanttLinkS()
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
		public bool ContainsKey(string sKey)
		{
			bool bOK = false;
			for(int i = 0; i < this.Count; i++)
			{
				if (this[i].Key.Equals(sKey))
				{ 
					bOK = true;
					break;
				}
			}

			return bOK;
		}

        #endregion


        #region Private Methods


        #endregion

    }
}
