using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;

namespace UDMLadderTracker
{
    public partial class UCErrorListPanel : DevExpress.XtraEditors.XtraUserControl
    {
        private string m_sProcessKey = string.Empty;
        private CErrorInfoS m_cErrorInfoS = new CErrorInfoS();

        public event UEventHandlerErrorLogGridDoubleClick UEventErrorPanelDoubleClicked = null;

        private delegate void CUpdateErrorListPanelCallBack(CErrorInfo cInfo);

        public UCErrorListPanel()
        {
            InitializeComponent();
        }

        public string ProcessKey
        {
            get { return m_sProcessKey; }
            set { m_sProcessKey = value; }
        }

        public void SetErrorListPanel(string sProcessKey)
        {
            m_sProcessKey = sProcessKey;
            lblTitle.Text = m_sProcessKey;
        }

        public void UpdateErrorListPanel(CErrorInfo cInfo)
        {
            if (this.InvokeRequired)
            {
                CUpdateErrorListPanelCallBack cUpdate = new CUpdateErrorListPanelCallBack(UpdateErrorListPanel);
                this.Invoke(cUpdate, new object[] {cInfo});
            }
            else
            {
                m_cErrorInfoS.Add(cInfo);

                grdError.DataSource = null;
                grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();
                grdError.RefreshDataSource();

                lblTitle.ForeColor = Color.White;
                lblTitle.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                lblTitle.Appearance.BackColor2 = Color.Red;

                tmrTimer.Start();
            }
        }

        public void Clear()
        {
            grdError.DataSource = null;

            m_cErrorInfoS.Clear();

            lblTitle.ForeColor = Color.DimGray;
            lblTitle.Appearance.BackColor = Color.Transparent;
            lblTitle.Appearance.BackColor2 = Color.Transparent;

            tmrTimer.Stop();
        }

        private void grvError_DoubleClick(object sender, EventArgs e)
        {
            int iHandle = grvError.FocusedRowHandle;
            if (iHandle < 0)
                return;

            object oData = grvError.GetRow(iHandle);
            if ((oData.GetType() != typeof(CErrorInfo)))
                return;

            if (UEventErrorPanelDoubleClicked != null)
                UEventErrorPanelDoubleClicked(sender, (CErrorInfo) oData);
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            Color cColor1 = lblTitle.Appearance.BackColor;
            Color cColor2 = lblTitle.Appearance.BackColor2;

            lblTitle.Appearance.BackColor = cColor2;
            lblTitle.Appearance.BackColor2 = cColor1;

            lblTitle.Refresh();
        }

    }
}
