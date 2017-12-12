using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace UDM.UI.TimeChart
{
	public partial class UCCanvas : PictureBox
	{

		#region Member Variables

		protected Font m_fntFont = new Font("Tahoma", 12f, FontStyle.Regular);
		
		public event UEventHandlerLayoutUpdated UEventLayoutUpdated;

		#endregion


		#region Initialize/Dispose

		public UCCanvas()
		{
			InitializeComponent();
		}

		public UCCanvas(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		#endregion


		#region Public Properties

		[Browsable(true)]
		public new Font Font
		{
			get { return m_fntFont; }
			set { m_fntFont = value; }
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Bitmap Image
		{
			get;
			set;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Bitmap ErrorImage
		{
			get;
			set;
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Bitmap InitialImage
		{
			get;
			set;
		}

		#endregion


		#region Public Methods

		public void BeginUpdate()
		{

		}

		public void EndUpdate()
		{

		}

		public void UpdateLayout()
		{
			this.Invalidate();
		}

		#endregion


		#region Private Methods


		#region Layout


		#endregion


		#region Item


		#endregion


		#region User Action


		#endregion


		#region Util


		#endregion


		#region Raising Event

		protected void GenerateLayoutUpdatedEvent()
		{
			if (UEventLayoutUpdated != null)
				UEventLayoutUpdated(this);
		}
		

		#endregion


		#region Drawing


		#endregion


		

		#endregion


		#region Event Methods

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);

			this.Focus();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
		}

		#endregion
	}
}
