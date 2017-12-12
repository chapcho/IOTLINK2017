using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Project;

namespace UDMTracker
{
    public partial class FrmRunningTimeDifferenceReport : Form
    {

        private CProject m_cProject;
        private CTimeLogS m_cTimeLogS;
        private List<string> m_lstItem;
        private DateTime m_dtCheckStart;
        private DateTime m_dtCheckEnd;
        private string m_sResolveType;
        private int m_iResolveType = 0;

        private List<CReportTimePeriod> m_lstReportTime = new List<CReportTimePeriod>();
        private List<CDeviceTimeDiffenceReport> m_lstTimeDefferenceReport = new List<CDeviceTimeDiffenceReport>();
        private List<CTagCycleRunningStepMsS> m_lstTagCycleRunningStepMs = new List<CTagCycleRunningStepMsS>();
        private CDeviceStepRunningInfoS m_deviceTimeInfoS = new CDeviceStepRunningInfoS();

        public int ResolveType
        {
            get { return m_iResolveType; }
            set
            {
                m_iResolveType = value;
                m_sResolveType = m_iResolveType == 0 ? "FirstLastDevice" : "FirstDevice";
            }
        }

        public CDeviceStepRunningInfoS DeviceStepRunningInfoS
        {
            get { return m_deviceTimeInfoS; }
            set { m_deviceTimeInfoS = value; }
        }

        public FrmRunningTimeDifferenceReport(CProject srcProject, CTimeLogS srcTimeLogS, List<string> srcLstItem, DateTime srcDtStart, DateTime srcDtEnd, int srcResolveType)
        {
            InitializeComponent();

            m_cProject = srcProject;
            m_cTimeLogS = srcTimeLogS;
            m_lstItem = srcLstItem;
            m_dtCheckStart = srcDtStart;
            m_dtCheckEnd = srcDtEnd;
            ResolveType = srcResolveType;

            this.Text = string.Format("동작시간 Report 사이클 구간 : {0}", ResolveType == 0 ? "First On -> Last On" : "First On -> First On");
        }

        public void ShowReport()
        {
            bool bOK = ResolveDeviceTimeLog();
            if (bOK == false)
            {
                MessageBox.Show("신호 이력에서 사이클을 찾을 수 없습니다.", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
                this.ShowDialog();
        }

        private BandedGridView GetBandedGridView(int nCycleCount)
        {
            BandedGridView bandedView = new BandedGridView();

            SetBandedGridViewParameter(bandedView);
            SetBandedGridTagColumn(bandedView);
            SetBandedGridCycleColumn(bandedView, nCycleCount);

            bandedView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grvView1_CustomUnboundColumnData);

            return bandedView;
        }

        private void SetBandedGridViewParameter(BandedGridView bandedView)
        {
            bandedView.OptionsSelection.MultiSelect = true;
            bandedView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            bandedView.OptionsBehavior.AllowIncrementalSearch = true;
            bandedView.OptionsPrint.PrintDetails = true;
            bandedView.OptionsView.ColumnAutoWidth = false;

            bandedView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            bandedView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            bandedView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            bandedView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            bandedView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            bandedView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            bandedView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            bandedView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            bandedView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            bandedView.Appearance.Empty.Options.UseBackColor = true;
            bandedView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            bandedView.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(234)))));
            bandedView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.EvenRow.Options.UseBackColor = true;
            bandedView.Appearance.EvenRow.Options.UseBorderColor = true;
            bandedView.Appearance.EvenRow.Options.UseForeColor = true;
            bandedView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            bandedView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            bandedView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            bandedView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            bandedView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            bandedView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            bandedView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.FilterPanel.Options.UseBackColor = true;
            bandedView.Appearance.FilterPanel.Options.UseForeColor = true;
            bandedView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(114)))), ((int)(((byte)(113)))));
            bandedView.Appearance.FixedLine.Options.UseBackColor = true;
            bandedView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            bandedView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.FocusedCell.Options.UseBackColor = true;
            bandedView.Appearance.FocusedCell.Options.UseForeColor = true;
            bandedView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(192)))), ((int)(((byte)(157)))));
            bandedView.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(219)))), ((int)(((byte)(188)))));
            bandedView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.FocusedRow.Options.UseBackColor = true;
            bandedView.Appearance.FocusedRow.Options.UseBorderColor = true;
            bandedView.Appearance.FocusedRow.Options.UseForeColor = true;
            bandedView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.FooterPanel.Options.UseBackColor = true;
            bandedView.Appearance.FooterPanel.Options.UseBorderColor = true;
            bandedView.Appearance.FooterPanel.Options.UseForeColor = true;
            bandedView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            bandedView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(179)))));
            bandedView.Appearance.GroupButton.Options.UseBackColor = true;
            bandedView.Appearance.GroupButton.Options.UseBorderColor = true;
            bandedView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.GroupFooter.Options.UseBackColor = true;
            bandedView.Appearance.GroupFooter.Options.UseBorderColor = true;
            bandedView.Appearance.GroupFooter.Options.UseForeColor = true;
            bandedView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(242)))), ((int)(((byte)(213)))));
            bandedView.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.White;
            bandedView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.GroupPanel.Options.UseBackColor = true;
            bandedView.Appearance.GroupPanel.Options.UseForeColor = true;
            bandedView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.GroupRow.Options.UseBackColor = true;
            bandedView.Appearance.GroupRow.Options.UseBorderColor = true;
            bandedView.Appearance.GroupRow.Options.UseForeColor = true;
            bandedView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.HeaderPanel.Options.UseBackColor = true;
            bandedView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            bandedView.Appearance.HeaderPanel.Options.UseForeColor = true;
            bandedView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            bandedView.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            bandedView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            bandedView.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            bandedView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            bandedView.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.HorzLine.Options.UseBackColor = true;
            bandedView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            bandedView.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            bandedView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.OddRow.Options.UseBackColor = true;
            bandedView.Appearance.OddRow.Options.UseBorderColor = true;
            bandedView.Appearance.OddRow.Options.UseForeColor = true;
            bandedView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            bandedView.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            bandedView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            bandedView.Appearance.Preview.Options.UseBackColor = true;
            bandedView.Appearance.Preview.Options.UseFont = true;
            bandedView.Appearance.Preview.Options.UseForeColor = true;
            bandedView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(236)))));
            bandedView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.Row.Options.UseBackColor = true;
            bandedView.Appearance.Row.Options.UseForeColor = true;
            bandedView.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(232)))), ((int)(((byte)(201)))));
            bandedView.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White;
            bandedView.Appearance.RowSeparator.Options.UseBackColor = true;
            bandedView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(215)))), ((int)(((byte)(188)))));
            bandedView.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(230)))), ((int)(((byte)(203)))));
            bandedView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            bandedView.Appearance.SelectedRow.Options.UseBackColor = true;
            bandedView.Appearance.SelectedRow.Options.UseBorderColor = true;
            bandedView.Appearance.SelectedRow.Options.UseForeColor = true;
            bandedView.Appearance.TopNewRow.BackColor = System.Drawing.Color.White;
            bandedView.Appearance.TopNewRow.Options.UseBackColor = true;
            bandedView.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(209)))), ((int)(((byte)(170)))));
            bandedView.Appearance.VertLine.Options.UseBackColor = true;
            bandedView.OptionsView.EnableAppearanceEvenRow = true;
            bandedView.OptionsView.EnableAppearanceOddRow = true;

            bandedView.OptionsView.ShowGroupPanel = false;

            bandedView.GridControl = this.grdReport;
        }

        private void SetBandedGridCycleColumn(BandedGridView bandedView, int nCycleCount)
        {
            for (int i = 0; i < m_lstReportTime.Count(); i++)
            {
                var gridBand = new GridBand();

                gridBand.Caption = (i + 1).ToString() + " 사이클(ms) [ " + m_lstReportTime[i].StartDt.ToString("HH:mm:ss.fff") + " ~ " + m_lstReportTime[i].EndDt.ToString("HH:mm:ss.fff") + " ]";
                gridBand.AppearanceHeader.Options.UseTextOptions = true;
                gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                SetBandedGridCycleColumnDetail(bandedView, gridBand, "stepTime", "스텝시간", i, 0, 65);
                SetBandedGridCycleColumnDetail(bandedView, gridBand, "stepTime", "동작시간", i, 1, 75);
                SetBandedGridCycleColumnDetail(bandedView, gridBand, "stepTime", "동작시간 합", i, 2, 80);
                SetBandedGridCycleColumnDetail(bandedView, gridBand, "stepTime", "로그수", i, 3, 50);
                SetBandedGridCycleColumnDetail(bandedView, gridBand, "cycleStepTime", "Cycle스텝시간", i, 4, 65);
            }
        }

        private void SetBandedGridCycleColumnDetail(BandedGridView bandedView, GridBand gridBand, string sColName, string sDesc, int nCycleCnt, int iRefIndex, int iWidth)
        {
            int iFieldIdx = (nCycleCnt * 5) + iRefIndex;

            BandedGridColumn colCycle = new BandedGridColumn();

            colCycle.Name = "colRunningTime" + iFieldIdx.ToString();
            colCycle.FieldName = iFieldIdx.ToString();
            colCycle.Caption = sDesc;

            colCycle.Tag = iFieldIdx;
            colCycle.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            colCycle.OptionsColumn.AllowEdit = false;
            colCycle.OptionsColumn.ReadOnly = true;
            colCycle.OwnerBand = gridBand;

            colCycle.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            colCycle.AppearanceHeader.Options.UseTextOptions = true;
            colCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            colCycle.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            colCycle.Visible = true;
            colCycle.Width = iWidth;

            bandedView.Columns.Add(colCycle);  
        }

        private void SetBandedGridTagColumn(BandedGridView bandedView)
        {
            var gridBand = new GridBand();

            gridBand.Caption = "Device";
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            BandedGridColumn colCycle = new BandedGridColumn();

            colCycle.Name = "Address";
            colCycle.FieldName = "Tag.Address";
            colCycle.Caption = "주소";

            colCycle.Tag = "Tag.Address";
            // colCycle.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colCycle.OptionsColumn.AllowEdit = false;
            colCycle.OptionsColumn.ReadOnly = true;
            colCycle.OwnerBand = gridBand;
            colCycle.AppearanceHeader.Options.UseTextOptions = true;
            colCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            // colCycle.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            colCycle.Visible = true;
            colCycle.Width = 80;

            bandedView.Columns.Add(colCycle);

            colCycle = new BandedGridColumn();

            colCycle.Name = "Description";
            colCycle.FieldName = "Tag.Description";
            colCycle.Caption = "코멘트";

            colCycle.Tag = "Tag.Description";
            // colCycle.UnboundType = DevExpress.Data.UnboundColumnType.String;
            colCycle.OptionsColumn.AllowEdit = false;
            colCycle.OptionsColumn.ReadOnly = true;
            colCycle.OwnerBand = gridBand;
            colCycle.AppearanceHeader.Options.UseTextOptions = true;
            colCycle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            colCycle.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            colCycle.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

            colCycle.Visible = true;
            colCycle.Width = 140;

            bandedView.Columns.Add(colCycle);
        }

        private bool ResolveDeviceTimeLog()
        {
            int nCycleCount = 0;

            if (m_cProject == null || m_cTimeLogS == null || m_cTimeLogS.Count < 1)
            {
                return false;
            }

            nCycleCount = DeviceRunningTimeResolve(m_cProject, m_cTimeLogS, m_lstItem, m_sResolveType, m_dtCheckStart, m_dtCheckEnd);

            if (nCycleCount < 1) return false;

            grdReport.MainView = GetBandedGridView(nCycleCount);
            grdReport.DataSource = m_lstTagCycleRunningStepMs;
            grdReport.RefreshDataSource();

            return true;
        }

        /********************************************************************************************************
         * 
         * Name : CalcRunncingTime
         * Purpose : 디바이스의 동작 시간 계산
         * Author  : ijsong@udmtek
         * Note :
         * 정해진 시간 범위에서 특정 디바이스가 On된 시간의 합을 구합니다.
         * 시작 지점을 지나서 종료된 경우는 시작지점에서 시작한것으로 간주하고,
         * 종료 지점 전에 시작되었으나, 종료 기록이 없는 경우는 종료지점까지 동작한것으로 간주합니다.
         * 
         ********************************************************************************************************/
        private double CalcDeviceRunningTime(List<CTimeLog> lstTimeLog, DateTime dtCheckStart, DateTime dtCheckEnd)
        {
            double dRunningTime = 0;

            for (int i = 0; i < lstTimeLog.Count; i++)
            {
                if (lstTimeLog[i].Time < dtCheckStart) continue;
                if (lstTimeLog[i].Time > dtCheckEnd) continue;

                if (lstTimeLog.Count > i + 1)
                {
                    dRunningTime += lstTimeLog[i + 1].Time.Subtract(lstTimeLog[i].Time).TotalMilliseconds;
                    i += 1;
                }
                else
                {
                    if (lstTimeLog[i].Time < dtCheckEnd)
                    {
                        dRunningTime += dtCheckEnd.Subtract(lstTimeLog[i].Time).TotalMilliseconds;
                    }
                    else
                        dRunningTime += lstTimeLog[i].Time.Subtract(dtCheckEnd).TotalMilliseconds;

                    i += 1;
                }
            }
            return dRunningTime;
        }

        /*********************************************************************************************************
         * 
         * Name : DeviceRunningTimeResolve
         * Purpose : 디바이스 신호를 2가지 규칙으로 구분하여 분석한다.
         * Author : ijsong@udmtek
         * Note :
         *  - 전달된 로그를 디바이스 기준으로 조각내어 분석한다.
         *  - 전달된 로그를 최상위,최하위 디바이스 On시점으로 조각내어 분석한다.
         *  - 입력 파라미터 주의 : 차트의 항목중 비트 값만 중복 없이 전달 된다.
         * 
         ********************************************************************************************************/
        private int  DeviceRunningTimeResolve(CProject cProject, CTimeLogS cTimeLogs, List<string> lstGanttItemInfo, string sDivideType, DateTime dtStart, DateTime dtEnd)
        {
            #region *** Step 1 Method 내부 변수
            DateTime dtCheckStart = DateTime.MinValue;
            DateTime dtCheckEnd = DateTime.MinValue;
            List<CTimeLog> lstFirstDeviceTimeLog = new List<CTimeLog>();
            List<CTimeLog> lstLastDeviceTimeLog = new List<CTimeLog>();
            int iFirstDeviceStartLogIdx = 0;
            int iLastDeviceStartLogIdx = 0;
            // int iRetCycleCount = 0;
            #endregion

            m_lstReportTime.Clear();
            if (lstGanttItemInfo.Count < 1) return m_lstReportTime.Count();            

            lstFirstDeviceTimeLog = cTimeLogs.Where(x => x.Key.Contains( lstGanttItemInfo[0]) ).OrderBy(x => x.Time).ToList();
            lstLastDeviceTimeLog = cTimeLogs.Where(x => x.Key.Contains(lstGanttItemInfo[lstGanttItemInfo.Count - 1])).OrderBy(x => x.Time).ToList();

            #region *** 분석은 조건 디바이스의 On 시점 부터 시작할 수 있도록 조정

            for (int i = 0; i < lstFirstDeviceTimeLog.Count; i++)
            {
                if( lstFirstDeviceTimeLog[i].Value.ToString().Equals("0") ) iFirstDeviceStartLogIdx++;
                else break;
            }

            for (int i = 0; i < lstLastDeviceTimeLog.Count; i++)
            {
                if (lstLastDeviceTimeLog[i].Value.ToString().Equals("0")) iLastDeviceStartLogIdx++;
                else break;
            }

            #endregion

            for (int i = iFirstDeviceStartLogIdx; i < lstFirstDeviceTimeLog.Count; i += 2 )
            {
                #region *** 처음 디바이스의 신호기준인지, 처음과 최종 디바이스 신호기준인지에 따라 시간 조건을 설정. ***
                switch (sDivideType)
                {
                    case "FirstLastDevice":
                        dtCheckStart = lstFirstDeviceTimeLog[i].Time;
                        if (iLastDeviceStartLogIdx > iFirstDeviceStartLogIdx)
                        {
                            if (lstLastDeviceTimeLog.Count > (i + iLastDeviceStartLogIdx + 1))
                            {
                                dtCheckEnd = lstLastDeviceTimeLog[i + iLastDeviceStartLogIdx + 1].Time;
                            }
                            else dtCheckEnd = dtEnd;
                        }
                        else
                        {
                            if (lstLastDeviceTimeLog.Count > (i + 1))
                            {
                                dtCheckEnd = lstLastDeviceTimeLog[i + 1].Time;
                            }
                            else dtCheckEnd = dtEnd;
                        }
                        
                        break;
                    case "FirstDevice":
                    default:
                        dtCheckStart = lstFirstDeviceTimeLog[i].Time;
                        if (lstFirstDeviceTimeLog.Count > i + 2) dtCheckEnd = lstFirstDeviceTimeLog[i + 2].Time;
                        else dtCheckEnd = dtEnd;
                        break;
                }
                #endregion

                if (dtCheckStart != DateTime.MinValue)
                {
                    // List<CTimeLog> cTargetTimeLog = cTimeLogs.Where(x => x.Time >= dtCheckStart && x.Time <= dtCheckEnd).ToList();
                    List<CTimeLog> cTargetTimeLog = cTimeLogs.Where(x => x.Time >= dtCheckStart && x.Time <= dtEnd).ToList();

                    DeviceRunningTimeResolveStep2(cProject, cTargetTimeLog, lstGanttItemInfo, dtCheckStart, dtCheckEnd);
                    m_lstReportTime.Add(new CReportTimePeriod(dtCheckStart, dtCheckEnd));
                }
            }

            return m_lstReportTime.Count();
        }

        private void DeviceRunningTimeResolveStep2(CProject cProject, List<CTimeLog> cTimeLogs, List<string> lstGanttItemInfo, DateTime dtCheckStart, DateTime dtCheckEnd)
        {
            DateTime dtNextTimePoint = dtCheckStart;
            bool bStartTimeCheck = false;

            for (int i = 0; i < lstGanttItemInfo.Count; i++)
            {
                CDeviceTimeDiffenceReport src = new CDeviceTimeDiffenceReport();
                List<CTimeLog> lstTimeLog = new List<CTimeLog>();
                CTag cTag;

                src.Key = lstGanttItemInfo[i];
                cTag = cProject.TagS.Where(x => x.Value.Key == src.Key).ToList()[0].Value;

                // lstTimeLog = cTimeLogs.Where(x => x.Key.Equals(cTag.Key)).Where(x => x.Time >= dtNextTimePoint).ToList();
                lstTimeLog = cTimeLogs.Where(x => x.Key.Equals(cTag.Key) && x.Time >= dtCheckStart).ToList();

                lstTimeLog = (from timeLog in cTimeLogs 
                             where timeLog.Key.Equals(cTag.Key) && timeLog.Time >= dtCheckStart 
                             orderby timeLog.Time
                             select timeLog).ToList();

                lstTimeLog = lstTimeLog.OrderBy(x => x.Time).ToList();

                bStartTimeCheck = false;

                for (int j = 0; j < lstTimeLog.Count; j++)
                {
                    if (lstTimeLog[j].Value.ToString().Equals("0")) continue;
                    else
                    {
                        src.StepTime = lstTimeLog[j].Time.Subtract(dtNextTimePoint).TotalMilliseconds;
                        src.CycleStepTime = lstTimeLog[j].Time.Subtract(dtCheckStart).TotalMilliseconds;
                        src.StartTime = lstTimeLog[j].Time;
                        if (lstTimeLog.Count > j + 1)
                        {
                            src.RunningTime = lstTimeLog[j + 1].Time.Subtract(lstTimeLog[j].Time).TotalMilliseconds;
                            src.EndTime = lstTimeLog[j + 1].Time;
                        }
                        else
                        {
                            src.RunningTime = dtCheckEnd.Subtract(lstTimeLog[j].Time).TotalMilliseconds;
                            src.EndTime = dtCheckEnd;
                        }
                        // src.SumRunningTime = CalcDeviceRunningTime(lstTimeLog, dtCheckStart, dtCheckEnd);
                        if (src.EndTime > dtCheckEnd)
                        {
                            src.SumRunningTime = src.CalcDeviceRunningTime(lstTimeLog, src.StartTime, src.EndTime);
                        }
                        else
                        {
                            src.SumRunningTime = src.CalcDeviceRunningTime(lstTimeLog, src.StartTime, dtCheckEnd);
                        }

                        src.LogCount = lstTimeLog.Where(x => x.Time >= dtCheckStart && x.Time <= dtCheckEnd).Count();

                        if (!bStartTimeCheck)
                        {
                            dtNextTimePoint = lstTimeLog[j].Time;    // ijsong@udmtek 2015.12.07 
                            bStartTimeCheck = !bStartTimeCheck;
                        }
                    }

                    break;  // 첫번째 동작에 대해서만 분석..
                }


                // 상위 Loop에서 4개의 값을 구해서 배열에 추가합니다.
                // Tag의 시간 분석 배열에 추가합니다.

                CTagCycleRunningStepMsS addPosData;

                if (m_lstTagCycleRunningStepMs.Where(x => x.Tag.Key == cTag.Key).ToList().Count > 0)
                {
                    addPosData = m_lstTagCycleRunningStepMs.Where(x => x.Tag.Key == cTag.Key).ToList()[0];
                    addPosData.Add(src.StepTime);
                    
                    addPosData.Add(src.RunningTime);
                    addPosData.Add(src.SumRunningTime);
                    addPosData.Add(src.LogCount);
                    addPosData.Add(src.CycleStepTime);
                }
                else
                {
                    addPosData = new CTagCycleRunningStepMsS( cTag );

                    addPosData.Add(src.StepTime);
                    
                    addPosData.Add(src.RunningTime);
                    addPosData.Add(src.SumRunningTime);
                    addPosData.Add(src.LogCount);
                    addPosData.Add(src.CycleStepTime);

                    m_lstTagCycleRunningStepMs.Add(addPosData);
                }

                m_lstTimeDefferenceReport.Add( src );

                lstTimeLog = null;
                src = null;
            }
        }

        /*
         * GridView의 데이터를 Excel로 Export...
         */
        private void TimeResolveDataExcelExport()
        {
            string sPath = "";

            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.Filter = "*.xlsx|*.xlsx|*.xls|*.xls";

            DialogResult dlgResult = dlgSave.ShowDialog();

            if (dlgResult == DialogResult.Cancel)
                return;

            sPath = dlgSave.FileName;

            if (sPath == "")
                return;

            if (dlgSave.FilterIndex == 1)
            {
                XlsxExportOptions xlsxExportOption = new XlsxExportOptions();
                xlsxExportOption.SheetName = "신호동작시간분석";
                grdReport.ExportToXlsx(sPath, xlsxExportOption);
            }
            else
            {
                XlsExportOptions xlsExportOption = new XlsExportOptions();
                xlsExportOption.SheetName = "신호동작시간분석";
                grdReport.ExportToXls(sPath, xlsExportOption);
            }
        }


        #region Event Handler

        

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            if (m_lstTagCycleRunningStepMs.Count > 0)
            {
                TimeResolveDataExcelExport();
            }
        }

        private void grvView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Row == null)
                return;

            if (e.Column.Tag == null)
                return;

            CTagCycleRunningStepMsS cLogCountS = (CTagCycleRunningStepMsS)e.Row;
            int iIndex = (int)e.Column.Tag;
            if (cLogCountS.Count > iIndex)
            {
                e.Value = (int)cLogCountS[iIndex];
            }
            else
            {
                e.Value = (int)0;
            }

        }
        #endregion

        /// <summary>
        /// 사이클 동안 기록된 스탭과 동작시간 정보를 저장.
        /// 스탭시간과 동작시간은 이동평균법을 이용하여 계산.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenStepRunningTimeSeq_Click(object sender, EventArgs e)
        {
            CDeviceStepRunningInfo deviceRunningInfo;
            CDeviceStepRunningInfoS deviceTimeInfoS = new CDeviceStepRunningInfoS();
            int itemIndex = -1;

            if (m_lstTimeDefferenceReport.Count > 0)
            {
                for (int i = 0; i < m_lstTimeDefferenceReport.Count; i++)
                {
                    CDeviceTimeDiffenceReport src = m_lstTimeDefferenceReport[i];
                    itemIndex = deviceTimeInfoS.GetKeyIndex(src.Key);
                    if( itemIndex != -1)
                    {
                        deviceRunningInfo = deviceTimeInfoS[itemIndex];
                        deviceRunningInfo.StepMs = int.Parse((((deviceRunningInfo.StepMs + int.Parse(src.CycleStepTime.ToString())) / 2)).ToString());
                        deviceRunningInfo.RunningMs = int.Parse((((deviceRunningInfo.RunningMs + int.Parse(src.RunningTime.ToString()) )/ 2)).ToString());
                        deviceRunningInfo.RunningTimes = int.Parse((((deviceRunningInfo.RunningTimes + int.Parse(src.SumRunningTime.ToString()) )/ 2)).ToString());
                    }
                    else
                    {
                        deviceRunningInfo = new CDeviceStepRunningInfo();
                        deviceRunningInfo.Key = src.Key;
                        deviceRunningInfo.StepMs = int.Parse(src.CycleStepTime.ToString());
                        deviceRunningInfo.RunningMs = int.Parse( src.RunningTime.ToString() );
                        deviceRunningInfo.RunningTimes = int.Parse( src.SumRunningTime.ToString() );

                        deviceTimeInfoS.Add(deviceRunningInfo);
                    }
                }

                this.DeviceStepRunningInfoS = deviceTimeInfoS;

                switch (this.m_iResolveType)
                {
                    case 0: // "FirstLastDevice":
                        break;
                    case 1: // "FirstDevice":
                        break;
                }

               
            }
        }

    }

}

/*
 *      // Report 호출자 sample..
 *      // 동작시간 리포트는 차트에 표시된 시간을 기준으로 작성합니다.
 *      // 최상위 디바이스가 사이클 시작디바이스여야 하므로, 차트에서 시간순 정렬과 디바이스 순서 정렬이 먼저 작업되어야 합니다.
 *      // 최상위 디바이스의 On 시점으로 사이클을 결정하는 First -> First 방식의 사이클 시간은 최상위 On( = ) ~ 최상위 On( < ) 입니다.
 *      // 최상위 On ~ 최하위 Off 는 최하위 디바이스가 Off 되는 시점으로 사이클 범위를 설정합니다.
 *      
        private void GenerateReportWithSignalTimeDifference(DateTime dtStart, DateTime dtEnd)
        {
            if(dtStart == DateTime.MinValue || dtEnd == DateTime.MinValue) return;

            CTimeLogS srcTimeLogS = new CTimeLogS();
            List<string> lstGanttItem = new List<string>();
            CGanttItem[] arGanttItem = ucLogicChart.GetListGanttItems();

            for (int i = 0; i < arGanttItem.Length; i++)
            {
                string sKey = "";

                if (IsTagItem(arGanttItem[i]))
                {
                    if (((CTag)arGanttItem[i].Tag).DataType != EMDataType.Bool) continue;

                    sKey = ((CTag)arGanttItem[i].Tag).Key;
                }
                else if (IsstepItem(arGanttItem[i]))
                {
                    if (((CStep)arGanttItem[i].Tag).DataType != EMDataType.Bool) continue;

                    sKey = ((CStep)arGanttItem[i].Tag).Key;
                }

                if (sKey != "")
                {
                    lstGanttItem.Add(sKey);
                    // 로그를 생성할때, 기준 시간을 앞쪽은 포함하고( >= ), 뒤쪽은 포함하지 않습니다.( < ) 
                    srcTimeLogS.AddRange(m_cHistory.TimeLogS.Where(x => x.Key.Equals(sKey)).Where(x => x.Time >= dtStart && x.Time < dtEnd));
                }
            }

            FrmRunningTimeDifferenceReport frmDlg = new FrmRunningTimeDifferenceReport( m_cUpmProject, srcTimeLogS, lstGanttItem, dtStart, dtEnd , 0);
            frmDlg.Show();
        } 
 
 */