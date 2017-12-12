using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NewIOMaker.Form.Form_TagGenerator;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using NewIOMaker.Classes.ClassTagGenerator.Base;
using NewIOMaker.Classes.ClassTagGenerator.Core;
using NewIOMaker.Enumeration.EnumTagGenerator;
using NewIOMaker.Enumeration.Enum_Common;
using NewIOMaker.Event.Event_TagGenerator;
using NewIOMaker.Form.Form_TagGenerator.Menu;
using NewIOMaker.Classes.ClassCommon.Util;
using UDM.Common;
using UDM.General;
using UDM.UDLImport;
using UDM.UDL;



namespace NewIOMaker.Form.Form_TagGenerator
{
    /// <summary>
    /// PLC와 HMI Grid를 표현하는 클래스 
    /// exprt시에 hmi menu에 db를 전달해야한다.
    /// </summary>
    /// 
    public partial class TagGrid : DevExpress.XtraEditors.XtraUserControl
    {
        public event delGridImportAfter ImportAfterEvent;

        protected TagMain _ControlMain;
        protected DataTable _HMIdb = new DataTable();
        protected CMessage _cMessage = new CMessage();
        protected TagMain _tagMain;
        protected PLC _plc;
        protected HMI _hmi;
        protected Tool _tool;
        protected CTagS _cTags;
        protected EMPLCMaker _PLCMaker;

        public TagGrid(TagMain tagMain,PLC plc, HMI hmi, Tool tool)
        {
            InitializeComponent();
          
            this.Resize += Control_Tag_Grid_Resize;

            _tagMain = tagMain;
            _plc = plc;
            _hmi = hmi;
            _tool = tool;
          
            _plc.EventSDFClick += _plc_EventSDFClick;
            _plc.EventAWLClick += _plc_EventAWLClick;
            _plc.EventCSVClick += _plc_EventCSVClick;
            _plc.EventL5KClick += _plc_EventL5KClick;

            _hmi.EventImportTagClick += _hmi_EventImportTagClick;
            exGridViewHMI.MouseUp += exGridViewHMI_MouseUp;

            ButtonMapping.ItemClick += ButtonMapping_ItemClick;
            ButtonConvertor.ItemClick += ButtonConvertor_ItemClick;
            ButtonInsertor.ItemClick += ButtonInsertor_ItemClick;

        }

        void ButtonInsertor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.Inserting.ToString());
        }

        void ButtonConvertor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.Converting.ToString());
        }

        void ButtonMapping_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mapping(EMTagGeneratorMappingType.General.ToString());
        }

        void exGridViewHMI_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point CurrentPoint = new Point(MousePosition.X, MousePosition.Y);
                popupHMI.ShowPopup(CurrentPoint);
            }
        }

    
        public DataTable HMIdb
        {
            get { return _HMIdb; }
            set { _HMIdb = value; }
        }

        #region PLC HMI event 

        void _hmi_EventExportTagClick(object sender, string HMI)
        {
           
        }

        void _hmi_EventImportTagClick(object sender, string HMI)
        {
            InputHMIData(sender, HMI);
        }

        void _plc_EventL5KClick(object sender, string PLC, int CPU)
        {
            InputPLCData(PLC, CPU);
        }

        void _plc_EventCSVClick(object sender, string PLC, int CPU)
        {
            InputPLCData(PLC, CPU);
        }

        void _plc_EventAWLClick(object sender, string PLC, int CPU)
        {
            _cMessage.Preparing();
            //InputPLCData(PLC,CPU);
        }

        void _plc_EventSDFClick(object sender, string PLC, int CPU)
        {
            InputPLCData(PLC,CPU);
        }

        #endregion


        #region Public Methods

        protected void InputPLCData(string PLC, int CPU)
        {        
            CUDLTagImport tagImport = new CUDLTagImport();

            _cTags = tagImport.CtagS;

            _PLCMaker = tagImport.Marker;

            TagsConvertor tagConvertor = new TagsConvertor(_cTags);

            exGridPLC.DataSource = tagConvertor.db;

            ImportAfterEvent(PLC);
        }

        protected void InputHMIData(object sender, string HMI)
        {
            ModuleHMI cHmi = new ModuleHMI(HMI);
            exGridHMI.DataSource = cHmi.dbHMI;
            exGridViewHMI.Columns["Column1"].Visible = false;

            _tagMain._HMIdb = cHmi.dbHMI;
            ImportAfterEvent(HMI);
        }

        #region etc

        void Control_Tag_Grid_Resize(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = splitContainerControl1.Height;
        }

        #endregion

        #endregion

        #region Pravate Methods

        protected bool Mapping(string MappingType)
        {
            int[] SelcetPLC = exGridViewPLC.GetSelectedRows();
            int[] SelcetHMI = exGridViewHMI.GetSelectedRows();

            if (SelcetHMI.Length == 0 )
                return false;

            List<DataRow> dbRow = new List<DataRow>();
            foreach (int Count in SelcetPLC)
                dbRow.Add(exGridViewPLC.GetDataRow(Count));

            if (MappingType.Equals(EMTagGeneratorMappingType.Inserting.ToString())) 
            {
                RowInserting(SelcetHMI);
            }
            else // Mapping or Converting
            {
                for (int i = 0; i < dbRow.Count; i++)
                {
                    if (SelcetHMI.Length <= i)
                        break;

                    DataRow dbRowPLC = (DataRow)exGridViewPLC.GetDataRow(SelcetPLC[i]);
                    DataRow dbRowHMI = (DataRow)exGridViewHMI.GetDataRow(SelcetHMI[i]);

                    RowMapping(dbRowPLC, dbRowHMI, MappingType);

                }
            }
            
            AssignChecker(dbRow, SelcetHMI.Length);

            return true;

        }

        protected void RowMapping(DataRow PLCdbRow, DataRow HMIdbRow, string MappingType)
        {
            bool bOK = MappingOK(PLCdbRow, HMIdbRow);

            string address = PLCdbRow[EMTagGeneratorPLCColumns.Address.ToString()].ToString();
            string Symbol = PLCdbRow[EMTagGeneratorPLCColumns.Symbol.ToString()].ToString();

            if (EMTagGeneratorMappingType.General.ToString().Equals(MappingType) && bOK)
            {
                HMIdbRow["디바이스"] = address;
                HMIdbRow["설명"] = HMIdbRow["설명"].ToString() + Symbol;
            }
            else if (EMTagGeneratorMappingType.Converting.ToString().Equals(MappingType))
            {
                if (address.StartsWith("W"))
                {
                    string temp = address.Replace("W", "X");
                    HMIdbRow["디바이스"] = temp + ".0";
                    HMIdbRow["설명"] = HMIdbRow["설명"].ToString() + Symbol;
                }
                else if (address.StartsWith("X"))
                {
                    string temp = AddressChecker(address.Replace("X", "W"));
                    HMIdbRow["디바이스"] = temp;
                    HMIdbRow["설명"] = HMIdbRow["설명"].ToString() + Symbol;
                }              
            }
        }

        protected void RowInserting(int[] SelcetHMI)
        {

            DataRow StartRowHMI = (DataRow)exGridViewHMI.GetDataRow(SelcetHMI[0]);
            string startHMI = StartRowHMI["디바이스"].ToString();

            InsertBit insertBit = new InsertBit(_PLCMaker, startHMI, SelcetHMI.Length);

            for(int i = 0 ; i< SelcetHMI.Length - 1 ; i++)
            {
                DataRow dbRowHMI = (DataRow)exGridViewHMI.GetDataRow(SelcetHMI[i + 1]);
                dbRowHMI["디바이스"] = insertBit.Bit[i];

                if (dbRowHMI["타입"].ToString() == "WORD")
                    break;

            }
        }

        protected bool MappingOK(DataRow PLCdbRow, DataRow HMIdbRow)
        {
            string PLCType = PLCdbRow["Data Type"].ToString();
            string HMIType = HMIdbRow["타입"].ToString();

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
                string[] sConver = address.Split('.');
                address = sConver[0] + "." + sConver[1];
            }
            else if (address.Contains("."))
            {
                string[] sConver = address.Split('.');
                address = sConver[0];
            }

            return address;
        }

        protected void AssignChecker(List<DataRow> dbRow, int Count)
        {
            DataTable db = new DataTable();
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

        #endregion

    }
}
