using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace FTOPApp
{
    [Serializable]
    public class COPCItem : IDisposable
    {

        #region Member Variables

		protected string m_sKey = "";
        protected string m_sTagKey;
        protected string m_sTagAddress = "";
        protected EMPLCDataType m_emTagDataType = EMPLCDataType.Bool;

		protected bool m_bInstant = false;
        protected int m_iClientHandle = -1;
        protected int m_iServerHandle = -1;
		protected int m_iValue = -1;

        public string OPCChannel { get; set; }
        public string OPCDevice { get; set; }


        #endregion


        #region Initialize/Dispose

        public COPCItem(FTOPTagFull tag, bool bLsOpc, bool bAbOpc)
		{

            if (tag.PLCMaker == EMFTOPPLCMaker.YOKOGAWA || tag.PLCMaker == EMFTOPPLCMaker.MELSEC)
            {
                m_sKey = "[" + tag.OPCChannel + "]" + tag.OPCDevice + "." + tag.PLCAddress; // ex) [Channel]Device.I15001
            }
            else if (bLsOpc)
                m_sKey = "[" + tag.OPCChannel + "]" + tag.OPCDevice + ".%" + tag.PLCAddress; // ex) [Channel]Device.%PX00001
            else if (bAbOpc)
                m_sKey = "[" + tag.OPCChannel + "]" + tag.OPCDevice;
            else
                m_sKey = tag.OPCChannel + "." + tag.PLCAddress;
            m_sTagKey = tag.Key;
            m_sTagAddress = tag.PLCAddress;
            m_emTagDataType = tag.PLCDataType;

            OPCChannel = tag.OPCChannel;
            OPCDevice = tag.OPCDevice;
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

        public EMPLCDataType TagDataType
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
