using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CGroupS : Dictionary<string, CGroup>, IDisposable
    {

        #region Member Variables

        
        #endregion


        #region Initialize/Dispose

        public CGroupS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CGroupS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties

        public CGroup this[int iIndex]
        {
            get { return GetGroup(iIndex); }
        }

        #endregion


        #region Public Methods

        public void AddRange(CGroupS cGroupS)
        {
            CGroup cGroup;
            for (int i = 0; i < cGroupS.Count; i++)
            {
                cGroup = cGroupS[i];
                this.Add(cGroup.Key, cGroup);
            }
        }

        public new void Clear()
        {
            CGroup cGroup;
            for(int i=0;i<this.Count;i++)
            {
                cGroup = this[i];
                cGroup.Clear();
            }

            base.Clear();
        }

		public void Compose(CTagS cTagS)
		{
			for(int i=0;i<cTagS.Count;i++)
				cTagS[i].GroupRoleS.Clear();

			for(int i=0;i<this.Count;i++)
				this[i].Compose();
		}

        #endregion


        #region Private Methods

        protected CGroup GetGroup(int iIndex)
        {
            CGroup cGroup = null;

            if (this.Count > iIndex)
                cGroup = this.ElementAt(iIndex).Value;

            return cGroup;
        }

        #endregion
    }
}
