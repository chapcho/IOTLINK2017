using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.ILConverter;

namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDGroup : CLDItem
    {
        private List<CLDRow> m_ListILNodeRow = new List<CLDRow>();
        private bool bOr = false;
        private bool bMix = false;
        private bool m_bDeadCoil = false;

        #region Initialize/Dispose

        public CLDGroup(List<CILContact> ListLogic)
        {
            if (ListLogic.Count > 0)
            {
                Address = ListLogic[0].Address;
                Symbol = ListLogic[0].Symbol;

                GenerationNodeRow(ListLogic);
            }
        }

        public CLDGroup(List<CLDRow> ListILNodeRow)
        {
            m_ListILNodeRow = ListILNodeRow;

            if (ListILNodeRow.Count > 0)
            {
                Address = ListILNodeRow[0].Address;
                Symbol = ListILNodeRow[0].Symbol;
            }
        }

        public override void Dispose()
        {
            m_ListILNodeRow.Clear();
        }

        #endregion

        #region Public interface

        public List<CLDRow> ListILNodeRow
        {
            get { return m_ListILNodeRow; }
        }

        public bool OR_DIAGRAM
        {
            get { return bOr; }
            set { bOr = value; }
        }

        public bool IsMixDiagram
        {
            get { return bMix; }
            set { bMix = value; }
        }

        public bool IsDeadCoil
        {
            get { return m_bDeadCoil; }
            set { m_bDeadCoil = value; }
        }

        
        #endregion

        #region Public Method

        public void AddRow(CLDRow CLDRow)
        {
            ListILNodeRow.Add(CLDRow);
        }

        public bool IsExistNodeRow(CLDRow CLDRow)
        {
            if (FindILNodeRow(CLDRow) == null)
                return false;
            else
                return true;
        }

        public bool RemoveNodeRow(CLDRow CLDRow)
        {
            CLDRow CLDRowFinded = FindILNodeRow(CLDRow);

            if (CLDRowFinded == null)
                return false;
            else
            {
                m_ListILNodeRow.Remove(CLDRowFinded);
                return true;
            }
        }

        public Dictionary<string, string> GetUsedAddressNSymbol(CTagS cTagS)
        {
            Dictionary<string, string> DicNodeAddress = new Dictionary<string, string>();

            foreach (CLDRow CLDRow in this.ListILNodeRow)
            {
                AddUsedAddressNSymbolKey(DicNodeAddress, CLDRow.Address, cTagS);
                AddUsedAddressNSymbolKey(DicNodeAddress, CLDRow.ILContact.ILLine.Source, cTagS);
                AddUsedAddressNSymbolKey(DicNodeAddress, CLDRow.ILContact.ILLine.Source_Sub1, cTagS);
                AddUsedAddressNSymbolKey(DicNodeAddress, CLDRow.ILContact.ILLine.Source_Sub2, cTagS);
                AddUsedAddressNSymbolKey(DicNodeAddress, CLDRow.ILContact.ILLine.Source_Sub3, cTagS);
            }

            return DicNodeAddress;

        }
            
        #endregion

        #region Private Method

        private void AddUsedAddressNSymbolKey(Dictionary<string, string> DicNodeAddress, string sKey, CTagS cTagS)
        {
            if (sKey == string.Empty)
                return;
            
            if (cTagS.ContainsKey(CPlc.DefaultPath + sKey))
            {
                if (!DicNodeAddress.ContainsKey(sKey))
                    DicNodeAddress.Add(sKey, sKey + " : " + cTagS[CPlc.DefaultPath + sKey].Description);
            }
        }

        private void GenerationNodeRow(List<CILContact> ListLP)
        {
            foreach (CILContact LP in ListLP)
            {
                CLDRow ILNodeRow = new CLDRow((CILContact)LP.Clone());

                m_ListILNodeRow.Add(ILNodeRow);
            }
        }

        private CLDRow FindILNodeRow(CLDRow CLDRowORG)
        {
            CLDRow CLDRowFind = m_ListILNodeRow.Find(delegate(CLDRow CLDRow)
            {
                return CLDRow.Address == CLDRowORG.Address 
                    && CLDRow.ILContact.CELL_ROW == CLDRowORG.ILContact.CELL_ROW
                    && CLDRow.ILContact.CELL_COL == CLDRowORG.ILContact.CELL_COL
                    && CLDRow.eILConnect == CLDRowORG.eILConnect;
            });

            return CLDRowFind;
        }

        #endregion
    }


}