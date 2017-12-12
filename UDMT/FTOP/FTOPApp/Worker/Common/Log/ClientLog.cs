using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    [Serializable]
    public class FTOPLog
    {
        public DateTime Time { get; set; }
        public string Type { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public bool IsException { get; set; }
        public bool IsWarning { get; set; }

        public FTOPLog()
        {

        }

        public FTOPLog(DateTime time, string type, string sender, string message, bool isException, bool isWarning)
        {
            Time = time;
            Type = type;
            Sender = sender;
            Message = message;
            IsException = isException;
            IsWarning = isWarning;
        }
    }


}
