using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDM.EnergyDaq.Config;
using UDM.Log.Energy;

namespace UDM.EnergyDaq.Monitor
{
    public static class CMeterValueTranslator
    {
        public static CEnergyLogS EnergyDataConvertor(CMeterData cData)
        {
            CEnergyLogS lstEnergyLogS = new CEnergyLogS();

            if(cData.DeviceModel == EMMeterModel.Accura3300S)
            {
                CThreePhaseMidData cMidData = CMeterDataConvertor.Accura3300SDataTranslator(cData);
                CEnergyLog tempLog = ThreePhaseMidDataAnalysis(cMidData, cData);

                lstEnergyLogS.Add(tempLog);
            }
            else if(cData.DeviceModel == EMMeterModel.AcuRev2000)
            {
                lstEnergyLogS = CMeterDataConvertor.AcuRev2000DataTranslator(cData);

            }

            return lstEnergyLogS;
        }

        #region Private Methods

        private static CEnergyLog ThreePhaseMidDataAnalysis(CThreePhaseMidData cMidData,CMeterData cData)
        {
            CEnergyLog cTempLog = new CEnergyLog();

            cTempLog.Key = cData.DeviceInfo;
            cTempLog.Time = cData.Time;

            if(cMidData.VoltageAB>0||cMidData.VoltageBC>0||cMidData.VoltageCA>0)
                cTempLog.Voltage = (double)CMeterDataConvertor.FindFloatAveValue(cMidData.VoltageAB, cMidData.VoltageBC, cMidData.VoltageCA);
            else
                cTempLog.Voltage = (double)CMeterDataConvertor.FindFloatAveValue(cMidData.VoltageA, cMidData.VoltageB, cMidData.VoltageC);

            cTempLog.Current = (double)CMeterDataConvertor.FindFloatAveValue(cMidData.CurrentA, cMidData.CurrentB, cMidData.CurrentC);

            cTempLog.Frequency = (double)cMidData.Frequency;
            cTempLog.ActiveAmountPower = (double)cMidData.TotalKwh;
            cTempLog.ReactiveAmountPower = (double)cMidData.TotalKvarh;
            cTempLog.ActivePower = (double)cMidData.ActiveTotal;
            cTempLog.ReactivePower = (double)cMidData.ReactiveTotal;
            cTempLog.ApparentPower = (double)cMidData.ApparentTotal;
            return cTempLog;
        }

        #endregion
    }
}
