using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDM.Flow
{
    [Serializable]
    /// <summary>
    /// Key == Tag Key
    /// </summary>
    public class CCycleMasterUnitS : Dictionary<string, CCycleMasterUnit>, IDisposable
    {
        public CCycleMasterUnitS()
        {
            
        }

        public void Dispose()
        {
            Clear();
        }

        protected CCycleMasterUnitS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        public CCycleMasterUnitS GetSameRecipeMasterUnit(string sRecipe)
        {
            CCycleMasterUnitS cUnitS = new CCycleMasterUnitS();

            CCycleMasterUnit cUnit;
            CCycleMasterUnit cNewUnit = null;
            foreach (var who in this)
            {
                cUnit = who.Value;

                if (cUnit.MasterUnitS.ContainsKey(sRecipe))
                {
                    cNewUnit = new CCycleMasterUnit(cUnit.Key, null);
                    cNewUnit.MasterUnit = cUnit.MasterUnitS[sRecipe];
                    cUnitS.Add(cUnit.Key, cNewUnit);
                }
            }

            return cUnitS;
        }

    }
}
