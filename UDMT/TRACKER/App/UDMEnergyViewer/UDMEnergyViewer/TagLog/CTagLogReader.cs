using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;

namespace UDMEnergyViewer
{
    public class CTagLogReader : IDisposable
    {

        #region Member Variables

        protected CCsvLogReader m_cReader = null;

        #endregion


        #region Initialize/Dispose

        public CTagLogReader()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        
        #endregion


        #region Public Methods

        public bool Open(string[] saPath)
        {
            if(m_cReader != null)
            {
                m_cReader.Close();
                m_cReader.Dispose();
                m_cReader = null;
            }

            m_cReader = new CCsvLogReader();
            bool bOK = m_cReader.Open(saPath);
            if (bOK == false)
                Close();

            return bOK;
        }

        public bool Close()
        {
            if(m_cReader == null)
            {
                m_cReader.Close();
                m_cReader.Dispose();
                m_cReader = null;
            }

            return true;
        }

        public CTagItemS Read(CTagS cTagS)
        {
            if (m_cReader == null)
                return null;

            CTagItemS cItemS = new CTagItemS();
            
            CTagItem cItem;
            CTag cTag;
            CTimeLog cLog;
            CTimeLogS cLogS = m_cReader.ReadTimeLogS();
            for(int i=0;i<cLogS.Count;i++)
            {
                cLog = cLogS[i];
                if(cItemS.ContainsKey(cLog.Key))
                {
                    cItem = cItemS[cLog.Key];
                    cItem.LogS.Add(cLog);
                }
                else if(cTagS.ContainsKey(cLog.Key))
                {
                    cTag = cTagS[cLog.Key];
                    cItem = new CTagItem(cTag);
                    cItem.LogS.Add(cLog);

                    cItemS.Add(cItem.Key, cItem);
                }
            }

            for(int i = 0;i<cItemS.Count;i++)
            {
                cItem = cItemS.ElementAt(i).Value;
                cItem.UpdateLogKey();
                cItem.LogS.Sort();
            }

            return cItemS;
        }

        #endregion


        #region Private Methods

        private DateTime GetTime(List<string> lstValue)
        {
            DateTime dtTime = DateTime.MinValue;

            dtTime = DateTime.ParseExact(lstValue[0], "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);

            return dtTime;
        }

        private int GetValue(string sValue)
        {
            int iValue = int.Parse(sValue);

            return iValue;;
        }

        #endregion

    }
}
