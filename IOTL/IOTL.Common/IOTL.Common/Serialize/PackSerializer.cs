using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using MsgPack;
using MsgPack.Serialization;
using System.IO.Compression;

namespace IOTL.Common.Serialize
{
    public class PackSerializer<T> : IDisposable
    {

        #region Member Variables


        #endregion


        #region Intialize/Dispose

        public PackSerializer()
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

                var serializer = MessagePackSerializer.Get<T>();
                byte[] arrByte = serializer.PackSingleObject(oData);
                byte[] arrByteCompress = CompressByte(arrByte);

                pStream.Write(arrByteCompress, 0, arrByteCompress.Length);

                serializer = null;
                arrByte = null;
                arrByteCompress = null;

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
                byte[] buffer = ReadFullStream(pStream);
                byte[] bufferDeCompress = DecompressByte(buffer);

                var serializer = MessagePackSerializer.Get<T>();
                oData = serializer.UnpackSingleObject(bufferDeCompress);

                serializer = null;
                buffer = null;
                bufferDeCompress = null;
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

        public byte[] ReadFullStream(Stream stream)
        {
            //스트림을 Byte 배열로 변환
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }


        #endregion


        #region Private Methods

        private byte[] DecompressByte(byte[] bytDs)
        {
            MemoryStream inMs = new MemoryStream(bytDs);
            inMs.Seek(0, 0); //스트림으로 가져오기

            //1. 압축객체 생성- 압축 풀기
            DeflateStream zipStream = new DeflateStream(inMs, CompressionMode.Decompress, true);

            //2. 스트림을 Byte 배열로 변환
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[32768];

            while (true)
            {
                int read = zipStream.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                    break;
                ms.Write(buffer, 0, read);
            }

            zipStream.Flush();
            zipStream.Close();

            return ms.ToArray();
        }

        private byte[] CompressByte(byte[] inbyt)
        {
            //1. 데이터 압축
            MemoryStream objStream = new MemoryStream();
            DeflateStream objZS = new DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress);
            objZS.Write(inbyt, 0, inbyt.Length);
            objZS.Flush();
            objZS.Close();

            //2. 데이터 리턴
            return objStream.ToArray();
        }

        #endregion
    }
}
