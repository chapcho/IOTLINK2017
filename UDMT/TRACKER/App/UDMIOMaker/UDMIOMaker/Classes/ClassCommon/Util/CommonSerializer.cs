using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Data;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    public class CommonSerializer : IDisposable
    {

        public CommonSerializer()
        {

        }

        public void Dispose()
        {

        }

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
                }
            }

            return oData;
        }

        #endregion
    }
}
