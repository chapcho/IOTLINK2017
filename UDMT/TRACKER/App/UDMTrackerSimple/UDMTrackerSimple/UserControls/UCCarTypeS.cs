using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace UDMTrackerSimple
{
    public partial class UCCarTypeS : DevExpress.XtraEditors.XtraUserControl
    {
        protected int m_iMinHeight = 200;
        public event UEventHandlerScrollBarMoved UEventScrollBarMoved = null;

        public UCCarTypeS()
        {
            InitializeComponent();
        }

        public void ShowBoard(string sPlcKey)
        {
            Clear();
            SetCarTypeS(sPlcKey);
        }

        public void ShowBoard()
        {
            Clear();
            SetCarTypeS();
        }

        public void Clear()
        {
            if (pnlView.Controls.Count > 0)
            {
                foreach (Control control in pnlView.Controls)
                {
                    control.Dispose();
                    pnlView.Controls.Remove(control);
                }

                pnlView.Controls.Clear();
                pnlView.Refresh();
            }
        }

        public void SetScrollPosition(int iYPosition)
        {
            pnlView.VerticalScroll.Value = iYPosition;
            pnlView.Refresh();
        }


        public void UpdateCarTypeS(string sProcessKey, string sRecipe)
        {
            if (!pnlView.Controls.ContainsKey(sProcessKey)) return;

            UCCarType ucCarType = (UCCarType)pnlView.Controls[sProcessKey];

            ucCarType.SetCarType(sRecipe);
        }

        private void SetUnitSize()
        {
            ControlCollection controls = pnlView.Controls;
            if (controls.Count == 0)
                return;

            try
            {
                int iUnitHeight = 0;
                if (controls.Count > 7)
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / controls.Count;
                else
                    iUnitHeight = pnlView.ClientRectangle.Height * 2 / 8;
                if (iUnitHeight < m_iMinHeight)
                    iUnitHeight = m_iMinHeight;

                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessCycleBoard))
                        control.Height = iUnitHeight - 5;
                }

                pnlView.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void AddGroup(CPlcProc cProcess)
        {
            try
            {
                UCCarType ucViewer = new UCCarType();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Top;
                pnlSplitter.Height = 5;

                ucViewer.Name = cProcess.Name;
                ucViewer.ProcessKey = cProcess.Name;
                ucViewer.Dock = DockStyle.Top;
                ucViewer.Height = m_iMinHeight;

                pnlView.Controls.Add(pnlSplitter);
                pnlView.Controls.Add(ucViewer);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void SetCarTypeS(string sPlcKey)
        {
            try
            {
                CPlcProc cProcess;
                for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
                {
                    cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                    if (!cProcess.PlcLogicDataS.ContainsKey(sPlcKey))
                        continue;

                    if (!cProcess.IsErrorMonitoring)
                        AddGroup(cProcess);
                }
                for (int i = 0; i < pnlView.Controls.Count; i++)
                    pnlView.Controls[i].BringToFront();
                
                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void SetCarTypeS()
        {
            try
            {
                CPlcProc cProcess;
                for (int i = 0; i < CMultiProject.PlcProcS.Count; i++)
                {
                    cProcess = CMultiProject.PlcProcS.ElementAt(i).Value;

                    if (!cProcess.IsErrorMonitoring)
                        AddGroup(cProcess);
                }
                for (int i = 0; i < pnlView.Controls.Count; i++)
                    pnlView.Controls[i].BringToFront();

                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void pnlView_Scroll(object sender, ScrollEventArgs e)
        {
            if (UEventScrollBarMoved != null)
                UEventScrollBarMoved(pnlView.VerticalScroll.Value);
        }


    }
}
