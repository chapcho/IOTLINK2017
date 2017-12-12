using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    [Serializable]
    public partial class UCUserDevice : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected CUserDevice m_cUserDevice = new CUserDevice();

        #endregion


        #region Initialize

        public UCUserDevice()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public CUserDevice UserDevice
        {
            get { return m_cUserDevice; }
            set { m_cUserDevice = value; }
        }

        #endregion

        public void SetInitial()
        {
            if (m_cUserDevice == null) return;

            lblDescription.Text = m_cUserDevice.Tag.Description;
            lblAddress.Text = m_cUserDevice.Tag.Address;
            lblLastTime.Text = string.Format("{0}\r\n{1}", m_cUserDevice.LastTime.ToString("yyyy / MM / dd"), m_cUserDevice.LastTime.ToString("hh : mm : ss . fff"));
            lblCurrentValue.Text = string.Format("{0}", m_cUserDevice.Value);

            if (m_cUserDevice.Tag.DataType == UDM.Common.EMDataType.Bool)
            {
                grpCurrentValue.Visible = false;
                this.Size = new Size(this.Size.Width, this.Size.Height - (grpCurrentValue.Size.Height));

                ChangeBitAddressColor(m_cUserDevice.Value);
            }
            else
            {
                ChangeBitAddressColor(0);
            }
        }

        public void RefreshData()
        {
            lblDescription.Refresh();
            lblAddress.Refresh();
            lblLastTime.Refresh();
            lblCurrentValue.Refresh();

        }

        private void ChangeBitAddressColor(int iValue)
        {
            if (iValue > 0)
            {
                lblAddress.Appearance.BackColor = Color.YellowGreen;
                lblAddress.Appearance.BackColor2 = Color.GreenYellow;
            }
            else
            {
                lblAddress.Appearance.BackColor = Color.FromArgb(201, 201, 201);
                lblAddress.Appearance.BackColor2 = Color.FromArgb(163, 163, 163);
            }
            lblAddress.Refresh();
        }

        private void UCUserDevice_Load(object sender, EventArgs e)
        {
            if (m_cUserDevice == null)
                return;
        }

        private void chkHexa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHexa.Checked)
                lblCurrentValue.Text = string.Format("0x{0:x8}", m_cUserDevice.Value);
            else
                lblCurrentValue.Text = string.Format("{0}", m_cUserDevice.Value);
        }

    }
}
