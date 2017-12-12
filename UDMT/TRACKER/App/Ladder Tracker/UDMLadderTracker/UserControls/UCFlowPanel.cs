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

namespace UDMLadderTracker
{
    public partial class UCFlowPanel : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member Variables

        private const int m_iBaseLabelHeight = 100;
        private bool m_bArrowPnl = false;
        private int m_iPanelCount = 0;
        private Color color1st = Color.FromArgb(201, 201, 201);
        private Color color2nd = Color.FromArgb(163, 163, 163);
        private CFlowChartItem m_cFlowItem = null;
        private bool m_bFlicker = false;
        private delegate void UpdateFlickerBack();

        #endregion


        #region Initialize

        public UCFlowPanel()
        {
            InitializeComponent();
            lblStepText.Text = "";
            pnlArrow.Enabled = m_bArrowPnl;
        }

        #endregion


        #region Properties

        public bool ArrowVisible
        {
            get { return m_bArrowPnl; }
            set { m_bArrowPnl = value; }
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
            if (m_cFlowItem == null) return;
            if (!m_bArrowPnl)
                pnlArrow.BackgroundImage = null;

            lblStepText.Text = m_cFlowItem.ViewString;

            lblStepText.ToolTip = m_cFlowItem.ToolTip;
            SetOffColor();
            lblCount.Text = m_iPanelCount.ToString();
        }

        public void SetActiveColor()
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
            lblStepText.Appearance.BackColor = color1st;
            lblStepText.Appearance.BackColor2 = color2nd;
        }

        public void SetOffColor()
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
            lblStepText.Appearance.BackColor = color1st;
            lblStepText.Appearance.BackColor2 = color2nd;
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
    }
}
