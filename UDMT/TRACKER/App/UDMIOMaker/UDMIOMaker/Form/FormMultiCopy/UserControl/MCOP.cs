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
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;
using NewIOMaker.Form.Form_Common;
using NewIOMaker.Enumeration.EnumMultiCopy;
using NewIOMaker.Event.EventMultiCopy;
using NewIOMaker.Classes.ClassMultiCopy;
using NewIOMaker.Classes.ClassCommon.Util;

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class MCOP : DevExpress.XtraEditors.XtraUserControl
    {
        #region Dll Import

        [DllImport("kernel32.dll")]
        private static extern bool Beep(int freq, int dur);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hwnd, int id);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string sClassName, string sAppName);

        #endregion

        protected Dictionary<int, List<string>> _Data = new Dictionary<int, List<string>>();
        protected Dictionary<string, List<string>> _Key = new Dictionary<string, List<string>>();
        protected List<string> _TabData = new List<string>();
        protected List<string> _KeyData = new List<string>();
        protected CMessage cMessage = new CMessage();
        protected MCMenu _mcMenu;
        protected MCKeyList _mcKeyList;
       
        

        protected int _NowIndex = 0;
        protected int _TabPage = 0;

        protected int _SendKey1 = (int)EMMultiCopyInputKey.Right_Ctrl;
        protected int _SendKey2 = (int)EMMultiCopyInputKey.Right_Alt;


        #region Initialize/Dispose

        public MCOP(MCMenu mcMenu, MCKeyList mcKeyList)
        {
            InitializeComponent();

            _mcMenu = mcMenu;
            _mcKeyList = mcKeyList;


            _mcMenu.EventRunAfter += _mcMenu_EventRunAfter;
            _mcMenu.EventStopAfter += _mcMenu_EventStopAfter;
            _mcKeyList.EventKeySelctAfter += _mcKeyList_EventKeySelctAfter;

        }

        void _mcMenu_EventStopAfter()
        {
            int SelectTab = xtraTabControl1.SelectedTabPageIndex;

            foreach (KeyValuePair<int, List<string>> Datas in _Data)
            {
                if(Datas.Key.Equals(SelectTab))
                {
                    _TabData = Datas.Value;
                }
            }

            RegisterHotKeys();
            cMessage.Run();
        }

        void _mcMenu_EventRunAfter()
        {
            UnregisterHotKeys();
            _KeyData.Clear();
            _TabData.Clear();
            cMessage.Stop();
        }

        void _mcKeyList_EventKeySelctAfter(string SelectKey, Dictionary<string, List<string>> dicKey)
        {
            _KeyData.Clear();

            _Key = dicKey;
            
            foreach (KeyValuePair<string, List<string>> Keys in _Key)
            {
                if (Keys.Key.Equals(SelectKey))
                {
                    _KeyData = Keys.Value;
                }
            }

            groupControl2.Text = "Selected Key : " + SelectKey;
        }


        #endregion

        #region Public Methods


        #region Input Data

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            object oDragFile = e.Data.GetData(DataFormats.FileDrop);

            foreach (string paths in (string[])oDragFile)
            {
                listBox1.Items.Add(paths);
                InputTabPage(paths);
            }

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void InputTabPage(string path)
        {
            string FileName = path.Substring(path.LastIndexOf('\\') + 1);
            string FileData = InputLine(path);

            xtraTabControl1.TabPages.Add(FileName);

            MCTextBox ControlTextBox = new MCTextBox();
            ControlTextBox.Controls[0].Text = FileData;

            DicDataInput(_TabPage, FileData);

            xtraTabControl1.TabPages[_TabPage++].Controls.Add(ControlTextBox);
            ControlTextBox.Dock = DockStyle.Fill;

        }

        private void DicDataInput(int Page , string Data)
        {
            List<string> lstTemp = new List<string>();
            string[] ArrayTemp = Regex.Split(Data, "\r\n");

            foreach (string Temp in ArrayTemp)
            {
                lstTemp.Add(Temp);
            }

            _Data.Add(Page, lstTemp);
        }

        private string InputLine(string file)
        {
            StreamReader stream = new StreamReader(file);
            string TotalLine = stream.ReadToEnd();

            return TotalLine;
        }

        #endregion

        #endregion

        #region Private Mehtods

        protected override void WndProc(ref Message KeyPressed)
        {
            if (KeyPressed.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)KeyPressed.LParam >> 16) & 0xFFFF);

                int modifier = (int)KeyPressed.LParam & 0xFFFF;

                if ((int)key == _SendKey1)  
                {
                    SendKeyWorking(EMMultiCopyUpDown.up);
                }
                else if ((int)key == _SendKey2)
                {
                    SendKeyWorking(EMMultiCopyUpDown.down);
                }
            }

            base.WndProc(ref KeyPressed);
        }

        protected void SendKeyWorking(EMMultiCopyUpDown updown)
        {
            string data = string.Empty;

            if(EMMultiCopyUpDown.up == updown)
                data = _TabData[_NowIndex++];

            else if(EMMultiCopyUpDown.down == updown)
                data = _TabData[--_NowIndex];

            Clipboard.SetText(data);
            CMultiCopyWorking Keywork = new CMultiCopyWorking(_KeyData);
        }

        public void RegisterHotKeys()
        {
            RegisterHotKey(this.Handle, 1, 0x0000, (int)EMMultiCopyInputKey.Right_Ctrl);
            RegisterHotKey(this.Handle, 2, 0x0000, (int)EMMultiCopyInputKey.Right_Alt);

        }

        public void UnregisterHotKeys()
        {
            UnregisterHotKey(this.Handle, 1);
            UnregisterHotKey(this.Handle, 2);
        }

        #endregion
    }
}
