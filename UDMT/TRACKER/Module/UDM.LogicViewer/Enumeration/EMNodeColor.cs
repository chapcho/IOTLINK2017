using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.LogicViewer
{
    public class EColorBlock
    {
        public static Color ON = SystemColors.Highlight;
        public static Color Off = Color.Gray;
        public static Color MonitorNone = Color.DarkOrange;

        public static Color And = Color.Snow;
        public static Color OR = Color.PaleGreen;
        public static Color TAG = Color.DarkGray;
        public static Color None = Color.SlateGray;

        public static Color RowON = Color.Transparent;
        public static Color RowOff = Color.Transparent;
        public static Color RowNone = Color.Transparent;
        public static Color RowCompare = Color.LightGoldenrodYellow;
        public static Color RowCompareText = Color.BlueViolet;
        public static Color RowDelay = Color.OrangeRed;
        public static Color RowSelected = Color.YellowGreen;

        public static Color BackColor = Color.Snow;
        public static Color TextColor = Color.Black;

        public static Color CoilNormal = Color.LightBlue;
        public static Color CoilShift = Color.LightPink;
    }

}
