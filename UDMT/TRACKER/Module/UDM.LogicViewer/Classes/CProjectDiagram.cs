using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using DevComponents.Tree;

using UDM.General.Csv;
using UDM.General.WaitForm;
using UDM.LogicViewer;
using UDM.Common;
using UDM.Converter;
using UDM.Log;
using UDM.General;
using UDM.Log.Csv;
using UDM.Ladder;

namespace UDM.LogicViewer
{
    public class CProjectDiagram
    {
        private CLDRungS m_cILRungS = new CLDRungS();
        private CTagS m_cTagS = new CTagS();
        private CTimePacketLogS m_cPacketLogS = new CTimePacketLogS();
        private UCLogicDiagram m_treeGXSelected = null;
        private UCLogicDiagramS m_ucLogicDiagramS = new UCLogicDiagramS();
        private Dictionary<string, CTimeLogS> m_DicTimeLogS = new Dictionary<string, CTimeLogS>();
        private CCsvLogReader m_cCsvLogReader = new CCsvLogReader();
        private bool m_bFragment = false;

        public CProjectDiagram(CStepS cStepS, CTagS cTags, UCLogicDiagramS ucLogicDiagramS)
        {
            CLDConvet cLDConvet = new CLDConvet(cStepS);
            m_cILRungS = cLDConvet.LDRungS;
            m_ucLogicDiagramS = ucLogicDiagramS;
        }
       
        public void Dispose()
        {

        }

        #region Public Properties

      

        public bool IsFragment
        {
            get { return m_bFragment; }
            set { m_bFragment = value; }
        }

        public CLDRungS RungS
        {
            get { return m_cILRungS; }
        }

        #endregion

        #region Public Methods

        public string ShowDiagram(string sStepKey, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn, bool bNewCoil)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRungKey(sStepKey);

            if (cLDRung != null)
                return ShowDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn, bNewCoil);
            else
                return string.Empty;
        }


        public string ShowDiagram(CTag cTag, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn, bool bNewCoil)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cTag.Address);

            if (cLDRung != null)
                return ShowDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn, bNewCoil);
            else
                return string.Empty;
        }

        public string ShowDiagram(CStep cStep, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn, bool bNewCoil)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cStep);

            if (cLDRung != null)
                return ShowDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn, bNewCoil);
            else
                return string.Empty;
        }

        public string AddTabDiagram(CStep cStep, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cStep);

            if (cLDRung != null)
                return AddTabDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn);
            else
                return string.Empty;
        }

        public string AddTabDiagram(CTag cTag, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cTag.Address);

            if (cLDRung != null)
                return AddTabDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn);
            else
                return string.Empty;
        }

        public string ShowDiagram(CLDRung cLDRung , CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn, bool bNewCoil)
        {
            try
            {
                m_treeGXSelected = m_ucLogicDiagramS.TreeGXSelected;

                if (cLDRung == null)
                    return string.Empty;

                if (m_treeGXSelected == null)
                    return AddTabDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn);

                string sTabName = CLogicHelper.GetBaseTabName(cLDRung);
                m_treeGXSelected.SetName(sTabName);

                if (bNewCoil || m_treeGXSelected.NodeBase == null)
                {
                    m_treeGXSelected.ClearAll();
                    m_treeGXSelected.CreateBaseNode(true);
                    m_treeGXSelected.TreeBase.Zoom = (float)1.0;
                }

                bool bTimerCoil = cLDRung.CoilAddress.StartsWith("T");
                string sKey = cLDRung.GetFirstKey();

                if (dtCurrent == DateTime.MinValue)
                {
                    CTimeLog cTimeLog = GetLastLog(cLDRung, DateTime.MaxValue, bStartOn ? 1 : 0, bTimerCoil);
                    if (cTimeLog != null)
                    {
                        dtCurrent = cTimeLog.Time;
                        //  bCoilOn = cTimeLog.Value == 1 ? true : false;
                    }
                }

                if (cLDRung.CoilCommand == "RST")
                    bStartOn = false;
                if (cLDRung.CoilCommand == "SET")
                    bStartOn = true;

                m_treeGXSelected.AddBaseNode(true);

                CreateLogicCoil(cLDRung, cLDRung.CoilAddress, dtCurrent, bStartOn, false);
                ApplyNodeTime(cLDRung, cLDRung.LogPacketBlock, dtCurrent, bStartOn ? 1 : 0, new TimeSpan());
                DrawLogic(cLDRung, m_treeGXSelected.NodeCurrent, true);

                if (cTimeLogS != null)
                {
                    if (bTimerCoil)
                        m_treeGXSelected.TimeLogS = cTimeLogS.GetTimeLogS(sKey, 1);
                    else if (bStartOn)
                        m_treeGXSelected.TimeLogS = cTimeLogS.GetNTimeLogS(sKey, 0);
                    else
                        m_treeGXSelected.TimeLogS = cTimeLogS.GetTimeLogS(sKey, 0);
                }

                m_treeGXSelected.UEventTimeIndicatorChanged += new UEventHandlerLogicViewerTimeIndicatorChanged(ucLogicDiagram_UEventTimeIndicatorChanged);

                CLogicHelper.UpdateMonitorCallBack(m_treeGXSelected.NodeBase);

                m_treeGXSelected.EndUpdate();

                return sTabName;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        public string AddTabDiagram(CLDRung cLDRung, CTimeLogS cTimeLogS, DateTime dtCurrent, bool bStartOn)
        {
            try
            {
                if (cLDRung == null)
                    return string.Empty;

                string sTabName = CLogicHelper.GetBaseTabName(cLDRung);
                m_ucLogicDiagramS.AddTab(sTabName);

                ShowDiagram(cLDRung, cTimeLogS, dtCurrent, bStartOn, true);

                return sTabName;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }


        #endregion

        #region Private Methods


        private void ShowLadder(CStep cStep)
        {
            UCLadderStep ucLadderStep = new UCLadderStep(cStep, null, EditorBrand.MELSEC);
            Node NodeLadder = new Node();

            ElementStyle  styleBlock = new ElementStyle();
            styleBlock.BackColor = System.Drawing.Color.White;
            styleBlock.BackColor2 = System.Drawing.Color.White;
            styleBlock.BackColorGradientAngle = 90;
            styleBlock.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            styleBlock.BorderBottomWidth = 1;
            styleBlock.BorderColor = System.Drawing.Color.DarkGray;
            styleBlock.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            styleBlock.BorderLeftWidth = 1;
            styleBlock.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            styleBlock.BorderRightWidth = 1;
            styleBlock.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            styleBlock.BorderTopWidth = 1;
            styleBlock.CornerDiameter = 4;
            styleBlock.CornerType = DevComponents.Tree.eCornerType.Rounded;
            styleBlock.Description = "Blue";
            styleBlock.Name = "Default";
            styleBlock.PaddingBottom = 1;
            styleBlock.PaddingLeft = 1;
            styleBlock.PaddingRight = 1;
            styleBlock.PaddingTop = 1;
            styleBlock.TextColor = System.Drawing.Color.Black;

            NodeLadder.Style = styleBlock;
            NodeLadder.CellLayout = eCellLayout.Vertical;
            NodeLadder.ParentConnector = new DevComponents.Tree.NodeConnector();
            NodeLadder.ParentConnector.LineWidth = EWidthBlock.Border;

            NodeLadder.HostedControl = ucLadderStep;

            if (m_treeGXSelected.NodeCurrent.Parent.Parent.Tag is CNodeCoil)
                m_treeGXSelected.NodeCurrent.Parent.Parent.Nodes.Add(NodeLadder);
            else if (m_treeGXSelected.NodeCurrent.Parent.Parent.Parent.Tag is CNodeCoil)
                m_treeGXSelected.NodeCurrent.Parent.Parent.Parent.Nodes.Add(NodeLadder);
        }

        private void DrawLogic(CLDRung cILRung, Node nodeParent, bool bExpanded)
        {
            try
            {
                Node nodeCOMGroup = null;
                List<DateTime> m_ListDateTime = new List<DateTime>();

                foreach (var who in cILRung.DIAGRAM_HEADS)
                {
                    if (who.Key.Contains(EILGroup.C.ToString()))
                    {
                        m_treeGXSelected.AddCurrentNode(nodeParent, who.Key, bExpanded);
                        nodeCOMGroup = m_treeGXSelected.NodeCurrent;
                    }
                    else
                    {
                        m_treeGXSelected.AddCurrentNode(nodeCOMGroup, who.Key, bExpanded);
                    }

                    CNodeGroup cNodeGroup = new CNodeGroup(m_treeGXSelected.NodeCurrent, who.Key);
                    cNodeGroup.UEventExpand += new CNodeGroup.UEventHandlerExpand(this.SubNodeExpend);
                    m_treeGXSelected.NodeCurrent.Tag = cNodeGroup;
                    Node nodeGroup = m_treeGXSelected.NodeCurrent;
                    Dictionary<string, string> DicNodeAddress = new Dictionary<string, string>();

                    foreach (CLDNodeBody cILNode in cILRung.DIAGRAM_HEADS[who.Key])
                    {
                        m_treeGXSelected.AddCurrentNode(nodeGroup, who.Key, true);

                        CNodeBlock cNodeBlock = new CNodeBlock(m_treeGXSelected.NodeCurrent, cILNode, cILRung.CoilAddress, cILNode.GetUsedAddressNSymbol(m_cTagS), cILRung.LogPacketBlock);
                        cNodeBlock.UEventSubCall += new CNodeBlock.UEventHandlerSubCall(this.MakeSubCallCoil);
                        cNodeBlock.UEventSubCallBlock += new CNodeBlock.UEventHandlerSubCallBlock(this.MakeSubCallCoilAll);
                        m_treeGXSelected.NodeCurrent.Tag = cNodeBlock;
                    }
                }

               // if (cILRung.IsMixBlock)
                    ShowLadder(cILRung.Step);

                if (m_treeGXSelected.TreeBase.Zoom < 0.3)
                    CLogicHelper.DrawMinMode(m_treeGXSelected.TreeBase.Nodes[0], true);

            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private Dictionary<string, CTimeLogS> CreateEventTag()
        {
            Dictionary<string, CTimeLogS> DicTimeLog = new Dictionary<string, CTimeLogS>();

            foreach (var who in m_cPacketLogS)
            {
                foreach (CTimeLog cTimeLog in who.Value)
                {
                    if (DicTimeLog.ContainsKey(cTimeLog.Key))
                    {
                        DicTimeLog[cTimeLog.Key].Add(cTimeLog);
                    }
                    else
                    {
                        CTimeLogS cTimeLogSNew = new CTimeLogS();
                        cTimeLogSNew.Add(cTimeLog);
                        DicTimeLog.Add(cTimeLog.Key, cTimeLogSNew);
                    }
                }
            }

            foreach (CTimeLogS cTimeLogSReverse in DicTimeLog.Values)
                cTimeLogSReverse.Sort();

            return DicTimeLog;
        }

        private bool CreateSubCoil(Node nodeParent, CLDNodeRow cILNodeRow, bool bAllSub)
        {
            try
            {
                List<CLDRung> ListILRung = new List<CLDRung>();
                if (cILNodeRow.IsCompareRow)
                {
                    if (cILNodeRow.ContentSub1.Argument != string.Empty)
                        ListILRung = m_cILRungS.FindCoilRungS(cILNodeRow.ContentSub1.Argument);
                    if (cILNodeRow.ContentSub2.Argument != string.Empty)
                        ListILRung.AddRange(m_cILRungS.FindCoilRungS(cILNodeRow.ContentSub2.Argument));
                }
                else
                    if (cILNodeRow.Address != string.Empty)
                        ListILRung = m_cILRungS.FindCoilRungS(cILNodeRow.Address);

                if (bAllSub)
                {
                    foreach (CLDRung cLDRung in ListILRung)
                        DrawSubCoil(nodeParent, cLDRung, cILNodeRow);
                }
                else
                {
                    CLDRung cLDRung = GetSelectedRung(ListILRung);

                    if (cLDRung == null)
                    {
                        if (nodeParent.Tag is CNodeBlock)
                        {
                            CNodeBlock cNodeBlock = (CNodeBlock)nodeParent.Tag;


                            cNodeBlock.ClearSelectedRow();
                            return false;
                        }
                    }
                    if (m_cCsvLogReader != null && m_cCsvLogReader.LogType == EMLogType.Fragment)
                    {
                        bool bTimerCoil = cLDRung.CoilAddress.StartsWith("T");
                        CTimeLog cTimeLog = GetLastLog(cLDRung, DateTime.MaxValue, cILNodeRow.Value, bTimerCoil);
                        if (cTimeLog != null)
                            cILNodeRow.Time = cTimeLog.Time;
                    }
                    DrawSubCoil(nodeParent, cLDRung, cILNodeRow);
                }

                return true;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void DrawSubCoil(Node nodeParent, CLDRung cLDRung, CLDNodeRow cILNodeRow)
        {
            DateTime dt = cILNodeRow.Time;
            int nValue = cILNodeRow.Value;

            if (m_treeGXSelected.Keys == Keys.Control)
                nValue = 1;
            else if (m_treeGXSelected.Keys == Keys.Alt)
                nValue = 0;

            m_treeGXSelected.AddCurrentNode(nodeParent, EILGroup.COIL.ToString(), true);

            if (cILNodeRow.Block != cLDRung.LogPacketBlock)
            {
                CTimeLog cTimeLog = GetLastLog(cLDRung, DateTime.MaxValue, nValue, false);
                if (cTimeLog != null)
                    dt = cTimeLog.Time;
            }
            TimeSpan dtCalTime = new TimeSpan(0);
            if (cILNodeRow.Time >= dt)
                dtCalTime = cILNodeRow.Time.Subtract(dt);

            CreateLogicCoil(cLDRung, cILNodeRow.Address, cILNodeRow.Time, nValue == 0 ? false : true, true);
            ApplyNodeTime(cLDRung, cILNodeRow.Block, dt, nValue, dtCalTime);
            DrawLogic(cLDRung, m_treeGXSelected.NodeCurrent, true);
        }

        private CLDRung GetSelectedRung(List<CLDRung> ListILRung)
        {
            CLDRung cILRung = null;

            if (ListILRung.Count == 0)
                return null;

            Dictionary<string, CLDRung> DicRung = new Dictionary<string, CLDRung>();

            if (ListILRung.Count > 1)
            {
                List<string> ListSelect = new List<string>();
                foreach (CLDRung cILRungTemp in ListILRung)
                {
                    if (DicRung.ContainsKey(cILRungTemp.CoilKey))
                        continue;
                    DicRung.Add(cILRungTemp.CoilKey, cILRungTemp);

                    ListSelect.Add(string.Format("P: {0}.{1:0000}\t[{2}]"
                        , cILRungTemp.Step.Program
                        , cILRungTemp.Step.StepIndex
                        , cILRungTemp.Step.CoilS.GetFirstCoil().Instruction
                        ));
                }

                FrmMessage _FrmMessage = new FrmMessage(ListSelect, eMessageDialogLevel.SELECTOR);
                if (_FrmMessage.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                    return null;

                cILRung = ListILRung[_FrmMessage.SelectedIndex];

            }
            else
                cILRung = ListILRung[0];

            return cILRung;

        }

        private bool CreateSubCoilAll(Node nodeParent, List<CLDNodeRow> ListAddress)
        {
            try
            {
                foreach (CLDNodeRow cILNodeRow in ListAddress)
                {
                    List<CLDRung> ListILRung = new List<CLDRung>();

                    if (cILNodeRow.IsCompareRow)
                    {
                        ListILRung = m_cILRungS.FindCoilRungS(cILNodeRow.ContentSub1.Argument);
                        ListILRung.AddRange(m_cILRungS.FindCoilRungS(cILNodeRow.ContentSub2.Argument));
                    }
                    else
                        ListILRung = m_cILRungS.FindCoilRungS(cILNodeRow.Address);

                    if (ListILRung.Count > 0)
                    {
                        foreach (CLDNodeRow cNodeRow in ListAddress)
                            CreateSubCoil(nodeParent, cNodeRow, true);
                    }
                }

                return true;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void CreateLogicCoil(CLDRung cLDRung, string sAddress, DateTime dtCurrent, bool bCoilOn, bool bSubCoil)
        {
            try
            {
                CNodeCoil cNodeCoil = null;

                if (bSubCoil)
                    cNodeCoil = new CNodeCoil(m_treeGXSelected.NodeCurrent, cLDRung, sAddress, dtCurrent, bCoilOn, EMCoilStyle.Normal, m_cILRungS.SymbolS);
                else
                    cNodeCoil = new CNodeCoil(m_treeGXSelected.NodeBase.Nodes[m_treeGXSelected.NodeBase.Nodes.Count - 1], cLDRung, sAddress, dtCurrent, bCoilOn, EMCoilStyle.Normal, m_cILRungS.SymbolS);


                cNodeCoil.UEventCoilDoubleClick += new CNodeCoil.UEventHandlerCoilDoubleClick(this.CoilDoubleClick);
                m_treeGXSelected.NodeCurrent.Tag = cNodeCoil;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private CTimeLog GetLastLog(CLDRung cLDRung, DateTime dt, int iValue, bool bTimerCoil)
        {
            try
            {
                CTimeLog cTimeLog = null;
                CTimeLogS cTimeLogS = GetFragmentLogS(cLDRung);

                string sKey = cLDRung.GetFirstKey();

                if (bTimerCoil)
                {
                    if (cTimeLogS.Count > 1)
                        cTimeLogS = cTimeLogS.GetTimeLogS(sKey, 1);

                    if (iValue > 0)
                        cTimeLog = cTimeLogS.GetLastLog(sKey, dt, iValue);
                    else
                        cTimeLog = cTimeLogS.GetLastLog(sKey, dt, 0);
                }
                else
                {
                    if (iValue > 0)
                        cTimeLog = cTimeLogS.GetLastLog(sKey, dt, iValue);
                    else
                        cTimeLog = cTimeLogS.GetLastLog(sKey, dt, 0);
                }
                return cTimeLog;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void SubNodeExpend(Node nodeParent)
        {
            try
            {
                if (nodeParent.Expanded)
                    nodeParent.Expanded = false;
                else
                    nodeParent.Expanded = true;

            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void CoilDoubleClick(Node NodeSelected, TreeGXNodeMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    m_treeGXSelected.BeginUpdate();
                    if (!m_treeGXSelected.NodeBase.Nodes.Contains(NodeSelected))
                        m_treeGXSelected.NodeBase.Nodes.Add(NodeSelected);
                    m_treeGXSelected.EndUpdate();
                }
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void DrawSubCallBack(Node treeNode, List<string> ListUsedAddress, bool bSubAll)
        {
            try
            {
                for (int n = 0; n < treeNode.Nodes.Count; n++)
                {
                    if (treeNode.Nodes[n].Tag is CNodeBlock)
                    {
                        CNodeBlock cNodeBlock = (CNodeBlock)treeNode.Nodes[n].Tag;
                        List<CLDNodeRow> ListNode = cNodeBlock.GetListAddressSub();

                        List<CLDNodeRow> ListAddress = new List<CLDNodeRow>();

                        foreach (CLDNodeRow cILNodeRow in ListNode)
                        {
                            if (!ListUsedAddress.Contains(cILNodeRow.Address))
                            {
                                ListAddress.Add(cILNodeRow);
                                ListUsedAddress.Add(cILNodeRow.Address);
                            }
                        }

                        m_treeGXSelected.RemoveLogicTree(treeNode.Nodes[n]);

                        foreach (CLDNodeRow cILNodeRow in ListAddress)
                            CreateSubCoil(treeNode.Nodes[n], cILNodeRow, bSubAll);
                    }

                    int nShowSubLevel = 0;
                    if (bSubAll || CLogicHelper.GetNodeLevel(treeNode.Nodes[n]) <= nShowSubLevel)
                        DrawSubCallBack(treeNode.Nodes[n], ListUsedAddress, bSubAll);
                }
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void ucLogicDiagram_UEventTimeIndicatorChanged(object sender, DateTime dtTime)
        {
            object oData = m_treeGXSelected.NodeBase.Tag;
            if (oData == null)
                return;

            CNodeCoil cNodeCoil = (CNodeCoil)oData;
            cNodeCoil.Time = dtTime;

            CLDRung cLDRung = cNodeCoil.LDRung;

            m_treeGXSelected.BeginUpdate();

            ApplyNodeTime(cLDRung, cLDRung.LogPacketBlock, dtTime, cNodeCoil.CoilOn ? 1 : 0, new TimeSpan());
            SetTimeUpdateCallback(m_treeGXSelected.NodeBase);

            CLogicHelper.SetTimeShowCallback(m_treeGXSelected.NodeBase, true);

            m_treeGXSelected.EndUpdate();
        }

        private void SetTimeUpdateCallback(Node treeNode)
        {
            DateTime dtCurrent = DateTime.MinValue;
            int iValue = 0;
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                if (treeNode.Nodes[n].Tag is CNodeCoil && treeNode.Nodes[n].Parent.Tag is CNodeBlock)
                {
                    foreach (Cell cell in treeNode.Nodes[n].Parent.Cells)
                    {
                        if (cell.Tag is CLDNodeRow)
                        {
                            CLDNodeRow cLDNodeRow = (CLDNodeRow)cell.Tag;
                            CNodeCoil cNodeCoil = (CNodeCoil)treeNode.Nodes[n].Tag;

                            if (cLDNodeRow.Address == cNodeCoil.Address)
                            {
                                cNodeCoil.Time = cLDNodeRow.Time;
                                dtCurrent = cLDNodeRow.Time;
                                iValue = cLDNodeRow.Value;

                                if (cNodeCoil.LDRung.LogPacketBlock != cLDNodeRow.Block)
                                {
                                    CTimeLog cTimeLog = GetLastLog(cNodeCoil.LDRung, DateTime.MaxValue, cLDNodeRow.Value, cLDNodeRow.Address.StartsWith("T"));
                                    if (cTimeLog != null)
                                        dtCurrent = cTimeLog.Time;
                                }

                                ApplyNodeTime(cNodeCoil.LDRung, cLDNodeRow.Block, dtCurrent, iValue, cLDNodeRow.Time.Subtract(dtCurrent));
                            }
                        }
                    }
                }

                SetTimeUpdateCallback(treeNode.Nodes[n]);
            }
        }

        private void MakeSubCallCoilAll(Node nodeParent, List<CLDNodeRow> ListAddress)
        {
            try
            {
                m_treeGXSelected.BeginUpdate();
                m_treeGXSelected.RemoveLogicTree(nodeParent);

                CreateSubCoilAll(nodeParent, ListAddress);

                CLogicHelper.UpdateMonitorCallBack(nodeParent);

                m_treeGXSelected.EndUpdate();
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void MakeSubCallCoil(Node nodeParent, CLDNodeRow cILNodeRow)
        {
            try
            {
                m_treeGXSelected.BeginUpdate();
                m_treeGXSelected.RemoveLogicTree(nodeParent);

                CreateSubCoil(nodeParent, cILNodeRow, false);

                CLogicHelper.UpdateMonitorCallBack(nodeParent);

                m_treeGXSelected.EndUpdate();
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private bool ApplyNodeTime(CLDRung cILRung, int iPacket, DateTime dt, int nValue, TimeSpan tsOffset)
        {
            if (m_DicTimeLogS.Count == 0)
                return false;
            else
            {
                EMLogType emLogType = EMLogType.Normal;
                if (m_cCsvLogReader != null)
                    emLogType = m_cCsvLogReader.LogType;
                CStepTime cStepTime = new CStepTime(cILRung, m_DicTimeLogS, cILRung.LogPacketBlock, tsOffset, emLogType);
                cILRung.TimeOffset = tsOffset;
                cStepTime.ApplyNodeTime(dt, nValue);

                return true;
            }
        }

        private void AddShiftCoil(Node nodeParent, CLDRung cILRung, DateTime dtCurrent, bool bCoilOn)
        {
            try
            {
                m_treeGXSelected.AddCurrentNode(nodeParent, EILGroup.COIL.ToString(), false);
                CreateLogicCoil(cILRung, cILRung.CoilAddress, dtCurrent, bCoilOn,true);
                ApplyNodeTime(cILRung, cILRung.LogPacketBlock, dtCurrent, bCoilOn ? 1 : 0, new TimeSpan());
                DrawLogic(cILRung, m_treeGXSelected.NodeCurrent, false);

                CLogicHelper.UpdateMonitorCallBack(nodeParent);
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private void DrawSubCallAll(Node treeNode)
        {
            try
            {
                DrawSubCallBack(treeNode, new List<string>(), true);
                m_treeGXSelected.TreeBase.Zoom = 0.299999f;
                CLogicHelper.DrawMinMode(m_treeGXSelected.TreeBase.Nodes[0], true);
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }


        private CTimeLogS GetFragmentLogS(CLDRung cLDRung)
        {
            CTimeLogS cTimeLogS = new CTimeLogS();

            if (m_cCsvLogReader == null)
                return cTimeLogS;

            string sKey = cLDRung.GetFirstKey();

            if (m_cCsvLogReader.LogType == EMLogType.Fragment)
            {
                cTimeLogS = m_cPacketLogS.GetTimeLogS(cLDRung.LogPacketBlock);
            }
            else
            {
                cTimeLogS = m_cPacketLogS.GetTimeLogS(cLDRung.LogPacketBlock, sKey);
            }

            return cTimeLogS;
        }

        #endregion

    }
}