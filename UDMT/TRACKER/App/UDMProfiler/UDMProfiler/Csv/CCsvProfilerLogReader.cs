using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using UDM.General;
using UDM.General.Csv;
using UDM.Common;
using UDM.Log;

namespace UDMProfiler.Csv
{
    public class CCsvProfilerLogReader : IDisposable
    {
        #region Member Variables

        protected int COL_INDEX_TIME = 0;
        protected int COL_INDEX_KEY = 1;
        protected int COL_INDEX_VALUE = 2;
        protected int COL_INDEX_PACKET = 3;
        protected int COL_INDEX_CYCLE = 4;
        protected int COL_INDEX_NOTE = 5;
        protected int COL_INDEX_RECIPE = 6;
        protected int Col_INDEX_PLCID = 7;

        protected int COL_MIN_COUNT = 4;

        protected List<List<string>> m_lstLogValue = null;
        protected List<CCsvReader> m_lstReader = null;
        protected EMFileState m_emState = EMFileState.Closed;

        #endregion

        #region Intialize/Dispose

        public CCsvProfilerLogReader()
        {
        }

        public void Dispose()
        {
            this.Close();
        }

        #endregion

        #region Public Properties

        public EMFileState State
        {
            get { return m_emState; }
        }

        #endregion

        #region Public Methods

        public bool Open(string sPath)
        {
            Close();

            bool bOK = true;

            m_lstReader = new List<CCsvReader>();

            try
            {
                CCsvReader cReader = new CCsvReader();

                bOK = cReader.Open(sPath, true);

                if(bOK)
                {
                    bOK = false;
                    if (cReader.Header.Count > COL_MIN_COUNT)
                    {
                        if (cReader.Header[0] == "Time")
                            bOK = true;
                    }
                }

                if (bOK)
                {
                    m_lstReader.Add(cReader);
                    m_emState = EMFileState.Opened;
                }
                else
                {
                    if (cReader != null)
                    {
                        cReader.Close();
                        cReader.Dispose();
                        cReader = null;
                    }
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Open(string[] saPath)
        {
            Close();

            bool bOK = true;
            string sPath = "";

            m_lstReader = new List<CCsvReader>();

            try
            {
                CCsvReader cReader;
                for (int i = 0; i < saPath.Length; i++)
                {
                    cReader = new CCsvReader();

                    sPath = saPath[i];
                    bOK = cReader.Open(sPath, true);

                    if (bOK)
                    {
                        bOK = false;
                        if (cReader.Header.Count > COL_MIN_COUNT)
                        {
                            if (cReader.Header[0] == "Time")
                                bOK = true;
                        }
                    }

                    if (bOK)
                    {
                        m_lstReader.Add(cReader);
                    }
                    else
                    {
                        if (cReader != null)
                        {
                            cReader.Close();
                            cReader.Dispose();
                            cReader = null;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            if (m_lstReader.Count == 0)
            {
                bOK = false;
                m_lstReader = null;
            }
            else
            {
                bOK = true;
                m_emState = EMFileState.Opened;
            }

            return bOK;
        }

        public int Open(string[] saPath, string sIncludeString)
        {
            Close();

            bool bOK = true;
            string sPath = "";
            int iCount = 0;

            m_lstReader = new List<CCsvReader>();

            try
            {
                CCsvReader cReader;
                m_lstLogValue = new List<List<string>>();

                for (int i = 0; i < saPath.Length; i++)
                {

                    cReader = new CCsvReader();

                    sPath = saPath[i];

                    string[] saSplit = sPath.Split('\\');
                    string sFileName = saSplit[saSplit.Length - 1];
                    if (sFileName.Contains(sIncludeString) == false)
                    {
                        iCount++;
                        continue;
                    }

                    bOK = cReader.Open(sPath, true);

                    if (bOK)
                    {
                        bOK = false;
                        if (cReader.Header.Count > COL_MIN_COUNT)
                        {
                            if (cReader.Header[0] == "Time")
                                bOK = true;
                        }
                    }

                    if (bOK)
                    {
                        m_lstReader.Add(cReader);
                    }
                    else
                    {
                        if (cReader != null)
                        {
                            cReader.Close();
                            cReader.Dispose();
                            cReader = null;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            if (m_lstReader.Count == 0)
            {
                bOK = false;
                m_lstReader = null;
            }
            else
            {
                bOK = true;
                m_emState = EMFileState.Opened;
            }
            if (bOK == false) iCount = -1;

            return iCount;
        }

        public CTimeLogS ReadTimeLogS(string sPlcID)
        {
            if (m_emState == EMFileState.Closed)
                return null;

            CTimeLog cLog = new CTimeLog();
            CTimeLogS cLogS = new CTimeLogS();

            CCsvReader cReader;

            for (int i = 0; i < m_lstReader.Count; i++)
            {
                cReader = m_lstReader[i];

                while (cReader.EOF == false)
                {
                    m_lstLogValue.Add(cReader.ReadLine());
                }
            }

            foreach (List<string> sLog in m_lstLogValue)
            {
                if (sLog != null)
                {
                    if (sPlcID != sLog[Col_INDEX_PLCID])
                        continue;

                    cLog = CreateLog(sLog);
                    if (cLog != null)
                        cLogS.Add(cLog);
                }
            }
            cLogS.Sort();
            return cLogS;
        }


        public void Close()
        {
            if (m_lstReader != null)
            {
                CCsvReader cReader;
                for (int i = 0; i < m_lstReader.Count; i++)
                {
                    cReader = m_lstReader[i];
                    cReader.Close();
                    cReader.Dispose();
                    cReader = null;
                }
            }

            m_lstReader = null;
            m_emState = EMFileState.Closed;
        }

        #endregion


        #region Private Methods

        protected CTimeLog CreateLog(List<string> lstValue)
        {
			if (lstValue.Count < COL_MIN_COUNT)
				return null;

            CTimeLog cLog = new CTimeLog(lstValue[COL_INDEX_KEY]);
            cLog.Time = UDM.General.CTypeConverter.ToDateTime(lstValue[COL_INDEX_TIME]);
            cLog.Value = UDM.General.CTypeConverter.ToInteger(lstValue[COL_INDEX_VALUE]);
            cLog.Note = lstValue[COL_INDEX_NOTE];

            return cLog;
        }

        #endregion
    }
}