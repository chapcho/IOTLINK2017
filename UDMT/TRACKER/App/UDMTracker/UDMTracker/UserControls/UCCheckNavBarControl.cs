using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraNavBar;
using DevExpress.XtraNavBar.ViewInfo;

namespace UDMTracker
{
	public partial class UCCheckNavBarControl : DevExpress.XtraNavBar.NavBarControl
	{
		#region Member Variables
		private bool m_bLocked;
		private int m_iCheckIndent = 5;
		private Rectangle m_nhotRectangle;
		private NavBarGroup m_hotNavGroup;
		private NavBarItemLink m_hotNavItemLink;

		public delegate void NavBarStateEventHandler(object sender, NavBarStateEventsArgs stateArgS);
		public event NavBarStateEventHandler CheckedChaged;

		private RepositoryItemCheckEdit m_repCheckEdit = new RepositoryItemCheckEdit();
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

		#endregion

		#region Properties
		public int CheckIndent
		{
			get { return m_iCheckIndent; }
			set { m_iCheckIndent = value; }
		}

		public RepositoryItemCheckEdit CheckEdit
		{
			get { return m_repCheckEdit; }
			set { m_repCheckEdit = value; }
		}
		#endregion

		#region Initialize/Dispose
		public UCCheckNavBarControl()
		{
			InitializeComponent();
		}

		public UCCheckNavBarControl(IContainer container)
		{
			container.Add(this);
			
			InitializeComponent();
			m_repCheckEdit = new RepositoryItemCheckEdit();
		}
		#endregion

		#region Public Methods
		public void GroupChecekdChange(NavLinkCollection ItemLinkS)
		{
			foreach (NavBarItemLink hotLink in ItemLinkS)
			{
				ToggleLinkState(hotLink);
			}
		}
		public void ItemChecekdChange(NavBarGroup hotGroup)
		{
			ToggleGroupState(hotGroup);
		}
		#endregion

		#region Private Methods
		private bool IsCustomDrawNeeded()
		{
			return m_repCheckEdit != null && !m_bLocked;
		}

		private int GetCheckBoxWidth()
		{
			return CheckIndent * 2 + 10;
		}

		private Rectangle GetCaptionBounds(Rectangle originalCaptionBounds)
		{
			Point loc = originalCaptionBounds.Location;
			loc.X += GetCheckBoxWidth();
			return new Rectangle(loc, new Size(originalCaptionBounds.Width - GetCheckBoxWidth(), originalCaptionBounds.Height));
		}
		
		private Rectangle GetCheckBoxBounds(Rectangle fixedCaptionBounds)
		{
			return new Rectangle(fixedCaptionBounds.Left - GetCheckBoxWidth(), fixedCaptionBounds.Top, GetCheckBoxWidth(), fixedCaptionBounds.Height);
		}

		private bool IsGroupEnabled(NavBarGroup navBarGroup)
		{
			return navBarGroup.Tag != null;
		}

		private bool IsLinkEnabled(NavBarItemLink navBarLink)
		{
			return !navBarLink.Item.Hint.Equals("");
		}
		private void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
		{
			BaseEditPainter painter = m_repCheckEdit.CreatePainter();
			BaseEditViewInfo info = m_repCheckEdit.CreateViewInfo();
			info.EditValue = Checked;
			info.Bounds = r;
			info.CalcViewInfo(g);
			ControlGraphicsInfoArgs args = new ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
			painter.Draw(args);
			args.Cache.Dispose();
		}
		private bool IsCheckBox(Point p)
		{
			bool bOK = false;
			NavBarHitInfo hi = CalcHitInfo(p);
			if(hi.Group != null && hi.Link == null)
			{
				ViewInfo.Calc(ClientRectangle);
				NavGroupInfoArgs GroupInfo = ViewInfo.GetGroupInfo(hi.Group);
				Rectangle checkBounds = GetCheckBoxBounds(GetCaptionBounds(GroupInfo.CaptionBounds));
				m_hotNavGroup = hi.Group;
				m_nhotRectangle = checkBounds;
				bOK = checkBounds.Contains(p);
			}
			else if (hi.Group != null && hi.Link != null)
			{
				ViewInfo.Calc(ClientRectangle);
				NavLinkInfoArgs LinkInfo = ViewInfo.GetLinkInfo(hi.Link);
				Rectangle checkBounds = GetCheckBoxBounds(GetCaptionBounds(LinkInfo.Bounds));
				m_hotNavItemLink = hi.Link;
				m_nhotRectangle = checkBounds;
				bOK = checkBounds.Contains(p);
			}
			else
			{
				return false;
			}

			return bOK;
		}

		private void ToggleGroupState(NavBarGroup hotGroup)
		{
			SetGroupState(hotGroup, !IsGroupEnabled(hotGroup));
		}

		private void ToggleLinkState(NavBarItemLink hotLink)
		{
			SetLinkState(hotLink, !IsLinkEnabled(hotLink));
		}

		private void SetGroupState(NavBarGroup hotGroup, bool enabled)
		{
			if (enabled) hotGroup.Tag = hotGroup.ItemLinks.Count;
			else hotGroup.Tag = null;

			Invalidate(m_nhotRectangle);
		}

		private void SetLinkState(NavBarItemLink hotLink, bool enabled)
		{
			if (enabled) hotLink.Item.Hint = "0";
			else hotLink.Item.Hint = "";

			Invalidate(m_nhotRectangle);
		}
		#endregion

		#region Event Methods

		private void UCCheckNavBarControl_CustomDrawGroupCaption(object sender, CustomDrawNavBarElementEventArgs e)
		{
			if (!IsCustomDrawNeeded())
				return;
			if (Groups.Count == 0)
				return;
			try
			{
				m_bLocked = true;
				BaseNavGroupPainter GroupPainter = View.CreateGroupPainter(this);
				NavGroupInfoArgs Groupinfo = e.ObjectInfo as NavGroupInfoArgs;
				Rectangle originalCaptionBounds = Groupinfo.CaptionBounds;
				Rectangle fixedCaptionBounds = GetCaptionBounds(originalCaptionBounds);
				Rectangle checkBoxBounds = GetCheckBoxBounds(fixedCaptionBounds);
				Groupinfo.CaptionBounds = fixedCaptionBounds;
				GroupPainter.UpDownButtonPainter.DrawObject(Groupinfo);
				//GroupPainter.DrawObject(Groupinfo);
				GroupPainter.DrawCaption(Groupinfo, e.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), Groupinfo.CaptionBounds, StringFormat.GenericDefault);
				Groupinfo.CaptionBounds = originalCaptionBounds;
				DrawCheckBox(e.Graphics, checkBoxBounds, IsGroupEnabled(Groupinfo.Group));
				e.Handled = true;
			}
			finally
			{
				m_bLocked = false;
			}
		}

		private void UCCheckNavBarControl_CustomDrawLink(object sender, DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs e)
		{
			if (!IsCustomDrawNeeded())
				return;
			try
			{
				m_bLocked = true;
				BaseNavLinkPainter LinkPainter = View.CreateLinkPainter(this);
				NavLinkInfoArgs Linkinfo = e.ObjectInfo as NavLinkInfoArgs;
				Rectangle originalCaptionBounds = Linkinfo.Bounds;
				Rectangle fixedCaptionBounds = GetCaptionBounds(originalCaptionBounds);
				Rectangle checkBoxBounds = GetCheckBoxBounds(fixedCaptionBounds);
				Linkinfo.Bounds = fixedCaptionBounds;
				LinkPainter.DrawObject(Linkinfo);
				Linkinfo.Bounds = originalCaptionBounds;
				DrawCheckBox(e.Graphics, checkBoxBounds, IsLinkEnabled(Linkinfo.Link));
				e.Handled = true;
			}
			finally
			{
				m_bLocked = false;
			}
		}

		private void UCCheckNavBarControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(IsCheckBox(e.Location))
			{
				NavBarHitInfo info = CalcHitInfo(e.Location);
				if (info.Group != null && info.Link == null)
				{
					ToggleGroupState(m_hotNavGroup);
					if (CheckedChaged != null)
						CheckedChaged(this, new NavBarStateEventsArgs(m_hotNavGroup, null, IsGroupEnabled(m_hotNavGroup)));
				}
				else if (info.Group != null && info.Link != null)
				{
					ToggleLinkState(m_hotNavItemLink);
					if (CheckedChaged != null)
						CheckedChaged(this, new NavBarStateEventsArgs(null, m_hotNavItemLink, IsLinkEnabled(m_hotNavItemLink)));
				}
			}
		}
		#endregion
	}

	public class NavBarStateEventsArgs : EventArgs
	{
		public readonly NavBarGroup Group;
		public readonly NavBarItemLink Link;
		public readonly bool State;

		public NavBarStateEventsArgs(NavBarGroup someGroup, NavBarItemLink someLink, bool someState)
		{
			Group = someGroup;
			Link = someLink;
			State = someState;
		}
	}
}
