using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NewIOMaker.Enumeration;
using NewIOMaker.Classes.ClassTagGenerator;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class HeaderPLC
    {

        protected DataTable _db = null;
        protected List<string> m_GroupWorks2 = new List<string>(); 

        #region Initialize/Dispose

        public HeaderPLC(string PLCInfo, int PLCNumber, DataTable dbRaw)
        {

            SelectedPLC(PLCInfo, PLCNumber, dbRaw);
        }

        public HeaderPLC(DataTable BaseHeader)
        {

            TagPLCBaseColumns(BaseHeader);

        }

        public void Dipose()
        {
            if (_db != null)
                _db.Dispose();
        }

        #endregion

        #region Public Properites

        public DataTable db
        {
            get { return _db; }
            set { _db = value; }
        }

        #endregion

        #region Public Methods

        protected bool ABInsert(DataTable m_dbTablePLC)
        {
            m_dbTablePLC.Columns["TYPE"].ColumnName = "Assign";
            m_dbTablePLC.Columns["Assign"].SetOrdinal(0);

            DataColumn Col_One = m_dbTablePLC.Columns.Add("PLC");
            Col_One.SetOrdinal(1);

            m_dbTablePLC.Columns["DESCRIPTION"].ColumnName = "Logic";
            m_dbTablePLC.Columns["Logic"].SetOrdinal(2);

            m_dbTablePLC.Columns["SCOPE"].ColumnName = "Group";
            m_dbTablePLC.Columns["Group"].SetOrdinal(3);

            m_dbTablePLC.Columns["ATTRIBUTES"].ColumnName = "Comment";
            m_dbTablePLC.Columns["Comment"].SetOrdinal(4);

            m_dbTablePLC.Columns["DATATYPE"].ColumnName = "Data Type";
            m_dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            m_dbTablePLC.Columns["NAME"].ColumnName = "Symbol";
            m_dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            m_dbTablePLC.Columns["SPECIFIER"].ColumnName = "Address";
            m_dbTablePLC.Columns["Address"].SetOrdinal(7);

            for (int i = 0; i < m_dbTablePLC.Rows.Count; i++)
            {
                if (m_dbTablePLC.Rows[i]["Data Type"].ToString() == string.Empty &&
                    m_dbTablePLC.Rows[i]["Address"].ToString().Contains("."))
                {
                    m_dbTablePLC.Rows[i]["Data Type"] = "BOOL";
                }

                m_dbTablePLC.Rows[i]["Group"] = m_dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0];
                m_dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                m_dbTablePLC.Rows[i]["PLC"] = "None";
            }

            _db = m_dbTablePLC;

            return true;
        }

        protected bool ABL5KInsert(DataTable m_dbTablePLC)
        {
            m_dbTablePLC.Columns.Add("Assign");
            m_dbTablePLC.Columns.Add("PLC");
            m_dbTablePLC.Columns.Add("Logic");
            m_dbTablePLC.Columns.Add("Group");
            m_dbTablePLC.Columns.Add("Comment");
            m_dbTablePLC.Columns.Add("Data Type");
            m_dbTablePLC.Columns.Add("Symbol");
            m_dbTablePLC.Columns.Add("Address");

            _db = m_dbTablePLC;
            return true;
        }

        protected bool TagPLCBaseColumns(DataTable m_dbTablePLC)
        {
            m_dbTablePLC.Columns.Add("Number");
            m_dbTablePLC.Columns.Add("Assign");
            m_dbTablePLC.Columns.Add("PLC");
            m_dbTablePLC.Columns.Add("Logic");
            m_dbTablePLC.Columns.Add("Group");
            m_dbTablePLC.Columns.Add("Comment");
            m_dbTablePLC.Columns.Add("Data Type");
            m_dbTablePLC.Columns.Add("Symbol");
            m_dbTablePLC.Columns.Add("Address");

            _db = m_dbTablePLC;
            return true;
        }

        protected bool MelsecInsert(DataTable m_dbTablePLC)
        {
            DataColumn Col_One = m_dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            DataColumn Col_Two = m_dbTablePLC.Columns.Add("PLC");
            Col_Two.SetOrdinal(1);

            DataColumn Col_Three = m_dbTablePLC.Columns.Add("Logic");
            Col_Three.SetOrdinal(2);

            m_dbTablePLC.Columns["Label"].ColumnName = "Group";
            m_dbTablePLC.Columns["Group"].SetOrdinal(3);

            m_dbTablePLC.Columns["Comment"].ColumnName = "Symbol";
            DataColumn Col_Four = m_dbTablePLC.Columns.Add("Comment");
            Col_Four.SetOrdinal(4);

            DataColumn Col_Five = m_dbTablePLC.Columns.Add("Data Type");
            Col_Five.SetOrdinal(5);

            m_dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            m_dbTablePLC.Columns["Device"].ColumnName = "Address";
            m_dbTablePLC.Columns["Address"].SetOrdinal(7);

            for (int i = 0; i < m_dbTablePLC.Rows.Count; i++)
            {
                m_dbTablePLC.Rows[i]["Data Type"] = "Word";

                // MX Component Version4 Programming Manual p.48 Common Device Types

                if (m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("FX") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("FY") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("SM") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("X") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("Y") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("M") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("L") ||                                     
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("F") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("V") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("B") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("TS") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("TC") ||                                   
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("CS") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("CC") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("SS") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("SC") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("SB") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().StartsWith("S") ||
                    m_dbTablePLC.Rows[i]["Address"].ToString().Contains("."))
                {
                    m_dbTablePLC.Rows[i]["Data Type"] = "BOOL";
                }
                m_dbTablePLC.Rows[i]["Comment"] = m_dbTablePLC.Rows[i]["Symbol"].ToString();
                m_dbTablePLC.Rows[i]["Group"] = m_dbTablePLC.Rows[i]["Symbol"].ToString().Split(' ')[0];

                m_GroupWorks2.Add(m_dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0]);

                m_dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                m_dbTablePLC.Rows[i]["PLC"] = "None";
            }
            GroupCheck();
            _db = m_dbTablePLC;

            return true;

        }

        protected bool Works2Insert(DataTable m_dbTablePLC)
        {
            DataColumn Col_One = m_dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            m_dbTablePLC.Columns["Class"].ColumnName = "PLC";
            m_dbTablePLC.Columns["PLC"].SetOrdinal(1);

            DataColumn Col_Two = m_dbTablePLC.Columns.Add("Logic");
            Col_Two.SetOrdinal(2);

            DataColumn Col_Three = m_dbTablePLC.Columns.Add("Group");
            Col_Three.SetOrdinal(3);

            m_dbTablePLC.Columns["Comment"].SetOrdinal(4);
            m_dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            m_dbTablePLC.Columns["Label Name"].ColumnName = "Symbol";
            m_dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            m_dbTablePLC.Columns["Address"].ColumnName = "Value";

            m_dbTablePLC.Columns["Device"].ColumnName = "Address";
            m_dbTablePLC.Columns["Address"].SetOrdinal(7);

            _db = m_dbTablePLC;

            for (int i = 0; i < m_dbTablePLC.Rows.Count; i++)
            {
                m_dbTablePLC.Rows[i]["Group"] = m_dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0];

                m_GroupWorks2.Add(m_dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0]);

                m_dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                m_dbTablePLC.Rows[i]["Comment"] =  m_dbTablePLC.Rows[i]["Comment"].ToString() + " " +
                                                   m_dbTablePLC.Rows[i]["Value"].ToString();
            }

            try
            {
                m_dbTablePLC.Columns.Remove("Constant");
                m_dbTablePLC.Columns.Remove("Remark");
                m_dbTablePLC.Columns.Remove("Relation with System Label");
                m_dbTablePLC.Columns.Remove("Attribute");
                m_dbTablePLC.Columns.Remove("System Label Name");
                m_dbTablePLC.Columns.Remove("Value");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Format Different.."+ ex.ToString());
            }

            GroupCheck();

            return true;
        }

        protected void GroupCheck()
        {
            m_GroupWorks2 = new List<string>(new HashSet<string>(m_GroupWorks2));
        }

        protected bool SiemensInsert(DataTable m_dbTablePLC, string sCpuNumber)
        {

            DataColumn Col_One = m_dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            DataColumn Col_Two = m_dbTablePLC.Columns.Add("PLC");
            Col_Two.SetOrdinal(1);

            DataColumn Col_Three = m_dbTablePLC.Columns.Add("Logic");
            Col_Three.SetOrdinal(2);

            DataColumn Col_Four = m_dbTablePLC.Columns.Add("Group");
            Col_Four.SetOrdinal(3);

            m_dbTablePLC.Columns["3"].ColumnName = "Comment";
            m_dbTablePLC.Columns["Comment"].SetOrdinal(4);

            m_dbTablePLC.Columns["2"].ColumnName = "Data Type";
            m_dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            m_dbTablePLC.Columns["0"].ColumnName = "Symbol";
            m_dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            m_dbTablePLC.Columns["1"].ColumnName = "Address";
            m_dbTablePLC.Columns["Address"].SetOrdinal(7);

         

            for (int i = 0; i < m_dbTablePLC.Rows.Count; i++)
            {
                m_dbTablePLC.Rows[i]["Group"] = m_dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0];
                m_dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();

                string sAddressConvertor = m_dbTablePLC.Rows[i]["Address"].ToString().Replace(" ", string.Empty);
                MODAdress cSDF = new MODAdress();
                cSDF.AddressConvertor(sAddressConvertor);
                m_dbTablePLC.Rows[i]["Address"] = cSDF.SDFAddress;
                m_dbTablePLC.Rows[i]["PLC"] = sCpuNumber;
                        
            }

            _db = m_dbTablePLC;
            return true;
        }

        protected bool AWLInsert(DataTable m_dbTablePLC)
        {

            m_dbTablePLC.Columns.Add("Assign");
            m_dbTablePLC.Columns.Add("PLC");
            m_dbTablePLC.Columns.Add("Logic");
            m_dbTablePLC.Columns.Add("Group");
            m_dbTablePLC.Columns.Add("Comment");
            m_dbTablePLC.Columns.Add("Data Type");
            m_dbTablePLC.Columns.Add("Symbol");
            m_dbTablePLC.Columns.Add("Address");

            _db = m_dbTablePLC;

            return true;
        }

        #region Other PLC

        protected bool XG(DataTable dbTablePLC)
        {
            DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            dbTablePLC.Columns["Type"].ColumnName = "PLC";
            dbTablePLC.Columns["PLC"].SetOrdinal(1);

            dbTablePLC.Columns["Scope"].ColumnName = "Logic";
            dbTablePLC.Columns["Logic"].SetOrdinal(2);

            dbTablePLC.Columns["Property"].ColumnName = "Group";
            dbTablePLC.Columns["Group"].SetOrdinal(3);

            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            dbTablePLC.Columns["DataType"].ColumnName = "Data Type";
            dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            dbTablePLC.Columns["Variable"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            dbTablePLC.Columns["Address"].SetOrdinal(7);

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
            }

            _db = dbTablePLC;
            return true;
        }

        protected bool CX(DataTable dbTablePLC)
        {
            dbTablePLC.Columns.Add("Assign");
            dbTablePLC.Columns.Add("PLC");
            dbTablePLC.Columns.Add("Logic");
            dbTablePLC.Columns.Add("Group");
            dbTablePLC.Columns.Add("Comment");
            dbTablePLC.Columns.Add("Data Type");
            dbTablePLC.Columns.Add("Symbol");
            dbTablePLC.Columns.Add("Address");

            _db = dbTablePLC;
            return true;
        }

        protected bool SX(DataTable dbTablePLC)
        {
            dbTablePLC.Columns.Remove("POU/Worksheet");
            dbTablePLC.Columns.Remove("Y-Position");
            dbTablePLC.Columns.Remove("X-Position");
            dbTablePLC.Columns.Remove("Access");
            dbTablePLC.Columns.Remove("Command");
            dbTablePLC.Columns.Remove("I/O Address");
            dbTablePLC.Columns.Remove("I/O Comment");
            dbTablePLC.Columns.Remove("Global Path");
            dbTablePLC.Columns.Remove("Network Block No.");

            DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            dbTablePLC.Columns["XRefType"].ColumnName = "PLC";
            dbTablePLC.Columns["PLC"].SetOrdinal(1);

            dbTablePLC.Columns["Blocktype"].ColumnName = "Logic";
            dbTablePLC.Columns["Logic"].SetOrdinal(2);

            dbTablePLC.Columns["IN/OUT/INOUT"].ColumnName = "Group";
            dbTablePLC.Columns["Group"].SetOrdinal(3);

            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            dbTablePLC.Columns["Datatype"].ColumnName = "Data Type";
            dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            dbTablePLC.Columns["Variable"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            DataColumn Col_2 = dbTablePLC.Columns.Add("Address");
            Col_2.SetOrdinal(7);

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                dbTablePLC.Rows[i]["Address"] = dbTablePLC.Rows[i]["Symbol"];
            }

            _db = dbTablePLC;

            return true;
        }

        protected bool FPWIN(DataTable dbTablePLC)
        {
            DataColumn Col_1 = dbTablePLC.Columns.Add("Assign");
            Col_1.SetOrdinal(0);
            DataColumn Col_2 = dbTablePLC.Columns.Add("PLC");
            Col_2.SetOrdinal(1);
            DataColumn Col_3 = dbTablePLC.Columns.Add("Logic");
            Col_3.SetOrdinal(2);
            DataColumn Col_4 = dbTablePLC.Columns.Add("Group");
            Col_4.SetOrdinal(3);

            dbTablePLC.Columns["1"].ColumnName = "Comment";
            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            DataColumn Col_5 = dbTablePLC.Columns.Add("Data Type");
            Col_5.SetOrdinal(5);

            dbTablePLC.Columns["0"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            DataColumn Col_6 = dbTablePLC.Columns.Add("Address");
            Col_6.SetOrdinal(7);

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                dbTablePLC.Rows[i]["Address"] = dbTablePLC.Rows[i]["Symbol"];
                dbTablePLC.Rows[i]["PLC"] = "Main";
                dbTablePLC.Rows[i]["Logic"] = "UnUse";
            }

            _db = dbTablePLC;

            return true;
        }

        protected bool WINGPC(DataTable dbTablePLC)
        {

            DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            DataColumn Col_Two = dbTablePLC.Columns.Add("PLC");
            Col_Two.SetOrdinal(1);

            DataColumn Col_Three = dbTablePLC.Columns.Add("Logic");
            Col_Three.SetOrdinal(2);

            DataColumn Col_4 = dbTablePLC.Columns.Add("Group");
            Col_4.SetOrdinal(3);

            dbTablePLC.Columns["2"].ColumnName = "Comment";
            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            DataColumn Col_6 = dbTablePLC.Columns.Add("Data Type");
            Col_6.SetOrdinal(5);

            dbTablePLC.Columns["1"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            dbTablePLC.Columns["0"].ColumnName = "Address";
            dbTablePLC.Columns["Address"].SetOrdinal(7);

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                dbTablePLC.Rows[i]["Group"] = dbTablePLC.Rows[i]["Symbol"];
            }

            _db = dbTablePLC;

            return true;
        }

        protected bool KV(DataTable dbTablePLC)
        {
            DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            dbTablePLC.Columns["Module"].ColumnName = "PLC";
            dbTablePLC.Columns["PLC"].SetOrdinal(1);

            dbTablePLC.Columns["Instruction"].ColumnName = "Logic";
            dbTablePLC.Columns["Logic"].SetOrdinal(2);

            DataColumn Col_2 = dbTablePLC.Columns.Add("Group");
            Col_2.SetOrdinal(3);

            dbTablePLC.Columns["Comments"].ColumnName = "Comment";
            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            DataColumn Col_3 = dbTablePLC.Columns.Add("Data Type");
            Col_3.SetOrdinal(5);

            dbTablePLC.Columns["Device"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            DataColumn Col_4 = dbTablePLC.Columns.Add("Address");
            Col_4.SetOrdinal(7);

            dbTablePLC.Columns.Remove("Row");
            dbTablePLC.Columns.Remove("Column");
            dbTablePLC.Columns.Remove("Script");

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                dbTablePLC.Rows[i]["Address"] = dbTablePLC.Rows[i]["Symbol"]; 
            }

            _db = dbTablePLC;

            return true;
        }

        protected bool Wk2(DataTable dbTablePLC)
        {
            string UseLabel = string.Empty;

            if (dbTablePLC.Columns.Count == 2)
            {

                DataColumn Col_1 = dbTablePLC.Columns.Add("Assign");
                Col_1.SetOrdinal(0);
                DataColumn Col_2 = dbTablePLC.Columns.Add("PLC");
                Col_2.SetOrdinal(1);
                DataColumn Col_3 = dbTablePLC.Columns.Add("Logic");
                Col_3.SetOrdinal(2);
                DataColumn Col_4 = dbTablePLC.Columns.Add("Group");
                Col_4.SetOrdinal(3);

                dbTablePLC.Columns["Comment"].SetOrdinal(4);

                DataColumn Col_5 = dbTablePLC.Columns.Add("Data Type");
                Col_5.SetOrdinal(5);

                DataColumn Col_6 = dbTablePLC.Columns.Add("Symbol");
                Col_6.SetOrdinal(6);

                dbTablePLC.Columns["Device Name"].ColumnName = "Address";
                dbTablePLC.Columns["Address"].SetOrdinal(7);

                for (int i = 0; i < dbTablePLC.Rows.Count; i++)
                {
                    dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                    dbTablePLC.Rows[i]["Symbol"] = dbTablePLC.Rows[i]["Address"];
                    dbTablePLC.Rows[i]["PLC"] = "Main";
                    dbTablePLC.Rows[i]["Logic"] = "UnUse";
                }

                _db = dbTablePLC;
                return true;
            }
            else
            {
                DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
                Col_One.SetOrdinal(0);

                dbTablePLC.Columns["Class"].ColumnName = "PLC";
                dbTablePLC.Columns["PLC"].SetOrdinal(1);

                DataColumn Col_Two = dbTablePLC.Columns.Add("Logic");
                Col_Two.SetOrdinal(2);

                DataColumn Col_Three = dbTablePLC.Columns.Add("Group");
                Col_Three.SetOrdinal(3);

                dbTablePLC.Columns["Comment"].SetOrdinal(4);
                dbTablePLC.Columns["Data Type"].SetOrdinal(5);

                dbTablePLC.Columns["Label Name"].ColumnName = "Symbol";
                dbTablePLC.Columns["Symbol"].SetOrdinal(6);

                DataColumnCollection columns = dbTablePLC.Columns;

                if (columns.Contains("Address"))
                {
                    dbTablePLC.Columns["Address"].ColumnName = "Value";
                    UseLabel = "UnUse Label";
                }
                else
                    UseLabel = "Use Label";
             
                dbTablePLC.Columns["Device"].ColumnName = "Address";
                dbTablePLC.Columns["Address"].SetOrdinal(7);

                for (int i = 0; i < dbTablePLC.Rows.Count; i++)
                {
                    dbTablePLC.Rows[i]["Group"] = dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0];                 
                    dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                    dbTablePLC.Rows[i]["Comment"] = dbTablePLC.Rows[i]["Comment"].ToString() + " " + dbTablePLC.Rows[i]["Value"].ToString();
                    dbTablePLC.Rows[i]["Logic"] = UseLabel;
                                                       
                }

                try
                {
                    dbTablePLC.Columns.Remove("Constant");
                    dbTablePLC.Columns.Remove("Remark");
                    dbTablePLC.Columns.Remove("Relation with System Label");
                    dbTablePLC.Columns.Remove("Attribute");
                    dbTablePLC.Columns.Remove("System Label Name");
                    dbTablePLC.Columns.Remove("Value");
                }
                catch (Exception ex)
                { Console.WriteLine("Not Remove UnUse Columns..."+ ex.ToString()); }

                _db = dbTablePLC;

                return true;
            }
        }

        protected bool Wk3(DataTable dbTablePLC)
        {
            DataColumn Col_One = dbTablePLC.Columns.Add("Assign");
            Col_One.SetOrdinal(0);

            dbTablePLC.Columns["Class"].ColumnName = "PLC";
            dbTablePLC.Columns["PLC"].SetOrdinal(1);

            DataColumn Col_Two = dbTablePLC.Columns.Add("Logic");
            Col_Two.SetOrdinal(2);

            DataColumn Col_Three = dbTablePLC.Columns.Add("Group");
            Col_Three.SetOrdinal(3);

            dbTablePLC.Columns["Comment"].SetOrdinal(4);

            dbTablePLC.Columns["Data Type"].SetOrdinal(5);

            dbTablePLC.Columns["Label Name"].ColumnName = "Symbol";
            dbTablePLC.Columns["Symbol"].SetOrdinal(6);

            dbTablePLC.Columns["Address"].SetOrdinal(7);

            for (int i = 0; i < dbTablePLC.Rows.Count; i++)
            {
                dbTablePLC.Rows[i]["Group"] = dbTablePLC.Rows[i]["Symbol"].ToString().Split('_')[0];
                dbTablePLC.Rows[i]["Assign"] = EMTagGeneratorAssign.False.ToString();
                dbTablePLC.Rows[i]["Comment"] = dbTablePLC.Rows[i]["Comment"].ToString() + " " + dbTablePLC.Rows[i]["Comment 2"].ToString() +
                                                                                           " " + dbTablePLC.Rows[i]["Comment 3"].ToString() +
                                                                                           " " + dbTablePLC.Rows[i]["Comment 4"].ToString() +
                                                                                           " " + dbTablePLC.Rows[i]["Comment 5"].ToString() ;
                dbTablePLC.Rows[i]["Logic"] = "";

                dbTablePLC.Rows[i]["Address"] = dbTablePLC.Rows[i]["Address"].ToString() + dbTablePLC.Rows[i]["Assign (Device/Label)"].ToString();
            }

            try
            {
                dbTablePLC.Columns.Remove("Constant");
                dbTablePLC.Columns.Remove("Initial Value");
                dbTablePLC.Columns.Remove("Assign (Device/Label)");
                dbTablePLC.Columns.Remove("Comment 2"); dbTablePLC.Columns.Remove("Comment 3"); dbTablePLC.Columns.Remove("Comment 4");
                dbTablePLC.Columns.Remove("Comment 5");
                dbTablePLC.Columns.Remove("Japanese/日本語"); dbTablePLC.Columns.Remove("English");
                dbTablePLC.Columns.Remove("Chinese Simplified/简体中文"); dbTablePLC.Columns.Remove("Korean/한국어");
                dbTablePLC.Columns.Remove("Chinese Traditional/繁體中文");
                dbTablePLC.Columns.Remove("Reserved1"); dbTablePLC.Columns.Remove("Reserved2"); dbTablePLC.Columns.Remove("Reserved3");
                dbTablePLC.Columns.Remove("Reserved4"); dbTablePLC.Columns.Remove("Reserved5"); dbTablePLC.Columns.Remove("Reserved6");
                dbTablePLC.Columns.Remove("Remark");
                dbTablePLC.Columns.Remove("System Label Relation"); dbTablePLC.Columns.Remove("System Label Name");
                dbTablePLC.Columns.Remove("Attribute");
                dbTablePLC.Columns.Remove("Access from External Device");
            }
            catch (Exception ex)
            { Console.WriteLine("Not Remove UnUse Columns..." + ex.ToString()) ; }

            _db = dbTablePLC;

            return true;
        }

        #endregion

        #endregion

        #region Private Methods

        public void SelectedPLC(string PLCInfo, int PLCNumber, DataTable dbRaw)
        {
            if (PLCInfo.Equals(EMTagGeneratorPLCHeader.Step7_SDF.ToString()))
            {
                SiemensInsert(dbRaw, PLCNumber.ToString());
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.Step7_AWL.ToString()))
            {
                AWLInsert(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.RSLogix_CSV.ToString()))
            {
                ABInsert(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.RSLogix_L5K.ToString()))
            {
                ABL5KInsert(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.Developer.ToString()))
            {
                MelsecInsert(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.Works2.ToString()))
            {
                Wk2(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.Works3.ToString()))
            {
                Wk3(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.XG5000.ToString()))
            {
                XG(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.CX_Programmer.ToString()))
            {
                CX(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.SX_Programmer.ToString()))
            {
                SX(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.FPWINGR.ToString()))
            {
                FPWIN(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.KVStudio.ToString()))
            {
                KV(dbRaw);
            }
            else if (PLCInfo.Equals(EMTagGeneratorPLCHeader.WinGPC.ToString()))
            {
                WINGPC(dbRaw);
            }
        }

        #endregion
    }
}
