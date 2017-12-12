using System;
using System.Windows.Forms;
using System.Drawing;
using UDM.Project;
using UDM.LogicViewer;
using UDM.Flow;
using UDM.UI.GanttChart;
using UDM.Log;
using UDM.Log.DB;
using UDM.Common;

namespace UDM.Tile
{
	public partial class UCTileItemDetailView : UserControl
	{
		#region Member Variables
		private CGroupInfo m_cGroupInfo = null;
		private string m_sItemName = string.Empty;
		private bool m_bGanttChart = false;
		private bool m_bDiagram = false;

		protected CProject m_cProject = null;
		protected CFlowItemS m_cItemS = null;

		private CLogicDiagram m_cLogicDiagram = null;

		private CDBLogReader m_cReader = null;

		public event UEventHandlerDetailClose UEventDetailClose;

		#endregion

		#region Properties
		public CProject Project
		{
			get { return m_cProject; }
			set { m_cProject = value; }
		}
		public CFlowItemS ItemS
		{
			get { return m_cItemS; }
			set { m_cItemS = value; }
		}
		public CGroupInfo GroupInfo
		{
			get { return m_cGroupInfo; }
			set 
			{
				m_cGroupInfo = value;
				SetTextToButton();
			}
		}

		public CDBLogReader LogReader
		{
			get { return m_cReader; }
			set { m_cReader = value; }
		}

		public string ItemName
		{
			get { return this.m_sItemName; }
			set { m_sItemName = value; }
		}

		public bool GanttChartOn
		{
			get { return m_bGanttChart; }
			set 
			{ 
				m_bGanttChart = value;
				if (value)
				{
					GanttChartOnOff(value);
				}
			}
		}

		public bool DiagramOn
		{
			get { return m_bDiagram; }
			set 
			{
				m_bDiagram = value;
				if (value)
				{
					DiagramOnOff(value);
				}
			}
		}
		#endregion

		#region Initialize/Dispose
		public UCTileItemDetailView()
		{
			InitializeComponent();
			this.btnErrorAlert.Resize += new EventHandler(btnErrorAlert_Resize);
			this.btnView1.Resize += new EventHandler(btnView1_Resize);
			this.btnBack.Resize += new EventHandler(btnBack_Resize);
		}

		void btnBack_Resize(object sender, EventArgs e)
		{
			try
			{
				FontResizing(this.btnBack);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		void btnView1_Resize(object sender, EventArgs e)
		{
			try
			{
				FontResizing(this.btnView1);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void btnErrorAlert_Resize(object sender, EventArgs e)
		{
			try
			{
				FontResizing(this.btnErrorAlert);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

		private void btnView1_Click(object sender, EventArgs e)
		{
			try
			{
				if (btnView1.Text.Equals("래더"))
				{
                    GanttChartOn = false;
					DiagramOn = true;
					btnView1.Text = "차트";
					btnView1.ImageIndex = 1;
				}
                else if (btnView1.Text.Equals("차트"))
				{
                    DiagramOn = false;
					GanttChartOn = true;
                    btnView1.Text = "래더";
					btnView1.ImageIndex = 2;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		#region Event Methods
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		private void DiagramOnOff(bool bDiagramOn)
		{
			try
			{
				if (bDiagramOn)
				{
					GanttChartOnOff(false);


					DateTime dtFrom;
					DateTime dtTo;

					DateTime dtLast = m_cReader.GetLastLogTime();
					if (dtLast == DateTime.MinValue)
					{
						dtFrom = default(DateTime);
						dtTo = default(DateTime);
					}
					else
					{
						dtFrom = (DateTime)dtLast.AddMinutes(-30);
						dtTo = (DateTime)dtLast;
					}

                    if (m_cLogicDiagram == null)
					    m_cLogicDiagram = new CLogicDiagram(Project.StepS, Project.TagS, ucLogicDiagramS);
					CTag cTag = Project.TagS[GroupInfo.EventArgs.SourceSymbol.Key];;
					//m_cLDRung = m_cLogicDiagram.RungS.FindCoilRungKey();
					//m_cReader = new CDBLogReader();
					CTimeLogS cTimeLogS = m_cReader.GetTimeLogS(GroupInfo.EventArgs.SourceSymbol.Key, dtFrom, dtTo);
					//CTimeLogS cTimeLogS = m_cReader.GetTimeLogS(m_cLDRung.GetFirstKey());

                    ucLogicDiagramS.ClearTabs();

                    if (m_cLogicDiagram.SelectedDiagram == null)
                        m_cLogicDiagram.UEventDrawDiagram += new UEventHandlerDrawDiagram(m_cLogicDiagram_UEventDrawDiagram);
                    
                    m_cLogicDiagram.ShowDiagram(cTag, cTimeLogS, true, false);


					string sAddress = string.Empty;

					ucLogicDiagramS.Dock = DockStyle.Fill;
				}
				else
				{
					ucLogicDiagramS.Hide();
					ucFlowResultGanttViewer.Dock = DockStyle.Fill;
					ucFlowResultGanttViewer.Show();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void m_cLogicDiagram_UEventDrawDiagram(DevComponents.Tree.Node selectNode, CLDRung cLDRung, DateTime dtCurrent)
		{
			CTimeLogS cTimeLogSCoil = m_cReader.GetTimeLogS(cLDRung.GetFirstKey());
			try
			{
				if (cTimeLogSCoil != null && cTimeLogSCoil.Count > 0)
				{

					DateTime dtCoil = cTimeLogSCoil.GetLastLog().Time;

					CTimeLogS cTimeLogS = m_cReader.GetTimeLogS(dtCoil.AddHours(-1), dtCoil);

					cLDRung.TimeLogS = cTimeLogS;
				}

				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}


        private void GanttChartOnOff(bool bGanttChartOn)
        {
            try
            {
                if (bGanttChartOn)
                {
                    DiagramOnOff(false);

                    CGroup cGroup = m_cProject.GroupS[GroupInfo.EventArgs.Group.Key];

                    DateTime dtFrom;
                    DateTime dtTo;
                    DateTime dtLast = m_cReader.GetLastLogTime();
                    string sRecipe = "";

                    CGroupLogS latestGroupLogS = m_cReader.GetGroupLogLatestTime(GroupInfo.EventArgs.Group.Key, dtLast.AddMinutes(-60));

                    if (dtLast == DateTime.MinValue)
                    {
                        dtFrom = default(DateTime);
                        dtTo = default(DateTime);
                    }
                    else
                    {
                        if (latestGroupLogS != null && latestGroupLogS.Count > 0)
                        {
                            dtFrom = latestGroupLogS[0].CycleStart;
                            dtTo = latestGroupLogS[0].CycleEnd;
                            sRecipe = latestGroupLogS[0].Recipe;
                        }
                        else
                        {
                            dtTo = (DateTime)dtLast;
                            dtFrom = (DateTime)dtLast.AddMilliseconds(-cGroup.MaxCycleTime);
                        }
                    }

                    foreach (CSymbol src in cGroup.TotalSymbolS.Values)
                    {
                        if (src.IsMemberOf(cGroup.Key, EMGroupRoleType.General))
                            cGroup.TotalSymbolS.Remove(src.Key);
                    }

                    CFlowItemS cItemS = CreateFlowItemS(m_cReader, cGroup.Key, cGroup.TotalSymbolS, dtFrom, dtTo);
                    if (cItemS == null || cItemS.Count == 0)
                        return;

                    CFlowCompareResultS cResultS = Project.MasterPatternS.Compare(cGroup.Key, sRecipe, cItemS);
                    if (cResultS == null)
                    {
                        cResultS = new CFlowCompareResultS();
                        cResultS.FlowItemS = cItemS;
                    }
                    ucFlowResultGanttViewer.Clear();
                    ucFlowResultGanttViewer.ShowResult(cResultS);
                }
                else
                {
                    ucFlowResultGanttViewer.Hide();
                    ucLogicDiagramS.Dock = DockStyle.Fill;
                    ucLogicDiagramS.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

		private void SetTextToButton()
		{
			string sMessage;
			try
			{
				sMessage = string.Format(ItemName + "-");

				if (GroupInfo.EventArgs.SourceSymbol != null)
				{
					// sMessage += string.Format(GroupInfo.EventArgs.SourceSymbol.Description);

                    sMessage = string.Format("[{0}] {1} 지연!!", GroupInfo.EventArgs.SourceSymbol.Address, GroupInfo.EventArgs.SourceSymbol.Description);

					btnErrorAlert.Text = sMessage;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void FontResizing(DevExpress.XtraEditors.SimpleButton btn)
		{
			try
			{
				SizeF size;
				Graphics gBtnGraphics = btn.CreateGraphics();
				btn.Font = AppropriateFont(gBtnGraphics, 5, 45,
						  btn.Size, btn.Text, btn.Font, out size);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		private static Font AppropriateFont(Graphics g, float minFontSize,
			float maxFontSize, Size layoutSize, string s, Font f, out SizeF extent)
		{
			if (maxFontSize == minFontSize)
				f = new Font(f.FontFamily, minFontSize, f.Style);

			extent = g.MeasureString(s, f);
			if (maxFontSize <= minFontSize)
				return f;
			try
			{

				float hRatio = layoutSize.Height / extent.Height;
				float wRatio = layoutSize.Width / extent.Width;
				float ratio = (hRatio < wRatio) ? hRatio : wRatio;

				float newSize = f.Size * ratio;

				if (newSize < minFontSize)
					newSize = minFontSize;
				else if (newSize > maxFontSize)
					newSize = maxFontSize;

				f = new Font(f.FontFamily, newSize, f.Style);
				extent = g.MeasureString(s, f);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return f;
		}
		#endregion

		private void UCTileItemDetailView_Load(object sender, EventArgs e)
		{
			//ucLogGanttViewer.ShowLog(null, ItemS);
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			if (UEventDetailClose != null)
				UEventDetailClose(this, e);
		}
		private CFlowItemS CreateFlowItemS(CDBLogReader cLogReader, string sGroup, CSymbolS cSymbolS, DateTime dtFrom, DateTime dtTo)
		{
			if (cLogReader == null || cLogReader.IsConnected == false)
				return null;
				CFlowItemS cItemS = new CFlowItemS();
				cItemS.First = dtFrom;
				cItemS.Last = dtTo;

				CFlowItem cItem;
				CTimeLogS cLogS;
				CSymbol cSymbol;
				for (int i = 0; i < cSymbolS.Count; i++)
				{
					cSymbol = cSymbolS[i];

					cItem = new CFlowItem();
					cItem.Key = cSymbol.Key;
                    cItem.Group = sGroup;
					cItem.Description = cSymbol.Description;
					cItem.First = dtFrom;
					cItem.Last = dtTo;

					cLogS = cLogReader.GetTimeLogS(cSymbol.Key, dtFrom, dtTo);
					if (cLogS != null && cLogS.Count > 0)
					{
						CTag cTag = new CTag();
						cTag.Key = cSymbol.Key;
						cTag.DataType = cSymbol.DataType;
						cItem.TimeNodeS = new CTimeNodeS(cTag, cLogS, dtFrom, dtTo);
						cLogS.Clear();
						cLogS = null;
					}

					cItemS.Add(cSymbol.Key, cItem);
				}
			return cItemS;
		}
	}
}
