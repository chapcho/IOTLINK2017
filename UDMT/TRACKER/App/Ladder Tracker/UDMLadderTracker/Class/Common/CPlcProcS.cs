using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDMLadderTracker
{
    /// <summary>
    /// Key = CPlcProc Name
    /// </summary>
    [Serializable]
    public class CPlcProcS : Dictionary<string, CPlcProc>
    {
        #region Member Variables

        #endregion


        #region Initialize

        public CPlcProcS()
        {

        }

        protected CPlcProcS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Properties

        #endregion


        #region Public Method

        public List<string> GetCollectTagKeyList(EMMonitorType emMonitorType)
        {
            List<string> lstTagKey = new List<string>();

            foreach (var who in this)
            {
                CPlcProc cProcess = who.Value;

                lstTagKey.AddRange(cProcess.KeySymbolS.Keys.ToList());
                lstTagKey.AddRange(cProcess.InOutTagS.Keys.ToList());

                if(cProcess.SelectRecipeWord != null)
                    lstTagKey.Add(cProcess.SelectRecipeWord.Key);

                if (emMonitorType == EMMonitorType.Detection)
                {
                    if (!lstTagKey.Contains(cProcess.TotalAbnormalSymbolKey))
                        lstTagKey.Add(cProcess.TotalAbnormalSymbolKey);

                    lstTagKey.AddRange(cProcess.AbnormalSymbolS.GetAbnormalSymbolKeyList());
                    lstTagKey.AddRange(cProcess.RecipeWordS.Keys.ToList());
                }
            }
            
            return lstTagKey;
        }

        #endregion
    }
}
