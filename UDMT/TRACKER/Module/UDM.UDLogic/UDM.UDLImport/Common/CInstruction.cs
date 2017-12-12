using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDM.UDLImport
{
    public class CInstruction
    {
        string m_sCommand = string.Empty;
        string m_sInstrunction = string.Empty;
        
        int m_iSourceLabelNum = 0;
        int m_iSourceLabelNum_Sub1 = 0;
        int m_iSourceLabelNum_Sub2 = 0;

        int m_iCoilLabelNum = 0;
        int m_iCoilLabelNum_Sub1 = 0;
        int m_iCoilLabelNum_Sub2 = 0;

        List<CLabel> m_lstSourceLabel = null;
        List<CLabel> m_lstCoilLabel = null;

        List<CInstruction> m_lstInstruction_Sub = null;

        #region Initialize/Dispose

        #endregion

        #region Properties

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        public string Instruction
        {
            get {  return m_sInstrunction; }
            set { m_sInstrunction = value;  }
        }

        public List<CInstruction> SubInstructions
        {
            get { return m_lstInstruction_Sub; }
            set { m_lstInstruction_Sub = value; }
        }

        public int SourceLabelNum
        {
            get { return m_iSourceLabelNum; }
            set { m_iSourceLabelNum = value; }
        }

        public int SourceLabelNum_Sub1
        {
            get { return m_iSourceLabelNum_Sub1; }
            set { m_iSourceLabelNum_Sub1 = value; }
        }

        public int SourceLabelNum_Sub2
        {
            get { return m_iSourceLabelNum_Sub2; }
            set { m_iSourceLabelNum_Sub2 = value; }
        }

        public int CoilLabelNum
        {
            get { return m_iCoilLabelNum; }
            set { m_iCoilLabelNum = value; }
        }

        public int CoilLabelNum_Sub1
        {
            get { return m_iCoilLabelNum_Sub1; }
            set { m_iCoilLabelNum_Sub1 = value; }
        }

        public int CoilLabelNum_Sub2
        {
            get { return m_iCoilLabelNum_Sub2; }
            set { m_iCoilLabelNum_Sub2 = value; }
        }

        public List<CLabel> SourceLabel
        {
            get { return m_lstSourceLabel; }
            set { m_lstSourceLabel = value; }
        }

        public List<CLabel> CoilLabel
        {
            get { return m_lstCoilLabel; }
            set { m_lstCoilLabel = value; }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion


    }
}
