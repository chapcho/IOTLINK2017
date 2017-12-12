using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CGroup : CObject
    {

        #region Member Variables

        protected string m_sName = "";
        protected CGroup m_cParent = null;
        protected CSymbolS m_cKeySymbolS = new CSymbolS();
        protected CSymbolS m_cGeneralSymbolS = new CSymbolS();
        protected CSymbolS m_cTrendSymbolS = new CSymbolS();
        protected CSymbolS m_cAbnormalSymbolS = new CSymbolS();        
        protected CSymbol m_cProduct = new CSymbol();
        protected CSymbol m_cRecipe = new CSymbol();
        protected CConditionS m_cCycleStartConditionS = new CConditionS();
        protected CConditionS m_cCycleEndConditionS = new CConditionS();
        protected int m_iMaxCycleTime = 60000;

        #endregion


        #region Initialize/Dispose

        public CGroup()
        {
            m_cProduct.Tag = new CTag();
            m_cRecipe.Tag = new CTag();
        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Name
        {
            get { return m_sName; }
            set { SetKeyValue(value); }
        }

        public CGroup Parent
        {
            get { return m_cParent; }
            set { m_cParent = value; }
        }

        public new string Key
        {
            get { return m_sKey; }
            set { SetKeyValue(value); }
        }

        public CSymbolS KeySymbolS
        {
            get { return m_cKeySymbolS; }
            set { m_cKeySymbolS = value; }
        }

        public CSymbolS GeneralSymbolS
        {
            get { return m_cGeneralSymbolS; }
            set { m_cGeneralSymbolS = value; }
        }

        public CSymbolS TrendSymbolS
        {
            get { return m_cTrendSymbolS; }
            set { m_cTrendSymbolS = value; }
        }

        public CSymbolS AbnormalSymbolS
        {
            get { return m_cAbnormalSymbolS; }
            set { m_cAbnormalSymbolS = value; }
        }

        public CSymbol Product
        {
            get { return m_cProduct; }
            set { m_cProduct = value; }
        }

        public CSymbol Recipe
        {
            get { return m_cRecipe; }
            set { m_cRecipe = value; }
        }

        public CConditionS CycleStartConditionS
        {
            get { return m_cCycleStartConditionS; }
            set { m_cCycleStartConditionS = value; }
        }

        public CConditionS CycleEndConditionS
        {
            get { return m_cCycleEndConditionS; }
            set { m_cCycleEndConditionS = value; }
        }

        public int MaxCycleTime
        {
            get { return m_iMaxCycleTime; }
            set { m_iMaxCycleTime = value; }
        }

        #endregion


        #region Public Methods

		public CTagS GetTotalTagS()
		{
			CTagS cTotalTagS = new CTagS();

			CTagS cTagS = m_cKeySymbolS.GetTotalTagS();
			cTotalTagS.AddRange(cTagS);

			cTagS = m_cGeneralSymbolS.GetTotalTagS();
			cTotalTagS.AddRange(cTagS);

			cTagS = m_cTrendSymbolS.GetTotalTagS();
			cTotalTagS.AddRange(cTagS);

			cTagS = m_cAbnormalSymbolS.GetTotalTagS();
			cTotalTagS.AddRange(cTagS);

			return cTotalTagS;
		}

		public CSymbol AddSymbol(CTag cTag, EMGroupRoleType emRoleType)
		{
			if(IsSubRoleType(emRoleType))
				return null;

			CSymbol cSymbol = null;
			if(emRoleType == EMGroupRoleType.Key)
			{
				if (m_cKeySymbolS.ContainsKey(cTag.Key))
					return null;

				RemoveSymbol(cTag.Key);

				cSymbol = CreateSymbol(cTag, emRoleType);
				m_cKeySymbolS.Add(cSymbol);
			}
			else if(emRoleType == EMGroupRoleType.General)
			{
				if (m_cGeneralSymbolS.ContainsKey(cTag.Key))
					return null;

				RemoveSymbol(cTag.Key);

				cSymbol = CreateSymbol(cTag, emRoleType);
				m_cGeneralSymbolS.Add(cSymbol);
			}
			else if (emRoleType == EMGroupRoleType.Trend)
			{
				if (m_cTrendSymbolS.ContainsKey(cTag.Key))
					return null;

				RemoveSymbol(cTag.Key);

				cSymbol = CreateSymbol(cTag, emRoleType);
				m_cTrendSymbolS.Add(cSymbol);
			}
			else if (emRoleType == EMGroupRoleType.Abnormal)
			{
				if (m_cAbnormalSymbolS.ContainsKey(cTag.Key))
					return null;

				RemoveSymbol(cTag.Key);

				cSymbol = CreateSymbol(cTag, emRoleType);
				m_cAbnormalSymbolS.Add(cSymbol);
			}

			return cSymbol;
		}

		public CSymbol AddSubSymbol(CSymbol cParent, CTag cTag)
		{
			if (cParent.SubSymbolS == null)
				cParent.SubSymbolS = new CSymbolS();
			
			if (cParent.SubSymbolS.ContainsKey(cTag.Key))
				return null;

			EMGroupRoleType emParentRoleType = GetRoleTypeKind(cParent);
			EMGroupRoleType emRoleType = EMGroupRoleType.General;

			if (emParentRoleType == EMGroupRoleType.Key)
				emRoleType = EMGroupRoleType.SubKey;
			else if (emParentRoleType == EMGroupRoleType.General)
				emRoleType = EMGroupRoleType.SubGeneral;
			else if (emParentRoleType == EMGroupRoleType.Trend)
				emRoleType = EMGroupRoleType.SubTrend;
			else if (emParentRoleType == EMGroupRoleType.Abnormal)
				emRoleType = EMGroupRoleType.SubAbnormal;

			CSymbol cSymbol = CreateSymbol(cTag, emRoleType);
			cParent.SubSymbolS.Add(cSymbol);

			return cSymbol;
		}

		public CSymbol GetSymbol(string sKey)
		{
			CSymbol cSymbol = null;
			if (m_cKeySymbolS.ContainsKey(sKey))
				cSymbol = m_cKeySymbolS[sKey];
			else if (m_cGeneralSymbolS.ContainsKey(sKey))
				cSymbol = m_cGeneralSymbolS[sKey];
			else if (m_cTrendSymbolS.ContainsKey(sKey))
				cSymbol = m_cTrendSymbolS[sKey];
			else if (m_cAbnormalSymbolS.ContainsKey(sKey))
				cSymbol = m_cAbnormalSymbolS[sKey];

			return cSymbol;
		}

		public CSymbol GetSubSymbol(CSymbol cParent, string sKey)
		{
			if (cParent.SubSymbolS == null)
				cParent.SubSymbolS = new CSymbolS();

			CSymbol cSymbol = null;
			if (cParent.SubSymbolS.ContainsKey(sKey))
				cSymbol = cParent.SubSymbolS[sKey];

			return cSymbol;
		}

		public void RemoveSymbol(string sKey)
		{
			if (m_cKeySymbolS.ContainsKey(sKey))
				m_cKeySymbolS.Remove(sKey);

			if (m_cGeneralSymbolS.ContainsKey(sKey))
				m_cGeneralSymbolS.Remove(sKey);

			if (m_cTrendSymbolS.ContainsKey(sKey))
				m_cTrendSymbolS.Remove(sKey);

			if (m_cAbnormalSymbolS.ContainsKey(sKey))
				m_cAbnormalSymbolS.Remove(sKey);
		}

		public void RemoveSymbol(CSymbol cSymbol)
		{
			EMGroupRoleType emRoleType =  GetRoleTypeKind(cSymbol);
			if (emRoleType == EMGroupRoleType.Key)
				m_cKeySymbolS.Remove(cSymbol);
			else if (emRoleType == EMGroupRoleType.General)
				m_cGeneralSymbolS.Remove(cSymbol);
			else if (emRoleType == EMGroupRoleType.Trend)
				m_cTrendSymbolS.Remove(cSymbol);
			else if (emRoleType == EMGroupRoleType.Abnormal)
				m_cAbnormalSymbolS.Remove(cSymbol);
		}

		public void RemoveSubSymbol(CSymbol cParent, CSymbol cSymbol)
		{
			if (cParent.SubSymbolS == null)
				cParent.SubSymbolS = new CSymbolS();

			if (cParent.SubSymbolS.ContainsKey(cSymbol.Key))
				cParent.SubSymbolS.Remove(cSymbol.Key);
		}

		public void RemoveAllSymbolS(string sKey)
		{
			m_cKeySymbolS.RemoveAll(sKey);
			m_cGeneralSymbolS.RemoveAll(sKey);
			m_cTrendSymbolS.RemoveAll(sKey);
			m_cAbnormalSymbolS.RemoveAll(sKey);
		}

		public CSymbolS FindSymbolS(string sKey)
		{
			CSymbolS cTotalSymbolS = new CSymbolS();
			CSymbolS cSymbolS = null;

			cSymbolS = m_cKeySymbolS.FindSymbolS(sKey);
			cTotalSymbolS.AddRange(cSymbolS);
			cSymbolS.Clear();

			cSymbolS = m_cGeneralSymbolS.FindSymbolS(sKey);
			cTotalSymbolS.AddRange(cSymbolS);
			cSymbolS.Clear();

			cSymbolS = m_cTrendSymbolS.FindSymbolS(sKey);
			cTotalSymbolS.AddRange(cSymbolS);
			cSymbolS.Clear();

			cSymbolS = m_cAbnormalSymbolS.FindSymbolS(sKey);
			cTotalSymbolS.AddRange(cSymbolS);
			cSymbolS.Clear();

			return cTotalSymbolS;
		}

		public void Clear()
		{
			if (m_cKeySymbolS == null)
				m_cKeySymbolS = new CSymbolS();
			else
				m_cKeySymbolS.Clear();

			if (m_cGeneralSymbolS == null)
				m_cGeneralSymbolS = new CSymbolS();
			else
				m_cGeneralSymbolS.Clear();

			if (m_cAbnormalSymbolS == null)
				m_cAbnormalSymbolS = new CSymbolS();
			else
				m_cAbnormalSymbolS.Clear();

			if (m_cTrendSymbolS == null)
				m_cTrendSymbolS = new CSymbolS();
			else
				m_cTrendSymbolS.Clear();
		}

		public bool IsContains(string sKey)
		{
			if (m_cKeySymbolS.IsContains(sKey))
				return true;

			if (m_cGeneralSymbolS.IsContains(sKey))
				return true;

			if (m_cTrendSymbolS.IsContains(sKey))
				return true;

			if (m_cAbnormalSymbolS.IsContains(sKey))
				return true;

			return false;
		}

		internal void Compose()
		{
			CTagS cTotalTagS = GetTotalTagS();
			
			bool bOK = false;

			CTag cTag;
			for(int i=0;i<cTotalTagS.Count;i++)
			{
				bOK = false;

				cTag = cTotalTagS[i];
				if (m_cKeySymbolS.ContainsKey(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.Key)); 
					bOK = true;
				}
				else if (m_cAbnormalSymbolS.ContainsKey(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.Abnormal)); 
					bOK = true;
				}
				else if (m_cTrendSymbolS.ContainsKey(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.Trend));
					bOK = true;
				}
				else if (m_cGeneralSymbolS.ContainsKey(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.General)); 
					bOK = true;
				}

				if (bOK)
					continue;

				if (m_cKeySymbolS.IsContains(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.SubKey));
					bOK = true;
				}
				else if (m_cAbnormalSymbolS.IsContains(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.SubAbnormal));
					bOK = true;
				}
				else if (m_cTrendSymbolS.IsContains(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.SubTrend));
					bOK = true;
				}
				else if (m_cGeneralSymbolS.IsContains(cTag.Key))
				{
					cTag.GroupRoleS.Add(new CTagGroupRole(m_sKey, EMGroupRoleType.SubGeneral));
					bOK = true;
				}
			}
		}

        #endregion


        #region Private Methods

        private void SetKeyValue(string sValue)
        {
			TraceRenameGroupKey(m_sKey, sValue, m_cKeySymbolS);
			TraceRenameGroupKey(m_sKey, sValue, m_cGeneralSymbolS);
			TraceRenameGroupKey(m_sKey, sValue, m_cTrendSymbolS);
			TraceRenameGroupKey(m_sKey, sValue, m_cAbnormalSymbolS);

            m_sKey = sValue;
            m_sName = sValue;

            if (m_cProduct == null)
                m_cProduct = new CSymbol();

            m_cProduct.Key = "[PRD]" + m_sKey;
            m_cProduct.GroupKey = m_sKey;

            if (m_cRecipe == null)
                m_cRecipe = new CSymbol();

            m_cRecipe.Key = "[RCP]" + m_sKey;
            m_cRecipe.GroupKey = m_sKey;
        }

		private void TraceRenameGroupKey(string sOldKey, string sNewKey, CSymbolS cSymbolS)
		{
			CSymbol cSymbol;
			for (int i = 0; i < cSymbolS.Count; i++)
			{
				cSymbol = cSymbolS[i];
				cSymbol.GroupKey = sNewKey;

				if (cSymbol.Tag != null)
					cSymbol.Tag.GroupRoleS.Rename(sOldKey, sNewKey);

				if (cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
					TraceRenameGroupKey(sOldKey, sNewKey, cSymbol.SubSymbolS);
			}
		}

		private CSymbol CreateSymbol(CTag cTag, EMGroupRoleType emRoleType)
		{
			CSymbol cSymbol = new CSymbol(cTag);
			cSymbol.RoleType = emRoleType;
			cSymbol.GroupKey = m_sKey;
			return cSymbol;
		}
				
		private bool IsSubRoleType(EMGroupRoleType emRoleType)
		{
			bool bOK = false;
			if (emRoleType.ToString().StartsWith("Sub"))
				bOK = true;

			return bOK;
		}

		private EMGroupRoleType GetRoleTypeKind(CSymbol cSymbol)
		{
			EMGroupRoleType emRoleTypeKind = EMGroupRoleType.General;
			if (cSymbol.RoleType == EMGroupRoleType.Key || cSymbol.RoleType == EMGroupRoleType.SubKey)
				emRoleTypeKind = EMGroupRoleType.Key;
			else if (cSymbol.RoleType == EMGroupRoleType.Trend || cSymbol.RoleType == EMGroupRoleType.SubTrend)
				emRoleTypeKind = EMGroupRoleType.Trend;
			else if (cSymbol.RoleType == EMGroupRoleType.Abnormal || cSymbol.RoleType == EMGroupRoleType.SubAbnormal)
				emRoleTypeKind = EMGroupRoleType.Abnormal;

			return emRoleTypeKind;
		}
        #endregion
    }
}
