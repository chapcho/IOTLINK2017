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
using NewIOMaker.Event.Event_IOMaker;
using NewIOMaker.Enumeration.EnumTagGenerator;

namespace NewIOMaker.Form.Form_IOMaker.Menu
{
    public partial class IOHome : DevExpress.XtraEditors.XtraUserControl
    {
        public event delIOMakerMenuSelectEvent EventImport;
        public event delIOMakerMenuEvent EventExport;

        #region Intialize/Dispose

        public IOHome()
        {
            InitializeComponent();
            this.Load += IOHome_Load;
        }

        void IOHome_Load(object sender, EventArgs e)
        {
            tileItemImport.ItemClick += tileItemImport_ItemClick;
            tileItemExport.ItemClick += tileItemExport_ItemClick;
        }

        #endregion

        #region Public Properites

        #endregion

        #region Click Event

        void tileItemImport_ItemClick(object sender, TileItemEventArgs e)
        {
            Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
            popupMenu1.ShowPopup(CurrentPoint);

        }

        void tileItemExport_ItemClick(object sender, TileItemEventArgs e)
        {
            EventExport(sender);
        }

        #endregion

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EventImport(sender, EMTagGeneratorPLCHeader.Developer.ToString());
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EventImport(sender, EMTagGeneratorPLCHeader.Works2.ToString());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EventImport(sender, EMTagGeneratorPLCHeader.Works3.ToString());
        }



    }
}
