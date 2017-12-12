using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CUnit:IDisposable,ICloneable
    {
        #region Member Variables

        protected string m_sInstruction = "";
        protected string m_sOperator = "";
        protected string m_sStep = "";
        protected int m_iUnitIndex = -1;
        protected EMLogicUnitType m_emLogicUnitType = EMLogicUnitType.Contact;
        protected CContentS m_cContentS = new CContentS();
        protected CRelation m_cRelation = null;

        #endregion

        #region Initialize/Dispose

        public CUnit()
        {
            m_cRelation = new CRelation();
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// 명령어 + 사용 정보
        /// </summary>
        public string Instruction
        {
            get { return m_sInstruction; }
            set { m_sInstruction = value; }
        }

        /// <summary>
        /// 명령어
        /// </summary>
        public string Operator
        {
            get { return m_sOperator; }
            set { m_sOperator = value; }
        }

        /// <summary>
        /// Step정보
        /// </summary>
        public string StepKey
        {
            get { return m_sStep; }
            set { m_sStep = value; }
        }

        /// <summary>
        /// 명령어 사용 하는 속성
        /// </summary>
        public CContentS ContentS
        {
            get { return m_cContentS; }
            set { m_cContentS = value; }
        }

        /// <summary>
        /// Unit의 전후 로직 관계
        /// </summary>
        public CRelation Relation
        {
            get { return m_cRelation; }
            set { m_cRelation = value; }
        }

        /// <summary>
        /// Step 안에의 Index
        /// </summary>
        public int UnitIndex
        {
            get { return m_iUnitIndex; }
            set { m_iUnitIndex = value; }
        }

        /// <summary>
        /// Contact, Coil or FunctionBlock
        /// </summary>
        public EMLogicUnitType UnitType
        {
            get { return m_emLogicUnitType; }
            set { m_emLogicUnitType = value; }
        }


        #endregion

        #region Public Methods

        public virtual object Clone()
        {
            CUnit cUnit = new CUnit();

            cUnit.Instruction = m_sInstruction;
            cUnit.Operator = m_sOperator;
            cUnit.StepKey = m_sStep;
            cUnit.ContentS = (CContentS)m_cContentS.Clone();
            cUnit.Relation = (CRelation)m_cRelation.Clone();
            cUnit.UnitIndex = m_iUnitIndex;
            cUnit.UnitType = m_emLogicUnitType;

            return cUnit;
        }

        public virtual object Clone(Type type)
        {
            if (type.BaseType != this.GetType())
                return null;

            object obj = Activator.CreateInstance(type);

            CUnit cUnit = (CUnit)obj;

            cUnit.Instruction = m_sInstruction;
            cUnit.Operator = m_sOperator;
            cUnit.StepKey = m_sStep;
            cUnit.ContentS = (CContentS)m_cContentS.Clone();
            cUnit.Relation = (CRelation)m_cRelation.Clone();
            cUnit.UnitIndex = m_iUnitIndex;
            cUnit.UnitType = m_emLogicUnitType;

            return obj;
        }

        #endregion

        #region Private Methods

        private void Clear()
        {
            m_cContentS.Dispose();
        }

        #endregion
    }
}
