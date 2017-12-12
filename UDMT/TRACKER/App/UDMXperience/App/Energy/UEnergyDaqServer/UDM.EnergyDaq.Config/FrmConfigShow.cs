using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDM.EnergyDaq.Config
{
    public partial class FrmConfigShow : Form
    {
        protected CConfigS m_cConfigS = null;

        public FrmConfigShow(CConfigS configs)
        {
            m_cConfigS = configs;
            InitializeComponent();

            EditConnectType();
            EditModelType();
        }

        #region Private Method

        private void EditConnectType()
        {
            var fields = typeof(EMConnectType).GetFields(BindingFlags.Static | BindingFlags.Public);

            List<string> lstTempListString = new List<string>();

            foreach( var fi in fields)
            {
                lstTempListString.Add(fi.Name);
            }
            string[] tempConnectS = lstTempListString.ToArray();
            this.colConnectType.Items.AddRange(tempConnectS);

            lstTempListString.Clear();
        }

        private void EditModelType()
        {
            var fields = typeof(EMMeterModel).GetFields(BindingFlags.Static | BindingFlags.Public);

            List<string> lstTempListString = new List<string>();

            foreach (var fi in fields)
            {
                lstTempListString.Add(fi.Name);
            }
            string[] tempModelS = lstTempListString.ToArray();
            this.colMeterModel.Items.AddRange(tempModelS);

            lstTempListString.Clear();
        }

        private void ShowConfigSData()
        {
            foreach( CConfig tempConfig in m_cConfigS)
            {
                DataGridViewRow tempRow = new DataGridViewRow();

                tempRow.CreateCells(this.dgvConfigShow);
                tempRow.Cells[0].Value = tempConfig.MeterKey;
            }
        }

        private void MakeEthernetRow(CConfig cconfig,DataGridViewRow tempRow)
        {
            try
            {
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error : {0} [{1}->{2}]", ex.Message, this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name);
                ex.Data.Clear();
            }

        }

        #endregion
    }
}
