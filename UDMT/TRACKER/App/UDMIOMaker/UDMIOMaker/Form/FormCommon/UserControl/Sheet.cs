using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using NewIOMaker.Classes.Class_MultiCopy;
using NewIOMaker.Form.Form_IOMaker;

namespace NewIOMaker.Form.FormCommon
{
    public partial class Sheet : DevExpress.XtraEditors.XtraUserControl
    {
        IOMenu _ioMenu;

        public Sheet()
        {
            InitializeComponent();

            Sheetribbon.Minimized = true;
        }

        public SpreadsheetControl sheetcontrol
        {
            get { return Userspreadsheet; }
            set { Userspreadsheet = value; }
        }

        #region IOMaker

        public Sheet(IOMenu ioMenu)
        {
            InitializeComponent();
         
            Sheetribbon.Minimized = true;
            CheckForIllegalCrossThreadCalls = false;

        }

        #endregion

        #region MultiCopy

        #endregion
    }
}
