using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.NewCommon
{
    [Serializable]
    public class CLDBlock:CObject,IDisposable,ICloneable
    {
        #region Member Variables

        protected string m_SBlockName = string.Empty;
        protected string m_sDescription = string.Empty;
        protected string m_sMainRoutine = string.Empty;
        protected int m_iParameterSize = 0;
        protected CParameterS m_cParameterKeyS = null;
        protected CTagS m_cLocalTagS = null;
        protected CLDRoutineS m_cRoutineS = null;

        #endregion

        #region Initialize/Dispose

        public CLDBlock()
        {
            m_cParameterKeyS = new CParameterS();
            m_cLocalTagS = new CTagS();
            m_cRoutineS = new CLDRoutineS();
        }

        public new void Dispose()
        {
            m_cRoutineS.Clear();
            m_cLocalTagS.Clear();
            m_cParameterKeyS.Clear();
            base.Dispose();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Block Name
        /// </summary>
        public string BlockName
        {
            get { return m_SBlockName; }
            set { m_SBlockName = value; }
        }

        /// <summary>
        /// Block Description
        /// </summary>
        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        /// <summary>
        /// Block Parameter Size Number of bits
        /// </summary>
        public int ParameterSize
        {
            get { return m_iParameterSize; }
            set { m_iParameterSize = value; }
        }

        /// <summary>
        /// Main Routine Name
        /// </summary>
        public string MainRoutine
        {
            get { return m_sMainRoutine; }
            set { m_sMainRoutine = value; }
        }

        /// <summary>
        /// Parameter  Dic<localTagkey(string), ParameterType(EmParameterType)>
        /// </summary>
        public CParameterS ParameterS
        {
            get { return m_cParameterKeyS; }
            set { m_cParameterKeyS = value; }
        }

        /// <summary>
        /// Local TagS 
        /// </summary>
        public CTagS LocalTagS
        {
            get { return m_cLocalTagS; }
            set { m_cLocalTagS = value; }
        }

        /// <summary>
        /// Local Routine save the LogicS
        /// </summary>
        public CLDRoutineS RoutineS
        {
            get { return m_cRoutineS; }
            set { m_cRoutineS = value; }
        }
        #endregion

        #region Public Methods

        public object Clone()
        {
            CLDBlock cTempBlock = new CLDBlock();

            cTempBlock.Key = m_sKey;
            cTempBlock.BlockName = m_SBlockName;
            cTempBlock.Description = m_sDescription;
            cTempBlock.ParameterSize = m_iParameterSize;
            cTempBlock.MainRoutine = m_sMainRoutine;
            cTempBlock.ParameterS = (CParameterS)m_cParameterKeyS.Clone();
            cTempBlock.LocalTagS = (CTagS)m_cLocalTagS.Clone();
            cTempBlock.RoutineS = (CLDRoutineS)m_cRoutineS.Clone();

            return cTempBlock;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
