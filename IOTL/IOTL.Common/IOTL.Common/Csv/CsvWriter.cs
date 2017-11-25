using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IOTL.Common.Csv
{
    public class CsvWriter : IDisposable
    {

        #region Member Variables

        private StreamWriter m_csvWriter = null;
        private bool m_bWritable = false;
        private bool m_bAppend = false;
        private List<string> m_lstHeader = new List<string>();
        private EMFileState m_emState = EMFileState.Closed;
        private EMCsvType m_emSplitter = EMCsvType.Comma;

        #endregion


        #region Initialize/Dispose

        public CsvWriter(bool bAppend)
        {
            m_bAppend = bAppend;
        }

        public void Dispose()
        {
            Close();
        }

        #endregion


        #region Public Properties

        public List<string> Header
        {
            get { return m_lstHeader; }
            set { m_lstHeader = value; }
        }

        public EMFileState State
        {
            get { return m_emState; }
        }

        public EMCsvType CsvType
        {
            get { return m_emSplitter; }
            set { m_emSplitter = value; }
        }

        #endregion


        #region Public Methods

        public bool Open(string sPath)
        {
            bool bOK = true;

            Close();

            try
            {
                string sDirectory = Path.GetDirectoryName(sPath);
                if (Directory.Exists(sDirectory) == false)
                    Directory.CreateDirectory(sDirectory);

                m_csvWriter = new StreamWriter(sPath, m_bAppend, Encoding.Default);
                m_bWritable = true;

                if (m_lstHeader.Count > 0)
                    WriteColumn();

                m_emState = EMFileState.Opened;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public bool Close()
        {
            bool bOK = true;

            m_bWritable = false;

            try
            {
                if (m_csvWriter != null)
                {
                    m_csvWriter.Close();
                    m_csvWriter.Dispose();
                    m_csvWriter = null;
                }

                //m_lstHeader.Clear();
                m_emState = EMFileState.Closed;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            return bOK;
        }

        public void WriteLine(string sLine)
        {
            if (m_bWritable == false || sLine == "")
                return;

            try
            {
                m_csvWriter.WriteLine(sLine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion


        #region Private Methods

        private void WriteColumn()
        {
            if (m_bWritable)
            {
                string sLine = string.Empty;
                for (int i = 0; i < m_lstHeader.Count; i++)
                {
                    if (i == m_lstHeader.Count - 1)
                        sLine += m_lstHeader[i];
                    else
                        sLine += m_lstHeader[i] + ",";
                }

                if (sLine != "")
                    m_csvWriter.WriteLine(sLine);
            }
        }

        #endregion
    }
}
