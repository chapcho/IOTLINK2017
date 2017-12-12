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
using DevExpress.Spreadsheet;
using System.Text.RegularExpressions;
using NewIOMaker.Classes.ClassTagGenerator;

namespace NewIOMaker.Form.FormCommon.Convertor
{
    public partial class ControlABConvertor : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _frmMain;
        protected List<string> _ABTags = new List<string>();

        public ControlABConvertor(FormMain frmMain)
        {
            InitializeComponent();

            _frmMain = frmMain;
            _frmMain.EventPageClick += _frmMain_EventPageClick;

            
            abImport.LinkClicked += abImport_LinkClicked;
            abExport.LinkClicked += abExport_LinkClicked;
            userExport.LinkClicked += userExport_LinkClicked;
        }

        void _frmMain_EventPageClick(Enums.EMCommonPageInfo sender)
        {
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
            commonBar1.Offset = splitContainerControl1.Width;
        }

        void userExport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string sPath = dlgSaveFile.FileName;

            if (sPath == string.Empty)
                return;

            SheetInput(sPath);
        }

        void abExport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "*.csv|*.csv";
            dlgSaveFile.ShowDialog();

            string sPath = dlgSaveFile.FileName;

            if (sPath == string.Empty)
                return;

            DataTable db = new DataTable();
            db.Columns.Add();
            db.Rows.Add("TAG");
            foreach (string Tag in _ABTags)
            {
                db.Rows.Add(Tag + ",");
            }
            db.Rows.Add("END_TAG");

            gridView1.ExportToCsv(sPath);
            WriteCSV(sPath, db);
        }

        void abImport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
            List<string> file = ABL5KOpen();

            CABL5KSorting cABSort = new CABL5KSorting();
            cABSort.ABInformation(file);

            CABL5KConvertor cABConver = new CABL5KConvertor();
            cABConver.AliasConvertor(cABSort.Alias);
            cABConver.BaseConvertor(cABSort.Base);
            cABConver.CommentConvertor(cABSort.Comment);

            gridInput(cABConver.BaseCov, cABConver.AliasCov, cABConver.CommentCoV);
        }

        #region User Sheet Export Function

        private void SheetInput(string sPath)
        {

            IWorkbook workbook = spreadsheetControl1.Document;

            Worksheet worksheet = workbook.Worksheets[0];

            DataTable db = new DataTable();
            db.Columns.Add();

            db.Rows.Add("TAG");

            int iNumber = worksheet.Columns.LastUsedIndex;


            if (iNumber == 11)
            {
                var cells = spreadsheetControl1.ActiveWorksheet.GetUsedRange();

                for (int i = 0; i < cells.RowCount; i++)
                {
                    object sValue = worksheet.Columns["F"][i].DisplayText;

                    bool bCheck = Converting(sValue);

                    if (bCheck)
                    {
                        db.Rows.Add(worksheet.Columns["A"][i].DisplayText + " : " +
                            (worksheet.Columns["F"][i].DisplayText) + ",");
                    }

                }
                db.Rows.Add("END_TAG");
                WriteCSV(sPath, db);
            }
            else if (iNumber == 9)
            {
                var cells = spreadsheetControl1.ActiveWorksheet.GetUsedRange();

                for (int i = 0; i < cells.RowCount; i++)
                {
                    object sValue = worksheet.Columns["E"][i].DisplayText;

                    bool bCheck = Converting(sValue);

                    if (bCheck)
                    {
                        db.Rows.Add(worksheet.Columns["A"][i].DisplayText + " : " +
                            (worksheet.Columns["E"][i].DisplayText) + ",");
                    }

                }
                db.Rows.Add("END_TAG");
                WriteCSV(sPath, db);
            }
            else
                MessageBox.Show("Not Suppoted..");



        }

        private bool Converting(object Value)
        {
            string str = Convert.ToString(Value);

            if (str.Contains(":"))
                return false;
            else
                return true;
        }

        public void WriteCSV(string fileName, System.Data.DataTable DT)
        {

            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(1200));
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)

                        str.Append(string.Format("{0}\t", field));

                    str.Remove(str.Length - 1, 1);

                    str.Append("\r\n");

                }

                str.Remove(str.Length - 2, 2);

                srOutput.WriteLine(str.ToString());

                srOutput.Close();

                fsOutput.Close();

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }

        }

        #endregion

        public List<string> ABL5KOpen()
        {
            OpenFileDialog odlg = new OpenFileDialog();
            List<string> lstFile = new List<string>();
            odlg.Filter = "L5X Files(*.L5K)|*.L5k";

            if (odlg.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("File Open !!");
            }

            try
            {
                StreamReader FileList = new StreamReader(odlg.FileName, Encoding.Default);
                string totalLine = FileList.ReadToEnd();
                string[] Line = Regex.Split(totalLine, "\r\n");

                foreach (string lines in Line)
                {
                    lstFile.Add(lines.Replace("\t", ""));
                }
                FileList.Close();
            }
            catch (Exception ex)
            { Console.WriteLine("File Open Fail..."+ex); }


            return lstFile;
        }

        private void gridInput(List<string> BaseCov, List<string> AliasCov, List<string> CommentCoV)
        {
            DataTable db = new DataTable();
            db.Columns.Add("BaseTag");
            db.Columns.Add("AliasTag");
            db.Columns.Add("CommentTag");

            foreach (string BaseCovs in BaseCov)
            {
                string temp = BaseCovs.Replace(":", " : ");
                _ABTags.Add(temp.Replace("+", ":"));
            }

            foreach (string AliasCovs in AliasCov)
            {
                _ABTags.Add(AliasCovs);
            }

            foreach (string CommentCoVs in CommentCoV)
            {
                _ABTags.Add(CommentCoVs.Replace(":", " : "));
            }

            for(int i = 0; i< gridSize(BaseCov.Count,AliasCov.Count,CommentCoV.Count);i++)
            {
                DataRow dr = db.NewRow();

                if (i < BaseCov.Count)
                    dr["BaseTag"] = BaseCov[i];
                else
                    dr["BaseTag"] = "";

                if (i < AliasCov.Count)
                    dr["AliasTag"] = AliasCov[i];
                else
                    dr["AliasTag"] = "";

                if (i < CommentCoV.Count)
                    dr["CommentTag"] = CommentCoV[i];
                else
                    dr["CommentTag"] = "";
           
                db.Rows.Add(dr);
            }

            gridControl1.DataSource = db;

        }

        private int gridSize(int col0 , int col1, int col2)
        {
            int MaxValue = 0;

            if (col0 > col1)
            {

                if(col0>col2)
                {
                    MaxValue = col0;
                }
                else if(col2 > col0)
                {
                    MaxValue = col2;
                }

            }
            else if (col1 > col0)
            {
                if(col1 > col2)
                {
                    MaxValue = col1;
                }
                else
                {
                    MaxValue = col2;
                }
            }

            return MaxValue;
        }
    }
}
