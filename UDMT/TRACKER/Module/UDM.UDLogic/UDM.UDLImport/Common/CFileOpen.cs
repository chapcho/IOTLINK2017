using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using UDM.UDL;
using UDM.Common;
using System.Data;
using System.Globalization;
using UDM.General.Csv;

namespace UDM.UDLImport
{
    public class CFileOpen 
    {
        /// <summary>
        /// list string for each file
        /// </summary>
        protected List<string> m_lstSDFFile = null;
        protected List<string> m_lstAWLFile = null;
        protected List<string> m_lstL5kFile = null;

        protected DataSet m_dbMelsecCSV = null;
        protected DataSet m_dbLS = null;

        /// <summary>
        /// stream reader for each file
        /// </summary>
        protected StreamReader m_sSDFFileReader;
        protected StreamReader m_sAWLFileReader;
        protected OpenFileDialog m_oFile;

        protected bool m_bFileOpenCheck = false;

        protected EMPLCMaker m_emPLCMaker = EMPLCMaker.Mitsubishi_Developer;

        #region Initialze/Dispose

        public CFileOpen(EMPLCMaker emMaker, bool bTagGenerate)
        {
            try
            {
                m_oFile = new OpenFileDialog();
                m_oFile.Multiselect = true;

                if (emMaker.ToString().Contains("Mitsubishi"))
                    m_oFile.Filter = "MITSUBISHI Files(*.csv)|*.CSV";
                else if (emMaker == EMPLCMaker.Siemens)
                {
                    if (bTagGenerate)
                        m_oFile.Filter = "Siemens Tag Files(*.SDF)|*.SDF";
                    else
                        m_oFile.Filter = "Siemens Files(*.AWL, *.SDF)|*.AWL;*.SDF";
                }
                else if (emMaker == EMPLCMaker.Rockwell)
                    m_oFile.Filter = "Rockwell Files(*.L5K)|*.L5K";
                else if (emMaker == EMPLCMaker.LS)
                    m_oFile.Filter = "LS Files(*.csv, *.il)|*.CSV;*.IL";
                else
                {
                    if(bTagGenerate)
                        m_oFile.Filter =
                        "All Files(*.csv, *.SDF, *.L5K, *.il)|*.CSV;*.SDF;*.L5K;*.IL|MITSUBISHI Files(*.csv)|*.CSV|Rockwell Files(*.L5K)|*.L5K|LS Files(*.csv, *.il)|*.CSV;*.IL|Siemens Tag Files(*.SDF)|*.SDF";
                    else
                        m_oFile.Filter =
                        "All Files(*.csv, *.AWL, *.SDF, *.L5K, *.il)|*.CSV;*.AWL;*.SDF;*.L5K;*.IL|MITSUBISHI Files(*.csv)|*.CSV|Rockwell Files(*.L5K)|*.L5K|LS Files(*.csv, *.il)|*.CSV;*.IL|Siemens Files(*.AWL, *.SDF)|*.AWL;*.SDF";
                }

                if (m_oFile.ShowDialog() == DialogResult.OK)
                {
                    m_bFileOpenCheck = true;
                    string[] sFilePaths = m_oFile.FileNames;

                    FileOpen(sFilePaths);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion

        #region Public Properites

        public bool FileOpenCheck
        {
            get { return m_bFileOpenCheck; }
        }

        public List<string> SDFFile
        {
            get { return m_lstSDFFile; }
        }
        
        public List<string> AWLFile
        {
            get { return m_lstAWLFile; }
        }

        public DataSet dbMelsecCSV
        {
            get { return m_dbMelsecCSV; }
        }

        public EMPLCMaker PLCMaker
        {
            get { return m_emPLCMaker; }
        }

        public List<string> L5kFile
        {
            get { return m_lstL5kFile; }
        }

        public DataSet dbLS
        {
            get { return m_dbLS; }
        }

        #endregion

        #region Public Methods
        #endregion

        #region Private Methods

        private void FileOpen(string[] sFilePaths)
        {
            try
            {
                int iCount = sFilePaths.Length;
    
                for(int i =0;i<iCount;i++)
                {
                    string sTemp = sFilePaths[i];
                    /// <summary>
                    /// Read file to each list string
                    /// </summary>
                    if(sTemp.EndsWith(".sdf")||sTemp.EndsWith(".SDF"))
                    {
                        m_lstSDFFile = new List<string>();
                        m_emPLCMaker = EMPLCMaker.Siemens;

                        m_sSDFFileReader = new StreamReader(sTemp, Encoding.Default);
                        string strLine = m_sSDFFileReader.ReadLine();
                        
                        while(strLine!= null)
                        {
                            m_lstSDFFile.Add(strLine);
                            strLine = m_sSDFFileReader.ReadLine();
                        }
                    }
                    else if (sTemp.EndsWith(".awl") || sTemp.EndsWith(".AWL"))
                    {
                        m_lstAWLFile = new List<string>();
                        m_emPLCMaker = EMPLCMaker.Siemens;

                        m_sAWLFileReader = new StreamReader(sTemp, Encoding.Default);
                        string strLine = m_sAWLFileReader.ReadLine();

                        while (strLine != null)
                        {
                            m_lstAWLFile.Add(strLine);
                            strLine = m_sAWLFileReader.ReadLine();
                        }
                    }
                    else if(sTemp.EndsWith(".l5k") || sTemp.EndsWith(".L5K"))
                    {
                        m_lstL5kFile = new List<string>();

                        CABL5kFileOpen abFileOpen = new CABL5kFileOpen(sTemp);

                        m_lstL5kFile = abFileOpen.L5kFile;

                        m_emPLCMaker = EMPLCMaker.Rockwell;
                    }
                    else if(sTemp.EndsWith(".csv") || sTemp.EndsWith(".CSV")) //LS Tag, Works2,3 Tag/Logic, Developer Tag/Logic
                    {
                        DataTable dtTemp = OpenCSVFile(sTemp);

                        if (m_emPLCMaker.Equals(EMPLCMaker.Mitsubishi))
                        {
                            if (m_dbMelsecCSV == null)
                                m_dbMelsecCSV = new DataSet();

                            dbMelsecCSV.Tables.Add(dtTemp);
                        }
                        else if (m_emPLCMaker.Equals(EMPLCMaker.LS))
                        {
                            if(m_dbLS == null)
                                m_dbLS = new DataSet();

                            m_dbLS.Tables.Add(dtTemp);
                        }
                    }
                    else if(sTemp.EndsWith(".IL") || sTemp.EndsWith(".il"))
                    {
                        m_emPLCMaker = EMPLCMaker.LS;

                        DataSet dbTemp = OpenILFile(sTemp);

                        if (m_dbLS == null)
                            m_dbLS = new DataSet();

                        m_dbLS.Merge(dbTemp);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private DataSet OpenILFile(string sPath) 
        {
            DataSet dbIL = new DataSet();
            
            try
            {
                if (File.Exists(sPath) == false)
                {
                    dbIL = null;
                    return dbIL;
                }

                StreamReader cReader = new StreamReader(sPath, Encoding.Default);

                string sFileName = Path.GetFileName(sPath).Replace(".IL", string.Empty);

                DataTable DT;
                DataRow dbRow;
                string[] TempArray;

                while (!cReader.EndOfStream)
                {
                    string sILLine = cReader.ReadLine();

                    if (sILLine == string.Empty)
                        continue;

                    if (!sILLine.Contains("\t") && sILLine.Contains("[") && sILLine.Contains("]"))
                    {
                        DataTable dtProgram = new DataTable();
                        //dtProgram.TableName = sILLine.Replace("[", string.Empty).Replace("]", string.Empty);
                        dtProgram.TableName = string.Format("{0}_{1}", sFileName, sILLine);
                        dbIL.Tables.Add(dtProgram);
                    }
                    else
                    {
                        DT = dbIL.Tables[dbIL.Tables.Count - 1];

                        TempArray = sILLine.Split('\t');

                        if (TempArray.Length != 1)
                        {
                            if (DT.Columns.Count == 0)
                            {
                                for (int i = 0; i < 3; i++)
                                    DT.Columns.Add(i.ToString());
                            }

                            dbRow = DT.NewRow();

                            if (TempArray.Length == 4)
                            {
                                TempArray[1] = string.Format("{0}.{1}", TempArray[1], TempArray[2]);
                                TempArray[2] = TempArray[3];

                                for (int i = 0; i < 3; i++)
                                    dbRow[i] = TempArray[i];
                            }
                            else
                            {
                                for (int i = 0; i < TempArray.Length; i++)
                                    dbRow[i] = TempArray[i];
                            }

                            DT.Rows.Add(dbRow);
                        }
                        TempArray = null;
                    }
                }                               
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                dbIL = null;
            }

            return dbIL;
        }

        private DataTable OpenCSVFile(string sPath)
        {
            DataTable dbCSV = new DataTable(Path.GetFileName(sPath));

            CCsvReader cHelper = new CCsvReader();

            bool bOK = false;

            StreamReader cReader = new StreamReader(sPath, Encoding.Default);
            string sFirstLine = cReader.ReadLine();

            string[] TempArray = sFirstLine.Split(',');
            cReader.Dispose();
            cReader = null;
            if (TempArray.Length == 1)
            {
                cHelper.CsvType = General.EMCsvType.Tab;

                if (CheckLogicFile(sPath))
                    bOK = cHelper.Open(sPath, true, 2);
                else
                    bOK = cHelper.Open(sPath, true, 1); // Works2,3 Tag Format

                m_emPLCMaker = EMPLCMaker.Mitsubishi;
            }
            else if (TempArray.Length == 2 || TempArray.Length == 7)
            {
                bOK = cHelper.Open(sPath, true, 7); //LS Tag Format
                m_emPLCMaker = EMPLCMaker.LS;
            }
            else if (TempArray.Length == 3)
            {
                bOK = cHelper.Open(sPath, true); //Developer Tag Format
                m_emPLCMaker = EMPLCMaker.Mitsubishi;
            }
            else //if (TempArray.Length == 9 || TempArray.Length == 4)
            {
                bOK = cHelper.Open(sPath, false); // Developer, Works2,3 Logic format
                m_emPLCMaker = EMPLCMaker.Mitsubishi;
            }

            if (bOK)
                bOK = cHelper.Fill(dbCSV);

            cHelper.Dispose();
            cHelper = null;

            return dbCSV;
        }

        private bool CheckLogicFile(string sPath)
        {
            bool bOK = false;

            StreamReader cReader = new StreamReader(sPath, Encoding.Default);
            string sFirstLine = string.Empty;
            string[] TempArray = null;

            for (int i = 0; i < 3; i++)
            {
                sFirstLine = cReader.ReadLine();
                TempArray = sFirstLine.Split(',');

                for (int j = 0; j < TempArray.Length; j++)
                {
                    if (TempArray[j].Contains("Step No."))
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            cReader.Dispose();
            cReader = null;

            return bOK;
        }

        #endregion
    }
}
