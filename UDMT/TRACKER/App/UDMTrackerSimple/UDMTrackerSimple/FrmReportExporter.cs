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
using System.Text.RegularExpressions;
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

namespace UDMTrackerSimple
{
    public partial class FrmReportExporter : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;
        private string m_sLineName = string.Empty;
        private string m_sSavePath = string.Empty;
        private string m_sAutoSavePath = Application.StartupPath + "\\TrackerReportBackup";

        private bool m_bAuto = false;
        private bool m_bVerified = true;

        private CMySqlLogReader m_cReader = null;

        private Dictionary<string, CCycleStatisticView> m_lstView = new Dictionary<string, CCycleStatisticView>();
        private Dictionary<string, CErrorInfoSummary> m_lstErrorInfoSum = new Dictionary<string, CErrorInfoSummary>();
        private List<CDateStatisticView> m_lstDateView = new List<CDateStatisticView>();

        private CErrorInfoS m_cTotalErrorInfoS = null;

        private int m_iProcessIndex = 0;

        #endregion

        #region Initialize/Dispose

        public FrmReportExporter()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;
        }

        #endregion

        #region Properties

        public bool IsAuto
        {
            get { return m_bAuto; }
            set { m_bAuto = value; }
        }

        #endregion

        #region Private Methods

        private void VerifyInformation()
        {
            if (CMultiProject.PlcProcS == null || CMultiProject.PlcProcS.Count == 0)
            {
                MessageBox.Show("Process가 정의되지 않았습니다.\r\nReport를 만들 수 없습니다.", "Warning!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                m_bVerified = false;
                return;
            }

            bool bOK = true;

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

            if (!bOK)
            {
                XtraMessageBox.Show("이상 감지기능 비가동 시간 설정이 잘못되었습니다.\r\n시간 설정을 다시 진행해주세요!!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                m_bVerified = false;
            }
        }

        private bool VerifyParameter()
        {
            if (CMultiProject.ProjectID == "00000000" || CMultiProject.ProjectID == "")
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ExportPLCMonitoringInfo()
        {
            bool bOK = false;

            if (!m_bVerified)
                return false;

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
                    return false;

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

                if (Regex.IsMatch(m_sLineName, @"[/?\*\[\]\\]"))
                    m_sLineName = Regex.Replace(m_sLineName, @"[/?\*\[\]\\]", "_");

                string sSavePath = m_sSavePath + "\\생산이력리포트_" + m_sLineName + "_" + m_dtFrom.ToString("yyyyMMdd") + "_" +
                                   m_dtTo.ToString("yyyyMMdd");

                iStep = 8;

                // xlWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, sSavePath);
                xlWorkBook.SaveAs(sSavePath);
                //MessageBox.Show("Report File Save OK!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bOK = true;

                xlWorkBook.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
            }
            catch (System.Exception ex)
            {
                string sMessage = string.Empty;

                switch (iStep)
                {
                    case 4 :
                        sMessage = "해당 컴퓨터에 설치된 Microsoft Excel에 접근할 수 없습니다.";
                        break;
                    case 5 :
                        sMessage = "UDM Tracker 설치 파일 경로에 생산 이력 리포트 템플릿이 존재하지 않습니다.";
                        break;
                    case 6:
                        sMessage = "Microsoft Excel의 WorkSheet를 Open하는데 문제가 있습니다.";
                        break;
                    case 7:
                        sMessage = "생산 이력 리포트의 내용을 작성하는데 문제가 있습니다.";
                        break;
                    case 8:
                        sMessage = "작성된 생산 이력 리포트를 저장하는데 문제가 있습니다.\r\n정품이 아닌 Microsoft Excel의 경우 저장이 되지 않을 수 있습니다.";
                        break;
                }

                CMultiProject.SystemLog.WriteLog("Export Report", "Report File Save Fail!!" + sMessage);
                //MessageBox.Show("Report File Save Fail! Step Num : " + sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                ReleaseExcelObject(xlWorkSheets);
                ReleaseExcelObject(xlWorkBook);
                ReleaseExcelObject(xlWorkBooks);
                ReleaseExcelObject(xlApp);

                m_lstView.Clear();
                m_lstErrorInfoSum.Clear();
                m_lstDateView.Clear();

                if(m_cTotalErrorInfoS != null)
                    m_cTotalErrorInfoS.Clear();
            }

            return bOK;
        }

        private bool ExportPLCCycleInfo()
        {
            bool bOK = false;

            if (!m_bVerified)
                return false;

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

                string sResourcePath = Path.Combine(Application.StartupPath, "PLC 모니터링 생산 리포트 Template_사이클");

                if (!File.Exists(sResourcePath + ".xlsx"))
                    MessageBox.Show("Template File이 존재하지 않음", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                iStep = 6;

                xlWorkBooks = xlApp.Workbooks;
                xlWorkBook = xlWorkBooks.Open(sResourcePath, 0, true, 5, "", "", false, Excel.XlPlatform.xlWindows,
                    "",
                    true, false, 0, true, false, false);

                iStep = 7;

                if (xlWorkBook == null)
                    return false;

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
                        MakeProcessCyclePage(sheet);

                    ReleaseExcelObject(sheet);
                }

                if (Regex.IsMatch(m_sLineName, @"[/?\*\[\]\\]"))
                    m_sLineName = Regex.Replace(m_sLineName, @"[/?\*\[\]\\]", "_");

                string sSavePath = m_sSavePath + "\\생산이력리포트_" + m_sLineName + "_" + m_dtFrom.ToString("yyyyMMdd") + "_" +
                                   m_dtTo.ToString("yyyyMMdd");

                iStep = 8;

                xlWorkBook.SaveAs(sSavePath);

                bOK = true;

                xlWorkBook.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
            }
            catch (System.Exception ex)
            {
                string sMessage = string.Empty;

                switch (iStep)
                {
                    case 4:
                        sMessage = "해당 컴퓨터에 설치된 Microsoft Excel에 접근할 수 없습니다.";
                        break;
                    case 5:
                        sMessage = "UDM Tracker 설치 파일 경로에 생산 이력 리포트 템플릿이 존재하지 않습니다.";
                        break;
                    case 6:
                        sMessage = "Microsoft Excel의 WorkSheet를 Open하는데 문제가 있습니다.";
                        break;
                    case 7:
                        sMessage = "생산 이력 리포트의 내용을 작성하는데 문제가 있습니다.";
                        break;
                    case 8:
                        sMessage = "작성된 생산 이력 리포트를 저장하는데 문제가 있습니다.\r\n정품이 아닌 Microsoft Excel의 경우 저장이 되지 않을 수 있습니다.";
                        break;
                }

                CMultiProject.SystemLog.WriteLog("Export Report", "Report File Save Fail!!" + sMessage);
                //MessageBox.Show("Report File Save Fail! Step Num : " + sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ex.Data.Clear();
                bOK = false;
            }
            finally
            {
                ReleaseExcelObject(xlWorkSheets);
                ReleaseExcelObject(xlWorkBook);
                ReleaseExcelObject(xlWorkBooks);
                ReleaseExcelObject(xlApp);

                m_lstView.Clear();
                m_lstErrorInfoSum.Clear();
                m_lstDateView.Clear();

                if (m_cTotalErrorInfoS != null)
                    m_cTotalErrorInfoS.Clear();
            }

            return bOK;
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

                    if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(who2.Value.CycleStart))
                        continue;

                    cTotalCycleInfoS.Add(iTempKey++, who2.Value);
                }
            }

            if(cCycleInfoS != null)
                cCycleInfoS.Clear();

            cCycleInfoS = null;

            m_cTotalErrorInfoS = m_cReader.GetErrorInfoS(CMultiProject.ProjectID);

            if (m_cTotalErrorInfoS != null)
            {
                foreach (CErrorInfo cInfo in m_cTotalErrorInfoS)
                {
                    if (cInfo.ErrorTime < m_dtFrom || cInfo.ErrorTime > m_dtTo) continue;
                    if (cInfo.IsVisible == false && !cInfo.ErrorType.Equals("CycleOver")) continue;
                    if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(cInfo.ErrorTime)) continue;

                    cTotalErrorInfoS.Add(cInfo);
                }
            }

            SetErrorInfoSummary(cTotalErrorInfoS);
            m_lstView = CreateCycleStatistic(cTotalCycleInfoS);

            xlWorkSheet.Cells[3, 15] = m_dtFrom;
            xlWorkSheet.Cells[4, 15] = m_dtTo;

            CCycleStatisticView cView;
            int iRowIndex = 0;
            int iColIndex = 0;
            for (int i = 0; i < m_lstView.Count; i++)
            {
                cView = m_lstView.ElementAt(i).Value;

                if (iRowIndex != i / 14)
                    iRowIndex = i / 14;

                if (i < 14)
                    CreateProcessInfo(xlWorkSheet, cView, 24, i + 3);
                else
                {
                    if (iColIndex == 14)
                        iColIndex = 0;

                    CreateProcessInfo(xlWorkSheet, cView, 24 + (iRowIndex * 12), 3 + iColIndex++);
                }
            }

            m_lstDateView = GetDateStatisticView();

            for (int i = 0; i < m_lstDateView.Count; i++)
                CreateDateErrorInfo(xlWorkSheet, i, m_lstDateView[i]);

            cTotalCycleInfoS.Clear();
            cTotalErrorInfoS.Clear();
        }

        private void CreateDateErrorInfo(Excel.Worksheet xlWorkSheet, int iColIndex, CDateStatisticView cView)
        {
            xlWorkSheet.Cells[120, 1 + iColIndex] = cView.DateValue;
            xlWorkSheet.Cells[121, 1 + iColIndex] = cView.ErrorCount;
        }

        private List<CDateStatisticView> GetDateStatisticView()
        {
            List<CDateStatisticView> lstView = new List<CDateStatisticView>();
            CErrorInfoS cInfoS = new CErrorInfoS();

            foreach (var who in m_lstErrorInfoSum)
            {
                cInfoS.AddRange(who.Value.lstErrorInfoNoRedundancy);
                cInfoS.AddRange(who.Value.lstDelayInfoNoRedundancy);
            }

            //DateTime dtTotalFrom = new DateTime(m_dtFrom.Year, m_dtFrom.Month, 1);
            //DateTime dtTotalTo = new DateTime(dtTotalFrom.Year, dtTotalFrom.AddMonths(1).Month, 1);

            int iDuration = m_dtTo.Subtract(m_dtFrom).Days;

            DateTime dtFrom = DateTime.MinValue;
            DateTime dtTo = DateTime.MinValue;

            CDateStatisticView cView;
            CErrorInfoS cErrorInfoS;

            for (int i = 0; i < iDuration; i++)
            {
                cView = new CDateStatisticView();

                dtFrom = m_dtFrom.AddDays(i);
                dtTo = m_dtFrom.AddDays(i + 1);

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
            List<CErrorInfo> lstErrorInfo = null;
            string sProcessKey = CMultiProject.PlcProcS.ElementAt(m_iProcessIndex++).Key;

            if (Regex.IsMatch(sProcessKey, @"[/?\*\[\]\\]"))
                xlWorkSheet.Name = Regex.Replace(sProcessKey, @"[/?\*\[\]\\]", "_");
            else
                xlWorkSheet.Name = sProcessKey;

            xlWorkSheet.Cells[2, 2] = sProcessKey;

            if (m_cTotalErrorInfoS != null)
                lstErrorInfo =
                    m_cTotalErrorInfoS.GetErrorInfoS(sProcessKey, m_dtFrom, m_dtTo)
                        .Where(x => x.IsVisible == true || x.ErrorMessage.Contains("Cycle Over"))
                        .ToList();

            if (lstErrorInfo == null || lstErrorInfo.Count == 0)
            {
                xlWorkSheet.Delete();
                return;
            }

            CreateProcessInfo(xlWorkSheet, m_lstView[sProcessKey], 6, 7);
            if (m_lstErrorInfoSum.ContainsKey(sProcessKey))
                CreateErrorInfo(xlWorkSheet, m_lstErrorInfoSum[sProcessKey], 20, 3);
        }

        private void MakeProcessCyclePage(Excel.Worksheet xlWorkSheet)
        {
            List<CErrorInfo> lstErrorInfo = null;
            string sProcessKey = CMultiProject.PlcProcS.ElementAt(m_iProcessIndex++).Key;

            if (Regex.IsMatch(sProcessKey, @"[/?\*\[\]\\]"))
                xlWorkSheet.Name = Regex.Replace(sProcessKey, @"[/?\*\[\]\\]", "_");
            else
                xlWorkSheet.Name = sProcessKey;

            CreateProcessInfo(xlWorkSheet, m_lstView[sProcessKey], 1, 3);

            CCycleInfoS cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, sProcessKey, m_dtFrom, m_dtTo);

            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
            {
                xlWorkSheet.Delete();
                return;
            }

            int iRowIndex = 2;
            foreach (CCycleInfo cInfo in cCycleInfoS.Values)
            {
                xlWorkSheet.Cells[iRowIndex, 6] = cInfo.GroupKey;
                xlWorkSheet.Cells[iRowIndex, 7] = cInfo.CycleType.ToString();
                xlWorkSheet.Cells[iRowIndex, 8] = cInfo.CycleStart;
                xlWorkSheet.Cells[iRowIndex, 9] = cInfo.CycleEnd;
                xlWorkSheet.Cells[iRowIndex, 10] = cInfo.CycleTime;
                xlWorkSheet.Cells[iRowIndex, 11] = cInfo.TactTime;
                xlWorkSheet.Cells[iRowIndex, 12] = cInfo.IdleTime;

                iRowIndex++;
            }

            xlWorkSheet.Columns["F:L"].AutoFit();

            cCycleInfoS.Clear();
            cCycleInfoS = null;
        }

    
        private void MakeProcessFlowGanttChart(Excel.Worksheet xlWorkSheet, string sProcessKey)
        {
            DateTime dtStart = DateTime.MinValue;

            DateTime dtOnTime = DateTime.MinValue;
            DateTime dtOffTime = DateTime.MinValue;
            double dDuration = 0;
            double dStartTime = 0;
            string sStartCondition = string.Empty;
            bool bAddCycleEndLog = false;

            CPlcProc cProcess = CMultiProject.PlcProcS[sProcessKey];
            CTimeLogS cLogS = m_cReader.GetTimeLogS(cProcess.KeySymbolS.Keys.ToList(), cProcess.ChartStartTime,
                cProcess.ChartEndTime);

            if (cLogS == null || cLogS.Count == 0)
                return;

            if (cProcess.CycleEndConditionS.Count == 1 && cProcess.CycleEndConditionS.First().TargetValue == 1)
                bAddCycleEndLog = true;

            dtStart = cProcess.CycleStartTimeLine;

            CKeySymbol cSymbol;
            List<CTimeLog> lstLog;
            int iRowCount = 0;

            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                dtOnTime = DateTime.MinValue;
                dtOffTime = DateTime.MinValue;

                cSymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                lstLog = cLogS.Where(x => x.Key == cSymbol.Tag.Key).Where(b => b.Time >= dtStart).ToList();

                if (lstLog == null || lstLog.Count < 2)
                {
                    if (bAddCycleEndLog && cSymbol.Tag.Key == cProcess.CycleEndConditionS.First().Key)
                    {
                        CTimeLogS cTempLogS = m_cReader.GetTimeLogS(cSymbol.Tag.Key, 0, lstLog[0].Time, cProcess.ChartEndTime);
                        lstLog.Add(cTempLogS.GetFirstLog(cSymbol.Tag.Key, lstLog[0].Time));
                    }
                    else
                        continue;
                }

                bool bOn = false;

                foreach (CTimeLog cLog in lstLog)
                {
                    if (cLog.Value == 1)
                    {
                        dtOnTime = cLog.Time;
                        bOn = true;
                    }
                    else if (cLog.Value == 0 && bOn)
                        dtOffTime = cLog.Time;

                    if (dtOnTime != DateTime.MinValue && dtOffTime != DateTime.MinValue)
                        break;
                }

                if (dtOnTime == DateTime.MinValue || dtOffTime == DateTime.MinValue)
                    continue;

                dDuration = dtOffTime.Subtract(dtOnTime).TotalSeconds;
                dStartTime = dtOnTime.Subtract(dtStart).TotalSeconds;

                xlWorkSheet.Cells[iRowCount + 4, 14] = iRowCount + 1;
                xlWorkSheet.Cells[iRowCount + 4, 15] = cSymbol.Tag.Address;
                xlWorkSheet.Cells[iRowCount + 4, 17] = cSymbol.Tag.Description;
                xlWorkSheet.Cells[iRowCount + 4, 23] = Math.Round(dDuration, 2);
                xlWorkSheet.Cells[iRowCount + 4, 24] = Math.Round(dStartTime, 2);
                xlWorkSheet.Cells[iRowCount + 4, 25] = Math.Round(dStartTime + dDuration, 2);

                iRowCount++;
            }
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
            xlWorkSheet.Cells[iRowIndex + 3, iColIndex] = cView.DelayCount;
            xlWorkSheet.Cells[iRowIndex + 4, iColIndex] = cView.UPH;
            xlWorkSheet.Cells[iRowIndex + 5, iColIndex] = cView.Efficiency;
            xlWorkSheet.Cells[iRowIndex + 6, iColIndex] = cView.CycleTime;
            xlWorkSheet.Cells[iRowIndex + 7, iColIndex] = cView.TactTime;
            xlWorkSheet.Cells[iRowIndex + 8, iColIndex] = cView.Min;
            xlWorkSheet.Cells[iRowIndex + 9, iColIndex] = cView.Max;
            xlWorkSheet.Cells[iRowIndex + 10, iColIndex] = cView.IdleTime;
        }

        private void CreateErrorInfo(Excel.Worksheet xlWorkSheet, CErrorInfoSummary cErrorInfoSum, int iStartRow, int iStartCol)
        {
            Dictionary<string, CErrorInfoS> DicMergedCategory = null;
            DicMergedCategory = cErrorInfoSum.GetErrorReportValue();

            CErrorInfoS cInfoS;
            int iDetailErrorStartRow = 5;
            int iDetailDelayStartRow = 5;
            CTimeLogS cLogS = null;

            if (CMultiProject.PlcProcS.ContainsKey(cErrorInfoSum.GroupKey))
            {
                if (CMultiProject.PlcProcS[cErrorInfoSum.GroupKey].CycleCheckTag != null)
                    cLogS = m_cReader.GetTimeLogS(CMultiProject.PlcProcS[cErrorInfoSum.GroupKey].CycleCheckTag.Key, m_dtFrom,
                    m_dtTo);
            }

            bool bCycleOver = false;
            for (int i = 0; i < DicMergedCategory.Count; i++)
            {
                cInfoS = DicMergedCategory.ElementAt(i).Value;
                cInfoS.SetTimeRange();

                if (!cInfoS.First().ErrorType.Equals("CycleOver"))
                    bCycleOver = false;
                else
                {
                    bCycleOver = true;

                    xlWorkSheet.Range[
                        xlWorkSheet.Cells[iStartRow + i, iStartCol], xlWorkSheet.Cells[iStartRow + i, iStartCol + 6]]
                        .Interior.Color = ColorTranslator.ToOle(Color.FromArgb(197, 217, 241));
                }

                SetErrorRecoveryTime(cLogS, cInfoS);

                xlWorkSheet.Cells[iStartRow + i, iStartCol] = i + 1;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 2] = cInfoS.RangeMaximum;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 4] = cInfoS.Count;
                xlWorkSheet.Cells[iStartRow + i, iStartCol + 6] = DicMergedCategory.ElementAt(i).Key;

                if (!bCycleOver)
                {
                    if (DicMergedCategory.ElementAt(i).Key == string.Empty)
                        SetSymbolErrorDetailInfo(xlWorkSheet, iDetailErrorStartRow, i, cInfoS);
                    else
                        iDetailErrorStartRow = SetErrorDetailInfo(xlWorkSheet, iDetailErrorStartRow, i, cInfoS, cLogS);
                }
                else
                {
                    if (DicMergedCategory.ElementAt(i).Key != string.Empty)
                        iDetailDelayStartRow = SetDelayDetailInfo(xlWorkSheet, iDetailDelayStartRow, i, cInfoS);
                }
            }

            if (cLogS != null)
            {
                cLogS.Clear();
                cLogS = null;
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

        private int SetErrorDetailInfo(Excel.Worksheet xlWorkSheet, int iDetailErrorStartRow, int iErrorIndex, CErrorInfoS cInfoS, CTimeLogS cLogS)
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
                .Where(x => x.IsVisible == true)
                .ToList();

            if (lstInfo != null && lstInfo.Count > 0)
            {
                lstInfo.OrderBy(x => x.ErrorTime);
                cTempErrorInfoS.AddRange(lstInfo);

                SetErrorRecoveryTime(cLogS, cTempErrorInfoS);

                foreach (var who in lstInfo)
                {
                    if (who.ErrorTime < m_dtFrom || who.ErrorTime > m_dtTo) continue;
                    if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(who.ErrorTime)) continue;

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
                    if (who.ErrorTime < m_dtFrom || who.ErrorTime > m_dtTo) continue;
                    if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(who.ErrorTime)) continue;

                    xlWorkSheet.Cells[iDetailErrorStartRow, 32] = who.ErrorTime;
                    xlWorkSheet.Cells[iDetailErrorStartRow, 39] = who.RecoveryTime;

                    iDetailErrorStartRow++;
                }
            }

            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 12], xlWorkSheet.Cells[iDetailErrorStartRow - 1, 12]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 13], xlWorkSheet.Cells[iDetailErrorStartRow - 1, 13]].Merge();

            if (cTempErrorInfoS.Count > 0)
                cTempErrorInfoS.Clear();

            cTempErrorInfoS = null;

            return iDetailErrorStartRow;
        }

        private int SetDelayDetailInfo(Excel.Worksheet xlWorkSheet, int iDetailDelayStartRow, int iErrorIndex, CErrorInfoS cInfoS)
        {
            List<CErrorInfo> lstInfo = null;
            string sErrorMessage = string.Empty;
            int iStartRow = iDetailDelayStartRow;

            xlWorkSheet.Cells[iDetailDelayStartRow, 45] = iErrorIndex + 1;
            xlWorkSheet.Cells[iDetailDelayStartRow, 46] = string.Format("{0} : {1}", cInfoS[0].DetailErrorMessage, cInfoS[0].DetailErrorAddress);

            sErrorMessage = cInfoS[0].DetailErrorMessage;
            lstInfo = m_cTotalErrorInfoS.GetErrorInfoS(cInfoS[0].GroupKey, m_dtFrom, m_dtTo)
                .Where(x => x.DetailErrorMessage == sErrorMessage)
                .ToList();

            if (lstInfo != null && lstInfo.Count > 0)
            {
                lstInfo.OrderBy(x => x.ErrorTime);

                foreach (var who in lstInfo)
                {
                    if (who.ErrorTime < m_dtFrom || who.ErrorTime > m_dtTo) continue;
                    if (CMultiProject.NonDetectTimeS != null && CMultiProject.NonDetectTimeS.IsNonDetectTime(who.ErrorTime)) continue;

                    xlWorkSheet.Cells[iDetailDelayStartRow, 53] = who.ErrorTime;
                    xlWorkSheet.Cells[iDetailDelayStartRow, 60] = who.RecoveryTime;

                    iDetailDelayStartRow++;
                }
            }

            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 45], xlWorkSheet.Cells[iDetailDelayStartRow - 1, 45]].Merge();
            xlWorkSheet.Range[xlWorkSheet.Cells[iStartRow, 46], xlWorkSheet.Cells[iDetailDelayStartRow - 1, 46]].Merge();

            return iDetailDelayStartRow;
        }


        private void SetErrorRecoveryTime(CTimeLogS cLogS, CErrorInfoS cInfoS)
        {
            CCycleInfoS cCycleInfoS = null;
            CCycleInfo cCycleInfo = null;
            CTimeLog cLog = null;

            CPlcProc cProcess = CMultiProject.PlcProcS[cInfoS.First().GroupKey];

            //if (cProcess.IsErrorMonitoring)
            //{
            if (cLogS == null || cLogS.Count == 0)
                return;

            if (cProcess.CycleCheckTag == null)
                return;

            string sKey = cProcess.CycleCheckTag.Key;

            foreach (var who in cInfoS)
            {
                if (who.RecoveryTime != -1)
                    continue;

                cLog = null;
                cLog = cLogS.GetFirstLog(sKey, who.ErrorTime, 1);

                if (cLog != null)
                    who.RecoveryTime = Math.Abs(Math.Round(cLog.Time.Subtract(who.ErrorTime).TotalSeconds, 2));
            }

            //cLogS.Clear();
            //cLogS = null;
            //}
            //else
            //{
            //    foreach (var who in cInfoS)
            //    {
            //        if (who.RecoveryTime != -1)
            //            continue;

            //        cCycleInfoS = m_cReader.GetCycleInfoS(CMultiProject.ProjectID, who.GroupKey, who.CycleID + 1);

            //        if (cCycleInfoS == null || cCycleInfoS.Count == 0)
            //            continue;

            //        cCycleInfo = cCycleInfoS.ElementAt(0).Value;

            //        who.RecoveryTime = Math.Abs(Math.Round(cCycleInfo.CycleStart.Subtract(who.ErrorTime).TotalSeconds, 2));
            //    }
            //}
        }

        private Dictionary<string, CCycleStatisticView> CreateCycleStatistic(CCycleInfoS cCycleInfoS)
        {
            Dictionary<string, CCycleStatisticView> lstCycleView = new Dictionary<string, CCycleStatisticView>();

            List<double> lstTact = new List<double>();
            List<double> lstCycle = new List<double>();
            List<double> lstIdle = new List<double>();
            string sProcessKey = string.Empty;

            CCycleStatisticView cStatisticView;

            foreach (var who in CMultiProject.PlcProcS)
            {
                sProcessKey = who.Key;

                lstTact.Clear();
                lstCycle.Clear();
                lstIdle.Clear();

                cStatisticView = new CCycleStatisticView();
                cStatisticView.ProcessKey = sProcessKey;

                List<CCycleInfo> lstCycleInfo = cCycleInfoS.Values.Where(x => x.GroupKey == sProcessKey).ToList();

                if (lstCycleInfo != null)
                {
                    foreach (CCycleInfo cInfo in lstCycleInfo)
                    {
                        if (cInfo.CycleStart.Subtract(m_dtFrom).TotalSeconds < 0)
                            continue;

                        cStatisticView.TotalCount += 1;

                        if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                            continue;
                        if (cInfo.CycleTimeValue.TotalMilliseconds > who.Value.MaxTactTime) continue;

                        lstTact.Add(cInfo.TactTimeValue.TotalMilliseconds);
                        lstCycle.Add(cInfo.CycleTimeValue.TotalMilliseconds);
                        lstIdle.Add(cInfo.IdleTimeValue.TotalMilliseconds);
                    }
                }

                lstCycleInfo = null;

                CErrorInfoSummary cErrorSum = null;
                if (m_lstErrorInfoSum.ContainsKey(sProcessKey))
                {
                    cErrorSum = m_lstErrorInfoSum[sProcessKey];
                    cErrorSum.SetErrorReportValueNoRedundancy();
                }

                if (cErrorSum == null || cErrorSum.lstErrorInfoNoRedundancy == null)
                {
                    cStatisticView.ErrorCount = 0;
                    cStatisticView.DelayCount = 0;
                }
                else
                {
                    cStatisticView.ErrorCount = cErrorSum.lstErrorInfoNoRedundancy.Count;
                    cStatisticView.DelayCount = cErrorSum.lstDelayInfoNoRedundancy.Count;
                }


                if (lstCycle.Count != 0)
                {

                    double dAvrTact = CStatics.Mean(lstTact);
                    double dAvrCycle = CStatics.Mean(lstCycle);
                    double dAvrIdle = CStatics.Mean(lstIdle);

                    cStatisticView.CycleTime = dAvrCycle / 1000;
                    cStatisticView.TactTime = dAvrTact / 1000;
                    cStatisticView.IdleTime = dAvrIdle / 1000;
                    cStatisticView.Min = lstTact.Min() / 1000;
                    cStatisticView.Max = lstTact.Max() / 1000;
                    cStatisticView.UPH = 3600000 / dAvrCycle;
                    cStatisticView.Efficiency = (dAvrTact / dAvrCycle) * 100;
                }

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

            bool bOK = false;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                bOK = ExportPLCMonitoringInfo();
            }
            SplashScreenManager.CloseDefaultWaitForm();

            if(bOK)
                MessageBox.Show("Report File Save OK!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Report File Save Fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void FrmReportExporter_Load(object sender, EventArgs e)
        {

            bool bOK = VerifyParameter();
            if (!bOK)
                this.Close();

            dptkFrom.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dptkTo.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);

            if (CMultiProject.NonDetectTimeS == null)
                CMultiProject.NonDetectTimeS = new CNonDetectTimeS();

            grdNonDetect.DataSource = CMultiProject.NonDetectTimeS;
            grdNonDetect.RefreshDataSource();
        }

        #endregion

        #region Public Method
        public void AutoExportPLCMonitoringInfo()
        {
            if (!m_bVerified) return;
            if (!m_bAuto) return;

            SplashScreenManager.ShowDefaultWaitForm();
            {
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
                        return ;

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
                    //MessageBox.Show("Report File Save OK!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();
                }
                catch (System.Exception ex)
                {
                    string sMessage = string.Empty;

                    switch (iStep)
                    {
                        case 4:
                            sMessage = "해당 컴퓨터에 설치된 Microsoft Excel에 접근할 수 없습니다.";
                            break;
                        case 5:
                            sMessage = "UDM Tracker 설치 파일 경로에 생산 이력 리포트 템플릿이 존재하지 않습니다.";
                            break;
                        case 6:
                            sMessage = "Microsoft Excel의 WorkSheet를 Open하는데 문제가 있습니다.";
                            break;
                        case 7:
                            sMessage = "생산 이력 리포트의 내용을 작성하는데 문제가 있습니다.";
                            break;
                        case 8:
                            sMessage = "작성된 생산 이력 리포트를 저장하는데 문제가 있습니다.\r\n정품이 아닌 Microsoft Excel의 경우 저장이 되지 않을 수 있습니다.";
                            break;
                    }

                    CMultiProject.SystemLog.WriteLog("Export Report", "Report File Save Fail!!" + sMessage);
                    XtraMessageBox.Show(sMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ex.Data.Clear();
                }
                finally
                {
                    ReleaseExcelObject(xlWorkSheets);
                    ReleaseExcelObject(xlWorkBook);
                    ReleaseExcelObject(xlWorkBooks);
                    ReleaseExcelObject(xlApp);

                    m_lstView.Clear();
                    m_lstErrorInfoSum.Clear();
                    m_lstDateView.Clear();

                    if (m_cTotalErrorInfoS != null)
                        m_cTotalErrorInfoS.Clear();
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }


        #endregion

        private void grvNonDetect_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
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

                if (obj == null || obj.GetType() != typeof(CNonDetectTime))
                    return;

                CNonDetectTime cNonDetect = (CNonDetectTime)obj;

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
            this.Close();
        }

        private void FrmReportExporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bool bOK = true;

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

                if (!bOK)
                {
                    if (
                        XtraMessageBox.Show("이상 감지기능 비가동 시간 설정이 잘못되었습니다.\r\n그래도 창을 닫으시겠습니까?", "Error", MessageBoxButtons.YesNo,
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

        private void btnCycleExport_Click(object sender, EventArgs e)
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

            bool bOK = false;

            SplashScreenManager.ShowDefaultWaitForm();
            {
                bOK = ExportPLCCycleInfo();
            }
            SplashScreenManager.CloseDefaultWaitForm();

            if (bOK)
                MessageBox.Show("Report File Save OK!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Report File Save Fail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }
    }

    public class CDateStatisticView
    {
        private DateTime m_dtDate = DateTime.MinValue;
        int m_iErrorCount = 0;

        public DateTime DateValue
        {
            get { return m_dtDate; }
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
}