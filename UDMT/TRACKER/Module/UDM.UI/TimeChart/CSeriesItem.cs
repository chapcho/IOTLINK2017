using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace UDM.UI.TimeChart
{
	public class CSeriesItem : CRowItem
	{

		#region Member Variables

		protected CSeriesPointS m_cPointS = null;
		protected Color m_cColor = Color.Black;
		protected bool m_bShowPoint = true;
		protected float m_nPointSize = 6f;
		protected float m_nScale = 1f;

		#endregion


		#region Initialize/Dispose

		public CSeriesItem(object[] oaValue)
			: base(oaValue)
		{
			m_cPointS = new CSeriesPointS(this);
		}

		public new void Dispose()
		{
			m_cPointS.Clear();
			base.Dispose();
		}

		#endregion


		#region Public Properties

		public CSeriesPointS PointS
		{
			get { return m_cPointS; }
		}

		public Color Color
		{
			get { return m_cColor; }
			set { m_cColor = value; }
		}

		public float MaxValue
		{
			get { return m_cPointS.MaxValue; }
		}

		public float MinValue
		{
			get { return m_cPointS.MaxValue; }
		}

		public float Scale
		{
			get { return m_nScale; }
			set { m_nScale = value; }
		}

		public bool ShowPoint
		{
			get { return m_bShowPoint; }
			set { m_bShowPoint = value; }
		}

		public float PointSize
		{
			get { return m_nPointSize; }
			set { m_nPointSize = value; }
		}

		#endregion


		#region Public Methods


		#endregion


		#region Private Methods

		#endregion


		#region Event Methods


		#endregion
	}
}
