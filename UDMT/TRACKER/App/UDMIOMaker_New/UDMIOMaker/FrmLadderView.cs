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
using UDM.Ladder;
using UDM.Log;

namespace UDMIOMaker
{
    public partial class FrmLadderView : DevExpress.XtraEditors.XtraForm
    {
        private CStep m_cStep = null;
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

        public CStep Step
        {
            get { return m_cStep; }
            set { m_cStep = value; }
        }

        public void SetLadderStep(CStep cStep, int iStepLevel, bool bView)
        {
            if (cStep != null)
            {
                m_iStepLevel = 0;

                if (cStep.CoilS.GetFirstCoil().ContentS[0].Tag == null)
                    return;

                CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

                UCLadderStep ucStep = new UCLadderStep(cStep, null, EditorBrand.Common);
                ucStep.Dock = DockStyle.Top;
                ucStep.AutoSizeParent = true;
                ucStep.AutoScroll = false;
                ucStep.ScaleDefault = 1f; // 0.6f;
                ucStep.Scrollable = false;
                ucStep.StepLevel = iStepLevel;
                ucStep.IsViewStep = bView;

                string sDesc = cTag.Name != string.Empty ? cTag.Name : cTag.Description;

                ucStep.StepName =
                    string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                        cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
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
                        UCLadderStep ucView = (UCLadderStep)pnlLadder.Controls[i];
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
                CProjectManager.UpdateSystemMessage("UEvent Selected Cell Data Error", ex.Message + " [" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]");
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private CStep GetMasterStep(CTag cTag)
        {
            CStep cStep;


            FrmStepSelector frmStepSelector = new FrmStepSelector();
            frmStepSelector.Tag = cTag;
            frmStepSelector.TopMost = true;

            if (frmStepSelector.ShowDialog() != DialogResult.OK)
                return null;

            cStep = frmStepSelector.GetSelectedStep();

            frmStepSelector.Dispose();
            frmStepSelector = null;

            return cStep;
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