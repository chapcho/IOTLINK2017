using System;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Form;
using NewIOMaker.Form.FormCommon.UserControl;
using NewIOMaker.Form.Form_TagGenerator;
using NewIOMaker.Form.Form_MultiCopy;
using NewIOMaker.Form.Form_IOMaker;
using NewIOMaker.Event;
using NewIOMaker.Enumeration;
using NewIOMaker.Properties;
using NewIOMaker.Form.FormCommon.Convertor;
using NewIOMaker.Classes.ClassCommon.Util;
using NewIOMaker.Enums;

namespace NewIOMaker
{

    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private IOPLCVerification _plcVerification;
        protected IOMenu _IOMaker;
        protected MCMenu _MultiCopy;
        protected TagMain _TagGenerator;
        protected ControlBase _ControlMenu;
        protected ControlInfo _ControlInfo;
        protected ControlOption _ControlOption;
        protected ControlTool _ControlTool;
        protected ControlABConvertor _ConvertorAB;
        protected ControlTrackerConvertor _controlTracker;

        protected CommonMessage _cMessage = new CommonMessage();
        protected Stopwatch _StopWatch = new Stopwatch();
        protected System.Windows.Forms.Timer _WorkingTimer = new System.Windows.Forms.Timer();
        protected System.Windows.Forms.Timer _BackupTimer = new System.Windows.Forms.Timer();

        public string _Statusbar = string.Empty;
        public string _Version = "IOMaker v2.5";
        protected int _WorkingTime = 60000;   // Default 1 Min
        protected int _BackupTime = 60000;  // Default 1 Min
        protected int _LoadingTime = 1000; // 

        #region Event

        public event delMultiKeyListUpdate EventKeyUpdate;
        public event delBackupCallEvent EventBackCallAlarm;
        public event delBackupCallEvent EventBackupBtnClick;

        public event delTagGeneratorMenuEvent EventPLCAddClick;
        public event delTagGeneratorMenuEvent EventPLCImportClick;
        public event delTagGeneratorMenuEvent EventHMIImportClick;
        public event delTagHMIExportMenuEvent EventHMIExportAllClick;
        public event delTagHMIExportMenuEvent EventHMIExportPartClick;
        public event delTagGeneratorMenuEvent EventFilterClick;
        public event delTagGeneratorMenuEvent EventEditerClick;
        public event delTagGeneratorMenuEvent EventFilterGellayClick;
        public event delTagGeneratorMenuEvent EventEditerGellayClick;
        public event delTagGeneratorOpenSaveEvent EventOpenSaveClick;
        public event delTagGeneratorMenuEvent EventNewPLCClick;
        public event delTagGeneratorMenuEvent EventNewHMIClick;

        public event delTagGeneratorColorEvent EventColorMappingClick;
        public event delTagGeneratorColorEvent EventColorConvertingClick;
        public event delTagGeneratorColorEvent EventColorInsertingClick;

        public event delIOMakerMenuEvent EventIOImportClick;
        public event delIOMakerExportEvent EventIOALLClick;
        public event delIOMakerExportEvent EventIOIOClick;
        public event delIOMakerExportEvent EventIODummyClick;
        public event delIOMakerExportEvent EventIOLinkClick;
        public event delIOMakerPLCVerificationEvent EventIOPLC;

        public event delMultiCopyMenuEvent EventMCStopClick;
        public event delMultiCopyMenuEvent EventMCKeyListClick;
        public event delMultiCopyMenuEvent EventMCKeyGeneratorClick;

        public event delMenuClickEvent EventMenuInformationClick;
        public event delMenuClickEvent EventMenuToolClick;
        public event delPageClickEvent EventPageClick;

        public event delLogInputEvent EventLogInput;

        #endregion
        
        #region Intialize/Dispose

        public FormMain()
        {
            InitializeComponent();                               
            Thread.Sleep(_LoadingTime);
            skinLoad();

            _IOMaker = new IOMenu(this);
            _MultiCopy = new MCMenu(this);
            _TagGenerator = new TagMain(this);
            _ControlMenu = new ControlBase();
            _ControlInfo = new ControlInfo(this);
            _ControlOption = new ControlOption(this);
            _ConvertorAB = new ControlABConvertor(this);
            _controlTracker = new ControlTrackerConvertor(this);
            _plcVerification = new IOPLCVerification(this);

            _WorkingTimer.Start();
            _BackupTimer.Start();
            _StopWatch.Start();

            _WorkingTimer.Interval = _WorkingTime;
            _BackupTimer.Interval = _BackupTime;

            btnBackupTimer.EditValueChanged += btnBackupTimer_EditValueChanged;
            btnBackup.ItemClick += btnBackup_ItemClick;
            Ribbon.SelectedPageChanging += Ribbon_SelectedPageChanging;
            FrmRibbon.ItemClick += ribbonControl1_ItemClick;
            _BackupTimer.Tick += _BackupTimer_Tick;
            _WorkingTimer.Tick += _WorkingTimer_Tick;

            this.Load += FormMain_Load;
            this.FormClosing += FormMain_FormClosing;
            this.Text = _Version;
                      
            Mainpanel.Dock = DockStyle.Fill;

            Mainpanel.Controls.Add(_TagGenerator);
            _TagGenerator.Dock = DockStyle.Fill;
            MouseStatus.Caption = "[ TagGenerator  :   Mapping Worker for PLC and HMI  ]";
            EventPageClick(EMCommonPageInfo.Tag);
        }

        void skinLoad()
        {
            try
            {
                var sSavePath = Application.StartupPath + "\\AutoSkin.UDM";
                var cSerializer = new CommonSerializer();
                var oProject = cSerializer.Read(sSavePath);
                var cProject = (CommonProject)oProject;
                defaultLookAndFeel1.LookAndFeel.SkinName = cProject.Skin;
                cSerializer = null;
            }
            catch(Exception ex )
            {
                Console.WriteLine("Not Save Skin.." + ex);
            }
        }

        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var cSerializer = new CommonSerializer();
            var cProject = new CommonProject {Skin = defaultLookAndFeel1.LookAndFeel.SkinName};
            var sSavePath = Application.StartupPath;
            var saveName = sSavePath + "\\AutoSkin.UDM";
            cSerializer.Write(saveName, cProject);
            cSerializer = null;

        }

        void _WorkingTimer_Tick(object sender, EventArgs e)
        {
            var time = _StopWatch.Elapsed;

            string WorkingTime = time.ToString().Substring(0, 5);

            btnAppTime.Caption = "Running Time : " + WorkingTime;

        }

        void btnBackupTimer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                TimeSpan timeSpan = (TimeSpan)btnBackupTimer.EditValue;
                _BackupTime = int.Parse(timeSpan.TotalSeconds.ToString());

                if (_BackupTime == 0)
                    return;

                _BackupTimer.Interval = _BackupTime * 1000;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Timer Interval Invalied.." + ex);
            }
        }
      
        void _BackupTimer_Tick(object sender, EventArgs e)
        {
            EventBackCallAlarm(sender);
        }

        void ribbonControl1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Caption == "열기" || e.Item.Caption == "저장")
                EventOpenSaveClick(e.Item.Caption);
        }

        #endregion

        #region Public Properties

         public string Statusbar
         {
             get { return _Statusbar; }
             set { _Statusbar = value; }
         }

        #endregion

        #region Public Methods

        #region Menu Event Register

         void FormMain_Load(object sender, EventArgs e)
         {
             MenuExit.ItemClick += MenuExit_ItemClick;

             //TagGenearot
             btnPLCImport.ItemClick += btnPLCImport_ItemClick;
             btnHMIImport.ItemClick += btnHMIImport_ItemClick;
             btnHMIAllExport.ItemClick += btnHMIAllExport_ItemClick;
             btnPartExport.EditValueChanged += btnPartExport_EditValueChanged;
             ColorMapping.EditValueChanged += ColorMapping_EditValueChanged;
             ColorConverting.EditValueChanged += ColorConverting_EditValueChanged;
             ColorInserting.EditValueChanged += ColorInserting_EditValueChanged;
             NewPLC.ItemClick += NewPLC_ItemClick;
             NewHMI.ItemClick += NewHMI_ItemClick;
             NewAlarm.ItemClick += NewAlarm_ItemClick;
             NewLog.ItemClick += NewLog_ItemClick;
             btnFilter.ItemClick += btnFilter_ItemClick;
             btnEditer.ItemClick += btnEditer_ItemClick;
             btnManualIO.ItemClick += btnManualIO_ItemClick;
             btnManualHMI.ItemClick += btnManualHMI_ItemClick;
             bntVideoTag.ItemClick += (o, s) => { EventMenuInformationClick("Tag"); };
             btnVideoIO.ItemClick += (o, s) => { EventMenuInformationClick("IO"); };
             btnVideoMulti.ItemClick += (o, s) => { EventMenuInformationClick("Multi"); };
             btnVideoVerification.ItemClick += (o, s) => { EventMenuInformationClick("Verification"); };
             btnPdf.ItemClick += (o, s) => { EventMenuInformationClick("Pdf"); };
             btnVideo.ItemClick += (o, s) => { EventMenuInformationClick("Video"); };

             btnInformation.ItemClick += btnInformation_ItemClick;
             FilterGallery.GalleryItemClick += FilterGallery_GalleryItemClick;
             EditGallery.GalleryItemClick += EditGallery_GalleryItemClick;
             btnAddCUP_1.ItemClick += btnAddCUP_1_ItemClick;
             btnAddCUP_2.ItemClick += btnAddCUP_2_ItemClick;
             btnAddCUP_3.ItemClick += btnAddCUP_3_ItemClick;
             btnAddCUP_4.ItemClick += btnAddCUP_4_ItemClick;

             _TagGenerator.DataInputEvent += _TagGenerator_DataInputEvent;
             _TagGenerator.EventBackupTimeAction += _TagGenerator_EventBackupTimeAction;
             _TagGenerator.EventLogInput += _TagGenerator_EventLogInput;
                                   
             //IOMaker
             btnIOImport1.ItemClick += btnIOImport1_ItemClick;
             btnIOAll.ItemClick += btnIOAll_ItemClick;
             btnIOIO.ItemClick += btnIOIO_ItemClick;
             btnIODummy.ItemClick += btnIODummy_ItemClick;
             btnIOLink.ItemClick += btnIOLink_ItemClick;
             btnIOPreView.ItemClick += btnIOPreView_ItemClick;
             _IOMaker.EventLogInput += _IOMaker_EventLogInput;
             btnIOView.ItemClick += btnIOView_ItemClick;

             btnIoPlcOpen.ItemClick += (o, s) => { EventIOPLC(o,EMPLCVerificationMenu.Open);};
             btnIoPlcVerification.ItemClick += (o, s) => { EventIOPLC(o, EMPLCVerificationMenu.Analysis); };
             btnExportExcel.ItemClick += (o, s) => { EventIOPLC(o, EMPLCVerificationMenu.ExportToExcel); };
             btnExportWord.ItemClick += (o, s) => { EventIOPLC(o, EMPLCVerificationMenu.ExportToWord); };
             btnExportPDF.ItemClick += (o, s) => { EventIOPLC(o, EMPLCVerificationMenu.ExportToPdf); };
             btnPlcAddReport.ItemClick += (o, s) => { EventIOPLC(textLogicCheck.EditValue, EMPLCVerificationMenu.LogicAdd); };

             //MultiCopy
             btnMCRun.ItemClick += btnMCRun_ItemClick;
             btnMCStop.ItemClick += btnMCStop_ItemClick;
             btnMCKeyList.ItemClick += btnMCKeyList_ItemClick;
             btnMCKeyGenerator.ItemClick += btnMCKeyGenerator_ItemClick;
             //_MultiCopy.EventKeyUpdate += _MultiCopy_EventKeyUpdate;

             //ETC Menu
             btnExcel.ItemClick += btnExcel_ItemClick;
             btnLog.ItemClick += btnLog_ItemClick;
             btnDoc.ItemClick += btnDoc_ItemClick;
             btnTrackerConvert.ItemClick += btnTrackerConvert_ItemClick;
             btnHMIConvert.ItemClick += btnHMIConvert_ItemClick;

             PageVideo.CaptionButtonClick += PageVideo_CaptionButtonClick;
        
         }

         void PageVideo_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
         {
             
         }

         #region Page change

         void Ribbon_SelectedPageChanging(object sender, DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs e)
         {
             Mainpanel.Controls.Clear();

             string PageInfo = string.Empty;

             if (e.Page.Name == "PageTagGenerator" || e.Page.Name =="PageOption")
             {
                 Mainpanel.Controls.Add(_TagGenerator);
                 _TagGenerator.Dock = DockStyle.Fill;
                 PageInfo = "[ TagGenerator  :   Mapping Worker for PLC and HMI  ]";
                 EventPageClick(EMCommonPageInfo.Tag);
                 
             }
             else if (e.Page.Name == "PageIOMaker")
             {
                 Mainpanel.Controls.Add(_IOMaker);
                 _IOMaker.Dock = DockStyle.Fill;
                 PageInfo = "[ IOMaker  :   PLC Symbol Worker for IO and Dummy List  ]";
                 EventPageClick(EMCommonPageInfo.IO);
             }

             else if (e.Page.Name == "PageInfo")
             {
                 Mainpanel.Controls.Add(_ControlInfo);
                 _ControlInfo.Dock = DockStyle.Fill;
                 PageInfo = "[ Information  :   UDMtek Leading the PLC Verification  ]";
                 EventPageClick(EMCommonPageInfo.Info);
             }

             else if (e.Page.Name == "PagePLCVerification")
             {
                 Mainpanel.Controls.Add(_plcVerification);
                 _plcVerification.Dock = DockStyle.Fill;
                 PageInfo = "[ PLC Verification  :   Auto Verification for PLC  ]";
             }

             MouseStatus.Caption = PageInfo;
         }

         void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             Mainpanel.Controls.Clear();

             Mainpanel.Controls.Add(_ControlOption);
             _ControlOption.Dock = DockStyle.Fill;
             MouseStatus.Caption = "[ Log  :   Mapping & Backup & IOList & Alarm Log ]";
             EventPageClick(EMCommonPageInfo.Log);
 
         }

         void btnIOView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             Mainpanel.Controls.Clear();

             Mainpanel.Controls.Add(_IOMaker);
             _IOMaker.Dock = DockStyle.Fill;
             MouseStatus.Caption = "[ IOMaker  :   PLC Symbol Worker for IO and Dummy List  ]";
             EventPageClick(EMCommonPageInfo.IO);

         }

         void btnMCRun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             

             Mainpanel.Controls.Clear();

             Mainpanel.Controls.Add(_MultiCopy);
             _MultiCopy.Dock = DockStyle.Fill;
             MouseStatus.Caption = "[ MultiCopy  :   HMI Address Worker for Drawing  ]";
             EventPageClick(EMCommonPageInfo.MC);


         }

         void btnHMIConvert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             

             Mainpanel.Controls.Clear();

             Mainpanel.Controls.Add(_ConvertorAB);
             _ConvertorAB.Dock = DockStyle.Fill;
             MouseStatus.Caption = "[ HMI Convertor  :   Exporting PLC Symbol DataType  ]";
             EventPageClick(EMCommonPageInfo.HMI);
         }

         void btnTrackerConvert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             Mainpanel.Controls.Clear();

             Mainpanel.Controls.Add(_controlTracker);
             _controlTracker.Dock = DockStyle.Fill;
             MouseStatus.Caption = "[ Tracker Convertor  :   Converting Original PLC to Tracker Format  ]";
             EventPageClick(EMCommonPageInfo.Tracker);
         }

         #endregion

         void btnAddCUP_4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventPLCAddClick(e.Item.Name);
         }

         void btnAddCUP_3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventPLCAddClick(e.Item.Name);
         }

         void btnAddCUP_2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventPLCAddClick(e.Item.Name);
         }

         void btnAddCUP_1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventPLCAddClick(e.Item.Name);
         }

         #region v2.5.1 Menu Event

         void _IOMaker_EventLogInput(LogEventArgs e)
         {
             EventLogInput(e);
         }

         void _TagGenerator_EventLogInput(LogEventArgs e)
         {
             EventLogInput(e);
         }

         void btnDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             //EventMenuToolClick("Doc");
         }

         void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventMenuToolClick("Excel");
         }

         void _TagGenerator_EventBackupTimeAction(object sender)
         {
             LabelBackup.Caption = "Backup Time :   " + sender.ToString();
         }

         void _MultiCopy_EventKeyUpdate(DataTable KeyDB)
         {
             EventKeyUpdate(KeyDB);
         }

         void _TagGenerator_DataInputEvent(string Temp)
         {
             GroupExtractHMI groupExport = new GroupExtractHMI(_TagGenerator._HMIdb);

             foreach (string HMIList in groupExport.GroupList)
             {
                 repositoryItemComboBox1.Items.Add(HMIList);
             }
         }

         void MenuExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             if (_cMessage.Quit())
                 Application.Exit();
         }

         void EditGallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
         {
             EventEditerGellayClick(e.Item.Caption);
         }

         void FilterGallery_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
         {
             EventFilterGellayClick(e.Item.Caption);
         }

         void btnEditer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventEditerClick(sender);
         }

         void btnFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventFilterClick(sender);
         }       

         void btnIOPreView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

         }

         void btnIOLink_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventIOLinkClick(sender);
         }

         void btnIODummy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventIODummyClick(sender);
         }

         void btnIOIO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventIOIOClick(sender);
         }

         void btnIOAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventIOALLClick(sender);
         }

         void btnIOImport1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventIOImportClick(sender);
         }

         void btnHMIAllExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventHMIExportAllClick(e.Item.Caption);
         }

         void btnPartExport_EditValueChanged(object sender, EventArgs e)
         {
             EventHMIExportPartClick(btnPartExport.EditValue.ToString());
         }

         void btnMCKeyGenerator_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventMCKeyGeneratorClick(sender);
         }

         void btnMCKeyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventMCKeyListClick(sender);
         }

         void btnMCStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventMCStopClick(sender);
         }

         void btnHMIImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventHMIImportClick(sender);
         }

         void btnPLCImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventPLCImportClick(sender);
         }

         void btnBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             EventBackupBtnClick(sender);
         }

         void btnInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

         }

         void btnManualHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             string HMI = "HMI";
             EventMenuInformationClick(HMI);
         }

         void btnManualIO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             string IOMaker = "IOMaker";
             EventMenuInformationClick(IOMaker);

         }

         void ColorInserting_EditValueChanged(object sender, EventArgs e)
         {
             EventColorInsertingClick((Color)ColorInserting.EditValue);
         }

         void ColorConverting_EditValueChanged(object sender, EventArgs e)
         {
             EventColorConvertingClick((Color)ColorConverting.EditValue);
         }

         void ColorMapping_EditValueChanged(object sender, EventArgs e)
         {
             EventColorMappingClick((Color)ColorMapping.EditValue);
         }

         void NewAlarm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

         }

         void NewLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

         }

         void NewHMI_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             if (_cMessage.Clear())
             {
                 EventNewHMIClick(sender);
                 repositoryItemComboBox1.Items.Clear();
             }

         }

         void NewPLC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             if (_cMessage.Clear())
                 EventNewPLCClick(sender);
         }

         #endregion

        #endregion

         private void btnRunVideo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {
             
         }

        #endregion

         private void MenuOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
         {

         }

        #region Private Methods

        #endregion
    }

}
