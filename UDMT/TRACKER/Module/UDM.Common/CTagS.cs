using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CTagS : Dictionary<string, CTag>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CTagS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CTagS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Propoerties

        public CTag this[int iIndex]
        {
            get { return GetTag(iIndex); }
        }

        #endregion


        #region Public Methods

        public new void Add(string sKey, CTag cTag)
        {
            if (this.ContainsKey(sKey) == false)
                base.Add(sKey, cTag);
        }

        public void Add(CTag cTag)
        {
            Add(cTag.Key, cTag);
        }

		public void AddRange(CTagS cTagS)
		{
			CTag cTag;
			for (int i = 0; i < cTagS.Count; i++)
			{
				cTag = cTagS[i];
                if (this.ContainsKey(cTag.Key) == false)
                    this.Add(cTag.Key, cTag);
			}
		}

        public void AddRange(List<CTag> lstTag)
        {
            CTag cTag;
            for (int i = 0; i < lstTag.Count; i++)
            {
                cTag = lstTag[i];
                if (this.ContainsKey(cTag.Key) == false)
                    this.Add(cTag.Key, cTag);
            }
        }

        public CTag GetFirst()
        {
            CTag cTag = new CTag();

            if (this.Count > 0)
                cTag = this.First().Value;

            return cTag;
        }

        public CTag GetFirst(string sAddress)
        {
            CTag cTagFound = null;
            CTag cTag = null;
            for (int i = 0; i< this.Count; i++)
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

        public CTag GetLast()
        {
            CTag cTag = new CTag();

            if (this.Count > 0)
                cTag = this.Last().Value;

            return cTag;
        }

        public CTag GetLast(string sAddress)
        {
            CTag cTagFound = null;
            CTag cTag = null;
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

        protected CTag GetTag(int iIndex)
        {
            CTag cTag = null;

            if (this.Count > iIndex)
                cTag = this.ElementAt(iIndex).Value;

            return cTag;
        }

        #endregion

    }
}
