using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;

namespace UDM.Project
{
    public partial class UCTrendProperty : DevExpress.XtraEditors.XtraUserControl
    {

        #region Member Variables

        protected bool m_bEditable = false;
        protected CSymbol m_cSymbol = null;

        #endregion


        #region Initialize/Dispose

        public UCTrendProperty()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { SetEditable(value); }
        }

        public CSymbol Symbol
        {
            get { return m_cSymbol; }
            set { SetSymbol(value); }
        }

        #endregion


        #region Public Methods

        public void Clear()
        {
            m_cSymbol = null;
            exProperty.SelectedObject = null;
            exProperty.Refresh();
        }

        #endregion


        #region Private Methods

        protected void SetEditable(bool bEditable)
        {
            m_bEditable = bEditable;
            exProperty.Enabled = bEditable;
        }

        protected void SetSymbol(CSymbol cSymbol)
        {
            Clear();

            m_cSymbol = cSymbol;
            exProperty.SelectedObject = m_cSymbol;            
            exProperty.Refresh();
        }

        #endregion


        #region Event Methods

        private void UCTrendSymbolProperty_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
