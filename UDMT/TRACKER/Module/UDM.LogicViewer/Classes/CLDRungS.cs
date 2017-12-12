using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.General;
using System.Runtime.Serialization;

using UDM.UDLImport;

namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDRungS : Dictionary<string, CLDRung>
    {
        //protected CILSymbolS m_cLcSymbolS = new CILSymbolS();

        #region Initialize/Dispose

        public CLDRungS()
        {
        }

        protected CLDRungS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        public void Dispose()
        {
        }

        #endregion

        #region Public interface

        //public CILSymbolS SymbolS
        //{
        //    get { return m_cLcSymbolS; }
        //    set { m_cLcSymbolS = value; }
        //}

        #endregion

        #region Public Method


        public List<CLDRung> FindCoilRungS(string strAddress)
        {
            List<CLDRung> FindListRung = this.Values.ToList().FindAll(delegate(CLDRung CLDRung)
            {
                return CLDRung.CoilAddress == strAddress || CLDRung.lstCoil.Contains(strAddress);
            });

            return FindListRung;
        }

        public CLDRung FindCoilRung(string strAddress)
        {
            CLDRung FindRung = this.Values.ToList().Find(delegate(CLDRung cLDRung)
            {
                return cLDRung.CoilAddress == strAddress;
            });

            return FindRung;
        }

        public CLDRung FindCoilRung(CStep cStep)
        {
            CLDRung FindRung = this.Values.ToList().Find(delegate(CLDRung cLDRung)
            {
                return cLDRung.Step == cStep;
            });

            return FindRung;
        }

        public CLDRung FindCoilRungKey(string sStepKey)
        {
            CLDRung FindRung = this.Values.ToList().Find(delegate(CLDRung cLDRung)
            {
                return cLDRung.Step.Key == sStepKey;
            });

            return FindRung;
        }

        public List<CLDRung> FindContactRung(string strAddress)
        {
            List<CLDRung> FindListRung = this.Values.ToList().FindAll(delegate(CLDRung CLDRung)
            {
                return CLDRung.lstContact.Contains(strAddress);
            });

            return FindListRung;
        }


//         public CStepS FindStepS(string strAddress)  //paju
//         {
//             CStepS cStepS = new CStepS();
// 
//             foreach (CLDRung cLDRung in this.Values)
//                 cStepS.Add(cLDRung.Step);
// 
//             CStepS CStepSCoil = cStepS.GetStepSCoilAddress(strAddress);
// 
//             return CStepSCoil;
//         }
// 
// 
//         public CStepS FindStepSContactMatach(string strAddress)
//         {
//             CStepS cStepS = new CStepS();
// 
//             foreach (CLDRung cLDRung in this.Values)
//                 cStepS.Add(cLDRung.Step);
// 
//             CStepS CStepSCoil = cStepS.GetStepSContactAddress(strAddress);
// 
//             return CStepSCoil;
//         }


        //public string GetProgramSize(string sProgram)
        //{
        //    CILSymbolS cILSymbolS = new CILSymbolS();
        //    int nBit = 0;
        //    int nWord = 0;

        //    foreach (var whoRung in this)
        //    {
        //        CLDRung CLDRung = (CLDRung)whoRung.Value;

        //        if (CLDRung.CoilProgram != sProgram)
        //            continue;

        //        cILSymbolS = CLDRung.GetUsedSymbols();
        //        nBit += cILSymbolS.GetTotalSize(EMDataType.Bool);
        //        nWord += cILSymbolS.GetTotalSize(EMDataType.Word);
        //    }

        //    return string.Format("Word :{1}\t Bit :{0}\t ", nBit, nWord);
        //}

        #endregion

        #region Private Method


        #endregion
    }
}
