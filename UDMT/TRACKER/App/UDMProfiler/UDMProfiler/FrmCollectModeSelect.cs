using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMProfiler
{
    public partial class FrmCollectModeSelect : DevExpress.XtraEditors.XtraForm
    {
        #region Member Verialbes
        private EMCollectModeType m_emCollectMode = EMCollectModeType.Normal;
        private bool m_bCancel = false;
        #endregion

        #region Initialize
        public FrmCollectModeSelect()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public EMCollectModeType CollectMode
        {
            get { return m_emCollectMode; }
        }

        public bool IsCancel
        {
            get { return m_bCancel; }
        }

        #endregion

        #region Form Event

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (rdoNormal.Checked)
                m_emCollectMode = EMCollectModeType.Normal;
            else
                m_emCollectMode = EMCollectModeType.Output;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bCancel = true;
            this.Close();
        }
        #endregion

    }
}