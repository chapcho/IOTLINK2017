using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDMPresenter
{
    [Serializable]
    public class CFilterOption
    {
        #region Member Variables

        private int m_iDepth = 1;
        private int m_iMaxWord = 94;
        private bool m_bAddressFilter = true;
        private bool m_bDescriptionFilter = true;
        private EMDataType m_emDataType = EMDataType.Bool;

        private List<string> m_lstBaseAddress = new List<string>();
        private List<string> m_lstAddressFilter = new List<string>();
        private List<string> m_lstDescriptionFilter = new List<string>();

        #endregion

        #region Pubilc Properties

        public int Depth
        {
            get { return m_iDepth; }
            set { m_iDepth = value; }
        }

        public int MaxWord
        {
            get { return m_iMaxWord; }
            set { m_iMaxWord = value; }
        }

        public bool UseAddressFilter
        {
            get { return m_bAddressFilter; }
            set { m_bAddressFilter = value; }
        }

        public bool UseDescriptionFilter
        {
            get { return m_bDescriptionFilter; }
            set { m_bDescriptionFilter = value; }
        }

        public EMDataType DataType
        {
            get { return m_emDataType; }
            set { m_emDataType = value; }
        }

        public List<string> BaseAddressList
        {
            get { return m_lstBaseAddress; }
            set { m_lstBaseAddress = value; }
        }

        public List<string> AddressFilterList
        {
            get { return m_lstAddressFilter; }
            set { m_lstAddressFilter = value; }
        }

        public List<string> DescriptionFilterList
        {
            get { return m_lstDescriptionFilter; }
            set { m_lstDescriptionFilter = value; }
        }

        #endregion

        #region Public Mehtods

        public void Clear()
        {
            m_iDepth = 0;
            m_iMaxWord = 94;
            m_bAddressFilter = true;
            m_bDescriptionFilter = true;
            m_emDataType = EMDataType.Bool;

            m_lstBaseAddress.Clear();
            m_lstAddressFilter.Clear();
            m_lstDescriptionFilter.Clear();
        }

        #endregion

    }
}
