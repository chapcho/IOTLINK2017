using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevComponents.Tree;
using UDM.UDLImport;
using UDM.Common;

namespace UDM.LogicViewer
{
    public class CNodeBlock
    {
        #region Member Variables

        public delegate void UEventHandlerSubCall(Node selectNode, CLDNodeRow cILNodeRow);
        public event UEventHandlerSubCall UEventSubCall;

        private ElementStyle m_styleBlock = new ElementStyle();
        private Node m_selectNode = null;
        private bool m_bShowTime = false;
        private bool m_bMonitorOn = false;
        private bool m_bMonitorNone = false;
        private string m_sTime = string.Empty;
        //private int m_iPacket = -1;
        //private int m_iCycle = -1;
        private Dictionary<string, string> m_DicUsedAddress = new Dictionary<string, string>();

        private bool m_bMotionAnalysis = false;
        private bool m_bInterlock = false;

        //private delegate void MonitorOnBitCallBack(bool bMonitorOn, bool bbUserMonitor);

        #endregion

        #region Initialize/Dispose

        public CNodeBlock(Node selectNode, CLDNodeBody cILNodeBody, string sCoilAddress, Dictionary<string,string> DicUsedAddress, bool bMotionAnalysis, bool bInterlock)
        {
            SetDefaultNodeStyle();

            m_bMotionAnalysis = bMotionAnalysis;
            m_bInterlock = bInterlock;

            m_selectNode = selectNode;
            m_selectNode.Text = m_selectNode.Text;
            m_selectNode.CellLayout = eCellLayout.Vertical;
            m_selectNode.ParentConnector = new DevComponents.Tree.NodeConnector();
            m_selectNode.ParentConnector.LineWidth = EWidthBlock.Border;

            m_selectNode.Expanded = true;
            m_selectNode.Style = m_styleBlock;

            m_DicUsedAddress = DicUsedAddress;

            //m_iPacket = iPacket;
            //m_iCycle = iCycle;

            if (cILNodeBody.OR_DIAGRAM)
            {
                m_selectNode.Style.BackColor = EColorBlock.OR;
                m_selectNode.Style.BackColor2 = EColorBlock.BackColor;
            }
            else
            {
                m_selectNode.Style.BackColor = EColorBlock.And;
                m_selectNode.Style.BackColor2 = EColorBlock.BackColor;
            }

            
            InitializeCell(cILNodeBody, sCoilAddress);

            m_selectNode.NodeDoubleClick += new EventHandler(SelectNode_NodeDoubleClick);
            m_selectNode.NodeClick += new EventHandler(SelectNode_NodeClick);
            m_selectNode.Disposed += new EventHandler(SelectNode_Disposed);

            UpdateMonitorOnBit();

            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.Tag is CLDNodeRow)
                {
                    CLDNodeRow cLDNodeRow = (CLDNodeRow)cell.Tag;
                    UpdateCellRowStyle(cell, cLDNodeRow);
                }
            }

           // SetTimeOn();  //ahn
        }

        public bool AddTAG(CTag cTag, CLDRung cLDRung, int iValue, DateTime dt)
        {
            Cell cellRemove = null;
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.Tag is CLDNodeRow)
                    if (((CLDNodeRow)cell.Tag).Key == cTag.Key)
                        if (cell.StyleNormal.BorderRightColor == EColorBlock.TAG)
                            cellRemove = cell;
            }

            if (cellRemove != null)
            {
                m_selectNode.Cells.Remove(cellRemove);
                return false;
            }

            CLDNodeRow cLDNodeRow = new CLDNodeRow(cTag);
            if (cLDNodeRow == null)
                return false;

            m_selectNode.Cells.Add(CreateRow(cLDNodeRow, EColorBlock.TAG, dt, iValue));

            if (cLDRung != null)
                cLDRung.TagRowS.Add(cLDNodeRow);

            return true;
        }

        #endregion

        #region Public Properties

        public void SelectNode_Disposed(object sender, EventArgs e)
        {
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.Tag != null)
                    cell.Tag = null;
            }
        }

        public string Time
        {
            get { return m_sTime; }
            set { m_sTime = value; }
        }
        
        public string AddressSub
        {
            get
            {
                string AddressSub = ((CLDNodeRow)m_selectNode.SelectedCell.Tag).Address;

                return AddressSub;
            }
        }

        #endregion

        #region Public Methods

        public void SetMonitor(bool bMonitorOn ,bool bUserMonitor)
        {
            m_bMonitorOn = bMonitorOn;
            m_bMonitorNone = bUserMonitor;

            m_selectNode.BeginEdit();

            m_selectNode.Style.BorderWidth = EWidthBlock.Border;

            if (bMonitorOn)
            {
                m_selectNode.Style.BorderColor = EColorBlock.ON;
                m_selectNode.ParentConnector.LineColor = EColorBlock.ON;
            }
            else if (!bUserMonitor)
            {
                m_selectNode.Style.BorderColor = EColorBlock.Off;
                m_selectNode.ParentConnector.LineColor = EColorBlock.Off;
            }
            else
            {
                m_selectNode.Style.BorderColor = EColorBlock.MonitorNone;
                m_selectNode.ParentConnector.LineColor = EColorBlock.MonitorNone;
            }

            m_selectNode.EndEdit(false);
        }

        public void SetMinMode(bool bMin)
        {
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (bMin)
                {
                    if (cell.Tag is CLDNodeRow)
                        cell.Text = cell.Name;
                }
                else
                {
                    if (cell.Tag is CLDNodeRow)
                        cell.Text = ((CLDNodeRow)cell.Tag).RowFullName;
                }
            }
        }

        public void SetTimeMode()
        {
            m_bShowTime = !m_bShowTime;
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (!(cell.Tag is CLDNodeRow))
                    continue;

                CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                cILNodeRow.RowFullName = cILNodeRow.GetRowText();

                UpdateCellRowText(cell, cILNodeRow);
                UpdateCellRowStyle(cell, cILNodeRow);
            }
        }

        public void SetTimeOff()
        {
            m_bShowTime = false;
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.Tag is CLDNodeRow)
                {
                    CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                    cILNodeRow.RowFullName = cILNodeRow.GetRowText();
                    cell.Text = cILNodeRow.RowFullName;
                    UpdateCellRowStyle(cell, cILNodeRow);
                }
            }
        }

        public void SetTimeOn()
        {
            m_bShowTime = true;
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.Tag is CLDNodeRow)
                {
                    CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                    cILNodeRow.RowFullName = cILNodeRow.GetRowText();
                    UpdateCellRowText(cell, cILNodeRow);
                    UpdateCellRowStyle(cell, cILNodeRow);
                }
            }
        }

        public void UpdateSelectedRow()
        {
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                {
                    CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                    if (cILNodeRow.IsSelectedRow)
                        cell.StyleNormal.TextColor = Color.BlueViolet;
                    else
                        cell.StyleNormal.TextColor = Color.Black;
                }
            }
        }

        public void ClearSelectedRow()
        {
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                {
                    CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                    cILNodeRow.IsSelectedRow = false;
                    cell.StyleNormal.TextColor = Color.Black;
                }
            }
        }

        public List<CLDNodeRow> GetListAddressSub()
        {
            List<CLDNodeRow> ListAddress = new List<CLDNodeRow>();
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                {
                    CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                    if (cILNodeRow.ColorSubLink != Color.Transparent)
                        ListAddress.Add(cILNodeRow);
                }
            }

            return ListAddress;
        }

        public List<CLDNodeRow> GetListAddressCommand()
        {
            List<CLDNodeRow> lstLDNodeRow = new List<CLDNodeRow>();

            if (m_selectNode.SelectedCell != null)
            {
                CLDNodeRow cILNodeRow = (CLDNodeRow)m_selectNode.SelectedCell.Tag;
                if (cILNodeRow.Address != string.Empty)
                {
                    if (cILNodeRow.ColorSubLink != Color.Transparent)
                        lstLDNodeRow.Add(cILNodeRow);
                }
            }

            return lstLDNodeRow;
        }

        public void SetNodeRowTime(DateTime dtTime)
        {
            if (m_selectNode.SelectedCell != null)
            {
                foreach (Cell cell in m_selectNode.Cells)
                {
                    if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                    {
                        CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
                        cILNodeRow.Time = dtTime;
                        cell.Text = string.Format("{0}{1}", cILNodeRow.RowFullName, cILNodeRow.TimeString);
                    }
                }
            }
        }

        public void UpdateMonitorOnBit(string sAddress, int iValue)
        {
            int nContactAll = 0;
            int nContactOn = 0;
            bool bUserMonitor = false;

            if (m_selectNode.Parent.Tag is CNodeGroup)
            {
                if (m_selectNode.Parent.Text.Contains(EILGroup.M.ToString()))
                    bUserMonitor = true;
            }

            foreach(Cell cell in m_selectNode.Cells)
            {
                if(cell.Tag is CLDNodeRow)
                {
                    CLDNodeRow cLDNodeRow = (CLDNodeRow)cell.Tag;
                    string sNodeAddress = cLDNodeRow.Address;

                    if (sAddress != sNodeAddress)
                        break;

                    string sNodeInstruction = cLDNodeRow.Operator;
                    int iNodeValue = cLDNodeRow.Value;
                    nContactAll++;

                    if(cLDNodeRow.eILMonitor == EMContactState.On)
                    {
                        if((sNodeInstruction.Equals("XIC") || sNodeInstruction.Equals("XIOF") || sNodeInstruction.Equals("XICP")) && iValue == 0
                            || (sNodeInstruction.Equals("XIO") || sNodeInstruction.Equals("XICF") || sNodeInstruction.Equals("XIOP")) && iValue == 1)
                            cLDNodeRow.eILMonitor = EMContactState.Off;
                    }
                    else if(cLDNodeRow.eILMonitor == EMContactState.Off)
                    {
                        if ((sNodeInstruction.Equals("XIC") || sNodeInstruction.Equals("XIOF") || sNodeInstruction.Equals("XICP")) && iValue == 1
                            || (sNodeInstruction.Equals("XIO") || sNodeInstruction.Equals("XICF") || sNodeInstruction.Equals("XIOP")) && iValue == 0)
                        {
                            cLDNodeRow.eILMonitor = EMContactState.On;
                            nContactOn++;
                        }
                    }
                }
            }
            SetMonitor(nContactAll == nContactOn ? true : false, bUserMonitor);
        }

        public void UpdateMonitorOnBit()
        {
            int nContactAll = 0;
            int nContactOn = 0;
            bool bUserMonitor = false;

            if (m_selectNode.Parent.Tag is CNodeGroup)
            {
                if (m_selectNode.Parent.Text.Contains(EILGroup.M.ToString()))
                    bUserMonitor = true;
            }

            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                {
                    if (cell.Tag is CLDNodeRow)
                    {

                        CLDNodeRow cLDNodeRow = (CLDNodeRow)cell.Tag;
                        string sInstruction = cLDNodeRow.Operator;

                        int nValue = cLDNodeRow.Value;
                        nContactAll++;

                        if ((cLDNodeRow.Time == DateTime.MinValue && !cLDNodeRow.Address.StartsWith("SM")) 
                            || (cLDNodeRow.Time == DateTime.MinValue && !cLDNodeRow.Address.StartsWith("F")))
                            bUserMonitor = true;

                        cLDNodeRow.eILMonitor = EMContactState.Off;

                        if (cLDNodeRow.IsCompareRow)
                        {
                            if (cLDNodeRow.Value != 0)
                            {
                                cLDNodeRow.eILMonitor = EMContactState.On;
                                nContactOn++;
                            }
                            else
                                cLDNodeRow.eILMonitor = EMContactState.Off;
                        }
                        else
                        {
                            if ((sInstruction == "XIC" || sInstruction == "XIOF" || sInstruction == "XICP") && nValue == 1
                                || (sInstruction == "XIO" || sInstruction == "XICF" || sInstruction == "XIOP") && nValue == 0)
                            {
                                cLDNodeRow.eILMonitor = EMContactState.On;
                                nContactOn++;
                            }
                            else
                                cLDNodeRow.eILMonitor = EMContactState.Off;
                        }
                    }
                }
            }
            SetMonitor(nContactAll == nContactOn ? true : false, bUserMonitor);
        }

        public void UpdateBlockTimeValue(string sAddress, int nValue)
        {
            foreach (Cell cell in m_selectNode.Cells)
            {
                if (cell.StyleNormal != null && cell.StyleNormal.TextColor != Color.Empty)
                    if (sAddress == ((CLDNodeRow)cell.Tag).Address)
                    {
                        ((CLDNodeRow)cell.Tag).Value = nValue;
                    }
            }
        }

        #endregion

        #region Priate Methods

        private void SetDefaultNodeStyle()
        {
            m_styleBlock.BackColor = System.Drawing.Color.White;
            m_styleBlock.BackColor2 = System.Drawing.Color.White;
            m_styleBlock.BackColorGradientAngle = 90;
            m_styleBlock.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderBottomWidth = 1;
            m_styleBlock.BorderColor = System.Drawing.Color.DarkGray;
            m_styleBlock.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderLeftWidth = 1;
            m_styleBlock.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderRightWidth = 1;
            m_styleBlock.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderTopWidth = 1;
            m_styleBlock.CornerDiameter = 4;
            m_styleBlock.CornerType = DevComponents.Tree.eCornerType.Rounded;
            m_styleBlock.Description = "Blue";
            m_styleBlock.Name = "Default";
            m_styleBlock.PaddingBottom = 1;
            m_styleBlock.PaddingLeft = 1;
            m_styleBlock.PaddingRight = 1;
            m_styleBlock.PaddingTop = 1;
            m_styleBlock.TextColor = System.Drawing.Color.Black;
        }

        

        private void InitializeCell(CLDNodeBody cILNodeBody, string sCoilAddress)
        {
            List<string> lstAddress = new List<string>();
            foreach (CLDNodeRow cILNodeRow in cILNodeBody.ListILNodeRow)
            {
                if (cILNodeRow.Address == "SM400" || cILNodeRow.Address == "F00099" )
                    cILNodeRow.Value = 1;

                if ((cILNodeRow.Address == "SM400" && cILNodeRow.Instruction == EMContactTypeBit.Close.ToString()) || (cILNodeRow.Address == "SM401" && cILNodeRow.Instruction == EMContactTypeBit.Open.ToString())
                    || (cILNodeRow.Address == "F00099" && cILNodeRow.Instruction.Contains("XIC")) || (cILNodeRow.Address == "F00099" && cILNodeRow.Instruction.Contains("XIO")))
                {
                    if (!cILNodeBody.OR_DIAGRAM && !cILNodeBody.IsMixDiagram)
                        m_selectNode.Style.BackColor = EColorBlock.None;
                }

                if (cILNodeBody.IsMixDiagram)
                {
                    if (lstAddress.Contains(cILNodeRow.Key))
                        continue;
                    else
                        lstAddress.Add(cILNodeRow.Key);
                }

                Color colorItem = cILNodeRow.ColorSubLink;
                if (sCoilAddress == cILNodeRow.Address)
                    colorItem = Color.Transparent;

                if (cILNodeRow.IsCompareRow)
                {
                    if (cILNodeRow.ContentSub1.Tag != null)
                        cILNodeRow.Address = cILNodeRow.ContentSub1.Tag.Address;
                    else if (cILNodeRow.ContentSub2.Tag != null)
                        cILNodeRow.Address = cILNodeRow.ContentSub2.Tag.Address;

                    m_selectNode.Cells.Add(CreateCompareRow(cILNodeRow));
                }
                else
                {
                    if (cILNodeRow.Contact.RefTagS.Count > 0)
                        cILNodeRow.Address = cILNodeRow.Contact.RefTagS[0].Address;

                    m_selectNode.Cells.Add(CreateRow(cILNodeRow, colorItem, cILNodeRow.Time, cILNodeRow.Value));
                }
            }
        }

        private Cell CreateCompareRow(CLDNodeRow cILNodeRow)
        {
            Cell cellRow = new Cell();
           // cellRow.CheckBoxVisible = true;
            cellRow.Name = string.Format("{0} ({1})", cILNodeRow.Address, cILNodeRow.Value);
            cellRow.Tag = cILNodeRow;
            cellRow.Text = cILNodeRow.GetCompareRowText();

            cILNodeRow.RowFullName = cellRow.Text;
            cILNodeRow.Time = cILNodeRow.Time_Sub1;

            if (cILNodeRow.Time_Sub1.CompareTo(cILNodeRow.Time_Sub2) < 0)
                cILNodeRow.Time = cILNodeRow.Time_Sub2;

            UpdateSubCoilColor(cellRow, cILNodeRow.ColorSubLink, true);

            return cellRow;
        }

        private Cell CreateRow(CLDNodeRow cILNodeRow, Color color, DateTime dtNodeTime, int nValue)
        {
            Cell cellRow = new Cell();
            cellRow.Name = string.Format("{0} ({1})", cILNodeRow.Address, cILNodeRow.Value);
            cellRow.Tag = cILNodeRow;

            cILNodeRow.Value = nValue;
            cILNodeRow.Time = dtNodeTime;
            cellRow.Text = cILNodeRow.GetRowText();


            cILNodeRow.RowFullName = cellRow.Text;

            UpdateSubCoilColor(cellRow, color,false);

            return cellRow;
        }

        private void UpdateCellRowText(Cell cellRow, CLDNodeRow cILNodeRow)
        {
            if (m_bShowTime)
            {
                if (cILNodeRow.Time == DateTime.MinValue && (cILNodeRow.Note != string.Empty || cILNodeRow.NoteCompare != string.Empty))
                {
                    if (cILNodeRow.IsCompareRow)
                        cellRow.Text = string.Format("{0}{1}\r\n{2}", cILNodeRow.RowFullName, cILNodeRow.Note, cILNodeRow.NoteCompare);
                    else
                        cellRow.Text = string.Format("{0}{1}", cILNodeRow.RowFullName, cILNodeRow.Note);
                }
                else
                {
                    string sTime = string.Format("{0}", cILNodeRow.TimeString);
                    //if (m_iPacket != -1)
                    //    sTime = string.Format("{0}-P{1}C{2}", cILNodeRow.TimeString, m_iPacket, m_iCycle);

                    cellRow.Text = string.Format("{0}{1}", cILNodeRow.RowFullName, sTime);
                }
            }
            else
            {
                cellRow.Text = cILNodeRow.RowFullName;
            }
        }

        private void UpdateCellRowStyle(Cell cellRow, CLDNodeRow cILNodeRow)
        {
            if ((!m_bMotionAnalysis && cILNodeRow.Last) || (m_bMotionAnalysis && !m_bInterlock && cILNodeRow.eILMonitor == EMContactState.Off) 
                || (m_bMotionAnalysis && m_bInterlock && cILNodeRow.eILMonitor == EMContactState.On) )// || m_bMonitorOn || m_bMonitorNone)
            {
                cellRow.StyleNormal.BackColor = Color.Pink;
                cellRow.StyleNormal.BackColor2 = EColorBlock.RowDelay;
            }
            else
            {
                if (cellRow.StyleNormal.BorderRightColor == EColorBlock.TAG)
                {
                    cellRow.StyleNormal.BackColor = Color.LightGray;
                    cellRow.StyleNormal.BackColor2 = Color.White;
                }
                else
                {
                    cellRow.StyleNormal.BackColor = Color.Empty;
                    cellRow.StyleNormal.BackColor2 = Color.Empty;
                }
            }
        }

        private void UpdateSubCoilColor(Cell cellRow, Color color, bool bCompareRow)
        {
            cellRow.StyleNormal = new DevComponents.Tree.ElementStyle();
            cellRow.StyleNormal.Border = eStyleBorderType.Solid;
            cellRow.StyleNormal.BorderRightWidth = 10;
            cellRow.StyleNormal.BorderRightColor = color;
            cellRow.StyleNormal.TextColor = Color.Black;

            if (cellRow.StyleNormal.BorderRightColor == EColorBlock.TAG)
            {
                cellRow.StyleNormal.BackColor = Color.LightGray;
                cellRow.StyleNormal.BackColor2 = Color.White;
            }

            if (bCompareRow)
            {
                cellRow.StyleNormal.BackColor = EColorBlock.RowCompare;
            }
        }

        public void UpdateTimeCoil()
        {
            if (m_selectNode != null)
            {
                if (m_selectNode.Tag is CNodeBlock)
                {
                    if (m_selectNode.Parent.Tag is CNodeGroup)
                    {
                        CNodeCoil cNodeCoil = null;

                        if (m_selectNode.Parent.Parent.Tag is CNodeCoil)
                            cNodeCoil = (CNodeCoil)m_selectNode.Parent.Parent.Tag;
                        else if (m_selectNode.Parent.Parent.Parent.Tag is CNodeCoil)
                            cNodeCoil = (CNodeCoil)m_selectNode.Parent.Parent.Parent.Tag;

                        if (cNodeCoil != null)
                        {
                            CNodeBlock cNodeBlock = (CNodeBlock)m_selectNode.Tag;
                            SetNodeRowTime(cNodeCoil.Time);
                        }
                    }
                }
            }
        }

   
        #endregion

        #region UI Events

        private void SelectNode_NodeDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (m_selectNode.SelectedCell == null)
                    return;

                if (m_selectNode.SelectedCell == m_selectNode.Cells[0])
                    return;

                if (m_selectNode.SelectedCell.StyleNormal.BorderRightColor != Color.Transparent)
                {
                    ClearSelectedRow();
                    CLDNodeRow cILNodeRow = (CLDNodeRow)m_selectNode.SelectedCell.Tag;
                    cILNodeRow.IsSelectedRow = true;
                    UEventSubCall(m_selectNode, cILNodeRow);
                }

                UpdateSelectedRow();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }

        private void SelectNode_NodeClick(object sender, EventArgs e)
        {
            try
            {
//                 if (m_selectNode.SelectedCell == null)
//                     return;
// 
//                 foreach (Cell cell in m_selectNode.Cells)
//                 {
//                     if (cell.Tag is CLDNodeRow)
//                     {
//                         CLDNodeRow cILNodeRow = (CLDNodeRow)cell.Tag;
//                         UpdateCellRowText(cell, cILNodeRow);
//                         UpdateCellRowStyle(cell, cILNodeRow);
//                     }
//                 }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }

        private void NodeSimulation(string sAddress, string sInstruction, int iValue)
        {

        }

        #endregion

    }
}
