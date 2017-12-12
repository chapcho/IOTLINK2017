using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;
using UDM.Project;

namespace UDMTracker
{
    public partial class FrmTrendProperty : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        protected CSymbol m_cSymbol = null;

        #endregion


        #region Initialize/Dispose

        public FrmTrendProperty()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return ucTrendProperty.Editable; }
            set { ucTrendProperty.Editable = value; }
        }

        public CSymbol Symbol
        {
            get { return m_cSymbol; }
            set { m_cSymbol = value; ucTrendProperty.Symbol = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods


        #endregion


        #region Event Methods

        private void FrmTrendProperty_Load(object sender, EventArgs e)
        {

        }

        #endregion

    }
}