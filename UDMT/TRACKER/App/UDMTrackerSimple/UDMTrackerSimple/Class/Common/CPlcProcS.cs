using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
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

        public List<string> GetCollectTagKeyList(EMMonitorType emMonitorType, bool bOptimizeMode, string sSelectedProcess)
        {
            List<string> lstTagKey = new List<string>();

            foreach (var who in this)
            {
                CPlcProc cProcess = who.Value;

                if (cProcess.CycleCheckTag != null)
                    lstTagKey.Add(cProcess.CycleCheckTag.Key);

                if(cProcess.RecipeWordS != null && cProcess.RecipeWordS.Count != 0)
                    lstTagKey.AddRange(cProcess.RecipeWordS.Keys.ToList());

                if (cProcess.TotalAbnormalSymbolKey != string.Empty && !lstTagKey.Contains(cProcess.TotalAbnormalSymbolKey))
                    lstTagKey.Add(cProcess.TotalAbnormalSymbolKey);

                if(cProcess.AbnormalSymbolS != null && cProcess.AbnormalSymbolS.Count != 0)
                    lstTagKey.AddRange(cProcess.AbnormalSymbolS.GetAbnormalSymbolKeyList());

                if (bOptimizeMode)
                {
                    if (cProcess.IsOptimizerSelectedProcess)
                    {
                        //All Process
                        if (sSelectedProcess == string.Empty || cProcess.Name == sSelectedProcess)
                        {
                            if (cProcess.CollectCandidateTagS != null && cProcess.CollectCandidateTagS.Count != 0)
                                lstTagKey.AddRange(cProcess.CollectCandidateTagS.Keys.ToList());
                        }
                    }
                }
                else
                {
                    if (emMonitorType == EMMonitorType.Learning)
                    {
                        if (cProcess.ChartViewTagS != null && cProcess.ChartViewTagS.Count != 0)
                            lstTagKey.AddRange(cProcess.ChartViewTagS.Keys.ToList());
                    }
                    else
                    {
                        if (cProcess.KeySymbolS != null && cProcess.KeySymbolS.Count != 0)
                            lstTagKey.AddRange(cProcess.KeySymbolS.Keys.ToList());
                    }
                }
            }
            
            return lstTagKey;
        }

        #endregion
    }
}
