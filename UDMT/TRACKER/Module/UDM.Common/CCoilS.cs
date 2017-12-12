using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]    
    public class CCoilS : List<CCoil>, ITagComposable, IDisposable
    {

        #region Member Variables


        #endregion


        #region Initialize/Dispose

        public CCoilS()
        {

        }

        public void Dispose()
        {
            Clear();
        }

        #endregion


        #region Public Properties

        public string Address
        {
            get { return GetAddresss(); }
        }

        public string Instructions
        {
            get { return GetInstructions(); }
        }

        public int LogCount
        {
            get { return GetLogCount(); }
        }

        public EMDataType DataType
        {
            get { return GetDataType(); }
        }

        public string Description
        {
            get { return GetDescription(); }
        }

        public string Channel
        {
            get { return GetChannel(); }
        }

        #endregion


        #region Public Methods

        public void Compose(CTagS cTagS)
        {
            foreach (CCoil cCoil in this)
            {
                cCoil.Compose(cTagS);
            }
        }

        public void Compose(CRefTagS cRefTagS)
        {
            foreach (CCoil cCoil in this)
            {
                cCoil.Compose(cRefTagS);
            }
        }

        public void ComposeTagRoleS()
        {
            foreach (CCoil cCoil in this)
            {
                cCoil.ComposeTagRoleS();
            }
        }

        public CCoil GetFirstCoil()
        {
            CCoil cCoil = new CCoil();

            if (this.Count > 0)
                cCoil = this.First();

            return cCoil;
        }

        public CCoil GetLastCoil()
        {
            CCoil cCoil = new CCoil();

            if (this.Count > 0)
                cCoil = this.Last();

            return cCoil;
        }

        #endregion


        #region Private Methods

        private string GetAddress(CCoil cCoil)
        {
            if (cCoil.RefTagS.Count == 0)
                return "";

            string sValue = cCoil.RefTagS[0].Address;

            if (sValue == string.Empty || sValue == "")
                sValue = cCoil.RefTagS[0].Name;

            return sValue;
        }

        private string GetDescription(CCoil cCoil)
        {
            if (cCoil.RefTagS.Count == 0)
                return "";

            string sValue = cCoil.RefTagS[0].GetDescription();

            return sValue;
        }

        private string GetChannel(CCoil cCoil)
        {
            if (cCoil.RefTagS.Count == 0)
                return "";

            string sValue = cCoil.RefTagS[0].Channel;

            return sValue;
        }

        private EMDataType GetDataType(CCoil cCoil)
        {
            if (cCoil.RefTagS.Count == 0)
                return EMDataType.None;

            EMDataType emDataType = cCoil.RefTagS[0].DataType;

            return emDataType;
        }

        private EMDataType GetDataType()
        {
            if (this.Count == 0)
                return EMDataType.None;

            EMDataType emDataType = EMDataType.None;

            emDataType = GetDataType(this[0]);

            return emDataType;

        }

        private string GetAddresss()
        {
            if (this.Count == 0)
                return "";

            string sValue = GetAddress(this[0]);

            return sValue;
        }

        private string GetChannel()
        {
            if (this.Count == 0)
                return "";

            string sValue = GetChannel(this[0]);

            return sValue;
        }

        private string GetDescription()
        {
            if (this.Count == 0)
                return "";

            string sValue = GetDescription(this[0]);

            return sValue;
        }

        private string GetInstructions()
        {
            if (this.Count == 0)
                return "";

            string sValue = this[0].Instruction;

            for (int i = 1; i < this.Count; i++)
            {
                sValue += ";" + this[i].Instruction;
            }

            return sValue;
        }

        private int GetLogCount()
        {
            int iCount = 0;

            for (int i = 0; i < this.Count; i++)
            {
                iCount += this[i].LogCount;
            }

            return iCount;
        }

        #endregion
    }
}
