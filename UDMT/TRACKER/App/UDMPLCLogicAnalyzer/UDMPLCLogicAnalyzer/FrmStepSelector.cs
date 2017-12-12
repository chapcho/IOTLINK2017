using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using UDM.Common;

namespace UDMPLCLogicAnalyzer
{
    public partial class FrmStepSelector : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bSelect = false;
        private List<CStep> m_lstStep = null;

        #endregion


        #region Intialize/Dispose

        public FrmStepSelector()
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
        public bool IsSelectStep
        {
            get { return m_bSelect; }
            set { m_bSelect = value; }
        }


        #endregion


        #region Public Methods

        public CStep GetSelectedStep()
        {
            CStep cStep = ucStepTable.GetSelectedStep();

            return cStep;
        }

        #endregion


        #region Private Methods

        private void ShowTable()
        {
            if (m_lstStep == null)
                return;

            ucStepTable.StepList = m_lstStep;
            ucStepTable.ShowTable();
        }

        #endregion


        #region Event Methods

        private void FrmStepSelector_Load(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void ucStepTable_UEventStepTableDoulbeClicked(object sender, CStep cStep)
        {
            m_bSelect = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bSelect = false;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_bSelect = true;
            this.Close();
        }

        #endregion


    }
}