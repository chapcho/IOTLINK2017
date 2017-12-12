using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Form.FormCommon;
using UDM.Common;
using UDM.UDLImport;
using UDM.Ladder;
using UDM.Log;

namespace NewIOMaker
{
    public partial class IOPLCVerification : UserControl
    {

        private FormMain _frMain;
        private Sheet _sheet;
        private DataTable _dbPLC;
        private CUDLImport _udlImport;
        private PLCVerificationExport _export;
       
        private Dictionary<string, DataRow[]> _userData;
        private VerificationList _list;

        public string Path = Application.StartupPath + "\\ExcelTemplate\\PLCVerification_Template.xls";
        public string PathUser = System.Windows.Forms.Application.StartupPath + "\\ExcelTemplate\\PLCVerification_User_Template.xls";

        #region Initialize/Dispose

        public IOPLCVerification(FormMain frMain)
        {
            InitializeComponent();

            _frMain = frMain;
            _sheet = new Sheet();
            _dbPLC =  new DataTable();
            _userData = new Dictionary<string, DataRow[]>();

            splitControl.Panel2.Controls.Add(_sheet);
            _sheet.Dock = DockStyle.Fill;


            this.Load += IOPLCVerification_Load;

            colLogic.Visible = false;

        }

        private void IOPLCVerification_Load(object sender, EventArgs e)
        {
            this.Resize += (o, s) => { splitControl.SplitterPosition = splitControl.Width / 2; exGridView.BestFitColumns();};
            _frMain.EventIOPLC += (o, option) =>
            {
                switch (option)
                {
                    case EMPLCVerificationMenu.Open:
                        OpenPlc();
                        break;
                    case EMPLCVerificationMenu.Analysis:
                        Analysis();
                        break;
                    case EMPLCVerificationMenu.LogicAdd:
                        AddLogicCheck(o);
                        break;
                    case EMPLCVerificationMenu.ExportToExcel:
                        Export(option);
                        break;
                    case EMPLCVerificationMenu.ExportToWord:
                        Export(option);
                        break;
                    case EMPLCVerificationMenu.ExportToPdf:
                        Export(option);
                        break;
                }
            };

            exGridView.RowCellStyle += exGridView_RowCellStyle;
            exGridView.DoubleClick += exGridView_DoubleClick;
            exGridPLC.MouseClick += exGridPLC_MouseClick;

            LoadExceltoSheet(Path);
        }

        private void exGridPLC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var point = Control.MousePosition;
            popupMenu.ShowPopup(point);
        }

        private void exGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            //var View = sender as GridView;
            //if (e.Column.FieldName == "memory")
            //{
            //    var category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["memory"]);
            //    if (category == "심볼")
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.LightBlue;
            //    }
            //    else if (category == "로직")
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.Salmon;
            //    }
            //    else if (category == "심볼/로직")
            //    {
            //        e.Appearance.BackColor = System.Drawing.Color.RoyalBlue;
            //    }
            //}
        }

        private void exGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var address = exGridView.GetFocusedRowCellDisplayText(colAddress);
                if (address == string.Empty)
                    return;

                var lstStep = _udlImport.StepS.Where(i => i.Value.Address == address).Select(i => i.Value).ToList();
                if (lstStep.Count == 0)
                    return;

                ViewTabControl.TabPages.Clear();
                for (int i = 0; i < lstStep.Count; i++)
                {
                    var ucStep = new UCLadderStep(lstStep[i], new UDM.Log.CTimeLogS(), EditorBrand.Common);
                    ViewTabControl.TabPages.Add(address + " : " + (i + 1).ToString());
                    ViewTabControl.TabPages[i].Controls.Add(ucStep);
                    ucStep.Dock = DockStyle.Fill;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Value Null...Exception..Error..");
            }

        }

 
        #endregion

        #region Public Methods

        private void OpenPlc()
        {
            try
            {
                _udlImport = new CUDLImport();
                _udlImport.UDLGenerate();

                InputDataSymbol(_dbPLC, _udlImport.GlobalTags.Values);
            }
            catch (Exception)
            {
                Console.WriteLine("PLC Import Fail....");
            }

        }

        private void Analysis()
        {
            try
            {
                InputDataLogic(_dbPLC, _udlImport.GlobalTags.Values);

                _export = new PLCVerificationExport(_list);

                LoadExceltoSheet(PathUser);
            }
            catch (Exception)
            {
                Console.WriteLine("Export Fail...");
            }

        }

        private void AddLogicCheck(object o)
        {
            try
            {
                var s = o.ToString();
                if (s.Contains(" "))
                {
                    XtraMessageBox.Show("공백이 포함되어 있습니다. 공백을 제거해주세요.");
                    return;
                }
                
                var rows = new DataRow[exGridView.DataRowCount];
                for (var i = 0; i < exGridView.DataRowCount; i++)
                {
                    rows[i] = exGridView.GetDataRow(i);
                }

                if (!_userData.ContainsKey(s))
                {
                    _userData.Add(s, rows);
                    if (WritingExcel(s, rows))
                    {
                        var caption = "[" + s + " ]";
                        var textinfo = "사용자 정의가 추가 되었습니다.";
                        var image = Image.FromFile(Application.StartupPath + "\\res\\BackupLoadOK.png");
                        alert.Show(this.FindForm(), caption, textinfo, image);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Add Fail...");
            }

               
        }

        private bool WritingExcel(string name ,DataRow[] rows )
        {
            if (_export == null)
                return false;

            try
            {
                _export.WirteUserExcel(name, rows);
                LoadExceltoSheet(PathUser);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void Export(EMPLCVerificationMenu type)
        {
            if (_udlImport == null || _list.data.IsEmpty())
                return;
            
            splashScreenManager1.ShowWaitForm();
            _sheet.sheetcontrol.Options.Save.CurrentFileName = Application.StartupPath +"\\(" + _udlImport.PLCMaker.ToString() 
                                                                + ")PLCReport_" + DateTime.Now.ToString("yyyy-MM-dd");

            if (type == EMPLCVerificationMenu.ExportToExcel)
            {
               
                _sheet.sheetcontrol.SaveDocumentAs();
            }
            else if (type == EMPLCVerificationMenu.ExportToPdf)
            {
                var savefile = new SaveFileDialog { Filter = @"*.pdf|*.pdf" };
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    _sheet.sheetcontrol.ExportToPdf(savefile.FileName);
                }
                
            }

            splashScreenManager1.CloseWaitForm();
        }

        #endregion

        #region Private Methods

        private void InputDataLogic(DataTable db, IEnumerable<CTag> tags)
        {
            _list = new VerificationList();
            AddColums(db, "PLCVerification");

            foreach (var tag in tags)
            {
                var dr = db.NewRow();
                var contact = GetContact(tag.StepRoleS.ToArray());
                var memory = GetMemory(tag, tag.UseOnlyInLogic);
                var logic = GetLogic(tag, tag.StepRoleS.ToArray());

                VerifiCationTag(tag, contact, memory, logic);
                VerificationCount(memory, contact);

                dr[(int) EMPLCColums.address] = tag.Address;
                dr[(int) EMPLCColums.symbol] = tag.Description;
                dr[(int) EMPLCColums.contact] = contact;
                dr[(int) EMPLCColums.memory] = memory;
                dr[(int) EMPLCColums.logic] = logic;

                db.Rows.Add(dr);
                
            }

            exGridPLC.DataSource = db;
        }

        private void InputDataSymbol(DataTable db, IEnumerable<CTag> tags)
        {
            AddColums(db, "PLCVerification");
            foreach (var tag in tags)
            {
                var dr = db.NewRow();
                dr[(int)EMPLCColums.address] = tag.Address;
                dr[(int)EMPLCColums.symbol] = tag.Description;
                db.Rows.Add(dr);
            }

            exGridPLC.DataSource = db;
        }

        private string GetLogic(CTag tag , IEnumerable<CTagStepRole> stepRoleS)
        {
            var coil = stepRoleS.Where(i => i.RoleType == EMStepRoleType.Coil);
            var both = stepRoleS.Where(i => i.RoleType == EMStepRoleType.Both);

            if (coil.Count() + both.Count() > 1)
            {
                return "NONE";
            }
            else
            {
                return "NONE";
            }
        }

        private string GetMemory(CTag tag, bool useOnlyInLogic)
        {
            if (useOnlyInLogic)
            {
                return "로직";
            }
            else
            {
                return tag.StepRoleS.Count == 0 ? "심볼" : "심볼/로직";
            }
        }

        private string GetContact(IEnumerable<CTagStepRole> stepRoleS)
        {
            var coil = stepRoleS.Where(i => i.RoleType == EMStepRoleType.Coil);
            var contact = stepRoleS.Where(i => i.RoleType == EMStepRoleType.Contact);
            var both = stepRoleS.Where(i => i.RoleType == EMStepRoleType.Both);
            var none = stepRoleS.Where(i => i.RoleType == EMStepRoleType.None);

            if (both.Any() || (contact.Any() && coil.Any()) )
            {
                return "조건/코일";
            }
            else
            {
                if (!contact.Any() && coil.Any())
                    return "코일";
                else if (contact.Any() && !coil.Any())
                    return "조건";
                else if (!none.Any())
                    return "NONE";
                else
                    return "";
            }
        }

        private void AddColums(DataTable db, string plcverification)
        {
            db.Clear();
            db.Columns.Clear();

            db.Columns.Add(EMPLCColums.address.ToString());
            db.Columns.Add(EMPLCColums.symbol.ToString());
            db.Columns.Add(EMPLCColums.memory.ToString());
            db.Columns.Add(EMPLCColums.contact.ToString());
            db.Columns.Add(EMPLCColums.logic.ToString());
        }

        private void VerificationCount(string memory, string contact)
        {
            switch (memory)
            {
                case "심볼":
                    _list.symbol++;
                    break;
                case "로직":
                    _list.logic++;
                    break;
                case "심볼/로직":
                    _list.memoryboth++;
                    break;
            }

            switch (contact)
            {
                case "조건":
                    _list.contact++;
                    break;
                case "코일":
                    _list.coil++;
                    break;
                case "조건/코일":
                    _list.contactboth++;
                    break;
            }
            
        }

        #endregion

        #region Template

        private void VerifiCationTag(CTag tag, string contact, string memory, string logic)
        {

            if (logic == "이중코일")
            {
                var key = "DoubleCoil";
                if (_list.data.ContainsKey(key))
                    _list.data[key].Add(tag);
                else
                    _list.data.Add(key, new BindingList<CTag> { tag });

                _list.doubleCoil++;
            }
        }

        private void LoadExceltoSheet(string outPath)
        {
            try
            {

                var finfo = new FileInfo(outPath);
                if (finfo.Exists && !IsFileLocked(finfo))
                {
                    _sheet.sheetcontrol.LoadDocument(outPath);
                }
                else
                {
                    ExceptionSheetLoad();
                }

            }
            catch (Exception ex)
            {
                ExceptionSheetLoad();
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is: 
                //still being written to 
                //or being processed by another thread 
                //or does not exist (has already been processed) 
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked 
            return false;
        }

        private void ExceptionSheetLoad()
        {
            var workbook = _sheet.sheetcontrol.Document;
            Worksheet worksheet = workbook.Worksheets[0];

            Cell cell1 = worksheet.Cells[0, 0];
            cell1.Value = "템플릿 파일로드에 실패 했습니다.";

            Cell cell2 = worksheet.Cells[1, 0];
            cell2.Value = "PLCVerification_Template.xls 파일이 사용 중이거나 파일이 없습니다. ";

            Cell cell3 = worksheet.Cells[2, 0];
            cell3.Value = "프로세스 종료 후 다시 시도해주세요.";
        }

        #endregion
    }

}
