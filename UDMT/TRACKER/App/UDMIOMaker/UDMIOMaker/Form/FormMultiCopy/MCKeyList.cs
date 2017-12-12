using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using NewIOMaker.Event;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCKeyList : DevExpress.XtraEditors.XtraUserControl
    {
        public event delKeyListSelectAfter EventKeySelctAfter;


        public DataTable _db = new DataTable();

        protected Dictionary<string, List<string>> _dicKey = new Dictionary<string, List<string>>();

        protected MCKey _mcKey;
        protected MCMenu _mcMenu;
        protected string _KeyGridColumn1 = "Key List";
        protected string _KeyGridColumn2 = "Option";

        #region Initialize/Dispose

        public MCKeyList(MCMenu mcMenu,MCKey mcKey)
        {
            InitializeComponent();

            _mcMenu = mcMenu;
            _mcKey = mcKey;
            _mcKey.EventKeyListUpdate += _mcKey_EventKeyListUpdate;
            _mcKey.EventGenerateKeyClick += _mcKey_EventGenerateKeyClick;

            KeyListGridView.DoubleClick += KeyListGridView_DoubleClick;
            KeyListGridView.MouseUp += KeyListGridView_MouseUp;
            btnRemoveKey.ItemClick += btnRemoveKey_ItemClick;
            UpdateKey.ItemClick += UpdateKey_ItemClick;
            btnSelecKey.ItemClick += btnSelecKey_ItemClick;
            KeyListGridView.MouseDown += KeyListGridView_MouseDown;

            _db.Columns.Add(_KeyGridColumn1);
            _db.Columns.Add(_KeyGridColumn2);

            defaultOpenKeyList();

            
        }

        void KeyListGridView_MouseDown(object sender, MouseEventArgs e)
        {

        }


        void _mcKey_EventGenerateKeyClick(object sender1, object sender2)
        {
            KeyListGridControl.Update();
        }

        void _mcKey_EventKeyListUpdate(Dictionary<string, List<string>> dicKey)
        {
            KeyListGridControl.DataSource = null;

            foreach (var dickeys in dicKey)
            {
                if (_dicKey.ContainsKey(dickeys.Key) == false)
                {
                    _dicKey.Add(dickeys.Key, dickeys.Value);

                    dbChecker();
                    DataRow dr = _db.NewRow();
                    dr[_KeyGridColumn1] = dickeys.Key;
                    dr[_KeyGridColumn2] = dicKeyValueList(dickeys.Key, dicKey);

                    _db.Rows.Add(dr);
                }

            }


            KeyListGridControl.DataSource = _db;

            defaultSaveKeyList();
        }

        void UpdateKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KeyListGridControl.Update();
        }

        void btnRemoveKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string key = selectedGrid();

            if (key == null)
                return;

            _dicKey.Remove(key);

            int[]SelectRows = KeyListGridView.GetSelectedRows();

            foreach(int Selectrow in SelectRows)
            {
                _db.Rows[Selectrow].Delete();
                break;
            }

            defaultSaveKeyList();  
      
        }

        void KeyListGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupKeyList.ShowPopup(CurrentPoint);
            }
        }

        #endregion

        #region Key Worker

        void btnSelecKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string keyValue = selectedGrid();

            if (keyValue == null)
                return;

            EventKeySelctAfter(keyValue, _dicKey);
        }

        void KeyListGridView_DoubleClick(object sender, EventArgs e)
        {
            string keyValue = selectedGrid();

            if (keyValue == null)
                return;

          
            EventKeySelctAfter(keyValue, _dicKey);
        }

        #endregion

        #region Public Methods

        protected string dicKeyValueList(string key,Dictionary<string, List<string>> dicKey)
        {
            string Values = string.Empty;

            foreach (KeyValuePair<string, List<string>> item in dicKey)
            {
                foreach(string str in item.Value)
                {
                    Values = Values + "+" + str;
                }
            }

            return Values;
        }
     
        protected void defaultSaveKeyList()
        {
            if (KeyListGridControl.DataSource == null)
                return;

            CommonSerializer cSerializer = new CommonSerializer();
            CommonProject cProject = new CommonProject();

            cProject.KeyDB = (DataTable)KeyListGridControl.DataSource;
            cProject.DicKey = _dicKey;

            string sSavePath = Application.StartupPath;
            string SaveName = sSavePath + "\\AutoBackupKeyList.UDM";

            cSerializer.Write(SaveName, cProject);
            cSerializer = null;
        }

        protected void defaultOpenKeyList()
        {
            try
            {
                string sSavePath = Application.StartupPath + "\\AutoBackupKeyList.UDM";

                CommonSerializer cSerializer = new CommonSerializer();

                object oProject = cSerializer.Read(sSavePath);

                CommonProject cProject = (CommonProject)oProject;

                KeyListGridControl.DataSource = cProject.KeyDB;

                
                _dicKey = cProject.DicKey;

                foreach (var dickeys in _dicKey)
                {
                    dbChecker();
                    DataRow dr = _db.NewRow();
                    dr[_KeyGridColumn1] = dickeys.Key;
                    dr[_KeyGridColumn2] = dicKeyValueList(dickeys.Key, _dicKey);
                    //dr[_KeyGridColumn2] = ListConvertor(dickeys.Value);

                    _db.Rows.Add(dr);
                }

                KeyListGridControl.DataSource = _db;
            }
            catch(Exception ex)
            {
                Console.WriteLine("No Key List..." + ex);
            }
            
        }

        protected string ListConvertor(List<string> value)
        {
            string KeyValue = string.Empty;

            foreach (string values in value)
            {
                KeyValue = KeyValue + KeyConvertor(values);
            }
                            
            return KeyValue;
        }

        protected void dbChecker()
        {
            if(_db.Columns.Count==0)
            {
                _db.Columns.Add(_KeyGridColumn1);
                _db.Columns.Add(_KeyGridColumn2);
            }
        }

        protected string KeyConvertor(string sKey)
        {
            string value = string.Empty;

            value = sKey;

            if (value.Contains("User : "))
                value = value.Replace("User : ", "");

            if (value.Contains("^"))
                return value.Replace("^", "Ctrl");
            if (value.Contains("+"))
                return value.Replace("+", "Alt");
            if (value.Contains("%"))
                return value.Replace("%", "Shift");
            if (value.Contains("{PGDN}"))
                return value.Replace("{PGDN}", "PageDown");
            if (value.Contains("{PGUP}"))
                return value.Replace("{PGUP}", "PageUP");
            if (value.Contains("{PRTSC}"))
                return value.Replace("{PRTSC}", "PrintScreen");
            else
                return value;
        }

        protected string selectedGrid()
        {
            int[] SelctRow = KeyListGridView.GetSelectedRows();

            if (SelctRow.Length == 0)
                return null;

            string keyValue = string.Empty;

            foreach (int selecRow in SelctRow)
            {
                DataRow dr = (DataRow)KeyListGridView.GetDataRow(selecRow);
                keyValue = dr[_KeyGridColumn1].ToString();

               
                break;
            }

            return keyValue;
        }

        #endregion
    }
}
