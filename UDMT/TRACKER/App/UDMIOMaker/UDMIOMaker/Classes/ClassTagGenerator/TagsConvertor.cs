using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using UDM.Common;
using UDM.General;
using NewIOMaker.Classes.ClassTagGenerator;
using NewIOMaker.Enumeration;


namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class TagsConvertor
    {
        protected DataTable _db = new DataTable();
        protected DataTable _IOdb = new DataTable();
        protected CTagS _cTags;
        protected string _Cpu = "MAIN";
        protected EMPLCMaker _Maker;
        protected bool _AddOK = false;
        

        public TagsConvertor(CTagS cTags, int Cpu, EMPLCMaker Maker, int StartNumber)
        {
            _cTags = cTags;
            _Maker = Maker;

            if (Cpu != 0)
            {
                _Cpu = Cpu.ToString();
                _AddOK = true;
            }
                
            if (_cTags == null)
                return;

            PLCInput(StartNumber);
      
        }

        #region Public Properites

        public DataTable db
        {
            get { return _db; }
            set { _db = value; }
        }

        public DataTable IOdb
        {
            get { return _IOdb; }
            set { _IOdb = value; }
        }

        #endregion

        protected void PLCInput(int StartNumber)
        {
            DataTable db = new DataTable();
            HeaderPLC HeaderPLC = new HeaderPLC(db);
            _db = HeaderPLC.db;

            foreach (CTag cTag in _cTags.Values)
            {
                DataRow dr = _db.NewRow();

                dr[(int)EMTagGeneratorPLCColumns.Number] = StartNumber++;

                if (_AddOK)
                    dr[(int)EMTagGeneratorPLCColumns.Address] = _Cpu + ":" + cTag.Address;
                else
                    dr[(int)EMTagGeneratorPLCColumns.Address] = cTag.Address;

                dr[(int)EMTagGeneratorPLCColumns.Comment] = cTag.Description;
                dr[(int)EMTagGeneratorPLCColumns.DataType] = cTag.DataType;
                dr[(int)EMTagGeneratorPLCColumns.Symbol] = TagNameExtractor(cTag.Name);

                dr[(int)EMTagGeneratorPLCColumns.Assign] = EMTagGeneratorAssign.False.ToString();
                dr[(int)EMTagGeneratorPLCColumns.PLC] = _Cpu;

                if (cTag.Name.Contains("_"))
                    dr[(int)EMTagGeneratorPLCColumns.Group] = TagGroupExtractor(cTag.Name);



                _db.Rows.Add(dr);
            }

            IOdbExtractor();
        }

        protected void IOdbExtractor()
        {
            _IOdb = _db.Copy();

            string RemoveColumn1 = EMTagGeneratorPLCColumns.Assign.ToString();
            _IOdb.Columns.Remove(RemoveColumn1);

            string RemoveColumn2 = EMTagGeneratorPLCColumns.PLC.ToString();
            _IOdb.Columns.Remove(RemoveColumn2);

            string RemoveColumn3 = EMTagGeneratorPLCColumns.Logic.ToString();
            _IOdb.Columns.Remove(RemoveColumn3);

            string RemoveColumn4 = EMTagGeneratorPLCColumns.Group.ToString();
            _IOdb.Columns.Remove(RemoveColumn4);

            string RemoveColumn5 = EMTagGeneratorPLCColumns.Comment.ToString();
            _IOdb.Columns.Remove(RemoveColumn5);

        }

        protected string TagGroupExtractor(string key)
        {
            string Temp = key.Replace("[CH_DV]", "");

            if(Temp.Contains("_"))
            {
                string[] Temps = Temp.Split('_');
                Temp = Temps[0];
            }

            return Temp;
        }

        protected string TagNameExtractor(string key)
        {
            string Temp = key.Replace("HMI_Sensor_Disp_Area.", "");

            return Temp;
        }
    }
}
