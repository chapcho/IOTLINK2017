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
using UDM.Log;
using UDM.UI.TimeChart;

namespace UDMEnergyViewer
{
    public partial class FrmRegressionUnitView : DevExpress.XtraEditors.XtraForm
    {
        public FrmRegressionUnitView()
        {
            InitializeComponent();
        }

        private void FrmRegressionUnitView_Load(object sender, EventArgs e)
        {

        }

        private void btnZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucTimeChart.TimeLine.ZoomIn();
        }

        private void btnZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucTimeChart.TimeLine.ZoomOut();
        }

        private void btnItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucTimeChart.GanttTree.ItemUp(lstItem);
            lstItem.Clear();
        }

        private void btnItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<CRowItem> lstItem = ucTimeChart.GanttTree.GetSelectedItemList();
            if (lstItem == null || lstItem.Count == 0)
                return;

            ucTimeChart.GanttTree.ItemDown(lstItem);
            lstItem.Clear();
        }

        private void GanttChart_UEventBarClicked(object sender, CGanttBar cBar)
        {
            txtWordValue.Text = "";
            txtWordValue.Text = cBar.Text;
        }

        private void GanttChart_UEventBarDoubleClicked(object sender, CGanttBar cBar)
        {
            ucTimeChart.TimeLine.TimeIndicatorS.Clear();
            ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.StartTime, Color.Red));
            ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(cBar.EndTime, Color.Red));

            dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
            dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

            TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
            double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
            txtInterval.Text = nInterval.ToString();

            ucTimeChart.TimeLine.UpdateLayout();

        }

        private void TimeLine_UEventTimeIndicatorMoved(object sender, CTimeIndicator cIndicator)
        {
            if (ucTimeChart.TimeLine.TimeIndicatorS.Count == 0) return;
            else if (ucTimeChart.TimeLine.TimeIndicatorS.Count == 1)
                dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
            else
            {
                dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;
                dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
        }

        private void TimeLine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DateTime dtTime = ucTimeChart.TimeLine.CalcTime(e.X);

            if (ucTimeChart.TimeLine.TimeIndicatorS.Count > 1)
                ucTimeChart.TimeLine.TimeIndicatorS.RemoveAt(0);

            ucTimeChart.TimeLine.TimeIndicatorS.Add(new CTimeIndicator(dtTime, Color.Red));
            ucTimeChart.TimeLine.UpdateLayout();


            if (ucTimeChart.TimeLine.TimeIndicatorS.Count > 0)
                dtpkIndicator1.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[0].Time;

            if (ucTimeChart.TimeLine.TimeIndicatorS.Count > 1)
            {
                dtpkIndicator2.EditValue = (DateTime)ucTimeChart.TimeLine.TimeIndicatorS[1].Time;

                TimeSpan tsSpan = ucTimeChart.TimeLine.TimeIndicatorS[1].Time.Subtract(ucTimeChart.TimeLine.TimeIndicatorS[0].Time);
                double nInterval = Math.Abs(tsSpan.TotalMilliseconds);
                txtInterval.Text = nInterval.ToString();
            }
            else
            {
                txtInterval.Text = "0";
            }
        }

        private void btnShow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnAxisApply_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucTimeChart.SeriesChart.BeginUpdate();
            {
                string sMin = spinAxisMin.EditValue.ToString();
                string sMax = spinAxisMax.EditValue.ToString();
                double nMin = double.Parse(sMin);
                double nMax = double.Parse(sMax);

                ucTimeChart.SeriesChart.Axis.Minimumn = (float)(nMin);
                ucTimeChart.SeriesChart.Axis.Maximum = (float)(nMax);
            }
            ucTimeChart.SeriesChart.EndUpdate();
        }


    }
}