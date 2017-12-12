using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CLabel : CObject
    {
        private string m_sName = string.Empty;
        private int m_iLabel = -1;
        private CTag m_cTag = null;
        //private EMArgmentType m_emLabelCase = EMArgmentType.None;
        private bool m_bUsingSource = true;

        #region Initialize/Dispose

        public CLabel(int iLabel)
        {
            m_iLabel = iLabel;
            m_sKey = iLabel.ToString();
        }


        #endregion


        #region Public Properites

        public int Index
        {
            get { return m_iLabel; }
            set { m_iLabel = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public CTag LabelTag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }
// 
//         public EMArgmentType LabelCase
//         {
//             get { return m_emLabelCase; }
//             set { m_emLabelCase = value; }
//         }

        public bool IsUsingSource
        {
            get { return m_bUsingSource; }
            set { m_bUsingSource = value; }
        }        

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods



        #endregion
    }
}
