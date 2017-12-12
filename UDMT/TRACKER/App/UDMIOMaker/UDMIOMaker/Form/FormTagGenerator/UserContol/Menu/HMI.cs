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
using NewIOMaker.Event.Event_TagGenerator;
using NewIOMaker.Enumeration.Enum_Common;
using NewIOMaker.Classes.ClassTagGenerator.Base;

namespace NewIOMaker.Form.Form_TagGenerator.Menu
{
    public partial class HMI : DevExpress.XtraEditors.XtraUserControl
    {

        public event delHMILSISClick EventImportTagClick;
        public event delHMILSISClick EventExportTagAllClick;
        public event delHMILSISClick EventExportTagPartClick;
        public event delHMILSISClick EventExportAlarmClick;

        protected TagMain _tagMain;
        protected DataTable _HMIdb = new DataTable();

        protected string _HMI = EMCommonHMIPrograms.XP_Builder.ToString();

        public HMI(TagMain tagMain)
        {
            InitializeComponent();

            _tagMain = tagMain;

            this.ImportTag.ItemClick += ImportTag_ItemClick;
            this.ExportTag.ItemClick += ExportTag_ItemClick;
            this.ExportAlarm.ItemClick += ExportAlarm_ItemClick;

            _tagMain.EventHMIInput += _tagMain_EventHMIInput;
        }

        void _tagMain_EventHMIInput(string Temp)
        {
            _HMIdb = _tagMain._HMIdb;

            GroupExtractHMI groupExport = new GroupExtractHMI(_HMIdb);

            foreach (string HMIList in groupExport.GroupList)
            {
                repositoryItemComboBox1.Items.Add(HMIList);
            }
        }

        void ExportAlarm_ItemClick(object sender, TileItemEventArgs e)
        {
            //EventExportAlarmClick(sender, _HMI);
        }

        void ExportTag_ItemClick(object sender, TileItemEventArgs e)
        {
            Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
            popupMenu1.ShowPopup(CurrentPoint);
        }

        void ImportTag_ItemClick(object sender, TileItemEventArgs e)
        {
            EventImportTagClick(sender, _HMI);
        }


    }
}
