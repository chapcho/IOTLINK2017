using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UDM.General.Serialize
{
    public class CNetSerializer : IDisposable
    {

        #region Member Variables



        #endregion


        #region Intialize/Dispose

        public CNetSerializer()
        {

        }

        public void Dispose()
        {

        }


        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public bool Write(string sPath, object oData)
        {
            bool bOK = false;

            Stream pStream = null;

            try
            {
                IFormatter pFormatter = new BinaryFormatter();
                pStream = new FileStream(sPath, FileMode.Create, FileAccess.Write, FileShare.None);
                pFormatter.Serialize(pStream, oData);
                bOK = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (pStream != null)
                {
                    pStream.Close();
                    pStream.Dispose();
                    pStream = null;
                }
            }

            return bOK;
        }

        public object Read(string sPath)
        {
            object oData = null;

            Stream pStream = null;

            try
            {
                pStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.None);
                IFormatter pFormatter = new BinaryFormatter();

                oData = pFormatter.Deserialize(pStream);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                if (pStream != null)
                {
                    pStream.Close();
                    pStream.Dispose();
                    pStream = null;
                }
            }

            return oData;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
