using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CSymbol : CObject
    {
        #region Member Variables

        protected string m_sGroupKey = "";
        protected CTag m_cTag = null;
        protected CSymbolS m_cSubSymbolS = new CSymbolS();
        protected EMGroupRoleType m_emRoleType = EMGroupRoleType.General;
        protected int m_iLowerBound = -1;
        protected int m_iUpperBound = -1;
        protected object m_oData = null;

        [NonSerialized]
        protected int m_iValue = -1;
        [NonSerialized]
        protected string m_sValue = "";
        [NonSerialized]
        protected int m_iCount = 0;

        #endregion


        #region Initialize/Dispose

        public CSymbol()
        {
            m_cTag = new CTag();
        }

        public CSymbol(CTag cTag)
        {
            if(cTag != null)
                m_sKey = cTag.Key;

            m_cTag = cTag;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properies

        public string GroupKey
        {
            get { return m_sGroupKey; }
            set { SetGroupKey(value); }
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; if(m_cTag != null) {m_sKey = m_cTag.Key;} }
        }

        public CSymbolS SubSymbolS
        {
            get { return m_cSubSymbolS; }
            set { m_cSubSymbolS = value; }
        }

        public new string Key
        {
            get { return GetKey(); }
            set { SetKey(value); }
        }

        public string Name
        {
            get { return GetName(); }
            set { SetName(value); }
        }

        public string Address
        {
            get { return GetAddress(); }
            set { SetAddress(value); }
        }

        public string Description
        {
            get { return GetDescription(); }
            set { SetDescription(value); }
        }

        public int Size
        {
            get { return GetSize(); }
            set { SetSize(value); }
        }

        public EMDataType DataType
        {
            get { return GetDataType(); }
            set { SetDataType(value); }
        }

        public EMGroupRoleType RoleType
        {
            get { return m_emRoleType; }
            set { SetRoleType(value); }
        }

        public int LowerBound
        {
            get { return m_iLowerBound; }
            set { m_iLowerBound = value; }
        }

        public int UpperBound
        {
            get { return m_iUpperBound; }
            set { m_iUpperBound = value; }
        }

        public int Value
        {
            get { return m_iValue; }
            set { m_iValue = value; }
        }

        public string CurrentValue
        {
            get { return m_sValue; }
            set { m_sValue = value; }
        }

        public int ChangeCount
        {
            get { return m_iCount; }
            set { m_iCount = value; }
        }

        public object Data
        {
            get { return m_oData; }
            set { m_oData = value; }
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods
        
        private string GetName()
        {
            if (m_cTag == null)
                return "";

            return m_cTag.Key;
        }

        private void SetName(string sValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.Key = sValue;
        }

        private string GetKey()
        {
            if (m_cTag == null)
                return "";

            return m_cTag.Key;
        }

        private void SetKey(string sValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.Key = sValue;
        }

        private string GetAddress()
        {
            if (m_cTag == null)
                return "";

            return m_cTag.Address;
        }

        private void SetAddress(string sValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.Address = sValue;
        }

        private string GetDescription()
        {
            if(m_cTag == null)
                return "";

            return m_cTag.Description;
        }

        private void SetDescription(string sValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.Description = sValue;
        }

        private EMDataType GetDataType()
        {
            if (m_cTag == null)
                return EMDataType.None;

            return m_cTag.DataType;
        }

        private void SetDataType(EMDataType emValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.DataType = emValue;
        }

        private int GetSize()
        {
            if (m_cTag == null)
                return -1;

            return m_cTag.Size;
        }

        private void SetSize(int iValue)
        {
            if (m_cTag == null)
                return;

            m_cTag.Size = iValue;
        }

        private void SetRoleType(EMGroupRoleType emRoleType)
        {
            m_emRoleType = emRoleType; 
            if(m_cTag != null)
            {
                CTagGroupRole cRole = m_cTag.GroupRoleS.GetRole(m_sGroupKey);
                if (cRole != null)
                    cRole.RoleType = emRoleType;
            }
        }

        private void SetGroupKey(string sValue)
        {
            m_sGroupKey = sValue;
			if (m_cSubSymbolS == null)
				m_cSubSymbolS = new CSymbolS();
            //m_cSubSymbolS.GroupKey = sValue;

            for (int i = 0; i < m_cSubSymbolS.Count; i++)
                m_cSubSymbolS[i].GroupKey = sValue;
        }
        #endregion
    }
}
