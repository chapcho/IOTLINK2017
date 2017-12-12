using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Common;

namespace UDMLadderTracker
{
    public partial class UCStepTable : UserControl
    {

        #region Member Variables

        private List<CStep> m_lstStep = null;
        public event UEventHandlerStepTableDoubleClicked UEventStepTableDoulbeClicked;

        #endregion


        #region Intialize/Dispose

        public UCStepTable()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public List<CStep> StepList
        {
            get { return m_lstStep; }
            set { m_lstStep = value; }
        }
        
        #endregion


        #region Public Methods

        public void ShowTable()
        {
            Clear();

            grdStep.DataSource = m_lstStep;
            grdStep.RefreshDataSource();
        }

        public void Clear()
        {
            grdStep.DataSource = null;
            grdStep.RefreshDataSource();
        }

        public CStep GetSelectedStep()
        {
            int iRowIndex = grvStep.FocusedRowHandle;
            if (iRowIndex < 0)
                return null;
            
            CStep cStep = (CStep)grvStep.GetRow(iRowIndex);
            
            return cStep;
        }

        #endregion


        #region Private Methods

        private void GenerateDoubleClickEvent(CStep cStep)
        {
            if (UEventStepTableDoulbeClicked != null)
                UEventStepTableDoulbeClicked(this, cStep);
        }

        #endregion


        #region Event Methods

        private void UCStepTable_Load(object sender, EventArgs e)
        {

        }

        private void grvStep_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle + 1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void grvStep_DoubleClick(object sender, EventArgs e)
        {
            CStep cStep = GetSelectedStep();
            if (cStep != null)
                GenerateDoubleClickEvent(cStep);
        }

        #endregion
    }
}
