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

namespace NewIOMaker.Form.Form_TagGenerator
{
    public partial class FormTagMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormTagMain()
        {
            InitializeComponent();
          
            this.Load += Form_Tag_Main_Load;


            Ribbon.Minimized = true;
        }

        void Form_Tag_Main_Load(object sender, EventArgs e)
        {
            TagMain cTagMain = new TagMain();

            this.Controls.Add(cTagMain);

            cTagMain.Dock = DockStyle.Fill;
        }
    }
}