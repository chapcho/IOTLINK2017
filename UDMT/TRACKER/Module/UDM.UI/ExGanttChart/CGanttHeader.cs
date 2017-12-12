using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UI.ExGanttChart
{
    public class CGanttHeader : IDisposable
    {

        #region Member Variables

        private string m_sCaption = string.Empty;
        private int m_iWidth = 50;
        
        #endregion


        #region Initialize/Dispose

        public CGanttHeader()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public string Caption
        {
            get { return m_sCaption; }
            set { m_sCaption = value; }
        }

        public int Width
        {
            get { return m_iWidth; }
            set { m_iWidth = value; }
        }

        #endregion


        #region Public Methods

        

        #endregion
    }
}
