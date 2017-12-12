using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using System.Drawing.Drawing2D;

namespace UDMLadderTracker
{
    public partial class UCProcessErrorTagGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected int m_iErrCount = 0;
        protected string m_sGroupName = "Group1";
        protected List<CSymbol> m_lstAbnormalSymbol = new List<CSymbol>();
        protected delegate void UpdateCallBack(List<CSymbol> lstErrorSymbol);
        protected delegate void UpdateCallBack2();

        #endregion


        #region Initialize

        public UCProcessErrorTagGrid()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public string GroupName
        {
            get { return m_sGroupName; }
            set 
            { 
                m_sGroupName = value;
                grpGroup.Text = m_sGroupName;
                this.Refresh();
            }
        }

        public List<CSymbol> AbnormalSymbolList
        {
            set
            {
                m_lstAbnormalSymbol = value;
                grdAbnormalSymbolS.DataSource = null;
                grdAbnormalSymbolS.DataSource = m_lstAbnormalSymbol;
                grdAbnormalSymbolS.Refresh();
            }
        }

        #endregion


        #region Public Method

        public void UpdateGrid(List<CSymbol>lstErrorSymbol)
        {
            if (this.InvokeRequired)
            {
                UpdateCallBack cbUpdateText = new UpdateCallBack(UpdateGrid);
                this.Invoke(cbUpdateText, new object[] { lstErrorSymbol });
            }
            else
            {
                grdAbnormalSymbolS.DataSource = null;
                grdAbnormalSymbolS.DataSource = m_lstAbnormalSymbol;
                grdAbnormalSymbolS.Refresh();

                if (lstErrorSymbol.Count > 0)
                {
                    SetActiveSymbolGridColor(lstErrorSymbol);
                    this.Refresh();
                }
            }
        }

        public void UpdateGrid2()
        {
            if (this.InvokeRequired)
            {
                UpdateCallBack2 cbUpdateText = new UpdateCallBack2(UpdateGrid2);
                this.Invoke(cbUpdateText, new object[] {  });
            }
            else
            {
                grdAbnormalSymbolS.DataSource = null;
                grdAbnormalSymbolS.DataSource = m_lstAbnormalSymbol;
                grdAbnormalSymbolS.Refresh();
            }
        }

        #endregion


        #region Private Method

        private void SetActiveSymbolGridColor(List<CSymbol> lstErrorSymbol)
        {
            pnlBackGround.BringToFront();
            pnlBackGround.Visible = true;

            string sMessage = lblMessage.Text + "\r\n";
            for (int i = 0; i < lstErrorSymbol.Count; i++)
            {
                if (i == lstErrorSymbol.Count - 1)
                    sMessage += string.Format("\" {0} \" : {1}", lstErrorSymbol[i].Description, lstErrorSymbol[i].Tag.Address);
                else
                    sMessage += string.Format("\" {0} \" : {1}\r\n", lstErrorSymbol[i].Description, lstErrorSymbol[i].Tag.Address);
                m_iErrCount++;
            }
            if (m_iErrCount > 3)
                lblMessage.Text = string.Format("Error Count : {0} ea", m_iErrCount);
            else
                lblMessage.Text = sMessage;
            
            tmrBackGround.Start();
        }

        #endregion

        private void grvAbnormalSymbolS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            pnlBackGround.Visible = false;
            tmrBackGround.Stop();
            lblMessage.Text = "";
            m_iErrCount = 0;
        }

        private void tmrBackGround_Tick(object sender, EventArgs e)
        {
            tmrBackGround.Enabled = false;

            Color cColor1 = pnlBackGround.Appearance.BackColor;
            Color cColor2 = pnlBackGround.Appearance.BackColor2;

            pnlBackGround.Appearance.BackColor = cColor2;
            pnlBackGround.Appearance.BackColor2 = cColor1;

            pnlBackGround.Refresh();

            tmrBackGround.Enabled = true;
        }

        private void grpGroup_Paint(object sender, PaintEventArgs e)
        {
            HatchBrush brush = new HatchBrush(HatchStyle.LargeGrid, Color.YellowGreen, Color.YellowGreen);
            Rectangle rect = grpGroup.ClientRectangle;
            rect.Height = 22;
            e.Graphics.FillRectangle(brush, rect);
            e.Graphics.DrawString(grpGroup.Text, grpGroup.AppearanceCaption.Font, Brushes.Black, rect);
        }
    }
}
