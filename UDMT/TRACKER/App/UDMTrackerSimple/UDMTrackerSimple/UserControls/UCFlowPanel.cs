using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Flow;
using UDM.Log;
using TrackerCommon;

namespace UDMTrackerSimple
{
    public partial class UCFlowPanel : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private const int m_iBaseLabelHeight = 100;
        private bool m_bArrowPnl = false;
        private bool m_bArrowPnlResize = true;
        private int m_iPanelCount = 0;
        private Color color1st = Color.FromArgb(201, 201, 201);
        private Color color2nd = Color.FromArgb(163, 163, 163);
        private CFlowChartItem m_cFlowItem = null;
        private bool m_bFlicker = false;

        private delegate void UpdateFlickerBack();
        private delegate void UpdateNoneParameterCallback();

        public UEventHandlerManualCycleOverTagKey UEventManualCycleOver = null;

        #endregion


        #region Initialize

        public UCFlowPanel()
        {
            InitializeComponent();
            lblStepText.Text = "";
            pnlArrow.Enabled = m_bArrowPnl;

            pnlArrow.MouseWheel += new MouseEventHandler(All_MouseWheel);
            lblStepText.MouseWheel += new MouseEventHandler(All_MouseWheel);
        }

        #endregion


        #region Properties

        public bool ArrowVisible
        {
            get { return m_bArrowPnl; }
            set { m_bArrowPnl = value; }
        }

        public bool ArrowPanelVisible
        {
            get { return m_bArrowPnlResize; }
            set { m_bArrowPnlResize = value; }
        }

        public CFlowChartItem FlowItem
        {
            get { return m_cFlowItem; }
            set { m_cFlowItem = value; }
        }

        public int PanelCount
        {
            set { m_iPanelCount = value + 1; }
        }


        #endregion

        public void SetInit()
        {
            try
            {
                if (m_cFlowItem == null) return;
                if (!m_bArrowPnl)
                    pnlArrow.BackgroundImage = null;

                if (!m_bArrowPnlResize)
                {
                    pnlArrow.BackgroundImage = null;
                    pnlArrow.Height = pnlArrow.Height - 20;
                    this.Height = this.Height - 20;
                    lblCount.Visible = false;
                }

                lblStepText.Text = m_cFlowItem.ViewString;

                lblStepText.ToolTip = m_cFlowItem.ToolTip;
                SetOffColor();
                lblCount.Text = m_iPanelCount.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetActiveColor()
        {
            try
            {
                if (m_cFlowItem.ConditionElement)
                {
                    color1st = Color.MediumTurquoise;
                    color2nd = Color.Cyan;
                }
                else if (m_cFlowItem.RecipeElement)
                {
                    color1st = Color.LightYellow;
                    color2nd = Color.Yellow;
                }
                else
                {
                    if (m_cFlowItem.TargetValue > 0)
                    {
                        color1st = Color.GreenYellow;
                        color2nd = Color.Lime;
                    }
                    else
                    {
                        color1st = Color.Cyan;
                        color2nd = Color.Cyan;
                    }
                }

                lblStepText.Appearance.BackColor = color1st;
                lblStepText.Appearance.BackColor2 = color2nd;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetOffColor()
        {
            try
            {
                if (m_cFlowItem.ConditionElement)
                {
                    color1st = Color.DarkSlateGray;
                    color2nd = Color.Teal;
                }
                else if (m_cFlowItem.RecipeElement)
                {
                    color1st = Color.Olive;
                    color2nd = Color.DarkKhaki;
                }
                else
                {
                    if (m_cFlowItem.TargetValue > 0)
                    {
                        color1st = Color.DarkGreen;
                        color2nd = Color.DarkGreen;
                    }
                    else
                    {
                        color1st = Color.RoyalBlue;
                        color2nd = Color.RoyalBlue;
                    }
                }

                lblStepText.Appearance.BackColor = color1st;
                lblStepText.Appearance.BackColor2 = color2nd;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        public void SetFlicker()
        {
            if (m_cFlowItem.TargetValue > 0)
            {
                if (m_bFlicker)
                {
                    color1st = Color.GreenYellow;
                    color2nd = Color.Lime;
                }
                else
                {
                    color1st = Color.DarkGreen;
                    color2nd = Color.DarkGreen;
                }
            }
            else
            {
                if (m_bFlicker)
                {
                    color1st = Color.Cyan;
                    color2nd = Color.Cyan;
                }
                else
                {
                    color1st = Color.RoyalBlue;
                    color2nd = Color.RoyalBlue;
                }
            }
            m_bFlicker = !m_bFlicker;
            lblStepText.Appearance.BackColor = color1st;
            lblStepText.Appearance.BackColor2 = color2nd;
        }

        private void ManualErrorGenerate()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateFlickerBack cUpdate = new UpdateFlickerBack(ManualErrorGenerate);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (UEventManualCycleOver != null)
                        UEventManualCycleOver(string.Empty, m_cFlowItem.Key);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void LadderDiagramView()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(LadderDiagramView);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (m_cFlowItem == null || !CMultiProject.PlcLogicDataS.ContainsKey(m_cFlowItem.PlcID))
                        return;

                    CPlcLogicData cData = CMultiProject.PlcLogicDataS[m_cFlowItem.PlcID];

                    if (!cData.StepS.ContainsKey(m_cFlowItem.StepKey))
                        return;

                    CStep cStep = cData.StepS[m_cFlowItem.StepKey];

                    FrmLadderView frmView = new FrmLadderView();
                    frmView.TopMost = true;
                    frmView.Show();

                    frmView.SetLadderStep(cData, cStep, 0, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void EditPanelText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateNoneParameterCallback cUpdate = new UpdateNoneParameterCallback(EditPanelText);
                    this.Invoke(cUpdate, new object[] {});
                }
                else
                {
                    if (m_cFlowItem == null || !CMultiProject.TotalTagS.ContainsKey(m_cFlowItem.Key))
                        return;

                    FrmInputDialog dlgInput = new FrmInputDialog("Flow Chart 텍스트 변경", "변경할 텍스트를 입력해주세요.");
                    dlgInput.ShowDialog();

                    string sName = dlgInput.InputText;

                    dlgInput.Dispose();
                    dlgInput = null;

                    if (sName == string.Empty)
                        return;

                    m_cFlowItem.Description = sName;
                    lblStepText.Text = m_cFlowItem.ViewString;

                    CTag cTag = CMultiProject.TotalTagS[m_cFlowItem.Key];
                    cTag.Description = sName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseWheel(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void All_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                base.OnMouseUp(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnErrorGen_Click(object sender, EventArgs e)
        {
            try
            {
                ManualErrorGenerate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void lblStepText_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                LadderDiagramView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void btnEditText_Click(object sender, EventArgs e)
        {
            try
            {
                EditPanelText();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

    }
}
