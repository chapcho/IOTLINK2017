using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class UCErrorListPanel : DevExpress.XtraEditors.XtraUserControl
    {
        private string m_sProcessKey = string.Empty;
        private CErrorInfoS m_cErrorInfoS = new CErrorInfoS();

        public event UEventHandlerErrorLogGridDoubleClick UEventErrorPanelDoubleClicked = null;
        public event UEventHandlerMonitorPanelDoubleClicked UEventErrorDoubleClicked = null;

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

        public int ErrorCount
        {
            get { return m_cErrorInfoS.Count; }
        }

        public void SetErrorListPanel(string sProcessKey)
        {
            try
            {
                m_sProcessKey = sProcessKey;
                lblTitle.Text = m_sProcessKey;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetErrorListPanel(string sPlcName, string sProcess)
        {
            try
            {
                lblTitle.Text = string.Format("라인 : {0}, 공정 : {1}", sPlcName, sProcess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void UpdateErrorListPanel(CErrorInfo cInfo)
        {
            try
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
                    //grdError.DataSource = m_cErrorInfoS.Where(x => x.IsVisible == true).ToList();
                    grdError.DataSource =
                        m_cErrorInfoS.Where(x => x.IsVisible == true || x.ErrorMessage.Contains("Cycle Over")).ToList();
                        // 무언정지 포함
                    grdError.RefreshDataSource();

                    AdjustGridMinHeight();

                    lblTitle.ForeColor = Color.White;
                    lblTitle.Appearance.BackColor = Color.FromArgb(255, 128, 0);
                    lblTitle.Appearance.BackColor2 = Color.Red;

                    this.Size = new Size(grdError.Width, (grvError.RowCount*grvError.RowHeight) + lblTitle.Height);
                    tmrTimer.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void Clear()
        {
            try
            {
                grdError.DataSource = null;

                m_cErrorInfoS.Clear();

                lblTitle.ForeColor = Color.DimGray;
                lblTitle.Appearance.BackColor = Color.Transparent;
                lblTitle.Appearance.BackColor2 = Color.Transparent;

                tmrTimer.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void AdjustGridMinHeight()
        {
            try
            {
                int iLabelHeight = lblTitle.Height;
                int iRowHandle = 0;
                int iHeight = 0;
                for (int i = 0; i < grvError.RowCount; i++)
                {
                    iRowHandle = grvError.GetVisibleRowHandle(i);
                    iHeight += GetRowHeight(iRowHandle);
                }

                grdError.Height = iHeight;
                grdError.Refresh();

                this.Height = iLabelHeight + iHeight;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private int GetRowHeight(int iRowHandle)
        {
            int iValue = -1;
            try
            {
                GridViewInfo viewInfo = grvError.GetViewInfo() as GridViewInfo;
                iValue = viewInfo.CalcRowHeight(CreateGraphics(), iRowHandle, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            return iValue;
        }

        private void grvError_DoubleClick(object sender, EventArgs e)
        {
            //int iHandle = grvError.FocusedRowHandle;
            //if (iHandle < 0)
            //    return;

            //object oData = grvError.GetRow(iHandle);
            //if ((oData.GetType() != typeof(CErrorInfo)))
            //    return;

            //if (UEventErrorPanelDoubleClicked != null)
            //    UEventErrorPanelDoubleClicked(sender, (CErrorInfo) oData);

            if (UEventErrorDoubleClicked != null)
                UEventErrorDoubleClicked();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Color cColor1 = lblTitle.Appearance.BackColor;
                Color cColor2 = lblTitle.Appearance.BackColor2;

                lblTitle.Appearance.BackColor = cColor2;
                lblTitle.Appearance.BackColor2 = cColor1;

                lblTitle.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCErrorListPanel_Load(object sender, EventArgs e)
        {

        }

        private void UCErrorListPanel_Resize(object sender, EventArgs e)
        {

        }

    }
}
