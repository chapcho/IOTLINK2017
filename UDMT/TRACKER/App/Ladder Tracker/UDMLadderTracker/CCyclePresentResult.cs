using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;

namespace UDMLadderTracker
{
    internal class CCyclePresentResult : List<CCyclePresentUnit>
    {

        #region Member Variables

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
				bOK = IsRegular(lstUnit, cOption);
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

		private bool IsRegular(List<CCyclePresentUnit> lstUnit, CCyclePresentOption cOption)
        {
			if (lstUnit.Count < 2)
                return false;

            bool bOK = true;

            CCyclePresentUnit cFirstUnit = null;
            CCyclePresentUnit cCurrUnit = null;
            for (int i = 0; i < lstUnit.Count;i++ )
            {
                if(i == 0)
                {
                    cFirstUnit = lstUnit[i];
					if (cOption.UseFirstActive && cFirstUnit.FirstValue == 0)
					{
						bOK = false;
						break;
					}

					if(cFirstUnit.LogCount < cOption.MinimumLogCount)
					{
						bOK = false;
						break;
					}

					if(cFirstUnit.ActiveCount < cOption.MinimnumActiveCount)
					{
						bOK = false;
						break;
					}
                }
                else
                {
                    cCurrUnit = lstUnit[i];
                    if (cFirstUnit.LogCount != cCurrUnit.LogCount || cFirstUnit.FirstValue != cCurrUnit.FirstValue || cFirstUnit.ActiveCount != cCurrUnit.ActiveCount)
                    {
                        bOK = false;
                        break;
                    }
                }
            }
            
            return bOK;
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
