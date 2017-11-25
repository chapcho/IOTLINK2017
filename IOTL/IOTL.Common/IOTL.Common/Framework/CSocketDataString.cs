using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.Framework
{
    public class CSocketDataString : IReceiveData
    {
        private string _socketData;

        public CSocketDataString()
        {
            _socketData = string.Empty;
        }

        public CSocketDataString(string sData)
        {
            _socketData = sData;
        }

        public int Length
        {
            get { return _socketData.Length; }
        }

        public object ReceiveData
        {
            get { return (object)_socketData; }
            set { _socketData = value.ToString(); }
        }

    }
}
