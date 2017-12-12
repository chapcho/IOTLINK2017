using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;

namespace UDMIOMaker
{
    [Serializable]
    public class CProject
    {
        private string m_sFactory = string.Empty;
        private string m_sLine = string.Empty;

        private CTagS m_cTotalTagS = new CTagS();
        private CHMITagS m_cHMITagS = new CHMITagS();
        private CPlcLogicDataS m_cLogicDataS = new CPlcLogicDataS();
        private CVerifTagS m_cVerifTagS = new CVerifTagS();
        private CStdTagS m_cStdTagS = new CStdTagS();

        private CStdS m_cStdS = new CStdS();
        private Dictionary<string, CConvertUnitS> m_dicGroupConvertUnitS = new Dictionary<string, CConvertUnitS>();
        private CErrorFilterS m_cErrorFilterS = null;
        private List<CReportElement> m_lstReportElement = new List<CReportElement>(); 

        private EMIOMakerMode m_emMode = EMIOMakerMode.Design;
        

        #region Initialize/Dispose

        #endregion

        #region Properties

        public string FactoryName
        {
            get { return m_sFactory;}
            set { m_sFactory = value; }
        }

        public string LineName
        {
            get { return m_sLine;}
            set { m_sLine = value; }
        }

        public List<CReportElement> ReportElementS
        {
            get { return m_lstReportElement;}
            set { m_lstReportElement = value; }
        }


        public EMIOMakerMode IOMakerMode
        {
            get { return m_emMode;}
            set { m_emMode = value; }
        }

        public CErrorFilterS ErrorFilterS
        {
            get { return m_cErrorFilterS;}
            set { m_cErrorFilterS = value; }
        }

        public CStdS StdS
        {
            get { return m_cStdS;}
            set { m_cStdS = value; }
        }

        public CStdTagS StdTagS
        {
            get { return m_cStdTagS;}
            set { m_cStdTagS = value; }
        }

        public Dictionary<string, CConvertUnitS> GroupConvertUnitS
        {
            get { return m_dicGroupConvertUnitS;}
            set { m_dicGroupConvertUnitS = value; }
        }

        public CVerifTagS VerifTagS
        {
            get { return m_cVerifTagS;}
            set { m_cVerifTagS = value; }
        }

        public CPlcLogicDataS LogicDataS
        {
            get { return m_cLogicDataS;}
            set { m_cLogicDataS = value; }
        }

        public CTagS PLCTagS
        {
            get { return m_cTotalTagS; }
            set { m_cTotalTagS = value; }
        }

        public CHMITagS HMITagS
        {
            get { return m_cHMITagS;}
            set { m_cHMITagS = value; }
        }

        #endregion

        #region Public Methods

        public void Clear()
        {
            m_cTotalTagS.Clear();
            m_cVerifTagS.Clear();
            m_cHMITagS.Clear();
            m_cLogicDataS.Clear();
        }

        #endregion

        #region Private Methods

        #endregion



    }
}
