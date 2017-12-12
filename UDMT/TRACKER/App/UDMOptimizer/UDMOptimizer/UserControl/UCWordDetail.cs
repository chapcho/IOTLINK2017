using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;

namespace UDMOptimizer
{
    public delegate void UEventHandlerSelectBitS(object sender, int iIndex, string sWordName, List<int> lstSelectBit);

    public partial class UCWordDetail : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        protected int m_iIndex = -1;
        protected Size m_Board32BitSize = new Size(578, 146);
        protected Size m_Board16BitSize = new Size(578, 92);
        protected UInt32 m_uiWordData = 0;
        protected Dictionary<int, bool> m_dicWordCheck = new Dictionary<int, bool>();
        protected EMBitSizeType m_emBitSizeType = EMBitSizeType.Bit_16;
        public UEventHandlerSelectBitS UEventSelectBits;

        #endregion


        #region Initialize

        public UCWordDetail()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public EMBitSizeType BitSizeType
        {
            set
            {
                m_emBitSizeType = value;
                if (value == EMBitSizeType.Bit_32)
                {
                    this.Size = m_Board32BitSize;
                    pnlHighBit.Visible = true;
                }
                else
                {
                    this.Size = m_Board16BitSize;
                    pnlHighBit.Visible = false;
                    if (value == EMBitSizeType.Bit_8)
                    {

                    }
                }

                this.Refresh();
            }
        }

        /// <summary>
        /// 화면을 초기화 시키는 구문 포함됨.
        /// </summary>
        public UInt32 WordMaskValue
        {
            set 
            { 
                m_uiWordData = value;

                InitialData();

                this.Refresh();
            }
        }

        public string WordName
        {
            get { return grpMain.Text; }
            set { grpMain.Text = value; }
        }

        public int WordIndex
        {
            get { return m_iIndex; }
            set { m_iIndex = value; }
        }

        #endregion


        #region Private Method

        private void InitialData()
        {
            UInt32 iCount = 16;
            if (m_emBitSizeType == EMBitSizeType.Bit_32)
                iCount = 32;
            
            for (int i = 0; i < iCount; i++)
            {
                int iVal = 0x1 << i;
                UInt32 iCheckVal = m_uiWordData & (UInt32)iVal;

                Control[] acControl = this.Controls.Find("chkWordBit" + i.ToString(), true);
                if (acControl.Length > 0 && acControl[0].GetType() == typeof(CheckButton))
                {
                    CheckButton chkBit = (CheckButton)acControl[0];
                    if (m_emBitSizeType == EMBitSizeType.Bit_8 && i >= 8)
                    {
                        chkBit.Enabled = false;
                        chkBit.ImageIndex = 0;
                        continue;
                    }
                    if (iCheckVal > 0)
                    {
                        chkBit.Enabled = false;
                        chkBit.ImageIndex = 1;
                    }
                    else
                    {
                        m_dicWordCheck.Add(i, false);
                        chkBit.Enabled = true;
                        chkBit.ImageIndex = -1;
                    }
                    chkBit.Refresh();
                }
            }
        }

        private void ChangeSelectedBits(List<int> lstSelected)
        {
            for (int i = 0; i < lstSelected.Count; i++)
            {
                Control[] acControl = this.Controls.Find("chkWordBit" + lstSelected[i].ToString(), true);
                if (acControl.Length > 0 && acControl[0].GetType() == typeof(CheckButton))
                {
                    CheckButton chkBit = (CheckButton)acControl[0];
                    chkBit.Enabled = false;
                    chkBit.ImageIndex = 1;
                }
            }
        }

        private void RemoveItem(List<int> lstSelected)
        {
            for (int i = 0; i < lstSelected.Count; i++)
            {
                if (m_dicWordCheck.ContainsKey(lstSelected[i]))
                {
                    m_dicWordCheck.Remove(lstSelected[i]);
                }
            }
        }

        #endregion


        #region Public Method

        public void SetPosColor(UInt32 uiMask)
        {
            UInt32 iCount = 16;
            if (m_emBitSizeType == EMBitSizeType.Bit_32)
                iCount = 32;

            for (int i = 0; i < iCount; i++)
            {
                int iVal = 0x1 << i;
                UInt32 iCheckVal = uiMask & (UInt32)iVal;

                Control[] acControl = this.Controls.Find("chkWordBit" + i.ToString(), true);
                if (acControl.Length > 0 && acControl[0].GetType() == typeof(CheckButton))
                {
                    CheckButton chkBit = (CheckButton)acControl[0];
                    if (iCheckVal > 0)
                        chkBit.Appearance.BackColor = Color.Pink;
                    else
                        chkBit.Appearance.BackColor = Color.White;
                }
            }
        }

        public void CompleteView(List<int> lstSelected)
        {
            ChangeSelectedBits(lstSelected);
            RemoveItem(lstSelected);
            btnApply.Enabled = false;
        }

        #endregion


        private void btnApply_Click(object sender, EventArgs e)
        {
            //Event발생
            if (UEventSelectBits != null)
            {
                List<int> lstSelected = new List<int>();
                foreach (var who in m_dicWordCheck)
                {
                    if (who.Value == true)
                        lstSelected.Add(who.Key);
                }
                if (lstSelected.Count > 0)
                {
                    UEventSelectBits(this, m_iIndex, WordName, lstSelected);
                }
            }
        }

        private void chkWordBit0_CheckedChanged(object sender, EventArgs e)
        {
            CheckButton chk = (CheckButton)sender;
            if (chk.Checked)
                chk.ImageIndex = 2;
            else
                chk.ImageIndex = -1;
            int iBitPos = -1;
            bool bOK = int.TryParse((string)chk.Tag, out iBitPos);
            if (bOK && m_dicWordCheck.ContainsKey(iBitPos))
            {
                m_dicWordCheck[iBitPos] = chk.Checked;
            }
            int iCount = m_dicWordCheck.Values.Where(b => b == true).Count();
            if (iCount > 0)
                btnApply.Enabled = true;
            else
                btnApply.Enabled = false;
        }
    }
}
