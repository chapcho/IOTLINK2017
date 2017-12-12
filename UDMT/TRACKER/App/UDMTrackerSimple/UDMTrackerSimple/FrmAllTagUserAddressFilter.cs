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
    public partial class FrmAllTagUserAddressFilter : DevExpress.XtraEditors.XtraForm
    {
        private List<CTag> m_lstTag = new List<CTag>();

        public List<CTag> FilterTagList
        {
            get { return m_lstTag; }
        }

        public FrmAllTagUserAddressFilter()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sBase = txtAddressList.Text.Replace("\r", "");
            string[] saAddress = sBase.Split('\n');
            m_lstTag.Clear();
            if (saAddress != null && saAddress.Length > 0)
            {
                CTagS cTagS = CMultiProject.TotalTagS;
                for (int i = 0; i < saAddress.Length; i++)
                {
                    List<CTag> lstTag = cTagS.Values.Where(b => b.Address == saAddress[i]).ToList();
                    if (lstTag != null && lstTag.Count > 0)
                        m_lstTag.AddRange(lstTag);
                }
            }

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            m_lstTag.Clear();
            this.Close();
        }
    }
}