using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
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

        public static float FindFloatAveValue(float dValue1, float dValue2, float dValue3)
        {
            float dTemp = (float)0.0;

            float total = dValue1 + dValue2 + dValue3;

            dTemp = total / dTemp;

            return dTemp;
        }

        public static double FindDoubleAveValue(double dValue1, double dValue2, double dValue3)
        {
            double dTemp = 0.0;

            double total = dValue1 + dValue2 + dValue3;

            dTemp = total / dTemp;

            return dTemp;
        }

        public static double FindMinDoubleValue(double dValue1, double dValue2, double dValue3)
        {
            double dTemp = dValue1;

            if (dTemp > dValue2)
                dTemp = dValue2;

            if (dTemp > dValue3)
                dTemp = dValue3;

            return dTemp;
        }

        public static double FindMaxDoubleValue(double dValue1, double dValue2, double dValue3)
        {
            double dTemp = dValue1;

            if (dTemp < dValue2)
                dTemp = dValue2;

            if (dTemp < dValue3)
                dTemp = dValue3;

            return dTemp;
        }

        public static CThreePhaseMidData Accura3300SDataTranslator(CMeterData cDataS)
        {
            CThreePhaseMidData cMidLog = new CThreePhaseMidData();

            try
            {
                int iCount = cDataS.Data.Length;

                if (iCount >= 87)
                {
                    for (int i = 0; i < 88; i = i + 4)
                    {
                        byte[] data = new byte[4];

                        data[0] = cDataS.Data[i];
                        data[1] = cDataS.Data[i + 1];
                        data[2] = cDataS.Data[i + 2];
                        data[3] = cDataS.Data[i + 3];

                        switch (i)
                        {
                            case 0: cMidLog.VoltageA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 4: cMidLog.VoltageB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 8: cMidLog.VoltageC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 12: cMidLog.VoltageAB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 16: cMidLog.VoltageBC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 20: cMidLog.VoltageCA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 24: cMidLog.CurrentA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 28: cMidLog.CurrentB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 32: cMidLog.CurrentC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 40: cMidLog.ActiveA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 44: cMidLog.ActiveB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 48: cMidLog.ActiveC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 52: cMidLog.ActiveTotal = CMeterDataConvertor.GetFloatValue(data); break;
                            case 56: cMidLog.ReactiveA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 60: cMidLog.ReactiveB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 64: cMidLog.ReactiveC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 68: cMidLog.ReactiveTotal = CMeterDataConvertor.GetFloatValue(data); break;
                            case 72: cMidLog.ApparentA = CMeterDataConvertor.GetFloatValue(data); break;
                            case 76: cMidLog.ApparentB = CMeterDataConvertor.GetFloatValue(data); break;
                            case 80: cMidLog.ApparentC = CMeterDataConvertor.GetFloatValue(data); break;
                            case 84: cMidLog.ApparentTotal = CMeterDataConvertor.GetFloatValue(data); break;
                        }
                    }
                }

                if(iCount> 96)
                {
                    for(int i=88; i<98;i= i+2)
                    {
                        byte[] data = new byte[2];

                        data[0] = cDataS.Data[i];
                        data[1] = cDataS.Data[i + 1];

                        switch(i)
                        {
                            case 88: cMidLog.PFa = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                            case 90: cMidLog.PFb = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                            case 92: cMidLog.PFc = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                            case 94: cMidLog.TotalPF = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                            case 96: cMidLog.Frequency = CMeterDataConvertor.getUInt16Value(data) * (float)0.01; break;
                        }
                    }
                }

                if(iCount >=102)
                {
                    byte[] data = new byte[4];

                    data[0] = cDataS.Data[98];
                    data[1] = cDataS.Data[99];
                    data[2] = cDataS.Data[100];
                    data[3] = cDataS.Data[101];

                    cMidLog.TotalKwh = CMeterDataConvertor.GetIntValue(data);
                }

                if(iCount>=106)
                {
                    byte[] data = new byte[4];

                    data[0] = cDataS.Data[102];
                    data[1] = cDataS.Data[103];
                    data[2] = cDataS.Data[104];
                    data[3] = cDataS.Data[105];

                    cMidLog.TotalKwh = CMeterDataConvertor.GetIntValue(data);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

            return cMidLog;
        }

        public static CEnergyLogS AcuRev2000DataTranslator(CMeterData cDataS)
        {
            CEnergyLogS cTempData = new CEnergyLogS();



            return cTempData;
        }
    }
}
