using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace IOTL.Common
{
    public static class ObjectHelper
    {
        public static List<T> Clone<T>(this List<T> originalList) where T : ICloneable
        {
            return originalList.ConvertAll(x => (T)x.Clone());
        }

        public static byte[] DecompressByte(byte[] bytDs)
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

        public static byte[] CompressByte(byte[] inbyt)
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


        public static byte[] ReadFullStream(Stream stream)
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

        public static byte[] ToByteArray(Object obj)
        {
            if (obj != null)
            {
                using (var ms = new MemoryStream())
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }

            return null;
        }

    }
}
