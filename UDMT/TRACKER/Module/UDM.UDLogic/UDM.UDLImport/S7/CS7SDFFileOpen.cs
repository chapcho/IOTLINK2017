using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace UDM.UDLImport
{
    public class CS7SDFFileOpen
    {
        protected List<string> m_lSDFFile = new List<string>();
        protected StreamReader m_sSDFFIleReader;
        protected OpenFileDialog oFile;

         #region Initialze/Dispose

        public CS7SDFFileOpen()
        {
            try
            {
                oFile = new OpenFileDialog();
                oFile.Multiselect = true;
                oFile.Filter = "SDF Files(*.SDF)|*.SDF";

                oFile.ShowDialog();

                string sFilePath = oFile.FileName;

                m_sSDFFIleReader = new StreamReader(sFilePath);


                string strLine = m_sSDFFIleReader.ReadLine();
                while (strLine != null)
                {
                    m_lSDFFile.Add(strLine);
                    strLine = m_sSDFFIleReader.ReadLine();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion



        #region Public Properites

        public List<string> SDFFile
        {
            get { return m_lSDFFile; }
        }

        #endregion
    }
}
