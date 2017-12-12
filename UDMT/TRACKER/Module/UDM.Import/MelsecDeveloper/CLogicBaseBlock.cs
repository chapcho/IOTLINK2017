using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CLogicBaseBlock
    {
        #region Member Veriables

        protected byte[] _naTargetByte = null;
        protected byte[] _naBlockByteOrg = null;
        protected bool _bAnalyzeComplete = false;
        protected bool _bSingleOP = true;
        protected EMLadderBlockTpye _emBlockType = EMLadderBlockTpye.NONE;
        protected string _sResult = string.Empty;
        protected int _iStepNumber = 0;
        protected int _iStepNumberCount = 0;
        protected int _iFactorCount = 0;

        #endregion


        #region Initialize

        #endregion


        #region Properties

        public string ResultString
        {
            get { return _sResult; }
            set { _sResult = value; }
        }
    
        public bool AnalyzeComplete
        {
            get { return _bAnalyzeComplete; }
            set { _bAnalyzeComplete = value; }
        }

        public EMLadderBlockTpye BlockType
        {
            get { return _emBlockType; }
            set { _emBlockType = value; }
        }

        public int StepNumber
        {
            get { return _iStepNumber; }
            set { _iStepNumber = value; }
        }

        public int StepNumberCount
        {
            get { return _iStepNumberCount; }
            set { _iStepNumberCount = value; }
        }

        public byte[] BlockByteORG
        {
            get { return _naBlockByteOrg; }
            set { _naBlockByteOrg = value; }
        }

        public byte[] TargetByte
        {
            get { return _naTargetByte; }
            set { _naTargetByte = value; }
        }

        public int FactorCount
        {
            get { return _iFactorCount; }
            set
            {
                //if (_emBlockType == EMLadderBlockTpye.COMMAND)
                    _iFactorCount = value;
            }
        }

        /// <summary>
        /// 인자를 하나만 갖는 명령어
        /// </summary>
        public bool SingleOP
        {
            get { return _bSingleOP; }
            set { _bSingleOP = value; }
        }

        #endregion


        #region Private Method

        #endregion
    }
}
