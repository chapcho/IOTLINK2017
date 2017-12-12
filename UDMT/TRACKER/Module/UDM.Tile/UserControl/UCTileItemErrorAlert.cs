using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.Tile
{
	public partial class UCTileItemErrorAlert : UserControl
	{
		#region Member Variables
		protected bool m_bSingleButton = false;
		protected int m_iIndexNameS = -1;
		protected string m_sItemName = string.Empty;
		protected List<string> m_sItemNameS = new List<string>();
		protected Dictionary<string, DevExpress.XtraEditors.SimpleButton> m_btnAlertS = null;

		protected CGroupInfoS m_cGroupInfoS = null;
		private UCTileItemDetailView m_ucDetailView = new UCTileItemDetailView();

		protected Timer m_tTimer = new Timer();
		protected Timer m_tButtonChangeTimer = new Timer();

		public event UEventHandlerAlertButtonClick UEventErrorAlertClick;

		#endregion

		#region Properties
		public CGroupInfoS GroupInfoS
		{
			get { return m_cGroupInfoS; }
			set { m_cGroupInfoS = value; }
		}

		public bool IsSingleButton
		{
			get { return m_bSingleButton; }
			set { m_bSingleButton = value; }
		}

		public string ItemName
		{
			get { return m_sItemName; }
			set { m_sItemName = value; }
		}
		#endregion

		#region Events
		public UCTileItemErrorAlert()
		{
			InitializeComponent();
			/*
			 * Alert 창 Backgroud 변경
			 * Alert 창을 볼 수 있도록 설정하기 위해 2초마다 색 변화를 줌
			*/
			m_tTimer.Interval = 500;
			m_tTimer.Tick += new EventHandler(m_tTimer_Tick);
			m_tTimer.Start();
			this.Load += new EventHandler(UCTileItemErrorAlert_Load);
			//this.btnErr1.SizeChanged += new EventHandler(btnErr1_SizeChanged);
			this.Disposed += new EventHandler(UCTileItemErrorAlert_Disposed);
			btnErr1.Hide();
		}


		private void UCTileItemErrorAlert_Disposed(object sender, EventArgs e)
		{
			try
			{
				m_tTimer.Stop();
				m_tTimer.Dispose();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void btnErr1_SizeChanged(object sender, EventArgs e)
		{
			try
			{
				if(m_btnAlertS.ContainsKey(btnErr1.Name))
					FontResizing(m_btnAlertS[btnErr1.Name]);
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
				btn.Font = AppropriateFont(gBtnGraphics, 5, 100,
						  btn.Size, btn.Text, btn.Font, out size);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void UCTileItemErrorAlert_Load(object sender, EventArgs e)
		{
			/*
			 * Alert 창 Backgroud 변경
			 * Alert 창을 볼 수 있도록 설정하기 위해 2초마다 색 변화를 줌
			*/
			m_tTimer.Start();

			m_ucDetailView.Hide();
		}

		private void m_tTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				FlickerButtonColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void FlickerButtonColor()
		{
			try
			{
				Color colorTop = btnErr1.Appearance.BackColor;
				Color colorMidle = btnErr1.Appearance.BackColor2;

				btnErr1.Appearance.BackColor = colorMidle;
				btnErr1.Appearance.BackColor2 = colorTop;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void AlertButton_Click(object sender, EventArgs e)
		{
			try
			{
				Control ctl = sender as Control;
				//MessageBox.Show(ctl.Name);
				if (UEventErrorAlertClick != null)
					UEventErrorAlertClick(this, GroupInfoS[ctl.Name]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}
		#endregion

		#region Public Methods
		public void SetAlertItem(string sItemName)
		{
			try
			{
				m_sItemNameS.Add(sItemName);
				AddButton(sItemName);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}


		public int CheckButtonCount()
		{
			int ibtnCount = -1;
			try
			{
				ibtnCount = m_btnAlertS.Count;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return ibtnCount;
		}

		public bool ContainsKey(string sItemName)
		{
			return m_btnAlertS.ContainsKey(sItemName);
		}

		public void RemoveAlertItem(string sItemName)
		{
			RemoveButton(sItemName);
		}
		#endregion

		#region Private Methods
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

		private void AddButton(string sItemName)
		{
			try
			{
				if (m_btnAlertS == null)
					m_btnAlertS = new Dictionary<string, DevExpress.XtraEditors.SimpleButton>();

				DevExpress.XtraEditors.SimpleButton AlertButton = new DevExpress.XtraEditors.SimpleButton();
				AlertButton.Name = sItemName;
				AlertButton.Appearance.BackColor = Color.FromArgb(255, 128, 0);
				AlertButton.Appearance.BackColor2 = Color.Red;
				AlertButton.Appearance.BorderColor = Color.FromArgb(255, 128, 128);
				AlertButton.ForeColor = Color.White;
				AlertButton.Text = SetTextToButton(sItemName);
				AlertButton.Dock = DockStyle.Fill;
				AlertButton.BringToFront();
				AlertButton.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
				AlertButton.Click += new EventHandler(AlertButton_Click);
				AlertButton.SizeChanged += new EventHandler(AlertButton_SizeChanged);

				btnErr1 = AlertButton;
				if (!m_btnAlertS.ContainsKey(sItemName))
					m_btnAlertS.Add(sItemName, AlertButton);

				Controls.Add(AlertButton);

				if (m_tButtonChangeTimer.Enabled)
					m_tButtonChangeTimer.Stop();

				ChangeMoveButtonS();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void AlertButton_SizeChanged(object sender, EventArgs e)
		{
			try
			{
				if(m_btnAlertS.ContainsKey(btnErr1.Name))
					FontResizing(m_btnAlertS[btnErr1.Name]);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void RemoveButton(string sItemName)
		{
			try
			{
				if (m_tButtonChangeTimer.Enabled)
					m_tButtonChangeTimer.Stop();

				Controls.Remove(m_btnAlertS[sItemName]);
				m_btnAlertS.Remove(sItemName);
				m_sItemNameS.Remove(sItemName);

				ChangeMoveButtonS();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}


		private void ChangeMoveButtonS()
		{
			try
			{
				m_tButtonChangeTimer.Interval = 2000;
				if (CheckButtonCount() > 1)
				{
					m_tButtonChangeTimer.Start();
					m_tButtonChangeTimer.Tick += new EventHandler(m_tButtonChangeTimer_Tick);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
		}

		private void m_tButtonChangeTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (m_iIndexNameS == m_sItemNameS.Count - 1)
					m_iIndexNameS = 0;
				else
					m_iIndexNameS++;
				m_btnAlertS[m_sItemNameS[m_iIndexNameS]].BringToFront();
				btnErr1 = m_btnAlertS[m_sItemNameS[m_iIndexNameS]];
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}

		}

		
		private string SetTextToButton(string ItemName)
		{
			string sMessage;
			sMessage = string.Format("{0} \n", ItemName);
			try
			{
				if (GroupInfoS[ItemName].EventArgs.SourceSymbol == null
					&& GroupInfoS[ItemName].EventArgs.SymbolGroup == null)
				{
					sMessage += string.Format(GroupInfoS[ItemName].EventArgs.Message);
				}
				else
				{
					if (GroupInfoS[ItemName].EventArgs.SourceSymbol != null
						&& GroupInfoS[ItemName].EventArgs.SymbolGroup == null)
					{
						//sMessage += string.Format(GroupInfoS[ItemName].EventArgs.SourceSymbol.Description);// + "\n"
						sMessage += string.Format("[{0}] {1} 지연", GroupInfoS[ItemName].EventArgs.SourceSymbol.Address, GroupInfoS[ItemName].EventArgs.SourceSymbol.Description);// + "\n"
					}
					else if (GroupInfoS[ItemName].EventArgs.SourceSymbol != null
						&& GroupInfoS[ItemName].EventArgs.SymbolGroup != null)
					{
						if (GroupInfoS[ItemName].EventArgs.SymbolGroup.Count > 1)
						{
							//sMessage += string.Format(GroupInfoS[ItemName].EventArgs.SourceSymbol.Name + "그룹 에서 Error 발생\n");
							sMessage += string.Format("[{0}] ", GroupInfoS[ItemName].EventArgs.SourceSymbol.Address);// + "\n"

							if (GroupInfoS[ItemName].EventArgs.SourceSymbol.Description.Equals(""))
							{
								sMessage += string.Format("{0} 지연", GroupInfoS[ItemName].EventArgs.Message);
							}
							else
							{
								sMessage += string.Format("{0} 지연", GroupInfoS[ItemName].EventArgs.SourceSymbol.Description);
							}
						}
						else
						{
                            if (GroupInfoS[ItemName].EventArgs.Message != "")
						    {
						        // sMessage += string.Format(GroupInfoS[ItemName].EventArgs.Message);
                                sMessage += string.Format("[{0}] {1}", GroupInfoS[ItemName].EventArgs.SourceSymbol.Address, GroupInfoS[ItemName].EventArgs.SourceSymbol.Description);
						    }
						//    else
						//    {
						//        sMessage += string.Format(GroupInfoS[ItemName].EventArgs.SourceSymbol.Description);
						//    }

						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
			}
			return sMessage;
		}
		#endregion

	}
}
