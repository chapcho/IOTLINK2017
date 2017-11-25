using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Common.DB
{
    public interface IMySQLDBConnect
    {
        #region MySQLDBConfig String
        string DatabaseServerIp { get; set; }
        string InitialDatabaseName { get; set; }
        uint DatabaseServerPort { get; set; }
        string LoginUserID { get; set; }
        string LoginUserPassword { get; set; }
        string DatabaseCharset { get; set; }
        #endregion

        string GetDBConnectionString();
    }
}
