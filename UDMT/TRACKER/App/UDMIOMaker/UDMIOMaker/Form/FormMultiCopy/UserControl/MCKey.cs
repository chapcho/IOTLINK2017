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
using NewIOMaker.Classes.ClassMultiCopy;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Event.EventMultiCopy;


namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCKey : DevExpress.XtraEditors.XtraUserControl
    {
        protected Dictionary<string, List<string>> _DicKeyList = new Dictionary<string, List<string>>();
        protected List<string> _KeyList = new List<string>();
        protected DataTable _Keydb = new DataTable();
        protected CMessage cMessage = new CMessage();
        protected MCMenu _mcMenu;

        protected string _KeyName = string.Empty;
        protected string _dbColumn = "Key Order";

        public event delKeyListInputAfter EventKeyListUpdate;

        #region Initialize/Dispose

        public MCKey(MCMenu mcMenu)
        {
            InitializeComponent();

            _mcMenu = mcMenu;

            this.Load += Control_MultiCopy_Key_Load;
        }

        void Control_MultiCopy_Key_Load(object sender, EventArgs e)
        {
            UserKeyRegister();

            btnKeyGeneration.Click += btnKeyGeneration_Click;
            btnKeyRegister.Click += btnKeyRegister_Click;

            KeygridControl.MouseUp += KeygridControl_MouseUp;
            RemoveKey.ItemClick += RemoveKey_ItemClick;

            _Keydb.Columns.Add(_dbColumn);

        }

        #endregion

        #region Public Properites

        public Dictionary<string, List<string>> DicKeyList
        {
            get { return _DicKeyList; }
            set { _DicKeyList = value; }
        }

        #endregion

        #region funtion key Pressed

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tileItemCtrl.Checked)
                tileItemCtrl.Checked = false;
            else
                tileItemCtrl.Checked = true;
        }

        private void tileItemAlt_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tileItemAlt.Checked)
                tileItemAlt.Checked = false;
            else
                tileItemAlt.Checked = true;
        }

        private void tileItemShift_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tileItemShift.Checked)
                tileItemShift.Checked = false;
            else
                tileItemShift.Checked = true;
        }

        private void tileItemWin_ItemClick(object sender, TileItemEventArgs e)
        {
            if (tileItemWin.Checked)
                tileItemWin.Checked = false;
            else
                tileItemWin.Checked = true;
        }

        #endregion

        #region User Key Pressed

        private void tileItemUser_ItemClick(object sender, TileItemEventArgs e)
        {
            Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
            popupMenu1.ShowPopup(CurrentPoint);
        }

        private void UserKeyRegister()
        {
            CMultiCopyUserKey cUserKeyList = new CMultiCopyUserKey();

            foreach (string Alphabets in cUserKeyList.Alphabet)
            {
                repositoryItemCheckedComboBoxEdit2.Items.Add(Alphabets);
            }
            foreach (string Numbers in cUserKeyList.Number)
            {
                repositoryItemCheckedComboBoxEdit1.Items.Add(Numbers);
            }
            foreach (string Maths in cUserKeyList.Math)
            {
                repositoryItemCheckedComboBoxEdit3.Items.Add(Maths);
            }
            foreach (string Funtions in cUserKeyList.Funtion)
            {
                repositoryItemCheckedComboBoxEdit4.Items.Add(Funtions);
            }
        }

        private void barEditItemClear_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barEditItem1.EditValue = null;
            barEditItem2.EditValue = null;
            barEditItem5.EditValue = null;
            barEditItem4.EditValue = null;
        }

        void btnKeyRegister_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> DicTemp = new Dictionary<string, List<string>>();

            if (KeyNameText.Text == "")
            {
                cMessage.KeyClickConform(); return;
            }

            List<string> data = new List<string>();
            foreach (DataRow dr in _Keydb.Rows)
            {
                data.Add(dr[_dbColumn].ToString());
            }
            DicTemp.Add(KeyNameText.Text, data);
            CMultiCopyLogic cKeylogic = new CMultiCopyLogic(DicTemp);
            _KeyList = cKeylogic.KeyConvertList;
            _KeyName = cKeylogic.KeyName;
            _DicKeyList.Add(_KeyName, _KeyList);
            cMessage.RegistConform();

            EventKeyListUpdate(_DicKeyList);

            KeygridControl.DataSource = null;

            _Keydb.Clear();
            _DicKeyList.Clear();
            KeyNameText.Text = "";
            
        }

        void RemoveKey_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] SelcetGrid = KeygridView.GetSelectedRows();

            foreach (int deleteRow in SelcetGrid)
            {
                _Keydb.Rows.RemoveAt(deleteRow);

                break;
            }
        }

        void KeygridControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                Gridpopup.ShowPopup(CurrentPoint);
            }
        }

        void btnKeyGeneration_Click(object sender, EventArgs e)
        {
            CMultiCopyCombination KeyCom = new CMultiCopyCombination();
            string sKey = string.Empty;
            if (tileItemCtrl.Checked)
                sKey = sKey + "Ctrl" + "+";
            if (tileItemAlt.Checked)
                sKey = sKey + "Alt" + "+";
            if (tileItemShift.Checked)
                sKey = sKey + "Shift" + "+";
            if (tileItemWin.Checked)
                sKey = sKey + "Window" + "+";

            object oSelect1 = repositoryItemCheckedComboBoxEdit1.GetCheckedItems();
            if (oSelect1.ToString() != "")
                sKey = KeyCom.KeyFuntion(sKey, oSelect1);
            object oSelect2 = repositoryItemCheckedComboBoxEdit2.GetCheckedItems();
            if (oSelect2.ToString() != "")
                sKey = KeyCom.KeyFuntion(sKey, oSelect2);
            object oSelect3 = repositoryItemCheckedComboBoxEdit3.GetCheckedItems();
            if (oSelect3.ToString() != "")
                sKey = KeyCom.KeyFuntion(sKey, oSelect3);
            object oSelect4 = repositoryItemCheckedComboBoxEdit4.GetCheckedItems();
            if (oSelect4.ToString() != "")
                sKey = KeyCom.KeyFuntion(sKey, oSelect4);
            if (sKey.EndsWith("+"))
                sKey = sKey.Remove(sKey.Length - 1);

            if (sKey != string.Empty)
            {
                DataRow dr = _Keydb.NewRow();
                dr[_dbColumn] = sKey;

                _Keydb.Rows.Add(dr);
            }

            KeygridControl.DataSource = _Keydb;
        }

        #endregion
    }
}
