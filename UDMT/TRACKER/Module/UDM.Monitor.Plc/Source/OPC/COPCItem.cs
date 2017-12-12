using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Monitor.Plc.Source.OPC
{
    public class COPCItem : IDisposable
    {

        #region Member Variables

		protected string m_sKey = "";
		protected string m_sTagKey = "";
        protected string m_sTagAddress = "";
        protected EMDataType m_emTagDataType = EMDataType.Bool;

		protected bool m_bInstant = false;
        protected int m_iClientHandle = -1;
        protected int m_iServerHandle = -1;
		protected int m_iValue = -1;

        #endregion


        #region Initialize/Dispose

		public COPCItem(CTag cTag, bool bLsOpc)
		{
            if (bLsOpc)
                m_sKey = cTag.Channel + cTag.Address;
            else
                m_sKey = cTag.Channel + "." + cTag.Address;
			m_sTagKey = cTag.Key;
			m_sTagAddress = cTag.Address;
			m_emTagDataType = cTag.DataType;
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

		public string TagKey
		{
			get { return m_sTagKey; }
			set { m_sTagKey = value; }
		}

        public string TagAddress
        {
            get { return m_sTagAddress; }
            set { m_sTagAddress = value; }
        }

        public EMDataType TagDataType
        {
            get { return m_emTagDataType; }
            set { m_emTagDataType = value; }
        }

		public bool IsInstantItem
		{
			get { return m_bInstant; }
			set { m_bInstant = value; }
		}

        public int ServerHandle
        {
            get { return m_iServerHandle; }
            set { m_iServerHandle = value; }
        }

        public int ClientHandle
        {
            get { return m_iClientHandle; }
            set { m_iClientHandle = value; }
        }

		public int Value
		{
			get { return m_iValue; }
			set { m_iValue = value; }
		}

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion

    }
}
