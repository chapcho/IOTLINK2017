using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NewIOMaker.Event.Event_IOMaker;
using NewIOMaker.Form.Form_IOMaker.Menu;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Enumeration.EnumCommon;
using NewIOMaker.Form.Form_Common;
using NewIOMaker.Classes.ClassTagGenerator.Core;
using UDM.Export;
using UDM.Common;
using UDM.Converter;
using UDM.UI;

namespace NewIOMaker.Form.Form_IOMaker.Grid
{
    public enum EMPlcColumnBase
    {
        Symbol,
        Address,
    }

    public partial class IOImportGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public event delIOMakerExportEvent ExportEvent;

        protected BackgroundWorker m_backgroundWorker;
        protected CExport _cExport = new CExport();
        protected CTagS _cTagS = new CTagS();
        protected IOHome _home;

        #region Intialize/Dispose
        public IOImportGrid()
        {

        }

        public IOImportGrid(IOHome home)
        {
            InitializeComponent();
            _home = home;

            this.Load += IOImportGrid_Load;
        }

        void IOImportGrid_Load(object sender, EventArgs e)
        {
            _home.EventExport += home_EventExport;
            _home.EventImport += _home_EventImport;
        }



        #endregion

        #region Public Properites

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        void _home_EventImport(object sender, string PLC)
        {
            int defaultCUP = 0;
            ModulePLC cPlc = new ModulePLC(defaultCUP, PLC);
            gridControl1.DataSource = cPlc.dbPLC;
        }

        void home_EventExport(object sender)
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
            _cExport.UEventExcelExportProcess += uEventExcelExportProcess;

            eExcelListType ExcelListType = eExcelListType.IO;
            string sPlcMaker = ePLC_MAKER.MITSUBISHI_WORKS3;
            _cExport.ExportExcel(_cTagS, (string)e.Argument, ExcelListType, sPlcMaker);
            _cExport.UEventExcelExportProcess -= uEventExcelExportProcess;

            ExportEvent(sender, (string)e.Argument);
        }

        private void uEventExcelExportProcess(object sender, int nProcess)
        {
            m_backgroundWorker.ReportProgress(nProcess);
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
                ClassCommonReader cHelper = new ClassCommonReader();

                if (bTabSplitter)
                    cHelper.CsvType = EMCommonCsvType.Tab;

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
     
        #endregion
    }
}
