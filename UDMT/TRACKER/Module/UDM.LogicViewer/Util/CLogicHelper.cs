using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

using UDM.UDLImport;
using System.ComponentModel;
using DevComponents.Tree;
using UDM.Common;

namespace UDM.LogicViewer
{

    public class EWidthBlock
    {
        public static int Border = 1;
        public static int BorderBase = 5;
    }

    public class CLogicHelper
    {
        #region Members


        #endregion

        #region Initialize/Dispose


        #endregion

        #region Public interface

     
        #endregion

        #region Public Methods

        public static void UpdateMonitorCallBack(Node treeNode)
        {
            if (treeNode.Parent == null)
            {
                UpdateMonitorGroup(treeNode);
                UpdateMonitorCoil(treeNode);
            }

            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                UpdateMonitorGroup(treeNode.Nodes[n]);
                UpdateMonitorCoil(treeNode.Nodes[n]);

                UpdateMonitorCallBack(treeNode.Nodes[n]);
            }
        }

        public static void SetTimeShowCallback(Node treeNode, bool bShow)
        {
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                if (treeNode.Nodes[n].Tag is CNodeBlock)
                {
                    if (bShow)
                        ((CNodeBlock)treeNode.Nodes[n].Tag).SetTimeOn();
                    else
                        ((CNodeBlock)treeNode.Nodes[n].Tag).SetTimeOff();
                }

                SetTimeShowCallback(treeNode.Nodes[n], bShow);
            }
        }


        public static void MakeStepCallback(Node treeNode, CStepS cStepS)
        {
            CStep cStep;
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                if (treeNode.Nodes[n].Tag is CNodeCoil)
                {
                    cStep = ((CNodeCoil)treeNode.Nodes[n].Tag).LDRung.Step;
                    cStepS.Add(cStep.Key, cStep);
                }

                MakeStepCallback(treeNode.Nodes[n], cStepS);
            }
        }

        public static void DrawMinMode(Node treeNode,bool bMin)
        {
            if (treeNode.Tag is CNodeCoil)
                ((CNodeCoil)treeNode.Tag).SetMinMode(bMin);
            SetCoilMinModeCallback(treeNode, bMin);
        }


        public static int GetNodeLevel(Node node)
        {
            string sText = EILGroup.COIL.ToString();
            if (!node.FullPath.Contains(sText))
                return 0;

            string[] delimiter = new string[] { sText };
            int nLevel = node.FullPath.Split(delimiter, StringSplitOptions.None).Length - 1;
            return nLevel;
        }

        public string GetSelectNodeTime(Node node)
        {
            string sResult = string.Empty;
            //<font size=\"+0\"><span width=\"55\">{0}</span><span width=\"220\">{1}</span><span width=\"30\">{2}</span><span width=\"15\">{3}</span><span width=\"150\">{4}</span></font>
            string[] split = node.SelectedCell.Text.Split('<', '>');
            sResult = split[24];
            return sResult;
        }

        public string GetSelectNodeValue(Node node)
        {
            string sResult = string.Empty;
            string[] split = node.SelectedCell.Text.Split('<', '>');
            sResult = split[16];
            return sResult;
        }

        public static string GetBaseTabName(CLDRung cILRung)
        {
            string strBase = string.Format("{0}\r\n{1}"
                    , cILRung.CoilAddress
                    , cILRung.CoilSymbol
                    );

            if(cILRung.CoilAddress == string.Empty)
                strBase = string.Format("{0}\r\n{1}", cILRung.CoilCommand, cILRung.Step.Address);

            return strBase;
        }

        public static string GetSymbolIndent(string strSymbol)
        {
            string strIndent = string.Empty;
            int nIndent = 0;

            if (strSymbol.Contains(' '))
            {
                strSymbol = strSymbol.Replace("   ", " ").Replace("  ", " ").Replace("  ", " ");
                foreach (string strSplit in strSymbol.Split(' '))
                {
                    if (nIndent == 1)
                    {
                        strIndent += strSplit + "\r\n";
                    }
                    else
                        strIndent += strSplit + " ";

                    nIndent++;
                }
            }
            else
                strIndent = strSymbol;

            return strIndent.TrimEnd(' ');
        }

        public static string GetSymbolHtml(string strSymbol)
        {
            string strSymbolHtml = strSymbol.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");

            return strSymbolHtml;
        }

        

        public static string GetSpanAddress(string sAddress)
        {
            string sSpanAddress = string.Empty;
            if (sAddress.Contains("Z"))
            {
                if (sAddress.Contains("ZR"))
                {
                    sSpanAddress = sAddress.Replace("ZR", string.Empty);
                    sSpanAddress = string.Format("ZR{0}\r\nZ{1}", sSpanAddress.Split('Z')[0], sSpanAddress.Split('Z')[1]);
                }
                else if (sAddress.Split('Z').Length == 2)
                    sSpanAddress = string.Format("{0}\r\nZ{1}", sAddress.Split('Z')[0], sAddress.Split('Z')[1]);
                else
                    sSpanAddress = sAddress;
            }
            else if(sAddress.Contains("[Z"))
            {
                string sIndex = sAddress.Split('Z')[1].Replace("]", string.Empty);

                if(sAddress.Contains("."))
                {
                    string sBitAddress = sAddress.Split('.')[1];
                    sSpanAddress = string.Format("{0}.{1}\r\n[Z{2}]", sAddress.Split('[')[0], sBitAddress, sIndex);
                }
                else
                    sSpanAddress = string.Format("{0}\r\n[Z{1}]", sAddress.Split('[')[0], sIndex);
            }
            else
                sSpanAddress = sAddress;

            return sSpanAddress;
        }

        public static string GetILConnect(string sOperator)
        {
            if (sOperator == "XIC")
                return "A";
            if (sOperator == "XIO")
                return "B";
            if (sOperator == "XICP")
                return "A↑";
            if (sOperator == "XICF")
                return "A↓";
            if (sOperator == "XIOP")
                return "B↑";
            if (sOperator == "XIOF")
                return "B↓";

            return string.Empty;
        }

        #endregion

        #region private Methods


        private static void SetCoilMinModeCallback(Node treeNode, bool bMin)
        {
            for (int n = 0; n < treeNode.Nodes.Count; n++)
            {
                if (treeNode.Nodes[n].Tag is CNodeCoil)
                {
                    ((CNodeCoil)treeNode.Nodes[n].Tag).SetMinMode(bMin);
                }
                if (treeNode.Nodes[n].Tag is CNodeBlock)
                {
                    ((CNodeBlock)treeNode.Nodes[n].Tag).SetMinMode(bMin);
                }

                SetCoilMinModeCallback(treeNode.Nodes[n], bMin);
            }
        }

        private static void UpdateMonitorGroup(Node treeNode)
        {
            if (treeNode.Tag is CNodeGroup && treeNode.Text == EILGroup.C.ToString())
            {
                bool bOptionOn = true;
                bool bCommonOn = true;
                foreach (Node nodeGroup in treeNode.Nodes)
                {
                    if (nodeGroup.Tag is CNodeGroup
                        && (nodeGroup.Text == EILGroup.O.ToString() || nodeGroup.Text == EILGroup.M.ToString()))
                    {
                        bOptionOn = false;
                        foreach (Node nodeBlock in nodeGroup.Nodes)
                            if (nodeBlock.ParentConnector.LineColor == EColorBlock.ON)
                            {
                                bOptionOn = true;
                                break;
                            }
                        if (bOptionOn)
                            SetParentConnectorColor(nodeGroup, true);
                        else
                            SetParentConnectorColor(nodeGroup, false);
                    }
                    else if (nodeGroup.Tag is CNodeBlock)
                    {
                        if (nodeGroup.ParentConnector.LineColor == EColorBlock.Off)
                            bCommonOn = false;
                    }
                }
                if (bOptionOn && bCommonOn)
                {
                    SetParentConnectorColor(treeNode, true);
                }
                else
                {
                    SetParentConnectorColor(treeNode, false);
                }
            }
        }


        private static void UpdateMonitorCoil(Node treeNode)
        {
            if (treeNode.Tag is CNodeCoil)
            {
                if (((CNodeCoil)treeNode.Tag).CoilOn)
                    SetParentConnectorColor(treeNode, true);
                else
                    SetParentConnectorColor(treeNode, false);
            }
        }

        private static void SetParentConnectorColor(Node treeNode, bool bOn)
        {
            treeNode.Style.BorderWidth = EWidthBlock.Border;

            if (bOn)
            {
                treeNode.ParentConnector.LineColor = EColorBlock.ON;
                treeNode.Style.BorderColor = EColorBlock.ON;
            }
            else
            {
                treeNode.ParentConnector.LineColor = EColorBlock.Off;
                treeNode.Style.BorderColor = EColorBlock.Off;
            }
        }


        #endregion

    }
}
