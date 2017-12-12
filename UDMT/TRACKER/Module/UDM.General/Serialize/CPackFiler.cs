using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MsgPack;
using MsgPack.Serialization;

namespace UDM.General.Serialize
{
    public class CPackFiler<T> : IDisposable
    {

        #region Member Variables

        

        #endregion


        #region Intialize/Dispose

        public CPackFiler()
        {

        }

        public void Dispose()
        {
            
        }


        #endregion


        #region Public Properties


        #endregion


        #region Public Methods

        public bool Write(string sPath, T oData)
        {
            bool bOK = false;

            Stream pStream = null;

            try
            {
                pStream = new FileStream(sPath, FileMode.Create, FileAccess.Write, FileShare.None);
                var cSerializer = SerializationContext.Default.GetSerializer<T>();
                cSerializer.Pack(pStream, oData);
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

        public T Read(string sPath)
        {
            T oData = default(T);

            Stream pStream = null;

            try
            {
                pStream = new FileStream(sPath, FileMode.Open, FileAccess.Read, FileShare.None);
                var cSerializer = SerializationContext.Default.GetSerializer<T>();

                oData = cSerializer.Unpack(pStream);
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
