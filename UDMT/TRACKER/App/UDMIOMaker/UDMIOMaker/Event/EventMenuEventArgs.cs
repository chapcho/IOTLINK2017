using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NewIOMaker.Event
{
    public class LogEventArgs : EventArgs
    {
        public DataTable TagLog { get; set; }
        public DataTable IOLog { get; set; }
        public DataTable BackupLog { get; set; }
    }
}
