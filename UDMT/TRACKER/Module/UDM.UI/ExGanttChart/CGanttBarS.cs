using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace UDM.UI.ExGanttChart
{
    public class CGanttBarS:List<CGanttBar>, IDisposable
    {

        #region Member Variables

        protected object m_oData = null;

        #endregion


        #region Initialize/Dispose

        public CGanttBarS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
}
