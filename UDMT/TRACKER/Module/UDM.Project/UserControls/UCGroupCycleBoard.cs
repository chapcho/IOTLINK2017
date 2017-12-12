using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UDM.Log;

namespace UDM.Project
{
	public partial class UCGroupCycleBoard : UserControl
	{

		#region Member Variables

		protected EMGroupStateType m_emStateType = EMGroupStateType.End;
		protected int m_iElapseTime = 0;
		protected int m_iProductCount = 0;
		protected double m_nAvgCycleTime = 0;
		protected double m_nMaxCycleTime = 0;

		private delegate void UpdateStateTypeCallback(EMGroupStateType emStateType, double nCycleTime);
		private delegate void UpdateElapseTimeCallback();
		
		#endregion


		#region Initialize/Dispose

		public UCGroupCycleBoard()
		{
			InitializeComponent();
		}

		#endregion


		#region Public Properties

		public string Title
		{
			get { return lblTitle.Text; }
			set { lblTitle.Text = value; }
		}

		public double MaxCycleTime
		{
			get {return m_nMaxCycleTime;}
			set {SetMaxCycleTime(value);}
		}

		#endregion


		#region Public Methods

		public void SetGroupStatus(EMGroupStateType emStateType, double nCycleTime)
		{
			if (this.InvokeRequired)
			{
				UpdateStateTypeCallback cbUpdateState = new UpdateStateTypeCallback(SetGroupStatus);
				this.Invoke(cbUpdateState, new object[] {emStateType, nCycleTime});
			}
			else
			{
				if (emStateType == EMGroupStateType.Start)
				{
					ucCycleTimeInfo.ValueBarColor = Color.GreenYellow;

					SetElaspeTime(0);
				}
				else if (emStateType == EMGroupStateType.End)
				{
					SetElaspeTime(0);

					AddProductCount();

					UpdateAverAgeCycleTime(m_iProductCount, nCycleTime);

					AddCycleTimeHistory(nCycleTime, Color.GreenYellow, null);
				}
				else if (emStateType == EMGroupStateType.Error)
				{
					ucCycleTimeInfo.ValueBarColor = Color.Red;
				}
				else if (emStateType == EMGroupStateType.ErrorEnd)
				{
					SetElaspeTime(0);

					AddCycleTimeHistory(nCycleTime, Color.OrangeRed, null);
				}

				m_emStateType = emStateType;
			}
		}
		
		
		public void ElapseTime()
		{
			if (this.InvokeRequired)
			{
				UpdateElapseTimeCallback cbUpdateState = new UpdateElapseTimeCallback(ElapseTime);
				this.Invoke(cbUpdateState);
			}
			else
			{
				if (m_emStateType == EMGroupStateType.Start || m_emStateType == EMGroupStateType.Error)
				{
					m_iElapseTime += 1;
					ucCycleTimeInfo.CircleText = m_iElapseTime.ToString() + "s";
					ucCycleTimeInfo.Value = (float)m_iElapseTime;
				}
			}
		}

		public void Clear()
		{
			if (this.InvokeRequired)
			{
				UpdateElapseTimeCallback cbUpdateState = new UpdateElapseTimeCallback(Clear);
				this.Invoke(cbUpdateState);
			}
			else
			{
				SetElaspeTime(0);
				SetAverageCycleTime(0);
				SetProductCount(0);
				ucCycleTimeHistory.Clear();
			}
		}

		#endregion


		#region Private Methods

		protected void SetMaxCycleTime(double nValue)
		{
			m_nMaxCycleTime = nValue;
			ucCycleTimeInfo.BottomLabelText = nValue.ToString("F2") + "s";
			ucCycleTimeInfo.MaxValue = (float)nValue;
		}

		protected void SetProductCount(int iValue)
		{
			m_iProductCount = iValue;
			ucProductInfo.CircleText = m_iProductCount.ToString();
		}

		protected void SetAverageCycleTime(double nValue)
		{
			m_nAvgCycleTime = nValue;
			ucCycleTimeInfo.TopLabelText = m_nAvgCycleTime.ToString("F2") + "s";
		}

		protected void UpdateAverAgeCycleTime(int iCount, double nValue)
		{
			m_nAvgCycleTime =  (double)(m_nAvgCycleTime * (iCount - 1) + nValue) / (double)iCount;
			ucCycleTimeInfo.TopLabelText = m_nAvgCycleTime.ToString("F2") + "s";
		}

		protected void AddProductCount()
		{
			m_iProductCount += 1;
			ucProductInfo.CircleText = m_iProductCount.ToString();
		}

		protected void SetElaspeTime(int iValue)
		{
			m_iElapseTime = iValue;
			ucCycleTimeInfo.CircleText = iValue.ToString() + "s";
			ucCycleTimeInfo.Value = (float)iValue;
		}

		protected void AddCycleTimeHistory(double nValue, Color cColor, object oData)
		{
			ucCycleTimeHistory.AddPoint(nValue, cColor, oData);
		}


		#endregion


		#region Event Methods

		private void UCGroupBoard_Load(object sender, EventArgs e)
		{

		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			ucCycleTimeInfo.Width = 2 * ucCycleTimeInfo.Height;
			ucProductInfo.Width = ucProductInfo.Height;
		}

		#endregion
	}
}
