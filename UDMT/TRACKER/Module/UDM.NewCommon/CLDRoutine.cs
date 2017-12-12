using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDRoutine:CObject,IDisposable,ICloneable
    {
        #region Member Variables

        protected string m_sRoutineName = string.Empty;
        protected CStepS m_cLocalStepS = null;
        protected string m_sDescription = string.Empty;
        protected CJumpLabelS m_cJumpLabelS = null;

        #endregion

        #region Initialize/Dispose

        public CLDRoutine()
        {
            m_cLocalStepS = new CStepS();
            m_cJumpLabelS = new CJumpLabelS();
        }

        public new void Dispose()
        {
            m_cLocalStepS.Clear();
            m_cJumpLabelS.Clear();
            base.Dispose();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// String  :: Routine Name
        /// </summary>
        public string RoutineName
        {
            get { return m_sRoutineName; }
            set { m_sRoutineName = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        /// <summary>
        /// Steps
        /// </summary>
        public CStepS LocalStepS
        {
            get { return m_cLocalStepS; }
            set { m_cLocalStepS = value; }
        }

        /// <summary>
        /// Jump Label Mapping to Step Key
        /// </summary>
        public CJumpLabelS JumpLabelS
        {
            get { return m_cJumpLabelS; }
            set { m_cJumpLabelS = value; }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            CLDRoutine tempRoutine = new CLDRoutine();

            tempRoutine.Key = m_sKey;
            tempRoutine.RoutineName = m_sRoutineName;
            tempRoutine.Description = m_sDescription;
            tempRoutine.LocalStepS = (CStepS)m_cLocalStepS.Clone();
            tempRoutine.JumpLabelS = (CJumpLabelS)m_cJumpLabelS.Clone();

            return tempRoutine;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
