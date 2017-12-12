using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{   
    [Serializable]
    public class CCoil : ITagComposable, IDisposable, IStepMember
    {

        #region Member Variables

        protected string m_sInstruction = "";
        protected string m_sCommand = "";
        protected string m_sStep = "";
        protected int m_iStepIndex = -1;

        protected EMCoilType m_emCoilType = EMCoilType.None;
        protected CContentS m_cContentS = new CContentS();        
        protected CRelation m_cRelation = new CRelation();
        protected CRefTagS m_cRefTagS = new CRefTagS();

        #endregion


        #region Intialize/Dispose

        public CCoil()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        public string Instruction
        {
            get { return m_sInstruction; }
            set { m_sInstruction = value; }
        }

        public EMCoilType CoilType
        {
            get { return m_emCoilType; }
            set { m_emCoilType = value; }
        }

        public CContentS ContentS
        {
            get { return m_cContentS; }
            set { m_cContentS = value; }
        }

        public CRelation Relation
        {
            get { return m_cRelation; }
            set { m_cRelation = value; }
        }

        public CRefTagS RefTagS
        {
            get { return m_cRefTagS; }
            set { m_cRefTagS = value; }
        }

        public string Step
        {
            get { return m_sStep; }
            set { m_sStep = value; }
        }

        public int StepIndex
        {
            get { return m_iStepIndex; }
            set { m_iStepIndex = value; }
        }

        public int LogCount
        {
            get { return GetLogCount(); }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            m_cContentS.Clear();                
        }        

        public void Compose(CTagS cTagS)
        {
            if (m_cRefTagS == null)
                m_cRefTagS = new CRefTagS();

            m_cRefTagS.Compose(cTagS);            

            m_cContentS.Compose(m_cRefTagS);
        }

        public void Compose(CRefTagS cRefTagS)
        {
            if (m_cRefTagS == null)
                m_cRefTagS = new CRefTagS();

            m_cRefTagS.Compose(cRefTagS);

            m_cContentS.Compose(m_cRefTagS);
        }

        public void ComposeTagRoleS()
        {
            CTagStepRole cTagRole = new CTagStepRole();
            cTagRole.StepKey = m_sStep;
            cTagRole.RoleType = EMStepRoleType.Coil;

            m_cContentS.ComposeTagRoleS(cTagRole);
        }

        #endregion


        #region Private Methods

        protected int GetLogCount()
        {
            int iLogCount = 0;

            CContent cArg;
            for (int i = 0; i < m_cContentS.Count; i++)
            {
                cArg = m_cContentS[i];
                if (cArg.Tag != null)
                {
                    iLogCount = cArg.Tag.LogCount;
                    break;
                }
            }

            return iLogCount;
        }

        #endregion

    }
}
