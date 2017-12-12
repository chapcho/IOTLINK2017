using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using UDM.Common;
using UDM.General;
using UDM.UDLImport;
using UDM.Log;


namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDRung
    {
        private string m_sAddress = string.Empty;
        private string m_sSymbol = string.Empty;
        private string m_sKey = string.Empty;
        private List<string> m_ListCoil = new List<string>();
        private List<string> m_ListContact = new List<string>();
        private List<CLDNodeRow> m_lstTagRow = new List<CLDNodeRow>();

        private Dictionary<string, List<CLDNodeBody>> m_DicILNode = new Dictionary<string, List<CLDNodeBody>>();
        private Dictionary<string, List<CContact>> m_DicLogic = new Dictionary<string, List<CContact>>();  
        private bool m_bDeadCoil = false;
        private bool m_bEndCoil = false;
        //private int m_nLogBlock = -1;
        //private int m_nLogCycle = -1;
        
        private CStep m_cStep = null;
        private EMOperaterType m_eDiagrmaOperator = EMOperaterType.And;
        private bool m_bHasPulse = false; // MEP, MEF, EGP, EGF , INV
        private bool m_bLogicCountAvalable = true;
        private CTimeLogS m_cTimeLogS = new CTimeLogS();

        #region Initialize/Dispose

        public CLDRung(CStep cStep)
        {
            InitialParameter(cStep);

            CreateDicLogic();

            if (m_bLogicCountAvalable && m_DicLogic.Count != 1)
                CreateCommonLogic();

            m_bHasPulse = CheckPulseCommand();


            CreateDiagram();

            UpdateProperty();
        }

        public void Dispose()
        {
        }

        #endregion

        #region Public interface

        public string CoilAddress
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string CoilSymbol
        {
            get { return m_sSymbol; }
            set { m_sSymbol = value; }
        }

        public string CoilKey
        {
            get { return m_sKey; }
        }

        public string CoilCommand
        {
            get { return m_cStep.CoilS.GetFirstCoil().Command; }

        }
        public string CoilStep
        {
            get { return m_cStep.StepIndex.ToString(); }
        }

        public string CoilProgram
        {
            get { return m_cStep.Program; }
        }

        //public int Packet
        //{
        //    get { return m_nLogBlock; }
        //    set { m_nLogBlock = value; }
        //}

        //public int Cycle
        //{
        //    get { return m_nLogCycle; }
        //    set { m_nLogCycle = value; }
        //}

        public string RefInfo
        {
            get
            {
                string sRefinfo = string.Format("{0:0000}, [{1}]", m_cStep.StepIndex, m_cStep.CoilS.GetFirstCoil().Instruction);

                return sRefinfo;
            }
        }

        public Dictionary<string, List<CLDNodeBody>> DIAGRAM_HEADS
        {
            get { return m_DicILNode; }
        }

        public CStep Step
        {
            get { return m_cStep; }
        }

        public bool IsDeadCoil
        {
            get { return m_bDeadCoil; }
            set { m_bDeadCoil = value; }
        }

        public bool IsEndCoil
        {
            get { return m_bEndCoil; }
            set { m_bEndCoil = value; }
        }

        public List<string> lstCoil
        {
            get { return m_ListCoil; }
        }

        public List<string> lstContact
        {
            get { return m_ListContact; }
        }

        public EMOperaterType DIAGRAM_OPREATOR
        {
            get { return m_eDiagrmaOperator; }
            set { m_eDiagrmaOperator = value; }
        }

        public bool HasPulse
        {
            get { return m_bHasPulse; }
        }

        public bool IsMixBlock
        {
            get { return !m_bLogicCountAvalable; }
        }

        public CTimeLogS TimeLogS
        {
            get { return m_cTimeLogS; }
            set { m_cTimeLogS = value; }
        }

        public List<CLDNodeRow> TagRowS
        {
            get { return m_lstTagRow; }
            set { m_lstTagRow = value; }
        }
        
        #endregion

        #region Public Method

        public List<CLDNodeRow> GetILNodeRowAll()
        {
            List<CLDNodeRow> ListILNodeRow = new List<CLDNodeRow>();

            foreach (var who in m_DicILNode)
            {
                foreach (CLDNodeBody cILNode in m_DicILNode[who.Key])
                {
                    foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                    {
                        ListILNodeRow.Add(cILNodeRow);
                    }
                }
            }

            return ListILNodeRow;
        }


        //public CILSymbolS GetUsedSymbols()
        //{
        //    CILSymbol cLcSymbol = null;
        //    CILSymbolS cLcSymbolS = new CILSymbolS();

        //    cLcSymbol = new CILSymbol(string.Empty, this.CoilAddress, this.CoilProgram);
        //    if (!cLcSymbolS.ContainsKey(cLcSymbol.Key))
        //        cLcSymbolS.Add(cLcSymbol.Key, cLcSymbol);

        //    foreach (var who in this.DIAGRAM_HEADS)
        //    {
        //        foreach (CLDNodeBody cILNode in this.DIAGRAM_HEADS[who.Key])
        //        {
        //            foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
        //            {
        //                foreach (string sAddress in cILNodeRow.ListAddress)
        //                {
        //                    if (sAddress == string.Empty)
        //                        continue;

        //                    cLcSymbol = new CILSymbol(string.Empty, sAddress, this.CoilProgram);
        //                    if (!cLcSymbolS.ContainsKey(cLcSymbol.Key))
        //                        cLcSymbolS.Add(cLcSymbol.Key, cLcSymbol);
        //                }

        //            }
        //        }
        //    }

        //    return cLcSymbolS;
        //}

        public string GetFirstKey()
        {
            string sKey = string.Empty;

            CCoil cCoil = m_cStep.CoilS.GetFirstCoil();

            foreach (CContent cContent in cCoil.ContentS)
            {
                if (cContent.Parameter == EMParametorType.D1.ToString())
                {
                    if (cContent.ArgumentType == EMArgumentType.Tag)
                        sKey = cContent.Tag.Key;
                    break;
                }
            }

            if (sKey == string.Empty)
                sKey = cCoil.RefTagS.GetFirstTag().Key;

            return sKey;
        }

        #endregion

        #region Private Method

        private void UpdateProperty()
        {
            try
            {
                CreateCoilAddress();

                CreateContactAddress();

                foreach (var who in DIAGRAM_HEADS)
                {
                    foreach (CLDNodeBody cILNodeBody in DIAGRAM_HEADS[who.Key])
                    {
                        ApplyNodeDeadCoil(cILNodeBody);
                        if (cILNodeBody.IsDeadCoil && who.Key.Contains(EILGroup.C.ToString()))
                            IsDeadCoil = true;
                        foreach (CLDNodeRow cILNodeRow in cILNodeBody.ListILNodeRow)
                        {
                            if (cILNodeRow.ContactType == EMContactType.Compare)
                                cILNodeRow.IsCompareRow = true;
                        }
                    }
                }

                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        private void ApplyNodeDeadCoil(CLDNodeBody cILNodeBody)
        {
            try
            {
                foreach (CLDNodeRow cILNodeRow in cILNodeBody.ListILNodeRow)
                {
                    if ((cILNodeRow.Address == "SM400" && cILNodeRow.Instruction == EMContactTypeBit.Close.ToString())
                    || (cILNodeRow.Address == "SM401" && cILNodeRow.Instruction == EMContactTypeBit.Open.ToString()))
                        if (!(cILNodeBody.OR_DIAGRAM || cILNodeBody.IsMixDiagram))
                        {
                            cILNodeBody.IsDeadCoil = true;
                            break;
                        }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CreateCoilAddress()
        {
            try
            {
                m_ListCoil.Clear();

                List<CTag> lstTag = new List<CTag>();

                foreach (CContent cContent in m_cStep.CoilS.GetFirstCoil().ContentS)
                {
                    if (cContent.ArgumentType == EMArgumentType.Tag)
                    {
                        if(cContent.Tag != null)
                            lstTag.Add(cContent.Tag);
                    }
                }

                foreach (CTag cTag in lstTag)
                    if (!m_ListCoil.Contains(cTag.Address))
                        m_ListCoil.Add(cTag.Address);

                //             if (Step.CallControl != string.Empty)
                //             {
                //                 foreach (string sPosition in Step.CallControl.Split('*'))
                //                     if (sPosition != string.Empty)
                //                         if (!m_ListCoil.Contains(sPosition))
                //                                 m_ListCoil.Add(sPosition);
                //             }
                if (Step.MasterControl != string.Empty)
                {
                    foreach (string sPosition in Step.MasterControl.Split('*'))
                        if (sPosition != string.Empty)
                            if (!m_ListCoil.Contains(sPosition))
                                m_ListCoil.Add(sPosition);
                }
                //             if (Step.ForNextControl != string.Empty)
                //             {
                //                 foreach (string sPosition in Step.ForNextControl.Split('*'))
                //                     if (sPosition != string.Empty)
                //                         if (!m_ListCoil.Contains(sPosition))
                //                                 m_ListCoil.Add(sPosition);
                //             }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        private void CreateContactAddress()
        {
            try
            {
                m_ListContact.Clear();

                for (int i = 0; i < m_cStep.RefTagS.Count; i++)
                {
                    CTag cTag = (CTag)m_cStep.RefTagS[i];
                    m_ListContact.Add(cTag.Address);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
      
        private void RelationCallBack(CContact cContact, Dictionary<int, List<int>> DicBuffer)
        {
            if (m_DicLogic.Count > EMDiagramConfig.MixBlockLimit || !m_bLogicCountAvalable)
            {
                m_bLogicCountAvalable = false;
                return;
            }

            if (cContact.Relation.NextContactS.Count == 0)
            {
                CreateNewCondition(DicBuffer);
            }

            foreach (int  iContact in cContact.Relation.NextContactS)
            {
                if (cContact.Relation.NextContactS.Count > 1 && cContact.Relation.NextContactS.Last() != iContact)
                    BufferPush(DicBuffer);

                CContact cTemp = GetContact(m_cStep, iContact);

                BufferAddContact(DicBuffer, cTemp);

                RelationCallBack(cTemp, DicBuffer);
            }
        }

        private void CreateNewCondition(Dictionary<int, List<int>> DicBuffer)
        {
            List<CContact> lstContact = new List<CContact>();
            List<int> lstContactIndex = DicBuffer.Values.Last();

            foreach (int i in lstContactIndex)
                lstContact.Add(GetContact(m_cStep, i));

            m_DicLogic.Add(EILGroup.O.ToString() + m_DicLogic.Count.ToString(), lstContact);

            BufferPop(DicBuffer);

            return;
        }

        private void BufferAddContact(Dictionary<int, List<int>> DicBuffer, CContact cContact)
        {
            int iContact = cContact.StepIndex;

            if (DicBuffer.Values.Count > 0)
                DicBuffer.Values.Last().Add(iContact);
            else
            {
                Console.WriteLine("Warning : {0} [{1}] - {2}", "Not Support IL Command", System.Reflection.MethodBase.GetCurrentMethod().Name, m_cStep.CoilS.GetFirstCoil().Instruction);
            }
        }

        private void BufferPush(Dictionary<int, List<int>> DicBuffer)
        {
            List<int> lstInt = new List<int>(DicBuffer.Values.Last().ToArray());
            DicBuffer.Add(DicBuffer.Count,lstInt);
        }

        private void BufferPop(Dictionary<int, List<int>> DicBuffer)
        {
            int iRemove = DicBuffer.Count - 1;
            DicBuffer.Remove(iRemove);
        }

        private void InitialParameter(CStep cStep)
        {
            m_cStep = cStep;
            m_sKey = string.Format("{0}.{1}[{2}]", cStep.Program, cStep.StepIndex, cStep.CoilS.GetFirstCoil().StepIndex);

            if (cStep.CoilS.GetFirstCoil().RefTagS.Count > 0)
            {
                m_sAddress = cStep.CoilS.GetFirstCoil().RefTagS[0].Address;
                m_sSymbol = cStep.CoilS.GetFirstCoil().RefTagS[0].Description;
            }
        }

        private void CreateDicLogic()
        {
            try
            {
                m_DicLogic.Clear();

                foreach (CContact cContact in m_cStep.ContactS)
                {
                    if (!m_bLogicCountAvalable)
                        break;

                    if (!cContact.IsInitial)
                        continue;

                    if (cContact.Relation.NextContactS.Count == 0)
                    {
                        m_DicLogic.Add(EILGroup.O.ToString() + m_DicLogic.Count.ToString(), new List<CContact> { cContact });
                        continue;
                    }

                    Dictionary<int, List<int>> DicBuffer = new Dictionary<int, List<int>>();

                    foreach (int iContact in cContact.Relation.NextContactS)
                    {
                        List<int> lstContact = new List<int>();

                        lstContact.Add(cContact.StepIndex);
                        lstContact.Add(iContact);

                        DicBuffer.Add(DicBuffer.Count, lstContact);

                        CContact cTemp = GetContact(m_cStep, iContact);

                        RelationCallBack(cTemp, DicBuffer);

                        if (!m_bLogicCountAvalable)
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, m_cStep.CoilS.GetFirstCoil().Instruction); ex.Data.Clear();
            }
        }

        private CContact GetContact(CStep cStep, int StepIndex)
        {
            CContact cContact = null;

            foreach(CContact cTemp in cStep.ContactS)
            {
                if(cTemp.StepIndex == StepIndex)
                {
                    cContact = cTemp;
                    break;
                }
            }

            return cContact;
        }

        private void CreateCommonLogic()
        {
            try
            {
                List<CContact> lstContactMaxCount = GetMaxContactS();
                List<CContact> lstContactCommon = new List<CContact>();

                foreach (CContact cContact in lstContactMaxCount)
                {
                    if (IsCommonContact(cContact))
                        lstContactCommon.Add(cContact);
                }

                foreach (CContact cContact in lstContactCommon)
                    RemoveCommonContact(cContact);

                if (lstContactCommon.Count > 0)
                    m_DicLogic.Add(EILGroup.C.ToString() + m_DicLogic.Count.ToString(), lstContactCommon);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void CreateDiagram()
        {
            try
            {
                List<CLDNodeRow> lstLDNodeRow = new List<CLDNodeRow>();
                if (m_bLogicCountAvalable)
                {
                    m_DicILNode.Add(EILGroup.C.ToString(), new List<CLDNodeBody>());
                    m_DicILNode.Add(EILGroup.O.ToString(), new List<CLDNodeBody>());

                    foreach (var who in m_DicLogic)
                    {
                        lstLDNodeRow = new List<CLDNodeRow>();
                        foreach (CContact cContact in who.Value)
                        {
                            CLDNodeRow cLDNodeRow = new CLDNodeRow(cContact, m_cStep);
                            lstLDNodeRow.Add(cLDNodeRow);
                        }

                        CLDNodeBody cILNodeBody = new CLDNodeBody(lstLDNodeRow);

                        if (who.Key.StartsWith(EILGroup.C.ToString()) && cILNodeBody.ListILNodeRow.Count != 0)
                            m_DicILNode[EILGroup.C.ToString()].Add(cILNodeBody);

                        if (who.Key.StartsWith(EILGroup.O.ToString()))
                            m_DicILNode[EILGroup.O.ToString()].Add(cILNodeBody);

                    }

                    if (m_DicILNode[EILGroup.C.ToString()].Count == 0 && m_DicILNode[EILGroup.O.ToString()].Count < 2)
                    {
                        m_DicILNode[EILGroup.C.ToString()].Add(m_DicILNode[EILGroup.O.ToString()][0]);
                        m_DicILNode.Remove(EILGroup.O.ToString());
                    }
                }
                else
                {
                    CreateMixDiagram();
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        private void CreateOrDiagram()
        {

          
        }

        private void CreateMixDiagram()
        {
            try
            {
                List<CLDNodeRow> lstLDNodeRow = new List<CLDNodeRow>();

                m_DicILNode.Add(EILGroup.C.ToString(), new List<CLDNodeBody>());
                m_DicILNode.Add(EILGroup.M.ToString(), new List<CLDNodeBody>());

                foreach (CContact cContact in m_cStep.ContactS)
                {
                    CLDNodeRow cLDNodeRow = new CLDNodeRow(cContact, m_cStep);
                    lstLDNodeRow.Add(cLDNodeRow);
                }

                CLDNodeBody cILNodeBody = new CLDNodeBody(lstLDNodeRow);

                m_DicILNode[EILGroup.M.ToString()].Add(cILNodeBody);
                cILNodeBody.IsMixDiagram = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private List<CContact> GetMaxContactS()
        {
            List<CContact> lstContactMaxCount = new List<CContact>();
            int nMax = 0;
            foreach (List<CContact> lstContact in m_DicLogic.Values)
            {
                if (lstContact.Count >= nMax)
                {
                    lstContactMaxCount = lstContact;
                    nMax = lstContactMaxCount.Count;
                }
            }

            return lstContactMaxCount;
        }

        private bool IsCommonContact(CContact cContact)
        {
            foreach (List<CContact> lstContact in m_DicLogic.Values)
            {
                if (!lstContact.Contains(cContact))
                    return false;
            }

            return true;
        }

        private bool RemoveCommonContact(CContact cContact)
        {
            foreach (List<CContact> lstContact in m_DicLogic.Values)
            {
                lstContact.Remove(cContact);
            }

            return true;
        }

        #endregion

        #region Privates Methods

        private bool CheckPulseCommand()
        {
            foreach (CContact cContact in m_cStep.ContactS)
            {
                if (cContact.ContactType == EMContactType.Logical)
                    return true;
            }

            return false;
        }

        #endregion
    }

}
