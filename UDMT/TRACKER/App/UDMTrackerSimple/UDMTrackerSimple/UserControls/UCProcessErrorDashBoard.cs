using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMTrackerSimple
{
    public partial class UCProcessErrorDashBoard : DevExpress.XtraEditors.XtraUserControl
    {
        protected int m_iMinHeight = 150;
        protected Dictionary<string, CSymbolS> m_dicAbnormalSymbolS = null;

        #region Initialize

        public UCProcessErrorDashBoard()
        {
            InitializeComponent();
        }

        #endregion


        #region Public Properties

        public Dictionary<string, CSymbolS> AbnormalSymbolS
        {
            get { return m_dicAbnormalSymbolS; }
            set 
            { 
                m_dicAbnormalSymbolS = value;
                SetGroupS();
            }
        }

        #endregion


        #region Private Methods

        private void AddGroup(string sGroupKey, CSymbolS cSymbolS)
        {
            try
            {
                UCProcessErrorTagGrid ucViewer = new UCProcessErrorTagGrid();
                Panel pnlSplitter = new Panel();
                pnlSplitter.Dock = DockStyle.Top;
                pnlSplitter.Height = 5;

                ucViewer.GroupName = sGroupKey;
                ucViewer.AbnormalSymbolList = cSymbolS.Values.ToList();
                ucViewer.Dock = DockStyle.Top;
                ucViewer.Height = m_iMinHeight;
                ucViewer.UpdateGrid2();

                pnlView.Controls.Add(pnlSplitter);
                pnlView.Controls.Add(ucViewer);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void RemoveGroup(string sName)
        {
            pnlView.Controls.RemoveByKey(sName);
        }


        private void SetGroupS()
        {
            try
            {
                if (m_dicAbnormalSymbolS == null) return;
                foreach (var who in m_dicAbnormalSymbolS)
                {
                    AddGroup(who.Key, who.Value);
                }

                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
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
                    if (control.GetType() == typeof(UCProcessErrorTagGrid))
                        control.Height = iUnitHeight - 5;
                }

                pnlView.Refresh();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        #endregion


        #region Public Method

        public void UpdateInterlockGridS(Dictionary<string,CSymbolS> dicErrorSymbol)
        {
            ControlCollection controls = pnlView.Controls;
            try
            {
                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessErrorTagGrid))
                    {
                        UCProcessErrorTagGrid ucItem = (UCProcessErrorTagGrid)control;
                        if (dicErrorSymbol.ContainsKey(ucItem.GroupName))
                            ucItem.UpdateGrid(dicErrorSymbol[ucItem.GroupName].Values.ToList());
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void UpdateInterlockGridS(string sGroupKey, CSymbol cSymbol)
        {
            ControlCollection controls = pnlView.Controls;
            if (cSymbol == null) return;
            try
            {
                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessErrorTagGrid))
                    {
                        UCProcessErrorTagGrid ucItem = (UCProcessErrorTagGrid)control;
                        if (sGroupKey == ucItem.GroupName)
                        {
                            List<CSymbol> lstSymbol = new List<CSymbol>();
                            lstSymbol.Add(cSymbol);
                            ucItem.UpdateGrid(lstSymbol);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        public void UpdateInterlockGridS()
        {
            ControlCollection controls = pnlView.Controls;
            try
            {
                Control control;
                for (int i = 0; i < controls.Count; i++)
                {
                    control = controls[i];
                    if (control.GetType() == typeof(UCProcessErrorTagGrid))
                        ((UCProcessErrorTagGrid)control).UpdateGrid2();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void ClearControl()
        {
            if (pnlView.Controls != null && pnlView.Controls.Count > 0)
                pnlView.Controls.Clear();
        }

        #endregion



        private void UCGroupErrorDashBoard_Resize(object sender, EventArgs e)
        {
            try
            {
                SetUnitSize();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

    }
}
