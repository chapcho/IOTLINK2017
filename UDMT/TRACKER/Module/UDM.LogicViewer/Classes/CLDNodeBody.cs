using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using UDM.Common;
using UDM.UDLImport;

namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDNodeBody : CLDNode
    {
        private List<CLDNodeRow> m_ListILNodeRow = new List<CLDNodeRow>();
        private bool bOr = false;
        private bool bMix = false;
        private bool m_bDeadCoil = false;
        

        #region Initialize/Dispose

        public CLDNodeBody(List<CLDNodeRow> ListILNodeRow)
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

        public List<CLDNodeRow> ListILNodeRow
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

        public void AddRow(CLDNodeRow cILNodeRow)
        {
            ListILNodeRow.Add(cILNodeRow);
        }

        public Dictionary<string, string> GetUsedAddressNSymbol(CTagS cTagS)
        {
            Dictionary<string, string> DicNodeAddress = new Dictionary<string, string>();

            foreach (CLDNodeRow cILNodeRow in this.ListILNodeRow)
            {
                AddUsedAddressNSymbolKey(DicNodeAddress, cILNodeRow.Contact, cTagS);
            }

            return DicNodeAddress;

        }
            
        #endregion

        #region Private Method

        private void AddUsedAddressNSymbolKey(Dictionary<string, string> DicNodeAddress, CContact cContact, CTagS cTagS)
        {
            if (cContact == null)
                return;

            foreach (CContent cContent in cContact.ContentS)
            {
                if (cContent.ArgumentType == EMArgumentType.Tag)
                {
                    if (cContent.Tag != null)
                    {
                        if (!DicNodeAddress.ContainsKey(cContent.Tag.Key))
                            DicNodeAddress.Add(cContent.Tag.Key, cContent.Tag.Description);
                    }
                    else
                        DicNodeAddress.Add(cContent.Argument, "");
                }
            }
        }



        #endregion
    }


}