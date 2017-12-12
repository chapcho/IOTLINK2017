using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMIOMaker
{
    public delegate void UEventHandlerNameEdit(string sDescription);

    public partial class FrmSymbolNameEdit : DevExpress.XtraEditors.XtraForm
    {
        private CParseView m_cParseView = null;
        private bool m_bLoad = false;
        private bool m_bStandardization = false;
        private bool m_bEdit = false;

        public UEventHandlerNameEdit UEventNameEdit = null;

        public bool IsLoad
        {
            get { return m_bLoad; }
            set { m_bLoad = value; }
        }

        public FrmSymbolNameEdit()
        {
            InitializeComponent();
        }

        public void SetParseView(List<string> lstParse )
        {
            int iLevelCount = lstParse.Count;

            m_cParseView = null;
            m_bStandardization = false;
            m_bEdit = false;
            InitLevelNumber();
            InitRowColor();
            CheckLevelNumber(iLevelCount);

            if (iLevelCount > 12)
                iLevelCount = 12;

            m_cParseView = new CParseView();

            foreach (var who in m_cParseView.lstLevel)
                who.IsCurrentView = true;

            CLevel cLv = null;
            for (int i = 0; i < iLevelCount; i++)
            {
                cLv = m_cParseView.GetLevel(i + 1);
                cLv.CurrentParse = lstParse[i];
            }

            exNameProperty.SelectedObject = m_cParseView;
        }

        private void CheckLevelNumber(int iLevelCount)
        {
            if (iLevelCount == 8)
                rowLv8.Visible = true;
            else if (iLevelCount == 9)
            {
                rowLv8.Visible = true;
                rowLv9.Visible = true;
            }
            else if (iLevelCount == 10)
            {
                rowLv8.Visible = true;
                rowLv9.Visible = true;
                rowLv10.Visible = true;
            }
            else if (iLevelCount == 11)
            {
                rowLv8.Visible = true;
                rowLv9.Visible = true;
                rowLv10.Visible = true;
                rowLv11.Visible = true;
            }
            else if (iLevelCount == 12)
            {
                rowLv8.Visible = true;
                rowLv9.Visible = true;
                rowLv10.Visible = true;
                rowLv11.Visible = true;
                rowLv12.Visible = true;
            }
        }

        private void InitLevelNumber()
        {
            rowLv8.Visible = false;
            rowLv9.Visible = false;
            rowLv10.Visible = false;
            rowLv11.Visible = false;
            rowLv12.Visible = false;
        }

        private void InitRowColor()
        {
            rowLv1.Appearance.BackColor = Color.Transparent;
            rowLv2.Appearance.BackColor = Color.Transparent;
            rowLv3.Appearance.BackColor = Color.Transparent;
            rowLv4.Appearance.BackColor = Color.Transparent;
            rowLv5.Appearance.BackColor = Color.Transparent;
            rowLv6.Appearance.BackColor = Color.Transparent;
            rowLv7.Appearance.BackColor = Color.Transparent;
            rowLv8.Appearance.BackColor = Color.Transparent;
            rowLv9.Appearance.BackColor = Color.Transparent;
            rowLv10.Appearance.BackColor = Color.Transparent;
            rowLv11.Appearance.BackColor = Color.Transparent;
            rowLv12.Appearance.BackColor = Color.Transparent;
        }

        private void Standardization()
        {
            if (m_cParseView == null)
                return;

            CLevel cLv;
            for (int i = 0; i < m_cParseView.lstLevel.Count; i++)
            {
                cLv = m_cParseView.GetLevel(i + 1);

                if (CheckStdLibrary(cLv))
                    cLv.IsStdExist = true;
                else
                    cLv.IsStdExist = false;

                if (cLv.TargetParse != string.Empty)
                    cLv.IsCurrentView = false;
                else
                    cLv.IsCurrentView = true;

                SetRowCellColor(i + 1);
            }

            exNameProperty.Refresh();
        }

        private void SetRowCellColor(int iLevelIndex)
        {
            CLevel cLv = m_cParseView.GetLevel(iLevelIndex);

            switch (iLevelIndex)
            {
                case 1:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv1.Appearance.BackColor = Color.Orange;
                        else
                            rowLv1.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if(!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv1.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv1.Appearance.BackColor = Color.White;
                    break;
                case 2:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv2.Appearance.BackColor = Color.Orange;
                        else
                            rowLv2.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv2.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv2.Appearance.BackColor = Color.White;
                    break;
                case 3:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv3.Appearance.BackColor = Color.Orange;
                        else
                            rowLv3.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv3.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv3.Appearance.BackColor = Color.White;
                    break;
                case 4:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv4.Appearance.BackColor = Color.Orange;
                        else
                            rowLv4.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv4.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv4.Appearance.BackColor = Color.White;
                    break;
                case 5:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv5.Appearance.BackColor = Color.Orange;
                        else
                            rowLv5.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv5.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv5.Appearance.BackColor = Color.White;
                    break;
                case 6:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv6.Appearance.BackColor = Color.Orange;
                        else
                            rowLv6.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv6.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv6.Appearance.BackColor = Color.White;
                    break;
                case 7:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv7.Appearance.BackColor = Color.Orange;
                        else
                            rowLv7.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv7.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv7.Appearance.BackColor = Color.White;
                    break;
                case 8:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv8.Appearance.BackColor = Color.Orange;
                        else
                            rowLv8.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv8.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv8.Appearance.BackColor = Color.White;
                    break;
                case 9:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv9.Appearance.BackColor = Color.Orange;
                        else
                            rowLv9.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv9.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv9.Appearance.BackColor = Color.White;
                    break;
                case 10:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv10.Appearance.BackColor = Color.Orange;
                        else
                            rowLv10.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv10.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv10.Appearance.BackColor = Color.White;
                    break;
                case 11:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv11.Appearance.BackColor = Color.Orange;
                        else
                            rowLv11.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv11.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv11.Appearance.BackColor = Color.White;
                    break;
                case 12:
                    if (cLv.IsStdExist)
                    {
                        if (cLv.IsChanged)
                            rowLv12.Appearance.BackColor = Color.Orange;
                        else
                            rowLv12.Appearance.BackColor = Color.PaleGreen;
                    }
                    else if (!cLv.IsStdExist && cLv.CurrentParse != string.Empty)
                        rowLv12.Appearance.BackColor = Color.Salmon;
                    else if (cLv.CurrentParse == string.Empty)
                        rowLv12.Appearance.BackColor = Color.White;
                    break;
            }

        }

        private bool SetDescParseContainBracket(string sConvertCurrent, CLevel cLv)
        {
            bool bOK = false;

            string sConvertHeader = sConvertCurrent.Split('[')[0];

            string sConvertTail = sConvertCurrent.Split('[')[1].Replace("]", string.Empty);

            if (sConvertHeader == string.Empty)
                return false;

            if (CProjectManager.StdS.ContainsKey(sConvertHeader))
            {
                string sTarget = CProjectManager.StdS[sConvertHeader].TargetName;

                if (sTarget == sConvertHeader)
                    cLv.IsChanged = false;
                else
                {
                    cLv.IsChanged = true;
                    cLv.TargetParse = string.Format("{0}[{1}]", sTarget, sConvertTail);
                }

                bOK = true;
            }
            else if (Regex.IsMatch(sConvertHeader, "[0-9]"))
            {
                if (SetDescParseContainNumber(sConvertHeader, cLv))
                    bOK = true;
                else
                    bOK = false;
            }

            return bOK;
        }

        private bool SetDescParseContainNumber(string sConvertCurrent, CLevel cLv)
        {
            bool bOK = false;

            if (sConvertCurrent == string.Empty)
                return false;

            string sValueExceptNumeric = Regex.Replace(sConvertCurrent, "[0-9]", " ");
            string[] arrValue = sValueExceptNumeric.Split(' ');

            foreach (string sValue in arrValue)
            {
                if (sValue == string.Empty)
                    continue;

                if (CProjectManager.StdS.ContainsKey(sValue))
                {
                    bOK = true;

                    string sTarget = CProjectManager.StdS[sValue].TargetName;

                    if (sValue == sTarget)
                        cLv.IsChanged = false;
                    else
                    {
                        cLv.IsChanged = true;
                        cLv.TargetParse = sConvertCurrent.Replace(sValue, sTarget);
                    }
                }
            }

            return bOK;
        }

        private bool CheckStdLibrary(CLevel cLv)
        {
            bool bOK = false;
            string sConvertCurrent = cLv.CurrentParse.ToUpper();

            if (sConvertCurrent.Contains("["))
            {
                if (SetDescParseContainBracket(sConvertCurrent, cLv))
                    bOK = true;
                else
                    bOK = false;
            }
            else if (Regex.IsMatch(sConvertCurrent, "[0-9]"))
            {
                if (SetDescParseContainNumber(sConvertCurrent, cLv))
                    bOK = true;
                else
                    bOK = false;
            }
            else if (CProjectManager.StdS.ContainsKey(sConvertCurrent))
            {
                bOK = true;

                string sTarget = CProjectManager.StdS[sConvertCurrent].TargetName;

                if (sTarget == sConvertCurrent)
                    cLv.IsChanged = false;
                else
                {
                    cLv.IsChanged = true;
                    cLv.TargetParse = sTarget;
                }
            }
            //else if (CheckDescriptionContainLibrary(sConvertCurrent, cLv))
            //    bOK = true;
            else
                bOK = false;

            return bOK;
        }

        private void btnLevelAdd_Click(object sender, EventArgs e)
        {
            if (rowLv8.Visible == false)
                rowLv8.Visible = true;
            else if (rowLv9.Visible == false)
                rowLv9.Visible = true;
            else if (rowLv10.Visible == false)
                rowLv10.Visible = true;
            else if (rowLv11.Visible == false)
                rowLv11.Visible = true;
            else if (rowLv12.Visible == false)
                rowLv12.Visible = true;
            else
            {
                XtraMessageBox.Show("더이상 Level을 추가할 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnStdLView_Click(object sender, EventArgs e)
        {
            FrmStdSetting frmStd = new FrmStdSetting();
            frmStd.TopMost = true;
            frmStd.Show();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (m_cParseView == null)
            {
                XtraMessageBox.Show("한 개 이상의 PLC 심볼을 선택해주세요.", "Apply Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_bEdit)
            {
                if (
                    XtraMessageBox.Show("해당 심볼 이름을 적용하시겠습니까?", "Question", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) ==
                    DialogResult.Yes)
                {
                    if (UEventNameEdit != null)
                        UEventNameEdit(m_cParseView.GetDescription());
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmSymbolNameEdit_Load(object sender, EventArgs e)
        {
            exNameProperty.SelectedObject = m_cParseView;
            exNameProperty.Refresh();

            m_bLoad = true;
        }

        private void FrmSymbolNameEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bLoad = false;
        }

        private void exNameProperty_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            try
            {
                m_bEdit = true;

                if (!m_bStandardization)
                    return;

                Standardization();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("NameEdit CellValueChanged Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnStandardization_Click(object sender, EventArgs e)
        {
            try
            {
                Standardization();

                m_bStandardization = true;
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("NameEdit Standardization Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void FrmSymbolNameEdit_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void FrmSymbolNameEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            m_bLoad = false;
        }
    }

    public class CParseView
    {
        private CLevel m_cLv1 = new CLevel();
        private CLevel m_cLv2 = new CLevel();
        private CLevel m_cLv3 = new CLevel();
        private CLevel m_cLv4 = new CLevel();
        private CLevel m_cLv5 = new CLevel();
        private CLevel m_cLv6 = new CLevel();
        private CLevel m_cLv7 = new CLevel();
        private CLevel m_cLv8 = new CLevel();
        private CLevel m_cLv9 = new CLevel();
        private CLevel m_cLv10 = new CLevel();
        private CLevel m_cLv11 = new CLevel();
        private CLevel m_cLv12 = new CLevel();

        private List<CLevel> m_lstLevel = new List<CLevel>();

        #region Properties

        public CParseView()
        {
            m_lstLevel.Add(m_cLv1);
            m_lstLevel.Add(m_cLv2);
            m_lstLevel.Add(m_cLv3);
            m_lstLevel.Add(m_cLv4);
            m_lstLevel.Add(m_cLv5);
            m_lstLevel.Add(m_cLv6);
            m_lstLevel.Add(m_cLv7);
            m_lstLevel.Add(m_cLv8);
            m_lstLevel.Add(m_cLv9);
            m_lstLevel.Add(m_cLv10);
            m_lstLevel.Add(m_cLv11);
            m_lstLevel.Add(m_cLv12);
        }

        public List<CLevel> lstLevel
        {
            get { return m_lstLevel;}
        }

        public CLevel Lv1
        {
            get { return m_cLv1; }
            set { m_cLv1 = value; }
        }

        public CLevel Lv2
        {
            get { return m_cLv2; }
            set { m_cLv2 = value; }
        }

        public CLevel Lv3
        {
            get { return m_cLv3; }
            set { m_cLv3 = value; }
        }

        public CLevel Lv4
        {
            get { return m_cLv4; }
            set { m_cLv4 = value; }
        }

        public CLevel Lv5
        {
            get { return m_cLv5; }
            set { m_cLv5 = value; }
        }

        public CLevel Lv6
        {
            get { return m_cLv6; }
            set { m_cLv6 = value; }
        }

        public CLevel Lv7
        {
            get { return m_cLv7; }
            set { m_cLv7 = value; }
        }

        public CLevel Lv8
        {
            get { return m_cLv8; }
            set { m_cLv8 = value; }
        }

        public CLevel Lv9
        {
            get { return m_cLv9; }
            set { m_cLv9 = value; }
        }

        public CLevel Lv10
        {
            get { return m_cLv10; }
            set { m_cLv10 = value; }
        }

        public CLevel Lv11
        {
            get { return m_cLv11; }
            set { m_cLv11 = value; }
        }

        public CLevel Lv12
        {
            get { return m_cLv12; }
            set { m_cLv12 = value; }
        }

        public string Lv1Name
        {
            get { return GetLv1Name(); }
            set { SetLv1Name(value); }
        }

        public string Lv2Name
        {
            get { return GetLv2Name(); }
            set { SetLv2Name(value); }
        }

        public string Lv3Name
        {
            get { return GetLv3Name(); }
            set { SetLv3Name(value); }
        }

        public string Lv4Name
        {
            get { return GetLv4Name(); }
            set { SetLv4Name(value); }
        }

        public string Lv5Name
        {
            get { return GetLv5Name(); }
            set { SetLv5Name(value); }
        }

        public string Lv6Name
        {
            get { return GetLv6Name(); }
            set { SetLv6Name(value); }
        }

        public string Lv7Name
        {
            get { return GetLv7Name(); }
            set { SetLv7Name(value); }
        }

        public string Lv8Name
        {
            get { return GetLv8Name(); }
            set { SetLv8Name(value); }
        }

        public string Lv9Name
        {
            get { return GetLv9Name(); }
            set { SetLv9Name(value); }
        }

        public string Lv10Name
        {
            get { return GetLv10Name(); }
            set { SetLv10Name(value); }
        }

        public string Lv11Name
        {
            get { return GetLv11Name(); }
            set { SetLv11Name(value); }
        }

        public string Lv12Name
        {
            get { return GetLv12Name(); }
            set { SetLv12Name(value); }
        }

        #endregion

        public string GetDescription()
        {
            string sDescription = string.Empty;

            foreach (var who in m_lstLevel)
            {
                if (!who.IsCurrentView)
                    sDescription += string.Format("{0}_", who.TargetParse);
                else
                {
                    if (who.CurrentParse != string.Empty)
                        sDescription += string.Format("{0}_", who.CurrentParse);
                    else
                        continue;
                }
            }

            if(sDescription != string.Empty)
                sDescription = sDescription.Substring(0, sDescription.Length - 1);

            return sDescription;
        }

        public CLevel GetLevel(int iIndex)
        {
            CLevel cLv = null;

            switch (iIndex)
            {
                case 1: cLv = m_cLv1; break;
                case 2: cLv = m_cLv2; break;
                case 3: cLv = m_cLv3; break;
                case 4: cLv = m_cLv4; break;
                case 5: cLv = m_cLv5; break;
                case 6: cLv = m_cLv6; break;
                case 7: cLv = m_cLv7; break;
                case 8: cLv = m_cLv8; break;
                case 9: cLv = m_cLv9; break;
                case 10: cLv = m_cLv10; break;
                case 11: cLv = m_cLv11; break;
                case 12: cLv = m_cLv12; break;
            }

            return cLv;
        }

        #region Private Methods

        private string GetLv1Name()
        {
            string sName = string.Empty;

            if (m_cLv1 == null)
                return string.Empty;

            if (m_cLv1.IsCurrentView)
                sName = m_cLv1.CurrentParse;
            else
                sName = m_cLv1.TargetParse;

            return sName;
        }

        private string GetLv2Name()
        {
            string sName = string.Empty;

            if (m_cLv2 == null)
                return string.Empty;

            if (m_cLv2.IsCurrentView)
                sName = m_cLv2.CurrentParse;
            else
                sName = m_cLv2.TargetParse;

            return sName;
        }

        private string GetLv3Name()
        {
            string sName = string.Empty;

            if (m_cLv3 == null)
                return string.Empty;

            if (m_cLv3.IsCurrentView)
                sName = m_cLv3.CurrentParse;
            else
                sName = m_cLv3.TargetParse;

            return sName;
        }

        private string GetLv4Name()
        {
            string sName = string.Empty;

            if (m_cLv4 == null)
                return string.Empty;

            if (m_cLv4.IsCurrentView)
                sName = m_cLv4.CurrentParse;
            else
                sName = m_cLv4.TargetParse;

            return sName;
        }

        private string GetLv5Name()
        {
            string sName = string.Empty;

            if (m_cLv5 == null)
                return string.Empty;

            if (m_cLv5.IsCurrentView)
                sName = m_cLv5.CurrentParse;
            else
                sName = m_cLv5.TargetParse;

            return sName;
        }

        private string GetLv6Name()
        {
            string sName = string.Empty;

            if (m_cLv6 == null)
                return string.Empty;

            if (m_cLv6.IsCurrentView)
                sName = m_cLv6.CurrentParse;
            else
                sName = m_cLv6.TargetParse;

            return sName;
        }

        private string GetLv7Name()
        {
            string sName = string.Empty;

            if (m_cLv7 == null)
                return string.Empty;

            if (m_cLv7.IsCurrentView)
                sName = m_cLv7.CurrentParse;
            else
                sName = m_cLv7.TargetParse;

            return sName;
        }

        private string GetLv8Name()
        {
            string sName = string.Empty;

            if (m_cLv8 == null)
                return string.Empty;

            if (m_cLv8.IsCurrentView)
                sName = m_cLv8.CurrentParse;
            else
                sName = m_cLv8.TargetParse;

            return sName;
        }

        private string GetLv9Name()
        {
            string sName = string.Empty;

            if (m_cLv9 == null)
                return string.Empty;

            if (m_cLv9.IsCurrentView)
                sName = m_cLv9.CurrentParse;
            else
                sName = m_cLv9.TargetParse;

            return sName;
        }

        private string GetLv10Name()
        {
            string sName = string.Empty;

            if (m_cLv10 == null)
                return string.Empty;

            if (m_cLv10.IsCurrentView)
                sName = m_cLv10.CurrentParse;
            else
                sName = m_cLv10.TargetParse;

            return sName;
        }

        private string GetLv11Name()
        {
            string sName = string.Empty;

            if (m_cLv10 == null)
                return string.Empty;

            if (m_cLv11.IsCurrentView)
                sName = m_cLv11.CurrentParse;
            else
                sName = m_cLv11.TargetParse;

            return sName;
        }

        private string GetLv12Name()
        {
            string sName = string.Empty;

            if (m_cLv12 == null)
                return string.Empty;

            if (m_cLv12.IsCurrentView)
                sName = m_cLv12.CurrentParse;
            else
                sName = m_cLv12.TargetParse;

            return sName;
        }

        private void SetLv1Name(string sName)
        {
            if (m_cLv1 != null)
            {
                m_cLv1.Clear();
                m_cLv1.CurrentParse = sName;
                m_cLv1.IsCurrentView = true;
            }
        }

        private void SetLv2Name(string sName)
        {
            if (m_cLv2 != null)
            {
                m_cLv2.Clear();
                m_cLv2.CurrentParse = sName;
                m_cLv2.IsCurrentView = true;
            }
        }

        private void SetLv3Name(string sName)
        {
            if (m_cLv3 != null)
            {
                m_cLv3.Clear();
                m_cLv3.CurrentParse = sName;
                m_cLv3.IsCurrentView = true;
            }
        }

        private void SetLv4Name(string sName)
        {
            if (m_cLv4 != null)
            {
                m_cLv4.Clear();
                m_cLv4.CurrentParse = sName;
                m_cLv4.IsCurrentView = true;
            }
        }

        private void SetLv5Name(string sName)
        {
            if (m_cLv5 != null)
            {
                m_cLv5.Clear();
                m_cLv5.CurrentParse = sName;
                m_cLv5.IsCurrentView = true;
            }
        }

        private void SetLv6Name(string sName)
        {
            if (m_cLv6 != null)
            {
                m_cLv6.Clear();
                m_cLv6.CurrentParse = sName;
                m_cLv6.IsCurrentView = true;
            }
        }

        private void SetLv7Name(string sName)
        {
            if (m_cLv7 != null)
            {
                m_cLv7.Clear();
                m_cLv7.CurrentParse = sName;
                m_cLv7.IsCurrentView = true;
            }
        }

        private void SetLv8Name(string sName)
        {
            if (m_cLv8 != null)
            {
                m_cLv8.Clear();
                m_cLv8.CurrentParse = sName;
                m_cLv8.IsCurrentView = true;
            }
        }

        private void SetLv9Name(string sName)
        {
            if (m_cLv9 != null)
            {
                m_cLv9.Clear();
                m_cLv9.CurrentParse = sName;
                m_cLv9.IsCurrentView = true;
            }
        }

        private void SetLv10Name(string sName)
        {
            if (m_cLv10 != null)
            {
                m_cLv10.Clear();
                m_cLv10.CurrentParse = sName;
                m_cLv10.IsCurrentView = true;
            }
        }

        private void SetLv11Name(string sName)
        {
            if (m_cLv11 != null)
            {
                m_cLv11.Clear();
                m_cLv11.CurrentParse = sName;
                m_cLv11.IsCurrentView = true;
            }
        }

        private void SetLv12Name(string sName)
        {
            if (m_cLv12 != null)
            {
                m_cLv12.Clear();
                m_cLv12.CurrentParse = sName;
                m_cLv12.IsCurrentView = true;
            }
        }


        #endregion
    }

}