using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDM.Flow
{
    public class CCyclePresentResult : List<CCyclePresentUnit>
    {

        #region Member Variables

        /// <summary>
        /// Key = Recipe
        /// </summary>
        private CTag m_cTag = null;

        #endregion


        #region Initialize/Dispose

        public CCyclePresentResult(CTag cTag)
        {
            m_cTag = cTag;
        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties


        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        #endregion


        #region Public Methods

        public bool IsRegular(CCyclePresentOption cOption)
        {
            bool bOK = true;

            List<string> lstRecipe = CreateRecipeList();
            List<CCyclePresentUnit> lstUnit = null;
            for (int i = 0; i < lstRecipe.Count; i++)
            {
                lstUnit = this.Where(x => x.Recipe == lstRecipe[i]).ToList();
				bOK = IsRegular(lstUnit, cOption, lstRecipe[i]);
                if (bOK == false)
                    break;

                lstUnit.Clear();
            }

            if(lstUnit != null)
                lstUnit.Clear();

            return bOK;
        }

        public bool IsSatisfied(int iTotalCycleCount, double nCyclePresentRatio)
        {
            int iPresentCount = GetActiveCycleCount();
            if (iPresentCount == -1)
                return false;

            double nRation = (double)iPresentCount / (double)iTotalCycleCount;
            if (nRation >= nCyclePresentRatio)
                return true;
            else
                return false;
        }

        #endregion


        #region Private Methods

        private List<string> CreateRecipeList()
        {
            List<string> lstRecipe = new List<string>();
            for (int i = 0; i < this.Count;i++ )
            {
                if (lstRecipe.Contains(this[i].Recipe) == false)
                    lstRecipe.Add(this[i].Recipe);
            }

            return lstRecipe;
        }

		private bool IsRegular(List<CCyclePresentUnit> lstUnit, CCyclePresentOption cOption, string sRecipe)
        {
            bool bOK = true;

            //if (lstUnit.Count < 2)
            //    return false;

		    int iCount = lstUnit.Count;

		    lstUnit = GetOptionSatisfiedUnit(lstUnit, cOption);

		    if (iCount != lstUnit.Count)
		        return false;

		    int iFalseCount = 0;
            CCyclePresentUnit cFirstUnit = null;
            CCyclePresentUnit cCurUnit = null;
		    for (int i = 0; i < lstUnit.Count; i++)
		    {
		        cFirstUnit = lstUnit[i];

		        for (int j = i + 1; j < lstUnit.Count; j++)
		        {
		            cCurUnit = lstUnit[j];
		            if (!cFirstUnit.IsSameUnit(cCurUnit))
		                iFalseCount++;
		        }
		    }

		    if (lstUnit.Count > iFalseCount)
		        bOK = true;
		    else
		        bOK = false;
            
            return bOK;
        }

        private List<CCyclePresentUnit> GetOptionSatisfiedUnit(List<CCyclePresentUnit> lstUnit, CCyclePresentOption cOption)
        {
            List<CCyclePresentUnit> lstNewUnit = new List<CCyclePresentUnit>();

            bool bOK = true;
            List<int> lstRemoveUnitIndex = new List<int>();

            CCyclePresentUnit cFirstUnit = null;
            for (int i = 0; i < lstUnit.Count; i++)
            {
                bOK = true;

                cFirstUnit = lstUnit[i];
                //if (cOption.UseFirstActive && cFirstUnit.FirstValue == 0)
                //    bOK = false;

                if (bOK && cFirstUnit.LogCount < cOption.MinimumLogCount)
                    bOK = false;

                if (bOK && cFirstUnit.ActiveCount < cOption.MinimnumActiveCount)
                    bOK = false;

                if (!bOK)
                    lstRemoveUnitIndex.Add(i);
            }

            if (lstRemoveUnitIndex.Count > 0)
            {
                for (int i = 0; i < lstUnit.Count; i++)
                {
                    if(!lstRemoveUnitIndex.Contains(i))
                        lstNewUnit.Add(lstUnit[i]);
                }
            }
            else
                lstNewUnit.AddRange(lstUnit);

            return lstNewUnit;
        }

        private int GetActiveCycleCount()
        {
            int iCount = 0;

            CCyclePresentUnit cUnit;
            for(int i=0;i<this.Count;i++)
            {
                cUnit = this[i];
                if (cUnit.FirstValue == 0)
                {
                    iCount = -1;
                    break;
                }
                else if (cUnit.ActiveCount == 1)
                {
                    iCount += 1;
                }
                else if (cUnit.ActiveCount > 1)
                {
                    iCount = -1;
                    break;
                }
            }

            return iCount;

        }

        #endregion
    }
}
