using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UDMEnergyViewer
{
    public class CMeterLogWriter : IDisposable
    {
        #region Member Variables

        private StreamWriter m_cWriter = null;
        private string m_sFilePath = string.Empty;
        private int m_iRowsCount = 0;
        private int m_iContinueFileCount = 0;
        private int m_iChannelS = 0;

        #endregion


        #region Intialize/Dispose

        public CMeterLogWriter()
        {
        }

        public void Dispose()
        {
            Close();
        }

        #endregion

        
        #region Public Properties

        public int ChannelS
        {
            get { return m_iChannelS; }
            set { m_iChannelS = value; }
        }

        #endregion


        #region Public Methdos

        public bool Open(string sPath)
        {
            m_iRowsCount = 0;
            m_iContinueFileCount = 0;

            m_sFilePath = sPath;
            m_cWriter = new StreamWriter(new FileStream(sPath, FileMode.CreateNew));
            StringBuilder sw = new StringBuilder();
            sw.Append("Time");

            for (int i = 8448; i <= 8448 + m_iChannelS * 12; i++)
            {
                sw.Append(","+i.ToString() + "LO");
                sw.Append("," + i.ToString() + "HI");
            }

            m_cWriter.WriteLine(sw);
            return true;
        }

        public void Close()
        {
            if (m_cWriter != null)
            {
                m_cWriter.Close();
                m_cWriter.Dispose();
                m_cWriter = null;
            }
        }

        public void Write(CMeterData cData)
        {
            if(m_iRowsCount>=10000)
            {
                m_cWriter.Close();
                m_cWriter.Dispose();
                m_cWriter = null;
                NewFileOpen();
            }

            StringBuilder sw = new StringBuilder();

            sw.Append(cData.Time.ToString("yyyyMMddHHmmss.fff"));

            int iCount = cData.Data.Length;

            for(int i =0;i<iCount;i++)
            {
                sw.Append("," + cData.Data[i].ToString());
            }
            m_cWriter.WriteLine(sw);
            m_iRowsCount++;
        }
        
        #endregion


        #region Private Methods

        private void NewFileOpen()
        {
            string sTempFileName = string.Empty;

            int iPos = m_sFilePath.IndexOf(".csv");
            sTempFileName = m_sFilePath.Remove(iPos);
            m_iContinueFileCount++;
            m_iRowsCount = 0;

            sTempFileName = sTempFileName + m_iContinueFileCount.ToString() + ".csv";

            m_cWriter = new StreamWriter(new FileStream(sTempFileName , FileMode.CreateNew));
            StringBuilder sw = new StringBuilder();
            sw.Append("Time");

            for (int i = 8448; i <= 8448+m_iChannelS*12; i++)
            {
                sw.Append("," + i.ToString() + "LO");
                sw.Append("," + i.ToString() + "HI");
            }

            m_cWriter.WriteLine(sw);
        }

        #endregion
    }
}
