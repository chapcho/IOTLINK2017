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
    public partial class TagGridLog : DevExpress.XtraEditors.XtraUserControl
    {
        protected TagMain _tagMain;
        protected TagGrid _tagGrid;

        public TagGridLog(TagMain tagMain ,TagGrid tagGrid)
        {
            InitializeComponent();

            _tagMain = tagMain;
            _tagGrid = tagGrid;
        }
    }
}
