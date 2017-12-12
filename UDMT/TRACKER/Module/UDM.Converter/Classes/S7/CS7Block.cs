using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7Block
    {
        // Create by Qin Shiming at 2015.06.22
        // Frist edit at 2015.06.28 by Qin Shiming 

        #region MemberVariables

        protected CTagS m_dInputTags = null;
        protected CTagS m_dOutputTags = null;
        protected CTagS m_dInOutTags = null;
        protected CTagS m_dStatTags = null;
        protected CTagS m_dtempTags = null;

        protected CTagS m_dTotalInternalTags = null;
        protected CStepS m_lInternalLogics = null;
        protected CStepS m_dJumpLabelDic = null;
        protected CS7DataBlock m_cInstanceDB = null;

        protected EMS7BlockType m_eBlockType = EMS7BlockType.None;

        protected string m_sBlockName = string.Empty;
        protected string m_sBlockSymbol = string.Empty;
        protected string m_sBlockAddress = string.Empty;
        protected string m_sBlockComment = string.Empty;
        protected string m_sDescription = string.Empty;

        protected int m_iTagLenght = 0;

        #endregion

        #region Initialze/Dispose

        public CS7Block(string sblockname)
        {
            m_sBlockName = sblockname;

            m_dInputTags = new CTagS();
            m_dInOutTags = new CTagS();
            m_dOutputTags = new CTagS();
            m_dStatTags = new CTagS();
            m_dtempTags = new CTagS();

            m_dTotalInternalTags = new CTagS();
            m_lInternalLogics = new CStepS();
        }

        #endregion

        #region Public Properites

        public CTagS InputTags
        {
            get { return m_dInputTags; }
        }
        public CTagS InOUtTags
        {
            get { return m_dInOutTags; }
        }
        public CTagS OutputTags
        {
            get { return m_dOutputTags; }
        }
        public CTagS StatTags
        {
            get { return m_dStatTags; }
        }
        public CTagS TempTags
        {
            get { return m_dtempTags; }
        }
        public CTagS TotalInternalTags
        {
            get { return m_dTotalInternalTags; }
        }
        public CStepS InternalLogic
        {
            get { return m_lInternalLogics; }
        }
        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }
        public CS7DataBlock InstanceDB
        {
            get { return m_cInstanceDB; }
            set { m_cInstanceDB = value; }
        }
        public EMS7BlockType BlockType
        {
            get { return m_eBlockType; }
            set { m_eBlockType = value; }
        }
        public string BlockName
        {
            get { return m_sBlockName; }
            set { m_sBlockName = value; }
        }
        public string BlockAddress
        {
            get { return m_sBlockAddress; }
            set { m_sBlockAddress = value; }
        }
        public string BlockSymbol
        {
            get { return m_sBlockSymbol; }
            set { m_sBlockSymbol = value; }
        }
        public string BlockComment
        {
            get { return m_sBlockComment; }
            set { m_sBlockComment = value; }
        }
        public int BlockTagLength
        {
            get { return m_iTagLenght; }
            set { m_iTagLenght = value; }
        }
        public CStepS JumpLabelS
        {
            get { return m_dJumpLabelDic; }
            set { m_dJumpLabelDic = value; }
        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}
