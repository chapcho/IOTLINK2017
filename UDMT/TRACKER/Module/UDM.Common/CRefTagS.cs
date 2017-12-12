using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Common
{
    [Serializable]
    public class CRefTagS : CRefKeyS<CTag>
    {

        #region Member Variables


        #endregion


        #region Intialize/Dispose

        public CRefTagS()
        {
            m_lstObject = new CTagS();
        }

        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public CTag GetFirstTag()
        {
            CTag cTag = new CTag();

            if (this.Count > 0)
                cTag = m_lstObject.First().Value;

            return cTag;
        }

        public CTag GetFirstTag(string sAddress)
        {
            CTag cTagFound = null;
            CTag cTag = null;
            for (int i = 0; i < this.Count; i++)
            {
                cTag = m_lstObject.ElementAt(i).Value;
                if (cTag.Address == sAddress)
                {
                    cTagFound = cTag;
                    break;
                }

                if (cTagFound == null && cTag.Name == sAddress)
                {
                    cTagFound = cTag;
                    break;
                }
            }

            return cTagFound;
        }

        public CTag GetLastTag()
        {
            CTag cTag = new CTag();

            if (this.Count > 0)
                cTag = m_lstObject.Last().Value;

            return cTag;
        }

        public CTag GetLastTag(string sAddress)
        {
            CTag cTagFound = null;
            CTag cTag = null;
            for (int i = this.Count - 1; i > -1; i--)
            {
                cTag = m_lstObject.ElementAt(i).Value;
                if (cTag.Address == sAddress)
                {
                    cTagFound = cTag;
                    break;
                }
            }

            return cTagFound;
        }

        public string GetBaseAddress()
        {
            CTag cTag = GetFirstTag();

            string sAddress = string.Empty;

            if (cTag.PLCMaker.Equals(EMPLCMaker.LS) || cTag.PLCMaker.Equals(EMPLCMaker.Rockwell))
            {
                if (cTag.Name != string.Empty)
                    sAddress = cTag.Name;
                else
                    sAddress = cTag.Address;
            }
            else
                sAddress = cTag.Address;

            return sAddress;
        }

        public string GetBaseDescription()
        {
            CTag cTag = GetFirstTag();

            string sDescription = string.Empty;

            if (cTag.Description != string.Empty)
                sDescription = cTag.Description;
            else
                sDescription = cTag.Name;

            return sDescription;
        }

        #endregion


        #region Private Methods


        #endregion

    }
}
