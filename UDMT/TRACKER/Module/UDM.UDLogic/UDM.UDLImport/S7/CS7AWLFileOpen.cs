using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace UDM.UDLImport.S7
{
    class CS7AWLFileOpen
    {
        protected List<string> m_lstAWLFile = new List<string>();
        protected StreamReader m_sAWLFileReader;

        #region Initialze/Dispose

        public CS7AWLFileOpen()
        {
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();

                oFile = new OpenFileDialog();
                oFile.Multiselect = false;
                oFile.Filter = "AWL Files(*.AWL)|*.AWL";

                oFile.ShowDialog();

                string sFilePath = oFile.FileName;

                m_sAWLFileReader = new StreamReader(sFilePath);

                string strLine = m_sAWLFileReader.ReadLine();

                while(strLine!= null)
                {
                    m_lstAWLFile.Add(strLine);
                    strLine = m_sAWLFileReader.ReadLine();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public CS7AWLFileOpen(string path)
        {
            try
            {
                m_sAWLFileReader = new StreamReader(path);

                string strLine = m_sAWLFileReader.ReadLine();

                while (strLine != null)
                {
                    m_lstAWLFile.Add(strLine);
                    strLine = m_sAWLFileReader.ReadLine();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        
        #endregion

        #region Public Properites

        public List<string> AWLFile
        {
            get { return m_lstAWLFile; }
        }

        #endregion
    }
}
