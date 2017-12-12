using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TrackerCommon;
using UDM.Common;
using UDM.General.Threading;
using UDM.Log;
using UDM.Log.DB;

namespace UDMOptimizer
{
    public class COptraErrorAnalyzer : CThreadWithQueBase<object>
    {
        #region Member Variables

        private COptraLogWriter m_cWriter = null;
        public event UEventHandlerTrackerMessage UEventMessage = null;

        private CErrorInfo m_cCurErrorInfo = null;
        private CPlcLogicData m_cCurLogicData = null;

        #endregion

        #region Properties

        public COptraLogWriter LogWriter
        {
            get { return m_cWriter; }
            set { m_cWriter = value; }
        }

        #endregion

        #region Privete Method

        private void UpdateSystemMessage(string sSender, string sMessage)
        {
            //Event 생성
            if (UEventMessage != null)
                UEventMessage(sSender, sMessage);
        }

        private CStep GetStepList(CTag cTag)
        {
            CStep cStep = null;

            if (cTag == null)
                return null;

            if(m_cCurLogicData == null)
                m_cCurLogicData = CMultiProject.GetPlcLogicData(cTag);

            List<CStep> lstStep = m_cCurLogicData.StepS.Where(b => b.Value.Address == cTag.Address).Select(b => b.Value).ToList();
            if (lstStep == null || lstStep.Count == 0)
                return null;

            if (lstStep.Count == 1 && !lstStep[0].Instruction.Contains("RST"))
                cStep = lstStep[0];

            return cStep;
        }

        private CErrorInfoS GetErrorS()
        {
            CErrorInfoS cDetailInfoS = new CErrorInfoS();
            bool bOffError = false;
            int iStep = 0;

            try
            {
                if (m_cCurErrorInfo.ErrorLogS == null || m_cCurErrorInfo.ErrorLogS.Count == 0)
                    return cDetailInfoS;

                CAbnormalSymbol cSymbol = null;
                foreach (var who in CMultiProject.PlcProcS)
                {
                    if (who.Value.AbnormalSymbolS.IsContainKey(m_cCurErrorInfo.SymbolKey))
                    {
                        cSymbol = who.Value.AbnormalSymbolS.GetAbnormalSymbol(m_cCurErrorInfo.SymbolKey);
                        break;
                    }
                }

                iStep = 1;

                if (cSymbol == null)
                    return cDetailInfoS;

                if (m_cCurErrorInfo.Value == 0)
                    bOffError = true;

                Stopwatch stw = new Stopwatch();
                UpdateSystemMessage("Error Analyzer", "Detail Error Find Start");
                stw.Start();

                if (cSymbol.SubCoil == null)
                    return null;

                CSubCoilS cSubCoilS = cSymbol.SubCoil.GetLastSubCoilS(m_cCurErrorInfo.ErrorLogS, bOffError);

                iStep = 2;

                CSubLogicPathS cErrorPathS = null;

                if (cSubCoilS == null || cSubCoilS.Count == 0)
                {
                    iStep = 3;

                    cErrorPathS = cSymbol.SubCoil.SubLogicPathS.GetErrorLogicPathS(m_cCurErrorInfo.ErrorLogS, bOffError);
                    m_cCurErrorInfo.InputSymbolKeyList.Clear();

                    if (cErrorPathS != null && cErrorPathS.Count != 0)
                        m_cCurErrorInfo.InputSymbolKeyList = GetStepInputSymbolKey(CMultiProject.TotalTagS[m_cCurErrorInfo.SymbolKey], cErrorPathS, bOffError);

                    iStep = 4;

                    SetDetailErrorS(cDetailInfoS, m_cCurErrorInfo.InputSymbolKeyList, m_cCurErrorInfo.SymbolKey, m_cCurErrorInfo.ErrorMessage);

                    if (cDetailInfoS.Count != 0)
                    {
                        m_cCurErrorInfo.IsVisible = false;
                        m_cCurErrorInfo.CoilKey = m_cCurErrorInfo.SymbolKey;
                        m_cCurErrorInfo.AbnormalSymbolKey = m_cCurErrorInfo.SymbolKey;
                        cDetailInfoS.Add(m_cCurErrorInfo);
                    }

                    iStep = 5;
                }
                else
                {
                    iStep = 6;

                    CErrorInfo cInfo = null;
                    int iErrorCount = 0;
                    foreach (var who in cSubCoilS)
                    {
                        cErrorPathS = who.SubLogicPathS.GetErrorLogicPathS(m_cCurErrorInfo.ErrorLogS, bOffError);
                        cInfo = GetError(CMultiProject.TotalTagS[who.CoilKey], cErrorPathS);
                        if (cInfo != null)
                            cDetailInfoS.Add(cInfo);

                        iErrorCount = cDetailInfoS.Count;
                        SetDetailErrorS(cDetailInfoS, cInfo.InputSymbolKeyList, cInfo.SymbolKey, cInfo.DetailErrorMessage);

                        if (iErrorCount == cDetailInfoS.Count)
                            cInfo.IsVisible = true;
                    }

                    iStep = 7;
                }

                stw.Stop();
                UpdateSystemMessage("Error Analyzer", string.Format("Count : {0}", cErrorPathS.Count));
                UpdateSystemMessage("Error Analyzer", string.Format("Error : {0}, Detail Error Count : {1}", m_cCurErrorInfo.ErrorMessage, cDetailInfoS.Count));
                UpdateSystemMessage("Error Analyzer", "Detail Error Find END, Time : " + stw.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                if (UEventMessage != null)
                    UEventMessage("ErrorAnlayzer",
                        string.Format("Method : {0}, Error : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name,
                            ex.Message));

                Console.WriteLine(string.Format("Method : {0}, Error : {1}, Step : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message, iStep));
                ex.Data.Clear();
            }

            return cDetailInfoS;
        }

        private void SetDetailErrorS(CErrorInfoS cInfoS, List<string> lstInputSymbolKeyList, string sCoilKey, string sErrorMessage)
        {
            CErrorInfo cInfo = null;
            CTag cTag = null;
            foreach (string sKey in lstInputSymbolKeyList)
            {
                cTag = CMultiProject.TotalTagS[sKey];
                cInfo = GetErrorNotContainInputSymbolList(cTag, sCoilKey, sErrorMessage);

                cInfoS.Add(cInfo);
            }
        }

        private CErrorInfo GetErrorNotContainInputSymbolList(CTag cErrorTag, string sCoilKey, string sErrorMessage)
        {
            CErrorInfo cDetailInfo = new CErrorInfo();

            cDetailInfo.SymbolKey = cErrorTag.Key;
            cDetailInfo.ErrorMessage = sErrorMessage;
            cDetailInfo.DetailErrorMessage = cErrorTag.Description;
            cDetailInfo.CurrentRecipe = m_cCurErrorInfo.CurrentRecipe;
            cDetailInfo.CycleID = m_cCurErrorInfo.CycleID;
            cDetailInfo.CycleStart = m_cCurErrorInfo.CycleStart;
            cDetailInfo.ErrorID = m_cCurErrorInfo.ErrorID;
            cDetailInfo.ErrorTime = m_cCurErrorInfo.ErrorTime;
            cDetailInfo.ErrorType = m_cCurErrorInfo.ErrorType;
            cDetailInfo.GroupKey = m_cCurErrorInfo.GroupKey;
            cDetailInfo.ProjectID = m_cCurErrorInfo.ProjectID;
            cDetailInfo.Value = m_cCurErrorInfo.Value;
            cDetailInfo.AbnormalSymbolKey = m_cCurErrorInfo.SymbolKey;
            cDetailInfo.CoilKey = sCoilKey;
            cDetailInfo.IsVisible = true;

            return cDetailInfo;
        }

        private CErrorInfo GetError(CTag cErrorTag, CSubLogicPathS cErrorPathS)
        {
            CErrorInfo cDetailInfo = new CErrorInfo();

            cDetailInfo.SymbolKey = cErrorTag.Key;
            cDetailInfo.ErrorMessage = m_cCurErrorInfo.ErrorMessage;
            cDetailInfo.DetailErrorMessage = cErrorTag.Description;
            cDetailInfo.CurrentRecipe = m_cCurErrorInfo.CurrentRecipe;
            cDetailInfo.CycleID = m_cCurErrorInfo.CycleID;
            cDetailInfo.CycleStart = m_cCurErrorInfo.CycleStart;
            cDetailInfo.ErrorID = m_cCurErrorInfo.ErrorID;
            cDetailInfo.ErrorTime = m_cCurErrorInfo.ErrorTime;
            cDetailInfo.ErrorType = m_cCurErrorInfo.ErrorType;
            cDetailInfo.GroupKey = m_cCurErrorInfo.GroupKey;
            cDetailInfo.ProjectID = m_cCurErrorInfo.ProjectID;

            CTimeLog cLog = m_cCurErrorInfo.ErrorLogS.GetFirstLog(cErrorTag.Key);
            cDetailInfo.Value = cLog.Value;
            cDetailInfo.AbnormalSymbolKey = m_cCurErrorInfo.SymbolKey;
            cDetailInfo.CoilKey = cErrorTag.Key;

            Stopwatch stw = new Stopwatch();
            stw.Start();

            if(cErrorPathS != null && cErrorPathS.Count != 0)
                cDetailInfo.InputSymbolKeyList = GetStepInputSymbolKey(cErrorTag, cErrorPathS, cLog.Value == 1 ? false : true);

            stw.Stop();

            UpdateSystemMessage("Error Anlayzer", "Detail Error Info InputSymbolKeyList Time : " + stw.ElapsedMilliseconds.ToString());

            return cDetailInfo;
        }

        private CErrorInfoS GetDetailErrorS()
        {
            CErrorInfoS cDetailInfoS = new CErrorInfoS();
            List<string> lstTotalStepKey = new List<string>();
            Dictionary<int, string> dicTraceStepKey = new Dictionary<int, string>();
            int iCurDepth = 0;

            if (m_cCurErrorInfo.ErrorLogS == null || m_cCurErrorInfo.ErrorLogS.Count == 0)
                return cDetailInfoS;

            CStep cStep = GetStepList(CMultiProject.TotalTagS[m_cCurErrorInfo.SymbolKey]);
            if(cStep == null)
                return cDetailInfoS;

            CTag cLastTag = null;
            foreach (CContact cContact in cStep.ContactS)
            {
                lstTotalStepKey.Clear();
                dicTraceStepKey.Clear();
                iCurDepth = 0;
                dicTraceStepKey.Add(iCurDepth, cStep.Key);
                lstTotalStepKey.Add(cStep.Key);

                if (cContact.ContactType != EMContactType.Bit) continue;
                if (cContact.ContentS.Count == 0) continue;

                cLastTag = GetLastCoil(cContact.ContentS[0].Tag, lstTotalStepKey, iCurDepth, dicTraceStepKey);

                if(cLastTag != null)
                    cDetailInfoS.Add(GetDetailError(cLastTag, dicTraceStepKey));
            }

            return cDetailInfoS;
        }

        private CTag GetLastCoil(CTag cTag, List<string> lstTotalStepKey, int iCurDepth, Dictionary<int, string> dicTraceStepKey)
        {
            CTag cLastTag = null;
            CTimeLogS cLogS = null;
            List<string> lstLastTagKey = new List<string>();
            CStep cSubStep = GetStepList(cTag);

            if (cSubStep == null) return null;
            if (!lstTotalStepKey.Contains(cSubStep.Key))
            {
                lstTotalStepKey.Add(cSubStep.Key);
                iCurDepth++;

                if(!dicTraceStepKey.ContainsKey(iCurDepth))
                    dicTraceStepKey.Add(iCurDepth, cSubStep.Key);
            }
            else
                return null;

            cLogS = m_cCurErrorInfo.ErrorLogS.GetTimeLogS(cTag.Key);
            if (cLogS != null && cLogS.Count > 0)
            {
                foreach (var who in cLogS)
                {
                    if (who.Value > 0)
                    {
                        foreach (CContact cContact in cSubStep.ContactS)
                        {
                            if (cContact.ContactType != EMContactType.Bit) continue;
                            if (cContact.ContentS.Count == 0) continue;
                            cLastTag = GetLastCoil(cContact.ContentS[0].Tag, lstTotalStepKey, iCurDepth, dicTraceStepKey);
                            if(cLastTag != null)
                                lstLastTagKey.Add(cLastTag.Key);
                        }
                        if (lstLastTagKey.Count == 0)
                            return cTag;
                        else
                            return CMultiProject.TotalTagS[lstLastTagKey[0]];
                    }
                }
            }

            return cLastTag;
        }

        private CErrorInfo GetDetailError(CTag cErrorTag, Dictionary<int, string> dicTraceStepKey)
        {
            CErrorInfo cDetailInfo = new CErrorInfo();

            cDetailInfo.SymbolKey = cErrorTag.Key;
            cDetailInfo.ErrorMessage = cErrorTag.Description;
            cDetailInfo.CurrentRecipe = m_cCurErrorInfo.CurrentRecipe;
            cDetailInfo.CycleID = m_cCurErrorInfo.CycleID;
            cDetailInfo.CycleStart = m_cCurErrorInfo.CycleStart;
            cDetailInfo.ErrorID = m_cCurErrorInfo.ErrorID;
            cDetailInfo.ErrorTime = m_cCurErrorInfo.ErrorTime;
            cDetailInfo.ErrorType = m_cCurErrorInfo.ErrorType;
            cDetailInfo.GroupKey = m_cCurErrorInfo.GroupKey;
            cDetailInfo.ProjectID = m_cCurErrorInfo.ProjectID;
            cDetailInfo.Value = m_cCurErrorInfo.Value;

            Stopwatch stw = new Stopwatch();
            stw.Start();
            //cDetailInfo.InputSymbolKeyList = GetStepInputSymbolKey(cErrorTag);
            stw.Stop();

            UpdateSystemMessage("Error Anlayzer", "Detail Error Info InputSymbolKeyList Time : " + stw.ElapsedMilliseconds.ToString());
            cDetailInfo.TraceStepKey = dicTraceStepKey;

            return cDetailInfo;
        }

        private List<string> GetStepInputSymbolKey(CTag cTag, CSubLogicPathS cErrorPathS, bool bOffError)
        {
            List<string> lstInputSymbolKey = new List<string>();

            if (m_cCurLogicData == null)
                m_cCurLogicData = CMultiProject.GetPlcLogicData(cTag);
            else if (m_cCurLogicData.PlcChannel != cTag.Channel)
                m_cCurLogicData = CMultiProject.GetPlcLogicData(cTag);

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];

                if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
                    continue;

                if (m_cCurLogicData.StepS.ContainsKey(cRole.StepKey))
                {
                    cStep = m_cCurLogicData.StepS[cRole.StepKey];

                    if (cStep.CoilS.GetFirstCoil().CoilType != EMCoilType.Bit)
                        continue;

                    List<string> lstTempKey = GetInputSymbolList(cStep, cErrorPathS, bOffError);

                    foreach (string sKey in lstTempKey)
                    {
                        if (!lstInputSymbolKey.Contains(sKey))
                            lstInputSymbolKey.Add(sKey);
                    }
                }
            }

            return lstInputSymbolKey;
        }

        private List<string> GetInputSymbolList(CStep cStep, CSubLogicPathS cErrorPathS, bool bOffError)
        {
            List<string> lstInputKey = new List<string>();

            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if (cCoil.Relation.PrevContactS.Count != 0)
                foreach (int PreCont in cCoil.Relation.PrevContactS)
                    CreateFirstDepthSymbolTagList(cStep, lstInputKey, cErrorPathS, PreCont, false, bOffError);

            return lstInputKey;
        }

        private void SetFirstDepthSymbolTagList(CContact cContact, CSubLogicPathS cErrorPathS, bool bInverse, List<string> lstInputSymbol, bool bOffError)
        {
            string sInputSymbol = string.Empty;
            bool bASymbolState = false;

            CTag cTag = null;
            for (int i = 0; i < cContact.RefTagS.Count; i++)
            {
                cTag = cContact.RefTagS[i];

                if (cTag.DataType != EMDataType.Bool || CheckRoleType(cTag))
                    continue;

                if (!CheckDetailErrorContainErrorPathS(cErrorPathS, cTag.Key))
                    continue;

                string sTemp = string.Empty;
                sInputSymbol = cTag.Key;
                if (GetContactSymbolType(cContact))
                    bASymbolState = true;
                else
                    bASymbolState = false;

                CTimeLogS cLogS = m_cCurErrorInfo.ErrorLogS.GetTimeLogS(cTag.Key);
                CTimeLog cLog = null;

                if (cLogS == null || cLogS.Count == 0)
                    continue;

                cLog = cLogS[0];

                if (CheckDetailErrorSymbol(cLog, bASymbolState, bInverse, bOffError))
                {
                    if (!lstInputSymbol.Contains(sInputSymbol))
                        lstInputSymbol.Add(sInputSymbol);
                }
            }
        }

        private bool CheckDetailErrorContainErrorPathS(CSubLogicPathS cErrorPathS, string sKey)
        {
            bool bOK = false;

            if (cErrorPathS == null || cErrorPathS.Count == 0)
                return false;

            foreach (CSubLogicPath cPath in cErrorPathS)
            {
                if (cPath.SubContactS.ContainsKey(sKey))
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool CheckDetailErrorSymbol(CTimeLog cLog, bool bASymbolState, bool bInverse, bool bOffError)
        {
            bool bOK = false;

            if(bASymbolState)
            {
                if (!bOffError)
                {
                    if (bInverse && cLog.Value == 0 || !bInverse && cLog.Value == 1)
                        bOK = true;
                }
                else
                {
                    if (bInverse && cLog.Value == 1 || !bInverse && cLog.Value == 0)
                        bOK = true;
                }
            }
            else
            {
                if (!bOffError)
                {
                    if (bInverse && cLog.Value == 1 || !bInverse && cLog.Value == 0)
                        bOK = true;
                }
                else
                {
                    if (bInverse && cLog.Value == 0 || !bInverse && cLog.Value == 1)
                        bOK = true;
                }
            }

            return bOK;
        }

        private void CreateFirstDepthSymbolTagList(CStep cStep, List<string> lstInputSymbol, CSubLogicPathS cErrorPathS, int iStepIndex, bool bInverse, bool bOffError)
        {
            foreach (CContact cContact in cStep.ContactS)
            {
                if (cContact.StepIndex == iStepIndex)
                {
                    if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit)
                        SetFirstDepthSymbolTagList(cContact, cErrorPathS, bInverse, lstInputSymbol, bOffError);

                    if (cContact.Operator.Contains("INV"))
                        bInverse = true;

                    if (cContact.Relation.PrevContactS.Count != 0)
                    {
                        foreach (int PreCont in cContact.Relation.PrevContactS)
                            CreateFirstDepthSymbolTagList(cStep, lstInputSymbol, cErrorPathS, PreCont, bInverse, bOffError);
                    }
                    break;
                }
            }
        }

        private bool CheckRoleType(CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil || who.RoleType == EMStepRoleType.Both)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private bool GetContactSymbolType(CContact cContact)
        {
            bool bASymbolState = true;

            if (cContact.Operator.Contains("XIC"))
                bASymbolState = true;
            else if (cContact.Operator.Contains("XIO"))
                bASymbolState = false;

            return bASymbolState;
        }


        #endregion

        protected override bool BeforeRun()
        {
            if (m_cWriter == null || !m_cWriter.IsConnected)
            {
                UpdateSystemMessage("연결 실패", "Analyzer Error Log Writer 실패");
                m_bRun = false;
            }
            else
                m_bRun = true;

            return m_bRun;
        }

        protected override bool AfterRun()
        {
            return true;
        }

        protected override bool BeforeStop()
        {
            return true;
        }

        protected override bool AfterStop()
        {

            return true;
        }

        protected override void DoThreadWork()
        {
            int iStep = 0;
            bool bCheck = false;
            while (m_bRun)
            {
                Thread.Sleep(1);
                try
                {
                    iStep = 0;
                    object oData = m_cQue.DeQue();
                    if (oData == null) continue;
                    if(oData.GetType() != typeof(CErrorInfo)) continue;

                    CErrorInfo cInfo = (CErrorInfo) oData;
                    m_cCurErrorInfo = cInfo;
                    bool bFirst = true;

                    Stopwatch stw = new Stopwatch();
                    stw.Start();
                    CErrorInfoS cDetailInfoS = GetErrorS();
                    iStep++;
                    stw.Stop();

                    UpdateSystemMessage("Error Analyzer", "Total Detail Info Create Time : " + stw.ElapsedMilliseconds.ToString());

                    iStep++;
                    if (cDetailInfoS == null || cDetailInfoS.Count == 0)
                    {
                        bCheck = false;
                        m_cCurErrorInfo.IsVisible = true;
                        m_cCurErrorInfo.CoilKey = m_cCurErrorInfo.SymbolKey;

                        iStep++;
                        //CMultiProject.ErrorInfoS.Add(m_cCurErrorInfo);
                        //CMultiProject.ErrorView.UpdateView(m_cCurErrorInfo);
                        //CMultiProject.ErrorAlarmView.UpdateError(m_cCurErrorInfo);
                        //CMultiProject.ErrorPanelS.UpdateErrorListPanelS(m_cCurErrorInfo);
                        //CMultiProject.ErrorSummaryPanelS.UpdateErrorListPanelS(m_cCurErrorInfo);
                        iStep++;
                        if (m_cWriter != null && m_cWriter.IsConnected)
                        {
                            m_cWriter.EnQue((CErrorInfo)m_cCurErrorInfo.Clone());
                            UpdateSystemMessage("EmergTimeLogS_ErrorAnlayzer", "Error Log Write");
                        }
                        else
                            UpdateSystemMessage("EmergTimeLogS_ErrorAnlayzer", "DB연결이 실패했습니다");
                        iStep++;
                        //Memory 최적화
                        m_cCurErrorInfo.ErrorLogS.Clear();
                        m_cCurErrorInfo = null;
                    }
                    else
                    {
                        bCheck = true;
                        iStep++;
                        foreach (var who in cDetailInfoS)
                        {
                            if (bFirst)
                            {
                                who.ErrorLogS = m_cCurErrorInfo.ErrorLogS;
                                bFirst = false;
                            }

                            //CMultiProject.ErrorInfoS.Add(who);
                            //CMultiProject.ErrorView.UpdateView(who);
                            //CMultiProject.ErrorAlarmView.UpdateError(who);
                            //CMultiProject.ErrorPanelS.UpdateErrorListPanelS(who);
                            //CMultiProject.ErrorSummaryPanelS.UpdateErrorListPanelS(who);

                            if (m_cWriter != null && m_cWriter.IsConnected)
                            {
                                m_cWriter.EnQue((CErrorInfo)who.Clone());
                                UpdateSystemMessage("EmergTimeLogS_ErrorAnlayzer", "Error Log Write");
                            }
                            else
                                UpdateSystemMessage("EmergTimeLogS_ErrorAnlayzer", "DB연결이 실패했습니다");

                            if(who.ErrorLogS != null)
                                who.ErrorLogS.Dispose();
                        }
                        iStep++;
                        //Memory 최적화
                        m_cCurErrorInfo.ErrorLogS.Dispose();
                        m_cCurErrorInfo = null;
                    }

                    UpdateSystemMessage("Error Analyzer", string.Format("Detail Interlock Error 발생, Count : {0}", cDetailInfoS.Count));

                    //Memory 최적화
                    cDetailInfoS.Clear();
                    cDetailInfoS = null;
                    iStep++;
                    oData = null;

                    //CMultiProject.ErrorLogTable.ShowGrid();
                }
                catch (Exception ex)
                {
                    UpdateSystemMessage("Error Analyzer", string.Format("Error Main Roof = {0}, Fail Step : {1}", ex.Message, iStep));
                    ex.Data.Clear();
                }
            }
        }
    }
}
