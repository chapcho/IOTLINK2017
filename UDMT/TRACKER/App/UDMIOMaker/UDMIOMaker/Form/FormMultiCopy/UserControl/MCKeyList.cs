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
using NewIOMaker.Event.EventMultiCopy;

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCKeyList : DevExpress.XtraEditors.XtraUserControl
    {
        protected Dictionary<string, List<string>> _dicKey = new Dictionary<string, List<string>>();
        protected DataTable _db = new DataTable();
        protected MCKey _mcKey;
        protected string _KeyGridColumn1 = "Key List";
        protected string _KeyGridColumn2 = "Annotation";

        public event delKeyListSelectAfter EventKeySelctAfter;

        public MCKeyList(MCKey mcKey)
        {
            InitializeComponent();

            _mcKey = mcKey;

            _mcKey.EventKeyListUpdate += _mcKey_EventKeyListUpdate;
            KeyListGridView.DoubleClick += KeyListGridView_DoubleClick;
            KeyListGridView.MouseUp += KeyListGridView_MouseUp;
            btnRemoveKey.ItemClick += btnRemoveKey_ItemClick;

            _db.Columns.Add(_KeyGridColumn1);
            _db.Columns.Add(_KeyGridColumn2);
        }

        void btnRemoveKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string key = selectedGrid();

            if (key == null)
                return;

            _dicKey.Remove(key);

            _mcKey_EventKeyListUpdate(_dicKey);
        }

        void KeyListGridView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupKeyList.ShowPopup(CurrentPoint);
            }
        }

        void KeyListGridView_DoubleClick(object sender, EventArgs e)
        {
            string keyValue = selectedGrid();

            if (keyValue == null)
                return;

            EventKeySelctAfter(keyValue, _dicKey);
        }

        void _mcKey_EventKeyListUpdate(Dictionary<string, List<string>> dicKey)
        {
            foreach (var dickeys in dicKey)
            {
                if (_dicKey.ContainsKey(dickeys.Key)==false)
                    _dicKey.Add(dickeys.Key, dickeys.Value);              
            }
                
            _db.Clear();

            foreach (string keyList in _dicKey.Keys)
            {
                DataRow dr = _db.NewRow();
                dr[_KeyGridColumn1] = keyList;
                dr[_KeyGridColumn2] = dicKeyValueList(keyList, dicKey);
                _db.Rows.Add(dr);
            }

            KeyListGridControl.DataSource = _db;
            KeyListGridView.BestFitColumns();

        }

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
    }
}
