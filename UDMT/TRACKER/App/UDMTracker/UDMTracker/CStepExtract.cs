using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.Common;
using UDM.UDLImport;

namespace UDMTracker
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

        public static void SplitStepS(CStepS cStepS, CTagS cGobalTagS, CTagS cLobalTagS)
        {
            Clear();

            m_cStepS = cStepS;
            m_cGlobalTagS = cGobalTagS;
            m_cLocalTagS = m_cLocalTagS;

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
                        //    if (CheckIsS7DBTagAddress(tempTag.Address))
                        //        refKey = tempTag.Key;
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
            foreach (CStep cStep in m_cStepS.Values)
            {
                if (cStep.CoilS.Count > 1)
                {
                    m_lstStepKey.Add(cStep.Key);
                    SplitOneCoilStep(cStep);
                }
            }

            foreach (string sStepKey in m_lstStepKey)
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

                foreach (CCoil cCoil in cCoilS)
                {
                    m_lstUsedSymbolIndex.Clear();

                    cSplitStep = new CStep();
                    cSplitStep.CoilS.Add(cCoil);

                    cSplitStep.Program = cStep.Program;
                    cSplitStep.StepIndex = cStep.StepIndex;

                    sKey = string.Format("{0}.{1}[{2}]", cSplitStep.Program, cSplitStep.StepIndex, cSplitStep.CoilS.GetFirstCoil().StepIndex);
                    cSplitStep.CoilS.GetFirstCoil().Step = sKey;

                    cRelatedContactS = new CContactS();

                    CreateNewStepRelation(cSplitStep, cStep.ContactS, cRelatedContactS, sKey);
                    UpdateUsedContactIndex(cSplitStep);


                    CheckStepRefTags(cSplitStep, cStep.Key, sKey);
                    cSplitStep.Key = sKey;
                    m_cTempStepS.Add(sKey, cSplitStep);
                    cTempStepS.Add(sKey, cSplitStep);
                }
                CheckTagStepRoleS(cStep.Key, cTempStepS);
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
                CTagStepRoleS cTempStepRoleS = null;
                CTagStepRole cTempStepRole = null;

                foreach (CStep cSplitStep in cTempStepS.Values)
                {
                    for (int i = 0; i < cSplitStep.RefTagS.Count; i++)
                    {
                        CTag cTag = cSplitStep.RefTagS[i];
                        cTempStepRoleS = new CTagStepRoleS();

                        foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        {
                            if (cTagStepRole.StepKey == sBeforeStepKey)
                            {
                                cTempStepRole = new CTagStepRole();
                                cTempStepRole.StepKey = cSplitStep.Key;
                                cTempStepRole.RoleType = cTagStepRole.RoleType;

                                cTempStepRoleS.Add(cTempStepRole);
                            }

                            cTempStepRoleS.Add(cTagStepRole);
                        }

                        cTag.StepRoleS = cTempStepRoleS;
                    }
                }

                foreach (CStep cSplitStep in cTempStepS.Values)
                {
                    for (int i = 0; i < cSplitStep.RefTagS.Count; i++)
                    {
                        CTag cTag = cSplitStep.RefTagS[i];
                        cTempStepRoleS = new CTagStepRoleS();

                        foreach (CTagStepRole cTagStepRole in cTag.StepRoleS)
                        {
                            if (cTagStepRole.StepKey != sBeforeStepKey)
                                cTempStepRoleS.Add(cTagStepRole);
                        }

                        cTag.StepRoleS = cTempStepRoleS;
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
                            {
                                cStep.RefTagS.Add(refKey, tempContact.RefTagS[refKey]);

                                //int DefaultCount = tempContact.RefTagS[refKey].StepRoleS.Count;
                                //CTagStepRoleS cTagStepRoleS = tempContact.RefTagS[refKey].StepRoleS;

                                //for (int i = 0; i < DefaultCount; i++ )
                                //{
                                //    if (cTagStepRoleS[i].StepKey == sBeforeKey)
                                //    {
                                //        cTagStepRoleTemp = new CTagStepRole();
                                //        cTagStepRoleTemp.RoleType = cTagStepRoleS[i].RoleType;
                                //        cTagStepRoleTemp.StepKey = sAfterKey;

                                //        tempContact.RefTagS[refKey].StepRoleS.Add(cTagStepRoleTemp);
                                //    }
                                //}
                            }
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
                            {
                                cStep.RefTagS.Add(refKey, tempCoil.RefTagS[refKey]);

                                //int DefaultCount = tempCoil.RefTagS[refKey].StepRoleS.Count;
                                //CTagStepRoleS cTagStepRoleS = tempCoil.RefTagS[refKey].StepRoleS;

                                //for (int i = 0; i < DefaultCount; i++)
                                //{
                                //    if (cTagStepRoleS[i].StepKey == sBeforeKey)
                                //    {
                                //        cTagStepRoleTemp = new CTagStepRole();
                                //        cTagStepRoleTemp.RoleType = cTagStepRoleS[i].RoleType;
                                //        cTagStepRoleTemp.StepKey = sAfterKey;

                                //        tempCoil.RefTagS[refKey].StepRoleS.Add(cTagStepRoleTemp);
                                //    }
                                //}
                            }
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

        #endregion
    }
}