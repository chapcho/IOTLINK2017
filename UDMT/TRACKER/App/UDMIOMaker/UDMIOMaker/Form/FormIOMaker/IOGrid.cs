using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Enumeration;
using NewIOMaker.Event;
using NewIOMaker.Form.FormCommon;
using NewIOMaker.Form.Form_IOMaker;
using UDM.Common;
using UDM.Export;
using UDM.UDLImport;
using UDM.UI;
using UDM.Ladder;

namespace NewIOMaker.Form.FormIOMaker
{
    public enum EmPlcColumnBase
    {
        Symbol,
        Address,
    }

    public partial class IOGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public event delIOMakerIOListLoad EventIOListLoad;
        public event delIOMakerExportEvent EventIOExportClick;
        public event delLogInputEvent EventLogInput;

        protected BackgroundWorker m_backgroundWorker = new BackgroundWorker();
        protected CExport _cExport = new CExport();
        protected List<CTag> lstTagS = new List<CTag>();
        protected CTagS _cTagS;
        protected IOMenu _IOMenu;
        protected Sheet _sheet;

        public DataTable _ioListDB = new DataTable();
        public DataTable _PLCdb = new DataTable();

        protected eExcelListType _ExcelListType;
        protected string _PLCMaker = string.Empty;
        protected string _BackupTime = string.Empty;

        #region TreeList Member

        private TreeListNode _IOTAG, _IOARRAY, _ITYPE, _OTYPE, _IADDRESS, _OADDRESS;
        private TreeListNode _STAG, _SARRAY, _STYPE, _SADDRESS;
        private TreeListNode _BaseTAG, _BaseARRAY, _BaseTYPE, _BaseADDRESS;

        private TreeListHitInfo _HitInfo = null;

        protected const int IMG_INDEX_TAG = 0;
        protected const int IMG_INDEX_ARRAY = 1;
        protected const int IMG_INDEX_TYPE = 2;
        protected const int IMG_INDEX_ADDRESS = 3;

        #endregion

        #region Intialize/Dispose

        public IOGrid(IOMenu ioMenu, Sheet sheet)
        {
            InitializeComponent();

            _sheet = sheet;
            _IOMenu = ioMenu;
            _IOMenu.EventIOImportClick += _IOMenu_EventIOImportClick;
            _IOMenu.EventIOALLClick += _IOMenu_EventIOALLClick;
            _IOMenu.EventIOIOClick += _IOMenu_EventIOIOClick;
            _IOMenu.EventIODummyClick += _IOMenu_EventIODummyClick;
            _IOMenu.EventIOLinkClick += _IOMenu_EventIOLinkClick;

            treeList1.MouseClick += treeList1_MouseClick;
            btnTreeExpand.ItemClick += btnTreeExpand_ItemClick;
            btnCollapes.ItemClick += btnCollapes_ItemClick;

            var backuploger = new CommonLogger(EMCommonLogType.IOList);
            _ioListDB = backuploger.LogDB; ;

            groupTree.CustomButtonClick += (o, e) => { TreeViewInputTag(_cTagS, _PLCMaker); };

        }

        void ucLadderStep_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        void treeList1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = Control.MousePosition;
                popupMenu1.ShowPopup(point);
            }
        }

        void btnTreeExpand_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.ExpandAll();
        }

        void btnCollapes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.CollapseAll();
        }

        #endregion

        #region Event

        void _IOMenu_EventIOLinkClick(object sender)
        {

        }

        void _IOMenu_EventIODummyClick(object sender)
        {
            _ExcelListType = eExcelListType.DUMMY;
            ExoportMode();
        }

        void _IOMenu_EventIOIOClick(object sender)
        {
            _ExcelListType = eExcelListType.IO;
            ExoportMode();
        }

        void _IOMenu_EventIOALLClick(object sender)
        {

        }

        void _IOMenu_EventIOImportClick(object sender)
        {
            splashScreenManager1.ShowWaitForm();

            try
            {
                _BackupTime = DateTime.Now.ToString();
                var udlImport = new CUDLImport();
                udlImport.UDLGenerate();

                if (udlImport.GlobalTags.Count == 0)
                    return;

                UDM.Common.EMPLCMaker maker = udlImport.CUDL.Tags[0].PLCMaker;
                _cTagS = null;
                _cTagS = udlImport.GlobalTags;
                _PLCMaker = udlImport.CUDL.Tags[0].PLCMaker.ToString();

                foreach (var tag in _cTagS.Values)
                    lstTagS.Add(tag);

                var tagConvertor = new TagsConvertor(_cTagS, 0, udlImport.CUDL.Tags[0].PLCMaker, 1);
                if (tagConvertor.db.Rows.Count != 0)
                {
                    _PLCdb.Clear();
                    _PLCdb = tagConvertor.db;
                    exGrid.DataSource = _PLCdb;
                    exGridViewLog.Columns[0].Visible = false;
                    exGridViewLog.Columns[1].Visible = false;
                    exGridViewLog.Columns[2].Visible = false;
                    exGridViewLog.Columns[3].Visible = false;
                }

                _ioListDB.Rows.Add(_BackupTime, "Import", _PLCMaker);
                var ioListArg = new LogEventArgs {IOLog = _ioListDB};
                EventLogInput(ioListArg);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Open Failed...."+ ex.Message);
            }

            splashScreenManager1.CloseWaitForm();
        }

        #endregion

        #region Private Methods

        protected void ExoportMode()
        {
            if (_cTagS == null)
                return;

            _BackupTime = DateTime.Now.ToString();
            var dlgSaveFile = new SaveFileDialog {Filter = @"*.xlsx|*.xlsx"};
            dlgSaveFile.ShowDialog();
            var sPath = dlgSaveFile.FileName;
            if (sPath == "" || _cTagS.Count == 0)
                return;

            var type = PLCMakerConvertor(_PLCMaker);
            if (type == ePLC_MAKER.AB_ALIAS)
            {
                m_backgroundWorker = new BackgroundWorker();
                m_backgroundWorker.DoWork += new DoWorkEventHandler(ExportExcelAB);
                var BGT = new BackgroundThread(m_backgroundWorker, "Processing..", sPath);
                m_backgroundWorker.RunWorkerCompleted += (o, s) => { LoadExceltoSheet(sPath); };
            }
            else
            {
                m_backgroundWorker = new BackgroundWorker();
                m_backgroundWorker.DoWork += new DoWorkEventHandler(ExportExcel);
                var BGT = new BackgroundThread(m_backgroundWorker, "Processing..", sPath);
                m_backgroundWorker.RunWorkerCompleted += (o, s) => { LoadExceltoSheet(sPath); };
            }

            _ioListDB.Rows.Add(_BackupTime, "Export", _ExcelListType.ToString());
            var ioListArg = new LogEventArgs {IOLog = _ioListDB};
            EventLogInput(ioListArg);

            
        }

        private void DoworkABExport(string inputPath, string outPath, string CoverName)
        {
            var abExport = new IOListExport(_cTagS);
           
            if (_ExcelListType == eExcelListType.IO)
            {
                abExport.ExportToExcel(abExport.LstIoTag, inputPath, outPath, CoverName);
            }
        }

        private void ExportExcel(object sender, DoWorkEventArgs e)
        {
            var path = (string)e.Argument;
            _cExport.UEventExcelExportProcess += UEventExcelExportProcess;

            if (!_cExport.ExportExcel(_cTagS, (string)e.Argument, _ExcelListType, PLCMakerConvertor(_PLCMaker)))
            {
                MessageBox.Show("ExcelTemplate 파일이 존재 하지 않습니다.", "Important Note",
                                 MessageBoxButtons.OK,MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            _cExport.UEventExcelExportProcess -= UEventExcelExportProcess;
        }

        private void ExportExcelAB(object sender, DoWorkEventArgs e)
        {
            var abExport = new IOListExport(_cTagS);
            var inputPath = string.Empty;

            switch (_ExcelListType)
            {
                case eExcelListType.IO:
                    inputPath = Application.StartupPath + "\\ExcelTemplate\\AB\\IO_LIST_Template.xls";
                    break;
                case eExcelListType.DUMMY:
                    inputPath = Application.StartupPath + "\\ExcelTemplate\\AB\\DUMMY_LIST_Template";
                    break;
            }

            var finfo = new FileInfo(inputPath);
            if(!finfo.Exists)
            {
                MessageBox.Show("ExcelTemplate 파일이 존재 하지 않습니다.", "Important Note",
                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            var path = (string)e.Argument;

            abExport.UEventExcelExportProcess += UEventExcelExportProcess;
            switch (_ExcelListType)
            {
                case eExcelListType.IO:
                    abExport.ExportToExcel(abExport.LstIoTag, inputPath, (string)e.Argument, "Project");
                    break;
                case eExcelListType.DUMMY:
                    abExport.ExportToExcelDummy(abExport.DicDummyTagS, inputPath, (string)e.Argument, "Project");
                    break;
            }
            abExport.UEventExcelExportProcess -= UEventExcelExportProcess;
        }

        private void UEventExcelExportProcess(object sender, int nProcess)
        {
            m_backgroundWorker.ReportProgress(nProcess);
        }

        private string PLCMakerConvertor(string value)
        {

            if (value.Contains("Developer"))
                return ePLC_MAKER.MITSUBISHI_DEVELOPER;
            else if (value.Contains("Works2"))
                return ePLC_MAKER.MITSUBISHI_WORKS2;
            else if (value.Contains("Works3"))
                return ePLC_MAKER.MITSUBISHI_WORKS3;
            else if (value.Contains("Siemens"))
                return ePLC_MAKER.SIEMENS;
            else if (value.Contains("Rockwell"))
                return ePLC_MAKER.AB_ALIAS;
            else
                return value;

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
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
     
        #endregion

        #region TreeList Node

        private void TreeViewInputTag(CTagS tags, string conver)
        {
            splashScreenManager1.ShowWaitForm();

            try
            {
                string type = PLCMakerConvertor(_PLCMaker);

                if (type == ePLC_MAKER.AB_ALIAS)
                {
                    treeList1.ClearNodes();
                    ABTreeInput(tags);
                }
                else
                {
                    MessageBox.Show("Not Supported..");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            splashScreenManager1.CloseWaitForm();
        }

        private void ABTreeInput(CTagS tags)
        {
            IOListExport ABIO = new IOListExport(tags);

            _IOTAG = treeList1.Nodes.Add(new object[] { "[ TAG ] IO" });
            _STAG = treeList1.Nodes.Add(new object[] { "[ TAG ] S" });
            _BaseTAG = treeList1.Nodes.Add(new object[] { "[ TAG ] BASE" });

            CreateIONode(ABIO.LstIoTag);
            CreateSNode(ABIO.LstSTag);
            CreateBASENode(ABIO.LstBaseTag);

        }

        private void CreateIONode(List<ABTag> ABSTags)
        {
            foreach (var node in GetSortingData(ABSTags))
            {
                _IOARRAY = _IOTAG.Nodes.Add(new object[] { node.Key });
                _IOARRAY.ImageIndex = IMG_INDEX_ARRAY;
                _IOARRAY.Tag = node.Value;

                var arrayList = ABSTags.FindAll(s => s.ABINFO == node.Value.ABINFO);
                if (arrayList == null)
                    return;

                _ITYPE = _IOARRAY.Nodes.Add(new object[] { node.Value.ABINFO + ": I"  });
                _OTYPE = _IOARRAY.Nodes.Add(new object[] { node.Value.ABINFO + ": O" });

                var IList = arrayList.FindAll(s => s.ABGROUP == "I");
                if (IList != null)
                {
                    IList.Sort(CompareTwoPointAddress);
                    foreach(ABTag t in IList)
                    {
                        _IADDRESS = _ITYPE.Nodes.Add(new object[] { t.ABGROUP });
                        _IADDRESS.SetValue(colARRAY, GetArray(t.ABADDRESS));
                        _IADDRESS.SetValue(colADDRESS, t.ABADDRESS);
                        _IADDRESS.SetValue(colSYMBOL, t.ABSYMBOL);
                        _IADDRESS.SetValue(colTYPE, t.ABDATATYPE);
                    }
                }

                var OList = arrayList.FindAll(s => s.ABGROUP == "O");
                if (OList != null)
                {
                    OList.Sort(CompareTwoPointAddress);
                    foreach (ABTag t in OList)
                    {
                        _OADDRESS = _OTYPE.Nodes.Add(new object[] { t.ABGROUP });
                        _OADDRESS.SetValue(colARRAY, GetArray(t.ABADDRESS));
                        _OADDRESS.SetValue(colADDRESS, t.ABADDRESS);
                        _OADDRESS.SetValue(colSYMBOL, t.ABSYMBOL);
                        _OADDRESS.SetValue(colTYPE, t.ABDATATYPE);
                    }
                }

            }
        }

        private void CreateSNode(List<ABTag> ABSTags)
        {

            foreach (int idInfo in GetUnitInfo(ABSTags))
            {
                _SARRAY = _STAG.Nodes.Add(new object[] { "LOCAL : " + idInfo });
                _SARRAY.ImageIndex = IMG_INDEX_ARRAY;

                var arrayList = ABSTags.FindAll(s => s.ABINFO == idInfo.ToString());
                if (arrayList == null)
                    return;

                foreach (int t in GetUnitArray(arrayList))
                {
                    var dataList = arrayList.FindAll(s => GetArray(s.Address) == t.ToString());
                    _STYPE = _SARRAY.Nodes.Add(new object[] { "LOCAL : " + idInfo });

                    foreach(ABTag data in dataList)
                    {
                        _SADDRESS = _STYPE.Nodes.Add(new object[] { "LOCAL : " + idInfo });
                        _SADDRESS.SetValue(colTYPE, GetDataType(data.Address));
                        _SADDRESS.SetValue(colARRAY, t);
                        _SADDRESS.SetValue(colADDRESS, data.Address);
                        _SADDRESS.SetValue(colSYMBOL, data.Name);
                    }

                }


            }

        }

        private void CreateBASENode(List<ABTag> ABBaseTags)
        {
            foreach (var node in ABBaseTags)
            {
                _BaseARRAY = _BaseTAG.Nodes.Add(new object[] { GetAddress(node.Address) });
                _BaseARRAY.ImageIndex = IMG_INDEX_ARRAY;
                _BaseARRAY.SetValue(colARRAY, GetSize(node.Address));
                _BaseARRAY.SetValue(colTYPE, node.DataType);
                _BaseARRAY.Tag = node;

                var arrayList = lstTagS.FindAll(s => GetAddress(s.Address) == GetAddress(node.Address) && GetSize(s.Address) != GetSize(node.Address));
                if (arrayList == null)
                    return;

                List<int> ArrayCount = new List<int>();
                foreach (CTag t in arrayList)
                    if (!ArrayCount.Contains(int.Parse(GetArray(t.Address))))
                        ArrayCount.Add(int.Parse(GetArray(t.Address)));
                ArrayCount.Sort();

                foreach (int arr in ArrayCount)
                {
                    var arrayDetailList = arrayList.FindAll(s => GetArray(s.Address) == arr.ToString());
                    if (arrayDetailList == null)
                        return;

                    _BaseTYPE = _BaseARRAY.Nodes.Add(new object[] { GetPointRemove(arrayDetailList[0].Address) });
                    arrayDetailList.Sort(CompareAddress);

                    foreach (CTag ctag in arrayDetailList)
                    {
                        _BaseADDRESS = _BaseTYPE.Nodes.Add(new object[] { GetPointRemove(ctag.Address) });

                        _BaseADDRESS.SetValue(colARRAY, arr);
                        _BaseADDRESS.SetValue(colTYPE, GetDataType(ctag.Address));
                        _BaseADDRESS.SetValue(colADDRESS, ctag.Address);
                        _BaseADDRESS.SetValue(colSYMBOL, ctag.Name);
                    }

                }
            }

        }

        #endregion

        #region GetFunction

        private Dictionary<string, ABTag> GetSortingData(IEnumerable<ABTag> tags)
        {
            var temp = new Dictionary<string, ABTag>();
            var idInfoData = new Dictionary<string, ABTag>();

            foreach (var tag in tags)
            {
                if (!temp.ContainsKey(tag.ABINFO))
                    temp.Add(tag.ABINFO, tag);
            }

            foreach (var item in temp.OrderBy(i => i.Key))
                idInfoData.Add(item.Key, item.Value);

            temp.Clear();

            return idInfoData;
        }

        private IEnumerable<int> GetUnitInfo(IEnumerable<ABTag> absTags)
        {
            var arrayCount = new List<int>();
            foreach (var t in absTags)
                if (!arrayCount.Contains(int.Parse(t.ABINFO)))
                    arrayCount.Add(int.Parse(t.ABINFO));

            arrayCount.Sort();
            return arrayCount;
        }

        private IEnumerable<int> GetUnitArray(IEnumerable<ABTag> absTags)
        {
            var arrayCount = new List<int>();
            foreach (var t in absTags)
                if (!arrayCount.Contains(int.Parse(GetArray(t.Address))))
                    arrayCount.Add(int.Parse(GetArray(t.Address)));

            arrayCount.Sort();
            return arrayCount;
        }

        private string GetArray(string value)
        {
            if (!value.Contains("["))
                return "";

            if (value.Contains("."))
            {
                var array = value.Split('[')[1].Split(']')[0]; // B176[13].30 -> 13
                return array;
            }
            else
            {
                var array = value.Split('[')[1].Replace("]", ""); // B176[13] -> 13
                return array;
            }
        }

        private string GetPointRemove(string value)
        {
            try
            {
                return !value.Contains(".") ? value : value.Split('.')[0];
            }
            catch (Exception)
            {
                return value;
            }

        }

        private string GetDataType(string value)
        {
            return value.Contains(".") ? "Bool" : "";
        }

        private string GetAddress(string value)
        {
            return !value.Contains("[") ? value : value.Split('[')[0];
        }

        private string GetSize(string value)
        {
            return !value.Contains("[") ? "" : value.Split('[')[1].Replace("]", "");
        }

        private string GetPointNumber(string value)
        {
            return value.Contains(".") ? value.Split('.')[1] : "";
        }

        private string GetTwoPointNumber(string value)
        {
            if (value.Contains("."))
            {
                var arr = value.Split('.');
                return arr.Length == 3 ? arr[2] : "";
            }
            else
                return "";
        }

        private string NumberChecker(string value)
        {
            var ok = true;

            foreach (var ch in value)
            {
                if (!Char.IsDigit(ch))
                    ok = false;
            }

            return ok ? value : "";
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

        #endregion

        #region Sorting

        private static int CompareID(CTag x, CTag y)
        {
            return CompareString(string.Format("{0:00000000}", x.Address), string.Format("{0:00000000}", y.Address));
        }

        private int CompareAddress(CTag x, CTag y)
        {
            return CompareInt(GetPointNumber(x.Address), GetPointNumber(y.Address));
        }

        private int CompareTwoPointAddress(ABTag x, ABTag y)
        {
            return CompareInt(GetTwoPointNumber(x.ABADDRESS), GetTwoPointNumber(y.ABADDRESS));
        }

        private static int CompareString(string textA1, string textB1)
        {
            if (textA1 == null)
            {
                if (textB1 == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (textB1 == null)
                    return 1;
                else

                    return textA1.CompareTo(textB1);
            }
        }

        private int CompareInt(string A, string B)
        {
            string textA1 = NumberChecker(A);
            string textB1 = NumberChecker(B);

            if (textA1 == null || textA1 == "")
            {
                if (textB1 == null || textB1 == "")
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (textB1 == null || textB1 == "")
                    return 1;
                else
                {
                    int a = int.Parse(textA1);
                    int b = int.Parse(textB1);
                    return a.CompareTo(b);
                }

            }

        }

        #endregion

    }
}
