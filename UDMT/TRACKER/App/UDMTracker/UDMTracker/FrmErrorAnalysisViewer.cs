﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.Tree;

using UDM.Common;
using UDM.Log;
using UDM.Log.DB;
using UDM.Flow;
using UDM.Monitor.Plc;
using UDM.Project;
using UDM.LogicViewer;

namespace UDMTracker
{
    public partial class FrmErrorAnalysisViewer : DevExpress.XtraEditors.XtraForm
    {

        #region Member Variables

        private bool m_bVerified = false;
        private bool m_bFirst = true;
        private bool m_bComplete = false;
        private CProject m_cProject = null;
        private CGroupLog m_cGroupLog = null;
        private CMonitorErrorInfo m_cErrorInfo = null;
        private CMonitor m_cMonitor = null;
        private CMySqlLogReader m_cReader = null;
        private CLogicDiagram m_cDiagram = null;        

        #endregion


        #region Initialize/Dispose

        public FrmErrorAnalysisViewer()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public CProject Project
        {
            get { return m_cProject; }
            set { m_cProject = value; }
        }

        public CGroupLog GroupLog
        {
            get { return m_cGroupLog; }
            set { m_cGroupLog = value; }
        }

        public CMonitorErrorInfo ErrorInfo
        {
            get { return m_cErrorInfo; }
            set { m_cErrorInfo = value; }
        }

        public CMonitor Monitor
        {
            get { return m_cMonitor; }
            set { m_cMonitor = value; }
        }

        public CMySqlLogReader Reader
        {
            get { return m_cReader; }
            set { m_cReader = value; }
        }

        #endregion


        #region Public Methods


        #endregion


        #region Private Methods

        private bool VerifyParameter()
        {
            if (m_cProject == null)
            {
                MessageBox.Show("Project is not created!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (m_cReader == null || m_cReader.IsConnected == false)
            {
                MessageBox.Show("Can't connect Database!!", "UDM Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ShowChart(CGroupLog cGroupLog)
        {
            if (m_bVerified == false)
                return;

            if (cGroupLog == null)
                return;

            if (m_cProject.GroupS.ContainsKey(cGroupLog.Key) == false)
                return;

            CGroup cGroup = m_cProject.GroupS[cGroupLog.Key];
            CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(cGroup.Key, cGroup.KeySymbolS, cGroupLog.CycleStart, cGroupLog.CycleEnd, cGroupLog.TimeLogS, true);
            if (cItemS == null || cItemS.Count == 0)
                return;

            CFlowCompareResultS cResultS = m_cProject.MasterPatternS.Compare(cGroup.Key, cGroupLog.Recipe, cItemS, true);
            if (cResultS == null)
            {
                cResultS = new CFlowCompareResultS();
                cResultS.FlowItemS = cItemS;
            }

            cResultS.Key = cGroup.Key;
            if (cResultS.MasterFlow != null)
                cResultS.MasterFlow.Normalize(cGroupLog.CycleStart);

            ucFlowResultViewer.ShowChart(cResultS);
        }

        private void InitDiagram(CProject cProject)
        {
            if (cProject != null)
            {
                if (m_cDiagram != null)
                {
                    m_cDiagram.UEventDrawDiagram -= new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
                    m_cDiagram.Dispose();
                    m_cDiagram = null;
                }

                m_cDiagram = new CLogicDiagram(cProject.StepS, cProject.TagS, ucLogicDiagramS);
                m_cDiagram.UEventDrawDiagram += new UEventHandlerDrawDiagram(m_cDiagram_UEventDrawDiagram);
            }
        }

        private void ShowDiagram(CMonitorErrorInfo cErrorInfo)
        {
            if (m_bVerified == false)
                return;

            List<CStep> lstStep = m_cProject.GetStepList(cErrorInfo.Symbol.Key);
            if (lstStep == null || lstStep.Count == 0)
                return;

            CStep cStep = lstStep[0];
            CTimeLogS cLogS = GetInstantTimeLogS(cStep);
            m_cDiagram.ShowDiagram(lstStep[0], cLogS, true, true, true);
        }

        private CTimeLogS GetInstantTimeLogS(CStep cStep)
        {
            CTimeLogS cLogS = null;

            this.Cursor = Cursors.WaitCursor;
            {
                List<CTag> lstTag = GetTagList(cStep);
                if (m_cMonitor != null && m_cMonitor.IsRunning && lstTag.Count > 0)
                    cLogS = m_cMonitor.ReadInstant(lstTag);

                lstTag.Clear();

                if (cLogS == null)
                    cLogS = new CTimeLogS();
            }
            this.Cursor = Cursors.Default;

            return cLogS;
        }

        private List<CTag> GetTagList(CStep cStep)
        {
            List<CTag> lstTag = new List<CTag>();

            CTag cTag;
            for (int i = 0; i < cStep.RefTagS.Count; i++)
            {
                cTag = cStep.RefTagS[i];
                if (cTag.DataType == EMDataType.Bool)
                    lstTag.Add(cTag);
            }

            return lstTag;
        }

		private void InitDetecting()
		{
			InitTreeGX();
		}

		private void InitTreeGX()
		{
			exTreeGX.Nodes.Clear();

			if (ErrorInfo.Symbol == null)
				return;
			Node BaseNode = new Node();
			BaseNode = SettingTextNode(m_cGroupLog.Key);
			Node nodeRoot = null;
			Node nodeChild = null;

			List<CNodeRank> lstNodeRank = new List<CNodeRank>();

			nodeRoot = SettingNode(m_cErrorInfo.Symbol);
			exTreeGX.Nodes.AddRange(new Node[] { BaseNode });
			BaseNode.Nodes.AddRange(new Node[] { nodeRoot });
			foreach (KeyValuePair<string, CSymbol> pair in ErrorInfo.Symbol.SubSymbolS)
			{
				nodeChild = SettingNode(pair.Value);
				nodeRoot.Nodes.AddRange(new Node[] { nodeChild });
			}

			nodeRoot.Expanded = true;

			CGroup cGroup = m_cProject.GroupS[GroupLog.Key];
			CFlowItemS cItemS = CTrackerHelper.CreateFlowItemS(cGroup.Key, cGroup.KeySymbolS, m_cGroupLog.CycleStart, m_cGroupLog.CycleEnd, m_cGroupLog.TimeLogS, true);
			CFlowCompareResultS cResultS = m_cProject.MasterPatternS.Compare(m_cGroupLog.Key, m_cGroupLog.Recipe, cItemS, true);

			GroupComparePattern(nodeRoot, cResultS, lstNodeRank);
		}
		private Node SettingTextNode(string sText)
		{
			Node node = new Node();
			node.CellLayout = eCellLayout.Vertical;
			node.Name = sText;
			node.DragDropEnabled = false;
			ElementStyle styleRootBlock = GetDefaultNodeStyle(CHighlightRankingColor.Normal);
			node.Style = styleRootBlock;
			Cell cellNodeGroup = CellStyleSetting();
			Cell cellText = CellStyleSetting();
			cellNodeGroup.Text = "Group";
			cellText.Text = sText;
			node.Cells.Add(cellNodeGroup);
			node.Cells.Add(cellText);
			node.Expanded = true;
			return node;
		}
		private Node SettingNode(CSymbol cSymbol)
		{
			Node node = new Node();

			node.CellLayout = eCellLayout.Vertical;
			node.Name = cSymbol.Name;
			node.DragDropEnabled = false;
			ElementStyle styleRootBlock = GetDefaultNodeStyle(CHighlightRankingColor.Normal);
			node.Style = styleRootBlock;

			Cell cellText = CellStyleSetting();
			Cell cellAddress = CellStyleSetting();
			Cell cellDescription = CellStyleSetting();
			CTag cTag = cSymbol.Tag;
			if (cTag.IsEndContact())
				cellText.Text = "[Contact]";
			else
				cellText.Text = "[Coil]";
			cellAddress.Text = cSymbol.Address;
			cellDescription.Text = cSymbol.Description;
			node.Cells.Add(cellText);
			node.Cells.Add(cellAddress);
			node.Cells.Add(cellDescription);

			return node;
		}
		private void GroupComparePattern(Node node, CFlowCompareResultS cResultS, List<CNodeRank> lstNodeRank)
		{
			// Rank //
			//1. Sub Node가 Missing일 때 발현 순서
			//2. Missing이 아닐 때 MasterPattern 시점과 가장 근접한 시점의 시작지점을 갖은 Node


			CFlow cMasterFlow = cResultS.MasterFlow;
			CFlowItemS cFlowItemS = cMasterFlow.FlowItemS;
			//Group Master Pattern의 시작 시간(Error 시점)
			DateTime dtMasterStart = DateTime.MinValue;
			DateTime dtMasterEnd = DateTime.MinValue;
			DateTime dtCoilStart = DateTime.MinValue;


			CFlowItem cFlowItem = cFlowItemS[node.Name];
			CTimeNodeS cItemNodeS = cFlowItemS[node.Name].TimeNodeS;

			for (int i = 0; i < cItemNodeS.Count; i++)
			{
				if (dtMasterStart == DateTime.MinValue)
					dtMasterStart = cItemNodeS[i].Start;
				else if (dtMasterStart <= cItemNodeS[i].Start)
					dtMasterStart = cItemNodeS[i].Start;

				if (dtMasterEnd == DateTime.MinValue)
					dtMasterEnd = cItemNodeS[i].End;
				else if (dtMasterEnd <= cItemNodeS[i].End)
					dtMasterEnd = cItemNodeS[i].End;
			}

			CTimeLogS cTimeLogS = m_cGroupLog.TimeLogS;

			if (cTimeLogS != null || cTimeLogS.Count != 0)
			{
				for (int i = cTimeLogS.Count - 1; i >= 0; i--)
				{
					CTimeLog cTimeLog = cTimeLogS[i];
					if (cTimeLog.Key.Equals(node.Name))
					{
						dtCoilStart = cTimeLog.Time;
						break;
					}
				}
			}

			if (dtCoilStart != DateTime.MinValue)
				ComparePattern(node, dtCoilStart, cMasterFlow, lstNodeRank);
			else
				lstNodeRank = ComparePattern(node, dtMasterStart, cMasterFlow, lstNodeRank);

			if (cFlowItem.SubFlow != null)
				for (int i = 0; i < node.Nodes.Count; i++)
					if(dtCoilStart != DateTime.MinValue)
						lstNodeRank = ComparePattern(node.Nodes[i], dtCoilStart, cFlowItem.SubFlow, lstNodeRank);
					else
						lstNodeRank = ComparePattern(node.Nodes[i], dtMasterStart, cFlowItem.SubFlow, lstNodeRank);

			HighLightNode(lstNodeRank);
		}
		private List<CNodeRank> ComparePattern(Node node, DateTime dtRoleTime, CFlow cMasterFlow, List<CNodeRank> lstNodeRank)
		{
			CFlowItemS cFlowItemS = cMasterFlow.FlowItemS;

			//Group Master Pattern의 시작 시간(Error 시점)
			DateTime dtMasterStart = DateTime.MinValue;
			DateTime dtMasterEnd = DateTime.MinValue;
			DateTime dtError = DateTime.MinValue;

			CFlowItem cFlowItem = cFlowItemS[node.Name];
			CTimeNodeS cItemNodeS = cFlowItemS[node.Name].TimeNodeS;
			CTimeLog cTimeLog = null;

			string sMasterState = "";
			string sLogState = "";

			Cell cellCurrentValue = new Cell();
			Cell cellMasterValue = new Cell();
			Cell cellMatchResult = new Cell();

			cellCurrentValue = CellStyleSetting();
			cellMasterValue = CellStyleSetting();
			cellMatchResult = CellStyleSetting();


			cellMasterValue.Text = "Pattern value : ";
			cellCurrentValue.Text = "Current Value : ";

			for (int i = 0; i < cItemNodeS.Count; i++)
			{
				if (dtMasterStart == DateTime.MinValue)
					dtMasterStart = cItemNodeS[i].Start;
				else if (dtMasterStart <= cItemNodeS[i].Start)
					dtMasterStart = cItemNodeS[i].Start;

				if (dtMasterEnd == DateTime.MinValue)
					dtMasterEnd = cItemNodeS[i].End;
				else if (dtMasterEnd <= cItemNodeS[i].End)
					dtMasterEnd = cItemNodeS[i].End;

				if(cItemNodeS[i].Start <= dtRoleTime)
				{
					sMasterState = "On";
				}
				else if(cItemNodeS[i].End <= dtRoleTime)
				{
					sMasterState = "Off";
				}
				else
				{
					sMasterState = "None";
				}
			}
			if (sMasterState == "")
				sMasterState = "None";
			cellMasterValue.Text = cellMasterValue.Text + sMasterState;
			// Master Pattern과 Log를 비교하여 Match or Non-Match 확인
			// 이 때 비교 중심은 해당 시점의 Log Value가 0인지 아닌지
			DateTime dtFrom = dtMasterStart;
			DateTime dtTo = dtMasterEnd;

			CTimeLogS cTimeLogS = m_cGroupLog.TimeLogS;

			if (cTimeLogS == null || cTimeLogS.Count == 0)
			{
				//None
				sLogState = "None";
			}
			else
			{
				for (int i = cTimeLogS.Count - 1; i >= 0; i--)
				{
					cTimeLog = cTimeLogS[i];
					if (cTimeLog.Key.Equals(node.Name))
					{

						if (cTimeLog.Time >= dtRoleTime)
						{
							if (cTimeLog.Value == 0)
							{
								sLogState = "On";
								dtError = cTimeLog.Time;
							}
							else if (cTimeLog.Value == 1)
							{
								sLogState = "None";
								dtError = cTimeLog.Time;
							}
						}
						else
						{
							if (cTimeLog.Value == 0)
							{
								if (sMasterState == "On")
								{
									if (sLogState == "None")
									{
										sLogState = "Off";
										dtError = cTimeLog.Time;
									}
										
								}
							}
							if (cTimeLog.Value == 1)
							{
								if (sLogState == "" || sLogState == "None")
								{
									sLogState = "On";
									dtError = cTimeLog.Time;
								}
							}
						}
					}
				}
			}

			if (sLogState == "")
			{
				sLogState = "None";
				dtError = DateTime.MinValue;
			}

			cellCurrentValue.Text = cellCurrentValue.Text + sLogState;

			node.Cells.Add(cellCurrentValue);
			node.Cells.Add(cellMasterValue);
			node.Cells.Add(cellMatchResult);

			if(sMasterState != sLogState)
			{
				CNodeRank cNodeRank = new CNodeRank();
				if (node.Name != ErrorInfo.Symbol.Key)
				{
					cNodeRank.Node = node;
					cNodeRank.TimeInfo = dtError;
					cNodeRank.Status = sLogState;
					lstNodeRank.Add(cNodeRank);
				}
				else
				{
					node.Style.BackColor = CHighlightRankingColor.SRank;
				}
			}

			return lstNodeRank;
		}

		private void HighLightNode(List<CNodeRank> lstNodeRank)
		{
			if (lstNodeRank.Count == 0)
				return;

			double nTotalSnd = -1;
			double nResult = -1;
			double nSub = 0.001;
			SortedList<double, Node> lstNode = new SortedList<double, Node>();
			for(int i = 0; i < lstNodeRank.Count; i++)
			{
				if (lstNodeRank[i].TimeInfo == DateTime.MinValue)
					nResult = 0;
				else
				{
					nTotalSnd = m_cGroupLog.CycleStart.Subtract(lstNodeRank[i].TimeInfo).TotalSeconds;
					if (nResult == -1)
						nResult = nTotalSnd;
				}


				if (lstNode.ContainsKey(nResult))
				{
					nResult = nResult + nSub;
					lstNode.Add(nResult, lstNodeRank[i].Node);
					nSub = nSub + 0.001;
				}
				else
				{
					lstNode.Add(nResult, lstNodeRank[i].Node);
				}
			}

			int iRound = lstNode.Count - 1;

			for(int i = 0; i <= iRound; i++)
			{
				if(i == 0 )
				{
					lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.SRank;
				}
				else if(i != 0 && i < 3)
				{
					lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.ARank;
				}
				else
				{
					lstNode.ElementAt(i).Value.Style.BackColor = CHighlightRankingColor.BRank;
				}
			}
		}

		private Cell CellStyleSetting()
		{
			Cell cellRow = new Cell();
			ElementStyle style = new ElementStyle();
			style = new DevComponents.Tree.ElementStyle();
			style.TextColor = Color.Black;
			cellRow.StyleNormal = style;
			return cellRow;
		}

		private ElementStyle GetDefaultNodeStyle(Color Highlihgt)
		{
			ElementStyle style = new ElementStyle();
			style.BackColor = Highlihgt;
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
        #endregion


        #region Event Methods

        private void FrmErrorAnalysisViewer_Load(object sender, EventArgs e)
        {
            m_bVerified = VerifyParameter();
            if (m_bVerified == false)
                return;

            if (m_cErrorInfo.ErrorType != EMMonitorGroupErrorType.Abnormal)
            {
                InitDetecting();
                ShowChart(m_cGroupLog);
            }
         
            InitDiagram(m_cProject);
        }

        private void btnChartZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomIn();
        }

        private void btnChartZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ZoomOut();
        }

        private void btnChartItemUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemUp();
        }

        private void btnChartItemDown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ucFlowResultViewer.ItemDown();
        }

        private void btnDiagramZoomIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDiagramZoomOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDiagramMaximize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(true);
        }

        private void btnDiagramMinimize_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ucLogicDiagramS.FocusedTab == null)
                return;

            UCLogicDiagram ucDiagram = ucLogicDiagramS.FocusedTab;
            ucDiagram.ShowMaxMode(false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tpgDiagramResult)
            {
                if (m_bFirst)
                    ShowDiagram(m_cErrorInfo);
            }
        }

        private void m_cDiagram_UEventDrawDiagram(Node selectNode, CLDRung cLDRung, DateTime dtCurrent)
        {
            if(m_bFirst)
            {
                m_bFirst = false;
                return;
            }

            if(cLDRung == null)
                return;

            CTimeLogS cLogS = null;
            if (cLDRung.Step != null)
                cLogS = GetInstantTimeLogS(cLDRung.Step);
            else
                cLogS = new CTimeLogS();

            cLDRung.TimeLogS = cLogS;
        }

        #endregion

	}
}

class CHighlightRankingColor
{
	public static Color Normal = Color.YellowGreen;
	public static Color SRank = Color.Red;
	public static Color ARank = Color.OrangeRed;
	public static Color BRank = Color.Orange;
}

class CNodeRank
{
	public DateTime TimeInfo;
	public Node Node;
	public string Status;
}