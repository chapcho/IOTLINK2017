using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace IOTL.Common.MessageFilter
{
    public class MessageFilter : IMessageFilter
    {
        #region Member Variables

        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;
        private const int WM_MOUSEWHEEL = 0x20A;

        public const int MK_CONTROL = 0x8;
        public const int MK_LBUTTON = 0x1;
        public const int MK_RBUTTON = 0x2;
        public const int MK_MBUTTON = 0x10;
        public const int MK_SHIFT = 0x4;

        public event MouseEventHandler UEventMouseDown;
        public event MouseEventHandler UEventMouseUp;
        public event MouseEventHandler UEventMouseMove;
        public event MouseEventHandler UEventMouseWheel;

        #endregion


        #region Initialize/Dispose

        public MessageFilter()
        {

        }

        public void Dispose()
        {

        }

        #endregion


        #region Public Methods

        public bool PreFilterMessage(ref Message m)
        {
            if (m.LParam.ToInt64() < 0)
                return false;

            try
            {
                int iPosX = m.LParam.ToInt32() & 65535;
                int iPosY = m.LParam.ToInt32() / 65536;
                int iMouseKey = m.WParam.ToInt32() & 65535;
                int iRotation = m.WParam.ToInt32() / 65536;
                int iDelta = iRotation / 120;

                MouseButtons emButton = MouseButtons.None;
                if (iMouseKey == MK_LBUTTON)
                    emButton = MouseButtons.Left;
                else if (iMouseKey == MK_RBUTTON)
                    emButton = MouseButtons.Right;
                else if (iMouseKey == MK_MBUTTON)
                    emButton = MouseButtons.Middle;

                MouseEventArgs e = new MouseEventArgs(emButton, 0, iPosX, iPosY, iDelta);

                if (m.Msg == WM_MOUSEMOVE)
                {
                    if (UEventMouseMove != null)
                        UEventMouseMove(this, e);
                }
                else if (m.Msg == WM_LBUTTONDOWN || m.Msg == WM_RBUTTONDOWN)
                {
                    if (UEventMouseDown != null)
                        UEventMouseMove(this, e);
                }
                else if (m.Msg == WM_LBUTTONUP || m.Msg == WM_RBUTTONUP)
                {
                    if (UEventMouseUp != null)
                        UEventMouseUp(this, e);
                }
                else if (m.Msg == WM_MOUSEWHEEL)
                {
                    if (UEventMouseWheel != null)
                        UEventMouseWheel(this, e);
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return false;
        }

        #endregion
    }
}
