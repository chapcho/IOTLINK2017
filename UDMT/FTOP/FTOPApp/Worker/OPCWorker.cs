using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace FTOPApp
{
    public class OPCWorker
    {
        private DBWorker _dbWorker;
        private List<OPCTag> _tagS;

        public OPCWorker()
        {
            _dbWorker = new DBWorker();
            _dbWorker.Connect();
        }

        public List<OPCTag> GetTags(EMClientNumber clientNum , int interval , string adapter)
        {
            _tagS = _dbWorker.GetFTOPDBStandard(clientNum, interval, adapter);

            return _tagS;
        }

        public void GenerateOPCWorkXML()
        {
            if (_tagS == null) return;

            var saveDig = new SaveFileDialog();
            saveDig.Filter = "owx files for OPCWorkX (*.owx)|*.owx|All files (*.*)|*.*";

            if (saveDig.ShowDialog() == DialogResult.OK)
            {

            }

        }
    }
}
