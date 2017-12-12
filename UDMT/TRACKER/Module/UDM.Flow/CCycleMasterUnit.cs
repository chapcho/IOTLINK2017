using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Flow
{
    [Serializable]
    public class CCycleMasterUnit
    {
        private string m_sKey = string.Empty;
        private Dictionary<string, CCyclePresentUnit> m_dicMasterUnitS = null;
        private CCyclePresentUnit m_cUnit = null;


        public CCycleMasterUnit(string sKey, Dictionary<string, CCyclePresentUnit> dicMasterUnit)
        {
            m_sKey = sKey;
            m_dicMasterUnitS = dicMasterUnit;
        }

        public string Key
        {
            get { return m_sKey;}
            set { m_sKey = value; }
        }

        public CCyclePresentUnit MasterUnit
        {
            get { return m_cUnit; }
            set { m_cUnit = value; }
        }

        public Dictionary<string, CCyclePresentUnit> MasterUnitS
        {
            get { return m_dicMasterUnitS; }
            set { m_dicMasterUnitS = value; }
        }
    }
}
