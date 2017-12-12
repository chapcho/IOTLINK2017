using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTOPApp
{
    public interface IWorker
    {
        void Run();
        void Stop();
        void Reset();
    }
}
