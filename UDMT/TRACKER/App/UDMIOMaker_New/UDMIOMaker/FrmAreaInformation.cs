using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UDM.Common;

namespace UDMIOMaker
{
    public partial class FrmAreaInformation : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, CBlockView> m_dicBlockView = new Dictionary<string, CBlockView>(); 
        private List<CAreaView> m_lstAreaView = new List<CAreaView>();

        public FrmAreaInformation()
        {
            InitializeComponent();
        }

        private void SetPLCList()
        {
            cboPLCList.Properties.Items.Clear();

            if (CProjectManager.LogicDataS.Count == 0)
                return;

            foreach (var who in CProjectManager.LogicDataS)
            {
                if (!cboPLCList.Properties.Items.Contains(who.Key))
                    cboPLCList.Properties.Items.Add(who.Key);
            }

            cboPLCList.EditValue = CProjectManager.LogicDataS.First().Key;
        }

        private void SetAddressTypeArea(string sPLCName)
        {
            try
            {
                m_dicBlockView.Clear();

                CBlock cBlock;
                CBlockView cBlockView;
                foreach (var who in CProjectManager.LogicDataS[sPLCName].AddressBlockS)
                {
                    cBlock = who.Value;

                    cBlockView = new CBlockView();
                    cBlockView.BlockName = who.Key;
                    cBlockView.StartAddress = cBlock.GetFirstBlockUnit();
                    cBlockView.EndAddress = cBlock.GetLastBlockUnit();

                    m_dicBlockView.Add(who.Key, cBlockView);

                    cBlock = null;
                }
            }
            catch (Exception ex)
            {
                CProjectManager.UpdateSystemMessage("Block View Error", ex.Message);
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private void SetAreaInformation()
        {
            #region Melsec

            CAreaView cView = new CAreaView();
            cView.PLCMaker = "Mitsubishi";
            cView.TypeList = "IO, M, L, B, W";
            cView.NormalRange = "8191 (1FFF)";
            cView.ExtendRange = "16383 (3FFF)";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "Mitsubishi";
            cView.TypeList = "D";
            cView.NormalRange = "8191 (8191.F)";
            cView.ExtendRange = "12287 (12287.F)";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "Mitsubishi";
            cView.TypeList = "T";
            cView.NormalRange = "2047";
            cView.ExtendRange = "2047";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "Mitsubishi";
            cView.TypeList = "C";
            cView.NormalRange = "1023";
            cView.ExtendRange = "1023";
            m_lstAreaView.Add(cView);

            #endregion

            #region Siemens

            cView = new CAreaView();
            cView.PLCMaker = "Siemens";
            cView.TypeList = "IO, M";
            cView.NormalRange = "8191 (8191.7)";
            cView.ExtendRange = "16383 (16383.7)";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "Siemens";
            cView.TypeList = "T, C";
            cView.NormalRange = "8191";
            cView.ExtendRange = "16383";
            m_lstAreaView.Add(cView);

            #endregion

            #region LS

            cView = new CAreaView();
            cView.PLCMaker = "LS";
            cView.TypeList = "P, K";
            cView.NormalRange = "1023F";
            cView.ExtendRange = "2047F";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "LS";
            cView.TypeList = "T, C";
            cView.NormalRange = "1023";
            cView.ExtendRange = "2047";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "LS";
            cView.TypeList = "L";
            cView.NormalRange = "5630";
            cView.ExtendRange = "11263";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "LS";
            cView.TypeList = "N";
            cView.NormalRange = "11263";
            cView.ExtendRange = "21503";
            m_lstAreaView.Add(cView);

            cView = new CAreaView();
            cView.PLCMaker = "LS";
            cView.TypeList = "M, D";
            cView.NormalRange = "12000";
            cView.ExtendRange = "25000";
            m_lstAreaView.Add(cView);

            #endregion

            grdArea.DataSource = m_lstAreaView;
            grdArea.RefreshDataSource();
        }


        private void FrmAreaInformation_Load(object sender, EventArgs e)
        {
            SetPLCList();
            SetAreaInformation();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPLCList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPLCList.EditValue == null)
                return;

            string sPLCName = (string) cboPLCList.EditValue;

            EMPLCMaker emPLCMaker = CProjectManager.LogicDataS[sPLCName].PLCMaker;
            txtMaker.Text = emPLCMaker.ToString();

            grdAddressType.DataSource = null;
            SetAddressTypeArea(sPLCName);

            grdAddressType.DataSource = m_dicBlockView.Values.ToList();
            grdAddressType.RefreshDataSource();
        }
    }

    public class CAreaView
    {
        public string PLCMaker { get; set; }
        public string TypeList { get; set; }
        public string NormalRange { get; set; }
        public string ExtendRange { get; set; }
    }
}