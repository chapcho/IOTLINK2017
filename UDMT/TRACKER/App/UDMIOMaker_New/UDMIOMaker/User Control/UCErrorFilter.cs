using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public partial class UCErrorFilter : DevExpress.XtraEditors.XtraUserControl
    {
        private CErrorFilter m_cErrorFilter = null;
        private bool m_bEdit = false;

        public UCErrorFilter()
        {
            InitializeComponent();
        }

        public CErrorFilter ErrorFilter
        {
            get{return m_cErrorFilter;}
            set
            {
                m_cErrorFilter = value;
                SetSheetName();
            }
        }

        private void SetSplitPosition()
        {
            spt1.SplitPosition = this.Width/2;
            spt2.SplitPosition = spt1.SplitPosition;
        }

        private void SetSheetName()
        {
            if (m_cErrorFilter == null)
                return;

            lblText.Text = m_cErrorFilter.SheetName;
        }

        public void UpdateErrorFilter()
        {
            if (m_cErrorFilter == null)
                return;

            if (!m_bEdit)
                return;

            List<string> lstFilter = memoFilter.Lines.ToList();

            m_cErrorFilter.ErrorFilter.Clear();

            foreach (string sFilter in lstFilter)
            {
                if(sFilter == string.Empty)
                    continue;

                if (!m_cErrorFilter.ErrorFilter.Contains(sFilter))
                    m_cErrorFilter.ErrorFilter.Add(sFilter);
            }
            lstFilter.Clear();

            lstFilter = memoNotFilter.Lines.ToList();
            m_cErrorFilter.ErrorNotContainFilter.Clear();

            foreach (string sFilter in lstFilter)
            {
                if (sFilter == string.Empty)
                    continue;

                if (!m_cErrorFilter.ErrorNotContainFilter.Contains(sFilter))
                    m_cErrorFilter.ErrorNotContainFilter.Add(sFilter);
            }
        }

        private void txtSheetName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSheetName.EditValue == null)
                return;

            string sName = (string) txtSheetName.EditValue;

            if (sName == string.Empty)
                return;

            if(Regex.IsMatch(sName, "[\\\\/:*?\"<>|]"))
            {
                XtraMessageBox.Show("Sheet Name에 [\\, /, :, *, ?, \", <, >, |]가 포함될 수 없습니다.\r\n다시 이름을 설정하세요.",
                    "Sheet Name", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtSheetName.EditValue = string.Empty;
                return;
            }

            m_cErrorFilter.SheetName = sName;
        }

        private void UCErrorFilter_Load(object sender, EventArgs e)
        {
            if (m_cErrorFilter == null)
                return;

            txtSheetName.EditValue = m_cErrorFilter.SheetName;
            memoFilter.EditValue = string.Empty;

            foreach (string sFilter in m_cErrorFilter.ErrorFilter)
            {
                if (!memoFilter.Lines.Contains(sFilter))
                    memoFilter.EditValue += string.Format("{0}\r\n", sFilter);
            }

            memoNotFilter.EditValue = string.Empty;

            foreach (string sFilter in m_cErrorFilter.ErrorNotContainFilter)
            {
                if (!memoNotFilter.Lines.Contains(sFilter))
                    memoNotFilter.EditValue += string.Format("{0}\r\n", sFilter);
            }

            SetSplitPosition();
        }

        private void memoFilter_EditValueChanged(object sender, EventArgs e)
        {
            m_bEdit = true;
        }

        private void memoNotFilter_EditValueChanged(object sender, EventArgs e)
        {
            m_bEdit = true;
        }

        private void UCErrorFilter_Resize(object sender, EventArgs e)
        {
            SetSplitPosition();
        }

    }
}
