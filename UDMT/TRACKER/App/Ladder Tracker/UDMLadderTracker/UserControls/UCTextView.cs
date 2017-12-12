using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMLadderTracker
{
    public partial class UCTextView : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        #endregion


        #region Initialize

        public UCTextView()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public string TextData
        {
            get { return lblTextBox.Text; }
            set { lblTextBox.Text = value; }
        }

        public Color TextBackColor1
        {
            get { return lblTextBox.Appearance.BackColor; }
            set { lblTextBox.Appearance.BackColor = value; }
        }

        public Color TextBackColor2
        {
            get { return lblTextBox.Appearance.BackColor2; }
            set { lblTextBox.Appearance.BackColor2 = value; }
        }

        public Font TextFont
        {
            get { return lblTextBox.Appearance.Font; }
            set { lblTextBox.Appearance.Font = value; }
        }

        public Color TextColor
        {
            get { return lblTextBox.ForeColor; }
            set { lblTextBox.ForeColor = value; }
        }

        #endregion


        #region Form Event

        private void UCTrackerMode_Load(object sender, EventArgs e)
        {

        }

        #endregion


        #region Public Method

        #endregion
    }
}
