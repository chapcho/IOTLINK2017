using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB_DataRead
{
    public class CILStepData
    {
        #region Member Variables
        
        protected List<byte[]> _lstStepORGByte = new List<byte[]>();
        protected List<CContactData> _lstContact = new List<CContactData>();
        protected CMelsecCommand _cMelsecCommand = null;

        protected List<string> _lstFinalStepString = new List<string>();
        protected int _iStepGapNumber = 0;
        protected bool _bAnalyzeComp = false;
        protected EMStepType _emStepType = EMStepType.NONE;

        #endregion


        #region Initialze

        #endregion


        #region Properties

        /// <summary>
        /// Step단위로 자른 Byte값
        /// </summary>
        public List<byte[]> StepORGByteList
        {
            get { return _lstStepORGByte; }
            set { _lstStepORGByte = value; }
        }

        /// <summary>
        /// Step의 Command를 제외한 나머지 값(디바이스, 상수, 인덱스 등)
        /// </summary>
        public List<CContactData> ContactList
        {
            get { return _lstContact; }
            set { _lstContact = value; }
        }

        /// <summary>
        /// Command를 갖는 스텝일 경우 값이 채워짐.
        /// null일경우 StepType을 확인
        /// </summary>
        public CMelsecCommand Command
        {
            get { return _cMelsecCommand; }
            set { _cMelsecCommand = value; }
        }

        public EMStepType StepType
        {
            get { return _emStepType; }
            set { _emStepType = value; }
        }

        /// <summary>
        /// 분석이 완료되면 true
        /// </summary>
        public bool AnalyzeComp
        {
            get { return _bAnalyzeComp; }
            set { _bAnalyzeComp = value; }
        }

        /// <summary>
        /// 이전 스텝과 표시될때의 차이값
        /// </summary>
        public int StepGapNumber
        {
            get { return _iStepGapNumber; }
            set { _iStepGapNumber = value; }
        }

        /// <summary>
        /// 최종 Step에 찍힐값(,가 포함된 GX Developer에 CSV로 Convert되어 나온 내용과 동일해야함.)
        /// 단, Step Number의 경우 달라질 수 있으므로 포함하지 않는다.
        /// 여러 줄일 수 있다.
        /// </summary>
        public List<string> FinalStringList
        {
            get { return _lstFinalStepString; }
        }


        #endregion


        #region Public Method

        #endregion
    }
}
