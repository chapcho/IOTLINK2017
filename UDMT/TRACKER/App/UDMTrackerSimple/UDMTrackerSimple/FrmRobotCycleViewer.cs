using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    public partial class FrmRobotCycleViewer : DevExpress.XtraEditors.XtraForm
    {
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private int m_iSplitPos = 0;

        public FrmRobotCycleViewer()
        {
            InitializeComponent();
        }

        private void InitTable()
        {
            grdRobot.DataSource = null;
            grdRobot.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values;
            grdRobot.RefreshDataSource();
        }

        private void InitTimeRange()
        {
            m_dtTo = CMultiProject.LogReader.GetLastTimeLogTime();

            if (m_dtTo == DateTime.MinValue)
            {
                m_dtFrom = DateTime.MinValue;
                dtpkFrom.EditValue = null;
                dtpkTo.EditValue = null;
            }
            else
            {
                m_dtFrom = m_dtTo.AddMinutes(-30);

                dtpkFrom.EditValue = m_dtFrom;
                dtpkTo.EditValue = m_dtTo;
            }
        }

        private bool CheckCycleStatistic(CTag cTag)
        {
            bool bOK = false;

            Control control;
            for (int i = 0; i < ucRobotCycleStatisticS.Controls.Count; i++)
            {
                control = ucRobotCycleStatisticS.Controls[i];
                if (control.GetType() == typeof(UCRobotCycleStatistic))
                {
                    UCRobotCycleStatistic ucView = (UCRobotCycleStatistic)control;

                    if (ucView.Tag.Key == cTag.Key)
                    {
                        bOK = true;
                        break;
                    }
                }
            }

            return bOK;
        }

        private void FrmRobotCycleViewer_Load(object sender, EventArgs e)
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDMTracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            InitTimeRange();
            InitTable();
            m_iSplitPos = sptMain.SplitterPosition;
        }

        private void dtpkFrom_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            m_dtTo = (DateTime) dtpkTo.EditValue;
            m_dtFrom = (DateTime) dtpkFrom.EditValue;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                Control control;
                for (int i = 0; i < ucRobotCycleStatisticS.Controls.Count; i++)
                {
                    control = ucRobotCycleStatisticS.Controls[i];
                    if (control.GetType() == typeof (UCRobotCycleStatistic))
                    {
                        UCRobotCycleStatistic ucView = (UCRobotCycleStatistic) control;
                        ucView.UpdateView(CMultiProject.LogReader.GetTimeLogS(ucView.Tag.Key, m_dtFrom, m_dtTo));
                    }
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucRobotCycleStatisticS.Controls.Clear();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grvRobot_DoubleClick(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                int[] iaRowIndex = grvRobot.GetSelectedRows();

                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CTag cTag = (CTag) grvRobot.GetRow(iaRowIndex[i]);

                        if (CheckCycleStatistic(cTag))
                            continue;

                        CTimeLogS cLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, m_dtFrom, m_dtTo);
                        if (cLogS == null || cLogS.Count == 0)
                            return;

                        UCRobotCycleStatistic ucView = new UCRobotCycleStatistic();
                        ucView.Tag = cTag;
                        ucView.TimeLogS = cLogS;
                        ucView.Height = 220;
                        ucView.Dock = DockStyle.Top;

                        ucRobotCycleStatisticS.Controls.Add(ucView);
                    }
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos = sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }
    }
}