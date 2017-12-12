using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UDM.Log;

namespace UDM.Monitor.Energy
{
    public class CMeterValueTranslator:IDisposable
    {
        protected EMMeterModule m_emMeterModel = EMMeterModule.Accura3300S;
        protected CMeterValueTranslator m_cInstance = null;

        #region Initialze/Dispose

        public CMeterValueTranslator(EMMeterModule ModelName)
        {
            
        }
        public void Dispose()
        {
            m_cInstance = null;
        }
        

        #endregion

        #region Public Preperties

        public EMMeterModule MeterModel
        {
            get { return m_emMeterModel; }
            set { m_emMeterModel = value; }
        }

        public CMeterValueTranslator Instance
        {
            get { return m_cInstance; }
            set { m_cInstance = value; }
        }
        #endregion

        #region Public Methods

        public virtual CEnergyLog TranslatData(CMeterData cDataS)
        {
            Console.WriteLine("This is one exception data in model : {0}, this model didn't have one data block data", m_emMeterModel.ToString());
            return new CEnergyLog();
        }

        public virtual CEnergyLog TranslatData(DateTime ctime , byte[] meterData1,byte[] meterData2)
        {
            Console.WriteLine("This is one exception data in model : {0}, this model didn't have two data block data", m_emMeterModel.ToString());
            return new CEnergyLog();
        }

        #endregion


    }
}
