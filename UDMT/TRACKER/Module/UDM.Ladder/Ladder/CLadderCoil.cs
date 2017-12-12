using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;

namespace UDM.UI
{
    public class CLadderCoil : IDisposable, ICanvasItem
    {
        #region Private Members

        private Dictionary<Type, CLadderItem> m_dicLogicElement = new Dictionary<Type, CLadderItem>();
        private List<CVertex> m_listBoundingBoxes = new List<CVertex>();
        private Point m_originPoint = new Point(0, 0); // WCS
        private CCoil m_cCoil = null;
        private Dictionary<CItem, CLadderCell> m_dicItemLadderCell= new Dictionary<CItem, CLadderCell>();
        private HashSet<CLadderCell> m_hashCells = new HashSet<CLadderCell>();
        private HashSet<CLadderCell> m_hashCellsSelected = new HashSet<CLadderCell>();
        private AlignVertical m_eAllignVertical = AlignVertical.TOP;
        private AlignHorizontal m_eAllignHorizontal = AlignHorizontal.LEFT;
        private int m_nOffsetVertical = 0;
        private int m_nOffsetHorizontal = 0;
        private int m_nCellWidth = 0;
        private int m_nCellHeight = 0;
        private int m_nGapCoilToMaxCol = 2;
        private Pen m_penLine = new Pen(Color.Black);

        #endregion

        #region Public Enum

        public enum AlignVertical { MIDDLE = 0, TOP, BOTTOM }
        public enum AlignHorizontal { MIDDLE = 0, LEFT, RIGHT }
        
        #endregion

        #region Public Properties

        public Point OriginPoint { get { return m_originPoint; } set { m_originPoint = value; } }
        public List<CVertex> BoundingBoxes { get{ return m_listBoundingBoxes; } }
        public int CellWidth { get { return m_nCellWidth; } set { m_nCellWidth = value; } }
        public int CellHeight { get { return m_nCellHeight; } set { m_nCellHeight = value; } }
        public AlignVertical AllignmentVertical { get { return m_eAllignVertical; } set { m_eAllignVertical = value; AllignVertical(); } }
        public AlignHorizontal AllignmentHorizontal { get { return m_eAllignHorizontal; } set { m_eAllignHorizontal = value; AllignHorizontal(); } }
        public CCoil Coil { get { return m_cCoil; } set { m_cCoil = value; GenerateCells(); CalculateBoundingBoxes(); } }
        public Pen Pen { get { return m_penLine; } set { m_penLine = value; } }

        #endregion

        #region Public Methods

        public CLadderCoil(CCoil cCoil) 
            : this()
        {
            m_cCoil = cCoil;
        }

        public CLadderCoil()
        {
            m_nCellWidth = 100;
            m_nCellHeight = 100;
            AllignmentVertical = AlignVertical.MIDDLE;
            AllignmentHorizontal = AlignHorizontal.MIDDLE;
            CLadderItemContact elementConnect = new CLadderItemContact(); elementConnect.Pen = m_penLine;
            CLadderItemCoil elementCoil = new CLadderItemCoil(); elementCoil.Pen = m_penLine;
            CLadderItemLine elementLine = new CLadderItemLine(); elementLine.Pen = m_penLine;
            m_dicLogicElement.Add(typeof(CContact), elementConnect);
            m_dicLogicElement.Add(typeof(CCoil), elementCoil);
            //m_dicLogicElement.Add(EILType.LINE, elementLine);
            m_cCoil = null;
            m_penLine.Width *= 2;
        }

        public void OnClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {
            m_hashCellsSelected.Clear();

            if (m_hashCells.Count < 1 ) { return; }

            foreach (CLadderCell cell in m_hashCells)
            {
                for (int i = cell.Row; i < cell.Row + cell.RowOccupied; i++)
                {
                    for (int j = cell.Column; j < cell.Column + cell.ColumnOccupied; j++)
                    {
                        if (IsInsideCell(x, y, i, j))
                        {
                            m_hashCellsSelected.Add(cell);
                            return;
                        }
                    }
                }
            }
        }

        public void OnRClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {

        }

        public void OnDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k)
        {

        }

        public void Draw(Graphics graphics)
        {
            try
            {
                if (m_hashCells.Count < 1) { return; }

                // Rung line start-stop
                if (m_listBoundingBoxes.Count == 4)
                {
                    Pen penRung = new Pen(Color.Black, m_penLine.Width * 2);
                    graphics.DrawLine(penRung, m_listBoundingBoxes[0].X, m_listBoundingBoxes[0].Y, m_listBoundingBoxes[3].X, m_listBoundingBoxes[3].Y);
                    graphics.DrawLine(penRung, m_listBoundingBoxes[1].X, m_listBoundingBoxes[1].Y, m_listBoundingBoxes[2].X, m_listBoundingBoxes[2].Y);
                    penRung.Dispose();
                }

                // Selected cell
                foreach (CLadderCell cell in m_hashCellsSelected)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(50, Color.Blue));
                    for (int i = cell.Row; i < cell.Row + cell.RowOccupied; i++)
                    {
                        for (int j = cell.Column; j < cell.Column + cell.ColumnOccupied; j++)
                        {
                            Point point = GetCellOrigin(i, j);
                            graphics.FillRectangle(brush, new Rectangle(point.X, point.Y, m_nCellWidth, m_nCellHeight));
                        }
                    }
                    brush.Dispose();
                }

                // Basic shape
                DrawCellS(graphics);

                // Connection
                DrawContactConnection(graphics);
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

        private Point GetCellOrigin(int r, int c) // WCS -> x+ => column direction+, y => row direction+ 
        {
            return new Point(m_originPoint.X + c * m_nCellWidth, m_originPoint.Y + r * m_nCellHeight);
        }

        private bool IsInsideCell(int x, int y, int r, int c)
        {
            Point point = GetCellOrigin(r, c);

            if (x < point.X || x > (point.X + m_nCellWidth) || y < point.Y || y > (point.Y + m_nCellHeight))
            {
                return false;
            }

            return true;
        }

        private void DrawCellS(Graphics graphics)
        {
            foreach (CLadderCell cLadderCell in m_hashCells)
            {
                Point point = GetCellOrigin(cLadderCell.Row, cLadderCell.Column);
                point.X += m_nOffsetHorizontal;
                point.Y += m_nOffsetVertical;

                CLadderItem element = null;

                if (cLadderCell.Data.GetType() == typeof(CContact))
                {
                    element = m_dicLogicElement[typeof(CContact)];
                    CLadderItemContact cElementContact = element as CLadderItemContact;
                    cElementContact.Value = true; // HARDCODING
                    cElementContact.Contact = cLadderCell.Data as CContact;
                }
                else if (cLadderCell.Data.GetType() == typeof(CCoil))
                {
                    element = m_dicLogicElement[typeof(CCoil)];
                    CLadderItemCoil cElementCoil = element as CLadderItemCoil;
                    cElementCoil.Coil = cLadderCell.Data as CCoil;
                }

                if (element != null) { element.Draw(graphics, point); }
            }
        }

        private void DrawContactConnection(Graphics graphics)
        {
            CLadderCell cLadderCellCoil = m_dicItemLadderCell[m_cCoil];
            Point pointCoil = GetCellOrigin(cLadderCellCoil.Row, cLadderCellCoil.Column);

            m_cCoil.ContactS.DoThisOnEveryContact(null, (c, parent) =>
            {
                if (!m_dicItemLadderCell.ContainsKey(c)) { return; }

                CLadderCell cLadderCell = m_dicItemLadderCell[c];
                Point point = GetCellOrigin(cLadderCell.Row, cLadderCell.Column);

                foreach (CContact cContactChild in c.ContactS)
                {
                    if (!m_dicItemLadderCell.ContainsKey(cContactChild)) { continue; }

                    CLadderCell cLadderCellChild = m_dicItemLadderCell[cContactChild];

                    if ((cLadderCell.Row == cLadderCellChild.Row) && (Math.Abs(cLadderCell.Column - cLadderCellChild.Column) == 1)) { continue; }

                    Point pointNeighbor = GetCellOrigin(cLadderCellChild.Row, cLadderCellChild.Column);
                    Point pointTemp = GetCellOrigin(cLadderCellChild.Row, cLadderCell.Column);

                    graphics.DrawLine(m_penLine, point.X + m_nCellWidth, point.Y + m_nOffsetVertical, pointTemp.X + m_nCellWidth, pointTemp.Y + m_nOffsetVertical);
                    graphics.DrawLine(m_penLine, pointNeighbor.X, pointNeighbor.Y + m_nOffsetVertical, pointTemp.X + m_nCellWidth, pointTemp.Y + m_nOffsetVertical);

                }

                if (c.ContactS.Count == 0)
                {
                    Point pointTemp = GetCellOrigin(cLadderCellCoil.Row, cLadderCellCoil.Column - m_nGapCoilToMaxCol);
                    graphics.DrawLine(m_penLine, point.X + m_nCellWidth, point.Y + m_nOffsetVertical, pointTemp.X + m_nCellWidth, pointTemp.Y + m_nOffsetVertical);
                    graphics.DrawLine(m_penLine, pointCoil.X, pointCoil.Y + m_nOffsetVertical, pointTemp.X + m_nCellWidth, pointTemp.Y + m_nOffsetVertical);
                }
            });
        }

        private void GenerateCells()
        {
            m_hashCells.Clear();
            m_dicItemLadderCell.Clear();
            
            if (m_cCoil == null) { return; }

            int nColMax = -1;
            int nRowMax = 0;

            foreach (CContact cContact in m_cCoil.ContactS)
            {
                // Generate cells of contact that are directly child of m_cCoil (has no parent)
                if (!m_dicItemLadderCell.ContainsKey(cContact))
                {
                    int nRow = -1;
                    if (cContact.ContactS.Count == 0)
                    {
                        nRow = nRowMax;
                        nRowMax++;
                    }
                    else
                    {
                        // Find the available cell according to the childs
                        bool bAvailable = false;
                        foreach (CContact cContactChild in cContact.ContactS)
                        {
                            // If this child has not cell yet, no need to consider, 
                            if (!m_dicItemLadderCell.ContainsKey(cContactChild)) { continue; }
                            CLadderCell cLadderCellChild = m_dicItemLadderCell[cContactChild];

                            bool bFoundSlot = true;
                            foreach (CLadderCell cLadderCell in m_hashCells)
                            {
                                if (cLadderCell.Column != 0) { continue; }
                                if (cLadderCell.Row == cLadderCellChild.Row) { bFoundSlot = false; break; } // If this [Row, 0] has been occupied, it means this child's row can not be used
                            }

                            // if from above iteration does not result true, it means this child's row is available, then break
                            if (bFoundSlot) 
                            { 
                                nRow = cLadderCellChild.Row;
                                bAvailable = true;
                                break; 
                            } 
                        }

                        if (!bAvailable) { nRow = nRowMax; nRowMax++; }
                    }
                    
                    nColMax = nColMax < 0 ? 0 : nColMax;
                    CLadderCell cell = new CLadderCell(nRow, 0, cContact);
                    m_hashCells.Add(cell);
                    m_dicItemLadderCell.Add(cContact, cell);
                }

                // Then, for every child of every coil's contact, do ... 
                cContact.DoThis(m_cCoil, (c, parent) => // c is the cContact
                {
                    // CContact only
                    if (!(parent is CContact)) { return; }

                    CContact cContactParent = parent as CContact;
                    System.Diagnostics.Debug.Assert(m_dicItemLadderCell[parent] != null);
                    CLadderCell cLadderCellParent = m_dicItemLadderCell[parent];

                    int nR = cContactParent.ContactS.Count == 0 ? cLadderCellParent.Row : cLadderCellParent.Row + cContactParent.ContactS.IndexOf(c);
                    int nC = cLadderCellParent.Column + 1;

                    if (!m_dicItemLadderCell.ContainsKey(c))
                    {
                        CLadderCell cLadderCell = new CLadderCell(nR, nC, c);
                        m_hashCells.Add(cLadderCell);
                        m_dicItemLadderCell.Add(c, cLadderCell);
                        nRowMax = nRowMax > nR ? nRowMax + 1 : nR;
                        nColMax = nColMax > nC ? nColMax : nC;
                    } 
                });
            }

            // The coil
            CLadderCell cellCoil = new CLadderCell(0, nColMax + m_nGapCoilToMaxCol, m_cCoil);
            cellCoil.ColumnOccupied = 4;
            m_hashCells.Add(cellCoil);
            m_dicItemLadderCell.Add(m_cCoil, cellCoil);
        }

        private void CalculateBoundingBoxes()
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
                rMin = rMin > r ? r : rMin;
                rMax = rMax < r ? r : rMax;
                cMin = cMin > c ? c : cMin;
                cMax = cMax < c ? c : cMax;
            }

            m_listBoundingBoxes.Clear();
            Point LeftTop = GetCellOrigin(rMin, cMin);
            Point RightTop = GetCellOrigin(rMin, cMax);
            Point RightBottom = GetCellOrigin(rMax, cMax);
            Point LeftBottom = GetCellOrigin(rMax, cMin);
            m_listBoundingBoxes.Add(new CVertex(LeftTop.X, LeftTop.Y));
            m_listBoundingBoxes.Add(new CVertex(RightTop.X + m_nCellWidth, RightTop.Y));
            m_listBoundingBoxes.Add(new CVertex(RightBottom.X + m_nCellWidth, RightBottom.Y + m_nCellHeight));
            m_listBoundingBoxes.Add(new CVertex(LeftBottom.X, LeftBottom.Y + m_nCellHeight));
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

        #endregion
    }
}
