using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;
using UDM.Log.DB;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;


namespace UDMTrackerSimple
{
    public partial class FrmLadderLogViewer : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private int m_iLadderID = -1;
        private int m_iCurrentTimeIndex = 0;
        private int m_iSplitPos = 0;
        private DataTable m_dtLogList = null;
        private CTimeLogS m_cLadderIDTimeLogS = null;
        private List<IGrouping<DateTime, CTimeLog>> m_lstGroupLogS = null;

        private CMySqlLogReader m_cLogReader = null;

        #endregion

        #region Initialize
        public FrmLadderLogViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #endregion

        #region Private Method

        private bool ConnectLogReader()
        {
            bool bOK = false;

            m_cLogReader = new CMySqlLogReader();

            bOK = m_cLogReader.Connect();

            if (!bOK)
            {
                Console.Write("LogWriter", "DB연결에 실패했습니다.");
                return false;
            }

            return bOK;
        }

        private bool DisconnectLogReader()
        {
            bool bOK = false;

            bOK = m_cLogReader.Disconnect();
            m_cLogReader.Dispose();
            m_cLogReader = null;

            return bOK;
        }

        private void SetGridLogList()
        {
            if(m_cLogReader.IsConnected)
            {
                m_dtLogList = m_cLogReader.GetLadderLogList(CMultiProject.ProjectID);
                grdLogList.DataSource = m_dtLogList;
                //yyyy-MM-dd HH:mm:ss.fff
            }
        }

        private void Clear()
        {
            dtpkFrom.EditValue = "";
            dtpkTo.EditValue = "";

            m_dtLogList = null;
            grdLogList.DataSource = null;
            grdLogList.RefreshDataSource();

            if (m_cLadderIDTimeLogS != null)
            {
                m_cLadderIDTimeLogS.Clear();
                m_cLadderIDTimeLogS = null;
            }

            tabLadder.TabPages.Clear();
            trbLogTime.Properties.Labels.Clear();
        }

        private void SetLadderViewFromLogData(int iLadderID)
        {
            string sPlcID = "";
            string sMainStepKey = "";
            string sStepKeyS = "";
            CStepS cStepS = null;

            try
            {
                tabLadder.TabPages.Clear();

                DataRow[] draLogList = m_dtLogList.Select("iLadderID = '" + iLadderID + "'");

                foreach (DataRow dr in draLogList)
                {
                    sMainStepKey = dr["sMainStepKey"].ToString();
                    sStepKeyS = dr["sStepKeyS"].ToString();
                    sPlcID = dr["sPlcID"].ToString();

                    cStepS = CMultiProject.PlcLogicDataS[sPlcID].StepS;

                    CStep cMainStep = cStepS[sMainStepKey];
                    CTag cMainTag = cMainStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                    XtraTabPage tp = new XtraTabPage();
                    tp.Name = "tp" + cMainTag.Key;
                    tp.Text = cMainTag.Key + " : " + cMainTag.Description;
                    tp.Tag = cMainStep;
                    tp.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;

                    tabLadder.TabPages.Add(tp);
                    tabLadder.SelectedTabPage = tp;

                    Panel pnlLadder = new Panel();
                    pnlLadder.AutoScroll = true;
                    pnlLadder.VerticalScroll.Enabled = true;
                    tp.Controls.Add(pnlLadder);
                    pnlLadder.Dock = DockStyle.Fill;

                    string[] saStepKeyS = sStepKeyS.Split(';');

                    foreach (string sStepKey in saStepKeyS)
                    {
                        if (sStepKey != "")
                            SetLadderStep(cStepS[sStepKey], 0, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void SetLadderStep(CStep cStep, int iStepLevel, bool bView)
        {
            try
            {
                if (cStep != null)
                {
                    Panel pnlLadder = (Panel)tabLadder.SelectedTabPage.Controls[0];
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlLadder.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep)pnlLadder.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                            lstRemove.Add(ucView);
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.", "Real Time Ladder View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                    {
                        pnlLadder.Controls.Remove(lstRemove[i]);
                    }

                    CCoil cLadderCoil = cStep.CoilS.GetFirstCoil();
                    CTag cLadderTag = cLadderCoil.ContentS[0].Tag;

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.AutoScroll = true;
                    ucStep.ScaleDefault = 1f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel;
                    ucStep.IsViewStep = bView;

                    if (cLadderTag != null)
                    {
                        ucStep.StepName =
                           string.Format("CPU : {0} / Program : {1} / Network : {2} / Coil : {3} ( {4} )",
                               cLadderTag.Channel, cStep.Program, cStep.StepIndex, cLadderTag.Address, cLadderTag.Description);
                    }
                    else
                    {
                        ucStep.StepName =
                             string.Format("Program : {0} / Network : {1} / Coil : {2}",
                                 cStep.Program, cStep.StepIndex, cStep.Instruction);
                    }
                    pnlLadder.Controls.Add(ucStep);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void SetActiveTime()
        {
            try
            {
                string sTime;
                List<TrackBarLabel> lstLabel = new List<TrackBarLabel>();

                //List<IGrouping<string, CTimeLog>> lstLogS = m_cLadderIDTimeLogS.OrderBy(x => x.Time).GroupBy(x => x.Time.ToString("yyyy-MM-dd HH:mm:ss.fff")).ToList();
                m_lstGroupLogS = m_cLadderIDTimeLogS.OrderBy(x => x.Time).GroupBy(x => x.Time).ToList();

                for (int i = 0; i < m_lstGroupLogS.Count; i++)
                {
                    sTime = m_lstGroupLogS[i].Key.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    TrackBarLabel cLabel = new DevExpress.XtraEditors.Repository.TrackBarLabel(sTime, i);
                    lstLabel.Add(cLabel);
                }

                trbLogTime.Properties.Labels.Clear();
                trbLogTime.Properties.Labels.AddRange(lstLabel.ToArray());
                trbLogTime.Properties.Minimum = 0;
                trbLogTime.Properties.Maximum = m_lstGroupLogS.Count;
                trbLogTime.Properties.TickFrequency = m_lstGroupLogS.Count / 10;

                trbLogTime.Value = m_lstGroupLogS.Count;

                //DevExpress.XtraEditors.Repository.TrackBarLabel cLabel;

                //trbLogTime.Properties.Minimum = 0;
                //trbLogTime.Properties.Maximum = m_cLadderIDTimeLogS.Count;
                //trbLogTime.Properties.TickFrequency = 20;
                //for (int i = 0; i < m_cLadderIDTimeLogS.Count; i++)ㅇ
                //{
                //    sTime = m_cLadderIDTimeLogS[i].Time.ToString("HH:mm:ss");
                //    cLabel = new DevExpress.XtraEditors.Repository.TrackBarLabel(sTime, i);
                //    trbLogTime.Properties.Labels.Add(cLabel);
                //}

                //m_iCurrentTimeIndex = m_cLadderIDTimeLogS.Count;
                //trbLogTime.Value = m_iCurrentTimeIndex;

                trbLogTime.Refresh();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        #endregion

        #region Public Method
        #endregion

        #region Form Event
        private void FrmLadderLogViewer_Load(object sender, EventArgs e)
        {
            bool bOK = ConnectLogReader();
            
            if (bOK)
                SetGridLogList();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (tabLadder.TabPages.Count == 0) return;

                if (dtpkFrom.EditValue == null || dtpkTo.EditValue == null)
                {
                    XtraMessageBox.Show("Ladder View Log 조회 시간을 설정 해 주세요.", "Ladder View Log Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime dtFrom = DateTime.Parse(dtpkFrom.EditValue.ToString());
                DateTime dtTo = DateTime.Parse(dtpkTo.EditValue.ToString());
                TimeSpan tsTime = dtTo - dtFrom;

                string sDtFrom = dtFrom.ToString("yyyyMMddHHmmss.fff");
                string sDtTo = dtTo.ToString("yyyyMMddHHmmss.999");

                if (tsTime.TotalSeconds < 0)
                {
                    XtraMessageBox.Show("Ladder View Log 조회 시간 설정을 확인 해 주세요.", "Ladder View Log Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                m_cLadderIDTimeLogS = new CTimeLogS();
                m_cLadderIDTimeLogS = m_cLogReader.GetLadderTimeLogS(CMultiProject.ProjectID, m_iLadderID, sDtFrom, sDtTo);

                if (m_cLadderIDTimeLogS.Count > 1000)
                {
                    XtraMessageBox.Show("최대 조회 가능한 Log 수(1000개)를 초과합니다.\nLadder View Log 조회 시간을 다시 설정 해 주세요.", "Ladder View Log Viewer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_cLadderIDTimeLogS = null;
                    return;
                }
                SetActiveTime();
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
            SetGridLogList();
        }

        private void grvLogList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle + 1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void grvLogList_DoubleClick(object sender, EventArgs e)
        {
            if (grdLogList.DataSource == null || grvLogList.DataRowCount == 0) return;

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                if (m_cLadderIDTimeLogS != null)
                {
                    DialogResult dlgResult = MessageBox.Show("조회 된 Ladder View 정보가 있습니다.\n다른 정보를 조회하시겠습니까?", "Real Time Ladder View",
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == System.Windows.Forms.DialogResult.No)
                        return;
                }

                m_iLadderID = int.Parse(view.GetDataRow(view.FocusedRowHandle)["iLadderID"].ToString());

                if (m_iLadderID > -1)
                {
                    string sFromTime = view.GetDataRow(view.FocusedRowHandle)["dtCollectStartDate"].ToString() + view.GetDataRow(view.FocusedRowHandle)["dtCollectStartTime"].ToString();
                    string sToTime = view.GetDataRow(view.FocusedRowHandle)["dtCollectEndTime"].ToString();

                    dtpkFrom.EditValue = DateTime.Parse(sFromTime);
                    dtpkTo.EditValue = DateTime.Parse(sToTime);

                    SetLadderViewFromLogData(m_iLadderID);
                }
            }
        }

        private void trbLogTime_Properties_ValueChanged(object sender, EventArgs e)
        {
            string sTime = "";
            CTimeLogS cLogS = new CTimeLogS();
            try
            {
                if (trbLogTime.Value != 0)
                {
                    sTime = trbLogTime.Properties.Labels[trbLogTime.Value].Label;
                    DateTime dtTrbTime = DateTime.Parse(sTime);
                    decimal dcTime = decimal.Parse(dtTrbTime.ToString("yyyyMMddHHmmss.fff"));
                    List<CTimeLog> lstSelectLogS = new List<CTimeLog>();
                    //List<CTimeLog> lstTimeLog = m_cLadderIDTimeLogS.Where(x => decimal.Parse(x.Time.ToString("yyyyMMddHHmmss.fff")) == dcTime).ToList();

                   List<IGrouping<DateTime, CTimeLog>> lst = m_lstGroupLogS.Where(x => x.Key <= dtTrbTime).ToList();

                    for (int i = 0; i < m_lstGroupLogS.Count; i++)
                    {
                        DateTime dtLogTime = m_lstGroupLogS[i].Key;

                        if (dtLogTime <= dtTrbTime)
                        {
                            lstSelectLogS.AddRange(m_lstGroupLogS[i].ToList());
                        }
                    }

                    foreach (CTimeLog cSelectLog in lstSelectLogS)
                    {
                        List<CTimeLog> lstLog = cLogS.Where(x => x.Key == cSelectLog.Key).ToList();

                        if (lstLog.Count > 0)
                        {
                            CTimeLog cLog = lstLog[0];

                            if (cLog.Key == cSelectLog.Key)
                            {
                                if (cLog.Value != cSelectLog.Value && cLog.Time <= cSelectLog.Time)
                                {
                                    cLog.Value = cSelectLog.Value;
                                    cLog.Time = cSelectLog.Time;
                                }
                            }
                            //foreach (CTimeLog cLog in cLogS)
                            //{
                            //}
                        }
                        else
                            cLogS.Add(cSelectLog);
                    }
                }

                foreach (XtraTabPage tp in tabLadder.TabPages)
                {
                    Panel pnlLadder = (Panel)tp.Controls[0];
                    foreach (Control con in pnlLadder.Controls)
                    {
                        UCLadderStep ucLadder = (UCLadderStep)con;
                        if (ucLadder.Step != null)
                        {
                            ucLadder.SymbolLogS = cLogS;
                            ucLadder.Refresh();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmLadderLogViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectLogReader();
        }

        private void trbLogTime_BeforeShowValueToolTip(object sender, TrackBarValueToolTipEventArgs e)
        {
            if (trbLogTime.Value != 0)
                e.ShowArgs.ToolTip = trbLogTime.Properties.Labels[trbLogTime.Value - 1].Label;//m_cLadderIDTimeLogS[trbLogTime.Value - 1].Time.ToString("yyyy-MM-dd HH:mm:ss.fff");
            else
                e.ShowArgs.Show = false;
        }
        #endregion

        private void grvLogList_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = (GridView)sender;

            if(m_cLadderIDTimeLogS != null)
            {
                for (int i = 0; i < grvLogList.RowCount; i++)
                {
                    if(int.Parse(grvLogList.GetDataRow(i)["iLadderID"].ToString()) == m_iLadderID)
                    {
                        //grvLogList.SelectRow(i);
                        //grvLogList.FocusedRowHandle = i;
                    }
                }

                //grvLogList.SelectedRowsCount;

                view.Appearance.FocusedRow.ForeColor = Color.Salmon;
                view.Appearance.FocusedRow.Options.UseForeColor = true;
                view.Appearance.FocusedRow.BackColor = Color.LightGray;
                view.Appearance.FocusedRow.Options.UseBackColor = true;

                //view.Appearance.SelectedRow.ForeColor = Color.Salmon;
                //view.Appearance.SelectedRow.Options.UseForeColor = true;
                //view.Appearance.SelectedRow.BackColor = Color.LightGray;
                //view.Appearance.SelectedRow.Options.UseBackColor = true;

                //grvLogList.RefreshData();

            }
        }
        
        private void sptMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sptMain.SplitterPosition > 0)
            {
                m_iSplitPos=  sptMain.SplitterPosition;
                sptMain.SplitterPosition = 0;
            }
            else
                sptMain.SplitterPosition = m_iSplitPos;
        }

    }
}
