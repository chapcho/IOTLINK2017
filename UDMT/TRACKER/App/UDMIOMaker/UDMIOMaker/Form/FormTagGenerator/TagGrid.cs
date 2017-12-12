using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Enumeration;
using NewIOMaker.Event;
using NewIOMaker.Form.Form_TagGenerator;
using UDM.Common;
using UDM.UDLImport;

namespace NewIOMaker.Form.FormTagGenerator
{
    /// <summary>
    /// PLC와 HMI Grid를 표현하는 클래스 
    /// exprt시에 hmi menu에 db를 전달해야한다.
    /// </summary>
    /// 
    public partial class TagGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public event delGridIHMIDataConfirm DataInputEvent;
        public event delBackupTimeEvent EventBackupTimeAction;
        public event delLogInputEvent EventLogInput;

        public DataTable HmIdb = new DataTable();
        public DataTable PlCdb = new DataTable();
        public DataTable Keydb = new DataTable();
        public DataTable LogDb = new DataTable();
        public DataTable BackupDb = new DataTable();
        
        protected List<CellColor> CellColors = new List<CellColor>();
        protected CommonMessage CMessage = new CommonMessage();

        protected string AppPath = Application.StartupPath;
        protected string BackupTime = string.Empty;

        protected Color[] Color = new Color[3];
        protected TagMain TagMain;
        protected CTagS CTags;
        protected EMPLCMaker PlcMaker;
        protected EMCommonLogType LogType;
        protected bool EmptyAddressColor = false;


        #region Initialize/Dispose

        public TagGrid(TagMain tagMain)
        {
            InitializeComponent();       
            this.Resize += Control_Tag_Grid_Resize;
            exGridViewPLC.OptionsBehavior.Editable = false;
            exGridViewHMI.OptionsBehavior.Editable = false;

            TagMain = tagMain;
            exGridViewHMI.MouseUp += exGridViewHMI_MouseUp;
            exGridViewPLC.MouseUp += exGridViewPLC_MouseUp;
            ButtonMapping.ItemClick += ButtonMapping_ItemClick;
            ButtonConvertor.ItemClick += ButtonConvertor_ItemClick;
            ButtonInsertor.ItemClick += ButtonInsertor_ItemClick;
            exGridViewPLC.DoubleClick += exGridViewPLC_DoubleClick;
            exGridViewHMI.DoubleClick += exGridViewHMI_DoubleClick;

            TagMain.EventPLCImportClick += _tagMain_EventPLCImportClick;
            TagMain.EventPLCAddClick += _tagMain_EventPLCAddClick;
            TagMain.EventHMIImportClick += _tagMain_EventHMIImportClick;
            TagMain.EventHMIExportAllClick += _tagMain_EventHMIExportAllClick;
            TagMain.EventHMIExportPartClick += _tagMain_EventHMIExportPartClick;
            TagMain.EventColorMappingClick += _tagMain_EventColorMappingClick;
            TagMain.EventColorConvertingClick += _tagMain_EventColorConvertingClick;
            TagMain.EventColorInsertingClick += _tagMain_EventColorInsertingClick;
            TagMain.EventOpenSaveClick += _tagMain_EventOpenSaveClick;
            TagMain.EventNewPLCClick += _tagMain_EventNewPLCClick;
            TagMain.EventNewHMIClick += _tagMain_EventNewHMIClick;
            TagMain.EventFilterClick += _tagMain_EventFilterClick;
            TagMain.EventEditerClick += _tagMain_EventEditerClick;
            TagMain.EventFilterGellayClick += _tagMain_EventFilterGellayClick;
            TagMain.EventEditerGellayClick += _tagMain_EventEditerGellayClick;
            TagMain.EventKeyUpdate += _tagMain_EventKeyUpdate;
            TagMain.EventBackCallAlarm += _tagMain_EventBackCallAlarm;
            TagMain.EventBackupBtnClick += _tagMain_EventBackupBtnClick;

            btnAlarm.ItemClick += btnAlarm_ItemClick;
            btnAlarmView.ItemClick += btnAlarmView_ItemClick;
            groupPLC.CustomButtonChecked += groupPLC_CustomButtonChecked;
            groupPLC.CustomButtonUnchecked += groupPLC_CustomButtonUnchecked;
            groupHMI.CustomButtonChecked += groupHMI_CustomButtonChecked;
            groupHMI.CustomButtonUnchecked += groupHMI_CustomButtonUnchecked;
            exGridViewHMI.RowCellStyle += exGridViewHMI_RowCellStyle;
            exGridViewPLC.RowCellStyle += exGridViewPLC_RowCellStyle;

            groupPLC.ShowCaption = false;
            groupHMI.ShowCaption = false;

            exGridHMI.DataSourceChanged += exGridHMI_DataSourceChanged;
            exGridPLC.DataSourceChanged += exGridPLC_DataSourceChanged;
            exGridViewPLC.OptionsBehavior.Editable = false;
            exGridViewHMI.OptionsBehavior.Editable = false;

            btnEmptyAddressColor.EditValue = System.Drawing.Color.FromArgb(229, 224, 236);

            CommonLogger backuploger = new CommonLogger(EMCommonLogType.Backup);
            BackupDb = backuploger.LogDB;

            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }

        private void btnAlarmView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormAlarm frmAlarm = new FormAlarm(this);
            frmAlarm.Show();
        }

        public void btnAlarm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("on the anvil....  ");
        }

        private void _tagMain_EventBackupBtnClick(object sender)
        {
            DataBackupExcute(sender);
        }

        private void _tagMain_EventBackCallAlarm(object sender)
        {
            DataBackup(sender);
        }

        private void _tagMain_EventKeyUpdate(DataTable KeyDB)
        {
            Keydb = KeyDB;
        }

        private void _tagMain_EventEditerGellayClick(object sender)
        {
            if (sender.ToString() == "PLC")
            {
                if (groupPLC.ShowCaption == true)
                    groupPLC.ShowCaption = false;
                else
                    groupPLC.ShowCaption = true;
                
            }
            else if(sender.ToString() == "HMI")
            {

                if (groupHMI.ShowCaption == true)
                    groupHMI.ShowCaption = false;
                else
                    groupHMI.ShowCaption = true;
            }          
        }

        private void _tagMain_EventFilterGellayClick(object sender)
        {
            if (sender.ToString() == "PLC")
            {
                exGridViewPLC.ClearColumnsFilter();
                exGridViewPLC.ClearGrouping();
                exGridViewPLC.FindFilterText = "";
            }
            else if (sender.ToString() == "HMI")
            {
                exGridViewHMI.ClearColumnsFilter();
                exGridViewHMI.ClearGrouping();
                exGridViewHMI.FindFilterText = "";
            } 
        }

        private void _tagMain_EventEditerClick(object sender)
        {
            
        }

        private void _tagMain_EventFilterClick(object sender)
        {

        }

        private void _tagMain_EventNewHMIClick(object sender)
        {
            try
            {
                exGridHMI.DataSource = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Not HMI Grid Data..." + ex);
            }        

        }

        private void _tagMain_EventNewPLCClick(object sender)
        {
            try
            {
                exGridPLC.DataSource = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not PLC Grid Data..." + ex);
            }
        }

        private void _tagMain_EventOpenSaveClick(string option)
        {
            if (option == "열기")
                OpenData();

            else if (option == "저장")
                SaveData();
        }

        #endregion

        #region Public Properites

        public DataTable HMIdb
        {
            get { return HmIdb; }
            set { HmIdb = value; }
        }

        public DataTable LogDB
        {
            get { return LogDb; }
            set { LogDb = value; }
        }

        #endregion

        #region Event

        private void exGridViewHMI_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if(e.Column.FieldName == "디바이스")
            {
                string Device = View.GetRowCellDisplayText(e.RowHandle, View.Columns["디바이스"]);
                if (Device.StartsWith("HX") || Device.StartsWith("HW"))
                {
                    if (EmptyAddressColor)
                    {
                        e.Appearance.BackColor = System.Drawing.Color.FromArgb(229, 224, 236);
                        e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(204, 193, 217);
                    }
                    else
                        e.Appearance.BackColor2 = System.Drawing.Color.FromArgb(255, 255, 255);
                }

                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["#번호"]);
                if (category == "")
                    return;
                else
                {
                    CellColor color = CellColors.AsEnumerable().FirstOrDefault(r => r.SelectRow == int.Parse(category));
                    if (color == null)
                        return;

                    e.Appearance.BackColor = color.SelectColor;
                }

            }
            
        }

        private void exGridViewPLC_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var View = sender as GridView;
            if (e.Column.FieldName == "Assign")
            {
                var category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Assign"]);
                if (category == "True")
                {
                    e.Appearance.BackColor = System.Drawing.Color.Salmon;
                    e.Appearance.BackColor2 = System.Drawing.Color.SeaShell;
                }
            }
        }

        private void exGridViewHMI_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupHMI.ShowPopup(CurrentPoint);
            }
        }

        private void exGridViewPLC_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupPLC.ShowPopup(CurrentPoint);
            }
        }

        private void _tagMain_EventHMIExportPartClick(string part)
        {
            ExportHmiMode(part);
        }

        private void _tagMain_EventHMIExportAllClick(string part)
        {
            string All = "All";
            ExportHmiMode(All);
        }

        private void _tagMain_EventColorInsertingClick(Color color)
        {
            Color[2] = color;
        }

        private void _tagMain_EventColorConvertingClick(Color color)
        {
            Color[1] = color;
        }

        private void _tagMain_EventColorMappingClick(Color color)
        {
            Color[0] = color;
        }

        private void _tagMain_EventHMIExportAlarmClick(object sender)
        {

        }

        private void _tagMain_EventHMIExportTagClick(object sender)
        {

        }

        private void _tagMain_EventHMIImportClick(object sender)
        {         
            string HMI = EMCommonHMIPrograms.XP_Builder.ToString();
            InputHmiData(sender, HMI);
        }

        private void _tagMain_EventPLCImportClick(object sender)
        {
            string PLC = "Suppored PLC";
            int CPU = 0;

            InputPlcData(PLC, CPU);
        }

        private void _tagMain_EventPLCAddClick(object sender)
        {
            try
            {
                string PLC = "Suppored PLC";
                string data = sender.ToString();

                int CPU = 0;

                string[] dataDetail = data.Split('_');

                CPU = int.Parse(dataDetail[1]);

                InputAddPlcData(PLC, CPU);
            }
            catch(Exception ex)
            {
                Console.WriteLine("exception" + ex);
            }


        }

        private void ButtonInsertor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.Inserting.ToString());
        }

        private void ButtonConvertor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.Converting.ToString());
        }

        private void ButtonMapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.General.ToString());
        }

        private void bntEmptyAddressColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EmptyAddressColor)
            {
                EmptyAddressColor = false;
                exGridViewHMI.LayoutChanged();
            }
            else
            {
                EmptyAddressColor = true;
                exGridViewHMI.LayoutChanged();
            }
        }

        #endregion

        #region Shortcut Register

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                this.ButtonMapping_ItemClick(null, null);
                return true;
            }
            if (keyData == Keys.F6)
            {
                this.ButtonConvertor_ItemClick(null, null);
                return true;
            }
            if (keyData == Keys.F7)
            {
                this.ButtonInsertor_ItemClick(null, null);
                return true;
            }
            if (keyData == Keys.F10)
            {
                this.bntEmptyAddressColor_ItemClick(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Public Methods

        private void ExportHmiMode(string part)
        {
            if ((DataTable)exGridHMI.DataSource==null)
                return;

            var writer = new CommonWriteCSV();
            var dlgSaveFile = new SaveFileDialog {Filter = @"*.csv|*.csv"};
            dlgSaveFile.ShowDialog();

            var path = dlgSaveFile.FileName;
            if (path == string.Empty)
                return;
            
            var dbHmi = new DataTable();
            exGridHMI.RefreshDataSource();
            var tempDt = (DataTable)exGridHMI.DataSource;
            dbHmi = tempDt.Copy();
            HmIdb = tempDt.Copy();

            if (dbHmi.Columns.Contains("태그 타입"))
                dbHmi.Columns.Remove("태그 타입");
            
            if(part.Equals("All"))
            {
                var cAddinfo = new InfoHMI();
                cAddinfo.HMIinfo.Merge(dbHmi, false);
                exGridViewHMI.ExportToCsv(path);
                writer.WriteCSV(path, cAddinfo.HMIinfo);
                exGridViewHMI.Columns.Clear();
                cAddinfo.HMIinfo.Clear();
            }
            else
            {
                var cAddinfo = new InfoHMI();
                cAddinfo.HMIinfo.Merge(HmiSelectGroupListExport(part, dbHmi),false);
                exGridViewHMI.ExportToCsv(path);
                writer.WriteCSV(path, cAddinfo.HMIinfo);
                exGridViewHMI.Columns.Clear();
                cAddinfo.HMIinfo.Clear();
            }
            exGridHMI.DataSource = HmIdb;
            exGridHMI.RefreshDataSource();
        }

        private void InputPlcData(string plc, int cpu)
        {   
            try
            {        
                var udlImport = new CUDLImport();
                udlImport.UDLGenerate();

                
                PlcMaker = udlImport.PLCMaker;

                if (udlImport.GlobalTags.Count == 0)
                {                    
                    CMessage.NotSupport();
                    return;
                }
                // 고유넘버 1부터 시작
                var tagConvertor = new TagsConvertor(udlImport.GlobalTags, cpu, PlcMaker, 1);

                if (tagConvertor.db.Rows.Count != 0)
                {
                    PlCdb.Clear();
                    PlCdb = tagConvertor.db;
                    exGridPLC.DataSource = PlCdb;
                }

                BackupTime = DateTime.Now.ToString();
                BackupAlertControl("PLC Input OK", BackupTime);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Not Selected.." + ex);
            }
          
        }

        private void InputAddPlcData(string plc, int cpu)
        {
            try
            {
                var udlImport = new CUDLImport();
                udlImport.UDLGenerate();
                PlcMaker = udlImport.PLCMaker;

                if (udlImport.GlobalTags.Count == 0)
                {
                    CMessage.NotSupport();
                    return;
                }

                // 고유넘버 Add
                var tagConvertor = new TagsConvertor(udlImport.GlobalTags, cpu, PlcMaker, PlCdb.Rows.Count + 1);

                if (tagConvertor.db.Rows.Count != 0)
                {
                    PlCdb.Merge(tagConvertor.db);
                    exGridPLC.DataSource = PlCdb;
                    BackupTime = DateTime.Now.ToString();
                    BackupAlertControl("ADD PLC Input OK", BackupTime);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("etc Error...."+ ex);
            }
                
        }

        private void InputHmiData(object sender, string hmi)
        {
            try
            {
                var cHmi = new ModuleHMI(hmi);
                HmIdb = cHmi.dbHMI;

                if (HmIdb.Rows.Count != 0)
                {
                    exGridHMI.DataSource = HmIdb;
                    CellColors.Clear();
                    TagMain._HMIdb = HmIdb;
                    DataInputEvent(hmi);
                    BackupTime = DateTime.Now.ToString();
                    BackupAlertControl("HMI Input OK", BackupTime);
                }
            }
            catch(Exception ex)
            {
                //_cMessage.NotSupport();
                Console.WriteLine("Not Supported Type.." + ex);
            }
        }

        private void OpenData()
        {
            try
            {
                var dlgOpenFile = new OpenFileDialog {Filter = "*.Tag|*.Tag"};
                DialogResult dlgResult = dlgOpenFile.ShowDialog();

                if (dlgResult == DialogResult.Cancel)
                    return;
                var sSavePath = dlgOpenFile.FileName;
                dlgOpenFile.Dispose();
                dlgOpenFile = null;

                CommonWaitForm.ShowWaitForm("Opening Project", "Please Wait..");

                var cSerializer = new CommonSerializer();
                var oProject = cSerializer.Read(sSavePath);
                var cProject = (CommonProject)oProject;

                if (cProject == null)
                {
                    MessageBox.Show("Project Load Failed...");
                }

                PlCdb = cProject.PLC;
                HmIdb = cProject.HMI;
                PlcMaker = cProject.PLCType;

                exGridHMI.DataSource = HmIdb;
                exGridPLC.DataSource = PlCdb;
                CellColors = cProject.CellColor;
                Color = cProject.Color;
                CTags = cProject.cTags;
                Keydb = cProject.KeyDB;

                TagMain._HMIdb = HmIdb;
                var HMI = EMCommonHMIPrograms.XP_Builder.ToString();
                DataInputEvent(HMI);
                CommonWaitForm.CloseWaitForm();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Load Failed....");
            }

         
        }

        private void SaveData()
        {
            if (exGridPLC.DataSource == null && exGridHMI.DataSource == null)
                return;

            var cSerializer = new CommonSerializer();
            var cProject = new CommonProject();
            var dlgSaveFile = new SaveFileDialog {Filter = @"*.Tag|*.Tag"};
            bool bSave = false;

            var dlgResult = dlgSaveFile.ShowDialog();
            if (dlgResult == DialogResult.Cancel)
                return;

            cProject.PLC = (DataTable)exGridPLC.DataSource;
            cProject.HMI = (DataTable)exGridHMI.DataSource;
            cProject.CellColor = CellColors;
            cProject.cTags = CTags;
            cProject.Color = Color;
            cProject.KeyDB = Keydb;
            cProject.PLCType = PlcMaker;
            
            var sSavePath = dlgSaveFile.FileName;
            var sSplit = sSavePath.Split('\\');
            var sSavePath2 = "";
            for (int i = 0; i < sSplit.Length - 1; i++)
                sSavePath2 += sSplit[i] + "\\";
            if (sSavePath != "")
            {
                cSerializer.Write(sSavePath, cProject);
                bSave = true;
            }

            cSerializer = null;
            dlgSaveFile = null;
           
            CMessage.SaveOK(bSave);
        }

        #region etc

        private void Control_Tag_Grid_Resize(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = splitContainerControl1.Width / 2;
        }

        private void exGridViewHMI_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                exGridViewHMI.FocusedColumn.BestFit();
            }
            catch(Exception ex)
            {
                Console.WriteLine("BestFit Exception.." + ex);
            }
        }

        private void exGridViewPLC_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                exGridViewPLC.FocusedColumn.BestFit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("BestFit Exception.." + ex);
            }
        }

        public DataTable HmiSelectGroupListExport(string sSelectGruop, DataTable m_dbTableHMI)
        {
            var HMISelect = new DataTable();
            HMISelect = m_dbTableHMI.Clone();
            for (var i = 0; i < m_dbTableHMI.Rows.Count; i++)
            {
                if (m_dbTableHMI.Rows[i]["그룹"].ToString() == sSelectGruop)
                {
                    HMISelect.ImportRow(m_dbTableHMI.Rows[i]);
                }
            }
            return HMISelect;
        }

        private void groupHMI_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (HmIdb.Columns.Count == 0)
                return;

            switch (e.Button.Properties.Caption)
            {
                case "이름":
                    exGridViewHMI.Columns["이름"].OptionsColumn.AllowEdit = false;
                    break;
                case "타입":
                    exGridViewHMI.Columns["타입"].OptionsColumn.AllowEdit = false;
                    break;
                case "디바이스":
                    exGridViewHMI.Columns["디바이스"].OptionsColumn.AllowEdit = false;
                    break;
                case "설명":
                    exGridViewHMI.Columns["설명"].OptionsColumn.AllowEdit = false;
                    break;
            }
        }

        private void groupHMI_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (HmIdb.Columns.Count == 0)
                return;

            switch (e.Button.Properties.Caption)
            {
                case "이름":
                    exGridViewHMI.Columns["이름"].OptionsColumn.AllowEdit = true;
                    break;
                case "타입":
                    exGridViewHMI.Columns["타입"].OptionsColumn.AllowEdit = true;
                    break;
                case "디바이스":
                    exGridViewHMI.Columns["디바이스"].OptionsColumn.AllowEdit = true;
                    break;
                case "설명":
                    exGridViewHMI.Columns["설명"].OptionsColumn.AllowEdit = true;
                    break;
            }
        }

        private void groupPLC_CustomButtonUnchecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (PlCdb.Columns.Count == 0)
                return;

            switch (e.Button.Properties.Caption)
            {
                case "Assign":
                    exGridViewPLC.Columns["Assign"].OptionsColumn.AllowEdit = false;
                    break;
                case "Comment":
                    exGridViewPLC.Columns["Comment"].OptionsColumn.AllowEdit = false;
                    break;
                case "DataType":
                    exGridViewPLC.Columns["Data Type"].OptionsColumn.AllowEdit = false;
                    break;
                case "Symbol":
                    exGridViewPLC.Columns["Symbol"].OptionsColumn.AllowEdit = false;
                    break;
                case "Address":
                    exGridViewPLC.Columns["Address"].OptionsColumn.AllowEdit = false;
                    break;
            }
        }

        private void groupPLC_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (PlCdb.Columns.Count == 0)
                return;

            switch (e.Button.Properties.Caption)
            {
                case "Assign":
                    exGridViewPLC.Columns["Assign"].OptionsColumn.AllowEdit = true;
                    break;
                case "Comment":
                    exGridViewPLC.Columns["Comment"].OptionsColumn.AllowEdit = true;
                    break;
                case "DataType":
                    exGridViewPLC.Columns["Data Type"].OptionsColumn.AllowEdit = true;
                    break;
                case "Symbol":
                    exGridViewPLC.Columns["Symbol"].OptionsColumn.AllowEdit = true;
                    break;
                case "Address":
                    exGridViewPLC.Columns["Address"].OptionsColumn.AllowEdit = true;
                    break;
            }
        }

        private void exGridPLC_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (exGridViewPLC.RowCount != 0)
                {
                    exGridViewPLC.Columns["Number"].Visible = false;
                    exGridViewPLC.Columns["Logic"].Visible = false;
                }
                    
                exGridViewPLC.OptionsBehavior.Editable = true;
                exGridViewPLC.Columns["Number"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Assign"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Logic"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Group"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Comment"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Data Type"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Address"].OptionsColumn.AllowEdit = false;
                exGridViewPLC.Columns["Symbol"].OptionsColumn.AllowEdit = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void exGridHMI_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                exGridViewHMI.OptionsBehavior.Editable = true;
                exGridViewHMI.Columns["#번호"].OptionsColumn.AllowEdit = false;
                exGridViewHMI.Columns["그룹"].OptionsColumn.AllowEdit = false;
                exGridViewHMI.Columns["이름"].OptionsColumn.AllowEdit = false;
                exGridViewHMI.Columns["타입"].OptionsColumn.AllowEdit = false;
                exGridViewHMI.Columns["디바이스"].OptionsColumn.AllowEdit = false;
                exGridViewHMI.Columns["설명"].OptionsColumn.AllowEdit = false;

                if (exGridViewHMI.RowCount != 0)
                    exGridViewHMI.Columns["Column1"].Visible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Pravate Methods

        protected List<string> GetRealSelectPlcRows()
        {
            var SelcetPLC = exGridViewPLC.GetSelectedRows();
            var PLCrows = new List<string>();

            foreach (var index in SelcetPLC)
            {
                var gridPLCrow = (DataRow)exGridViewPLC.GetDataRow(index);
                var realIndex = gridPLCrow["Number"].ToString();
                var dataRow = PlCdb.AsEnumerable().FirstOrDefault(r => r["Number"].ToString() == realIndex);
                PLCrows.Add(dataRow["Number"].ToString());
            }

            return PLCrows;
        }

        protected List<string> GetRealSelectHmiRows()
        {
            var SelcetHMI = exGridViewHMI.GetSelectedRows();
            var HMIrows = new List<string>();

            foreach (var index in SelcetHMI)
            {
                var gridHMIrow = (DataRow)exGridViewHMI.GetDataRow(index);
                var realIndex = gridHMIrow["#번호"].ToString();
                var dataRow = HmIdb.AsEnumerable().FirstOrDefault(r => r["#번호"].ToString() == realIndex);
                HMIrows.Add(dataRow["#번호"].ToString());
            }

            return HMIrows;
        }

        protected bool Mapping(string mappingType)
        {
            var plc = GetRealSelectPlcRows();
            var hmi = GetRealSelectHmiRows();

            if (hmi.Count == 0) return false;

            if (mappingType.Equals(EMTagGeneratorMappingType.Inserting.ToString())) 
            {
                RowInserting(hmi);
            }
            else
            {
                if (SameAddressChecker(plc)) return false;
                if (plc.Count != hmi.Count)
                {
                    var dCliResTest = XtraMessageBox.Show(
                        "연결 하려는 대상의 수가 다릅니다. 계속 하시겠습니까? ", "[선택된 PLC : " + plc.Count + "]" + " [선택된 HMI : " + hmi.Count + "]"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dCliResTest == DialogResult.No)
                        return false;
                }

                if (mappingType.Equals(EMTagGeneratorMappingType.Converting.ToString()))
                {
                    for (var i = 0; i < CompareSize(hmi.Count, plc.Count); i++)
                    {
                        var hmiRow = HmIdb.AsEnumerable().FirstOrDefault(r => (string)r["#번호"] == hmi[i]);
                        var plcRow = PlCdb.AsEnumerable().FirstOrDefault(r => (string)r["Number"] == plc[i]);
                        var result = RowMapping(plcRow, hmiRow, mappingType);
                        ColorInput(result, i, hmiRow);
                    }
                }
                else if (mappingType.Equals(EMTagGeneratorMappingType.General.ToString()))
                {
                    for (var i = 0; i < CompareSize(hmi.Count, plc.Count); i++)
                    {
                        var hmiRow = HmIdb.AsEnumerable().FirstOrDefault(r => (string)r["#번호"] == hmi[i]);
                        var plcRow = PlCdb.AsEnumerable().FirstOrDefault(r => (string)r["Number"] == plc[i]);
                        var result = RowMapping(plcRow, hmiRow, mappingType);
                        ColorInput(result, i, hmiRow);
                    }
                }
            }

            return true;
        }

        private bool SameAddressChecker(IEnumerable<string> plc)
        {
            foreach (var symbol in plc)
            {
                var plcRow = PlCdb.AsEnumerable().FirstOrDefault(r => (string)r["Number"] == symbol);
                var sameAddress = HmIdb.AsEnumerable().FirstOrDefault(r => (string)r["디바이스"] == (string)plcRow["Address"]);
                if (sameAddress == null) continue;
                var dialogResult = XtraMessageBox.Show("중복된 HMI 주소가 있습니다. 연결하시겠습니까? ", (string)plcRow["Address"]
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    return true;
                }           
            }

            return false;
        }

        protected void ColorInput(string Result ,int Row , DataRow HMIRow)
        {
            if (Result.Equals(""))
                return;

            var cellColor = new CellColor
            {
                SelectRow = int.Parse(HMIRow["#번호"].ToString()),
                SelectColumn = HMIRow["디바이스"].ToString()
            };

            var beforeColor = CellColors.AsEnumerable().FirstOrDefault(r => r.SelectRow == cellColor.SelectRow);
            if (beforeColor!=null)
                CellColors.Remove(beforeColor);

            if (Result.Equals("General"))
            {               
                cellColor.SelectColor = Color[0];      
            }               
            else if (Result.Equals("Conver"))
            {
                cellColor.SelectColor = Color[1];
            }
            else if (Result.Equals("Inserting"))
            {
                cellColor.SelectColor = Color[2];
            }

            CellColors.Add(cellColor);

            
        }

        protected string RowMapping(DataRow PLCdbRow, DataRow HMIdbRow, string MappingType)
        {
            var bOk = MappingOk(PLCdbRow, HMIdbRow);

            var address = PLCdbRow[EMTagGeneratorPLCColumns.Address.ToString()].ToString();
            var symbol = PLCdbRow[EMTagGeneratorPLCColumns.Symbol.ToString()].ToString();
            var general = EMTagGeneratorMappingType.General.ToString();
            var conver = EMTagGeneratorMappingType.Converting.ToString();

            if (general.Equals(MappingType) && bOk)
            {
                HMIdbRow["디바이스"] = address;
                HMIdbRow["설명"] = symbol;
                MappingLogger(EMCommonLogType.TagMapping, address,symbol, general);
                PLCdbRow["Assign"] = "True";
            
                AdditionalMapping(HMIdbRow["이름"].ToString(), HMIdbRow["디바이스"].ToString(), HMIdbRow["설명"].ToString());
                return general;
            }
            else if (conver.Equals(MappingType))
            {
                if (address.StartsWith("W"))
                {
                    var temp = address.Replace("W", "X");
                    HMIdbRow["디바이스"] = temp + ".0";
                    HMIdbRow["설명"] = symbol;
                    MappingLogger(EMCommonLogType.TagMapping, temp + ".0", symbol, conver);
                }
                else if (address.StartsWith("X"))
                {
                    var temp = AddressChecker(address.Replace("X", "W"));
                    HMIdbRow["디바이스"] = temp;
                    HMIdbRow["설명"] = HMIdbRow["설명"].ToString() + symbol;
                    MappingLogger(EMCommonLogType.TagMapping, temp,symbol, conver);
                }
                else if (address.Contains("DBW"))
                {
                    var temp = address.Replace("DBW", "DBX");
                    HMIdbRow["디바이스"] = temp + ".0";
                    HMIdbRow["설명"] = symbol;
                    MappingLogger(EMCommonLogType.TagMapping, temp + ".0", symbol, conver);
                }
                else if (address.Contains("DBX"))
                {
                    HMIdbRow["디바이스"] = BitToWordConvert(address);
                    HMIdbRow["설명"] = symbol;
                    MappingLogger(EMCommonLogType.TagMapping, BitToWordConvert(address) + ".0", symbol, conver);
                }
                else
                {
                    CMessage.XYSupport();
                }
                PLCdbRow["Assign"] = "True";
                return conver;
            }
            else
                return "";
        }

        protected string BitToWordConvert(string value)
        {
            var temp = value.Replace("DBX", "DBW");
            try
            {
                var str = temp.Split('.');
                return str[0] + "."+ str[1];
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception.." + ex);
            }

            return "";
        }

        protected void AdditionalMapping(string Symbol ,string Address, string Comment)
        {
            var StandardValue = string.Empty;
            var InputValue = string.Empty;

            HmIdb = (DataTable)exGridHMI.DataSource;

            for (var index = 0; index < HmIdb.Rows.Count; index++)
            {

                var dr = HmIdb.Rows[index];

                StandardValue = TextConvertor(dr["이름"].ToString());
                InputValue = TextConvertor(Symbol);

                if (StandardValue == InputValue)
                {
                    dr["디바이스"] = Address;
                    dr["설명"] = Comment;
                    //ColorInput("General", index, dr);
                }

            }

        }

        protected string TextConvertor(string Value)
        {
            var ConverValue = string.Empty;

            if (Value.Contains(']'))
            {
                var index = Value.IndexOf(']');
                ConverValue = Value.Substring(index + 1);
            }
            else
                ConverValue = Value;

            return ConverValue;
        }

        protected void RowInserting(List<string> HMI)
        {
            try
            {
                var StartRow = HmIdb.AsEnumerable().FirstOrDefault(r => r["#번호"] == HMI[0]);
                var insertBit = new InsertBit(PlcMaker, StartRow["디바이스"].ToString(), HMI.Count);
                for (var i = 1; i < HMI.Count; i++)
                {
                    var Row = HmIdb.AsEnumerable().FirstOrDefault(r => r["#번호"] == HMI[i]);
                    if (Row["타입"].ToString() == "WORD")
                        break;

                    Row["디바이스"] = insertBit.Bit[i - 1];
                    ColorInput("Inserting", i, Row);
                    MappingLogger(EMCommonLogType.TagMapping, insertBit.Bit[i - 1], "", "Inserting");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("삽입하려는 인덱스를 확인하세요. Simense 8 Bit , Mitsubishi 16 Bit , Rockwell 32 Bit");
            }
        }

        protected bool MappingOk(DataRow PLCdbRow, DataRow HMIdbRow)
        {
            var PLCType = PLCdbRow["Data Type"].ToString();
            var HMIType = HMIdbRow["타입"].ToString();

            if (PLCType.StartsWith("B") == HMIType.StartsWith("B") ||
                !PLCType.StartsWith("B") == HMIType.StartsWith("W"))
                return true;
            else
                return false;

        }

        protected string AddressChecker(string address)
        {
            if (address.StartsWith("M"))
                address = address.Replace("M", "MW");

            if (address.Contains(".") && address.Contains("DB"))
            {
                var sConver = address.Split('.');
                address = sConver[0] + "." + sConver[1];
            }
            else if (address.Contains("."))
            {
                var sConver = address.Split('.');
                address = sConver[0];
            }

            return address;
        }

        protected void AssignChecker(List<DataRow> dbRow, int Count)
        {
            var db = new DataTable();
            db = (DataTable)exGridPLC.DataSource;

            exGridPLC.DataSource = null;

            if (dbRow.Count < Count)
            {
                foreach (DataRow DR in dbRow)
                    DR[EMTagGeneratorPLCColumns.Assign.ToString()] = EMTagGeneratorAssign.True.ToString();
            }
            else
            {
                for (int i = 0; i < Count; i++)
                    dbRow[i][EMTagGeneratorPLCColumns.Assign.ToString()] = EMTagGeneratorAssign.True.ToString();
            }

            exGridPLC.DataSource = db;

        }

        protected void DataBackup(object sender)
        {
            var intervalTime = sender.ToString();

            if (exGridHMI.DataSource == null)
                return;

            var cSerializer = new CommonSerializer();
            var cProject = new CommonProject();
            BackupTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            cProject.HMI = (DataTable)exGridHMI.DataSource;
            cProject.PLC = (DataTable)exGridPLC.DataSource;
            cProject.CellColor = CellColors;
            cProject.BackupDate = BackupTime;

            var sSavePath = Application.StartupPath;
            var saveName = sSavePath + "\\AutoBackup.UDM";
            cSerializer.Write(saveName, cProject);
            cSerializer = null;

            EventBackupTimeAction(BackupTime);
            //BackupAlertControl("BackupOK", _BackupTime);

            BackupDb.Rows.Add(BackupTime,"Backup","HMI DataSource");
            LogEventArgs backupArg = new LogEventArgs {BackupLog = BackupDb};
            EventLogInput(backupArg);
        }

        protected void DataBackupExcute(object sender)
        {
            try
            {
                var sSavePath = Application.StartupPath + "\\AutoBackup.UDM";

                if (CMessage.bReallyRestore())
                {
                    var cSerializer = new CommonSerializer();
                    var oProject = cSerializer.Read(sSavePath);
                    var cProject = (CommonProject)oProject;
                    HmIdb = cProject.HMI;
                    PlCdb = cProject.PLC;
                    exGridHMI.DataSource = HmIdb;
                    exGridPLC.DataSource = PlCdb;
                    CellColors = cProject.CellColor;

                    TagMain._HMIdb = HmIdb;
                    var hmi = EMCommonHMIPrograms.XP_Builder.ToString();
                    DataInputEvent(hmi);
                    XtraMessageBox.Show(cProject.BackupDate,"Backup Time");
                    BackupAlertControl("LoadOK", cProject.BackupDate);

                    if (BackupTime == string.Empty)
                        BackupTime = cProject.BackupDate;

                    BackupDb.Rows.Add(BackupTime, "Load", "HMI DataSource");
                    var backupArg = new LogEventArgs {BackupLog = BackupDb};
                    EventLogInput(backupArg);           
                }
            }
            catch(Exception ex)
            {
                CMessage.FileLoadFail();
                Console.WriteLine("File Load Fail..." + ex);
            }

        }

        protected void BackupAlertControl(string value,string time)
        {
            var caption = string.Empty;
            var textInfo = string.Empty;
            var hotTrackedText = string.Empty;
            var imagePath = string.Empty;
            Image image;

            switch (value)
            {
                case "BackupOK":
                    caption = "HMI File Backup OK";
                    textInfo = "Back up Time is " + time;
                    imagePath = AppPath + "\\res\\BackupOK.png";
                    image = Image.FromFile(imagePath);
                    break;
                case "PLC Input OK":
                    caption = "PLC Input OK";
                    textInfo = "PLC Input Time is " + time;
                    imagePath = AppPath + "\\res\\BackupLoadOK.png";
                    image = Image.FromFile(imagePath);
                    break;
                case "ADD PLC Input OK":
                    caption = "ADD PLC Input OK";
                    textInfo = "ADD PLC Input Time is " + time;
                    imagePath = AppPath + "\\res\\BackupLoadOK.png";
                    image = Image.FromFile(imagePath);
                    break;
                case "HMI Input OK":
                    caption = "HMI Input OK";
                    textInfo = "HMI Input Time is " + time;
                    imagePath = AppPath + "\\res\\BackupLoadOK.png";
                    image = Image.FromFile(imagePath);
                    break;
                default:
                    caption = "Load OK";
                    textInfo = "Load Time is " + time;
                    imagePath = AppPath + "\\res\\BackupLoadOK.png";
                    image = Image.FromFile(imagePath);
                    break;
            }

            BackupAlert.Show(
                  this.FindForm(), caption, textInfo, hotTrackedText, image);
        }

        protected void MappingLogger(EMCommonLogType LogType,string Device, string Comment ,string MappingType)
        {
            var WorkingTime = DateTime.Now.ToString();
            var logger = new CommonLogger(LogType);

            if (LogDb.Columns.Count==0)
                LogDb = logger.LogDB;
           
            LogDb.Rows.Add(WorkingTime, MappingType, Device, Comment);

            var TagArg = new LogEventArgs {TagLog = LogDb};
            EventLogInput(TagArg);
        }

        protected int CompareSize(int value1, int value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        #endregion



    }
}
