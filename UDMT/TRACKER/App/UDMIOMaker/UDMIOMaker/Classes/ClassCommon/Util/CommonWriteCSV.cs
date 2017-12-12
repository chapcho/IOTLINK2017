using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewIOMaker.Classes.ClassCommon.Util
{
    public class CommonWriteCSV
    {
        public CommonWriteCSV()
        {

        }

        public void WriteCSV(string fileName, System.Data.DataTable DT)
        {

            try
            {
                FileStream fsOutput = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                StreamWriter srOutput = new StreamWriter(fsOutput, Encoding.GetEncoding(1200));
                StringBuilder str = new StringBuilder();
                foreach (DataRow dr in DT.Rows)
                {
                    foreach (object field in dr.ItemArray)

                        str.Append(string.Format("{0}\t", field));

                    str.Remove(str.Length - 1, 1);

                    str.Append("\r\n");

                }

                str.Remove(str.Length - 2, 2);

                srOutput.WriteLine(str.ToString());

                srOutput.Close();

                fsOutput.Close();

            }
            catch (Exception error)
            {
                throw new Exception(error.Message + " [ " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ] ", error.InnerException);
            }

        }
    }
}
