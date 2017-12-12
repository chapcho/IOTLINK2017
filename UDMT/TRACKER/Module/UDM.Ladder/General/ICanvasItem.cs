using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.Ladder
{
    public interface ICanvasItem
    {
        Point OriginPoint { get; set; }
        List<CVertex> BoundingBoxes { get; }
        void Draw(Graphics graphics);
        void OnClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k); // WCS
        void OnRClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k); // WCS
        void OnDClick(int x, int y, System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Keys k); // WCS
    }
}
