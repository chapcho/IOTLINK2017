using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.ExGanttChart
{
    public partial class FrmLinkProperty : Form
    {

        #region Member Variables

        private bool m_bOK = false;
        private CGanttLink m_cLink = null;
        private bool m_bEditable = true;
        

        #endregion


        #region Initialize/Dispose

        public FrmLinkProperty(bool bEditable)
        {
            InitializeComponent();
            
            m_bEditable = bEditable;
        }

        #endregion


        #region Public Properties

        public CGanttLink Link
        {
            set { m_cLink = value; }
        }
        
        public bool OK
        {
            get { return m_bOK; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private void InitCombo()
        {
            cmbFromPoint.Items.Clear();
            cmbToPoint.Items.Clear();
            cmbFromPoint.Items.Add(((EMGanttPointType)0).ToString());
            cmbFromPoint.Items.Add(((EMGanttPointType)1).ToString());
            cmbToPoint.Items.Add(((EMGanttPointType)0).ToString());
            cmbToPoint.Items.Add(((EMGanttPointType)1).ToString());
        }


        private void ShowProperty(CGanttLink cLink)
        {
            txtText.Text = cLink.Text;

            cmbFromPoint.SelectedIndex = (int)(cLink.PointTypeFrom);
            cmbToPoint.SelectedIndex = (int)(cLink.PointTypeTo);
            txtFrom.Text = cLink.BarFrom.Key;
            txtTo.Text = cLink.BarTo.Key;
            txtText.Focus();

        }

        private void ShowPropertyEtc()
        {

        }

        #endregion


        #region Event Methods

        private void FrmLinkProperty_Load(object sender, EventArgs e)
        {            
            InitCombo();

            ShowProperty(m_cLink);
          
            cmbFromPoint.Enabled = m_bEditable;
            cmbToPoint.Enabled = m_bEditable;
            txtText.Enabled = m_bEditable;
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, EventArgs.Empty);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_bEditable)
                {
                    int iPointFrom = cmbFromPoint.SelectedIndex;
                    int iPointTo = cmbToPoint.SelectedIndex;

                    EMGanttPointType emPointFrom = (EMGanttPointType)iPointFrom;
                    EMGanttPointType emPointTo = (EMGanttPointType)iPointTo;

                    m_bOK = true;

                    m_cLink.Text = txtText.Text;
                    m_cLink.PointTypeFrom = emPointFrom;
                    m_cLink.PointTypeTo = emPointTo;
                    
                }
                else
                    m_bOK = false;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }            

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bOK = false;

            this.Close();
        }

        private void FrmLinkProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(this, EventArgs.Empty);
            }
        }

        #endregion

        
    }
}
