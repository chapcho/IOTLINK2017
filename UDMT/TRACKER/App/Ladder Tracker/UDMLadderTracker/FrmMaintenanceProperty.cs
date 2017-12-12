using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class FrmMaintenanceProperty : DevExpress.XtraEditors.XtraForm
    {
        private CErrorInfo m_cErrorInfo = null;

        public FrmMaintenanceProperty(CErrorInfo cErrorInfo)
        {
            InitializeComponent();

            m_cErrorInfo = cErrorInfo;
        }

        public CErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; }
        }

        private CErrorInfo CreateViewMaintProperty(CErrorInfo cErrorInfo)
        {
            CErrorInfo cErrorInfoView = new CErrorInfo();

            if (cErrorInfo == null)
                return cErrorInfoView;

            cErrorInfoView.Name = cErrorInfo.Name;
            cErrorInfoView.ErrorCategory = cErrorInfo.ErrorCategory;
            cErrorInfoView.ErrorSolution = cErrorInfo.ErrorSolution;

            return cErrorInfoView;
        }

        private void ApplyMaintenanceProperty(CErrorInfo cErrorInfoView)
        {
            if (m_cErrorInfo == null || cErrorInfoView == null)
                return;

            m_cErrorInfo.Name = cErrorInfoView.Name;
            m_cErrorInfo.ErrorCategory = cErrorInfoView.ErrorCategory;
            m_cErrorInfo.ErrorSolution = cErrorInfoView.ErrorSolution;
            m_cErrorInfo.MaintTime = DateTime.Now;
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {
            CErrorInfo cErrorInfoView = (CErrorInfo) exMaintProperty.SelectedObject;
            ApplyMaintenanceProperty(cErrorInfoView);

            this.Close();
        }

        private void FrmMaintenanceProperty_Load(object sender, EventArgs e)
        {
            CErrorInfo cErrorInfoView = CreateViewMaintProperty(m_cErrorInfo);

            exMaintProperty.SelectedObject = cErrorInfoView;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}