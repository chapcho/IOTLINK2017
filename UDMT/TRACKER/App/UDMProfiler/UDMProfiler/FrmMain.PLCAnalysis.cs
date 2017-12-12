using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraBars;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

using UDM.Common;
using UDM.Log;
using UDM.Log.Csv;
using UDMProfiler.Csv;


namespace UDMProfiler
{
    public partial class FrmMain
    {

        #region Member Variables

        protected Dictionary<EMCollectModeType, CLogHistoryInfo> m_dicLogHistoryByMode = new Dictionary<EMCollectModeType, CLogHistoryInfo>();
        protected CLogHistoryInfoS m_cLogHistoryInfoS = new CLogHistoryInfoS();

        #endregion

        #region Private Methods

        private bool OpenCSVLogFiles(string[] saLogFile)
        {
            bool bOK = false;

            if (saLogFile != null && saLogFile.Length > 0)
            {
                bOK = CheckLogFiles(saLogFile, "_Normal_");
                if (bOK)
                {
                    bOK = OpenCollectModeLogFile(saLogFile, EMCollectModeType.Normal);
                    if (!bOK)
                    {
                        CProjectManager.SystemLog.WriteLog("LogOpen", "Normal Log Open Fail");
                        return false;
                    }
                }

                bOK = CheckLogFiles(saLogFile, "_Output_");
                if (bOK)
                {
                    bOK = OpenCollectModeLogFile(saLogFile, EMCollectModeType.Output);
                    if (!bOK)
                    {
                        CProjectManager.SystemLog.WriteLog("LogOpen", "Output Log Open Fail");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool OpenCollectModeLogFile(string[] saLogFile, EMCollectModeType emCollectMode)
        {
            CCsvProfilerLogReader cReader = new CCsvProfilerLogReader();
            CTimeLogS cLogS = new CTimeLogS();

            string sMode = "_Normal_";

            if (emCollectMode == EMCollectModeType.Output)
                sMode = "_Output_";

            int iCount = cReader.Open(saLogFile, sMode);
            if (iCount >= 0)
            {
                foreach(string sPlcID in CProjectManager.Project.PlcIDList)
                {
                    cLogS = cReader.ReadTimeLogS(sPlcID);

                    if (cLogS != null && cLogS.Count > 0)
                    {
                        if (!m_cLogHistoryInfoS.ContainsKey(sPlcID))
                        {
                            m_cLogHistoryInfoS.Add(sPlcID, new Dictionary<EMCollectModeType, CLogHistoryInfo>());
                            m_cLogHistoryInfoS[sPlcID].Add(emCollectMode, new CLogHistoryInfo());

                            //m_dicLogHistoryByMode.Add(emCollectMode, new CLogHistoryInfo());
                        }
                        else
                        {
                            if (!m_cLogHistoryInfoS[sPlcID].ContainsKey(emCollectMode))
                            {
                                m_cLogHistoryInfoS[sPlcID].Add(emCollectMode, new CLogHistoryInfo());
                            }
                            else
                            {
                                m_cLogHistoryInfoS[sPlcID][emCollectMode].Clear();
                                m_cLogHistoryInfoS[sPlcID].Remove(emCollectMode);
                                m_cLogHistoryInfoS[sPlcID].Add(emCollectMode, new CLogHistoryInfo());
                            }
                        }

                        CLogHistoryInfo cHistory = m_cLogHistoryInfoS[sPlcID][emCollectMode];

                        cHistory.ProjectID = CProjectManager.ProjectID;
                        cHistory.PLCID = sPlcID;
                        cHistory.TimeLogS = cLogS;
                        cHistory.LogCount = cLogS.Count();
                        cHistory.StartTime = cLogS.Aggregate(cLogS.First(), (first, curr) => curr.Time < first.Time ? curr : first).Time;
                        cHistory.EndTime = cLogS.Aggregate(cLogS.First(), (last, curr) => curr.Time > last.Time ? curr : last).Time;
                        cHistory.CollectMode = emCollectMode;
                    }
                }
                cReader.Dispose();
                cReader = null;

            }
            else
            {
                cReader.Dispose();
                cReader = null;

                //ShowErrorMessageBox("Can't import log(Available log count is 0)");
                return false;
            }
            return true;
        }

        private bool CheckLogFiles(string[] saFile, string sInclude)
        {
            bool bOK = false;
            for (int i = 0; i < saFile.Length; i++)
            {
                string sPath = saFile[i];
                string[] saSplit = sPath.Split('\\');
                string sFileName = saSplit[saSplit.Length - 1];
                if (sFileName.Contains(sInclude))
                {
                    bOK = true;
                }
            }
            return bOK;
        }
        #endregion

        #region Event Methods
        private void btnLogImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CheckProjectExist() == false)
                return;

            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Multiselect = true;
            dlgOpenFile.Filter = "*.csv|*.csv";
            DialogResult dlgResult = dlgOpenFile.ShowDialog();
            if (dlgResult == DialogResult.Cancel) return;

            SplashScreenManager.ShowForm(this, typeof(FrmWaitForm), true, true, false);
            bool bOK = OpenCSVLogFiles(dlgOpenFile.FileNames);
            if (!bOK)
            {
                UpdateSystemMessage("Log Import", "파일에 이상이 있습니다.");
            }
            SplashScreenManager.CloseForm(false);
        }

        private void btnLogicChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCollectModeSelect frmCollectModeSelect = new FrmCollectModeSelect();
            frmCollectModeSelect.ShowDialog();
            if (frmCollectModeSelect.IsCancel)
                return;

            FrmLogicChartViewer frmLogicChart = new FrmLogicChartViewer();
            frmLogicChart.Show();
        }
        #endregion
    }
}
