using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDMIOMaker
{
    [Serializable]
    public class ABTagS : Dictionary<string, ABTag>, IDisposable
    {

        #region Initialize/Dispose

        public ABTagS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected ABTagS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion

        #region Public Propoerties

        public ABTag this[int iIndex]
        {
            get { return GetTag(iIndex); }
        }

        #endregion


        #region Public Methods

        public new void Add(string sKey, ABTag cTag)
        {
            if (this.ContainsKey(sKey) == false)
                base.Add(sKey, cTag);
        }

        public void Add(ABTag cTag)
        {
            Add(cTag.Key, cTag);
        }


        public ABTag GetFirst()
        {
            ABTag cTag = new ABTag();

            if (this.Count > 0)
                cTag = this.First().Value;

            return cTag;
        }

        public ABTag GetFirst(string sAddress)
        {
            ABTag cTagFound = null;
            ABTag cTag = null;
            for (int i = 0; i < this.Count; i++)
            {
                cTag = this.ElementAt(i).Value;
                if (cTag.Address == sAddress)
                {
                    cTagFound = cTag;
                    break;
                }
            }

            return cTagFound;
        }

        public ABTag GetLast()
        {
            ABTag cTag = new ABTag();

            if (this.Count > 0)
                cTag = this.Last().Value;

            return cTag;
        }

        public ABTag GetLast(string sAddress)
        {
            ABTag cTagFound = null;
            ABTag cTag = null;
            for (int i = this.Count - 1; i > -1; i--)
            {
                cTag = this.ElementAt(i).Value;
                if (cTag.Address == sAddress)
                {
                    cTagFound = cTag;
                    break;
                }
            }

            return cTagFound;
        }

        #endregion


        #region Private Methods

        protected ABTag GetTag(int iIndex)
        {
            ABTag cTag = null;

            if (this.Count > iIndex)
                cTag = this.ElementAt(iIndex).Value;

            return cTag;
        }

        #endregion
    }
}
