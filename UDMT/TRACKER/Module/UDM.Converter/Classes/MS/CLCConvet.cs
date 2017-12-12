using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.General;


namespace UDM.Converter
{
    [Serializable]
    public class CLCConvet
    {
		private string m_sChannel = "";
        private CTagS m_cTagS = null;
        private CStepS m_cStepS = null;
        private CILSymbolS m_cILSymbolS = null;
        private List<string> m_lstCommandAll = CILImportType.GetCommandAll();

        
        #region Initialize/Dispose

		public CLCConvet(string sChannel, CILConvert cILConvert)
		{
			m_sChannel = sChannel;
            m_cILSymbolS = cILConvert.SymbolS;
            CreateTagS(cILConvert);
            m_cStepS = GetStepS(cILConvert);
		}

        public CLCConvet(CILConvert cILConvert)
        {
            m_cILSymbolS = cILConvert.SymbolS;
            CreateTagS(cILConvert);
            m_cStepS = GetStepS(cILConvert);
        }

        public void Dispose()
        {
            m_cTagS.Clear();
            m_cStepS.Clear();
            m_cILSymbolS.Clear();
            m_lstCommandAll.Clear();
        }

        #endregion

        #region Public interface

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

        #endregion

        #region Public Methods

  
        #endregion

        #region Privates Methods

        private bool CreateTagS(CILConvert cILConvert)
        {
            CTag cTag = null;
            m_cTagS = new CTagS();
            List<string> lstCoil = new List<string>();
            List<string> lstContact = new List<string>();
            string sCommand = string.Empty;
            bool bDword = false;

            try
            {
                foreach (CILStep cILStep in cILConvert.LIST_COIL)
                {
                    lstCoil = cILStep.ILLine.GetUsedAddress();
                    bDword = cILStep.ILLine.CheckDoubleWord(m_lstCommandAll);

                    foreach (string sAddress in lstCoil)
                    {
                        cTag = GetTag(cILStep, sAddress, bDword);

                        if (cTag != null && !m_cTagS.ContainsKey(cTag.Key))
                            m_cTagS.Add(cTag.Key, cTag);
                    }


                    foreach (CILContact cILContact in cILStep.RelationContactS)
                    {
                        lstContact = cILContact.UsedAddressS;
                        bDword = cILContact.ILLine.CheckDoubleWord(m_lstCommandAll);

                        foreach (string sAddress in lstContact)
                        {
                            cTag = GetTag(cILStep, sAddress, bDword);

                            if (cTag != null && !m_cTagS.ContainsKey(cTag.Key))
                                m_cTagS.Add(cTag.Key, cTag);
                        }
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                return false;
            }
        }

        private CTag GetTag(CILStep cILStep, string sAddress, bool bDWord)
        {
            CTag cTag = null;

            string sKey = string.Format("[{0}]{1}[{2}]", m_sChannel , sAddress.Replace(".", "_"), bDWord ? 2 : 1);

            if (m_cTagS.ContainsKey(sKey))
            {
                cTag = m_cTagS[sKey];
            }
            else if (CPlcMelsec.IsAddress(sAddress))
            {
                cTag = new CTag();
                cTag.Key = sKey;
				cTag.Channel = m_sChannel;
                cTag.Address = sAddress;
                cTag.Description = m_cILSymbolS.GetSymbol(cILStep.Program, sAddress);
                cTag.Program = cILStep.Program;

                if (CPlcMelsec.IsHexa(sAddress))
                    cTag.AddressType = EMAddressType.Hexa;
                else
                    cTag.AddressType = EMAddressType.Decimal;

                if (sAddress.StartsWith("K"))
                {
                    cTag.DataType = EMDataType.Word;
                    cTag.Size = 1;
                }
                else if (bDWord || sAddress.StartsWith("@"))
                {
                    cTag.DataType = EMDataType.DWord;
                    cTag.Size = 2;
                }                
                else if (CPlcMelsec.IsBit(sAddress))
                {
                    cTag.DataType = EMDataType.Bool;
                }
                else
                {
                    cTag.DataType = EMDataType.Word;
                }
            }

            return cTag;
        }

        private CContent GetArgument(CILStep cILStep, string sItem, string sType, bool bDword)
        {
            CContent cContent = null;

            CTag cTag = GetTag(cILStep, sItem, bDword);
            if (cTag != null)
            {
                cContent = new CContent();
                cContent.ArgumentType = EMArgumentType.Tag;
                cContent.Tag = cTag;
                cContent.Parameter = sType;
                cContent.Argument = sItem;
            }
            else if (CPlcMelsec.IsNumeric(sItem))
            {
                cContent = new CContent();
                cContent.ArgumentType = EMArgumentType.Constant;
                cContent.Parameter = sType;
                cContent.Argument = sItem;
            }
            else if (sItem != string.Empty)
            {
                cContent = new CContent();
                cContent.Parameter = sType;
                cContent.Argument = sItem;
            }

            return cContent;
        }

        private bool CreateArgumentS(CILStep cILStep, CILLine cILLine, CContentS cContentS)
        {
            CContent cContent = null;
            bool bDword = cILLine.CheckDoubleWord(m_lstCommandAll);

            cContent = GetArgument(cILStep, cILLine.SpecialParameter, EMParametorType.Etc.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Source, EMParametorType.S1.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Source_Sub1, EMParametorType.S2.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Source_Sub2, EMParametorType.S3.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Source_Sub4, EMParametorType.S4.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Destination, EMParametorType.D1.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Destination_Sub1, EMParametorType.D2.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Destination_Sub2, EMParametorType.D3.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Numeric, EMParametorType.N1.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Numeric_Sub1, EMParametorType.N2.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Numeric_Sub2, EMParametorType.N3.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
            cContent = GetArgument(cILStep, cILLine.Numeric_Sub3, EMParametorType.N4.ToString(), bDword);
            if (cContent != null)
                cContentS.Add(cContent);
       

            return true;
        }

        private bool CreateMoveArgumentS(CILStep cILStep, CContentS cContentS)
        {
            CContent cContent = null;

            CILSubData cILSubData = CILSubDataType.GetILSubData(cILStep.ILLine);
            bool bDword = cILStep.ILLine.CheckDoubleWord(m_lstCommandAll);
            if (cILSubData == null)
                return true;

          
            foreach (string sAddress in cILSubData.SubDataListDst)
            {
                cContent = GetArgument(cILStep, sAddress, EMParametorType.Dst.ToString(), bDword);
                if (cContent != null && cContent.Tag != null)
                    cContentS.Add(cContent);
            }

            foreach (string sAddress in cILSubData.SubDataListSrc)
            {
                cContent = GetArgument(cILStep, sAddress, EMParametorType.Src.ToString(), bDword);
                if (cContent != null && cContent.Tag != null)
                    cContentS.Add(cContent);
            }

            return true;
        }        
    
        #region Coil Methods

        private CCoilS GetCoil(CILStep cILStep)
        {
            try
            {
                CCoilS cCoilS = new CCoilS();
                CCoil cCoil = new CCoil();
                cCoil.CoilType = cILStep.CoilType;
                cCoil.Command = cILStep.CoilCommand;
                cCoil.Instruction = cILStep.CoilCommandFull;
                
                cCoil.StepIndex = GetStepNumber(cILStep);
                cCoilS.Add(cCoil);

                CreateArgumentS(cILStep, cILStep.ILLine, cCoil.ContentS);

                CreateMoveArgumentS(cILStep, cCoil.ContentS);

                CTag cTag;
                for (int i = 0; i < cCoil.ContentS.Count; i++)
                {
                    cTag = cCoil.ContentS[i].Tag;
                    if (cTag != null)
                        cCoil.RefTagS.Add(cTag.Key, cTag);

                }

                if (cILStep.RelationContactS.Count == 0 && !CILType.IsCommandOnlyIL(cILStep.CoilCommand))
                    Console.WriteLine("Warning : {0} [{1}] - {2}", "there is no Contact", System.Reflection.MethodBase.GetCurrentMethod().Name, cILStep.DebugInfo);

                return cCoilS;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, cILStep.DebugInfo); ex.Data.Clear();
                return null;
            }
        }

        #endregion

        #region Contact Methods

        private CContact GetContact(CILStep cILStep, CILContact cILContact)
        {
            try
            {
                CContact cContact = new CContact();
                cContact.ContactType = cILContact.eILConnenct;
                cContact.Instruction = cILContact.ILLine.CommandFull;
                cContact.Operator = cILContact.emContactTypeBit.ToString();
                cContact.StepIndex = GetStepNumber(cILStep);

                CreateArgumentS(cILStep, cILContact.ILLine, cContact.ContentS);

                if (cILContact.eILConnenct == EMContactType.Compare)
                {
                    cContact.ContactType = EMContactType.Compare;
                    UpdateContactCase(cContact, cILStep, cILContact);
                }

                if (cILContact.eILConnenct == EMContactType.Logical)
                {
                    cContact.ContactType = EMContactType.Logical;
                    UpdateContactTypeLogicalMelsec(cContact, cILContact);
                }

                CTag cTag;
                for (int i = 0; i < cContact.ContentS.Count; i++)
                {
                    cTag = cContact.ContentS[i].Tag;
                    if (cTag != null)
                        cContact.RefTagS.Add(cTag.Key, cTag);
                }

                return cContact;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, cILStep.DebugInfo); ex.Data.Clear();
                return null;
            }
        }

        private void UpdateContactTypeLogicalMelsec(CContact cContact, CILContact cILContact)
        {
            if (cILContact.Command == "INV")
                cContact.Operator = EMContactTypeLogical.INV.ToString();
            else if (cILContact.Command == "MEP")
                cContact.Operator = EMContactTypeLogical.MEP.ToString();
            else if (cILContact.Command == "MEF")
                cContact.Operator = EMContactTypeLogical.MEF.ToString();
            else if (cILContact.Command == "EGF")
                cContact.Operator = EMContactTypeLogical.EGF.ToString();
            else if (cILContact.Command == "EGP")
                cContact.Operator = EMContactTypeLogical.EGP.ToString();
        }

        private void UpdateContactCase(CContact cContact, CILStep cILStep, CILContact cILContact)
        {
            string strCompareOnly = cILContact.Command.Replace("LD", string.Empty).Replace("OR", string.Empty).Replace("AND", string.Empty);
            
            cContact.Instruction = string.Format("{0} {1} {2}", cILContact.ILLine.Source, strCompareOnly, cILContact.ILLine.Source_Sub1);

            strCompareOnly = strCompareOnly.Replace("D", string.Empty).Replace("E", string.Empty).Replace("$", string.Empty);
            
            if (strCompareOnly == "=")
                cContact.Operator = EMContactTypeCompare.Equal.ToString();
            else if (strCompareOnly == "<>")
                cContact.Operator = EMContactTypeCompare.EqualNot.ToString();
            else if (strCompareOnly == ">")
                cContact.Operator = EMContactTypeCompare.Large.ToString();
            else if (strCompareOnly == ">=")
                cContact.Operator = EMContactTypeCompare.LargeEqual.ToString();
            else if (strCompareOnly == "<")
                cContact.Operator = EMContactTypeCompare.Small.ToString();
            else if (strCompareOnly == "<=")
                cContact.Operator = EMContactTypeCompare.SmallEqual.ToString();
            else
            {
                Console.WriteLine("Warning : {0} Can't Assign ContactCase [{1}]", cILContact.ILLine.ItemArray, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        #endregion

        #region Step Methods


        private CStepS GetStepS(CILConvert cILConvert)
        {
            CStepS cStepS = new CStepS();
            CILStep cILStepDebug = null;
            try
            {
                foreach (CILStep cILStep in cILConvert.LIST_COIL)
                {
                    cILStepDebug = cILStep;

                    CCoilS cCoilS = GetCoil(cILStep);
                    if (cCoilS.Count == 0)
                        continue;

                    CStep cStep = new CStep();
                    cStep.CoilS = cCoilS;
                    cStep.Program = cILStep.Program;
                    cStep.StepIndex = cILStep.ILLine.StepNumber;
                    cStep.MasterControl = cILStep.MasterControl;
                    cStep.ForNextControl = cILStep.ForNextControl;
                    cStep.CallControl = cILStep.CallControl;
                    
                    CreateRelationContact(cStep, cILStep);
                    CreateTotalTagS(cStep);

                    UpdateStepKey(cStep);

                    cStepS.Add(cStep.Key, cStep);
                }

                return cStepS;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, cILStepDebug.DebugInfo); ex.Data.Clear();
                return new CStepS();
            }
        }

        private void UpdateStepKey(CStep cStep)
        {
            string sKey = cStep.Program + "_" + cStep.StepIndex;

            cStep.Key = sKey;

            for (int i = 0; i < cStep.CoilS.Count; i++)
                cStep.CoilS[i].Step = sKey;

            for (int i = 0; i < cStep.ContactS.Count; i++)
                cStep.ContactS[i].Step = sKey;
        }

        private int GetStepNumber(CILStep cILStep)
        {
            int nStep = -1;
            if (CStringHelper.IsDigitString(cILStep.ILLine.Step))
                nStep = Convert.ToInt32(cILStep.ILLine.Step);

            return nStep;
        }

        private bool CreateRelationContact(CStep cStep, CILStep cILStep)
        {
            Dictionary<CILContact, CContact> DicContact = new Dictionary<CILContact, CContact>();
            foreach (CILContact cILContact in cILStep.RelationContactS)
            {
                if (cILContact.eILType == EILType.LINE)
                    continue;

                CContact cContact = GetContact(cILStep, cILContact);
                if (cContact == null)
                    continue;

                cContact.IsInitial = cILContact.IsInitial;
                cStep.ContactS.Add(cContact);
                DicContact.Add(cILContact, cContact);
            }

            foreach (CILContact cILContact in cILStep.RelationContactS)
            {
                if (cILContact.eILType == EILType.LINE)
                    continue;

                CContact cContact = DicContact[cILContact];
                if (cILContact.RelationS.Count == 0)
                {
                    cContact.Relation.NextCoilS.Add(0);
                }
                else
                {
                    foreach (int iContact in cILContact.RelationS)
                    {
                        CILContact cILContactFind = FindILContact(cILStep, iContact);
                        if (cILContactFind != null)
                        {
                            int iNext = cStep.ContactS.IndexOf(DicContact[cILContactFind]);
                            cContact.Relation.NextContactS.Add(iNext);
                        }
                    }
                }
            }

            return true;
        }

        private CILContact FindILContact( CILStep cILStep, int iContact)
        {
            CILContact cILContactFind = null;
            foreach (CILContact cILContact in cILStep.RelationContactS)
            {
                if (cILContact.ContactNum == iContact)
                {
                    cILContactFind =  cILContact;
                    break;
                }
            }

            return cILContactFind;
        }


        private bool CreateTotalTagS(CStep cStep)
        {
            foreach (CCoil cCoil in cStep.CoilS)
            {
                CTag cTag;
                for (int i = 0; i < cCoil.RefTagS.Count; i++)
                {
                    cTag = cCoil.RefTagS.GetValueAt(i);
                    if (!cStep.RefTagS.ContainsKey(cTag.Key))
                        cStep.RefTagS.Add(cTag.Key, cTag);
                }
            }

            foreach (CContact cContact in cStep.ContactS)
            {
                CTag cTag;
                for (int i = 0; i < cContact.RefTagS.Count; i++)
                {
                    cTag = cContact.RefTagS.GetValueAt(i);
                    if (!cStep.RefTagS.ContainsKey(cTag.Key))
                        cStep.RefTagS.Add(cTag.Key, cTag);
                }

                foreach (CContent cContent in cContact.ContentS)
                {
                    if (cContent.ArgumentType == EMArgumentType.Tag)
                    {
                        if (m_cTagS.ContainsKey(cContent.Argument))
                            cStep.RefTagS.Add(m_cTagS[cContent.Argument].Key, m_cTagS[cContent.Argument]);
                    }
                }
            }

            return true;
        }

        #endregion
    
        #endregion
    }
}
