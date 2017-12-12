using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.General;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILStep : ICloneable
    {
        private string m_sProgramName = string.Empty;
        private string m_sCoilAddress = string.Empty;
        private string m_sCoilSymbol = string.Empty;
        private string m_sCoilCommand = string.Empty;
        private string m_sCoilCommandFull = string.Empty;
        private string m_sMasterControl = string.Empty;
        private string m_sForNextControl = string.Empty;
        private string m_sCallControl = string.Empty;

        private EMCoilType m_emCoilType = EMCoilType.None;

        private int m_iLoad = 0;
        private int m_iBlock = 1;
        private int m_iMergeDepth = 0;
        private bool m_bBlockConveted = false;

        private CILLine m_cILLineCoil = null;
        private CILBufferS m_cILBufferS = null;
        private List<CILBlock> m_ListILBlock = new List<CILBlock>();
        private List<CCell> m_ListBlockCell = new List<CCell>();
        private List<CILContact> m_ListRelationContact = new List<CILContact>();
        private List<string> m_lstLoadOperator = new List<string>();

        #region Initialize/Dispose

        public CILStep()
        {
            m_cILBufferS = new CILBufferS();

        }

        public object Clone()
        {
            CILStep ILStep = (CILStep)this.MemberwiseClone();
            ILStep.m_ListILBlock = m_ListILBlock.Clone();
            ILStep.m_ListBlockCell = m_ListBlockCell.Clone();
            ILStep.m_ListRelationContact = m_ListRelationContact.Clone();
            ILStep.m_lstLoadOperator = m_lstLoadOperator.Clone();
            ILStep.m_cILBufferS = new CILBufferS();

            foreach (var who in m_cILBufferS)
            {
                CILBuffer cILBuffer = (CILBuffer)who.Value.Clone();
                ILStep.m_cILBufferS.Add(ILStep.m_cILBufferS.Count, cILBuffer);
            }

            ILStep.m_cILBufferS.Logic = (CPlcLogic)m_cILBufferS.Logic.Clone();

            return ILStep;
        }

        public void Dispose()
        {
        }

        #endregion

        #region Public interface

        public string Program
        {
            get { return m_sProgramName; }
            set { m_sProgramName = value; }
        }

        public string CoilAddress
        {
            get { return m_sCoilAddress; }
            set { m_sCoilAddress = value; }
        }

        public string CoilSymbol
        {
            get { return m_sCoilSymbol; }
            set { m_sCoilSymbol = value; }
        }

        public string CoilCommand
        {
            get { return m_sCoilCommand; }
            set { m_sCoilCommand = value; }
        }

        public string CoilCommandFull
        {
            get { return m_sCoilCommandFull; }
            set { m_sCoilCommandFull = value; }
        }

        public string MasterControl
        {
            get { return m_sMasterControl; }
            set { m_sMasterControl = value; }
        }

        public string ForNextControl
        {
            get { return m_sForNextControl; }
            set { m_sForNextControl = value; }
        }

        public string CallControl
        {
            get { return m_sCallControl; }
            set { m_sCallControl = value; }
        }

        public CPlcLogic LogicGroup
        {
            get { return m_cILBufferS.Logic; }
        }

        public List<CILBlock> BLOCKS
        {
            get { return m_ListILBlock; }
            set { m_ListILBlock = value; }
        }

        public CILLine ILLine
        {
            get { return m_cILLineCoil; }
            set { m_cILLineCoil = value; }
        }

        public List<CILContact> RelationContactS
        {
            get { return m_ListRelationContact; }
            set { m_ListRelationContact = value; }
        }

        public List<string> lstLoadOperator
        {
            get { return m_lstLoadOperator; }
            set { m_lstLoadOperator = value; }
        }

        public int IndexLoad
        {
            get { return m_iLoad; }
            set {  m_iLoad  =value; }
        }

        public int IndexBlock
        {
            get { return m_iBlock; }
            set { m_iBlock = value; }
        }

        public bool BlockConveted
        {
            get { return m_bBlockConveted; }
            set { m_bBlockConveted = value; }
        }

        public int MergeDepth
        {
            get { return m_iMergeDepth; }
            set { m_iMergeDepth = value; }
        }

        public EMCoilType CoilType
        {
            get { return m_emCoilType; }
            set { m_emCoilType = value; }
        }

        public string DebugInfo
        {
            get
            {
                if (m_cILLineCoil != null)
                    return m_cILLineCoil.ItemAll;
                else
                    return string.Format("Program \"{0}\"", m_sProgramName);
            }
        }
   
        #endregion

        #region public Methods

        public void AddBlock(CILBlock cILBlock)
        {
            m_ListILBlock.Add(cILBlock);
        }

        public void ClearBlock()
        {
            m_ListILBlock.Clear();
        }

        public List<string> GetUsedAddressS()
        {
            List<string> ListsAddress = m_cILLineCoil.GetUsedAddress();

            foreach (CILContact cILContact in m_ListRelationContact)
                foreach (string sAddress in cILContact.UsedAddressS)
                    ListsAddress.Add(sAddress);

            return ListsAddress;
        }

        public List<string> GetUsedContactAddressS()
        {
            List<string> ListsAddress = new List<string>();

            foreach (CILBlock cILBlock in BLOCKS)
                foreach (CILContact cILContact in cILBlock.ILContactS)
                    foreach (string sAddress in cILContact.UsedAddressS)
                        ListsAddress.Add(sAddress);

            return ListsAddress;
        }

        public bool AddBlockCell(CCell cCell)
        {
            m_ListBlockCell.Add(cCell);
            return true;
        }

        public CCell GetBlockCell(int iblockCell)
        {
            return m_ListBlockCell[iblockCell];
        }

        public int GetLastColunm()
        {
            if (m_ListILBlock.Count == 0 || m_ListILBlock[0].ILContactS.Count == 0)
                return -1;

            int nCurValue = m_ListILBlock[0].ILContactS[0].CELL_COL;
            foreach (CILBlock cILBlock in m_ListILBlock)
                foreach (CILContact LP in cILBlock.ILContactS)
                {
                    if (nCurValue < LP.CELL_COL)
                        nCurValue = LP.CELL_COL;
                }

            return nCurValue;
        }

        public int GetLastColunm(int nStartRow, int nEndRow)
        {
            if (m_ListILBlock.Count == 0 || m_ListILBlock[0].ILContactS.Count == 0)
                return -1;

            int nCurValue = 0;
            foreach (CILBlock cILBlock in m_ListILBlock)
                foreach (CILContact LP in cILBlock.ILContactS)
                {
                    if (LP.CELL_ROW < nStartRow || LP.CELL_ROW > nEndRow)
                        continue;

                    if (nCurValue < LP.CELL_COL)
                        nCurValue = LP.CELL_COL;
                }

       
            return nCurValue;
        }

        public int GetLastRow()
        {
            if (m_ListILBlock.Count == 0 || m_ListILBlock[0].ILContactS.Count == 0)
                return -1;

            int nCurValue = m_ListILBlock[0].ILContactS[0].CELL_ROW;
            foreach (CILBlock cILBlock in m_ListILBlock)
                foreach (CILContact LP in cILBlock.ILContactS)
                {
                    if (nCurValue < LP.CELL_ROW)
                        nCurValue = LP.CELL_ROW;
                }

         
            return nCurValue;
        }

        public int GetLastRow(int nStartCol, int nEndCol)
        {
            if (m_ListILBlock.Count == 0 || m_ListILBlock[0].ILContactS.Count == 0)
                return -1;

            int nCurValue = 0;
            foreach (CILBlock cILBlock in m_ListILBlock)
                foreach (CILContact LP in cILBlock.ILContactS)
                {
                    if (LP.CELL_COL < nStartCol || LP.CELL_COL > nEndCol)
                        continue;

                    if (nCurValue < LP.CELL_ROW)
                        nCurValue = LP.CELL_ROW;
                }

            return nCurValue;
        }

        public int GetFirstRow()
        {
            if (m_ListILBlock.Count == 0 || m_ListILBlock[0].ILContactS.Count == 0)
                return -1;

            int nCurValue = m_ListILBlock[0].ILContactS[0].CELL_ROW;
            foreach (CILBlock cILBlock in m_ListILBlock)
                foreach (CILContact LP in cILBlock.ILContactS)
                {
                    if (nCurValue > LP.CELL_ROW)
                        nCurValue = LP.CELL_ROW;
                }


            return nCurValue;
        }

        public int GetBlockIndex(CILContact LogicItem)
        {
            int nBlock = 0;

            foreach (CILBlock cILBlock in m_ListILBlock)
            {
                if (cILBlock.ILContactS.Contains(LogicItem))
                {
                    break;
                }

                nBlock++;
            }

            return nBlock;
        }

        public void RemoveEmptyContactBlock()
        {

            List<CILBlock> ListRemoveBlock = new List<CILBlock>();
            foreach (CILBlock cILBlock in m_ListILBlock)
            {
                if (cILBlock.ILContactS.Count == 0)
                    ListRemoveBlock.Add(cILBlock);
            }

            foreach (CILBlock cILBlock in ListRemoveBlock)
                m_ListILBlock.Remove(cILBlock);
        }


        public int CheckHasContactBlockCount()
        {
            int nValidBlock = 0;

            foreach (CILBlock cILBlock in m_ListILBlock)
            {
                if (cILBlock.ILContactS.Count != 0)
                    nValidBlock++;
            }

            return nValidBlock;
        }



        public void InitializeBuffer()
        {
            m_cILBufferS = new CILBufferS();
        }


        public void CleanBuffer()
        {
            m_cILBufferS.Clear();
        }

        public void ApplyBufferLogic()
        {
            try
            {
                if (CheckHasContactBlockCount() == 1)
                {
                    CILBuffer cILBuffer = new CILBuffer(m_ListILBlock[0].ILContactS);
                    m_cILBufferS.Add(m_cILBufferS.Count, cILBuffer);
                }
                else
                {
                    CPlcLogic cPlcLogic = (CPlcLogic)m_cILBufferS.Logic.Clone();
                    m_cILBufferS.Clear();
                    m_cILBufferS.CreateBufferLogic(m_ListILBlock);
                    m_cILBufferS.Logic = cPlcLogic;
                }

                CreateLink();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] -> ", error.InnerException);
            }
        }

      
        public EMOperaterType GetBlockOperator(List<string> lstOperator, string sStep)
        {
            bool bFind = false;
            int nSkipBlock = 0;
            foreach (string sOperator in lstOperator)
            {
                if (bFind)
                {
                    if (CStringHelper.IsDigitString(sOperator))
                        nSkipBlock++;
                    else if (nSkipBlock <= 0)
                    {
                        if (sOperator == EMOperaterType.And.ToString())
                            return EMOperaterType.And;
                        else
                            return EMOperaterType.Or;
                    }
                    else
                        nSkipBlock--;
                }
                else if (sOperator == sStep)
                    bFind = true;
            }

            return EMOperaterType.And;
        }

        public bool UpdateBlockLogic(string sStep, bool bAndOperator)
        {
            string sSourceA = string.Empty;
            string sSourceB = string.Empty;
            bool bFind = false;
            int iLoad =  0;
            m_lstLoadOperator.Reverse();

            for (int i = 0; i < m_lstLoadOperator.Count; i++)
            {
                if (m_lstLoadOperator[i] == sStep)
                    bFind = true;

                if (!m_lstLoadOperator[i].Contains("LOAD") && !m_lstLoadOperator[i].Contains("MERGE"))
                    continue;

                iLoad = Convert.ToInt16(m_lstLoadOperator[i].Replace("LOAD", string.Empty).Replace("MERGE", string.Empty));
                if (m_ListILBlock[iLoad].ILContactS.Count == 0)
                    continue;

                if (bFind && sSourceB == string.Empty)
                {
                    sSourceB = m_lstLoadOperator[i];
                }
                else if (sSourceA == string.Empty && sSourceB != string.Empty)
                {
                    sSourceA = m_lstLoadOperator[i];
                    break;
                }
            }

            for (int i = 0; i < m_lstLoadOperator.Count; i++)
            {
                if (m_lstLoadOperator[i] == sSourceA)
                    m_lstLoadOperator[i] = string.Empty;
                if (m_lstLoadOperator[i] == sSourceB)
                    m_lstLoadOperator[i] = "MERGE" + sSourceB.Replace("LOAD", string.Empty).Replace("MERGE", string.Empty);
            }

            m_lstLoadOperator.Reverse();

            MergeBlockLogic(sSourceA, sSourceB, bAndOperator);

            return true;
        }


        private bool MergeBlockLogic(string sSourceA, string sSourceB, bool bAndOperator)
        {
            int iSourceA = -1;
            int iSourceB = -1;
            int iMergeCheck = -1;

            if (sSourceA.Contains("LOAD"))
                iSourceA = Convert.ToInt16(sSourceA.Replace("LOAD", string.Empty));
            if (sSourceB.Contains("LOAD"))
                iSourceB = Convert.ToInt16(sSourceB.Replace("LOAD", string.Empty));

            if (iSourceA == -1)
                iMergeCheck = iSourceB;
            else
                iMergeCheck = iSourceA;

            if (iSourceA != -1 && iSourceB != -1)
            {
                if (LogicGroup.GetCount() > 0)
                    LogicGroup.AddWait();

                LogicGroup.AddLogic(iSourceA, iSourceB, bAndOperator);
                m_ListILBlock[iSourceA].Updated = true;
                m_ListILBlock[iSourceB].Updated = true;
            }
            else
            {
                if (LogicGroup.IsMergeLogicBlock(iMergeCheck))
                {
                    LogicGroup.MergeLogicBlock(bAndOperator);
                }
                else
                {
                    if (iSourceA == -1 && iSourceB != -1)
                    {
                        LogicGroup.AddLogicBack(iSourceB, bAndOperator);
                        m_ListILBlock[iSourceB].Updated = true;
                    }
                    else if (iSourceA != -1 && iSourceB == -1)
                    {
                        LogicGroup.AddLogicFront(iSourceA, bAndOperator);
                        m_ListILBlock[iSourceA].Updated = true;
                    }
                }
            }

            return true;

        }

        public bool IsLastBlockMerge(string sStep)
        {
            foreach (CILBlock cILBlock in m_ListILBlock)
            {
                if (sStep == cILBlock.StepNumBlock)
                    if (cILBlock.IsLast)
                        return true;
                    else
                        return false;
            }

            return false;
        }

        #endregion

        #region Privates Methods

        private void CreateLink()
        {
            if (m_cILBufferS == null || m_cILBufferS.Count == 0)
                return;

            m_ListRelationContact = m_cILBufferS.Values.Last().ILContactS;

            foreach (CILContact cILContact in m_ListRelationContact)
            {
                if (cILContact.CELL_COL == 0)
                    cILContact.IsInitial = true;
            }
        }

        private List<CILBlock> FindNextBlock(CILBlock cILBlock)
        {
            List<CILBlock> ListILBlockFinded = new List<CILBlock>();

            int iBlock = 0;

            foreach (CILBlock cILBlockTemp in m_ListILBlock)
            {
                if (cILBlock == cILBlockTemp)
                {
                    if (m_ListILBlock.Count == iBlock)
                        break;
                }

                iBlock++;
            }

            return ListILBlockFinded;
        }

        private CILBlock FindBlockWithContact(CILContact cILContact)
        {
            CILBlock cILBlockFinded = null;
            foreach (CILBlock cILBlock in BLOCKS)
            {
                if (cILBlockFinded != null)
                    break;
                
                foreach (CILContact cILContactTemp in cILBlock.ILContactS)
                {
                    if (cILContactTemp == cILContact)
                    {
                        cILBlockFinded = cILBlock;
                        break;
                    }
                }
            }

            return cILBlockFinded;
        }

        #endregion

    }
}
