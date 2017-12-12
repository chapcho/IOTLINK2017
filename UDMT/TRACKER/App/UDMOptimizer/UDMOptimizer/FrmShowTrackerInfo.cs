using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Log;
using System.Diagnostics;
namespace UDMOptimizer
{
    public partial class FrmShowTrackerInfo : DevExpress.XtraEditors.XtraForm
    {
        public FrmShowTrackerInfo()
        {
            InitializeComponent();
        }

        private void FrmShowTrackerInfo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ShowInitData();
        }

        private void ShowInitData()
        {
            //기본 정보
            exPropertyView.SelectedObject = CMultiProject.ProjectInfo;
            exPropertyView.Refresh();
            List<CCollectInfo> lstCollectInfo = new List<CCollectInfo>();

            if (CMultiProject.LogReader.IsConnected == false)
                CMultiProject.LogReader.Connect();

            foreach (var who in CMultiProject.CollectSymbolInfoList)
            {
                CCollectInfo cCollectInfo = new CCollectInfo();
                cCollectInfo.StartTime = who.Value.StartTime;
                cCollectInfo.EndTime = who.Value.EndTime;

                if (cCollectInfo.StartTime != DateTime.MinValue && cCollectInfo.EndTime != DateTime.MinValue)
                {
                    CTimeLogS cLogS = CMultiProject.LogReader.GetTimeLogS(cCollectInfo.StartTime, cCollectInfo.EndTime);
                    if (cLogS != null)
                        cCollectInfo.TimeLogS = cLogS;
                }

                cCollectInfo.CycleInfoS = CMultiProject.LogReader.GetCycleInfoS(who.Value.ProjectID, cCollectInfo.StartTime, cCollectInfo.EndTime);

                lstCollectInfo.Add(cCollectInfo);
            }

            grdLogInfo.DataSource = lstCollectInfo;
            grdLogInfo.RefreshDataSource();
        }

        private void grvLogInfo_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iCount = e.RowHandle + 1;
                e.Info.DisplayText = iCount.ToString();
            }
        }

        private void grvLogInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
            if (e.RowHandle < 0) return;
            object obj = grvLogInfo.GetRow(e.RowHandle);
            if (obj.GetType() != typeof(CCollectInfo)) return;
            CCollectInfo cCollect = (CCollectInfo)obj;

            grdCycleInfo.DataSource = null;
            grdCycleInfo.RefreshDataSource();

            if (cCollect.CycleInfoS == null || cCollect.CycleInfoS.Count == 0) return;

            grdCycleInfo.DataSource = cCollect.CycleInfoS.Values.ToList();
            grdCycleInfo.RefreshDataSource();
            grvCycleInfo.ExpandAllGroups();
        }
    }
}