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
    public class CLDRow : CLDItem
    {
        private string m_sAddress = string.Empty;
        private string m_sValue = string.Empty;
        private DateTime m_dtTime = DateTime.MinValue;
        private string m_sValue_Sub1 = string.Empty;
        private DateTime m_dtTime_Sub1 = DateTime.MinValue;
        private string m_sValue_Sub2 = string.Empty;
        private DateTime m_dtTime_Sub2 = DateTime.MinValue;

        private EMContactType m_eEILConnect = EMContactType.Open;
        private CILContact m_cILContact = null;
        private string m_sRowFullName = string.Empty;
        private Color m_color = Color.Transparent;
        private bool m_bLast = false;
        private bool m_bHoldSignal = false;
        private bool m_bCompareRow = false;
        private bool m_bSelectedRow = false;
        private int m_nSortTime = -1;

        #region Initialize/Dispose

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public CLDRow(CILContact cLogicPoint)
        {
            m_cILContact = cLogicPoint;
            m_sValue = "0";
            Monitor = EMMonitor.OFF;

            if (cLogicPoint.Address != string.Empty)
            {
                if (cLogicPoint.Address.Contains(";"))
                    SetMultiAddressProperty(cLogicPoint);
                else
                {
                    Address = cLogicPoint.Address;
                    Symbol = cLogicPoint.Symbol;
                }
            }
            else
                SetCommadProperty(cLogicPoint);


            m_eEILConnect = cLogicPoint.eILConnenct;
        }


        #endregion

        #region Public interface

        public string Value
        {
            get { return m_sValue; }
            set { m_sValue = value; }
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

        public string Value_Sub1
        {
            get { return m_sValue_Sub1; }
            set { m_sValue_Sub1 = value; }
        }

        public DateTime Time_Sub1
        {
            get { return m_dtTime_Sub1; }
            set { m_dtTime_Sub1 = value; }
        }

        public string Value_Sub2
        {
            get { return m_sValue_Sub2; }
            set { m_sValue_Sub2 = value; }
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

        public EMContactType eILConnect
        {
            get { return m_eEILConnect; }
        }

        public CILContact ILContact
        {
            get { return m_cILContact; }
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
                string[] strArray = { Address, Symbol, Value, m_eEILConnect.ToString(), "False", "00:00:00" };
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
        
        #endregion

        #region Public Method

      

        #endregion

        #region Private Method

        private void SetCommadProperty(CILContact cILContact)
        {
            if(cILContact.eILType == EILType.CONNECT)
            {
                string strCompareOnly = cILContact.Command.Replace("LD", string.Empty).Replace("OR", string.Empty).Replace("AND", string.Empty);

                Symbol = string.Format("Command : [ {0} {1} {2} ]", cILContact.ILLine.Source, strCompareOnly, cILContact.ILLine.Source_Sub1);
            }
            else
                Symbol = string.Format("Command : [ {0} ]", cILContact.ILLine.Command);

        }

        private void SetMultiAddressProperty(CILContact cILContact)
        {
            if( cILContact.Address.StartsWith("K") ||  cILContact.Address.StartsWith("H"))
                Address = cILContact.Address.Split(';')[1];
        }
        
        #endregion

    }
}