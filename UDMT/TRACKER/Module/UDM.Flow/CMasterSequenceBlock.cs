using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDM.Flow
{
    [Serializable]
    public class CMasterSequenceBlock : List<CMasterSequenceUnitS>, IDisposable
    {
        private string m_sRecipe = string.Empty;

        public CMasterSequenceBlock()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        public string Recipe
        {
            get { return m_sRecipe;}
            set { m_sRecipe = value; }
        }


        public void Update(CMasterSequenceUnitS cUnitS)
        {
            if (CheckSameUnitS(cUnitS))
            {
                CMasterSequenceUnitS cExistUnit = GetSameUnitS(cUnitS);
                cExistUnit.Update(cUnitS);
            }
            else
                this.Add(cUnitS);
        }

        public CMasterSequenceUnitS GetUnitS(CTimeLogS cLogS)
        {
            CMasterSequenceUnitS cUnitS = null;
            List<CTimeLog> lstOnLogS = cLogS.Where(x => x.Value == 1).ToList();

            foreach (var who in this)
            {
                if (who.CheckSameUnitS(lstOnLogS))
                {
                    cUnitS = who;
                    break;
                }
            }

            return cUnitS;
        }

        private bool CheckSameUnitS(CMasterSequenceUnitS cUnitS)
        {
            bool bOK = false;

            foreach (var who in this)
            {
                if (who.CheckSameUnitS(cUnitS))
                {
                    bOK = true;
                    break;
                }
            }
            return bOK;
        }

        private CMasterSequenceUnitS GetSameUnitS(CMasterSequenceUnitS cUnitS)
        {
            CMasterSequenceUnitS cSameUnitS = null;

            foreach (var who in this)
            {
                if (who.CheckSameUnitS(cUnitS))
                {
                    cSameUnitS = who;
                    break;
                }
            }
            return cSameUnitS;
        }

    }
}
