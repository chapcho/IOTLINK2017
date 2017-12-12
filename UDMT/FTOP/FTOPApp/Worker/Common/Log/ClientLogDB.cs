using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public class ClientLogDB
    {
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string WorkStation { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int value { get; set; }
     
        public string GroupType { get; set; }
        public string GetPoint { get; set; }
        public string DataWhere { get; set; }
        
        public ClientLogDB()
        {
           
        }
    }
}
