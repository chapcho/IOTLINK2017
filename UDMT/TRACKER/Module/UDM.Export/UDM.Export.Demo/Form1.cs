using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UDM.Common;
using UDM.Converter;
using UDM.Export;
using UDM.General;
using UDM.General.Csv;
using UDM.UI;

namespace UDM.Export.Demo
{
    public enum EMPlcColumnBase
    {
        Symbol,
        Address,
    }

    public partial class Form1 : Form
    {
        CExport m_cExport = new CExport();
        CTagS m_cTagS = new CTagS();
        BackgroundWorker m_backgroundWorker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.xlsx|*.xlsx";
            dlgSaveFile.ShowDialog();
            string sPath = dlgSaveFile.FileName;
            if (sPath == "")
                return;

            m_backgroundWorker = new BackgroundWorker();
            m_backgroundWorker.DoWork += new DoWorkEventHandler(ExportExcel);
            BackgroundThread BGT = new BackgroundThread(m_backgroundWorker, "Processing..", sPath);
        }

        private void ExportExcel(object sender, DoWorkEventArgs e)
        {
            m_cExport.UEventExcelExportProcess += uEventExcelExportProcess;

            eExcelListType ExcelListType = eExcelListType.LINK;
            string sPlcMaker = ePLC_MAKER.MITSUBISHI_WORKS3;
            m_cExport.ExportExcel(m_cTagS, (string)e.Argument, ExcelListType, sPlcMaker);

            m_cExport.UEventExcelExportProcess -= uEventExcelExportProcess;

        }

        private void uEventExcelExportProcess(object sender, int nProcess)
        {
            m_backgroundWorker.ReportProgress(nProcess);

        }

        private void button_Open_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Developer.csv|*.csv|Works2.csv|*.csv|Works3.csv|*.csv";
            dlgOpenFile.Multiselect = true;
            dlgOpenFile.FilterIndex = 1;

            dlgOpenFile.ShowDialog();
            string[] sPaths = dlgOpenFile.FileNames;

            if (sPaths.Length == 0)
                return;

            DataTable dtTablePLC = new DataTable();
            dtTablePLC.Columns.Add(EMPlcColumnBase.Symbol.ToString());
            dtTablePLC.Columns.Add(EMPlcColumnBase.Address.ToString());

            bool bDeveloper = false;
            if (dlgOpenFile.FilterIndex == 1)
                bDeveloper = true;

            CILConvert cILConvert = null;
            if (dlgOpenFile.FilterIndex == 1)
                cILConvert = LoadPLC(sPaths, false, null, bDeveloper, false);
            else if (dlgOpenFile.FilterIndex == 2)
                cILConvert = LoadPLC(sPaths, true, null, bDeveloper, true);
            else if (dlgOpenFile.FilterIndex == 3)
                cILConvert = LoadPLC(sPaths, true, null, bDeveloper, false);

            if (bDeveloper)
            {
                CLCConvet cLCConvet = new CLCConvet("CH.DV", cILConvert);
                m_cTagS = cLCConvet.TagS;
            }
            else
            {
                foreach (CILSymbol cILSymbol in cILConvert.SymbolS.Values)
                {
                    CTag cTag = new CTag();
                    cTag.Key = "CH.DV" + cILSymbol.Address;
                    cTag.Address = cILSymbol.Address;
                    cTag.Description = cILSymbol.Name;
                    if (!m_cTagS.ContainsKey(cTag.Key))
                        m_cTagS.Add(cTag.Key, cTag);
                }
            }

            foreach (CTag cTag in m_cTagS.Values)
            {
                DataRow dr = dtTablePLC.NewRow();
                dr[(int)EMPlcColumnBase.Symbol] = cTag.Description;
                dr[(int)EMPlcColumnBase.Address] = cTag.Address;
                dtTablePLC.Rows.Add(dr);
            }

            dataGridView_PLC.DataSource = dtTablePLC;
        }


        #region Import  //MX Developer

        private CILConvert LoadPLC(string[] sFileNames, bool bTabSplitter, BackgroundWorker backgroundWorker, bool bDeveloper, bool bWork2)
        {
            CILConvert cILConvert = new CILConvert();
            CILImport cILImport = new CILImport();
            DataSet dbCSV = new DataSet();

            dbCSV = OpenCSVfiles(sFileNames, bTabSplitter);

            if (bDeveloper)
            {
                cILImport.ImportIL(dbCSV);
                cILConvert.ConvertIL(cILImport.DicILLINE, backgroundWorker);
            }

            cILConvert.SymbolS = ImportSymbol(dbCSV, bTabSplitter, bDeveloper, bWork2);

            return cILConvert;
        }

        private DataSet OpenCSVfiles(string[] sArrPath, bool bTabSplitter)
        {
            DataSet dbCSV = new DataSet();

            for (int iTable = 0; iTable < sArrPath.Length; iTable++)
            {
                dbCSV.Tables.Add(Path.GetFileName(sArrPath[iTable]));
                CCsvReader cHelper = new CCsvReader();

                if (bTabSplitter)
                    cHelper.CsvType = EMCsvType.Tab;

                bool bOK = false;

                if (dbCSV.Tables[iTable].TableName.Contains("COMMENT"))
                {
                    bOK = cHelper.Open(sArrPath[iTable], true, 1);
                }
                else
                {
                    if (bTabSplitter)
                        bOK = cHelper.Open(sArrPath[iTable], true, 2);  // works2 format // works3 format
                    else
                        bOK = cHelper.Open(sArrPath[iTable], false); // Developer format
                }

                if (bOK)
                    bOK = cHelper.Fill(dbCSV.Tables[iTable]);

                cHelper.Dispose();
                cHelper = null;
            }

            return dbCSV;
        }

        private CILSymbolS ImportSymbol(DataSet DS, bool bTabSplitter, bool bDeveloper, bool bWorks2)
        {
            CILSymbolS cLcSymbolS = new CILSymbolS();

            foreach (DataTable DT in DS.Tables)
            {
                if (bDeveloper && (DT.Columns.Count > 3 || DT.Columns.Count < 2))
                    continue;

                int iColAddress = 0;
                int iColSymbol = 2;

                if (!bDeveloper)
                {
                    if (bWorks2)
                    {
                        iColSymbol = 1;
                        iColAddress = 4;
                    }
                    else
                    {
                        iColSymbol = 1;
                        iColAddress = 5;
                    }
                }

                string sProgram = DT.TableName.Replace(".csv", string.Empty).ToUpper();

                for (int nRow = 1; nRow < DT.Rows.Count; nRow++)
                {
                    string sAddress = DT.Rows[nRow].ItemArray[iColAddress].ToString().ToUpper();
                    string sName = DT.Rows[nRow].ItemArray[iColSymbol].ToString();

                    if (sAddress == string.Empty)
                        continue;
                    CILSymbol cLcSymbol = new CILSymbol(sName, sAddress, sProgram);

                    if (!cLcSymbolS.ContainsKey(cLcSymbol.Key))
                        cLcSymbolS.Add(cLcSymbol.Key, cLcSymbol);
                }
            }

            return cLcSymbolS;
        }

        #endregion
    }
}
