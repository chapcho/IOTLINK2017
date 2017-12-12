using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.UserAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommonAttributeClass : Attribute
    {

        string _name = string.Empty;
        string _update = string.Empty;

        public CommonAttributeClass(string name , string update)
        {
            this._name = name;
            this._update = update;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Update
        {
            get { return _update; }
        }

    }
}
