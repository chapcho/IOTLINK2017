using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Flow;

namespace UDM.Project
{
    public partial class UCFlowRuleProperty : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = true;
        protected CFlowRule m_cRule = null;

        #endregion


        #region Initialize/Dispose

        public UCFlowRuleProperty()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; }
        }

        public CFlowRule Rule
        {
            get { return m_cRule; }
            set { m_cRule = value; }
        }

        #endregion


        #region Public Methods

        public void ShowProperty()
        {
            exProperty.SelectedObject = m_cRule;
        }

        #endregion


        #region Private Methods

        protected void SetEditable(bool bEditable)
        {
            m_bEditable = bEditable;
            exProperty.Enabled = bEditable;
        }

        #endregion


        #region Event Methods

        private void UCFlowRule_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
