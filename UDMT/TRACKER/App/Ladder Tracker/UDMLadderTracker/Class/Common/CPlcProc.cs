using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;
using UDM.Log;

namespace UDMLadderTracker
{
    [Serializable]
    public class CPlcProc
    {
        #region Member Variables

        private string m_sName = "";

        private CKeySymbolS m_cKeySymbolS = new CKeySymbolS();
        private CAbnormalSymbolS m_cAbnormalSymbolS = new CAbnormalSymbolS();
        private CTagS m_cInOutTagS = new CTagS();
        private CTagS m_cRecipeWordS = new CTagS();
        private CTag m_cSelectRecipeWord = null;
        private Dictionary<string, CFlowChartItemS> m_dicFlowChartItemS = new Dictionary<string, CFlowChartItemS>();

        private string m_sTotalAbnormalSymbolKey = string.Empty;

        [NonSerialized]
        private CPlcLogicDataS m_cPlcLogicDataS = new CPlcLogicDataS();               

        [NonSerialized]
        private bool m_bCycleError = false;

        [NonSerialized]
        private bool m_bCycleStart = false;

        [NonSerialized]
        private bool m_bCycleEnd = false;

        [NonSerialized]
        private int m_iCurrentValue = -1;

        [NonSerialized]
        private int m_iCycleID = -1;

        [NonSerialized] private List<string> m_lstAbnormalFilter = null;

        #endregion


        #region Properties

        public Dictionary<string, CFlowChartItemS> RecipeFlowChartItemS
        {
            get { return m_dicFlowChartItemS; }
            set { m_dicFlowChartItemS = value; }
        }

        public int CurrentCycleSignalValue
        {
            get { return m_iCurrentValue;}
            set { m_iCurrentValue = value; }
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

        public CTagS InOutTagS
        {
            get { return m_cInOutTagS;}
            set { m_cInOutTagS = value; }
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
            m_cKeySymbolS.Clear();
            m_cAbnormalSymbolS.Clear();
            m_cInOutTagS.Clear();
            m_cRecipeWordS.Clear();
            m_dicFlowChartItemS.Clear();
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
                lstResult.AddRange(cSymbol.SubDepthTagList.Select(x => x.Key).ToList());
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
                lstResult.AddRange(cSymbol.SubDepthTagList.Select(x => x.Key).ToList());
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
            }
        }

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

                if (bCoil)
                    cAbnormalSymbol.AllSubDepthTagList = GetAllContact(cTag, EMDataType.Bool);
            }
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
                }
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
            m_cKeySymbolS.RemoveSubSymbol(cTag);
        }

        public void RemoveEndSubDepthSymbolS(CTag cTag)
        {
            m_cKeySymbolS.RemoveEndSubDepthSymbol(cTag);
        }

        #endregion


        #region Private Methods

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

            foreach(CStep cStep in lstStep)
                SetSubAbnormalSymbolList(cStep, cSymbolS);

            return cSymbolS;
        }

        private List<CTag> GetStepContact(CTag cTag)
        {
            List<CTag> lstStepTag = new List<CTag>();
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

                    lstStepTag.AddRange(GetTagList(cStep));
                }
            }

            return lstStepTag;
        }

        private List<CStep> GetStepList(CTag cTag)
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

                    if (cStep.CoilS.GetFirstCoil().CoilType == EMCoilType.Bit || cStep.CoilS[0].CoilType == EMCoilType.Function || cStep.CoilS[0].CoilType == EMCoilType.None)
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
                if (cContact.RefTagS[i].DataType != EMDataType.Bool || !CheckAbnormalTag(cContact.RefTagS[i].Description))
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

            foreach(var who in cTag.StepRoleS)
            {
                if(who.RoleType == EMStepRoleType.Coil || who.RoleType == EMStepRoleType.Both)
                {
                    bOK = true;
                    break;
                }
            }

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

        private List<CTag> GetAllContact(CTag cBaseTag, EMDataType emDataType)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<CTag> lstTotalTag = new List<CTag>();
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
                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            SetTagList(GetTagList(cStep), lstTotalTag);
                            TraceAllEndContact(cLogicData.StepS, lstTotalStep, lstTotalTag, cStep, emDataType);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTag;
        }

        private  List<CTag> GetTagList(CStep cStep)
        {
            List<CTag> lstTag = new List<CTag>();

            CTag cTag;

            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                if (cTag.DataType != EMDataType.Bool) continue;
                //if (CheckPlcInputDevice(cTag) == false) continue;
                
                if (lstTag.Contains(cTag) == false)
                    lstTag.Add(cTag);
            }

            return lstTag;
        }

        private void SetSubAbnormalSymbolList(CStep cStep, CAbnormalSymbolS cSymbolS)
        {
            if (cStep == null)
                return;

            CCoil cCoil = cStep.CoilS.GetFirstCoil();

            if (cCoil.ContentS[0].Tag == null)
                return;

            if (cCoil.Relation.PrevContactS.Count != 0)
            {
                foreach(int PreCont in cCoil.Relation.PrevContactS)
                    CreateSubAbnormalList(cStep, cSymbolS, PreCont, false);
            }
        }

        private void CreateSubAbnormalList(CStep cStep, CAbnormalSymbolS cSymbolS, int iStepIndex, bool bInverse)
        {
            foreach (CContact cContact in cStep.ContactS)
            {
                if (cContact.StepIndex == iStepIndex)
                {
                    if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit && cContact.ContentS[0].Tag.Key != cStep.CoilS[0].ContentS[0].Tag.Key)
                        cSymbolS.AddRange(GetSubAbnormalSymbolS(cContact, bInverse));

                    if (cContact.Operator.Contains("INV"))
                        bInverse = true;

                    if (cContact.Relation.PrevContactS.Count != 0)
                    {
                        foreach (int PreCont in cContact.Relation.PrevContactS)
                            CreateSubAbnormalList(cStep, cSymbolS, PreCont, bInverse);
                    }
                    break;
                }
            }
        }

        public bool CheckAbnormalTag(string sDescription)
        {
            bool bOK = false;

            foreach (string sFilter in m_lstAbnormalFilter)
            {
                if (sDescription.Contains(sFilter))
                {
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

                if (cTag.DataType != EMDataType.Bool )
                    continue;

                cSubSymbol = new CAbnormalSymbol(cTag);
                cSubSymbol.IsAStateSymbol = GetContactSymbolType(cContact);
                cSubSymbol.IsRelatedInverse = bInverse;
                cSubSymbol.SubCoil = GetAbnormalSubCoil(cTag);

                string sSubKey = string.Format("_{0}", cSubSymbol.IsAStateSymbol == true ? "A" : "B");

                if (!cSubSymbolS.ContainsKey(cSubSymbol.Tag.Key + sSubKey))
                    cSubSymbolS.Add(cSubSymbol.Tag.Key + sSubKey, cSubSymbol);
            }

            return cSubSymbolS;
        }

        private CSubCoil GetAbnormalSubCoil(CTag cTag)
        {
            CSubCoil cSubCoil = new CSubCoil();
            CStep cStep = null;
            List<string> lstTotalStepKey = new List<string>();
            int iCurDepth = 0;

            cStep = GetStep(cTag);

            if (cStep == null)
                return null;

            cSubCoil.CoilKey = cTag.Key;
            cSubCoil.CurDepth = iCurDepth;
            cSubCoil.StepKey = cStep.Key;
            cSubCoil.SubLogicPathS = GetSubLogicPathS(cStep, cSubCoil);

            foreach (CContact cContact in cStep.ContactS)
            {
                lstTotalStepKey.Clear();
                iCurDepth = 0;
                lstTotalStepKey.Add(cStep.Key);

                if (cContact.ContactType != EMContactType.Bit) continue;
                if (cContact.ContentS.Count == 0) continue;
                if (!CheckRoleType(cContact.ContentS[0].Tag)) continue;
                if (cContact.ContentS[0].Tag.DataType != EMDataType.Bool) continue;
                if (!CheckAbnormalTag(cContact.ContentS[0].Tag.Description)) continue;

                SetSubCoil(cSubCoil.SubCoilS, cContact.ContentS[0].Tag, iCurDepth, lstTotalStepKey);
            }

            return cSubCoil;
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

            foreach(CContact cContact in cStep.ContactS)
            {
                if (cContact.StepIndex == StepIndex)
                {
                    if (!cContact.Operator.Contains("INV") && cContact.ContactType == EMContactType.Bit)
                    {
                        if(cContact.ContentS[0].Tag == null)
                        {
                            if (cContact.Relation.PrevContactS.Count != 0)
                                continue;
                            else
                            {
                                cLogicPathS.Add(cLogicPath);
                                break;
                            }
                        }

                        if ( cContact.ContentS[0].Tag.Key == cStep.CoilS[0].ContentS[0].Tag.Key)
                            break;

                        SetSubContactS(cLogicPath.SubContactS, cContact, bInverse);
                        cNewSubContact = cLogicPath.SubContactS.Clone();
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
                                cNewLogicPath.SubContactS = cNewSubContact.Clone();

                                CreateSubLogicPathS(cStep, cLogicPathS, cNewLogicPath, PreCont, bInverse);
                            }
                        }
                    }
                    else
                        cLogicPathS.Add(cLogicPath);

                    break;
                }
            }
        }

        private void SetSubContactS(CSubContactS cSubContactS, CContact cContact, bool bInverse)
        {
            if (cSubContactS.ContainsKey(cContact.ContentS[0].Tag.Key) || cContact.ContentS[0].Tag.DataType != EMDataType.Bool)
                return;

            CSubContact cSubContact = new CSubContact(cContact.ContentS[0].Tag);
            cSubContact.IsInverse = bInverse;
            cSubContact.IsASymbolState = GetContactSymbolType(cContact);
            cSubContactS.Add(cSubContact.Tag.Key, cSubContact);
        }

        private CStep GetStep(CTag cTag)
        {
            CStep cStep = null;
            List<CStep> lstStep = GetStepList(cTag);

            if (lstStep == null || lstStep.Count == 0)
                return null;

            if (lstStep.Count == 1 && !lstStep[0].Instruction.Contains("RST"))
                cStep = lstStep[0];

            return cStep;
        }

        private void SetSubCoil(CSubCoilS cSubCoilS, CTag cTag, int iCurDepth, List<string> lstTotalStepKey)
        {
            CSubCoil cSubCoil = new CSubCoil();
            CStep cSubStep = GetStep(cTag);
            List<string> lstTempTotalStepKey = new List<string>();

            if (cSubStep == null) return;
            if (!lstTotalStepKey.Contains(cSubStep.Key))
            {
                lstTotalStepKey.Add(cSubStep.Key);
                iCurDepth++;

                cSubCoil.CoilKey = cTag.Key;
                cSubCoil.CurDepth = iCurDepth;
                cSubCoil.StepKey = cSubStep.Key;
                cSubCoil.SubLogicPathS = GetSubLogicPathS(cSubStep, cSubCoil);

                if (!CheckContainSubCoil(cSubCoilS, cSubCoil.CoilKey))
                    cSubCoilS.Add(cSubCoil);
            }
            else
                return;

            foreach (CContact cContact in cSubStep.ContactS)
            {
                lstTempTotalStepKey.Clear();
                foreach (string sKey in lstTotalStepKey)
                    lstTempTotalStepKey.Add(sKey);

                if (cContact.ContactType != EMContactType.Bit) continue;
                if (cContact.ContentS.Count == 0) continue;
                if (!CheckRoleType(cContact.ContentS[0].Tag)) continue;
                if (cContact.ContentS[0].Tag.DataType != EMDataType.Bool) continue;
                if (!CheckAbnormalTag(cContact.ContentS[0].Tag.Description)) continue;

                SetSubCoil(cSubCoil.SubCoilS, cContact.ContentS[0].Tag, iCurDepth, lstTempTotalStepKey);
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

        private void SetTagList(List<CTag> lstAdd, List<CTag> lstTotalTag)
        {
            foreach (CTag cTag in lstAdd)
            {
                if (cTag.DataType != EMDataType.Bool)
                    continue;

                if (!lstTotalTag.Contains(cTag))
                    lstTotalTag.Add(cTag);
            }
        }

        private void SetInputTagList(List<CTag> lstAdd, List<CTag> lstTotalTag)
        {
            foreach (CTag cTag in lstAdd)
            {
                if (cTag.DataType != EMDataType.Bool)
                    continue;

                if (CheckPlcInputDevice(cTag) == false)
                    continue;

                if (!cTag.IsEndContact() && !CheckFBRelatedCoil(cTag))
                    continue;

                if (!lstTotalTag.Contains(cTag))
                    lstTotalTag.Add(cTag);
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

        private List<CTag> GetEndContactList(CTag cBaseTag, EMDataType emDataType)
        {
            List<CStep> lstTotalStep = new List<CStep>();
            List<CTag> lstTotalTag = new List<CTag>();
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
                        if (lstTotalStep.Contains(cStep) == false)
                        {
                            lstTotalStep.Add(cStep);
                            SetInputTagList(GetTagList(cStep), lstTotalTag);
                            TraceEndContact(cLogicData.StepS, lstTotalStep, lstTotalTag, cStep, emDataType);
                        }
                    }
                }
            }

            lstTotalStep.Clear();

            return lstTotalTag;
        }

        private bool CheckPlcInputDevice(CTag cTag)
        {
            if (cTag.DataType != EMDataType.Bool) return false;

            //Melsec
            if (cTag.Address.StartsWith("X"))
                return true;

            //Seimens
            if (cTag.Address.StartsWith("I"))
                return true;

            //LS
            if (cTag.Address.StartsWith("P"))
                return true;

            if (cTag.Address.Contains("I25.4"))
                return true;

            return false;
        }

        //private bool CheckAbnormalDescription(string sDescription)
        //{
            
        //}

        private void TraceEndContact(CStepS cCurStepS, List<CStep> lstTotalStep, List<CTag> lstTotalTag, CStep cBaseStep, EMDataType emDataType)
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
                                    SetInputTagList(GetTagList(cStep), lstTotalTag);

                                    TraceEndContact(cCurStepS, lstTotalStep, lstTotalTag, cStep, emDataType);
                                }
                            }
                        }
                    }
                }
                
            }
        }

        private void TraceAllEndContact(CStepS cCurStepS, List<CStep> lstTotalStep, List<CTag> lstTotalTag, CStep cBaseStep, EMDataType emDataType)
        {
            CTag cTag;
            CStep cStep;
            CTagStepRole cRole;
            for (int i = 0; i < cBaseStep.RefTagS.Count; i++)
            {
                cTag = cBaseStep.RefTagS[i];
                if (!cTag.IsEndContact())
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
                                    SetTagList(GetTagList(cStep), lstTotalTag);
                                    TraceAllEndContact(cCurStepS, lstTotalStep, lstTotalTag, cStep, emDataType);
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
