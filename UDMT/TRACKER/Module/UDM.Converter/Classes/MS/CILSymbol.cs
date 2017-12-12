using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILSymbol
    {
        #region Memeber Variables

        protected string m_sKey = string.Empty;
        protected string m_sName = string.Empty;
        protected string m_sAddress = string.Empty;
        protected string m_sDescription = string.Empty;
        protected EMDataType m_emDataType = EMDataType.Bool;
        protected EMMemoryType m_emAddressType = EMMemoryType.UnKnown;
        protected Color m_cColor = Color.Blue;
        protected int m_iValue = -1;
        protected EMPLCMaker m_emPLCMaker = EMPLCMaker.Melsec;
        protected string m_sProgram = string.Empty;
        protected DateTime m_dtTime;

        #endregion

        #region Initialize/Dispose

        public CILSymbol(string sSymbol, string sAddress, string sProgram)
        {
            Name = sSymbol;
            Address = sAddress;
            m_sProgram = sProgram;

            this.Key = string.Format("{0}.{1}", sProgram, sAddress);
            this.DataType = GetDataType();
        }

        public void Dispose()
        {

        }

        #endregion

        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Address
        {
            set { m_sAddress = value; }
            get { return m_sAddress; }
        }

        public string Description
        {
            set { m_sDescription = value; }
            get { return m_sDescription; }
        }

        public string Text
        {
            get { return m_sName; }
            set { return; }
        }

        public EMDataType DataType
        {
            set { m_emDataType = value; }
            get { return m_emDataType; }
        }

        public EMMemoryType AddressType
        {
            set { m_emAddressType = value; }
            get { return m_emAddressType; }
        }

        public Color Color
        {
            get { return m_cColor; }
            set { m_cColor = value; }
        }


        public int Value
        {
            get { return m_iValue; }
            set { m_iValue = value; }
        }


        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
            set { m_emPLCMaker = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }


        public DateTime Time
        {
            get { return m_dtTime; }
            set { m_dtTime = value; }
        }


        #endregion

        #region Public Methods

        public object Clone()
        {
            CILSymbol cSymbol = new CILSymbol(m_sDescription, m_sAddress, m_sProgram);

            cSymbol.Name = m_sName;
            cSymbol.Name = m_sKey;
            cSymbol.Address = m_sAddress;
            cSymbol.Description = m_sDescription;
            cSymbol.DataType = m_emDataType;

            return cSymbol;
        }


        private EMDataType GetDataType()
        {
            if (CPlcMelsec.IsBit(Address))
                return EMDataType.Bool;
            else if (CPlcMelsec.IsWord(Address))
                return EMDataType.Word;
            else
                return EMDataType.None;
        }

        #endregion

        #region protected Methods


        #endregion
    }
}
