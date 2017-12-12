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

namespace UDMTrackerSimple
{
    public partial class FrmTagValidateErrorView : DevExpress.XtraEditors.XtraForm
    {
        private List<string> m_lstErrorTagKey = new List<string>(); 

        public FrmTagValidateErrorView()
        {
            InitializeComponent();
        }

        public List<string> lstErrorTagKey
        {
            get { return m_lstErrorTagKey; }
            set { m_lstErrorTagKey = value; }
        }

        private CTagS GetTagS()
        {
            CTagS cTagS = new CTagS();
            CTag cTag = null;

            foreach (string sKey in m_lstErrorTagKey)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                    continue;

                cTag = CMultiProject.TotalTagS[sKey];
                cTagS.Add(cTag.Key, cTag);
            }

            return cTagS;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTagValidateErrorView_Load(object sender, EventArgs e)
        {
            if (m_lstErrorTagKey.Count == 0)
                return;

            CTagS cTagS = GetTagS();

            grdDesignPLC.DataSource = cTagS.Values.ToList();
            grdDesignPLC.RefreshDataSource();
        }
    }
}