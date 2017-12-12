using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CStepS : Dictionary<string, CStep>, IDisposable, ITagComposable
    {

        #region Member Variables
        
        #endregion


        #region Initialize/Dispose

        public CStepS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CStepS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion
        

        #region Public Properties

        public CStep this[int iIndex]
        {
            get { return GetStep(iIndex); }
        }

        #endregion


        #region Public Methods

        public new void Add(string sKey, CStep cStep)
        {
            if (this.ContainsKey(sKey) == false)
                base.Add(sKey, cStep);
        }

        public void Add(CStep cStep)
        {
            Add(cStep.Key, cStep);
        }

        public void AddRange(List<CStep> lstStep)
        {
            for (int i = 0; i < lstStep.Count; i++)
                Add(lstStep[i]);
        }

        public void Compose(CTagS cTagS)
        {
            CStep cStep;
            for (int i = 0; i < this.Count; i++)
            {
                cStep = this.ElementAt(i).Value;
                cStep.Compose(cTagS);
            }
        }

        public void Compose(CRefTagS cRefTagS)
        {
            CStep cStep;
            for (int i = 0; i < this.Count; i++)
            {
                cStep = this.ElementAt(i).Value;
                cStep.Compose(cRefTagS);
            }
        }

        public void ComposeTagRoleS()
        {
            CStep cStep;
            for (int i = 0; i < this.Count; i++)
            {
                cStep = this.ElementAt(i).Value;
                cStep.ComposeTagRoleS();
            }
        }

        #endregion


        #region Private Methods

        protected CStep GetStep(int iIndex)
        {
            CStep cStep = null;

            if (this.Count > iIndex)
                cStep = this.ElementAt(iIndex).Value;

            return cStep;
        }

        #endregion

    }
}
