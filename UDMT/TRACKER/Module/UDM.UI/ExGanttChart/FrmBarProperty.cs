using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.ExGanttChart
{
    public partial class FrmBarProperty : Form
    {
        #region Member Variables

        private bool m_bEditable = true;
        private bool m_bOK = false;
        private CGanttBar m_cBar = null;
        private DateTime m_dtStart = DateTime.MinValue;
        private DateTime m_dtEnd = DateTime.MinValue;
        private double m_nDuration = 0;

        #endregion


        #region Initialize/Dispose


        public FrmBarProperty(bool bEditable)
        {
            InitializeComponent();

            m_bEditable = bEditable;
        }

        #endregion
        

        #region Public Properties

        public CGanttBar Bar
        {
            set { m_cBar = value; }
        }

        public bool OK
        {
            get { return m_bOK; }
        }       
      
        #endregion


        #region Public Methods
        

        #endregion


        #region Private Methods


        private void ShowProperty(CGanttBar cBar)
        {
            double nDuration = cBar.End.Subtract(cBar.Start).TotalMilliseconds;
            txtItem.Text = cBar.Key;
            txtStartTime.Text = cBar.Start.ToString("HH:mm:ss.fff");
            txtEndTime.Text = cBar.End.ToString("HH:mm:ss.fff");
            txtDuration.Text = nDuration.ToString();
            txtText.Text = cBar.Text;

            txtStartTime.Focus();

            txtStartTime.Enabled = m_bEditable;
            txtEndTime.Enabled = m_bEditable;
            txtDuration.Enabled = m_bEditable;
            txtText.Enabled = m_bEditable;

            m_dtStart = cBar.Start;
            m_dtEnd = cBar.End;
            m_nDuration = nDuration;
        }

        private DateTime GetDateTime(DateTime dtBase, string sTime)
        {
            DateTime dtTime = dtBase;

            try
            {
                string[] saTime = sTime.Split(':');
                if (saTime == null || saTime.Length != 3)
                    return dtBase;

                string[] saSecMil = saTime[2].Split('.');
                if (saSecMil == null || saSecMil.Length != 2)
                    return dtBase;

                int iYear = dtBase.Year;
                int iMonth = dtBase.Month;
                int iDay = dtBase.Day;
                int iHour = int.Parse(saTime[0]);
                int iMin = int.Parse(saTime[1]);
                int iSec = int.Parse(saSecMil[0]);
                int iMilSec = int.Parse(saSecMil[1]);

                dtTime = new DateTime(iYear, iMonth, iDay, iHour, iMin, iSec, iMilSec);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                MessageBox.Show("Please Check Time Format!!");
            }

            return dtTime;
        }


        private void ShowDuration()
        {
            TimeSpan tsSpan = m_dtEnd.Subtract(m_dtStart);
            txtDuration.Text = tsSpan.TotalMilliseconds.ToString();
        }

        private int ToInteger(string sValue)
        {
            int iValue = 0;

            try
            {
                iValue = int.Parse(sValue);
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return iValue;
        }
        

        #endregion


        #region Event Methods

        private void FrmBarProperty_Load(object sender, EventArgs e)
        {   
            ShowProperty(m_cBar);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_bEditable)
            {
                m_bOK = true;

                if (m_dtStart > m_dtEnd)
                {
                    MessageBox.Show("Can't set StartTime(StartTime > EndTime)");
                    return;
                }
                else
                {
                    m_cBar.Start = m_dtStart;
                    m_cBar.End = m_dtEnd;
                }
            }
            else
                m_bOK = false;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bOK = false;

            this.Close();
        }
        
        private void txtStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStartTime_Leave(this, EventArgs.Empty);
                btnOK_Click(this, EventArgs.Empty);
            }
        }

        private void txtEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEndTime_Leave(this, EventArgs.Empty);
                btnOK_Click(this, EventArgs.Empty);
            }
        }

        private void txtDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDuration_Leave(this, EventArgs.Empty);
                btnOK_Click(this, EventArgs.Empty);
            }
        }

        private void txtStartTime_Leave(object sender, EventArgs e)
        {
            string sTime = txtStartTime.Text;
            m_dtStart = GetDateTime(m_dtStart, sTime);

            ShowDuration();
        }

        private void txtEndTime_Leave(object sender, EventArgs e)
        {
            string sTime = txtEndTime.Text;
            m_dtEnd = GetDateTime(m_dtEnd, sTime);

            ShowDuration();
        }

        private void txtDuration_Leave(object sender, EventArgs e)
        {
            string sDuration = txtDuration.Text.Trim();
            
            try
            {
                long nDuration = long.Parse(sDuration);

                if (nDuration <= 0)
                {
                    ShowDuration();
                    return;
                }

                m_dtEnd = m_dtStart.AddMilliseconds(nDuration);
                txtEndTime.Text = m_dtEnd.ToString("HH:mm:ss.fff");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void txtOffSet_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnOK_Click(this, EventArgs.Empty);
        }

        private void FrmBarProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel_Click(this, EventArgs.Empty);
            }
        }

        #endregion
        
    }
}
