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
using System.ComponentModel.Design;

namespace SmartEnergyVision.UserControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UCTileItem : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private List<string> m_lstBaseControl = new List<string>();

        #endregion


        #region Intialize/Dispose

        public UCTileItem()
        {
            m_lstBaseControl.Add("pnlHeader");
            m_lstBaseControl.Add("pnlTail");

            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public Bitmap Image
        {
            get { return ucMonoImage.Image; }
            set { ucMonoImage.Image = value; }
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string Status
        {
            get { return lblTailLeft.Text; }
            set { lblTailLeft.Text = value; }
        }

        public string FootNote
        {
            get { return lblTailRight.Text; }
            set { lblTailRight.Text = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Event Methods

        private void UCTileItem_Load(object sender, EventArgs e)
        {

        }


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (m_lstBaseControl.Contains(e.Control.Name))
                return;

            e.Control.BringToFront();

        }

        #endregion
    }
}
