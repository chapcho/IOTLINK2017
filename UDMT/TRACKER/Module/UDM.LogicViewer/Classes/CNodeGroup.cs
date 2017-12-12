using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using DevComponents.Tree;
using UDM.UDLImport;

namespace UDM.LogicViewer
{
    public class CNodeGroup
    {
        #region Member Variables

        public delegate void UEventHandlerExpand(Node selectNode);
        public event UEventHandlerExpand UEventExpand;
        private ElementStyle m_styleBlock = new ElementStyle();
        private Node m_selectNode = null;

        #endregion

        #region Initalize/Dispose

        public CNodeGroup(Node selectNode, string strGroup)
        {
            SetDefaultNodeStyle();

            m_selectNode = selectNode;
            m_selectNode.Text = strGroup;
            m_selectNode.Style = m_styleBlock;
            m_selectNode.ParentConnector = new DevComponents.Tree.NodeConnector();
            m_selectNode.ParentConnector.LineWidth = EWidthBlock.Border;

            if (strGroup.Contains(EILGroup.C.ToString()))
            {
                m_selectNode.Style.BackColor = Color.AliceBlue;
                m_selectNode.Style.BackColor2 = Color.AliceBlue;
            }
            else if (strGroup.Contains(EILGroup.O.ToString()))
            {
                m_selectNode.Style.BackColor = Color.LightGreen;
                m_selectNode.Style.BackColor2 = Color.LightGreen;
            }
            else if (strGroup.Contains(EILGroup.M.ToString()))
            {
                m_selectNode.Style.BackColor = Color.LightPink;
                m_selectNode.Style.BackColor2 = Color.LightPink;
            }

            m_selectNode.NodeDoubleClick += new System.EventHandler(this.SelectNode_NodeDoubleClick);
            m_selectNode.Disposed += new EventHandler(SelectNode_Disposed);
        }

        #endregion

        #region Public Properties



       
        #endregion

        #region Public Methods

        public void SelectNode_Disposed(object sender, EventArgs e)
        {
            if (m_selectNode.Tag != null)
                m_selectNode.Tag = null;
        }

        #endregion

        #region Private Methods

        private void SelectNode_NodeDoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (UEventExpand != null)
                {
                    UEventExpand(m_selectNode);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message + "\t" + System.Reflection.MethodBase.GetCurrentMethod().Name); error.Data.Clear();
            }
        }

        private void SetDefaultNodeStyle()
        {
            m_styleBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            m_styleBlock.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            m_styleBlock.BackColorGradientAngle = 90;
            m_styleBlock.BorderBottom = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderBottomWidth = 1;
            m_styleBlock.BorderColor = System.Drawing.Color.DarkGray;
            m_styleBlock.BorderLeft = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderLeftWidth = 1;
            m_styleBlock.BorderRight = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderRightWidth = 1;
            m_styleBlock.BorderTop = DevComponents.Tree.eStyleBorderType.Solid;
            m_styleBlock.BorderTopWidth = 1;
            m_styleBlock.CornerDiameter = 4;
            m_styleBlock.CornerType = DevComponents.Tree.eCornerType.Rounded;
            m_styleBlock.Description = "Blue";
            m_styleBlock.Name = "Default";
            m_styleBlock.PaddingBottom = 2;
            m_styleBlock.PaddingLeft = 2;
            m_styleBlock.PaddingRight = 2;
            m_styleBlock.PaddingTop = 2;
            m_styleBlock.TextColor = System.Drawing.Color.Black;
        }

        #endregion
    }
}
