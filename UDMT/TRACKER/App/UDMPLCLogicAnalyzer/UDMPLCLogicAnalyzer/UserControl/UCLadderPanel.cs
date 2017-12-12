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
using UDM.Log;
using UDM.Ladder;

namespace UDMPLCLogicAnalyzer
{
    public partial class UCLadderPanel : DevExpress.XtraEditors.XtraUserControl
    {
        private CStep m_cStep = null;
        private CPlcLogicData m_cData = null;
        private bool m_bLoad = false;
        private int m_iStepLevel = -1;

        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;

        private delegate void UpdateLadderViewCallback(CPlcLogicData cData, CStep cStep, int iStepLevel, bool bView);
        private delegate void UpdateLadderCellViewCallback(CTag cTag, int iStepLevel, CTimeLogS cLogS);

        public UCLadderPanel()
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
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateLadderViewCallback cUpdate = new UpdateLadderViewCallback(SetLadderStep);
                    this.Invoke(cUpdate, new object[] { cData, cStep, iStepLevel, bView });
                }
                else
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

                            string sDesc = cTag.GetDescription();

                            ucStep.StepName =
                                string.Format("CPU : {3} / Program : {0} / Network : {1} / Coil : {2} ( {4} )",
                                    cStep.Program, cStep.StepIndex, cTag.Address, cTag.Channel, sDesc);
                        }
                        else
                        {
                            CCoil cCoil = cStep.CoilS.GetFirstCoil();

                            ucStep.StepName =
                                string.Format("CPU : {3} / Program : {0} / Network : {1} / 설명 : {2}",
                                    cStep.Program, cStep.StepIndex, cCoil.Instruction.Replace("\t", "  "),
                                    m_cData.PlcChannel);
                        }

                        //ucStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;
                        //ucStep.UEventRightSelectedCellData += ucStep_UEventSelectedRightCellData;
                        //ucStep.MouseUp += ucStep_MouseUp;
                        //ucStep.MouseDown += ucStep_MouseDown;
                        //ucStep.MouseMove += ucStep_MouseMove;
                        pnlLadder.Controls.Add(ucStep);
                        ucStep.Focus();
                        pnlLadder.VerticalScroll.Value = 0;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void ClearLadder()
        {
            pnlLadder.Controls.Clear();
            m_bLoad = false;
        }

        private void UCLadderPanel_Load(object sender, EventArgs e)
        {
            pnlLadder.MouseWheel += pnlLadder_MouseWheel;
            pnlLadder.Scroll += pnlLadder_Scroll;
        }


        private void pnlLadder_MouseWheel(object sender, MouseEventArgs e)
        {
            if (pnlLadder.VerticalScroll.Visible)
                pnlLadder_Scroll(null, null);
        }

        private void pnlLadder_Scroll(object sender, ScrollEventArgs e)
        {
            int iSumHeight = 0;
            Control conTopLadder = pnlLadder.GetChildAtPoint(new Point(0, 0));
            UCLadderStep ucTopLadder = (UCLadderStep)conTopLadder;

            for (int i = 0; i < pnlLadder.Controls.Count; i++)
            {
                UCLadderStep ucLadder = (UCLadderStep)pnlLadder.Controls[i];

                if (ucLadder == ucTopLadder)
                {
                    ucLadder.TextPanel.SendToBack();
                    ucLadder.TopPanel.SendToBack();
                    ucLadder.TextPanel.Dock = DockStyle.None;
                    ucLadder.TextPanel.BringToFront();
                    ucLadder.TextPanel.Width = ucLadder.Width;
                    ucLadder.TopPanel.Height = ucLadder.TextPanel.Height;
                    ucLadder.TextPanel.Location = new Point(ucLadder.TextPanel.Location.X, pnlLadder.VerticalScroll.Value);

                    if (i != pnlLadder.Controls.Count - 1)
                    {
                        for (int j = pnlLadder.Controls.Count - 1; j > i; j--)
                            iSumHeight += pnlLadder.Controls[j].Height;

                        ucLadder.TextPanel.Location = new Point(ucLadder.TextPanel.Location.X, pnlLadder.VerticalScroll.Value - iSumHeight);
                    }
                }
                else
                {
                    ucLadder.TopPanel.Height = 5;
                    ucLadder.TopPanel.BringToFront();
                    ucLadder.TextPanel.SendToBack();
                    ucLadder.TextPanel.Dock = DockStyle.Top;
                    ucLadder.TextPanel.Width = ucLadder.Width;
                }
            }
        }
    }
}
