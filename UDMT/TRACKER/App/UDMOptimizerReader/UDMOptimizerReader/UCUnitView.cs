using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMSPDManager
{
    public partial class UCUnitView : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Veriables

        private bool m_bActiveStatus = false;
        private bool m_bOff = true;
        private int m_iLogCount = 0;

        #endregion


        #region Initialize

        public UCUnitView()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public int ChangedLogCount
        {
            get { return m_iLogCount; }
            set 
            { 
                m_iLogCount = value; 
                lblLogCount.Text = string.Format("{0}", m_iLogCount);
            }
        }

        #endregion


        #region Form Event

        private void UCUnitView_Load(object sender, EventArgs e)
        {

        }

        #endregion


        #region Private Method

        private void SetLamp()
        {
            if (m_bOff)
            {
                m_bActiveStatus = false;
                btnData.Appearance.BackColor = Color.Gray;
            }
        }

        #endregion
    }
}
