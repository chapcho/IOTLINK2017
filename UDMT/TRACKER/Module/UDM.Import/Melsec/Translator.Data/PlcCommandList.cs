using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace UDM.Import.ME.Translator.Data
{
    [Serializable]
    public class PlcCommandList : List<PlcCommand>
    {
        public PlcCommandList() { }

        public bool TryGetValue(String cond, out PlcCommand rslt)
        {
            var element = this.Find(e => e.HexPrint == cond);

            if(element != null)
            {
                rslt = (PlcCommand)element;
                return true;
            }
            else
            {
                rslt = null;
                return false;
            }
        }

        public bool AddCommand(PlcCommand newCommand)
        {
            PlcCommand plcCommand = new PlcCommand();

            var element = this.Find(e => e.HexPrint == newCommand.HexPrint);

            try
            {

                if (element != null)
                {
                    this.Remove(element);
                }
                plcCommand = newCommand;

                this.Add(plcCommand);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public void ReplaceCommand(PlcCommand plcCommand)
        {
            PlcCommand targetCommand = new PlcCommand();
            var element = this.Find(e => e.HexPrint == plcCommand.HexPrint);

            try
            {

                if (element != null)
                {
                    this.Remove(element);
                }
                targetCommand = plcCommand;

                this.Add(targetCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void SavePlcCommandList(String sFilePath)
        {
            FileStream fs = new FileStream(sFilePath, FileMode.Create);
            XmlSerializer sf = new XmlSerializer(typeof(PlcCommandList), "PlcCommandList");
            sf.Serialize(fs, this);
            fs.Close();
        }

    }
}
