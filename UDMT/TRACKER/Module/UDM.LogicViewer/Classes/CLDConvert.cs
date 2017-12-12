using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using UDM.Common;
using System.ComponentModel;


namespace UDM.LogicViewer
{
    [Serializable]
    public class CLDConvet
    {
        private CLDRungS m_cLDRungS = null;
        private List<int> m_lstUsedContactIndex = new List<int>();

        #region Initialize/Dispose

        public CLDConvet(CStepS cStepS, BackgroundWorker backgroundWorker)
        {
            m_cLDRungS = CreateRungS(cStepS, backgroundWorker);
        }
        public CLDConvet(CStepS cStepS)
        {
            m_cLDRungS = CreateRungS(cStepS, null);
        }

        public void Dispose()
        {

        }

        #endregion

        #region Public interface

        public CLDRungS LDRungS
        {
            get { return m_cLDRungS; }
            set { m_cLDRungS = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Privates Methods

        private CLDRungS CreateRungS(CStepS cStepS, BackgroundWorker backgroundWorker)
        {
            CStep cStepDebug = null;
            CLDRungS cLDRungS = new CLDRungS();
            Dictionary<string, Color> DicColor = new Dictionary<string, Color>();
            Random random = new Random();
            int nProcess = 0;
            try
            {
                CStep cStep;
                for (int i = 0; i < cStepS.Count; i++)
                {
                    cStep = cStepS.ElementAt(i).Value;

                    if (backgroundWorker != null)
                        backgroundWorker.ReportProgress(nProcess++ * 100 / cStepS.Count, "Analysis");

                    cStepDebug = cStep;

                    if (cStep.ContactS.Count == 0)
                        continue;

                    CLDRung cLDRung = new CLDRung(cStep);

                    CreateUsedRung(cLDRung, random, DicColor);

                    if (!cLDRungS.ContainsKey(cLDRung.CoilKey))
                        cLDRungS.Add(cLDRung.CoilKey, cLDRung);                    
                }

                CreateColorRowSub(DicColor, cLDRungS);  

                return cLDRungS;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}] - {2}", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name, cStepDebug.CoilS.GetFirstCoil().Instruction); ex.Data.Clear();
                return cLDRungS;
            }
        }

        private bool CreateColorRowSub(Dictionary<string, Color> DicColor, CLDRungS cLDRungS)
        {
            foreach (var whoRung in cLDRungS)
            {
                CLDRung cLDRung = (CLDRung)whoRung.Value;
                foreach (var who in cLDRung.DIAGRAM_HEADS)
                {
                    foreach (CLDNodeBody cILNode in cLDRung.DIAGRAM_HEADS[who.Key])
                    { 
                        foreach (CLDNodeRow cILNodeRow in cILNode.ListILNodeRow)
                        {
                            if (cILNodeRow.ContactType == EMContactType.Compare)
                            {
                                SetColorSubLink(cILNodeRow, cILNodeRow.Address, DicColor);
//                                 SetColorSubLink(cILNodeRow, cILNodeRow.Addess_Sub1, DicColor);
//                                 SetColorSubLink(cILNodeRow, cILNodeRow.Addess_Sub2, DicColor);
                            }
                            else
                                SetColorSubLink(cILNodeRow, cILNodeRow.Address, DicColor);

                        }
                    }
                }
            }

            return true;
        }

        private void CreateUsedRung(CLDRung cLDRung, Random r, Dictionary<string, Color> DicColor)
        {
            if (cLDRung.Step.CoilS.GetFirstCoil().RefTagS.Count > 0)
            {
                CTag cTag = cLDRung.Step.CoilS.GetFirstCoil().RefTagS[0];
                if (!DicColor.ContainsKey(cTag.Address))
                    DicColor.Add(cTag.Address, Color.FromArgb(r.Next(50, 250), r.Next(50, 250), r.Next(50, 250)));
            }

            foreach (string sAddress in cLDRung.lstCoil)
            {
                if (!DicColor.ContainsKey(sAddress))
                    DicColor.Add(sAddress, Color.FromArgb(r.Next(50, 250), r.Next(50, 250), r.Next(50, 250)));
            }
        }

        private void SetColorSubLink(CLDNodeRow cILNodeRow, string strAddress, Dictionary<string, Color> DicColor)
        {
            if (DicColor.ContainsKey(strAddress))
                cILNodeRow.ColorSubLink = DicColor[strAddress];
        }

        #endregion
    }
}
