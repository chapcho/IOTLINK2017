using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using UDM.Common;

namespace UDM.Flow
{
    [Serializable]
    public class CMasterPatternS : Dictionary<string, CMasterPattern>, IDisposable, ICloneable
    {

        #region Member Variables

        protected CFlowRule m_cRule = new CFlowRule();

        #endregion


        #region Initialize/Dispose

        public CMasterPatternS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CMasterPatternS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        #endregion


        #region Public Properties

        public CFlowRule Rule
        {
            get { return m_cRule; }
            set { m_cRule = value; }
        }

        public CMasterPattern this[int iIndex]
        {
            get { return GetMasterPattern(iIndex); }
        }

        #endregion


        #region Public Methods

        public void Add(string sKey, string sRecipe, CFlow cFlow)
        {
            if (this.ContainsKey(sKey))
            {
                CMasterPattern cMasterPattern = this[sKey];

                if (cMasterPattern.ContainsKey(sRecipe))
                {
                    CFlowS cFlowS = cMasterPattern[sRecipe];
                    cFlowS.Add(cFlow);
                }
                else
                {
                    CFlowS cFlowS = new CFlowS();
                    cFlowS.Add(cFlow);

                    cMasterPattern.Add(sRecipe, cFlowS);
                }
            }
            else
            {
                CMasterPattern cMasterPattern = new CMasterPattern();
                cMasterPattern.Key = sKey;

                CFlowS cFlowS = new CFlowS();                                
                cFlowS.Add(cFlow);

                cMasterPattern.Add(sRecipe, cFlowS);

                this.Add(sKey, cMasterPattern);
            }
        }

        public void Update(string sKey, string sRecipe, CFlowItemS cItemS)
        {
            if (this.ContainsKey(sKey))
            {
                CMasterPattern cMasterPattern = this[sKey];
                cMasterPattern.Update(sRecipe, cItemS, m_cRule);
            }
            else
            {
                CMasterPattern cMasterPattern = new CMasterPattern();
                cMasterPattern.Key = sKey;
                cMasterPattern.Update(sRecipe, cItemS, m_cRule);

                this.Add(sKey, cMasterPattern);
            }
        }

        public CFlowCompareResultS Compare(string sKey, string sRecipe, CFlowItemS cItemS, bool bSubItem)
        {
            CFlowCompareResultS cResultS = null;

            if (this.ContainsKey(sKey))
            {
                CMasterPattern cMasterFlow = this[sKey];
                cResultS = cMasterFlow.Compare(sRecipe, cItemS, bSubItem);
            }

            return cResultS;
        }

        public object Clone()
        {
            CMasterPatternS cMasterSClone = new CMasterPatternS();

            string sKey;
            CMasterPattern cMasterClone;
            for(int i=0;i<this.Count;i++)
            {
                sKey = this.ElementAt(i).Key;
                cMasterClone = (CMasterPattern)this.ElementAt(i).Value.Clone();
                cMasterSClone.Add(sKey, cMasterClone);
            }

            return cMasterSClone;
        }

        #endregion


        #region Privte Methods

        protected CMasterPattern GetMasterPattern(int iIndex)
        {
            CMasterPattern cMasterPattern = null;
            if (this.Count > iIndex)
                cMasterPattern = this.ElementAt(iIndex).Value;

            return cMasterPattern;
        }

        #endregion
    }
}
