using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace UDM.UDLImport
{
    public class CLabel
    {
        string m_sName = string.Empty;
        List<EMDataType> m_lstDataType = new List<EMDataType>();
        bool m_bConstant = false;
        int m_iLabelIndex = 0;

        #region Initialize/Dispose

        #endregion

        #region Properties

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public List<EMDataType> lstDataType
        {
            get { return m_lstDataType; }
            set { m_lstDataType = value; }
        }

        public bool Constant
        {
            get { return m_bConstant; }
            set { m_bConstant = value; }
        }

        public int LabelIndex
        {
            get { return m_iLabelIndex; }
            set { m_iLabelIndex = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
