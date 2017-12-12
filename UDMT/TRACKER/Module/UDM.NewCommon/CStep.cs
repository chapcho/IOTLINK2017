using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CStep:CObject,IDisposable,ICloneable
    {
        #region Member Variables

        protected string m_sName = string.Empty;
        protected int m_iStepIndex = -1;
        protected string m_sSituation = string.Empty;
        protected string m_sMasterControl = string.Empty;
        protected string m_sJumpLabel = string.Empty;
        protected CUnitS m_cUnitS = null;
        #endregion

        #region Initialize/Dispose

        public CStep()
        {
            m_cUnitS = new CUnitS();
        }

        public new void Dispose()
        {
            m_cUnitS.Dispose();
            base.Dispose();
        }

        #endregion

        #region Public Properties

        ///Key is Routine Name + "." + Step Name
        
        /// <summary>
        /// Step/Network Name
        /// </summary>
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        /// <summary>
        /// This Step's Index in one Routine
        /// </summary>
        public int StepIndex
        {
            get { return m_iStepIndex; }
            set { m_iStepIndex = value; }
        }

        /// <summary>
        /// Description
        /// </summary>
        public string Situation
        {
            get { return m_sSituation; }
            set { m_sSituation = value; }
        }

        /// <summary>
        /// Master Control Step Key
        /// </summary>
        public string MasterControl
        {
            get { return m_sMasterControl; }
            set { m_sMasterControl = value; }
        }
        
        /// <summary>
        /// Label when this step controled by a jump operator
        /// </summary>
        public string JumpLabel
        {
            get { return m_sJumpLabel; }
            set { m_sJumpLabel = value; }
        }

        /// <summary>
        /// Logic Units in this step
        /// </summary>
        public CUnitS UnitS
        {
            get { return m_cUnitS; }
            set { m_cUnitS = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CStep tempStep = new CStep();

            tempStep.Key = m_sKey;
            tempStep.Name = m_sName;
            tempStep.Situation = m_sSituation;
            tempStep.MasterControl = m_sMasterControl;
            tempStep.JumpLabel = m_sJumpLabel;
            tempStep.StepIndex = m_iStepIndex;
            tempStep.UnitS = (CUnitS)m_cUnitS.Clone();

            return tempStep;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
