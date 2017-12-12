using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using UDM.UDLImport;
using DevExpress.XtraSplashScreen;
using UDM.Common;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList.Nodes;
using TrackerCommon;

namespace UDMLadderTracker
{
    public partial class FrmModel : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Member Variables

        private List<string> m_lstAddressFilter = new List<string>();
        private List<string> m_lstDescriptionFilter = new List<string>();
        protected bool m_bDragDropReady = false;
        protected bool m_bFirstSetting = false;
        #endregion


        #region Initialize

        public FrmModel()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        public bool IsSaveExcute { get; set; }

        public bool IsChangePlcList { get; set; }

        #endregion


        #region Private Method

        private string GetUserInputText(string sTitle, string sMessage)
        {
            FrmInputDialog dlgInput = new FrmInputDialog(sTitle, sMessage);
            dlgInput.ShowDialog();

            if (dlgInput.DialogResult == DialogResult.Cancel)
                return string.Empty;

            string sName = dlgInput.InputText;

            dlgInput.Dispose();
            dlgInput = null;

            return sName;
        }

        public CTagS GetSelectedTagS()
        {
            CTagS cTagS = new CTagS();

            int[] iaRowIndex = grvTotalTagS.GetSelectedRows();
            if (iaRowIndex != null)
            {
                CTag cTag;
                for (int i = 0; i < iaRowIndex.Length; i++)
                {
                    cTag = (CTag)grvTotalTagS.GetRow(iaRowIndex[i]);
                    if (cTag != null)
                        cTagS.Add(cTag.Key, cTag);
                }
            }

            return cTagS;
        }

        private void CreateTreeNodeS()
        {
            TreeListNode trnNode = null;
            CPlcConfig cPLCConfig = null;

            if (CMultiProject.PlcConfigS.Count == 0)
                return;

            RemoveTreeNodeS();

            foreach (var who in CMultiProject.PlcConfigS)
            {
                cPLCConfig = who.Value;
                trnNode = exTreeList.Nodes.Add(new object[] {CMultiProject.PlcLogicDataS[who.Key].PlcName, cPLCConfig.PLCMaker, cPLCConfig.CollectType});

                trnNode.ImageIndex = 0;
                trnNode.SelectImageIndex = 0;
                trnNode.Tag = cPLCConfig;
            }
        }

        private void RemoveTreeNodeS()
        {
            exTreeList.Nodes.Clear();
        }

        private void RemoveTreeNode(TreeListNode trnNode)
        {
            CPlcConfig cPLCConfig = null;
            string sPLCID = string.Empty;

            exTreeList.Nodes.Remove(trnNode);

            cPLCConfig = (CPlcConfig) trnNode.Tag;
            if (cPLCConfig == null)
                return;

            sPLCID = cPLCConfig.PlcID;

            CMultiProject.PlcLogicDataS.Remove(sPLCID);
            CMultiProject.PlcConfigS.Remove(sPLCID);
            List<string> lstRemovePlcProcess = new List<string>();

            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                if(cProcess.PlcLogicDataS.ContainsKey(sPLCID))
                    lstRemovePlcProcess.Add(cProcess.Name);
            }

            foreach (string sProcessKey in lstRemovePlcProcess)
                CMultiProject.PlcProcS.Remove(sProcessKey);

            List<CTag> lstRemoveRobotTag = CMultiProject.ProjectInfo.RobotCycleTagS.Values.Where(b=>b.Creator == sPLCID).ToList();
            foreach (CTag tag in lstRemoveRobotTag)
                CMultiProject.ProjectInfo.RobotCycleTagS.Remove(tag.Key);

            List<CUserDevice> lstRemoveUserDevice = CMultiProject.UserDeviceS.Values.Where(b => b.Tag.Creator == sPLCID).ToList();

            foreach (CUserDevice dev in lstRemoveUserDevice)
                CMultiProject.UserDeviceS.Remove(dev.Tag.Key);

            ucProcessTree.Clear();
            ucProcessTree.ShowTree();

            CMultiProject.TotalTagS.Clear();
            foreach (var who in CMultiProject.PlcLogicDataS)
            {
                CMultiProject.TotalTagS.AddRange(who.Value.TagS);
            }
            grdTotalTagS.DataSource = null;
            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            grdRobotCycle.DataSource = null;
            grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
            grdRobotCycle.RefreshDataSource();

            grdUserAll.DataSource = null;
            grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
            grdUserAll.RefreshDataSource();
        }

        private void ConfigOPC(CPlcConfig cConfig)
        {
            FrmOPCProperty frmProperty = new FrmOPCProperty();
            frmProperty.Editable = true;
            frmProperty.OPCConfig = cConfig.OPCConfig;
            frmProperty.ShowDialog();
        }

        private void ConfigMelsec(CPlcConfig cConfig)
        {
            FrmDDEAProperty frmMelsec = new FrmDDEAProperty(cConfig.MelsecConfig);
            frmMelsec.ShowDialog();
            if (frmMelsec.IsDataChange)
                cConfig.MelsecConfig = frmMelsec.Config;

        }

        private void ConfigLs(CPlcConfig cConfig)
        {
            FrmLsPlcConfig frmLs = new FrmLsPlcConfig(cConfig.LsConfig);
            frmLs.ShowDialog();
            if (frmLs.ChangeConfig)
            {
                frmLs.LsConfig.Use = true;
                cConfig.LsConfig = frmLs.LsConfig;
            }

        }

        private void ucProcessTree_ProcessDoubleClicked(object sender, string sProcessKey)
        {

        }

        private void UpdateProcessTree()
        {
            SplashScreenManager.ShowDefaultWaitForm();
            {
                ucProcessTree.Clear();

                if (CMultiProject.PlcProcS.Count != 0)
                {
                    ucProcessTree.ShowTree();
                    TabTable.SelectedTabPage = tpProcess;
                }
            }
            SplashScreenManager.CloseDefaultSplashScreen();
        }

        private void InitFilter()
        {
            List<string> lstFilter = new List<string>();

            lstFilter.Add("이상");
            lstFilter.Add("NG");
            lstFilter.Add("에러");
            lstFilter.Add("Error");
            lstFilter.Add("Err");
            lstFilter.Add("안전");
            lstFilter.Add("비상");
            lstFilter.Add("Warning");
            lstFilter.Add("Alarm");
            lstFilter.Add("OFF");
            lstFilter.Add("Off");

            CMultiProject.AbnormalFilter = lstFilter;
        }


        #endregion


        #region Public Method

        #endregion


        #region Form Event

        private void FrmModel_Load(object sender, EventArgs e)
        {
            if (CMultiProject.ProjectName == "")
            {
                string sName = GetUserInputText("Input Project Name", "Please enter text below...");
                if (sName != "")
                {
                    CMultiProject.Create(sName);
                    btnAddPlc_ItemClick(null, null);
                }
                else
                {
                    MessageBox.Show("Name 입력이 없습니다. 창을 닫습니다.", "UDM Tracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            if (CMultiProject.PatternItemStep == EMMonitorModeType.None)
                m_bFirstSetting = true;

            CreateTreeNodeS();
            InitFilter();

            if (CMultiProject.PlcProcS.Count != 0)
            {
                ucProcessTree.UEventProcessDoubleClicked += ucProcessTree_ProcessDoubleClicked;
                ucProcessTree.ShowTree();
            }

            grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
            grdRobotCycle.RefreshDataSource();

            grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
            grdTotalTagS.RefreshDataSource();

            grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
            grdUserAll.RefreshDataSource();
            IsSaveExcute = false;
            IsChangePlcList = false;
        }

        private void FrmModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool bOK = false;
            foreach (CPlcProc cProcess in CMultiProject.PlcProcS.Values)
            {
                if (cProcess.SelectRecipeWord != null)
                    bOK = true;
                else
                {
                    bOK = false;
                    break;
                }
            }

            if (!bOK)
            {
                DialogResult dlgResult = MessageBox.Show("모든 공정의 Cycle Signal 접점이 설정되지 않았습니다. 이대로 종료하시겠습니까?", "UDM Tracker Simple", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void btnClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sName = GetUserInputText("Input Project Name", "Please enter text below...");
            if (sName != "")
            {
                CMultiProject.Create(sName);
                CMultiProject.ProjectPath = "";
                btnAddPlc_ItemClick(null, null);
                ucProcessTree.Clear();
                grdUserAll.DataSource = null;
                grdUserAll.RefreshDataSource();

                grdRobotCycle.DataSource = null;
                grdRobotCycle.RefreshDataSource();
                IsChangePlcList = true;
            }
            else
            {
                MessageBox.Show("취소되었습니다.", "UDM Tracker Simple", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFilterApply_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnAddPlc_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPlcSetWizard frmWizard = new FrmPlcSetWizard();
            frmWizard.ShowDialog();

            if (CMultiProject.PlcLogicDataS.Count > 0 && frmWizard.ChangeFlag)
            {
                CMultiProject.TotalTagS.Clear();
                CMultiProject.PlcIDList.Clear();
                foreach (var who in CMultiProject.PlcLogicDataS)
                {
                    CMultiProject.TotalTagS.AddRange(who.Value.TagS);
                    CMultiProject.PlcIDList.Add(who.Key);
                }
                grdTotalTagS.DataSource = CMultiProject.TotalTagS.Values.ToList();
                grdTotalTagS.RefreshDataSource();
                                
                //if (CMultiProject.ProjectPath == "")
                //{
                //    SaveFileDialog dlgSaveFile = new SaveFileDialog();
                //    dlgSaveFile.Filter = "*.umpp|*.umpp";
                //    DialogResult dlgResult = dlgSaveFile.ShowDialog();
                //    if (dlgResult == System.Windows.Forms.DialogResult.Cancel) return;

                //    CMultiProject.ProjectPath = dlgSaveFile.FileName;
                //}
                
                //PLC Node 추가
                if (CMultiProject.PlcConfigS.Count != 0)
                {
                    CreateTreeNodeS();
                    TabTable.SelectedTabPage = tpPLC;
                }
                IsSaveExcute = true;
                IsChangePlcList = true;
            }

        }

        private void grvUserAll_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void grdUserAll_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdUserAll_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                if (cTagS != null)
                {
                    List<CUserDevice> lstViewData = new List<CUserDevice>();
                    if (grdUserAll.DataSource != null)
                        lstViewData = (List<CUserDevice>)grdUserAll.DataSource;

                    CTag cTag;
                    for (int i = 0; i < cTagS.Count; i++)
                    {
                        cTag = cTagS[i];

                        if (CMultiProject.UserDeviceS.ContainsKey(cTag.Key) == false)
                        {
                            CUserDevice cUser = new CUserDevice();
                            cUser.Tag = cTag;

                            CMultiProject.UserDeviceS.Add(cTag.Key, cUser);
                            lstViewData.Add(cUser);
                        }
                    }
                    grdUserAll.DataSource = lstViewData;
                    grdUserAll.RefreshDataSource();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                }
            }
        }

        private void grvUserAll_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
            if (cUser == null) return;

            if (e.Column.FieldName == "MainShow")
            {
                if (cUser.DataType != EMDataType.Bool)
                {
                    if (cUser.DetailViewShow != (bool)e.Value)
                        cUser.DetailViewShow = (bool)e.Value;
                }
            }
            else if (e.Column.FieldName == "Name")
            {
                cUser.Name = (string)e.Value;
            }
        }

        private void grvUserAll_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MainShow")
            {
                CUserDevice cUser = (CUserDevice)grvUserAll.GetRow(e.RowHandle);
                if (cUser == null) return;
                if (cUser.DataType == EMDataType.Bool)
                    cUser.DetailViewShow = false;
            }
        }

        private void grdRobotCycle_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grdRobotCycle_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                if (cTagS != null)
                {
                    if (CMultiProject.ProjectInfo.RobotCycleTagS == null)
                        CMultiProject.ProjectInfo.RobotCycleTagS = new CTagS();
                    CMultiProject.ProjectInfo.RobotCycleTagS.AddRange(cTagS);

                    grdRobotCycle.DataSource = null;
                    grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
                    grdRobotCycle.RefreshDataSource();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                }
            }
        }

        private void grvRobotCycle_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void mnuDeleteSymbolS_Click(object sender, EventArgs e)
        {
            if (tabUserSet.SelectedTabPageIndex == 0)
            {
                int[] iaRowIndex = grvUserAll.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CUserDevice cDevice = (CUserDevice) grvUserAll.GetRow(iaRowIndex[i]);
                        if (CMultiProject.UserDeviceS.ContainsKey(cDevice.Tag.Key))
                            CMultiProject.UserDeviceS.Remove(cDevice.Tag.Key);
                    }
                    grdUserAll.DataSource = null;
                    grdUserAll.DataSource = CMultiProject.UserDeviceS.Values.ToList();
                    grdUserAll.RefreshDataSource();
                }
            }
            else
            {
                int[] iaRowIndex = grvRobotCycle.GetSelectedRows();
                if (iaRowIndex != null)
                {
                    for (int i = 0; i < iaRowIndex.Length; i++)
                    {
                        CTag cRobotTag = (CTag)grvRobotCycle.GetRow(iaRowIndex[i]);
                        if (CMultiProject.ProjectInfo.RobotCycleTagS.ContainsKey(cRobotTag.Key))
                            CMultiProject.ProjectInfo.RobotCycleTagS.Remove(cRobotTag.Key);

                    }
                    grdRobotCycle.DataSource = null;
                    grdRobotCycle.DataSource = CMultiProject.ProjectInfo.RobotCycleTagS.Values.ToList();
                    grdRobotCycle.RefreshDataSource();
                }
            }
        }

        private void grvTotalTagS_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = e.RowHandle.ToString();
            }
        }

        private void grvTotalTagS_ShownEditor(object sender, EventArgs e)
        {
            if (grvTotalTagS.FocusedColumn == colAddress)
            {
                TextEdit edit = grvTotalTagS.ActiveEditor as TextEdit;
                edit.Properties.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void grvTotalTagS_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && m_bDragDropReady)
            {
                CTagS cTagS = GetSelectedTagS();
                if (cTagS == null)
                {
                    m_bDragDropReady = false;
                    return;
                }

                grdTotalTagS.DoDragDrop(cTagS, DragDropEffects.Move);
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                m_bDragDropReady = false;
            }
        }

        private void grvTotalTagS_MouseDown(object sender, MouseEventArgs e)
        {
            m_bDragDropReady = false;

            GridView exView = sender as GridView;
            GridHitInfo exHitInfo = exView.CalcHitInfo(new Point(e.X, e.Y));
            if (exHitInfo.InColumnPanel)
                return;

            if (Control.ModifierKeys != Keys.None)
                return;

            m_bDragDropReady = true;
        }

        private void grvTotalTagS_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            /*if (e.Column == colGroup)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].GroupKey + ";";

                e.Value = sText;
            }
            else if (e.Column == colGroupRoleType)
            {
                if (e.Row == null)
                    return;

                string sText = "";

                CTag cTag = (CTag)e.Row;
                for (int i = 0; i < cTag.GroupRoleS.Count; i++)
                    sText += cTag.GroupRoleS[i].RoleType.ToString() + ";";

                e.Value = sText;
            }
            else if (e.Column == colStepRoleType)
            {
                if (e.Row == null)
                    return;

                CTag cTag = (CTag)e.Row;
                if (cTag.IsEndContact())
                    e.Value = "Contact";
                else
                    e.Value = "Coil";
            }*/
        }

        private void grdTotalTagS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void grdTotalTagS_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(CTagS)))
            {
                e.Effect = DragDropEffects.Move;

                Point pntClient = this.PointToClient(new Point(e.X, e.Y));
                CTagS cTagS = (CTagS)e.Data.GetData(typeof(CTagS));
                if (cTagS != null)
                {
                    List<CTag> lstViewData = (List<CTag>)grdTotalTagS.DataSource;

                    CTag cTag;
                    for (int i = 0; i < cTagS.Count; i++)
                    {
                        cTag = cTagS[i];
                        if (CMultiProject.TotalTagS.ContainsKey(cTag.Key) == false)
                        {
                            CMultiProject.TotalTagS.Add(cTag.Key, cTag);
                            lstViewData.Add(cTag);
                        }
                    }

                    grdTotalTagS.RefreshDataSource();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Can't assign this node!!");
                }
            }
        }

        #endregion

        private void exTreeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null)
            {
                CPlcConfig cConfig = (CPlcConfig) trnNode.Tag;

                if (cConfig != null)
                {
                    if (cConfig.CollectType == EMCollectType.DDEA)
                        ConfigMelsec(cConfig);
                    else if (cConfig.CollectType == EMCollectType.LSDDE)
                        ConfigLs(cConfig);
                    else if (cConfig.CollectType == EMCollectType.OPC)
                        ConfigOPC(cConfig);
                }
            }
        }

        private void mnuPLCChangeConfig_Click(object sender, EventArgs e)
        {
            exTreeList_MouseDoubleClick(null, null);
        }

        private void mnuDeletePLC_Click(object sender, EventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;
            if (trnNode != null)
            {
                RemoveTreeNode(trnNode);
            }
        }

        private void mnuRenamePLC_Click(object sender, EventArgs e)
        {
            TreeListNode trnNode = exTreeList.FocusedNode;
            string sPLCID = string.Empty;
            string sNewPLCName = string.Empty;

            if (trnNode != null)
            {
                CPlcConfig cConfig = (CPlcConfig) trnNode.Tag;
                sPLCID = cConfig.PlcID;

                if (cConfig != null)
                {
                    sNewPLCName = GetUserInputText("Input PLC Name", "Please enter text below...");

                    if (sNewPLCName != string.Empty)
                    {
                        CMultiProject.PlcLogicDataS[sPLCID].PlcName = sNewPLCName;
                        trnNode.SetValue(colPLCName, sNewPLCName);
                    }
                }
            }
        }

        private void btnRecipeSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCarType frmRecipe = new FrmCarType();
            frmRecipe.ShowDialog();
        }

        private void btnProcessAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
                FrmInputProcess frmProcess = new FrmInputProcess();
                frmProcess.ShowDialog();

                UpdateProcessTree();
        }

        private void grvTotalTagS_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            //GridHitInfo info = view.CalcHitInfo(pt);
            //object oData = view.GetRow(info.RowHandle);
            //if (oData == null) return;
            //if (oData.GetType() != typeof(CTag)) return;
            //CTag cTag = (CTag)oData;

            //if (cTag == null)
            //    return;

            //FrmLadderView frmLadder = new FrmLadderView();
            //frmLadder.MasterTag = cTag;
            //frmLadder.LogicData = CMultiProject.PlcLogicDataS[cTag.Creator];
            //frmLadder.TopMost = true;
            //frmLadder.Show();
        }
    }
}
