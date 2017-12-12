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
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using UDM.Log.DB;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerMasterPatternGernerate(bool bOK);

    public partial class FrmMasterPatternUpdate : DevExpress.XtraEditors.XtraForm
    {
        private CMySqlLogReader m_cReader = null;
        private CCyclePresentOption m_cKeyOption = new CCyclePresentOption();
        private CCyclePresentOption m_cSubKeyOption = new CCyclePresentOption();
        private bool m_bIndividual = false;
        private string m_sIndividual = string.Empty;
        private List<string> m_lstRegularKeySymbol = new List<string>();

        private string m_sCaption = string.Empty;
        private string m_sDescription = string.Empty;
        private int m_iCurCycleID = 0;

        public UEventHandlerMasterPatternGernerate UMasterPatternGenerateEvent = null;
        private delegate bool UpdateMasterPatternCallback(Dictionary<string, CCycleInfoS> dicProcessCycleInfoS);

        public FrmMasterPatternUpdate()
        {
            InitializeComponent();

            m_cReader = CMultiProject.LogReader;

            if (m_cReader.IsConnected == false)
                m_cReader.Connect();
        }

        public bool IsIndividual 
        {
            get { return m_bIndividual; }
            set { m_bIndividual = value; }
        }

        public string IndividualProcessName
        {
            get { return m_sIndividual; }
            set { m_sIndividual = value; }
        }

        public void SetCaption(string caption)
        {
            m_sCaption = caption;
        }

        public void SetDescription(string description)
        {
            m_sDescription = description;
        }

        public void CreateAllMasterPattern()
        {
            try
            {
                if (CheckCycleStartEndCondition())
                {
                    SplashScreenManager.ShowDefaultWaitForm("Please Wait", m_sDescription);
                    {
                        //UpdateAbnormalSymbol();
                        if (CreateMasterPatternS())
                        {
                            if (UMasterPatternGenerateEvent != null)
                                UMasterPatternGenerateEvent(true);
                        }
                    }
                    SplashScreenManager.CloseDefaultWaitForm();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
        }

        public bool CreateNewRecipeMasterPattern(Dictionary<string, CCycleInfoS> dicProcessCycleInfoS)
        {
            bool bOK = false;

            try
            {
                if (this.InvokeRequired)
                {
                    UpdateMasterPatternCallback cUpdate = new UpdateMasterPatternCallback(CreateNewRecipeMasterPattern);
                    this.Invoke(cUpdate, new object[] { dicProcessCycleInfoS });
                }
                else
                {
                    SplashScreenManager.ShowDefaultWaitForm("Please Wait", m_sDescription);
                    {
                        CMasterPattern cMasterPattern = null;

                        foreach (var who in dicProcessCycleInfoS)
                        {
                            cMasterPattern = CMultiProject.MasterPatternS[who.Key];
                            cMasterPattern.Key = who.Key;

                            if (CreateNewRecipeFlowS(cMasterPattern, who.Value))
                                bOK = true;
                        }
                    }
                    SplashScreenManager.CloseDefaultWaitForm();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
                bOK = false;
            }
            return bOK;
        }

        private bool CreateNewRecipeFlowS(CMasterPattern cMasterPattern, CCycleInfoS cCycleInfoS)
        {
            bool bOK = false;

            try
            {
                CPlcProc cProcess = CMultiProject.PlcProcS[cMasterPattern.Key];

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

                CCycleInfo cInfo;
                CFlowItemS cItemS;
                CFlowItem cItem;
                CTimeNode cNode;
                bool bTimeNodeNone = false;
                for (int i = 0; i < cCycleInfoS.Count; i++)
                {
                    bTimeNodeNone = false;
                    cInfo = cCycleInfoS.ElementAt(i).Value;

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

                    cMasterPattern.Update(cInfo.CurrentRecipe, cItemS, new CFlowRule());
                }
                cMasterPattern.FinalizeLinkS();

                bOK = true;

                cCycleInfoS.Clear();
                cCycleInfoS = null;

                cRegularKeySymbolS.Clear();
                cRegularKeySymbolS = null;
            }
            catch (Exception ex)
            {
                CMultiProject.SystemLog.WriteLog(System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
                ex.Data.Clear();
            }
            return bOK;
        }



        private void UpdateAbnormalSymbol()
        {
            //List<string> lstSymbolKey = null;
            //CTimeLogS cLogS = null;

            //foreach (var who in CMultiProject.PlcProcS)
            //{
            //    lstSymbolKey = who.Value.AbnormalSymbolS.GetAbnormalSymbolFirstSubDepthKeyList();

            //    foreach (string sKey in lstSymbolKey)
            //    {
            //        cLogS = m_cReader.GetTimeLogS(sKey);

            //        int iOnLogCount = cLogS.Where(x => x.Value == 1).Count();
            //        int iOffLogCount = cLogS.Where(x => x.Value == 0).Count();

            //        if(iOnLogCount >= 1 && iOffLogCount >= 1)
            //            who.Value.AbnormalSymbolS.RemoveSymbol(sKey);
            //    }

            //}
        }

        private bool CreateMasterPatternS()
        {
            bool bOK = false;
            try
            {
                CMasterPatternS cMasterPatternS = new CMasterPatternS();
                CFlowRule cFlowRule = new CFlowRule();

                cMasterPatternS.Rule = cFlowRule;

                CPlcProc cProcess;
                CMasterPattern cMasterPattern;
                string sErrorProcess = string.Empty;

                for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
                {
                    cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                    if (m_bIndividual && cProcess.Name != m_sIndividual)
                        continue;

                    if (cProcess.IsErrorMonitoring)
                        continue;

                    cMasterPattern = CreateMasterPattern(cProcess, cFlowRule);

                    if (cMasterPattern != null && cMasterPattern.Count != 0)
                        cMasterPatternS.Add(cProcess.Name, cMasterPattern);
                    else
                        sErrorProcess += cProcess.Name + ", ";
                }

                if (sErrorProcess != string.Empty)
                {
                    sErrorProcess = sErrorProcess.Substring(0, sErrorProcess.Length - 2);
                    MessageBox.Show("\'" + sErrorProcess + "\' 의 MasterPattern이 생성되지 않았습니다.\r\nCycle 수집을 더 진행해주세요.",
                        "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (var who in cMasterPatternS)
                {
                    if (CMultiProject.MasterPatternS.ContainsKey(who.Key))
                    {
                        foreach (string sKey in who.Value.Keys)
                        {
                            if (CMultiProject.MasterPatternS[who.Key].ContainsKey(sKey))
                                CMultiProject.MasterPatternS[who.Key][sKey] = who.Value[sKey];
                            else
                                CMultiProject.MasterPatternS[who.Key].Add(sKey, who.Value[sKey]);
                        }
                    }
                    else
                        CMultiProject.MasterPatternS.Add(who.Key, who.Value);

                    bOK = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private CCycleInfoS CreateCycleInfoS(CPlcProc cProcess)
        {
            CCycleInfoS cInfoS = new CCycleInfoS();
            try
            {
                m_iCurCycleID = 0;

                int iUpperCycleTime = Convert.ToInt32(cProcess.TargetTactTime * 1.3);
                int iLowerCycleTime = Convert.ToInt32(cProcess.TargetTactTime * 0.7);

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

                if(!bRecipeNone)
                    dicRecipeS = GetCycleRecipeValueS(cProcess.SelectRecipeWord);

                if (dicRecipeS == null || dicRecipeS.Count == 0)
                    bRecipeNone = true;

                if (cStartLogS == null || cEndLogS == null)
                    return null;

                CTimeLog cEndLog = null;
                CCycleInfo cInfo = null;
                CTimeLog cLog = null;
                for(int i = 0 ; i < cStartLogS.Count ; i++)
                {
                    cLog = cStartLogS[i];

                    if (cEndLog != null && cLog.Time < cEndLog.Time)
                        continue;

                    cEndLog = cEndLogS.GetFirstLog( cLog.Time);

                    if (cEndLog == null)
                        continue;

                    if (bRecipeNone)
                        cInfo = GetCycleInfo(cProcess.Name, cLog, cEndLog, string.Empty);
                    else
                        cInfo = GetCycleInfo(cProcess.Name, cLog, cEndLog, GetRecipeValue(cLog.Time, dicRecipeS));

                    if (cInfo != null && i + 1 < cStartLogS.Count)
                    {
                        if (cInfo.CycleTimeValue.TotalMilliseconds <= iUpperCycleTime &&
                            cInfo.CycleTimeValue.TotalMilliseconds >= iLowerCycleTime)
                        {
                            cInfo.NextCycleStart = cStartLogS[i + 1].Time;
                            cInfoS.Add(cInfo.CycleID, cInfo);
                        }
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
                        if (i == 0)
                            sValue = dicRecipeS.ElementAt(i).Value;
                        else
                            sValue = dicRecipeS.ElementAt(i - 1).Value;

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
            List<string> lstValue = new List<string>();

            CTimeLogS cLogS = m_cReader.GetTimeLogS(cRecipeTag.Key);

            if (cLogS == null || cLogS.Count == 0)
                return null;

            cLogS.UpdateTimeRange();

            foreach (CTimeLog cLog in cLogS)
            {
                if (!dicRecipeS.ContainsKey(cLog.Time))
                {
                    sValue = cLog.Value.ToString();// GetRecipeName(cLog.Value);

                    if (sValue == string.Empty)
                        continue;

                    if (!lstValue.Contains(sValue))
                    {
                        dicRecipeS.Add(cLog.Time, sValue);
                        lstValue.Add(sValue);
                    }
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
                        m_cReader.GetLimitTimeLogS(cCondition.Key, 10, cCondition.TargetValue, true).ToList();
                else
                    lstTempLog =
                        m_cReader.GetLimitOnTimeLogS(cCondition.Key, 10, true).ToList();

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

            lstTempLog.Clear();
            lstTempLog = null;

            return cLogS;
        }

        private CMasterPattern CreateMasterPattern(CPlcProc cProcess, CFlowRule cRule)
        {
            CMasterPattern cMasterPattern = null;
            try
            {
                CCycleInfoS cCycleInfoS = CreateCycleInfoS(cProcess);

                if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                    return null;

                //KeySymbol Clear & ChartViewTagS로 Key Symbol 새롭게 ADD

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

                CCycleInfo cInfo;
                CFlowItemS cItemS;
                CFlowItem cItem;
                CTimeNode cNode;
                for (int i = 0; i < cCycleInfoS.Count; i++)
                {
                    bool bTimeNodeNone = false;

                    if (i == 0)
                        continue;

                    if (i > 20)
                        break;

                    cInfo = cCycleInfoS.ElementAt(i).Value;

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

                cCycleInfoS.Clear();
                cCycleInfoS = null;

                cRegularKeySymbolS.Clear();
                cRegularKeySymbolS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return cMasterPattern;
        }

        private void UpdateEndSubDepthSymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateEndSubDepthSymbolCyclePresentResultS(cProcess, cCycleInfoS);
            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cSubKeyOption) == false)
                    RemoveEndSubDepthSymbol(cProcess, cResult.Tag);
            }

            cCyclePresentResultS.Clear();
            cCyclePresentResultS = null;
        }

        private CCyclePresentResultS CreateEndSubDepthSymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return null;

            //  End SubDepth Key 심볼 만
            CKeySymbol cSymbol;
            CTagS cTempCandiTagS = new CTagS();
            CTagS cCandiTagS = new CTagS();
            for (int i = 0; i < cProcess.KeySymbolS.Count; i++)
            {
                cSymbol = cProcess.KeySymbolS.ElementAt(i).Value;
                //cTempCandiTagS.AddRange(cSymbol.SubDepthTagKeyList);
            }

            foreach (var who in cTempCandiTagS)
            {
                if (!cCandiTagS.ContainsKey(who.Key))
                    cCandiTagS.Add(who.Value);
            }

            CCyclePresentResultS cResultS = new CCyclePresentResultS(cCandiTagS);
            TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;
                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue)
                    continue;

                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
                    continue;

                tsSpan = cInfo.CycleEnd.Subtract(cInfo.CycleStart);
                if (tsSpan.TotalMilliseconds > cProcess.MaxTactTime)
                    continue;

                UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);
            }

            return cResultS;
        }

        private void RemoveEndSubDepthSymbol(CPlcProc cProcess, CTag cTag)
        {
            cProcess.RemoveEndSubDepthSymbolS(cTag);
        }

        private void UpdateKeySymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        {
            if (cCycleInfoS == null || cCycleInfoS.Count == 0)
                return;

            CCyclePresentResultS cCyclePresentResultS = CreateKeySymbolCyclePresentResultS(cProcess, cCycleInfoS);

            if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
                return;

            CCyclePresentResult cResult;
            for (int i = 0; i < cCyclePresentResultS.Count; i++)
            {
                cResult = cCyclePresentResultS[i];
                if (cResult.IsRegular(m_cKeyOption))
                { 
                    if(!m_lstRegularKeySymbol.Contains(cResult.Tag.Key))
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
                if (cKeySymbol.Tag.IsEndContact() == false && cKeySymbol.Tag.DataType == EMDataType.Bool)
                    cCandiTagS.Add(cKeySymbol.Tag);
            }

            cResultS = new CCyclePresentResultS(cCandiTagS);
            //TimeSpan tsSpan;
            CCycleInfo cInfo;
            for (int i = 0; i < cCycleInfoS.Count; i++)
            {
                cInfo = cCycleInfoS.ElementAt(i).Value;

                if (i > 20)
                    break;

                if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue) continue;
                if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd) continue;

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

                //if (cLogS.Count != 0 && cLogS.First().Value == 0)
                //{
                //    CTimeLogS cTempLogS = CMultiProject.LogReader.GetTimeLogS(cTag.Key);
                //    if (cTempLogS != null)
                //    {
                //        CTimeLog cTempLog = cTempLogS.GetFirstLog(cTag.Key, cLogS[1].Time, 0);

                //        if (cTempLog != null)
                //            cLogS.Add(cTempLog);
                //    }

                //    cLogS.RemoveAt(0);

                //    cTempLogS.Clear();
                //    cTempLogS = null;
                //}

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

        //private void UpdateSubSymbolS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        //{
        //    if (cCycleInfoS == null || cCycleInfoS.Count == 0)
        //        return;

        //    CCyclePresentResultS cCyclePresentResultS = CreateSubSymbolCyclePresentResultS(cProcess, cCycleInfoS);
        //    if (cCyclePresentResultS == null || cCyclePresentResultS.Count == 0)
        //        return;

        //    CCyclePresentResult cResult;
        //    for (int i = 0; i < cCyclePresentResultS.Count; i++)
        //    {
        //        cResult = cCyclePresentResultS[i];
        //        if (cResult.IsRegular(m_cSubKeyOption) == false)
        //            RemoveSubSymbol(cProcess, cResult.Tag);
        //    }

        //    cCyclePresentResultS.Clear();
        //    cCyclePresentResultS = null;
        //}

        //private CCyclePresentResultS CreateSubSymbolCyclePresentResultS(CPlcProc cProcess, CCycleInfoS cCycleInfoS)
        //{
        //    if (cCycleInfoS == null || cCycleInfoS.Count == 0)
        //        return null;

        //    if (cProcess.SubKeySymbolS == null)
        //        return null;

        //    //  SubKey 심볼 만
        //    CSubKeySymbol cSymbol;
        //    CTagS cCandiTagS = new CTagS();
        //    for (int i = 0; i < cProcess.SubKeySymbolS.Count; i++)
        //    {
        //        cSymbol = cProcess.SubKeySymbolS.ElementAt(i).Value;
        //        cCandiTagS.Add(cSymbol.Tag);
        //    }

        //    CCyclePresentResultS cResultS = new CCyclePresentResultS(cCandiTagS);
        //    TimeSpan tsSpan;
        //    CCycleInfo cInfo;
        //    for (int i = 0; i < cCycleInfoS.Count; i++)
        //    {
        //        cInfo = cCycleInfoS.ElementAt(i).Value;
        //        if (cInfo.CycleStart == DateTime.MinValue || cInfo.CycleEnd == DateTime.MinValue)
        //            continue;

        //        if (cInfo.CycleType == EMCycleRunType.Error || cInfo.CycleType == EMCycleRunType.ErrorEnd)
        //            continue;

        //        tsSpan = cInfo.CycleEnd.Subtract(cInfo.CycleStart);
        //        if (tsSpan.TotalMilliseconds > cProcess.MaxTactTime)
        //            continue;

        //        UpdateCyclePresentResultS(cCandiTagS, cInfo, cResultS);
        //    }

        //    return cResultS;
        //}

        //private void RemoveSubSymbol(CPlcProc cProcess, CTag cTag)
        //{
        //    cProcess.RemoveSubSymbolS(cTag);
        //}

        private bool CheckCycleStartEndCondition()
        {
            bool bOK = true;

            try
            {
                string sErrorProcess = string.Empty;

                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.IsErrorMonitoring)
                        continue;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return bOK;
        }

        private void FrmMasterPatternUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}