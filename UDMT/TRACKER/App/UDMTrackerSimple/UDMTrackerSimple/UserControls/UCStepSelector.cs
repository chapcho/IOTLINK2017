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
using UDM.Common;

namespace UDMTrackerSimple
{
    public delegate void UEventHandlerStepRoleDoubleClick(CStep cStep);

    public partial class UCStepSelector : DevExpress.XtraEditors.XtraUserControl
    {
        private CTag m_cTag = null;
        private CPlcLogicData m_cData = null;
        private List<CStepRoleView> m_lstView = new List<CStepRoleView>();

        public UEventHandlerStepRoleDoubleClick UEventStepRoleDoubleClicked = null;

        public UCStepSelector()
        {
            InitializeComponent();
        }

        public void ShowStepRole(CTag cTag, CPlcLogicData cData, bool bCoilView)
        {
            try
            {
                if (cTag == null || cData == null)
                    return;

                m_cTag = cTag;
                m_cData = cData;

                m_lstView.Clear();

                CStepRoleView cRoleView = null;
                foreach (var who in m_cTag.StepRoleS)
                {
                    if (bCoilView)
                    {
                        if (who.RoleType.Equals(EMStepRoleType.Contact) || who.RoleType.Equals(EMStepRoleType.None))
                            continue;
                    }

                    cRoleView = new CStepRoleView();
                    cRoleView.cStepRole = who;
                    cRoleView.Address = cTag.Address;
                    cRoleView.Instruction = cData.StepS[who.StepKey].Instruction;
                    cRoleView.Program = cData.StepS[who.StepKey].Program;
                    cRoleView.CoilDesc = cData.StepS[who.StepKey].Description;
                    cRoleView.CoilAddress = cData.StepS[who.StepKey].Address;
                    cRoleView.TagKey = m_cTag.Key;
                    cRoleView.Step = cData.StepS[who.StepKey];

                    m_lstView.Add(cRoleView);
                }

                grdStep.DataSource = m_lstView;
                grdStep.RefreshDataSource();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ShowStepRole Error : " + ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearStepRole()
        {
            m_cTag = null;
            m_cData = null;
            m_lstView.Clear();

            grdStep.RefreshDataSource();
        }

        private void grvStep_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRowHandle = grvStep.FocusedRowHandle;

                if (iRowHandle < 0)
                    return;

                object obj = grvStep.GetRow(iRowHandle);

                if (obj.GetType() != typeof (CStepRoleView))
                    return;

                CStepRoleView cView = (CStepRoleView) obj;
                CStep cStep = m_cData.StepS[cView.cStepRole.StepKey];

                if (UEventStepRoleDoubleClicked != null)
                    UEventStepRoleDoubleClicked(cStep);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Step Selector Grid Double Click Error : " + ex.Message);
                ex.Data.Clear();
            }
        }



    }

    public class CStepRoleView
    {
        private string m_sProgram = string.Empty;
        private CTagStepRole m_cStepRole = null;
        private string m_sAddress = string.Empty;
        private string m_sInstruction = string.Empty;
        private string m_sCoilAddress = string.Empty;
        private string m_sCoilDesc = string.Empty;
        private string m_sKey = string.Empty;
        private CStep m_cStep = null;

        public int ImageIndex
        {
            get { return GetImageIndex(); }
        }

        public string TagKey
        {
            get { return m_sKey; }
            set { m_sKey = value; }
        }

        public CStep Step
        {
            get { return m_cStep;}
            set { m_cStep = value; }
        }

        public string Program
        {
            get { return m_sProgram;}
            set { m_sProgram = value; }
        }

        public CTagStepRole cStepRole
        {
            get { return m_cStepRole;}
            set { m_cStepRole = value; }
        }

        public string Address
        {
            get { return m_sAddress;}
            set { m_sAddress = value; }
        }

        public string Instruction
        {
            get { return m_sInstruction;}
            set { m_sInstruction = value; }
        }

        public string CoilAddress
        {
            get { return m_sCoilAddress;}
            set { m_sCoilAddress = value; }
        }

        public string CoilDesc
        {
            get { return m_sCoilDesc;}
            set { m_sCoilDesc = value; }
        }

        private CContact GetContact()
        {
            CContact cContact = null;

            foreach (var who in m_cStep.ContactS)
            {
                if (who.RefTagS.ContainsKey(m_sKey))
                {
                    cContact = who;
                    break;
                }
            }

            return cContact;
        }

        private int GetImageIndex()
        {
            int iIndex = -1;

            if (m_cStepRole == null)
                return -1;

            if (m_cStepRole.RoleType.Equals(EMStepRoleType.Contact))
            {
                CContact cContact = GetContact();

                if (cContact.ContactType.Equals(EMContactType.Bit))
                {
                    if (cContact.Operator.Equals("XIO"))
                        iIndex = 1;
                    else
                        iIndex = 0;
                }
                else
                    iIndex = 3;
            }
            else if (m_cStepRole.RoleType.Equals(EMStepRoleType.Coil) ||
                     (m_cStepRole.RoleType.Equals(EMStepRoleType.Both)))
            {
                iIndex = 2;
            }
            else if (m_cStepRole.RoleType.Equals(EMStepRoleType.None))
                iIndex = -1;

            return iIndex;
        }
    }
}
