using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UExpression
{
	public partial class AutoFontSizeLabel : Label
	{
		#region Member Variables

		#endregion

		#region Initialize/Dispose
		public AutoFontSizeLabel()
		{
			InitializeComponent();
		}
		#endregion

		#region Properties

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods
		private Font GetCorrectFont(Graphics graphic, string sText, Size size, Font labelFont)
		{
			SizeF sizeStr = graphic.MeasureString(sText, labelFont);
			Font fontStr = new Font(labelFont.Name, labelFont.Size);

			float wRatio = size.Width / sizeStr.Width;
			float hRatio = size.Height / sizeStr.Height;
			float ratio = Math.Min(hRatio, wRatio);
			float newSize = (int)(Font.Size * ratio);

			fontStr = new Font(labelFont.Name, newSize, FontStyle.Bold);
			sizeStr = graphic.MeasureString(sText, fontStr);

			return fontStr;
		}
		#endregion

		#region Events
		private void AutoFontSizeLabel_Paint(object sender, PaintEventArgs e)
		{
			this.Font = GetCorrectFont(e.Graphics, this.Text, this.DisplayRectangle.Size, this.Font);
		}

		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
		}
		#endregion
	}
}
