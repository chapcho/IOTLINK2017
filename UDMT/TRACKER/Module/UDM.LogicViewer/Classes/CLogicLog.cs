using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevComponents.AdvTree;

using UDM.General.Csv;
using UDM.LogicViewer;
using UDM.Common;
using UDM.ILConverter;
using UDM.Log.Csv;
using UDM.Log;

namespace UDM.LogicViewer
{
    public class CLogicLog
    {
        private Dictionary<string, CTimeLogS> m_DicILSymbolS = new Dictionary<string, CTimeLogS>();
        private Dictionary<string, EMDataType> m_DicCollect = new Dictionary<string, EMDataType>();

        public CLogicLog()
        {
        }

        public void Dispose()
        {

        }

        #region public Properties

        public Dictionary<string, CTimeLogS> LogS
        {
            get { return m_DicILSymbolS; }
            set { m_DicILSymbolS = value; }
        }

        public Dictionary<string, EMDataType> CollectItemS
        {
            get { return m_DicCollect; }
        }

        #endregion

        #region Private Methods


        #endregion

        #region public Methods


        public bool CreateEventTag(CCsvLogReader cCsvLogReader)
        {
            CTimeLogS cTimeLogS = cCsvLogReader.GetTimeLogS();
            foreach (CTimeLog cTimeLog in cTimeLogS)
            {
                string sKey = cTimeLog.Key.Replace(CPlc.DefaultPath, string.Empty);

                if (m_DicILSymbolS.ContainsKey(sKey))
                {
                    m_DicILSymbolS[sKey].Add(cTimeLog);
                }
                else
                {
                    CTimeLogS cTimeLogSNew = new CTimeLogS();
                    cTimeLogSNew.Add(cTimeLog);
                    m_DicILSymbolS.Add(sKey, cTimeLogSNew);
                }
            }

            foreach (CTimeLogS cTimeLogSReverse in m_DicILSymbolS.Values)
                cTimeLogSReverse.Reverse();

            if (m_DicILSymbolS.Count == 0)
                return false;
            else
                return true;
        }

        public bool UpdateCollectList(CLDRungS cILRungS)
        {
            m_DicCollect.Clear();

            foreach (var who in cILRungS)
            {
                CLDRung cLDRung = (CLDRung)who.Value;
                List<CTag> lstTag = cLDRung.Step.Coil.OtherTagS;
                foreach (CContact cContact in cLDRung.Step.TotalContactS)
                    lstTag.AddRange(cContact.GetAddressTagS());

                foreach (CTag cTag in lstTag)
                    if (!m_DicCollect.ContainsKey(cTag.Address))
                        m_DicCollect.Add(cTag.Address, EMDataType.Bool);
            }

            return true;

        }

        public bool ApplyNodeTime(CLDRung cILRung, DateTime dt, string sValue)
        {
            if (m_DicILSymbolS.Count == 0)
                return false;
            else
            {
                CStepTime cStepTime  = new CStepTime(cILRung, m_DicILSymbolS, m_DicCollect);
                cStepTime.ApplyNodeTime(dt, sValue);

                return true;
            }
        }

        #endregion




    }
}
