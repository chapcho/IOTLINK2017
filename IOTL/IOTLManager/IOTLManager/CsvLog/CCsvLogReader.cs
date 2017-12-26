using IOTL.Common;
using IOTL.Common.Csv;
using IOTL.Common.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTLManager.CsvLog
{
    public class CCsvLogReader : IDisposable
    {

        #region Member Variables

        protected int COL_INDEX_TIME = 0;
        protected int COL_INDEX_KEY = 1;
        protected int COL_INDEX_VALUE = 2;
        protected int COL_INDEX_PACKET = 3;
        protected int COL_INDEX_CYCLE = 4;
        protected int COL_INDEX_NOTE = 5;
        protected int COL_INDEX_RECIPE = 6;
        protected int m_iMinColumns = 3;

        protected List<CsvReader> m_lstReader = null;
        protected EMFileState m_emState = EMFileState.Closed;
//        protected EMLogType m_emLogType = EMLogType.Normal;
//        protected CTimePacketLogS m_cPacketLogS = new CTimePacketLogS();

        #endregion


        #region Intialize/Dispose

        public CCsvLogReader()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Properties

        public EMFileState State
        {
            get { return m_emState; }
        }

        //public EMLogType LogType
        //{
        //    get { return m_emLogType; }
        //    set { m_emLogType = value; }
        //}

        #endregion


        #region Public Methods

        public bool Open(string sPath)
        {
            Close();

            bool bOK = true;

            m_lstReader = new List<CsvReader>();

            try
            {
                CsvReader cReader = new CsvReader();

                bOK = cReader.Open(sPath, true);

                if (bOK)
                {
                    bOK = false;
                    if (cReader.Header.Count > m_iMinColumns)
                    {
                        if (cReader.Header[0] == "ReceiveTime")
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

            m_lstReader = new List<CsvReader>();

            try
            {
                CsvReader cReader;
                for (int i = 0; i < saPath.Length; i++)
                {
                    cReader = new CsvReader();

                    sPath = saPath[i];
                    bOK = cReader.Open(sPath, true);

                    if (bOK)
                    {
                        bOK = false;
                        if (cReader.Header.Count > m_iMinColumns)
                        {
                            if (cReader.Header[0] == "ReceiveTime")
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

            m_lstReader = new List<CsvReader>();

            try
            {
                CsvReader cReader;

                for (int i = 0; i < saPath.Length; i++)
                {

                    cReader = new CsvReader();

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
                        if (cReader.Header.Count > m_iMinColumns)
                        {
                            if (cReader.Header[0] == "ReceiveTime")
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



        public CTimeLogS ReadTimeLogS()
        {
            if (m_emState == EMFileState.Closed)
                return null;

            CTimeLogS cLogS = new CTimeLogS();

            CsvReader cReader;
            for (int i = 0; i < m_lstReader.Count; i++)
            {
                cReader = m_lstReader[i];
                FillTimeLogS(cReader, cLogS);
            }

            return cLogS;
        }

        public CTimeLogS ReadTimeLogS(BackgroundWorker worker)
        {
            if (m_emState == EMFileState.Closed)
                return null;

            CTimeLogS cLogS = new CTimeLogS();

            CsvReader cReader;
            int percentValue = 0;

            for (int i = 0; i < m_lstReader.Count; i++)
            {
                cReader = m_lstReader[i];
                FillTimeLogS(cReader, cLogS);

                percentValue = (i*100) / m_lstReader.Count;
                worker.ReportProgress(percentValue);
            }

            if(m_lstReader.Count > 0)
                worker.ReportProgress(100);

            return cLogS;
        }

        public void Close()
        {
            if (m_lstReader != null)
            {
                CsvReader cReader;
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

        protected void FillTimeLogS(CsvReader cReader, CTimeLogS cLogS)
        {
            CTimeLog cLog;
            List<string> lstValue = new List<string>();
            while (cReader.EOF == false)
            {
                lstValue = cReader.ReadLine();
                if (lstValue != null)
                {
                    cLog = CreateLog(lstValue);
                    if (cLog != null)
                        cLogS.Add(cLog);

                    lstValue.Clear();
                    lstValue = null;
                }
            }
        }

        protected CTimeLog CreateLog(List<string> lstValue)
        {
            // CTimeLog cLog = new CTimeLog(lstValue[COL_INDEX_KEY]);
            // 2017.12.22
            // 로그 파일에서 한줄씩 읽어서 다시 로그를 만들텐데
            // 로그에는 현재 수신시간,로그 데이터가 문자열로 저장되어 있어야 한다.
            // 임의의 데이터를 만들어서 테스트할 필요가 있다.
            CTimeLog cLog = new CTimeLog("UnKnown", "ReadFromFileLog");
            try
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 1; i< lstValue.Count; i++)
                {
                    sb.Append(lstValue[i]);
                    if(i < lstValue.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                cLog.Key = sb.ToString();
                cLog.ReceiveData = CTypeConverter.StringToBytes(sb.ToString());

                // Log Import시에는 수집된 로그 시간을 기록한다.
                cLog.LogTime = CTypeConverter.ToDateTime(lstValue[0]);

                sb.Clear();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                cLog = null;
            }

            return cLog;
        }

        //protected void FillTimeLogS(CsvReader cReader, CTimePacketLogS cPacketLogS)
        //{
        //    CTimeLog cLog;
        //    List<string> lstValue = new List<string>();
        //    while (cReader.EOF == false)
        //    {
        //        lstValue = cReader.ReadLine();
        //        if (lstValue != null)
        //        {
        //            cLog = CreateLog(lstValue);
        //            cPacketLogS.Add(cLog);

        //            lstValue.Clear();
        //            lstValue = null;
        //        }
        //    }
        //}



        #endregion
    }
}
