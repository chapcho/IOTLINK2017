using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UDM.UI.ExGanttChart
{
    public partial class UCGanttChart : UserControl
    {
        #region Member Variables

        protected bool m_bEditable = false;
        protected bool m_bFirstDraw = true;
        protected bool m_bUpdating = false;
        protected bool m_bChartEventActivated = false;
		protected bool m_bInsideZoom = true;
        protected bool m_bGenerateEvent = false;

        protected int m_iUnitHeight = 26;
        protected int m_iUnitWidth = 20;
        protected int m_iOverviewHeight = 100;
        protected int m_iPaneWidthLeft = 20;
        protected int m_iBarHeight = 18;
       
        protected CGanttHeaderS m_cColumnHeaderS = null;
        protected Color m_cSelectItemColor = Color.PaleTurquoise;
        protected EMGanttBarType m_emGanttBarType = EMGanttBarType.BTask;
		protected EMGanttUnitScale m_emGanttUnitScale = EMGanttUnitScale.Second;
        protected CGanttTimeZoneS m_cTimeZoneS = new CGanttTimeZoneS();
        protected CGanttTimeIndicatorS m_cTimeIndicatorS = new CGanttTimeIndicatorS();
        protected CGanttTimeIndicator m_cTimeIndicatorSelected = null;
        protected Point m_pntTimeIndicator = new Point(0, 0);

        protected Point m_pntMiddleButton = new Point(0, 0);

        protected DateTime m_dtFirstVisibleTime = DateTime.MinValue;
        protected exontrol.EXG2ANTTLib.Chart m_exChart = null;
        protected exontrol.EXG2ANTTLib.Items m_exItems = null;
        protected ContextMenuStrip m_mnuBar = null;
        protected ContextMenuStrip m_mnuItem = null;

        public event UEventHandlerGanttMouseDown UEventMouseDown;
        public event UEventHandlerGanttMouseUp UEventMouseUp;
        public event UEventHandlerGanttMouseMove UEventMouseMove;
        public event UEventHandlerGanttFirstVisibleTimeChanged UEventFirstVisibleTimeChanged;
        public event UEventHandlerGanttZoomed UEventZoomed;
        public event UEventHandlerGanttGridWidthChanged UEventGridWidthChanged;

        public event UEventHandlerGanttBarTimeChanged UEventBarTimeChanged;
        public event UEventHandlerGanttBarCreated UEventBarCreated;
        public event UEventHandlerGanttBarRemoved UEventBarRemoved;
        public event UEventHandlerGanttLinkUpdated UEventLinkUpdated;
        public event UEventHandlerGanttLinkCreated UEventLinkCreated;
        public event UEventHandlerGanttLinkRemoved UEventLinkRemoved;
        public event UEventHandlerGanttBarClicked UEventBarClicked;
        public event UEventHandlerGanttBarDoubleClicked UEventBarDoubleClicked;
        public event UEventHandlerGanttLinkClicked UEventBarLinkClicked;
        public event UEventHandlerGanttLinkDoubleClicked UEventBarLinkDoubleClicked;
        public event UEventHandlerGanttKeyDown UEventKeyDown;
        public event UEVentHandlerGanttTimeIndicatorCreated UEventTimeIndicatorCreated;
        public event UEventHandlerGanttTimeIndicatorRemoved UEventTimeIndicatorRemoved;
        public event UEventHandlerGanttTimeIndicatorMoved UEventTimeIndicatorMoved;
        public event UEventHandlerGanttTimeIndicatorIntervalChanged UEventTimeIndicatorIntervalChanged;
		public event UEventHandlerGanttAfterExpandItem UEventAfterExpandItem;

        #endregion


        #region Initialize/Dispose

        public UCGanttChart()
        {
            exontrol.EXG2ANTTLib.exg2antt.RuntimeKey = "yjcpmfBwfovgm0eqo";

            InitializeComponent();

            InitChartLayout();

            InitChartBarTypeS();

            m_cColumnHeaderS = new CGanttHeaderS(this);
        }

        #endregion


        #region Public Properties

        public bool Editable
        {
            get { return m_bEditable; }
            set { m_bEditable = value; SetChartEditable(value); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CGanttHeaderS ColumnHeaderS
        {
            get { return m_cColumnHeaderS; }
            set { SetColumnHeader(value); }
        }

        public int UnitHeight
        {
            get { return m_iUnitHeight; }
            set { SetCellHeight(value); }
        }

        public int UnitWidth
        {
            get { return m_iUnitWidth; }
            set { SetCellWidth(value); }
        }

        public int OverViewHeight
        {
            get { return m_iOverviewHeight; }
            set { SetOverviewHeight(value); }
        }

        public int BarHeight
        {
            get { return m_iBarHeight; }
            set { m_iBarHeight = value; InitChartBarTypeS(); }
        }

        public DateTime FirstVisibleTime
        {
            get { return exGant.Chart.FirstVisibleDate; }
            set { SetFirstVisibleTime(value); }
        }

        public int LeftPanelWidth
        {
            get { return exGant.Chart.PaneWidthLeft; }
        }

        public Color SelectedItemColor
        {
            get { return m_cSelectItemColor; }
            set { m_cSelectItemColor = value; }
        }

        public ContextMenuStrip BarMenu
        {
            get { return m_mnuBar; }
            set { m_mnuBar = value; }
        }

        public ContextMenuStrip ItemMenu
        {
            get { return m_mnuItem; }
            set { m_mnuItem = value; }
        }

        public CGanttTimeIndicatorS TimeIndicatorS
        {
            get { return m_cTimeIndicatorS; }
        }

		public EMGanttUnitScale DefaultUnitScale
		{
			get { return m_emGanttUnitScale; }
			set { SetDefaultUnitScale(value); }
		}

		public bool InsideZoom
		{
			get { return m_bInsideZoom; }
			set { SetInsideZoom(value); }
		}


        #endregion


        #region Public Methods

        #region Item
        
        public bool AddItem(CGanttItem cItem)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                int iHandle = m_exItems.AddItem(cItem.Key);
                cItem.Handle = iHandle;
                if (cItem.Handle > 0)
                {
                    m_exItems.set_ItemData(cItem.Handle, cItem);

                    if (cItem.CellTextS != null)
                    {
                        int iCount = (cItem.CellTextS.Length > m_cColumnHeaderS.Count) ? m_cColumnHeaderS.Count : cItem.CellTextS.Length;
                        for (int i = 0; i < iCount; i++)
                        {
                            m_exItems.set_CellValue(cItem.Handle, i, cItem.CellTextS[i]);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool InsertItem(CGanttItem cParent, CGanttItem cItem)
        {
            bool bOK = true;

            if (cParent.IsExist == false)
                return false;

            m_bGenerateEvent = false;

            try
            {
                cItem.Handle = m_exItems.InsertItem(cParent.Handle, cItem.Key);
                if (cItem.Handle > 0)
                {
                    cItem.Path = cParent.Path + "/" + cItem.Key;
                    m_exItems.set_ItemData(cItem.Handle, cItem);

                    if (cItem.CellTextS != null)
                    {
                        int iCount = (cItem.CellTextS.Length > m_cColumnHeaderS.Count) ? m_cColumnHeaderS.Count : cItem.CellTextS.Length;
                        for (int i = 0; i < iCount; i++)
                        {
                            m_exItems.set_CellValue(cItem.Handle, i, cItem.CellTextS[i]);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool RemoveItem(CGanttItem cItem)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                RemoveChildItem(cItem.Handle);

                if (m_exItems.get_EnableItem(cItem.Handle))
                    m_exItems.RemoveItem(cItem.Handle);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public void RemoveSelectedGanttItem()
        {
            CGanttItemS cItemS = new CGanttItemS();
            CGanttItem cItem = null;
            int iSelectedItemCount = m_exItems.SelectCount;
            int iHandle;
            object oData;

            try { 
                for(int i = 0; i < iSelectedItemCount;i++)
                {
                    iHandle = m_exItems.get_SelectedItem(i);
                    if(iHandle > 0)
                    {
                        oData = m_exItems.get_ItemData(iHandle);
                        if (oData != null && oData.GetType() == typeof(CGanttItem))
                        {
                            cItem = (CGanttItem)oData;
                            cItemS.Add(cItem);
                        }
                    }
                }

                foreach(CGanttItem item in cItemS)
                {
                    this.RemoveItem(item);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

        }

        public void RemoveChildItem(CGanttItem cItem)
        {
            m_bGenerateEvent = false;

            try
            {
                RemoveChildItem(cItem.Handle);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            m_bGenerateEvent = true;
        }

        public void ExpandItem(CGanttItem cItem)
        {
            if (cItem.IsExist == false)
                return;

            m_exItems.set_ExpandItem(cItem.Handle, true);
        }

        public CGanttItemS GetSelectedItemS()
        {
            CGanttItemS cItemS = new CGanttItemS();
            CGanttItem cItem = null;

            try
            {
                int iCount = m_exItems.SelectCount;
                int iHandle;
                object oData;
                for (int i = 0; i < iCount; i++)
                {
                    iHandle = m_exItems.get_SelectedItem(i);
                    if (iHandle > 0)
                    {
                        oData = m_exItems.get_ItemData(iHandle);
                        if (oData != null && oData.GetType() == typeof(CGanttItem))
                        {
                            cItem = (CGanttItem)oData;
                            cItemS.Add(cItem);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cItemS;
        }

		public CGanttItem GetItem(int X, int Y)
		{
			int iHandle = exGant.get_ItemFromPoint(X, Y);
			CGanttItem cItem = GetItem(iHandle);
			return cItem;
		}

        public CGanttItem GetItem(CGanttBar cBar)
        {
            CGanttItem cItem = null;

            try
            {
                if (cBar.Handle > 0)
                {
                    int iHandle = cBar.Handle;
                    if (iHandle > 0)
                    {
                        cItem = (CGanttItem)(m_exItems.get_ItemData(iHandle));
                    }
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return cItem;
        }

        public CGanttItem GetChildItem(CGanttItem cParent, string sKey)
        {   
            List<CGanttItem> lstChild = GetChildItem(cParent);
            if (lstChild == null)
                return null;

            CGanttItem cItem;
            CGanttItem cItemFound = null;
            for (int i = 0; i < lstChild.Count; i++)
            {
                cItem = lstChild[i];
                if (cItem.Key == sKey)
                    cItemFound = cItem;
            }

            return cItemFound;
        }

        public CGanttItem GetItemHasData(object oData)
        {
            CGanttItem cItemFound = null;
            CGanttItem cItem;

            int iCount = m_exItems.ItemCount;
            int iHandle;
            object oItem;
            for (int i = 0; i < iCount; i++)
            {
                iHandle = m_exItems[i];
                oItem = m_exItems.get_ItemData(iHandle);
                if (oItem != null && oItem.GetType() == typeof(CGanttItem))
                {
                    cItem = (CGanttItem)oItem;
                    if (cItem.Data == oData)
                    {
                        cItemFound = cItem;
                        break;
                    }
                }
            }

            return cItemFound;
        }

        public CGanttItem GetChildItemHasData(CGanttItem cParent, object oData)
        {
            List<CGanttItem> lstChild = GetChildItem(cParent);
            if (lstChild == null)
                return null;

            CGanttItem cItem;
            CGanttItem cItemFound = null;
            for (int i = 0; i < lstChild.Count; i++)
            {
                cItem = lstChild[i];
                if (cItem.Data == oData)
                    cItemFound = cItem;
            }

            return cItemFound;
        }

        public CGanttItem GetParentItem(CGanttItem cItem)
        {
            CGanttItem cParentItem = null;

            if (cItem.Handle > 0)
            {
                int iHandle = cItem.Handle;
                int iParentHandle = m_exItems.get_ItemParent(iHandle);
                object objValue;

                while (iParentHandle > 0)
                {
                    objValue = (m_exItems.get_ItemData(iParentHandle));
                    if (objValue == null)
                        break;

                    if (objValue.GetType() == typeof(CGanttItem))
                    {
                        cParentItem = (CGanttItem)objValue;
                        break;
                    }
                }
            }

            return cParentItem;
        }

        public int GetChildCount(CGanttItem cParent)
        {
            return m_exItems.get_ChildCount(cParent.Handle);
        }

        public List<CGanttItem> GetChildItem(CGanttItem cParent)
        {
            List<CGanttItem> lstItem = new List<CGanttItem>();

            int iCount = m_exItems.get_ChildCount(cParent.Handle);
            if (iCount == 0)
                return lstItem;

            int iHandle;
            object oItem;
            CGanttItem cItem;
            iHandle = m_exItems.get_ItemChild(cParent.Handle);
            oItem = m_exItems.get_ItemData(iHandle);
            if (oItem != null && oItem.GetType() == typeof(CGanttItem))
            {
                cItem = (CGanttItem)oItem;
                lstItem.Add(cItem);
            }

            for (int i = 1; i < iCount; i++)
            {
                iHandle = m_exItems.get_NextSiblingItem(iHandle);
                oItem = m_exItems.get_ItemData(iHandle);
                if (oItem != null && oItem.GetType() == typeof(CGanttItem))
                {
                    cItem = (CGanttItem)oItem;
                    lstItem.Add(cItem);
                }
            }

            return lstItem;
        }

        public void SetItemBackColor(CGanttItem cItem, Color cColor)
        {
            if (cItem.IsExist == false)
                return;
            
            if (cColor == Color.Transparent)
                m_exItems.ClearItemBackColor(cItem.Handle);
            else
                m_exItems.set_ItemBackColor(cItem.Handle, cColor);

        }

        #endregion

        #region Bar
        
        public bool AddBar(CGanttItem cItem, CGanttBar cBar)
        {
            bool bOK = true;

            if (cItem.IsExist == false)
                return false;

            m_bGenerateEvent = false;

            try
            {
                cBar.Handle = cItem.Handle;
                cBar.Key = cItem.Path + "/" + cItem.BarCount.ToString();
                m_exItems.AddBar(cItem.Handle, cItem.BarType.ToString(), cBar.Start, cBar.End, cBar.Key, cBar.Text);
                m_exItems.set_BarData(cItem.Handle, cBar.Key, cBar);
                DecorateBar(cItem.Handle, cBar.Key, cBar.BarType, cBar.EdgeType, cBar.EdgeShapeType, cItem.OffSet, CreateTooltip(cBar.Start, cBar.End));

                cItem.BarCount += 1;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool UpdateBar(CGanttBar cBar)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (cBar.Handle > 0)
                {
                    DecorateBar(cBar.Handle, cBar.Key, cBar.BarType, cBar.EdgeType, cBar.EdgeShapeType);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public CGanttBar GetBar(CGanttItem cItem, DateTime dtStart)
        {
            CGanttBar cBar = null;

            CGanttBarS cBarS = GetBarS(cItem);
            if (cBarS != null)
            {
                for(int i=0;i<cBarS.Count;i++)
                {
                    if (cBarS[i].Start == dtStart)
                    {
                        cBar = cBarS[i];
                        break;
                    }
                }
            }

            return cBar;
        }

        public CGanttBar GetBarHasData(CGanttItem cItem, object oData)
        {
            CGanttBar cBar = null;

            CGanttBarS cBarS = GetBarS(cItem);
            if (cBarS != null)
            {
                for (int i = 0; i < cBarS.Count; i++)
                {
                    if (cBarS[i].Data == oData)
                    {
                        cBar = cBarS[i];
                        break;
                    }
                }
            }

            return cBar;
        }

        public bool RemoveBar(CGanttBar cBar)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (cBar.Handle > 0)
                {
                    m_exItems.RemoveBar(cBar.Handle, cBar.Key);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool AddBarS(CGanttItem cItem, CGanttBarS cBarS)
        {
            bool bOK = true;

            if (cItem.IsExist == false)
                return false;

            m_bGenerateEvent = false;

            try
            {
                CGanttBar cBar;
                for (int i = 0; i < cBarS.Count; i++)
                {
                    cBar = cBarS[i];
                    AddBar(cItem, cBar);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public CGanttBarS GetSelectedBarS()
        {
            CGanttBarS cBarS = new CGanttBarS();

            try
            {
                List<exontrol.EXG2ANTTLib.Items.SelectedBar> lstBar = m_exItems.get_SelectedBars();
                if (lstBar == null)
                    return null;

                exontrol.EXG2ANTTLib.Items.SelectedBar exBar;
                CGanttBar cBar;
                for (int i = 0; i < lstBar.Count; i++)
                {
                    exBar = lstBar[i];

                    cBar = (CGanttBar)m_exItems.get_BarData(exBar.Item, exBar.Key);
                    cBarS.Add(cBar);
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return cBarS;
        }

        public int GetBarCount(CGanttItem cItem)
        {
            return m_exItems.get_BarsCount(cItem.Handle);
        }

        public CGanttBarS GetBarS(CGanttItem cItem)
        {
            CGanttBarS cBarS = new CGanttBarS();

            if (cItem.BarCount > 0)
            {
                CGanttBar cBar;
                object oData;
                for (int i = 0; i < cItem.BarCount; i++)
                {
                    oData = m_exItems.get_BarData(cItem.Handle, cItem.Path + "/" + i.ToString());
                    if (oData != null && oData.GetType() == typeof(CGanttBar))
                    {
                        cBar = (CGanttBar)oData;
                        cBarS.Add(cBar);
                    }
                }
            }

            return cBarS;
        }

        #endregion
        
        #region Link

        public bool AddLink(CGanttLink cLink)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (cLink == null || cLink.BarFrom == null || cLink.BarTo == null || cLink.BarFrom.Key == "" || cLink.BarTo.Key == "")
                {
                    m_bGenerateEvent = true;
                    return false;
                }

				if(cLink.Key == "")
				{ 
					cLink.Key = cLink.BarFrom.Handle.ToString() + "_" + cLink.BarTo.Handle.ToString();
				}
                m_exItems.AddLink(cLink.Key, cLink.BarFrom.Handle, cLink.BarFrom.Key, cLink.BarTo.Handle, cLink.BarTo.Key);
                m_exItems.set_LinkUserData(cLink.Key, cLink);
                DecorateLink(cLink.Key, cLink.Color, cLink.PointTypeFrom, cLink.PointTypeTo, cLink.Text);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool UpdateLink(CGanttLink cLink)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (cLink == null || cLink.BarFrom == null || cLink.BarTo == null || cLink.BarFrom.Key == "" || cLink.BarTo.Key == "")
                {
                    m_bGenerateEvent = true;
                    return false;
                }

                DecorateLink(cLink.Key, cLink.Color, cLink.PointTypeFrom, cLink.PointTypeTo, cLink.Text);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool RemoveLink(CGanttLink cLink)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (cLink == null || cLink.BarFrom == null || cLink.BarTo == null || cLink.BarFrom.Key == "" || cLink.BarTo.Key == "")
                    return false;

                m_exItems.RemoveLink(cLink.Key);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool AddLinkS(CGanttLinkS cLinkS)
        {
            bool bTotalOK = true;
            bool bOK = true;

            m_bGenerateEvent = false;

            CGanttLink cLink;
            for (int i = 0; i < cLinkS.Count; i++)
            {
                cLink = cLinkS[i];
                bOK = AddLink(cLink);
                if (bTotalOK)
                    bTotalOK = bOK;
            }

            m_bGenerateEvent = true;

            return bTotalOK;
        }

        #endregion

        #region Time zone

        public bool AddTimeZone(CGanttTimeZone cTimeZone)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                string sKey = cTimeZone.Key;
                if (m_cTimeZoneS.ContainsKey(sKey) == false)
                {
                    m_exChart.MarkTimeZone(sKey, cTimeZone.Start, cTimeZone.End, cTimeZone.BackColor, ";;" + cTimeZone.Text);
                    m_cTimeZoneS.Add(sKey, cTimeZone);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public CGanttTimeZone GetTimeZone(string sTimeZoneKey)
        {
            CGanttTimeZone cTimeZone = null;

            if (m_cTimeZoneS.ContainsKey(sTimeZoneKey))
                cTimeZone = m_cTimeZoneS[sTimeZoneKey];

            return cTimeZone;
        }

        public CGanttTimeZone GetTimeZone(int iIndex)
        {
            CGanttTimeZone cTimeZone = null;

            if (m_cTimeZoneS.Count > iIndex)
                cTimeZone = m_cTimeZoneS.ElementAt(iIndex).Value;

            return cTimeZone;
        }

        public int GetTimeZoneCount()
        {
            return m_cTimeZoneS.Count;
        }

        public bool RemoveTimeZone(string sTimeZoneKey)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                if (m_cTimeZoneS.ContainsKey(sTimeZoneKey) == false)
                {
                    m_exChart.RemoveTimeZone(sTimeZoneKey);
                    m_cTimeZoneS.Remove(sTimeZoneKey);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool RemoveTimeZone(int iIndex)
        {
            bool bOK = true;

            m_bGenerateEvent = false;

            try
            {
                CGanttTimeZone cTimeZone = GetTimeZone(iIndex);
                if (cTimeZone != null)
                    RemoveTimeZone(cTimeZone.Key);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
                bOK = false;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public void ClearTimeZone()
        {
            m_bGenerateEvent = false;

            try
            {
                string sKey = "";
                for (int i = 0; i < m_cTimeZoneS.Count; i++)
                {
                    sKey = m_cTimeZoneS.ElementAt(i).Key;
                    m_exChart.RemoveTimeZone(sKey);
                }

                m_cTimeZoneS.Clear();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            m_bGenerateEvent = true;
        }

        #endregion

        #region Note

        public bool AddNote(CGanttBar cBar, string sText, int iXOffSet, int iYOffSet)
        {
            bool bOK = false;

            m_bGenerateEvent = false;

            if (cBar.Handle > 0)
            {
                exontrol.EXG2ANTTLib.Note cNote = m_exChart.Notes.Add(cBar.Key + "_" + cBar.Key, cBar.Handle, cBar.Key, sText);
                if (cNote == null)
                    return false;

                cNote.set_PartCanMove(exontrol.EXG2ANTTLib.NotePartEnum.exNoteStart, true);
                cNote.set_PartCanMove(exontrol.EXG2ANTTLib.NotePartEnum.exNoteEnd, true);
                cNote.ShowLink = exontrol.EXG2ANTTLib.NoteLinkTypeEnum.exNoteLinkEndToStart;
                cNote.set_PartAlignment(exontrol.EXG2ANTTLib.NotePartEnum.exNoteEnd, exontrol.EXG2ANTTLib.AlignmentEnum.CenterAlignment);
                cNote.set_PartVOffset(exontrol.EXG2ANTTLib.NotePartEnum.exNoteEnd, iYOffSet);
                cNote.set_PartHOffset(exontrol.EXG2ANTTLib.NotePartEnum.exNoteEnd, iXOffSet);

                bOK = true;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        public bool RemoveNote(CGanttBar cBar)
        {
            bool bOK = false;

            m_bGenerateEvent = false;

            if (cBar.Handle > 0)
            {
                m_exChart.Notes.Remove("Note_" + cBar.Key);

                bOK = true;
            }

            m_bGenerateEvent = true;

            return bOK;
        }

        #endregion        

        #region Zoom-Move

        public void ZoomInWidth()
        {
            if (m_iUnitWidth == 400)
                return;

            m_iUnitWidth += 20;

            if (m_iUnitWidth > 400)
                m_iUnitWidth = 400;

            SetCellWidth(m_iUnitWidth);

            if (UEventZoomed != null)
                UEventZoomed(this, m_iUnitWidth);
        }        

        public void ZoomOutWidth()
        {
            if (m_iUnitWidth == 2)
                return;

            m_iUnitWidth -= 5;

            if (m_iUnitWidth < 2)
                m_iUnitWidth = 2;
            
            SetCellWidth(m_iUnitWidth);

            if (UEventZoomed != null)
                UEventZoomed(this, m_iUnitWidth);
        }        

        public void ZoomInHeight()
        {
            if (m_iUnitHeight == 50)
                return;

            m_iUnitHeight += 5;

            if (m_iUnitHeight > 50)
                m_iUnitHeight = 50;

            SetCellHeight(m_iUnitHeight);
        }


        public void ZoomOutHeight()
        {
            if (m_iUnitHeight == 2)
                return;

            m_iUnitHeight -= 2;

            if (m_iUnitHeight < 2)
                m_iUnitHeight = 2;

            SetCellHeight(m_iUnitHeight);
        }

        public void ZoomInOverviewHeight()
        {
            if (m_iOverviewHeight == 800)
                return;

            m_iOverviewHeight += 5;

            if (m_iOverviewHeight > 800)
                m_iOverviewHeight = 800;

            SetOverviewHeight(m_iOverviewHeight);
        }

        public void ZoomOutOverviewHeight()
        {
            if (m_iOverviewHeight == 20)
                return;

            m_iOverviewHeight -= 5;

            if (m_iOverviewHeight < 20)
                m_iOverviewHeight = 20;

            SetOverviewHeight(m_iOverviewHeight);
        }

        public void ItemUp()
        {
            int nScrollPos = exGant.get_ScrollPos(true);

            Dictionary<int, int> lstSelectItem = new Dictionary<int, int>();

            for (int i = 0; i < m_exItems.SelectCount; i++)
                lstSelectItem.Add(m_exItems.get_SelectedItem(i), m_exItems.get_ItemPosition(m_exItems.get_SelectedItem(i)));

            List<KeyValuePair<int, int>> list = lstSelectItem.ToList();
            list.Sort(CompareAscending);
            lstSelectItem = list.ToDictionary(p => p.Key, p => p.Value);

            foreach (KeyValuePair<int, int> who in lstSelectItem)
                m_exItems.set_ItemPosition(who.Key, who.Value - 1);

            exGant.set_ScrollPos(true, nScrollPos - 1);
        }


        public void ItemDown()
        {
            int nScrollPos = exGant.get_ScrollPos(true);

            Dictionary<int, int> lstSelectItem = new Dictionary<int, int>();

            for (int i = 0; i < m_exItems.SelectCount; i++)
                lstSelectItem.Add(m_exItems.get_SelectedItem(i), m_exItems.get_ItemPosition(m_exItems.get_SelectedItem(i)));

            List<KeyValuePair<int, int>> list = lstSelectItem.ToList();
            list.Sort(CompareDescending);
            lstSelectItem = list.ToDictionary(p => p.Key, p => p.Value);

            foreach (KeyValuePair<int, int> who in lstSelectItem)
                m_exItems.set_ItemPosition(who.Key, who.Value + 1);

            exGant.set_ScrollPos(true, nScrollPos + 1);
        }

        public List<string> GetGanttChartDisplayedItemKeyList()
        {
            Dictionary<int, string> displayKeyList = new Dictionary<int, string>();

            for (int i = 0; i < m_exItems.ItemCount; i++)
            {
                int iHandle = m_exItems[i];
                object oItem = m_exItems.get_ItemData(iHandle);
                if (oItem != null && oItem.GetType() == typeof(CGanttItem))
                {
                    if (!string.IsNullOrEmpty(((CGanttItem)oItem).Key)) displayKeyList.Add(m_exItems.get_ItemPosition(iHandle), ((CGanttItem)oItem).Key);
                }
            }

            return displayKeyList.OrderBy(x => x.Key).Select(x => x.Value).ToList();
        }

        #endregion

        #region Others

        public void Clear()
        {
            m_bGenerateEvent = false;

            DisableChartEvent();

            ClearChart();

            ClearTimeZone();

            EnableChartEvent();

            m_bGenerateEvent = true;
        }

        public void BeginUpdate()
        {
            if (m_bUpdating)
                return;

            m_bUpdating = true;
            DisableChartEvent();

            exGant.BeginUpdate();
        }

        public void EndUpdate()
        {
            if (!m_bUpdating)
                return;

            m_bUpdating = false;
            EnableChartEvent();

            exGant.EndUpdate();
        }

        #endregion

        #endregion


        #region Private Methods

        #region Initialize Chart

        protected void InitChartLayout()
        {
            DisableChartEvent();

            try
            {
                BeginUpdate();

                //exGant Configuration

                //exGant.BackColor = Color.White;
                //exGant.BackColorLevelHeader = Color.White;
                //exGant.BackColorAlternate = ColorTranslator.FromOle(0x7ffdf2f2);
                //exGant.BackColorHeader32 = 0x1000000;

                //exGant.FilterBarBackColor32 = 0x1000000;
                //exGant.SelBackColor32 = 0x1000000;
                //exGant.SelForeColor = Color.FromArgb(0, 0, 128);
                //exGant.Chart.BackColorLevelHeader32 = 16777216;

                //AddApearance();

                exGant.MarkSearchColumn = false;
                exGant.ShowFocusRect = false;
                exGant.HasLines = exontrol.EXG2ANTTLib.HierarchyLineEnum.exDotLine;
                exGant.Indent = 24;
                exGant.DefaultItemHeight = m_iUnitHeight;
                exGant.DrawGridLines = exontrol.EXG2ANTTLib.GridLinesEnum.exAllLines;
                exGant.SingleSel = false;
                exGant.LinesAtRoot = exontrol.EXG2ANTTLib.LinesAtRootEnum.exGroupLinesAtRoot;
                exGant.ColumnAutoResize = false;
                exGant.SelBackColor = m_cSelectItemColor;
                exGant.SelForeColor = Color.Black;

                // Gantt Chart Configuration

                m_exChart = exGant.Chart;

                m_exChart.SelBackColor32 = exGant.SelBackColor32;
                m_exChart.SelForeColor = exGant.SelForeColor;
                m_exChart.UnitWidth = m_iUnitWidth;
                m_exChart.DrawDateTicker = true;
				m_exChart.LevelCount = 2;
                m_exChart.DrawGridLines = exontrol.EXG2ANTTLib.GridLinesEnum.exAllLines;
                m_exChart.NonworkingDays = 0; // Non-Working Day                

                m_exChart.AllowInsideZoom = true;
                m_exChart.AllowResizeInsideZoom = true;
                m_exChart.InsideZoomOnDblClick = true;
                
                SetChartEditable(m_bEditable);

                //m_exChart.AllowSelectObjects = exontrol.EXG2ANTTLib.SelectObjectsEnum.exSelectLinksOnly;
                //m_exChart.AllowResizeInsideZoom = true;
                //m_exChart.AllowInsideZoom = true;


                //OverView Setting
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exSecond, "<%ss%>");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exMinute, "<%yy%>/<%mm%>/<%dd%> <%hh%>:<%nn%>");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exHour, "<%yy%>/<%mm%>/<%dd%> <%hh%>");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exDay, "<%yy%>/<%mm%>/<%dd%>");
                //m_exChart.DateTickerLabel = "<%mmm%> <%d%>";

                m_exChart.OverviewVisible = exontrol.EXG2ANTTLib.OverviewVisibleEnum.exOverviewShowAll;
                m_exChart.OverviewZoomUnit = 36;
                m_exChart.OverviewHeight = m_iOverviewHeight;
                m_exChart.AllowOverviewZoom = exontrol.EXG2ANTTLib.OverviewZoomEnum.exAlwaysZoom;
                //Hides the Month, Year
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exWeek, "");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exMonth, "");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exThirdMonth, "");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exQuarterYear, "");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exHalfYear, "");
                m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exYear, "");

				m_exChart.get_Level(0).Label = exontrol.EXG2ANTTLib.UnitEnum.exMinute;
				m_exChart.get_Level(1).Label = exontrol.EXG2ANTTLib.UnitEnum.exSecond;
				m_exChart.UnitScale = (exontrol.EXG2ANTTLib.UnitEnum)m_emGanttUnitScale;
				m_exChart.ResizeUnitScale = (exontrol.EXG2ANTTLib.UnitEnum)m_emGanttUnitScale;

                // Gantt Items Properties                
                m_exItems = exGant.Items;
                m_exItems.AllowCellValueToItemBar = false;


                //EnableUndoRedo(exGant);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                EndUpdate();
            }

            EnableChartEvent();
        }

        protected void InitChartBarTypeS()
        {
            // Gantt Bar Visual Properties
            exontrol.EXG2ANTTLib.Bars exBars = m_exChart.Bars;
            exBars.Clear();

			RegisterBarType(exBars, EMGanttBarType.BTask, Color.SteelBlue);
			RegisterBarType(exBars, EMGanttBarType.GTask, Color.YellowGreen);
			RegisterBarType(exBars, EMGanttBarType.RTask, Color.OrangeRed);
			RegisterBarType(exBars, EMGanttBarType.LGTask, Color.LightGray);
			RegisterBarType(exBars, EMGanttBarType.LBTask, Color.SkyBlue);

			RegisterBlankBarType(exBars, EMGanttBarType.BlankTask, Color.Black);
        }

		private void RegisterBarType(exontrol.EXG2ANTTLib.Bars exBars, EMGanttBarType emBarType, Color cColor)
		{
			exontrol.EXG2ANTTLib.Bar exBar;

			string sBarType = emBarType.ToString();
			exBars.Copy("Task", sBarType);
			exBar = exBars[sBarType];
			exBar.Height = m_iBarHeight;
			exBar.Pattern = (exontrol.EXG2ANTTLib.PatternEnum)((int)exontrol.EXG2ANTTLib.PatternEnum.exPatternBox + (int)exontrol.EXG2ANTTLib.PatternEnum.exPatternSolid);
			exBar.Color = cColor;

			sBarType = "Focused" + emBarType.ToString();
			exBars.Copy(emBarType.ToString(), sBarType);
			exBar = exBars[sBarType];
			exBar.StartShape = exontrol.EXG2ANTTLib.ShapeCornerEnum.exShapeIconSquare;
			exBar.StartColor = Color.Red;
			exBar.EndShape = exontrol.EXG2ANTTLib.ShapeCornerEnum.exShapeIconSquare;
			exBar.EndColor = Color.Red;

			sBarType = "Startless" + emBarType.ToString();
			exBars.Copy(emBarType.ToString(), sBarType);
			exBar = exBars[sBarType];
			exBar.StartShape = exontrol.EXG2ANTTLib.ShapeCornerEnum.exShapeIconRhombus;
			exBar.StartColor = Color.Black;

			sBarType = "Endless" + emBarType.ToString();
			exBars.Copy(emBarType.ToString(), sBarType);
			exBar = exBars[sBarType];
			exBar.EndShape = exontrol.EXG2ANTTLib.ShapeCornerEnum.exShapeIconRhombus;
			exBar.EndColor = Color.Black;
		}

		private void RegisterBlankBarType(exontrol.EXG2ANTTLib.Bars exBars, EMGanttBarType emBarType, Color cColor)
		{
			exontrol.EXG2ANTTLib.Bar exBar;

			string sBarType = emBarType.ToString();
			exBars.Copy("Task", sBarType);
			exBar = exBars[sBarType];
			exBar.Height = m_iBarHeight;
			exBar.Pattern = exontrol.EXG2ANTTLib.PatternEnum.exPatternBDiagonal;
			exBar.Color = cColor;
		}

        protected void AddApearance()
        {
            exontrol.EXG2ANTTLib.Appearance var_Appearance = exGant.VisualAppearance;
            var_Appearance.Add(64, "gBFLBCJwBAEHhEJAEGg4BagCg6AADACAxRDAMgBQKAAzQFAYZBuGgBIRGcZoJhUAIIRZGMIjFDcEwxC6NIpAWLoJDCH4mSTHYxAJIMWwzDiGZIgOL5BgyIIDShOEpSPKkNR7DMXdAzOAFBr/I4AKLfeJpcimG4nULIMbhDDQJwTIaPaKpCioWjYMg1CTXVgTMKoYTDBKybLlaqYapSQouXBMdLTVaYABlEa4ZamC5pSoSNZ9TiAGAwPatJQ0BarYRBW7aaouXIVUzdEK1BaFuKIQLVUB4XaVXwHLjHYRsKyrWqOaJmWRqGS4TAeMABNwAM4vHBsSwKO6FT5GVB0Hp2ZwzSLbKbkWodZgPMJDZoAG67dCuR6dU7SLRmaJaYxZEWBJsDkfJMm0EARAkKAaEwZxDimSJKDGD4QiGBAiG+JgzBSAYKCEPIdhQIAxBYBh0nYdInEEIAfnwf4flefJnBGQJnn4BoAGCCACAqAIgEOGBGAMTgxCAEA2AWUJJiENoFkCPJiBmQ4TkSLwjE8cpUhIPoLHIUJ7gkT5CmCFYKGKOIqCyC5imiRIVD4IgjlSMwkA6MokgkNhGFCYJVBCGwjhgSQEg6Yo0gsPQLCIQJ5C2CQ4jCfQuEkU58jsJZlCkUhThUZYJF4Wglk+KQwnULIInOMIsCKDZigiAgzkQBpJn8O5hnkIhKhMJJpEIWYVicSZOHOFxJQIDw6kqOYQiMIJMkCeAMEIZo5jYSYSmSWIon4LoJGmWhbiPY" +
        "JiHqGIIiMfIkCEJoJimfQ7gqYgwnILBIniBgjgkYhyFIMILGqCoeieDQJCiWIQDsCoyCyYgpEgUxQEGIJQDefJshGJpCDYbooiqSgikKEwsDITpFiIDxilCEQ8gsAg6HwIhOFKHIGo0agRn0OonlONItCMDwLDaHwjk8OoCG6OJkhuEIQjmJprH6HAjCeQgomgKhIgOBBEi4AAHn6WAizsMILi6SI7i6a4vHACB/AEIxwDqdprj8LxziSKgiG0SxYA+NoIkucwShGMQMFaW5FgiTBjBiPwvhILwdj8MJamWfQ8CmWx0g6QRwCyJwEkqMoMi8LpAnIQgwmgEpctGbQPk8S4KmWTpuHycpok+NAMnaZ4oA6MZEEIOoGlEAQJFKDghhAOA5kSIBKAeApgh0TxWlUdYICmIRAEAgI=");
            var_Appearance.Add(65, "gBFLBCJwBAEHhEJAEGg4BLICg6AADACAxRDAMgBQKAAzQFAYaQNBgABhGYZYJhUAIIRZGMIjFDcEwxC6NIpAWLoJDCH4mSTHYwgJIMWwzDiBZgkCA4fiGEInThCI4TTJ0aw0BCSJohEAoJb5P4DUZGM6ABJEBx3EqiJ5hEC4aBOQYzABUIAUTTdDwtCAZBpEWwLChANQwWLCNj2TSUByBDKqKCla46Yo2TJLDTIdxAA79ezpCyZJijeboZjeKaHU5Scg4IAADQTN4ALhrCqrdb+fJ+RTSdzUfAYYS1RapYRxaA6WgPEofZRfWS1fDdS5bNgALTsayIQyCbqiaDpUZaTi2V4zRC7ZyxKKsMh/EKjX7tXA5bD+OSZT7iNxrDQuDeEwtjIbAsDsDYVisaY7iuZAjnkLhHFoLYDkeQhKAaEwZlCahyDKDBjmyKoJAiG5zgyDYhCKCBPFMTiSBEYhRlAX5ZFgFgGAICojH4BoCmCSA0n+AggigOYYGWYJABSMw7EAAp8n+BYOlgSgegcIYYG4F4DhCGAsAULZPDiBgqgaABSmCc4HpwNgpgaIoznwBguA8SAuCUXxAFKbJ4syCIyD6A4jlifg0hGWRpCABgvA+Fp5AMLpPjAAI8D8AACnYVIUmUKReFSFYlhAAhQhUT5ZgIXYXCWCYWFuFolmkRQJC8T5SBSYQ5ggY4MmgIhOHOMIJDoDpSCyaw8AiI4om+HxnnmeoAiCaApnoeg8Ccc42HQOwnBOIhuDmJ" +
        "gkCYGghmcIgcmQOhIgOGJrCKJ4CCiaQ7imaoCh+KBqEqDomiiKgJmKGQ6mkY4mhQOgiioSJ/CIDhTiqNItimKouguLpnFqch2i8bAKnzERsEqVo3iwUA4GqJInGmWoeiWKgsnsRpOjMDpagaSIIEiY48nQIxOmOTpcjeLZbH6Yo4G4S4CmaOJuHuFpZD0LRynyfoQGSG5GnCPJkguUhJjuUA0AQgI=");
            var_Appearance.Add(66, "gBFLBCJwBAEHhEJAEGg4BBIDg6AADACAxRDAMgBQKAAzQFAYaQNBgABhGYZYJACCIDEYeSzRNCsOw8GSEZAgOJ4eiWJIkDDKADQTAoYBKFoZJTgQYJOjCJULIRkSZ0CgmOY3UBHMjwSBEEigNIxToOU4jFimCROQwQRK1BDwbQSFCEUDnaagABiHQYRBQMavfYlSr+fx/LLtF7Xdb5fD8Py+b5vY7TdTofR9XxfxLDaz4ep+HreR63WbNej1PI+LyPC7DZrhRp4MCdTBXLbdcTqPg8DovM5zTrudpzHrdNxXWapZDxOw4bx6S6TVrEeR0XAeJx2fbBZTdPC5DabSzjXLEazfGvBCyrXq+aZ3G6aJzWbZBbjaM7zbLuWzbFJoGwMZck0Zgrh2KpEHUdpdG0RgjiWJJCHMM5Xm4NoCm2RJPF0OJZkuFwbC0bphGSLRcAwdYbgWDIyDgDBSkWegrE2cwYiyAAKjMeJDCoTZjACJw3EuYoUlwLxKEMdI7CiTYSnSHw2EuMh4lgLoJlMYI4CaTYCliGQ1gsQhclcLIJGMWIxCUTRSkSEw1AsAhIlUK5InMUIuCMDQijCCg0gqIgclMKhIEMSIoCCTQCiCBQzkocgQk4KYIDMOIkB+TJigwfAzEoEZgkwKAHHMLIfB2DByG4YIY1OaB0DGSYBkiRgmAbGoWBtU5UGsMZJGGKJDCSJxiEwaQwgkIYgkIJBGFMCIQVWMg8GEMIImEfJBCMRZinCCwWGjEg9CKB" +
        "YCniCQVmkYRcj8IZFR+BgVGmYRUj4IJFBqDBRC8SAhECPAgEScpsgAE4LiGfBNC4R5hDKNATAuMZ8EuLhEjKaB+BKC4RnQSQuAeQQgjcHpEHKWB6BGLIhBkZRCFYZYVGgWoPnWMRuFwFwll0dxeFeNZ1H8YBYDYFYHGIWI2EGEBkhkRhZhgZoZkYeYgGiGhGhmKBqhqRo5jAbIbEaWY4G6G5HAWQRwlwVwdkkcsxkmUh1B0ZxhlodwdmeAJFHiHhHhmaB6h6R45nAfIfEeWZ4H6H5HnoAIAgweASAaAggigMgOgQIQoFIFoGCGKByB6CAiCiEgmgoIoojILoMCMKJSDaDgjiicg+hAJApBIRoSCSKQyE6FAlCkUhWhYJYpHIXoYnUCYWGeGhmjmNhvhwZw5lYd4eGeOZ2H+IBoDoFoHiIaI6DaD4kGkOhWheJhpjodofigamsiiKoqkqOowiyKx6l6HkLwVxrAFEKGILA1giibDMNkdAGgBEBA");
            var_Appearance.Add(1, "gBFLBCJwBAEHhEJAEGg4BRQDg6AADACAxRDAMgBQKAAzQFAYZhxBaERiGIZ4JhUAIIRZGMIgXBIEw1DCNIDAWCQCgkOAxSTAY4jFBgABiGwZZAHEBJBgmIIgRSEcazLLkUgBHyTZAGGgpAgePIXUbIEbUPQ9ASHBKnYIoWbpBiCOoZBROdKTbI0UQTFaWZbmGIZDjyII+VjAYSwTZcBxvI6WaaoSIaFjiH4aVbPdqTNTcMzlKC5YDGKpLXgOeZ5WiAFq3bDUWhkGoScayCTRVDDEYJZTldjQTJuET3RiNKanaS6CqEOA0XZGOogABVeQHRLQIp0Kr6GgTJg0YRqUI3TIGE5hWK3MArcBqQDDFgtDIBfC8OKIYxDHyzYR1XA2m+AQWjeQJ6GAAhBhSQhkDKHIFkYIxpkIQB2jKEIJj4eJIloEgok+YovgGCIxAKS4gGyK4Rj+D5Xmed5+H8YAHnIAh/mAOAGASAZgBAAZ7DwDgDEycQ4A0Q5ImINYPCODJYDyThIFyZQ2g8Q4UlsPQOGMcggDcTxDh4JIJiIWIQmaCoiCgeJzgaYYDGIFQ2SqIJfH6YInmScA3g0GA8lIPBOBMTJyDgTRYEiVw8mEaBglmC5NikMJzDmDY5D4UYUCSaJAmSEphGkGhDDUYxYl2eYOEiU5AlwM5jjMQM9E0GAyA5QpDkYE4FE0eJMnKBhnDMZh1h2ZxJGSYw1maYzVjUJopHYOB+k6YxwkwO5NlMOoIhmI5Jh4P4ECCc" +
        "xWECJIkEgSgUhuYQ6E6Gg4CkKBCg6DpNBoChfiEDYjCibg2mgcxwk2IgMmmFogiOIJ4DoDYsGCeY2jOLZNDofoNT2CoyiIIxmAONJZDITpqhaJwyk6cxuisNwoiMdhki8KpqDYaIZmaGxOjuIwrlsOJvjMLITDaP4wE2AwikKMQsGMaJLimaobC6TYzEyegim2NovAuPoKjcKoriKRQym2d5smwNZMGONJYDGb5rgqQ4xGoa4anaKgtjsLzlnCHAckyPZwEuDp5H4TpDFiRY+m+UxfACOBuDuDwEkecBsgaZ5IjIAwrB2MJwBwTINDsDRTBMFZFnEbBgm2RowByVwok2TIch8OZODMXBzBqRgyiOLJVDCcpMjiVpRjMDBenyTJwAyUp/j+MY9EcUJTDSTBjC+S5yimdxaiYJwTgocYemcDYHGCHojCmaxflmdgdHoRpKicKZTG6HYlHmVhKykfZSEuLod4GxfDhF6M4XIVAvgoGKNwB4ARgjvHkJcBoKg4gcBIKkYIcBYD2CqBQeQEQjglAmPITgjwVjJHkNwZ4MQNhQDeMwXYzxjDdACL8aK7QHhNGiPQfoLwojVHmKQNI6g6CcA688bAdguivDSNsewfRnhtG6HcDo3wyiVA8KcKIwxwD4D8BcRI4x8DeCeIsco+QPBnEqOYfAngAjWDiB4XwnxVjqD0N4Z4sR2j4B8OcWo6x+AeH+LUSoQQIAvGaPIfoEAbxAAAAgBBAQ==");
            var_Appearance.Add(1, "gBFLBCJwBAEHhEJAEGg4BUYDg6AADACAxRDAMgBQKAAzQFAYZByHCGAAGEZBXgmFgAQhFcZQSBcEgTDaMYzgMBYJAKCQ3DTJUBjGK8IwmHKQRxASQpUhoMoJTbAcgyDIUIxUACUJBGGgpBgeNYYUbIMbzVDaGpcbIAKaqCJpfoGCZDThRM7yFIIJw2CqPIRnSCaSpGT4XRCMQyiLZNVwiGoYLYhG4LSjWO4bV5AdJ0PKtKxTBKWJaGSYKXiSfI1TiAGI3PKsfROGqiKroWw4axQAAUWJCNgUZDVSzLKjHchhWqqJgmeaXZpqOaRPj1TwtNq6cSta47Rq/NalarmEB6PjeDxFPyfZYoKpRUxaFqWXrIO5bdDfiA3aRAYzjJRuEGJowkCd48j4ZYiHGM4GneQAXE2NpHEGK4lHWYB9j6ZhnFYCIEhQDQmDOIZUmQZYsECTpYGIEQ3nUGgNhCEIhqwG5UCAGBFkQBgZlwNhKmINgMgOIJYD4EoEGESBCBaBJhHgVgYgaYRQAIDw8A4AxMnEOANEOSJiDWDwjgyWA8k4SIsmUNoPEOFJbD0DhjHINA3E8Q4eDiDojhiYJmg+Ixokic4LmKQxiCkNk2CCX4DmGaA0nAN4NBiDJSDwTgTEycg4E0WIYlcPJiiiMJZhCTYpgCcw5g2OYOGWGQmCkEJkheYopGoVw1GSGQuA2ExIlOQJcDOZJzEDSJNBiAgiU4Q5GCeChNHkHJygsaBzGaCYimiCY0mMNZoCMW" +
        "hUDUJ5pkYTIDk6YxwkwO5NlMOoch6JQJm4U4JCIMxWFSKYlgiGgoiCYh6h6Lg4CoaISiKE5NBoWhziYDYjCibg2mmMxwk2JwMmmZo0iiIg4goIYxGIOgGkeMpNDqTohUkCwCjYIxnEONJZDITpqmaOwyk6cxuj8NwpmMdh4jQLAqgYfIemeW4ek+KAtBuCJvjgLZTDaU41E2AwilaNgt0AS4umuWx+mGOBMnocwBjuMBMA6Ho8Cua5ylkMpvDgPJsDWTBjjSWAxnEK5aleNhriuawKi8Lp7H8HpHHGXBskyQpxguXwNgMTpDFiRZDnEExfBSPRvHuXwYkycYslae5NjMQwrDGNZxFyHINDsDRTBMKZKnKLIwm2S4xF0Jw8lKTIcm9eA0hyQwuksM5jiyVQwnQDQIlaVo0EyLwQlGcRNCME5EjKfYXGSWEgjMQ5QnOahHG6KwoFOCoFiOaBNlcdIjiQNQOw5xejuF2JQWrURqBHAKEUJodAmC9GGM0PgRBfjEHiJwL4CRjjRByPQQ4MhkBcFeCkZY8g5g3BqDQOYnBiDRGWHMGIlg+geHooIJoHR6gdBeFMaY9QuhvCyCUKQ8A2DjGyMkLooRfjbDuB0V4dRtj3D6M8PI3x7AkDSOoOgnAPAfEWOIPA3gniRHKPgfwbxKjnDyJ4P4jRPgeFOFEYY6h9D+FuLEdo+wvDvFmO8fYnwDi9HgPsDwoRrBxA8L8H40x6B9C+G8bI9x9C/EON0eo/hPifG6J8I" +
        "YkBnj1H4P8SA1x+D+EAAEAJAQ==");
            var_Appearance.Add(2, "gBFLBCJwBAEHhEJAEGg4BVACg6AADACAxRDAMgBQKAAzQFAgaBhBgABjGEYoJhUAIIQLGETRKCMEw7DYBIziYBoJiGAw2DjEECyTBIYhmHCNBwASQoVhqNAIQjOEyTWAEIRNBQcYyGGYYagePIXUbOQAUVQ8dx/FChIyGOhZfjSGgOSJHdJ0bQ8IBkGoSa6sCMOYTDBKybLnSKqMgmWIDWzXETUfJkCBhOoAJamCCRTAWR42W5HWBXpj6CZQSzREI0NZcRTfLaBaywS48HoHCZ8VRfeAwHh9NYlSaEbCtIAKfyOaZkWZEFTTTjYAY7UCQMplK55Rp4MaWYzGdJUVh+YQHOjZdwiHZhZpWIpXaxkOq7dLuFzHZzTNRtDotRgzkmSBrjke5rnQDpSC0Gp3AAHZhiwa4EDmJpxiMYIYE+L4rFyH5PkKEISHGPJkG0MIbAuZAjimUJoG8G4FnEVBwAuBghjQcBGgqJAwEIExghQbA2EIQoGAwABWhCABhBYHQaiWSJvDsToznIHg9mIA5aCIPQiEORgmDuYrzCqCpikiNgrgoIwDjycIMmGM4sACDRhmOcggSuI5aCRLhjkYMILiRM4xzUM5CDWDZhkiZg7g8Y55AYQ4RGUSQeDKDQhkkMgdgeYgYg4JYJmKGRSEWFYkhkLg4hcI5JHoQIYA6eYKGOEZmFkZhng6JZYnoX4QiYGY6EaHAlgiWhzhOZopEoeYeiKeZyEqHIkuaUIdmUOgSgWDBnBmeoJh0J" +
        "oZloa4eCaWg6g+DApBkahOh0ZQZjKGommSCZ22eKAagqIw7iYSoaH+KAokoDoOisaB6EoW4lCiOheg2JorEmGoTiAKRqAqGYomuWgijeMAqBoYorisKBqnqR4sCuKpKgSMRrGofoVjIa46k6TYWEGF5NnUfZfhebZ9H+RBxjAeQcAaCAGAOARHASfYMgKWJEFYDxAmEFANm0AAvHgVQWD8HJLnafo/loAYsFEEgGjESwEkGMAsBMA5CHAIQfAwFBEHQVB2BaBJxl8FJEkSfBjBYFAxGwZwUE8CBRhAWAhDILIHVaRhRGGEwkgacYHCyS/PgKfgngeAYnAAaAQBAgI=");
            var_Appearance.Add(3, "gBFLBCJwBAEHhEJAEGg8GAkHQAAYAQGKIYBkAKBQAGaAoEDQMIMAAMYwjFBMKgBBCBYwiaJQRgmHYbAJGcTANBMQwGGwcYggWSYJDEMw4RoOACSFCsNRoBCEZwmSawAhCJoKDjGQwzDDUDx5C6jZyACiqHjuP4oUJGQx0LL8aQ0ByRI7pOjaHhAMg1CTXVgRAKoYTDBKybLnSKqMgmWIDWzXETUfJkCBhOoAJamCCRTAWR42W5HWBXpb6CZQSzREI0NZcRTfLaBaywS48HoHCZ8VRfeAwHh9NYlSaEbCtIAKfyOaZkWZEFTTTjYAY7UCQMplK55Rp4MaWYzGdJUVh+YQHOjZdwiHZhZpWIpXaxkOq7dLuFzHZzTNRtDotRgzkmSBrjke5rnQDpSC0Gp3AAHZhiwa4EDmJpxiMYIYE+L4rFyH5PkKMISgGSJKHMOYZEyBZyBGVJoHQG5GmEfBVBwAphggbQcBGIopAwEIElgKQbA2EIQiGAwABWJAgBgRYHEaKRyDuTpTiySgrEkchcF4DIIiEJAXgkYh4hoKIKmKKI2CmC5igIWBdAwTAyhyEYHA6MACDgJgFnCTJjDCSpDjyVwxA8AxgkYPANhkHlEA0YwImoLxJjkPhRhQJQpFYUA3gqcguDIDBj0gHYKA6cxQkEOZMBKFJoDECoDiSRAqGaIogmoMBKDOBIcBmZwplIc4dE4Eh4GoOIKBGPJtDCShJgIHYXg6OYCGKGQKFmKIpDqDBSiSawxEqA" +
        "4wkIKQOFIeBpiUaR6FqGA5goMZAmgKoHjORJMCwKAomYOIYA0WYMkIKYokoOJGCqDpTBiKQ7gwSgkiEGpOhqXo5i4KxziyKAdk6YpMggPRNFKdoliEKoKiqLIjE6So8m4MZKiOPJFCkTpCgwbI1G0exalgO4KkGbJyC6CQTmCWwxGweoeCYO5qhOHorisbJSiqT40G0OxinKNotGscpejgLgrhKZ4gm4YBemiMouksOpQjSLRLlKWZBm8ax+mGOJuFkfpnjobo7DMAo8DAXAenMGwwhuYwMj6ahsDqfpECyMomm2O5wEwXwXkYcOnn6Pwxmufpqkgcg8A6cZBjIex3AqPhwloFwPkAMQrjsMpFHIa5XDaRoyikdp9kuLo6jybGYkOOJIhATByiCbQpgcHRMHAOwKF0XIlBvjw0H2N5JCyYwcjIMJzAjVxKjPZosE6Yw0jUPBMnKWJyDOS1AjIIQ3GIBkbwWAIAnDiFwH4HgCihAcHkS4xBcjwDczkZgUA8CbCMEkbAZwLgHDyKYL4njGCCDyJp9I6A1gXMQHwJgHgijpBeNASQxxEh4CUB4IyvA9CZAKDkeQcAMiZGYHgDInE/ByD0BwIwqR1ByA0OcWIyA2AeHOCkWAfAOCGFiOwNQlw/A/EmOQPIRxciyDCB8Ew8RMB2A0CUcgRAMhoGgOwH4EBiBxfOBcPY3wGBdBaJgSItBdANB8G8VY7h+C/DeOsfwNwEDjDAPIHADQIAUASAMBwCR9gZAMRUV" +
        "gIAgDQEiAMHooABABFCGIFgPwHBkASIEKALBoAGFgKICQAwsBSEEBAJQBwggIA+AUMAcAjiDACEQEYkQoDsAsIIPAdxCAQD4CcYQSAiAUBCBQEohACDwCEIYIAsEiB0BaIUeAxAZCFEGCYEggw8BhEOBBFwhgEAUBOIMYAaRAiGEBPsgIA=");
            var_Appearance.Add(4, "gBFLBCJwBAEHhEJAEGg4BRICg6AADACAxRDAMgBQKAAzQFAgawXBIZRgGSCYUACCIDRbFMSBDBMOQ0ASNIpAaCZAgMNg5QwAECyRBIYhmHCMRwASQYUhmNAIQjOEyTWAEUxLBQcYxGGYYZgePIWUbOQAUVQ8dx/E6hIxGOhZfjSGQOSDHVJ0bQ8UhkGoSa6sCSRVDCYYJWTZc6RTRkEyxAa2a4iWj5MgQMJ1SpLdRALQ8bTdDrALiiSboJpCLZEQjRVpyDZ9NwHLTBLjwWgcHhCVJ9X7AeK1ViGIwTMS1AArfQbJqSZopVZOOYgBjePQ/SaUZTmGrhRxTC4aUpSWK6dAdaZjO6pNoHGpZBpfKqParvE64TYfGZJU60Og1eJHB8HYsmSbwvhAOxIjQa5aAAdwGjGHYwAAcxNmIRoBDCHxXE6OQ/h+BYhCQQxJkyQhiDYGRMgWcgRlSaB0BuRphHwVQcAKYYIG0HARhKKQMBCBJYCkGgNhCEIhogFYkCAGBFEcRohHIO5OlOLJ8geTx4gSdoIk8SIUnGCZOniJJugqYpIjYLoLCKGJEm8PAjEgcJrAAIxoHyfIISyDJ2glLwcnGDBinkFgugzNpQnCDYjggdg6g8I5pAIQoRCQaRWEiDJjFgdhNgeIgIgoJIJiKCIqFWEYlHkKhMg4ZZYnYX4QGYE4+GOGVSBoWoaCOOR6D+GAkDmChvhGZwZGYN4dCUCYuFOHonjiQh9hKZw5DoaYUGeCRSgWIYjCmS" +
        "h/iKJxZiod4bCeGY6g+JAjBoShbhOZxpEobYmmmSQmH6J5ojoCojik8wWieIAqBoNoEiOapqCKE4XCkWgyhiI4pjqVhniUKAaF6A4mioSp62cLAagqGYrCqWgej+MgrBqboziEbBql6IIliyKpyjSM4liAbZyH0HxnmGeh/B+aAAEcGwHhGQBogCIBIBgcBPliKAxgoRQhAQDgSECXpAAKeYFhEU5xkqP5wAUNJGCmCYcA8BZBDAbAnAiQpwHIZQUkKMJcEMEBPDELAzAYZBxFwOp/kWcAcHafxAEAgIA=");
            var_Appearance.Add(5, "gBFLBCJwBAEHhEJAEGg4BCgEg6AADACAxRDAMgBQKAAzQFAgZhlBgABjGAZIJhUAIIQLGETRKCMEw7DYBIziYBoJiGAw2DjEECyTBIYhmHCNBwASQoVhqNAIQjOEyTWAEIRNBQcYyGGYYagePIXUbOQAUVQ8dx/FChIyGOhZfjSGgOSJHdJ0bQ8IBkGoSa6sCIBVDCYYJWTZc6RVRkEyxAa2a4iaj5MgQMJ1ABLUwQSKYCyPGy3I6wK9MfQTKCWaIhGhrLiKb5bQLWWCXHg9A4TPiqL7wGA8PprEqTQjYVpABT+RzTMizIgqaacbADHagSBlMpXPKNPBjSzGYzpKisPzCA50bLuEQ7MLNKxFK7WMh1XbpdwuY7OaZqNodFpGDOSZIGuOR7mudAOlILQancAAdmGLBrgQOYmnGIxghgT4visXIfk+QowhIQY8mwZQ5BkTIFnIEZUmgdAbkaYR8FUHACmGCBtBwEYiikDAQgSWApBsDYQhCIYDAAFYkCAGBFgcRopHIO5OlOLJbC+CoCmQfwUksAY4DyCRiHiGgogqYoojYKYLmKApgH4FINEKXIhgcDowAIOIIgUM4slgMoPFOKJhhATgTlCaA3g8Q4YlsPJOEMZJvDUTAZD4UYUA8AxckQPINjMJJ0DeTJjjiVQwiMIRKDiDohliIJzDmTZjjyXw0g8E4AlIPANlMOJvDaDITjiVwxE6EwEiGHhnjmaJrDEChjjSSgrE8Aw8jYPdIFYKIYmOCIiEZR" +
        "QTHyUw8g4GhMl4M5PBMbJKDwTYDBibQwkoOh+iGKAOmMGIoDwDIyjycg0Esc5igmIphlmEJriOJB5jTcxOCMUJzDeTQDkyXQyk8MxokcPAMGKFpEjGLBTkSSQqg8Iw0jAPQNCKYJ5DmDRqkIOYjGIY8WjeaRDFCdA4k0U5QpyTxDHiTA9U+IJyDICh7i6bY7A8MwsisPQMnKSJ1DUC4TmiZg1m0apKCiNotkOBpejgLgrhKZo6C6K4ym6O4vBuTp1j2b4bm6fY2AOTACl2N5uBuDpljmbocC8Co8C8K5SnaPgviucgmiMJhbGaW5FnATBrAeRxxnuPInkMcgsEMJZEnKHBXCuQIxgwFwbkIMZsksNJDnITBLCeLBxExRxLHAbBzAmTIwkyBxEkQchgnMKIsnKLAHAORh0l0AwxlQcJsg8VJODWDJrFqTxOBMShbDNpJwkoPIMisMxxfoEoknMMwK6MKALI5htA2FaKQM4NhojAUeGYWI6g5gbBOKkZAaxPCnAyKYPQnAbghFEFsDwhhEhrF6G8TgtgQB7A0MUdwbxRjaHyMkdgdROBnFSM4NwnhzhRGAHsZA/Qwi0W0MYYI7A2AYB6JkQEKBzABHcGwTARxci2DEJ4cw6RHB9A6CYcwyQPL8HiKIPgngThZHoHkfIxxEjUiwOcI4qA5haDML8WY7BPhHCCLMcQGxDrOUUEYcImQYDqHgPwIYERiiREIF0ew/gIh0GGBoSgUwMA0HyL4V4ux5D9F+K8f" +
        "A3AIjDDAHkBwARQgBBAEQBgHAEj5EYEEQwMBFChAEAYQgiAMjtAABAJICwIhhHwHMEAxAMiDCMIAGohQICQA0MISgHxCAwDsA8YI6AkgHCEDwE4CgQgcEUIcMAtAJjDF4C8QowQfAZRuKEBgYRSAvBOIICgMgCiBASA8MI5AfCIACJQFgGQYgkA2MMBgRxEghF4DAIIkQeAeAGEwDYNACAEICA=");
            var_Appearance.Add(6, "gBFLBCJwBAEHhEJAEGg4BFQEg6AADACAxRDAMgBQKAAzAFBIYhvASCBjHCCYUACCIDRbFMSBDBMOQ1D6KQKhGDIDDkN4kAANMLwaLIZwyGQCJAhGKZAh4AIoTJHcQTPBMTQyGKMRwleZIfoSGgISLONJQHJEfQbDKXIRGKaKFgkDofTZVFJxVLYZBqEqua7nMZRQqCCZkWZOMY0RDVLyZLacaZkex5LgSLYvATSVpwSCFLQSCS4IpnO4pfoGQ56R6DcI2YAEbYDCrCKbhGoYDpPla3AAxsy2HYfBKwbRACrtCqiY5lTrIF5wHjYAYzTzPZ4kW44DiqQY7DCMIyUNCueRRRjWdhtfY5IzbE64bpWW63dweGwTYLhNB6Kx9I4piKChKDUewtHcP4FBSPJtGyIpRjeAhTmIGpKDcMYRk0L4VBQBZCEEMZ5EOf5qACeo/nIFIYB+SgGEkGxGBGHBlAuBghjQcBGEqJBAEIExghQaA2EIQoEHYEhGIOYQVB0GoVkCbw7E6MwwjsLJJkGZBqCORhxFoJIJiIWIeCqChikiIgugmSYxmAaQxEsQoyBsOpAAiXghBqDgzHSWA7k6M4gm0OoOGOMJmDgTojhCXw6E4Ixwl0NBMHkPhRhQJQjgSVQzE4YxwlUOAlHiRBpg2Y4YHIJ4G0SIJhDdQgAloOJNjMUJiDYTQTH4VwzkuUo8k8LwKmMOI7CsZ4ijCUwwgsUxskwMBOlOFJghiYZJgSa4iA6OQwl4OgjlOH" +
        "JfDYThTHSVVZiMSJVTecxQkMLRNCMAIyDSC5ikCVwxguEx8lEMYOnOHJiiMKIohycIHA6I4Ml9QZZCIPVGhMboSDYDZDDSQA2gyIpwleJwNGMCI0DcDIyniYw1EyM5EmkOQrAiXoyi0DhDgCbA5k4OQYmAOpOEMeJqDiDYzgCUgxg3YhBY6ApssPpY0kIOYNgMOJxaAaxWGKCRrDOLhJjaLZLHqYI4i4S4amiOoukuOpwjyLxLlqeI+iiO5yliQAtsOA44m4W4emmOpuluPI3jwbw7lad4+GIWYClaRIvmsZpbkUbZ7gcGJBjGPAnB6SAwlyDwQjWcocFMApLjAXBrAiR244WSQFGyGp7BWL5bn8K5OnATBnAeRwwiwfwMkiMJ8hbNR0gwTxLkWM5NDsMZQDULQLDaVYj5GSZKjAE4cmFoBTHya1ZkOBJTDIDZzDyQw2kyEp0lpfgLiSQ5NHUXQXFeKMTwMByjwDiB0Y4SRmjEE4IcOoIA7hIHOCkWgaE9CxEsG8TQBgUi6DMBgA4CWkicHMNEUQeQ4A6BsCIFYHgoDfAkHMOApwojiDsB0DoeRoB4C+AcJIvg1idAMOkUwcgNDmDqJ4MoHBugRGsHADYBxMjaDoOICI2RoROEOKkcgeBPDHFCOYPYHg/CBHMHcfIxw8jjBIJ0c4RwIg0E6LcB4ug4j4GOEEaQbwNgyHuE0B4RAIgUCuvgX4fxygWGWMYGIaArDMAeOgAAIxGpYHABoCAIgDAlACOgR" +
        "YoBcAIEGJAQICQfAHHgJkUIUgVARAaOEJQPwIBOAUEELALQCjICYBUBgYQWAhCCLgHYBwQD0BCIQCAcgFDBEwC8BI4QiAUEINAJgOwCigE8B0cIdAWgJHgMoDABQEBhAZNkEoIA4CmA8EIRAVg/AEEgG8BgMQDAhGICgRIEAhgAEkA0aIDgSjDFGO8B4YhCAqEOHAKAUwDjgG6BUMQvArCLAiG4FoRQ0CdAoGMAI9gQBkAIQEA=");
            var_Appearance.Add(7, "gBFLBCJwBAEHhEJAEGg4BBgEg6AADACAxRDAMgBQKAAzQFAgaBpBgABjGAZIJhUAIIQLGETRKCMEw7DKNZBgMBoJAKCQ5DbJUBjKK8IBiHIZYyGIBJCgmGoiR6AEpTLIUIR3FCNBhjIaJSjeIZGRqCEizZRkBx+G6gYymGCRSjuIoaA5IM41NRsQwgGQaRJrewYQDUMJiQjZVoTZDVFQ3LKnK5nSj5biyLowTIBNKWbBIIQTOAAAiuKJpeieUIJUJCNCVJRELYaB6EbaACacDhaT5RQjUcB1LbdfwTSCBZxyTJYJqOawAWBpdpWLY8ISvSLPc60HRIbrSaaHQKOErDCKmGwrRqdci0DZKLgOKJ1bhEO5jJTkNyxYrJdh4TQtFKSZVlUaxtD2HYslsYRxgGYA4H0O5Ui6TgtBoeQABaLw8GuEg3iacxikAeBPk+OQDH+fgAB+B5+FuIYCECRQxgwcgbkaQYwF8FYECGVB0B0BpxjgLgYgaUZBBoKoQkECBNgUEYwlkCQKBGaB1CABgRGGUYuFyDpzjSawygqUhchcF4DCIKBJAWYpokIL4MGMSJODaDIjgiRIWBcQwTAyJwkGIU4sACEBJgEfAzDiTAyjCbw1kw8BYDGDwDGYUITk8AxYkIOoLlIbhYhaJYZG4XoWE2Yo8guDpDBkBhDgmIwTjyVAwE4cwEiUOgMEKIJpDECoZkyKA6gwEoMmEJwGHmbh9h8J5jgSHgag4IoEG8O1GBIaYJiYc4uGmG" +
        "pmlKFhzCoTojBSKQ6kwUogmwMIKEOFIeBoaZqgKH4oE4YoMHAOgKiGbJxDMCwKC4QoQGaExWXiChqFaFwxgqI40kZdBjBKEgoEaM4mkCMIsBsAJrCoBxzjiMwiA8UxUj2K4olrjwtGkY4yjgO4MHKKJvDEShTjCIwbC2a4Cl+OBOmKMB7VWIhEngNpMFsQowguTp6uuLQrGsWIqjYLYrHKYY+m4Ox+mWOZuhuLptjwKJLjwF48G0O5WleNhtjsdp9jiMQLn6aI6i6S46GiPAvCuUpVkKb4cDsEI/AaTBLAGRRwEqPwXkGcYbFCKY9ziNwgkgMgsFMA5BnAXIfAiPJyiyMwMj6MJ8kKZpEnALBag6Rgwhwbp3k6cZsj6fpPnIPJOGaQYzHuUo4DtnYwm4MgkiMHIoDsShhkcXAcA6QoXGAKRG5SLQfG6AhLEGSRtBwYJCV4UosmwMoLBOOL/k8Ew8jYHkDI5RQjeCyk0fIBg7iWAIAkbgVwHjHECGgIYngyjxBcHwDYhgbCFAw/waIkg7AZGKMEbwaRLjnESKwMAngzC5EIHoDQxR8jkC+BMA4kQ9BLHqEQWI4gvASEOJEQQTmWhBCcHwTgBgzCFBEIYM4MRMBcE8IcCIqg9CcEMLkdgcgNgHFyMoNgHwDghFYHsDQpRvihHSHoHwmR3BsEwEcZIvAzKtESHkCohgtB8CaBQIoUQyBrA4MYf4PxqgbGYIYEgfwZhEAgAQAoAggDQCIBUAwDRhD4EcDYB" +
        "4IxADQEGNARIOwNjEBKAsIANAZCGGeKQBIQxyBYCoBwIAxgJDCAoA8QQMAhAJCCFgFIBAEBJH2IMKAbgHAfSkB0QQ0AngOHgIaR4+AlgIGEIQEYhBoCGAYMEbAXQDDICQJIBo4RDAZCGXYBoYRIBgAkEEXQGghjIC2AscQAQEgUGCPgG4RAcCLAiCIGgSREgRAgIQSAECAg");
            var_Appearance.Add(8, "gBFLBCJwBAEHhEJAEGg4BRYCg6AADACAxRDAMgBQKAAzAFBIchzASBRjGYYIJhUAIIQLGETRKCMEw7DaQIqAaCYMgMOQ3SUcUZ4iRiHIZYyGIBJBgmGohR6AEozLIEWxTE6NBhjIaJSjeIJGRqCEiTZRkBx+G6gYymGCRSjuR4JA5IE41NRsNxaGQaRJrewZNDUMJiQjZVoTZDVFQ3LKnK5nSj5JiuLYvVLAYxALRlWwSCCsIRCK4oWj6DZQQjQUI0JSlEQtRwHYRtYAJZwSFpPVDCN4gBSte4DAbIYDnHJcWgmY5rZxZFo2PYuWY9AbJdBAC4MUyWG50WjiEBjRa4YhpRyKcalHYdWxfB51boAAx7aKlOYfT6dI6hHYuFABiea5qnUFopGwVhTH6OJAnaHROC2cgHGoFoNDyMorD+Ig1kkG5THmURQDwJ5pjeBI/n8IAPkuf4NmAAAYDQDBTBiRwhjwbAbAWcRYEIHRHEGUBvBuAphggbQcBGIopBAEIElgWQbA2EIQiGUhohNFwYEWBxHHEcg7k6U4snyCpPHiNJ2guTxIkScYMk6eJUm6DZjgiZg6g4IxYnSbw8CQCIgmsAAkCjMYLTMPJ2gxNZMnGDxjjkRg6g+IxZACcIQiQSImEaEgkikMhOhQJQpgYVIPmQGImFmCoikiOgwgyIxIloYYUiYORaFiERmhkJhrhMZpTj4b4cCUSZKGaHQkHmKhLhsJJ5joe4UmeWYWEOIAlkmXhfiGKB4nKC" +
        "YVmeeRqHWFxoEmAoRiSI5pnqC4ligGZagOHgoFmaobicI5aHoZ4WmgKR6HmKZqgkVoKiqaR6DqL4sA6aZGjOIwqloZoQiaa4qFKH4aCoGhiiSJoqHsBhzigKJag6D4pisCwqhWMQslqOoli4K4aE6S41CuWwej+JBtCsDosiiLRrCKQI2iYaIOAKAQgGgIgKgMIJhjgXwRkaQZkHAGghBgTQpDeEIYGKfIGmGV5XAIRhiCQWIoHEX5MCcCpCl+R5jAyQ5wiwOwQkScQsE8D5FHEbAvBiRhwhwbwcH6EA0AQgI=");
            var_Appearance.Add(9, "gBFLBCJwBAEHhEJAEGg4BEwEg6AADACAxRDAMgBQKAAzAFBIchzASBRjGYYIJhUAIIQLGETRKCMEw7DaQIqAaCYMgMOQ3SUcUZ4iRiHIZYyGIBJBgmGohR6AEozLIEWxTE6NBhjIaJSjeIJGRqCEiTZRkBx+G6gYymGCRSjuR4JA5IE41NRsNxaGQaRJrewZNDUMJiQjZVoTZDVFQ3LKnK5nSj5JiuLYvVLAYxALRlWwSCCsIRCK4oWj6DZQQjQUI0JSlEQtRwHYRtYAJZwSFpPVDCN4gBSte4DAbIYDnHJcWgmY5rZxZFo2PYuWY9AbJdBAC4MUyWG50WjiEBjRa4YhpRyKcalHYdWxfB51boAAx7aKlOYfT6dI6hHYuFABiea5qnUFopGwVhTH6OJAnaHROC2cgHGoFoNDyMorD+Ig1kkG5THmURQDwJ5pjeBI/n8IAPkuf4NmAAAYDQDBTBiRwhjwbAbAWcRYEIHRHEGUBvBuAphggbQcBGIopBAEIElgWQbA2EIQiGUhohNFwYEWBxHHEcg7k6U4svaCoCmQfwUksAY4DyDBjDiSg0g2YxomYNYOmMQpgH4FINEKXIhgoDowAIRILgUM4slgMoPFOKJhhMTgTlCaA3g8Q4YlsPJOEMZJvDUTAZG4XYXA8AxckQPINjMJJ0DeTJjjiVQwiOYRKETJIYlCcw5k2Y48l8NIPBOAJSDwDZTDibw2gyE44lcMROhMBIhiEaB6BiawxAoY40koKxPAMP" +
        "I2D3ThWDSG5kEiUhSUsEx8lMPIOBofJeDOTwTGySg8E2AwYm0MJKDqLotitPAYigPAMjKPJyDQSxzmKFYlmKGZAmuJolDmZN4k4I1djeTQDkyXQyk8MxokcPAMGKFpQjSLQTkSSQqg8Iw0jAPQNCKYJ5DmDRqnIRYmGMI5U0qagDFCdA4k0U5QmANBPEMeJMD1VYgnIMgKHuXp5j4DwzCyKw9AycpInUNQLhPOo1m4Kp6DSOYugOBpqjsLprkKco9C8a5inqPovlufwBkCcBcB8CY5AOTAymm+Bbj6cY8m8XBfBaPwvmwAwCkEMBsCIMomCcG4WmeSJxAyGwTkoco7myJ5GHKbBzDGR5zFyBw3kOMhMEcJ5FDKLJ7ECRpzAwewzi8cgMgsSJOHELIjBWT4xgyNxQkccwgnMNIvnMbA3A+SR1h0Mw9lccYsj8YJRDYTQbGaUhOBMShnDNqZwkoPIMisMYfT/QShJHMGYCrTxQBZHQFoSwxRVBoFuDEYCmwzCxHUHMDYJxUjIDWJ4U4GRTB6E4DcQIogtgeEMX0YYcQOgWBwHsDQxR3CHFSNwPQKR2B1E4GcVIzg3CeHOFEYAexlB9GCLRcoxhgjsDYBgHo+RAQwHMAEdwbBMBHFyLYMQnhzDpEcH0DoJhzDhBIngeIog+CeBOFkegeR9hHESNSMA5wjjADmFscwvxljyE+EcIIsx0AbEONEaylgjDhEyDYdgcQuBbAuMcCI5A6j8H+JEag2ibASDeEQN" +
        "ACQBAgDIBAQQkAxAOAaMEPgIxDDAHkBwAYQgIhCDIu0CAlAYgFCgNoDoPhYBsEYKIEQLAVAOBQGMBIYQFSxCQEeY4RATiEDOOAfwQhsBdAWM8aIAwHDBDQCcQ4eA0gMGEHwHAhhghCA2EMTAaQFghEIEEQopASBJAMPAYYEQxA8CMIkCIFAYAJBAN0CI4g+BAEQFEBAhBFBgH4BsUQtAsCKHiGYFwRRcCuCEEgBBAQ=");
            var_Appearance.Add(10, "gBFLBCJwBAEHhEJAEGg4BVICg6AADACAxRDAMgBQKAAzQFAYZBmGiGAAGEaBUgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwiK55Sp8MaGYrHFK6Xp8L5jOzckp7MLOLw5TK4czzLbZeyKY6jaV4eQ6Aq3KplmMeYXkgHYoFoNZtmkLJ9miXwEHMTpjEWQQwh8VhGmUQIgAWIQkwCSJaGENkBkcU4hlCXhuBeRBBjwdwbgKYYIG0HARjKKQMBCBJYCkHANhCEIhg8ThQgAYQXLeBZIm8OxOjOcgeD2YgDloIg9CIQ5GCYO5igOOgqgqYpIjYK4KCMA48nCDJhjOLAAg0YZjnIIEpCOWgkSuY5GDCC4kTGMczDOQi5GGSJmDuDxjnkBhDhEZRJB4MoNCGSQyB2B5iBiDglgmYoZFIRYViSGQuDiFwjkkehAhgDp5goY4RmYWRmGeDolliehfhCJgZjoRocCWCJaHOE5mikSh5h6Ip5nISociSWYiFCHZlDoEoFgwZwZnqCYdCaGZaGuH" +
        "gmloOoPgwKQZGoTodGUGYyhqJpkgmdtlCgGoKiMO4mEqGh/igKJKA6DorGgehKFuJQojoXoNiaKxJhqE4gCkagKhmKJrloIo3jAKgaGKK4rCgap6keLAriqSoEjEaxqH6FYyGuOpOk2FhBjeSZ0H2H4HmmfB/gQcYwHkHAGggAgCgEIBhkEQBiiCsQWgQEA4EkAx7AAC5iBURZPkcMp+j+cCDmMEpECufBrBQRIMB8CZCBkAZcFoE5HGwPwRBOcJhEMDgTlOUgUGQFgxiEYIEkacZcH8HAZHIMRhBYJIGnGBwokqMoci8LgbkYAhIG6SozDyLwBk2UxUAQgIA=");
            var_Appearance.Add(11, "gBFLBCJwBAEHhEJAEGg4BAgEg6AADACAxRDAMgBQKAAzQFAgZhlBgABjGAZIJhUAIIQLGETRKCMEw7DYBIziYBoJiGAw2DjEECyTBIYhmHCNBwASQoVhqNAIQjOEyTWAEIRNBQcYyGGYYagePIXUbOQAUVQ8dx/FChIyGOhZfjSGgOSJHdJ0bQ8IBkGoSa6sCIBVDCYYJWTZc6RVRkEyxAa2a4iaj5MgQMJ1ABLUwQSKYCyPGy3I6wK9MfQTKCWaIhGhrLiKb5bQLWWCXHg9A4TPiqL7wGA8PprEqTQjYVpABT+RzTMizIgqaacbADHagSBlMpXPKNPBjSzGYzpKisPzCA50bLuEQ7MLNKxFK7WMh1XbpdwuY7OaZqNodFpGDOSZIGuOR7mudAOlILQancAAdmGLBrgQOYmnGIxghgT4visXIfk+QpwhKAZIkocw5hkTIFnIEZUmgdAbkaYR8EQG5HHGOAuBiBpRkEGgqhCQQIE2AwRjCWQJAoGAwAEWhCAGBBYHQaoXCOPJtDqTIijSFwlkWYJIgoEhBHiHgpgoIoojYLILmKOJGCoJYFlCRJDCmSQYHiawACOIhgF8DJODMDIsDuTRzBCcA2AwY5AlmEhkgOQJWDCDoinSG4UGUORKFSFZlCMeIvCKYxAkYOoPCGeIom8NQMBOHJBCkToDBCKA6EwQomGwKgOiMBIjDgSZBh4dIdicWZcmEJ4GiOCIhBuTpTAyJIYiGeYAmuGImEmGIlhsCoTiiR" +
        "QqE6MwUigOwMCKEJlWWGhehmJgpiOGIjBwDoCigew8EyQpCgSDpjimCJVhkTAihqDokAwYoom0MdwDiRIikoEYsmmLhrjqao5DqSoBlybgskiA5UlULxqHoGoqisKpqDybIsE6YwcioO5MFKFJsCiRpLF6WY2C2I44iwHpPCKaIRD4DYzBaSYqGKA4+isOZqlqPpPCqLQbE6VY2i8SxyliN4uAuCpkjmLoaBaaAFm6Kwym6NAtCsUpWj2LY8CaeI4G4O4WmeGBuhuLptjOMBLksB5CG8UYzAuPowmudookQMAMEqTQqG6e5HAaRhxhwbwNj8MALnsIJAG6TIPCWQRvDwIwpjecJLm8D4hnEHALBSPAzEwXwoj2c4MHMLIXm+fJCm3mRDBzQgMgkDJHV4UoYHGVRHAOMIllYShRjybgrEeW4EhKToxmsKwRUoAwUisOwMiKRJuDMSxTkSTwtg8Iw8jQHcSwRATDwCCJ0cogQBB3AqMMeI4AtAQHOJkPgSxPgGHCI0ToxQjiJFoGQTohg4hwUKGUfI4g1quEyK4MIHhDCxD8WEYgwRyBeEkP0DILA8CXEIKEcgYBJiHFSJAKYnwTgBEyJ0Y4wRMjMceCcUIxA1CeFOCEVwewOCGGCO4OQmwDjBGQGsDwxhUh3HIPkPwVxMB7E2CYCI8g3gZEOGEUQXgiCBEsJEB4xAYgcCWBcIwURDjBHiMYCQ6REx8HAOMcw+hfDvGWPYfwv0biOBsA8EYgBogBCAJAG" +
        "gEAcAnHYGQDgYwECqAkCANAUBAieGgAEAIkBggWA+IcGQBggDYA4AAAYGAlgICgDQGohTOAFDALwCwMgwjcBaAQeA7QDhgHwE8QYgQhAOAIPIPAIQhggCwIUAIYAhBCEwFcBYYQoBlEMCEMAihEggG8BgMItAcCGHgOYDwBh4DABIIMOgOBEAwHMAcYgUg0BACAQEA=");
            var_Appearance.Add(12, "gBFLBCJwBAEHhEJAEGg4BVwCg6AADACAxRDAMgBQKAAzAFBIchjASBRjGQYYJhUAIIRZGMIjFDcNQZDSEQKhGL4KDmEAAQTJUIjCKYcQwAAcAIkCCZPiACIJTbMcxyPIgbBzF4YZblaK5VhqRYZTiAFIzVLUex/FaXRjlcYpEiCLwORoEM4UZTkThkGoSa6sCRxVDCYYJWTZc5SfRcEyxAa2a4jGjpHimdYtVCBNKUOAFXgBLSBcAuKJZcgmPpAUJUd6RLblfSTQTBbjwaj4EpGU5VUZbWZYDBOIYjQiNbD0GygAqmZJmSbVVZwHb1fY9T6BbolMYMUjCXgxbTqVIaXbuYYlAafLp2SodXDnGIZVbvGBXdr0BzFUivdI0axGiIPQ0l4Uh1jyWItmoBxpBaDR7joWw3gIX41ByVw4nEYBMCeWY/jkSQkgEaBJDiXhyDaGBNgWcgRlSaB0BuRphHwRAbkccY4C4GIGlGuQqhEAQIE2AwRhCWQJAoGZYFUAxCAGBBYHQahYDOPJtDqT5IgSd4Ik8aIUnSCZPBiJJvgqTpojYLoLmMCI6CuDJOnOQg2geDowAIOIISyDJ3glLwcnSCkxk4MYRzaUgrg2DwImIOoHmOSJ6ECEIkEkGhIhWZIolYN4HmSeICCKCQiGiIgqgsJR5CIWYTCSaJuF+D5mBkDhjDuZhZhoSoaCWSYqD2GAkBmChFhkJwZCYc4WmOGZaFKGxlFmch9gyJ55DYdYUCaOROHqFYoHoI" +
        "g0h0KAaDId4bCeGY6HuHApBoSgziUJZZEYeIVCaeh2h6EpoAqBoNiEKhahiboZmqGgKiOI5oGoRowiKKRZHqF4jimKhCh2LZmhoWoDiYaBaHKJowCiOpqkOKQpjqOoviIbAbCqM4vGsWgekiLhqCoYpMi+KxrEIXAGl8R5ZngfofkeegABGRpBmQcAaCAKASAaAgHASEQHECYJrk0FoEhAOBRAMe4AAucgYEWD5HG8ArRIkYwSkQ4BrBQRIMC8DZDBmcZcFoE5HGwTwVBOcQhEMEgTlOIgUGQFgxmEYIEkecgcg8IAZHIcRhBUJIGnGBwskuMpcj8MgbkYAhIG6S4zHyPwFk6UgEAQgIA=");
            var_Appearance.Add(13, "gBFLBCJwBAEHhEJAEGg4BCgEg6AADACAxRDAMgBQKAAzQFAYZBwHCGAAGMaRTgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwACTJSp8MaGYrHFK6Xp8L5jOzcIi2YacXhzGZxZrmW6zdoVR5HUq0dLkOgLNxVkqRpym+EA7FCNBrlqUhZnuMY+AiZodkWC4CGEPocg2SoBEAC5CEkBpzjGFJkGUMgXkgRxTiGUJeG4F5EEGPB3BuAphggbQcBGMopAwEIElgKQcA2EIQiGDxOFCABhBct4Fkibw7E6Mxsj4KgLhGfBTCwBpgnIJIJiIWIeCqChikiIgugmS4BngUg1AscoGBsOpAAiXghBTKRgkoPROiOBhADgTxDiCXg9A4YxsnMOQNhOPJVDAZJpEITw8A0cwQnINpMhOUJfDODpjFSQoMEUKL2gcIhzt+N4OnMfJSDwTgDEicA3EyY48loMhOmMXJFDoTASgYeIeieE4skQKYOlMKItDwDJylidw5A1MRig2Yh5BSXg8E2cxMnIO" +
        "BpCMeNKk2MwonENgMGONJDCiaZqgKHw7gwYognAMpKnOSJRC2T4KCKCoHCYM4ug2EYmkMTJzDiDRDkyXw0A8Mx0ksPJNiMHJwDGChbA6RYxA8EwkioPIMlKQJ0DSC4DmSZg1iqeJigyCRPFOIJfiSTRDlCYw1UGAJRD0DZjDCdFNgOSJICmborjKaw8kyMosnQM5LCOVJUC4T4jhiV41GsGIelmNpOBsdpfjgbg7haZ46G6O42m2PAvCuUp2vIK5ylcDwvnscpejgLgrhKZo6DCLAmm+PBvDuVp3j4b44haC4ZC2CxrBaQJxhwGwckeLpih8DLZHyEwSkoMRMisAZFnATBrAeRxzByTwOkicQchqMJEnEXJvCyQRxjwIwxkKcgNA8EJJYiHoykocAMAsGJTDOfJDFCQxyC0Tw3lWc4dGcPA4E0KRok1ot4HJqo9kCcgyEqE5MkwKxPEMQIzk0dBdFcI8TgWwTgBYcJoY4qRmBsZwCEVwehOBmEyOptgZhEhsD0BoEorh5i9HkLgPI7A1gXFyLYRoawzgHFiNYOLOAci6D2n4AI7wRh1DMNEdwcy5ixFgGAewRgAwgEwAcXIsgwgeHMNkRQexNimByPQOgmxNgcDsHdowiR5B4E6GcaI5xzCeBOFEegdxOgeEyM0NIGh/DHFgH0DoBhniGDcB8I4WReB5A2IYMgwRVhDGiARgYxR4hvGyPcYoswCBoCiEwlw4h8i+FeLseQ/RfijDgI4DYAyQgNAQAEA" +
        "IIAiAMA4AoAIiggiGBQIsEIAgDCEEQBkdYAAIBJAUJEOI+A5DgGIBkQYQAAAxEILAQoBghhYCiAkCAhgIjCBGCADowhoBPAcNAUwFRCD4CgBQEIQFjiiAoDIAoiA0AWAICQGohh4DmA2AYLAegLAIFgh8cIhgQhECQIcCIYggBvAYAIJAN56CbAiGAbgUQTCkAIQEA=");
            var_Appearance.Add(14, "gBFLBCJwBAEHhEJAEGg4BAQCg6AADACAxRDAMgBQKAAzAFBIcBzASBRjHAaIJhUAIIQLGETRKCMEw7DaQIqAWCYMgMNQzSUcUZ4QACBQ3RoMACSDBMNRCGSEZwmSZJNimJ4aDDGQxxVA8dwvIydAApGhpUj6Q4JUDCNLwGKUUxDGyQKRpOjJAi0Mg1CTXVgSaKoYTDBKybLnOqIbpqXI7U5PUqVAKEYQSGCRbTpCabPhaPZoVLLVBUJZkLYLCq3L5kCjqAwOOZWSBhd6VJhVOxzMbLbSlKxrExyRqSZRoOSxLaNUTtCKWRhGEZNAoeO4tR7ociYBaVBZTVbIIzjIDpAzHMayABYWZVfjVU47TTSJphGTYVzyA6/bJGUZATAkhIbQwhmTIimMEY0mEGhVEQCBEl8BBsG0CQUEePQxhAABiCwdJmFuXZulcW5zmqd57j2PwvE+W5Hnqbx/k6aAGAKAJgEgCZ/gGTpzkICh8g6MACAwfRPkeXJ3H4TxnmydB/E8GAeAWBsbCGf7pggMgOHyYQIEoFIFiGCBqByCphmgJgLHyYg3lGdh+B+J5xn6AAijgcgtggIgoD4M4EmMWBeDcO5jhiageg8IwInoEYNCEWJaBmDgkFgdhHguYJZCoJoQGKp5RgGJQ4gYSYJCOeIeE6ColjkcgIhIJRZgIS4QCSWQKE+EQmFmGgHhoIwYhYTIKCQOZGHKB5lEmVhhhYJ4ZmiboOmeWRaHeGJlimFoEheJq3muGImmmE" +
        "hxiKY5ZioV4bGWGZCHqJQlnoOoXh4Jp6AqA4XGkWh6geJBohkbociMZxpjKIIkiiKoSDAQBAIC");
            var_Appearance.Add(15, "gBFLBCJwBAEHhEJAEGg4BGwCg6AADACAxRDAMgBQKAAzQFAgahnBgABjHAaIJhUAIIQLGETRKCMEw7DaQIqAWCQCgmDolQKNIzxBAobw0GACJBhGKpBDKCY2TJMUQSQAEHQ0GKNBjjKB5ZheRY4ABSFCzFLkfQTICEaCmebJBjSIJIUpScgRAKQahLLivIgGUYKfiaZIQVTRcz1VLNGhnJqVabGCToJDCI45VZGdYWZC0dxNKSCKBoO6YWwSFZ7XxIFrTfgVJyLQy1YDrHCYDqCZaSWDZWTzbY+HzVSTKIzta4KBiwMQ0ZBGNCxBD+QxJP7SKh0YZKUiCGgOSBrOq6cAGLZ9TSxM50KY4JqiCa4QLuerRVDQEwSJI2TBMcwojiRBtDgRoVFCQgRDeNQbBsQhFBGbweigMQWDocYrE6dxri2GZuGafAZn8JoHlGJZ2Gofgaj+L5fm2LZ+DWYADGIAg2GAQxqAYNpggeLJrAAIInjiTB8AyV5Ik8fQNAeWJSH4DRHnIGh/g0aAAleAINggEJZgGDYoCCW4CiCR4yA6BAhCgUgWgYIYnnIHIHiICIKCSCYiggNZvHwXw3lWdx+GMF6QomOAWAcNpNiiZgqg6TJIjYPoFmQCQGEOB5kFiDhHgmXpIiWbYOmEGJ2BWD5hhkBJVhSYxZBoJYCGWGJqA+DwhDkPilCYSRWDeGggjmKgsheIp5EYMYcGIGYaDiGhkjmLhdhsZZ5EIYYUh+eQSH2FYmHkYh1iAZ" +
        "x6BIeYhmeOgmFSIpnDoOhagqZpIjoYIYiYOhaGWIwnnoPhbiCJJqBYb4iCGWgqDaFZkiqHoRieKBqgIfIrmiWpGhyIJrEqLoVisaR6mKJYmmWSomhOLYqCmSowiAKwqHYboeiGOwmhiMpqGqbpGieZwLEqQodAABAEICA=");
            var_Appearance.Add(16, "gBFLBCJwBAEHhEJAEGg4BAQCg6AADACAxRDAMgBQKAAzAFBIcBzASBRjHAaIJhUAIIQLGETRKCMEw7DaQIqAWCYMgMNQzSUcUZ4QACBQ3RoMACSDBMNRCGSEZwmSZJNimJ4aDDGQxxVA8dwvIydAApGhpUj6Q4JUDCNLwGKUUxDGyQKRpOjJAi0Mg1CTXVgSaKoYTDBKybLnOqIbpqXI7U5PUqVAKEYQSGCRbTpCabPhaPZoVLLVBUJZkLYLCq3L5kCjqAwOOZWSBhd6VJhVOxzMbLbSlKxrExyRqSZRoOSxLaNUTtCKWRhGEZNAoeO4tR7ociYBaVBZTVbIIzjIDpAzHMayABYWZVfjVU47TTSJphGTYVzyA6/bJGUZATAkhIbQwhmTIimMEY0mEGhVEQCBEl8BBsG0CQUEePQxhAABiCwdJmFuXZulcW5zmqd57j2PwvE+W5Hnqbx/k6aAGAKAJgEgCZ/gGTpzkICh8g6MACAwfRPkeXJ3H4TxnmydB/E8GAeAWBsbCGf7pggMgOHyYQIEoFIFiGCBqByCphmgJgLHyYg3lGdh+B+J5xn6AAijgcgtggIgoD4M4EmMWBeDcO5jhiageg8IwInoEYNCEWJaBmDgkFgdhHguYJZCoJoQGKp5RgGJQ4gYSYJCOeIeE6ColjkcgIhIJRZgIS4QCSWQKE+EQmFmGgHhoIwYhYTIKCQOZGHKB5lEmVhhhYJ4ZmiboOmeWRaHeGJlimFoEheJq3muGImmmE" +
        "hxiKY5ZioV4bGWGZCHqJQlnoOoXh4Jp6AqA4XGkWh6geJBohkbociMZxpjKIIkiiKoSDAQBAIC");
            var_Appearance.Add(17, "gBFLBCJwBAEHhEJAEGg4BfsMQAAYAQGKIYBkAKBQAGaAoEDMMIMAANAwDNBMKgBBCBYwiaJQRgmHYbSBFQCwSAUEhqGaSYDGUZ4QgUN4aDABEgwTDUQhlBKbZjmOIJJACJ9GYyGOKoHjqF5GTiAFI0NKcex/BKgYRoOaJdiGNYgUjSdKSBCAZBqEqua7iAZRQqCJplRBVVITRTcdSdFCTJYqAYJPgkMIjTpVcZ1TZsLR5EypYIoKhLahbBYVXxfMgWfQGBypIzDbYgOqsKgOYZmZLYVj5RL1UYhNbJcpjOz6OrWAwzSyMIyZDDNDQhD7RJIwDRaCykNJVSBGQLSBqGYZiADLeBzOw8eyONIJWjCO5wHr2Yw1DQEYRJEzTBJOGUFwYg2JwIlKKgYEIJp3GMcRIBiIg9maVoGCKRxOE0bZem0dY/D4Lx/huW5qnSe48H8Lp/luO57n4f5gAeeZ7gCTpzkIBh7g6MACAgfBPkeTJ3H0TxnlydB+E8GAOAGBaJhGe4Bg8CAiAoe5gkgOgQgSIRIFoGIJmGKAWAce5hneQZyH0HxnmGeh/CIeBiCmBwhmgLgvgOYwYE4Mw7mMWJaBqDgikiagNgwIQYkoFYNCQGBmEOCpghkGgig8YhZDITYAiSeB2EWCAjjiDhKgmJR5GIBIRCUGRyEeDwkhiehLhAJgZgoA4ZCKWIGEiCQjnmNhugaZQJkYXYVCcWZYm6DZnhkShzheZRpgaAIWiYWI6GeF4mimAhtiGY" +
        "4ZhoU4aGUWYyHaJAljoKoTh0Jo5nof4WGkGhqgOIxoFkXsIGcKYihyI4oGqAgsEAQCAg==");
            var_Appearance.Add(18, "gBFLBCJwBAEHhEJAEGg4BOICg6AADACAxRDAMgBQKAAzQFAYZBwGqGAAGQYxXgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwACTJSp8MaGYrHFK6Xp8L5jOzckp7MLOLw5TK4czzLbZeyKY6jaV4eQ6Aq3KplmMeYXkgHYoFoNZtmkLJ9miXwEHMTpjEWQQwh8VhGmUQIgAWIQkwCSJaGENkBkcU4hlCXhuBeRJBhQZj+GGCBtBwEYyikDAQgSWApBwDYQhCIYPE4UIAGEFy3gWSJvDsTo4G4HYHCGaIGCCCJhniFgigmIhIhwAIJmKSImC6CgjAiNglAADwIlYNoNmOCJmDqDpjkiZgrDuZAJAYQoQmQSQWEaEZkDifhIhKZJJDYQQAA6aRGFKFJlEkVhWhWZYJFYUIWGWSR2F6FJljkfhihiZgJhIZtTBmHhqhYJoZi4boYCSaZGHKEQAAORh2h2Z4JmYeoemeSZ2HpNRKAaAogmgSgWgbKQKBQAA9iiSg2g6I5pAoRoSiSaSFneJ" +
        "ZpgoZoaiaaZKHaHomkAA5yiKKJqEqFomimaoKiaJgAAGN5JnQfYfgeaZ8H+BBxjAeQcAaCACAKAQgGGQRAGKIKxBaBAQDgSQDHsAALCIFRFk+RwxHIGpFBEIpOAABxhGgT2UCsSYvCERhBGAd41i2CxpHIJIGnGBIEjcbRbF6URXEmYZgGmOQGBscBYjobQLgkXenguHpeBaBQLlWPWbFubpqBGbQ7lKa40lAOxDAQTwQBAgI=");
            var_Appearance.Add(19, "gBFLBCJwBAEHhEJAEGg4BBgEg6AADACAxRDAMgBQKAAzQFAYZBoGSGAAGIZhYgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwACTJSp8MaGYrHFK6Xp8L5jOzckp7MLOLw5TK4czzLbZeyKY6jaV4eQ6Aq3KplmMeYXkgHYoFoNZtmkLJ9miXwEHMTpjEWQQwh8VhGmUQIgAWYQlAOEYUmYcwyhkC5kCOKZQmgbwbgWcQwGUGYHECOBiBsRwEGyKhDAQIQ2AsRwDGQJAoGOU4UCAGBFkcRohHIO5OlOLgcgeIZYH4IoIGISICCaCJiHiFgoAADBChyEQlkWYJIgoEhBHiTg1g0IxomYOIOmMeJ2DqDxJGEdAxDCYpgAIQQME6QxEjwPhOAMMJ4DcDBjmCWwxGUKRSFOFRlgkXhaDETxTFSPQ8EyQpAm0MJKEMeIvCKZBwAINg+E2YwwnUMgKHOTI+CWTwimiEodEkGZiHoLonhmch7CQTpikyCA6AqIZsmIKBGnOKI9CaYxpioNA9k2E" +
        "wInIMBJkOQI0CHZw0H0O4KkGbocieKZaH6IooGmU4sigHZOGKDBwDgSZhiqCojCMSg4BcPYNFKbJxC8CRDjiLgfg6QoUG8OwKDGMpAjCLAbA6RoxGwE4kiEGpOFIeBpYGQYei+IxjGqUI7DyC5SFibwsAgGp0HCMZsEuBpgjCbIrDKTo0C0KgulSDQtGsYIXDuSwiAybQpi2ewimKPYuAuFpNjObQbE6MY1GsU5Ij4JgvAIEpzBwbg7mMCgbC+K4en2OovniUJ4DkDRjlC3ZPCMPI0DuTByiCbwxEoXB/CGSAyCyFwkkhPAQiUOwMCKEJqDASgzkCygujAXJ3DkTYDkyVwwg8Ew8jYO4MgKMJuDGSotA8RZRDQbQnEiUQOlMGIpDqTBSiCaQxAqA5AlgMYzFOWJkDZ2hYkF3BSlSbHekOMJGCqNhtiMZ5aHaTYvGcOp2WyRQqHUMoknANh1sCFw9E4IYXI3g0iXHOqoLAnQtiOHOLkCoPAjgVGGnAJw5xdCdA0KYVovBfAxFiOgOIGhThhE4FwDoBgUhWDmJgIoNwgjRDoD0D4TRpD1A6CcIjpRTg/CwHcTQ5gSgbAwAYI4MRMBcE8CYaIkoeCmAuHgMA9x/AJFWOAPAfgLiJHGJ0cwpxAjlA4GYDIWRtElCiFoJYkwBD4DOB8fYERzizA+HsKIpxVAZH0EQXAAQKB8EiFcZoFB+gfBYEwAAAxHiTHQPsH4Dxpj4H+A0YQOBsA8EcAMIgAwAjAFgDgc" +
        "AUAGBSAaDEIgWQECQJ2EAZ4YAACBBQFgRYjxhxFEGFgKICQIA8AAAcMAtAJjDCwFIQQZheBCEMEAWAHRwC8AyIMMoyAkgGHgMIEIIB6AWEGBAJArhEjgHgBoMIKAwiDFC9EIIGAjBXm+GAQoEA+AtAKAgNgbwiAoDKIcSArARjBCQGsBYIBQmwBiBQTwEAIEBA=");
            var_Appearance.Add(20, "gBFLBCJwBAEHhEJAEGg4BKACg6AADACAxRDAMgBQKAAzQFAYZBwHCGAAGMaRTgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwACTJSp8MaGYrHFK6Xp8L5jOzcIi2YacXhzGZxZrmW6zdoVR5HUq0dLkOgLNxVkqRpym+EA7FCNBrlqUhZnuMY+AiZodkWC4CGEPocg2SoBEADBCEiBoThmBJEGwMoZAuZAjimUJoG8G4FnEMBlBmBxAjgYgbEcBBsioQwECENgLEcAxkCQKBjlOFAhnARYHEaIRyDuTpTi4HIHiGWB+CKCBiEiAgmgiYh4hYKAACKCI2CqC5ihiRgugmAADkINoNmOCJmDqDpjkidg6gsDp5AYQoQmQSQWEaEZkgkEhAhIZJJDYToQziOhShSZRJFYVoVmWCRmFaFBlikdhehfTByGCGJmEmBhlhnVYKGiGtXCobIbmYGQ+HKHJkFAAJxh2Z4JmYeoemeSZ2H6HpAAOUoCiCaBKBaBohmiCgmgYAAPGoNoOiOaQKEaE" +
        "okmkShEAAPZpgoZoaiaaZKHaHonmmQAAnyKJqEqFomimaoKiaKopokdZxHyXxXl2eR+l+V58EcGwHhGQBoomOAWAcHAUAYKgNGKERoEUA4ElAN4sACMohGQXJ8HKVwjBiJgmG0AAClJmR2naV42m0NhClyNgtDsZROjebhLHWAo5G4CxRi+OgtFsfpVEIbgklUASAg");
            var_Appearance.Add(21, "gBFLBCJwBAEHhEJAEGg4BCAEg6AADACAxRDAMgBQKAAzQFAYZBwHCGAAGMaRTgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41SELCZZcgOEYnQoOMZjDKUNwPHqMKQnOA6LoiPZASjQcZjHQ1ARrDYHJDnGjaOjWEQyDSJNb2DCIahhMSEbKtCbYbpyqamK5peCZJisMItQRMFRgLREbzfD7ALiiab7UoKLpFQjRdqSHaEdYDQSQcJqKCaUwmVojVhfcBzTLOIYHRKyNAtMALKqWZ4RVbCNK4bhuO49AaoLwACTJSp8MaGYrHFK6Xp8L5jOzcIi2YacXhzGZxZrmW6zdoVR5HUq0dLkOgLNxVkqRpym+EA7FCNBrlqUhZnuMY+AiZodkWC4CGEPocg2SoBEAC5CEkBpzjGFJkGUMgXkgRxTiGUJeG4F5EkGFBmB0AphggbQcBGMopAwEIElgKQcA2EIQiGDxOFCABhBct4Fkibw7E6OBuB2BwhmiBgggiYZ4hYIoJiISIcAANQLHKCI4B+BQikAbgPCMKJSDODRjgiXg6g2I5ImYPILkUKIwiEAAkAOSJcDMD4jiSXA+g4YxeEyE4klkPhShQZRJECVw+E4YxYngOQNFOXhcDuDRTAoiQjFOaJrDeDxzHSRw9g0Yp0nUNQLhmPhxhwJwplYdIdkuE5QlILk3kSNw8AycpYnQN5MmiVhkgyZITHCdw2kwWZInQNALDOU" +
        "JPCyKQqFKE4lGmChehMPIMlKQJwDKSpzjSSgrE8IxskmIYmFOIJZD2TYTAidQ0EsU5MkxfIzCyK4tGsepajiLpriqWJxDISojjiRgqA6MwQiYPANHMEoogyZYDFydg1kwCg8jNd4SiScgyAoexelmNgtisdpcjYDwDBiJQ7EwMoMmkMBKBOPJVDAbIwnKTQ9g2CxGjBd4iiqXo2m+C5elrKY7haZ46G6O42m8NgMWKUQti8S5al+PhwjuXp8jkLhriKao7CMOgcDwPoOnOGJ3DmuZUmENBPEMcJKD0DYzCMJJJjIXIfCqShyYUWgxk8ExgkZUxzBScw5A2G43BgOgPHOIJaD0TgzE6AwzceeJMlEdB9BsSJSnSLQYnMNxMjORJbDKDpzGiSQ9Ucbw6DwTosnSXnaEMXJ0DgTQjlCYJIDYfYbGiWp2i2KJzDeTVCl4M5PAMdJOD0DoDHsOg8k6M5cmoHADwpwYiyeiGYV4CRhhwF4D8CoxB4iGFSOYOIGhDiROcJ4E4ARSB6E6EcBwBHqhnFSM4NwngzgZFaMkOQJwHhLGmPQToTwmjSDkLwUIvg0idHMP8F4zBoDFGQP4FInRjDxFEHsDsJx1B0DgAcIIvxvj4D8BcRI4x8DeCSL8XgGxvBhHMHMTYxwsiwDKHYYQmAABtEuMUI4qwPh7EiN8XYHh9jRE+KsdgFQAAECePMYoPwmBRHqP0CIKAAAOB8C8TY6h9i/BeNsfQNwEDjDAPIHADSHgEECBAG" +
        "AcAUAGBSAYDAogWCEAQBoCQIAzisAAEAYgKgijHHCMsFwQRWAoEIIgEgAABiwC0AkcIrAUhBDGF5IoIAsAOHgGoBwQRxDkBIIMPAYQICQEMAwYIuAVBXCIPAPADQYCgBgMIAAsQFhgFICYFYsJxBCFwEQCwghCA5BuKICgMhhj4C4BEcAvAcCFHgFwQIwQkCQCeAgBBAQ==");
            var_Appearance.Add(22, "gBFLBCJwBAEHhEJAEGg4BJoEg6AADACAxRDAMgBQKAAzQFAYZhsGCGAAGKDoJhUAIIQLGETRKCMEw7DaQIqAaCQCgkOQzSTAYzwXBIYhwGyNBwASQYJhqIYfAACEyTXCMUgBE6NBhjKB4JoSO42SBPU5TXRgAR9ICWaDoObpBhoD4gThSdKzJCIZBqEqua7iEZRQqCCZkWZRciSBS8By1LakZKlCCZLhGLowQiMYC0ZREBgdDzALgiWbbSoGUpFXzFWI3fAcfRxQSLKbGPBsIoWVIgVZCOKABLGH4hBKwbRiKwrHqWY6mXxad7QTZuOY/DbJJ6lOg7WDWRo0YjWU7ZXp8BwiGYbRhnYYRUzSLa2ZbGeY2dgIAZ5XrQeh0XQViIIwVh8RopFqTJWnYKx7gGWgFiMXp4AOQx4gGDh4GMGhvCYLAJgSApuDAN5/lAAZ0H+ZB1EAlYkhwbwcgaUYEGwF5FEGIB1BsRggjgYgbEcBBoioQwECENgPEaQxkCQKBzFOBAgBgRYHEcWRwDuTpTi4IIIiIGIOK+YoIhIKoJmKOMOAADBilCLQmkeAYkg8GZFGiXg5g4I4onYPIPmOOQGD6EBjEGJJFC0CpAAIRQ6E2YxknMOxOhOSJrDmDwZE4VYVCUaRmFiFplHORJpDkDpzhyYg7E4U4AmANRMlkFAAg6JJziCaw4A2A4cloNBOGMYJOh0Zx5loeIemeKZ0k4OJNFMLJfDQTBjGyTAwWAcJVg6Jo4mCbw6A4M" +
        "4aHMOBNCMHJeDODAzHiTQwimKhyhuJxqAofobDcDIyniVwxguExMkILROBmIoMg6DpThCXogAyIx02uDYjBiOA2EwUpejyL4rlqfpCjAa5TFjgYNCKeIwDOC4yjCXVpnqPg4DuDhjgCZA1kyYx8lAMRNjMJI9DaDICm6YI4i4G4OmaORuBMXo9DSDACkqTArGyexGDiIxFGoPJiDoDZTZyNYoCMPoZXWGhfAGQAwCwFwEkBiYojwNQMDKVJPC8CprkaUgVg8E4omRRpzFyZQ2g0A4ElMMgOAMSJGkgcg8gsJJJnIbIIlwMxMAMVo9DOS5Sj8Eo8mOI5UnIO5PAkTpUDgTozgyXA6g4IxvECUI0B1JBRHQE4cl8NgODMaJSDeZoDiSYg3DEM5YnN1gTjCaA7ikA4smUN5OjqSxhDeNg9hcYpZk2Y4kmENpOFMdJVDiDYTEcFg3nUU5MnGVh1jkfJsDmJwE4ZRVi/A4BwA4BRfjwEOAEagcRNi6CiLKBwZhTD8Dg/YUw7FJBHDiNIOYbwzgfBmM0Tg/Brg7GcHMY4GRqByE4DQQIuw1CbC4KEZoiRzDHEeCwOYSgzgWBaMMDiWQ2jZHuB0V4cIHD6EiLxcIJhwjeDqJ0CgYQcA8EaEcIIwA3BmHOGkcYEBPAeEOKQOo+gfCnFOOofYEQ7gpGIBsDwOBqAAAyIUbIZx3hID+CwQI8wkBfB4HEd4fASiYACBYPwHhqBbHyP4H4pAhFRCeOsf5Ew4AsAcBgQ" +
        "QOA2BBCQDAT4BhRGYDADICgQhiAkHuJAGY4gjBAAEBsEQpwKDXE+HgFoBRwDEAyD4WAagHBBGmOwPoAwMBLAQEcbwEBhA4CCAgUIJAUCDDgJ4CYDx8BLAUGENgLxChjH4DUQoEBIB9GGFgKQhhzjSA0MMXAaJUg5HuIMcY/AdiFFAJ4Po4gWBHB8IEbQIwiCIE2AwYgKAyALAON4FAxQZjpAqGIUAZRFDHHAPsRIIBvAYDEOwL4jAYiAH0AkEA3QMgiHCPQCYwRuA0E+HGLAYw6BwEaFEZQNBgjYHaAUUQHA7iOHAAAQAgCAg==");
            var_Appearance.Add(23, "gBFLBCJwBAEHhEJAEGg4BIwEg6AADACAxRDAMgBQKAAzQFAYZhwGqGAAGEZRZgmFgAQhAcYxPCwIwTDyOJBicBoJAKCQ5DLJUBjPBcEhiHAbIzHABJCgmG4iSELCZZchGKgAShGYwxXA8EyLHibZBnea5co0AI/UDLVCUJL8RQ2B6QZxpSjpVhEMg1CTXVgRCKoYTDBKybLpCRZBpiA5bVxSUjyTBMWQjF6YYRGMBaNomAwOR7gNwxNL1ZyFKajL6ifCsAgOP45YLFdQDHg+EyNKqQarhHDQAjnEKRQjYVpABT+RzTMizIhqazLfgmbqdaBHGRzfJlCTuGqjZpxKq5fxzMYDRCMYzjDL4YhpWyXNwzCLMaq/iDfN70Lo7IxTlWUZFiecY6F6Ow3j+CxfCAdoRGiV5CACcZeGAY4eCiRodkuC4CGEII7hQDZ/nYAB9h+eQtGaQgGFAHIGFGTBzBkRhBHwVAaAcUY0GIC4GCGNBwEaSokDAQgTGEFBwDYQhCgcPQ5EIAYEFwdBqhcE48m0OpiCiEgjgkYoIh4KoJiKSImC2CpimAAJECmSQSFwXgMgiIQkBeDhjjiag8g+Y5pAYPYQmQCQMhYFxDBMDg0AAJBwkSbA0EuQ5kmAMwPgMcJGD4DYzBYWIWiWGRuF6FxmAMFJ1DUS5TkSTAsA6UwMiQN4KnILhNAAI9Kl4MwPFMIInDyS5iFycgugkKZshGH4oAKah/iCKASESbgskiA4gioHpOCKBBvDqC" +
        "5SG4PIcCOI5clkMIPCMBIcDwCxCBybgrEeU44iwHpqCqEojikaoKh6Iw6kqAZcmYKJHAOBIeBqKQKEoOolAEc5YlULpPBKcIUDuCphnibApEac4wiMGwsGsIpHjIbJLC6Rw6EoEYsmUJ4GhPd4ZmsWhODyLoLjOSI9CWDpykCAYwkcCw2kqOZuGsJpQjSLRLFqWIkG2KJqlyN4JHOPIyCCTpShqZYz6AcpmjqbQ7FaV42GsexujsPILmIYp2CEL4RkaaY/jEAYzACOxwDuQwFg6D4DhCVg9A0Yp8nIM5LEOPJHCoDpzBSJZJHIfIbCiSpyiyGJuDEChTjCQgpA7dwjDwDRjAqcQFk8c4UlgPJNHMCJxcpPZICsDpjByKpSHSPQrEyU50m0KJtDGCoTiyRXMhMEIoDwDYDBsOw9g4QxgnENYMBOOJNC0TpDByLA7AwYorGyW42l2PxylwdpTi9LYMFKE4WQVBPAGGcL0RYghzipGQGsTo5hMh+DsBkIoiRqi7HeDsYIUxjhyA4G8Eox4LjZGiK0NYmx8AvC4B4Q4ERVQRGKMEaAYhKhnByIQKYdBuhHCeNQeonQvhdGqHUAwCQlBzHsEcPIrgxBSDiLAMgcwMiFGSOINoGUsiqDCHgIwDxFjjE0L4G4kxyB5C8Gkbwag8DeECMYMIlTrAADKBUUguQYAvEMHIF4vQQh7HkCcYIHQ9hhE+LAJYgAIh3GqBgPokQ/jdHqMUiQJhCC/HgAwA4AhgDwCQMRv" +
        "okAyAcCeMMKIGQhBwAKAsEIggJB8CQBkeYIwgABAcJEMYjg2BPGYBEQQUAnAKA+HgFYBRwDBHwD4YIjASiEBGPMA4IB6AbEGLAPwERghoW+EcfgIBCCQFEBUIQYR/AaGEIgJAP3GgpCGCMdoDAQi0BeAoEIHB+DBFCP4DowhoBPB+DEAQIQPhgHaBAMQHAkCFGEBQGQBRBjzAmCIOI9hFJjBkMUCY9A/BEEgG8BgMQxAtCKMgWwfZthuEWPELg+wEjgHcBoJ4yBPAPAiKIGQxhcDTA2KEOgGBHBQHsDkY4Ux3BACAQE");
            var_Appearance.Add(24, "gBFLBCJwBAEHhEJAEGg4BKYCg6AADACAxRDAMgBQKAAzQFAYZhwGqGAAGIaBYgmFgAQhAcYxPCwIwTDyOJBicBoJAKCQ5DLJUBjPBcEhiHAbIzHABJCgmG4iSELCZZchGKgAShGYwxXA8EyLHibZBnea5co0AI/UDLVCUJL8RQ2B6QZxpSjpVhEMg1CTXVgRCKoYTDBKybLpCRZBpiA5bVxSUjyTBMWQjF6YYRGMBaNomAwOR7gNwxNL1ZyFKajL6ifCsAgOP45YLFdQDHg+EyNKqQarhHDQAjnEKRQjYVpRFYdUTNMjTb5tS74Jq7HagRxkc7yZQlbhrI6acSrOb8czCA4RDKNYwzeKIaZrFzbcwjTKrPwIAK9b5oXWcDpTBGCxPmMdI9G4bx9BaPhAm0IrVAAAZijyQJHDwQYNDuFQXASQhBHcKAbn+agAnqP5yFqMCsBIRAaEcMYEGIGwGFGEBfBUBoBlQbQYgKYYIG0HARjKKQMBCBJYEko4QhCIZOE4UIAGEFwdB0dZEm8OxOjiDglgkIhoiYKIKmIeI2CqC4ikiPAADwIxIlYNoNmOCJmDqDqlACb4PmQCQGEKEJkEkFhGhCY5pB4SoSmSSQEAAO4lAkRhShSZRJFYVoV0qPhYhaZZJHYUoWiWaYGGKF5mDmFhihgJhpiYV4aCaKY2F+ExnAmRhIDwZxJlYdodmeCZmHqHpnoWdIfmgCgGgKIJoEoFoGiCQADlqCoimiSg2g6I5pAoRoOAAD" +
        "x6FbURpgoZoaiaaZKGQAA/CoCoGiKKJqEqFtZGoSJ6DGKpjAqNgviuapIhgAAFWSAgCgEIBoCICgYgQcYyA2A5TnGKQZgULAoF4GRCF8BANnIRoAAgeQWHGuRilKNJtEsVZ2jWLYLGWd42G2SxOluNxuAsfpgjcLgrg6WI5G4axWmiOhtmuMpajuLh7kKVgABAECAg");
            var_Appearance.Add(25, "gBFLBCJwBAEHhEJAEGg4BJAEg6AADACAxRDAMgBQKAAzQFAYZhkGCGAAGIZxRgmFgAQhAcYxPCwIwTDyOJBicBoJAKCQ5DLJUBjPBcEhiHAbIzHABJCgmG4iSELCZZchGKgAShGYwxXA8EyLHibZBnea5co0AI/UDLVCUJL8RQ2B6QZxpSjpVhEMg1CTXVgRCKoYTDBKybLpCRZBpiA5bVxSUjyTBMWQjF6YYRGMBaNomAwOR7gNwxNL1ZyFKajL6ifCsAgOP45YLFdQDHg+EyNKqQarhHDQAjnEKRQjYVpRFYdUTNMjTb5tS74Jq7HagRxkc7yZQlbhrI6acSrOb8czCA4RDLFE7jCKmaxdW7MI4zKz8CADPa+aJ0OjaHYmCMFofkaaR6lyXp6C0fIBloRYjF6eADkMeYBg4eBxFobwmC4CYEgKbhQDef5QAGdB/mSNR6ngGQgl4dgZEcIYUGQF5FEGIB1BsRggjgYgbEcBBsioQwECENiagMZAkCgcxThQIAYEWRxHFkcQ7k6U4uCCCIiBiDgmgkYoIhIKoJmKOImCwAANEKXIiC4B5hEiMAbgOSJeDmDgjiidg8g+Y45AYPoQGMQRKDEKBAAkFJyDcDJDmiaQ3A+I4YleFBlDkShUhWZRpGYVQ1k+E4YlYPgOEMVJ3hgTpjFSQoREACJonoOpNmOXJdDGTxjFiPQ9E0QpmHSHYnFmXh6h4Z5CmSdA0gvOxRC2TwDDyNg9A2cw6DqGhjgkOJcD2T" +
        "YzBYdw9A0ApMnQM5LCoXoZiYKYqHaHImA8Iw0jAPAMjKPJtDKCpTkiWwyGiOYomgNhPHMZJCWAEpUnMM2AkySwqmuKpyjuLxsAqfo7DwTISiibgxgqA4skQKYPAMXJEitbx0lcPYNHMAoUCyTwjCSKQ8gyAoelyN4tlsfpijgbZTkCRgpE6UwMiMOhMBKBJvDUTAbEAPI0g8YxilaLWdCiKo4m4C52nyN5uGuIpqjsLprkKctsAMBJ0DQSxrmae45C+bBCnyQBuhuLptjubwYmKDAPUoPJmD2ThjGCdQ4E0E5QlwMoPEMbJIkoco8isLJLnKbIonMNoMHORJYDGDpjFyRQ8k4QxmnKRxOgOXJoDaDxTgyU4ieAUJeDMNItDMS5THUDQ/EsPJNlMLJxDaTIjjyWgyE8Q4YluT5PBOKxCDf3wQlcPQOBMSJ0DgMhdjMa5bHcDY/G96BzECcg3gyc5Al0GcDwhwgi9e+GcLI7g6gcAOKkZjChDgZFWMQeIfArgZGOPEbgiRVOzCMKEcjlQziJGA1wU4URhiDfAFkdQcxNinEyMYNYch+CxGGNUOonQnhdGqska4Mg3iaDOHkX4zg5jUCyHIH4igzhxF4GgTwxwsjGD0J0DgKRoBvHwJ4I4jxyD5E8F8Tgbx3imHuKJ2Y5h4jWDYBkLo2BTAAA2GUeIUR2hID+AwQI8QkBfA4HEdoexShAACBYPokQ7jdAsP4D4bCrgCDQEsfQ/xgAwA4AsAYjAhA4GwIIS" +
        "AYQfgNCIGUBAwAaAoEKIgJI7wQBnGII0AABAbBFEcCkWAPh4BOAUEELALA+hgF4BkQYRxsD6AMDASwEBHi8A8IQCAdk4gYCWAYEIJARgfHgIoCYQhUBZAUAcfAawFAhBAPsQwsBSgNAeKQGQhwIDEBQIQOY7wDzeDuAsIIPB9zuEQH1BgQxECxBUBgBAUBkAWAeLwJwigDjSBSEUCAywKDPGCPcCSLQYDFFQLkC4oh0j0oqLqi4kx0AnEGLgNIPhxB4B4EYVAzwNhjC4HAQwEA1A6CGPgdYHRnipACQEA==");
            var_Appearance.Add(26, "gBFLBCJwBAEHhEJAEGg4BNYCg6AADACAxRDAMgBQKAAzQFAgaBrBgABjHEY4JhUAIIQLGETRKCMEw7DYBIziYBoJiGAw2DjEECyTBIYhmHCNBwASQoVhqNIfAACEyTXAcIRNBQcYyGGYYagePIXUbOUB0VQ8eR/FChIyGOhZfjSGgOSJOFKUbKkIBkGoSa6sCIBVDCYYJWTZc6RVTcEyxJauKahGSJKDCLIES7UQC0PK1XQ9P64Ypna46Bi2RIJUZachWfLOAYDEDCKhhGo8IpWIpXX5Ac4TRh+BYRMbPbSACybEqaEJWQjTGKYZjmOwHJ67QAlOYaeDHBaKRrTGpadC2YTrW6IdpHHJobxicKaZjvE66DYWRZJNDTJCnexmieE4MmUXpgHal5XjOI4zHcIxcAGTQ3gkFgEkIfQZAuDJ+H4F4EhODZnCMaYElgXwhB0ToHEMeY4j4UgaEYcYgHQC4GCGNBwEaCokDAQgTGCFBsDYQhCgYOQ4EIAYEFgdBplcE48m0OphigcgbgcYgIH4IoHiISIGCWCJiGAAgmgqYoIjYJ4LmKSIQAAPAjEiVg2g2Y4ImYOoOzuKJvg+ZAJAYQoQmQSQWEaEIjmkHhKhKZJJIOO4lAkRhShSZRJFYVoV0wPhYhaZZJHYUoWiWaYGGKF5mDmFhihgJhpiYV4aCaKY2F+ExnOAQwAA8GZWHaHZngmZh6h6Z5JmQAA9CgCgGgKIJoEoFoGiGaBAACdoimiSg2g7RQKEaE" +
        "ojkAA5e1KaYKGaGommmSh2hoAAPkqBoiiiahKhbWpqgqFAAAcHwHkmdB9h+B5pnwEZGkGZBwBoH5oAIAoBCAZJ9gmApYqYDxAmEFANmoAAsHgUQWD8HIklCEgbkYGw1BWM5GBIFBkBYLQrFKVgWAccRoE8bwtEIEpXB2LZhiwUQSBiexqmOORuHGDBLBCFZLDwYI4i2QRoFCOYugYBOVi0UYWnWN5amubp9jYLJbFGDxAEAgI=");
            var_Appearance.Add(27, "gBFLBCJwBAEHhEJAEGg4BBAEg6AADACAxRDAMgBQKAAzQFAgaBrBgABjHEY4JhUhyBYwiaJQRgmHYbAJGcTANBMQwGGwcYggWSYJDEMw4RoOACSFCsNRpD4AAQmSa4DhCJoKDjGQwzDDUDx5C6jZygOiqHjyP4oUJGQx0LL8aQ0ByRJwpSjZUhAMg1CTXVgRAKoYTDBKybLnSKqbgmWJLVxTUIyRJQYRZAiXaiAWh5Wq6Hp/XDFM7XHQMWyJBKjLTkKz5ZwDAYgYRUMI1HhFKxFK6/IDnCaMPwLCJjZ7aQAWTYlTQhKyEaYxTDMcx2A5PXaAEpzDTwY4LRSNaY1LToWzCda3RDtI45NDeMThTTMd4nXQbCyLJJoaZIU72ZonhODJlF6YB2pcV4ziOMx3CMXABk0N4JBYBJCH0GQLgyfh+BeBIUA4RhThmTJKGQL4Qg6JxDiGPJcF8EwGFGGB0AuBghjQcBGgqJAwEIExghQbA2EIQoGDkOBCAGBBYHQaZXBOPJtDqYYoHIG4HGICB+CKB4iEiBglgiYhgACRApkkEhcF4DIIiEJAXgwYw4koNINmMaJmDWDpjgibIWBcQwTA4LAACOcJEmwNBLkOZJgDMD4DHCRg+A2MwWFCFIlBkThWhUZYDBSdQ1EuU5EkwLAOlMDIkDeCpyC4RQACNRZeDMDxTCCJw8kuYhcnILoJCmTIRh2J4Cmod4eieEhEm4LJIgOIIqB6TgigQbw6guUhuDSGgjCOXJZDCD" +
        "wjASHA8AsQgcm4KxHlOOIsB6aYqHKG4nGoCh+hsOpKgGXJmCiRwDgSHgaiiCgqDKIwBHOWJVC6TwSnCFA7gqYZ4mwKRGnOMIjBsK5rAKP4wGwSwOj8OhKBGLJlCeBoT3KGZqloLg0iyC4zkiPQlg6cpAgGLpHAsFpCjebZrAaSIyiySw6lCIhtCiSpUjWCRzjyMggk6Uoal2MYuAuUpejibI7DaT40GqexOjMsBiGKbghC8EZGmGPYwgGMp4jkb47iKfYMg+A4QlYPQNGKfJyDOSxDjyRwqA6cwUiWRxxnwewgkicgsHibgxAoU4wkIKQO3IIw8A0YwKmkBZPHOFJYDyTRzAicXFGOOJICsDpjByKpQHQPQLESUZ0G0CJtDGCoTiyRXHhMEIoDwDaeDMPYOEMYJxDWDATjiTQtE6QwciwOwMGKKxklmNhdh9mR2FOLxlDqDBSicUQqE8AxnFaQ5BHOKkZAaxOjmEyH4OwGQiiJGqLcdwOxAhTGGHEDgL2KwNEyNEVIahNi7G+BoDwhwIiqgOMUYI0AxCVDODkQgUw5jdAOD8aA9BOgfCaNEOgBgEhKDmPUI4eRXBiCiHEOAZA5gZEKMkcQbQMpPFUGEO4RgHh7G+JoXo9xBjgDwF4FI3g1B3G8EEYwYRKidEgAAMoFRSC5BgC8QwcR3itA6HoeLDAMh6DCJ8UASxAARBuMUCgfBIg/GaPEYhEgdD4B8E8UY7B+A/CeOAbjcxBjIHADQBY4hIDSBmI0C" +
        "AHCsAJHyIkIIZgSCKFAPIAwhAkAZHUAACAKQFARDCPgOQiRQCSAaOEQwCAIhYBIBgIgKAyALAgFYBYwRICwA6MIaATwbiQC4EIIIoB2gICGFgKICQDA+AcMINAUQFCDAwEsBARQ5TaAQEsA8zAoCFBgKwYAiQQDdAMAMFgOBCBGF0B8IgCAbgEBALkR4IAQEBA=");
            var_Appearance.Add(28, "gBFLBCJwBAEHhEJAEGg4BRwCg6AADACAxRDAMgBQKAAzQFAgaBrBgABjHEY4JhUAIIQLGETRKCMEw7DYBIziYBoJiGAw2DjEECyTBIYhmHCNBwASQoVhqNIfAACEyTXAcIRNBQcYyGGYYagePIXUbOUB0VQ8eR/FChIyGOhZfjSGgOSJOFKUbKkIBkGoSa6sCIBVDCYYJWTZc6RVTcEyxJauKahGSJKDCLIES7UQC0PK1XQ9P64Ypna46Bi2RIJUZachWfLOAYDEDCKhhGo8IpWIpXX5Ac4TRh+BYRMbPbSACybEqaEJWQjTGKYZjmOwHJ67QAlOYaeDHBaKRrTGpadC2YTrW6IdpHHJobxicKaZjvE66DYWRZJNDTJCnexmieE4MmUXpgHal5XjOI4zHcIxcAGTQ3gkFgEkIfQZAuDJ+H4GoEhEDQnDMCYIlgZQyBeSBHFOIZQl4bgSAWcRIGkGZGgGUAuBiBpRkEGgqhCQQIE2AwRjCWQJAoGJkmECAGBEYZRicXBOnONJrgcYZ4HoIIImIKIWCGCZiEiIgmgoQADkILoLmMCJGDKDJjEiVgyAADp4mYOoOmOSJ2D6D5kAidg4hAZBJBYRoOzQOhKhKZJJDYToTmUCRGE6EhlCkVhWhXR5SFiFplkkZhdhfURqGCGJlBmChkhmZYZB4aoamQI5GG6G5nOAcocmcSZWHIAAPEmZh6h6Z5JnYfofmgCZ0AAPYoEoFoGiGaIKCaCoimihZ3iOaQKEaE" +
        "okmkShWhaJM0HKGommmSh2h6J5qAqBoeg4Io6hYKopmLdgmggAAHigAARkaQZkHAGggHgJQ/gQAAIDqOBFGEJAOBQcgsAUIgYEUYYmjqKoqCqOwmkjfhYlqTozm0CJCEOGwtEkHpTjUbYJAIZoaCaCxulyGQtmsfhgjgbgpHUPAxgoYhlgGNwuHuJpojqFB7jEO47m8S4lDuNhjiuNIZj0b47lkFodjACY+nqPwvkQJoBkGZ4sA6bpCm8BBWgyQ5oFwKp9kMUY6F8FokDEJQ2iK8I7mmAYxnICIYAAQBAICA==");
            var_Appearance.Add(29, "gBFLBCJwBAEHhEJAEGg4BCIEg6AADACAxRDAMgBQKAAzQFAYZhgGCGAAGMYRXgmFgAQhAcYxPCwIwTDyOACjSJwGgmIoDDYOMQwLJUEhiGYcIzHABJDhaG41AhCM4zLLgAQjE6FBxjMYZShuB49RhSE5gBRdER5ICUaDjMY6GoCNYbA5IcgUZR1EQiGQaRJrewYRDUMJiQjZVoTbDdGwTLKBbarWJ6Qi2BAwXYAErzDBIZgLJCbbbjfA7ThaP4JVDLVCwTQ9WRHOCuIDrPBbUwiQqKXzVOAYFAeIS3SbKIRsOywAqDJJqWTZcQ1PLWOABTzQZByaS7YjKXwxZbjUaUXReIZjAa6do3GItXDmVojVhrORadr8fYZMjndL1KxPE8ZQamUZB1nyTZ9n4BxqBaDR7iADp4lYN5DByU44nGQBMCeWZWi6UAoAGCBJCCXh2DKHIMiYQp5Aiah0B0BpxjgXwUgaEYcGgHQCmGCBtBwEYyikDAQgSWA5BwDYQhCIYEAAFY0CGcxFgcRotHMO5OlOLgggiIgYg4JoJGKCISCqCZijiJgsAADRClyIguAeYRIjAG4DkiXg5g4I4onYPIPmOOQGD6EBjEESgxCgQAJBScg3AyQ5omkNwPiOGJXhQZQ5EoVIVmUaRmFUNZPhOGJWD4DhDFSd4YE6YxUkKERAAiaJ6DqTZjlyXQxk8YzJj0TRCmYdIdicWZeHqHhnkKZJ0DSC88FELZPAMPI2D0DZzDoOoaGOCQ4lwP" +
        "ZNjMFh3D0DQCkydAzksKhehmJgpiodociYDwjDSMA8AyMo8m0MoKlOSJbDIaI5iiaA2E8cxkkJYISlScwzYETJLCqa4qnKO4vGwCp+jsPBMhKKJuDGCoDiyRApg8AxckSK1vnSVw9g0cwChQLJPCMJIpDyDICh6XI3i2Wx+mKOBtlOQKxk6UwMiMOhMBKBJvDUTAbEAPI0g8YxilaLWdiiKo4m4C52nyN5uGuIpqjsLprkKctsgMBJ0DQSxrmae45C+bBCnyQBuhuLptjubwYmKDAPUsPJmD2ThjGCdQ4E0E5QlwMoPEMbJIkoco8isLJLnKbIonMNoMHORJYDGDpjFyRQ8k4QxmnKRxOgOXJoDaDxTgyU4ieAUJeDMNItDMS5THUDQ/EsPJNlMLJxDaTIjjyWgyE8Q4YluT5PBOKxCDf3wQlcPQOBMSJ0DgMhdjMa5bHcDY/G96BzECcg3gyc5Al0GcDwhwgi9e+GcLI7g6gcAOKkZjCxDgZFWMQeIfArgZGOPEbgiRVOzCMKEcjlQziJGA1wU4URhiDfAFkdQcxNinEyMY+g/BYjDGqHUToTwujVWUNcGQbxNBnDyL8ZwcxqBZDkD8RQZw4i8DQJ4Y4WRjB6E6BwFI0A3j4E8EcR45B8ieC+JwN47xTD3FE7Mcw8RrBsAyF0bApgAAbDKPEKI7QkB/AYIEeISAvgcDiO0PYpQgABAsH0SIdxugWH8B8NgVAAADFeKMdg/AfhPHGP0AADRhA4GwB4I" +
        "YgA0BADQBUAYoBKAWCgAwNRFRSBZAUBAGgLAgDPDgAAQQKA0CLEeMMTQTQiCQDeAwGAXBFhBEgMJJgIAsCDEgHoCABRADuAsIKIIgxhASAgIcNAUANDCEQEgGQkBJAWGEPgMQGBhEDBWLAMgMAhDICZNEQhIwjAUCSAYdAPgMhhH4CkGwMQLAjGECgF4BxGChACQEA=");
            var_Appearance.Add(30, "gBFLBCJwBAEHhEJAEGg4BYkMQAAYAQGKIYBkAKBQAGaAoDDIMQ1QwAAyDAK0EwsACEIDjGJ4WBGCYeRxIMTgLBIBQSGocZKgMZxRhEMQxDbGYxgJIUEw3ESQAAiGZZBhGKgAShGYwxWKENwPHiMKQGKCaLoiSI/UDCNBwTQtGR/ESbZBpUAKbo6IoRDINIi2BYUIhqGCxZLtCa5BpmHI5WxXUT1BJMExZFyYJikSbLOAADofYBcUTTdI4cyFIijL5ia7bfhzDaCRxdGD1JQ1LzbQK/MwxfIMDoyZaeWjAdj6DQFVyRRjMJxzSRcFj+LJES4NFR3ZRVGZXObWbq2MABQzEMaWRxiWzQbq+OwbT7jdI0OxtGxGNo9ZpxPLxVAkBMCQkhszBzCiOJEG0OBGlUUJCBEN5FByCpAkUGoeHgYguHSOJTh2bpXF+S5pnOep+D6f4vjec5zn0fpfmAAJwgCYBIBYBoBmCCAmAqAZAAOPgOgOYQIEYEoEmESBWBKAxhGgZgagaYSFm6B5iAiBi9mISIWCaCJhmiHgqgqYpIgYKYLGMCJGC6DIjOYL4NGOCIaDeDhjkiOgcg+ZAIFycYQmQSQWEaEZkgkJhKhHH5SE6E5lAkRhShSZRJFYUgAA8aRmFqFplkkdheheZgJHQAA9mYSYWGaGZmgmJhqhqZqFnyG5nAmRhyhyZxJlYdocmCWACHof5nkeeh+h6XxQAEASAg==");
            var_Appearance.Add(31, "gBFLBCJwBAEHhEJAEGg4BekMQAAYAQGKIYBkAKBQAGaAoDDIOAwQwAAxjCK0EwsACEIDjGJ4WBGCYeRxIMTgLBIBQSGocZKgMZxRhEMQxDbGYxgJIUEw3ESQAAiGZZBhGKgAShGYwxWKENwPHiMKQGKCaLoiSI/UDCNBwTQtGR/ESbZBpUAKbo6IoRDINIi2BYUIhqGCxZLtCa5BpmHI5WxXUT1BJMExZFyYJikSbLOAADofYBcUTTdI4cyFIijL5ia7bfhzDaCRxdGD1JQ1LzbQK/MwxfIMDoyZaeWjAdj6DQFVyRRjMJxzSRcFj+LJES4NFR3ZRVGZXObWbq2MAIQpLMqWRxiWzQbq+OwbT7jdI0OxtGxGNo9ZpxPLxVAkBMCQkhszBzCiOJEG0OBGlUUJCBEN5FByCpAkUGoeHgYguHSOJTh2bpXF+S5pnOep+D6f4vjec5zn0fpfmAAZ+gCiYVn+AZgEecAADaYJIDYDg2k2KA+BKBJhEgVgOAADYoGYGoGmGSB2B6B5iAgdAADYYhIhYJoJmKCImCqCpioWWILmMCJGDKDJjEiVg2gyjZeDqDpjkidg+g+ZAJAYPgAA0aQWEaEZkgkJhKhKZJJCQAA1GUCRGFKFJlEkVhWhXSw+FiFplkkdhShaJZpgYYoXk0SYWGaGZmgmJhqhqZpJ0cNInAmRhyhyZxJlYdodmcQAAlCHpnkmdh+h+aAKAaAofo2PoGiGaIKCaCoimiSg2goAAMloRoSiSa" +
        "QzDKFNSAoZoaDMjYyh6J5qAqBoiiiahKhaIgABAECAgA==");
            var_Appearance.Add(32, "gBFLBCJwBAEHhEJAEGg4BY0MQAAYAQGKIYBkAKBQAGaAoDDIOAwQwAAxjCK0EwsACEIDjGJ4WBGCYeRxIMTgLBIBQSGocZKgMZxRhEMQxDbGYxgJIUEw3ESQAAiGZZBhGKgAShGYwxWKENwPHiMKQGKCaLoiSI/UDCNBwTQtGR/ESbZBpUAKbo6IoRDINIi2BYUIhqGCxZLtCa5BpmHI5WxXUT1BJMExZFyYJikSbLOAADofYBcUTTdI4cyFIijL5ia7bfhzDaCRxdGD1JQ1LzbQK/MwxfIMDoyZaeWjAdj6DQFVyRRjMJxzSRcFj+LJES4NFR3ZRVGZXObWbq2MAIQpLMqWRxiWzQbq+OwbT7jdI0OxtGxGNo9ZpxPLxVAkBMCQkhszBzCiOJEG0OBGlUUJCBEN5FByCpAkUGoeHgYguHSOJTh2bpXF+S5pnOep+D6f4vjec5zn0fpfmAAZ+gCiYVn+AZgEecAADwIJIDYDoDmECBGBKBMhgib4FmGCBmBqBphkgdgegaIRoH4vZiEgYAADuvYmCqCpikiNgugvMYeDCDJjEiVgqgyIxomYOoNmOOJ2DqDgjmkBgvhAJApBYN4JGSCQmBsAAPBkNhOhOZQJEYUoUmUSREAAPQlgkZhahaZZJHYXoXmWQAAnaGJmEmFhmhmZoJiYaoZkAA5eG6G5nAmRhyhyZxJlYcgAA+SZmHqHpnkmdh+h+aAJnQABAEAgIA==");
            var_Appearance.Add(33, "gBFLBCJwBAEHhEJAEGg4BY0MQAAYAQGKIYBkAKBQAGaAoDDIOAwQwAAxjCK0EwsACEIDjGJ4WBGCYeRxIMTgLBIBQSGocZKgMZxRhEMQxDbGYxgJIUEw3ESQAAiGZZBhGKgAShGYwxWKENwPHiMKQGKCaLoiSI/UDCNBwTQtGR/ESbZBpUAKbo6IoRDINIi2BYUIhqGCxZLtCa5BpmHI5WxXUT1BJMExZFyYJikSbLOAADofYBcUTTdI4cyFIijL5ia7bfhzDaCRxdGD1JQ1LzbQK/MwxfIMDoyZaeWjAdj6DQFVyRRjMJxzSRcFj+LJES4NFR3ZRVGZXObWbq2MAIQpLMqWRxiWzQbq+OwbT7jdI0OxtGxGNo9ZpxPLxVAkBMCQkhszBzCiOJEG0OBGlUUJCBEN5FByCpAkUGoeHgYguHSOJTh2bpXF+S5pnOep+D6f4vjec5zn0fpfmAAZ+gCiYVn+AZgEecAADwIJIDYDoDmECBGBKBMhgib4FmGCBmBqBphkgdgegaIRoH4vZiEgYAADuvYmCqCpikiNgugvMYeDCDJjEiVgqgyIxomYOoNmOOJ2DqDgjmkBgvhAJApBYN4JGSCQmBsAAPBkNhOhOZQJEYUoUmUSREAAPQlgkZhahaZZJHYXoXmWQAAnaGJmEmFhmhmZoJiYaoZkAA5eG6G5nAmRhyhyZxJlYcgAA+SZmHqHpnkmdh+h+aAJnQABAEAgIA==");
        }

        protected void DecorateBar(int iHandle, string sBarKey, EMGanttBarType emBarType, EMGanttEdgeType emEdgeType, EMGanttEdgeShapeType emCornerType, int iOffSet, string sToolTip)
        {

            DecorateBar(iHandle, sBarKey, emBarType, emEdgeType, emCornerType);

            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarCanMove, m_bEditable);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarCanStartLink, true);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarCanEndLink, true);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarCanResize, m_bEditable);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarCanBeLinked, true);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarOffset, iOffSet);
            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarToolTip, sToolTip);
        }

        protected void DecorateBar(int iHandle, string sBarKey, EMGanttBarType emBarType, EMGanttEdgeType emEdgeType, EMGanttEdgeShapeType emEdgeShapeType)
        {
            string sBarName = emBarType.ToString();

            //if (emEdgeShapeType != EMGanttEdgeShapeType.Empty)
            //{
            //    sBarName = emBarType.ToString() + emEdgeShapeType.ToString() + emEdgeType.ToString();

            //    exontrol.EXG2ANTTLib.Bar exBar = m_exChart.Bars[sBarName];
            //    if (exBar == null)
            //    {
            //        exBar = m_exChart.Bars[emBarType.ToString()];
            //        exontrol.EXG2ANTTLib.Bar exBarClone = m_exChart.Bars.Copy(emBarType.ToString(), sBarName);

            //        if (emEdgeType == EMGanttEdgeType.Start)
            //            exBarClone.StartShape = (exontrol.EXG2ANTTLib.ShapeCornerEnum)((int)emEdgeShapeType);
            //        else if (emEdgeType == EMGanttEdgeType.End)
            //            exBarClone.EndShape = (exontrol.EXG2ANTTLib.ShapeCornerEnum)((int)emEdgeShapeType);
            //        else
            //        {
            //            exBarClone.StartShape = (exontrol.EXG2ANTTLib.ShapeCornerEnum)((int)emEdgeShapeType);
            //            exBarClone.EndShape = (exontrol.EXG2ANTTLib.ShapeCornerEnum)((int)emEdgeShapeType);
            //        }
            //    }
            //}

            m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarName, sBarName);
        }

        protected void DecorateLink(string sLinkKey, Color cLinkColor, EMGanttPointType emPointFrom, EMGanttPointType emPointTo, string sText)
        {
            m_exItems.set_LinkColor(sLinkKey, cLinkColor);
            if (emPointFrom == EMGanttPointType.Start)
                m_exItems.set_LinkStartPos(sLinkKey, exontrol.EXG2ANTTLib.AlignmentEnum.LeftAlignment);
            else
                m_exItems.set_LinkStartPos(sLinkKey, exontrol.EXG2ANTTLib.AlignmentEnum.RightAlignment);

            if (emPointTo == EMGanttPointType.Start)
                m_exItems.set_LinkEndPos(sLinkKey, exontrol.EXG2ANTTLib.AlignmentEnum.LeftAlignment);
            else
                m_exItems.set_LinkEndPos(sLinkKey, exontrol.EXG2ANTTLib.AlignmentEnum.RightAlignment);

            m_exItems.set_LinkText(sLinkKey, sText);
        }

        #endregion

        #region User Event

        protected void OnBarCreated(int iHandle, DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                TimeSpan tsSpan = dtEnd.Subtract(dtStart);
                if (tsSpan.TotalSeconds < 1)
                    return;

                CGanttItem cItem = GetItem(iHandle);
                if (cItem == null || cItem.IsBarAddable == false)
                    return;

                int iCount = m_exItems.get_BarsCount(iHandle);

                CGanttBar cBar = new CGanttBar();                
                cBar.Handle = iHandle;
                cBar.Start = dtStart;
                cBar.End = dtEnd;

                AddBar(cItem, cBar);

                if (m_bGenerateEvent && UEventBarCreated != null)
                    UEventBarCreated(this, cBar);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnBarRemoved(int iHandle, string sKey)
        {
            try
            {
                CGanttBar cBar = GetBar(iHandle, sKey);
                if (m_bGenerateEvent &&  UEventBarRemoved != null && cBar != null)
                    UEventBarRemoved(this, cBar);

                m_exItems.RemoveBar(iHandle, sKey);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnBarResized(int iHandle, string sBarKey)
        {
            try
            {
                CGanttBar cBar = GetBar(iHandle, sBarKey);
                if (cBar == null)
                    return;

                cBar.Start = m_exItems.get_BarStart(iHandle, sBarKey);
                cBar.End = m_exItems.get_BarEnd(iHandle, sBarKey);

                if (m_bGenerateEvent &&  UEventBarTimeChanged != null)
                    UEventBarTimeChanged(this, cBar);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnBarProperty(int iHandle, string sBarKey)
        {
            try
            {
                CGanttBar cBar = GetBar(iHandle, sBarKey);
                if (cBar == null)
                    return;

                CreateTimeIndicator(cBar.Start);
                CreateTimeIndicator(cBar.End);

                FrmBarProperty dlgProperty = new FrmBarProperty(m_bEditable);
                dlgProperty.Bar = cBar;
                dlgProperty.ShowDialog(this);

                bool bOK = dlgProperty.OK;
                if (bOK && m_bEditable)
                {
                    m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarStart, cBar.Start);
                    m_exItems.set_ItemBar(iHandle, sBarKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarEnd, cBar.End);

                    if (m_bGenerateEvent &&  UEventBarTimeChanged != null)
                        UEventBarTimeChanged(this, cBar);
                }

                dlgProperty.Dispose();
                dlgProperty = null;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnLinkCreated(string sLinkKey)
        {
            try
            {
                int iCount =m_exItems.get_LinksCount();
                int iHandleFrom = m_exItems.get_LinkStartItem(sLinkKey);
                int iHandleTo = m_exItems.get_LinkEndItem(sLinkKey);

                object oFrom = m_exItems.get_LinkStartBar(sLinkKey);
                string sKeyFrom = (string)m_exItems.get_LinkStartBar(sLinkKey);
                string sKeyTo = (string)m_exItems.get_LinkEndBar(sLinkKey);

                if (iHandleFrom == iHandleTo)
                {
                    m_exItems.RemoveLink(sLinkKey);
                    return;
                }

                // Check Inside Group
                int iHandleStartParent = m_exItems.get_ItemParent(iHandleFrom);
                int iHandleEndParent = m_exItems.get_ItemParent(iHandleTo);
                if (iHandleStartParent != iHandleEndParent)
                {
                    m_exItems.RemoveLink(sLinkKey);
                    return;
                }

                CGanttBar cBarFrom = (CGanttBar)m_exItems.get_BarData(iHandleFrom, sKeyFrom);
                CGanttBar cBarTo = (CGanttBar)m_exItems.get_BarData(iHandleTo, sKeyTo);
                if (cBarFrom == null || cBarTo == null)
                {
                    m_exItems.RemoveLink(sLinkKey);
                    return;
                }

                CGanttLink cLink = new CGanttLink();
                cLink.Key = sLinkKey;
                if (cBarFrom.Start > cBarTo.Start)
                {
                    cLink.BarFrom = cBarTo;
                    cLink.BarTo = cBarFrom;
                }
                else
                {
                    cLink.BarFrom = cBarFrom;
                    cLink.BarTo = cBarTo;
                }

                TimeSpan tsSpan = cLink.BarTo.Start.Subtract(cLink.BarFrom.Start);
                cLink.Text = tsSpan.TotalMilliseconds.ToString();
                cLink.PointTypeFrom = EMGanttPointType.Start;
                cLink.PointTypeTo = EMGanttPointType.Start;

                m_exItems.set_LinkUserData(sLinkKey, cLink);
                DecorateLink(sLinkKey, cLink.Color, cLink.PointTypeFrom, cLink.PointTypeTo, cLink.Text);

                if (m_bGenerateEvent &&  UEventLinkCreated != null)
                    UEventLinkCreated(this, cLink);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnLinkRemoved(string sLinkKey)
        {
            try
            {
                int iHandleStart = m_exItems.get_LinkStartItem(sLinkKey);
                CGanttLink cLink = (CGanttLink)m_exItems.get_LinkUserData(sLinkKey);

                if (m_bGenerateEvent &&  UEventLinkRemoved != null)
                    UEventLinkRemoved(this, cLink);

                m_exItems.RemoveLink(sLinkKey);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected void OnEditLinkProperty(string sLinkKey)
        {
            try
            {
                CGanttLink cLink = (CGanttLink)m_exItems.get_LinkUserData(sLinkKey);

                FrmLinkProperty dlgProperty = new FrmLinkProperty(m_bEditable);
                dlgProperty.Link = cLink;
                dlgProperty.ShowDialog(this);

                bool bOK = dlgProperty.OK;
                if (bOK && m_bEditable)
                {
                    DecorateLink(sLinkKey, cLink.Color, cLink.PointTypeFrom, cLink.PointTypeTo, cLink.Text);

                    if (m_bGenerateEvent && UEventLinkUpdated != null)
                        UEventLinkUpdated(this, cLink);
                }

                dlgProperty.Dispose();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }


        #endregion

        #region Zoom-Move

        protected void SetCellHeight(int iHeight)
        {
            BeginUpdate();

            try
            {
                m_iUnitHeight = iHeight;

                int iCount = exGant.Items.ItemCount;
                int iHandle;
                for (int i = 0; i < iCount; i++)
                {
                    iHandle = exGant.Items[i];
                    if (iHandle > 0)
                        exGant.Items.set_ItemHeight(iHandle, m_iUnitHeight);
                }

                exGant.DefaultItemHeight = m_iUnitHeight;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            EndUpdate();
        }


        protected void SetCellWidth(int iWidth)
        {
            BeginUpdate();

            try
            {
                m_iUnitWidth = iWidth;
                exGant.Chart.UnitWidth = m_iUnitWidth;

                CGanttTimeIndicator cIndicator;
                for (int i = 0; i < m_cTimeIndicatorS.Count; i++)
                {
                    cIndicator = m_cTimeIndicatorS[i];

                    m_exChart.RemoveTimeZone(cIndicator.Key);
                    m_exChart.MarkTimeZone(cIndicator.Key, cIndicator.Time, GetTimeIndicatorEndTime(cIndicator.Time), cIndicator.BackColor, ";;" + cIndicator.Text);
                    
                }
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            EndUpdate();
        }

        public bool GetTimeIndicatePeriod(out DateTime dtStart, out DateTime dtEnd)
        {
            if (m_cTimeIndicatorS.Count < 2)
            {
                dtStart = DateTime.MinValue;
                dtEnd = DateTime.MinValue;
                return false;
            }

            CGanttTimeIndicator cIndicator;

            cIndicator = m_cTimeIndicatorS[0];
            dtStart = cIndicator.Time;

            cIndicator = m_cTimeIndicatorS[1];
            dtEnd = cIndicator.Time;

            return true;
        }

        protected void SetOverviewHeight(int iHeight)
        {
            BeginUpdate();

            try
            {
                m_iOverviewHeight = iHeight;
                exGant.Chart.OverviewHeight = m_iOverviewHeight;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            EndUpdate();
        }

        #endregion

        #region Control

        protected void SetColumnHeader(CGanttHeaderS cHeaderS)
        {
            exGant.BeginUpdate();

            exGant.Columns.Clear();

            int iTotalWidth = 0;
            m_cColumnHeaderS = cHeaderS;
            if (m_cColumnHeaderS != null)
            {
                CGanttHeader cHeader;
                exontrol.EXG2ANTTLib.Column cColumn;
                for (int i = 0; i < m_cColumnHeaderS.Count; i++)
                {
                    cHeader = m_cColumnHeaderS[i];
                    cColumn = exGant.Columns.Add(cHeader.Caption);
                    cColumn.Width = cHeader.Width;
                    cColumn.ShowFilter();
                    cColumn.HeaderAlignment = exontrol.EXG2ANTTLib.AlignmentEnum.CenterAlignment;
                    iTotalWidth += cHeader.Width;
                }

                exGant.Chart.PaneWidthLeft = iTotalWidth;
            }

            exGant.EndUpdate();
        }

        protected CGanttItem GetItem(int iHandle)
        {
            CGanttItem cItem = null;

            try
            {
                cItem = (CGanttItem)m_exItems.get_ItemData(iHandle);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cItem;
        }

        protected void RemoveChildItem(int iHandle)
        {
            try
            {
                int iCount = m_exItems.get_ChildCount(iHandle);
                int iChildHandle;
                for (int i = 0; i < iCount; i++)
                {
                    iChildHandle = m_exItems.get_ItemChild(iHandle);
                    if (iChildHandle > 0)
                    {
                        RemoveChildItem(iChildHandle);

                        if (m_exItems.get_EnableItem(iHandle))
                            m_exItems.RemoveItem(iChildHandle);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }

        protected CGanttBar GetBar(int iHandle, string sKey)
        {
            CGanttBar cBar = null;

            try
            {
                cBar = (CGanttBar)m_exItems.get_ItemBar(iHandle, sKey, exontrol.EXG2ANTTLib.ItemBarPropertyEnum.exBarData);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return cBar;
        }

        protected void ClearChart()
        {
            try
            {
                if (exGant != null && exGant.Items != null)
                {
                    exGant.Chart.Notes.Clear();
                    exGant.Items.RemoveAllItems();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
        }
        
        protected void SetFirstVisibleTime(DateTime dtTime)
        {
            if (dtTime == DateTime.MinValue)
                return;

            m_dtFirstVisibleTime = dtTime;

            BeginUpdate();

            exGant.Chart.FirstVisibleDate = dtTime;

            if (UEventFirstVisibleTimeChanged != null)
                UEventFirstVisibleTimeChanged(this, exGant.Chart.FirstVisibleDate);

            EndUpdate();
        }

        private DateTime GetTimeIndicatorEndTime(DateTime dtStart)
        {
            int iUnitTime = 0;
            if (m_exChart.UnitScale == exontrol.EXG2ANTTLib.UnitEnum.exSecond)
                iUnitTime = 1000;
            else if (m_exChart.UnitScale == exontrol.EXG2ANTTLib.UnitEnum.exMinute)
                iUnitTime = 1000 * 60;
            else if (m_exChart.UnitScale == exontrol.EXG2ANTTLib.UnitEnum.exHour)
                iUnitTime = 1000 * 60 * 60;

            int pxTime = (int)(iUnitTime / m_exChart.UnitWidth);
            DateTime dtEnd = dtStart.AddMilliseconds(pxTime * 4);

            return dtEnd;
        }

		protected void SetDefaultUnitScale(EMGanttUnitScale value)
		{
			m_emGanttUnitScale = value;
			m_exChart.UnitScale = (exontrol.EXG2ANTTLib.UnitEnum)value;
			exGant_OverviewZoom(this);
		}

		protected void SetInsideZoom(bool value)
		{
			m_bInsideZoom = value;
			m_exChart.AllowInsideZoom = value;
		}
        #endregion

        #region Editable

        protected void SetChartEditable(bool bEditable)
        {
            if (bEditable)
            {
                m_exChart.AllowCreateBar = exontrol.EXG2ANTTLib.CreateBarEnum.exCreateBarManual;
                m_exChart.AllowLinkBars = true;
                m_exChart.BarsAllowSizing = true;
            }
            else
            {
                m_exChart.AllowCreateBar = exontrol.EXG2ANTTLib.CreateBarEnum.exNoCreateBar;
                m_exChart.AllowLinkBars = false;
                m_exChart.BarsAllowSizing = false;
            }
        }        

        protected void EnableChartEvent()
        {
            if (m_bChartEventActivated)
                return;

            m_bChartEventActivated = true;

            this.exGant.MouseDownEvent += new exontrol.EXG2ANTTLib.exg2antt.MouseDownEventHandler(this.exGant_MouseDownEvent);
            this.exGant.MouseMoveEvent += new exontrol.EXG2ANTTLib.exg2antt.MouseMoveEventHandler(exGant_MouseMoveEvent);
            this.exGant.MouseUpEvent += new exontrol.EXG2ANTTLib.exg2antt.MouseUpEventHandler(exGant_MouseUpEvent);
            this.exGant.OverviewZoom += new exontrol.EXG2ANTTLib.exg2antt.OverviewZoomEventHandler(this.exGant_OverviewZoom);
            this.exGant.DblClick += new exontrol.EXG2ANTTLib.exg2antt.DblClickEventHandler(this.exGant_DblClick);
            this.exGant.KeyDown += new exontrol.EXG2ANTTLib.exg2antt.KeyDownEventHandler(this.exGant_KeyDown);
			this.exGant.AfterExpandItem += exGant_AfterExpandItem;

            if (m_bEditable)
            {
                this.exGant.CreateBar += new exontrol.EXG2ANTTLib.exg2antt.CreateBarEventHandler(exGant_CreateBar);
                this.exGant.BarResize += new exontrol.EXG2ANTTLib.exg2antt.BarResizeEventHandler(exGant_BarResize);
                this.exGant.AddLink += new exontrol.EXG2ANTTLib.exg2antt.AddLinkEventHandler(exGant_AddLink);
            }
        }

		private void exGant_AfterExpandItem(object sender, int Item)
		{
			if(UEventAfterExpandItem != null)
				UEventAfterExpandItem(this, Item, GetItem(Item));
		}

        protected void DisableChartEvent()
        {
            if (m_bChartEventActivated == false)
                return;

            m_bChartEventActivated = false;

            this.exGant.MouseDownEvent -= new exontrol.EXG2ANTTLib.exg2antt.MouseDownEventHandler(this.exGant_MouseDownEvent);
            this.exGant.MouseMoveEvent -= new exontrol.EXG2ANTTLib.exg2antt.MouseMoveEventHandler(exGant_MouseMoveEvent);
            this.exGant.MouseUpEvent -= new exontrol.EXG2ANTTLib.exg2antt.MouseUpEventHandler(exGant_MouseUpEvent);
            exGant.OverviewZoom -= new exontrol.EXG2ANTTLib.exg2antt.OverviewZoomEventHandler(exGant_OverviewZoom);
            this.exGant.DblClick -= new exontrol.EXG2ANTTLib.exg2antt.DblClickEventHandler(this.exGant_DblClick);
            this.exGant.KeyDown -= new exontrol.EXG2ANTTLib.exg2antt.KeyDownEventHandler(this.exGant_KeyDown);
			this.exGant.AfterExpandItem -= exGant_AfterExpandItem;

            if (m_bEditable)
            {
                this.exGant.CreateBar -= new exontrol.EXG2ANTTLib.exg2antt.CreateBarEventHandler(exGant_CreateBar);
                this.exGant.BarResize -= new exontrol.EXG2ANTTLib.exg2antt.BarResizeEventHandler(exGant_BarResize);
                this.exGant.AddLink -= new exontrol.EXG2ANTTLib.exg2antt.AddLinkEventHandler(exGant_AddLink);
            }
        }


        protected void EnableUndoRedo(exontrol.EXG2ANTTLib.exg2antt g2antt)
        {
            System.Reflection.PropertyInfo pUndoRedo = g2antt.Chart.GetType().GetProperty("AllowUndoRedo");
            if (pUndoRedo != null)
            {
                if (pUndoRedo.CanWrite)
                {
                    pUndoRedo.SetValue(g2antt.Chart, true, null);
                }
            }
        }

        #endregion

        #region Time Indicator

        protected void GenerateTimeIndicatorCreated(CGanttTimeIndicator cIndicator)
        {
            if (UEventTimeIndicatorCreated != null)
                UEventTimeIndicatorCreated(this, cIndicator);
        }

        protected void GenerateTimeIndicatorIntervalChanged()
        {
            if (UEventTimeIndicatorIntervalChanged != null && m_cTimeIndicatorS.Count == 2)
            {
                double nTime = 0;
                if (m_cTimeIndicatorS[0].Time > m_cTimeIndicatorS[1].Time)
                    nTime = m_cTimeIndicatorS[0].Time.Subtract(m_cTimeIndicatorS[1].Time).TotalMilliseconds;
                else
                    nTime = m_cTimeIndicatorS[1].Time.Subtract(m_cTimeIndicatorS[0].Time).TotalMilliseconds;

                UEventTimeIndicatorIntervalChanged(this, nTime);
            }
        }

        #endregion

        #region Util

        protected bool IsLeafItem(int iHandle)
        {
            bool bOK = true;

            int iCount = m_exItems.get_ChildCount(iHandle);
            if (iCount > 0)
                bOK = false;

            return bOK;
        }

        protected string CreateTooltip(DateTime dtStart, DateTime dtEnd)
        {
            string strTooltip = "";
            try
            {
                string sTimeInterval = string.Format("{0}", dtEnd.Subtract(dtStart).TotalSeconds);
                strTooltip = string.Format("START : {0}\r\nEND : {1}\r\nBETWEEN [ {2} ]",
                                            dtStart.ToString("HH:mm:ss.fff"),
                                            dtEnd.ToString("HH:mm:ss.fff"),
                                            sTimeInterval);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }

            return strTooltip;
        }

        protected int CompareAscending(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return x.Value.CompareTo(y.Value);
        }

        protected int CompareDescending(KeyValuePair<int, int> x, KeyValuePair<int, int> y)
        {
            return y.Value.CompareTo(x.Value);
        }

        #endregion

        #endregion


        #region Event Methods

        #region UC Event

        private void UCGanttChart_Load(object sender, EventArgs e)
        {   
            EnableChartEvent();

            this.Resize += new EventHandler(UCMSGanttChart_Resize);
            exGant.Resize += new EventHandler(exGant_Resize);
            exGant.Click += new exontrol.EXG2ANTTLib.exg2antt.ClickEventHandler(exGant_Click);
			exGant.AfterExpandItem += exGant_AfterExpandItem;

            UCMSGanttChart_Resize(this, EventArgs.Empty);
        }

        protected void UCMSGanttChart_Resize(object sender, EventArgs e)
        {
            m_iPaneWidthLeft = m_cColumnHeaderS.TotalColumnWidth;
            m_exChart.PaneWidthLeft = m_iPaneWidthLeft;
        }
        
        #endregion


        #region ExGant Event

        protected void exGant_Resize(object sender, EventArgs e)
        {
            BeginUpdate();

            m_iPaneWidthLeft = m_cColumnHeaderS.TotalColumnWidth;
            m_exChart.PaneWidthLeft = m_iPaneWidthLeft;
            

            EndUpdate();

            if (UEventGridWidthChanged != null)
                UEventGridWidthChanged(this, m_exChart.PaneWidthLeft);
        }

        protected void exGant_CreateBar(object sender, int Item, DateTime DateStart, DateTime DateEnd)
        {
            DisableChartEvent();

            BeginUpdate();

            OnBarCreated(Item, DateStart, DateEnd);

            EndUpdate();

            EnableChartEvent();
        }

        protected void exGant_BarResize(object sender, int Item, object Key)
        {
            if (Key == null)
                return;

            DisableChartEvent();

            BeginUpdate();

            OnBarResized(Item, Key.ToString());

            EndUpdate();

            EnableChartEvent();
        }

        protected void exGant_AddLink(object sender, string LinkKey)
        {
            DisableChartEvent();

            BeginUpdate();

            OnLinkCreated(LinkKey);

            EndUpdate();

            EnableChartEvent();
        }

        protected void exGant_KeyDown(object sender, ref short KeyCode, short Shift)
        {
            if (UEventKeyDown != null)
                UEventKeyDown(this, ref KeyCode, Shift);

            if (KeyCode == 46)  // Delete            
            {
                if (m_bEditable)
                {
                    DisableChartEvent();
                    BeginUpdate();

                    List<exontrol.EXG2ANTTLib.Items.SelectedBar> lstBar = m_exItems.get_SelectedBars();
                    List<string> lstLink = m_exItems.get_SelectedLinks();

                    if (lstBar != null)
                    {
                        exontrol.EXG2ANTTLib.Items.SelectedBar exBar;
                        for (int i = 0; i < lstBar.Count; i++)
                        {
                            exBar = lstBar[i];
                            OnBarRemoved(exBar.Item, exBar.Key.ToString());
                        }

                        lstBar.Clear();
                    }

                    if (lstLink != null)
                    {
                        string sLink;
                        for (int i = 0; i < lstLink.Count; i++)
                        {
                            sLink = lstLink[i];
                            OnLinkRemoved(sLink);
                        }

                        lstLink.Clear();
                    }

                    if (m_cTimeIndicatorSelected != null)
                    {
                        m_cTimeIndicatorS.Remove(m_cTimeIndicatorSelected);
                        m_exChart.RemoveTimeZone(m_cTimeIndicatorSelected.Key);

                        if (UEventTimeIndicatorRemoved != null)
                            UEventTimeIndicatorRemoved(this, m_cTimeIndicatorSelected);

                        m_cTimeIndicatorSelected = null;
                    }

                    EndUpdate();
                    EnableChartEvent();

                    KeyCode = 0;
                }
            }
            else if (Shift == 0 && KeyCode == 107) // +
            {
                ZoomInWidth();
                KeyCode = 0;
            }
            else if (Shift == 0 && KeyCode == 109)  // -
            {
                ZoomOutWidth();
                KeyCode = 0;
            }
            else if (Shift == 1 && KeyCode == 107)
            {
                ZoomInHeight();
                KeyCode = 0;
            }
            else if (Shift == 1 && KeyCode == 109)
            {
                ZoomOutHeight();
                KeyCode = 0;
            }
            else if (Shift == 1 && KeyCode == 38)  //up
            {
                ZoomOutOverviewHeight();
                KeyCode = 0;
            }
            else if (Shift == 1 && KeyCode == 40) // down
            {   
                ZoomInOverviewHeight();
                KeyCode = 0;
            }

        }

        protected void exGant_Click(object sender)
        {
            /*
            if (m_ehOnClickGanttObject != null ) 
            {
                int col = 0;
                exontrol.EXG2ANTTLib.HitTestInfoEnum h = (exontrol.EXG2ANTTLib.HitTestInfoEnum)0;
                int hItem = exGant.get_ItemFromPoint(-1, -1, ref col, ref h);
                object oKey = exGant.Chart.get_BarFromPoint(-1, -1);
                m_ehOnClickGanttObject(exGant, exGant.Items.get_BarData(hItem,oKey));
            }
            else
            {
                // If necessary to have default ...
            }
             * */

        }

        protected void exGant_DblClick(object sender, short Shift, int X, int Y)
        {
            DisableChartEvent();

            BeginUpdate();

            List<exontrol.EXG2ANTTLib.Items.SelectedBar> lstBar = m_exItems.get_SelectedBars();
            if (lstBar != null && lstBar.Count == 1)
            {
                int iHandle = lstBar[0].Item;
                string sBar = lstBar[0].Key.ToString().Trim();

                bool bHandled = false;

                if (UEventBarDoubleClicked != null)
                {
                    CGanttBar cBar = GetBar(iHandle, sBar);
                    if (cBar != null)
                        UEventBarDoubleClicked(this, cBar, iHandle, ref bHandled);
                }

                if (bHandled == false)
                    OnBarProperty(iHandle, sBar);
            }

            List<string> lstLink = m_exItems.get_SelectedLinks();
            if (lstLink != null && lstLink.Count == 1)
            {
                OnEditLinkProperty(lstLink[0]);
            }

            EndUpdate();

            EnableChartEvent();

        }

        protected void exGant_MouseDownEvent(object sender, short Button, short Shift, int X, int Y)
        {
            if (UEventMouseDown != null)
                UEventMouseDown(this, Button, Shift, X, Y);

            if (Button == 2) // Right Button
            {
                if (Shift == 0)
                {
                    Point pntPoint = new Point(X, Y);
                    if (X > m_iPaneWidthLeft)
                    {
                        List<exontrol.EXG2ANTTLib.Items.SelectedBar> lstBar = m_exItems.get_SelectedBars();
                        if (lstBar == null || lstBar.Count == 0)
                            return;

                        if (m_mnuBar != null)
                            m_mnuBar.Show(this, pntPoint);

                        lstBar.Clear();
                    }
                    else
                    {
                        if(m_mnuItem != null)
                            m_mnuItem.Show(this, pntPoint);
                    }
                }
                else
                {
                    ZoomOutWidth();
                }
            }
            else if (Button == 4)   // Wheel Button
            {
                m_pntMiddleButton = new Point(X, Y);
            }
            else
            {
                if (Shift == 1)
                {
                    ZoomInWidth();
                }
                else
                {
                    object oObject = m_exChart.get_TimeZoneFromPoint(X, Y);
                    if (oObject == null)
                    {
                        m_cTimeIndicatorSelected = null;
                    }
                    else
                    {
                        string sKey = oObject.ToString();

                        if (m_cTimeIndicatorS.ContainsKey(sKey))
                        {
                            m_cTimeIndicatorSelected = m_cTimeIndicatorS[sKey];
                            if (m_cTimeIndicatorSelected != null)
                            {
                                m_cTimeIndicatorSelected.X = X;
                                m_cTimeIndicatorSelected.Y = Y;

                                m_exChart.AllowSelectObjects = exontrol.EXG2ANTTLib.SelectObjectsEnum.exNoSelectObjects;
                            }
                        }
                        else
                        {
                            m_cTimeIndicatorSelected = null;
                        }
                    }
                }
            }
        }

        private void exGant_MouseMoveEvent(object sender, short Button, short Shift, int X, int Y)
        {
            if (UEventMouseMove != null)
                UEventMouseMove(this, Button, Shift, X, Y);

            if (m_cTimeIndicatorSelected != null && Button == 1)
            {
                double nDelta = (double)((X - m_cTimeIndicatorSelected.X) * 1000 / (m_exChart.UnitWidth));


                if (nDelta == 0)
                    return;

                BeginUpdate();

                m_exChart.RemoveTimeZone(m_cTimeIndicatorSelected.Key);

                m_cTimeIndicatorSelected.Time = m_cTimeIndicatorSelected.Time.AddMilliseconds(nDelta);

                m_cTimeIndicatorSelected.X = X;
                m_cTimeIndicatorSelected.Y = Y;
                m_cTimeIndicatorSelected.Text = m_cTimeIndicatorSelected.Time.ToString("HH:mm:ss.fff");
                m_exChart.MarkTimeZone(m_cTimeIndicatorSelected.Key, m_cTimeIndicatorSelected.Time, GetTimeIndicatorEndTime(m_cTimeIndicatorSelected.Time), m_cTimeIndicatorSelected.BackColor, ";;" + m_cTimeIndicatorSelected.Text);

                EndUpdate();

                if (UEventTimeIndicatorMoved != null)
                    UEventTimeIndicatorMoved(this, m_cTimeIndicatorSelected);

                GenerateTimeIndicatorIntervalChanged();
            }
        }

        private void exGant_MouseUpEvent(object sender, short Button, short Shift, int X, int Y)
        {
            if (UEventMouseUp != null)
                UEventMouseUp(this, Button, Shift, X, Y);

            if(Button == 1)
            {
                if (m_dtFirstVisibleTime != m_exChart.FirstVisibleDate)
                {
                    m_dtFirstVisibleTime = m_exChart.FirstVisibleDate;

                    if (UEventFirstVisibleTimeChanged != null)
                        UEventFirstVisibleTimeChanged(this, m_exChart.FirstVisibleDate);
                }

                if (m_iPaneWidthLeft != m_exChart.PaneWidthLeft)
                {
                    m_iPaneWidthLeft = m_exChart.PaneWidthLeft;
                    if (UEventGridWidthChanged != null)
                        UEventGridWidthChanged(this, m_exChart.PaneWidthLeft);
                }

                if (m_cTimeIndicatorSelected != null)
                {
                    //m_cTimeIndicatorSelected = null;
                    m_exChart.AllowSelectObjects = exontrol.EXG2ANTTLib.SelectObjectsEnum.exSelectObjects;
                }
            }
            else if (Button == 4)
            {
                if (m_pntMiddleButton.X > X + 10 && m_pntMiddleButton.Y > Y + 10)
                    ZoomOutWidth();
                else if (m_pntMiddleButton.X < X - 10 && m_pntMiddleButton.Y < Y - 10)
                    ZoomInWidth();
            }
        }

        protected void exGant_OverviewZoom(object sender)
        {
            DisableChartEvent();

            BeginUpdate();

            m_exChart.get_Level(1).Count = 1;

            switch (exGant.Chart.UnitScale)
            {
                case exontrol.EXG2ANTTLib.UnitEnum.exSecond:
                    m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exMinute, "<%yy%>/<%mm%>/<%dd%> <%hh%>:<%nn%>");
                    m_exChart.get_Level(0).Label = exontrol.EXG2ANTTLib.UnitEnum.exMinute;
                    m_exChart.get_Level(1).Label = exontrol.EXG2ANTTLib.UnitEnum.exSecond;
                    m_exChart.UnitWidth = 20;
                    break;
                case exontrol.EXG2ANTTLib.UnitEnum.exMinute:
                    m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exMinute, "<%nn%>");
                    m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exHour, "<%yy%>/<%mm%>/<%dd%> <%hh%>");
                    m_exChart.get_Level(0).Label = exontrol.EXG2ANTTLib.UnitEnum.exHour;
                    m_exChart.get_Level(1).Label = exontrol.EXG2ANTTLib.UnitEnum.exMinute;
                    m_exChart.UnitWidth = 40;
                    break;
                case exontrol.EXG2ANTTLib.UnitEnum.exHour:
                    m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exHour, "<%hh%>");
                    m_exChart.set_Label(exontrol.EXG2ANTTLib.UnitEnum.exDay, "<%yy%>/<%mm%>/<%dd%>");
                    m_exChart.get_Level(0).Label = exontrol.EXG2ANTTLib.UnitEnum.exDay;
                    m_exChart.get_Level(1).Label = exontrol.EXG2ANTTLib.UnitEnum.exHour;
                    m_exChart.UnitWidth = 80;
                    break;
                default:
                    break;

            }

            EndUpdate();

            EnableChartEvent();
        }

        protected void CreateTimeIndicator(DateTime dtTime)
        {
            m_cTimeIndicatorSelected = null;


            if (m_cTimeIndicatorS.Count > 1)
            {
                CGanttTimeIndicator cIndicatorOld = m_cTimeIndicatorS[0];

                BeginUpdate();
                m_exChart.RemoveTimeZone(cIndicatorOld.Key);
                EndUpdate();

                m_cTimeIndicatorS.RemoveAt(0);

                cIndicatorOld = null;
            }

            string sKey = "TimeIndicator0";
            if (m_cTimeIndicatorS.ContainsKey(sKey))
                sKey = "TimeIndicator1";

            CGanttTimeIndicator cIndicator = new CGanttTimeIndicator(sKey);
            cIndicator.Time = dtTime;
            cIndicator.BackColor = Color.Red;
            cIndicator.Text = cIndicator.Time.ToString("HH:mm:ss.fff");

            m_cTimeIndicatorS.Add(cIndicator);

            BeginUpdate();
            m_exChart.MarkTimeZone(cIndicator.Key, cIndicator.Time, GetTimeIndicatorEndTime(cIndicator.Time), cIndicator.BackColor, ";;" + cIndicator.Text);
            EndUpdate();

            GenerateTimeIndicatorCreated(cIndicator);
            GenerateTimeIndicatorIntervalChanged();
            
        }

        private void exGant_InsideZoom(object sender, DateTime dtTime)
        {
            CreateTimeIndicator(dtTime);
        }

        private void exGant_ScrollButtonClick(object sender, exontrol.EXG2ANTTLib.ScrollBarEnum ScrollBar, exontrol.EXG2ANTTLib.ScrollPartEnum ScrollPart)
        {
            if (UEventFirstVisibleTimeChanged != null)
                UEventFirstVisibleTimeChanged(this, m_exChart.FirstVisibleDate);
        }

        #endregion



		#endregion


    }
}
