using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TrackerCommon;
using UDM.Common;
using UDM.Ladder;
using UDM.Log;

namespace UDMOptimizer
{
    public partial class FrmLadderView : DevExpress.XtraEditors.XtraForm
    {
        private CStep m_cStep = null;
        private CPlcLogicData m_cData = null;
        private bool m_bLoad = false;
        private int m_iStepLevel = -1;

        public FrmLadderView()
        {
            InitializeComponent();
        }

        public bool IsLoad
        {
            get { return m_bLoad; }
            set { m_bLoad = value; }
        }

        public CPlcLogicData LogicData
        {
            get { return m_cData; }
            set { m_cData = value; }
        }

        public CStep Step
        {
            get { return m_cStep; }
            set { m_cStep = value; }
        }

        public void SetLadderStep(CPlcLogicData cData, CStep cStep, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                m_cData = cData;

                m_iStepLevel = iStepLevel;

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
                        string.Format("CPU : {3} / Program : {0} / Network : {1} / 설명 : {2}",
                            cStep.Program, cStep.StepIndex, cCoil.Instruction.Replace("\t", "  "), m_cData.PlcChannel);
                }

                ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                pnlLadder.Controls.Add(ucStep);
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

                    ucStep.StepName = string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
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

        private CStep GetMasterStep(CTag cTag)
        {
            if (cTag == null) return null;
            if (m_cData == null) return null;
            CStep cStep = null;
            List<CStep> lstStep = new List<CStep>();


            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType == EMStepRoleType.Coil)
                {
                    if (m_cData.StepS.ContainsKey(who.StepKey))
                        lstStep.Add(m_cData.StepS[who.StepKey]);
                }
                else if (who.RoleType == EMStepRoleType.Both)
                {
                    if (m_cData.StepS.ContainsKey(who.StepKey))
                    {
                        cStep = m_cData.StepS[who.StepKey];

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
                {
                    FrmStepSelector frmSelector = new FrmStepSelector();
                    frmSelector.StepList = lstStep;
                    frmSelector.TopMost = true;
                    frmSelector.ShowDialog();

                    if (frmSelector.IsSelectStep)
                    {
                        cStep = frmSelector.GetSelectedStep();
                    }

                    frmSelector.Dispose();
                    frmSelector = null;
                }
            }
            else
                XtraMessageBox.Show("해당 태그는 출력 접점으로 사용되지 않았습니다.");

            return cStep;
        }

        private bool CheckDoubleCoil(CTag cTag)
        {
            bool bOK = false;

            int iCoilCount = cTag.StepRoleS.Where(x => x.RoleType == EMStepRoleType.Coil).Count();
            int iBothCount = 0;
            List<string> lstBothStepKey = new List<string>();
            string sStepKey = string.Empty;

            foreach (var who in cTag.StepRoleS)
            {
                if (who.RoleType.Equals(EMStepRoleType.Both))
                {
                    sStepKey = who.StepKey;

                    if (sStepKey.Contains("["))
                        sStepKey = sStepKey.Split('[').First();

                    if (!lstBothStepKey.Contains(sStepKey))
                    {
                        lstBothStepKey.Add(sStepKey);
                        iBothCount++;
                    }
                }
            }

            int iCount = iCoilCount + iBothCount;

            if (iCount >= 2)
                bOK = true;

            return bOK;
        }

 

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlLadder.Controls.Clear();
            this.Hide();
            m_bLoad = false;
        }

        private void FrmLadderView_Load(object sender, EventArgs e)
        {

        }

        private void btnLadderStepDelete_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl == null || this.ActiveControl.GetType() != typeof(UCLadderStep))
                return;

            UCLadderStep ucStep = (UCLadderStep) this.ActiveControl;

            pnlLadder.Controls.Remove(ucStep);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pnlLadder.Controls.Clear();
        }

        private void FrmLadderView_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_bLoad = false;
        }

        private void FrmLadderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            pnlLadder.Controls.Clear();
            this.Hide();
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
            m_bLoad = false;
        }

    }
}