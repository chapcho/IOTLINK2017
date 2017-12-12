using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using UDM.Log;

namespace UDM.Ladder
{
    public class CommonFuntionBlock : CLadderItem, ILadderItemFB
    {
        #region Private Members

        private bool m_bValue = false;
        private string m_sFormatDate = "";

        private DateTime m_dtTime = DateTime.MinValue;
        private CFB_Info m_cFB_Info = null;

        private CFBCommon m_cFBCommon = new CFBCommon();

        #endregion

        #region Public Properties

        public CFB_Info FB_Info { get { return m_cFB_Info; } set { m_cFB_Info = value; Update(); } }
        public bool Value { get { return m_bValue; } set { m_bValue = value; } }
        public DateTime Date { get { return m_dtTime; } set { m_dtTime = value; } }
        public string DateFormat { get { return m_sFormatDate; } set { m_sFormatDate = value; } }

        #endregion

        #region Protected Methods

        protected override void Vertexes() { }
        protected override void Edges() { }
        protected override void Polygons() { }
        protected override void Beziers() { }

        protected override void DrawAdditional(Graphics graphics, Point point, CTimeLogS cLogS)
        {
            try
            {
                if (m_cFB_Info != null)
                    DrawAdditional(graphics, point, m_bValue, m_dtTime.ToString(m_sFormatDate), m_cFB_Info, m_font, m_brushText);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        #endregion

        #region Private Methods

        public void DrawAdditional(Graphics graphics, Point point, bool bValue, string strTime, CFB_Info cFB_Info, Font font, Brush brush)
        {
            try
            {
                // If value
                Brush brushValue = bValue ? new SolidBrush(Color.FromArgb(90, Color.Blue)) : new SolidBrush(Color.FromArgb(0, Color.Blue));
                if (m_cPolygonS.Count > 0)
                {
                    CVertexS cOffsetedVertexS = m_cPolygonS.First().OffsetAllPointsTemporary(point.X, point.Y);
                    graphics.FillPolygon(brushValue, cOffsetedVertexS.ConvertToPointArray());
                }

                string strAddress = cFB_Info.FBNumber;
                string strDescription = cFB_Info.FBDescription;

                // String format 
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                Brush brushInfo = bValue ? new SolidBrush(Color.Yellow) : brush;

                Font fontAddress = new Font(font.SystemFontName, (int)(font.Size * 1.2));
                SizeF sizeFont = graphics.MeasureString(strAddress, fontAddress);

                // Address
                graphics.DrawString(strAddress, fontAddress, brushInfo, new Point(point.X + 100, point.Y - (int)Math.Round(0.5 * sizeFont.Height)), stringFormat);
               
                Font fontComment = new Font(font.SystemFontName, (int)(font.Size * 1.2));
                sizeFont = graphics.MeasureString(strDescription, fontComment);
                
                int nWrapBoxHeight = (int)(3.5 * sizeFont.Height); // 2.5 lines ( 0.5 to show it is wrapped .. )
                int nWrapBoxWidth = Math.Abs(m_cBoundingBoxeS[1].X - m_cBoundingBoxeS[0].X);

                float levelHeight = 25F;
                levelHeight += sizeFont.Height;

                // String symbol (comment)
                graphics.DrawString(strDescription, fontComment, brush, new RectangleF(point.X + 50 - (int)(nWrapBoxWidth / 3.0), point.Y + levelHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormat);

                StringFormat stringFormatItem = new StringFormat();
                Font fontItem = new Font(font.SystemFontName, (float)(0.87 * font.Size));

                // InItemS
                int iHeight = m_cFBCommon.FBHeight + 65;
                int iLineHeight = m_cFBCommon.FBHeight + 70;
                int iItemHeight = 100;

                for (int i = m_cFB_Info.InOut_ItemNameList.Count - 1; i >= 0; i--)
                {
                    string sTempItem = m_cFB_Info.InOut_ItemNameList[i];
                    string sItem = sTempItem;
                    if (sItem.Contains('.'))
                        sItem = sItem.Split('.')[1];

                    iHeight -= iItemHeight;
                    iLineHeight -= iItemHeight;

                    stringFormatItem.Alignment = StringAlignment.Near;
                    graphics.DrawString(sItem, fontItem, new SolidBrush(Color.Black), new RectangleF(point.X - 20, iHeight, nWrapBoxWidth / 2, nWrapBoxHeight), stringFormatItem);
                    graphics.DrawLine(m_pen, point.X - 50, iLineHeight, point.X - 20, iLineHeight);
                }

                for (int i = m_cFB_Info.In_ItemNameList.Count-1; i >= 0 ; i--)
                {
                    iItemHeight = 100;
                    string sValue = "";
                    
                    string sTempItem = m_cFB_Info.In_ItemNameList[i];
                    string sItem = sTempItem;
                    if (sItem.Contains('.'))
                        sItem = sItem.Split('.')[1];

                    if (sItem.Equals("EN"))
                    {
                        graphics.DrawString(sItem, fontItem, new SolidBrush(Color.Black), new RectangleF(point.X - 20, 45, nWrapBoxWidth / 2, nWrapBoxHeight), stringFormatItem);
                        graphics.DrawLine(m_pen, point.X - 50, 50, point.X - 20, 50);
                    }
                    else
                    {
                        if (cFB_Info.DicItem != null && cFB_Info.DicItem.ContainsKey(sTempItem) && cFB_Info.DicItem[sTempItem] != "")
                        {
                            sValue = cFB_Info.DicItem[sTempItem];

                            if (sValue.Contains("SubLogic"))
                            {
                                string[] saValue = sValue.Split(';'); //ex) SubLogic_0;2 형태로 SubLogic의 RowCount 표시

                                if (saValue.Length > 1)
                                {
                                    int iLength = int.Parse(saValue[1]);

                                    int iPreItemHeight = iItemHeight;
                                    iItemHeight = iLength * 100;
                                    graphics.DrawLine(m_pen, point.X - 50, iLineHeight - iPreItemHeight, point.X - 50, iLineHeight - iItemHeight);
                                }
                            }
                        }

                        iHeight -= iItemHeight;
                        iLineHeight -= iItemHeight;

                        if (sValue != "" && !sValue.Contains("SubLogic"))
                        {
                            stringFormatItem.Alignment = StringAlignment.Far;
                            graphics.DrawString(sValue, new Font(font.SystemFontName, (int)(0.9 * font.Size), FontStyle.Bold),
                                                new SolidBrush(Color.Black), new RectangleF(point.X - 360, iHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormatItem);
                        }

                        stringFormatItem.Alignment = StringAlignment.Near;
                        graphics.DrawString(sItem, fontItem, new SolidBrush(Color.Black), new RectangleF(point.X - 20, iHeight, nWrapBoxWidth / 2, nWrapBoxHeight), stringFormatItem);
                        graphics.DrawLine(m_pen, point.X - 50, iLineHeight, point.X - 20, iLineHeight);
                    }
                }

                // OutItemS
                iHeight = 45;
                iLineHeight =  50;
                stringFormatItem.Alignment = StringAlignment.Far;
                int iOutItemHeight = (m_cFBCommon.FBHeight - 100) / (m_cFB_Info.Out_ItemNameList.Count + 1);

                foreach (string sTempItem in cFB_Info.Out_ItemNameList)
                {
                    string sItem = sTempItem;
                    if (sItem.Contains('.'))
                        sItem = sItem.Split('.')[1];

                    if (sItem.Contains("ENO"))
                    {
                        graphics.DrawLine(m_pen, point.X + 220, iLineHeight, point.X + 230, iLineHeight);
                        graphics.DrawString(sItem, fontItem, new SolidBrush(Color.Black), new RectangleF(point.X - 85, iHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormatItem);
                        iHeight += 100;
                        iLineHeight += 100;
                    }
                    else
                    {
                        if (cFB_Info.DicItem != null && cFB_Info.DicItem.ContainsKey(sTempItem) && cFB_Info.DicItem[sTempItem] != "")
                        {
                            if (cFB_Info.DicItem[sTempItem] == cFB_Info.MainCoil.StepIndex.ToString())
                            {
                                graphics.DrawLine(m_pen, point.X + 230, iLineHeight, point.X + 350, iLineHeight);
                                graphics.DrawLine(m_pen, point.X + 350, iLineHeight, point.X + 350, 150);
                                if(cFB_Info.ContactS.Count > 0)
                                    graphics.DrawLine(m_pen, point.X + 350, 150, point.X + 550, 150);
                            }
                        }
                        
                        graphics.DrawLine(m_pen, point.X + 220, iLineHeight, point.X + 230, iLineHeight);
                        graphics.DrawString(sItem, fontItem, new SolidBrush(Color.Black), new RectangleF(point.X - 85, iHeight, nWrapBoxWidth, nWrapBoxHeight), stringFormatItem);

                        if (m_cFB_Info.In_ItemNameList.Count < m_cFB_Info.Out_ItemNameList.Count)
                        {
                            iHeight += iOutItemHeight;
                            iLineHeight += iOutItemHeight;
                        }
                        else
                        {
                            iHeight += 100;
                            iLineHeight += 100;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private void Update()
        {
            if (m_cFB_Info == null) { return; }

            ClearResources();
            FBCommon();
        }

        private void ClearResources()
        {
            // Dont clear !!, because if we use clear, it means we clear up the previous reference static variable from MELSECContactOpen, MELSECContactClose, etc ...
            // So, just assign a new empty
            m_cVertexS = new CVertexS();
            m_cEdgeS = new CEdgeS();
            m_cPolygonS = new CPolygonS();
            m_cBoundingBoxeS = new CVertexS();
            m_cBezierS = new CBezierS();
            m_hashExcludedPolygons = new HashSet<int>();
            //m_nColumnOccupied = 1;
        }

        private void FBCommon()
        {
            m_cFBCommon = new CFBCommon(m_cFB_Info.RowOccupied);

            m_cVertexS = m_cFBCommon.Vertexs;
            m_cEdgeS = m_cFBCommon.Edges;
            m_cPolygonS = m_cFBCommon.Polygons;
            m_cBoundingBoxeS = m_cFBCommon.BoundingBoxes;
            m_hashExcludedPolygons = m_cFBCommon.ExcludedPolygons;
        }

        #endregion

        #region Public Methods

        public CommonFuntionBlock()
        {

        }

        #endregion
    }
}
