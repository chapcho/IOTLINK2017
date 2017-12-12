using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackerCommon;
using UDM.Common;

namespace UDMPLCLogicAnalyzer
{

    public class CCompareTag
    {
        #region Member Variables

        private string m_sKey = "";
        private string m_sPLCID = "";
        private CTag m_cBaseTag = null;
        private CTag m_cCompareTag = null;
        private bool m_bLogicCheck = false;
        private bool m_bTagCheck = false;
        private bool m_bBaseTagIn = false;
        private bool m_bCompareTagIn = false;
        private bool m_bIsCoil = false;
        private List<string> m_lstFailMessage = new List<string>();
        private List<string> m_lstBaseCoilStepKey = new List<string>();
        private List<string> m_lstCompareCoilStepKey = new List<string>();
        private List<double> m_lstMatchPersent = new List<double>();
        private string m_sPersent = "0";

        #endregion


        #region Initialize

        public CCompareTag(CTag cBaseTag, CTag cCompareTag)
        {
            if (cBaseTag != null && cCompareTag != null)
            {
                m_sKey = cBaseTag.Key;
                m_sPLCID = cBaseTag.Creator;
                m_cBaseTag = cBaseTag;
                m_cCompareTag = cCompareTag;
                m_bBaseTagIn = true;
                m_bCompareTagIn = true;
                m_bLogicCheck = CheckCompare();
                m_bTagCheck = CheckTagCompare();

                FindCoilStepKey();
                m_bIsCoil = CheckIsCoil();
            }
        }

        public CCompareTag(CTag cTag, bool bBase)
        {
            if (cTag != null)
            {
                m_sKey = cTag.Key;
                m_sPLCID = cTag.Creator;
                if (bBase)
                {
                    m_cBaseTag = cTag;
                    m_bBaseTagIn = true;
                }
                else
                {
                    m_cCompareTag = cTag;
                    m_bCompareTagIn = true;
                }
                m_bLogicCheck = false;
                m_bTagCheck = false;
                FindCoilStepKey();
                m_bIsCoil = CheckIsCoil();
            }
        }

        #endregion


        #region Properties

        /// <summary>
        /// 키는 비교 대상인 두 로직 모두 같은 주소를 갖고 있음.
        /// </summary>
        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string PLCID
        {
            get { return m_sPLCID; }
            set { m_sPLCID = value; }
        }

        public CTag BaseTag
        {
            get { return m_cBaseTag; }
            set { m_cBaseTag = value; }
        }

        public CTag CompareTag
        {
            get { return m_cCompareTag; }
            set { m_cCompareTag = value; }
        }

        public bool IsLogicMatch
        {
            get { return m_bLogicCheck; }
        }

        public bool IsTagMatch
        {
            get { return m_bTagCheck; }
        }

        public bool IsBaseTagIn
        {
            get { return m_bBaseTagIn; }
        }

        public bool IsCompareTagIn
        {
            get { return m_bCompareTagIn; }
        }

        public string BaseTagComment
        {
            get { return GetTagComment(m_cBaseTag); }
        }

        public string CompareTagComment
        {
            get { return GetTagComment(m_cCompareTag); }
        }

        public List<string> FailMessageList
        {
            get { return m_lstFailMessage; }
        }

        public List<string> BaseCoilStepKeyList
        {
            get { return m_lstBaseCoilStepKey; }
        }

        public List<string> CompareCoilStepKeyList
        {
            get { return m_lstCompareCoilStepKey; }
        }

        public bool IsCoil
        {
            get { return m_bIsCoil; }
            set { m_bIsCoil = value; }
        }

        public List<double> MatchPersent
        {
            get { return m_lstMatchPersent; }
            set { m_lstMatchPersent = value; }
        }

        public string PersentString
        {
            get { return m_sPersent; }
        }
        #endregion



        private string GetTagComment(CTag cTag)
        {
            string sResult = "";

            if (cTag != null)
            {
                if (cTag.Description == "")
                    return cTag.Name;
                else
                    return cTag.Description;
            }

            return sResult;
        }

        private bool CheckTagCompare()
        {
            bool bOK = false;

            if (m_cBaseTag.Address != m_cBaseTag.Address)
                m_lstFailMessage.Add("Address Match Fail");

            if (m_cBaseTag.Description != m_cBaseTag.Description)
                m_lstFailMessage.Add("Description Match Fail");
            else
                bOK = true;
            if (m_cBaseTag.Name != m_cCompareTag.Name)
                m_lstFailMessage.Add("Name Match Fail");
            else
                bOK = true;

            return bOK;
        }

        private bool CheckCompare()
        {
            bool bOK = false;
            if (m_cBaseTag == null || m_cCompareTag == null)
            {
                return bOK;
            }
            else
            {
                
                bool bError = false;
                if (m_cBaseTag.StepRoleS.Count >= m_cCompareTag.StepRoleS.Count)
                {
                    foreach (CTagStepRole cTagRole in m_cBaseTag.StepRoleS)
                    {
                        List<CTagStepRole> lstFind = m_cCompareTag.StepRoleS.FindAll(b => b.RoleType == cTagRole.RoleType && b.StepKey == cTagRole.StepKey);
                        if (lstFind == null || lstFind.Count == 0)
                        {
                            m_lstFailMessage.Add(string.Format("Base Tag : Not Found Step {0}", cTagRole.StepKey));
                            bError = true;
                        }
                    }
                }
                else
                {
                    foreach (CTagStepRole cTagRole in m_cCompareTag.StepRoleS)
                    {
                        List<CTagStepRole> lstFind = m_cBaseTag.StepRoleS.FindAll(b => b.RoleType == cTagRole.RoleType && b.StepKey == cTagRole.StepKey);
                        if (lstFind == null || lstFind.Count == 0)
                        {
                            m_lstFailMessage.Add(string.Format("Compare Tag : Not Found Step {0}", cTagRole.StepKey));
                            bError = true;
                        }
                    }
                }
                if (bError == false) bOK = true;
            }


            return bOK;
        }

        private bool CheckIsCoil()
        {
            bool bOK = false;
            if(m_bBaseTagIn)
            {
                if (m_lstBaseCoilStepKey.Count >0)
                    bOK = true;
            }
            else if(m_bCompareTagIn)
            {
                if (m_lstCompareCoilStepKey.Count > 0)
                    bOK = true;
            }
            return bOK;
        }

        private void FindCoilStepKey()
        {
            if (m_bCompareTagIn)
            {
                m_lstCompareCoilStepKey.AddRange(m_cCompareTag.StepRoleS.FindAll(b => b.RoleType != EMStepRoleType.Contact).Select(b => b.StepKey));
            }
            if (m_bBaseTagIn)
            {
                m_lstBaseCoilStepKey.AddRange(m_cBaseTag.StepRoleS.FindAll(b => b.RoleType != EMStepRoleType.Contact).Select(b => b.StepKey));
            }
        }

        public void SetMatchPersent(CPlcLogicData cBaseLogic, CPlcLogicData cCompareLogic)
        {
            if(m_bBaseTagIn && m_bCompareTagIn && m_bIsCoil)
            {
                if (m_lstBaseCoilStepKey.Count == 1 && m_lstCompareCoilStepKey.Count == 0)
                    m_sPersent = "비교 대상 없음";
                else if (m_lstBaseCoilStepKey.Count == 1 && m_lstCompareCoilStepKey.Count == 1)
                {
                    foreach (string sKey in m_lstBaseCoilStepKey)
                    {
                        if (cBaseLogic.StepS.ContainsKey(sKey) == false) continue;

                        CStep cBaseStep = cBaseLogic.StepS[sKey];
                        //실제 비교
                        CStep cCompareStep = cCompareLogic.StepS[m_lstCompareCoilStepKey.First()];
                        int iItemCount = cBaseStep.CoilS.Count + cBaseStep.ContactS.Count;
                        int iMatchCount = 0;
                        foreach (CCoil cCoil in cBaseStep.CoilS)
                        {
                            foreach (CCoil coil in cCompareStep.CoilS)
                            {
                                if (cCoil.Instruction.Contains(coil.Instruction))
                                {
                                    iMatchCount++;
                                    break;
                                }
                            }
                        }
                        foreach (CContact cContact in cBaseStep.ContactS)
                        {
                            foreach (CContact contact in cCompareStep.ContactS)
                            {
                                if (cContact.Instruction.Contains(contact.Instruction))
                                {
                                    iMatchCount++;
                                    break;
                                }
                            }
                        }
                        double ndddd = (100.0 / (double)iItemCount);
                        double nResult = ndddd * (double)iMatchCount;
                        m_sPersent = string.Format("{0:.00}", nResult);
                        m_lstMatchPersent.Add(nResult);
                    }
                }
                else
                {
                    //2개 이상일경우
                    foreach (string sKey in m_lstBaseCoilStepKey)
                    {
                        m_sPersent = "";
                        if (cBaseLogic.StepS.ContainsKey(sKey) == false) continue;

                        CStep cBaseStep = cBaseLogic.StepS[sKey];
                        //실제 비교
                        List<double> lstPerSent = new List<double>();
                        foreach (string sComKey in m_lstCompareCoilStepKey)
                        {
                            CStep cCompareStep = cCompareLogic.StepS[sComKey];
                            int iItemCount = cBaseStep.CoilS.Count + cBaseStep.ContactS.Count;
                            int iMatchCount = 0;
                            foreach (CCoil cCoil in cBaseStep.CoilS)
                            {
                                foreach (CCoil coil in cCompareStep.CoilS)
                                {
                                    if (cCoil.Instruction.Contains(coil.Instruction))
                                    {
                                        iMatchCount++;
                                        break;
                                    }
                                }
                            }
                            foreach (CContact cContact in cBaseStep.ContactS)
                            {
                                foreach (CContact contact in cCompareStep.ContactS)
                                {
                                    if (cContact.Instruction.Contains(contact.Instruction))
                                    {
                                        iMatchCount++;
                                        break;
                                    }
                                }
                            }

                            double ndddd = (100.0 / (double)iItemCount);
                            double nResult = ndddd * (double)iMatchCount;
                            lstPerSent.Add(nResult);
                        }
                        lstPerSent.Sort();
                        if (lstPerSent.Count > 0)
                        {
                            m_sPersent += string.Format("{0:.00}/", lstPerSent.Last());
                            m_lstMatchPersent.Add(lstPerSent.Last());
                        }
                        else
                            m_sPersent += "없음";
                    }
                }
            }
            
        }
    }
}
