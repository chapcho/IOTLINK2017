using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace UDMPLCLogicAnalyzer
{
    [Serializable]
    public class CAnalyzeDataS : Dictionary<string, CAnalyzeData>
    {
        [NonSerialized]
        private CDoubleCoilDataS m_cTotalDoubleCoilFirst = new CDoubleCoilDataS();
        [NonSerialized]
        private CDoubleCoilDataS m_cTotalDoubleCoilSecond = new CDoubleCoilDataS();
        
        public CAnalyzeDataS()
        {

        }

        protected CAnalyzeDataS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }


        public CDoubleCoilDataS TotalFirstDoubleCoilS
        {
            get { return m_cTotalDoubleCoilFirst; }
            set { m_cTotalDoubleCoilFirst = value; }
        }

        public CDoubleCoilDataS TotalSecondDoubleCoilS
        {
            get { return m_cTotalDoubleCoilSecond; }
            set { m_cTotalDoubleCoilSecond = value; }
        }

        public void UpdateTotalDoubleCoilData()
        {
            m_cTotalDoubleCoilFirst.Clear();
            m_cTotalDoubleCoilSecond.Clear();
            foreach(CAnalyzeData cData in this.Values)
            {
                foreach (var who in cData.FirstDoubleCoilDataS)
                {
                    m_cTotalDoubleCoilFirst.Add(who.Key, who.Value);
                }
                foreach (var who in cData.SecondDoubleCoilDataS)
                {
                    m_cTotalDoubleCoilSecond.Add(who.Key, who.Value);
                }
            }

        }
    }
}
