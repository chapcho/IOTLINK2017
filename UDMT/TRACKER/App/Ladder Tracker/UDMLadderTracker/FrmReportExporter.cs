using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.DocumentView;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using TrackerCommon;
using UDM.Flow;
using UDM.General.Statistics;
using UDM.Log;
using UDM.Log.DB;
using Excel = Microsoft.Office.Interop.Excel;

namespace UDMLadderTracker
{
    public partial class FrmReportExporter : DevExpress.XtraEditors.XtraForm
    {
        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private string m_sLineName = string.Empty;
        private string m_sSavePath = string.Empty;

        private bool m_bVerified = true;

        private CMySqlLogReader m_cReader = null;

        private Dictionary<string, CCycleStatisticView> m_lstView = new Dictionary<string, CCycleStatisticView>();
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();
        private List<CDateStatisticView> m_lstDateView = new List<CDateStatisticView>();

        private CErrorInfoS m_cTotalErrorInfoS = null;

        private int m_iProcessIndex = 0;

        public FrmReportExporter()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        private void VerifyInformation()
        {
            if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
            {
                MessageBox.Show("Process가 정의되지 않았습니다.\r\nReport를 만들 수 없습니다.", "Warning!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                m_bVerified = false;
                return;
            }

            //if (CMultiProject.MasterPatternS == null || CMultiProject.MasterPatternS.Count == 0)
            //{
            //    MessageBox.Show("MasterPattern이 정의되지 않았습니다.\r\nReport를 만들 수 없습니다.", "Warning!", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    m_bVerified = false;
            //    return;
            //}
            //else
            //{
            //    foreach (var who in CMultiProject.PlcProcS)
            //    {
            //        if (!CMultiProject.MasterPatternS.ContainsKey(who.Key))
            //        {
            //            MessageBox.Show(who.Key + " Process의 MasterPattern이 정의되지 않았습니다.\r\nReport를 만들 수 없습니다.", "Warning!", MessageBoxButtons.OK,
            //                MessageBoxIcon.Warning);
            //            m_bVerified = false;
            //            break;
            //        }
            //    }
            //}
        }

        private void ExportPLCMonitoringInfo()
        {
            if (!m_bVerified)
                return;

            m_iProcessIndex = 0;

            int iStep = 0;

            iStep = 1;
            Excel.Application xlApp = null;
            iStep = 2;
            Excel.Workbook xlWorkBook = null;
            iStep = 3;
            Excel.Workbooks xlWorkBooks = null;
            Excel.Sheets xlWorkSheets = null;

            try
            {
                iStep = 4;
                xlApp = new Excel.Application();

                iStep = 5;
                xlApp.ScreenUpdating = false;
                xlApp.DisplayAlerts = false;
                xlApp.Visible = false;

                string sResourcePath = Path.Combine(Application.StartupPath, "PLC 모니터링 생산 리포트 Template_이상");

                if (!File.Exists(sResourcePath + ".xlsx"))
                    MessageBox.Show("Template File이 존재하지 않음", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                iStep = 6;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(sResourcePath, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows,
                    "",
                    true, false, 0, true, false, false);

                iStep = 7;

                if (xlWorkBook == null)
                    return;

                xlWorkSheets = xlWorkBook.Sheets;

                foreach (Excel.Worksheet sheet in xlWorkSheets)
                {
                    if (m_iProcessIndex >= CMultiProject.PlcProcS.Count)
                    {
                        sheet.Delete();
                        ReleaseExcelObject(sheet);
                        continue;
                    }

                    if (sheet.Name == "표지")
                        MakeCoverPage(sheet);
                    else if (sheet.Name == "종합")
                        MakeAllInformationPage(sheet);
                    else if (sheet.Name.Contains("공정"))
                        MakeProcessPage(sheet);

                    ReleaseExcelObject(sheet);
                }

                string sSavePath = m_sSavePath + "\\생산이력리포트_" + m_sLineName + "_" + m_dtFrom.ToString("yyyyMMdd") + "_" +
                                   m_dtTo.ToString("yyyyMMdd");

                iStep = 8;

                // xlWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, sSavePath);
                xlWorkBook.SaveAs(sSavePath);
                MessageBox.Show("Report File Save OK!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                xlWorkBook.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Report File Save Fail! Step Num : " + iStep, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ex.Data.Clear();
                return;
            }
            finally
            {
                ReleaseExcelObject(xlWorkSheets);
                ReleaseExcelObject(xlWorkBook);
                ReleaseExcelObject(xlWorkBooks);
                ReleaseExcelObject(xlApp);
            }
        }

        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            //finally
            //{
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        private void MakeCoverPage(Excel.Worksheet xlWorkSheet)
        {
            if (xlWorkSheet == null)
                return;

            xlWorkSheet.Cells[18, 24] = m_sLineName;
            xlWorkSheet.Cells[21, 24] = m_dtFrom;
            xlWorkSheet.Cells[24, 24] = m_dtTo;
        }

        private void MakeAllInformationPage(Excel.Worksheet xlWorkSheet)
        {
            if (xlWorkSheet == null)
                return;

            bool bRangeOver = false;

            CCycleInfoS cTotalCycleInfoS = new CCycleInfoS();
            CCycleInfoS cCycleInfoS = null;

            CErrorInfoS cTotalErrorInfoS = new CErrorInfoS();
            int iTempKey = 0;

            foreach (var who in CMultiProject.PlcProcS)
            {
                cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.Key, m_dtFrom, m_dtTo);

                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                    continue;

                foreach (var who2 in cCycleInfoS)
                {
                    if (who2.Value.CycleStart == DateTime.MinValue || who2.Value.CycleEnd == DateTime.MinValue)
                        continue;

                    cTotalCycleInfoS.Add(iTempKey++, who2.Value);
                }
            }

            m_cTotalErrorInfoS = m_cReader.GetErrorInfoS(CMultiProject.ProjectID);
            List<CErrorInfo> lstTotalErrorInfo = m_cTotalErrorInfoS.GetErrorInfoS(m_dtFrom, m_dtTo).Where(x => x.IsVisible == true).ToList();

            cTotalErrorInfoS.AddRange(lstTotalErrorInfo);

            SetErrorInfoSummary(cTotalErrorInfoS);

            m_lstView = CreateCycleStatistic(cTotalCycleInfoS);

            if (m_lstView.Count != CMultiProject.PlcProcS.Count)
            {
                MessageBox.Show("Cycle Statistic Information에 대한 정보가 부족합니다.", "Warning!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            xlWorkSheet.Cells[3, 12] = m_dtFrom;
            xlWorkSheet.Cells[4, 12] = m_dtTo;

            CCycleStatisticView cView;

            for (int i = 0; i < m_lstView.Count; i++)
            {
                cView = m_lstView.ElementAt(i).Value;

                if (i < 11)
                    CreateProcessInfo(xlWorkSheet, cView, 24, i + 3);
                else
                {
                    CreateProcessInfo(xlWorkSheet, cView, 35, i - m_lstView.Count + 3);
                    bRangeOver = true;
                }
            }

            if (bRangeOver)
                xlWorkSheet.PageSetup.PrintArea = "B2:M44";
            else
                xlWorkSheet.PageSetup.PrintArea = "B2:M33";

            m_lstDateView = GetDateStatisticView();

            for (int i = 0; i < m_lstDateView.Count; i++)
                CreateDateErrorInfo(xlWorkSheet, i, m_lstDateView[i]);
        }

        private void CreateDateErrorInfo(Excel.Worksheet xlWorkSheet, int iColIndex, CDateStatisticView cView)
        {
            xlWorkSheet.Cells[48, 3 + iColIndex] = cView.DateValue;
            xlWorkSheet.Cells[49, 3 + iColIndex] = cView.ErrorCount;
        }

        private List<CDateStatisticView> GetDateStatisticView()
        {
            List<CDateStatisticView> lstView = new List<CDateStatisticView>();
            CErrorInfoS cInfoS = new CErrorInfoS();

            foreach (var who in m_lstErrorInfoSum)
            {
                who.Value.SetErrorReportValueNoRedundancy();
                cInfoS.AddRange(who.Value.lstErrorInfoNoRedundancy);
            }

            DateTime dtTotalFrom = new DateTime(m_dtFrom.Year, m_dtFrom.Month, 1);
            DateTime dtTotalTo = new DateTime(dtTotalFrom.Year, dtTotalFrom.AddMonths(1).Month, 1);

            int iDuration = dtTotalTo.Subtract(dtTotalFrom).Days;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;

            CDateStatisticView cView;
            CErrorInfoS cErrorInfoS;

            for (int i = 0; i < iDuration; i++)
            {
                cView = new CDateStatisticView();

                dtFrom = dtTotalFrom.AddDays(i);
                dtTo = dtTotalFrom.AddDays(i + 1);

                cErrorInfoS = cInfoS.GetErrorInfoS(dtFrom, dtTo);

                if (cErrorInfoS == null)
                    cView.ErrorCount = 0;
                else
                    cView.ErrorCount = cErrorInfoS.Count;

                cView.DateValue = dtFrom;
                lstView.Add(cView);
            }

            return lstView;
        }

        private void MakeProcessPage(Excel.Worksheet xlWorkSheet)
        {
            CErrorInfoS cTotalErrorInfoS = new CErrorInfoS();
            List<CErrorInfo> lstErrorInfo = null;
            string sProcessKey = CMultiProject.PlcProcS.ElementAt(m_iProcessIndex++).Key;

            if (CMultiProject.PlcProcS.Count > 11)
                xlWorkSheet.PageSetup.PrintArea = "B2:AR56";
            else
                xlWorkSheet.PageSetup.PrintArea = "B2:AR43";

            xlWorkSheet.Name = sProcessKey;

            xlWorkSheet.Cells[2, 2] = sProcessKey;


            if (m_cTotalErrorInfoS != null)
                lstErrorInfo =
                    m_cTotalErrorInfoS.GetErrorInfoS(sProcessKey, m_dtFrom, m_dtTo)
                        .Where(x => x.IsVisible == true)
                        .ToList();

            if (lstErrorInfo != null)
                cTotalErrorInfoS.AddRange(lstErrorInfo);


            CreateProcessInfo(xlWorkSheet, m_lstView[sProcessKey], 6, 7);
            if (m_lstErrorInfoSum.ContainsKey(sProcessKey))
                CreateErrorInfo(xlWorkSheet, m_lstErrorInfoSum[sProcessKey], 19, 3);
        }

        private void SetErrorInfoSummary(CErrorInfoS cErrorInfoS)
        {
            CErrorInfoSummary cErrorSum = null;
            m_lstErrorInfoSum.Clear();

            if (cErrorInfoS == null)
                return;

            foreach (CErrorInfo cInfo in cErrorInfoS)
            {
                if (m_lstErrorInfoSum.ContainsKey(cInfo.GroupKey))
                {
                    cErrorSum = m_lstErrorInfoSum[cInfo.GroupKey];

                    if (!cErrorSum.lstErrorInfo.Contains(cInfo))
                        cErrorSum.lstErrorInfo.Add(cInfo);
                }
                else
                {
                    cErrorSum = new CErrorInfoSummary();
                    cErrorSum.GroupKey = cInfo.GroupKey;
                    cErrorSum.lstErrorInfo.Add(cInfo);

                    m_lstErrorInfoSum.Add(cErrorSum.GroupKey, cErrorSum);
                }
            }
        }

        private void CreateProcessInfo(Excel.Worksheet xlWorkSheet, CCycleStatisticView cView, int iRowIndex, int iColIndex)
        {
            xlWorkSheet.Cells[iRowIndex, iColIndex] = cView.ProcessKey;
            xlWorkSheet.Cells[iRowIndex + 1, iColIndex] = cView.TotalCount;
            xlWorkSheet.Cells[iRowIndex + 2, iColIndex] = cView.ErrorCount;
            xlWorkSheet.Cells[iRowIndex + 3, iColIndex] = cView.UPH;
            xlWorkSheet.Cells[iRowIndex + 4, iColIndex] = cView.Efficiency;
            xlWorkSheet.Cells[iRowIndex + 5, iColIndex] = cView.CycleTime;
            xlWorkSheet.Cells[iRowIndex + 6, iColIndex] = cView.TactTime;
            xlWorkSheet.Cells[iRowIndex + 7, iColIndex] = cView.Min;
            xlWorkSheet.Cells[iRowIndex + 8, iColIndex] = cView.Max;
            xlWorkSheet.Cells[iRowIndex + 9, iColIndex] = cView.IdleTime;
        }

        private void CreateErrorInfo(Excel.Worksheet xlWorkSheet, CErrorInfoSummary cErrorInfoSum, int iStartRow, int iStartCol)
        {
            Dictionary<string, CErrorInfoS> DicMergedCategory = null;
            DicMergedCategory = cErrorInfoSum.GetErrorReportValue();

            bool bRangeOver = false;

            if (DicMergedCategory.Count > 26)
                bRangeOver = true;

            CErrorInfoS cInfoS;
            int iDetailErrorStartRow = 5;
            for (int i = 0; i < DicMergedCategory.Count; i++)
            {
                cInfoS = DicMergedCategory.ElementAt(i).Value;
                cInfoS.SetTimeRange();

                SetErrorRecoveryTime(cInfoS);

                xlWorkSheet.Cells[iStartRow + i, iStartCol] = i + 1;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 2] = cInfoS.RangeMaximum;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 4] = cInfoS.Count;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 6] = DicMergedCategory.ElementAt(i).Key;

                if (DicMergedCategory.ElementAt(i).Key == string.Empty)
                    SetSymbolErrorDetailInfo(xlWorkSheet, iDetailErrorStartRow, i, cInfoS);
                else
                    iDetailErrorStartRow = SetErrorDetailInfo(xlWorkSheet, iDetailErrorStartRow, i, DicMergedCategory.ElementAt(i).Key, cInfoS);
            }
        }

        private void SetSymbolErrorDetailInfo(Excel.Worksheet xlWorkSheet, int iDetailErrorStartRow, int iErrorIndex, CErrorInfoS cInfoS)
        {
            Dictionary<string, CErrorInfoS> DicMergedSymbolCategory = GetDicMergedSymbolCategory(cInfoS);
            CErrorInfoS cSymbolErrorInfoS = null;

            int iRow = iDetailErrorStartRow;

            foreach (var who in DicMergedSymbolCategory)
            {
                cSymbolErrorInfoS = who.Value;

                for (int i = 0; i < cSymbolErrorInfoS.Count; i++)
                {
                    xlWorkSheet.Cells[iRow + i, 33] = cSymbolErrorInfoS[i].ErrorTime;
                    xlWorkSheet.Cells[iRow + i, 40] = cSymbolErrorInfoS[i].RecoveryTime;
                }

                xlWorkSheet.Cells[iRow, 13] = who.Key;
                xlWorkSheet.Cells[iRow, 18] = string.Empty;

                xlWorkSheet.Range[xlWorkSheet.Cells[iRow, 13], xlWorkSheet.Cells[iRow + cSymbolErrorInfoS.Count - 1, 13]].Merge();
                xlWorkSheet.Range[xlWorkSheet.Cells[iRow, 18], xlWorkSheet.Cells[iRow + cSymbolErrorInfoS.Count - 1, 18]].Merge();

                iRow = iRow + cSymbolErrorInfoS.Count;
            }

            xlWorkSheet.Cells[iDetailErrorStartRow, 12] = iErrorIndex + 1;
            xlWorkSheet.Range[xlWorkSheet.Cells[iDetailErrorStartRow, 12], xlWorkSheet.Cells[iDetailErrorStartRow + cInfoS.Count - 1, 12]].Merge();
        }

        private Dictionary<string, CErrorInfoS> GetDicMergedSymbolCategory(CErrorInfoS cInfoS)
        {
            Dictionary<string, CErrorInfoS> DicMergedSymbolCategory = new Dictionary<string, CErrorInfoS>();
            CErrorInfoS cErrorInfoS = null;

            foreach (var who in cInfoS)
            {
                if (DicMergedSymbolCategory.ContainsKey(who.SymbolKey))
                {
                    cErrorInfoS = DicMergedSymbolCategory[who.SymbolKey];
                    cErrorInfoS.Add(who);
                }
                else
                {
                    cErrorInfoS = new CErrorInfoS();
                    cErrorInfoS.Add(who);

                    DicMergedSymbolCategory.Add(who.SymbolKey, cErrorInfoS);
                }
            }

            return DicMergedSymbolCategory;
        }

        private int SetErrorDetailInfo(Excel.Worksheet xlWorkSheet, int iDetailErrorStartRow, int iErrorIndex, string sKey, CErrorInfoS cInfoS)
        {
            List<CErrorInfo> lstInfo = null;
            CErrorInfoS cTempErrorInfoS = new CErrorInfoS();

            string sErrorMessage = string.Empty;
            int iStartRow = iDetailErrorStartRow;

            xlWorkSheet.Cells[iDetailErrorStartRow, 12] = iErrorIndex + 1;
            xlWorkSheet.Cells[iDetailErrorStartRow, 13] = string.Format("{0} : {1}", cInfoS[0].ErrorMessage, cInfoS[0].ErrorAddress);

            sErrorMessage = cInfoS[0].ErrorMessage;
            lstInfo = m_cTotalErrorInfoS.GetErrorInfoS(cInfoS[0].GroupKey, m_dtFrom, m_dtTo)
                .Where(x => x.ErrorMessage == sErrorMessage)
                .Where(x => x.DetailErrorMessage != string.Empty)
                .ToList();

            if (lstInfo != null && lstInfo.Count > 0)
            {
                lstInfo.OrderBy(x => x.ErrorTime);
                cTempErrorInfoS.AddRange(lstInfo);

                SetErrorRecoveryTime(cTempErrorInfoS);

                foreach (var who in lstInfo)
                {
                    xlWorkSheet.Cells[iDetailErrorStartRow, 22] = who.DetailErrorMessage;
                    xlWorkSheet.Cells[iDetailErrorStartRow, 29] = who.DetailErrorAddress;
                    xlWorkSheet.Cells[iDetailErrorStartRow, 32] = who.ErrorTime;
                    xlWorkSheet.Cells[iDetailErrorStartRow, 39] = who.RecoveryTime;

                    iDetailErrorStartRow++;
                }
            }
            else
            {
                foreach (var who in cInfoS)
                {
                    xlWorkSheet.Cells[iDetailErrorStartRow, 32] = who.ErrorTime;
                    xlWorkSheet.Cells[iDetailErrorStartRow, 39] = who.RecoveryTime;

                    iDetailErrorStartRow++;
                }
            }

            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 12], xlWorkSheet.Cells[iDetailErrorStartRow - 1, 12]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 13], xlWorkSheet.Cells[iDetailErrorStartRow - 1, 13]].Merge();

            return iDetailErrorStartRow;
        }

        private void SetErrorRecoveryTime(CErrorInfoS cInfoS)
        {
            CCycleInfoS cCycleInfoS = null;
            CCycleInfo cCycleInfo = null;

            foreach (var who in cInfoS)
            {
                if (who.RecoveryTime != -1)
                    continue;

                cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.GroupKey, who.CycleID + 1);

                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                    continue;

                cCycleInfo = cCycleInfoS.ElementAt(0).Value;

                who.RecoveryTime = Math.Abs(Math.Round(cCycleInfo.CycleStart.Subtract(who.ErrorTime).TotalSeconds, 2));
            }
        }

        private Dictionary<string, CCycleStatisticView> CreateCycleStatistic(CCycleInfoS cCycleInfoS)
        {
            Dictionary<string, CCycleStatisticView> lstCycleView = new Dictionary<string, CCycleStatisticView>();

            List<double> lstTact = new List<double>();
            List<double> lstCycle = new List<double>();
            List<double> lstIdle = new List<double>();
            string sProcessKey = string.Empty;

            CCycleStatisticView cStatisticView;
            CErrorInfoS cProcessErrorInfoS;

            foreach (var who in CMultiProject.PlcProcS)
            {
                sProcessKey = who.Key;

                lstTact.Clear();
                lstCycle.Clear();
                lstIdle.Clear();

                cStatisticView = new CCycleStatisticView();
                cStatisticView.ProcessKey = sProcessKey;

                foreach (CCycleInfo cInfo in cCycleInfoS.Values)
                {
                    if (cInfo.GroupKey != sProcessKey)
                        continue;

                    if (cInfo.CycleStart.Subtract(m_dtFrom).TotalSeconds < 0)
                        continue;

                    lstTact.Add(cInfo.TactTimeValue.TotalMilliseconds);
                    lstCycle.Add(cInfo.CycleTimeValue.TotalMilliseconds);
                    lstIdle.Add(cInfo.IdleTimeValue.TotalMilliseconds);
                    cStatisticView.TotalCount += 1;
                }

                CErrorInfoSummary cErrorSum = m_lstErrorInfoSum[sProcessKey];
                cErrorSum.SetErrorReportValueNoRedundancy();

                if (cErrorSum == null || cErrorSum.lstErrorInfoNoRedundancy == null)
                    cStatisticView.ErrorCount = 0;
                else
                    cStatisticView.ErrorCount = cErrorSum.lstErrorInfoNoRedundancy.Count;


                if (lstCycle.Count == 0)
                    continue;

                double dAvrTact = CStatics.Mean(lstTact);
                double dAvrCycle = CStatics.Mean(lstCycle);
                double dAvrIdle = CStatics.Mean(lstIdle);

                cStatisticView.CycleTime = dAvrCycle / 1000;
                cStatisticView.TactTime = dAvrTact / 1000;
                cStatisticView.IdleTime = dAvrIdle / 1000;
                cStatisticView.Min = lstCycle.Min() / 1000;
                cStatisticView.Max = lstCycle.Max() / 1000;
                cStatisticView.UPH = 3600000 / dAvrCycle;
                cStatisticView.Efficiency = (dAvrTact / dAvrCycle) * 100;

                lstCycleView.Add(cStatisticView.ProcessKey, cStatisticView);
            }

            return lstCycleView;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtLine.Text == "")
            {
                MessageBox.Show("Line명을 입력해 주세요");
                return;
            }

            VerifyInformation();

            if (!m_bVerified)
                return;

            FolderBrowserDialog folder = new FolderBrowserDialog();

            if (m_sSavePath != string.Empty)
                folder.SelectedPath = m_sSavePath;

            if (folder.ShowDialog() != DialogResult.OK)
                return;

            m_sSavePath = folder.SelectedPath;
            m_sLineName = txtLine.Text;
            m_dtFrom = (DateTime)dptkFrom.EditValue;
            m_dtTo = (DateTime)dptkTo.EditValue;

            if (m_dtTo < m_dtFrom)
            {
                MessageBox.Show("기간 설정을 다시해주세요.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SplashScreenManager.ShowDefaultWaitForm();
            {
                ExportPLCMonitoringInfo();
            }
            SplashScreenManager.CloseDefaultWaitForm();

            this.Close();
        }

        private void FrmReportExporter_Load(object sender, EventArgs e)
        {
            dptkFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dptkTo.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
        }

    }

    public class CDateStatisticView
    {
        private DateTime m_dtDate = DateTime.MinValue;
        int m_iErrorCount = 0;

        public DateTime DateValue
        {
            get { return m_dtDate ; }
            set { m_dtDate = value; }
        }

        public string DateString
        {
            get { return m_dtDate.Date.ToString(); }
        }

        public int ErrorCount
        {
            get { return m_iErrorCount; }
            set { m_iErrorCount = value; }
        }

    }

    public partial class CCycleStatisticView
    {
        private double m_dCycle = 0;
        private double m_dTact = 0;
        private double m_dIdle = 0;
        private double m_dMin = 0;
        private double m_dMax = 0;
        private double m_dUPH = 0;
        private double m_dEfficiency = 0;
        private int m_iTotalCount = 0;
        private int m_iErrorCount = 0;
        private string m_sProcessKey = string.Empty;

        public string ProcessKey
        {
            get { return m_sProcessKey; }
            set { m_sProcessKey = value; }
        }

        public int TotalCount
        {
            get { return m_iTotalCount; }
            set { m_iTotalCount = value; }
        }

        public int ErrorCount
        {
            get { return m_iErrorCount; }
            set { m_iErrorCount = value; }
        }

        public double CycleTime
        {
            get { return Math.Round(m_dCycle, 2); }
            set { m_dCycle = value; }
        }

        public double TactTime
        {
            get { return Math.Round(m_dTact, 2); }
            set { m_dTact = value; }
        }

        public double IdleTime
        {
            get { return Math.Round(m_dIdle, 2); }
            set { m_dIdle = value; }
        }

        public double Min
        {
            get { return Math.Round(m_dMin, 2); }
            set { m_dMin = value; }
        }

        public double Max
        {
            get { return Math.Round(m_dMax, 2); }
            set { m_dMax = value; }
        }

        public double UPH
        {
            get { return Math.Round(m_dUPH, 2); }
            set { m_dUPH = value; }
        }

        public double Efficiency
        {
            get { return Math.Round(m_dEfficiency, 2); }
            set { m_dEfficiency = value; }
        }
    }
}