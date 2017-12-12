using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using UDM.Common;

namespace UDM.Converter
{
    public class CS7FileOpen
    {
        // Create by Qin Shiming at 2015.06.22
        //
        #region MemberVariables
        protected List<string> m_lSDFFile = new List<string>();
        protected List<string> m_lAWLFile = new List<string>();
        protected StreamReader m_sSDFFIleReader;
        protected StreamReader m_sAWLFileReader;
        protected OpenFileDialog oFile;

        #endregion

        #region Initialze/Dispose

        public CS7FileOpen()
        {
            try
            {
                oFile = new OpenFileDialog();
                oFile.Multiselect = true;
                oFile.Filter = "AWL Files(*.AWL);SDF Files(*.SDF)|*.AWL;*.SDF";

                oFile.ShowDialog();

                string[] sFilePaths = oFile.FileNames;

                FileOpen(sFilePaths);
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

        public List<string> AWLFile
        {
            get { return m_lAWLFile; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void FileOpen(string[] sFilePaths)
        {
            try
            {
                if (sFilePaths.Length >= 1)
                {
                    if (sFilePaths.Length == 1)
                    {
                        if (sFilePaths[0].EndsWith(".sdf") || sFilePaths[0].EndsWith(".SDF"))
                        {
                            m_sSDFFIleReader = new StreamReader(sFilePaths[0], Encoding.Default);

                            string strLine = m_sSDFFIleReader.ReadLine();
                            while (strLine != null)
                            {
                                m_lSDFFile.Add(strLine);
                                strLine = m_sSDFFIleReader.ReadLine();
                            }

                            MessageBox.Show("You just opened a SDF file. Please open one AWL file");

                            oFile = new OpenFileDialog();
                            oFile.Multiselect = false;
                            oFile.Filter = "AWL Files(*.AWL)|*.AWL;";
                            oFile.ShowDialog();

                            string sAWLPath = oFile.FileName;

                            m_sAWLFileReader = new StreamReader(sAWLPath);


                            strLine = m_sAWLFileReader.ReadLine();

                            while (strLine != null)
                            {
                                m_lAWLFile.Add(strLine);
                                strLine = m_sAWLFileReader.ReadLine();
                            }

                        }
                        else if (sFilePaths[0].EndsWith(".awl") || sFilePaths[0].EndsWith(".AWL"))
                        {
                            m_sAWLFileReader = new StreamReader(sFilePaths[0], Encoding.Default);
                            string strLine = m_sAWLFileReader.ReadLine();

                            while (strLine != null)
                            {
                                m_lAWLFile.Add(strLine);
                                strLine = m_sAWLFileReader.ReadLine();
                            }

                            MessageBox.Show("You just opened a AWL file. Please open one SDF file");

                            oFile = new OpenFileDialog();
                            oFile.Multiselect = false;
                            oFile.Filter = "SDF Files(*.SDF)|*.SDF";
                            oFile.ShowDialog();

                            string sSDFPath = oFile.FileName;

                            m_sSDFFIleReader = new StreamReader(sSDFPath);

                            strLine = m_sSDFFIleReader.ReadLine();
                            while (strLine != null)
                            {
                                m_lSDFFile.Add(strLine);
                                strLine = m_sSDFFIleReader.ReadLine();
                            }
                        }
                        else
                            MessageBox.Show("Your file is wrong file, Please check again.");
                    }
                    else if (sFilePaths.Length == 2)
                    {
                        for (int i = 0; i < sFilePaths.Length;i++ )
                        {
                            if (sFilePaths[i].EndsWith(".awl") || sFilePaths[i].EndsWith(".AWL"))
                            {
                                m_sAWLFileReader = new StreamReader(sFilePaths[i], Encoding.Default);

                                string strLine = m_sAWLFileReader.ReadLine();

                                while (strLine != null)
                                {
                                    m_lAWLFile.Add(strLine);
                                    strLine = m_sAWLFileReader.ReadLine();
                                }
                            }
                            else if (sFilePaths[i].EndsWith(".sdf") || sFilePaths[i].EndsWith(".SDF"))
                            {
                                m_sSDFFIleReader = new StreamReader(sFilePaths[i], Encoding.Default);

                                string strLine = m_sSDFFIleReader.ReadLine();
                                while (strLine != null)
                                {
                                    m_lSDFFile.Add(strLine);
                                    strLine = m_sSDFFIleReader.ReadLine();
                                }
                            }
                        }
                    }
                }
                else
                {

                    //MessageBox.Show("Not Open any file. Please try again.");
                    //oFile = new OpenFileDialog();
                    //oFile.Multiselect = true;
                    //oFile.Filter = "AWL Files(*.AWL);SDF Files(*.SDF)|*.AWL;*.SDF";
                    //oFile.ShowDialog();

                    //sFilePaths = oFile.FileNames;

                    //FileOpen(sFilePaths);
                }
            }
            catch (System.Exception ex)
            {
            	Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion
    }
}
