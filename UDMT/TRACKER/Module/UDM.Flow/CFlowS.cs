using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CFlowS : List<CFlow>, IDisposable, ICloneable
    {

        #region Member Variables
        
        #endregion


        #region Initialize/Dispose

        public CFlowS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void Update(CFlowItemS cItemS, CFlowRule cRule)
        {
            CFlow cFlow = new CFlow();

            cFlow.Create(cItemS, cRule);

            CFlow cBaseFlow;
            bool bUpdated = false;
            for (int i = 0; i < this.Count; i++)
            {
                cBaseFlow = this[i];
                bUpdated = cBaseFlow.Update(cFlow);
                if (bUpdated)
                    break;
            }

            if (bUpdated == false)
                this.Add(cFlow);
        }

        //public void Update(CFlowItemS cItemS, CCycleMasterUnitS cUnitS, CFlowRule cRule)
        //{
        //    CFlow cFlow = new CFlow();

        //    cFlow.Create(cItemS, cUnitS, cRule);

        //    CFlow cBaseFlow;
        //    bool bUpdated = false;
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        cBaseFlow = this[i];
        //        bUpdated = cBaseFlow.Update(cFlow);
        //        if (bUpdated)
        //            break;
        //    }

        //    if (bUpdated == false)
        //        this.Add(cFlow);
        //}

        public void FinalizeLinkS()
        {
            CFlow cFlow;
            for(int i=0;i<this.Count;i++)
            {
                cFlow = this[i];
                cFlow.FinalizeLinkS();
            }
        }

        public CFlowCompareResultS Compare(CFlowItemS cItemS, bool bSubItem)
        {
            CFlowCompareResultS cResultS = null;

            // Find Best Fit Flow
            CFlow cFlowBest = null;
            CFlow cFlow;
            int iDiff = -1;
            int iDiffBest = -1;
            for (int i = 0; i < this.Count; i++)
            {
                cFlow = this[i];
                iDiff = cFlow.GetDifferenceScore(cItemS);

                if (cFlowBest == null)
                {
                    cFlowBest = cFlow;
                    iDiffBest = iDiff;
                }
                else if (iDiffBest > iDiff)
                {
                    cFlowBest = cFlow;
                    iDiffBest = iDiff;
                }
            }

            if (cFlowBest != null)
                cResultS = cFlowBest.Compare(cItemS, bSubItem);

            return cResultS;
        }

        public object Clone()
        {
            CFlowS cFlowSClone = new CFlowS();

            CFlow cFlowClone;
            for(int i=0;i<this.Count;i++)
            {
                cFlowClone = (CFlow)this[i].Clone();
                cFlowSClone.Add(cFlowClone);
            }

            return cFlowSClone;
        }

        #endregion


        #region Private Methtods


        #endregion
    }
}
