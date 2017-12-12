using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMIOMaker
{
    /// <summary>
    /// Key = CurrentName
    /// </summary>
    [Serializable]
    public class CStdS : Dictionary<String, CStd>, IDisposable
    {
        private bool m_bEdit = false;

        public CStdS()
        {
            
        }

        public bool IsEdit
        {
            get { return m_bEdit;}
            set { m_bEdit = value; }
        }

        public void Dispose()
        {
            Clear();
        }

        protected CStdS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

    }
}
