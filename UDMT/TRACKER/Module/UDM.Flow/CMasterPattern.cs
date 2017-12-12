using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CMasterPattern : Dictionary<string, CFlowS>, IDisposable, IObject, ICloneable
    {

        #region Member Variables

        protected string m_sKey = "";

        #endregion


        #region Initialize/Dispose

        public CMasterPattern()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CMasterPattern(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public CFlowS this[int iIndex]
        {
            get { return GetFlowS(iIndex); }
        }

        #endregion


        #region Public Methods

        public void Update(string sKey, CFlowItemS cItemS, CFlowRule cRule)
        {
            if (this.ContainsKey(sKey))
            {
                CFlowS cFlowS = this[sKey];
                cFlowS.Update(cItemS, cRule);
            }
            else
            {
                CFlowS cFlowS = new CFlowS();
                cFlowS.Update(cItemS, cRule);

                this.Add(sKey, cFlowS);
            }
        }

        //public void Update(string sKey, CFlowItemS cItemS, CCycleMasterUnitS cMasterUnitS, CFlowRule cRule)
        //{
        //    if (this.ContainsKey(sKey))
        //    {
        //        CFlowS cFlowS = this[sKey];
        //        cFlowS.Update(cItemS, cMasterUnitS, cRule);
        //    }
        //    else
        //    {
        //        CFlowS cFlowS = new CFlowS();
        //        cFlowS.Update(cItemS, cMasterUnitS, cRule);

        //        this.Add(sKey, cFlowS);
        //    }
        //}

        public void FinalizeLinkS()
        {
            CFlowS cFlowS;
            for (int i = 0; i < this.Count; i++)
            {
                cFlowS = this.ElementAt(i).Value;
                cFlowS.FinalizeLinkS();
            }
        }

        public CFlowCompareResultS Compare(string sRecipe, CFlowItemS cItemS, bool bSubItem)
        {
            CFlowCompareResultS cResultS = null;

            if (this.ContainsKey(sRecipe))
            {
                CFlowS cFlowS = this[sRecipe];
                cResultS = cFlowS.Compare(cItemS, bSubItem);
            }
            else
            {
                //JP Add
                CFlowS cFlowS = this.First().Value;
                cResultS = cFlowS.Compare(cItemS, bSubItem);
            }

            return cResultS;
        }

        public object Clone()
        {
            CMasterPattern cMasterClone = new CMasterPattern();
            cMasterClone.Key = m_sKey;

            string sKey;
            CFlowS cFlowSClone;
            for(int i=0;i<this.Count;i++)
            {
                sKey = this.ElementAt(i).Key;
                cFlowSClone = (CFlowS)this.ElementAt(i).Value.Clone();
                cMasterClone.Add(sKey, cFlowSClone);
            }

            return cMasterClone;
        }

        #endregion


        #region Private Methods

        protected CFlowS GetFlowS(int iIndex)
        {
            CFlowS cFlowS = null;
            if (this.Count > iIndex)
                cFlowS = this.ElementAt(iIndex).Value;

            return cFlowS;
        }

        #endregion
    }
}
