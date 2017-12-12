using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerSPD.DDEA;

namespace UDMSPDSingle
{
    public partial class FrmDetailView : DevExpress.XtraEditors.XtraForm
    {
        private CDDEARead m_cRead = null;
        private List<CDetailViewData> m_lstDetailViewData = new List<CDetailViewData>();
        protected DataTable m_tblComInfo = new DataTable();

        public FrmDetailView(CDDEARead cRead)
        {
            InitializeComponent();
            m_cRead = cRead;
        }

        public List<CDetailViewData> DetailViewData
        {
            get { return m_lstDetailViewData; }
            set { m_lstDetailViewData = value; }
        }

        private void FrmDetailView_Load(object sender, EventArgs e)
        {
            tmrView.Start();    
        }

        private void tmrView_Tick(object sender, EventArgs e)
        {
            if (m_cRead == null)
                return;
            if (m_cRead.IsRunning == false) return;
            tmrView.Enabled = false;

            Dictionary<string, string> dicData = m_cRead.ShowDetailView();

            List<CDetailViewData> lstData = new List<CDetailViewData>();

            for (int i = 0; i < m_lstDetailViewData.Count; i++)
            {
                lstData.Add(m_lstDetailViewData[i]);
            }

            foreach (var who in dicData)
            {
                CDetailViewData cData = new CDetailViewData();
                cData.Item = who.Key;
                cData.Value = who.Value;

                lstData.Add(cData);
            }
            //CreateTable(dicData);

            grdComInfo.DataSource = lstData;
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
    public class CDetailViewData : ICloneable
    {
        public string Item { get; set; }
        public string Value { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}