using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace UDM.Import.ME.Translator.Data
{
    [Serializable]
    public class PlcCommandS : Dictionary<string, PlcCommand> 
    {
        public PlcCommandS()
        {
        }

        protected PlcCommandS(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        public bool AddCommand(PlcCommand newCommand)
        {
            PlcCommand plcCommand = new PlcCommand();
            if (!this.TryGetValue(newCommand.HexPrint, out plcCommand))
            {
                this.Add(newCommand.HexPrint, newCommand);
                return true;
            }
            return false;
        }

        public void ReplaceCommand(PlcCommand plcCommand)
        {
            PlcCommand targetCommand = new PlcCommand();
            if (this.TryGetValue(plcCommand.HexPrint, out targetCommand))
            {
                this.Remove(plcCommand.HexPrint);
            }

            this.Add(plcCommand.HexPrint, plcCommand);
        }

        public void SaveIt()
        {
            FileStream fs = new FileStream(@"PlcCommandDic.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }
    }
}
