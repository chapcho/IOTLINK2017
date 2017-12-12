using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CStep : CObject, IDisposable, ITagComposable
    {

        #region Member Variables

        protected int m_iFBCount = 0;
        protected int m_iStepIndex = -1;
        protected string m_sProgram = "";
        protected string m_sSituation = "";
        protected string m_sMasterControl = "";
        protected string m_sForNextControl = "";
        protected string m_sCallControl = "";

        protected CCoilS m_cCoilS = new CCoilS();
        protected CContactS m_cContactS = new CContactS();
        protected CRefTagS m_cRefTagS = new CRefTagS();
        protected List<CFB_Info> m_lstFBInfo = new List<CFB_Info>();

        #endregion


        #region Initialize/Dispose

        public CStep()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public int StepIndex
        {
            get { return m_iStepIndex; }
            set { m_iStepIndex = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public string Situation
        {
            get { return m_sSituation; }
            set { m_sSituation = value; }
        }

        public string MasterControl
        {
            get { return m_sMasterControl; }
            set { m_sMasterControl = value; }
        }

        public string ForNextControl
        {
            get { return m_sForNextControl; }
            set { m_sForNextControl = value; }
        }

        public string CallControl
        {
            get { return m_sCallControl; }
            set { m_sCallControl = value; }
        }

        public CCoilS CoilS
        {
            get { return m_cCoilS; }
            set { m_cCoilS = value; }
        }

        public CContactS ContactS
        {
            get { return m_cContactS; }
            set { m_cContactS = value; }
        }

        public CRefTagS RefTagS
        {
            get { return m_cRefTagS; }
            set { m_cRefTagS = value; }
        }

        public string Address
        {
            get { return m_cCoilS.Address; }
        }

        public string Instruction
        {
            get { return m_cCoilS.Instructions; }
        }

        public int LogCount
        {
            get { return m_cCoilS.LogCount; }
        }

        public EMDataType DataType
        {
            get { return m_cCoilS.DataType; }
        }

        public string Description
        {
            get { return m_cCoilS.Description; }
        }

        public string Channel
        {
            get { return m_cCoilS.Channel; }
        }

        public List<CFB_Info> FBInfoList
        {
            get { return m_lstFBInfo; }
            set { m_lstFBInfo = value; }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            m_cCoilS.Clear();
            m_cContactS.Clear();
            m_cRefTagS.Clear();
        }

        public int GetIndexContact(CContact cContact)
        {
            return m_cContactS.IndexOf(cContact);
        }        

        public void Compose(CTagS cTagS)
        {
            m_cRefTagS.Compose(cTagS);
            m_cCoilS.Compose(m_cRefTagS);
            m_cContactS.Compose(m_cRefTagS);
        }

        public void Compose(CRefTagS cRefTagS)
        {
            m_cRefTagS.Compose(cRefTagS);
            m_cCoilS.Compose(m_cRefTagS);
            m_cContactS.Compose(m_cRefTagS);
        }

        public void ComposeTagRoleS()
        {
            m_cCoilS.ComposeTagRoleS();
            m_cContactS.ComposeTagRoleS();
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
