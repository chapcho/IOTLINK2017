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

namespace NewIOMaker.Form.Form_TagGenerator
{
    public partial class TagGridAlarm : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _FrmMain;

        public TagGridAlarm(FormMain FrmMain)
        {
            InitializeComponent();

            _FrmMain = FrmMain;

        }
    }
}
