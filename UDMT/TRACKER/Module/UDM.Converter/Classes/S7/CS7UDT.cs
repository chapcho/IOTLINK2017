using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7UDT
    {
        // Create by Qin Shiming at 2015.06.23
        //
        #region MemberVariables
        protected string m_sUDTName= string.Empty;
        protected string m_sUDTSymbol = string.Empty;
        protected string m_sUDTAddress = string.Empty;
        protected string m_sComment = string.Empty;
        protected int m_iDTLength = 0;
        protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;
        #endregion

        #region Initialze/Dispose
        public CS7UDT(string sUdtName)
        {
            m_sUDTName = sUdtName;
            m_dAddressTags = new CTagS();
            m_dSymbolTags = new CTagS();
        }
        #endregion

        #region Public Properites

        public string UDTName
        {
            get { return m_sUDTName; }
            set { m_sUDTName = value; }
        }
        public string UDTSymbol
        {
            get { return m_sUDTSymbol; }
            set { m_sUDTSymbol = value; }
        }
        public string UDTAddress
        {
            get { return m_sUDTAddress; }
            set { m_sUDTAddress = value; }
        }
        public string Comment
        {
            get { return m_sComment; }
            set { m_sComment = value; }
        }
        public int DTLength
        {
            get { return m_iDTLength; }
            set { m_iDTLength = value; }
        }
        public CTagS SymbolTags
        {
            get { return m_dSymbolTags; }
        }
        public CTagS AddressTags
        {
            get { return m_dAddressTags; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
