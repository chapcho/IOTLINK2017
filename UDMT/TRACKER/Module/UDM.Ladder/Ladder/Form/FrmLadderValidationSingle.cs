using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UDM.Common;

namespace UDM.Ladder
{
    public partial class FrmLadderValidationSingle : Form
    {
        private DataTable m_dtTableValidation = new DataTable();

        public FrmLadderValidationSingle()
        {
            InitializeComponent();
        }

        public void Validate(CStep cStep)
        {
            CValidatorSingle cValidatorSingle = new CValidatorSingle(cStep);

            gridControlMain.DataSource = cValidatorSingle.ResultData;
            gridViewMain.SelectRow(-1);
            labelResult.Text =
                "Result : Total = " + cValidatorSingle.NoData.ToString() +
                "     OK = " + cValidatorSingle.NoMatch.ToString() +
                "     NOT OK = " + cValidatorSingle.NotMatch.ToString() +
                "     -- = " + cValidatorSingle.NotAvailable.ToString();
        }
    }
}
