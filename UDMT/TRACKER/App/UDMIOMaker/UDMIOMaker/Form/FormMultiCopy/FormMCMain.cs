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

namespace NewIOMaker.Form.Form_MultiCopy
{
    public partial class FormMCMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMCMain()
        {
            InitializeComponent();
            this.Load += Form_MultiCopy_Main_Load;
        }

        void Form_MultiCopy_Main_Load(object sender, EventArgs e)
        {
            MCMenu cMultiMain = new MCMenu();

            this.Controls.Add(cMultiMain);

            cMultiMain.Dock = DockStyle.Fill;
        }
    }
}