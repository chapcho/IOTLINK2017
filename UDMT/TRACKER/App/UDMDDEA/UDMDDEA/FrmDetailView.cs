using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.DDEA;

namespace UDMDDEA
{
    public partial class FrmDetailView : DevExpress.XtraEditors.XtraForm
    {

        private CDDEARead m_cRead = null;
        protected DataTable m_tblComInfo = new DataTable();

        public FrmDetailView(CDDEARead cRead)
        {
            InitializeComponent();
            m_cRead = cRead;
        }

        private void FrmDetailView_Load(object sender, EventArgs e)
        {
            tmrView.Start();    
        }

        private void tmrView_Tick(object sender, EventArgs e)
        {
            if (m_cRead == null)
                return;
            tmrView.Enabled = false;

            Dictionary<string, string> dicData = m_cRead.ShowDetailView();

            CreateTable(dicData);

            grdComInfo.DataSource = m_tblComInfo;
            grdComInfo.RefreshDataSource();

            tmrView.Enabled = true;
        }

        protected void CreateTable(Dictionary<string, string> dicData)
        {
            m_tblComInfo.Clear();
            m_tblComInfo.Columns.Clear();
            m_tblComInfo.Columns.Add("항목");
            m_tblComInfo.Columns.Add("내용");

            foreach (var who in dicData)
            {
                m_tblComInfo.Rows.Add(new object[] { who.Key, who.Value });
            }
        }

        private void FrmDetailView_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrView.Stop();
        }
    }
}