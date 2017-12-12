using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace UDMOptimizerReader
{
    public partial class FrmAutoModeSetting : DevExpress.XtraEditors.XtraForm
    {
        private CProject m_cProject = null;
        private bool m_bChanged = false;
        public FrmAutoModeSetting()
        {
            InitializeComponent();
        }

        public CProject Project
        {
            set { m_cProject = value; }
        }

        public bool IsChanged
        {
            get { return m_bChanged; }
        }

        private void btnPathChange_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgFolder = new FolderBrowserDialog();
            DialogResult dlgResult = dlgFolder.ShowDialog();
            if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

            txtDBPath.Text = dlgFolder.SelectedPath;
        }

        private void FrmAutoModeSetting_Load(object sender, EventArgs e)
        {
            if (m_cProject == null) this.Close();

            txtDBPath.Text = m_cProject.DBBackupPath;
            if (txtDBPath.Text == "")
                txtDBPath.Text = Application.StartupPath;

            if (m_cProject.AutoStartTime == DateTime.MinValue)
            {
                m_cProject.AutoStartTime = DateTime.Now;
                m_cProject.AutoStopTime = DateTime.Now;
                m_cProject.AutoStopTime.AddHours(8);
            }
            chkAutoMode.Checked = m_cProject.IsAutoMode;
            tStart.EditValue = m_cProject.AutoStartTime;
            tStop.EditValue = m_cProject.AutoStopTime;
        }

        private void FrmAutoModeSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtDBPath.Text != m_cProject.DBBackupPath)
                m_bChanged = true;
            if ((DateTime)tStart.EditValue != m_cProject.AutoStartTime)
                m_bChanged = true;
            if ((DateTime)tStop.EditValue != m_cProject.AutoStopTime)
                m_bChanged = true;
            if(chkAutoMode.Checked != m_cProject.IsAutoMode)
                m_bChanged = true;

            if (m_bChanged)
            {
                m_cProject.AutoStartTime = (DateTime)tStart.EditValue;
                m_cProject.AutoStopTime = (DateTime)tStop.EditValue;
                m_cProject.DBBackupPath = txtDBPath.Text;
                m_cProject.IsAutoMode = chkAutoMode.Checked;
            }
        }
    }
}