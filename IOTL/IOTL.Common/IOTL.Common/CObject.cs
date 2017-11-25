using IOTL.Common.Framework;
using MsgPack.Serialization;
using System;

namespace IOTL.Common
{
    [Serializable]
    public class CObject : IObject, IDescribable
    {
        protected string _key = "";
        protected string _description = "";


        public CObject()
        {

        }

        [MessagePackMember(0, Name = "Key")]
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        [MessagePackMember(1, Name = "Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
