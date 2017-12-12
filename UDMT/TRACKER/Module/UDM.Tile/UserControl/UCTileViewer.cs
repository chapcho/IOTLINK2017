using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;
using UDM.Project;
using UDM.Log.DB;

namespace UDM.Tile
{
	public partial class UCTileViewer : UserControl
	{
		#region Member Variables
		private UCTileControl ucTileControl = new UCTileControl();
		private UCTileItemErrorAlert ucTileItemErrorAlert = null;
		private UCTileItemDetailView ucTileItemDetailView = null;
		private CDBLogReader m_cReader = null;
		private CProject m_cProject = null;
		#endregion

		#region Properties
		public CProject Project
		{
			get { return m_cProject; }
			set { m_cProject = value; }
		}

		public CDBLogReader LogReader
		{
			get { return m_cReader; }
			set { m_cReader = value; }
		}
		public Color ItemErrorColor
		{
			get { return ucTileControl.ItemErrorColor; }
			set { ucTileControl.ItemErrorColor = value; }
		}

		public CGroupInfoS GroupInfoS
		{
			get { return ucTileControl.GroupInfoS; }
			set { ucTileControl.GroupInfoS = value; }
		}
		#endregion

		#region Initialize/Dispose
		public UCTileViewer()
		{
			InitializeComponent();
			ucTileControl.UEventTileItemErrorColorChanged += new UEventHandlerTileItemErrorColorChaged(ucTileControl_UEventTileItemErrorColorChanged);
			ucTileControl.UEventTileItemNormalColorChanged += new UEventHandlerTileItemNormalColorChanged(ucTileControl_UEventTileItemNormalColorChanged);
			ucTileControl.UEventTileItemClick += new UEventHandlerTileItemClick(ucTileControl_UEventTileItemClick);
		}

		#endregion

		#region Events

		private void ucTileControl_UEventTileItemClick(object Sender, DevExpress.XtraEditors.TileItem item)
		{
			if (GroupInfoS[item.Name].EventArgs != null)
			{
				if (GroupInfoS[item.Name].EventArgs.Group.StateType == EMStateType.Error)
				{
					ucTileItemDetailView = new UCTileItemDetailView();
					ucTileItemDetailView.UEventDetailClose += new UEventHandlerDetailClose(ucTileItemDetailView_UEventDetailClose);
					ucTileItemDetailView.Project = Project;
					ucTileItemDetailView.LogReader = m_cReader;
					ucTileItemDetailView.ItemName = item.Name;
					ucTileItemDetailView.GroupInfo = GroupInfoS[item.Name];
					// ucTileItemDetailView.DiagramOn = true;
                    ucTileItemDetailView.GanttChartOn = true;

					if(ucTileItemErrorAlert != null) ucTileItemErrorAlert.Hide();
					ucTileItemDetailView.Dock = DockStyle.Fill;
					//ucTileItemDetailView.Show();
					Controls.Add(ucTileItemDetailView);
					ucTileControl.StopMoveTileView();
					ucTileControl.Hide();
					ucTileControl.Visible = false;
				}
			}
		}

		private void UCTileViewer_Load(object sender, EventArgs e)
		{
			ucTileControl.Dock = DockStyle.Fill;
			this.Controls.Add(ucTileControl);
		}


		private void ucTileItemDetailView_UEventDetailClose(object sender, EventArgs args)
		{

			try
			{
				ucTileItemDetailView.UEventDetailClose -= new UEventHandlerDetailClose(ucTileItemDetailView_UEventDetailClose);
				Controls.Remove(ucTileItemDetailView);
				ucTileItemDetailView.Dispose();
				ucTileControl.Dock = DockStyle.Fill;
				ucTileControl.Visible = true;
				ucTileControl.StartMoveTileView();
				ucTileControl.Show();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void ucTileItemErrorAlert_UEventErrorAlertClick(object Sender, CGroupInfo cGroupInfo)
		{
			try
			{
				if (cGroupInfo.EventArgs.SourceSymbol != null && cGroupInfo.EventArgs.SymbolGroup != null)
				{
					this.ucTileControl.Visible = true;
					ucTileControl.StartMoveTileView();
					ucTileControl.Show();
					ucTileItemErrorAlert.Hide();
					if (ucTileItemErrorAlert.CheckButtonCount() == 0)
					{
						ucTileItemErrorAlert.UEventErrorAlertClick -= new UEventHandlerAlertButtonClick(ucTileItemErrorAlert_UEventErrorAlertClick);
						Controls.Remove(ucTileItemErrorAlert);
						ucTileItemErrorAlert.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void ucTileControl_UEventTileItemNormalColorChanged(object Sender, DevExpress.XtraEditors.TileItem item, CMonitorEventArgs Args)
		{
			try
			{
				//AddTileItem("Normal", item.Name, item.Text);
				//ucTileControl.RemoveTileItem(ucTileControl.GetTileGroupByName("Abnormal"), item);
				//item = ucTileControl.GetTileItemByName(item.Name);

				if (item == null)
					return;
				else
				{
					item.AppearanceItem.Normal.BackColor = ucTileControl.ItemNormalColor;
					if (ucTileItemDetailView != null && !ucTileItemDetailView.IsDisposed)
					{
						if (ucTileItemDetailView.GroupInfo.Name.Equals(item.Name))
						{
							ucTileItemDetailView.Hide();
							ucTileItemDetailView_UEventDetailClose(this, ucTileItemDetailView.GroupInfo.EventArgs);
						}
					}
					else
					{

						if (ucTileItemErrorAlert != null && !ucTileItemErrorAlert.IsDisposed)
						{
							if (ucTileItemErrorAlert.ContainsKey(item.Name))
								ucTileItemErrorAlert.RemoveAlertItem(item.Name);
							
							if (ucTileItemErrorAlert.CheckButtonCount() == 0)
							{
								ucTileItemErrorAlert.Hide();
								ucTileItemErrorAlert.UEventErrorAlertClick -= new UEventHandlerAlertButtonClick(ucTileItemErrorAlert_UEventErrorAlertClick);
								ucTileControl.Dock = DockStyle.Fill;
								ucTileControl.Visible = true;
								ucTileControl.StartMoveTileView();
								ucTileControl.Show();
								Controls.Remove(ucTileItemErrorAlert);
								ucTileItemErrorAlert.Dispose();
							}

						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void ucTileControl_UEventTileItemErrorColorChanged(object Sender, DevExpress.XtraEditors.TileItem item, CMonitorEventArgs Args)
		{
			string sMessage = string.Empty;
			try
			{
				item.AppearanceItem.Normal.BackColor = ucTileControl.ItemErrorColor;

				if (ucTileItemErrorAlert == null || ucTileItemErrorAlert.IsDisposed)
					ucTileItemErrorAlert = new UCTileItemErrorAlert();

				ucTileItemErrorAlert.ItemName = item.Name;
				ucTileItemErrorAlert.GroupInfoS = ucTileControl.GroupInfoS;
				ucTileItemErrorAlert.SetAlertItem(item.Name);
				ucTileItemErrorAlert.UEventErrorAlertClick += new UEventHandlerAlertButtonClick(ucTileItemErrorAlert_UEventErrorAlertClick);
				this.ucTileControl.Hide();
				ucTileControl.StopMoveTileView();
				this.ucTileControl.Visible = false;
				ucTileItemErrorAlert.Dock = DockStyle.Fill;
				if (Controls.ContainsKey(ucTileItemErrorAlert.Name))
					ucTileItemErrorAlert.Show();
				else
					Controls.Add(ucTileItemErrorAlert);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion
		#region public Methods
		public void InitializeTileControl()
		{
			try
			{
				ucTileControl.InitializeTileControl();

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void StopItemTimer()
		{
			foreach (string key in GroupInfoS.Keys)
			{
				ucTileControl.StopItemTimer(key);
			}
		}

		public void RefreshTileInfo(CMonitorEventArgs args)
		{
			try
			{
				ucTileControl.RefreshTileInfo(args);

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void AddTileGroup()
		{
			try
			{
				ucTileControl.AddTileGroup();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void AddTileItem(string sGroupName, string sItemName, string sItemText)
		{
			try
			{
				ucTileControl.AddTileItem(sGroupName, sItemName, sItemText);

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		public CMonitorEventArgs ViewSampleErrorAlertS()
		{
			DevExpress.XtraEditors.TileGroup dev_Group = ucTileControl.GetTileGroupByName("Normal");
			if (dev_Group == null)
			{
				ucTileControl.AddTileGroup();
				ucTileControl.AddTileItem("Normal", "NProcess1", "NProcess1");
				ucTileControl.AddTileItem("Normal", "NProcess2", "NProcess2");
				ucTileControl.AddTileItem("Normal", "NProcess3", "NProcess3");
				ucTileControl.AddTileItem("Normal", "ABNProcess1", "ABNProcess1");
				ucTileControl.AddTileItem("Normal", "ABNProcess2", "ABNProcess2");
			}

			DevExpress.XtraEditors.TileItem TileItem = null;
			TileItem = ucTileControl.GetTileItemByName("ABNProcess1");

			CGroupInfoS cGroupInfoS = new CGroupInfoS();
			CGroupInfo cGroupInfo = new CGroupInfo();
			CGroupInfo cGroupInfo1 = new CGroupInfo();
			CMonitorEventArgs cMonitorEventArgs = new CMonitorEventArgs();
			CMonitorEventArgs cMonitorEventArgs1 = new CMonitorEventArgs();
			CSymbolS cSymbolS = null;
			CSymbol cSymbol = null;
			CSymbolS cSymbolS1 = null;
			CSymbol cSymbol1 = null;

			cGroupInfo.EventArgs = new CMonitorEventArgs();
			cGroupInfo.EventArgs.SourceSymbol = cSymbol;
			cGroupInfo.EventArgs.SymbolGroup = cSymbolS;

			cGroupInfo1.EventArgs = new CMonitorEventArgs();
			cGroupInfo1.EventArgs.SourceSymbol = cSymbol1;
			cGroupInfo1.EventArgs.SymbolGroup = cSymbolS1;

			cGroupInfo.EventArgs.Message = "#114 - Cycle Delay";
			cGroupInfo1.EventArgs.Message = "#115 - Cycle Delay";

			cGroupInfoS.Add("ABNProcess1", cGroupInfo);
			cGroupInfoS.Add("ABNProcess2", cGroupInfo1);
			ucTileControl.GroupInfoS = cGroupInfoS;
			ucTileControl.ChangeItemColor(TileItem, ucTileControl.ItemErrorColor, cGroupInfo.EventArgs);

			TileItem = ucTileControl.GetTileItemByName("ABNProcess2");
			ucTileControl.ChangeItemColor(TileItem, ucTileControl.ItemErrorColor, cGroupInfo1.EventArgs);

			ucTileControl.Hide();
			ucTileControl.StopMoveTileView();
			ucTileControl.Visible = false;


			return cGroupInfo.EventArgs;
		}
		public CMonitorEventArgs ViewSampleErrorAlert()
		{
			DevExpress.XtraEditors.TileGroup dev_Group = ucTileControl.GetTileGroupByName("Normal");
			if (dev_Group == null)
			{
				ucTileControl.AddTileGroup();
				ucTileControl.AddTileItem("Normal", "NProcess1", "NProcess1");
				ucTileControl.AddTileItem("Normal", "NProcess2", "NProcess2");
				ucTileControl.AddTileItem("Normal", "NProcess3", "NProcess3");
				ucTileControl.AddTileItem("Normal", "ABNProcess1", "ABNProcess1");
			}

			DevExpress.XtraEditors.TileItem TileItem = null;
			TileItem = ucTileControl.GetTileItemByName("ABNProcess1");
			CGroupInfoS cGroupInfoS = new CGroupInfoS();
			CGroupInfo cGroupInfo = new CGroupInfo();
			CMonitorEventArgs cMonitorEventArgs = new CMonitorEventArgs();
			CSymbolS cSymbolS = new CSymbolS();
			CSymbol cSymbol = new CSymbol();
			cSymbol.Address = "X0E0F";
			cSymbol.Description = "#145-1  ASSY -1 스토퍼LH후진단1";
			cGroupInfo.EventArgs = new CMonitorEventArgs();
			cGroupInfo.EventArgs.SourceSymbol = cSymbol;
			cGroupInfoS.Add("ABNProcess1", cGroupInfo);

			ucTileControl.GroupInfoS = cGroupInfoS;

			ucTileControl.Hide();
			ucTileControl.StopMoveTileView();
			ucTileControl.Visible = false;

			ucTileControl.ChangeItemColor(TileItem, ucTileControl.ItemErrorColor, cGroupInfo.EventArgs);


			return cGroupInfo.EventArgs;
		}

		public void ErrorResolution()
		{
			try
			{
				DevExpress.XtraEditors.TileItem devTileItem = ucTileControl.GetTileItemByName("ABNProcess1");

				ucTileControl.ChangeItemColor(devTileItem, ucTileControl.ItemNormalColor, ucTileControl.GroupInfoS["ABNProcess1"].EventArgs);
				ucTileItemErrorAlert.GroupInfoS.Clear();

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

		#region Private Methods
		#endregion
	}
}
