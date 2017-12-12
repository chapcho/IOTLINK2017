using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7Step:CStep
    {
        // Create by Qin Shiming at 2015.06.22
        // Frist edit at 2015.07.01 by Qin Shiming
        #region MemberVariables
        Dictionary<string, CContactS> m_dLocalMem = null;
        #endregion

        #region Initialze/Dispose

        public CS7Step()
            : base()
        {
            m_dLocalMem = new Dictionary<string, CContactS>();
        }

        #endregion

        #region Public Properites

        public Dictionary<string, CContactS> LocalMemory
        {
            get { return m_dLocalMem; }
            set { m_dLocalMem = value; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
