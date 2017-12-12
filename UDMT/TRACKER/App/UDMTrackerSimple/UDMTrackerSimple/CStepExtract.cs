using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.UDLImport;

namespace UDMTrackerSimple
{
    public class CStepExtract
    {
        private static List<int> m_lstUsedSymbolIndex = new List<int>();
        private static CStepS m_cStepS = null;
        private static CTagS m_cGlobalTagS = null;
        private static CTagS m_cLocalTagS = null;
        private static List<string> m_lstStepKey = new List<string>();
        private static CStepS m_cTempStepS = new CStepS();

        #region Initialize/Dispose

        #endregion

        #region Properties

        #endregion

        #region Public Methods 

        public static void SplitStepS(CStepS cStepS, CTagS cGobalTagS)
        {
            Clear();

            m_cStepS = cStepS;
            m_cGlobalTagS = cGobalTagS;

            UpdateStepS();
        }

        public static void SplitStepS(CStepS cStepS, CTagS cGobalTagS, CTagS cLocalTagS)
        {
            Clear();

            m_cStepS = cStepS;
            m_cGlobalTagS = cGobalTagS;
            m_cLocalTagS = cLocalTagS;

            UpdateStepS();
            //CreateLocalRefTagS();
        }
        
        #endregion

        #region Private Methods

        private static void Clear()
        {
            m_lstUsedSymbolIndex.Clear();
            m_lstStepKey.Clear();
            m_cTempStepS.Clear();
        }

        private static void CreateLocalRefTagS()
        {
            foreach (CStep cStep in m_cStepS.Values)
            {
                foreach (CCoil cCoil in cStep.CoilS)
                    SetRefTagS(cCoil, false, cCoil.ContentS);

                foreach (CContact cContact in cStep.ContactS)
                    SetRefTagS(cContact, true, cContact.ContentS);

                //CheckStepRefTags(cStep);
            }
        }

        private static void SetRefTagS(object cObject, bool bContact, CContentS cContentS)
        {
            CContact cContact = null;
            CCoil cCoil = null;

            if (bContact)
                cContact = cObject as CContact;
            else
                cCoil = cObject as CCoil;

            foreach (CContent cContent in cContentS)
            {
                string sRefKey = CheckRefTagKey(cContent);

                if (sRefKey != string.Empty)
                {
                    if (bContact)
                        cContact.RefTagS.Add(sRefKey, cContent.Tag);
                    else
                        cCoil.RefTagS.Add(sRefKey, cContent.Tag);
                }
            }
        }

        private static string CheckRefTagKey(CContent tempContent)
        {
            string refKey = string.Empty;

            try
            {
                if (tempContent.ArgumentType == EMArgumentType.Tag || tempContent.ArgumentType == EMArgumentType.MoveTag || tempContent.ArgumentType == EMArgumentType.LogicTag)
                {
                    CTag tempTag = tempContent.Tag;

                    if (tempTag.Address.Length >= 2)
                    {
                        if (m_cLocalTagS.ContainsKey(tempTag.Key))
                            refKey = tempTag.Key;
                        //else
                        //{
                        //    if (CheckIsS7DBTagAddress(tempUDLTag.Address))
                        //        refKey = tempUDLTag.Key;
                        //}
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return refKey;
        }

        private static void UpdateStepS()
        {
            if (m_cStepS.Values.Where(x => x.CoilS.Count > 1).Count() > 0)
            {
                foreach (CStep cStep in m_cStepS.Values.Where(x => x.CoilS.Count > 1))
                {
                    m_lstStepKey.Add(cStep.Key);
                    SplitOneCoilStep(cStep);
                }
            }

            foreach(string sStepKey in m_lstStepKey)
            {
                if (m_cStepS.Keys.Contains(sStepKey))
                    m_cStepS.Remove(sStepKey);
            }

            foreach (string sKey in m_cTempStepS.Keys)
                m_cStepS.Add(sKey, m_cTempStepS[sKey]);
        }

        private static void SplitOneCoilStep(CStep cStep)
        {
            try
            {
                CStep cSplitStep = null;
                string sKey = string.Empty;
                CCoilS cCoilS = cStep.CoilS;
                CContactS cRelatedContactS = null;
                CStepS cTempStepS = new CStepS();

                foreach (CCoil cTempCoil in cCoilS)
                {
                    m_lstUsedSymbolIndex.Clear();

                    cSplitStep = new CStep();
                    cSplitStep.Program = cStep.Program;
                    cSplitStep.StepIndex = cStep.StepIndex;
                    sKey = string.Format("{0}.{1}[{2}]", cSplitStep.Program, cSplitStep.StepIndex, cTempCoil.StepIndex);

                    CCoil cCoil = CoilClone(cTempCoil, sKey);
                    cSplitStep.CoilS.Add(cCoil);
                    cSplitStep.CoilS[0].Step = sKey;

                    if (cStep.FBInfoList != null && cStep.FBInfoList.Count > 0)
                    {
                        foreach (CFB_Info cFB in cStep.FBInfoList)
                        {
                            CCoil cFBCoil = cFB.CoilS.Find(x => x.StepIndex == cSplitStep.CoilS[0].StepIndex);

                            if(cFBCoil != null)
                                cSplitStep.FBInfoList.Add(cFB);
                        }
                    }

                    cRelatedContactS = new CContactS();

                    CreateNewStepRelation(cSplitStep, cStep, cRelatedContactS, sKey,cSplitStep.StepIndex);
                    StepRelationModifile(cSplitStep);
                    CheckStepRefTags(cSplitStep, cStep.Key, sKey);
                    cSplitStep.Key = sKey;

                    m_cTempStepS.Add(sKey, cSplitStep);
                    cTempStepS.Add(sKey, cSplitStep);
                }
                CheckTagStepRoleS(cStep.Key, cTempStepS);

                cTempStepS.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CheckTagStepRoleS(string sBeforeStepKey, CStepS cTempStepS)
        {
            try
            {
                //CTagStepRoleS cTempStepRoleS = null;
                CTagStepRole cTempStepRole = null;

                foreach (CStep cSplitStep in cTempStepS.Values)
                {
                    for (int i = 0; i < cSplitStep.RefTagS.Count; i++)
                    {
                        CTag cTag = cSplitStep.RefTagS[i];
                        //cTempStepRoleS = new CTagStepRoleS();

                        CTagStepRole cSplitStepRole = cTag.StepRoleS.Find(x => x.StepKey == sBeforeStepKey);

                        if (cSplitStepRole != null)
                        {
                            cTempStepRole = new CTagStepRole();
                            cTempStepRole.StepKey = cSplitStep.Key;
                            cTempStepRole.RoleType = cSplitStepRole.RoleType;

                            cTag.StepRoleS.Add(cTempStepRole);
                            //cTempStepRoleS.Add(cTempStepRole);
                        }

                        //cTempStepRoleS.AddRange(cTag.StepRoleS);

                        //foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        //{
                        //    if (cTagStepRole.StepKey == sBeforeStepKey)
                        //    {
                        //        cTempStepRole = new CTagStepRole();
                        //        cTempStepRole.StepKey = cSplitStep.Key;
                        //        cTempStepRole.RoleType = cTagStepRole.RoleType;

                        //        cTempStepRoleS.Add(cTempStepRole);
                        //    }

                        //    cTempStepRoleS.Add(cTagStepRole);
                        //}

                        //cTag.StepRoleS = cTempStepRoleS;
                    }
                }

                foreach (CStep cSplitStep in cTempStepS.Values)
                {
                    for (int i = 0; i < cSplitStep.RefTagS.Count; i++)
                    {
                        CTag cTag = cSplitStep.RefTagS[i];

                        CTagStepRole cStepRole = cTag.StepRoleS.Find(x => x.StepKey == sBeforeStepKey);

                        if (cStepRole != null)
                            cTag.StepRoleS.Remove(cStepRole);
                    }
                }

                //CheckContactCoilSteps(cTempStepS);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CheckContactCoilSteps(CStepS cTempStepS)
        {
            try
            {
                string sStepKey = string.Empty;

                foreach (CStep cStep in cTempStepS.Values)
                {
                    sStepKey = cStep.Key;
                    cStep.CoilS[0].Step = sStepKey;

                    foreach (CContact cContact in cStep.ContactS)
                        cContact.Step = sStepKey;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void UpdateUsedContactIndex(CStep cSplitStep)
        {
            try
            {
                List<int> lstPreCont = new List<int>();

                foreach (int PrevCont in cSplitStep.CoilS.GetFirstCoil().Relation.PrevContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(PrevCont))
                        lstPreCont.Add(PrevCont);
                }

                cSplitStep.CoilS.GetFirstCoil().Relation.PrevContactS = lstPreCont;

                foreach (CContact cContact in cSplitStep.ContactS)
                    UpdateUsedContactIndex(cContact);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void UpdateUsedContactIndex(CContact cContact)
        {
            try
            {
                List<int> lstPreCont = new List<int>();
                List<int> lstNextCont = new List<int>();
                List<int> lstNextCoil = new List<int>();

                foreach (int PrevCont in cContact.Relation.PrevContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(PrevCont))
                        lstPreCont.Add(PrevCont);
                }
                cContact.Relation.PrevContactS = lstPreCont;

                foreach (int NextCont in cContact.Relation.NextContactS)
                {
                    if (m_lstUsedSymbolIndex.Contains(NextCont))
                        lstNextCont.Add(NextCont);
                }
                cContact.Relation.NextContactS = lstNextCont;

                foreach (int NextCoil in cContact.Relation.NextCoilS)
                {
                    if (m_lstUsedSymbolIndex.Contains(NextCoil))
                        lstNextCoil.Add(NextCoil);
                }
                cContact.Relation.NextCoilS = lstNextCoil;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CreateNewStepRelation(CStep cSplitStep, CStep cOriginalStep, CContactS cRelatedContactS, string sStepKey,int iCoilIndex)
        {
            try
            {
                CCoil cCoil = cSplitStep.CoilS.GetFirstCoil();
                cSplitStep.ContactS = cRelatedContactS;

                if(cCoil.Relation.PrevContactS.Count != 0)
                {
                    foreach (int iPrevContact in cCoil.Relation.PrevContactS)
                        CopyPrevContactRelation(cOriginalStep, cRelatedContactS, iPrevContact, sStepKey,cCoil.StepIndex,true,cSplitStep);
                }

                if(cCoil.Relation.PrevCoilS.Count != 0)
                {
                    foreach(int iPrevCoil in cCoil.Relation.PrevCoilS)
                        CopyPrevCoilRelation(cOriginalStep, cRelatedContactS, iPrevCoil, sStepKey,cCoil.StepIndex,true,cSplitStep);
                }

                m_lstUsedSymbolIndex.Add(cCoil.StepIndex);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CopyPrevContactRelation(CStep cOriginalStep, CContactS cRelatedContactS,int iStepIndex,string sStepKey,int iNextIndex,bool bNextIsCoil,CStep cSplitStep)
        {
            try
            {
                //CContact cTempContact =  FindContactByIndex(cOriginalStep, iStepIndex);
                CContact cTempContact = cOriginalStep.ContactS.Find(x => x.StepIndex == iStepIndex);

                if(cTempContact != null)
                {
                    if (!CheckIsHaveSameContact(cRelatedContactS,cTempContact))
                    {
                        CContact cRelatedContact = ContactClone(cTempContact, sStepKey);
                        int iThisContactIndex = cRelatedContact.StepIndex;

                        if(bNextIsCoil)
                        {
                            if (!cRelatedContact.Relation.NextCoilS.Contains(iNextIndex))
                                cRelatedContact.Relation.NextCoilS.Add(iNextIndex);
                        }
                        else
                        {
                            if (!cRelatedContact.Relation.NextContactS.Contains(iNextIndex))
                                cRelatedContact.Relation.NextContactS.Add(iNextIndex);
                        }

                        ConnectRelationToNext(cSplitStep, iNextIndex, iThisContactIndex, bNextIsCoil, false);
                    
                        cRelatedContactS.Add(cRelatedContact);

                        if (cTempContact.Relation.PrevContactS.Count != 0)
                        {
                            foreach (int iPrevContact in cTempContact.Relation.PrevContactS)
                                CopyPrevContactRelation(cOriginalStep, cRelatedContactS, iPrevContact, sStepKey, iThisContactIndex, false, cSplitStep);
                        }

                        if (cTempContact.Relation.PrevCoilS.Count != 0)
                        {
                            foreach (int iPrevCoil in cTempContact.Relation.PrevCoilS)
                                CopyPrevCoilRelation(cOriginalStep, cRelatedContactS, iPrevCoil, sStepKey, iThisContactIndex, false, cSplitStep);
                        }
                    }                    
                }                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CopyPrevCoilRelation(CStep cOriginalStep, CContactS cRelatedContactS, int iStepIndex,string sStepKey, int iNextIndex,bool bNextIsCoil,CStep cSplitStep)
        {
            try
            {
                CCoil cTempCoil = cOriginalStep.CoilS.Find(x => x.StepIndex == iStepIndex);

                if (cTempCoil == null)
                    return;

                cTempCoil = CoilClone(cTempCoil, sStepKey);

                if (cTempCoil.Relation.PrevContactS.Count != 0)
                {
                    foreach (int iPrevContact in cTempCoil.Relation.PrevContactS)
                        CopyPrevContactRelation(cOriginalStep, cRelatedContactS, iPrevContact, sStepKey, iNextIndex,
                            bNextIsCoil, cSplitStep);
                }

                if (cTempCoil.Relation.PrevCoilS.Count != 0)
                {
                    foreach (int iPrevCoil in cTempCoil.Relation.PrevCoilS)
                        CopyPrevCoilRelation(cOriginalStep, cRelatedContactS, iPrevCoil, sStepKey, iNextIndex,
                            bNextIsCoil, cSplitStep);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static CContact FindContactByIndex(CStep cOriginalStep,int iIndex)
        {
            CContact cTempContact = null;
            try
            {
                foreach(CContact cContact in cOriginalStep.ContactS)
                {
                    if(cContact.StepIndex == iIndex)
                    {
                        cTempContact = cContact;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cTempContact;
        }

        private static CCoil FindCoilByIndex(CStep cOriginalStep, int iIndex)
        {
            CCoil cTempCoil = null;
            try
            {
                foreach(CCoil cCoil in cOriginalStep.CoilS)
                {
                    if(cCoil.StepIndex == iIndex)
                    {
                        cTempCoil = cCoil;
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
            return cTempCoil;
        }

        private static void CreateNewStepRelation(CStep cSplitStep, CContactS cContactS, CContactS cRelatedContactS, string sStepKey)
        {
            try
            {
                CCoil cCoil = cSplitStep.CoilS.GetFirstCoil();

                if (cCoil.Relation.PrevContactS.Count != 0)
                {
                    foreach (int PreCont in cCoil.Relation.PrevContactS)
                        CreateContactRelatedCoil(PreCont, cContactS, cRelatedContactS, sStepKey);
                }

                cSplitStep.ContactS.AddRange(cRelatedContactS);
                m_lstUsedSymbolIndex.Add(cCoil.StepIndex);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void CreateContactRelatedCoil(int StepIndex, CContactS cContactS, CContactS cRelatedContactS, string sStepKey)
        {
            try
            {
                CContact cRelatedContact = null;

                foreach (CContact cContact in cContactS)
                {
                    if (cContact.StepIndex == StepIndex)
                    {
                        cRelatedContact = ContactClone(cContact, sStepKey);

                        if (!m_lstUsedSymbolIndex.Contains(cRelatedContact.StepIndex))
                        {
                            m_lstUsedSymbolIndex.Add(cContact.StepIndex);
                            cRelatedContactS.Add(cRelatedContact);
                        }

                        if (cRelatedContact.Relation.PrevContactS.Count != 0)
                        {
                            foreach (int PrevCont in cRelatedContact.Relation.PrevContactS)
                                CreateContactRelatedCoil(PrevCont, cContactS, cRelatedContactS, sStepKey);
                        }
                        break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static CContact ContactClone(CContact cContact, string sStepKey)
        {
            CContact cRelatedContact = new CContact();

            cRelatedContact.ContactType = cContact.ContactType;
            cRelatedContact.ContentS = cContact.ContentS;
            cRelatedContact.Instruction = cContact.Instruction;
            cRelatedContact.IsInitial = cContact.IsInitial;
            cRelatedContact.Operator = cContact.Operator;
            cRelatedContact.RefTagS = cContact.RefTagS;

            cRelatedContact.Relation.PrevCoilS.AddRange(cContact.Relation.PrevCoilS);
            cRelatedContact.Relation.PrevContactS.AddRange(cContact.Relation.PrevContactS);
            cRelatedContact.Relation.NextCoilS.AddRange(cContact.Relation.NextCoilS);
            cRelatedContact.Relation.NextContactS.AddRange(cContact.Relation.NextContactS);

            cRelatedContact.Step = sStepKey;
            cRelatedContact.StepIndex = cContact.StepIndex;

            return cRelatedContact;
        }

        private static CCoil CoilClone(CCoil cCoil, string sStepKey)
        {
            CCoil cRelatedCoil = new CCoil();

            cRelatedCoil.CoilType = cCoil.CoilType;
            cRelatedCoil.ContentS = cCoil.ContentS;
            cRelatedCoil.Instruction = cCoil.Instruction;
            cRelatedCoil.Command = cCoil.Command;
            cRelatedCoil.RefTagS = cCoil.RefTagS;

            cRelatedCoil.Relation.PrevCoilS.AddRange(cCoil.Relation.PrevCoilS);
            cRelatedCoil.Relation.PrevContactS.AddRange(cCoil.Relation.PrevContactS);
            cRelatedCoil.Relation.NextCoilS.AddRange(cCoil.Relation.NextCoilS);
            cRelatedCoil.Relation.NextContactS.AddRange(cCoil.Relation.NextContactS);

            cRelatedCoil.Step = sStepKey;
            cRelatedCoil.StepIndex = cCoil.StepIndex;
            //cRelatedCoil.LogCount = cCoil.LogCount;

            return cRelatedCoil;
        }

        private static void CheckStepRefTags(CStep cStep, string sBeforeKey, string sAfterKey)
        {
            try
            {
                //CTagStepRole cTagStepRoleTemp = null;

                if (cStep.ContactS.Count > 0)
                {
                    foreach (CContact tempContact in cStep.ContactS)
                    {
                        foreach (string refKey in tempContact.RefTagS.KeyList)
                        {
                            if (!cStep.RefTagS.ContainsKey(refKey))
                                cStep.RefTagS.Add(refKey, tempContact.RefTagS[refKey]);
                        }
                    }
                }

                if (cStep.CoilS.Count > 0)
                {
                    foreach (CCoil tempCoil in cStep.CoilS)
                    {
                        foreach (string refKey in tempCoil.RefTagS.KeyList)
                        {
                            if (!cStep.RefTagS.ContainsKey(refKey))
                                cStep.RefTagS.Add(refKey, tempCoil.RefTagS[refKey]);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void StepRelationModifile(CStep cStep)
        {
            try
            {
                List<int> lstUsedIndex = new List<int>();

                foreach (CContact cContact in cStep.ContactS)
                    lstUsedIndex.Add(cContact.StepIndex);

                foreach(CCoil cCoil in cStep.CoilS)
                    lstUsedIndex.Add(cCoil.StepIndex);

                foreach (CContact cContact in cStep.ContactS)
                    LogicUnitRelationModifile(cContact.Relation, lstUsedIndex);

                foreach(CCoil cCoil in cStep.CoilS)
                    LogicUnitRelationModifile(cCoil.Relation, lstUsedIndex);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void LogicUnitRelationModifile(CRelation cRelation, List<int> lstUsedIndex)
        {
            try
            {
                List<int> lstUnusedIndex = new List<int>();

                foreach(int iTemp in cRelation.PrevContactS)
                {
                    if (!lstUsedIndex.Contains(iTemp))
                        lstUnusedIndex.Add(iTemp);
                }

                foreach(int iTemp in lstUnusedIndex)
                {
                    cRelation.PrevContactS.Remove(iTemp);
                }

                lstUnusedIndex.Clear();

                foreach(int iTemp in cRelation.PrevCoilS)
                {
                    if (!lstUsedIndex.Contains(iTemp))
                        lstUnusedIndex.Add(iTemp);
                }

                foreach (int iTemp in lstUnusedIndex)
                {
                    cRelation.PrevCoilS.Remove(iTemp);
                }

                lstUnusedIndex.Clear();

                foreach (int iTemp in cRelation.NextContactS)
                {
                    if (!lstUsedIndex.Contains(iTemp))
                        lstUnusedIndex.Add(iTemp);
                }

                foreach (int iTemp in lstUnusedIndex)
                {
                    cRelation.NextContactS.Remove(iTemp);
                }

                lstUnusedIndex.Clear();

                foreach (int iTemp in cRelation.NextCoilS)
                {
                    if (!lstUsedIndex.Contains(iTemp))
                        lstUnusedIndex.Add(iTemp);
                }

                foreach (int iTemp in lstUnusedIndex)
                {
                    cRelation.NextCoilS.Remove(iTemp);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static void ConnectRelationToNext(CStep cRelatedStep, int iNextIndex, int iThisIndex,bool bIsNextCoil,bool bIsThisCoil)
        {
            try
            {
                if(bIsNextCoil)
                {
                    CCoil cTempCoil = cRelatedStep.CoilS.Find(x => x.StepIndex == iNextIndex);

                    if (cTempCoil != null)
                    {
                        if (bIsThisCoil)
                        {
                            if (!cTempCoil.Relation.PrevCoilS.Contains(iThisIndex))
                                cTempCoil.Relation.PrevCoilS.Add(iThisIndex);
                        }
                        else
                        {
                            if (!cTempCoil.Relation.PrevContactS.Contains(iThisIndex))
                                cTempCoil.Relation.PrevContactS.Add(iThisIndex);
                        }
                    }
                }
                else
                {
                    CContact cTempContact = cRelatedStep.ContactS.Find(x => x.StepIndex == iNextIndex);

                    if (cTempContact != null)
                    {
                        if (bIsThisCoil)
                        {
                            if (!cTempContact.Relation.PrevCoilS.Contains(iThisIndex))
                                cTempContact.Relation.PrevCoilS.Add(iThisIndex);
                        }
                        else
                        {
                            if (!cTempContact.Relation.PrevContactS.Contains(iThisIndex))
                                cTempContact.Relation.PrevContactS.Add(iThisIndex);
                        }  
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }
        }

        private static bool CheckIsHaveSameContact(CContactS cRelatedContactS, CContact cTempContact)
        {
            bool bOk = false;

            if (
                cRelatedContactS.Where(
                    x => x.Instruction == cTempContact.Instruction && x.StepIndex == cTempContact.StepIndex).Count() > 0)
                bOk = true;


            //foreach(CContact cContact in cRelatedContactS)
            //{
            //    if(cContact.Instruction == cTempContact.Instruction && cContact.StepIndex == cTempContact.StepIndex)
            //    {
            //        bOk = true;
            //        break;
            //    }
            //}

            return bOk;
        }

        #endregion
    }
}