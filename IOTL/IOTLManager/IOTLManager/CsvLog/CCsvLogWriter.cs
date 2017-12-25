using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOTL.Common.Csv;
using IOTL.Common;
using IOTL.Common.Log;

namespace IOTLManager.CsvLog
{
    public class CCsvLogWriter : IDisposable
    {

        #region Member Variables

        protected int COL_INDEX_TIME = 0;
        protected int COL_INDEX_KEY = 1;
        protected int COL_INDEX_VALUE = 2;
        protected int COL_INDEX_PACKET = 3;
        protected int COL_INDEX_CYCLE = 4;
        protected int COL_INDEX_NOTE = 5;
        protected int COL_INDEX_RECIPE = 6;

        protected CsvWriter m_cWriter = null;

        #endregion


        #region Intialize/Dispose

        public CCsvLogWriter()
        {

        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        public EMFileState StateType
        {
            get
            {
                if (m_cWriter != null) { return m_cWriter.State; }
                else { return EMFileState.Closed; }
            }
        }


        #endregion


        #region Public Methods

        public bool Open(string sPath)
        {
            Close();

            m_cWriter = new CsvWriter(false);

            // 시작 : "S" // 1byte
            // 컴프레셔ID : "00000000" // 8byte
            // 컴프레셔정보번호 : "00" // 2byte
            // 데이터 : "0000" // 4byte (데이터당)
            // 끝 : "E" // 1byte

            m_cWriter.Header.Add("ReceiveTime"); // yyyymmddhhMMss.fff
            m_cWriter.Header.Add("STX");
            m_cWriter.Header.Add("CompressorID");
            m_cWriter.Header.Add("CompressDataType");
            m_cWriter.Header.Add("NData");
            m_cWriter.Header.Add("ETX");

            bool bOK = m_cWriter.Open(sPath);

            return bOK;
        }

        public void Close()
        {
            if (m_cWriter != null)
            {
                m_cWriter.Close();
                m_cWriter = null;
            }
        }

        public bool WriteTimeLogS(CTimeLogS cLogS)
        {
            bool bOK = true;

            // =======================================
            // 시작 : "S" // 1byte
            // 컴프레셔ID : "00000000" // 8byte
            // 컴프레셔정보번호 : "00" // 2byte
            // 데이터 : "0000" // 4byte (데이터당)
            // 끝 : "E" // 1byte

            if (m_cWriter != null && m_cWriter.State == EMFileState.Opened)
            {
                CTimeLog cLog;
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < cLogS.Count; i++)
                {
                    cLog = cLogS[i];
                    sb.Clear();
                    sb.Append(CTypeConverter.ToDateTimeFormat(cLog.LogTime));
                    sb.Append("/" + cLog.Key);
                    m_cWriter.WriteLine(sb.ToString());
                }

                sb.Clear();
            }

            return bOK;
        }

        public bool WriteTimeLog(CTimeLog cLog)
        {
            bool bOK = true;

            // =======================================
            // 시작 : "S" // 1byte
            // 컴프레셔ID : "00000000" // 8byte
            // 컴프레셔정보번호 : "00" // 2byte
            // 데이터 : "0000" // 4byte (데이터당)
            // 끝 : "E" // 1byte

            if (m_cWriter != null && m_cWriter.State == EMFileState.Opened)
            {
                StringBuilder sb = new StringBuilder();

                sb.Clear();
                sb.Append(CTypeConverter.ToDateTimeFormat(cLog.LogTime));
                sb.Append("/" + cLog.Key);
                m_cWriter.WriteLine(sb.ToString());

                sb.Clear();
            }

            return bOK;
        }



        #endregion


        #region Private Methods


        #endregion
    }
}
