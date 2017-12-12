using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMOptimizerReader
{
    public class CBitDevice
    {
        #region Member Variables
        
        protected int m_iCurrentValue = -1;

        #endregion

        #region Properties

        public CTag Tag { get; set; }
        public int MajorNumber { get; set; }

        public int MinorNumber { get; set; }

        public int CurrentValue 
        {
            get { return m_iCurrentValue; }
            set { m_iCurrentValue = value; }
        }

        #endregion
    }
}
