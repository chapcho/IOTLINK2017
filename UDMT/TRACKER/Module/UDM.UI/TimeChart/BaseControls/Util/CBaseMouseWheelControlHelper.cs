using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	internal static class CBaseMouseWheelControlHelper
	{
		private class CBaseMouseWheelMessageFilter : IMessageFilter
		{
			[DllImport("user32.dll")]
			private static extern IntPtr WindowFromPoint(Point pt);

			private readonly Control mCtrl;
			private readonly Action<MouseEventArgs> mOnMouseWheel;

			public CBaseMouseWheelMessageFilter(Control ctrl, Action<MouseEventArgs> onMouseWheel)
			{
				mCtrl = ctrl;
				mOnMouseWheel = onMouseWheel;
			}

			public bool PreFilterMessage(ref Message m)
			{
				// handle only mouse wheel messages
				if (m.Msg != 0x20a)
					return false;

				Point mouseAbsolutePosition = new Point(m.LParam.ToInt32());
				Point mouseRelativePosition = mCtrl.PointToClient(mouseAbsolutePosition);

				IntPtr hControlUnderMouse = WindowFromPoint(mouseAbsolutePosition);
				Control controlUnderMouse = Control.FromHandle(hControlUnderMouse);

				if (controlUnderMouse != mCtrl)
					return false;

				long nParam = m.WParam.ToInt64();
				int iParam = (int)nParam;
				MouseButtons buttons = GetMouseButtons(iParam);
				int delta = (int)(iParam >> 16);

				var e = new MouseEventArgs(buttons, 0, mouseRelativePosition.X, mouseRelativePosition.Y, delta);

				mOnMouseWheel(e);

				return true;
			}

			private static MouseButtons GetMouseButtons(int iParam)
			{
				MouseButtons buttons = MouseButtons.None;

				if (HasFlag(iParam, 0x0001)) buttons |= MouseButtons.Left;
				if (HasFlag(iParam, 0x0010)) buttons |= MouseButtons.Middle;
				if (HasFlag(iParam, 0x0002)) buttons |= MouseButtons.Right;
				if (HasFlag(iParam, 0x0020)) buttons |= MouseButtons.XButton1;
				if (HasFlag(iParam, 0x0040)) buttons |= MouseButtons.XButton2;

				return buttons;
			}

			private static bool HasFlag(int iInput, int flag)
			{
				return (iInput & flag) == flag;
			}
		}

		public static void Add(Control ctrl, Action<MouseEventArgs> onMouseWheel)
		{
			if (ctrl == null || onMouseWheel == null)
				throw new ArgumentNullException();

			var filter = new CBaseMouseWheelMessageFilter(ctrl, onMouseWheel);
			Application.AddMessageFilter(filter);
			ctrl.Disposed += (s, e) => Application.RemoveMessageFilter(filter);
		}
	}
}
