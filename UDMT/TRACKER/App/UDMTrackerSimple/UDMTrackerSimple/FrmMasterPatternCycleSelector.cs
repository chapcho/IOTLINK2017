using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using TrackerCommon;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;

namespace UDMTrackerSimple
{
    public partial class FrmMasterPatternCycleSelector : DevExpress.XtraEditors.XtraForm, IDisposable
    {
        private CMySqlLogReader m_cReader = null;
        private int m_iCurCycleID = 0;
        private bool m_bMasterPatternEdit = false;
        Dictionary<string, bool> m_dicTabPateControl = new Dictionary<string, bool>(); 
        private List<string> m_lstRegularKeySymbol = new List<string>();

        private DateTime m_dtFrom = DateTime.MinValue;
        private DateTime m_dtTo = DateTime.MinValue;

        public FrmMasterPatternCycleSelector()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;

            if (m_cReader.IsConnected == false)
                m_cReader.Connect();
        }

        public void Dispose()
        {
            XtraTabPage tpPage = null;
            UCPatternEditor ucEditor = null;
            for (int i = 0; i < tabMain.TabPages.Count; i++)
            {
                tpPage = tabMain.TabPages[i];

                if (tpPage.Controls == null || tpPage.Controls.Count == 0)
                    continue;

                ucEditor = (UCPatternEditor)tabMain.TabPages[i].Controls[0];
                ucEditor.Dispose();

                ucEditor = null;
            }

            tabMain.TabPages.Clear();

            m_cReader = null;
            m_dicTabPateControl.Clear();
            m_lstRegularKeySymbol.Clear();
        }

        public bool IsMasterPatternEdit
        {
            get { return m_bMasterPatternEdit; }
            set { m_bMasterPatternEdit = value; }
        }

        private bool CheckCycleStartEndCondition()
        {
            bool bOK = true;

            try
            {
                string sErrorProcess = string.Empty;
                int iNormalProcessCount = 0;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.IsErrorMonitoring)
                        continue;

                    iNormalProcessCount++;

                    if (who.Value.CycleStartConditionS.Count == 0 || who.Value.CycleEndConditionS.Count == 0)
                        sErrorProcess += who.Value.Name + ", ";
                }

                if (sErrorProcess != string.Empty)
                {
                    sErrorProcess = sErrorProcess.Substring(0, sErrorProcess.Length - 2);
                    if (
                        XtraMessageBox.Show(
                            string.Format("\'{0}\' 공정의 Cycle 시작/끝 조건이 설정되지 않았습니다.\r\n그래도 마스터 패턴 생성을 진행하시겠습니까?",
                                sErrorProcess), "Cycle Start/End", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
                        DialogResult.Yes)
                        bOK = true;
                    else
                        bOK = false;
                }
                else if (iNormalProcessCount == 0)
                {
                    XtraMessageBox.Show("공정이 존재하지 않습니다.", "Master Pattern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bOK = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private void SetEditorUserControl(XtraTabPage tpPage)
        {
            if (!CMultiProject.PlcProcS.ContainsKey(tpPage.Text))
                return;

            CPlcProc cProcess = CMultiProject.PlcProcS[tpPage.Text];

            UCPatternEditor ucEditor = new UCPatternEditor();
            ucEditor.Dock = DockStyle.Fill;
            ucEditor.Process = cProcess;
            ucEditor.CycleInfoS = CreateCycleInfoS(cProcess);
            ucEditor.UEventGenerateMasterPattern += UCPatternEditor_GenerateMasterPattern;
            ucEditor.UEventDeleteMasterPattern += UCPatternEditor_DeleteMasterPattern;
            ucEditor.UEventChangeMasterPattern += UCPatternEditor_MasterPatternChanged;

            tpPage.Controls.Add(ucEditor);
        }

        private void CreateTabPageS()
        {
            try
            {
                bool bFirst = true;

                SplashScreenManager.ShowDefaultWaitForm("Please Wait...", "패턴 에디터를 생성하고 있습니다.");

                tabMain.TabPages.Clear();

                foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
                {
                    m_iCurCycleID = 0;

                    if (cProcess.IsErrorMonitoring)
                        continue;

                    XtraTabPage tpPage = new XtraTabPage();
                    tpPage.Name = cProcess.Name;
                    tpPage.Text = cProcess.Name;
                    tabMain.TabPages.Add(tpPage);

                    if (bFirst)
                    {
                        SetEditorUserControl(tpPage);
                        bFirst = false;
                        m_dicTabPateControl.Add(tpPage.Name, true);
                    }
                    else
                        m_dicTabPateControl.Add(tpPage.Name, false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            finally
            {
                SplashScreenManager.CloseDefaultWaitForm();
            }
        }

        private CCycleInfoS CreateCycleInfoS(CPlcProc cProcess)
        {
            CCycleInfoS cInfoS = new CCycleInfoS();
            try
            {
                m_iCurCycleID = 0;

                int iUpperCycleTime = Convert.ToInt32(cProcess.TargetTactTime * 1.3);

                CTimeLogS cStartLogS = null;
                CTimeLogS cEndLogS = null;
                bool bRecipeNone = false;
                Dictionary<DateTime, string> dicRecipeS = null;

                if (cProcess.CycleStartConditionS.Count == 0 || cProcess.CycleEndConditionS.Count == 0)
                {
                    //XtraMessageBox.Show(string.Format("해당\'{0}\'공정의 Cycle 시작/끝 조건이 설정되지 않았습니다.", cProcess.Name), "Error",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                cStartLogS = GetCycleConditionLogS(cProcess.CycleStartConditionS);
                cEndLogS = GetCycleConditionLogS(cProcess.CycleEndConditionS);

                if (cProcess.SelectRecipeWord == null)
                    bRecipeNone = true;

                if (!bRecipeNone)
                    dicRecipeS = GetCycleRecipeValueS(cProcess.SelectRecipeWord);

                if (dicRecipeS == null || dicRecipeS.Count == 0)
                    bRecipeNone = true;

                if (cStartLogS == null || cEndLogS == null)
                    return null;

                CTimeLog cEndLog = null;
                CCycleInfo cInfo = null;
                CTimeLog cLog = null;
                CErrorInfoS cErrInfoS = null;
                for (int i = 0; i < cStartLogS.Count; i++)
                {
                    cLog = cStartLogS[i];

                    if (cEndLog != null && cLog.Time < cEndLog.Time)
                        continue;

                    cEndLog = cEndLogS.GetFirstLog(cLog.Time);

                    if (cEndLog == null)
                        continue;

                    if (bRecipeNone)
                        cInfo = GetCycleInfo(cProcess.Name, cLog, cEndLog, string.Empty);
                    else
                        cInfo = GetCycleInfo(cProcess.Name, cLog, cEndLog, GetRecipeValue(cLog.Time, dicRecipeS));

                    if (cInfo != null && i + 1 < cStartLogS.Count)
                    {
                        cInfo.NextCycleStart = cStartLogS[i + 1].Time;

                        //if (cInfo.CycleTimeValue.TotalMilliseconds > iUpperCycleTime)
                        //    continue;

                            //cErrInfoS = CMultiProject.LogReader.GetErrorInfoS(CMultiProject.ProjectID, cProcess.Name,
                            //    cInfo.CycleStart, cInfo.CycleEnd);

                        //if (cErrInfoS != null && cErrInfoS.Count > 0)
                        //{
                        //    cErrInfoS.Clear();
                        //    cErrInfoS = null;
                        //    continue;
                        //}

                        cInfoS.Add(cInfo.CycleID, cInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return cInfoS;
        }

        private string GetRecipeValue(DateTime dtAct, Dictionary<DateTime, string> dicRecipeS)
        {
            string sValue = string.Empty;

            if (dicRecipeS.Last().Key < dtAct)
                sValue = dicRecipeS.Last().Value;
            else
            {

                for (int i = 0; i < dicRecipeS.Count; i++)
                {
                    if (dicRecipeS.ElementAt(i).Key >= dtAct)
                    {
                        //if (i == 0 || dicRecipeS.ElementAt(i).Key == dtAct)
                            sValue = dicRecipeS.ElementAt(i).Value;
                        //else
                        //    sValue = dicRecipeS.ElementAt(i - 1).Value;

                        break;
                    }
                }
            }

            return sValue;
        }

        private CCycleInfo GetCycleInfo(string sName, CTimeLog cStartLog, CTimeLog cEndLog, string sValue)
        {
            CCycleInfo cInfo = new CCycleInfo();

            cInfo.GroupKey = sName;
            cInfo.CurrentRecipe = sValue;
            cInfo.CycleStart = cStartLog.Time;
            cInfo.CycleEnd = cEndLog.Time;
            cInfo.CycleType = EMCycleRunType.Complete;
            cInfo.CycleID = m_iCurCycleID++;
            cInfo.ProjectID = CMultiProject.ProjectID;

            return cInfo;
        }

        private Dictionary<DateTime, string> GetCycleRecipeValueS(CTag cRecipeTag)
        {
            Dictionary<DateTime, string> dicRecipeS = new Dictionary<DateTime, string>();
            string sValue = string.Empty;

            CTimeLogS cLogS = m_cReader.GetTimeLogS(cRecipeTag.Key, m_dtFrom, m_dtTo);

            if (cLogS == null || cLogS.Count == 0)
                return null;

            cLogS.UpdateTimeRange();

            foreach (CTimeLog cLog in cLogS)
            {
                if (!dicRecipeS.ContainsKey(cLog.Time))
                {
                    if (cLog.Value == 0)
                        continue;

                    sValue = GetRecipeName(cLog.Value);//cLog.Value.ToString();

                    if (sValue == string.Empty)
                        continue;

                    if (!dicRecipeS.ContainsKey(cLog.Time))
                        dicRecipeS.Add(cLog.Time, sValue);
                }
            }

            return dicRecipeS;
        }

        private string GetRecipeName(int iValue)
        {
            CRecipeSection cRecipeSection = CMultiProject.ProjectInfo.ViewRecipe;
            string sResult = string.Empty;

            int iSumValue = 0;
            cRecipeSection.BitPosList.Sort();

            for (int i = 0; i < cRecipeSection.BitPosList.Count; i++)
            {
                int iBitValue = iValue & (0x1 << cRecipeSection.BitPosList[i]);
                if (iBitValue > 0)
                    iSumValue += 0x1 << cRecipeSection.BitPosList[i];
            }

            for (int i = 0; i < cRecipeSection.SectionItemList.Count; i++)
            {
                CRecipeSectionItem cItem = cRecipeSection.SectionItemList[i];
                if (cItem.ItemValue == iSumValue)
                {
                    sResult = cItem.ItemName;
                    break;
                }
            }
            return sResult;
        }

        private CTimeLogS GetCycleConditionLogS(CConditionS cConditionS)
        {
            CTimeLogS cLogS = new CTimeLogS();
            List<CTimeLog> lstTempLog = null;

            foreach (CCondition cCondition in cConditionS)
            {
                if (cCondition.TargetValue != 100)
                    lstTempLog =
                        m_cReader.GetTimeLogS(cCondition.Key, cCondition.TargetValue, m_dtFrom, m_dtTo).ToList();
                else
                    lstTempLog =
                        m_cReader.GetTimeLogS(cCondition.Key, m_dtFrom, m_dtTo).Where(x => x.Value > 0).ToList();

                if (lstTempLog == null || lstTempLog.Count == 0)
                    continue;

                //CTimeLog cLog = null;
                //for (int i = lstTempLog.Count - 1; i > 0; i--)
                //{
                //    cLog = lstTempLog[i];
                //    cLogS.Add(cLog);
                //}

                //cLog = null;

                cLogS.AddRange(lstTempLog);
            }
            cLogS.UpdateTimeRange();
            cLogS.Sort();

            lstTempLog.Clear();
            lstTempLog = null;

            return cLogS;
        }

        private bool CreateIndividualMasterPattern(string sProcess, CCycleInfoS cCycleInfoS)
        {
            bool bOK = false;
            try
            {
                SplashScreenManager.ShowDefaultWaitForm("Please Wait...", "\'" + sProcess + "\'공정의 마스터 패턴을 생성중입니다.");

                if (!CMultiProject.PlcProcS.ContainsKey(sProcess))
                    return false;

                CPlcProc cProcess = CMultiProject.PlcProcS[sProcess];
                CMasterPattern cMasterPattern = CreateMasterPattern(cProcess, cCycleInfoS);

                if (cMasterPattern != null && cMasterPattern.Count != 0)
                {
                    if (CMultiProject.MasterPatternS.ContainsKey(cProcess.Name))
                    {
                        foreach (var who in cMasterPattern)
                        {
                            if (CMultiProject.MasterPatternS[cProcess.Name].ContainsKey(who.Key))
                                CMultiProject.MasterPatternS[cProcess.Name][who.Key] = who.Value;
                            else
                                CMultiProject.MasterPatternS[cProcess.Name].Add(who.Key, who.Value);
                        }
                    }
                    else
                        CMultiProject.MasterPatternS.Add(cProcess.Name, cMasterPattern);

                    XtraMessageBox.Show("\'" + cProcess.Name + "\' 공정 마스터 패턴 생성 완료!!!", "성공", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    XtraTabPage tpPage = tabMain.SelectedTabPage;
                    UCPatternEditor ucEditor = (UCPatternEditor)tpPage.Controls[0];

                    if(cMasterPattern.Count > 0)
                        ucEditor.UpdateMasterPatternView(cMasterPattern.First().Key);

                    bOK = true;
                }
                else
                {
                    XtraMessageBox.Show("\'" + cProcess.Name + "\' 공정 마스터 패턴 생성 실패!!!", "실패",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    bOK = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                return false;
            }
            finally
            {
                SplashScreenManager.CloseDefaultWaitForm();
            }

            return bOK;
        }

        private CMasterPattern CreateMasterPattern(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            CMasterPattern cMasterPattern = null;
            try
            {
                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                    return null;

                m_lstRegularKeySymbol.Clear();
                UpdateKeySymbolS(cProcess, cCycleInfoS);

                CKeySymbolS cRegularKeySymbolS = new CKeySymbolS();
                CKeySymbol cKeySymbol = null;
                foreach (string sKey in m_lstRegularKeySymbol)
                {
                    if (cProcess.KeySymbolS.ContainsKey(sKey))
                    {
                        cKeySymbol = cProcess.KeySymbolS[sKey];
                        cRegularKeySymbolS.Add(sKey, cKeySymbol);
                    }
                }

                cMasterPattern = new CMasterPattern();
                cMasterPattern.Key = cProcess.Name;

                CFlowRule cRule = new CFlowRule();

                CCycleInfo cInfo;
                CFlowItemS cItemS;
                CFlowItem cItem;
                CTimeNode cNode;
                for (int i = 0; i < cCycleInfoS.Count; i++)
                {
                    bool bTimeNodeNone = false;

                    cInfo = cCycleInfoS.ElementAt(i).Value;

                    if (!cInfo.IsSelected)
                        continue;

                    if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd) continue;

                    cItemS = CTrackerHelper.CreateFlowItemS(m_cReader, cProcess.Name, cRegularKeySymbolS, cInfo, true);

                    if (cItemS == null)
                        continue;

                    for (int j = 0; j < cItemS.Count; j++)
                    {
                        cItem = cItemS[j];

                        if (cItem.TimeNodeS.Count == 0)
                        {
                            bTimeNodeNone = true;
                            break;
                        }

                        for (int k = 0; k < cItem.TimeNodeS.Count; k++)
                        {
                            cNode = cItem.TimeNodeS[k];
                            cNode.IsEnd = true;
                            cNode.IsStart = true;
                        }
                    }

                    if (bTimeNodeNone)
                        continue;

                    cMasterPattern.Update(cInfo.CurrentRecipe, cItemS, cRule);
                }
                cMasterPattern.FinalizeLinkS();

                //cCycleInfoS.Clear();
                //cCycleInfoS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return cMasterPattern;
        }

        private void UpdateKeySymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateKeySymbolCyclePresentResultS(cProcess, cCycleInfoS);

            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentOption cOption = new CCyclePresentOption();

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(cOption))
                {
                    if (!m_lstRegularKeySymbol.Contains(cResult.Tag.Key))
                        m_lstRegularKeySymbol.Add(cResult.Tag.Key);
                }
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private CCyclePresentResultS CreateKeySymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            CCyclePresentResultS cResultS = null;

            CKeySymbol cKeySymbol;
            CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                cKeySymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                //if (cKeySymbol.Tag.IsEndContact() == false && cKeySymbol.Tag.DataType == EMDataType.Bool)
                    cCandiTagS.Add(cKeySymbol.Tag);
            }

            cResultS = new CCyclePresentResultS(cCandiTagS);
            //TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;

                if (!cInfo.IsSelected)
                    continue;

                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue) continue;
                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd) continue;
                //tsSpan = cInfo.CycleEnd.Subtract(cInfo.CycleStart);

//                 if (tsSpan.TotalMilliseconds > cProcess.MaxTactTime)
//                    continue;

                UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);
            }
            return cResultS;
        }

        private void UpdateCyclePresentResultS(CTagS cTagS, CCycleInfo cCycleInfo, CCyclePresentResultS cResultS)
        {
            List<string> lstKey = cTagS.Keys.ToList();
            CTimeLogS cTotalLogS = m_cReader.GetTimeLogS(lstKey, cCycleInfo.CycleStart, cCycleInfo.CycleEnd);
            if (cTotalLogS == null || cTotalLogS.Count == 0)
                return;

            CTimeLogS cLogS;
            CTag cTag;
            for (int i = 0; i < cTagS.Count; i++)
            {
                cTag = cTagS[i];

                cLogS = cTotalLogS.GetTimeLogS(cTag.Key);
                if (cLogS == null)
                    cLogS = new CTimeLogS();

                if (cLogS.Count == 1)
                {
                    CTimeLogS cTempLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key, cCycleInfo.CycleEnd);
                    if (cTempLogS != null)
                    {
                        CTimeLog cTempLog = cTempLogS.GetFirstLog(cTag.Key, cLogS[0].Time);

                        if (cTempLog != null)
                            cLogS.Add(cTempLog);
                    }
                }

                if (cLogS.Count == 2 && cLogS.First().Value == 0 && cLogS.Last().Value == 1)
                {
                    CTimeLogS cTempLogS = CMultiProject.LogReader.GetLimitTimeLogS(cTag.Key, cLogS.Last().Time, 1, 0);
                    if (cTempLogS != null)
                    {
                        CTimeLog cTempLog = cTempLogS.GetFirstLog(cTag.Key, cLogS[1].Time, 0);

                        if (cTempLog != null)
                            cLogS.Add(cTempLog);
                    }

                    cLogS.RemoveAt(0);

                    cTempLogS.Clear();
                    cTempLogS = null;
                }

                cResultS.UpdatePresentResult(cCycleInfo.CurrentRecipe, cTag.Key, cLogS);

                cLogS.Clear();
                cLogS = null;
            }

            cTotalLogS.Clear();
            cTotalLogS = null;

            cResultS.TotalCycleCount += 1;
        }

        private void RemoveKeySymbol(CPlcProc cProcess, CTag cTag)
        {
            if (IsCycleSymbol(cProcess, cTag))
                return;

            if (cProcess.KeySymbolS.ContainsKey(cTag.Key))
                cProcess.RemoveAllSymbolS(cTag.Key);
        }

        private bool IsCycleSymbol(CPlcProc cProcess, CTag cTag)
        {
            bool bOK = false;

            if (cProcess.CycleStartConditionS.ContainsKey(cTag.Key) || cProcess.CycleEndConditionS.ContainsKey(cTag.Key))
                bOK = true;

            return bOK;
        }

        private void InitTimeRange()
        {
            m_dtTo = m_cReader.GetLastTimeLogTime();

            if (m_dtTo == DateTime.MinValue)
            {
                m_dtTo = DateTime.Now;
                m_dtFrom = m_dtTo.AddDays(-1);
            }
            else
                m_dtFrom = m_dtTo.AddDays(-1);

            dtpkFrom.EditValue = m_dtFrom;
            dtpkTo.EditValue = m_dtTo;
        }

        private void UpdateRange()
        {
            try
            {
                DateTime dtFrom = (DateTime) dtpkFrom.EditValue;
                DateTime dtTo = (DateTime) dtpkTo.EditValue;

                if (dtFrom > dtTo)
                {
                    XtraMessageBox.Show("기간 오류!!! 기간 설정을 다시 진행해주세요.", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                m_dtFrom = dtFrom;
                m_dtTo = dtTo;

                UCPatternEditor ucEditor = null;
                foreach (XtraTabPage tpPage in tabMain.TabPages)
                {
                    if (tpPage.Controls.Count == 0)
                        continue;

                    ucEditor = (UCPatternEditor)tpPage.Controls[0];
                    ucEditor.ClearEditor();
                    ucEditor.CycleInfoS = CreateCycleInfoS(ucEditor.Process);
                    ucEditor.InitCycleGrid();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ClearEditor()
        {
            try
            {
                UCPatternEditor ucEditor = null;
                foreach (XtraTabPage tpPage in tabMain.TabPages)
                {
                    if (tpPage.Controls.Count == 0)
                        continue;

                    ucEditor = (UCPatternEditor)tpPage.Controls[0];
                    ucEditor.ClearEditor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void UCPatternEditor_GenerateMasterPattern(string sProcess, CCycleInfoS cInfoS)
        {
            try
            {
                if (CreateIndividualMasterPattern(sProcess, cInfoS))
                    m_bMasterPatternEdit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCPatternEditor_MasterPatternChanged(bool bChanged)
        {
            try
            {
                if(bChanged)
                    m_bMasterPatternEdit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void UCPatternEditor_DeleteMasterPattern()
        {
            m_bMasterPatternEdit = true;
            CMultiProject.MasterStep = EMMonitorModeType.None;
        }

        private void FrmMasterPatternCycleSelector_Load(object sender, EventArgs e)
        {
            try
            {
                if(CMultiProject.MasterPatternS == null)
                    CMultiProject.MasterPatternS = new CMasterPatternS();

                InitTimeRange();

                if (CheckCycleStartEndCondition())
                    CreateTabPageS();
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void tabMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (e.Page == null)
                    return;

                if (m_dicTabPateControl.ContainsKey(e.Page.Name))
                {
                    if (m_dicTabPateControl[e.Page.Name]) return;
                }
                else
                    return;

                SetEditorUserControl(e.Page);
                m_dicTabPateControl[e.Page.Name] = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SplashScreenManager.ShowDefaultWaitForm();
                {
                    UpdateRange();
                }
                SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnPatternClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ClearEditor();
        }

    }
}