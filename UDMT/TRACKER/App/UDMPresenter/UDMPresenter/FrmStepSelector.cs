using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;

namespace UDMPresenter
{
    public partial class FrmStepSelector : Form
    {

        #region Member Variables

        private List<CStepTagList> m_lstStep = null;
        private CStepTagList m_cStep = null;

        #endregion


        #region Initialize/Dispose

        public FrmStepSelector()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public List<CStepTagList> StepList
        {
            get { return m_lstStep; }
            set { m_lstStep = value; }
        }

        public CStepTagList SelectedStep
        {
            get { return m_cStep; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void ShowStepTable(List<CStepTagList> lstStep)
        {
            grdStepTable.DataSource = lstStep;
            grdStepTable.RefreshDataSource();
        }

        #endregion


        #region Event Methods

        private void FrmStepSelector_Load(object sender, EventArgs e)
        {
            ShowStepTable(m_lstStep);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_lstStep != null)
            {
                int iRowIndex = grvStepTable.FocusedRowHandle;
                if (iRowIndex >= 0)
                    m_cStep = (CStepTagList)grvStepTable.GetRow(iRowIndex);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvStepTable_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, EventArgs.Empty);
        }

        #endregion

        private void grvStepTable_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

    }
}
