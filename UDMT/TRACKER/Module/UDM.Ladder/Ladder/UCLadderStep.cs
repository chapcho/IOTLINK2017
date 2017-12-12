using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.Log;
using DevExpress.XtraEditors;


namespace UDM.Ladder
{
    public delegate void UEventHandlerSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS);

    public partial class UCLadderStep : UserControl
    {
        #region Member Variables

        private bool m_bScrollMove = false;
        private int m_iScrollPosition = 0;
        private float m_scaleCanvasDefault = 1f;
        private float m_scaleCanvas = 1f;
        private int m_nSpaceX = 10;
        private int m_nSpaceY = 10;
        private float m_nPinX = 10;
        private float m_nPinY = 10;
        private bool m_bAutoSizeParent = true;
        private CLadderStep m_cLadderStep = new CLadderStep();
        private List<CLadderCell> m_listResultFind = new List<CLadderCell>();
        private SizeF sizeScaleOne = new SizeF();

        public event UEventHandlerSelectedCellData UEventSelectedCellData = null;
        public event UEventHandlerSelectedCellData UEventRightSelectedCellData = null;

        public EditorBrand Brand { get { return m_cLadderStep.EditorBrand; } set { m_cLadderStep.EditorBrand = value; } }
        public CStep Step { get { return m_cLadderStep.Step; } set { m_cLadderStep.Step = value; } }
        public CTimeLogS SymbolLogS { get { return m_cLadderStep.SymbolLogS; } set { m_cLadderStep.SymbolLogS = value; } }
        public Dictionary<ITagComposable, CLadderCell> ItemLadderCell { get { return m_cLadderStep.ItemLadderCell; } }

        #endregion

        #region Initialize
        public UCLadderStep(CStep cStep, CTimeLogS cSymbolLogS, EditorBrand eBrand)
            : this(cStep, cSymbolLogS)
        {
            m_cLadderStep.EditorBrand = eBrand;
        }

        public UCLadderStep(CStep cStep, CTimeLogS cSymbolLogS)
            : this()
        {
            m_cLadderStep.Step = cStep;
            m_cLadderStep.SymbolLogS = cSymbolLogS;
        }

        public UCLadderStep()
        {
            InitializeComponent();

            m_nPinX = m_nSpaceX = 10;
            m_nPinY = m_nSpaceY = 10;

            m_cLadderStep = new CLadderStep();
            m_cLadderStep.Origin = new CVertex(0, 0);
            m_cLadderStep.UEventItemClick += m_cLadderStep_UEventItemClick;
            //m_cLadderStep.UEventItemRightClick += m_cLadderStep_UEventItemClick;
            m_cLadderStep.UEventItemDoubleClick += m_cLadderStep_UEventItemDoubleClick;
            //m_cLadderStep.UEventItemRightDoubleClick += m_cLadderStep_UEventItemRightDoubleClick;
            ucCanvas.AddElement(m_cLadderStep);
            ucCanvas.Scrollable = false;
            ucCanvas.Dragable = true;
            ucCanvas.Debugable = false;
            ucCanvas.EventScaled += EventScaled;
            ucCanvas.EventDragged += EventDragged;
            ucCanvas.EventBeforeDragged += EventBeforeDragged;

            this.Load += OnLoad;
        }

        #endregion

        #region Properties

        public PanelControl TextPanel
        {
            get { return pnlText; }
        }

        public PanelControl TopPanel
        {
            get { return pnlTop; }
        }

        public string StepName
        {
            set { lblText.Text = value; }
        }

        public bool SmallView
        {
            get { return chkView.Checked; }
            set { chkView.Checked = value; }
        }

        public bool AutoSizeParent 
        { 
            get { return m_bAutoSizeParent; } 
            set 
            { 
                // If the parent is other than Form class, then, the parent size is always same ClientSize of UCLadderStep
                m_bAutoSizeParent = this.Parent is Form == false ? true : value; 
                if (this.Parent is Form)
                {
                    (this.Parent as Form).FormBorderStyle = m_bAutoSizeParent ? FormBorderStyle.FixedDialog : (this.Parent as Form).FormBorderStyle ;
                }
            } 
        }

        public CVertex TopLeft { get { return m_cLadderStep.TopLeft; } }
        public CVertex TopRight { get { return m_cLadderStep.TopRight; } }
        public CVertex BottomRight { get { return m_cLadderStep.BottomRight; } }
        public CVertex BottomLeft { get { return m_cLadderStep.BottomLeft; } }

        public float ScaleDefault { get { return m_scaleCanvasDefault; } set { m_scaleCanvasDefault = value; } }

        public bool Scrollable { get; set; }

        public int StepLevel { get; set; }

        public bool IsViewStep
        {
            get { return chkView.Checked; }
            set { chkView.Checked = value; }
        }

        #endregion

        #region Method


        public CLadderCell GetLadderCell(ITagComposable cItem)
        {
            return m_cLadderStep == null ? null : m_cLadderStep.GetLadderCell(cItem);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (this.Parent is Form)
            {
                (this.Parent as Form).FormBorderStyle = m_bAutoSizeParent ? FormBorderStyle.FixedDialog : (this.Parent as Form).FormBorderStyle;
            }


            int w = (int)Math.Abs(TopLeft.X - TopRight.X);
            int h = (int)Math.Abs(TopLeft.Y - BottomLeft.Y);

            // The basic
            ucCanvas.OriginPoint(m_nSpaceX, m_nSpaceY);

            ucCanvas.ScaleFactor = m_scaleCanvasDefault; 
            if (this.Parent.ClientSize.Width < w)
            {
                float fTempScale = (float)(this.Parent.ClientSize.Width) / (float)(w + 50);
                //ucCanvas.ScaleFactor = fTempScale > 0.5f ? fTempScale : 0.5f;
                ucCanvas.ScaleFactor = fTempScale;
            }
                
            m_scaleCanvas = ucCanvas.ScaleFactor;
            ucCanvas.Scrollable = Scrollable;

            // Preliminary calculation the size
            int nSpaceX = 10;
            int nSpaceY = 10;

            //int w = (int)Math.Abs(TopLeft.X - TopRight.X);
            //int h = (int)Math.Abs(TopLeft.Y - BottomLeft.Y);

            w += (int)(2 * nSpaceX);
            h += (int)(2 * nSpaceY);

            w = (int)(w * m_scaleCanvas);
            h = (int)(h * m_scaleCanvas);

            this.ClientSize = new Size(w, h);

            if (this.Parent != null)
            {
                if (this.Parent is Form)
                {
                    this.Parent.ClientSize = this.ClientSize; // Make it nice
                    this.Parent.Invalidate();
                }
            }

            sizeScaleOne = new SizeF(this.ClientSize.Width / m_scaleCanvas, this.ClientSize.Height / m_scaleCanvas); // Very first time calculated

            if (chkView.Checked)
                UpdateClientSize();
            else
                this.Size = new Size(this.Size.Width, 50);

            this.Select();
        }

        private void MoveUp()
        {
            if (DragValid(0, -5))
            {
                ucCanvas.MoveY(-5);
                m_nPinX = ucCanvas.OriginX;
                m_nPinY = ucCanvas.OriginY;
            }
        }

        private void MoveDown()
        {
            if (DragValid(0, +5))
            {
                ucCanvas.MoveY(+5);
                m_nPinX = ucCanvas.OriginX;
                m_nPinY = ucCanvas.OriginY;
            }
        }
        
        private void MoveLeft()
        {
            if (DragValid(-5, 0))
            {
                ucCanvas.MoveX(-5);
                m_nPinX = ucCanvas.OriginX;
                m_nPinY = ucCanvas.OriginY;
            }
        }

        private void MoveRight()
        {
            if (DragValid(+5, 0))
            {
                ucCanvas.MoveX(+5);
                m_nPinX = ucCanvas.OriginX;
                m_nPinY = ucCanvas.OriginY;
            }
        }

        private void ZoomIncrease() 
        {
            Zoom(true);
        }

        private void ZoomDecrease()
        {
            Zoom(false);
        }

        private void Zoom(bool bIncrease)
        {
            float dScale = ucCanvas.ScaleFactor + (bIncrease ? 0.1f : -0.1f);
            dScale = dScale < m_scaleCanvasDefault/2f ? m_scaleCanvasDefault/2f : dScale;
            ucCanvas.ScaleFactor = dScale;
            m_scaleCanvas = ucCanvas.ScaleFactor;
            UpdateClientSize();
        }

        private void EventScaled(float scale)
        {           
            m_scaleCanvas = scale;
            UpdateClientSize();
        }

        private void UpdateClientSize()
        {
            //if (this.Parent.ClientSize.Width < this.ClientSize.Width)
            //{
            //    pnlView.AutoScroll = false;
            //    pnlView.HorizontalScroll.Enabled = true;
            //    pnlView.HorizontalScroll.Visible = true;
            //    pnlView.HorizontalScroll.Minimum = 0;
            //    pnlView.HorizontalScroll.Maximum = this.ClientSize.Width;
            //    pnlView.Scroll += pnlView_Scroll;
            //    pnlView.AutoScroll = true;
            //}
            //else
            //{
            //    pnlView.AutoScroll = false;
            //    pnlView.HorizontalScroll.Visible = false;
            //}

            this.ClientSize = new Size((int)(sizeScaleOne.Width * m_scaleCanvas), (int)(sizeScaleOne.Height * m_scaleCanvas) + 60);
            if (this.Parent is Form && m_bAutoSizeParent)
            {
                this.Parent.ClientSize = this.ClientSize;
            }
        }

        private void EventDragged(float dX, float dY) 
        { 
            ucCanvas.OriginPoint(ucCanvas.OriginX, ucCanvas.OriginY);
            m_nPinX = ucCanvas.OriginX;
            m_nPinY = ucCanvas.OriginY;
            m_scaleCanvas = ucCanvas.ScaleFactor;
        }

        private void EventBeforeDragged(float dX, float dY)
        {
            float w = m_cLadderStep.TopRight.X - m_cLadderStep.TopLeft.X;
            float h = m_cLadderStep.BottomLeft.Y - m_cLadderStep.TopLeft.Y;

            float left = ucCanvas.OriginX + dX;
            float right = left + w;
            float top = ucCanvas.OriginY + dY;
            float bottom = top + h;

            ucCanvas.Dragable = DragValid(dX, dY);
        }

        private bool DragValid(float dX, float dY)
        {
            float w = m_cLadderStep.TopRight.X - m_cLadderStep.TopLeft.X;
            float h = m_cLadderStep.BottomLeft.Y - m_cLadderStep.TopLeft.Y;

            float left = ucCanvas.OriginX + dX;
            float right = left + w;
            float top = ucCanvas.OriginY + dY;
            float bottom = top + h;

            return !CheckOutside(left, top, right, bottom, null);
        }

        private bool CheckOutside(float left, float top, float right, float bottom, float? scaleCustom)
        {
            float scale = scaleCustom.HasValue ? scaleCustom.Value : ucCanvas.ScaleFactor;
            float wClient = (this.ClientSize.Width / scale) - m_nSpaceX;
            float hClient = (this.ClientSize.Height / scale) - m_nSpaceY;

            if (this.Parent is Form)

            if (bottom < m_nSpaceY) { return true; }
            else if (top > hClient) { return true; }
            else if (right < m_nSpaceX) { return true; }
            else if (left > wClient) { return true; }

            return false;
        }

        private bool CheckInsideAll(float left, float top, float right, float bottom, float? scaleCustom)
        {
            float scale = scaleCustom.HasValue ? scaleCustom.Value : ucCanvas.ScaleFactor;
            float wClient = (this.ClientSize.Width / scale) - m_nSpaceX;
            float hClient = (this.ClientSize.Height / scale) - m_nSpaceY;

            if ((top >= m_nSpaceY) && (bottom <= hClient) && (left >= m_nSpaceX) && (right <= wClient)) { return true; }

            return false;
        }

        private void Reset()
        {
            m_cLadderStep.Reset();
            ucCanvas.OriginPoint(m_nSpaceX, m_nSpaceY);
            ucCanvas.Reset();
            m_nPinX = ucCanvas.OriginX;
            m_nPinY = ucCanvas.OriginY;
            ucCanvas.ScaleFactor = m_scaleCanvasDefault;
            m_scaleCanvas = ucCanvas.ScaleFactor;
            UpdateClientSize();
        }

        private void DefaultPosition()
        {
            ucCanvas.OriginPoint(m_nSpaceX, m_nSpaceY);
            m_nPinX = ucCanvas.OriginX;
            m_nPinY = ucCanvas.OriginY;
        }

        private void m_cLadderStep_UEventItemClick(CLadderCell cLadderCellCursor)
        {
            Point pointCursor = m_cLadderStep.GetCellOrigin(cLadderCellCursor.Row, cLadderCellCursor.Column);

            float x = pointCursor.X + ucCanvas.OriginX;
            float y = pointCursor.Y + ucCanvas.OriginY;

            float wClient = (this.ClientSize.Width / ucCanvas.ScaleFactor);
            float hClient = (this.ClientSize.Height / ucCanvas.ScaleFactor);

            if (x < 0) { ucCanvas.OriginPoint(ucCanvas.OriginX - x + m_nSpaceX, ucCanvas.OriginY); }
            if ((x + m_cLadderStep.CellWidth) > wClient) { ucCanvas.OriginPoint(ucCanvas.OriginX - ((x + m_cLadderStep.CellWidth) - wClient) - m_nSpaceX, ucCanvas.OriginY); }
            if (y < 0) { ucCanvas.OriginPoint(ucCanvas.OriginX, ucCanvas.OriginY - y + m_nSpaceY); }
            if ((y + m_cLadderStep.CellHeight) > hClient) { ucCanvas.OriginPoint(ucCanvas.OriginX, ucCanvas.OriginY - ((y + m_cLadderStep.CellHeight) - hClient) - m_nSpaceY); }
        }

        private void m_cLadderStep_UEventItemDoubleClick(CLadderCell cLadderCellCursor)
        {
            if (UEventSelectedCellData != null)
            {
                CLadderCellData cData = (CLadderCellData)cLadderCellCursor;
                
                if (!(cData.Data is CContact)) return;

                CContact cContact = (CContact)cData.Data;
                int iCount = cContact.ContentS.Count;
                if (iCount > 0)
                {
                    if (iCount == 1)
                    {
                        //이벤트 발생
                        CTag cSelectTag = cContact.ContentS[0].Tag;
                        UEventSelectedCellData(cSelectTag, StepLevel, SymbolLogS);
                    }
                    else if(iCount == 2)
                    {
                        //Bit일 경우
                        if(cContact.ContactType == EMContactType.Bit)
                        {
                            CTag cSelectTag = cContact.ContentS[0].Tag;
                            UEventSelectedCellData(cSelectTag, StepLevel, SymbolLogS);
                        }

                        //Compare일 경우
                        else if(cContact.ContactType == EMContactType.Compare)
                        {
                            CTag cFirstTag = cContact.ContentS[0].Tag;
                            CTag cSndTag = cContact.ContentS[1].Tag;
                            
                            // Content가 모두 접점인 경우
                            if (cFirstTag != null && cSndTag != null) 
                            {
                                string sDlg = string.Format("선택한 Contact에는 두개의 접점이 존재합니다.\n접점을 선택해주세요.\n\n      Yes({0})   /   No({1})",cFirstTag.Address, cSndTag.Address);

                                DialogResult dlgResult = XtraMessageBox.Show(sDlg, "UDM Tracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      
                                if (dlgResult == DialogResult.Yes)
                                {
                                    UEventSelectedCellData(cFirstTag, StepLevel, SymbolLogS);
                                }
                                else
                                {
                                    UEventSelectedCellData(cSndTag, StepLevel, SymbolLogS);
                                }
                            }

                            // 첫번째 Content가 상수인 경우
                            else if (cFirstTag == null && cSndTag != null) 
                            {
                                UEventSelectedCellData(cSndTag, StepLevel, SymbolLogS);
                            }

                            // 두번째 Content가 상수인 경우
                            else if (cFirstTag != null && cSndTag == null) 
                            {
                                UEventSelectedCellData(cFirstTag, StepLevel, SymbolLogS);
                            }

                            //else if (cFirstTag == null && cSndTag == null)
                            //{
                            //    string sFirstData = cContact.ContentS[0].Argument;
                            //    string sSecond = cContact.ContentS[1].Argument;
                            //    //미쓰비시만 적용 
                            //    if (sFirstData.Contains("K") && sSecond.Contains("K"))
                            //    {
                            //        //상수판단
                            //        CDDEASymbol cSymbol = new CDDEASymbol();
                            //        bool bOK = cSymbol.CreateMelsecDDEASymbol(sFirstData);
                            //        bOK = cSymbol.CreateMelsecDDEASymbol(sSecond);
                            //    }
                            //}
                        }
                    }
                }
            }
        }

        private void m_cLadderStep_UEventItemRightDoubleClick(CLadderCell cLadderCellCursor)
        {
            try
            {
                if (UEventRightSelectedCellData != null)
                {
                    CLadderCellData cData = (CLadderCellData)cLadderCellCursor;

                    if (!(cData.Data is CContact)) return;

                    CContact cContact = (CContact)cData.Data;
                    int iCount = cContact.ContentS.Count;
                    if (iCount > 0)
                    {
                        if (iCount == 1)
                        {
                            //이벤트 발생
                            CTag cSelectTag = cContact.ContentS[0].Tag;
                            UEventRightSelectedCellData(cSelectTag, StepLevel, SymbolLogS);
                        }
                        else if (iCount == 2)
                        {
                            //Bit일 경우
                            if (cContact.ContactType == EMContactType.Bit)
                            {
                                CTag cSelectTag = cContact.ContentS[0].Tag;
                                UEventRightSelectedCellData(cSelectTag, StepLevel, SymbolLogS);
                            }

                            //Compare일 경우
                            else if (cContact.ContactType == EMContactType.Compare)
                            {
                                CTag cFirstTag = cContact.ContentS[0].Tag;
                                CTag cSndTag = cContact.ContentS[1].Tag;

                                // Content가 모두 접점인 경우
                                if (cFirstTag != null && cSndTag != null)
                                {
                                    string sDlg = string.Format("선택한 Contact에는 두개의 접점이 존재합니다.\n접점을 선택해주세요.\n\n      Yes({0})   /   No({1})", cFirstTag.Address, cSndTag.Address);

                                    DialogResult dlgResult = XtraMessageBox.Show(sDlg, "UDM Tracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                                    if (dlgResult == DialogResult.Yes)
                                    {
                                        UEventRightSelectedCellData(cFirstTag, StepLevel, SymbolLogS);
                                    }
                                    else
                                    {
                                        UEventRightSelectedCellData(cSndTag, StepLevel, SymbolLogS);
                                    }
                                }

                                // 첫번째 Content가 상수인 경우
                                else if (cFirstTag == null && cSndTag != null)
                                {
                                    UEventRightSelectedCellData(cSndTag, StepLevel, SymbolLogS);
                                }

                                // 두번째 Content가 상수인 경우
                                else if (cFirstTag != null && cSndTag == null)
                                {
                                    UEventRightSelectedCellData(cFirstTag, StepLevel, SymbolLogS);
                                }

                                //else if (cFirstTag == null && cSndTag == null)
                                //{
                                //    string sFirstData = cContact.ContentS[0].Argument;
                                //    string sSecond = cContact.ContentS[1].Argument;
                                //    //미쓰비시만 적용 
                                //    if (sFirstData.Contains("K") && sSecond.Contains("K"))
                                //    {
                                //        //상수판단
                                //        CDDEASymbol cSymbol = new CDDEASymbol();
                                //        bool bOK = cSymbol.CreateMelsecDDEASymbol(sFirstData);
                                //        bOK = cSymbol.CreateMelsecDDEASymbol(sSecond);
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bCaptured = false;
            if (keyData == Keys.Left) { m_cLadderStep.MoveCursorLeft(); bCaptured = true; }
            else if (keyData == Keys.Right) { m_cLadderStep.MoveCursorRight(); bCaptured = true; }
            else if (keyData == Keys.Up) { m_cLadderStep.MoveCursorUp(); bCaptured = true; }
            else if (keyData == Keys.Down) { m_cLadderStep.MoveCursorDown(); bCaptured = true; }
            else if (keyData == Keys.Escape) { Reset(); bCaptured = true; }
            else if (keyData == Keys.F2) { DefaultPosition(); bCaptured = true; }
            else if (keyData == (Keys.Control | Keys.Up)) { ZoomIncrease(); bCaptured = true; }
            else if (keyData == (Keys.Control | Keys.Down)) { ZoomDecrease(); bCaptured = true; }
            else if (keyData == (Keys.Shift | Keys.Up)) { MoveUp(); bCaptured = true; }
            else if (keyData == (Keys.Shift | Keys.Down)) { MoveDown(); bCaptured = true; }
            else if (keyData == (Keys.Shift | Keys.Left)) { MoveLeft(); bCaptured = true; }
            else if (keyData == (Keys.Shift | Keys.Right)) { MoveRight(); bCaptured = true; }

            if (bCaptured) 
            { 
                //ucCanvas.Invalidate(); 
                return true;  
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkView.Checked)
                UpdateClientSize();
            else
                this.Size = new Size(this.Size.Width, 50);
        }

        private void chkScrollable_CheckedChanged(object sender, EventArgs e)
        {
            Scrollable = chkScrollable.Checked;
            ucCanvas.Scrollable = Scrollable;
            if (Scrollable)
                pnlView.Select();
        }

        private void lblText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chkView.Checked = !chkView.Checked;
        }

        private void pnlText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            chkView.Checked = !chkView.Checked;
        }

        private void UCLadderStep_Resize(object sender, EventArgs e)
        {
            pnlText.Width = this.Width;
            float nSize = pnlText.Width;
            FontFamily fontFamily = lblText.Font.FontFamily;
            float nFontSize = (float)nSize / 80f;
            if (nFontSize < 0.1f)
                nFontSize = 0.1f;

            Font fontText = new Font(fontFamily, nFontSize * 0.75f, FontStyle.Bold);

            if (fontText.Size < 11)
                fontText = new Font(fontFamily, 11, FontStyle.Bold);

            else if (fontText.Size > 15)
                fontText = new Font(fontFamily, 15, FontStyle.Bold);

            lblText.Font = fontText;
            pnlText.Height = (int)(fontText.Height * 2);
        }

        private void pnlText_MouseUp(object sender, MouseEventArgs e)
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

        private void pnlText_MouseMove(object sender, MouseEventArgs e)
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

        private void pnlText_MouseDown(object sender, MouseEventArgs e)
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

        private void ucCanvas_MouseDown(object sender, MouseEventArgs e)
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

        private void ucCanvas_MouseUp(object sender, MouseEventArgs e)
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

        private void ucCanvas_MouseMove(object sender, MouseEventArgs e)
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

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            m_scaleCanvas = m_scaleCanvas + 0.1f;

            if (m_scaleCanvas > 2f) m_scaleCanvas = 2f;

            ucCanvas.ScaleFactor = m_scaleCanvas;
            UpdateClientSize();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            m_scaleCanvas = m_scaleCanvas - 0.1f;
            if (m_scaleCanvas < 0.5f) m_scaleCanvas = 0.5f;

            ucCanvas.ScaleFactor = m_scaleCanvas;
            UpdateClientSize();
        }

        #endregion
    }
}
