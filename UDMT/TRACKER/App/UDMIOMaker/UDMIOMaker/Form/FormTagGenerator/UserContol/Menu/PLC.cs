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
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using NewIOMaker.Form.Form_Common;
using NewIOMaker.Event.Event_TagGenerator;
using NewIOMaker.Enumeration.EnumTagGenerator;



namespace NewIOMaker.Form.Form_TagGenerator.Menu
{

    public partial class PLC : DevExpress.XtraEditors.XtraUserControl
    {


        public event delPLCSelectedEvent EventSDFClick;
        public event delPLCSelectedEvent EventAWLClick;
        public event delPLCSelectedEvent EventCSVClick;
        public event delPLCSelectedEvent EventL5KClick;

        protected int _CPU = 0;

        public PLC()
        {
            InitializeComponent();
            this.tileItemSDF.ItemClick += tileItemSDF_ItemClick;
            this.tileItemAWL.ItemClick += tileItemAWL_ItemClick;

            this.tileItemCSV.ItemClick += tileItemCSV_ItemClick;
            this.tileItemL5K.ItemClick += tileItemL5K_ItemClick;
 
        }

        void tileItemL5K_ItemClick(object sender, TileItemEventArgs e)
        {
            EventL5KClick(sender, EMTagGeneratorPLCHeader.RSLogix_L5K.ToString(), _CPU);
        }

        void tileItemCSV_ItemClick(object sender, TileItemEventArgs e)
        {
            EventCSVClick(sender, EMTagGeneratorPLCHeader.RSLogix_CSV.ToString(), _CPU);
        }

        void tileItemAWL_ItemClick(object sender, TileItemEventArgs e)
        {
            EventAWLClick(sender, EMTagGeneratorPLCHeader.Step7_AWL.ToString(), _CPU);
        }

        void tileItemSDF_ItemClick(object sender, TileItemEventArgs e)
        {
            EventSDFClick(sender, EMTagGeneratorPLCHeader.Step7_SDF.ToString(), _CPU);
        }




    }
}
