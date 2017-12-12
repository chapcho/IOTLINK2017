using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME.DataStruct
{
    [Serializable]
    public class PLCDeviceCommentBlock
    {

        #region Member Variables

        protected string m_sDeviceName;
        protected Int64 m_i64StartAddress;
        protected int m_iNumOfComment;
        protected int m_iRadix;

        #endregion

        #region Initialize/Dispose

        public PLCDeviceCommentBlock()
        {
            m_sDeviceName = String.Empty;
            m_i64StartAddress = 0;
            m_iNumOfComment = 0;
            m_iRadix = 0;
        }

        #endregion

        #region Public Properties

        public string DeviceName
        {
            get { return m_sDeviceName; }
            set { m_sDeviceName = value; }
        }
        public Int64 StartAddress
        {
            get { return m_i64StartAddress; }
            set { m_i64StartAddress = value; }
        }
        public int NumOfComment
        {
            get { return m_iNumOfComment; }
            set { m_iNumOfComment = value; }
        }
        public int Radix
        {
            get { return m_iRadix; }
            set { m_iRadix = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

    }

    [Serializable]
    public class PLCDeviceComment
    {

        #region Member Variables

        protected string m_sAddress; // 메모리 디바이스 어드레스
        protected string m_sAlias;  // 8Byte
        protected string m_sComment;

        #endregion

        #region Initialize/Dispose

        public PLCDeviceComment()
        {
            m_sAddress = String.Empty;
            m_sAlias = String.Empty;
            m_sComment = String.Empty;
        }

        #endregion

        #region Public Properties

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }
        public string Alias
        {
            get { return m_sAlias; }
            set { m_sAlias = value; }
        }
        public string Comment
        {
            get { return m_sComment; }
            set { m_sComment = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

    }
}
