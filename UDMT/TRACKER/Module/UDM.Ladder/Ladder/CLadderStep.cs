using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.Log;
using System.Text.RegularExpressions;

namespace UDM.Ladder
{
    public enum EditorBrand { AB = 0, SIEMENS, MELSEC, Common };
    public delegate void EventHandlerCursorChanged(CLadderCell cLadderCellCursor);
    public delegate void EventHandlerUpdated();

    public class CLadderStep : CCanvasItem, IDisposable
    {
        #region Private Members

        private CStep m_cStep = null;
        private CTimeLogS m_cSymbolLogS = null;
        private Dictionary<ITagComposable, CLadderCell> m_dicItemLadderCell = new Dictionary<ITagComposable, CLadderCell>();
        private Dictionary<int, HashSet<int>> m_dicRowColumnOccupied = new Dictionary<int, HashSet<int>>();
        private HashSet<CLadderCell> m_hashCells = new HashSet<CLadderCell>();
        private HashSet<CLadderCell> m_hashCellsSelected = new HashSet<CLadderCell>();
        private CLadderCell m_cLadderCellSelectedCursor = null;
        private AlignVertical m_eAllignVertical = AlignVertical.TOP;
        private AlignHorizontal m_eAllignHorizontal = AlignHorizontal.LEFT;
        private int m_nOffsetVertical = 0;
        private int m_nOffsetHorizontal = 0;
        private int m_nCellWidth = 0;
        private int m_nCellHeight = 0;
        private int m_nIndexRowMax = 0;
        private int m_nIndexColumnMax = 0;
        private int m_nGapCoilToMaxCol = 2;
        private Pen m_penLine = new Pen(Color.Black);
        private static CLadderBrand m_cLadderBrand = new CLadderBrand();
        private CLadderCellData m_cLadderCellDataCoil = null;
        private Point m_pointCoil;

        private List<CLadderCellData> m_lstLadderCellDataFB = null;

        #endregion

        #region Public Enum

        public enum AlignVertical { MIDDLE = 0, TOP, BOTTOM }
        public enum AlignHorizontal { MIDDLE = 0, LEFT, RIGHT }
        
        #endregion

        #region Public Properties

        public int CellWidth { get { return m_nCellWidth; } set { m_nCellWidth = value; } }
        public int CellHeight { get { return m_nCellHeight; } set { m_nCellHeight = value; } }
        public AlignVertical AllignmentVertical { get { return m_eAllignVertical; } set { m_eAllignVertical = value; AllignVertical(); } }
        public AlignHorizontal AllignmentHorizontal { get { return m_eAllignHorizontal; } set { m_eAllignHorizontal = value; AllignHorizontal(); } }
        public CStep Step { get { return m_cStep; } set { m_cStep = value; Update(); } }
        public CTimeLogS SymbolLogS { get { return m_cSymbolLogS; } set { m_cSymbolLogS = value; Update(); } }
        public Pen Pen { get { return m_penLine; } set { m_penLine = value; } }
        public EditorBrand EditorBrand { get { return m_cLadderBrand.Brand; } set { m_cLadderBrand.Brand = value; Update(); } }
        
        public CVertex TopLeft { get { return m_cVertexSBoundingBoxes[0]; } }
        public CVertex TopRight { get { return m_cVertexSBoundingBoxes[1]; } }
        public CVertex BottomRight { get { return m_cVertexSBoundingBoxes[2]; } }
        public CVertex BottomLeft { get { return m_cVertexSBoundingBoxes[3]; } }

        public CLadderCell LastSelectedCell { get { return m_cLadderCellSelectedCursor; } }

        public Dictionary<ITagComposable, CLadderCell> ItemLadderCell { get { return m_dicItemLadderCell; } }

        public event EventHandlerCursorChanged UEventItemClick = null;
        public event EventHandlerCursorChanged UEventItemRightClick = null;
        public event EventHandlerCursorChanged UEventItemDoubleClick = null;
        public event EventHandlerCursorChanged UEventItemRightDoubleClick = null;

        public event EventHandlerUpdated Updated;

        #endregion

        #region Public Methods

        public CLadderStep(CStep cStep) 
            : this()
        {
            m_cStep = cStep;
        }

        public CLadderStep()
        {
            m_nCellWidth = 100;
            m_nCellHeight = 100;
            AllignmentVertical = AlignVertical.MIDDLE;
            AllignmentHorizontal = AlignHorizontal.MIDDLE;
            m_cStep = null;
            m_penLine.Width *= 2;

            m_cLadderBrand = new CLadderBrand();
            m_cLadderBrand.DateFormat = "yyyy-MM-dd\nHH:mm:ss;fff";//"HH:mm:ss;fff";
            m_cLadderBrand.Pen = m_penLine;

            m_cVertexSBoundingBoxes.Add(new CVertex(0, 0)); // 0
            m_cVertexSBoundingBoxes.Add(new CVertex(0, 0)); // 1
            m_cVertexSBoundingBoxes.Add(new CVertex(0, 0)); // 2
            m_cVertexSBoundingBoxes.Add(new CVertex(0, 0)); // 3
        }

        private void ExcuteClick(int x, int y, System.Windows.Forms.Keys k, bool bDoubleClick, bool bLeft)
        {

            if (k != System.Windows.Forms.Keys.Control)
            {
                m_hashCellsSelected.Clear();
            }

            if (m_hashCells.Count < 1) { return; }

            foreach (CLadderCell cell in m_hashCells)
            {
                if (!cell.Selectable) { continue; }
                for (int i = cell.Row; i < cell.Row + cell.RowOccupied; i++)
                {
                    for (int j = cell.Column; j < cell.Column + cell.ColumnOccupied; j++)
                    {
                        if (IsInsideCell(x, y, i, j))
                        {
                            if (k != System.Windows.Forms.Keys.Control)
                            {
                                m_cLadderCellSelectedCursor = cell;
                                if (bDoubleClick == false)
                                {
                                    if (bLeft)
                                    {
                                        if (UEventItemClick != null)
                                            UEventItemClick(m_cLadderCellSelectedCursor);
                                    }
                                    else
                                    {
                                        if (UEventItemRightClick != null)
                                            UEventItemRightClick(m_cLadderCellSelectedCursor);
                                    }
                                }
                                else
                                {
                                    if (bLeft)
                                    {
                                        if (UEventItemDoubleClick != null)
                                            UEventItemDoubleClick(m_cLadderCellSelectedCursor);
                                    }
                                    else
                                    {
                                        if (UEventItemRightDoubleClick != null)
                                            UEventItemRightDoubleClick(m_cLadderCellSelectedCursor);
                                    }
                                }
                            }
                            else
                            {
                                if (m_hashCellsSelected.Contains(cell))
                                {
                                    m_hashCellsSelected.Remove(cell);
                                }
                                else
                                {
                                    m_hashCellsSelected.Add(cell);
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }

        public override void OnClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {
            ExcuteClick(x, y, k, false, true);
        }

        public override void OnDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {
            ExcuteClick(x, y, k, true, true);
        }

        public override void OnRClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {
            ExcuteClick(x, y, k, false, false);
        }

        public override void OnRDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {
            ExcuteClick(x, y, k, true, false);
        }

        public Point GetCellOrigin(int r, int c) // WCS -> x+ => column direction+, y => row direction+ 
        {
            return new Point(m_cVertexOrigin.X + c * m_nCellWidth, m_cVertexOrigin.Y + r * m_nCellHeight);
        }

        public bool IsInsideCell(int x, int y, int r, int c)
        {
            Point point = GetCellOrigin(r, c);

            if (x < point.X || x > (point.X + m_nCellWidth) || y < point.Y || y > (point.Y + m_nCellHeight))
            {
                return false;
            }

            return true;
        }

        public CLadderCell GetActiveCell(int r, int c)
        {
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                if ((cLadderCell.Row == r) && (cLadderCell.Column == c))
                {
                    return cLadderCell;
                }
            }

            return null;
        }

        public void MoveCursorRight()
        {
            if (m_cLadderCellSelectedCursor != null)
                UpdateCursor(FindSiblingActiveCellColumn(m_cLadderCellSelectedCursor.Row, m_cLadderCellSelectedCursor.Column, false));
        }

        public void MoveCursorLeft()
        {
            if (m_cLadderCellSelectedCursor != null)
                UpdateCursor(FindSiblingActiveCellColumn(m_cLadderCellSelectedCursor.Row, m_cLadderCellSelectedCursor.Column, true));
        }

        public void MoveCursorDown()
        {
            if (m_cLadderCellSelectedCursor != null)
                UpdateCursor(FindSiblingActiveCellRow(m_cLadderCellSelectedCursor.Row, m_cLadderCellSelectedCursor.Column, false));
        }

        public void MoveCursorUp()
        {
            if (m_cLadderCellSelectedCursor != null)
                UpdateCursor(FindSiblingActiveCellRow(m_cLadderCellSelectedCursor.Row, m_cLadderCellSelectedCursor.Column, true));
        }

        public CLadderCell GetLadderCell(ITagComposable cItem)
        {
            CLadderCell cLadderCell = null;
            if (m_dicItemLadderCell.ContainsKey(cItem))
            {
                cLadderCell = m_dicItemLadderCell[cItem];
            }

            return cLadderCell;
        }

        public CTag GetTagFromSelectedLadder()
        {
            CTag cTag = null;
            int iCol = -1;
            if (m_cLadderCellSelectedCursor != null)
            {
                iCol = m_cLadderCellSelectedCursor.Column;
            }
            List<ITagComposable> lstTag = m_dicItemLadderCell.Where(b => b.Value.Column == iCol).Select(b => b.Key).ToList();
            for (int i = 0; i < lstTag.Count; i++)
            {
                foreach (CContact cContact in m_cStep.ContactS)
                {
                    if (lstTag[i] == cContact)
                    {
                        if (cContact.RefTagS.Count > 0)
                        {
                            cTag = cContact.RefTagS[0];
                            break;
                        }
                    }
                }
            }
            return cTag;
        }

        public void Reset()
        {
            if (m_hashCellsSelected != null) { m_hashCellsSelected.Clear(); }
        }

        public override void Draw(Graphics graphics)
        {
            try
            {
                // If nothing ...
                if (m_hashCells.Count < 1) { return; }

                // Rung line start-stop
                if (m_cVertexSBoundingBoxes.Count == 4)
                {
                    Pen penRung = new Pen(Color.Black, m_penLine.Width * 2); 
                    // 시작 "|" 그리는 부분
                    graphics.DrawLine(penRung, m_cVertexSBoundingBoxes[0].X, m_cVertexSBoundingBoxes[0].Y, m_cVertexSBoundingBoxes[3].X, m_cVertexSBoundingBoxes[3].Y);

                    // 마지막 "●" 그리는 부분
#if CUSTOM_PAJU
                    if (m_cLadderCellDataCoil.Row > 0)
                        graphics.FillEllipse(new SolidBrush(Color.Black), new RectangleF(m_cVertexSBoundingBoxes[2].X - 6 * 2, m_cVertexSBoundingBoxes[1].Y + 0.5f * m_nCellHeight * 3 - 6, 6 * 2, 6 * 2));

                    graphics.FillEllipse(new SolidBrush(Color.Black), new RectangleF(m_cVertexSBoundingBoxes[2].X - 6*2, m_cVertexSBoundingBoxes[1].Y + 0.5f * m_nCellHeight - 6, 6 * 2, 6 * 2));
#else
                    graphics.DrawLine(penRung, m_cVertexSBoundingBoxes[1].X, m_cVertexSBoundingBoxes[1].Y, m_cVertexSBoundingBoxes[2].X, m_cVertexSBoundingBoxes[2].Y);
#endif
                    
                    penRung.Dispose();
                }

                // Basic shape
                DrawCellS(graphics);

                // The connection
                DrawConnection(graphics);

                // Selected cellS
                DrawSelectedCellS(graphics);

                // Selected cell cursor
                DrawSelectedCellCursor(graphics);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        public void Dispose()
        {
            m_penLine.Dispose();
        }

        #endregion

        #region Private Methods

        private void Update()
        {
            GenerateCells();
            CalculateBoundingBoxes();
            GenerateConnection();
            if (Updated != null) { Updated(); } 
        }

        private void UpdateCursor(CLadderCell cNewLadderCellCursor)
        {
            if (cNewLadderCellCursor != null)
            {
                m_cLadderCellSelectedCursor = cNewLadderCellCursor;
                if (UEventItemClick != null) { UEventItemClick(m_cLadderCellSelectedCursor); }
                if (UEventItemRightClick != null) { UEventItemRightClick(m_cLadderCellSelectedCursor); }
            }
        }

        public CLadderCell FindSiblingActiveCellRow(int r, int c, bool bDecrease)
        {
            CLadderCell cLadderCellSibling = null;
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                if (cLadderCell.Column != c) { continue; }
                if (bDecrease)
                {
                    if (cLadderCell.Row >= r) { continue; }
                    cLadderCellSibling = cLadderCellSibling == null ? cLadderCell : (cLadderCell.Row > cLadderCellSibling.Row ? cLadderCell : cLadderCellSibling);
                }
                else
                {
                    if (cLadderCell.Row <= r) { continue; }
                    cLadderCellSibling = cLadderCellSibling == null ? cLadderCell : (cLadderCell.Row < cLadderCellSibling.Row ? cLadderCell : cLadderCellSibling);
                }
            }

            // If null, it automatically finds the nearest active column in neighbouring row
            int nNext = bDecrease ? r - 1 : r + 1;
            if (((nNext > -1) && (nNext < (m_nIndexRowMax + 1))) && (cLadderCellSibling == null))
            {
                cLadderCellSibling = FindSiblingActiveCellColumn(nNext, c, true);
            }

            return cLadderCellSibling;
        }

        private CLadderCell FindSiblingActiveCellColumn(int r, int c, bool bDecrease)
        {
            CLadderCell cLadderCellSibling = null;
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                if (!cLadderCell.Selectable) { continue; }
                if (cLadderCell.Row != r) { continue; }
                if (bDecrease)
                {
                    if (cLadderCell.Column >= c) { continue; }
                    cLadderCellSibling = cLadderCellSibling == null ? cLadderCell : (cLadderCell.Column > cLadderCellSibling.Column ? cLadderCell : cLadderCellSibling);
                }
                else
                {
                    if (cLadderCell.Column <= c) { continue; }
                    cLadderCellSibling = cLadderCellSibling == null ? cLadderCell : (cLadderCell.Column < cLadderCellSibling.Column ? cLadderCell : cLadderCellSibling);
                }

            }

            // If null, it automatically finds the nearest active row in neighbouring column
            int nNext = bDecrease ? c - 1 : c + 1;
            if (((nNext > -1) && (nNext < (m_nIndexColumnMax + 1))) && (cLadderCellSibling == null))
            {
                cLadderCellSibling = FindSiblingActiveCellRow(r, nNext, true);
            }

            return cLadderCellSibling;
        }

        private void DrawSelectedCellCursor(Graphics graphics)
        {
            if (m_cLadderCellSelectedCursor == null) { return; }

            // Brush
            Brush brush = new SolidBrush(Color.FromArgb(50, Color.Blue));
            int? r, l, b, t;
            r = l = b = t = null;

            // Find the bounding box
            for (int i = m_cLadderCellSelectedCursor.Row; i < m_cLadderCellSelectedCursor.Row + m_cLadderCellSelectedCursor.RowOccupied; i++)
            {
                for (int j = m_cLadderCellSelectedCursor.Column; j < m_cLadderCellSelectedCursor.Column + m_cLadderCellSelectedCursor.ColumnOccupied; j++)
                {
                    Point point = GetCellOrigin(i, j);
                    int pointW = point.X + m_nCellWidth;
                    int pointH = point.Y + m_nCellHeight;

                    l = l.HasValue ? (point.X < l ? point.X : l) : point.X;
                    r = r.HasValue ? (pointW > r ? pointW : r) : pointW;
                    t = t.HasValue ? (point.Y < t ? point.Y : t) : point.Y;
                    b = b.HasValue ? (pointH > b ? pointH : b) : pointH;
                }
            }

            // The selected area
            Rectangle rect = new Rectangle(l.Value, t.Value, r.Value - l.Value, b.Value - t.Value);
            graphics.FillRectangle(brush, rect);

            // Border rectangle
            Pen pen = new Pen(Color.Red, m_penLine.Width);
            graphics.DrawRectangle(pen, rect);
            pen.Dispose();

            // Dispose
            brush.Dispose();
        }

        private void DrawSelectedCellS(Graphics graphics)
        {
            foreach (CLadderCell cell in m_hashCellsSelected)
            {
                // Brush
                Brush brush = new SolidBrush(Color.FromArgb(50, Color.Blue));
                int? r, l, b, t;
                r = l = b = t = null;

                // Find the bounding box
                for (int i = cell.Row; i < cell.Row + cell.RowOccupied; i++)
                {
                    for (int j = cell.Column; j < cell.Column + cell.ColumnOccupied; j++)
                    {
                        Point point = GetCellOrigin(i, j);
                        int pointW = point.X + m_nCellWidth;
                        int pointH = point.Y + m_nCellHeight;

                        l = l.HasValue ? (point.X < l ? point.X : l) : point.X;
                        r = r.HasValue ? (pointW > r ? pointW : r) : pointW;
                        t = t.HasValue ? (point.Y < t ? point.Y : t) : point.Y;
                        b = b.HasValue ? (pointH > b ? pointH : b) : pointH;
                    }
                }

                // The selected area
                Rectangle rect = new Rectangle(l.Value, t.Value, r.Value - l.Value, b.Value - t.Value);
                graphics.FillRectangle(brush, rect);

                // Border rectangle
                Pen pen = new Pen(Color.Blue, m_penLine.Width);
                graphics.DrawRectangle(pen, rect);
                pen.Dispose();

                // Dispose
                brush.Dispose();
            }
        }

        private void DrawCellS(Graphics graphics)
        {
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                if (cLadderCell is CLadderCellData) { DrawCellData(graphics, cLadderCell as CLadderCellData); }
                else if (cLadderCell is CLadderCellConnector) { DrawCellConnector(graphics, cLadderCell as CLadderCellConnector); }
            }
        }

        private void DrawCellConnector(Graphics graphics, CLadderCellConnector cLadderCellConnector)
        {
            // The point (x,y) is the CENTER of the cell rectangular (if cell occupied > 0, the point is the CENTER of first cell rect)
            Point point = GetCellOrigin(cLadderCellConnector.Row, cLadderCellConnector.Column);
            graphics.DrawLine(m_penLine, point.X, point.Y + m_nOffsetVertical, point.X + m_nCellWidth, point.Y + m_nOffsetVertical);
        }

        private void DrawCellData(Graphics graphics, CLadderCellData cLadderCellData)
        {
            // The point (x,y) is the CENTER of the cell rectangular (if cell occupied > 0, the point is the CENTER of first cell rect)
            Point point = GetCellOrigin(cLadderCellData.Row, cLadderCellData.Column);
            point.X += m_nOffsetHorizontal;
            point.Y += m_nOffsetVertical;

            CLadderItem element = null;

            CContact cContact = cLadderCellData.Data as CContact;
            CCoil cCoil = cLadderCellData.Data as CCoil;
            CFB_Info cFB_Info = cLadderCellData.Data as CFB_Info;


            CTimeLog cSymbolLogData = null;
            CTimeLogS cSymbolLogDataS = null;
            if (m_cSymbolLogS != null)
            {
                cSymbolLogDataS = new CTimeLogS();

                if (cContact != null)
                {
                    if (cContact.ContactType.Equals(EMContactType.Bit) || cContact.ContactType.Equals(EMContactType.Function)) //|| cContact.ContactType.Equals(EMContactType.Compare)
                    {
                        foreach (CTimeLog cLog in m_cSymbolLogS)
                        {
                            if (cContact.RefTagS.ContainsKey(cLog.Key))
                            {
                                cSymbolLogData = cLog;
                                cSymbolLogDataS.Add(cLog);
                                //break;
                            }
                        }
                    }
                    else if (cContact.ContactType.Equals(EMContactType.Compare))
                    {
                        foreach (CTimeLog cLog in m_cSymbolLogS)
                        {
                            if (cContact.RefTagS.ContainsKey(cLog.Key))
                            {
                                cSymbolLogDataS.Add(cLog);
                            }
                        }
                    }
                    //else
                    //    cWordLogS = m_cSymbolLogS.GetTimeLogS(cContact.RefTagS.KeyList);
                }
                else if (cCoil != null)
                {
                    if (cCoil.CoilType.Equals(EMCoilType.Bit))// || cCoil.CoilType.Equals(EMCoilType.Counter) || cCoil.CoilType.Equals(EMCoilType.Timer))
                    {
                        foreach (CTimeLog cLog in m_cSymbolLogS)
                        {
                            if (cCoil.RefTagS.ContainsKey(cLog.Key))
                            {
                                cSymbolLogData = cLog;
                                cSymbolLogDataS.Add(cLog);
                                //break;
                            }
                        }
                    }

                    else
                    {
                        foreach (CTimeLog cLog in m_cSymbolLogS)
                        {
                            if (cCoil.RefTagS.ContainsKey(cLog.Key))
                            {
                                cSymbolLogDataS.Add(cLog);
                            }
                        }
                    }
                    //else
                    //    cWordLogS = m_cSymbolLogS.GetTimeLogS(cCoil.RefTagS.KeyList);
                }
            }
            if (cContact != null)
            {                
                // DUMMY TESTER ...
                //if (m_cSymbolLogS != null)
                //{
                //    if (m_cSymbolLogS.Count > 0)
                //    {
                //        cSymbolLogData = m_cSymbolLogS.Last();
                // y   }
                //}

                bool bStateOn = false;

                if (cSymbolLogDataS == null) //if (cSymbolLogData == null)
                {
                    if (cContact.ContactType == EMContactType.Bit || cContact.ContactType == EMContactType.Function)
                    {
                        if (cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF"))
                            bStateOn = true;
                        else
                            bStateOn = false;
                    }
                    else
                        bStateOn = false;
                }
                else
                {
                    bStateOn = CheckContactState(cContact, cSymbolLogDataS);
                }

                m_cLadderBrand.HoldUpdate();
                m_cLadderBrand.Contact = cContact;
                m_cLadderBrand.ContactDate = cSymbolLogData == null ? DateTime.MinValue : cSymbolLogData.Time;
                m_cLadderBrand.ContactValue = bStateOn;

                //if (m_lstLadderCellDataFB.Count == 0)
                //    m_cLadderBrand.FBInfo = null;

                //else
                //    m_cLadderBrand.FBInfo = cFB_Info;

                m_cLadderBrand.NowUpdate();

                element = m_cLadderBrand.GetContactLadderItem();
            }
            else if (cCoil != null)
            {
                if (cCoil.Instruction == "") return;

                bool bStateOn = false;

                if (cSymbolLogDataS != null)
                {
                    bStateOn = CheckCoilState(cCoil, cSymbolLogDataS);
                }

                m_cLadderBrand.HoldUpdate();
                m_cLadderBrand.Coil = cCoil;
                //m_cLadderBrand.CoilValue = cSymbolLogData == null ? false : Convert.ToBoolean(cSymbolLogData.Value);
                m_cLadderBrand.CoilValue = bStateOn;
                m_cLadderBrand.CoilDate = cSymbolLogData == null ? DateTime.MinValue : cSymbolLogData.Time;
                m_cLadderBrand.NowUpdate();

                element = m_cLadderBrand.GetCoilLadderItem();
            }

            else if( cFB_Info != null)
            {
                //bool bStateOn = false;

                cFB_Info.MainCoil = m_cStep.CoilS.GetFirstCoil();
                m_cLadderBrand.HoldUpdate();
                m_cLadderBrand.FBInfo = cFB_Info;
                m_cLadderBrand.FBInfo.RowOccupied = cLadderCellData.RowOccupied;
                m_cLadderBrand.NowUpdate();

                element = m_cLadderBrand.GetFBLadderItem();
            }

            if (element != null)
            {
                if (cLadderCellData.Drawable) { element.Draw(graphics, point, cSymbolLogDataS); }
            }
        }

        private bool CheckContactState(CContact cContact, CTimeLogS cLogS) //int iValue)
        {
            bool bStateOn = false;

            try
            {
                int iConstant = 0;
                string sNoSystem = "";
                string sConstant = "";

                int iValue = -1;

                if (cLogS != null && cLogS.Count > 0)
                    iValue = cLogS.Last().Value;

                if (cContact.ContactType == EMContactType.Bit || cContact.ContactType == EMContactType.Function)
                {
                    if (cContact.ContentS.Count == 1)
                    {
                        if (iValue == 1 && (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF"))
                            || iValue == 0 && (cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF")))
                            bStateOn = true;
                    }

                    //Timer,Counter 값 비교해서 On/OFF
                    else if (cContact.ContentS.Count == 2)
                    {
                        CContent cAddrContent = cContact.ContentS[0];
                        CContent cConstantContent = cContact.ContentS[1];
                        bool bOK = false;

                        if (cAddrContent.Tag != null)
                        {
                            if (cAddrContent.Argument.IndexOf("C") == 0 || cAddrContent.Argument.IndexOf("T") == 0)
                            {
                                if (cAddrContent.Tag.PLCMaker.ToString().Contains("Mitsubishi"))
                                {
                                    if (cConstantContent.Tag != null)
                                    {
                                        sNoSystem = "K";
                                        foreach (CTimeLog cLog in cLogS)
                                        {
                                            if (cConstantContent.Tag.Key == cLog.Key)
                                                sConstant = cLog.Value.ToString();
                                        }

                                        if (sConstant == string.Empty)
                                            sConstant = "0";
                                    }
                                    else
                                    {
                                        sNoSystem = cConstantContent.Argument.Substring(0, 1);
                                        sConstant = Regex.Replace(cConstantContent.Argument, @"\D", "");
                                    }


                                    if (sNoSystem.Equals("H"))  // Hexa -> Decimal로 변경
                                        iConstant = int.Parse(sConstant, System.Globalization.NumberStyles.HexNumber);
                                    else
                                        iConstant = int.Parse(sConstant);

                                    bOK = true;
                                }
                                else if (cAddrContent.Tag.PLCMaker.Equals(EMPLCMaker.Siemens))
                                {
                                    if (cConstantContent.Tag != null)
                                    {
                                        foreach (CTimeLog cLog in cLogS)
                                        {
                                            if (cConstantContent.Tag.Key == cLog.Key)
                                                sConstant = cLog.Value.ToString();
                                        }

                                        if (sConstant == string.Empty)
                                            sConstant = "0";
                                    }
                                    else
                                    {
                                        if (cConstantContent.Argument.Contains("#"))
                                            sConstant = cConstantContent.Argument.Split('#')[1];
                                        else
                                            sConstant = cConstantContent.Argument;

                                        sConstant = Regex.Replace(sConstant, @"\D", "");
                                    }

                                    iConstant = int.Parse(sConstant);
                                    bOK = true;
                                }

                                if (bOK && iValue != -1)
                                {
                                    if (cContact.Instruction.Contains("XIC") || cContact.Instruction.Contains("XICP") || cContact.Instruction.Contains("XIOF"))
                                    {
                                        if (iValue == iConstant)
                                            bStateOn = true;
                                        else
                                            bStateOn = false;
                                    }

                                    else if (cContact.Instruction.Contains("XIO") || cContact.Instruction.Contains("XIOP") || cContact.Instruction.Contains("XICF"))
                                    {
                                        if (iValue != iConstant)
                                            bStateOn = true;
                                        else
                                            bStateOn = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (cContact.ContactType == EMContactType.Compare)
                {
                    bool bOK = false;
                    int iFstValue = -1;
                    int iSndValue = -1;

                    if (cContact.RefTagS.GetFirstTag().PLCMaker.ToString().Contains("Mitsubishi"))
                    {
                        CTag cFirstTag = cContact.ContentS[0].Tag;
                        CTag cSecondTag = cContact.ContentS[1].Tag;

                        // 첫번째 값이 상수이고 두번째 값이 Address인 경우
                        if (cFirstTag == null && cSecondTag != null)
                        {
                            sNoSystem = cContact.ContentS[0].Argument.Substring(0, 1);
                            sConstant = Regex.Replace(cContact.ContentS[0].Argument, @"\D", "");

                            if (sNoSystem.Equals("H"))  // Hexa -> Decimal로 변경
                                iConstant = int.Parse(sConstant, System.Globalization.NumberStyles.HexNumber);
                            else
                                iConstant = int.Parse(sConstant);

                            iFstValue = iConstant;

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cSecondTag.Key)
                                    iSndValue = cLog.Value;
                            }
                        }

                        // 첫번째 값이 Address이고 두번째 값이 상수인 경우
                        else if (cFirstTag != null && cSecondTag == null)
                        {
                            sNoSystem = cContact.ContentS[1].Argument.Substring(0, 1);
                            sConstant = Regex.Replace(cContact.ContentS[1].Argument, @"\D", "");

                            if (sNoSystem.Equals("H"))  // Hexa -> Decimal로 변경
                                iConstant = int.Parse(sConstant, System.Globalization.NumberStyles.HexNumber);
                            else
                                iConstant = int.Parse(sConstant);

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cFirstTag.Key)
                                    iFstValue = cLog.Value;
                            }
                            iSndValue = iConstant;
                        }

                        // 두 값 모두 Address인 경우
                        else if (cFirstTag != null && cSecondTag != null)
                        {
                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cFirstTag.Key)
                                    iFstValue = cLog.Value;
                            }

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cSecondTag.Key)
                                    iSndValue = cLog.Value;
                            }
                        }
                        bOK = true;
                    }
                    else if (cContact.RefTagS.GetFirstTag().PLCMaker.Equals(EMPLCMaker.Siemens))
                    {
                        CTag cFirstTag = cContact.ContentS[0].Tag;
                        CTag cSecondTag = cContact.ContentS[1].Tag;

                        // 첫번째 값이 상수이고 두번째 값이 Address인 경우
                        if (cFirstTag == null && cSecondTag != null)
                        {
                            if (cContact.ContentS[0].Argument.Contains("#"))
                                sConstant = cContact.ContentS[0].Argument.Split('#')[1];
                            else
                                sConstant = cContact.ContentS[0].Argument;

                            sConstant = Regex.Replace(sConstant, @"\D", "");
                            iFstValue = int.Parse(sConstant);

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cSecondTag.Key)
                                    iSndValue = cLog.Value;
                            }
                        }

                        // 첫번째 값이 Address이고 두번째 값이 상수인 경우
                        else if (cFirstTag != null && cSecondTag == null)
                        {
                            if (cContact.ContentS[0].Argument.Contains("#"))
                                sConstant = cContact.ContentS[1].Argument.Split('#')[1];
                            else
                                sConstant = cContact.ContentS[1].Argument;

                            sConstant = Regex.Replace(sConstant, @"\D", "");
                            iSndValue = int.Parse(sConstant);

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cFirstTag.Key)
                                    iFstValue = cLog.Value;
                            }
                        }

                        // 두 값 모두 Address인 경우
                        else if (cFirstTag != null && cSecondTag != null)
                        {
                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cFirstTag.Key)
                                    iFstValue = cLog.Value;
                            }

                            foreach (CTimeLog cLog in cLogS)
                            {
                                if (cLog.Key == cSecondTag.Key)
                                    iSndValue = cLog.Value;
                            }
                        }
                        bOK = true;
                    }

                    if(bOK && iFstValue != -1 && iSndValue != -1)
                    {
                        //Compare 명령어에 따라 값 비교해서 On/OFF

                        // EQU , = 
                        if (cContact.Operator.Contains("EQU"))
                        {
                            if (iFstValue == iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                        // GRT , >
                        else if (cContact.Operator.Contains("GRT"))
                        {
                            if (iFstValue > iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                        // GEQ , >=
                        else if (cContact.Operator.Contains("GEQ"))
                        {
                            if (iFstValue >= iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                        // LES , <
                        else if (cContact.Operator.Contains("LES"))
                        {
                            if (iFstValue < iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                        // LEQ , <=
                        else if (cContact.Operator.Contains("LEQ"))
                        {
                            if (iFstValue <= iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                        // NEQ , <>
                        else if (cContact.Operator.Contains("NEQ"))
                        {
                            if (iFstValue != iSndValue)
                                bStateOn = true;
                            else
                                bStateOn = false;
                        }
                    }
                }
                else
                    bStateOn = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
                bStateOn = false;
            }
            return bStateOn;
        }

        private bool CheckCoilState(CCoil cCoil, CTimeLogS cLogS)
        {
            bool bStateOn = false;
            int iValue = 0;

            if(cLogS != null && cLogS.Count > 0)
                iValue = cLogS.Last().Value;

            if (cCoil.CoilType == EMCoilType.Counter || cCoil.CoilType == EMCoilType.Timer)
            {
                if (cCoil.RefTagS.GetFirstTag().PLCMaker.ToString().Contains("Mitsubishi"))
                {
                    CContent cAddrContent = cCoil.ContentS[0];
                    CContent cConstantContent = cCoil.ContentS[1];

                    int iConstant = 0;
                    string sNoSystem = "";
                    string sConstant = "";

                    if (cConstantContent.Tag != null)
                    {
                        sNoSystem = "K";
                        foreach (CTimeLog cLog in cLogS)
                        {
                            if (cConstantContent.Tag.Key == cLog.Key)
                                sConstant = cLog.Value.ToString();
                        }
                    }
                    else
                    {
                        sNoSystem = cConstantContent.Argument.Substring(0, 1);
                        sConstant = Regex.Replace(cConstantContent.Argument, @"\D", "");
                    }

                    if (cLogS != null && cLogS.Count > 0)
                    {
                        foreach (CTimeLog cLog in cLogS)
                        {
                            if (cAddrContent.Tag.Key == cLog.Key)
                                iValue = cLog.Value;
                        }
                    }

                    if (sNoSystem.Equals("H"))  // Hexa -> Decimal로 변경
                        iConstant = int.Parse(sConstant, System.Globalization.NumberStyles.HexNumber);
                    else
                        iConstant = int.Parse(sConstant);


                    if (iValue == iConstant)
                        bStateOn = true;
                    else
                        bStateOn = false;
                }
            }
            else if (cCoil.Command == "SET" || cCoil.Command == "RST") // Set / Reset State = false;
                bStateOn = false;
            else
                bStateOn = Convert.ToBoolean(iValue);

            return bStateOn;
        }

        private void DrawConnection(Graphics graphics)
        {
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                if (cLadderCell.Lines != null)
                {
                    foreach (CEdge e in cLadderCell.Lines)
                    {
                        graphics.DrawLine(m_penLine, e.V1.X, e.V1.Y, e.V2.X, e.V2.Y);
                    }
                }
            }
        }

        private void GenerateConnection()
        {
            foreach (CLadderCellData cLadderCellData in m_hashCells)
            {
                if (cLadderCellData.Data is CContact) { GenerateConnectionContact(cLadderCellData); }
                else if (cLadderCellData.Data is CFB_Info) { GenerateConnectionFB(cLadderCellData); }
                else if (cLadderCellData.Data is CCoil) { GenerateConnectionCoil(cLadderCellData); }
            }
        }

        private void GenerateConnectionFB(CLadderCellData cLadderCellData)
        {
            CFB_Info cFB_Info = cLadderCellData.Data as CFB_Info;
            Point point = GetCellOrigin(cLadderCellData.Row, cLadderCellData.Column);

            if (cFB_Info.Relation.PrevContactS.Count == 0)
                cLadderCellData.AddLine(0, point.Y + m_nOffsetVertical, point.X, point.Y + m_nOffsetVertical);

            //if (m_lstLadderCellDataFB.Count > 1 || m_cStep.ContactS.Count > 0) return;

            point.X = point.X + (cLadderCellData.ColumnOccupied * m_nCellWidth);

            if(m_cLadderCellDataCoil.Row == 1)
                cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, point.X + ((m_cLadderCellDataCoil.ColumnOccupied+1) * m_nCellWidth), point.Y + m_nOffsetVertical);
            else
                cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, point.X + m_nCellWidth, point.Y + m_nOffsetVertical);
        }

        private void GenerateConnectionContact(CLadderCellData cLadderCellData)
        {
            CContact cContact = cLadderCellData.Data as CContact;

            // If the cell doesn't exist, return
            if (!m_dicItemLadderCell.ContainsKey(cContact)) { return; }

            // The cell of this contact
            Point point = GetCellOrigin(cLadderCellData.Row, cLadderCellData.Column);

            point.X = point.X + (cLadderCellData.ColumnOccupied * m_nCellWidth);

            // It means this contact is directly connected to coil

            if (cContact.Relation.NextContactS.Count == 0)
            {
                if (m_lstLadderCellDataFB.Count != 0)
                {
                    CLadderCellData cFirstFB = m_lstLadderCellDataFB[0];
                    CLadderCellData cLastFB = m_lstLadderCellDataFB[m_lstLadderCellDataFB.Count - 1];

                    Point pointFirstFB = GetCellOrigin(cFirstFB.Row, cFirstFB.Column);
                    Point pointLastFB = GetCellOrigin(cLastFB.Row, cLastFB.Column);
                    Point pointCoil = GetCellOrigin(cLadderCellData.Row, m_cLadderCellDataCoil.Column);

                    cLadderCellData.AddLine(pointLastFB.X + (cLastFB.ColumnOccupied * m_nCellWidth), pointLastFB.Y + m_nOffsetVertical, m_pointCoil.X + (m_nCellWidth * m_cLadderCellDataCoil.ColumnOccupied), pointLastFB.Y + m_nOffsetVertical);

                    if(cContact.ContactType != EMContactType.Constant)
                        cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointFirstFB.X, point.Y + m_nOffsetVertical);

                    //Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, cFirstFB.Column - 1);
                    //cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
                    //cLadderCellData.AddLine(pointTemp3.X + (2 * m_nCellWidth), pointTemp3.Y + m_nOffsetVertical, m_pointCoil.X, m_pointCoil.Y + m_nOffsetVertical);
                    //cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
                    //cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp1.X + m_nCellWidth, pointTemp1.Y + m_nOffsetVertical);
                }

                else
                {
                    Point pointTemp1 = GetCellOrigin(m_cLadderCellDataCoil.Row, m_cLadderCellDataCoil.Column - m_nGapCoilToMaxCol);
                    Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, m_cLadderCellDataCoil.Column - m_nGapCoilToMaxCol);

                    cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
                    cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, m_pointCoil.X, m_pointCoil.Y + m_nOffsetVertical);
                    cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
                }
            }
            else
            {
                CContact contactFirst = GetContact(m_cStep, cContact.Relation.NextContactS.First());
                CContact contactLast = GetContact(m_cStep, cContact.Relation.NextContactS.Last());

                if (m_dicItemLadderCell.ContainsKey(contactFirst))
                {
                    System.Diagnostics.Debug.Assert(m_dicItemLadderCell[contactFirst] != null);
                    CLadderCellData cLadderCellChild = m_dicItemLadderCell[contactFirst] as CLadderCellData;
                    Point pointChild = GetCellOrigin(cLadderCellChild.Row, cLadderCellChild.Column);

                    // If it has connector (indicate that it has multiple parent
                    if (cLadderCellChild.Connectors != null)
                    {
                        Point pointTemp1 = GetCellOrigin(cLadderCellChild.Row, cLadderCellChild.Column);
                        Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, cLadderCellChild.Column);
                        cLadderCellData.AddLine(pointTemp2.X, pointTemp2.Y + m_nOffsetVertical, pointTemp1.X, pointTemp1.Y + m_nOffsetVertical);
                        cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
                    }

                    // Connecting all the childs
                    if (m_dicItemLadderCell.ContainsKey(contactLast))
                    {
                        CLadderCell cLadderCellChildLast = m_dicItemLadderCell[contactLast];
                        Point pointChildLast = GetCellOrigin(cLadderCellChildLast.Row, cLadderCellChildLast.Column);
                        cLadderCellData.AddLine(pointChild.X, pointChild.Y + m_nOffsetVertical, pointChildLast.X, pointChildLast.Y + m_nOffsetVertical);
                    }
                }
            }

            //if (cContact.Relation.NextContactS.Count == 0)
            //{
            //    if (m_lstLadderCellDataFB.Count != 0)
            //    {
            //        CLadderCellData cFirstFB = m_lstLadderCellDataFB[0];
            //        CLadderCellData cLastFB = m_lstLadderCellDataFB[m_lstLadderCellDataFB.Count - 1];

            //        Point pointTemp1 = GetCellOrigin(cFirstFB.Row, cFirstFB.Column-1);
            //        Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, cFirstFB.Column-1);
            //        Point pointTemp3 = GetCellOrigin(cLastFB.Row, cLastFB.Column);

            //        cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
            //        cLadderCellData.AddLine(pointTemp3.X + (2 * m_nCellWidth), pointTemp3.Y + m_nOffsetVertical, m_pointCoil.X, m_pointCoil.Y + m_nOffsetVertical);
            //        cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
            //        cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp1.X + m_nCellWidth, pointTemp1.Y + m_nOffsetVertical);
            //    }
            //    else
            //    {
            //        Point pointTemp1 = GetCellOrigin(m_cLadderCellDataCoil.Row, m_cLadderCellDataCoil.Column - m_nGapCoilToMaxCol);
            //        Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, m_cLadderCellDataCoil.Column - m_nGapCoilToMaxCol);

            //        cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
            //        cLadderCellData.AddLine(pointTemp1.X, pointTemp1.Y + m_nOffsetVertical, m_pointCoil.X, m_pointCoil.Y + m_nOffsetVertical);
            //        cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
            //    }
            //}
            //else
            //{
            //    CContact contactFirst = GetContact(m_cStep, cContact.Relation.NextContactS.First());
            //    CContact contactLast = GetContact(m_cStep, cContact.Relation.NextContactS.Last());

            //    if (m_dicItemLadderCell.ContainsKey(contactFirst))
            //    {
            //        System.Diagnostics.Debug.Assert(m_dicItemLadderCell[contactFirst] != null);
            //        CLadderCellData cLadderCellChild = m_dicItemLadderCell[contactFirst] as CLadderCellData;
            //        Point pointChild = GetCellOrigin(cLadderCellChild.Row, cLadderCellChild.Column);

            //        // If it has connector (indicate that it has multiple parent
            //        if (cLadderCellChild.Connectors != null)
            //        {
            //            Point pointTemp1 = GetCellOrigin(cLadderCellChild.Row, cLadderCellChild.Column);
            //            Point pointTemp2 = GetCellOrigin(cLadderCellData.Row, cLadderCellChild.Column);
            //            cLadderCellData.AddLine(pointTemp2.X, pointTemp2.Y + m_nOffsetVertical, pointTemp1.X, pointTemp1.Y + m_nOffsetVertical);
            //            cLadderCellData.AddLine(point.X, point.Y + m_nOffsetVertical, pointTemp2.X, pointTemp2.Y + m_nOffsetVertical);
            //        }

            //        // Connecting all the childs
            //        if (m_dicItemLadderCell.ContainsKey(contactLast))
            //        {
            //            CLadderCell cLadderCellChildLast = m_dicItemLadderCell[contactLast];
            //            Point pointChildLast = GetCellOrigin(cLadderCellChildLast.Row, cLadderCellChildLast.Column);
            //            cLadderCellData.AddLine(pointChild.X, pointChild.Y + m_nOffsetVertical, pointChildLast.X, pointChildLast.Y + m_nOffsetVertical);
            //        }
            //    }
            //}
        }

        private void GenerateConnectionCoil(CLadderCellData cLadderCellData)
        {
            switch (m_cLadderBrand.Brand)
            {
                case EditorBrand.AB: GenerateConnectionCoilAB(cLadderCellData); break;
            }
        }

        private void GenerateConnectionCoilAB(CLadderCellData cLadderCellData)
        {
            List<CContact> InitialContactS = new List<CContact>();
            foreach ( CContact cContact in m_cStep.ContactS)
            {
                if (cContact.IsInitial)
                    InitialContactS.Add(cContact);
            }

            if (InitialContactS.Count == 0) { return; }
            CLadderCell cLadderCellFirst = m_dicItemLadderCell[InitialContactS.First()];
            CLadderCell cLadderCellLast = m_dicItemLadderCell[InitialContactS.Last()];
            Point pointFirst = GetCellOrigin(cLadderCellFirst.Row, cLadderCellFirst.Column);
            Point pointLast = GetCellOrigin(cLadderCellLast.Row, cLadderCellLast.Column);
            cLadderCellData.AddLine(m_cVertexSBoundingBoxes[0].X, m_cVertexSBoundingBoxes[0].Y + m_nOffsetVertical, pointFirst.X, pointFirst.Y + m_nOffsetVertical);
            cLadderCellData.AddLine(pointFirst.X, pointFirst.Y + m_nOffsetVertical, pointLast.X, pointLast.Y + m_nOffsetVertical);
        }

        private void DrawCoilToDirectChild(Graphics graphics)
        {
            List<CContact> InitialContactS = new List<CContact>();
            foreach (CContact cContact in m_cStep.ContactS)
            {
                if (cContact.IsInitial)
                    InitialContactS.Add(cContact);
            }


            switch (m_cLadderBrand.Brand)
            {
                case EditorBrand.AB :
                     
                    CLadderCell cLadderCellFirst = m_dicItemLadderCell[InitialContactS.First()];
                    CLadderCell cLadderCellLast = m_dicItemLadderCell[InitialContactS.Last()];
                    Point pointFirst = GetCellOrigin(cLadderCellFirst.Row, cLadderCellFirst.Column);
                    Point pointLast = GetCellOrigin(cLadderCellLast.Row, cLadderCellLast.Column);
                    graphics.DrawLine(m_penLine, m_cVertexSBoundingBoxes[0].X, m_cVertexSBoundingBoxes[0].Y + m_nOffsetVertical, pointFirst.X, pointFirst.Y + m_nOffsetVertical);
                    graphics.DrawLine(m_penLine, pointFirst.X, pointFirst.Y + m_nOffsetVertical, pointLast.X, pointLast.Y + m_nOffsetVertical);

                    cLadderCellFirst.AddLine(m_cVertexSBoundingBoxes[0].X, m_cVertexSBoundingBoxes[0].Y + m_nOffsetVertical, pointFirst.X, pointFirst.Y + m_nOffsetVertical);
                    cLadderCellFirst.AddLine(pointFirst.X, pointFirst.Y + m_nOffsetVertical, pointLast.X, pointLast.Y + m_nOffsetVertical);

                    break;

                case EditorBrand.SIEMENS : /* NOTHING */; break;
                case EditorBrand.MELSEC : /* NOTHING */; break;
            }
        }

        private void GenerateCells()
        {
            try
            {
                m_hashCells.Clear();
                m_dicItemLadderCell.Clear();
                m_dicRowColumnOccupied.Clear();

                if (m_cStep == null) { return; }

                int nColMax = 0;
                switch (m_cLadderBrand.Brand)
                {
                    case EditorBrand.AB: nColMax = 0; break;
                    case EditorBrand.SIEMENS: nColMax = 0; break;
                    case EditorBrand.MELSEC:
                    case EditorBrand.Common : nColMax = -1; break;
                }

                int nRowMax = -1;

                CLadderCell cCellLadderVeryFirst = null;

                foreach (CContact cContact in m_cStep.ContactS.FindAll(c => c.IsInitial))
                {
                    // Generate cells of contact that are directly child of m_cCoil (has no parent)
                    if (!m_dicItemLadderCell.ContainsKey(cContact))
                    {
                        int nRow = -1;
                        if (cContact.Relation.NextContactS.Count == 0)
                        {
                            nRowMax++;
                            nRow = nRowMax;
                        }
                        else
                        {
                            CContact cContactChild = GetContact(m_cStep, cContact.Relation.NextContactS.First());
                            if (!m_dicItemLadderCell.ContainsKey(cContactChild))
                            {
                                // Index of current contact
                                int nI = cContact.StepIndex;
                                    //m_cStep.ContactS.IndexOf(cContact);
                                // 이곳 Change

                                // If it is NOT the first child
                                if (nI != 0)
                                {
                                    // Index of previous sibling
                                    nI = nI - 1;

                                    CContact cContactSibling = GetContact(m_cStep, nI);

                                    if (cContactSibling != null && m_dicItemLadderCell.ContainsKey(cContactSibling))
                                    {
                                        // Previous sibling cell
                                        CLadderCell cCellSibling = m_dicItemLadderCell[cContactSibling];

                                        // If the parent has child more than one, it means this contact should (at least) in the row of parent + the order of it w.r.t other children
                                        nRow = cCellSibling.Row + 1;

                                        // Find the first child (or grand grand child) that has been created
                                        CLadderCell cCell = null;
                                        CLadderHelper.IterateContactAndCoils(m_cStep, m_cStep, cContact, (cc, pp) =>
                                        {
                                            if (cCell == null && cc is ITagComposable)
                                            {
                                                if (m_dicItemLadderCell.ContainsKey(cc as ITagComposable))
                                                {
                                                    cCell = m_dicItemLadderCell[cc as ITagComposable];
                                                    // NOTE : we need to mechanism for breaking the loop, in UDM.COMMON CContact.DoThis, maybe using return true/false
                                                }
                                            }
                                        });

                                        if (cCell != null)
                                        {
                                            nRow = ScanAvailableRow(nRow, cCell.Column);
                                        }
                                        else
                                        {
                                            nRowMax++;
                                            nRow = nRowMax;
                                        }
                                    }
                                    else
                                    {
                                        nRowMax++;
                                        nRow = nRowMax;
                                    }
                                }
                                else
                                {
                                    nRowMax++;
                                    nRow = nRowMax;
                                }
                            }
                            else
                            {
                                CLadderCell cLadderCellChild = m_dicItemLadderCell[cContactChild];
                                nRow = ScanAvailableRow(cLadderCellChild.Row, cLadderCellChild.Column);
                            }
                        }

                        switch (m_cLadderBrand.Brand)
                        {
                            case EditorBrand.AB: nColMax = nColMax < 1 ? 1 : nColMax; break;
                            case EditorBrand.SIEMENS: nColMax = nColMax < 1 ? 1 : nColMax; break;
                            case EditorBrand.Common :
                            case EditorBrand.MELSEC: nColMax = nColMax < 0 ? 0 : nColMax; ; break;
                        }

                        CLadderCell cell = CreateCellData(nRow, 0, cContact);
                        m_hashCells.Add(cell);
                        StoreCell(cContact, cell);
                        nRowMax = nRowMax > nRow ? nRowMax : nRow;

                        if (cCellLadderVeryFirst == null) { cCellLadderVeryFirst = cell; }
                    }

                    // Then, for every child of every coil's contact, do ... 
                    CLadderHelper.IterateContactAndCoils(m_cStep, m_cStep, cContact, (c, parent) => // c is the cContact
                    {
                        //if (c.ContactType == EMContactType.None) { return; }

                        // CContact only
                        if (c is CContact == false) { return; }

                        // CContact only
                        if (!(parent is CContact)) { return; } // For ex : parent is Coil

                        CContact cContactParent = parent as CContact;
                        System.Diagnostics.Debug.Assert(m_dicItemLadderCell[parent as ITagComposable] != null);
                        CLadderCell cLadderCellParent = m_dicItemLadderCell[parent as ITagComposable];

                        // At least, this contact should be same as Parent's row
                        int nR = cLadderCellParent.Row;
                        if (cContactParent.Relation.NextContactS.Count != 0) // If it is not the first child of its PARENT
                        {
                            // Only if this contact is not first child
                            if (GetContact(m_cStep, cContactParent.Relation.NextContactS.First()) != c)
                            {
                                int iC = (c as CContact).StepIndex;
                                    //m_cStep.ContactS.IndexOf(c as CContact);
                                    

                                // If the parent has child more than one, at least this contact should in the row of parent + the order of it w.r.t other children
                                nR = cLadderCellParent.Row + cContactParent.Relation.NextContactS.IndexOf(iC);
                                    //iC;
                                    //cContactParent.Relation.NextContactS.IndexOf(iC);

                                // If this contact has child 
                                bool bFirstChild = (c as CContact).Relation.NextContactS.Count > 0;

                                CLadderCell cCell = null;
                                CLadderHelper.IterateContactAndCoils(m_cStep, cContact, c, (cc, pp) =>
                                {
                                    if (cCell == null)
                                    {
                                        if (m_dicItemLadderCell.ContainsKey(cc as ITagComposable))
                                        {
                                            cCell = m_dicItemLadderCell[cc as ITagComposable];
                                        }
                                    }
                                });

                                if (cCell != null) { nR = ScanAvailableRow(nR, cCell.Column); }
                                else { nRowMax++; nR = nRowMax; }
                            }
                        }

                        // At least the column is next to parent
                        int nC = cLadderCellParent.Column + cLadderCellParent.ColumnOccupied;

                        // If doesnt exist create one, otherwise ...
                        if (!m_dicItemLadderCell.ContainsKey(c as ITagComposable))
                        {
                            // The front connector
                            CLadderCellConnector cLadderCellConnectorFront = null;
                            if (cContactParent.Relation.NextContactS.Count > 0)
                            {
                                // For checking whether we should create a new connector or not
                                if (GetContact(m_cStep, cContactParent.Relation.NextContactS.First()) == c)
                                {
                                    cLadderCellConnectorFront = new CLadderCellConnector(nR, nC);
                                    //m_hashCells.Add(cLadderCellConnectorFront); // The connector if added as drawable cell, it will appear in ladder, however, if it is not added it is just an indicator of junction
                                    //nC = nC + 1;
                                }
                                else // Just follow the column of first child
                                {
                                    System.Diagnostics.Debug.Assert(m_dicItemLadderCell.ContainsKey(GetContact(m_cStep, cContactParent.Relation.NextContactS.First())));
                                    nC = m_dicItemLadderCell[GetContact(m_cStep, cContactParent.Relation.NextContactS.First())].Column;
                                }
                            }

                            // Creation
                            CLadderCellData cLadderCellData = CreateCellData(nR, nC, c);
                            m_hashCells.Add(cLadderCellData);
                            StoreCell(c as ITagComposable, cLadderCellData);
                            nRowMax = nRowMax > nR ? nRowMax : nR;
                            nColMax = nColMax > (cLadderCellData.Column + cLadderCellData.ColumnOccupied - 1) ? nColMax : (cLadderCellData.Column + cLadderCellData.ColumnOccupied - 1);

                            if (cCellLadderVeryFirst == null) { cCellLadderVeryFirst = cLadderCellData; }

                            // Add the front connector to creation
                            if (cLadderCellConnectorFront != null) // it means, it just newly created, so add it ..
                            {
                                if (cLadderCellData.Connectors == null) { cLadderCellData.Connectors = new List<CLadderCellConnector>(); }
                                cLadderCellData.Connectors.Add(cLadderCellConnectorFront);

                                if (cLadderCellConnectorFront.CellConnected == null) { cLadderCellConnectorFront.CellConnected = new List<CLadderCell>(); }
                                cLadderCellConnectorFront.CellConnected.Add(cLadderCellParent); // not this contact, but this contact parent
                            }
                        }
                        else // Check the cell of child is already more to the left side of current parent
                        {
                            CLadderCell cLadderCellChild = m_dicItemLadderCell[c as ITagComposable];
                            if (cLadderCellChild.Column <= (cLadderCellParent.Column + cLadderCellParent.ColumnOccupied - 1))
                            {
                                // No junction point, the column is just next to its parent
                                nC = cLadderCellParent.Column + cLadderCellParent.ColumnOccupied;

                                cLadderCellChild.Column = nC;
                                //nColMax = nColMax > (nC - 1) ? nColMax : (nC - 1);
                                nColMax = nColMax > nC ? nColMax : nC;
                            }
                        }
                    });
                }

                // I dont know the elegant way, just make it safe
                foreach (CLadderCell cCell in m_hashCells)
                {
                    if (nColMax >= cCell.Column)
                    {
                        nColMax = nColMax <= (cCell.Column + cCell.ColumnOccupied) ? cCell.Column + cCell.ColumnOccupied + 1 : nColMax; 
                    }
                }

                m_lstLadderCellDataFB = new List<CLadderCellData>();

                if (m_cStep.FBInfoList != null && m_cStep.FBInfoList.Count > 0)
                {
                    if (m_hashCells.Count > 0) nColMax--;

                    foreach (CFB_Info cFB in m_cStep.FBInfoList)
                    {
                        if (cFB.Relation.PrevContactS.Count == 0)
                        {
                            foreach (CLadderCell cCell in m_hashCells)
                                cCell.Row = cCell.Row + 1;

                            nRowMax++;
                        }

                        CLadderCellData cellFB = null;

                        if (m_hashCells.Count > 0)
                            cellFB = CreateCellData(0, nColMax, cFB);

                        else
                            cellFB = CreateCellData(0, 1, cFB);

                        cellFB.ColumnOccupied = 3;
                        cellFB.RowOccupied = 2;

                        int iRowCnt = cFB.In_ItemNameList.Count + cFB.InOut_ItemNameList.Count;

                        if (iRowCnt > 1) //if (cFB.In_ItemNameList.Count > 1)
                        {
                            if (nRowMax + 1 > iRowCnt)
                                cellFB.RowOccupied = nRowMax + 1;
                            else
                                cellFB.RowOccupied = iRowCnt;
                        }

                        m_hashCells.Add(cellFB);
                        StoreCell(cFB, cellFB);

                        m_lstLadderCellDataFB.Add(cellFB);
                        nColMax += 3;
                    }

                    if (m_lstLadderCellDataFB.Count > 1)
                        nColMax -= 2;
                    else
                        if (m_cStep.CoilS.Count == 0)
                            nColMax -= 3;
                        else
                            nColMax++;
                }

                // The coil (right now version only single coil, not multi), so using GetFirstCoil 
                CCoil cCoil = m_cStep.CoilS.GetFirstCoil();

                int iCoilRow = 0;
                if (m_cStep.CoilS.Count > 0 && m_lstLadderCellDataFB.Count > 0) iCoilRow = 1;
                // The coil cell
                CLadderCellData cellCoil = CreateCellData(iCoilRow, nColMax + m_nGapCoilToMaxCol, cCoil);

                if (cCoil.Command == "SET") { cellCoil.ColumnOccupied = 4; }
                else if (cCoil.Command == "RST") { cellCoil.ColumnOccupied = 4; }
                else if (cCoil.CoilType == EMCoilType.Bit) { cellCoil.ColumnOccupied = 1; }
                else { cellCoil.ColumnOccupied = 4; }
                //else cellCoil.ColumnOccupied = 1;

                m_hashCells.Add(cellCoil);
                StoreCell(cCoil, cellCoil);
                m_cLadderCellDataCoil = cellCoil;
                m_pointCoil = GetCellOrigin(cellCoil.Row, cellCoil.Column);

#if CUSTOM_PAJU
                m_cLadderCellSelectedCursor = null;
                m_cLadderCellDataCoil.Selectable = false;

                if (cellCoil.ColumnOccupied == 0)
                    cellCoil.ColumnOccupied = 1;
#else
            m_cLadderCellSelectedCursor = cellCoil;
#endif
                m_nIndexRowMax = nRowMax;
                m_nIndexColumnMax = cellCoil.Column + cellCoil.ColumnOccupied - 1;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
            
        }

        private CContact GetContact(CStep cStep, int StepIndex)
        {
            CContact cContact = null;

            foreach (CContact cTemp in cStep.ContactS)
            {
                if (cTemp.StepIndex == StepIndex)
                {
                    cContact = cTemp;
                    break;
                }
            }

            return cContact;
        }

        private CCoil GetCoil(CStep cStep, int StepIndex)
        {
            CCoil cCoil = null;

            foreach (CCoil cTemp in cStep.CoilS)
            {
                if (cTemp.StepIndex == StepIndex)
                {
                    cCoil = cTemp;
                    break;
                }
            }

            return cCoil;
        }

        private int ScanAvailableRow(int nRowFrom, int nColumnTo)
        {
            int nRow = nRowFrom;

            // Scan each row, find the row that has no obstacle to connect this contact to its child
            while (true)
            {
                bool bBreak = true;
                if (m_dicRowColumnOccupied.ContainsKey(nRow))
                {
                    // Iterate throught cell [nRow, i]
                    for (int i = 0; i < nColumnTo; i++)
                    {
                        // If some cell has been occupied, break it, no need to continue
                        // Indicate this row is not available, and find others
                        if (m_dicRowColumnOccupied[nRow].Contains(i))
                        {
                            bBreak = false;
                            break;
                        }
                    }
                }

                // If this row is available, break it, we have found 
                if (bBreak) { break; }
                else { nRow++; } // Otherwise, find another empty line
            }

            return nRow;
        }

        private new void CalculateBoundingBoxes()
        {
            if (m_hashCells.Count < 1) { return; }

            int r, c;
            r = c = 0;
            int rMin, rMax, cMin, cMax;
            rMin = rMax = cMin = cMax = 0;

            foreach (CLadderCell cell in m_hashCells)
            {
                r = cell.Row + cell.RowOccupied - 1;
                c = cell.Column + cell.ColumnOccupied - 1;

                //CLadderCellData cLadderCellData = (CLadderCellData)cell;
                //if (cLadderCellData.Data is CCoil)
                //{
                //    CCoil cCoil = (CCoil)cLadderCellData.Data;
                //    if (cCoil.CoilType != EMCoilType.Bit)
                //    {
                //        int iContents = 0;
                //        foreach (CContent cContent in cCoil.ContentS)
                //        {
                //            if (cContent.Parameter != string.Empty)
                //                iContents++;
                //        }

                //        if (cCoil.ContentS.Count == iContents)
                //            c = cell.Column + cell.ColumnOccupied + iContents;
                //        else if (cCoil.ContentS.Count != iContents)
                //            c = cell.Column + iContents;

                //        if (cCoil.CoilType == EMCoilType.Math)
                //        {
                //            if (cCoil.ContentS.Count == 1)
                //                c = c + 1;
                //            else
                //                c = c - 1;
                //        }
                //    }
                //}

                rMin = rMin > r ? r : rMin;
                rMax = rMax < r ? r : rMax;
                cMin = cMin > c ? c : cMin;
                cMax = cMax < c ? c : cMax;
            }

            m_cVertexSBoundingBoxes.Clear();
            Point LeftTop = GetCellOrigin(rMin, cMin);
            Point RightTop = GetCellOrigin(rMin, cMax);
            Point RightBottom = GetCellOrigin(rMax, cMax);
            Point LeftBottom = GetCellOrigin(rMax, cMin);

            int nCompensationX = 0;

            switch (m_cLadderBrand.Brand)
            {
                case EditorBrand.AB: nCompensationX = -m_nCellWidth; break;
                case EditorBrand.SIEMENS: nCompensationX = 0; break;
                case EditorBrand.Common:
                case EditorBrand.MELSEC: nCompensationX = 0; break;
            }

            m_cVertexSBoundingBoxes.Add(new CVertex(LeftTop.X + nCompensationX, LeftTop.Y));
            m_cVertexSBoundingBoxes.Add(new CVertex(RightTop.X + m_nCellWidth, RightTop.Y));
            m_cVertexSBoundingBoxes.Add(new CVertex(RightBottom.X + m_nCellWidth, RightBottom.Y + m_nCellHeight));
            m_cVertexSBoundingBoxes.Add(new CVertex(LeftBottom.X + nCompensationX, LeftBottom.Y + m_nCellHeight));
        }

        private void AllignVertical()
        {
            switch (m_eAllignVertical)
            {
                case AlignVertical.BOTTOM :
                    m_nOffsetVertical = m_nCellHeight;
                    break;

                case AlignVertical.MIDDLE:
                    m_nOffsetVertical = (int)Math.Round(m_nCellHeight / 2.0);
                    break;

                case AlignVertical.TOP :
                    m_nOffsetVertical = 0;
                    break;
            }
        }

        private void AllignHorizontal()
        {
            switch (m_eAllignHorizontal)
            {
                case AlignHorizontal.RIGHT:
                    m_nOffsetHorizontal = m_nCellWidth;
                    break;

                case AlignHorizontal.MIDDLE:
                    m_nOffsetHorizontal = (int)Math.Round(m_nCellWidth / 2.0);
                    break;

                case AlignHorizontal.LEFT:
                    m_nOffsetHorizontal = 0;
                    break;
            }
        }

        private void MarkRowColumnAsOccupied(int nRow, int nCol, int nRowOccupied, int nColOccupied)
        {
            for (int i = nRow; i < (nRow + nRowOccupied); i++)
            {
                HashSet<int> hashColumn = null;
                if (m_dicRowColumnOccupied.ContainsKey(i)) { hashColumn = m_dicRowColumnOccupied[i]; }
                else { m_dicRowColumnOccupied.Add(i, hashColumn = new HashSet<int>()); }

                for (int j = nCol; j < (nCol + nColOccupied); j++)
                {
                    if (!hashColumn.Contains(j)) { hashColumn.Add(j); }
                }
            }
        }

        private void StoreCell(ITagComposable cItem, CLadderCell cLadderCell)
        {
            if (m_dicItemLadderCell.ContainsKey(cItem))
                m_dicItemLadderCell.Remove(cItem);

            m_dicItemLadderCell.Add(cItem, cLadderCell);
            MarkRowColumnAsOccupied(cLadderCell.Row, cLadderCell.Column, cLadderCell.RowOccupied, cLadderCell.ColumnOccupied);
        }

  
        private CLadderCellData CreateCellData(int r, int c, object o)
        {
            CLadderCellData cLadderCellData = new CLadderCellData(r, c, o);
            
            if (o is CContact) 
            {
                m_cLadderBrand.Contact = o as CContact;
                cLadderCellData.ColumnOccupied = m_cLadderBrand.GetContactLadderItem().ColumnOccupied; 
            }
            else if (o is CCoil) 
            {
                m_cLadderBrand.Coil = o as CCoil;
                cLadderCellData.ColumnOccupied = m_cLadderBrand.GetCoilLadderItem().ColumnOccupied; 
            }

            else if (o is CFB_Info)
            {
                m_cLadderBrand.FBInfo = o as CFB_Info;
                cLadderCellData.ColumnOccupied = m_cLadderBrand.GetFBLadderItem().ColumnOccupied; 
            }

            return cLadderCellData;
        }

        #endregion
    }
}
