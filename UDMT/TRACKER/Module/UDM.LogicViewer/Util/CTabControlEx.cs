using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.LogicViewer.Util
{
    public delegate bool PreRemoveTab(int indx);
    public class CTabControlEx : TabControl
    {
        public CTabControlEx()
            : base()
        {
            PreRemoveTabPage = null;

            this.DrawMode = TabDrawMode.Normal;
            //this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        public PreRemoveTab PreRemoveTabPage;

        //protected override void OnDrawItem(DrawItemEventArgs e)
        //{
        //    Rectangle r = e.Bounds;
        //    r = GetTabRect(e.Index);
        //    r.Offset(2, 2);
        //    r.Width  = 8;
        //    r.Height = 10;
        //    Brush b = new SolidBrush(Color.Black);
        //    Pen p = new Pen(b);
        //    // X
        //    e.Graphics.DrawLine(p, r.X, r.Y, r.X + r.Width, r.Y + r.Height);
        //    e.Graphics.DrawLine(p, r.X + r.Width, r.Y, r.X, r.Y + r.Height);

        //    e.Graphics.DrawLine(p, r.X, r.Y, r.X + r.Width, r.Y);
        //    e.Graphics.DrawLine(p, r.X, r.Y + r.Height, r.X + r.Width, r.Y + r.Height);

        //    e.Graphics.DrawLine(p, r.X, r.Y, r.X, r.Y + r.Height);
        //    e.Graphics.DrawLine(p, r.X + r.Width, r.Y, r.X + r.Width, r.Y + r.Height);

        //    string title = this.TabPages[e.Index].Text;
        //    Font f = this.Font;
        //    e.Graphics.DrawString(title, f, b, new PointF(r.X + 10, r.Y));
        //}

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                r.Offset(2, 2);
                r.Width = 8;
                r.Height = 10;
                if (r.Contains(p))
                {
                    CloseTab(i);
                }
            }
        }

        private void CloseTab(int i)
        {
            if (PreRemoveTabPage != null)
            {
                bool closeIt = PreRemoveTabPage(i);
                if (!closeIt)
                    return;
            }
            TabPages.Remove(TabPages[i]);
        }
    }
}
