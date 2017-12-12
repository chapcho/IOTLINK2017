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
using NewIOMaker.Form.FormCommon.UserControl;
using NewIOMaker.Form.FormCommon.Convertor;

namespace NewIOMaker.Form.FormCommon.UserControl
{
    public partial class ControlTool : DevExpress.XtraEditors.XtraUserControl
    {
        protected FormMain _frmMain;
        protected DOC _doc;
        protected Sheet _sheet;
        protected ControlABConvertor _abConvertor;

        public ControlTool(FormMain frmMain)
        {
            InitializeComponent();

            _frmMain = frmMain;
            _frmMain.EventMenuToolClick += _frmMain_EventMenuToolClick;

            _doc = new DOC();
            _sheet = new Sheet();
            //abConvertor = new ControlABConvertor();

        }

        void _frmMain_EventMenuToolClick(object sender)
        {
            this.Controls.Clear();

            if(sender.ToString()=="Excel")
            {
                this.Controls.Add(_sheet);
                _sheet.Dock = DockStyle.Fill;
            }
            else if (sender.ToString() == "Doc")
            {
                this.Controls.Add(_doc);
                _doc.Dock = DockStyle.Fill;
            }
            else if (sender.ToString() == "HMIConvert")
            {
                this.Controls.Add(_abConvertor);
                _abConvertor.Dock = DockStyle.Fill;
            }
            else if (sender.ToString() == "TrackerConvert")
            {

            }
        }
    }
}
