using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NewIOMaker.Classes.ClassTagGenerator
{
    public class HeaderIOList
    {
        protected DataTable _db = new DataTable();

        public HeaderIOList(DataTable db)
        {
            _db = db;
        }

        public DataTable db
        {
            get { return _db; }
            set { _db = value; }
        }

        protected void Developer()
        {
            
        }
    }
}
