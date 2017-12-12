using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SplitPanel.UserControls
{
    [Designer(typeof(UCSplitPanelDesigner))]
    public partial class UCSplitPanel : Panel
    {

        #region Member Variables

        protected int m_iSplitterHeight = 5;
        protected Color m_cSplitterColor = Color.LightGray;        

        #endregion


        #region Initialize/Dispose

        public UCSplitPanel()
        {
            InitializeComponent();
            InitializeLayout();
        }

        public UCSplitPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitializeLayout();
        }

        #endregion


        #region Public Properties

        public int SplitterHeight
        {
            get { return m_iSplitterHeight; }
            set { m_iSplitterHeight = value; ResizeByHeader();  Invalidate(); }
        }

        public Color SplitterColor
        {
            get { return m_cSplitterColor; }
            set { m_cSplitterColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel HeaderPanel
        {
            get { return pnlHead; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel BodyPanel
        {
            get { return pnlBody; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods
        
        protected void InitializeLayout()
        {   
            this.Controls.Add(pnlHead);
            this.Controls.Add(pnlBody);

            pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            pnlBody.Dock = System.Windows.Forms.DockStyle.Bottom;

            ResizeByHeader();

            pnlHead.Resize += pnlHead_Resize;
            pnlBody.Resize += pnlBody_Resize;
        }

        protected void ResizeByHeader()
        {
            int iBodyHeight = this.ClientRectangle.Height - pnlHead.Height - m_iSplitterHeight/2;
            if (iBodyHeight < 1)
                iBodyHeight = 1;

            pnlBody.Height = iBodyHeight;
        }

        protected void ResizeByBody()
        {
            int iHeaderHeight = this.ClientRectangle.Height - pnlBody.Height - m_iSplitterHeight/2;
            if (iHeaderHeight < 1)
                iHeaderHeight = 1;

            pnlHead.Height = iHeaderHeight;
        }

        #endregion


        #region Override Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen pen = new Pen(m_cSplitterColor, m_iSplitterHeight);
            e.Graphics.DrawLine(pen, 5, pnlHead.Height, this.Width - 5, pnlHead.Height);

            pen.Dispose();
            pen = null;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            pnlHead.Resize -= pnlHead_Resize;
            pnlBody.Resize -= pnlBody_Resize;
            {
                base.OnResize(eventargs);
                ResizeByHeader();
                this.Invalidate();
            }
            pnlHead.Resize += pnlHead_Resize;
            pnlBody.Resize += pnlBody_Resize;
        }

        #endregion


        #region Event Methods

        private void pnlHead_Resize(object sender, EventArgs e)
        {
            pnlBody.Resize -= pnlBody_Resize;
            {
                ResizeByHeader();

                this.Invalidate();
            }
            pnlBody.Resize += pnlBody_Resize;
        }

        private void pnlBody_Resize(object sender, EventArgs e)
        {
            pnlHead.Resize -= pnlHead_Resize;
            {
                ResizeByBody();

                this.Invalidate();
            }
            pnlHead.Resize += pnlHead_Resize;
        }

        #endregion
    }

    class UCSplitPanelDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            UCSplitPanel ucPanel = component as UCSplitPanel;

            this.EnableDesignMode(ucPanel.HeaderPanel, "HeaderPanel");            
            this.EnableDesignMode(ucPanel.BodyPanel, "BodyPanel");
        }
    }
}
