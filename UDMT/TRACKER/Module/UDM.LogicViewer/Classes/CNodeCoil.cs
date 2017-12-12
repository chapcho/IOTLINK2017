using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using DevComponents.Tree;
using UDM.Common;
using UDM.UDLImport;
using UDM.Log;

namespace UDM.LogicViewer
{
    public class CNodeCoil
    {
        #region Member Variables

        public delegate void UEventHandlerCoilDoubleClick(Node selectNode, TreeGXNodeMouseEventArgs e );
        public event UEventHandlerCoilDoubleClick UEventCoilDoubleClick;

        private Node m_selectNode = null;
        private CLogicHelper m_cLogicHelper = new CLogicHelper();

        private bool m_bMinMode = false;
        private bool m_bCoilOn= false;
        private string m_sAddress = string.Empty;
        private DateTime m_dtTime = DateTime.MinValue;
        private CLDRung m_cILRung = null;
        //private CILSymbolS m_cLcSymbolS = null;
        private ElementStyle m_styleBlock = new ElementStyle();

        #endregion

        #region Initialize/Dispose

        public CNodeCoil(Node selectNode, CLDRung cILRung, string sAddress, DateTime dtTime, bool bCoilOn, EMCoilStyle emCoilStyle, bool bFirstNode)
        {
            SetDefaultNodeStyle(emCoilStyle);

            m_selectNode = selectNode;
            m_selectNode.CellLayout = eCellLayout.Vertical;
            m_selectNode.ParentConnector = new DevComponents.Tree.NodeConnector();
            m_selectNode.Style = m_styleBlock;

            if (bFirstNode)
                m_selectNode.ParentConnector.LineWidth = EWidthBlock.BorderBase;
            else
                m_selectNode.ParentConnector.LineWidth = EWidthBlock.Border;

            m_selectNode.NodeDoubleClick += new System.EventHandler(this.SelectNode_NodeDoubleClick);
            m_selectNode.Disposed += new EventHandler(SelectNode_Disposed);
            
            m_cILRung = cILRung;
            //m_cLcSymbolS = cILSymbolS;

            m_bCoilOn = bCoilOn;
            m_dtTime = dtTime;
            m_sAddress = sAddress;

            InitializeCell();
        }

        #endregion

        #region Public Properties

        public CLDRung LDRung
        {
            get { return m_cILRung; }
        }

        public bool CoilOn
        {
            get { return m_bCoilOn; }
            set           {         
                m_bCoilOn = value;
                m_selectNode.Cells[(int)ECoilType.Addrss].Text = GetAddressCoil(m_cILRung.CoilAddress);
                SetMinMode(m_bMinMode);
            }
        }

        public DateTime Time
        {
            get { return m_dtTime; }
            set
            {
                m_dtTime = value;
                m_selectNode.Cells[(int)ECoilType.Time].Text = GetTimeCoil(m_dtTime, m_cILRung.CoilCommand);
                SetMinMode(m_bMinMode);
            }
        }

        public string Address
        {
            get { return m_sAddress; }
        }

        public string CoilCommand
        {
            get { return m_cILRung.CoilCommand; }
        }

        public bool IsMinMode
        {
            get { return m_bMinMode; }
        }

        public bool EndCoil
        {
            get { return m_selectNode.Cells[0].Checked; }
            set { m_selectNode.Cells[0].Checked = value; }
        }

        #endregion

        #region Public Methods

        public void SelectNode_Disposed(object sender, EventArgs e)
        {
            if (m_selectNode.Tag != null)
                m_selectNode.Tag = null;
        }
  
        public void SetMinMode(bool bMin)
        {
            m_bMinMode = bMin;

            foreach (Cell cell in m_selectNode.Cells)
            {
                if (bMin)
                {
                    cell.Text = cell.Text.Replace("<font size=\"+0\">", "<font size=\"+1\">");
                }
                else
                {
                    cell.Text = cell.Text.Replace("<font size=\"+1\">", "<font size=\"+0\">");
                }
            }
        }

        private void InitializeCell()
        {
            if (m_sAddress != string.Empty)
            {
                m_selectNode.Cells.Add(CreateAddressRow());
                m_selectNode.Cells.Add(CreateSymbolRow());
            }
            m_selectNode.Cells.Add(CreateTimeRow());
            m_selectNode.Cells.Add(CreateCommandRow());
        }

        private Cell CreateDefaultCell()
        {
            Cell cellRow = new Cell();
            cellRow.StyleNormal = new DevComponents.Tree.ElementStyle();
            cellRow.StyleNormal.TextColor = Color.Black;

            return cellRow;
        }

        private Cell CreateAddressRow()
        {
            Cell cellRow = CreateDefaultCell();
            cellRow.Text = GetAddressCoil(m_sAddress);

            cellRow.CheckBoxVisible = true;

//             if (cILRung.IsEndCoil)   //paju
//                 cellRow.Checked = true;

            return cellRow;
        }

        private Cell CreateSymbolRow()
        {
            Cell cellRow = CreateDefaultCell();
            cellRow.Text = GetSymbolCoil(m_cILRung.CoilSymbol); 
            
            return cellRow;
        }

        private Cell CreateTimeRow()
        {
            Cell cellRow = CreateDefaultCell();
            cellRow.Text = GetTimeCoil(m_dtTime, m_cILRung.CoilCommand);
            cellRow.StyleNormal.BackColor = EColorBlock.BackColor;
            cellRow.StyleNormal.BackColor2 = EColorBlock.BackColor;
            cellRow.StyleNormal.BackColorGradientAngle = 90;

            return cellRow;
        }

        public string GetAddressCoil(string sAddress)
        {
            CTag cTag = m_cILRung.Step.CoilS.GetFirstCoil().RefTagS[0];

            string sEnable = m_bCoilOn ? "T" : "F";
            if (cTag != null && cTag.DataType != EMDataType.Bool)
                sEnable = string.Empty;
            
            string strBase = string.Format("<font size=\"+0\"><span width=\"180\">{0}</span><span width=\"20\">{1}</span></font>"
                , sAddress
                , sEnable);

            return strBase;
        }

        public string GetSymbolCoil(string sSymbol)
        {
            string strBase = string.Format("<font size=\"+0\"><span width=\"200\">{0}</span></font>"
                , sSymbol.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;"));

            return strBase;
        }

        public string GetTimeCoil(DateTime dtTime, string sCommand)
        {
            string sTime = string.Format("{0}", dtTime.ToString("HH:mm:ss.fff"));

            //if (m_cILRung.Packet != -1)
            // sTime = string.Format("{0}-P{1}C{2}", dtTime.ToString("HH:mm:ss.fff"), m_cILRung.Packet,m_cILRung.Cycle);

            string strBase = string.Format("<font size=\"+0\"><span width=\"140\">{0}</span><span width=\"60\">{1}</span></font>"
                , sTime
                , CLogicHelper.GetSymbolHtml(sCommand));

            return strBase;
        }

        public bool UpdateCoilCommand()
        {
            if (m_selectNode.Cells.Count == 0)
                return false;

            m_selectNode.Cells.RemoveAt(m_selectNode.Cells.Count - 1);
            m_selectNode.Cells.Add(CreateCommandRow());

            return true;
        }

        #endregion

        #region Private Methods

        private Cell CreateCommandRow()
        {
            Cell cellRow = CreateDefaultCell();

            string sCommand = GetCommandParametor(m_cILRung.Step.CoilS.GetFirstCoil());

            if (m_cILRung.Step.MasterControl != string.Empty)
            {
                sCommand += string.Format("\r\n{0}", "CONTROL AREA");
                foreach (string sPosition in m_cILRung.Step.MasterControl.Split('*'))
                    sCommand += string.Format("\r\n {0}", sPosition);

            }

            if (m_cILRung.Step.ForNextControl != string.Empty)
            {
                sCommand += string.Format("\r\n{0}", "FORNEXT COUNT");
                foreach (string sPosition in m_cILRung.Step.ForNextControl.Split('*'))
                    sCommand += string.Format("\r\n {0}", sPosition);

            }

            if (m_cILRung.Step.CallControl != string.Empty)
            {
                sCommand += string.Format("\r\n{0}", "CALL POSITION");
                foreach (string sPosition in m_cILRung.Step.CallControl.Split('*'))
                    sCommand += string.Format("\r\n {0}", sPosition);
            }

            cellRow.Text = sCommand;

            return cellRow;
        }

        private string GetCommandParametor(CCoil cCoil)
        {
            string strCommand = string.Empty;
            CTimeLog cTimeLog = null;
            foreach (CContent cContent in cCoil.ContentS)
            {
                if (cContent.Parameter == string.Empty)
                    continue;

                //if (cContent.Parameter == EMParametorType.Src.ToString() || cContent.Parameter == EMParametorType.Dst.ToString())
                //    continue;
                if (cContent.ArgumentType == EMArgumentType.Tag)
                {
                    if (m_cILRung.TimeLogS != null)
                    {
                        if (cContent.Tag.DataType == EMDataType.Bool)
                            cTimeLog = m_cILRung.TimeLogS.GetLastLog(cContent.Tag.Key, m_dtTime.Add(new TimeSpan(1)), m_bCoilOn ? 1 : 0);
                        else
                            cTimeLog = m_cILRung.TimeLogS.GetLastLog(cContent.Tag.Key, m_dtTime.Add(new TimeSpan(1)));
                    }

                    if (cTimeLog == null)
                        cTimeLog = new CTimeLog();

                    if (cContent.Tag.Description != string.Empty)
                        strCommand += string.Format("[{0}]{1}({2}) : {3}\r\n", cContent.Parameter, cContent.Tag.Address, cTimeLog.Value, cContent.Tag.Description);
                    else
                        strCommand += string.Format("[{0}]({1}){2}\r\n", cContent.Parameter, cTimeLog.Value, cContent.Tag.Address);
                }
                else /*if (cLabel.LabelTag.TagType == EMTagType.Numeric)*/
                    strCommand += string.Format("[{0}]{1}\r\n", cContent.Parameter, cContent.Argument);
            }

            return strCommand;
        }
    
        private void SetDefaultNodeStyle(EMCoilStyle emCoilStyle)
        {
            if (emCoilStyle == EMCoilStyle.Normal)
                m_styleBlock.BackColor2 = EColorBlock.CoilNormal;
            else if (emCoilStyle == EMCoilStyle.Condition)
                m_styleBlock.BackColor2 = EColorBlock.CoilShift;
            m_styleBlock.BackColor = System.Drawing.Color.White;
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
            m_styleBlock.PaddingBottom = 2;
            m_styleBlock.PaddingLeft = 2;
            m_styleBlock.PaddingRight = 2;
            m_styleBlock.PaddingTop = 2;
            m_styleBlock.TextColor = System.Drawing.Color.Black;
        }

        #endregion

        #region UI Events

        private void SelectNode_NodeDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (UEventCoilDoubleClick != null)
                {
                    UEventCoilDoubleClick(m_selectNode, (TreeGXNodeMouseEventArgs)e);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }

        #endregion
    }
}
