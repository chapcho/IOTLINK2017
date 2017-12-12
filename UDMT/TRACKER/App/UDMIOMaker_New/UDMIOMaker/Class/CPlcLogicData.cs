using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CPlcLogicData
    {
        private string m_sName = string.Empty;
        private EMPLCMaker m_emPLCMaker = EMPLCMaker.ALL;

        private CTagS m_cTagS = new CTagS();
        private CStepS m_cStepS = new CStepS();

        private CBlock m_cIOBlock = null;

        [NonSerialized] private CBlockS m_cAddressBlockS = new CBlockS();

        #region Initialize/Dispose

        #endregion

        #region Properties

        public CBlock IOModuleBlock
        {
            get { return m_cIOBlock; }
            set { m_cIOBlock = value; }
        }


        public CBlockS AddressBlockS
        {
            get { return m_cAddressBlockS;}
            set { m_cAddressBlockS = value; }
        }


        public string Name
        {
            get { return m_sName;}
            set { m_sName = value; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker;}
            set { m_emPLCMaker = value; }
        }

        public CTagS TagS
        {
            get { return m_cTagS;}
            set { m_cTagS = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS;}
            set { m_cStepS = value; }
        }

        #endregion

        #region Public Methods

        public void Compose()
        {
            if (m_cStepS == null || m_cTagS == null)
                return;

            m_cStepS.Compose(m_cTagS);
            m_cStepS.ComposeTagRoleS();
        }

        #endregion

        #region Private Methods

        #endregion

    }
}
