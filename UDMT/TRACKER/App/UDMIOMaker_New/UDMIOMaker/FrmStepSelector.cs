using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmStepSelector : DevExpress.XtraEditors.XtraForm
    {
        private CTag m_cTag = null;
        private List<CStepRoleView> m_lstView = new List<CStepRoleView>();
        private bool m_bCoil = false;
        private bool m_bOnlyCoilView = false;

        public FrmStepSelector()
        {
            InitializeComponent();
        }

        public CTag Tag
        {
            get { return m_cTag; }
            set { m_cTag = value; }
        }

        public bool OnlyCoilView
        {
            get { return m_bOnlyCoilView; }
            set { m_bOnlyCoilView = value; }
        }

        public bool IsCoil
        {
            get { return m_bCoil; }
            set { m_bCoil = value; }
        }
        
        public void ShowTable()
        {
            Clear();

            grdStep.DataSource = m_lstView;
            grdStep.RefreshDataSource();
        }

        public void Clear()
        {
            grdStep.DataSource = null;
            grdStep.RefreshDataSource();
        }

        public CStep GetSelectedStep()
        {
            int iRowIndex = grvStep.FocusedRowHandle;
            if (iRowIndex < 0)
                return null;

            CStepRoleView cView = (CStepRoleView)grvStep.GetRow(iRowIndex);

            if (cView.RoleType == EMStepRoleType.Both || cView.RoleType == EMStepRoleType.Coil)
                m_bCoil = true;

            CPlcLogicData cData = GetUsedLogicData(m_cTag.Key);
            CStep cStep = cData.StepS[cView.StepKey];

            return cStep;
        }

        private CPlcLogicData GetUsedLogicData(string sKey)
        {
            CPlcLogicData cData = null;

            foreach (var who in CProjectManager.LogicDataS)
            {
                if (who.Value.TagS.ContainsKey(sKey))
                {
                    cData = who.Value;
                    break;
                }
            }

            return cData;
        }

        private void SetSetpRoleView()
        {
            CPlcLogicData cData = GetUsedLogicData(m_cTag.Key);

            if (cData == null)
                return;

            m_lstView.Clear();

            CTagStepRole cRole;
            CStepRoleView cRoleView = null;
            foreach (var who in m_cTag.StepRoleS)
            {
                if (m_bOnlyCoilView)
                {
                    if (who.RoleType.Equals(EMStepRoleType.Contact))
                        continue;
                }

                if (!cData.StepS.ContainsKey(who.StepKey))
                    continue;

                cRoleView = new CStepRoleView();
                cRoleView.StepRole = who;
                cRoleView.Address = cData.StepS[who.StepKey].Address;
                cRoleView.Instruction = cData.StepS[who.StepKey].Instruction;
                cRoleView.Program = cData.StepS[who.StepKey].Program;
                cRoleView.StepIndex = cData.StepS[who.StepKey].StepIndex;

                m_lstView.Add(cRoleView);
            }
        }

        private void grvStep_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int iIndex = e.RowHandle + 1;
                e.Info.DisplayText = iIndex.ToString();
            }
        }

        private void grvStep_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult =DialogResult.OK; 
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmStepSelector_Load(object sender, EventArgs e)
        {
            try
            {
                if (m_cTag == null)
                    return;

                SetSetpRoleView();
                ShowTable();
            }
            catch (System.Exception ex)
            {
                CProjectManager.UpdateSystemMessage("FrmStepSelector Load Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
    }

    public class CStepRoleView
    {
        private CTagStepRole m_cRole = null;
        private string m_sAddress = string.Empty;
        private string m_sInstruction = string.Empty;
        private string m_sProgram = string.Empty;
        private int m_iStepIndex = -1;

        public int StepIndex
        {
            get { return m_iStepIndex; }
            set { m_iStepIndex = value; }
        }

        public CTagStepRole StepRole
        {
            get { return m_cRole;}
            set { m_cRole = value; }
        }

        public string StepKey
        {
            get { return m_cRole.StepKey; }
        }

        public EMStepRoleType RoleType
        {
            get { return m_cRole.RoleType; }
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

        public string Program
        {
            get { return m_sProgram;}
            set { m_sProgram = value; }
        }


    }
}