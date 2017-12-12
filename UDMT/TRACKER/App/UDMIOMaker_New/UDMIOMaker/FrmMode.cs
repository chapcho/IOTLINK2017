using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public partial class FrmMode : DevExpress.XtraEditors.XtraForm
    {
        private bool m_bMappingMode = false;
        private bool m_bDesignMode = false;
        private bool m_bVerificationMode = false;

        public FrmMode()
        {
            InitializeComponent();
        }

        public bool IsMappingMode
        {
            get { return m_bMappingMode; }
            set { m_bMappingMode = value; }
        }

        public bool IsDesignMode
        {
            get { return m_bDesignMode;}
            set { m_bDesignMode = value; }
        }

        public bool IsVerificationMode
        {
            get { return m_bVerificationMode; }
            set { m_bVerificationMode = value; }
        }

        public bool IsGroupPanelVisible
        {
            get { return grpModeSelect.Visible; }
            set
            {
                grpModeSelect.Visible = value;
                SetGroupPanelVisible();
            }
        }

        private void SetGroupPanelVisible()
        {
            if (!grpModeSelect.Visible)
                this.Text = "About IO Maker";
        }

        private void btnSymbolDesign_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_bDesignMode = true;

            this.Close();
        }

        private void btnMappingMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_bMappingMode = true;

            this.Close();
        }

        private void btnVerifMode_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            m_bVerificationMode = true;

            this.Close();
        }

        private void btnSlideBefore_Click(object sender, EventArgs e)
        {
            imgSlide.SlidePrev();
        }

        private void btnSlideNext_Click(object sender, EventArgs e)
        {
            imgSlide.SlideNext();
        }

        private void FrmMode_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
