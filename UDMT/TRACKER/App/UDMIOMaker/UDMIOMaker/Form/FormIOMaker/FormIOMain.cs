using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace NewIOMaker.Form.Form_IOMaker
{
    public partial class FormIOMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormIOMain()
        {
            InitializeComponent();

            this.Load += Form_IO_Main_Load;
        }

        void Form_IO_Main_Load(object sender, EventArgs e)
        {
            IOMenu cIOMain = new IOMenu();

            this.Controls.Add(cIOMain);

            cIOMain.Dock = DockStyle.Fill;
        }
    }
}