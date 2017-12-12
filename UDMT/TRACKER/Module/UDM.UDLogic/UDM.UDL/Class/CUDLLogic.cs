using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.UDL
{
    public class CUDLLogic
    {

        protected string m_sLogic = string.Empty;
        protected int m_iStepIndex = 0;
        protected Dictionary<string, string> m_DicSubLogic = new Dictionary<string, string>();

        #region Intialize/Dispose
        #endregion

        #region Public Properties
        public string Logic
        {
            get { return m_sLogic; }
            set { m_sLogic = value; }
        }

        public int StepIndex
        {
            get { return m_iStepIndex; }
            set { m_iStepIndex = value; }
        }

        public Dictionary<string,string> SubLogicS
        {
            get { return m_DicSubLogic; }
            set { m_DicSubLogic = value; }
        }
       
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
