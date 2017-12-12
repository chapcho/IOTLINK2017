using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Common;
using UDM.UDL;

namespace UDM.UDLImport
{
    public enum EMILType
    {
        NONE,
        CONTACT,
        CONNECT,
        CONNECT_OPERATION,
        COIL,
        ROUTINE,
        FB,
    }

    public enum EMILCoil
    {
        NORMAL,
        Arithmetic,
        SubDataMove,
        SET,
        RST
    }

    public class CMelsecILPiece
    {
        private string m_sCommand = string.Empty;
        private string m_sAddress = string.Empty;
        private string m_sRoutine = string.Empty;
        private string m_sUDL = string.Empty;

        private CMelsecILLine m_cILLine = null;
        private bool m_bLoad = false;

        private EMILType m_emILType = EMILType.NONE;

        #region Initialize/Dispose

        public CMelsecILPiece(CMelsecILLine ILLine, string sUDLCommand)//Change
        {
            m_cILLine = ILLine;

            if (CMelsecILType.IsContactIL(ILLine.Command))
                m_emILType = EMILType.CONTACT;
            else if (CMelsecILType.IsConnenctionIL(ILLine.Command))
                m_emILType = EMILType.CONNECT;
            else if (CMelsecILType.IsConnenctionOperationIL(ILLine.Command))
                m_emILType = EMILType.CONNECT_OPERATION;
            else if (CMelsecILType.IsRoutineControlIL(ILLine.Command))
                m_emILType = EMILType.ROUTINE;
            else
                m_emILType = EMILType.COIL;

            m_sCommand = sUDLCommand;

            if (!CMelsecILType.IsConnenctionIL(m_sCommand))
                CreateUDLFormat();
        }

        #endregion

        #region Properties

        public EMILType ILType
        {
            get { return m_emILType; }
            set { m_emILType = value; }
        }

        public string Command
        {
            get { return m_sCommand; }
            set { m_sCommand = value; }
        }

        public string Address
        {
            get { return m_sAddress; }
            set { m_sAddress = value; }
        }

        public string Routine
        {
            get { return m_sRoutine; }
            set { m_sRoutine = value; }
        }

        public string UDL
        {
            get { return m_sUDL; }
            set { m_sUDL = value; }
        }

        public CMelsecILLine ILLine
        {
            get { return m_cILLine; }
            set { m_cILLine = value; }
        }

        public bool CheckLoad
        {
            get { return m_bLoad; }
            set { m_bLoad = value; }
        }

        #endregion

        #region Public Methods

        #endregion


        #region Private Methods

        private void CreateUDLFormat()
        {
            List<string> ListUsedAddress = m_cILLine.ListAddress;
            m_sAddress = string.Empty;

            for (int i = 0; i < ListUsedAddress.Count; i++)
            {
                if (ListUsedAddress[i] != string.Empty)
                {
                    m_sAddress += ListUsedAddress[i];
                    m_sAddress += ",";
                }
            }

            if(m_sAddress != string.Empty)
                m_sAddress = m_sAddress.Remove(m_sAddress.Length - 1);

            m_sUDL = string.Format("{0}({1})", m_sCommand, m_sAddress);
        }

        #endregion
    }
}
