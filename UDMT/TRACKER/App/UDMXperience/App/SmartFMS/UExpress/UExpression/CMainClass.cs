using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UExpression
{
	internal class CMainClass : IDisposable
	{
		#region Member Variables
		private float m_nTargetNum = 0;
		#endregion


		#region Initilaize/Dispose

		public CMainClass()
		{
			// CMainClass가 선언되면 Unit 정보를 Server에서 Read
			// Read 된 Unit 정보 Setting
		}

		public void Dispose()
		{

		}

		#endregion


		#region Public Properties
		public float TargetNum
		{
			get { return m_nTargetNum; }
		}

		#endregion


		#region Public Methods
		public void ChangeFontSize(List<Label> lstLabelS)
		{
			SettingFontSizeToLabelS(lstLabelS);
		}

		#endregion


		#region Private Methods
		private void SettingFontSizeToLabelS(List<Label> lstLabelS)
		{
			List<float> lstSizeS = new List<float>();
			for (int i = 0; i < lstLabelS.Count; i++ )
			{
				Graphics g = lstLabelS[i].CreateGraphics();
				float fontSize = NewFontSize(g, lstLabelS[i].Bounds.Size, lstLabelS[i].Font, lstLabelS[i].Text);
				lstSizeS.Add(fontSize);
			}

			float nFontSizeMin = lstSizeS.Min();
			SetLabelSFont(lstLabelS, nFontSizeMin);

		}

		private void SetLabelSFont(List<Label> lstLabelS, float f)
		{
			for(int i = 0; i < lstLabelS.Count; i++)
			{
				Font font = new Font("Arial", f, FontStyle.Bold);
				lstLabelS[i].Font = font;
				lstLabelS[i].BackColor = System.Drawing.Color.Transparent;
			}
		}

		private static float NewFontSize(Graphics graphics, Size size, Font font, string str)
		{
			SizeF stringSize = graphics.MeasureString(str, font);
			float wRatio = size.Width / stringSize.Width;
			float hRatio = size.Height / stringSize.Height;
			float ratio = Math.Min(hRatio, wRatio);
			return font.Size * ratio;
		}
		#endregion
	}
}
