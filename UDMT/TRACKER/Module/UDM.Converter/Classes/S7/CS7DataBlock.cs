using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7DataBlock
    {
        // Create by Qin Shiming at 2015.06.23
        //
        #region MemberVariables

        protected string m_sDBName = string.Empty;
        protected string m_sDBSymbol = string.Empty;
        protected string m_sDBAddress = string.Empty;
        protected string m_sComment = string.Empty;
        protected int m_iDTLength = 0;
        protected CTagS m_dSymbolTags = null;
        protected CTagS m_dAddressTags = null;

        #endregion

        #region Initialze/Dispose

        public CS7DataBlock(string sDBName)
        {
            m_sDBName = sDBName;

            m_dAddressTags = new CTagS();
            m_dSymbolTags = new CTagS();
        }
        #endregion

        #region Public Properites

        public string DBName
        {
            get { return m_sDBName; }
            set { m_sDBName = value; }
        }

        public string DBSymbol
        {
            get { return m_sDBSymbol; }
            set { m_sDBSymbol = value; }
        }

        public string DBAddress
        {
            get { return m_sDBAddress; }
            set { m_sDBAddress = value; }
        }

        public string Comment
        {
            get { return m_sComment; }
            set { m_sComment = value; }
        }

        public int DBLength
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
