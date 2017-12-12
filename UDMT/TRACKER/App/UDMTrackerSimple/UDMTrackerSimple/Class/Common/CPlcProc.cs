using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraTreeList;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMTrackerSimple
{
    [Serializable]
    public class CPlcProc
    {
        #region Member Variables

        private bool m_bErrorMonitoring = false;
        private CTag m_cCycleCheckTag = null;

        private string m_sName = "";
        private DateTime m_dtCycleStartTimeLine = DateTime.MinValue;
        private DateTime m_dtCycleEndTimeLine = DateTime.MinValue;
        private DateTime m_dtChartStartTime = DateTime.MinValue;
        private DateTime m_dtChartEndTime = DateTime.MinValue;

        private int m_iMaxTactTime = 60000;
        private int m_iTargetTactTime = 60000;
        private CConditionS m_cCycleStartConditionS = new CConditionS();
        private CConditionS m_cCycleEndConditionS = new CConditionS();

        private CTagS m_cRecipeWordS = new CTagS();
        private CTag m_cSelectRecipeWord = null;

        private List<string> m_lstAbnormalSymbolS = new List<string>();
        private string m_sTotalAbnormalSymbolKey = string.Empty;
        private bool m_bNormalAbnormalSymbol = false;

        private CKeySymbolS m_cKeySymbolS = new CKeySymbolS();
        private Dictionary<string, int> m_dicAbnormalPriority = null;
        private CCollectTagS m_cCollectCandidateTagS = null;

        [NonSerialized] private CAbnormalSymbolS m_cAbnormalSymbolS = new CAbnormalSymbolS();
        [NonSerialized] private Dictionary<string, CFlowChartItemS> m_dicFlowChartItemS = new Dictionary<string, CFlowChartItemS>();
        [NonSerialized] private CTagS m_cChartTagS = null;
        [NonSerialized] private CTimeLogS m_cChartViewTimeLogS = null;
        [NonSerialized] private CPlcLogicDataS m_cPlcLogicDataS = new CPlcLogicDataS();               
        [NonSerialized] private bool m_bCycleError = false;
        [NonSerialized] private bool m_bCycleStart = false;
        [NonSerialized] private bool m_bCycleEnd = false;
        [NonSerialized] private int m_iCycleID = -1;
        [NonSerialized] private List<string> m_lstAbnormalFilter = null;
        [NonSerialized] private CAbnormalSymbol m_cCurAbnormalSymbol = null;
        [NonSerialized] private List<string> m_lstAllSubDepthKeyList = new List<string>(); 
        [NonSerialized] private List<string> m_lstStep = new List<string>();
        [NonSerialized] private int m_iSetDepth = -1;
        [NonSerialized] private bool m_bOptimizerSelected = false;

        #endregion


        #region Properties

        public bool IsOptimizerSelectedProcess
        {
            get { return m_bOptimizerSelected; }
            set { m_bOptimizerSelected = value; }
        }

        public CCollectTagS CollectCandidateTagS
        {
            get { return m_cCollectCandidateTagS;}
            set { m_cCollectCandidateTagS = value; }
        }

        public Dictionary<string, int> AbnormalSymbolPriority
        {
            get { return m_dicAbnormalPriority;}
            set { m_dicAbnormalPriority = value; }
        }


        public int CollectSubDepth
        {
            get { return m_iSetDepth;}
            set { m_iSetDepth = value; }
        }
        public bool IsErrorMonitoring
        {
            get { return m_bErrorMonitoring;}
            set { m_bErrorMonitoring = value; }
        }

        public CTag CycleCheckTag
        {
            get { return m_cCycleCheckTag;}
            set { m_cCycleCheckTag = value; }
        }

        public List<string> AbnormalSymbolList
        {
            get { return m_lstAbnormalSymbolS; }
            set { m_lstAbnormalSymbolS = value; }
        }

        //public CSubKeySymbolS SubKeySymbolS
        //{
        //    get { return m_cSubKeySymbolS; }
        //    set { m_cSubKeySymbolS = value; }
        //}

        public bool IsNormalAbnormalSymbol
        {
            get { return m_bNormalAbnormalSymbol;}
            set { m_bNormalAbnormalSymbol = value; }
        }
        
        public Dictionary<string, CFlowChartItemS> RecipeFlowItemS
        {
            get { return m_dicFlowChartItemS; }
            set { m_dicFlowChartItemS = value; }
        }

        public string TotalAbnormalSymbolKey
        {
            get { return m_sTotalAbnormalSymbolKey; }
            set { m_sTotalAbnormalSymbolKey = value; }
        }

        public List<string> AbnormalFilter
        {
            get { return m_lstAbnormalFilter; }
            set { m_lstAbnormalFilter = value; }
        }

        public CPlcLogicDataS PlcLogicDataS
        {
            get { return m_cPlcLogicDataS;}
            set { m_cPlcLogicDataS = value; }
        }

        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        public int MaxTactTime
        {
            get { return GetMaxTactTime(); }
        }

        public int TargetTactTime
        {
            get { return m_iTargetTactTime; }
            set { m_iTargetTactTime = value; }
        }

        public CConditionS CycleStartConditionS
        {
            get { return m_cCycleStartConditionS; }
            set { m_cCycleStartConditionS = value; }
        }

        public CConditionS CycleEndConditionS
        {
            get { return m_cCycleEndConditionS; }
            set { m_cCycleEndConditionS = value; }
        }

        /// <summary>
        /// Cycle Condition Tag 포함
        /// </summary>
        public CKeySymbolS KeySymbolS
        {
            get { return m_cKeySymbolS; }
            set { m_cKeySymbolS = value; }
        }

        public CAbnormalSymbolS AbnormalSymbolS
        {
            get { return m_cAbnormalSymbolS; }
            set { m_cAbnormalSymbolS = value; }
        }

        public DateTime CycleStartTimeLine
        {
            get { return m_dtCycleStartTimeLine; }
            set { m_dtCycleStartTimeLine = value; }
        }

        public DateTime CycleEndTimeLine
        {
            get { return m_dtCycleEndTimeLine; }
            set { m_dtCycleEndTimeLine = value; }
        }

        public DateTime ChartStartTime
        {
            get { return m_dtChartStartTime; }
            set { m_dtChartStartTime = value; }
        }

        public DateTime ChartEndTime
        {
            get { return m_dtChartEndTime; }
            set { m_dtChartEndTime = value; }
        }

        /// <summary>
        /// Cycle 선정할때 포함된 TagS
        /// </summary>
        public CTagS ChartViewTagS
        {
            get { return m_cChartTagS; }
            set { m_cChartTagS = value; }
        }

        /// <summary>
        /// 이전 Cycle Start ~ 다음 Cycle Start까지
        /// </summary>
        public CTimeLogS ChartViewTimeLogS
        {
            get { return m_cChartViewTimeLogS;}
            set { m_cChartViewTimeLogS = value; }
        }

        public bool CycleErrorFlag
        {
            get { return m_bCycleError; }
            set { m_bCycleError = value; }
        }

        public bool CycleStartFlag
        {
            get { return m_bCycleStart; }
            set { m_bCycleStart = value; }
        }

        public bool CycleEndFlag
        {
            get { return m_bCycleEnd; }
            set { m_bCycleEnd = value; }
        }

        public int CycleID
        {
            get { return m_iCycleID; }
            set { m_iCycleID = value; }
        }

        public CTagS RecipeWordS
        {
            get { return m_cRecipeWordS; }
            set { m_cRecipeWordS = value; }
        }

        public CTag SelectRecipeWord
        {
            get { return m_cSelectRecipeWord; }
            set { m_cSelectRecipeWord = value; }
        }

        public string CurrentRecipe { get; set; }

        #endregion


        #region Public Method

        public void Clear()
        {
            if (m_cChartTagS != null)
                m_cChartTagS.Clear();

            m_cCycleStartConditionS.Clear();
            m_cCycleEndConditionS.Clear();
            m_cKeySymbolS.Clear();
            m_cAbnormalSymbolS.Clear();
            m_lstAbnormalSymbolS.Clear();

            if(m_dicAbnormalPriority != null)
                m_dicAbnormalPriority.Clear();

            m_cRecipeWordS.Clear();
        }

        public CTagS GetTotalTagS()
        {
            CTagS cTotalTagS = new CTagS();

            CTagS cTagS = m_cKeySymbolS.GetTagS();
            cTotalTagS.AddRange(cTagS);

            cTagS = m_cAbnormalSymbolS.GetTagS();
            cTotalTagS.AddRange(cTagS);

            return cTotalTagS;
        }

        public List<string> GetKeySymbolSFirstSubDepthTagList()
        {
            List<string> lstResult = new List<string>();

            foreach (var who in m_cKeySymbolS)
            {
                CKeySymbol cSymbol = who.Value;
                lstResult.AddRange(cSymbol.FirstTagList.Select(b => b.Key).ToList());
            }

            return lstResult;
        }

        public List<string> GetKeySymbolSEndSubDepthTagList()
        {
            List<string> lstResult = new List<string>();

            foreach (var who in m_cKeySymbolS)
            {
                CKeySymbol cSymbol = who.Value;
                lstResult.AddRange(cSymbol.SubDepthTagKeyList);
            }

            return lstResult;
        }

        public List<string> GetInterlockEndSubDepthTagList()
        {
            List<string> lstResult = new List<string>();

            foreach (var who in m_cAbnormalSymbolS)
            {
                CAbnormalSymbol cSymbol = who.Value;
                lstResult.Add(cSymbol.Tag.Key);
                lstResult.AddRange(cSymbol.SubDepthTagKeyList);
            }

            return lstResult;
        }

        /// <summary>
        /// Process에 포함된 Key SymbolS의 Sub Tag List, Plc Number를 Update
        /// </summary>
        public void UpdateKeySymbolS()
        {
            CTag cTag = null;
            bool bCoil = false;

            foreach (CKeySymbol cKeySymbol in m_cKeySymbolS.Values.Where(x => x.PLCNumber == -1))
            {
                cTag = cKeySymbol.Tag;
                cKeySymbol.PLCNumber = GetPlcNumber(cTag);

                foreach (CTagStepRole cRole in cTag.StepRoleS)
                {
                    if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                    {
                        bCoil = true;
                        break;
                    }
                }

                if (bCoil)
                    cKeySymbol.AllSubDepthTagKeyList = GetDepthContact(cTag, true);
            }
        }

        public void AddCollectTagS(CTag cTag)
        {
            bool bCoil = false;

            foreach (CTagStepRole cRole in cTag.StepRoleS)
            {
                if (cRole.RoleType == EMStepRoleType.Both || cRole.RoleType == EMStepRoleType.Coil)
                {
                    bCoil = true;
                    break;
                }
            }

            if (bCoil)
            {   
                List<string> lstKey = GetDepthContact(cTag, false);

                CCollectTag cCollectTag = null;
                foreach (string sKey in lstKey)
                {
                    if (!m_cCollectCandidateTagS.ContainsKey(sKey))
                    {
                        cCollectTag = new CCollectTag();
                        cCollectTag.Key = sKey;

                        m_cCollectCandidateTagS.Add(sKey, cCollectTag);
                    }
                }
            }
            else
            {
                if (!m_cCollectCandidateTagS.ContainsKey(cTag.Key))
                {
                    CCollectTag cCollectTag = new CCollectTag();
                    cCollectTag.Key = cTag.Key;

                    m_cCollectCandidateTagS.Add(cTag.Key, cCollectTag);
                }
            }
        }

        public void ComposeKeySymbolS()
        {
            CTag cTag = null;
            bool bCoil = false;

            foreach (CKeySymbol cKeySymbol in m_cKeySymbolS.Values)
            {
                cTag = cKeySymbol.Tag;

                foreach (CTagStepRole cRole in cTag.StepRoleS)
                {
                    if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                    {
                        bCoil = true;
                        break;
                    }
                }

                if (bCoil)
                {
                    if(cKeySymbol.AllSubDepthTagKeyList != null && cKeySymbol.AllSubDepthTagKeyList.Count > 0)
                        cKeySymbol.AllSubDepthTagKeyList.Clear();

                    cKeySymbol.AllSubDepthTagKeyList = GetDepthContact(cTag, true);
                }
            }
        }

        //public void UpdateSubKeySymbolS()
        //{
        //    CTag cTag = null;

        //    foreach (CSubKeySymbol cSymbol in m_cSubKeySymbolS.Values.Where(x => x.PLCNumber == -1))
        //    {
        //        cTag = cSymbol.Tag;
        //        cSymbol.PLCNumber = GetPlcNumber(cTag);

        //        foreach (CKeySymbol cKeySymbol in m_cKeySymbolS.Values)
        //        {
        //            if (cKeySymbol.SubDepthTagKeyList != null && cKeySymbol.SubDepthTagKeyList.Count > 0)
        //            {
        //                if (cKeySymbol.SubDepthTagKeyList.Contains(cSymbol.Tag.Key) && !cKeySymbol.SubKeySymbolS.ContainsKey(cSymbol.Tag.Key))
        //                    cKeySymbol.SubKeySymbolS.Add(cSymbol.Tag.Key, cSymbol);
        //            }
        //        }
        //    }

        //}

        /// <summary>
        /// Process에 포함된 Interlock SymbolS의 Sub Tag List, Plc Number를 Update
        /// </summary>
        public void UpdateAbnormalSymbolS()
        {
            CTag cTag = null;
            bool bCoil = false;

            foreach (CAbnormalSymbol cAbnormalSymbol in m_cAbnormalSymbolS.Values.Where(x => x.PLCNumber == -1))
            {
                cTag = cAbnormalSymbol.Tag;
                cAbnormalSymbol.PLCNumber = GetPlcNumber(cTag);

                foreach (CTagStepRole cRole in cTag.StepRoleS)
                {
                    if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                    {
                        bCoil = true;
                        break;
                    }
                }

                //if (bCoil)
                //    cAbnormalSymbol.AllSubDepthTagList = GetAllContact(cTag, EMDataType.Bool);
            }
        }

        public void RemoveAbnormalInfo()
        {
            m_sTotalAbnormalSymbolKey = string.Empty;
            m_bNormalAbnormalSymbol = false;

            if(m_cAbnormalSymbolS != null)
                m_cAbnormalSymbolS.Clear();

            if(m_lstAbnormalSymbolS != null)
                m_lstAbnormalSymbolS.Clear();

            if(m_dicAbnormalPriority != null)
                m_dicAbnormalPriority.Clear();
        }

        public void AddAbnormalSymbolS(CTagS cTagS)
        {
            CTag cTag = null;
            bool bCoil = false;

            foreach (var who in cTagS)
            {
                cTag = who.Value;

                foreach (CTagStepRole cRole in cTag.StepRoleS)
                {
                    if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                    {
                        bCoil = true;
                        break;
                    }
                }

                if (bCoil)
                {
                    m_sTotalAbnormalSymbolKey = cTag.Key;
                    m_cAbnormalSymbolS.AddRange(GetSubAbnormalSymbolS(cTag));

                    m_lstAbnormalSymbolS.Clear();
                    m_lstAbnormalSymbolS.AddRange(m_cAbnormalSymbolS.Keys);
                    SetPriorityHierarchy();
                }
            }
        }

        public void ComposeAbnormalSymbolS(CTag cTag)
        {
            try
            {
                CAbnormalSymbolS cAbnormalS = new CAbnormalSymbolS();

                cAbnormalS.AddRange(GetSubAbnormalSymbolS(cTag));

                foreach (string sKey in m_lstAbnormalSymbolS)
                {
                    if (cAbnormalS.ContainsKey(sKey))
                        m_cAbnormalSymbolS.Add(sKey, cAbnormalS[sKey]);
                }

                if (m_dicAbnormalPriority != null && m_dicAbnormalPriority.Count > 0)
                    SetUserPriorityHierarchy();
                else
                    SetPriorityHierarchy();

                cAbnormalS.Clear();
                cAbnormalS = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void RemoveAllSymbolS(string sKey)
        {
            if(m_cKeySymbolS.ContainsKey(sKey))
                m_cKeySymbolS.Remove(sKey);

            if (m_cAbnormalSymbolS.ContainsKey(sKey))
                m_cAbnormalSymbolS.Remove(sKey);
        }

        public void RemoveSubSymbolS(CTag cTag)
        {
            //if (m_cSubKeySymbolS.ContainsKey(cTag.Key))
            //    m_cSubKeySymbolS.Remove(cTag.Key);

            foreach (var who in m_cKeySymbolS)
            {
                if (who.Value.SubKeySymbolS.ContainsKey(cTag.Key))
                    who.Value.SubKeySymbolS.Remove(cTag.Key);
            }
        }

        public void RemoveEndSubDepthSymbolS(CTag cTag)
        {
            m_cKeySymbolS.RemoveEndSubDepthSymbol(cTag);
        }

        #endregion


        #region Private Methods

        private void SetUserPriorityHierarchy()
        {
            try
            {
                CAbnormalSymbol cSymbol = null;
                foreach (var who in m_dicAbnormalPriority)
                {
                    if (!m_cAbnormalSymbolS.ContainsKey(who.Key))
                        continue;

                    cSymbol = m_cAbnormalSymbolS[who.Key];
                    cSymbol.Priority = who.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetPriorityHierarchy()
        {
            try
            {
                Dictionary<string, bool> dicHierarchy = new Dictionary<string, bool>();

                foreach (string sKey in m_lstAbnormalSymbolS)
                {
                    CAbnormalSymbol cSymbol = m_cAbnormalSymbolS[sKey];

                    if (cSymbol.SubCoil == null || dicHierarchy.ContainsKey(cSymbol.SubCoil.CoilKey))
                        continue;

                    dicHierarchy.Add(cSymbol.SubCoil.CoilKey, false);
                }

                CSubCoil cSubCoil = null;
                int iDepth = 0;
                foreach (var who in m_cAbnormalSymbolS)
                {
                    if (who.Value.SubCoil == null)
                        continue;

                    cSubCoil = who.Value.SubCoil;

                    if (!dicHierarchy.ContainsKey(cSubCoil.CoilKey))
                        continue;

                    iDepth = 0;
                    SetAbnormalHierarchy(cSubCoil, dicHierarchy, iDepth);

                    foreach (string sKey in m_lstAbnormalSymbolS)
                    {
                        CAbnormalSymbol cSymbol = m_cAbnormalSymbolS[sKey];

                        if (cSymbol.SubCoil == null)
                            continue;

                        dicHierarchy[cSymbol.SubCoil.CoilKey] = false;
                    }
                }

                if(m_dicAbnormalPriority == null)
                    m_dicAbnormalPriority = new Dictionary<string, int>();

                m_dicAbnormalPriority.Clear();

                foreach (var who in m_cAbnormalSymbolS)
                    m_dicAbnormalPriority.Add(who.Key, who.Value.Priority);

                dicHierarchy.Clear();
                dicHierarchy = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetAbnormalHierarchy(CSubCoil cCoil, Dictionary<string, bool> dicHierarchy, int iDepth)
        {
            try
            {
                iDepth++;

                if (dicHierarchy.ContainsKey(cCoil.CoilKey) && !dicHierarchy[cCoil.CoilKey])
                {
                    dicHierarchy[cCoil.CoilKey] = true;

                    if(m_cAbnormalSymbolS.GetAbnormalSymbol(cCoil.CoilKey).Priority <= iDepth)
                        m_cAbnormalSymbolS.GetAbnormalSymbol(cCoil.CoilKey).Priority = iDepth;
                }

                if (cCoil.SubCoilS.Count > 0)
                {
                    foreach (CSubCoil cSubCoil in cCoil.SubCoilS)
                        SetAbnormalHierarchy(cSubCoil, dicHierarchy, iDepth);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }



        //private void SetMaxTactTime()
        //{
        //    m_iMaxTactTime = (m_iTargetTactTime*3)/2;
        //}

        private int GetMaxTactTime()
        {
            m_iMaxTactTime = (m_iTargetTactTime * 3) / 2;
            return m_iMaxTactTime;
        }

        private int GetPlcNumber(CTag cTag)
        {
            int PlcNumber = 0;
            string sPlcID = string.Empty;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cTag.Key))
                {
                    sPlcID = cData.PLCID;
                    PlcNumber = Convert.ToInt32(sPlcID.Split('-')[1].ToString());
                    break;
                }
            }

            return PlcNumber;
        }

        private CAbnormalSymbolS GetSubAbnormalSymbolS(CTag cBaseTag)
        {
            CAbnormalSymbolS cSymbolS = new CAbnormalSymbolS();

            List<CStep> lstStep = GetStepList(cBaseTag);

            foreach (CStep cStep in lstStep)
            {
                SetSubAbnormalSymbolList(cStep, cSymbolS);

                foreach (var who in cSymbolS)
                {
                    foreach (string sKey in cStep.RefTagS.KeyList)
                    {
                        if (!who.Value.AllSubDepthTagKeyList.Contains(sKey))
                        {
                            List<string> lstSmae = cStep.RefTagS.KeyList.Except(who.Value.AllSubDepthTagKeyList).ToList();
                            who.Value.AllSubDepthTagKeyList.AddRange(lstSmae);
                            //who.Value.AllSubDepthTagKeyList.AddRange(cStep.RefTagS.KeyList);
                        }
                    }
                }
            }

            return cSymbolS;
        }

        //private List<CTag> GetStepContact(CTag cTag)
        //{
        //    List<CTag> lstStepTag = new List<CTag>();
        //    CPlcLogicData cLogicData = null;

        //    foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
        //    {
        //        if (cData.TagS.ContainsKey(cTag.Key))
        //        {
        //            cLogicData = cData;
        //            break;
        //        }
        //    }

        //    if (cLogicData == null)
        //        return lstStepTag;

        //    CStep cStep;
        //    CTagStepRole cRole;
        //    for (int i = 0; i < cTag.StepRoleS.Count; i++)
        //    {
        //        cRole = cTag.StepRoleS[i];

        //        if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
        //            continue;

        //        if (cLogicData.StepS.ContainsKey(cRole.StepKey))
        //        {
        //            cStep = cLogicData.StepS[cRole.StepKey];

        //            if (cStep.CoilS.GetFirstCoil().CoilType != EMCoilType.Bit)
        //                continue;

        //            lstStepTag.AddRange(GetTagList(cStep));
        //        }
        //    }

        //    return lstStepTag;
        //}

        private List<string> GetStepContact(CTag cTag)
        {
            List<string> lstStepTagKey = new List<string>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if (cLogicData == null)
                return lstStepTagKey;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];

                if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
                    continue;

                if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                {
                    cStep = cLogicData.StepS[cRole.StepKey];

                    if (cStep.CoilS.GetFirstCoil().CoilType != EMCoilType.Bit)
                        continue;

                    lstStepTagKey.AddRange(GetTagKeyList(cStep));
                }
            }

            return lstStepTagKey;
        }

        private bool CheckContainCoilTag(CCoil cCoil, CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cCoil.ContentS)
            {
                if (who.Tag != null && who.Tag.Key == cTag.Key)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private List<CStep> GetStepList(CTag cTag)
        {
            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cLogicData = null;

            if (m_cPlcLogicDataS.Count == 0)
            {
                cLogicData = CMultiProject.GetPlcLogicData(cTag);

                if(cLogicData != null)
                    m_cPlcLogicDataS.Add(cLogicData.PLCID, cLogicData);
            }
            else
            {
                foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
                {
                    if (cData.TagS.ContainsKey(cTag.Key))
                    {
                        cLogicData = cData;
                        break;
                    }
                }
            }

            if (cLogicData == null)
                return lstStep;

            CStep cStep;
            CTagStepRole cRole;
            EMCoilType emCoilType = EMCoilType.None;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];

                if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
                    continue;

                if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                {
                    cStep = cLogicData.StepS[cRole.StepKey];

                    if (cRole.RoleType == EMStepRoleType.Both && cStep.CoilS.Count > 0 &&
                        !CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                        continue;

                    emCoilType = cStep.CoilS.GetFirstCoil().CoilType;

                    if (emCoilType.Equals(EMCoilType.Bit) || emCoilType.Equals(EMCoilType.Function) || emCoilType.Equals(EMCoilType.None) || emCoilType.Equals(EMCoilType.Timer) || emCoilType.Equals(EMCoilType.Counter))
                        lstStep.Add(cStep);
                }
            }

            if (cLogicData.Maker == EMPLCMaker.Rockwell &&
                (cTag.Address.Contains(".DN") || cTag.Address.Contains(".EN")))
            {
                string sTemp = cTag.Address.Split('.')[0];
                string sKey = string.Format("[{0}]{1}[{2}]", cTag.Channel, sTemp, cTag.Size);

                if(cLogicData.TagS.ContainsKey(sKey))
                    lstStep = GetABStepList(cLogicData.TagS[sKey]);
            }

            return lstStep;
        }

        private List<CStep> GetABStepList(CTag cTag)
        {
            List<CStep> lstStep = new List<CStep>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if (cLogicData == null)
                return lstStep;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];

                if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
                    continue;

                if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                {
                    cStep = cLogicData.StepS[cRole.StepKey];
                    lstStep.Add(cStep);
                }
            }

            return lstStep;
        }

        private List<CSymbolTag> GetStepSymbolTagContact(CTag cTag)
        {
            List<CSymbolTag> lstStepTag = new List<CSymbolTag>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if(cLogicData == null)
                return lstStepTag;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cTag.StepRoleS.Count; i++)
            {
                cRole = cTag.StepRoleS[i];

                if (cRole.RoleType != EMStepRoleType.Both && cRole.RoleType != EMStepRoleType.Coil)
                    continue;

                if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                {
                    cStep = cLogicData.StepS[cRole.StepKey];

                    if (cStep.CoilS.GetFirstCoil().CoilType != EMCoilType.Bit)
                        continue;

                    SetFirstDepthSymbolTagList(cStep, lstStepTag);
                }
            }

            return lstStepTag;
        }

        private void SetFirstDepthSymbolTagList(CContact cContact, bool bInverse, List<CSymbolTag> lstSymbolTag)
        {
            CSymbolTag cSymbolTag;
            for (int i = 0; i < cContact.RefTagS.Count; i++)
            {
                if (cContact.RefTagS[i].DataType != EMDataType.Bool || !CheckAbnormalTag(cContact.RefTagS[i]))
                    continue;

                cSymbolTag = new CSymbolTag(cContact.RefTagS[i]);
                cSymbolTag.IsAStateSymbol = GetContactSymbolType(cContact);
                cSymbolTag.IsRelatedInverse = bInverse;

                if (CheckSymbolTag(lstSymbolTag, cSymbolTag))
                    lstSymbolTag.Add(cSymbolTag);
            }
        }

        private bool CheckSymbolTag(List<CSymbolTag> lstSymbolTag, CSymbolTag cSymbolTag)
        {
            bool bOK = true;

            CTag cTag;
            foreach(var who in lstSymbolTag)
            {
                cTag = who.Tag;

                if(cTag.Key == cSymbolTag.Tag.Key)
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        private void SetFirstDepthSymbolTagList(CStep cStep, List<CSymbolTag> lstTotalSymbolTag)
        {
            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if (cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach (int PreCont in cCoil.Relation.PrevContactS)
                    CreateFirstDepthSymbolTagList(cStep, lstTotalSymbolTag, PreCont, false);
            }
        }

        private bool CheckRoleType(CTag cTag)
        {
            bool bOK = false;

            if (cTag == null)
                return false;
            
            //AB 대응
            if (cTag.Address.Contains(".DN") || cTag.Address.Contains(".EN"))
                return true;

            if (
                cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Both || x.RoleType == EMStepRoleType.Coil)
                    .Count() > 0)
                bOK = true;

            return bOK;
        }

        private void CreateFirstDepthSymbolTagList(CStep cStep, List<CSymbolTag> lstSymbolTag, int iStepIndex, bool bInverse)
        {
            foreach (CContact cContact in cStep.ContactS)
            {
                if (cContact.StepIndex == iStepIndex)
                {
                    if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit)
                        SetFirstDepthSymbolTagList(cContact, bInverse, lstSymbolTag);

                    if (cContact.Operator.Contains("INV"))
                        bInverse = true;

                    if (cContact.Relation.PrevContactS.Count != 0)
                    {
                        foreach (int PreCont in cContact.Relation.PrevContactS)
                            CreateFirstDepthSymbolTagList(cStep, lstSymbolTag, PreCont, bInverse);
                    }
                    break;
                }
            }
        }

        private List<string> GetAllContact(CTag cBaseTag, EMDataType emDataType)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<string> lstTotalTag = new List<string>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cBaseTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if (cLogicData == null)
                return lstTotalTag;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseTag.StepRoleS.Count; i++)
            {
                cRole = cBaseTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = cLogicData.StepS[cRole.StepKey];

                        if (cRole.RoleType == EMStepRoleType.Both && cStep.CoilS.Count > 0 &&
                            !CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cBaseTag))
                            continue;

                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            SetTagList(GetTagList(cStep), lstTotalTag, true);
                            TraceAllEndContact(cLogicData.StepS, lstTotalStep, lstTotalTag, cStep, emDataType);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTag;
        }

        private List<string> GetDepthContact(CTag cBaseTag, bool bWordCollect)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<string> lstTotalTag = new List<string>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cBaseTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if (cLogicData == null)
                return lstTotalTag;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseTag.StepRoleS.Count; i++)
            {
                cRole = cBaseTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = cLogicData.StepS[cRole.StepKey];

                        if (cRole.RoleType == EMStepRoleType.Both && cStep.CoilS.Count > 0 &&
                            !CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cBaseTag))
                            continue;

                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            SetTagList(GetTagList(cStep), lstTotalTag, bWordCollect);
                            TraceDepthContact(cLogicData.StepS, lstTotalStep, lstTotalTag, cStep, bWordCollect, 0);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTag;
        }


        private List<CTag> GetTagList(CStep cStep)
        {
            List<CTag> lstTag = new List<CTag>();

            if (cStep == null)
                return lstTag;

            CTag cTag;

            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                //if (!cTag.PLCMaker.ToString().Contains("Mitsubishi") 
                //    && cTag.DataType != EMDataType.Bool) continue;

                if (lstTag.Contains(cTag) == false)
                    lstTag.Add(cTag);
            }

            return lstTag;
        }

        private List<string> GetTagKeyList(CStep cStep)
        {
            List<string> lstTagKey = new List<string>();

            if (cStep == null)
                return lstTagKey;

            CTag cTag;

            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                if (cTag.DataType != EMDataType.Bool) continue;

                if (lstTagKey.Contains(cTag.Key) == false)
                    lstTagKey.Add(cTag.Key);
            }
            return lstTagKey;
        }

        private List<string> GetOneDepthContainTagList(CStep cStep, string sTagKey)
        {
            List<string> lstTagKey = new List<string>();
            List<CTag> lstTemp = null;

            CTag cTag;
            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];

                if (cTag.Key == sTagKey)
                    continue;

                //if (!cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.DataType != EMDataType.Bool) continue;
                if (!m_lstAllSubDepthKeyList.Contains(cTag.Key))
                {
                    m_lstAllSubDepthKeyList.Add(cTag.Key);
                    lstTagKey.Add(cTag.Key);
                }

                if (CheckRoleType(cTag))
                {
                    lstTemp = GetTagList(GetStep(cTag));

                    foreach (var who in lstTemp)
                    {
                        if(!m_lstAllSubDepthKeyList.Contains(who.Key))
                        {
                            m_lstAllSubDepthKeyList.Add(who.Key);
                            lstTagKey.Add(who.Key);
                        }
                    }
                }
            }

            return lstTagKey;
        }

        private List<string> GetAllDepthContainTagList(CStep cStep, string sTagKey, int iCurDepth)
        {
            List<string> lstTagKey = new List<string>();
            List<CTag> lstTemp = null;

            if (m_iSetDepth < iCurDepth)
                return lstTagKey;

            int iTempDepth = iCurDepth;
            CTag cTag;
            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];

                if (cTag.Key == sTagKey)
                    continue;

                iCurDepth = iTempDepth;
                if (!m_lstAllSubDepthKeyList.Contains(cTag.Key))
                {
                    m_lstAllSubDepthKeyList.Add(cTag.Key);
                    lstTagKey.Add(cTag.Key);
                }

                if (CheckRoleType(cTag))
                {
                    CStep cSubStep = GetStep(cTag);

                    if (cSubStep == null)
                        continue;

                    if (m_lstStep.Contains(cSubStep.Key))
                        continue;
                    else
                        m_lstStep.Add(cSubStep.Key);

                    lstTemp = GetTagList(cSubStep);

                    foreach (var who in lstTemp)
                    {
                        if (!m_lstAllSubDepthKeyList.Contains(who.Key))
                        {
                            m_lstAllSubDepthKeyList.Add(who.Key);
                            lstTagKey.Add(who.Key);
                        }
                    }
                    iCurDepth++;
                    lstTagKey.AddRange(GetAllDepthContainTagList(cSubStep, cTag.Key, iCurDepth));
                }
            }

            return lstTagKey;
        }


        private void SetSubAbnormalSymbolList(CStep cStep, CAbnormalSymbolS cSymbolS)
        {
            if (cStep == null)
                return;

            bool bInverse = false;
            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if (cCoil.ContentS[0].Tag == null)
                return;

            if (m_bNormalAbnormalSymbol)
                bInverse = true;

            if (cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach(int PreCont in cCoil.Relation.PrevContactS)
                    CreateSubAbnormalList(cStep, cSymbolS, PreCont, bInverse);
            }
        }

        private void CreateSubAbnormalList(CStep cStep, CAbnormalSymbolS cSymbolS, int iStepIndex, bool bInverse)
        {
            CContact cContact = cStep.ContactS.Find(x => x.StepIndex == iStepIndex);

            if (cContact == null)
                return;

            if (cContact.StepIndex == iStepIndex)
            {
                if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit &&
                    cContact.ContentS[0].Tag.Key != cStep.CoilS[0].ContentS[0].Tag.Key &&
                    cContact.ContentS[0].Tag.Key != m_sTotalAbnormalSymbolKey)
                    cSymbolS.AddRange(GetSubAbnormalSymbolS(cContact, bInverse));

                if (cContact.Operator.Contains("INV"))
                    bInverse = true;

                if (cContact.Relation.PrevContactS.Count != 0)
                {
                    foreach (int PreCont in cContact.Relation.PrevContactS)
                        CreateSubAbnormalList(cStep, cSymbolS, PreCont, bInverse);
                }
            }
        }

        public bool CheckAbnormalTag(CTag cTag)
        {
            bool bOK = false;

            string sDescription = cTag.Description;

            if (sDescription.ToUpper().Contains("RESET") || sDescription.ToUpper().Contains("RST") || sDescription.Contains("해제") || sDescription.Contains("리셋")
                || sDescription.Contains("항상 OFF") || sDescription.Contains("선택"))
                return bOK;

            foreach (string sFilter in m_lstAbnormalFilter)
            {
                if (sDescription.ToUpper().Contains(sFilter))
                {
                    if (sFilter == "NG" && sDescription.Contains("ING"))
                            continue;

                    bOK = true;
                    break;
                }
            }

            return bOK;
        }

        private CAbnormalSymbolS GetSubAbnormalSymbolS(CContact cContact, bool bInverse)
        {
            CAbnormalSymbolS cSubSymbolS = new CAbnormalSymbolS();

            CTag cTag = null;
            CAbnormalSymbol cSubSymbol = null;
            for (int i = 0; i < cContact.RefTagS.Count; i++)
            {
                cTag = cContact.RefTagS[i];

                //Abnormal Symbol은 Bit로만, Sub Coil은 Word도 가능
                if (cTag.DataType != EMDataType.Bool )
                    continue;

                if (cTag.Description.ToUpper().Contains("RESET") || cTag.Description.ToUpper().Contains("RST") ||
                    cTag.Description.Contains("해제") || cTag.Description.Contains("리셋") || cTag.Description.Contains("항상 OFF"))
                    continue;

                cSubSymbol = new CAbnormalSymbol(cTag);
                cSubSymbol.IsAStateSymbol = GetContactSymbolType(cContact);
                cSubSymbol.IsRelatedInverse = bInverse;
                
                m_cCurAbnormalSymbol = cSubSymbol;

                cSubSymbol.SubCoil = GetAbnormalSubCoil(cTag);

                if(cSubSymbol.SubCoil != null)
                    cSubSymbol.SubCoil.IsASymbolState = cSubSymbol.IsAStateSymbol;

                if(!cSubSymbol.AllSubDepthTagKeyList.Contains(m_sTotalAbnormalSymbolKey))
                    cSubSymbol.AllSubDepthTagKeyList.Add(m_sTotalAbnormalSymbolKey);

                string sSubKey = string.Format("_{0}", cSubSymbol.IsAStateSymbol == true ? "A" : "B");

                if (!cSubSymbolS.ContainsKey(cSubSymbol.Tag.Key + sSubKey))
                    cSubSymbolS.Add(cSubSymbol.Tag.Key + sSubKey, cSubSymbol);
            }

            m_cCurAbnormalSymbol = null;

            return cSubSymbolS;
        }

        private CSubCoil GetAbnormalSubCoil(CTag cTag)
        {
            CSubCoil cSubCoil = new CSubCoil();
            CStep cStep = null;
            int iCurDepth = 0;

            cStep = GetStep(cTag);

            if (cStep == null)
                return null;

            if (m_lstAllSubDepthKeyList == null)
                m_lstAllSubDepthKeyList = new List<string>();

            if(m_lstStep == null)
                m_lstStep = new List<string>();

            m_lstAllSubDepthKeyList.Clear();
            m_lstStep.Clear();

            m_lstStep.Add(cStep.Key);
            m_lstAllSubDepthKeyList.Add(cTag.Key);
            m_cCurAbnormalSymbol.AllSubDepthTagKeyList.Add(cTag.Key);

            List<string> lstOneDepth =
                GetAllDepthContainTagList(cStep, cTag.Key, 0)
                    .FindAll(x => !m_cCurAbnormalSymbol.AllSubDepthTagKeyList.Contains(x));

            if(lstOneDepth != null)
                m_cCurAbnormalSymbol.AllSubDepthTagKeyList.AddRange(lstOneDepth);

            cSubCoil.CoilKey = cTag.Key;
            cSubCoil.CurDepth = iCurDepth;
            cSubCoil.StepKey = cStep.Key;
            cSubCoil.SubLogicPathS = GetSubLogicPathS(cStep, cSubCoil);

            bool bInverse = false;
            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if (cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach (int PreCont in cCoil.Relation.PrevContactS)
                {
                    iCurDepth = 0;
                    CreateSubCoilList(cStep, cSubCoil, iCurDepth, PreCont, bInverse);
                }
            }

            return cSubCoil;
        }

        private void CreateSubCoilList(CStep cStep, CSubCoil cSubCoil, int iCurDepth, int iStepIndex, bool bInverse)
        {
            if (iCurDepth >= 7)
                return;
            Application.DoEvents();
            List<string> lstTotalStepKey = new List<string>();

            CContact cContact = cStep.ContactS.Find(x => x.StepIndex == iStepIndex);

            if (cContact.StepIndex == iStepIndex)
            {
                lstTotalStepKey.Clear();
                lstTotalStepKey.Add(cStep.Key);

                if (!cContact.Operator.Contains("INV") && CheckSubCoilCondition(cStep, cContact))
                    SetSubCoil(cSubCoil.SubCoilS, cContact, iCurDepth, lstTotalStepKey, bInverse);

                if (cContact.Operator.Contains("INV"))
                    bInverse = true;

                if (cContact.Relation.PrevContactS.Count != 0)
                {
                    foreach (int PreCont in cContact.Relation.PrevContactS)
                        CreateSubCoilList(cStep, cSubCoil, iCurDepth, PreCont, bInverse);
                }
            }
        }

        private bool CheckSubCoilCondition(CStep cStep, CContact cContact)
        {
            bool bOK = true;

            if (cContact.ContactType != EMContactType.Bit) return false;
            if (cContact.ContentS.Count == 0) return false;
            if (!CheckRoleType(cContact.ContentS[0].Tag)) return false;
            if (!cContact.ContentS[0].Tag.PLCMaker.ToString().Contains("Mitsubishi") 
                && cContact.ContentS[0].Tag.DataType != EMDataType.Bool) return false;
            //if (cContact.ContentS[0].Tag.DataType != EMDataType.Bool) return false;
            if (!CheckAbnormalTag(cContact.ContentS[0].Tag)) return false;
            if (cContact.ContentS[0].Tag.Key == m_sTotalAbnormalSymbolKey) return false;
            if (cContact.ContentS[0].Tag.Key == cStep.CoilS[0].ContentS[0].Tag.Key) return false;

            return bOK;
        }

        private CSubLogicPathS GetSubLogicPathS(CStep cStep, CSubCoil cSubCoil)
        {
            CSubLogicPathS cLogicPathS = new CSubLogicPathS();
            CSubLogicPath cLogicPath = null;

            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if(cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach(int PreCont in cCoil.Relation.PrevContactS)
                {
                    cLogicPath = new CSubLogicPath();
                    CreateSubLogicPathS(cStep, cLogicPathS, cLogicPath, PreCont, false);
                }
            }

            return cLogicPathS;
        }

        private void CreateSubLogicPathS(CStep cStep, CSubLogicPathS cLogicPathS, CSubLogicPath cLogicPath, int StepIndex, bool bInverse)
        {
            CSubContactS cNewSubContact = null;

            bool bFirst = true;

            CContact cContact = cStep.ContactS.Find(x => x.StepIndex == StepIndex);

            if (cContact == null)
                return;

                if (cContact.StepIndex == StepIndex)
                {
                    if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit)
                    {
                        if (cContact.ContentS.Count > 0)
                        {
                            if (cContact.ContentS[0].Tag == null)
                            {
                                if (cContact.Relation.PrevContactS.Count == 0)
                                {
                                    cLogicPathS.Add(cLogicPath);
                                    return;
                                }
                            }
                            else
                            {
                                if (cContact.ContentS[0].Tag.Key == cStep.CoilS[0].ContentS[0].Tag.Key)
                                    return;
                            }

                            SetSubContactS(cLogicPath.SubContactS, cContact, bInverse);
                            cNewSubContact = cLogicPath.SubContactS.Clone();
                        }
                    }

                    if (cContact.Operator.Contains("INV"))
                        bInverse = true;

                    if (cContact.Relation.PrevContactS.Count != 0)
                    {
                        foreach (int PreCont in cContact.Relation.PrevContactS)
                        {
                            if (bFirst)
                            {
                                CreateSubLogicPathS(cStep, cLogicPathS, cLogicPath, PreCont, bInverse);
                                bFirst = false;
                            }
                            else
                            {
                                CSubLogicPath cNewLogicPath = new CSubLogicPath();

                                if(cNewSubContact != null)
                                    cNewLogicPath.SubContactS = cNewSubContact.Clone();

                                CreateSubLogicPathS(cStep, cLogicPathS, cNewLogicPath, PreCont, bInverse);
                            }
                        }
                    }
                    else
                        cLogicPathS.Add(cLogicPath);
                }   
        }

        private void SetSubContactS(CSubContactS cSubContactS, CContact cContact, bool bInverse)
        {
            if (cContact.ContentS[0].Tag == null)
                return;

            if (cSubContactS.ContainsKey(cContact.ContentS[0].Tag.Key))
                return;

            if (cContact.ContentS[0].Tag.DataType != EMDataType.Bool)
                return;

            CSubContact cSubContact = new CSubContact(cContact.ContentS[0].Tag.Key);
            cSubContact.IsInverse = bInverse;
            cSubContact.IsASymbolState = GetContactSymbolType(cContact);
            cSubContact.IsEndContact = IsEndContact(cContact);
            cSubContactS.Add(cSubContact.Key, cSubContact);
        }

        private bool IsEndContact(CContact cContact)
        {
            bool bOK = true;

            CTag cTag = null;
            foreach (string sKey in cContact.RefTagS.KeyList)
            {
                if (!CMultiProject.TotalTagS.ContainsKey(sKey))
                    continue;

                cTag = CMultiProject.TotalTagS[sKey];

                if (
                    cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Both || x.RoleType == EMStepRoleType.Coil)
                        .Count() > 0)
                {
                    bOK = false;
                    break;
                }
            }

            return bOK;
        }

        private CStep GetStep(CTag cTag)
        {
            CStep cStep = null;
            List<CStep> lstStep = GetStepList(cTag);

            if (lstStep == null || lstStep.Count == 0)
                return null;

            if (lstStep.Count == 1 && !lstStep[0].Instruction.Contains("RST"))
                cStep = lstStep[0];

            if (lstStep.Count == 2)
            {
                if (!lstStep[0].Instruction.Contains("RST"))
                    cStep = lstStep[0];
                else
                    cStep = lstStep[1];
            }

            return cStep;
        }

        private void SetSubCoil(CSubCoilS cSubCoilS, CContact cContact, int iCurDepth, List<string> lstTotalStepKey, bool bInverse)
        {
            CSubCoil cSubCoil = null;

            CTag cTag = cContact.ContentS.First().Tag;
            CStep cSubStep = GetStep(cTag);

            if (cSubStep == null) return;

            CCoil cCoil = cSubStep.CoilS.First();

            if (cCoil.CoilType != EMCoilType.Bit)
                return;

            if (!lstTotalStepKey.Contains(cSubStep.Key))
            {
                lstTotalStepKey.Add(cSubStep.Key);
                iCurDepth++;

                List<string> lstOneDepth = GetAllDepthContainTagList(cSubStep, cTag.Key, 0).FindAll(x => !m_cCurAbnormalSymbol.AllSubDepthTagKeyList.Contains(x));

                if(lstOneDepth != null)
                    m_cCurAbnormalSymbol.AllSubDepthTagKeyList.AddRange(lstOneDepth);

                cSubCoil = new CSubCoil();
                cSubCoil.CoilKey = cTag.Key;
                cSubCoil.CurDepth = iCurDepth;
                cSubCoil.StepKey = cSubStep.Key;
                if (cCoil.CoilType == EMCoilType.Function)
                    cSubCoil.IsFunction = true;

                //현재 Melsec에 경우에만 Word 수집
                if (cTag.DataType != EMDataType.Bool)
                {
                    cSubCoil.IsWordCoil = true;

                    if (cSubStep.CoilS.GetFirstCoil().ContentS != null ||
                        cSubStep.CoilS.GetFirstCoil().ContentS.Count > 1)
                        cSubCoil.WordContent = cSubStep.CoilS.GetFirstCoil().ContentS[1];
                }

                cSubCoil.IsASymbolState = GetContactSymbolType(cContact);
                cSubCoil.SubLogicPathS = GetSubLogicPathS(cSubStep, cSubCoil);
                cSubCoil.IsInverse = bInverse;

                if (!CheckContainSubCoil(cSubCoilS, cSubCoil.CoilKey))
                    cSubCoilS.Add(cSubCoil);
            }
            else
                return;

            bool bNewInverse = false;

            if (cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach (int PreCont in cCoil.Relation.PrevContactS)
                    CreateSubCoilList(cSubStep, cSubCoil, iCurDepth, PreCont, bNewInverse);
            }
        }

        private bool CheckContainSubCoil(CSubCoilS cSubCoilS, string sKey)
        {
            bool bOK = false;

            foreach(var who in cSubCoilS)
            {
                if(who.CoilKey == sKey)
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

        private void SetTagList(List<CTag> lstAdd, List<string> lstTotalTag, bool bWordCollect)
        {
            foreach (CTag cTag in lstAdd)
            {
                //if (!cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.DataType != EMDataType.Bool)
                //    continue;

                if (!bWordCollect && cTag.DataType != EMDataType.Bool)
                    continue;

                if (!lstTotalTag.Contains(cTag.Key))
                    lstTotalTag.Add(cTag.Key);
            }
        }

        private void SetInputTagList(List<CTag> lstAdd, List<string> lstTotalTagKey)
        {
            foreach (CTag cTag in lstAdd)
            {
                if (cTag.DataType != EMDataType.Bool)
                    continue;

                if (CheckPlcInputDevice(cTag) == false)
                    continue;

                if (!cTag.IsEndContact() && !CheckFBRelatedCoil(cTag))
                    continue;

                if (!lstTotalTagKey.Contains(cTag.Key))
                    lstTotalTagKey.Add(cTag.Key);
            }
        }

        private bool CheckFBRelatedCoil(CTag cTag)
        {
            bool bOK = false;

            foreach(CTagStepRole cRole in cTag.StepRoleS)
            {
                if(cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (cRole.StepKey.Contains("FB") || cRole.StepKey.Contains("FC"))
                        bOK = true;
                    else
                        bOK = false;
                }
            }

            return bOK;
        }

        private List<string> GetEndContactList(CTag cBaseTag, EMDataType emDataType)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<string> lstTotalTagKey = new List<string>();
            CPlcLogicData cLogicData = null;

            foreach (CPlcLogicData cData in m_cPlcLogicDataS.Values)
            {
                if (cData.TagS.ContainsKey(cBaseTag.Key))
                {
                    cLogicData = cData;
                    break;
                }
            }

            if (cLogicData == null)
                return lstTotalTagKey;

            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseTag.StepRoleS.Count; i++)
            {
                cRole = cBaseTag.StepRoleS[i];
                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                {
                    if (cLogicData.StepS.ContainsKey(cRole.StepKey))
                    {
                        cStep = cLogicData.StepS[cRole.StepKey];
                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            SetInputTagList(GetTagList(cStep), lstTotalTagKey);
                            TraceEndContact(cLogicData.StepS, lstTotalStep, lstTotalTagKey, cStep, emDataType);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTagKey;
        }

        private bool CheckPlcInputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.PLCMaker.ToString().Contains("Mitsubishi") && cTag.Address.StartsWith("X"))
                return true;

            //Seimens
            if (cTag.PLCMaker.Equals(EMPLCMaker.Siemens) && cTag.Address.StartsWith("I"))
                return true;

            //LS
            if (cTag.PLCMaker.Equals(EMPLCMaker.LS) && cTag.Address.StartsWith("P"))
                return true;

            return false;
        }

        //private bool CheckAbnormalDescription(string sDescription)
        //{
            
        //}

        private void TraceEndContact(CStepS cCurStepS, List<CStep> lstTotalStep, List<string> lstTotalTagKey, CStep cBaseStep, EMDataType emDataType)
        {
            CTag cTag;
            CStep cStep;
            CTagStepRole cRole;

            for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
            {
                cTag = cBaseStep.RefTagS[i];

                if (!cTag.IsEndContact() && cTag.Address != cBaseStep.Address)
                {
                    for (int j = 0; j < cTag.StepRoleS.Count; j++)
                    {
                        cRole = cTag.StepRoleS[j];
                        if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
                        {
                            if (cCurStepS.ContainsKey(cRole.StepKey))
                            {
                                cStep = cCurStepS[cRole.StepKey];
                                if (lstTotalStep.Contains(cStep) == false)
                                {
                                    lstTotalStep.Add(cStep);
                                    SetInputTagList(GetTagList(cStep), lstTotalTagKey);

                                    TraceEndContact(cCurStepS, lstTotalStep, lstTotalTagKey, cStep, emDataType);
                                }
                            }
                        }
                    }
                }
                
            }
        }

        private void TraceAllEndContact(CStepS cCurStepS, List<CStep> lstTotalStep, List<string> lstTotalTag, CStep cBaseStep, EMDataType emDataType)
        {
            CTag cTag;
            CStep cStep;
            CTagStepRole cRole;
            List<CTagStepRole> lstRole = null;
            Application.DoEvents();
            for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
            {
                cTag = cBaseStep.RefTagS[i];
                if (!cTag.IsEndContact())
                {
                    lstRole = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Both || x.RoleType == EMStepRoleType.Coil).ToList();

                    if (lstRole.Where(x => x.RoleType == EMStepRoleType.Coil).Count() > 2)
                        continue;

                    if (lstRole != null && lstRole.Count > 0)
                    {
                        for (int j = 0; j < lstRole.Count; j++)
                        {
                            cRole = lstRole[j];
                            if (cCurStepS.ContainsKey(cRole.StepKey))
                            {
                                cStep = cCurStepS[cRole.StepKey];
                                if (lstTotalStep.Contains(cStep) == false)
                                {
                                    lstTotalStep.Add(cStep);
                                    SetTagList(GetTagList(cStep), lstTotalTag, true);
                                    TraceAllEndContact(cCurStepS, lstTotalStep, lstTotalTag, cStep, emDataType);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void TraceDepthContact(CStepS cCurStepS, List<CStep> lstTotalStep, List<string> lstTotalTag, CStep cBaseStep, bool bWordCollect, int iCurDepth)
        {
            if (m_iSetDepth < iCurDepth)
                return;

            CTag cTag;
            CStep cStep;
            CTagStepRole cRole;
            List<CTagStepRole> lstRole = null;
            int iTempDepth = iCurDepth;
            Application.DoEvents();
            for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
            {
                cTag = cBaseStep.RefTagS[i];
                if (!cTag.IsEndContact())
                {
                    iCurDepth = iTempDepth;

                    lstRole = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Both || x.RoleType == EMStepRoleType.Coil).ToList();

                    if (lstRole.Where(x => x.RoleType == EMStepRoleType.Coil).Count() > 2)
                        continue;

                    if (lstRole != null && lstRole.Count > 0)
                    {
                        for (int j = 0; j < lstRole.Count; j++)
                        {
                            cRole = lstRole[j];
                            if (cCurStepS.ContainsKey(cRole.StepKey))
                            {
                                cStep = cCurStepS[cRole.StepKey];
                                if (lstTotalStep.Contains(cStep) == false)
                                {
                                    iCurDepth++;
                                    lstTotalStep.Add(cStep);
                                    SetTagList(GetTagList(cStep), lstTotalTag, bWordCollect);
                                    TraceDepthContact(cCurStepS, lstTotalStep, lstTotalTag, cStep, bWordCollect, iCurDepth);
                                }
                            }
                        }
                    }
                }
            }
        }


        //private void TraceDepthContact(CStepS cCurStepS, List<CStep> lstTotalStep, CAbnormalSymbolS cSubAbnormalSymbolS, CStep cBaseStep)
        //{
        //    CTag cTag;
        //    CStep cStep;
        //    CTagStepRole cRole;
        //    int iDepth = m_iCurDepthLevel;

        //    for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
        //    {
        //        cTag = cBaseStep.RefTagS[i];
        //        m_iCurDepthLevel = iDepth;

        //        if (!cTag.IsEndContact())
        //        {
        //            for (int j = 0; j < cTag.StepRoleS.Count; j++)
        //            {
        //                cRole = cTag.StepRoleS[j];
        //                if (cRole.RoleType == EMStepRoleType.Coil || cRole.RoleType == EMStepRoleType.Both)
        //                {
        //                    if (cCurStepS.ContainsKey(cRole.StepKey))
        //                    {
        //                        cStep = cCurStepS[cRole.StepKey];
        //                        if (lstTotalStep.Contains(cStep) == false)
        //                        {
        //                            lstTotalStep.Add(cStep);
        //                            SetSubAbnormalSymbolList(cStep, cSubAbnormalSymbolS);

        //                            if(++m_iCurDepthLevel <= m_iSubDepthLevel)
        //                                TraceDepthContact(cCurStepS, lstTotalStep, cSubAbnormalSymbolS, cStep);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}

        #endregion
    }
}
