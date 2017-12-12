using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDM.Flow
{
    [Serializable]
    /// <summary>
    /// Key == sRecipe
    /// </summary>
    public class CMasterSequence : Dictionary<string, CMasterSequenceBlock>, IDisposable
    {
        private string m_sProcess = string.Empty;

        public CMasterSequence()
        {

        }

        protected CMasterSequence(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        public void Dispose()
        {
            Clear();
        }
      
        public string Process
        {
            get { return m_sProcess;}
            set { m_sProcess = value; }
        }


        public void Update(string sRecipe, CMasterSequenceUnitS cUnitS)
        {

            if (this.ContainsKey(sRecipe))
            {
                CMasterSequenceBlock cExistBlock = this[sRecipe];
                cExistBlock.Update(cUnitS);
            }
            else
            {
                CMasterSequenceBlock cBlock = new CMasterSequenceBlock();
                cBlock.Recipe = sRecipe;
                cBlock.Add(cUnitS);

                this.Add(cUnitS.Recipe, cBlock);
            }
        }


    }
}
