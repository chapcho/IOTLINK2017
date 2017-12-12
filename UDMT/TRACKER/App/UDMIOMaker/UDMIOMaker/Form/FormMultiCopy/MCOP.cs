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
using NewIOMaker.Form.FormCommon;
using NewIOMaker.Enumeration;
using NewIOMaker.Event;
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
        
        protected List<string> _TabData = new List<string>();
        protected List<string> _KeyData = new List<string>();
        protected CheckState _FirstCheck = CheckState.Unchecked;
        protected CheckState _SecondCheck = CheckState.Unchecked;

        protected CommonMessage cMessage = new CommonMessage();
        protected MCMenu _mcMenu;
        protected MCKeyList _mcKeyList;
       
        protected int _NowIndex = 0;
        protected int _TabPage = 0;
        protected int _SendKey1 = (int)EMMultiCopyInputKey.Right_Ctrl;
        protected int _SendKey2 = (int)EMMultiCopyInputKey.Right_Alt;

        protected string _UseOrUnUse = "UnUse";
        protected bool _AltCheck = false;

        #region Initialize/Dispose

        public MCOP(MCMenu mcMenu, MCKeyList mcKeyList)
        {
            InitializeComponent();

            _mcMenu = mcMenu;
            _mcKeyList = mcKeyList;
            _mcMenu.EventRunAfter += _mcMenu_EventRunAfter;
            _mcMenu.EventStopAfter += _mcMenu_EventStopAfter;
            _mcMenu.EventSelectKey += _mcMenu_EventSelectKey;
            _mcMenu.EventUseImportClick += _mcMenu_EventUseImportClick;
            _mcKeyList.EventKeySelctAfter += _mcKeyList_EventKeySelctAfter;

        }

        void _mcMenu_EventUseImportClick(string value)
        {
            if (_UseOrUnUse == "UnUse")
            {
                _UseOrUnUse = "Use";

                int SelectTab = xtraTabControl1.SelectedTabPageIndex;

                foreach (KeyValuePair<int, List<string>> Datas in _Data)
                {
                    if (Datas.Key.Equals(SelectTab))
                    {
                        _TabData = Datas.Value;
                    }
                }
            }
            else
            {
                _UseOrUnUse = "UnUse";
            }
           
        }

        void _mcMenu_EventSelectKey(object sender1, object sender2)
        {
            _FirstCheck = (CheckState)sender1;
            _SecondCheck = (CheckState)sender2;
        }

        void _mcMenu_EventStopAfter()
        {
            UnregisterHotKeys();
            _KeyData.Clear();
            _TabData.Clear();
            cMessage.Stop();
            _NowIndex = 0;
        }

        void _mcMenu_EventRunAfter()
        {
            int SelectTab = xtraTabControl1.SelectedTabPageIndex;

            foreach (KeyValuePair<int, List<string>> Datas in _Data)
            {
                if (Datas.Key.Equals(SelectTab))
                {
                    _TabData = Datas.Value;
                }
            }

            RegisterHotKeys();
            cMessage.Run();
        }

        void _mcKeyList_EventKeySelctAfter(string SelectKey, Dictionary<string, List<string>> dicKey)
        {
            Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();

            temp = dicKey;

            foreach (KeyValuePair<string, List<string>> Keys in temp)
            {
                if (Keys.Key == SelectKey)
                {

                    _KeyData = Keys.Value;
                }
            }

            FileViewGroup.Text = "Selected Key : " + SelectKey;
        }

        #endregion

        #region Public Methods

        #region Input Data

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            object oDragFile = e.Data.GetData(DataFormats.FileDrop);

            foreach (string paths in (string[])oDragFile)
            {
                MClistBox.Items.Add(paths);
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

            if (_UseOrUnUse == "Use")
            {
                try
                {
                    if (EMMultiCopyUpDown.up == updown)
                    {
                        if (!_AltCheck && _NowIndex != 0)
                            _NowIndex++;

                        data = _TabData[_NowIndex++];

                        _AltCheck = true;
                    }                      
                    else if (EMMultiCopyUpDown.down == updown)
                    {
                        if (_AltCheck)
                            _NowIndex--;

                        data = _TabData[--_NowIndex];

                        _AltCheck = false;
                    }                      
                    Clipboard.SetText(data);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("MultiCopy Exception..." + ex);
                    Clipboard.Clear();
                    _NowIndex = 0;
                }

            }
            
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
