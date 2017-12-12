using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;

namespace UDM.UDLImport.Demo
{
    public partial class FrmLadderView : DevExpress.XtraEditors.XtraForm
    {
        private CTagS m_cTagS = null;
        private CStepS m_cStepS = null;

        public FrmLadderView()
        {
            InitializeComponent();
        }

        public CTagS TagS
        {
            get { return m_cTagS; }
            set { m_cTagS = value; }
        }

        public CStepS StepS
        {
            get { return m_cStepS; }
            set { m_cStepS = value; }
        }

        private CStep GetMasterStep(CTag cTag)
        {
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if(m_cStepS.ContainsKey(who.StepKey))
                        lstStep.Add(m_cStepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (m_cStepS.ContainsKey(who.StepKey))
                    {
                        cStep = m_cStepS[who.StepKey];

                        if (cStep.CoilS.Count > 0 && CheckContainCoilTag(cStep.CoilS.GetFirstCoil(), cTag))
                            lstStep.Add(cStep);
                    }
                }
            }

            if (lstStep.Count > 0)
            {
                if (lstStep.Count == 1)
                    cStep = lstStep[0];
                else if (lstStep.Count > 1)
                    cStep = lstStep.First();
            }
            else
            {
                XtraMessageBox.Show("해당 접점은 출력 접점으로 사용되지 않았습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return cStep;
        }

        private bool CheckContainCoilTag(CCoil cCoil, CTag cTag)
        {
            bool bOK = false;

            foreach (var who in cCoil.ContentS)
            {
                if (who.Tag != null && who.Tag.Key == cTag.Key)
                {
                    bOK = true;
                    break;
                }
            }

            return bOK;
        }


        public void SetLadderStep(CStep cStep, int iStepLevel, bool bView)
        {
            try
            {
                if (cStep != null)
                {

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.AutoScroll = false;
                    ucStep.ScaleDefault = 1f; // 0.6f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel;
                    ucStep.IsViewStep = bView;

                    if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag != null)
                    {
                        CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                        string sDesc = cTag.Name != string.Empty ? cTag.Name : cTag.Description;

                        ucStep.StepName =
                            string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                                cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
                    }
                    else
                    {
                        CCoil cCoil = cStep.CoilS.GetFirstCoil();

                        ucStep.StepName =
                            string.Format("Program : {0} / Network : {1} / 설명 : {2}",
                                cStep.Program, cStep.StepIndex, cCoil.Instruction.Replace("\t", "  "));
                    }

                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                    pnlLadder.Controls.Add(ucStep);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {
            try
            {
                    if (cTag == null) return;
                    CStep cStep = GetMasterStep(cTag);

                if (cStep != null)
                {
                    List<UCLadderStep> lstRemove = new List<UCLadderStep>();
                    for (int i = 0; i < pnlLadder.Controls.Count; i++)
                    {
                        UCLadderStep ucView = (UCLadderStep) pnlLadder.Controls[i];
                        if (ucView.StepLevel > iStepLevel)
                            lstRemove.Add(ucView);
                        else
                        {
                            if (ucView.Step.Key == cStep.Key)
                            {
                                XtraMessageBox.Show("같은 Step이 열려 있습니다.");
                                return;
                            }
                        }
                    }
                    for (int i = 0; i < lstRemove.Count; i++)
                        pnlLadder.Controls.Remove(lstRemove[i]);

                    UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                    ucStep.Dock = DockStyle.Top;
                    ucStep.AutoSizeParent = true;
                    ucStep.ScaleDefault = 1f; // 0.6f;
                    ucStep.Scrollable = false;
                    ucStep.StepLevel = iStepLevel + 1;

                    string sDesc = cTag.Name != string.Empty ? cTag.Name : cTag.Description;

                    ucStep.StepName = string.Format(
                        " Program : {0} / Network : {1} / Coil : {2} ( {3} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, sDesc);
                    ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                    pnlLadder.Controls.Add(ucStep);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnlLadder.Controls.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvTag_DoubleClick(object sender, EventArgs e)
        {
            int iRowHandle = grvTag.FocusedRowHandle;

            if (iRowHandle < 0)
                return;

            object obj = grvTag.GetRow(iRowHandle);

            if (obj.GetType() != typeof(CTag))
                return;

            CTag cTag = (CTag)obj;

            if (cTag == null) return;

            CStep cStep = GetMasterStep(cTag);

            if (cStep == null)
                return;

            pnlLadder.Controls.Clear();
            SetLadderStep(cStep, 0 , true);
        }

        private void FrmLadderView_Load(object sender, EventArgs e)
        {
            if (m_cStepS == null || m_cTagS == null)
                return;

            grdTag.DataSource = m_cTagS.Values.ToList();
            grdTag.RefreshDataSource();
        }
    }
}