using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using NewIOMaker.Enumeration;

namespace NewIOMaker.Classes.ClassCommon.Util
{

    public class CommonLogger
    {
       
        protected DataTable _LogDB = new DataTable();
        protected EMCommonLogType _LogType;

        public CommonLogger(EMCommonLogType LogType)
        {

            _LogType = LogType;
            LoggerType(_LogType);

        }

        public DataTable LogDB
        {
             get { return _LogDB; }
             set { _LogDB = value; }
        }

        protected void LoggerType(EMCommonLogType type)
        {
            if(type == EMCommonLogType.TagMapping)
            {
                _LogDB.Columns.Add("Working Time");
                _LogDB.Columns.Add("Mapping Type");
                _LogDB.Columns.Add("HMI Device");
                _LogDB.Columns.Add("HMI Comment");
            }
            else if(type == EMCommonLogType.IOList)
            {
                _LogDB.Columns.Add("Working Time");
                _LogDB.Columns.Add("Mode");
                _LogDB.Columns.Add("Type");
            }
            else if (type == EMCommonLogType.MutiCopy)
            {

            }
            else if (type == EMCommonLogType.Alarm)
            {

            }
            else if (type == EMCommonLogType.Backup)
            {
                _LogDB.Columns.Add("Backup Time");
                _LogDB.Columns.Add("Type");
                _LogDB.Columns.Add("Contents");
            }

        }

    }
}
