using System;
using System.Drawing;
using System.Windows.Forms;
using UDM.Common;
using UDM.Project;

namespace UDM.Tile
{
	public partial class UCTileControl : UserControl
	{
		#region Member Variables
		protected bool m_bAllowHtmlDraw = false;
		protected int m_bLargeItemWidth = 0;
		protected Color m_ErrColor = Color.OrangeRed;
		protected Color m_NormalColor = Color.Green;
		protected Timer m_tTileMoveTimer = new Timer();

		protected CGroupInfoS m_cGroupInfoS = new CGroupInfoS();

		private DevExpress.XtraEditors.TileGroup m_devGroup = null;
		private DevExpress.XtraEditors.TileItem m_devItem = null;

		public event UEventHandlerTileGroupAdded UEventTileGroupAdded;
		public event UEventHandlerTileGroupRemoved UEventTileGroupRemoved;
		public event UEventHandlerTileGroupSRemoved UEventTileGroupSRemoved;
		public event UEventHandlerTileItemAdded UEventTileItemAdded;
		public event UEventHandlerTileItemRemoved UEventTileItemRemoved;
		public event UEventHandlerTileItemSRemoved UEventTileItemSRemoved;
		public event UEventHandlerTileItemNormalColorChanged UEventTileItemNormalColorChanged;
        public event UEventHandlerTileItemErrorColorChaged UEventTileItemErrorColorChanged;
        public event UEventHandlerTileItemClick UEventTileItemClick;

		#endregion

		#region Properties
		public CGroupInfoS GroupInfoS
		{
			get { return m_cGroupInfoS; }
			set { m_cGroupInfoS = value; }
		}

		public Color ItemErrorColor
		{
			get { return m_ErrColor; }
			set { m_ErrColor = value; }
		}

		public Color ItemNormalColor
		{
			get { return m_NormalColor; }
			set { m_NormalColor = value; }
		}

		#region ITileControlProperties Members
		public bool AllowHtmlDraw
		{
			get
			{
				return m_bAllowHtmlDraw;
			}
			set
			{
				m_bAllowHtmlDraw = true;
			}
		}

		public bool AllowItemHover
		{
			get
			{
				return this.TileControl.AllowItemHover;
			}
			set
			{
				this.TileControl.AllowItemHover = value;
			}
		}

		public bool AllowSelectedItem
		{
			get
			{
				return this.TileControl.AllowSelectedItem;
			}
			set
			{
				this.TileControl.AllowSelectedItem = value;
			}
		}

		public DevExpress.XtraEditors.TileItemCheckMode ItemCheckMode
		{
			get
			{
				return this.TileControl.ItemCheckMode;
			}
			set
			{
				this.TileControl.ItemCheckMode = value;
			}
		}

		public Padding ItemPadding
		{
			get
			{
				return this.TileControl.ItemPadding;
			}
			set
			{
				this.TileControl.ItemPadding = value;
			}
		}

		public int ItemSize
		{
			get
			{
				return this.TileControl.ItemSize;
			}
			set
			{
				this.TileControl.ItemSize = value;
			}
		}

		public DevExpress.XtraEditors.TileItemContentShowMode ItemTextShowMode
		{
			get
			{
				return this.TileControl.ItemTextShowMode;
			}
			set
			{
				this.TileControl.ItemTextShowMode = value;
			}
		}

		public Orientation Orientation
		{
			get
			{
				return this.TileControl.Orientation;
			}
			set
			{
				this.TileControl.Orientation = value;
			}
		}

		public int RowCount
		{
			get
			{
				return this.TileControl.RowCount;
			}
			set
			{
				this.TileControl.RowCount = value;
			}
		}

		public bool ShowGroupText
		{
			get
			{
				return this.TileControl.ShowGroupText;
			}
			set
			{
				this.TileControl.ShowGroupText = value;
			}
		}

		public bool ShowText
		{
			get
			{
				return this.TileControl.ShowText;
			}
			set
			{
				this.TileControl.ShowText = value;
			}
		}

		#endregion

		#endregion

		#region Initialize/Dispose
		public UCTileControl()
		{
			InitializeComponent();
			this.TileControl.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(TileControl_ItemClick);

			m_tTileMoveTimer.Interval = 3000;
			m_tTileMoveTimer.Tick += new EventHandler(m_tTimer_Tick);
			m_tTileMoveTimer.Start();

			this.Disposed += new EventHandler(UCTileControl_Disposed);
		}

		void UCTileControl_Disposed(object sender, EventArgs e)
		{
			if (m_tTileMoveTimer.Enabled)
				m_tTileMoveTimer.Stop();

			m_tTileMoveTimer.Dispose();
		}
		#endregion


		#region Form Event

		public void AddTileGroup()
		{
			try
			{
				TileControl.IndentBetweenItems = 1;
				TileControl.IndentBetweenGroups = 1;

				DevExpress.XtraEditors.TileGroup xtraNormalGroup = new DevExpress.XtraEditors.TileGroup();
				xtraNormalGroup.Name = "Normal";
				xtraNormalGroup.Visible = true;
				TileControl.Groups.Add(xtraNormalGroup);

				DevExpress.XtraEditors.TileGroup xtraAbnormalGroup = new DevExpress.XtraEditors.TileGroup();
				xtraAbnormalGroup.Name = "Abnormal";
				xtraAbnormalGroup.Visible = false;
				TileControl.Groups.Add(xtraAbnormalGroup);

				if (UEventTileGroupAdded != null)
					UEventTileGroupAdded(TileControl, xtraNormalGroup);

				if (UEventTileGroupAdded != null)
					UEventTileGroupAdded(TileControl, xtraAbnormalGroup);
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
                DevExpress.XtraEditors.TileItem item = new DevExpress.XtraEditors.TileItem();

                item.Name = sItemName;
                item.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
                item.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopLeft;
                item.Text = MessageFontSize(sItemName, 45);

                item.IsLarge = true;

				m_devGroup = TileControl.GetTileGroupByName(sGroupName);
                m_devGroup.Items.Add(item);


				if (UEventTileItemAdded != null)
					UEventTileItemAdded(TileControl, m_devItem);

                CGroupInfo srcGroup;

                if (!m_cGroupInfoS.TryGetValue(sItemName, out srcGroup))
                {
                    srcGroup = new CGroupInfo();

                    srcGroup.Name = sItemName;
                    m_cGroupInfoS.Add(sItemName, srcGroup);
                }
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public int GetAbnormalGroupCount()
		{
			int iCnt = 0;
			try
			{
				iCnt = TileControl.Groups["Abnormal"].Items.Count;

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return iCnt;
		}


		public DevExpress.XtraEditors.TileItem GetTileItemByName(string sName)
		{
			DevExpress.XtraEditors.TileItem devTileItem = null;
			try
			{
				for (int i = 0; i < TileControl.Groups.Count; i++)
				{
					devTileItem = TileControl.Groups[i].GetTileItemByName(sName);
					if (devTileItem != null)
						return devTileItem;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return devTileItem;
		}

        public string MessageFontSize(string msg, int size)
        {
            return string.Format("<size={0}><color=White>{1}</color></size>",size, msg);
        }

        public void RefreshTileInfo(CMonitorEventArgs args)
        {
            CGroupInfo srcGroup = null;
			string sStatus = string.Empty;
            try
            {
                if (m_cGroupInfoS.TryGetValue(args.Group.Name, out srcGroup))
                {
					GroupInfoS[args.Group.Name].EventArgs = args;
					m_devItem = GetTileItemByName(args.Group.Name);

                    if (m_devItem != null)
					{
                        //double dbCurrCycleTime = args.Group.CurrCycleTime.TotalMilliseconds;
                        //double dbPrevCycleTime = args.Group.PrevCycleTime.TotalMilliseconds;

						switch (args.Group.StateType)
						{
							case EMStateType.Start: // Prev : 이전 사이클 시간 OR 0 , Curr :  0
								StartItemTimer(args.Group.Name);
								//dbCurrCycleTime = 0;
								GroupInfoS[args.Group.Name].ItemStartDate = DateTime.Now;
								sStatus = "작업 중 ";
								//SetCurrentCycleTime(m_devItem, 0);
								break;
                            case EMStateType.End: // 현재 사이클을 이전 사이클시간으로 복사, 현재는 0로 수정.
								StopItemTimer(args.Group.Name);
								//dbCurrCycleTime = 0;
								//dbPrevCycleTime = args.Group.CurrCycleTime.TotalMilliseconds;
								//SetCurrentCycleTime(m_devItem, 0);
								//SetPrevCycleTime(m_devItem, args.Group.CurrCycleTime.TotalMilliseconds);
								sStatus = "대기 중 ";
								break;
							case EMStateType.Error: // 현재 시간의 갱신을 중지.
								PauseItemTimer(args.Group.Name);
								sStatus = "지연 중 ";
								CGroupInfo targetGroup;
								if (GroupInfoS.TryGetValue(args.Group.Name, out targetGroup))
								{
									TimeSpan tsTime = DateTime.Now.Subtract(targetGroup.ItemStartDate);
									//dbCurrCycleTime = (double)tsTime.TotalMilliseconds;
								}
								break;
						}
                        // Display Middle Range
						//SetCurrentCycleTime(m_devItem, sStatus, dbCurrCycleTime);

                        // Display Bottom Range
						//SetPrevCycleTime(m_devItem, dbPrevCycleTime);

                        if (args.Group.StateType == EMStateType.Error)
                        {
							ChangeItemColor(m_devItem, ItemErrorColor, args);
                        }
                        else if(args.Group.StateType == EMStateType.Start)
                        {
							ChangeItemColor(m_devItem, ItemNormalColor, args);
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

		public DevExpress.XtraEditors.TileGroup GetTileGroupByName(string sName)
		{
			DevExpress.XtraEditors.TileGroup devGroup = null;
			try
			{
				devGroup = TileControl.GetTileGroupByName(sName);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return devGroup;
		}

		public void ChangeItemColor(DevExpress.XtraEditors.TileItem devTileItem, Color color, CMonitorEventArgs args)
		{
			try
			{
				if (color.Equals(ItemErrorColor))
				{
					if (UEventTileItemErrorColorChanged != null)
						UEventTileItemErrorColorChanged(TileControl, devTileItem, args);
				}
				else
				{
					if (UEventTileItemNormalColorChanged != null)
						UEventTileItemNormalColorChanged(TileControl, devTileItem, args);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void ChangeSizeGroupItemS(string sGroupName, bool bIsLarge)
		{
			try
			{
				m_devGroup = TileControl.GetTileGroupByName(sGroupName);
				int itemCount = m_devGroup.Items.Count;

				for (int i = 0; i < itemCount; i++)
				{
					m_devGroup.Items[i].IsLarge = bIsLarge;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void InitializeTileControl()
        {
			try
			{
				RemovedTileGroupS();
				// this.ItemSize =  ClientRectangle.Width/3 ;
                this.ItemSize = 250;
				this.RowCount = 5;
				Padding padding = new Padding(12, 10, 12, 10);
				this.ItemPadding = padding;
			}

			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
        }

		#endregion

		#region Public Methods

		public void RemoveTileItem(DevExpress.XtraEditors.TileGroup group, DevExpress.XtraEditors.TileItem item)
		{
			try
			{
				if(group.Items.Contains(item))
					group.Items.Remove(item);
				//GroupInfoS.Remove(item.Name);
				if (UEventTileItemRemoved != null)
					UEventTileItemRemoved(TileControl, group);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void RemovedTileGroupS()
		{
			try
			{
				for (int i = 0; i < TileControl.Groups.Count; i++)
				{
					RemovedTileItemS(TileControl.Groups[i]);
				}

				TileControl.Groups.Clear();

				if (UEventTileGroupSRemoved != null)
					UEventTileGroupSRemoved(this, TileControl);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void RemovedTileGroup(DevExpress.XtraEditors.TileGroup group)
		{
			try
			{
				TileControl.Groups.Remove(group);

				if (UEventTileGroupRemoved != null)
					UEventTileGroupRemoved(this, TileControl);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void RemovedTileItemS(DevExpress.XtraEditors.TileGroup group)
		{
			try
			{
				group.Items.Clear();

				if (UEventTileItemSRemoved != null)
					UEventTileItemSRemoved(TileControl, group);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void StartMoveTileView()
		{
			try
			{
				if (!m_tTileMoveTimer.Enabled)
					m_tTileMoveTimer.Start();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void StopMoveTileView()
		{
			try
			{
			if (m_tTileMoveTimer.Enabled)
				m_tTileMoveTimer.Stop();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

		#region Private Methods
		private void SetCurrentCycleTime(DevExpress.XtraEditors.TileItem item, string sStatus, double TotalMilliseconds)
		{
			try
			{
				double dbCurrMilliseconds = 0;
				string strMiddle = string.Empty;
				if (TotalMilliseconds == 0)
				{
					strMiddle = string.Format("{0} 0.0", sStatus);
				}
				else
				{
					dbCurrMilliseconds = TotalMilliseconds / 1000;
					strMiddle = string.Format("{0} {1:F1}",sStatus, dbCurrMilliseconds);
				}
				item.Text2 = MessageFontSize(strMiddle, 40);
				item.Text2Alignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void SetPrevCycleTime(DevExpress.XtraEditors.TileItem item, double TotalMilliseconds)
		{
			try
			{
				double dbPrevMilliseconds = (TotalMilliseconds > 0 ? TotalMilliseconds : 0)/ 1000;
				string strBottom = string.Format("이전 {0:F1}", dbPrevMilliseconds);
				item.Text4 = MessageFontSize(strBottom, 25);
				item.Text4Alignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomCenter;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void StartItemTimer(string sName)
		{
			try
			{
				if (GroupInfoS[sName].IsTimerOn)
				{
					StopItemTimer(sName);
				}

				GroupInfoS[sName].Interval = 100;
				GroupInfoS[sName].IsTimerOn = true;
				GroupInfoS[sName].StartTimer();
				GroupInfoS[sName].UEventGroupInfoTimerTick += new UEventHandlerGroupInfoTimerTick(UCTileControl_UEventGroupInfoTimerTick);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		public void StopItemTimer(string sName)
		{
			try
			{
				GroupInfoS[sName].IsTimerOn = false;
				GroupInfoS[sName].StopTimer();
				GroupInfoS[sName].UEventGroupInfoTimerTick -= new UEventHandlerGroupInfoTimerTick(UCTileControl_UEventGroupInfoTimerTick);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void PauseItemTimer(string sName)
		{
			try
			{
				GroupInfoS[sName].StopTimer();
				GroupInfoS[sName].UEventGroupInfoTimerTick -= new UEventHandlerGroupInfoTimerTick(UCTileControl_UEventGroupInfoTimerTick);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

		#region Event Methods


		private void UCTileControl_UEventGroupInfoTimerTick(object sender, string sItemName)
		{
            CGroupInfo targetGroup;
			try
			{
                if (GroupInfoS.TryGetValue(sItemName, out targetGroup))
                {
                    targetGroup.StopTimer();
                }
                else
                {
                    return;
                }

				DevExpress.XtraEditors.TileItem dev_Item = GetTileItemByName(sItemName);
                if (targetGroup.EventArgs != null && dev_Item != null)
				{
                    TimeSpan tsTime = DateTime.Now.Subtract(targetGroup.ItemStartDate);
					SetCurrentCycleTime(dev_Item, "작업 중 ", (double)tsTime.TotalMilliseconds);
				}
                targetGroup.StartTimer();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

		}

		private void TileControl_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
		{
			if (UEventTileItemClick != null)
				UEventTileItemClick(sender, e.Item);
		}


		private void m_tTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				int iItemWidth = 0;
				if (TileControl.Groups.Count != 0)
				{
					if (TileControl.Groups[0].Items.Count > 0)
						iItemWidth = this.TileControl.ItemSize;
				}

				int iNextPostion = this.TileControl.Position + iItemWidth;
				int iPrevPostion = this.TileControl.Position;

				this.TileControl.Position = iNextPostion;

				if (iPrevPostion == this.TileControl.Position && iPrevPostion != 0)
				{
					iPrevPostion = 0;
					this.TileControl.Position = 0;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

	}
}
