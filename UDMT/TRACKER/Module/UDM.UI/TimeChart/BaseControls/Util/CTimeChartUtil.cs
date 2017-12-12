using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace UDM.UI.TimeChart
{
	internal static class CTimeChartUtil
	{

		#region Public Methods

		public static SizeF MeasureString(Graphics g, string text, Font font)
		{
			SizeF size = new SizeF();

			size.Width = MeasureStringWidth(g, text, font);
			size.Height = MeasureStringHeight(g, text, font);

			return size;
		}

		public static float MeasureStringWidth(Graphics g, string text, Font font)
		{
			System.Drawing.StringFormat format = new System.Drawing.StringFormat();
			System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0, 0, 1000, 1000);
			System.Drawing.CharacterRange[] ranges = { new System.Drawing.CharacterRange(0, text.Length) };
			System.Drawing.Region[] regions = new System.Drawing.Region[1];

			format.SetMeasurableCharacterRanges(ranges);

			regions = g.MeasureCharacterRanges(text, font, rect, format);
			if (regions.Length == 0) { return 0; }

			rect = regions[0].GetBounds(g);

			return (float)(rect.Right + 1.0f);
		}

		public static float MeasureStringHeight(Graphics g, string text, Font font)
		{
			return g.MeasureString(text, font).Height;
		}

		public static float ToDecimal2(float nValue)
		{
			return (float)Math.Round((double)nValue, 2);
		}

		#endregion


		#region Private Methods

		#endregion
	}
}
