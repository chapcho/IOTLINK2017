using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class GroupExtractHMI
    {
        protected List<string> _Group = new List<string>();
        protected List<string> _GroupList = new List<string>();


        public GroupExtractHMI(DataTable HMIdb)
        {
            HMIGroupListExport(HMIdb);
        }

        public List<string> GroupList
        {
            get { return _GroupList; }
            set { _GroupList = value;}
        }

        public void HMIGroupListExport(DataTable HMIdb)
        {
            //Key Export 
            //Dictionary<string, string> dicGroup = new Dictionary<string, string>(); 

            for (int i = 0; i < HMIdb.Rows.Count; i++)
            {
                string sGroup = HMIdb.Rows[i]["그룹"].ToString();
                _Group.Add(sGroup);
            }

            for (int i = 0; i < _Group.Count; i++)
            {
                try
                {
                    if (_Group[i] != _Group[i + 1])
                    {
                        _GroupList.Add(_Group[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("index over" + ex);
                }
            }

        }
    }
}
