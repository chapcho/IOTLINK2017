using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CTagItem
    {
        private string m_sKey = string.Empty;
        private string m_sAddress = string.Empty;
        private string m_sDescription = string.Empty;
        private string m_sName = string.Empty;
        private string m_sNote = string.Empty;
        private EMDataType m_emDataType = EMDataType.None;

        private bool m_bInsert = false;

        #region Initialize/Dispose


        #endregion

        #region Properties

        public bool IsInsertTag
        {
            get { return m_bInsert;}
            set { m_bInsert = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Note
        {
            get { return m_sNote; }
            set { m_sNote = value; }
        }


        public string Key
        {
            get { return m_sKey;}
            set { m_sKey = value; }
        }

        public string Address
        {
            get { return m_sAddress;}
            set { m_sAddress = value; }
        }

        public string Description
        {
            get { return m_sDescription;}
            set { m_sDescription = value; }
        }

        public EMDataType DataType
        {
            get { return m_emDataType;}
            set { m_emDataType = value; }
        }


        #endregion

        #region Public Methods


        #endregion


        #region Private Methods

        #endregion


    }
}
