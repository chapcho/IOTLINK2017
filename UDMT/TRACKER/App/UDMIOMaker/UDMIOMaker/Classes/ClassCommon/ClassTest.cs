using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassCommon
{
    [Serializable]
    public class ClassTest
    {
        protected string _PLCType = string.Empty;

        public string Path
        {
            get { return _PLCType; }
            set { _PLCType = value; }
        }
    }
}
