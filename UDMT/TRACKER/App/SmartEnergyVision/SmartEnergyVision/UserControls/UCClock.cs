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

namespace SmartEnergyVision.UserControls
{
    public partial class UCClock : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public UCClock()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public new Font Font
        {
            get { return lblTime.Font; }
            set { base.Font = value;  lblTime.Font = value; }
        }

        public new Color ForeColor
        {
            get { return lblTime.ForeColor; }
            set { base.ForeColor = value; lblTime.ForeColor = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion


        #region Event Methods

        private void UCClock_Load(object sender, EventArgs e)
        {
            tmrTimer.Start();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH : mm : ss");
            lblTime.Refresh();
        }

        #endregion
    }
}
