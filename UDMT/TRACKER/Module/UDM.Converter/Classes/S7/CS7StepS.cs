using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7StepS:CStepS
    {
        // Create by Qin Shiming at 2015.06.30
        // Frist edit at 2015.07.01 by Qin Shiming
        #region MemberVariables

        CS7StepS m_dJumpLabelDic = null;

        #endregion

        #region Initialze/Dispose

        public CS7StepS()
            : base()
        {
        }

        #endregion

        #region Public Properites

        public CS7StepS JumpLabelDic
        {
            get { return m_dJumpLabelDic; }
            set { m_dJumpLabelDic = value; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
