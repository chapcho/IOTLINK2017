using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Project
{
    [Serializable]
    public class CProject : IDisposable
    {
        protected string _compServerIPAddress = string.Empty;
        protected uint _compServerTcpPort = 0;
        protected string _compServerLogDirectory = string.Empty;
        protected string _CompServerInitialDatabaseName = string.Empty;
        protected string _CompServerDbLoginUserId = string.Empty;
        protected string _CompServerDbLoginUserPw = string.Empty;

        public CProject()
        {

        }

        #region ## Member Properties
        public string CompServerIPAddress
        {
            get { return _compServerIPAddress; }
            set { _compServerIPAddress = value; }
        }

        public uint CompServerTcpPort
        {
            get { return _compServerTcpPort; }
            set { _compServerTcpPort = value; }
        }

        public string CompServerLogDirectory
        {
            get { return _compServerLogDirectory; }
            set { _compServerLogDirectory = value; }
        }

        public string CompServerInitialDatabaseName
        {
            get { return _CompServerInitialDatabaseName; }
            set { _CompServerInitialDatabaseName = value; }
        }

        public string CompServerDBLoginUserId
        {
            get { return _CompServerDbLoginUserId; }
            set { _CompServerDbLoginUserId = value; }
        }

        public string CompServerDBLoginUserPw
        {
            get { return _CompServerDbLoginUserPw; }
            set { _CompServerDbLoginUserPw = value; }
        }

        #endregion

        public void Dispose()
        {
            ClearAll();
        }

        private void ClearAll()
        {
            Console.WriteLine("CProject Class Dispose");
        }
    }
}
