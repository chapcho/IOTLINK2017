using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using System.Drawing;

using UDM.UDLImport;

namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDNodeRow : CLDNode
    {
        private int m_nValue = 0;
        private DateTime m_dtTime = DateTime.MinValue;

        private CContent m_cContentSub1 = null;
        private CContent m_cContentSub2 = null;

        private int m_iValue_Sub1 = 0;
        private DateTime m_dtTime_Sub1 = DateTime.MinValue;
        private int m_iValue_Sub2 = 0;
        private DateTime m_dtTime_Sub2 = DateTime.MinValue;

        private EMContactType m_eEILConnect = EMContactType.None;
        private string m_sInstruction = string.Empty;
        private CContact m_cContact = null;
        private List<string> m_lstUsedAddress = new List<string>();
        private string m_sRowFullName = string.Empty;
        private string m_sNoteCompare = string.Empty;
        private string m_sNote = string.Empty;
        private string m_sCommandCompare = string.Empty;
        private string m_sCommand = string.Empty;
        private string m_sOperator = string.Empty;
        private string m_sKey = string.Empty;
        private Color m_color = Color.Transparent;
        private bool m_bLast = false;
        private bool m_bHoldSignal = false;
        private bool m_bCompareRow = false;
        private bool m_bSelectedRow = false;
        private int m_nSortTime = -1;
        //private int m_iPacket = -1;
        //private int m_iCycle = -1;

        #region Initialize/Dispose

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public CLDNodeRow(CContact cContact, CStep cStep)
        {
            m_cContact = cContact;
            m_nValue = 0;
            eILMonitor = EMContactState.Off;

            if (cContact.RefTagS.Count > 0)
            {
                Address = cContact.RefTagS[0].Address;
                Symbol = cContact.RefTagS[0].Description;
            }

            m_eEILConnect = cContact.ContactType;
            m_sInstruction = cContact.Instruction;
            m_sOperator = cContact.Operator;
            m_sKey = GetFirstKey();

            if (cContact.ContactType == EMContactType.Compare)
            {
                m_sCommandCompare = cContact.Instruction.Replace("LD", string.Empty).Replace("OR", string.Empty).Replace("AND", string.Empty);
                foreach (CContent cContent in m_cContact.ContentS)
                {
                    Address = cContent.Argument;

                    if (cContent.Parameter == EMParametorType.S1.ToString())
                    {
                        m_cContentSub1 = cContent;
                    }
                    else if (cContent.Parameter == EMParametorType.S2.ToString())
                    {
                        m_cContentSub2 = cContent;
                    }
                }
            }
            else if (cContact.ContactType == EMContactType.Logical)
            {
                m_sCommand = cContact.Instruction;

                switch (cContact.Instruction)
                {
                    case "INV": Symbol = string.Format("CMD : [ -/- ]"); break;
                    case "MEP": Symbol = string.Format("CMD : [ -↑- ]"); break;
                    case "MEF": Symbol = string.Format("CMD : [ -↓- ]"); break;
                    case "EGP": Symbol = string.Format("CMD : [ -/↑- ]"); break;
                    case "EGF": Symbol = string.Format("CMD : [ -/↓- ]"); break;
                    default :
                        Symbol = string.Format("CMD : [ {0} ]", cContact.Instruction);
                        break;
                }
            }
            m_lstUsedAddress.Add(Address);
        }

        public CLDNodeRow(CTag cTag)
        {
            m_cContact = new CContact();
            m_nValue = 0;
            eILMonitor = EMContactState.Off;

                Address = cTag.Address;
                Symbol = cTag.Description;

            m_lstUsedAddress.Add(Address);
            m_sKey = cTag.Key;
        }

        #endregion

        #region Public interface

        public int Value
        {
            get { return m_nValue; }
            set { m_nValue = value; }
        }

        public DateTime Time
        {
            get { return m_dtTime; }
            set { m_dtTime = value; }
        }

        public string TimeString
        {
            get { return m_dtTime.ToString("HH:mm:ss.fff"); }
        }

        public CContent ContentSub1
        {
            get { return m_cContentSub1; }
            set { m_cContentSub1 = value; }
        }

        public int Value_Sub1
        {
            get { return m_iValue_Sub1; }
            set { m_iValue_Sub1 = value; }
        }

        public DateTime Time_Sub1
        {
            get { return m_dtTime_Sub1; }
            set { m_dtTime_Sub1 = value; }
        }

        public CContent ContentSub2
        {
            get { return m_cContentSub2; }
            set { m_cContentSub2 = value; }
        }

        public int Value_Sub2
        {
            get { return m_iValue_Sub2; }
            set { m_iValue_Sub2 = value; }
        }

        public DateTime Time_Sub2
        {
            get { return m_dtTime_Sub2; }
            set { m_dtTime_Sub2 = value; }
        }

        public string RowFullName
        {
            get { return m_sRowFullName; }
            set { m_sRowFullName = value; }
        }

        public string Key
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public string Note
        {
            get { return m_sNote; }
            set { m_sNote = value; }
        }

        public string NoteCompare
        {
            get { return m_sNoteCompare; }
            set { m_sNoteCompare = value; }
        }

        public string CommandCompare
        {
            get { return m_sCommandCompare; }
            set { m_sCommandCompare = value; }
        }

        public string Operator
        {
            get { return m_sOperator; }
            set { m_sOperator = value; }
        }

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        public EMContactType ContactType
        {
            get { return m_eEILConnect; }
        }

        public string Instruction
        {
            get { return m_sInstruction; }
        }

        public CContact Contact
        {
            get { return m_cContact; }
        }

        public List<string> ListAddress
        {
            get { return m_lstUsedAddress; }
        }

        public Color ColorSubLink
        {
            get { return m_color; }
            set { m_color = value; }
        }

        public string[] ItemArray
        {
            get
            {
                string[] strArray = { Address, Symbol, m_nValue.ToString(), m_eEILConnect.ToString(), "False", "00:00:00" };
                return strArray;
            }
        }

        public bool Last
        {
            get { return m_bLast; }
            set {m_bLast = value; }
        }

        public bool IsHoldSignal
        {
            get { return m_bHoldSignal; }
            set { m_bHoldSignal = value; }
        }

        public bool IsCompareRow
        {
            get { return m_bCompareRow; }
            set { m_bCompareRow = value; }
        }

        public bool IsSelectedRow
        {
            get { return m_bSelectedRow; }
            set { m_bSelectedRow = value; }
        }

        public int SortNumber
        {
            get { return m_nSortTime; }
            set { m_nSortTime = value; }
        }

        //public int Packet
        //{
        //    get { return m_iPacket; }
        //    set { m_iPacket = value; }
        //}

        //public int Cycle
        //{
        //    get { return m_iCycle; }
        //    set { m_iCycle = value; }
        //}
        
        #endregion

        #region Public Method

        public string GetRowText()
        {
            string sRowText = string.Empty;

            if (m_bCompareRow)
                sRowText = GetCompareRowText();
            else
                sRowText = GetNormalRowText();

            return sRowText;
        }

        public void ClearTimeNValue()
        {
            m_nValue = 0;
            m_dtTime = DateTime.MinValue;
            m_iValue_Sub1 = 0;
            m_dtTime_Sub1 = DateTime.MinValue;
            m_iValue_Sub2 = 0;
            m_dtTime_Sub2 = DateTime.MinValue;
        }

        public string GetNormalRowText()
        {
            string sOrder = GetTimeOrder(m_nSortTime);
            string sRowText = string.Empty;

            sRowText = string.Format("<font size=\"+0\"><span width=\"15\">{0}</span><span width=\"55\">{1}</span><span width=\"200\">{2}</span><span width=\"30\">{3}</span><span width=\"15\">{4}</span></font>"
                , sOrder
                , this.Address
                , CLogicHelper.GetSymbolHtml(this.Symbol)
                , this.Value
                , CLogicHelper.GetILConnect(this.Contact.Operator)
              );

            return sRowText;
        }

        public string GetCompareRowText()
        {
            string sRowText = string.Empty;
            string sOrder = string.Empty;
            string sCommand = CLogicHelper.GetSymbolHtml(this.CommandCompare);

            if (m_nSortTime > 0)
                sOrder = m_nSortTime.ToString();

            if (m_color  != Color.Transparent)
                m_color = Color.YellowGreen;

            string sSourceA = this.ContentSub1.Tag != null ? this.ContentSub1.Tag.Description : string.Empty;
            string sSourceB = this.ContentSub2.Tag != null ? this.ContentSub2.Tag.Description : string.Empty;

            sRowText = string.Format("<font size=\"+0\"><span width=\"15\">{0}</span><span width=\"55\">{1}</span><span width=\"200\"><div>({2}) {3}</div><div>({4}) {5}</div></span><span width=\"30\">{6}</span><span width=\"15\">{7}</span></font>"
                           , sOrder
                           , sCommand
                           , this.Value_Sub1, sSourceA
                           , this.Value_Sub2, sSourceB
                           , this.Value == 0 ? "F" : "T"
                           , CLogicHelper.GetILConnect(this.Contact.Operator)
                         );


            return sRowText;
        }

        private string GetFirstKey()
        {
            string sKey = string.Empty;

            foreach (CContent cContent in m_cContact.ContentS)
            {
                if (cContent.Parameter == EMParametorType.D1.ToString())
                {
                    if (cContent.ArgumentType == EMArgumentType.Tag)
                    {
                        if (cContent.Tag != null)
                            sKey = cContent.Tag.Key;
                        else
                            sKey = cContent.Argument;
                    }
                    break;
                }
            }

            return sKey;
        }

        #endregion

        #region Private Method

        private string GetTimeOrder(int nSort)
        {
            string sOrder = nSort.ToString();
            if (nSort == (int)EMSortNumber.SPECIAL)
                sOrder = string.Empty;
            else if (nSort == (int)EMSortNumber.COLLECT_SKIP)
                sOrder = string.Empty;//"NC";
            else if (nSort == (int)EMSortNumber.EMPTY)
                sOrder = string.Empty;// "NC";
            else if (nSort == (int)EMSortNumber.ONCE)
                sOrder = "H";

            return sOrder;
        }
           
        //private void SetMultiAddressProperty(CILContact cILContact)
        //{
        //    if( cILContact.Address.StartsWith("K") ||  cILContact.Address.StartsWith("H"))
        //        Address = cILContact.Address.Split(';')[1];
        //}
        
        #endregion

    }
}