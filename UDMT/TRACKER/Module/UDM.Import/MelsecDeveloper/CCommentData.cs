using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CCommentData
    {
        #region Member Variables

        protected string _sHeader = "";
        protected string _sAddress = "";
        protected string _sLabel = "";
        protected string _sComment = "";

        protected byte[] _nLabelOrgByte = new byte[8];
        protected byte[] _nCommentOrgByte = new byte[32];

        #endregion


        #region Initialze

        #endregion


        #region Properties

        public string Header
        {
            get { return _sHeader; }
            set { _sHeader = value; }
        }

        public string Address
        {
            get { return _sAddress; }
            set { _sAddress = value; }
        }

        public string Label
        {
            get { return _sLabel; }
            set { _sLabel = value; }
        }

        public string Comment
        {
            get { return _sComment; }
            set { _sComment = value; }
        }

        public byte[] LabelOrgByte
        {
            get { return _nLabelOrgByte; }
            set { _nLabelOrgByte = value; }
        }

        public byte[] CommentOrgByte
        {
            get { return _nCommentOrgByte; }
            set { _nCommentOrgByte = value; }
        }

        #endregion


        #region Public Method

        #endregion
    }
}
