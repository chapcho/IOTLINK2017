using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class FrmDetectingTimeProperty : DevExpress.XtraEditors.XtraForm
    {
        public FrmDetectingTimeProperty()
        {
            InitializeComponent();
        }

        private void grvNonDetect_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void FrmDetectingTimeProperty_Load(object sender, EventArgs e)
        {
            try
            {
                if(CMultiProject.NonDetectTimeS == null)
                    CMultiProject.NonDetectTimeS = new CNonDetectTimeS();

                grdNonDetect.DataSource = CMultiProject.NonDetectTimeS;
                grdNonDetect.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CNonDetectTime cNonDetect = new CNonDetectTime();

                CMultiProject.NonDetectTimeS.Add(cNonDetect);
                grdNonDetect.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvNonDetect.FocusedRowHandle;

                object obj = grvNonDetect.GetRow(iRowHandle);

                if (obj == null || obj.GetType() != typeof (CNonDetectTime))
                    return;

                CNonDetectTime cNonDetect = (CNonDetectTime) obj;

                CMultiProject.NonDetectTimeS.Remove(cNonDetect);
                grdNonDetect.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmDetectingTimeProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bOK = true;

                if (CMultiProject.NonDetectTimeS != null)
                {
                    foreach (CNonDetectTime cNonDetect in CMultiProject.NonDetectTimeS)
                    {
                        if (cNonDetect.StartTime == DateTime.MinValue || cNonDetect.EndTime == DateTime.MinValue)
                        {
                            bOK = false;
                            break;
                        }
                        else if (cNonDetect.StartTime >= cNonDetect.EndTime)
                        {
                            bOK = false;
                            break;
                        }
                    }
                }
                
                if (!bOK)
                {
                    if (
                        XtraMessageBox.Show("시간 설정이 잘못되었습니다.\r\n그래도 창을 닫으시겠습니까?", "Error", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Error) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }

    [Serializable]
    public class CNonDetectTimeS : List<CNonDetectTime>
    {


        public bool IsNonDetectTime(DateTime dtNow)
        {
            bool bOK = false;
            bool bGEQStart = false;
            bool bLEQEnd = false;

            foreach (CNonDetectTime cTime in this)
            {
                bGEQStart = false;
                bLEQEnd = false;

                if (cTime.StartTime.Hour == dtNow.Hour)
                {
                    if (cTime.StartTime.Minute <= dtNow.Minute)
                        bGEQStart = true;
                }
                else if (cTime.StartTime.Hour < dtNow.Hour)
                    bGEQStart = true;

                if (cTime.EndTime.Hour > dtNow.Hour)
                    bLEQEnd = true;
                else if (cTime.EndTime.Hour == dtNow.Hour)
                {
                    if (cTime.EndTime.Minute >= dtNow.Minute)
                        bLEQEnd = true;
                }

                if (bGEQStart && bLEQEnd)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }
    }

    [Serializable]
    public class CNonDetectTime
    {
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;

        public DateTime StartTime
        {
            get { return m_dtStart; }
            set { m_dtStart = value; }
        }

        public DateTime EndTime
        {
            get { return m_dtEnd;}
            set { m_dtEnd = value; }
            
        }
    }

}