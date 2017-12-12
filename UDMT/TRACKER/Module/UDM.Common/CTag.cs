using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CTag:CObject
    {

        #region Member Variables

        protected string m_sName = "";
        protected string m_sAddress = "";
        protected string m_sDescription = "";
        protected string m_sProgram = "";
        protected string m_sLinkAddress = "";
		protected string m_sChannel = "";
        protected string m_sCreator = "System";
        protected string m_sNote = "";
        protected string m_sUdttype = "";
        protected bool m_bUseOnlyInLogic = false;
        protected int m_iSize = 1;
        protected EMPLCMaker m_emMakerType = EMPLCMaker.Mitsubishi_Developer;
        protected EMDataType m_emDataType = EMDataType.Bool;
        protected EMAddressType m_emAddressType = EMAddressType.Decimal;
        protected CTagStepRoleS m_cStepRoleS = new CTagStepRoleS();
        protected CTagGroupRoleS m_cGroupRoleS = new CTagGroupRoleS();

        private bool m_bHMIMapping = false;

        [NonSerialized]
        protected int m_iLogCount = 0;
        protected bool m_bCollectUsed = false;

        #endregion


        #region Initialize/Dispose

        public CTag()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public bool IsHMIMapping
        {
            get { return m_bHMIMapping;}
            set { m_bHMIMapping = value; }
        }

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public string Description
        {
            get { return m_sDescription; }
            set { m_sDescription = value; }
        }

        public string Program
        {
            get { return m_sProgram; }
            set { m_sProgram = value; }
        }

        public string LinkAddress
        {
            get { return m_sLinkAddress; }
            set { m_sLinkAddress = value; }
        }

        public string UDTType
        {
            get { return m_sUdttype; }
            set { m_sUdttype = value; }
        }

        public bool UseOnlyInLogic
        {
            get { return m_bUseOnlyInLogic; }
            set { m_bUseOnlyInLogic = value; }
        }

		public string Channel
		{
			get { return m_sChannel; }
			set { m_sChannel = value; }
		}

        public string Creator
        {
            get { return m_sCreator; }
            set { m_sCreator = value; }
        }
		
        public string Note
        {
            get { return m_sNote; }
            set { m_sNote = value; }
        }

        public int Size
        {
            get { return m_iSize; }
            set { m_iSize = value; }
        }

        public int LogCount
        {
            get { return m_iLogCount; }
            set { m_iLogCount = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emMakerType; }
            set { m_emMakerType = value; }
        }

        public EMDataType DataType
        {
            get { return m_emDataType; }
            set { m_emDataType = value; }
        }

        public EMAddressType AddressType
        {
            get { return m_emAddressType; }
            set { m_emAddressType = value; }
        }

        public CTagStepRoleS StepRoleS
        {
            get { return m_cStepRoleS; }
            set { m_cStepRoleS = value; }
        }

        public CTagGroupRoleS GroupRoleS
        {
            get { return m_cGroupRoleS; }
            set { m_cGroupRoleS = value; }
        }

        public bool IsCollectUsed
        {
            get { return m_bCollectUsed; }
            set { m_bCollectUsed = value; }
        }

        #endregion


        #region Public Methdos

        public bool IsEndCoil()
        {
            if (m_cStepRoleS.Count == 0)
                return false;

            bool bOK = true;
            for (int i = 0; i < m_cStepRoleS.Count; i++)
            {
                if (m_cStepRoleS[i].RoleType == EMStepRoleType.Contact)
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        public bool IsEndContact()
        {
            if (m_cStepRoleS.Count == 0)
                return false;

            bool bOK = true;

            if (m_cStepRoleS.Where(x => x.RoleType == EMStepRoleType.Both || x.RoleType == EMStepRoleType.Coil).Count() > 0)
                bOK = false;

            return bOK;
        }

        public string GetDescription()
        {
            string sDescription = string.Empty;

            if (m_sDescription != string.Empty)
                sDescription = m_sDescription;
            else
                sDescription = m_sName;

            return sDescription;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
