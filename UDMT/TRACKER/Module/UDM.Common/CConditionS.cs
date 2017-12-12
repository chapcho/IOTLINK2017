using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CConditionS : List<CCondition>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CConditionS()
        {

        }

        public void Dispose()
        {
            this.Clear();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public void MoveUp(CCondition cCondition)
        {
            int iIndex = GetIndex(cCondition);
            if (iIndex < 1)
                return;

            this.Remove(cCondition);
            this.Insert(iIndex - 1, cCondition);
        }

        public void MoveDown(CCondition cCondition)
        {
            int iIndex = GetIndex(cCondition);
            if (iIndex < 0 || iIndex == (this.Count -1))
                return;

            this.Remove(cCondition);
            this.Insert(iIndex + 1, cCondition);
        }

        public bool ContainsKey(string sKey)
        {
            bool bOK = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == sKey)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        public CCondition GetSelectedKeyData(string sKey)
        {
            CCondition cCondi = null;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Key == sKey)
                {
                    cCondi = this[i];
                    break;
                }
            }
            return cCondi;
        }

        public void Set(string sKey, int iValue)
        {
            CCondition cCondition = null;
            for (int i = 0; i < this.Count; i++)
            {
                cCondition = this[i];
                if (cCondition.Key == sKey)
                {
                    cCondition.Set(iValue);
                    break;
                }
            }
        }

        public void Reset()
        {
            CCondition cCondtion;
            for (int i = 0; i < this.Count; i++)
            {
                cCondtion = this[i];
                cCondtion.Reset();
            }
        }

        public bool CheckSatisfied()
        {
            bool bSatisfied = false;

            bool bOK = true;
            CCondition cCondition;

            for (int i = 0; i < this.Count; i++)
            {
                cCondition = this[i];

                if (i == 0)
                {
                    bSatisfied = cCondition.CheckSatisfied();
                }
                else
                {
                    bOK = cCondition.CheckSatisfied();

                    if (cCondition.OperatorType == EMOperaterType.And)
                        bSatisfied = bSatisfied & bOK;
                    else
                        bSatisfied = bSatisfied | bOK;
                }
            }

            return bSatisfied;
        }

        #endregion


        #region Private Methtods

        protected int GetIndex(CCondition cCondition)
        {
            int iIndex = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == cCondition)
                {
                    iIndex = i;
                    break;
                }
            }

            return iIndex;
        }

        #endregion
    }
}
