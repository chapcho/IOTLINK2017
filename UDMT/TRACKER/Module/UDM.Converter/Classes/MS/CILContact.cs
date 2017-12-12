using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.Converter
{
    [Serializable]
    public class CILContact : ICloneable
    {
        private string m_sAddress = string.Empty;
        private string m_sCommand = string.Empty;
        private string m_sRoutine = string.Empty;
        private string m_sSymbol = string.Empty;
        private List<string> m_ListUsedAddress = new List<string>();
        private List<int> m_ListRelationNum = new List<int>();
        private int m_ContactNum = -1;
        private int m_nMergeDepth = 0;

        private CILLine m_cILLine = null;
        private CCell m_CELL = new CCell(0, 0);
        private bool m_bLoad = false;
        private bool m_bInitial = false;
        private bool m_bUsingDiagram = false;
        
        public EILType eILType = EILType.CONNECT;
        public EMContactType eILConnenct = EMContactType.None;
        public EMContactTypeBit emContactTypeBit = EMContactTypeBit.None;
        public EILCoil eILCoil = EILCoil.NORMAL;
        public EMOperaterType eILOperator = EMOperaterType.None;

        #region Initialize/Dispose

        public object Clone()
        {
            CILContact cClone = (CILContact)this.MemberwiseClone();

            cClone.m_ListUsedAddress = new List<string>();
            cClone.m_ListRelationNum = new List<int>();

            foreach (string str in this.m_ListUsedAddress)
                cClone.m_ListUsedAddress.Add(str);

            foreach (int iRelation in this.m_ListRelationNum)
                cClone.m_ListRelationNum.Add(iRelation);

            return cClone;
        }


        public CILContact(CILLine ILLine)
        {
            m_cILLine = ILLine;

            if (CILType.IsContactIL(ILLine.Command))
                eILType = EILType.CONNECT;
            else if (CILType.IsConnenctionOperationIL(ILLine.Command))
                eILType = EILType.CONNECT_OPERATION;
            else if (CILType.IsRoutineControlIL(ILLine.Command))
                eILType = EILType.ROUTINE;
            else
                eILType = EILType.COIL;

            SetProperty();

            m_ListUsedAddress = ILLine.GetUsedAddress();


            //demo ahn

//             if (m_sAddress == string.Empty)
//             {
//                 foreach (string sAddress in m_ListUsedAddress)
//                 {
//                     if (CPlcMelsec.IsAddress(sAddress))
//                     {
//                         m_sAddress = sAddress;
//                         break;
//                     }
//                 }
//             }

            m_sAddress = m_sAddress.ToUpper();
        }



        public void ClearIlne()
        {
            m_cILLine = null;
        }


        public void Dispose()
        {
        }

        #endregion

        #region Public interface

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Symbol
        {
            get { return m_sSymbol; }
            set { m_sSymbol = value; }
        }

        public string Command
        {
            get { return m_sCommand; }
        }

        public string CommandFull
        {
            get { return m_cILLine.CommandFull; }
        }

        public string SpceialParameter
        {
            get { return m_cILLine.SpecialParameter; }
        }

        public string Routine
        {
            get { return m_sRoutine; }
        }

        public bool IsLaod
        {
            get { return m_bLoad; }
        }

        public bool IsInitial
        {
            get { return m_bInitial; }
            set { m_bInitial = value; }
        }

        public bool IsUsingDiagram
        {
            get { return m_bUsingDiagram; }
            set { m_bUsingDiagram = value; }
        }

        public int CELL_COL
        {
            get { return m_CELL.COL; }
            set { m_CELL.COL = value; }
        }

        public int CELL_ROW
        {
            get { return m_CELL.ROW; }
            set { m_CELL.ROW = value; }
        }

        public CCell CELL
        {
            get { return m_CELL; }
            set { m_CELL = value; }
        }

        public CILLine ILLine
        {
            get { return m_cILLine; }
        }

        public List<string> UsedAddressS
        {
            get { return m_ListUsedAddress; }
        }

        public List<int> RelationS
        {
            get { return m_ListRelationNum; }
        }

        public int ContactNum
        {
            get { return m_ContactNum; }
            set { m_ContactNum = value; }
        }

        public int MergeDepth
        {
            get { return m_nMergeDepth; }
            set { m_nMergeDepth = value; }
        }

        #endregion

        #region Privates Methods

        private void SetProperty()
        {
            if (eILType == EILType.CONNECT)
            {
                SetConnect();
            }
            else if (eILType == EILType.COIL)
            {
                SetCoil();
            }
            else if (eILType == EILType.CONNECT_OPERATION)
            {
                SetConnectOperation();
            }
            else if (eILType == EILType.ROUTINE)
            {
                SetRoutine();
            }
        }

    
        private void SetConnect()
        {
            m_sCommand = m_cILLine.Command;
            if (m_sCommand.EndsWith("I"))
            {
                eILConnenct = EMContactType.Bit;
                emContactTypeBit = EMContactTypeBit.Close;
            }
            else
            {
                eILConnenct = EMContactType.Bit;
                emContactTypeBit = EMContactTypeBit.Open;
            }

            if (m_sCommand.EndsWith("P") || m_sCommand.EndsWith("PI"))
            {
                if (emContactTypeBit == EMContactTypeBit.Close)
                    emContactTypeBit = EMContactTypeBit.PulseOnClose;
                else if (emContactTypeBit == EMContactTypeBit.Open)
                    emContactTypeBit = EMContactTypeBit.PulseOnOpen;
            }
            else if (m_sCommand.EndsWith("F") || m_sCommand.EndsWith("FI"))
            {
                if (emContactTypeBit == EMContactTypeBit.Close)
                    emContactTypeBit = EMContactTypeBit.PulseOffClose;
                else if (emContactTypeBit == EMContactTypeBit.Open)
                    emContactTypeBit = EMContactTypeBit.PulseOffOpen;
            }

            if (m_sCommand.Contains("OR"))
                eILOperator = EMOperaterType.Or;
            else
                eILOperator = EMOperaterType.And;

            if (m_sCommand.Contains("LD"))
                m_bLoad = true;

            if (CILType.IsCompareCommand(m_cILLine.Command))
            {
                eILConnenct = EMContactType.Compare;   //paju
                m_sAddress = string.Empty;
            }
            else
                m_sAddress = m_cILLine.Destination;
        }

        private void SetConnectOperation()
        {
            m_sAddress = m_cILLine.Destination;
            m_sCommand = m_cILLine.Command;
            eILConnenct = EMContactType.Logical;   //paju
        }

        private void SetCoil()
        {
            m_sAddress = m_cILLine.Destination;
            m_sCommand = m_cILLine.Command;

            if (m_sCommand == "SET")
                eILCoil = EILCoil.SET;
            if (m_sCommand == "RST")
                eILCoil = EILCoil.RESET;
        }

        private void SetRoutine()
        {
            m_sRoutine = m_cILLine.Numeric;
            m_sAddress = m_cILLine.Destination;
            m_sCommand = m_cILLine.Command;
        }


        #endregion
    }
}
