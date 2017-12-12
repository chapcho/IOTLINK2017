using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public delegate void UEventHandlerElementApplyClick();

    public partial class FrmReportElementSetting : DevExpress.XtraEditors.XtraForm
    {
        public event UEventHandlerElementApplyClick UEvenetApplyClicked;

        public FrmReportElementSetting()
        {
            InitializeComponent();
        }

        private void SetReportElement()
        {
            grdReportUnit.DataSource = CProjectManager.ReportElementS;
            grdReportUnit.RefreshDataSource();
        }

        private bool CheckElementRedundancy()
        {
            bool bOK = false;
            List<string> lstElement = new List<string>();

            foreach (var who in CProjectManager.ReportElementS)
            {
                if (who.Element == string.Empty)
                {
                    bOK = true;
                    break;
                }

                if (!lstElement.Contains(who.Element))
                    lstElement.Add(who.Element);
                else
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private void btnUnitAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CReportElement cElement = new CReportElement();
                CProjectManager.ReportElementS.Add(cElement);

                grdReportUnit.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Report Element Add Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvReportUnit.SelectedRowsCount > 1)
                {
                    XtraMessageBox.Show("하나의 Row만 선택하세요.", "Select Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int iRowHandle = grvReportUnit.FocusedRowHandle;

                if (iRowHandle < -1)
                    return;

                object obj = grvReportUnit.GetRow(iRowHandle);

                if (obj == null)
                    return;

                if (obj.GetType() != typeof(CReportElement))
                    return;

                CReportElement cUnit = (CReportElement)obj;
                CProjectManager.ReportElementS.Remove(cUnit);
                grdReportUnit.RefreshDataSource();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Report Element Delete Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckElementRedundancy())
            {
                XtraMessageBox.Show("리포트 항목이 비어있거나 동일한 것이 존재합니다.\r\n리포트 항목을 다시 설정해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.Close();

            if (UEvenetApplyClicked != null)
                UEvenetApplyClicked();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (CheckElementRedundancy())
            {
                XtraMessageBox.Show("리포트 항목이 비어있거나 동일한 것이 존재합니다.\r\n리포트 항목을 다시 설정해주세요.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void FrmReportElementSetting_Load(object sender, EventArgs e)
        {
            SetReportElement();
        }
    }

    [Serializable]
    public class CReportElement
    {
        private string m_sElement = string.Empty;

        public string Element
        {
            get { return m_sElement; }
            set { m_sElement = value; }
        }
    }
}