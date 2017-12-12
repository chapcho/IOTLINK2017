using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDM.Monitor.Energy
{
    internal static class CAcuRev2000DataTranslator
    {

        #region Initialze/Dispose


        #endregion

        

        #region Public Methods

        public static CEnergyLog TranslatData(CMeterData cDataS)
        {
            CEnergyLog cLog = new CEnergyLog(cDataS.DeviceInfo + cDataS.Time.ToString("yyyyMMddHHmmss.fff"));

            int iCount = cDataS.Data.Length;

            for (int i = 0; i < 88; i = i + 4)
            {
                byte[] data = new byte[4];

                data[0] = cDataS.Data[i];
                data[1] = cDataS.Data[i + 1];
                data[2] = cDataS.Data[i + 2];
                data[3] = cDataS.Data[i + 3];

                switch (i)
                {
                    case 0: cLog.VoltageA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 4: cLog.VoltageB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 8: cLog.VoltageC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 12: cLog.VoltageAB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 16: cLog.VoltageBC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 20: cLog.VoltageCA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 24: cLog.CurrentA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 28: cLog.CurrentB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 32: cLog.CurrentC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 40: cLog.ActiveA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 44: cLog.ActiveB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 48: cLog.ActiveC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 52: cLog.ActiveTotal = CMeterDataConvertor.GetFloatValue(data); break;
                    case 56: cLog.ReactiveA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 60: cLog.ReactiveB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 64: cLog.ReactiveC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 68: cLog.ReactiveTotal = CMeterDataConvertor.GetFloatValue(data); break;
                    case 72: cLog.ApparentA = CMeterDataConvertor.GetFloatValue(data); break;
                    case 76: cLog.ApparentB = CMeterDataConvertor.GetFloatValue(data); break;
                    case 80: cLog.ApparentC = CMeterDataConvertor.GetFloatValue(data); break;
                    case 84: cLog.ApparentTotal = CMeterDataConvertor.GetFloatValue(data); break;
                }
            }

            for (int i = 88; i < 98; i = i + 2)
            {
                byte[] data = new byte[2];

                data[0] = cDataS.Data[i];
                data[1] = cDataS.Data[i + 1];

                switch (i)
                {
                    case 88: cLog.PFa = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                    case 90: cLog.PFb = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                    case 92: cLog.PFc = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                    case 94: cLog.TotalPF = CMeterDataConvertor.getInt16Value(data) * (float)0.001; break;
                    case 96: cLog.Frequency = CMeterDataConvertor.getUInt16Value(data) * (float)0.01; break;
                }
            }

            if (cDataS.Data.Length >= 102)
            {
                byte[] Tempdata = new byte[4];

                Tempdata[0] = cDataS.Data[98];
                Tempdata[1] = cDataS.Data[99];
                Tempdata[2] = cDataS.Data[100];
                Tempdata[3] = cDataS.Data[101];

                cLog.TotalKwh = CMeterDataConvertor.GetIntValue(Tempdata);
            }

            if (cDataS.Data.Length >= 106)
            {
                byte[] Tempdata = new byte[4];

                Tempdata[0] = cDataS.Data[102];
                Tempdata[1] = cDataS.Data[103];
                Tempdata[2] = cDataS.Data[104];
                Tempdata[3] = cDataS.Data[105];

                cLog.TotalKwh = CMeterDataConvertor.GetIntValue(Tempdata);
            }

            return cLog;
        }

        #endregion
    }
}
