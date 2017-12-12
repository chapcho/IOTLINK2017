using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UDM.General.Threading;
using UDM.Log.DB;

namespace UDMOptimizerReader
{
    public class CDB_Control : CThreadBase
    {
        private int m_iStep = 0;
        private string m_sDBDumpPath = "";
        private string m_sSaveFilePaht = "";
        public int ActiveStep
        {
            get { return m_iStep; }
            set { m_iStep = value; }
        }

        public string DBDumpPath
        {
            set { m_sDBDumpPath = value; }
        }

        public string SaveFilePath
        {
            set { m_sSaveFilePaht = value; }
        }

        #region Private Method

        private bool DBBackup()
        {
            bool bOK = false;
            try
            {
                string sError = string.Empty;

                using (Process mysqlDump = new Process())
                {
                    //Maria DB의 경우 Path 다름
                    //mysqlDump.StartInfo.FileName =
                    //    @"C:\Program Files (x86)\MySQL\MySQL Server 5.5\bin\mysqldump.exe";
                    mysqlDump.StartInfo.FileName = m_sDBDumpPath;
                    //@"C:\Program Files\MariaDB 10.1\bin\mysqldump.exe";
                    mysqlDump.StartInfo.UseShellExecute = false;
                    mysqlDump.StartInfo.Arguments = string.Format("-uroot -pudmt plcms -r \"{0}\"", m_sSaveFilePaht);
                    mysqlDump.StartInfo.RedirectStandardInput = false;
                    mysqlDump.StartInfo.RedirectStandardOutput = false;
                    mysqlDump.StartInfo.RedirectStandardError = true;
                    mysqlDump.StartInfo.CreateNoWindow = true;
                    mysqlDump.Start();

                    sError = mysqlDump.StandardError.ReadToEnd();
                    
                    mysqlDump.WaitForExit();
                    mysqlDump.Close();
                }

                string sFolderPath = m_sSaveFilePaht.Substring(0, m_sSaveFilePaht.LastIndexOf("\\"));
                if (sError == string.Empty && Directory.Exists(sFolderPath))
                    Process.Start(sFolderPath);
                bOK = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return bOK;
        }

        private bool ClearDB()
        {
            bool bOK = false;
            try
            {

                CMySqlLogWriter cLogWriter = new CMySqlLogWriter();
                bOK = cLogWriter.CreateDB();

                cLogWriter.Dispose();
                cLogWriter = null;
                bOK = true;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return bOK;
        }
        #endregion

        #region Thread Method

        protected override bool BeforeRun()
        {
            m_bRun = true;
            return m_bRun;
        }
        protected override bool AfterRun()
        {
            return true;
        }
        protected override bool BeforeStop()
        {
            return true;
        }
        protected override bool AfterStop()
        {
            return true;
        }
        protected override void DoThreadWork()
        {
            while (m_bRun)
            {
                Thread.Sleep(10);
                if (m_iStep == 1)    //DB Backup
                {
                    bool bOK = DBBackup();
                    if(bOK)
                        m_iStep = 2;
                    else
                        m_iStep = 12;
                }
                else if (m_iStep == 3)   //DB Clear
                {
                    bool bOK = ClearDB();
                    if (bOK)
                        m_iStep = 4;
                    else
                        m_iStep = 14;
                }

            }
        }

        #endregion
    }
}
