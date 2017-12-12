using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using DevComponents.Tree;

using UDM.Log;
using UDM.Log.Csv;
using UDM.Converter;
using UDM.Common;

namespace UDM.LogicViewer
{
    public class CLogHelper
    {
        #region Member Variables

        #endregion

        #region Initalize/Dispose

        public CLogHelper()
        {

        }



        public void DIspose()
        {

        }

        #endregion

        #region Public Properties

        #endregion

        #region Priate Methods

        private static string GetOffsetAddress(string sAddress)
        {
            string sBaseAddress = sAddress.Split('Z')[0];
            int nOffset = Convert.ToInt32(sAddress.Split('+')[1]);
            string sOffsetAddress = CILSubDataType.GetNextAddress(sBaseAddress, nOffset);

            return sOffsetAddress;
        }


        #endregion

        #region Public Methods

        public static DateTime DateTimeDecimal(Decimal nDateTime)
        {
            DateTime dtTime = DateTime.ParseExact(nDateTime.ToString(), "yyyyMMddHHmmss.fff", System.Globalization.CultureInfo.InvariantCulture);

            return dtTime;
        }

        public static DateTime DateTimeFormatted(string sDateTime)
        {
            DateTime dtTime = DateTime.MinValue;

            if (sDateTime.Contains('/'))
                dtTime = DateTime.ParseExact(sDateTime, "yy/MM/dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
            else if (sDateTime.Contains('.'))
                dtTime = DateTime.ParseExact(sDateTime, "yy.MM.dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);
            else if (sDateTime.Contains('-'))
                dtTime = DateTime.ParseExact(sDateTime, "yy-MM-dd HH:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);


            return dtTime;
        }

        public static string StringFormatted(DateTime dtTime)
        {
            string sDateTime = dtTime.ToString("yyyyMMddHHmmss.fff");


            return sDateTime;
        }

        public static int Integer(string sNumber)
        {
            int iValue = 0;

            try
            {
                double dValue = double.Parse(sNumber);

                iValue = (int)dValue;
            }
            catch (System.Exception ex)
            {
                ex.Data.Clear();
            }

            return iValue;
        }

        public static DataSet CovertDataSet(List<string> ListItem, string strOPC)
        {
            DataSet DS = new DataSet();
            DS.Tables.Add();
            DS.Tables[0].Columns.Add("TIME");
            DS.Tables[0].Columns.Add("TAG");
            DS.Tables[0].Columns.Add("GROUP");
            DS.Tables[0].Columns.Add("KEY");
            DS.Tables[0].Columns.Add("VALUE");

            string strTime = string.Empty;
            string strTag = string.Empty;
            string strGroup = "Group";
            string strKey = "Key";
            string strValue = string.Empty;
            DateTime dateTime = DateTime.Now;


            foreach (string strLog in ListItem)
            {
                strTag = strOPC + "." + strLog.Split(',')[0];
                strTime = CLogHelper.StringFormatted(dateTime.AddMilliseconds(Convert.ToDouble(strLog.Split(',')[1])));
                strValue = strLog.Split(',')[2];

                DS.Tables[0].Rows.Add(strTime, strTag, strGroup, strKey, strValue);
            }


            return DS;
        }


        public static CILSymbol CreateLcEventTag(string sSymbol, string sAddress, string sTime, string sValue)
        {
            CILSymbol cLcSymbol = new CILSymbol(sSymbol, sAddress, string.Empty);
            cLcSymbol.Name = sSymbol;
            cLcSymbol.Address = sAddress;

            if (sTime != string.Empty)
                cLcSymbol.Time = UDM.General.CTypeConverter.ToDateTime(sTime);

            cLcSymbol.Value = UDM.General.CTypeConverter.ToInteger(sValue);

            return cLcSymbol;
        }

        #endregion

    }
}
