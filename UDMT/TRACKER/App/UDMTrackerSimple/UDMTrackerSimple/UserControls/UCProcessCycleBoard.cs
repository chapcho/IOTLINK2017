using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Senders;
using UDM.Log;

namespace UDMTrackerSimple
{
	public partial class UCProcessCycleBoard : UserControl
	{

		#region Member Variables

		protected EMGroupStateType m_emStateType = EMGroupStateType.End;
		protected int m_iElapseTime = 0;
		protected int m_iProductCount = 0;
		protected double m_nAvgCycleTime = 0;
		protected double m_nMaxCycleTime = 0;
        protected DateTime m_dtCycleStart = DateTime.MinValue;

        protected bool m_bEnd = false;
        protected bool m_bStart = false;

		private delegate void UpdateStateTypeCallback(EMGroupStateType emStateType, double nCycleTime);
		private delegate void UpdateElapseTimeCallback();
        private delegate void UpdateRecipeCallback(string sRecipe);


		
		#endregion


		#region Initialize/Dispose

		public UCProcessCycleBoard()
		{
			InitializeComponent();

            ucCycleTimeInfo.MouseWheel += new MouseEventHandler(ucCycleTimeInfo_MouseWheel);
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

        public DateTime CycleStartTime
        {
            get { return m_dtCycleStart; }
            set { m_dtCycleStart = value; }
        }

		#endregion


		#region Public Methods

		public void SetGroupStatus(EMGroupStateType emStateType, double nCycleTime)
		{
		    try
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
		                m_bStart = true;
		                m_bEnd = false;
		                ucCycleTimeInfo.ValueBarColor = Color.GreenYellow;

		                SetElaspeTime(0);
		            }
		            else if (emStateType == EMGroupStateType.End)
		            {
		                SetElaspeTime(0);
		                m_iProductCount++;

		                UpdateAverAgeCycleTime(m_iProductCount, nCycleTime);
		                m_bEnd = true;
		                m_bStart = false;
		                //AddCycleTimeHistory(nCycleTime, Color.GreenYellow, null);
		            }
		            else if (emStateType == EMGroupStateType.Error)
		            {
		                ucCycleTimeInfo.ValueBarColor = Color.Red;
		            }
		            else if (emStateType == EMGroupStateType.ErrorEnd)
		            {
		                SetElaspeTime(0);

		                m_bEnd = true;
		                m_bStart = false;
		                //AddCycleTimeHistory(nCycleTime, Color.OrangeRed, null);
		            }

		            m_emStateType = emStateType;
		        }
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine(ex.Message);
                ex.Data.Clear();
		    }
		}
		
		public void ElapseTime()
		{
		    try
		    {
		        if (this.InvokeRequired)
		        {
		            UpdateElapseTimeCallback cbUpdateState = new UpdateElapseTimeCallback(ElapseTime);
		            this.Invoke(cbUpdateState);
		        }
		        else
		        {
		            if (m_bEnd || !m_bStart)
		                return;

		            if (m_emStateType == EMGroupStateType.Start || m_emStateType == EMGroupStateType.Error)
		            {
		                m_iElapseTime += 1;
		                ucCycleTimeInfo.CircleText = m_iElapseTime.ToString() + "s";
		                ucCycleTimeInfo.Value = (float) m_iElapseTime;
		            }
		        }
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

		public void Clear()
		{
		    try
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
		        }
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

		#endregion


		#region Private Methods

		protected void SetMaxCycleTime(double nValue)
		{
		    try
		    {
		        m_nMaxCycleTime = nValue;
		        ucCycleTimeInfo.BottomLabelText = nValue.ToString("F2") + "s";
		        ucCycleTimeInfo.MaxValue = (float) nValue;
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

        //protected void SetProductCount(int iValue)
        //{
        //    m_iProductCount = iValue;
        //    ucProductInfo.CircleText = m_iProductCount.ToString();
        //}

		protected void SetAverageCycleTime(double nValue)
		{
		    try
		    {
		        m_nAvgCycleTime = nValue;
		        ucCycleTimeInfo.TopLabelText = m_nAvgCycleTime.ToString("F2") + "s";
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

		protected void UpdateAverAgeCycleTime(int iCount, double nValue)
		{
		    try
		    {
		        if (m_nAvgCycleTime == 0)
		            m_nAvgCycleTime = nValue;
		        else
		            m_nAvgCycleTime = (double) ((m_nAvgCycleTime*(iCount - 1)) + nValue)/(double) iCount;

		        ucCycleTimeInfo.TopLabelText = m_nAvgCycleTime.ToString("F2") + "s";
		    }
		    catch (Exception ex)
		    {
		        Console.WriteLine(ex.Message);
		        ex.Data.Clear();
		    }
		}

		protected void SetElaspeTime(int iValue)
		{
		    try
		    {
		        m_iElapseTime = iValue;
		        ucCycleTimeInfo.CircleText = iValue.ToString() + "s";
		        ucCycleTimeInfo.Value = (float) iValue;
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		}

        //protected void AddCycleTimeHistory(double nValue, Color cColor, object oData)
        //{
        //    ucCycleTimeHistory.AddPoint(nValue, cColor, oData);
        //}


		#endregion


		#region Event Methods

		private void UCGroupBoard_Load(object sender, EventArgs e)
		{

		}

		protected override void OnResize(EventArgs e)
		{
		    try
		    {
		        base.OnResize(e);

		        ucCycleTimeInfo.Width = 2*ucCycleTimeInfo.Height;
		    }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
		    //ucProductInfo.Width = ucProductInfo.Height;
		}

		#endregion

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucCycleTimeInfo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseDown(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucCycleTimeInfo_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseWheel(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucCycleTimeInfo_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseUp(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseUp(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void ucCycleTimeInfo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                this.OnMouseMove(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }
	}
}
