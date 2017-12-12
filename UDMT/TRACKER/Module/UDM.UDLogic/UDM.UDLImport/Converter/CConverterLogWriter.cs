using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UDM.UDLImport
{
    public static class CConverterLogWriter
    {
        private static StreamWriter m_cLogFileWriter = null;
        private static FileStream m_cFile = null;
        public static bool bIsNeedLog = true;

        public static void WrteFileStart()
        {
            if(bIsNeedLog)
            {
                DateTime dtNow = DateTime.Now;

                string sTime = dtNow.ToString("yyMMddHHmmss");

                string FileName = "PLCConverterLog_" + sTime + ".txt";
                m_cFile = new FileStream(FileName, FileMode.Create);

                m_cLogFileWriter = new StreamWriter(m_cFile, Encoding.Default);

                m_cLogFileWriter.WriteLine(sTime + "\tConverting Start.");
            }            
        }

        public static void WriteFileEnd()
        {
            if(bIsNeedLog)
            {
                DateTime dtNow = DateTime.Now;

                string sTime = dtNow.ToString("yyMMddHHmmss");
                m_cLogFileWriter.WriteLine(sTime + "\tConverting End.");
                m_cLogFileWriter.Close();
                m_cFile.Close();

            }        
        }

        public static void WriteEmptyLine()
        {
            if(bIsNeedLog)
            {
                m_cLogFileWriter.WriteLine(" ");
            }
        }

        public static void WriteLogEvent(string sFunctionName, string sEvent)
        {
            if(bIsNeedLog)
            {
                DateTime dtNow = DateTime.Now;

                string sTime = dtNow.ToString("yyMMddHHmmss");
                string sWriteLine = string.Format("[Function : {0}] \t {1}", sFunctionName, sEvent);
                m_cLogFileWriter.WriteLine(sTime + "\t" + sWriteLine);
            }
        }
    }
}
