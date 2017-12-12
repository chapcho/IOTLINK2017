using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using DevComponents.Tree;

using UDM.General.Csv;
using UDM.LogicViewer;
using UDM.Common;
using UDM.UDLImport;
using UDM.Log;
using UDM.General;
using UDM.Log.Csv;
using UDM.Ladder;

namespace UDM.LogicViewer
{
    public class CLogicDiagram
    {
        private CLDRungS m_cILRungS = new CLDRungS();
        private CTagS m_cTagS = new CTagS();
        private UCLogicDiagram m_treeGXSelected = null;
        private UCLogicDiagramS m_ucLogicDiagramS = new UCLogicDiagramS();

        private bool m_bMotionAnalysis = false;
        private bool m_bInterlock = false;

        public event UEventHandlerDrawDiagram UEventDrawDiagram;
        public event UEventHandlerDeviceSubDepthRetrive UEventSubDepthRetrive;

        public CLogicDiagram(CStepS cStepS, CTagS cTagS, UCLogicDiagramS ucLogicDiagramS)
        {
            CLDConvet cLDConvet = new CLDConvet(cStepS);
            m_cILRungS = cLDConvet.LDRungS;
            m_cTagS = cTagS;
            m_ucLogicDiagramS = ucLogicDiagramS;
        }

        public void Dispose()
        {

        }

        #region Public Properties

        public CLDRungS RungS
        {
            get { return m_cILRungS; }
        }

        public UCLogicDiagram SelectedDiagram
        {
            get { return m_treeGXSelected; }
        }

        #endregion

        #region Public Methods

        public string ShowDiagram(string sStepKey, CTimeLogS cTimeLogS, bool bStartOn, bool bNewTab)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRungKey(sStepKey);

            if (cLDRung != null)
            {
                cLDRung.TimeLogS = cTimeLogS;
                if (bNewTab)
                    return AddTabDiagram(cLDRung, bStartOn);
                else
                    return CreateDiagram(cLDRung, bStartOn);
            }
            else
                return string.Empty;
        }


        public string ShowDiagram(CStep cStep, CTimeLogS cTimeLogS, bool bStartOn, bool bNewTab, bool bMotionAnalysis, bool bInterlock)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cStep);
            m_bMotionAnalysis = bMotionAnalysis;
            m_bInterlock = bInterlock;

            if (cLDRung != null)
            {
                cLDRung.TimeLogS = cTimeLogS;
                if (bNewTab)
                    return AddTabDiagram(cLDRung, bStartOn);
                else
                    return CreateDiagram(cLDRung, bStartOn);
            }
            else
                return string.Empty;
        }

        public string ShowDiagram(CLDRung cLDRung, CTimeLogS cTimeLogS, bool bStartOn, bool bNewTab)
        {

            if (cLDRung != null)
            {
                cLDRung.TimeLogS = cTimeLogS;
                if (bNewTab)
                    return AddTabDiagram(cLDRung, bStartOn);
                else
                    return CreateDiagram(cLDRung, bStartOn);
            }
            else
                return string.Empty;
        }


        public string ShowDiagram(CTag cTag, CTimeLogS cTimeLogS, bool bStartOn, bool bNewTab)
        {
            CLDRung cLDRung = m_cILRungS.FindCoilRung(cTag.Address);
            if (cLDRung == null)
            {
                List<CLDRung> lstRung = m_cILRungS.FindContactRung(cTag.Address);
                if (lstRung != null && lstRung.Count > 0)
                    cLDRung = lstRung[0];
            }

            if (cLDRung != null)
            {
                cLDRung.TimeLogS = cTimeLogS;
                if (bNewTab)
                    return AddTabDiagram(cLDRung, bStartOn);
                else
                    return CreateDiagram(cLDRung, bStartOn);
            }
            else
                return string.Empty;
        }


        public string ShowDiagram(CTag cTag, CTimeLogS cTimeLogS, bool bStartOn)
        {
            if (cTag != null)
            {
                AddTagNode(cTag, cTimeLogS, bStartOn);
                return cTag.Address;
            }
            else
                return string.Empty;
        }

        #endregion

        #region Private Methods

        private string CreateDiagram(CLDRung cLDRung, bool bStartOn)
        {
            try
            {
                if (UEventDrawDiagram != null)
                    UEventDrawDiagram(null, cLDRung, DateTime.Now);

                CTimeLogS cTimeLogS = cLDRung.TimeLogS;

                m_treeGXSelected = m_ucLogicDiagramS.FocusedTab;

                if (m_treeGXSelected == null)
                    return AddTabDiagram(cLDRung, bStartOn);

                string sTabName = CLogicHelper.GetBaseTabName(cLDRung);
                m_treeGXSelected.SetName(sTabName);

                if (m_treeGXSelected.NodeBase == null)
                {
                    m_treeGXSelected.ClearAll();
                    m_treeGXSelected.CreateBaseNode(true);
                }

                DateTime dtCurrent = DateTime.Now;
                dtCurrent = SetActiveBarTime(cLDRung, cTimeLogS, bStartOn);

                m_treeGXSelected.AddBaseNode(true);

                ApplyNodeTime(cLDRung, dtCurrent, bStartOn ? 1 : 0, new TimeSpan());
                CreateLogicCoil(cLDRung, cLDRung.CoilAddress, dtCurrent, bStartOn, false);
                DrawLogic(cLDRung, m_treeGXSelected.NodeCurrent, true);

                m_treeGXSelected.UEventTimeIndicatorChanged += new UEventHandlerLogicViewerTimeIndicatorChanged(ucLogicDiagram_UEventTimeIndicatorChanged);
                CLogicHelper.SetTimeShowCallback(m_treeGXSelected.NodeBase, true);
                CLogicHelper.UpdateMonitorCallBack(m_treeGXSelected.NodeBase);

                m_treeGXSelected.EndUpdate();

                return sTabName;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                return string.Empty;
            }
        }

        private string AddTabDiagram(CLDRung cLDRung, bool bStartOn)
        {
            if (cLDRung != null)
                return CreateTabDiagram(cLDRung, bStartOn);
            else
                return string.Empty;
        }

        private string CreateTabDiagram(CLDRung cLDRung, bool bStartOn)
        {
            try
            {
                string sTabName = CLogicHelper.GetBaseTabName(cLDRung);
                m_ucLogicDiagramS.AddTab(sTabName, (CTimeLogS) cLDRung.TimeLogS.Clone());

                CreateDiagram(cLDRung, bStartOn);

                return sTabName;
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private DateTime SetActiveBarTime(CLDRung cLDRung, CTimeLogS cTimeLogS, bool bStartOn)
        {
            if (cLDRung == null || cTimeLogS == null)
                return DateTime.MinValue;

            if (cLDRung.CoilCommand == "RST")
                bStartOn = false;
            if (cLDRung.CoilCommand == "SET")
                bStartOn = true;

            string sKey = cLDRung.GetFirstKey();

            bool bTimerCoil = cLDRung.CoilAddress.StartsWith("T");
            CTimeLogS cTimeLogSActiveBarOn = new CTimeLogS();
            CTimeLogS cTimeLogSActiveBarOff = new CTimeLogS();

            foreach (CTimeLog cTimeLog in cTimeLogS)
            {
                if (cTimeLog.Key != sKey)
                    continue;
                if (cTimeLog.Value == 0)
                    cTimeLogSActiveBarOff.Add(cTimeLog);
                else
                    cTimeLogSActiveBarOn.Add(cTimeLog);
            }

            if (bTimerCoil)
                m_treeGXSelected.TimeLogS = cTimeLogSActiveBarOn;
            else
                m_treeGXSelected.TimeLogS = cTimeLogSActiveBarOff;

            if (m_treeGXSelected.TimeLogS.Count == 0)
                return DateTime.MinValue;
            else
                return m_treeGXSelected.TimeLogS.Last().Time;
        }

        private ElementStyle GetDefaultNodeStyle()
        {
            ElementStyle style = new ElementStyle();
            style.BackColor = System.Drawing.Color.White;
            style.BackColor2 = System.Drawing.Color.White;
            style.BackColorGradientAngle = 90;
            style.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderBottomWidth = 1;
            style.BorderColor = System.Drawing.Color.DarkGray;
            style.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderLeftWidth = 1;
            style.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderRightWidth = 1;
            style.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            style.BorderTopWidth = 1;
            style.CornerDiameter = 4;
            style.CornerType = DevComponents.Tree.eCornerType.Rounded;
            style.Description = "Blue";
            style.Name = "Default";
            style.PaddingBottom = 1;
            style.PaddingLeft = 1;
            style.PaddingRight = 1;
            style.PaddingTop = 1;
            style.TextColor = System.Drawing.Color.Black;


            return style;
        }

        private void ShowLadder(CStep cStep, CTimeLogS cLogS)
        {
            CTag cTag = cStep.CoilS.GetFirstCoil().ContentS[0].Tag;

            UCLadderStep ucLadderStep = new UCLadderStep(cStep, cLogS, EditorBrand.Common);
            ucLadderStep.Dock = DockStyle.Fill;
            ucLadderStep.AutoSizeParent = true;
            ucLadderStep.ScaleDefault = 0.7f;// 0.6f;

            if (cTag == null)
                ucLadderStep.StepName = string.Format("Network : {0} / Command : {1}", cStep.StepIndex, cStep.Instruction.Replace("\t^EMPTY", string.Empty));
            else
                ucLadderStep.StepName = string.Format("Network : {0} / Coil : {1}", cStep.StepIndex, cTag.Description != string.Empty ? cTag.Description : cTag.Address);


            //여기 확인
            ucLadderStep.UEventSelectedCellData += ucStep_UEventSelectedCellData;

            Node NodeLadder = new Node();
            ElementStyle styleBlock = GetDefaultNodeStyle();
            styleBlock.MaximumWidth = ucLadderStep.Size.Width;
            styleBlock.MaximumHeight = ucLadderStep.Size.Height;

            NodeLadder.Style = styleBlock;
            NodeLadder.CellLayout = eCellLayout.Vertical;
            NodeLadder.ParentConnector = new DevComponents.Tree.NodeConnector();
            NodeLadder.ParentConnector.LineWidth = EWidthBlock.Border;
            NodeLadder.HostedControl = ucLadderStep;

            Node NodeLadderGroup = new Node();
            NodeLadderGroup.Text = "LADDER";
            NodeLadderGroup.Expand();
            NodeLadderGroup.NodeDoubleClick += new EventHandler(NodeLadderGroup_NodeDoubleClick);
            NodeLadderGroup.Nodes.Add(NodeLadder);
            if (m_treeGXSelected.NodeCurrent.Parent.Parent.Tag is CNodeCoil)
                m_treeGXSelected.NodeCurrent.Parent.Parent.Nodes.Add(NodeLadderGroup);
            else if (m_treeGXSelected.NodeCurrent.Parent.Parent.Parent.Tag is CNodeCoil)
                m_treeGXSelected.NodeCurrent.Parent.Parent.Parent.Nodes.Add(NodeLadderGroup);
        }

        private void ucStep_UEventSelectedCellData(CTag cTag, int iStepLevel, CTimeLogS cLogS)
        {

        }

        private void AddTagNode(CTag cTag, CTimeLogS cTimeLogS, bool bStartOn)
        {
            if (m_treeGXSelected == null)
                return;

            m_treeGXSelected = m_ucLogicDiagramS.FocusedTab;

            CNodeBlock cNodeBlock = GetNodeBlcokCallback(m_treeGXSelected.NodeBase.Nodes[0]);
            if (cNodeBlock == null)
                return; 

            CLDRung cLDRung = null;
            DateTime dtCoil = DateTime.Now;
            if (m_treeGXSelected.NodeBase.Nodes[0].Tag is CNodeCoil)
            {
                dtCoil = ((CNodeCoil)m_treeGXSelected.NodeBase.Nodes[0].Tag).Time;
                cLDRung = ((CNodeCoil)m_treeGXSelected.NodeBase.Nodes[0].Tag).LDRung;
            }

            DateTime dtTag = CLDRungHelper.GetLastTime(cTag.Key, cTimeLogS, dtCoil);

            int nValue = bStartOn ? 1 : 0;
            cNodeBlock.AddTAG(cTag, cLDRung, nValue, dtTag);
        }

        private void NodeLadderGroup_NodeDoubleClick(object sender, EventArgs e)
        {
            if (sender is Node)
            {
                Node node = (Node)sender;
                node.Expanded = !node.Expanded;
            }
        }

        private void DrawLogic(CLDRung cLDRung, Node nodeParent, bool bExpanded)
        {
            try
            {
                Node nodeCOMGroup = null;
                List<DateTime> m_ListDateTime = new List<DateTime>();

                foreach (var who in cLDRung.DIAGRAM_HEADS)
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

                    foreach (CLDNodeBody cILNode in cLDRung.DIAGRAM_HEADS[who.Key])
                    {
                        m_treeGXSelected.AddCurrentNode(nodeGroup, who.Key, true);

                        CNodeBlock cNodeBlock = new CNodeBlock(m_treeGXSelected.NodeCurrent, cILNode, cLDRung.CoilAddress, cILNode.GetUsedAddressNSymbol(m_cTagS), m_bMotionAnalysis, m_bInterlock);

                        //if(!m_bInterlock)
                        cNodeBlock.UEventSubCall += new CNodeBlock.UEventHandlerSubCall(this.MakeSubCallCoil);

                        m_treeGXSelected.NodeCurrent.Tag = cNodeBlock;
                    }
                }

                //   if (cLDRung.IsMixBlock)         //크리스  LADDER
                ShowLadder(cLDRung.Step, cLDRung.TimeLogS);

                if (m_treeGXSelected.TreeBase.Zoom < 0.3)
                    CLogicHelper.DrawMinMode(m_treeGXSelected.TreeBase.Nodes[0], true);

            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
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

        private void CreateLogicCoil(CLDRung cLDRung, string sAddress, DateTime dtCurrent, bool bCoilOn, bool bSubCoil)
        {
            try
            {
                CNodeCoil cNodeCoil = null;

                if (bSubCoil)
                    cNodeCoil = new CNodeCoil(m_treeGXSelected.NodeCurrent, cLDRung, sAddress, dtCurrent, bCoilOn, EMCoilStyle.Normal, false);
                else
                    if (m_treeGXSelected.NodeBase.Nodes.Count == 1)
                        cNodeCoil = new CNodeCoil(m_treeGXSelected.NodeBase.Nodes[m_treeGXSelected.NodeBase.Nodes.Count - 1], cLDRung, sAddress, dtCurrent, bCoilOn, EMCoilStyle.Normal, true);
                    else
                        cNodeCoil = new CNodeCoil(m_treeGXSelected.NodeBase.Nodes[m_treeGXSelected.NodeBase.Nodes.Count - 1], cLDRung, sAddress, dtCurrent, bCoilOn, EMCoilStyle.Normal, false);

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
                CTimeLogS cTimeLogS = cLDRung.TimeLogS;
                if (cTimeLogS == null)
                    return null;

                string sKey = cLDRung.GetFirstKey();
                CTimeLog cTimeLog = null;

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
                if (m_treeGXSelected.Keys == (Keys.Control | Keys.ShiftKey | Keys.LButton))
                {
                    CLDRung cLDRung = null;
                    CNodeCoil cNodeCoil = null;
                    if (NodeSelected.Tag is CNodeCoil)
                    {
                        cNodeCoil = (CNodeCoil)NodeSelected.Tag;
                        cLDRung = cNodeCoil.LDRung;
                    }
                    if (cNodeCoil == null)
                        return;

                    List<CLDRung> ListILRung = new List<CLDRung>();
                    for (int i = 0; i < cLDRung.Step.CoilS.GetFirstCoil().RefTagS.Count; i++)
                    {
                        CTag cTag = cLDRung.Step.CoilS.GetFirstCoil().RefTagS.GetValueAt(i);
                        ListILRung.AddRange(m_cILRungS.FindCoilRungS(cTag.Address));
                    }

                    cLDRung = GetSelectedRung(ListILRung);
                    if (cLDRung == null)
                        return;

                    m_treeGXSelected.BeginUpdate();

                    DrawShiftCoil(NodeSelected, cLDRung, cNodeCoil);

                    CLogicHelper.UpdateMonitorCallBack(NodeSelected);

                    m_treeGXSelected.EndUpdate();
                }
                else if (m_treeGXSelected.Keys == (Keys.Alt | Keys.ShiftKey | Keys.RButton))
                {
                    m_treeGXSelected.RemoveNode(NodeSelected);
                }
                else if (e.Button == MouseButtons.Left)
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

        private void ucLogicDiagram_UEventTimeIndicatorChanged(object sender, DateTime dtTime)
        {
            if (m_treeGXSelected.NodeBase.Nodes[0] == null || !(m_treeGXSelected.NodeBase.Nodes[0].Tag is CNodeCoil))
                return;

            m_treeGXSelected.BeginUpdate();

            foreach (Node nodeCoil in m_treeGXSelected.NodeBase.Nodes)
            {
                Object oData = nodeCoil.Tag;
                if (oData is CNodeCoil)
                {
                    CNodeCoil cNodeCoil = (CNodeCoil)oData;
                    cNodeCoil.Time = dtTime;
                    cNodeCoil.UpdateCoilCommand();

                    CLDRung cLDRung = cNodeCoil.LDRung;

                    ApplyNodeTime(cLDRung, dtTime, cNodeCoil.CoilOn ? 1 : 0, new TimeSpan());
                    SetTimeUpdateCallback(m_treeGXSelected.NodeBase);
                }
            }

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
                            cNodeCoil.UpdateCoilCommand();

                            if (cLDNodeRow.Address == cNodeCoil.Address)
                            {
                                cNodeCoil.Time = cLDNodeRow.Time;
                                dtCurrent = cLDNodeRow.Time;
                                iValue = cLDNodeRow.Value;

                                ApplyNodeTime(cNodeCoil.LDRung, dtCurrent, iValue, new TimeSpan(0));
                            }
                        }
                    }
                }

                SetTimeUpdateCallback(treeNode.Nodes[n]);
            }
        }

        private CNodeBlock GetNodeBlcokCallback(Node treeNode)
        {
            CNodeBlock cNodeBlock = null;
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                if (treeNode.Nodes[n].Tag is CNodeBlock)
                    cNodeBlock = (CNodeBlock)treeNode.Nodes[n].Tag;

                if (cNodeBlock != null)
                    break;

                cNodeBlock = GetNodeBlcokCallback(treeNode.Nodes[n]);
            }

            return cNodeBlock;
        }

        private void MakeSubCallCoil(Node nodeParent, CLDNodeRow cILNodeRow)
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

                CLDRung cLDRung = GetSelectedRung(ListILRung);
                if (cLDRung == null)
                    return;

                m_treeGXSelected.BeginUpdate();
                m_treeGXSelected.RemoveLogicTree(nodeParent);

                DrawSubCoil(nodeParent, cLDRung, cILNodeRow);

                CLogicHelper.UpdateMonitorCallBack(nodeParent);

                m_treeGXSelected.EndUpdate();
            }
            catch (System.Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }
        }

        private bool ApplyNodeTime(CLDRung cLDRung, DateTime dt, int nValue, TimeSpan tsOffset)
        {
            //if (cLDRung.TimeLogS != null && cLDRung.TimeLogS.Count > 0)
            //{
            //    cLDRung.Packet = cLDRung.TimeLogS[0].PacketIndex;
            //    cLDRung.Cycle = cLDRung.TimeLogS[0].CycleIndex;
            //}

            CLDRungHelper.UpdateNodeTime(dt, nValue, cLDRung, cLDRung.TimeLogS, tsOffset);

            return true;
        }

        private TimeSpan GetTimeShift(CLDRung cLDRung, DateTime dtCurrent, int nValue)
        {
            TimeSpan timeSpan = new TimeSpan();

            if (cLDRung.TimeLogS != null)
            {
                string sKey = cLDRung.GetFirstKey();
                CTimeLog cTimeLog = null;
                CTimeLogS cKeyTimeLogS = cLDRung.TimeLogS.GetTimeLogS(sKey, nValue);

                CTimeLogS cFindTimeLogS = cKeyTimeLogS.GetTimeLogS(DateTime.MinValue, dtCurrent);
                if (cFindTimeLogS.Count == 0)
                {
                    cFindTimeLogS = cKeyTimeLogS.GetTimeLogS(dtCurrent, DateTime.Now);
                    cTimeLog = cFindTimeLogS.GetFirstLog(sKey);
                    if (cTimeLog != null)
                        timeSpan = dtCurrent.Subtract(cTimeLog.Time);
                }
            }

            return timeSpan;
        }

        private void DrawSubCoil(Node nodeParent, CLDRung cLDRung, CLDNodeRow cILNodeRow)
        {
            if (UEventDrawDiagram != null)
                UEventDrawDiagram(nodeParent, cLDRung, cILNodeRow.Time);

            if (UEventSubDepthRetrive != null)
                UEventSubDepthRetrive(this, null); // symbol..


            int nValue = cILNodeRow.Value;
            if (m_treeGXSelected.Keys == (Keys.Control | Keys.ShiftKey | Keys.LButton))
                nValue = 1;
            else if (m_treeGXSelected.Keys == (Keys.Alt | Keys.ShiftKey | Keys.RButton))
                nValue = 0;

            TimeSpan timeSpan = GetTimeShift(cLDRung, cILNodeRow.Time, nValue);

            m_treeGXSelected.AddCurrentNode(nodeParent, EILGroup.COIL.ToString(), true);
            ApplyNodeTime(cLDRung, cILNodeRow.Time, nValue, timeSpan);
            CreateLogicCoil(cLDRung, cILNodeRow.Address, cILNodeRow.Time, nValue == 0 ? false : true, true);
            DrawLogic(cLDRung, m_treeGXSelected.NodeCurrent, true);

            CLogicHelper.SetTimeShowCallback(m_treeGXSelected.NodeBase, true);
        }

        private void DrawShiftCoil(Node NodeSelected, CLDRung cLDRung, CNodeCoil cNodeCoil)
        {
            if (UEventDrawDiagram != null)
                UEventDrawDiagram(NodeSelected, cLDRung, cNodeCoil.Time);

            bool bCoilOn = cNodeCoil.CoilOn;
            if (m_treeGXSelected.Keys == (Keys.Control | Keys.ShiftKey | Keys.LButton))
                bCoilOn = true;
            else if (m_treeGXSelected.Keys == (Keys.Alt | Keys.ShiftKey | Keys.RButton))
                bCoilOn = false;

            m_treeGXSelected.AddBaseNode(true);
            ApplyNodeTime(cLDRung, cNodeCoil.Time, bCoilOn ? 1 : 0, new TimeSpan());
            CreateLogicCoil(cLDRung, cLDRung.CoilAddress, cNodeCoil.Time, cNodeCoil.CoilOn, true);
            DrawLogic(cLDRung, m_treeGXSelected.NodeCurrent, true);
        }

        #endregion

    }
}