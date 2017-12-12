using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UDM.Common
{
    [Serializable]
    public class CSymbolS : Dictionary<string, CSymbol>, IDisposable
    {

        #region Member Variables


        #endregion


        #region Intiailizie/Dispose

        public CSymbolS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        protected CSymbolS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        #endregion


        #region Public Properties

        public CSymbol this[int iIndex]
        {
            get { return GetSymbol(iIndex); }
        }

        #endregion


        #region Public Methods

		public CTagS GetTotalTagS()
		{
			CTagS cTotalTagS = new CTagS();

			TraceTotalTagS(this, cTotalTagS);

			return cTotalTagS;
		}

		public CTagS GetTagS()
		{
			CTagS cTagS = new CTagS();

			CSymbol cSymbol;
			for(int i=0;i<this.Count;i++)
			{
				cSymbol = this[i];
				if (cSymbol.Tag != null)
					cTagS.Add(cSymbol.Tag);
			}

			return cTagS;
		}

        public new void Add(string sKey, CSymbol cSymbol)
        {
            if(this.ContainsKey(sKey) == false)
                base.Add(sKey, cSymbol);
        }

        public void Add(CSymbol cSymbol)
        {
            Add(cSymbol.Key, cSymbol);
        }

        public void AddRange(CSymbolS cSymbolS)
        {
            CSymbol cSymbol;
            for (int i = 0; i < cSymbolS.Count; i++)
            {
                cSymbol = cSymbolS[i];
                this.Add(cSymbol.Key, cSymbol);
            }
        }

		public CSymbolS FindSymbolS(string sKey)
		{
			CSymbolS cTotalSymbolS = new CSymbolS();

			TraceFindSymbolS(sKey, this, cTotalSymbolS);

			return cTotalSymbolS;
		}

        public void Remove(int iIndex)
        {
            CSymbol cSymbol = this[iIndex];
			Remove(cSymbol.Key);
        }

		public void Remove(CSymbol cSymbol)
		{
			TraceRemove(cSymbol, this);
		}

		public void RemoveAll(string sKey)
		{	
			TraceRemoveAll(sKey,  this);
		}

		public bool IsContains(string sKey)
		{
			bool bOK = false;

			bOK = this.ContainsKey(sKey);
			if(!bOK)
			{
				CSymbol cSymbol = null;
				for(int i=0;i<this.Count;i++)
				{
					cSymbol = this[i];
					if(cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
					{
						bOK = cSymbol.SubSymbolS.IsContains(sKey);
						if (bOK)
							break;
					}
				}
			}

			return bOK;
		}

        #endregion


        #region Private Methods

        protected CSymbol GetSymbol(int iIndex)
        {
            CSymbol cSymbol = null;

            if (this.Count > iIndex)
                cSymbol = this.ElementAt(iIndex).Value;

            return cSymbol;
        }

		private void TraceTotalTagS(CSymbolS cSymbolS, CTagS cTotalTagS)
		{
			CSymbol cSymbol;
			for (int i = 0; i < cSymbolS.Count; i++)
			{
				cSymbol = cSymbolS[i];
				if (cSymbol.Tag != null)
					cTotalTagS.Add(cSymbol.Tag);

				if (cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
					TraceTotalTagS(cSymbol.SubSymbolS, cTotalTagS);
			}
		}

		private void TraceFindSymbolS(string sKey, CSymbolS cSymbolS, CSymbolS cTotalSymbolS)
		{
			if(cSymbolS.ContainsKey(sKey))
				cTotalSymbolS.Add(cSymbolS[sKey]);

			CSymbol cSymbol;
			for(int i=0;i<cSymbolS.Count;i++)
			{
				cSymbol = cSymbolS[i];
				if(cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
					TraceFindSymbolS(sKey, cSymbol.SubSymbolS, cTotalSymbolS);
			}
		}

		private void TraceRemove(CSymbol cSymbol, CSymbolS cSymbolS)
		{
			CSymbol cTemp;
			for (int i = 0; i < cSymbolS.Count; i++)
			{
				cTemp = cSymbolS[i];
				if (cTemp == cSymbol)
				{
					cSymbolS.Remove(cSymbol.Key);
					break;
				}
				else if(cTemp.SubSymbolS != null && cTemp.SubSymbolS.Count > 0)
				{
					TraceRemove(cSymbol, cTemp.SubSymbolS);
				}
			}
		}

		private void TraceRemoveAll(string sKey, CSymbolS cSymbolS)
		{
			CSymbol cSymbol;
			for (int i = 0; i < cSymbolS.Count; i++)
			{
				cSymbol = cSymbolS[i];
				if (cSymbol.SubSymbolS != null && cSymbol.SubSymbolS.Count > 0)
					TraceRemoveAll(sKey, cSymbol.SubSymbolS);
			}

			if (cSymbolS.ContainsKey(sKey))
				cSymbolS.Remove(sKey);
		}


        #endregion

    }
}
