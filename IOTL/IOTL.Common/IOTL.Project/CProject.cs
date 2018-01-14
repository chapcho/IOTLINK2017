using IOTL.Common.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTL.Project
{
    [Serializable]
    public class CProject : IDisposable
    {
        public const string ConfigFileName = "IOTLDataManager.ini";

        protected string _compServerIPAddress = string.Empty;
        protected uint _compServerDBPort = 0;
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

        public uint CompServerDBPort
        {
            get { return _compServerDBPort; }
            set { _compServerDBPort = value; }
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

        public bool Save(string sPath)
        {
            bool bOK = false;
            NetSerializer cSerializer = new NetSerializer();

            try
            {
                bOK = cSerializer.Write(sPath + "\\" + ConfigFileName, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}]", ex.Message, System.Reflection.MethodBase.GetCurrentMethod().Name); ex.Data.Clear();
            }
            finally
            {
                cSerializer.Dispose();
                cSerializer = null;
            }

            return bOK;
        }

        public bool Open(string sPath, out CProject savedConfig)
        {
            bool bOK = false;

            string configFilePath = sPath + "\\" + ConfigFileName;

            if (!File.Exists(configFilePath))
            {
                savedConfig = null;
                return false;
            }

            NetSerializer cSerializer = new NetSerializer();
            savedConfig = null;

            try
            {
                savedConfig = (cSerializer.Read(configFilePath)) as CProject;
            }
            catch (Exception ex) { ex.Data.Clear(); }
            finally
            {
                cSerializer.Dispose();
                cSerializer = null;
            }

            if (savedConfig != null)
            {
                bOK = true;
            }
            else
            {
                bOK = false;
            }

            return bOK;
        }
    }
}
