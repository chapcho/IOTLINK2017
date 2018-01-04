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
        protected string _ipAddress = string.Empty;


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
