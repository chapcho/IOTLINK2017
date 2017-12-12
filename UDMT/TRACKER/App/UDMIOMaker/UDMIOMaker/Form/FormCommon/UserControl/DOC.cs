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

namespace NewIOMaker.Form.FormCommon
{
    public partial class DOC : DevExpress.XtraEditors.XtraUserControl
    {
        public DOC()
        {
            InitializeComponent();

            DOCribbon.Minimized = true;
        }
    }
}
