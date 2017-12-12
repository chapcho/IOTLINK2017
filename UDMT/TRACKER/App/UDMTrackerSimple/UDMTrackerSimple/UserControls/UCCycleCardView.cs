using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.PivotGrid.OLAP.AdoWrappers;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Widget;
using DevExpress.XtraEditors;
using UDM.Common;
using UDM.Log;
using UDM.Monitor.Plc;

namespace UDMTrackerSimple
{
    public partial class UCCycleCardView : DevExpress.XtraEditors.XtraUserControl
    {
        private Timer m_tmrTicker = new Timer();
        private CPlcProcS m_cProcessS = null;
        private CCycleInfoS m_cCycleInfoS = null;
        protected CMonitorViewer m_cMonitorViewer = null;

        public UCCycleCardView()
        {
            InitializeComponent();

            widgetView.AllowDocumentStateChangeAnimation = DefaultBoolean.True;
        }

        public CMonitorViewer MonitorViewer
        {
            get { return m_cMonitorViewer; }
            set { m_cMonitorViewer = value; }
        }

        public void ClearControls()
        {
            widgetView.Documents.Clear();
        }

        public void SetView(CPlcProcS cProcessS, CCycleInfoS cCycleInfoS)
        {
            Document doc = null;
            int iDocCount = 0;

            m_cProcessS = cProcessS;
            m_cCycleInfoS = cCycleInfoS;

            if (m_cProcessS == null || m_cCycleInfoS == null)
                return;

            docManager.View.QueryControl += widgetView_QueryControl;

            foreach (CPlcProc cProcess in m_cProcessS.Values)
            {
                doc = new Document();
                doc.Caption = cProcess.Name;
                doc.Height = 193;
                doc.Tag = cProcess;
                doc.AppearanceCaption.FontSizeDelta = 3;
                doc.AppearanceActiveCaption.FontSizeDelta = 3;

                widgetView.Documents.Add(doc);

                if (iDocCount % 3 == 0)
                    doc.ColumnIndex = 0;
                else if (iDocCount % 3 == 1)
                    doc.ColumnIndex = 1;
                else if (iDocCount%3 == 2)
                    doc.ColumnIndex = 2;

                iDocCount++;
            }
        }

        public void UpdateView()
        {
            foreach (Document doc in widgetView.Documents)
            {
                if (doc.Control == null)
                    continue;

                UCCycleCardWidget ucCard = (UCCycleCardWidget)doc.Control;
                ucCard.UpdateCycle();
            }
        }

        public void Run()
        {
            try
            {
                foreach (Document doc in widgetView.Documents)
                {
                    if (doc.Control == null)
                        continue;

                    UCCycleCardWidget ucCard = (UCCycleCardWidget)doc.Control;
                    ucCard.InitComponent();
                }


                if (m_cMonitorViewer != null)
                    m_cMonitorViewer.UEventGroupStateChanged += m_cMonitorViewer_UEventGroupStateChanged;

                m_tmrTicker.Tick += m_tmrTicker_Tick;
                m_tmrTicker.Start();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        public void Stop()
        {
            try
            {
                if (m_cMonitorViewer != null)
                    m_cMonitorViewer.UEventGroupStateChanged -= m_cMonitorViewer_UEventGroupStateChanged;

                if (m_tmrTicker.Enabled)
                    m_tmrTicker.Stop();

                m_tmrTicker.Tick -= m_tmrTicker_Tick;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void widgetView_QueryControl(object sender, DevExpress.XtraBars.Docking2010.Views.QueryControlEventArgs e)
        {
            UCCycleCardWidget ucCard = new UCCycleCardWidget();

            ucCard.BackColor = Color.White;

            CPlcProc cProcess = (CPlcProc)e.Document.Tag;

            if (m_cCycleInfoS.ContainsKey(cProcess.Name))
                ucCard.CycleInfo = m_cCycleInfoS[cProcess.Name];

            ucCard.MaxCycleTime = cProcess.MaxTactTime / 1000;

            e.Control = ucCard;
        }

        private void m_cMonitorViewer_UEventGroupStateChanged(object sender, UDM.Log.CGroupLog cLog)
        {
            if (cLog.Key == null || cLog.Key == "")
                return;

            CGroupLog cGroupLog = (CGroupLog)cLog.Clone();

            List<BaseDocument> lstdoc = widgetView.Documents.Where(x => x.Caption == cGroupLog.Key).ToList();
            BaseDocument doc = lstdoc.First();

            UCCycleCardWidget ucUnit = (UCCycleCardWidget) doc.Control;

            try
            {
                if (cGroupLog.StateType == EMGroupStateType.End || cGroupLog.StateType == EMGroupStateType.ErrorEnd)
                    ucUnit.SetGroupStatus(cGroupLog.StateType, cGroupLog.CycleEnd.Subtract(cGroupLog.CycleStart).TotalSeconds);
                else
                    ucUnit.SetGroupStatus(cGroupLog.StateType, 0);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        private void m_tmrTicker_Tick(object sender, EventArgs e)
        {
            m_tmrTicker.Stop();

            double nElapseTime = (double)m_tmrTicker.Interval / 1000;

            try
            {
                foreach(Document doc in widgetView.Documents)
                {
                    if(doc.Control == null)
                        continue;

                    UCCycleCardWidget ucCard = (UCCycleCardWidget)doc.Control;
                    ucCard.ElapseTime();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            m_tmrTicker.Start();
        }
    }
}
