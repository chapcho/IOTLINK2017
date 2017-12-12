using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM.Import.ME.Translator.Define
{
    public abstract class LadderTranslator
    {
        public abstract string LadderTracerInitialize(string symbolFilePath, string sourceFilePath, Int32 headBlockLength);
        public abstract string LadderTracer(string sourceFilePath);
    }
}
