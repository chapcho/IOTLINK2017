using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CTag:CObject,ICloneable
    {
        #region Member Variables

        protected string m_sName = string.Empty;
        protected string m_sAddress = string.Empty;
        protected string m_sDescription = string.Empty;
        protected string m_sLinkAddress = string.Empty;
        protected string m_sChannel = string.Empty;
        protected object m_obTagValue = null;
        protected int m_iSize = 1;
        protected EMDataType m_emDataType = EMDataType.Bool;
        protected string m_sUdttype = string.Empty;

        #endregion

        #region Initialize/Dispose

        public CTag()
        {

        }

        

        #endregion

        #region Public Properties

        /// <summary>
        /// Real Address 
        /// If this tag is a Alias Tag then write original address in here
        /// </summary>
        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        /// <summary>
        /// Tag Name
        /// If is not a alias tag then same to address
        /// </summary>
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        /// <summary>
        /// Opc Channel Information
        /// </summary>
        public string Channel
        {
            get { return m_sChannel; }
            set { m_sChannel = value; }
        }

        /// <summary>
        /// Data type
        /// </summary>
        public string UDTType
        {
            get { return m_sUdttype; }
            set { m_sUdttype = value; }
        }

        /// <summary>
        /// When Tag use like A100[B0], X100Z10, then sub tag B0, Z10 is the LinkAddress
        /// </summary>
        public string LinkAddress
        {
            get { return m_sLinkAddress; }
            set { m_sLinkAddress = value; }
        }

        /// <summary>
        /// Bit Size
        /// </summary>
        public int Size
        {
            get { return m_iSize; }
            set { m_iSize = value; }
        }

        /// <summary>
        /// Data type
        /// </summary>
        public EMDataType DataType
        {
            get { return m_emDataType; }
            set { m_emDataType = value; }
        }

        /// <summary>
        /// Tag Value
        /// </summary>
        public object TagValue
        {
            get { return m_obTagValue; }
            set { m_obTagValue = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CTag cTag = new CTag();
            cTag.Name = m_sName;
            cTag.Key = m_sKey;
            cTag.m_sAddress = m_sAddress;
            cTag.Description = m_sDescription;
            cTag.LinkAddress = m_sLinkAddress;
            cTag.Channel = m_sChannel;
            cTag.TagValue = m_obTagValue;
            cTag.Size = m_iSize;
            cTag.DataType = m_emDataType;
            cTag.UDTType = m_sUdttype;

            return cTag;
        }

        #endregion
    }
}
