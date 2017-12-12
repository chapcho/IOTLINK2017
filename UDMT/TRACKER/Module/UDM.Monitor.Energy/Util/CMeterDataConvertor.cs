using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Monitor.Energy
{
    public static class CMeterDataConvertor
    {
        public static float GetFloatValue(byte[] datas)
        {
            float tempFloat = (float)0.0;

            byte[] tempDatas = new byte[4];

            tempDatas[0] = datas[3];
            tempDatas[1] = datas[2];
            tempDatas[2] = datas[1];
            tempDatas[3] = datas[0];

            tempFloat = BitConverter.ToSingle(tempDatas, 0);

            //tempFloat = cValueHelper.Instance.GetFloat(datas);

            return tempFloat;
        }

        public static int GetIntValue(byte[] datas)
        {
            int tempInt = 0;

            byte[] tempDatas = new byte[4];

            tempDatas[0] = datas[3];
            tempDatas[1] = datas[2];
            tempDatas[2] = datas[1];
            tempDatas[3] = datas[0];

            tempInt = BitConverter.ToInt32(tempDatas, 0);

            return tempInt;
        }

        public static short getInt16Value(byte[] datas)
        {
            short tempShort = 0;

            byte[] tempDatas = new byte[2];

            tempDatas[0] = datas[1];
            tempDatas[1] = datas[0];

            tempShort = BitConverter.ToInt16(tempDatas, 0);

            return tempShort;
        }

        public static ushort getUInt16Value(byte[] datas)
        {
            ushort tempShort = 0;

            byte[] tempDatas = new byte[2];

            tempDatas[0] = datas[1];
            tempDatas[1] = datas[0];

            tempShort = BitConverter.ToUInt16(tempDatas, 0);

            return tempShort;
        }
    }
}
